Imports System.Windows.Forms
Imports System.Drawing
Imports System.IO

Public Class AirOSForm
    Inherits System.Windows.Forms.Form

    Protected Overrides Sub OnHandleCreated(e As EventArgs)
        FormBorderStyle = Windows.Forms.FormBorderStyle.None
        ShowInTaskbar = False
        DoubleBuffered = False
        ControlContainer.Dock = DockStyle.Fill
        ControlContainer.Padding = New Padding(1)
        ControlContainer.BorderStyle = BorderStyle.None
        ControlContainer.Font = New Font("Segoe UI", 10)
        TitleBar.Invalidate()
        ControlContainer.Invalidate()
        Refresh()
        DoubleBuffered = True

        TopMost = True
        MyBase.OnHandleCreated(e)

    End Sub

    Protected Overrides Sub OnSizeChanged(e As EventArgs)
        MyBase.OnSizeChanged(e)
        If Me.DesignMode Then
            StartingSize = Size
        End If
    End Sub

    Public MyServer As PipeServer
    Public MyClient As pipeClient


    Private WithEvents CloseButton As New ExButton
    Private WithEvents MaxRestoreButton As New ExButton
    Private WithEvents MinimizeButton As New ExButton
    Private WithEvents TitleBar As New Panel
    Public WithEvents ControlContainer As New ControlContainer

    Private IsInAirOS As Boolean = False
    Private StartingSize As Size
    Public Sub New()
        InitializeComponent()
        StartingSize = Size
        If Environment.CommandLine.Length > 0 Then
            If Environment.CommandLine(0) = "airos" Then
                IsInAirOS = True
                TopLevel = False
            End If
        End If
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
        CloseButton.Width = 36
        MaxRestoreButton.Image = My.Resources.winmaximize
        MaxRestoreButton.Width = 32
        MinimizeButton.Image = My.Resources.winminimize
        MinimizeButton.Width = 32
        TitleBar.Dock = DockStyle.Top
        TitleBar.Height = 29
        TitleBar.Padding = New Padding(1, 1, 1, 0)
        TitleBar.BackColor = Color.DodgerBlue
        Controls.Add(TitleBar)
        ControlContainer.Dock = DockStyle.Fill
        Controls.Add(ControlContainer)
        ControlContainer.BringToFront()


        SetStyle(ControlStyles.ContainerControl, False)
        TopMost = True

        MyClient = New PipeClient
        MyServer = New PipeServer
        MyServer.Listen("airos_from_os_" + Myname)
        AddHandler MyServer.PipeMessage, New DelegateMessage(AddressOf RecievedMessage)
    End Sub

    Public Myname = Application.StartupPath.Substring(Application.StartupPath.LastIndexOf("\") + 1)

    Public Sub SendMessageToOS(message As String)
        MyClient.Send(Message, "airos_to_os_" + Myname, 2000)
    End Sub

    Private Sub RecievedMessage(message As String)
        Dim command As String = message.Split("|")(0)
        Dim arg As String() = "".Split("")
        Try
            arg = message.Split("|")(1).Split("^")
        Catch ex As Exception : End Try
    End Sub

    Public Sub ExecuteCommand(comm As String, args As String())
        Select Case comm
            Case "toggle"
                If WindowState = FormWindowState.Minimized Then
                    WindowState = FormWindowState.Normal
                Else
                    WindowState = FormWindowState.Minimized
                End If
            Case "sendtoback"
                TopLevel = False
            Case "close"

                Me.Close()
        End Select
    End Sub

    Public Property AppSize As Size
        Get
            Return StartingSize
        End Get
        Set(value As Size)
            StartingSize = value
            If Me.DesignMode Then
                Size = value
            End If
        End Set
    End Property

#Region "Drag"
    Dim startpt As New Point(0)
    Dim ismousedown As Boolean = False
    Private Sub TitleBar_MouseDown(sender As Object, e As MouseEventArgs) Handles TitleBar.MouseDown
        ismousedown = True
        startpt = TitleBar.PointToClient(Control.MousePosition)
    End Sub

    Private Sub TitleBar_MouseMove(sender As Object, e As MouseEventArgs) Handles TitleBar.MouseMove
        If ismousedown Then
            WindowState = FormWindowState.Normal
            Size = StartingSize
            Location = New Point(Control.MousePosition.X - startpt.X, Control.MousePosition.Y - startpt.Y)
        End If
    End Sub

    Private Sub TitleBar_MouseUp(sender As Object, e As MouseEventArgs) Handles TitleBar.MouseUp
        ismousedown = False
        If IsInAirOS Then
            If Control.MousePosition.Y < 1 Then
                WindowState = FormWindowState.Maximized
            End If
            If Control.MousePosition.X < 1 Then
                Size = New Size(My.Computer.Screen.Bounds.Width / 2 - 25, My.Computer.Screen.WorkingArea.Height - 50)
                Location = New Point(0, 0)
            End If
            If Control.MousePosition.X > My.Computer.Screen.Bounds.Width - 2 Then
                Size = New Size(My.Computer.Screen.Bounds.Width / 2 - 25, My.Computer.Screen.WorkingArea.Height - 50)
                Location = New Point(My.Computer.Screen.Bounds.Width / 2 - 25, 0)
            End If
        Else
            If Control.MousePosition.Y < 1 Then
                WindowState = FormWindowState.Maximized
            End If

            If Control.MousePosition.X < 1 Then
                Size = New Size(My.Computer.Screen.Bounds.Width / 2, My.Computer.Screen.WorkingArea.Height)
                Location = New Point(0, 0)
            End If
            If Control.MousePosition.X > My.Computer.Screen.Bounds.Width - 2 Then
                Size = New Size(My.Computer.Screen.Bounds.Width / 2, My.Computer.Screen.WorkingArea.Height)
                Location = New Point(My.Computer.Screen.Bounds.Width / 2, 0)
            End If
        End If

    
        Refresh()

    End Sub
#End Region



    Private Sub TitleBar_Paint(sender As Object, e As PaintEventArgs) Handles TitleBar.Paint
        e.Graphics.DrawImage(Functions.ResizeImage(Icon.ToBitmap, New Size(23, 23)), New Point(3, 3))
        '  e.Graphics.DrawRectangle(SystemPens.HotTrack, New Rectangle(0, 0, TitleBar.Width - 1, TitleBar.Height))
        Using s = New StringFormat, f = New Font("Segoe UI", 11)
            s.Alignment = StringAlignment.Near
            s.LineAlignment = StringAlignment.Center
            s.Trimming = StringTrimming.EllipsisCharacter
            e.Graphics.DrawString(Text, f, Brushes.White, New Rectangle(30, 3, Width - (CloseButton.Width * 3) - 40, 23), s)
        End Using
    End Sub

    Private Sub ControlContainer_Paint(sender As Object, e As PaintEventArgs) Handles ControlContainer.Paint
        e.Graphics.DrawRectangle(Pens.DodgerBlue, New Rectangle(0, -1, ControlContainer.Width - 1, ControlContainer.Height))
    End Sub

    Private Sub CloseButton_Click(sender As Object, e As EventArgs) Handles CloseButton.Click
        SendMessageToOS("close")
    End Sub

    Private Sub MinimizeButton_Click(sender As Object, e As EventArgs) Handles MinimizeButton.Click
        WindowState = FormWindowState.Minimized
    End Sub

    Private Sub MaxRestoreButton_Click(sender As Object, e As EventArgs) Handles MaxRestoreButton.Click
        If WindowState = FormWindowState.Normal Then
            WindowState = FormWindowState.Maximized
        Else
            WindowState = FormWindowState.Normal
        End If
    End Sub

    Private Sub AirOSForm_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged, Me.LocationChanged
        Invalidate()
    End Sub

    Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'AirOSForm
        '
        Me.ClientSize = New System.Drawing.Size(462, 535)
        Me.Name = "AirOSForm"
        Me.ResumeLayout(False)

    End Sub

    Private Sub AirOSForm_Load(sender As Object, e As EventArgs) Handles MyBase.Shown
        ' TopLevel = False
        'SendMessageToOS("putindt")
    End Sub
End Class

Public Class ControlContainer
    Inherits Panel

    Public Sub New()
        SetStyle(ControlStyles.ContainerControl, True)
    End Sub
End Class
