<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.vidpage = New System.Windows.Forms.TextBox
        Me.proxy = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.temptofolder = New System.Windows.Forms.Button
        Me.tempfolder = New System.Windows.Forms.TextBox
        Me.savetofolder = New System.Windows.Forms.Button
        Me.savefolder = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.getmanifest = New System.Windows.Forms.Button
        Me.httpsettings = New System.Windows.Forms.Button
        Me.convertsubtitle = New System.Windows.Forms.Button
        Me.savesubtitle = New System.Windows.Forms.Button
        Me.savevideo = New System.Windows.Forms.Button
        Me.vidmanifest = New System.Windows.Forms.TextBox
        Me.sublink = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.proxyforxml = New System.Windows.Forms.CheckBox
        Me.proxyport = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.resetproxy = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.proxyforvideo = New System.Windows.Forms.CheckBox
        Me.proxyforf4m = New System.Windows.Forms.CheckBox
        Me.proxyforhtml = New System.Windows.Forms.CheckBox
        Me.testproxy = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.useproxy = New System.Windows.Forms.CheckBox
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.about = New System.Windows.Forms.Button
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.vidtitle = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'vidpage
        '
        Me.vidpage.Location = New System.Drawing.Point(6, 41)
        Me.vidpage.Name = "vidpage"
        Me.vidpage.Size = New System.Drawing.Size(615, 21)
        Me.vidpage.TabIndex = 0
        '
        'proxy
        '
        Me.proxy.Location = New System.Drawing.Point(129, 14)
        Me.proxy.Name = "proxy"
        Me.proxy.Size = New System.Drawing.Size(295, 21)
        Me.proxy.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.temptofolder)
        Me.GroupBox1.Controls.Add(Me.tempfolder)
        Me.GroupBox1.Controls.Add(Me.savetofolder)
        Me.GroupBox1.Controls.Add(Me.savefolder)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.vidpage)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(627, 183)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Download"
        '
        'temptofolder
        '
        Me.temptofolder.Location = New System.Drawing.Point(590, 135)
        Me.temptofolder.Name = "temptofolder"
        Me.temptofolder.Size = New System.Drawing.Size(31, 23)
        Me.temptofolder.TabIndex = 12
        Me.temptofolder.Text = "..."
        Me.temptofolder.UseVisualStyleBackColor = True
        '
        'tempfolder
        '
        Me.tempfolder.Location = New System.Drawing.Point(8, 137)
        Me.tempfolder.Name = "tempfolder"
        Me.tempfolder.Size = New System.Drawing.Size(576, 21)
        Me.tempfolder.TabIndex = 11
        '
        'savetofolder
        '
        Me.savetofolder.Location = New System.Drawing.Point(590, 87)
        Me.savetofolder.Name = "savetofolder"
        Me.savetofolder.Size = New System.Drawing.Size(31, 23)
        Me.savetofolder.TabIndex = 10
        Me.savetofolder.Text = "..."
        Me.savetofolder.UseVisualStyleBackColor = True
        '
        'savefolder
        '
        Me.savefolder.Location = New System.Drawing.Point(8, 89)
        Me.savefolder.Name = "savefolder"
        Me.savefolder.Size = New System.Drawing.Size(576, 21)
        Me.savefolder.TabIndex = 9
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(2, 122)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(137, 12)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Temp Folder:(optional)"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(2, 74)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(95, 12)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Save to Folder:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(2, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(125, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Video Play Page URL:"
        '
        'getmanifest
        '
        Me.getmanifest.Location = New System.Drawing.Point(649, 16)
        Me.getmanifest.Name = "getmanifest"
        Me.getmanifest.Size = New System.Drawing.Size(88, 62)
        Me.getmanifest.TabIndex = 2
        Me.getmanifest.Text = "Get Manifest"
        Me.getmanifest.UseVisualStyleBackColor = True
        '
        'httpsettings
        '
        Me.httpsettings.Location = New System.Drawing.Point(543, 336)
        Me.httpsettings.Name = "httpsettings"
        Me.httpsettings.Size = New System.Drawing.Size(93, 22)
        Me.httpsettings.TabIndex = 6
        Me.httpsettings.Text = "HTTP Settings"
        Me.httpsettings.UseVisualStyleBackColor = True
        '
        'convertsubtitle
        '
        Me.convertsubtitle.Location = New System.Drawing.Point(649, 235)
        Me.convertsubtitle.Name = "convertsubtitle"
        Me.convertsubtitle.Size = New System.Drawing.Size(88, 62)
        Me.convertsubtitle.TabIndex = 5
        Me.convertsubtitle.Text = "Convert Subtitle to .srt"
        Me.convertsubtitle.UseVisualStyleBackColor = True
        '
        'savesubtitle
        '
        Me.savesubtitle.Location = New System.Drawing.Point(649, 162)
        Me.savesubtitle.Name = "savesubtitle"
        Me.savesubtitle.Size = New System.Drawing.Size(88, 62)
        Me.savesubtitle.TabIndex = 4
        Me.savesubtitle.Text = "Save Subtitle"
        Me.savesubtitle.UseVisualStyleBackColor = True
        '
        'savevideo
        '
        Me.savevideo.Location = New System.Drawing.Point(649, 89)
        Me.savevideo.Name = "savevideo"
        Me.savevideo.Size = New System.Drawing.Size(88, 62)
        Me.savevideo.TabIndex = 3
        Me.savevideo.Text = "Save Video"
        Me.savevideo.UseVisualStyleBackColor = True
        '
        'vidmanifest
        '
        Me.vidmanifest.Location = New System.Drawing.Point(8, 56)
        Me.vidmanifest.Name = "vidmanifest"
        Me.vidmanifest.Size = New System.Drawing.Size(615, 21)
        Me.vidmanifest.TabIndex = 3
        '
        'sublink
        '
        Me.sublink.Location = New System.Drawing.Point(8, 95)
        Me.sublink.Name = "sublink"
        Me.sublink.Size = New System.Drawing.Size(615, 21)
        Me.sublink.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 12)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Subtitle Link:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(125, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Video Manifest Link:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.proxyforxml)
        Me.GroupBox2.Controls.Add(Me.proxyport)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.resetproxy)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.proxyforvideo)
        Me.GroupBox2.Controls.Add(Me.proxyforf4m)
        Me.GroupBox2.Controls.Add(Me.proxyforhtml)
        Me.GroupBox2.Controls.Add(Me.testproxy)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.proxy)
        Me.GroupBox2.Enabled = False
        Me.GroupBox2.Location = New System.Drawing.Point(13, 360)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(621, 79)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Proxy Settings"
        '
        'proxyforxml
        '
        Me.proxyforxml.AutoSize = True
        Me.proxyforxml.Location = New System.Drawing.Point(419, 57)
        Me.proxyforxml.Name = "proxyforxml"
        Me.proxyforxml.Size = New System.Drawing.Size(114, 16)
        Me.proxyforxml.TabIndex = 11
        Me.proxyforxml.Text = "Subtitle (.xml)"
        Me.proxyforxml.UseVisualStyleBackColor = True
        '
        'proxyport
        '
        Me.proxyport.Location = New System.Drawing.Point(471, 14)
        Me.proxyport.Name = "proxyport"
        Me.proxyport.Size = New System.Drawing.Size(38, 21)
        Me.proxyport.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(430, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 12)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Port:"
        '
        'resetproxy
        '
        Me.resetproxy.Location = New System.Drawing.Point(539, 50)
        Me.resetproxy.Name = "resetproxy"
        Me.resetproxy.Size = New System.Drawing.Size(75, 23)
        Me.resetproxy.TabIndex = 98
        Me.resetproxy.Text = "Reset"
        Me.resetproxy.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 42)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(119, 12)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Use This Proxy For:"
        '
        'proxyforvideo
        '
        Me.proxyforvideo.AutoSize = True
        Me.proxyforvideo.Location = New System.Drawing.Point(318, 57)
        Me.proxyforvideo.Name = "proxyforvideo"
        Me.proxyforvideo.Size = New System.Drawing.Size(96, 16)
        Me.proxyforvideo.TabIndex = 6
        Me.proxyforvideo.Text = "Video Stream"
        Me.proxyforvideo.UseVisualStyleBackColor = True
        '
        'proxyforf4m
        '
        Me.proxyforf4m.AutoSize = True
        Me.proxyforf4m.Location = New System.Drawing.Point(169, 57)
        Me.proxyforf4m.Name = "proxyforf4m"
        Me.proxyforf4m.Size = New System.Drawing.Size(144, 16)
        Me.proxyforf4m.TabIndex = 5
        Me.proxyforf4m.Text = "Video Manfiest(.f4m)"
        Me.proxyforf4m.UseVisualStyleBackColor = True
        '
        'proxyforhtml
        '
        Me.proxyforhtml.AutoSize = True
        Me.proxyforhtml.Location = New System.Drawing.Point(8, 57)
        Me.proxyforhtml.Name = "proxyforhtml"
        Me.proxyforhtml.Size = New System.Drawing.Size(156, 16)
        Me.proxyforhtml.TabIndex = 4
        Me.proxyforhtml.Text = "Video Play Page(.html)"
        Me.proxyforhtml.UseVisualStyleBackColor = True
        '
        'testproxy
        '
        Me.testproxy.Location = New System.Drawing.Point(539, 12)
        Me.testproxy.Name = "testproxy"
        Me.testproxy.Size = New System.Drawing.Size(75, 23)
        Me.testproxy.TabIndex = 7
        Me.testproxy.Text = "Test"
        Me.testproxy.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(-2, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(131, 12)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Proxy Address:http://"
        '
        'useproxy
        '
        Me.useproxy.AutoSize = True
        Me.useproxy.Location = New System.Drawing.Point(13, 342)
        Me.useproxy.Name = "useproxy"
        Me.useproxy.Size = New System.Drawing.Size(54, 16)
        Me.useproxy.TabIndex = 5
        Me.useproxy.Text = "Proxy"
        Me.useproxy.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        '
        'about
        '
        Me.about.Location = New System.Drawing.Point(653, 367)
        Me.about.Name = "about"
        Me.about.Size = New System.Drawing.Size(75, 23)
        Me.about.TabIndex = 10
        Me.about.Text = "About"
        Me.about.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.vidtitle)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.vidmanifest)
        Me.GroupBox3.Controls.Add(Me.sublink)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Enabled = False
        Me.GroupBox3.Location = New System.Drawing.Point(13, 205)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(627, 129)
        Me.GroupBox3.TabIndex = 13
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Video Info"
        '
        'vidtitle
        '
        Me.vidtitle.Location = New System.Drawing.Point(209, 14)
        Me.vidtitle.Name = "vidtitle"
        Me.vidtitle.Size = New System.Drawing.Size(414, 21)
        Me.vidtitle.TabIndex = 5
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 17)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(197, 12)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "Title(also as target file name):"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(746, 462)
        Me.Controls.Add(Me.getmanifest)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.about)
        Me.Controls.Add(Me.useproxy)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.httpsettings)
        Me.Controls.Add(Me.savevideo)
        Me.Controls.Add(Me.convertsubtitle)
        Me.Controls.Add(Me.savesubtitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "NRK Video Downloader"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents vidpage As System.Windows.Forms.TextBox
    Friend WithEvents proxy As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents testproxy As System.Windows.Forms.Button
    Friend WithEvents httpsettings As System.Windows.Forms.Button
    Friend WithEvents proxyforvideo As System.Windows.Forms.CheckBox
    Friend WithEvents proxyforf4m As System.Windows.Forms.CheckBox
    Friend WithEvents proxyforhtml As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents proxyport As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents resetproxy As System.Windows.Forms.Button
    Friend WithEvents vidmanifest As System.Windows.Forms.TextBox
    Friend WithEvents sublink As System.Windows.Forms.TextBox
    Friend WithEvents useproxy As System.Windows.Forms.CheckBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents about As System.Windows.Forms.Button
    Friend WithEvents proxyforxml As System.Windows.Forms.CheckBox
    Friend WithEvents convertsubtitle As System.Windows.Forms.Button
    Friend WithEvents savesubtitle As System.Windows.Forms.Button
    Friend WithEvents savevideo As System.Windows.Forms.Button
    Friend WithEvents getmanifest As System.Windows.Forms.Button
    Friend WithEvents temptofolder As System.Windows.Forms.Button
    Friend WithEvents tempfolder As System.Windows.Forms.TextBox
    Friend WithEvents savetofolder As System.Windows.Forms.Button
    Friend WithEvents savefolder As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents vidtitle As System.Windows.Forms.TextBox

End Class
