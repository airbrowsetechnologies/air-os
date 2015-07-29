Imports System.Runtime.InteropServices

Public Class OSAppBase
    'Base of interaction between OS and App.

    Public MyServer As Air_OS2.PipeServer
    Public MyClient As Air_OS2.PipeClient
    Public MyProcess As Process
    Public MyName As String = ""
    Public WithEvents MyTimer As New Timer
    Public MyTBItem As TaskbarItem

    Public Sub New(path As String)
        MyClient = New PipeClient
        MyServer = New PipeServer
        MyServer.Listen("airos_to_os_" + path)
        AddHandler MyServer.PipeMessage, New DelegateMessage(AddressOf RecievedMessage)

        MyName = path

        MyTimer.Enabled = True
        MyTimer.Interval = 1000

        MyTBItem = New TaskbarItem(Me)
        MyTBItem.Width = Desktop.GetDesktopHandle.AppBar.Width - (2 * Desktop.GetDesktopHandle.AppBar.Padding.Left)
        MyTBItem.Height = MyTBItem.Width


        MyProcess = Process.Start(AirOS.OSDataPath + "\apps\" + path + "\" + path + ".exe", "airos")
        MyProcess.WaitForInputIdle()

        Threading.Thread.Sleep(100)
        SetParent(MyProcess.MainWindowHandle, Desktop.GetDesktopHandle.Content.Handle)
        '      Desktop.GetDesktopHandle.AddOwnedForm(Form.FromHandle(MyProcess.MainWindowHandle))
        '   CType(Form.FromHandle(MyProcess.MainWindowHandle), Form).MdiParent = Desktop.GetDesktopHandle

        Desktop.GetDesktopHandle.AppBar.Controls.Add(MyTBItem)
    End Sub


    <DllImport("user32.dll")> _
    Private Shared Function SetParent(hWndChild As IntPtr, hWndNewParent As IntPtr) As IntPtr
    End Function

    Public Sub Dispose()

        Desktop.GetDesktopHandle.AppBar.Controls.Remove(MyTBItem)

        If MyProcess.Responding Then
            MyProcess.CloseMainWindow()
        Else
            MyProcess.Kill()
        End If
        MyProcess.Kill()
        SendMessage("close")
        MyProcess.Dispose()
        MyServer.Close()

        MyTBItem.Dispose()
        MyTimer.Dispose()
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
        Desktop.GetDesktopHandle.Invoke(MyExecuteCommDel, command, arg)
    End Sub

    Public Delegate Sub ExecuteCommandDel(comm As String, args As String())
    Public MyExecuteCommDel = New ExecuteCommandDel(AddressOf ExecuteCommand)

    Public Sub ExecuteCommand(comm As String, args As String())
        ' MsgBox("Message : " + comm)
        Select Case comm.ToLower
            Case "close"
                Dispose()
            Case "restart"
                RestartApp()
            Case "putindt"
                'SetParent(MyProcess.MainWindowHandle, Desktop.GetDesktopHandle.Handle)

        End Select
    End Sub

    Private Sub MyTimer_Tick(sender As Object, e As EventArgs) Handles MyTimer.Tick
        If Not MyProcess.Responding Then


        End If
        If MyProcess.HasExited Then
            MyProcess.Dispose()
            MyServer.Close()
            MyTBItem.Dispose()
            MyTimer.Dispose()
        End If
    End Sub

    Public Sub RestartApp()
        If MyProcess.Responding Then
            MyProcess.CloseMainWindow()
        Else
            MyProcess.Kill()
        End If
        Threading.Thread.Sleep(100)
        MyProcess = Process.Start(AirOS.OSDataPath + "\apps\" + MyName + "\" + MyName + ".exe", "airos")
    End Sub
End Class
