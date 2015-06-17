Imports System.IO
Imports System.Drawing.Drawing2D
Imports System.Net
Imports System.Text
Imports System.Drawing

Public Class Functions

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
