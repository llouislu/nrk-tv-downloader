Imports System.Xml
Imports System.Xml.XPath
Imports System.Net
Imports System.Threading
Public Class Form4
    Private WithEvents MyProcess As Process
    Dim arg As String
    Dim SelectedQuality As RadioButton
    Private Sub Download_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles download.Click
        Try
            MyProcess = New Process
            With MyProcess.StartInfo
                .WorkingDirectory = Form1.savefolder.Text     '"D:\Program Files\php-5.4.24-nts-Win32-VC9-x86\"
                .FileName = Application.StartupPath + "\hdsdump.exe"
                Dim threads As String = " --threads "
                Dim manifest As String = " --manifest "
                Dim useragent As String = " --useragent """ + Form1.UserAgent + """ "
                Dim quality As String = " --quality "
                Dim outfile As String = " --outfile "
                Dim showtime As String = " --showtime "
                Dim fproxy As String = " --fproxy "
                Dim proxy As String = " --proxy "
                If Form1.proxyport.Text = "" Then Form1.proxyport.Text = "80"
                proxy += "http://" + Form1.proxy.Text + ":" + Form1.proxyport.Text + "/"
                arg = threads + dlthreads.Value.ToString _
                + manifest + """" + Form1.vidmanifest.Text + """" _
                + quality + SelectedQuality.Name _
                + useragent _
                + outfile + """" + Form1.vidtitle.Text + ".flv"""
                If useShowtime.Checked Then arg += showtime
                If Form1.proxyforvideo.Checked Then arg += fproxy
                If Form1.proxyforf4m.Checked Then arg += proxy
                .Arguments = arg
                .UseShellExecute = True
                .CreateNoWindow = False
                .WindowStyle = ProcessWindowStyle.Normal
            End With
            MyProcess.Start()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Me.Close()
    End Sub
    Private Sub RadioButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        SelectedQuality = sender
    End Sub

    Private Sub Form4_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ico As Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath)
        Me.Icon = ico
        Try
            Dim i As Integer
            For i = 1 To Form1.quality(0)
                Dim rbtn As New RadioButton
                rbtn.Name = Form1.quality(i).ToString
                rbtn.Visible = True
                rbtn.AutoSize = True
                Select Case Form1.quality(i)
                    Case Is < 250
                        rbtn.Text = Form1.quality(i) & " kbps(lowest)"
                    Case Is < 350
                        rbtn.Text = Form1.quality(i) & " kbps(low)"
                    Case Is < 1000
                        rbtn.Text = Form1.quality(i) & " kbps(medium)"
                    Case Is < 2000
                        rbtn.Text = Form1.quality(i) & " kbps(high)"
                    Case Else
                        rbtn.Text = Form1.quality(i) & " kbps(highest)"
                End Select
                rbtn.Left = 0
                If i = 1 Then
                    rbtn.Top = 5
                Else
                    rbtn.Top = (i - 1) * 30 + 5
                End If
                AddHandler rbtn.Click, AddressOf RadioButton1_Click
                Me.Controls.Add(rbtn)
                Me.Panel1.Controls.Add(rbtn)
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class