Public Class Login

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        version.Text = "Air OS " + My.Application.Info.Version.ToString
    End Sub

    Private Sub Login_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        Label1.Height = (Height - Panel1.Height) / 2

        Dim padsides As Integer = (Width - 400) / 2
        Panel1.Padding = New Padding(padsides, 0, padsides, 0)
    End Sub
End Class