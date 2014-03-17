<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form4
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
        Me.dlthreads = New System.Windows.Forms.NumericUpDown
        Me.Label1 = New System.Windows.Forms.Label
        Me.download = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.useShowtime = New System.Windows.Forms.CheckBox
        CType(Me.dlthreads, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dlthreads
        '
        Me.dlthreads.Location = New System.Drawing.Point(220, 12)
        Me.dlthreads.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.dlthreads.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.dlthreads.Name = "dlthreads"
        Me.dlthreads.Size = New System.Drawing.Size(52, 21)
        Me.dlthreads.TabIndex = 0
        Me.dlthreads.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Threads:"
        '
        'download
        '
        Me.download.Location = New System.Drawing.Point(197, 255)
        Me.download.Name = "download"
        Me.download.Size = New System.Drawing.Size(75, 23)
        Me.download.TabIndex = 2
        Me.download.Text = "Download"
        Me.download.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(39, 80)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(233, 168)
        Me.Panel1.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 12)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Quality:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(155, 12)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Show Downloading Progress"
        '
        'useShowtime
        '
        Me.useShowtime.AutoSize = True
        Me.useShowtime.Location = New System.Drawing.Point(257, 43)
        Me.useShowtime.Name = "useShowtime"
        Me.useShowtime.Size = New System.Drawing.Size(15, 14)
        Me.useShowtime.TabIndex = 13
        Me.useShowtime.UseVisualStyleBackColor = True
        '
        'Form4
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 290)
        Me.Controls.Add(Me.useShowtime)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.download)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dlthreads)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Form4"
        Me.Text = "Save Video"
        CType(Me.dlthreads, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dlthreads As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents download As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents useShowtime As System.Windows.Forms.CheckBox
End Class
