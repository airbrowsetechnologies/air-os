Imports System.Drawing.Drawing2D
Imports System.Drawing
Imports System.Windows.Forms

Public Class ExButton
    Inherits Button



#Region "Properties"
    Private nbc As Color ' = Color.Black
    Private hbc As Color ' = Color.Black
    Private mdbc As Color ' = Color.Black
    Private nc1 As Color '= Color.White
    Private nc2 As Color '= Color.Black
    Private hc1 As Color ' = Color.FromArgb(nc1.A - 5, nc1.R - 5, nc1.G - 5, nc1.B - 5)
    Private hc2 As Color '= Color.FromArgb(nc2.A - 5, nc2.R - 5, nc2.G - 5, nc2.B - 5)
    Private mdc1 As Color ' = Color.FromArgb(nc1.A - 10, nc1.R - 10, nc1.G - 10, nc1.B - 10)
    Private mdc2 As Color '= Color.FromArgb(nc1.A - 10, nc1.R - 10, nc1.G - 10, nc1.B - 10)
    Private corners As Integer = 0
    Private isinurlbar As Boolean = False
    Private userpaint As Boolean = False

    Public Property NormalBorder As Color
        Set(value As Color)
            nbc = value
            Invalidate()
        End Set
        Get
            Return nbc
        End Get

    End Property

    Public Property CornerRadius As Integer
        Get
            Return 0
        End Get
        Set(value As Integer)

        End Set
    End Property
    Public Property HoverBorder As Color
        Set(value As Color)
            hbc = value
            Invalidate()
        End Set
        Get
            Return hbc
        End Get
    End Property

    Public Property MouseDownBorder As Color
        Set(value As Color)
            mdbc = value
            Invalidate()
        End Set
        Get
            Return mdbc
        End Get
    End Property

    Public Property NormalColor1 As Color
        Set(value As Color)
            nc1 = value
            Invalidate()
        End Set
        Get
            Return nc1
        End Get
    End Property

    Public Property NormalColor2 As Color
        Set(value As Color)
            nc2 = value
            Invalidate()
        End Set
        Get
            Return nc2
        End Get
    End Property

    Public Property HoverColor1 As Color
        Set(value As Color)
            hc1 = value
            Invalidate()
        End Set
        Get
            Return hc1
        End Get
    End Property

    Public Property HoverColor2 As Color
        Set(value As Color)
            hc2 = value
            Invalidate()
        End Set
        Get
            Return hc2
        End Get
    End Property

    Public Property MouseDownColor1 As Color
        Set(value As Color)
            mdc1 = value
            Invalidate()
        End Set
        Get
            Return mdc1
        End Get
    End Property

    Public Property MouseDownColor2 As Color
        Set(value As Color)
            mdc2 = value
            Invalidate()
        End Set
        Get
            Return mdc2
        End Get
    End Property



    Public Property UserPainted As Boolean
        Set(value As Boolean)
            userpaint = value
        End Set
        Get
            Return userpaint
        End Get
    End Property

    'Public Sub UpdateColors()
    '    Try
    '        hc1 = Functions.AvgColor(nc1)  'Functions.ColorFromRGBOffsetUp(nc1, -5)
    '        hc2 = Functions.AvgColor(nc2) 'Functions.ColorFromRGBOffsetUp(nc2, -5)
    '        mdc1 = Functions.ColorFromRGBOffsetUp(nc1, -10)
    '        mdc2 = Functions.ColorFromRGBOffsetUp(nc2, -10)

    '        HoverBorder = mdc1
    '        MouseDownBorder = mdc2
    '    Catch ex As Exception

    '    End Try

    'End Sub

    Private _centerimg As Boolean = False
    Public Property CenterImage As Boolean
        Get
            Return _centerimg
        End Get
        Set(value As Boolean)
            _centerimg = value
        End Set
    End Property

    Private _textcentered As Boolean = True
    Public Property TextCentered As Boolean
        Get
            Return _textcentered
        End Get
        Set(value As Boolean)
            _textcentered = value
        End Set
    End Property
