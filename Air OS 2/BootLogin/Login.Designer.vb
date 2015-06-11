<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Login
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ExButton1 = New Air_OS2.ExButton()
        Me.version = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 40.0!)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Padding = New System.Windows.Forms.Padding(50, 0, 12, 13)
        Me.Label1.Size = New System.Drawing.Size(959, 197)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Login"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DodgerBlue
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.ForeColor = System.Drawing.Color.White
        Me.Panel1.Location = New System.Drawing.Point(0, 197)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(460, 0, 460, 0)
        Me.Panel1.Size = New System.Drawing.Size(959, 479)
        Me.Panel1.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.ExButton1)
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Controls.Add(Me.TextBox2)
        Me.Panel2.Controls.Add(Me.TextBox1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(460, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(39, 479)
        Me.Panel2.TabIndex = 1
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = Global.Air_OS2.My.Resources.Resources.AirOS_icon
        Me.PictureBox1.Location = New System.Drawing.Point(13, 58)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(14, 182)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'TextBox2
        '
        Me.TextBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox2.Font = New System.Drawing.Font("Segoe UI", 18.0!)
        Me.TextBox2.Location = New System.Drawing.Point(13, 356)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(14, 32)
        Me.TextBox2.TabIndex = 1
        Me.TextBox2.UseSystemPasswordChar = True
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Font = New System.Drawing.Font("Segoe UI", 18.0!)
        Me.TextBox1.Location = New System.Drawing.Point(13, 306)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(14, 32)
        Me.TextBox1.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 15.0!)
        Me.Label2.ForeColor = System.Drawing.Color.DimGray
        Me.Label2.Location = New System.Drawing.Point(0, 733)
        Me.Label2.Name = "Label2"
        Me.Label2.Padding = New System.Windows.Forms.Padding(0, 0, 0, 25)
        Me.Label2.Size = New System.Drawing.Size(959, 49)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Copyright © AirBrowse Technologies 2015"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'ExButton1
        '
        Me.ExButton1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ExButton1.ButtonScheme = Air_OS2.ExButton.ButtonType.Primary
        Me.ExButton1.CenterImage = False
        Me.ExButton1.CornerRadius = 0
        Me.ExButton1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ExButton1.Font = New System.Drawing.Font("Segoe UI", 16.0!)
        Me.ExButton1.ForeColor = System.Drawing.Color.White
        Me.ExButton1.HoverBorder = System.Drawing.Color.Transparent
        Me.ExButton1.HoverColor1 = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ExButton1.HoverColor2 = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ExButton1.IsExtension = False
        Me.ExButton1.Location = New System.Drawing.Point(13, 421)
        Me.ExButton1.MouseDownBorder = System.Drawing.Color.Transparent
        Me.ExButton1.MouseDownColor1 = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(118, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.ExButton1.MouseDownColor2 = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(118, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.ExButton1.Name = "ExButton1"
        Me.ExButton1.NormalBorder = System.Drawing.Color.Transparent
        Me.ExButton1.NormalColor1 = System.Drawing.Color.DodgerBlue
        Me.ExButton1.NormalColor2 = System.Drawing.Color.DodgerBlue
        Me.ExButton1.ScaleImageDown = True
        Me.ExButton1.Size = New System.Drawing.Size(14, 45)
        Me.ExButton1.TabIndex = 3
        Me.ExButton1.Text = "Sign in"
        Me.ExButton1.TextCentered = True
        Me.ExButton1.UserPainted = False
        Me.ExButton1.UseVisualStyleBackColor = True
        '
        'version
        '
        Me.version.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.version.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.version.Font = New System.Drawing.Font("Segoe UI", 15.0!)
        Me.version.ForeColor = System.Drawing.Color.DimGray
        Me.version.Location = New System.Drawing.Point(0, 679)
        Me.version.Name = "version"
        Me.version.Padding = New System.Windows.Forms.Padding(0, 0, 0, 5)
        Me.version.Size = New System.Drawing.Size(959, 54)
        Me.version.TabIndex = 3
        Me.version.Text = "Air OS"
        Me.version.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.BackgroundImage = Global.Air_OS2.My.Resources.Resources.material
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(959, 782)
        Me.Controls.Add(Me.version)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Login"
        Me.Text = "Login"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ExButton1 As Air_OS2.ExButton
    Friend WithEvents version As System.Windows.Forms.Label
End Class
