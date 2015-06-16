Imports System.Windows.Forms

Public Class AirOSApp
    Inherits System.Windows.Forms.Form
    Friend WithEvents ControlPanel As System.Windows.Forms.Panel
    Private WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ExButton1 As AirOSAppFramework.ExButton
    Friend WithEvents ExButton3 As AirOSAppFramework.ExButton
    Friend WithEvents ExButton2 As AirOSAppFramework.ExButton

    Public Property FormBorderStyle As FormBorderStyle
        Get
            Return Windows.Forms.FormBorderStyle.None
        End Get
        Set(value As FormBorderStyle)

        End Set
    End Property

    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ControlPanel = New System.Windows.Forms.Panel()
        Me.ExButton3 = New AirOSAppFramework.ExButton()
        Me.ExButton2 = New AirOSAppFramework.ExButton()
        Me.ExButton1 = New AirOSAppFramework.ExButton()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DodgerBlue
        Me.Panel1.Controls.Add(Me.ExButton3)
        Me.Panel1.Controls.Add(Me.ExButton2)
        Me.Panel1.Controls.Add(Me.ExButton1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(631, 29)
        Me.Panel1.TabIndex = 0
        '
        'ControlPanel
        '
        Me.ControlPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ControlPanel.Location = New System.Drawing.Point(0, 29)
        Me.ControlPanel.Margin = New System.Windows.Forms.Padding(0)
        Me.ControlPanel.Name = "ControlPanel"
        Me.ControlPanel.Size = New System.Drawing.Size(631, 395)
        Me.ControlPanel.TabIndex = 1
        '
        'ExButton3
        '
        Me.ExButton3.ButtonScheme = AirOSAppFramework.ExButton.ButtonType.Primary
        Me.ExButton3.CenterImage = True
        Me.ExButton3.CornerRadius = 0
        Me.ExButton3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ExButton3.Dock = System.Windows.Forms.DockStyle.Right
        Me.ExButton3.ForeColor = System.Drawing.Color.White
        Me.ExButton3.HoverBorder = System.Drawing.Color.Transparent
        Me.ExButton3.HoverColor1 = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ExButton3.HoverColor2 = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ExButton3.Image = Global.AirOSAppFramework.My.Resources.Resources.winminimize
        Me.ExButton3.Location = New System.Drawing.Point(526, 0)
        Me.ExButton3.MouseDownBorder = System.Drawing.Color.Transparent
        Me.ExButton3.MouseDownColor1 = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(118, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.ExButton3.MouseDownColor2 = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(118, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.ExButton3.Name = "ExButton3"
        Me.ExButton3.NormalBorder = System.Drawing.Color.Transparent
        Me.ExButton3.NormalColor1 = System.Drawing.Color.DodgerBlue
        Me.ExButton3.NormalColor2 = System.Drawing.Color.DodgerBlue
        Me.ExButton3.ScaleImageDown = True
        Me.ExButton3.Size = New System.Drawing.Size(35, 29)
        Me.ExButton3.TabIndex = 2
        Me.ExButton3.TextCentered = True
        Me.ExButton3.UserPainted = False
        Me.ExButton3.UseVisualStyleBackColor = True
        '
        'ExButton2
        '
        Me.ExButton2.ButtonScheme = AirOSAppFramework.ExButton.ButtonType.Primary
        Me.ExButton2.CenterImage = True
        Me.ExButton2.CornerRadius = 0
        Me.ExButton2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ExButton2.Dock = System.Windows.Forms.DockStyle.Right
        Me.ExButton2.ForeColor = System.Drawing.Color.White
        Me.ExButton2.HoverBorder = System.Drawing.Color.Transparent
        Me.ExButton2.HoverColor1 = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ExButton2.HoverColor2 = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ExButton2.Image = Global.AirOSAppFramework.My.Resources.Resources.winmaximize
        Me.ExButton2.Location = New System.Drawing.Point(561, 0)
        Me.ExButton2.MouseDownBorder = System.Drawing.Color.Transparent
        Me.ExButton2.MouseDownColor1 = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(118, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.ExButton2.MouseDownColor2 = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(118, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.ExButton2.Name = "ExButton2"
        Me.ExButton2.NormalBorder = System.Drawing.Color.Transparent
        Me.ExButton2.NormalColor1 = System.Drawing.Color.DodgerBlue
        Me.ExButton2.NormalColor2 = System.Drawing.Color.DodgerBlue
        Me.ExButton2.ScaleImageDown = True
        Me.ExButton2.Size = New System.Drawing.Size(35, 29)
        Me.ExButton2.TabIndex = 1
        Me.ExButton2.TextCentered = True
        Me.ExButton2.UserPainted = False
        Me.ExButton2.UseVisualStyleBackColor = True
        '
        'ExButton1
        '
        Me.ExButton1.ButtonScheme = AirOSAppFramework.ExButton.ButtonType.Primary
        Me.ExButton1.CenterImage = True
        Me.ExButton1.CornerRadius = 0
        Me.ExButton1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ExButton1.Dock = System.Windows.Forms.DockStyle.Right
        Me.ExButton1.ForeColor = System.Drawing.Color.White
        Me.ExButton1.HoverBorder = System.Drawing.Color.Transparent
        Me.ExButton1.HoverColor1 = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ExButton1.HoverColor2 = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ExButton1.Image = Global.AirOSAppFramework.My.Resources.Resources.winclose
        Me.ExButton1.Location = New System.Drawing.Point(596, 0)
        Me.ExButton1.MouseDownBorder = System.Drawing.Color.Transparent
        Me.ExButton1.MouseDownColor1 = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(118, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.ExButton1.MouseDownColor2 = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(118, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.ExButton1.Name = "ExButton1"
        Me.ExButton1.NormalBorder = System.Drawing.Color.Transparent
        Me.ExButton1.NormalColor1 = System.Drawing.Color.DodgerBlue
        Me.ExButton1.NormalColor2 = System.Drawing.Color.DodgerBlue
        Me.ExButton1.ScaleImageDown = False
        Me.ExButton1.Size = New System.Drawing.Size(35, 29)
        Me.ExButton1.TabIndex = 0
        Me.ExButton1.TextCentered = True
        Me.ExButton1.UserPainted = False
        Me.ExButton1.UseVisualStyleBackColor = True
        '
        'AirOSApp
        '
        Me.ClientSize = New System.Drawing.Size(631, 424)
        Me.Controls.Add(Me.ControlPanel)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "AirOSApp"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
End Class
