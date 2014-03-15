Imports System
Imports System.IO
Imports System.Net
Imports System.xml
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Threading
'parameter for threading
Public Structure param ' the parameter to the "xml2srt" thread
    Public inputfilepath As String
    Public outputfilepath As String
End Structure
Public Structure getpageoption
    Public mode As Byte
    Public useproxy As Boolean
    Public webproxy As WebProxy
    Public webproxyurl As String
    Public url As String
    Public xmlpath As String
End Structure
Public Structure videoinfo
    Public title As String
    Public vidmanifest As String
    Public sublink As String
End Structure
Public Class Form1
    'thread
    Private Delegate Sub callgetpagethread()
    Private Delegate Sub hideform3()
    Private Delegate Sub form1update(ByVal videoinfo As videoinfo)
    Private Delegate Sub VoidShow(ByRef i As Int32) 'pass i to form3 to show progress
    Dim mythread As Thread
    Dim htmlpage As String ' web page store for threading
    Dim result As String 'Regexcheck result match value
    Dim myvideoinfo As videoinfo 'title, manifest link and sublink
    ' HttpWebRequest options
    Public Accept As String = "*/*"
    Public AllowAutoRedirect As Boolean = True
    Public UserAgent As String = "Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:27.0) Gecko/20100101 Firefox/27.0"
    Public Timeout As Integer = 15000
    Public method As String = "GET"
    Public hdcore As String = "2.7.6"
    'quality
    Public quality(8) As Integer '{count,bitratevalue1,bitratevalue2,bitratevalue3,...,...,bitratevalue x}
    Private Function regexcheck(ByVal Regex As String, ByVal match As String, ByRef result As String) As Boolean
        Try
            Dim r As Regex = New Regex(Regex)
            Dim m As Match = r.Match(match)
            If m.Success Then
                regexcheck = True 'Matched
            Else
                If Regex = "http://(.*).f4m" Then
                    result = "Fail to Get Manifest Link!"
                    MsgBox("Fail to get manifest link! Please input a correct video play page url and click ""Get Manifest"" or ""Quick Download""", _
                                                                                                MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
                    Exit Try
                    Exit Function
                Else
                    regexcheck = False 'Unmached
                End If
            End If
            result = m.Value
        Catch e As Exception
            MsgBox("ERROR" & Chr(13) & e.Message, MsgBoxStyle.OkOnly)
        End Try
    End Function
    Private Function regexreplace(ByVal Regex As String, ByVal input As String) As String
        Dim r As New Regex(Regex, RegularExpressions.RegexOptions.Multiline + RegularExpressions.RegexOptions.Compiled)
        regexreplace = r.Replace(input, Regex)
    End Function
    Private Function getpage(ByVal URL As String, ByVal viaproxy As Boolean, ByVal mode As Byte) As String
        If Form3.Visible = False Then Form3.Show()
        Form3.Label2.Text = "Downloading " + URL + vbCrLf + "This may take a while..."
        '==============
        'mode
        '0=test proxy
        '1=download to memory and parse links
        '2=save xml subtitle
        '==============
        Try
            mythread = New Thread(AddressOf GetPageThread)
            mythread.Name = "getpage"
            Dim proxyurl As String = ""
            Dim mygetpageoption As getpageoption = Nothing
            mygetpageoption.url = URL
            mygetpageoption.mode = mode

            ' if using proxy
            If viaproxy = True Then
                Dim myProxy As New WebProxy()
                If proxyport.Text = "" Then proxyport.Text = "80"
                proxyurl = "http://" + proxy.Text + ":" + proxyport.Text + "/"
                myProxy.Address = New Uri(proxyurl)
                'myProxy.Credentials = New NetworkCredential("username", "password")

                'if downloading xml subtitle
                If mode = 2 Then
                    Dim xmlpath As String = savefolder.Text
                    Dim exp As String = "(?<=http://tv.nrk.no/programsubtitles/)(.*)"
                    regexcheck(exp, sublink.Text, result)
                    xmlpath = xmlpath + result + ".xml"
                    mygetpageoption.xmlpath = xmlpath
                End If
                'if testing  proxy
                If mode = 0 Then
                    'download synchronously without a thread
                    Dim hwrequest As Net.HttpWebRequest = Net.WebRequest.Create(URL)
                    hwrequest.Proxy = myProxy
                    hwrequest.Accept = Accept
                    hwrequest.AllowAutoRedirect = AllowAutoRedirect
                    hwrequest.UserAgent = UserAgent
                    hwrequest.Timeout = Timeout
                    hwrequest.Method = method
                    Dim hwresponse As Net.HttpWebResponse = hwrequest.GetResponse()
                    If hwresponse.StatusCode = Net.HttpStatusCode.OK Then
                        Dim responseStream As IO.StreamReader = New IO.StreamReader(hwresponse.GetResponseStream())
                        htmlpage = responseStream.ReadToEnd()
                        Return htmlpage
                        Exit Function
                    End If
                End If
                mygetpageoption.useproxy = True
                mygetpageoption.webproxy = myProxy
                mygetpageoption.webproxyurl = proxyurl
            Else
                ' if not using proxy
                mygetpageoption.useproxy = False
                mygetpageoption.webproxy = Nothing
                mygetpageoption.webproxyurl = Nothing
            End If
            mythread.Start(mygetpageoption)
            Return htmlpage
        Catch e As Exception
            MsgBox("[ERROR]" & e.Message)
        End Try
        Return ""
    End Function
    Private Sub GetPageThread(ByVal obj As Object)
        Dim optionreceiver As getpageoption
        optionreceiver = CType(obj, getpageoption)
        Try
            'receive data
            Dim hwrequest As Net.HttpWebRequest = Net.WebRequest.Create(optionreceiver.url)
            If optionreceiver.useproxy = True Then hwrequest.Proxy = optionreceiver.webproxy
            hwrequest.Accept = Accept
            hwrequest.AllowAutoRedirect = AllowAutoRedirect
            hwrequest.UserAgent = UserAgent
            hwrequest.Timeout = Timeout
            hwrequest.Method = method
            Dim hwresponse As Net.HttpWebResponse = hwrequest.GetResponse()
            If hwresponse.StatusCode = Net.HttpStatusCode.OK Then
                Dim responseStream As IO.StreamReader = New IO.StreamReader(hwresponse.GetResponseStream())
                htmlpage = responseStream.ReadToEnd()
            End If
            hwresponse.Close()

            'parse or write to disk
            If optionreceiver.mode = 1 Then
                'Parse the page to get videoinfo
                Dim exp As String 'regex expression to match stuff in the page
                'get video title
                exp = "(?<=<title>)(.*)(?=</title>)"
                regexcheck(exp, htmlpage, result)
                'replace bad characters 
                result = result.Replace("\\", String.Empty)
                result = result.Replace("/", String.Empty)
                result = result.Replace(":", String.Empty)
                result = result.Replace("*", String.Empty)
                result = result.Replace("?", String.Empty)
                result = result.Replace("\", String.Empty)
                result = result.Replace("<", String.Empty)
                result = result.Replace(">", String.Empty)
                result = result.Replace("|", String.Empty)
                result = result.Replace(" ", "_")
                myvideoinfo.title = result
                ' get manifest
                exp = "http://(.*).f4m"
                If regexcheck(exp, htmlpage, result) Then
                    myvideoinfo.vidmanifest = result + "?hdcore=" + hdcore
                End If
                ' get subtitle parameter
                exp = "nrk.programHasSubtitles = (.*);"
                regexcheck(exp, htmlpage, result)
                Dim HasSubtitles As String = result          'store nrk.programHasSubtitles = "True/False";
                ' check sub existence
                exp = "True"
                If Not regexcheck(exp, HasSubtitles, result) Then
                    myvideoinfo.sublink = "Subtitle Unavailable"
                Else
                    ' get sub link
                    exp = "data-subtitlesurl = (.*)\"""
                    regexcheck(exp, htmlpage, result)
                    HasSubtitles = result                           'store data-subtitlesurl = "/programsubtitles/........"
                    exp = "(?<=\"")(.*)(?=\"")"
                    regexcheck(exp, HasSubtitles, result)
                    myvideoinfo.sublink = "http://tv.nrk.no" + result
                End If
                'update videoinfo to Form1
                Me.BeginInvoke(New form1update(AddressOf showvideoinfo), New Object() {myvideoinfo})
            End If
            If optionreceiver.mode = 2 Then
                Dim appendMode As Boolean = False ' This overwrites the entire file.
                Dim sw As New StreamWriter(optionreceiver.xmlpath, appendMode, System.Text.Encoding.UTF8)
                sw.Write(htmlpage)
                sw.Close()
            End If
        Catch e As Exception
            If optionreceiver.useproxy = True Then
                MsgBox("[ERROR]" & e.Message & Chr(13) & "Via Proxy  """ & optionreceiver.webproxyurl & """" & Chr(13) & "With URL """ & optionreceiver.url & """", MsgBoxStyle.OkOnly)
            Else
                MsgBox("[ERROR]" & e.Message & Chr(13) & "With URL """ & optionreceiver.url & """", MsgBoxStyle.OkOnly)
            End If
        Finally
            Me.BeginInvoke(New hideform3(AddressOf form3hide))
        End Try
        mythread.Abort()
    End Sub
    Private Sub form3hide()
        Form3.Visible = False
    End Sub
    Private Sub showvideoinfo(ByVal myvideoinfo As videoinfo)
        vidtitle.Text = myvideoinfo.title
        vidmanifest.Text = myvideoinfo.vidmanifest
        sublink.Text = myvideoinfo.sublink
        If Not myvideoinfo.title = Nothing Then
            GroupBox3.Enabled = True
        Else
            GroupBox3.Enabled = False
        End If
    End Sub
    Private Function ToSrtStr(ByVal input As Integer) As String 'convert millionsecond to hh:mm:ss,mmm
        ToSrtStr = Nothing
        Dim h As Byte, m As Byte, s As Byte, ms As Integer
        h = input \ (60 ^ 2 * 1000)             'hh
        input = input Mod (60 ^ 2 * 1000)  'mm in millionsecond
        m = input \ (60 * 1000)
        input = input Mod (60 * 1000)
        s = input \ 1000
        ms = input Mod 1000

        'construct string
        'Console.WriteLine("hh:" + h.ToString + "mm:" + m.ToString + "ss:" + s.ToString + "mmm:" + ms.ToString)
        'Console.WriteLine(Format(h, "00").ToString)
        ToSrtStr = Format(h, "00").ToString + ":" + Format(m, "00").ToString + ":" + Format(s, "00").ToString + "," + Format(ms, "000").ToString
        Return ToSrtStr
    End Function
    Private Function converttimestr(ByVal input As String) As Integer
        ' initialize
        Dim output(3) As String 'convert time from "xx:xx:xx.xxx" to millionsecond
        converttimestr = 0
        ' regex match "hh:mm:ss,mmm" one by one
        Dim matches As MatchCollection = Regex.Matches(input, "\d+")
        For Each m As Match In matches
            ' Loop over captures.
            Dim i As Byte = 0
            For Each c As Capture In m.Captures
                ' Display.
                'Console.WriteLine("Index={0}, Value={1}", c.Index, c.Value)
                Select Case c.Index
                    Case Is = 0                    'hh
                        output(0) = c.Value
                    Case Is = 3                    'mm
                        output(1) = c.Value
                    Case Is = 6                    'ss
                        output(2) = c.Value
                    Case Is = 9                    'mmm
                        If c.Value.Length = 2 Then
                            output(3) = c.Value + "0" 'handle sth like this "00:00:04.20"
                        Else
                            output(3) = c.Value
                        End If
                End Select
                i = i + 1
            Next
        Next
        Console.WriteLine("hh:" + output(0) + "mm:" + output(1) + "ss:" + output(2) + "mmm:" + output(3))
        ' convert time to millionsecond
        converttimestr = 60 ^ 2 * 1000 * Convert.ToInt32(output(0))                       '+hh
        converttimestr = converttimestr + 60 * 1000 * Convert.ToInt32(output(1))     '+mm
        converttimestr = converttimestr + 1000 * Convert.ToInt32(output(2))            '+ss
        converttimestr = converttimestr + Convert.ToInt32(output(3))                       '+mmm
        Console.WriteLine("millionsecond:" + converttimestr.ToString)
        Return converttimestr
    End Function
    Private Function xml2srt(ByVal inputfilepath As String, ByVal outputfilepath As String) As Boolean
        'xml2srt = False
        If Not Form3.Visible Then Form3.Show()
        mythread = New Thread(AddressOf Xml2SrtThread)
        mythread.Name = "xml2srt"
        Dim para As param
        para.inputfilepath = inputfilepath
        para.outputfilepath = outputfilepath
        mythread.Start(para)
    End Function
    Private Sub srtwriteprogress(ByRef i As Int32)
        Form3.Label2.Text = "Converted " + i.ToString + " lines of subtitle."
    End Sub
    Private Sub srtwritefinshed(ByRef i As Int32)
        Form3.Label2.Text = Form3.Label2.Text + ".....Finished :)"
        MsgBox("Convert Success!", MsgBoxStyle.OkOnly)
        Form3.Close()
    End Sub
    Private Sub Xml2SrtThread(ByVal obj As Object)
        ' get parameter from obj
        Dim arg = CType(obj, param)
        Dim inputfilepath As String = arg.inputfilepath
        Dim outputfilepath As String = arg.outputfilepath
        Try
            ' Write the string as utf-8.
            ' This also writes the 3-byte utf-8 preamble at the beginning of the file.
            Dim stream As New StreamReader(inputfilepath, System.Text.Encoding.UTF8)
            Dim reader As XmlTextReader = New XmlTextReader(stream)

            Dim appendMode As Boolean = False ' This overwrites the entire file.
            Dim sw As New StreamWriter(outputfilepath, appendMode, System.Text.Encoding.UTF8)
            Dim begin As Integer  'sutitle begins at (millionsecond)
            Dim dur As Integer 'sutitle lasts for (millionsecond)
            Dim ends As Integer 'sutitle lasts for (millionsecond)
            Dim i As Integer = 1 ' srt: a numeric counter identifying each sequential subtitle

            ' read xml to convert and write in srt format.
            Do While (reader.Read())
                Select Case reader.NodeType
                    Case XmlNodeType.Element 'Display beginning of element.

                        Select Case reader.Name 'tell which name of the element is: <br>, <p>, whatelse
                            Case Is = "p" 'looking for <p ...> in <p begin="hh:mm:ss,mmm" dur="hh:mm:ss,mmm">subtitle</p>
                                sw.WriteLine(i.ToString)
                                If reader.HasAttributes Then 'attributes exist
                                    'sw.Write("<" + reader.Name)
                                    While reader.MoveToNextAttribute()
                                        'Display attribute name and value.
                                        Select Case reader.Name
                                            Case Is = "begin"  'get start time
                                                begin = converttimestr(reader.Value) 'read begin time as millionsecond
                                            Case Is = "dur"   'get duration
                                                dur = converttimestr(reader.Value) 'read duration time as millionsecond
                                            Case Is = "style"
                                                Exit While 'only for high-end ass subtitle
                                        End Select
                                    End While
                                    ends = begin + dur  'calculate end time in millionsecond
                                    sw.WriteLine(ToSrtStr(begin) + " --> " + ToSrtStr(ends))
                                    'sw.Write(" {0}='{1}'", reader.Name, reader.Value)
                                End If ' finish reading attributes of a tag
                                'sw.Write(">")
                            Case Is = "br" 'handle <br /> tag 
                                sw.Write("\N") 'to do a forced new line in srt
                            Case Else 'everything excluding <p> <br>
                                GoTo nextloop 'not <p>....</p> read the next node
                        End Select

                    Case XmlNodeType.Text 'Display the text in each element.
                        sw.Write(reader.Value) 'subtitle

                    Case XmlNodeType.EndElement 'Display end of element.
                        If Not reader.Name = "p" Then GoTo nextloop 'looking for </p> in <p>....</p>
                        'sw.Write("</" + reader.Name + ">")
                        sw.WriteLine() 'end of a subtitle line
                        sw.WriteLine() 'empty a line(*.srt syntax)
                        Me.BeginInvoke(New VoidShow(AddressOf srtwriteprogress), i) 'pass progress to form3  
                        i = i + 1
                End Select
nextloop:       'There's no "Countinue" in VB.Net. pity, old school way
            Loop
            sw.Close()
            reader.Close()
            Me.BeginInvoke(New VoidShow(AddressOf srtwritefinshed), i) 'pass progress to form3  
            'xml2srt = True
        Catch e As Exception
            'Return False
            MsgBox("ERROR" & Chr(13) & e.Message)
        End Try
        mythread.Abort()
    End Sub
    Private Sub getmanifest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles getmanifest.Click
        'Initialize
        vidmanifest.Text = Nothing
        sublink.Text = Nothing
        htmlpage = Nothing
        ' regular expressions
        ' manifest "http://(.*).f4m"
        ' subtitle detect "nrk.programHasSubtitles = (.*);"
        ' subtitlw link "data-subtitlesurl =(.*)\"""

        'get video play page
        Dim page As String = ""
        If proxyforhtml.Checked Then          'proxy switch
            page = getpage(vidpage.Text, True, 1)
        Else
            page = getpage(vidpage.Text, False, 1)
        End If
        '=================
        'here runs the getpagethread called by getpage function
        '=================
        '
    End Sub
    ' tv.nrk.no link check
    Private Sub vidpage_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles vidpage.TextChanged
        If regexcheck("http://(localhost|127.0.0.1|tv.nrk.no/)[^\s]*", vidpage.Text, result) Then
            vidpage.BackColor = Color.PaleGreen
        Else
            vidpage.BackColor = Color.Salmon
        End If
    End Sub
    'proxy switch
    Private Sub useproxy_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles useproxy.CheckedChanged
        If useproxy.Checked = True Then
            GroupBox2.Enabled = True
            proxyforhtml.Checked = True
            proxyforf4m.Checked = True
            proxyforvideo.Checked = True
            proxyforxml.Checked = True
        Else
            proxy.BackColor = SystemColors.Window
            proxyport.BackColor = SystemColors.Window
            GroupBox2.Enabled = False
            proxyforhtml.Checked = False
            proxyforf4m.Checked = False
            proxyforvideo.Checked = False
            proxyforxml.Checked = False
        End If
    End Sub
    'proxy test result echo
    Private Sub testproxy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles testproxy.Click
        If getpage("http://www.msftncsi.com/ncsi.txt", True, True) = "Microsoft NCSI" Then
            testproxy.Text = "Works"
            testproxy.BackColor = Color.PaleGreen
        Else
            testproxy.Text = "Failed"
            testproxy.BackColor = Color.Salmon
        End If
        Timer1.Interval = 3000
        Timer1.Enabled = True
    End Sub
    'proxy test result echo timer
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        testproxy.Text = "Test"
        testproxy.BackColor = Color.Transparent
    End Sub
    'check proxy addr
    Private Sub proxy_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles proxy.TextChanged
        'If regexcheck("[^\s]*", proxy.Text, result) Then
        'proxy.BackColor = Color.PaleGreen
        'Else
        'proxy.BackColor = Color.Salmon
        'End If
    End Sub
    'check proxy port
    Private Sub proxyport_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles proxyport.TextChanged
        If regexcheck("/^[1-9]$|(^[1-9][0-9]$)|(^[1-9][0-9][0-9]$)|(^[1-9][0-9][0-9][0-9]$)|(^[1-6][0-5][0-5][0-3][0-5]$)/", proxyport.Text, result) Then
            proxyport.BackColor = Color.PaleGreen
        Else
            proxyport.BackColor = Color.Salmon
        End If
    End Sub

    'getpage settings
    Private Sub httpsettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles httpsettings.Click
        Form2.Show()
    End Sub
    ' warning
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MsgBox("This software is still very buggy. Data loss at your own RISK!")
        Dim ico As Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath)
        Me.Icon = ico
    End Sub

    Private Sub resetproxy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles resetproxy.Click
        proxy.Text = Nothing
        proxyport.Text = Nothing
        proxy.BackColor = SystemColors.Window
        proxyport.BackColor = SystemColors.Window
        proxyforhtml.Checked = False
        proxyforf4m.Checked = False
        proxyforvideo.Checked = False

    End Sub


    Private Sub about_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles about.Click
        MsgBox("NRK video downloader version 0.1 Beta(This is very buggy!)" & Chr(13) & ".Net Framework 2.0 or higher version Required" & Chr(13) & "Built with Visual Studio 2005" & Chr(13) & "By Louis @larsenlouis")
    End Sub

    Private Sub savetofolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles savetofolder.Click
        FolderBrowserDialog1.ShowDialog()
        FolderBrowserDialog1.ShowNewFolderButton = True
        savefolder.Text = FolderBrowserDialog1.SelectedPath
        Dim exp As String = "[a-z|A-Z]:\\$"
        If regexcheck(exp, FolderBrowserDialog1.SelectedPath, result) Then
            tempfolder.Text = FolderBrowserDialog1.SelectedPath + "Temp"
        Else
            tempfolder.Text = FolderBrowserDialog1.SelectedPath + "\Temp"
        End If
        If tempfolder.Text = "\Temp" Then
            tempfolder.Text = ""
        End If
    End Sub

    Private Sub temptofolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles temptofolder.Click
        FolderBrowserDialog1.ShowDialog()
        FolderBrowserDialog1.ShowNewFolderButton = True
        tempfolder.Text = FolderBrowserDialog1.SelectedPath
    End Sub
    Private Sub savevideo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles savevideo.Click
        'initialize
        Dim i As Integer = 0
        For i = 0 To 8
            quality(i) = Nothing
        Next

        Dim exp As String = "[a-z|A-Z]:\\(.*)"
        If Not regexcheck(exp, savefolder.Text, result) Then
            MsgBox("Invalid save folder path " & Chr(34) & savefolder.Text & Chr(34) & " Please choose a folder!")
            savetofolder_Click(Nothing, Nothing)
        End If
        'Try
        'If Form1.vidmanifest.Text = "" Then MsgBox("Please click 'Get Manifest' first!") : Exit Sub
        Dim hwrequest As Net.HttpWebRequest = Net.WebRequest.Create(vidmanifest.Text)
        Dim manifest As String = ""
        Try
            If proxyforf4m.Checked Then
                Dim myproxy As New WebProxy()
                If proxyport.Text = "" Then proxyport.Text = "80"
                Dim proxyurl As String = ""
                proxyurl = "http://" + proxy.Text + ":" + proxyport.Text + "/"
                myproxy.Address = New Uri(proxyurl)
                'myproxy.credentials = new networkcredential("username", "password")
                hwrequest.Proxy = myproxy
                hwrequest.Accept = Accept
                hwrequest.AllowAutoRedirect = AllowAutoRedirect
                hwrequest.UserAgent = UserAgent
                hwrequest.Timeout = Timeout
                hwrequest.Method = method
            End If
            Dim hwresponse As Net.HttpWebResponse = hwrequest.GetResponse()
            If hwresponse.StatusCode = Net.HttpStatusCode.OK Then
                Dim responsestream As IO.StreamReader = New IO.StreamReader(hwresponse.GetResponseStream())
                manifest = responsestream.ReadToEnd
            End If
            hwresponse.Close()

            'parse the quality(s)
            Dim reader As XmlTextReader = New XmlTextReader(manifest, XmlNodeType.Document, Nothing)
            Dim n As Integer = 1 ' srt: a numeric counter identifying each sequential subtitle

            ' read xml to get quality info
            Do While (reader.Read())
                Select Case reader.NodeType
                    Case XmlNodeType.Element 'Display beginning of element.

                        Select Case reader.Name
                            Case Is = "media" 'looking for <media ...>
                                If reader.HasAttributes Then 'attributes exist
                                    While reader.MoveToNextAttribute()
                                        'Display attribute name and value.
                                        Select Case reader.Name
                                            Case Is = "bitrate"  'get quality
                                                quality(n) = Convert.ToInt32(reader.Value)
                                                n = n + 1
                                            Case Else
                                                Exit While 'skip reading this attribute
                                        End Select
                                    End While
                                End If ' finish reading attributes of a tag
                            Case Else 'skip reading this tag
                                GoTo nextloop 'not <media>....</media> read the next node
                        End Select

                    Case XmlNodeType.Text 'Display the text in each element.

                    Case XmlNodeType.EndElement 'Display end of element.
                End Select
nextloop:       'There's no "Countinue" in VB.Net. pity, old school way
            Loop
            quality(0) = n - 1
            reader.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Form4.Show()
    End Sub

    Private Sub savesubtitle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles savesubtitle.Click
        Dim exp As String = "[a-z|A-Z]:\\(.*)"
        If regexcheck(exp, savefolder.Text, result) Then
            'get xml subtitle
            Dim page As String
            If proxyforxml.Checked Then
                page = getpage(sublink.Text, True, 2)
            Else
                page = getpage(sublink.Text, False, 2)
            End If
            'write to file
            Dim xmlpath As String = savefolder.Text
            exp = "(?<=http://tv.nrk.no/programsubtitles/)(.*)"
            regexcheck(exp, sublink.Text, result)
            xmlpath = xmlpath + result + ".xml"
            Dim appendMode As Boolean = False ' This overwrites the entire file.
            Try
                Dim sw As New StreamWriter(xmlpath, appendMode, System.Text.Encoding.UTF8)
                sw.Write(page)
                sw.Close()
            Catch ex As Exception
                MsgBox("ERROR" & Chr(13) & ex.Message)
            End Try
        Else
            MsgBox("Invalid save folder path " & Chr(34) & savefolder.Text & Chr(34) & " Please choose a folder!")
            savetofolder_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub convertsubtitle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles convertsubtitle.Click
        'check save folder validity
        Dim exp As String = "[a-z|A-Z]:\\(.*)"
        If Not regexcheck(exp, savefolder.Text, result) Then
            MsgBox("Invalid save folder path " & Chr(34) & savefolder.Text & Chr(34) & " Please choose a folder!")
            savetofolder_Click(Nothing, Nothing)
            Exit Sub
        End If
        'check xml subtitle file existence
        'construct xml file path
        Dim xmlpath As String
        Dim srtpath As String
        xmlpath = savefolder.Text
        exp = "(?<=http://tv.nrk.no/programsubtitles/)(.*)"
        regexcheck(exp, sublink.Text, result)
        xmlpath = xmlpath + result + ".xml"
        If System.IO.File.Exists(xmlpath) Then
            'convert xml to srt
            srtpath = savefolder.Text + vidtitle.Text + ".srt"
            'check thread running
            Call xml2srt(xmlpath, srtpath)
        Else
            MsgBox("not found: xml subtitle " & result & ".xml You should download the subtitle first.")
        End If
    End Sub

    Private Sub Form_Closing()
        If mythread.IsAlive Then     'recycle sytem resources
            Dim msg As String
            msg = MsgBox("NRK Video Downloader is still running, exit anyway?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2)
            If msg = "6" Then
                mythread.Abort()
            Else
                Exit Sub
            End If
        End If
    End Sub

    Private Sub savefolder_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles savefolder.TextChanged
        Dim exp As String = "[a-z|A-Z]:\\$"
        If regexcheck(exp, savefolder.Text, result) Then
            tempfolder.Text = savefolder.Text + "Temp"
        Else
            tempfolder.Text = savefolder.Text + "\Temp"
        End If
        If tempfolder.Text = "\Temp" Then
            tempfolder.Text = ""
        End If
    End Sub

    Private Sub proxyforf4m_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles proxyforf4m.CheckedChanged
        'use proxy for video only if using proxyforf4m
        If Not proxyforf4m.Checked Then
            proxyforvideo.Enabled = False
        Else
            proxyforvideo.Enabled = True
        End If

    End Sub
End Class