#End Region

    Public Sub New()
        NormalColor1 = SystemColors.Control
        NormalColor2 = SystemColors.Control
        NormalBorder = Color.Transparent
        HoverBorder = Color.Silver
        MouseDownBorder = SystemColors.ControlDark
        'UpdateColors()
        ButtonScheme = ButtonType.Simple

        isinurlbar = False
        SetStyle(ControlStyles.SupportsTransparentBackColor Or ControlStyles.UserPaint Or ControlStyles.DoubleBuffer, True)
        SetStyle(ControlStyles.Selectable, False)
    End Sub


    Public Sub New(normcolor1 As Color, normcolor2 As Color, normalbord As Color, hoverbord As Color, clickbord As Color, userpaint As Boolean)
        NormalColor1 = normcolor1
        NormalColor2 = normcolor2
        'HoverColor1 = hovrcolor1
        'HoverColor2 = hovrcolor2
        'MouseDownColor1 = clickcolor1
        'MouseDownColor2 = clickcolor2
        NormalBorder = normalbord
        HoverBorder = hoverbord
        MouseDownBorder = clickbord
        ButtonScheme = ButtonType.Simple

        UserPainted = userpaint
        SetStyle(ControlStyles.SupportsTransparentBackColor Or ControlStyles.UserPaint Or ControlStyles.DoubleBuffer, True)
        SetStyle(ControlStyles.Selectable, False)
    End Sub

    Protected Overrides Sub OnPaint(pevent As PaintEventArgs)

        If Me.Cursor = Cursors.Default Then
            If ButtonScheme = ButtonType.Primary Or ButtonScheme = ButtonType.Delete Then
                Cursor = Cursors.Hand
            End If
        End If
        Try

            MyBase.OnPaint(pevent)
            'pevent.Graphics.SmoothingMode = SmoothingMode.HighQuality
            pevent.Graphics.Clear(nc1)

            Dim r As Rectangle = New Rectangle(New Point(0, 0), Me.Size)
            Dim r2 As Rectangle = New Rectangle(New Point(0, 0), New Size(Me.Width - 1, Me.Height - 1))
            If ismousedown Then


                Using linbrush = New LinearGradientBrush(r, mdc1, mdc2, LinearGradientMode.Vertical)
                    pevent.Graphics.FillRectangle(linbrush, r)
                End Using

                Using p = New Pen(mdbc)
                    pevent.Graphics.DrawRectangle(p, r2)
                End Using

            Else
                If ismousein Then
                    Using linbrush = New LinearGradientBrush(r, hc1, hc2, LinearGradientMode.Vertical)
                        pevent.Graphics.FillRectangle(linbrush, r)
                    End Using
                    Using p As New Pen(hbc)
                        pevent.Graphics.DrawRectangle(p, r2)
                    End Using


                Else
                    If UserPainted Then
                        pevent.Graphics.FillRectangle(Brushes.Transparent, r)
                        pevent.Graphics.DrawRectangle(Pens.Transparent, r)
                    Else
                        Using linbrush = New LinearGradientBrush(r, nc1, nc2, LinearGradientMode.Vertical)
                            pevent.Graphics.FillRectangle(linbrush, r)
                            Using apen = New Pen(nbc)
                                pevent.Graphics.DrawRectangle(apen, r2)
                            End Using
                        End Using
                    End If
                End If
            End If


