<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.MyTCPListener1 = New GIGATMS.MyTCPListener(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblPortOpenState = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.lblLedBuzzerActionDescription = New System.Windows.Forms.Label()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtDoorOpenTime = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnOpenDoor = New System.Windows.Forms.Button()
        Me.cmdOpenPort = New System.Windows.Forms.Button()
        Me.cboCommport = New System.Windows.Forms.ComboBox()
        Me.btnClearListView = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnFileDir = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblFilePath = New System.Windows.Forms.Label()
        Me.lvEvent = New System.Windows.Forms.ListView()
        Me.chdDeviceIP = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chdDateTime = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chdCardUID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chdName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lblTimeZone = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnReLink = New System.Windows.Forms.Button()
        Me.txtListenerIP = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtListenerPort = New System.Windows.Forms.TextBox()
        Me.txtView = New System.Windows.Forms.TextBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MyTCPListener1
        '
        Me.MyTCPListener1.ListenAddress = "0.0.0.0:1001"
        Me.MyTCPListener1.MaxConnectionCount = 0
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblPortOpenState)
        Me.GroupBox2.Controls.Add(Me.GroupBox4)
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Controls.Add(Me.cmdOpenPort)
        Me.GroupBox2.Controls.Add(Me.cboCommport)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(3, 371)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(620, 165)
        Me.GroupBox2.TabIndex = 43
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Hardware Control:"
        '
        'lblPortOpenState
        '
        Me.lblPortOpenState.BackColor = System.Drawing.Color.Red
        Me.lblPortOpenState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPortOpenState.Location = New System.Drawing.Point(7, 21)
        Me.lblPortOpenState.Name = "lblPortOpenState"
        Me.lblPortOpenState.Size = New System.Drawing.Size(24, 22)
        Me.lblPortOpenState.TabIndex = 35
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.lblLedBuzzerActionDescription)
        Me.GroupBox4.Controls.Add(Me.Button10)
        Me.GroupBox4.Controls.Add(Me.Button9)
        Me.GroupBox4.Controls.Add(Me.Button8)
        Me.GroupBox4.Controls.Add(Me.Button7)
        Me.GroupBox4.Controls.Add(Me.Button6)
        Me.GroupBox4.Controls.Add(Me.Button5)
        Me.GroupBox4.Controls.Add(Me.Button4)
        Me.GroupBox4.Controls.Add(Me.Button3)
        Me.GroupBox4.Controls.Add(Me.Button2)
        Me.GroupBox4.Controls.Add(Me.Button1)
        Me.GroupBox4.Location = New System.Drawing.Point(304, 50)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(297, 109)
        Me.GroupBox4.TabIndex = 34
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "LED/Buzzer Control:"
        '
        'lblLedBuzzerActionDescription
        '
        Me.lblLedBuzzerActionDescription.AutoSize = True
        Me.lblLedBuzzerActionDescription.Location = New System.Drawing.Point(13, 41)
        Me.lblLedBuzzerActionDescription.Name = "lblLedBuzzerActionDescription"
        Me.lblLedBuzzerActionDescription.Size = New System.Drawing.Size(267, 60)
        Me.lblLedBuzzerActionDescription.TabIndex = 34
        Me.lblLedBuzzerActionDescription.Text = "Command Description Here." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "! Please enable ""Enable LED/Buzzer Command" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Set Contro" &
    "l"" function in the Mifare Reader " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Utility first."
        Me.lblLedBuzzerActionDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button10
        '
        Me.Button10.Location = New System.Drawing.Point(246, 16)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(24, 24)
        Me.Button10.TabIndex = 33
        Me.Button10.Text = "9"
        Me.Button10.UseVisualStyleBackColor = True
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(220, 16)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(24, 24)
        Me.Button9.TabIndex = 33
        Me.Button9.Text = "8"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(194, 16)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(24, 24)
        Me.Button8.TabIndex = 33
        Me.Button8.Text = "7"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(168, 16)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(24, 24)
        Me.Button7.TabIndex = 33
        Me.Button7.Text = "6"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(142, 16)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(24, 24)
        Me.Button6.TabIndex = 33
        Me.Button6.Text = "5"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(116, 16)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(24, 24)
        Me.Button5.TabIndex = 33
        Me.Button5.Text = "4"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(90, 16)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(24, 24)
        Me.Button4.TabIndex = 33
        Me.Button4.Tag = ""
        Me.Button4.Text = "3"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(64, 16)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(24, 24)
        Me.Button3.TabIndex = 33
        Me.Button3.Tag = ""
        Me.Button3.Text = "2"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(38, 16)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(24, 24)
        Me.Button2.TabIndex = 33
        Me.Button2.Tag = ""
        Me.Button2.Text = "1"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 16)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(24, 24)
        Me.Button1.TabIndex = 33
        Me.Button1.Tag = ""
        Me.Button1.Text = "0"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtDoorOpenTime)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.btnOpenDoor)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 50)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(292, 109)
        Me.GroupBox3.TabIndex = 32
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Relay Control:"
        '
        'txtDoorOpenTime
        '
        Me.txtDoorOpenTime.Location = New System.Drawing.Point(15, 42)
        Me.txtDoorOpenTime.Name = "txtDoorOpenTime"
        Me.txtDoorOpenTime.Size = New System.Drawing.Size(132, 21)
        Me.txtDoorOpenTime.TabIndex = 28
        Me.txtDoorOpenTime.Text = "0"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(15, 21)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(132, 15)
        Me.Label6.TabIndex = 29
        Me.Label6.Text = "Period Time (0~255s) :"
        '
        'btnOpenDoor
        '
        Me.btnOpenDoor.Location = New System.Drawing.Point(167, 37)
        Me.btnOpenDoor.Name = "btnOpenDoor"
        Me.btnOpenDoor.Size = New System.Drawing.Size(104, 30)
        Me.btnOpenDoor.TabIndex = 27
        Me.btnOpenDoor.Text = "Open Door"
        Me.btnOpenDoor.UseVisualStyleBackColor = True
        '
        'cmdOpenPort
        '
        Me.cmdOpenPort.Location = New System.Drawing.Point(516, 20)
        Me.cmdOpenPort.Name = "cmdOpenPort"
        Me.cmdOpenPort.Size = New System.Drawing.Size(91, 27)
        Me.cmdOpenPort.TabIndex = 31
        Me.cmdOpenPort.Text = "Open Port"
        Me.cmdOpenPort.UseVisualStyleBackColor = True
        '
        'cboCommport
        '
        Me.cboCommport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCommport.FormattingEnabled = True
        Me.cboCommport.Location = New System.Drawing.Point(32, 21)
        Me.cboCommport.Name = "cboCommport"
        Me.cboCommport.Size = New System.Drawing.Size(478, 23)
        Me.cboCommport.TabIndex = 30
        '
        'btnClearListView
        '
        Me.btnClearListView.Image = Global.EthernetReader.My.Resources.Resources.delete2
        Me.btnClearListView.Location = New System.Drawing.Point(596, 1)
        Me.btnClearListView.Name = "btnClearListView"
        Me.btnClearListView.Size = New System.Drawing.Size(27, 25)
        Me.btnClearListView.TabIndex = 42
        Me.btnClearListView.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnFileDir)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.lblFilePath)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 327)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(620, 38)
        Me.GroupBox1.TabIndex = 41
        Me.GroupBox1.TabStop = False
        '
        'btnFileDir
        '
        Me.btnFileDir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFileDir.Location = New System.Drawing.Point(584, 11)
        Me.btnFileDir.Name = "btnFileDir"
        Me.btnFileDir.Size = New System.Drawing.Size(30, 21)
        Me.btnFileDir.TabIndex = 27
        Me.btnFileDir.Text = "..."
        Me.btnFileDir.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnFileDir.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(4, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(126, 15)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "Auto Save Records to:"
        '
        'lblFilePath
        '
        Me.lblFilePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFilePath.Location = New System.Drawing.Point(136, 14)
        Me.lblFilePath.Name = "lblFilePath"
        Me.lblFilePath.Size = New System.Drawing.Size(435, 13)
        Me.lblFilePath.TabIndex = 26
        '
        'lvEvent
        '
        Me.lvEvent.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chdDeviceIP, Me.chdDateTime, Me.chdCardUID, Me.chdName})
        Me.lvEvent.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvEvent.FullRowSelect = True
        Me.lvEvent.GridLines = True
        Me.lvEvent.HideSelection = False
        Me.lvEvent.Location = New System.Drawing.Point(3, 27)
        Me.lvEvent.MultiSelect = False
        Me.lvEvent.Name = "lvEvent"
        Me.lvEvent.Size = New System.Drawing.Size(620, 305)
        Me.lvEvent.TabIndex = 40
        Me.lvEvent.UseCompatibleStateImageBehavior = False
        Me.lvEvent.View = System.Windows.Forms.View.Details
        '
        'chdDeviceIP
        '
        Me.chdDeviceIP.Text = "Device IP"
        Me.chdDeviceIP.Width = 262
        '
        'chdDateTime
        '
        Me.chdDateTime.Text = "Date Time"
        Me.chdDateTime.Width = 110
        '
        'chdCardUID
        '
        Me.chdCardUID.Text = "Card UID"
        Me.chdCardUID.Width = 260
        '
        'chdName
        '
        Me.chdName.Text = "Name"
        Me.chdName.Width = 0
        '
        'lblTimeZone
        '
        Me.lblTimeZone.AutoSize = True
        Me.lblTimeZone.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTimeZone.Location = New System.Drawing.Point(541, 8)
        Me.lblTimeZone.Name = "lblTimeZone"
        Me.lblTimeZone.Size = New System.Drawing.Size(49, 13)
        Me.lblTimeZone.TabIndex = 39
        Me.lblTimeZone.Text = "+xx:xx:xx"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(429, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(107, 13)
        Me.Label3.TabIndex = 38
        Me.Label3.Text = "Local PC Time Zone:"
        '
        'btnReLink
        '
        Me.btnReLink.Image = Global.EthernetReader.My.Resources.Resources.link2
        Me.btnReLink.Location = New System.Drawing.Point(253, 1)
        Me.btnReLink.Name = "btnReLink"
        Me.btnReLink.Size = New System.Drawing.Size(25, 25)
        Me.btnReLink.TabIndex = 37
        Me.btnReLink.UseVisualStyleBackColor = True
        '
        'txtListenerIP
        '
        Me.txtListenerIP.AutoSize = True
        Me.txtListenerIP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtListenerIP.Location = New System.Drawing.Point(24, 8)
        Me.txtListenerIP.Name = "txtListenerIP"
        Me.txtListenerIP.Size = New System.Drawing.Size(76, 13)
        Me.txtListenerIP.TabIndex = 36
        Me.txtListenerIP.Text = "xxx.xxx.xxx.xxx"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(7, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(20, 13)
        Me.Label2.TabIndex = 35
        Me.Label2.Text = "IP:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(173, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "Port:"
        '
        'txtListenerPort
        '
        Me.txtListenerPort.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtListenerPort.Location = New System.Drawing.Point(203, 3)
        Me.txtListenerPort.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtListenerPort.Name = "txtListenerPort"
        Me.txtListenerPort.Size = New System.Drawing.Size(48, 20)
        Me.txtListenerPort.TabIndex = 33
        Me.txtListenerPort.Text = "2165"
        Me.txtListenerPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtView
        '
        Me.txtView.Location = New System.Drawing.Point(631, 27)
        Me.txtView.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtView.Multiline = True
        Me.txtView.Name = "txtView"
        Me.txtView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtView.Size = New System.Drawing.Size(178, 509)
        Me.txtView.TabIndex = 32
        '
        'Timer1
        '
        Me.Timer1.Interval = 300000
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(814, 539)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnClearListView)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lvEvent)
        Me.Controls.Add(Me.lblTimeZone)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnReLink)
        Me.Controls.Add(Me.txtListenerIP)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtListenerPort)
        Me.Controls.Add(Me.txtView)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ethernet Reader Event Server"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MyTCPListener1 As GIGATMS.MyTCPListener
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblPortOpenState As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents lblLedBuzzerActionDescription As System.Windows.Forms.Label
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtDoorOpenTime As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnOpenDoor As System.Windows.Forms.Button
    Friend WithEvents cmdOpenPort As System.Windows.Forms.Button
    Friend WithEvents cboCommport As System.Windows.Forms.ComboBox
    Friend WithEvents btnClearListView As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnFileDir As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblFilePath As System.Windows.Forms.Label
    Friend WithEvents lvEvent As System.Windows.Forms.ListView
    Friend WithEvents chdDeviceIP As System.Windows.Forms.ColumnHeader
    Friend WithEvents chdDateTime As System.Windows.Forms.ColumnHeader
    Friend WithEvents chdCardUID As System.Windows.Forms.ColumnHeader
    Friend WithEvents chdName As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblTimeZone As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnReLink As System.Windows.Forms.Button
    Friend WithEvents txtListenerIP As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents txtListenerPort As System.Windows.Forms.TextBox
    Private WithEvents txtView As System.Windows.Forms.TextBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
End Class
