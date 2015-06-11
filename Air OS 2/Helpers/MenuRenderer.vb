Public Class MenuRenderer
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
                    e.Graphics.FillRectangle(Brushes.WhiteSmoke, New Rectangle(0, 0, e.Item.Width, e.Item.Height))
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
            e.ArrowColor = Color.DodgerBlue
        Else
            e.ArrowColor = Color.DarkGray
        End If
        MyBase.OnRenderArrow(e)
    End Sub

    'Protected Overrides Sub OnRenderToolStripPanelBackground(e As ToolStripPanelRenderEventArgs)
    '    e.Graphics.Clear(Color.White)
    'End Sub
    Protected Overrides Sub OnRenderItemText(e As ToolStripItemTextRenderEventArgs)

        If e.Item.IsOnDropDown Then
            If e.Item.Selected Then
                e.TextColor = Color.Black
            Else
                e.TextColor = Color.DarkGray
            End If
        End If
        MyBase.OnRenderItemText(e)
    End Sub

    Protected Overrides Sub OnRenderItemImage(e As ToolStripItemImageRenderEventArgs)
        'MyBase.OnRenderItemImage(e)
        If e.Item.Selected Then
            e.Graphics.DrawImage(Functions.ResizeImage(Functions.SetPixels(Color.DodgerBlue, e.Image), New Size(e.Item.Height - 4, e.Item.Height - 4)), New Point(2, 2))
        Else
            e.Graphics.DrawImage(Functions.ResizeImage(e.Image, New Size(e.Item.Height - 4, e.Item.Height - 4)), New Point(2, 2))
        End If
    End Sub





End Class