DrawImage:

            Dim sf = New StringFormat
            sf.LineAlignment = StringAlignment.Center
            If TextCentered Then
                sf.Alignment = StringAlignment.Center
                pevent.Graphics.DrawString(Text, Font, New SolidBrush(ForeColor), New Point(Me.Width / 2, Me.Height / 2), sf)
            Else
                sf.Alignment = StringAlignment.Near
                pevent.Graphics.DrawString(Text, Font, New SolidBrush(ForeColor), New Point(Me.Height, Me.Height / 2), sf)

            End If


            If Image IsNot Nothing Then
                Dim pt As New Point(5, 5)
                If ScaleImageDown Then

                    Using img = Functions.ResizeImage(Me.Image, New Size(Me.Width - 10, Me.Height - 10))
                        If CenterImage Then
                            pt = New Point((Me.Width / 2) - (img.Width / 2), 5)
                        End If
                        pevent.Graphics.DrawImage(img, pt)
                    End Using
                Else
                    pt = New Point(2, 2)

                    Using img = Functions.ResizeImage(Me.Image, New Size(Me.Width - 4, Me.Height - 4))
                        If CenterImage Then
                            pt = New Point((Me.Width / 2) - (img.Width / 2), 2)
                        End If
                        pevent.Graphics.DrawImage(img, pt)
                    End Using
                End If

            End If





        Catch ex As Exception

        End Try

    End Sub


    Private _smallerimg As Boolean = True
    Public Property ScaleImageDown As Boolean
        Get
            Return _smallerimg
        End Get
        Set(value As Boolean)
            _smallerimg = value
        End Set
    End Property



    Public Enum ButtonType As Byte
        Primary = 0
        Secondary = 1
        Delete = 2
        Simple = 3
        Custom = 5

    End Enum

    Private _btype As ButtonType = ButtonType.Custom
    Public Property ButtonScheme As ButtonType
        Get
            Return _btype
        End Get
        Set(value As ButtonType)
            _btype = value
            Select Case _btype
                Case ButtonType.Delete
                    Cursor = Cursors.Hand
                    ForeColor = Color.White
                    NormalBorder = Color.Transparent
                    HoverBorder = Color.Transparent
                    MouseDownBorder = Color.Transparent

                    NormalColor1 = Color.FromArgb(211, 47, 47)
                    NormalColor2 = Color.FromArgb(211, 47, 47)
                    HoverColor1 = Color.FromArgb(231, 67, 67)
                    HoverColor2 = Color.FromArgb(231, 67, 67)
                    MouseDownColor1 = Color.FromArgb(191, 27, 27)
                    MouseDownColor2 = Color.FromArgb(191, 27, 27)
                Case ButtonType.Primary
                    Cursor = Cursors.Hand
                    ForeColor = Color.White
                    NormalBorder = Color.Transparent
                    HoverBorder = Color.Transparent
                    MouseDownBorder = Color.Transparent

                    NormalColor1 = Color.DodgerBlue
                    NormalColor2 = Color.DodgerBlue
                    HoverColor1 = Color.FromArgb(65, 158, 250)
                    HoverColor2 = Color.FromArgb(65, 158, 250)
                    MouseDownColor1 = Color.FromArgb(25, 118, 210)
                    MouseDownColor2 = Color.FromArgb(25, 118, 210)
                Case ButtonType.Secondary
                    Cursor = Cursors.Default
                    ForeColor = Color.DodgerBlue
                    NormalBorder = Color.Silver
                    HoverBorder = Color.DodgerBlue
                    MouseDownBorder = Color.DarkGray

                    NormalColor1 = Color.WhiteSmoke
                    NormalColor2 = SystemColors.Control
                    HoverColor1 = Color.WhiteSmoke
                    HoverColor2 = Color.AliceBlue
                    MouseDownColor1 = Color.Silver
                    MouseDownColor2 = Color.Silver
                Case ButtonType.Simple
                    Cursor = Cursors.Default
                    ForeColor = Color.Black
                    NormalBorder = Color.Silver
                    HoverBorder = Color.Silver
                    MouseDownBorder = Color.DarkGray

                    NormalColor1 = Color.WhiteSmoke
                    NormalColor2 = SystemColors.Control
                    HoverColor1 = Color.WhiteSmoke
                    HoverColor2 = Color.WhiteSmoke

                    MouseDownColor1 = Color.Silver
                    MouseDownColor2 = Color.Silver
            End Select
        End Set
    End Property

    Public ismousein As Boolean = False
    Public ismousedown As Boolean = False

    Protected Overrides Sub OnMouseEnter(e As EventArgs)
        MyBase.OnMouseEnter(e)

        ismousein = True
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        MyBase.OnMouseLeave(e)
        ismousein = False
        Invalidate()
    End Sub

    Protected Overrides Sub OnLostFocus(e As EventArgs)
        MyBase.OnLostFocus(e)
        ismousein = False
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseDown(mevent As MouseEventArgs)
        MyBase.OnMouseDown(mevent)

        ismousedown = True
        Invalidate()
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseUp(mevent As MouseEventArgs)
        MyBase.OnMouseUp(mevent)
        ismousedown = False
        Invalidate()

    End Sub

    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)
        Invalidate()
    End Sub



#Region "Colors"
    Private Function ContrastColor(color__1 As Color) As Color
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

    Public Function AvgColor(clr As Color) As Color
        Dim c1 As Color = Color.White
        c1 = Color.White
        Dim c2 As Color = clr
        Return Color.FromArgb((CInt(c1.A) + CInt(c2.A)) / 2, (CInt(c1.R) + CInt(c2.R)) / 2, (CInt(c1.G) + CInt(c2.G)) / 2, (CInt(c1.B) + CInt(c2.B)) / 2)
    End Function

    Public Function AvgColor(clr As Color, clr2 As Color) As Color
        Dim c1 As Color = clr
        Dim c2 As Color = clr2
        Return Color.FromArgb((CInt(c1.A) + CInt(c2.A)) / 2, (CInt(c1.R) + CInt(c2.R)) / 2, (CInt(c1.G) + CInt(c2.G)) / 2, (CInt(c1.B) + CInt(c2.B)) / 2)
    End Function
#End Region

    Private Sub ExButton_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed

    End Sub
End Class
