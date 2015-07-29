Public Class TaskbarItem

    Public myApp As OSAppBase
    Public Sub New(app As OSAppBase)
        InitializeComponent()
        myApp = app
    End Sub
   
    Private Sub TaskbarItem_Click(sender As Object, e As EventArgs) Handles Me.Click
        myApp.SendMessage("toggle")

    End Sub
End Class
