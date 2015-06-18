Public Class OSAppBase

    Public MyServer As Air_OS2.PipeServer
    Public MyClient As Air_OS2.PipeClient
    Public MyProcess As Process
    Public MyName As String = ""
    Public WithEvents MyTimer As New Timer
    Public Sub New(path As String)
        MyClient = New PipeClient
        MyServer = New PipeServer
        MyServer.Listen("airos_to_os_" + path)
        AddHandler MyServer.PipeMessage, New DelegateMessage(AddressOf RecievedMessage)
        MyProcess = Process.Start(AirOS.OSDataPath + "\apps\" + path + "\" + path + ".exe")
        MyName = path

        MyTimer.Enabled = True
        MyTimer.Interval = 1000

    End Sub

    Public Sub Dispose()
        MyServer.Close()
        If MyProcess.Responding Then
            MyProcess.CloseMainWindow()
        Else
            MyProcess.Kill()
        End If
    End Sub

    Public Sub SendMessage(message As String)
        MyClient.Send(message, "airos_to_app_" + MyName, 2000)
    End Sub

    Public Sub RecievedMessage(message As String)
        Dim command As String = message.Split("|")(0)
        Dim arg As String() = "".Split("")
        Try
            arg = message.Split("|")(1).Split("^")
        Catch ex As Exception : End Try
    End Sub

    Public Sub ExecuteCommand(comm As String, args As String())
        Select Case comm
            Case "close"
                Dispose()


        End Select
    End Sub

    Private Sub MyTimer_Tick(sender As Object, e As EventArgs) Handles MyTimer.Tick
        If Not MyProcess.Responding Then

        End If
    End Sub
End Class
