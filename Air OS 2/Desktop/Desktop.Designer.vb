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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.time = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.pm = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.MenuPanel = New System.Windows.Forms.Panel()
        Me.AppBar = New System.Windows.Forms.FlowLayoutPanel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.unamelab = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Content = New System.Windows.Forms.Panel()
        Me.Panel2.SuspendLayout()
        Me.MenuPanel.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(34, 584)
        Me.Panel1.TabIndex = 0
        '
        'time
        '
        Me.time.BackColor = System.Drawing.Color.Transparent
        Me.time.Font = New System.Drawing.Font("Segoe UI", 45.0!)
        Me.time.ForeColor = System.Drawing.Color.White
        Me.time.Location = New System.Drawing.Point(8, 8)
        Me.time.Margin = New System.Windows.Forms.Padding(8)
        Me.time.Name = "time"
        Me.time.Size = New System.Drawing.Size(177, 84)
        Me.time.TabIndex = 1
        Me.time.Text = "12:00"
        Me.time.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Panel2.Controls.Add(Me.pm)
        Me.Panel2.Controls.Add(Me.time)
        Me.Panel2.Location = New System.Drawing.Point(786, 473)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(250, 100)
        Me.Panel2.TabIndex = 2
        '
        'pm
        '
        Me.pm.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pm.BackColor = System.Drawing.Color.Transparent
        Me.pm.Font = New System.Drawing.Font("Segoe UI", 25.0!)
        Me.pm.ForeColor = System.Drawing.Color.White
        Me.pm.Location = New System.Drawing.Point(165, 27)
        Me.pm.Margin = New System.Windows.Forms.Padding(8)
        Me.pm.Name = "pm"
        Me.pm.Size = New System.Drawing.Size(77, 65)
        Me.pm.TabIndex = 2
        Me.pm.Text = "PM"
        Me.pm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'MenuPanel
        '
        Me.MenuPanel.BackColor = System.Drawing.Color.WhiteSmoke
        Me.MenuPanel.Controls.Add(Me.AppBar)
        Me.MenuPanel.Controls.Add(Me.Panel3)
        Me.MenuPanel.Controls.Add(Me.Panel4)
        Me.MenuPanel.Location = New System.Drawing.Point(34, 0)
        Me.MenuPanel.Name = "MenuPanel"
        Me.MenuPanel.Padding = New System.Windows.Forms.Padding(1)
        Me.MenuPanel.Size = New System.Drawing.Size(234, 309)
        Me.MenuPanel.TabIndex = 3
        '
        'AppBar
        '
        Me.AppBar.BackColor = System.Drawing.Color.White
        Me.AppBar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AppBar.Location = New System.Drawing.Point(1, 29)
        Me.AppBar.Margin = New System.Windows.Forms.Padding(0)
        Me.AppBar.Name = "AppBar"
        Me.AppBar.Size = New System.Drawing.Size(232, 251)
        Me.AppBar.TabIndex = 4
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.Controls.Add(Me.unamelab)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(1, 280)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(232, 28)
        Me.Panel3.TabIndex = 6
        '
        'unamelab
        '
        Me.unamelab.Dock = System.Windows.Forms.DockStyle.Right
        Me.unamelab.Font = New System.Drawing.Font("Open Sans", 10.0!, System.Drawing.FontStyle.Bold)
        Me.unamelab.ForeColor = System.Drawing.Color.Gray
        Me.unamelab.Location = New System.Drawing.Point(26, 0)
        Me.unamelab.Name = "unamelab"
        Me.unamelab.Size = New System.Drawing.Size(206, 28)
        Me.unamelab.TabIndex = 0
        Me.unamelab.Text = "USERNAME"
        Me.unamelab.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(1, 1)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.Panel4.Size = New System.Drawing.Size(232, 28)
        Me.Panel4.TabIndex = 5
        '
        'Content
        '
        Me.Content.BackColor = System.Drawing.Color.Transparent
        Me.Content.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Content.Location = New System.Drawing.Point(34, 0)
        Me.Content.Name = "Content"
        Me.Content.Size = New System.Drawing.Size(1014, 584)
        Me.Content.TabIndex = 4
        '
        'Desktop
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackgroundImage = Global.Air_OS2.My.Resources.Resources.material
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1048, 584)
        Me.Controls.Add(Me.MenuPanel)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Content)
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Desktop"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Desktop"
        Me.Panel2.ResumeLayout(False)
        Me.MenuPanel.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents time As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents pm As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents MenuPanel As System.Windows.Forms.Panel
    Friend WithEvents AppBar As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents unamelab As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Content As System.Windows.Forms.Panel
End Class