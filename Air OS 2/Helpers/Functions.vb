Imports System.IO
Imports System.Drawing.Drawing2D
Imports System.Net
Imports System.Text
Imports System.Security.Cryptography

Public Class Functions

    Public Shared Function GoogleSearchURL(ByVal search As String, ByVal engine As String) As String
        ' appsettings.SearchHistory.Add(search)
        'appsettings.Save()
        Dim url As String = ""
        Select Case engine
            Case "Google"
                Dim searchterm As String = search
                Dim newsearch As String = searchterm.Replace(" ", "+")
                url = String.Format("{0}{1}", "https://www.google.com/search?q=", newsearch)
            Case "Google Images"
                Dim searchterm As String = search
                Dim newsearch As String = searchterm.Replace(" ", "+")
                url = String.Format("{0}{1}", "https://www.google.com/search?safe=off&site=&tbm=isch&source=hp&biw=1280&bih=642&q=", newsearch)
            Case "Bing"
                Dim searchterm As String = search
                Dim newsearch As String = searchterm.Replace(" ", "+")
                url = String.Format("{0}{1}", "http://www.bing.com/search?q=", newsearch)
            Case "Yahoo"
                Dim searchterm As String = search
                Dim newsearch As String = searchterm.Replace(" ", "+")
                url = String.Format("{0}{1}", "http://search.yahoo.com/search?ei={inputEncoding}&fr=crmas&p=", newsearch)
            Case "Youtube"
                Dim searchterm As String = search
                Dim newsearch As String = searchterm.Replace(" ", "+")
                url = String.Format("{0}{1}", "http://www.youtube.com/results?search_query=", newsearch)
            Case "Wikipedia"
                Dim searchterm As String = search
                Dim newsearch As String = searchterm.Replace(" ", "+")
                url = String.Format("{0}{1}", "http://en.wikipedia.org/wiki/", newsearch)
            Case Else
                url = engine + search.Replace(" ", "+")
        End Select
        Return url
    End Function

    Public Shared Function ColorFromRGBOffsetUp(clr As Color, offset As Integer) As Color
        Try
            Dim ncolor As Color
            Dim r As Integer
            Dim g As Integer
            Dim b As Integer

            If offset >= 0 Then
                If clr.R + offset <= 255 Then
                    r = clr.R + offset
                Else
                    r = clr.R + (255 - clr.R)
                End If
                If clr.G + offset <= 255 Then
                    g = clr.G + offset
                Else
                    g = clr.G + (255 - clr.G)
                End If
                If clr.B + offset <= 255 Then
                    b = clr.B + offset
                Else
                    b = clr.B + (255 - clr.B)
                End If
            Else
                If clr.R + offset >= 0 Then
                    r = clr.R + offset
                Else
                    r = clr.R + (0 - clr.R)
                End If
                If clr.G + offset >= 0 Then
                    g = clr.G + offset
                Else
                    g = clr.G + (0 - clr.G)
                End If
                If clr.B + offset >= 0 Then
                    b = clr.B + offset
                Else
                    b = clr.B + (0 - clr.B)
                End If
            End If

            Return Color.FromArgb(r, g, b)
        Catch ex As Exception
            Return clr
        End Try
    End Function



    'encryption from http://stackoverflow.com/users/162313/markl

    Private Shared key() As Byte = {}
    Private Shared IV() As Byte = {&H12, &H34, &H56, &H78, &H90, &HAB, &HCD, &HEF}
    Private Const EncryptionKey As String = "airos"
    Public Shared Function Decrypt(ByVal stringToDecrypt As String) As String
        Try
            Dim inputByteArray(stringToDecrypt.Length) As Byte
            key = System.Text.Encoding.UTF8.GetBytes(Left(EncryptionKey, 8))
            Dim des As New DESCryptoServiceProvider
            inputByteArray = Convert.FromBase64String(stringToDecrypt)
            Dim ms As New MemoryStream
            Dim cs As New CryptoStream(ms, des.CreateDecryptor(key, IV), CryptoStreamMode.Write)
            cs.Write(inputByteArray, 0, inputByteArray.Length)
            cs.FlushFinalBlock()
            Dim encoding As System.Text.Encoding = System.Text.Encoding.UTF8
            Return encoding.GetString(ms.ToArray())
        Catch ex As Exception
            'oops - add your exception logic
            Return ""
        End Try
    End Function

    Public Shared Function Encrypt(ByVal stringToEncrypt As String) As String
        Try
            key = System.Text.Encoding.UTF8.GetBytes(Left(EncryptionKey, 8))
            Dim des As New DESCryptoServiceProvider
            Dim inputByteArray() As Byte = Encoding.UTF8.GetBytes(stringToEncrypt)
            Dim ms As New MemoryStream
            Dim cs As New CryptoStream(ms, des.CreateEncryptor(key, IV), CryptoStreamMode.Write)
            cs.Write(inputByteArray, 0, inputByteArray.Length)
            cs.FlushFinalBlock()
            Return Convert.ToBase64String(ms.ToArray())
        Catch ex As Exception
            'oops - add your exception logic
            Return ""
        End Try
    End Function



    Public Shared ReadOnly Property AppVersion As String
        Get
            Dim _assemblyInfo As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly
            Dim ourVersion As String = String.Empty
            'if running the deployed application, you can get the version
            '  from the ApplicationDeployment information. If you try
            '  to access this when you are running in Visual Studio, 
            ' it will not work.
            If System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed Then
                ourVersion = Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString
            ElseIf (Not (_assemblyInfo) Is Nothing) Then
                ourVersion = _assemblyInfo.GetName.Version.ToString
            End If
            Return ourVersion
        End Get
    End Property





    Public Shared Function ImageToBase64String(ByVal aImage As Image) As String
        Using stream = New System.IO.MemoryStream
            aImage.Save(stream, System.Drawing.Imaging.ImageFormat.Png)
            Return Convert.ToBase64String(stream.ToArray)
        End Using
    End Function

    Public Shared Function ImageBlackToWhite(img As Image) As Image
        Dim bm As New Bitmap(img)
        Dim X As Integer
        Dim Y As Integer
        Dim r As Integer
        Dim g As Integer
        Dim b As Integer

        For X = 0 To bm.Width - 1
            For Y = 0 To bm.Height - 1
                If Not bm.GetPixel(X, Y).A = 0 Then
                    If bm.GetPixel(X, Y).R < 5 And bm.GetPixel(X, Y).G < 5 And bm.GetPixel(X, Y).B < 5 Then
                        r = 255 '- bm.GetPixel(X, Y).R
                        g = 255 '- bm.GetPixel(X, Y).G
                        b = 255 '- bm.GetPixel(X, Y).B
                        bm.SetPixel(X, Y, Color.FromArgb(r, g, b))
                    End If
                End If
            Next Y
        Next X

        Return bm
    End Function


    Public Shared Function imageToByteArray(imageIn As System.Drawing.Image) As Byte()
        Dim ms As New MemoryStream()
        imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif)
        Dim m = ms.ToArray
        ms.Close()
        ms.Dispose()
        Return m
    End Function

    Public Shared Function byteArrayToImage(byteArrayIn As Byte()) As Image

        Dim MS As MemoryStream = New MemoryStream(byteArrayIn)
        Dim returnImage As Image = Image.FromStream(MS)

        MS.Dispose()
        Return returnImage
    End Function

    Public Shared Function ResizeImage(ByVal image As Image, _
      ByVal size As Size, Optional ByVal preserveAspectRatio As Boolean = True) As Image
        Dim newWidth As Integer
        Dim newHeight As Integer
        Try
            If preserveAspectRatio Then
                Dim originalWidth As Integer = image.Width
                Dim originalHeight As Integer = image.Height
                Dim percentWidth As Single = CSng(size.Width) / CSng(originalWidth)
                Dim percentHeight As Single = CSng(size.Height) / CSng(originalHeight)
                Dim percent As Single = If(percentHeight < percentWidth,
                        percentHeight, percentWidth)
                newWidth = CInt(originalWidth * percent)
                newHeight = CInt(originalHeight * percent)
            Else
                newWidth = size.Width
                newHeight = size.Height
            End If
            Dim newImage As Image = New Bitmap(newWidth, newHeight)
            Using graphicsHandle As Graphics = Graphics.FromImage(newImage)
                graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic
                graphicsHandle.DrawImage(image, 0, 0, newWidth, newHeight)
                graphicsHandle.Dispose()
            End Using
            Return newImage
            newImage.Dispose()
        Catch ex As Exception
        End Try
    End Function

    Public Shared Function ContrastColor(color__1 As Color) As Color
        Dim d As Integer = 0

        ' Counting the perceptive luminance - human eye favors green color... 
        Dim a As Double = 1 - (0.299 * color__1.R + 0.587 * color__1.G + 0.114 * color__1.B) / 255

        If a < 0.5 Then
            d = 0
        Else
            ' bright colors - black font
            d = 255
        End If
        ' dark colors - white font
        Return Color.FromArgb(d, d, d)
    End Function

    Public Shared Function ImageFromFile(path As String) As Image
        Try
            Dim bytes = File.ReadAllBytes(path)

            Using ms = New MemoryStream(bytes)
                Dim img = Image.FromStream(ms)
                Return img
            End Using
        Catch ex As Exception
            Return Nothing
        End Try


        'Dim orig = Image.FromFile(path)
        'Dim img = orig.Clone
        'orig.Dispose()
        'Return img

    End Function

    Public Shared Function InvertImageColor(img As Image) As Image
        Dim bm As New Bitmap(img)
        Dim X As Integer
        Dim Y As Integer
        Dim r As Integer
        Dim g As Integer
        Dim b As Integer

        For X = 0 To bm.Width - 1
            For Y = 0 To bm.Height - 1
                If Not bm.GetPixel(X, Y).A = 0 Then
                    r = 255 - bm.GetPixel(X, Y).R
                    g = 255 - bm.GetPixel(X, Y).G
                    b = 255 - bm.GetPixel(X, Y).B
                    bm.SetPixel(X, Y, Color.FromArgb(r, g, b))
                End If
            Next Y
        Next X

        Return bm
    End Function

    Public Shared Function SetPixels(clr As Color, img As Image) As Image
        Dim bm As New Bitmap(img)
        Dim X As Integer
        Dim Y As Integer
        Dim r As Integer
        Dim g As Integer
        Dim b As Integer

        For X = 0 To bm.Width - 1
            For Y = 0 To bm.Height - 1
                If Not bm.GetPixel(X, Y).A = 0 Then
                    r = clr.R
                    g = clr.G
                    b = clr.B
                    bm.SetPixel(X, Y, Color.FromArgb(r, g, b))
                End If
            Next Y
        Next X

        Return bm
    End Function


    Public Shared Function AvgColor(clr As Color) As Color
        Dim c1 As Color = Color.White

        c1 = Color.White

        Dim c2 As Color = clr
        Return Color.FromArgb((CInt(c1.A) + CInt(c2.A)) / 2, (CInt(c1.R) + CInt(c2.R)) / 2, (CInt(c1.G) + CInt(c2.G)) / 2, (CInt(c1.B) + CInt(c2.B)) / 2)
    End Function

    Public Shared Function AvgColor(clr As Color, clr2 As Color) As Color
        Dim c1 As Color = clr
        Dim c2 As Color = clr2
        Return Color.FromArgb((CInt(c1.A) + CInt(c2.A)) / 2, (CInt(c1.R) + CInt(c2.R)) / 2, (CInt(c1.G) + CInt(c2.G)) / 2, (CInt(c1.B) + CInt(c2.B)) / 2)
    End Function
End Class
