Imports System.IO

Public Class Login

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        version.Text = "Air OS " + My.Application.Info.Version.ToString
    End Sub

    Private Sub Login_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        Label1.Height = (Height - Panel1.Height) / 2

        Dim padsides As Integer = (Width - 400) / 2
        Panel1.Padding = New Padding(padsides, 0, padsides, 0)
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If Directory.GetDirectories(AirOS.OSDataPath + "\users").Contains(AirOS.OSDataPath + "\users\" + TextBox1.Text.ToLower) Then
            Try
                PictureBox1.Image = Functions.ImageFromFile(AirOS.OSDataPath + "\users\" + TextBox1.Text + "\img.png")
            Catch ex As Exception
                PictureBox1.Image = My.Resources.person
            End Try

        Else
            PictureBox1.Image = My.Resources.AirOS_icon
        End If
    End Sub

    Public Sub LoginUser()
        incorrect.Visible = False
        TextBox1.Visible = False
        TextBox2.Visible = False
        ExButton1.Text = "Signing in..."
        ExButton1.Enabled = False
        CurrentUser = TextBox1.Text

        Dim name As String = ""
        Dim pw As String = ""
        Dim img As Image = PictureBox1.Image
        Try
            name = File.ReadAllText(AirOS.OSDataPath + "\users\" + TextBox1.Text + "\name.txt")
        Catch ex As Exception
            name = TextBox1.Text
        End Try
        Try
            pw = Functions.Decrypt(File.ReadAllText(AirOS.OSDataPath + "\users\" + TextBox1.Text + "\pw.txt"))
        Catch ex As Exception
            pw = TextBox2.Text
        End Try
        AirOS.UserFullName = name
        AirOS.UserProfile = img
        AirOS.UserPassword = pw
    End Sub

    Public Sub TryLogin()
        If File.Exists(AirOS.OSDataPath + "\users\" + TextBox1.Text + "\pw.txt") Then
            If TextBox2.Text = Functions.Decrypt(File.ReadAllText(AirOS.OSDataPath + "\users\" + TextBox1.Text + "\pw.txt")) Then
                LoginUser()
            Else
                incorrect.Visible = True
                incorrect.Text = "Incorrect password!"
            End If
        Else
            If Directory.Exists(AirOS.OSDataPath + "\users\" + TextBox1.Text) Then
                File.WriteAllText(AirOS.OSDataPath + "\users\" + TextBox1.Text + "\pw.txt", "")
                MsgBox("Your user information has been deleted outside of Air OS and your password has been reset to an empty string!")
                TextBox2.Text = ""
                TryLogin()
            End If
            incorrect.Visible = True
            incorrect.Text = "Incorrect username or password!"
        End If
    End Sub

    Private Sub ExButton1_Click(sender As Object, e As EventArgs) Handles ExButton1.Click
        TryLogin()
    End Sub

    Private Sub TextBox2_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyUp, TextBox1.KeyUp
        If e.KeyCode = Keys.Enter Then
            TryLogin()
        Else
            incorrect.Visible = False
        End If
    End Sub
End Class