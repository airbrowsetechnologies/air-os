Imports System.Runtime.InteropServices

Public Class Desktop

    Public Sub New(user As String)
        InitializeComponent()


    End Sub

    Public RunningApps As New List(Of OSAppBase)


    Public Shared Function GetDesktopHandle() As Desktop
        Return CType(Application.OpenForms("Desktop"), Desktop)
    End Function

    Private Sub Desktop_Activated(sender As Object, e As EventArgs) Handles Me.Activated
    End Sub


    Private Sub Desktop_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate
        'For i = 0 To RunningApps.Count - 1
        '    RunningApps(i).SendMessage("hide")
        'Next
    End Sub


    Private Sub Desktop_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        For i = 0 To RunningApps.Count - 1
            RunningApps(i).Dispose()
        Next
    End Sub

    Private Sub Desktop_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Dim a As New OSAppBase("AirOSAppTest")
        RunningApps.Add(a)
    End Sub

    <DllImport("user32.dll")> _
    Private Shared Function SetParent(hWndChild As IntPtr, hWndNewParent As IntPtr) As IntPtr
    End Function
End Class