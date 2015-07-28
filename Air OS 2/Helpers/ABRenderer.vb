Public Class ABRenderer
    'Inherits ToolStripProfessionalRenderer

    'Public Sub New()

    '    MyBase.New(New ABColorTable)
    '    RoundedEdges = False
    'End Sub

    'Protected Overrides Sub OnRenderToolStripBorder(e As ToolStripRenderEventArgs)

    'End Sub



    Inherits ToolStripProfessionalRenderer

    Public Sub New()
        MyBase.New()

        RoundedEdges = False
    End Sub
    Protected Overrides Sub OnRenderMenuItemBackground(e As ToolStripItemRenderEventArgs)
        If e.Item.IsOnDropDown Then
            If e.Item.Selected Then
                If e.Item.Enabled Then
                    e.Graphics.FillRectangle(Brushes.DodgerBlue, New Rectangle(0, 0, e.Item.Width, e.Item.Height))
                Else
                    e.Graphics.DrawRectangle(Pens.DodgerBlue, New Rectangle(1, 0, e.Item.Width - 2, e.Item.Height - 1))
                End If
            End If
        Else
            If e.Item.Selected Then
                e.Graphics.FillRectangle(Brushes.White, New Rectangle(0, 0, e.Item.Width, e.Item.Height))
                e.Graphics.DrawLine(Pens.Silver, 0, 0, e.Item.Width, 0)
                e.Graphics.DrawLine(Pens.Silver, 0, 0, 0, e.Item.Height)
                e.Graphics.DrawLine(Pens.Silver, e.Item.Width - 1, 0, e.Item.Width - 1, e.Item.Height)
                e.Graphics.DrawLine(Pens.Silver, 0, e.Item.Height - 1, e.Item.Width - 1, e.Item.Height - 1)
            End If
        End If
    End Sub

    Protected Overrides Sub OnRenderToolStripBorder(e As ToolStripRenderEventArgs)
        If e.ToolStrip.IsDropDown Then
            e.Graphics.DrawRectangle(Pens.Silver, New Rectangle(0, 0, e.AffectedBounds.Width - 1, e.AffectedBounds.Height - 1))
        End If
    End Sub
    Protected Overrides Sub OnRenderImageMargin(e As ToolStripRenderEventArgs)
        e.Graphics.Clear(Color.White)

    End Sub

    Protected Overrides Sub OnRenderArrow(e As ToolStripArrowRenderEventArgs)
        If e.Item.Selected Then
            e.ArrowColor = Color.White
        Else
            e.ArrowColor = Color.DodgerBlue
        End If
        MyBase.OnRenderArrow(e)
    End Sub

    'Protected Overrides Sub OnRenderToolStripPanelBackground(e As ToolStripPanelRenderEventArgs)
    '    e.Graphics.Clear(Color.White)
    'End Sub
    Protected Overrides Sub OnRenderItemText(e As ToolStripItemTextRenderEventArgs)

        If e.Item.IsOnDropDown Then
            If e.Item.Selected Then
                e.TextColor = Color.White
            Else
                e.TextColor = Color.Black
            End If
        End If
        MyBase.OnRenderItemText(e)
    End Sub






End Class

Public Class ABColorTable
    Inherits ProfessionalColorTable

    Public Overrides ReadOnly Property MenuItemSelectedGradientBegin As Color
        Get
            Return Color.DodgerBlue
        End Get
    End Property

    Public Overrides ReadOnly Property MenuItemSelectedGradientEnd As Color
        Get
            Return Color.DodgerBlue
        End Get
    End Property

    Public Overrides ReadOnly Property MenuItemPressedGradientMiddle As Color
        Get
            Return Color.DodgerBlue
        End Get
    End Property

    Public Overrides ReadOnly Property ToolStripGradientBegin As Color
        Get
            Return Color.WhiteSmoke
        End Get
    End Property

    Public Overrides ReadOnly Property ToolStripGradientMiddle As Color
        Get
            Return Color.WhiteSmoke
        End Get
    End Property

    Public Overrides ReadOnly Property ToolStripGradientEnd As Color
        Get
            Return Color.WhiteSmoke
        End Get
    End Property

    Public Overrides ReadOnly Property ImageMarginGradientBegin As Color
        Get
            Return Color.WhiteSmoke
        End Get
    End Property

    Public Overrides ReadOnly Property ImageMarginGradientMiddle As Color
        Get
            Return Color.WhiteSmoke
        End Get
    End Property

    Public Overrides ReadOnly Property ImageMarginGradientEnd As Color
        Get
            Return Color.WhiteSmoke
        End Get
    End Property

    Public Overrides ReadOnly Property ToolStripDropDownBackground As Color
        Get
            Return Color.WhiteSmoke
        End Get
    End Property

    Public Overrides ReadOnly Property ToolStripBorder As Color
        Get
            Return SystemColors.Control
        End Get
    End Property

    Public Overrides ReadOnly Property MenuItemBorder As Color
        Get
            Return Color.DodgerBlue
        End Get
    End Property

    Public Overrides ReadOnly Property SeparatorLight As Color
        Get
            Return Color.Silver
        End Get
    End Property

    Public Overrides ReadOnly Property SeparatorDark As Color
        Get
            Return Color.Silver
        End Get
    End Property

    Public Overrides ReadOnly Property MenuItemSelected As Color
        Get
            Return AvgColor(SystemColors.Highlight)
        End Get
    End Property

    'Public Overrides ReadOnly Property ButtonSelectedGradientBegin As Color
    '    Get
    '        Return Functions.AvgColor(AppSettings.TabColor)
    '    End Get
    'End Property

    'Public Overrides ReadOnly Property ButtonSelectedGradientend As Color
    '    Get
    '        Return Functions.AvgColor(AppSettings.TabColor)
    '    End Get
    'End Property

    'Public Overrides ReadOnly Property MenuItemPressedGradientBegin As Color
    '    Get
    '        Return Functions.AvgColor(AppSettings.TabColor)
    '    End Get
    'End Property

    'Public Overrides ReadOnly Property MenuItemPressedGradientEnd As Color
    '    Get
    '        Return Functions.AvgColor(AppSettings.TabColor)
    '    End Get
    'End Property

    Public Overrides ReadOnly Property OverflowButtonGradientBegin As Color
        Get
            Return AvgColor(Color.DodgerBlue)
        End Get
    End Property

    Public Overrides ReadOnly Property OverflowButtonGradientEnd As Color
        Get
            Return AvgColor(Color.DodgerBlue)
        End Get
    End Property

    Public Function AvgColor(clr As Color) As Color
        Dim c1 As Color = Color.White
        Dim c2 As Color = clr
        Return Color.FromArgb((CInt(c1.A) + CInt(c2.A)) / 2, (CInt(c1.R) + CInt(c2.R)) / 2, (CInt(c1.G) + CInt(c2.G)) / 2, (CInt(c1.B) + CInt(c2.B)) / 2)
    End Function

    Public Function AvgColor(clr As Color, clr2 As Color) As Color
        Dim c1 As Color = clr
        Dim c2 As Color = clr2
        Return Color.FromArgb((CInt(c1.A) + CInt(c2.A)) / 2, (CInt(c1.R) + CInt(c2.R)) / 2, (CInt(c1.G) + CInt(c2.G)) / 2, (CInt(c1.B) + CInt(c2.B)) / 2)
    End Function

End Class
