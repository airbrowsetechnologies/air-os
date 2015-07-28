<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Desktop
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.AppBar = New System.Windows.Forms.FlowLayoutPanel()
        Me.OSToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.OSBtn = New System.Windows.Forms.PictureBox()
        Me.AppsBtn = New System.Windows.Forms.PictureBox()
        Me.Time = New System.Windows.Forms.Label()
        Me.OSBar = New System.Windows.Forms.Panel()
        Me.Content = New System.Windows.Forms.Panel()
        CType(Me.OSBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AppsBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.OSBar.SuspendLayout()
        Me.SuspendLayout()
        '
        'AppBar
        '
        Me.AppBar.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.AppBar.Dock = System.Windows.Forms.DockStyle.Left
        Me.AppBar.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.AppBar.Location = New System.Drawing.Point(0, 50)
        Me.AppBar.Name = "AppBar"
        Me.AppBar.Size = New System.Drawing.Size(50, 545)
        Me.AppBar.TabIndex = 1
        Me.AppBar.WrapContents = False
        '
        'OSToolTip
        '
        Me.OSToolTip.BackColor = System.Drawing.Color.White
        Me.OSToolTip.ForeColor = System.Drawing.Color.DodgerBlue
        '
        'OSBtn
        '
        Me.OSBtn.BackColor = System.Drawing.Color.Transparent
        Me.OSBtn.Dock = System.Windows.Forms.DockStyle.Left
        Me.OSBtn.Image = Global.Air_OS2.My.Resources.Resources.AirOS_icon
        Me.OSBtn.Location = New System.Drawing.Point(4, 4)
        Me.OSBtn.Name = "OSBtn"
        Me.OSBtn.Padding = New System.Windows.Forms.Padding(10)
        Me.OSBtn.Size = New System.Drawing.Size(56, 42)
        Me.OSBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.OSBtn.TabIndex = 0
        Me.OSBtn.TabStop = False
        '
        'AppsBtn
        '
        Me.AppsBtn.BackColor = System.Drawing.Color.Transparent
        Me.AppsBtn.Dock = System.Windows.Forms.DockStyle.Left
        Me.AppsBtn.Image = Global.Air_OS2.My.Resources.Resources.applauncher
        Me.AppsBtn.Location = New System.Drawing.Point(60, 4)
        Me.AppsBtn.Margin = New System.Windows.Forms.Padding(5)
        Me.AppsBtn.Name = "AppsBtn"
        Me.AppsBtn.Padding = New System.Windows.Forms.Padding(10)
        Me.AppsBtn.Size = New System.Drawing.Size(56, 42)
        Me.AppsBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.AppsBtn.TabIndex = 1
        Me.AppsBtn.TabStop = False
        '
        'Time
        '
        Me.Time.BackColor = System.Drawing.Color.Transparent
        Me.Time.Dock = System.Windows.Forms.DockStyle.Right
        Me.Time.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Time.Location = New System.Drawing.Point(833, 4)
        Me.Time.Name = "Time"
        Me.Time.Size = New System.Drawing.Size(96, 42)
        Me.Time.TabIndex = 2
        Me.Time.Text = "8:00 AM" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "1/1/1970" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Time.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'OSBar
        '
        Me.OSBar.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.OSBar.Controls.Add(Me.Time)
        Me.OSBar.Controls.Add(Me.AppsBtn)
        Me.OSBar.Controls.Add(Me.OSBtn)
        Me.OSBar.Dock = System.Windows.Forms.DockStyle.Top
        Me.OSBar.ForeColor = System.Drawing.Color.White
        Me.OSBar.Location = New System.Drawing.Point(0, 0)
        Me.OSBar.Name = "OSBar"
        Me.OSBar.Padding = New System.Windows.Forms.Padding(4)
        Me.OSBar.Size = New System.Drawing.Size(933, 50)
        Me.OSBar.TabIndex = 2
        '
        'Content
        '
        Me.Content.BackColor = System.Drawing.Color.Transparent
        Me.Content.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Content.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Content.Location = New System.Drawing.Point(50, 50)
        Me.Content.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Content.Name = "Content"
        Me.Content.Size = New System.Drawing.Size(883, 545)
        Me.Content.TabIndex = 0
        '
        'Desktop
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Air_OS2.My.Resources.Resources.material
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(933, 595)
        Me.Controls.Add(Me.Content)
        Me.Controls.Add(Me.AppBar)
        Me.Controls.Add(Me.OSBar)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Desktop"
        Me.Text = "Desktop"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.OSBtn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AppsBtn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.OSBar.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents AppBar As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents OSToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents OSBtn As System.Windows.Forms.PictureBox
    Friend WithEvents AppsBtn As System.Windows.Forms.PictureBox
    Friend WithEvents Time As System.Windows.Forms.Label
    Friend WithEvents OSBar As System.Windows.Forms.Panel
    Friend WithEvents Content As System.Windows.Forms.Panel
End Class
