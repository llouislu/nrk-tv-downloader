Public Class Form2

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ico As Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath)
        Me.Icon = ico
        TextBox1.Text = Form1.Accept
        CheckBox2.Checked = Form1.AllowAutoRedirect
        TextBox3.Text = Form1.UserAgent
        NumericUpDown4.Value = Form1.Timeout
        ComboBox1.Text = Form1.method
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Form1.Accept = TextBox1.Text
        Form1.AllowAutoRedirect = CheckBox2.Checked
        Form1.UserAgent = TextBox3.Text
        Form1.Timeout = NumericUpDown4.Value
        Form1.method = ComboBox1.Text
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        TextBox1.Text = "*/*"
        CheckBox2.Checked = True
        TextBox3.Text = "Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:27.0) Gecko/20100101 Firefox/27.0"
        NumericUpDown4.Value = 5000
        ComboBox1.Text = "GET"
    End Sub

End Class