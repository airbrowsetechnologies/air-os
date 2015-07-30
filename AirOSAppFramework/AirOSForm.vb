Imports System.Windows.Forms
Imports System.Drawing
Imports System.IO

Public Class AirOSForm
    Inherits System.Windows.Forms.Form

    Protected Overrides Sub OnHandleCreated(e As EventArgs)
        FormBorderStyle = Windows.Forms.FormBorderStyle.None
        DoubleBuffered = True
        ControlContainer.Dock = DockStyle.Fill
        ControlContainer.Padding = New Padding(1)
        ControlContainer.BorderStyle = BorderStyle.None
        TitleBar.Invalidate()
        ControlContainer.Invalidate()
        MyBase.OnHandleCreated(e)

    End Sub


    Private CloseButton As New ExButton
    Private MaxRestoreButton As New ExButton
    Private MinimizeButton As New ExButton
    Private WithEvents TitleBar As New Panel
    Public WithEvents ControlContainer As New ControlContainer

    Public Sub New()
        Dim exs = {MinimizeButton, MaxRestoreButton, CloseButton}
        For i = 0 To exs.Length - 1
            exs(i).ButtonScheme = ExButton.ButtonType.Primary
            exs(i).CenterImage = True
            exs(i).Text = ""
            exs(i).ScaleImageDown = True
            exs(i).Dock = Windows.Forms.DockStyle.Right
            exs(i).Size = New System.Drawing.Size(35, 29)
            TitleBar.Controls.Add(exs(i))
        Next
        CloseButton.Image = My.Resources.winclose
        MaxRestoreButton.Image = My.Resources.winmaximize
        MinimizeButton.Image = My.Resources.winminimize
        TitleBar.Dock = DockStyle.Top
        TitleBar.Height = 29
        TitleBar.Padding = New Padding(1, 1, 1, 0)
        TitleBar.BackColor = Color.DodgerBlue
        Controls.Add(TitleBar)
        ControlContainer.Dock = DockStyle.Fill
        Controls.Add(ControlContainer)
        ControlContainer.BringToFront()


        SetStyle(ControlStyles.ContainerControl, False)
    End Sub



    Private Sub TitleBar_Paint(sender As Object, e As PaintEventArgs) Handles TitleBar.Paint
        e.Graphics.DrawImage(Functions.ResizeImage(Icon.ToBitmap, New Size(23, 23)), New Point(3, 3))
        e.Graphics.DrawRectangle(SystemPens.HotTrack, New Rectangle(0, 0, TitleBar.Width - 1, TitleBar.Height))
        Using s = New StringFormat, f = New Font("Segoe UI", 11)
            s.Alignment = StringAlignment.Near
            s.LineAlignment = StringAlignment.Center
            s.Trimming = StringTrimming.EllipsisCharacter
            e.Graphics.DrawString(Text, f, Brushes.White, New Rectangle(30, 3, Width - (CloseButton.Width * 3) - 40, 23), s)
        End Using
    End Sub

    Private Sub ControlContainer_Paint(sender As Object, e As PaintEventArgs) Handles ControlContainer.Paint
        e.Graphics.DrawRectangle(Pens.DodgerBlue, New Rectangle(0, -1, ControlContainer.Width - 1, ControlContainer.Height + 1))
    End Sub
End Class

Public Class ControlContainer
    Inherits Panel

    Public Sub New()
        SetStyle(ControlStyles.ContainerControl, True)
    End Sub
End Class
