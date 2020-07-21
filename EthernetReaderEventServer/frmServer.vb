Imports VB = Microsoft.VisualBasic
Imports System.Data.SqlClient 'Import SQL Capabilities
Imports System.Configuration


Public Class frmMain
    Private m_iTimeZoneOffset As TimeSpan = GIGATMS.TimeZoneInfo.CurrentTimeZone.StandardUtcOffset

    Public WithEvents m_oERReader As GIGATMS.ERReader
    Private Delegate Sub ShowMsgToTextBoxDelegate(ByVal oTextBox As TextBox, ByVal iMaxTextLength As Integer, ByVal szMessage As String)
    Private m_oShowMsgToTextBox As ShowMsgToTextBoxDelegate = Nothing
    Private m_sLogDirPath As String = "C:\MifareServer\"
    Private m_sToday As String
    Private m_szEnumPortList As String

    Private strConn As String = "Data Source=TOYOTA;Initial Catalog=mifare_buffer;User ID=WCAttendanceUser;password=c0nt41n3r"
    Private strConnJed As String = "Data Source=JEDBURGH;Initial Catalog=mifare_buffer;User ID=WCAttendanceUser;password=c0nt41n3r"
    Private sqlCon As SqlConnection
    Private writeSQL As Boolean
    Private glbServer As String = "_2165"

    Private Function InsertMifareSwipe(ByRef mItem As ListViewItem) As Boolean
        Dim nRows As Integer
        Dim insRec As Boolean
        Dim CardID As String, ReaderId As String, AttendanceTime As Date
        'sqlCon = New SqlConnection(strConn)
        sqlCon = New SqlConnection(strConn)
        CardID = mItem.SubItems(2).Text
        ReaderId = mItem.SubItems(0).Text
        AttendanceTime = DateTime.Parse(mItem.SubItems(1).Text)
        insRec = False
        If writeSQL Then
            Using (sqlCon)
                Dim sqlComm As New SqlCommand()
                sqlComm.Connection = sqlCon
                sqlComm.CommandText = "AttendanceInsertNew"
                sqlComm.CommandType = CommandType.StoredProcedure
                sqlComm.Parameters.AddWithValue("UserCardID", CardID.ToString())
                sqlComm.Parameters.AddWithValue("ReaderID", ReaderId.ToString())
                sqlComm.Parameters.AddWithValue("AttendTime", AttendanceTime)
                sqlCon.Open()
                nRows = sqlComm.ExecuteNonQuery() ' used for Insert / Update queries
                If nRows > 0 Then insRec = True
                InsertMifareSwipe = insRec
            End Using
        Else ' We are not writing to the database because of some issue; will have set writeSQL = false in the config file.
            insRec = True ' Set to true so that we get green light coz we are writing data to a file.
        End If

    End Function

    Private Function CheckMifareCard(ByRef mItem As ListViewItem) As Boolean
        Dim insRec As Boolean
        Dim CardID As String, ReaderId As String, AttendanceTime As Date
        Dim myReader As SqlDataReader ' Used for select queries
        Dim myCommand As SqlCommand
        'sqlCon = New SqlConnection(strConn)
        sqlCon = New SqlConnection(strConn)
        CardID = mItem.SubItems(2).Text
        ReaderId = mItem.SubItems(0).Text
        AttendanceTime = DateTime.Parse(mItem.SubItems(1).Text)
        insRec = False
        Using (sqlCon)
            myCommand = sqlCon.CreateCommand
            myCommand.CommandText = "SELECT Student_ID, CardNum FROM StudentIDMifareID sm where CardNum = '" + CardID + "'"
            sqlCon.Open()
            myReader = myCommand.ExecuteReader
            If myReader.HasRows Then insRec = True ' The user card has been registered
        End Using
        CheckMifareCard = insRec

    End Function


    Private Sub InsertAttendanceRecord(CardID As String, ReaderId As String, AttendanceTime As Date)
        Dim nRows As Integer
        sqlCon = New SqlConnection(strConn)
        Using (sqlCon)
            Dim sqlComm As New SqlCommand()
            sqlComm.Connection = sqlCon
            sqlComm.CommandText = "AttendanceInsert"
            sqlComm.CommandType = CommandType.StoredProcedure
            sqlComm.Parameters.AddWithValue("UserCardID", CardID.ToString())
            sqlComm.Parameters.AddWithValue("ReaderID", ReaderId.ToString())
            sqlComm.Parameters.AddWithValue("AttendTime", AttendanceTime)
            sqlCon.Open()
            nRows = sqlComm.ExecuteNonQuery() ' used for Insert / Update queries

        End Using

    End Sub

    Private Sub ShowMsgToTextBox(ByVal oTextBox As TextBox, ByVal iMaxTextLength As Integer, ByVal szMessage As String)
        Dim szData As String
        Dim l As Integer
        With oTextBox
            szData = .Text
            If .TextLength > iMaxTextLength Then
                szData = oTextBox.Text
                l = InStr(CInt(.TextLength >> 1), szData, vbCrLf)
                If l = 0 Then
                    l = Int(.TextLength >> 1)
                End If
                .Text = Mid(szData, (l + 2))
            End If
            .SelectionStart = .TextLength
            .SelectedText = System.DateTime.Now.ToString("hh:mm:ss ")
            .SelectedText = szMessage
            .SelectedText = vbCr & vbLf
        End With
    End Sub

    Private Sub ShowMsg(ByVal szMeesage As String)
        If m_oShowMsgToTextBox Is Nothing Then
            m_oShowMsgToTextBox = New ShowMsgToTextBoxDelegate(AddressOf ShowMsgToTextBox)
        End If
        Me.BeginInvoke(m_oShowMsgToTextBox, txtView, 4096, szMeesage)
    End Sub

    Private Sub MyTCPListener1_OnServerStatusChanged(ByRef sender As Object, ByVal bIsServerStarted As Boolean) Handles MyTCPListener1.OnServerStatusChanged
        If bIsServerStarted Then
            ShowMsg("Listen OK")
        Else
            ShowMsg("Close OK")
        End If
    End Sub

    Private Sub MyTCPListener1_OnMonitor(ByRef sender As Object, ByVal iMonitorDataType As GIGATMS.MyTCPClient.MonitorConstants, ByRef bytDataBuffer() As Byte) Handles MyTCPListener1.OnMonitor
        Dim szMsg As String
        Dim I As Integer
        Dim szLineHex As String
        Dim szLineASC As String
        Dim iLineLen As Integer
        Dim oTcpClient As GIGATMS.MyTCPClient = CType(sender, GIGATMS.MyTCPClient)
        Const MAX_LINE_CHARS As Integer = 16
        iLineLen = 0
        szLineHex = ""
        szLineASC = ""
        szMsg = ""
        For I = 0 To bytDataBuffer.Length - 1
            If iLineLen > 0 Then
                szLineHex += " "
            End If
            szLineHex += bytDataBuffer(I).ToString("X").PadLeft(2, "0"c)
            If bytDataBuffer(I) >= 32 AndAlso bytDataBuffer(I) <= 127 Then
                szLineASC += ChrW(bytDataBuffer(I))
            Else
                szLineASC += "."c
            End If
            iLineLen += 1
            If iLineLen >= MAX_LINE_CHARS Then
                iLineLen = 0
                szMsg += szLineHex & "   " & szLineASC
                szMsg += vbCr & vbLf
                szLineHex = ""
                szLineASC = ""
            End If
        Next
        If iLineLen > 0 Then
            For I = iLineLen To MAX_LINE_CHARS - 1
                szLineHex += "   "
                szLineASC += " "
            Next
            szMsg += szLineHex & "   " & szLineASC
            szMsg += vbCr & vbLf
            szLineHex = ""
            szLineASC = ""
        End If
        szMsg = oTcpClient.ConnectTo & ": " & iMonitorDataType.ToString() & vbCr & vbLf & szMsg
    End Sub
    Private Delegate Sub OnConnectStatusChangedDelegate(ByRef sender As System.Object, ByVal iStatus As GIGATMS.MyTCPClient.ConnectStatusConstants, ByVal szConnectTo As System.String)
    Private m_oOnConnectStatusChangedDelegate As New OnConnectStatusChangedDelegate(AddressOf OnConnectStatusChanged)
    Private Sub OnConnectStatusChanged(ByRef sender As System.Object, ByVal iStatus As GIGATMS.MyTCPClient.ConnectStatusConstants, ByVal szConnectTo As System.String)
        ' When card swiped code runs in here first
        ' We get a Connected here then
        ' Data is sent which triggers the 'OnDataReceive' function then
        ' We get a disconnect here.
        ShowMsg(iStatus.ToString() & " with " & Convert.ToString(szConnectTo))
    End Sub

    Private Sub MyTCPListener1_OnConnectStatusChanged(ByRef sender As System.Object, ByVal iStatus As GIGATMS.MyTCPClient.ConnectStatusConstants, ByVal szConnectTo As System.String) Handles MyTCPListener1.OnConnectStatusChanged
        ' When card swiped code runs in here first
        ' We get a Connected here then
        ' Data is sent which triggers the 'OnDataReceive' function then
        ' We get a disconnect here.
        Me.BeginInvoke(m_oOnConnectStatusChangedDelegate, sender, iStatus, szConnectTo)
        'ShowMsg(iStatus.ToString() & " with " & Convert.ToString(szConnectTo))
    End Sub

    Private Delegate Sub OnDataReceiveDelegate(ByRef sender As Object, ByVal iBytesToReceive As Integer, ByRef bytDataBuffer() As Byte)
    Private m_oOnDataReceiveDelegate As New OnDataReceiveDelegate(AddressOf OnDataReceive)
    Private Sub MyTCPListener1_OnDataReceive(ByRef sender As Object, ByVal iBytesToReceive As Integer, ByRef bytDataBuffer() As Byte) Handles MyTCPListener1.OnDataReceive
        ShowMsg("ISM - BeginInvoke function triggered")

        Me.BeginInvoke(m_oOnDataReceiveDelegate, sender, iBytesToReceive, bytDataBuffer)
    End Sub

    Private Sub OnDataReceive(ByRef sender As Object, ByVal iBytesToReceive As Integer, ByRef bytDataBuffer() As Byte) ' Handles MyTCPListener1.OnDataReceive
        Dim oTcpClient As GIGATMS.MyTCPClient = CType(sender, GIGATMS.MyTCPClient)
        Dim oClientEventsList As List(Of GIGATMS.ClientEvents)
        Dim oItem As ListViewItem
        Dim bIsEnablePCTime As Boolean
        Dim sDeviceIP As String 'same to client IP.
        Dim sDateTime As String
        Dim sCardUID As String
        Dim sName As String
        Dim szPort As String
        Dim L As Integer
        Dim R As Integer
        Dim I As Integer
        Dim myMsg As String
        Dim bInserted As Boolean
        Dim bExists As Boolean
        bInserted = False
        bExists = False
        Try
            ShowMsg("ISM - Start OnDataReceived function triggered")
            'true:Local PC time; false:Standard UTC time
            bIsEnablePCTime = True

            'get data here.
            oClientEventsList = GIGATMS.ClientEvents.ToClientEventsList(bIsEnablePCTime, True, bytDataBuffer, iBytesToReceive, m_iTimeZoneOffset)

            sDeviceIP = oTcpClient.ConnectTo
            L = InStr(sDeviceIP, ":")
            If L > 0 Then
                sDeviceIP = VB.Left(sDeviceIP, (L - 1))
            End If
            szPort = sDeviceIP
            szPort = "TCP" & szPort
            L = InStr(m_szEnumPortList, vbNullChar & szPort & ":")
            szPort = szPort & ":2167"
            If L > 0 Then
                L += 1
                R = InStr(L, m_szEnumPortList, vbNullChar)
                If R > L Then
                    szPort = Mid(m_szEnumPortList, L, (R - L))
                End If
            End If
            L = InStr(szPort, " ")
            If L > 0 Then
                szPort = VB.Left(szPort, (L - 1))
            End If


            With oClientEventsList

                For I = 0 To (oClientEventsList.Count - 1)
                    With lvEvent
                        ' Remove 250 items when itemcount over 1000.
                        If .Items.Count >= 1000 Then
                            Do While .Items.Count > 750
                                .Items.RemoveAt(0)
                            Loop
                        End If

                        'sDateTime = "" 'Format(oClientEventsList(I).DateTime, m_sDateFormat & " HH:mm:ss")
                        sDateTime = Format(oClientEventsList(I).DateTime, "dd/MM/yyyy HH:mm:ss")
                        sCardUID = oClientEventsList(I).Data
                        sName = oClientEventsList(I).Name

                        'Add data to listview
                        oItem = .Items.Add(sDeviceIP)
                        With oItem
                            .SubItems.Add(sDateTime)
                            .SubItems.Add(sCardUID)
                            .SubItems.Add(sName)
                        End With

                        oItem.Selected = True
                        Try
                            .SelectedItems.Item(I).EnsureVisible() 'errors here if more than 1 item in the client events list.

                        Catch ex As Exception
                            myMsg = "EnsureVisibleError: " + ex.Message
                            SaveErrorToLog(myMsg)
                        End Try

                    End With

                    Call SaveLog(oItem)
                    ShowMsg("ISM - Event From: " & oTcpClient.ConnectTo & ", Time Zone: " & CStr(m_iTimeZoneOffset.ToString) & vbCrLf & .Item(I).ToString() & vbCrLf)

                    ' SJL 27/03/2015 commented out the port open and close
                    ' this stops the card reader from flashing red

                    With (m_oERReader)

                        If .PortOpen Then
                            ' .PortOpen = False
                            'System.Threading.Thread.Sleep(100)
                        End If
                        .PortName = szPort
                        .PortOpen = True
                        ' System.Threading.Thread.Sleep(1500)
                        'If m_oERReader.setLedBuzzer(7) = False Then ' Set reader green and 1 beep
                        'ShowMsg("LED operation failed")
                        'End If

                        bExists = CheckMifareCard(oItem) ' Check the card has been registered
                        If Not bExists Then
                            bInserted = InsertMifareSwipe(oItem) ' Insert the swpe data into the SQL database
                            If bInserted Then

                                If m_oERReader.setLedBuzzer(3) = False Then ' Set reader red 
                                    'ShowMsg("LED operation failed")
                                End If
                                If m_oERReader.setLedBuzzer(5) = False Then ' Set reader beep once 
                                    'ShowMsg("LED operation failed")
                                End If
                                System.Threading.Thread.Sleep(100)
                                If m_oERReader.setLedBuzzer(5) = False Then ' Set reader beep once 
                                    'ShowMsg("LED operation failed")
                                End If
                            Else
                                If m_oERReader.setLedBuzzer(8) = False Then ' Set reader red and 3 beeps
                                    'ShowMsg("LED operation failed")
                                End If
                                System.Threading.Thread.Sleep(10)
                            End If

                        Else
                            bInserted = InsertMifareSwipe(oItem) ' Insert the swpe data into the SQL database
                            If bInserted Then
                                If m_oERReader.setLedBuzzer(7) = False Then ' Set reader green and 1 beep
                                    'ShowMsg("LED operation failed")
                                End If
                                System.Threading.Thread.Sleep(10)
                            Else
                                If m_oERReader.setLedBuzzer(8) = False Then ' Set reader red and 3 beeps
                                    'ShowMsg("LED operation failed")
                                End If
                                System.Threading.Thread.Sleep(10)
                            End If


                        End If

                        .PortOpen = False
                        If .PortOpen Then
                            ShowMsg("LED connection successfully")
                        End If

                    End With
                Next I
            End With
            ShowMsg("ISM - End OnDataReceived function triggered")
        Catch Outer_ex As Exception
            myMsg = "OuterError: " + Outer_ex.Message
            SaveErrorToLog(myMsg)
        End Try
    End Sub

    'This function to save .log file.
    Private Sub SaveLog(ByRef oEventItem As ListViewItem)
        Dim sEventLog As String
        Dim sMyDay As String
        Dim sLogFileName As String
        Dim bIsaNewDay As Boolean
        Dim sMyFilePath As String

        sLogFileName = getLogFileName()

        sMyFilePath = m_sLogDirPath & sLogFileName

        sEventLog = oEventItem.Text & "," & oEventItem.SubItems(2).Text & "," & oEventItem.SubItems(1).Text & ", " & Now().ToString()
        'Call InsertAttendanceRecord(oEventItem.SubItems(2).Text, oEventItem.Text, DateTime.Parse(oEventItem.SubItems(1).Text))
        sMyDay = Format(Now, "dd")
        If m_sToday <> "" Then
            If m_sToday <> sMyDay Then
                m_sToday = sMyDay
                bIsaNewDay = True
            End If
        Else
            m_sToday = sMyDay
            bIsaNewDay = True
        End If

        If bIsaNewDay Then
            ' Call appendFileTitle(sMyFilePath)
        End If

        My.Computer.FileSystem.WriteAllText(sMyFilePath, sEventLog & vbCrLf, True)
    End Sub
    Private Sub SaveErrorToLog(oError As String)
        Dim sEventLog As String
        Dim sMyDay As String
        Dim sLogFileName As String
        Dim bIsaNewDay As Boolean
        Dim sMyFilePath As String

        sLogFileName = getLogFileName()

        sMyFilePath = m_sLogDirPath & sLogFileName

        sMyDay = Format(Now, "dd")
        If m_sToday <> "" Then
            If m_sToday <> sMyDay Then
                m_sToday = sMyDay
                bIsaNewDay = True
            End If
        Else
            m_sToday = sMyDay
            bIsaNewDay = True
        End If

        If bIsaNewDay Then
            Call appendFileTitle(sMyFilePath)
        End If

        My.Computer.FileSystem.WriteAllText(sMyFilePath, oError & vbCrLf, True)
    End Sub
    Private Sub appendFileTitle(ByVal sFilePath As String)
        Dim sString As String

        sString = "Attendance Records" & "," & "List" & "     " & Now.ToString
        My.Computer.FileSystem.WriteAllText(sFilePath, sString & vbCrLf, True)
        sString = " "
        My.Computer.FileSystem.WriteAllText(sFilePath, sString & vbCrLf, True)
        sString = "Device IP " & "," & "Card UID"
        My.Computer.FileSystem.WriteAllText(sFilePath, sString & vbCrLf, True)
        sString = "-------------------" & "," & "--------------------------------"
        My.Computer.FileSystem.WriteAllText(sFilePath, sString & vbCrLf, True)

    End Sub

    Private Function getLogFileName() As String
        Dim sMyYear As String
        Dim sMyMonth As String
        Dim sLogFileName As String

        sMyYear = Format(Now, "yyyy")
        sMyMonth = Format(Now, "MM")

        sLogFileName = sMyYear & "_" & sMyMonth & glbServer & ".log"
        getLogFileName = sLogFileName
    End Function


    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim MeVersion As String
        Dim UtcOffset As TimeSpan = GIGATMS.TimeZoneInfo.CurrentTimeZone.StandardUtcOffset

        writeSQL = System.Configuration.ConfigurationManager.AppSettings("writeSQL")
        ' show S/W version
        With My.Application.Info.Version
            MeVersion = " V" & .Major & "." & .Minor & "R" & .Revision
        End With
        Me.Text = Me.Text & Space$(3) & MeVersion


        txtListenerIP.Text = MyTCPListener1.getListenerIpAddress

        lblTimeZone.Text = UtcOffset.ToString

        'initial Event Server
        Call LinkToListener()

        'initial form's settings
        lblFilePath.Text = m_sLogDirPath
        Call ListAvailableComPorts()
        Timer1.Start()
        Me.Visible = False

    End Sub

    Private Sub btnReLink_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReLink.Click
        Call LinkToListener()
    End Sub

    Private Sub LinkToListener()
        If MyTCPListener1.IsServerStarted Then
            MyTCPListener1.Close()
        Else
            If MyTCPListener1.Listen(CInt(txtListenerPort.Text)) Then
                ShowMsg("Listen Port " & txtListenerPort.Text & " OK.")
            Else
                ShowMsg("Can't listen this port " & txtListenerPort.Text)
            End If
        End If

    End Sub

    Private Sub lvEvent_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvEvent.DoubleClick
        lvEvent.Columns.Clear()
    End Sub

    Private Sub txtView_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtView.DoubleClick
        txtView.Clear()
    End Sub

    Private Sub btnClearListView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearListView.Click
        lvEvent.Items.Clear()
    End Sub

    Private Sub btnOpenDoor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenDoor.Click
        Dim bResult As Boolean
        bResult = OpenDoor()
        If OpenDoor() = False Then
            MsgBox("Open door fail.")
        End If
        Call LedBuzzerEffect(bResult)
    End Sub

    Private Sub LedBuzzerEffect(ByVal bIsOpenDoor As Boolean)
        Dim iSeconds As Integer

        If bIsOpenDoor Then
            Call m_oERReader.setLedBuzzer("7")
            iSeconds = CInt(txtDoorOpenTime.Text) * 1000
            System.Threading.Thread.Sleep(iSeconds)
            Call m_oERReader.setLedBuzzer("0")
        Else
            Call m_oERReader.setLedBuzzer("8")
            iSeconds = 3
            System.Threading.Thread.Sleep(iSeconds)
            Call m_oERReader.setLedBuzzer("0")
        End If
    End Sub

    Private Function OpenDoor() As Boolean
        Dim bResult As Boolean
        Dim sDoorOpenTime As String
        Dim iCount As Integer

        sDoorOpenTime = txtDoorOpenTime.Text
        iCount = Val(sDoorOpenTime)
        If iCount = 0 Then
            OpenDoor = True
            Exit Function
        ElseIf iCount > 255 Then
            iCount = 255
            txtDoorOpenTime.Text = CStr(iCount)
        End If

        If m_oERReader.setRelay(iCount) Then
            bResult = True
        Else
            bResult = False
        End If
        OpenDoor = bResult
    End Function

    Private Sub ListAvailableComPorts()
        Dim szPorts() As String
        m_oERReader = New GIGATMS.ERReader()
        szPorts = m_oERReader.EnumCommPortEx
        cboCommport.Items.AddRange(szPorts)
        m_szEnumPortList = vbNullChar & Join(szPorts, vbNullChar) & vbNullChar

        If cboCommport.Items.Count > 0 Then
            cboCommport.SelectedIndex = 0
        End If
    End Sub

    Private Sub cmdOpenPort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOpenPort.Click
        Dim szPort As String, iType As GIGATMS.ERReader.MachineTypeConstants, iReadModal As GIGATMS.ERReader.ReaderModal
        szPort = cboCommport.Text

        If Microsoft.VisualBasic.Left(szPort, 3) = "COM" Or Microsoft.VisualBasic.Left(szPort, 3) = "TCP" Then
            iType = GIGATMS.ERReader.MachineTypeConstants.Any
            iReadModal = GIGATMS.ERReader.ReaderModal.Any
            If m_oERReader.AutoScan(iType, iReadModal, szPort, True) Then
                ShowMsg("Connect to " & Replace(szPort, vbCrLf, " "))
                lblPortOpenState.BackColor = System.Drawing.Color.Chartreuse
            Else
                MsgBox("Ethernet Reader Connect NG.")
                lblPortOpenState.BackColor = System.Drawing.Color.Red
            End If
        Else
            MsgBox("Please Select Commport.")
            lblPortOpenState.BackColor = System.Drawing.Color.Red
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click, Button3.Click, Button2.Click, Button9.Click, Button8.Click, Button7.Click, Button6.Click, Button5.Click, Button4.Click, Button10.Click
        Dim bResult As Boolean
        Dim sButtonCaption As String

        sButtonCaption = DirectCast((sender), Button).Text

        lblLedBuzzerActionDescription.Text = showLedBuzzerActionDescription(sButtonCaption)

        bResult = m_oERReader.setLedBuzzer(sButtonCaption)
        If bResult = False Then
            MsgBox("Set LED/Buzzer NG.")
        End If

    End Sub

    Private Function showLedBuzzerActionDescription(ByVal sNUMBER As String) As String
        Dim sActionDescription As String
        sActionDescription = "No Action."
        Select Case sNUMBER
            Case "0"
                sActionDescription = "Red and Green LED Off, Buzzer Off."
            Case "1"
                sActionDescription = "Green LED ON."
            Case "2"
                sActionDescription = "Green LED OFF."
            Case "3"
                sActionDescription = "Red LED ON."
            Case "4"
                sActionDescription = "Red LED OFF."
            Case "5"
                sActionDescription = "Buzzer Beep once."
            Case "6"
                sActionDescription = "Buzzer Beep 3 Times."
            Case "7"
                sActionDescription = "Green LED ON with Beep once."
            Case "8"
                sActionDescription = "Red LED ON with Beep 3 Times."
            Case "9"
                sActionDescription = "Red and Green LED ON."
        End Select
        showLedBuzzerActionDescription = sActionDescription
    End Function

    Private Sub btnFileDir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFileDir.Click
        Dim FolderBrowserDialog1 As New FolderBrowserDialog

        With FolderBrowserDialog1
            ' Desktop is the root folder in the dialog.
            .RootFolder = Environment.SpecialFolder.Desktop
            ' Select the directory on entry.
            .SelectedPath = m_sLogDirPath
            ' Prompt the user with a custom message.
            .Description = "Select the log file directory"
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                ' Display the selected folder if the user clicked on the OK button.
                lblFilePath.Text = .SelectedPath
                m_sLogDirPath = lblFilePath.Text.ToString & "\"
            End If
        End With
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick

    End Sub
End Class