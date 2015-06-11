Imports System.IO
Public Class Booter

    Private Sub Booting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
        Me.Size = My.Computer.Screen.Bounds.Size
        Me.BringToFront()
        '      My.Settings.Console.Clear()
        My.Settings.Save()
    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Me.BackColor.R < 100 Then
            Me.BackColor = Color.FromArgb(Me.BackColor.R + 1, Me.BackColor.G + 1, Me.BackColor.B + 1)
            If ProgressBar1.Value < ProgressBar1.Maximum Then
                ProgressBar1.Value += 1
            Else
                Me.Close()
            End If

            Console.WriteLine("Boot started...")
            Console.WriteLine("Checking file directories...")
            Console.WriteLine("Loading apps and settings...")

            If ProgressBar1.Value <= 33 Then
                Label1.Text = "Loading OS... - " + Math.Truncate((ProgressBar1.Value)).ToString + "%"

            ElseIf ProgressBar1.Value <= 66 Then
                Label1.Text = "Loading components and files... - " + Math.Truncate((ProgressBar1.Value)).ToString + "%"
                Refresh()
                If Not Application.StartupPath.Contains("Debug") Then
                    If Not IO.Directory.Exists(Application.StartupPath + "\files") Then
                        IO.Directory.CreateDirectory(Application.StartupPath + "\files")
                    End If
                    If IO.Directory.GetDirectories(Application.StartupPath + "\files").Length < 5 Then
                        If Not IO.Directory.Exists(Application.StartupPath + "\files\docs") Then
                            Label1.Text = "Copying documents..."
                            IO.Directory.CreateDirectory(Application.StartupPath + "\files\docs")
                            Dim files As String() = IO.Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments))
                            For i = 0 To files.Length - 1 Step 1
                                File.Copy(files(i), Application.StartupPath + "\files\docs\" + files(i).Substring(files(i).LastIndexOf("\") + 1), True)
                            Next
                        End If
                        If Not IO.Directory.Exists(Application.StartupPath + "\files\tunes") Then
                            Label1.Text = "Copying music..."
                            IO.Directory.CreateDirectory(Application.StartupPath + "\files\tunes")
                            Dim files As String() = IO.Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic))
                            For i = 0 To files.Length - 1 Step 1
                                File.Copy(files(i), Application.StartupPath + "\files\tunes\" + files(i).Substring(files(i).LastIndexOf("\") + 1), True)
                            Next
                        End If
                        If Not IO.Directory.Exists(Application.StartupPath + "\files\photos") Then
                            Label1.Text = "Copying photos..."
                            IO.Directory.CreateDirectory(Application.StartupPath + "\files\photos")
                            Dim files As String() = IO.Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures))
                            For i = 0 To files.Length - 1 Step 1
                                File.Copy(files(i), Application.StartupPath + "\files\photos\" + files(i).Substring(files(i).LastIndexOf("\") + 1), True)
                            Next
                        End If
                        If Not IO.Directory.Exists(Application.StartupPath + "\files\downloads") Then
                            IO.Directory.CreateDirectory(Application.StartupPath + "\files\downloads")
                        End If
                        If Not IO.Directory.Exists(Application.StartupPath + "\files\films") Then
                            Label1.Text = "Copying media..."
                            IO.Directory.CreateDirectory(Application.StartupPath + "\files\films")
                            Dim files As String() = IO.Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos))
                            For i = 0 To files.Length - 1 Step 1
                                File.Copy(files(i), Application.StartupPath + "\files\films\" + files(i).Substring(files(i).LastIndexOf("\") + 1), True)
                            Next
                        End If
                    End If
                End If
                Else
                    Label1.Text = "Loading apps and settings... - " + Math.Truncate((ProgressBar1.Value)).ToString + "%"

                End If
        Else
            Console.WriteLine("Booting complete...")
            Console.WriteLine("Showing login screen...")
            'Dim l As New Login
            'l.Show()
            'l.BringToFront()
            Me.Close()
            Timer1.Enabled = False
        End If
    End Sub
End Class
