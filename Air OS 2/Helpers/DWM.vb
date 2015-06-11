
'Imports System.Collections.Generic
'Imports System.Text
'Imports System.Runtime.InteropServices
'Imports System.Drawing
'Imports System.Drawing.Drawing2D

'Namespace AeroNonClientButtons
'    ''' <summary>
'    ''' DWM related code
'    ''' </summary>
'    ''' 

'#Region "Renderer"
'    Public Class NonClientAreaRenderer
'        Inherits ToolStripProfessionalRenderer

'        Public Sub New()
'            RoundedEdges = False

'        End Sub
'        Protected Overrides Sub OnRenderToolStripBackground(e As ToolStripRenderEventArgs)
'            If e.ToolStrip.IsDropDown Then
'                MyBase.OnRenderToolStripBackground(e)
'            Else
'                'Clear so Aero glass covers the area
'                e.Graphics.Clear(Color.Transparent)
'            End If
'        End Sub

'        Protected Overrides Sub OnRenderToolStripBorder(e As ToolStripRenderEventArgs)
'            ' Don't render border if on glass area
'            If e.ToolStrip.IsDropDown Then
'                MyBase.OnRenderToolStripBorder(e)
'            End If
'        End Sub

'        Protected Overrides Sub OnRenderSeparator(e As ToolStripSeparatorRenderEventArgs)
'            e.Graphics.DrawLine(Pens.Gainsboro, 0, 2, e.Item.Width, 2)
'        End Sub

'        Protected Overrides Sub OnRenderItemText(e As ToolStripItemTextRenderEventArgs)
'            If e.ToolStrip.IsDropDown Then
'                MyBase.OnRenderItemText(e)
'            Else
'                'Text must be rendered this way or text will be ugly-painted.
'                Dim path As New GraphicsPath()
'                path.AddString(e.Text, e.TextFont.FontFamily, CInt(e.TextFont.Style), e.TextFont.Size + 2, e.TextRectangle.Location, New StringFormat())
'                e.Graphics.SmoothingMode = SmoothingMode.HighQuality
'                e.Graphics.FillPath(Brushes.Black, path)

'                path.Dispose()
'            End If


'        End Sub

'        Protected Overrides Sub OnRenderOverflowButtonBackground(e As ToolStripItemRenderEventArgs)
'            'Draw overflow button, specially for this renderer.

'            If e.Item.Selected Then
'                e.Graphics.Clear(Color.FromArgb(20, Color.Navy))
'            End If

'            Dim r As Rectangle = Rectangle.Empty
'            If e.Item.RightToLeft = RightToLeft.Yes Then
'                r = New Rectangle(0, e.Item.Height - 8, 9, 5)
'            Else
'                r = New Rectangle(e.Item.Width - 12, e.Item.Height - 16, 9, 5)
'            End If

'            MyBase.DrawArrow(New ToolStripArrowRenderEventArgs(e.Graphics, e.Item, r, SystemColors.ControlText, ArrowDirection.Down))

'            e.Graphics.DrawLine(SystemPens.ControlText, CInt(r.Right - 7), CInt(r.Y - 2), CInt(r.Right - 3), CInt(r.Y - 2))

'        End Sub

'        Protected Overrides Sub OnRenderButtonBackground(e As ToolStripItemRenderEventArgs)
'            If e.Item.Pressed Then
'                ' e.Graphics.FillRectangle(New SolidBrush(Functions.ColorFromRGBOffsetUp(AppSettings.TabColor, -10)), e.Item.Bounds)
'                e.Graphics.DrawRectangle(New Pen(AppSettings.TabColor), 0, 0, e.Item.Width - 1, e.Item.Height - 1)

'            End If

'            If e.Item.Selected Then
'                'e.Graphics.DrawRectangle(New Pen(AppSettings.TabColor), 0, 0, e.Item.Width - 1, e.Item.Height - 1)
'            End If

'        End Sub


'    End Class
'#End Region

'    Public Class Dwm
'        <StructLayout(LayoutKind.Explicit)> _
'        Public Structure RECT
'            ' Fields
'            <FieldOffset(12)> _
'            Public bottom As Integer
'            <FieldOffset(0)> _
'            Public left As Integer
'            <FieldOffset(8)> _
'            Public right As Integer
'            <FieldOffset(4)> _
'            Public top As Integer

'            ' Methods
'            Public Sub New(rect__1 As Rectangle)
'                Me.left = rect__1.Left
'                Me.top = rect__1.Top
'                Me.right = rect__1.Right
'                Me.bottom = rect__1.Bottom
'            End Sub

'            Public Sub New(left As Integer, top As Integer, right As Integer, bottom As Integer)
'                Me.left = left
'                Me.top = top
'                Me.right = right
'                Me.bottom = bottom
'            End Sub

'            Public Sub [Set]()
'                Me.left = InlineAssignHelper(Me.top, InlineAssignHelper(Me.right, InlineAssignHelper(Me.bottom, 0)))
'            End Sub

'            Public Sub [Set](rect As Rectangle)
'                Me.left = rect.Left
'                Me.top = rect.Top
'                Me.right = rect.Right
'                Me.bottom = rect.Bottom
'            End Sub

'            Public Sub [Set](left As Integer, top As Integer, right As Integer, bottom As Integer)
'                Me.left = left
'                Me.top = top
'                Me.right = right
'                Me.bottom = bottom
'            End Sub

'            Public Function ToRectangle() As Rectangle
'                Return New Rectangle(Me.left, Me.top, Me.right - Me.left, Me.bottom - Me.top)
'            End Function

'            ' Properties
'            Public ReadOnly Property Height() As Integer
'                Get
'                    Return (Me.bottom - Me.top)
'                End Get
'            End Property

'            Public ReadOnly Property Size() As Drawing.Size
'                Get
'                    Return New Drawing.Size(Me.Width, Me.Height)
'                End Get
'            End Property

'            Public ReadOnly Property Width() As Integer
'                Get
'                    Return (Me.right - Me.left)
'                End Get
'            End Property
'            Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, value As T) As T
'                target = value
'                Return value
'            End Function
'        End Structure

'        <StructLayout(LayoutKind.Sequential)> _
'        Public Structure SIZE
'            Public cx As Integer
'            Public cy As Integer
'        End Structure

'        ' Fields
'        Public Const DWM_BB_BLURREGION As Integer = 2
'        Public Const DWM_BB_ENABLE As Integer = 1
'        Public Const DWM_BB_TRANSITIONONMAXIMIZED As Integer = 4
'        Public Const DWM_COMPOSED_EVENT_BASE_NAME As String = "DwmComposedEvent_"
'        Public Const DWM_COMPOSED_EVENT_NAME_FORMAT As String = "%s%d"
'        Public Const DWM_COMPOSED_EVENT_NAME_MAX_LENGTH As Integer = &H40
'        Public Const DWM_FRAME_DURATION_DEFAULT As Integer = -1
'        Public Const DWM_TNP_OPACITY As Integer = 4
'        Public Const DWM_TNP_RECTDESTINATION As Integer = 1
'        Public Const DWM_TNP_RECTSOURCE As Integer = 2
'        Public Const DWM_TNP_SOURCECLIENTAREAONLY As Integer = &H10
'        Public Const DWM_TNP_VISIBLE As Integer = 8
'        Public Shared ReadOnly DwmApiAvailable As Boolean = (Environment.OSVersion.Version.Major >= 6)
'        Public Const WM_DWMCOMPOSITIONCHANGED As Integer = &H31E

'        ' Methods
'        <DllImport("dwmapi.dll")> _
'        Public Shared Function DwmDefWindowProc(hwnd As IntPtr, msg As Integer, wParam As IntPtr, lParam As IntPtr, ByRef result As IntPtr) As Integer
'        End Function
'        <DllImport("dwmapi.dll")> _
'        Public Shared Function DwmEnableComposition(fEnable As Integer) As Integer
'        End Function
'        <DllImport("dwmapi.dll")> _
'        Public Shared Function DwmEnableMMCSS(fEnableMMCSS As Integer) As Integer
'        End Function
'        <DllImport("dwmapi.dll")> _
'        Public Shared Function DwmExtendFrameIntoClientArea(hdc As IntPtr, ByRef marInset As MARGINS) As Integer
'        End Function
'        <DllImport("dwmapi.dll")> _
'        Public Shared Function DwmGetColorizationColor(ByRef pcrColorization As Integer, ByRef pfOpaqueBlend As Integer) As Integer
'        End Function
'        <DllImport("dwmapi.dll")> _
'        Public Shared Function DwmGetCompositionTimingInfo(hwnd As IntPtr, ByRef pTimingInfo As DWM_TIMING_INFO) As Integer
'        End Function
'        <DllImport("dwmapi.dll")> _
'        Public Shared Function DwmGetWindowAttribute(hwnd As IntPtr, dwAttribute As Integer, pvAttribute As IntPtr, cbAttribute As Integer) As Integer
'        End Function
'        <DllImport("dwmapi.dll")> _
'        Public Shared Function DwmIsCompositionEnabled(ByRef pfEnabled As Integer) As Integer
'        End Function
'        <DllImport("dwmapi.dll")> _
'        Public Shared Function DwmModifyPreviousDxFrameDuration(hwnd As IntPtr, cRefreshes As Integer, fRelative As Integer) As Integer
'        End Function
'        <DllImport("dwmapi.dll")> _
'        Public Shared Function DwmQueryThumbnailSourceSize(hThumbnail As IntPtr, ByRef pSize As SIZE) As Integer
'        End Function
'        <DllImport("dwmapi.dll")> _
'        Public Shared Function DwmRegisterThumbnail(hwndDestination As IntPtr, hwndSource As IntPtr, ByRef pMinimizedSize As SIZE, ByRef phThumbnailId As IntPtr) As Integer
'        End Function
'        <DllImport("dwmapi.dll")> _
'        Public Shared Function DwmSetDxFrameDuration(hwnd As IntPtr, cRefreshes As Integer) As Integer
'        End Function
'        <DllImport("dwmapi.dll")> _
'        Public Shared Function DwmSetPresentParameters(hwnd As IntPtr, ByRef pPresentParams As DWM_PRESENT_PARAMETERS) As Integer
'        End Function
'        <DllImport("dwmapi.dll")> _
'        Public Shared Function DwmSetWindowAttribute(hwnd As IntPtr, dwAttribute As Integer, pvAttribute As IntPtr, cbAttribute As Integer) As Integer
'        End Function
'        <DllImport("dwmapi.dll")> _
'        Public Shared Function DwmUnregisterThumbnail(hThumbnailId As IntPtr) As Integer
'        End Function
'        <DllImport("dwmapi.dll")> _
'        Public Shared Function DwmUpdateThumbnailProperties(hThumbnailId As IntPtr, ByRef ptnProperties As DWM_THUMBNAIL_PROPERTIES) As Integer
'        End Function

'        ' Nested Types
'        <StructLayout(LayoutKind.Sequential)> _
'        Public Structure DWM_BLURBEHIND
'            Public dwFlags As Integer
'            Public fEnable As Integer
'            Public hRgnBlur As IntPtr
'            Public fTransitionOnMaximized As Integer
'        End Structure

'        <StructLayout(LayoutKind.Sequential)> _
'        Public Structure DWM_PRESENT_PARAMETERS
'            Public cbSize As Integer
'            Public fQueue As Integer
'            Public cRefreshStart As Long
'            Public cBuffer As Integer
'            Public fUseSourceRate As Integer
'            Public rateSource As UNSIGNED_RATIO
'            Public cRefreshesPerFrame As Integer
'            Public eSampling As DWM_SOURCE_FRAME_SAMPLING
'        End Structure

'        Public Enum DWM_SOURCE_FRAME_SAMPLING
'            DWM_SOURCE_FRAME_SAMPLING_POINT
'            DWM_SOURCE_FRAME_SAMPLING_COVERAGE
'            DWM_SOURCE_FRAME_SAMPLING_LAST
'        End Enum

'        <StructLayout(LayoutKind.Sequential)> _
'        Public Structure DWM_THUMBNAIL_PROPERTIES
'            Public dwFlags As Integer
'            Public rcDestination As RECT
'            Public rcSource As RECT
'            Public opacity As Byte
'            Public fVisible As Integer
'            Public fSourceClientAreaOnly As Integer
'        End Structure

'        <StructLayout(LayoutKind.Sequential)> _
'        Public Structure DWM_TIMING_INFO
'            Public cbSize As Integer
'            Public rateRefresh As UNSIGNED_RATIO
'            Public rateCompose As UNSIGNED_RATIO
'            Public qpcVBlank As Long
'            Public cRefresh As Long
'            Public qpcCompose As Long
'            Public cFrame As Long
'            Public cRefreshFrame As Long
'            Public cRefreshConfirmed As Long
'            Public cFlipsOutstanding As Integer
'            Public cFrameCurrent As Long
'            Public cFramesAvailable As Long
'            Public cFrameCleared As Long
'            Public cFramesReceived As Long
'            Public cFramesDisplayed As Long
'            Public cFramesDropped As Long
'            Public cFramesMissed As Long
'        End Structure

'        Public Enum DWMNCRENDERINGPOLICY
'            DWMNCRP_USEWINDOWSTYLE
'            DWMNCRP_DISABLED
'            DWMNCRP_ENABLED
'        End Enum

'        Public Enum DWMWINDOWATTRIBUTE
'            DWMWA_ALLOW_NCPAINT = 4
'            DWMWA_CAPTION_BUTTON_BOUNDS = 5
'            DWMWA_FLIP3D_POLICY = 8
'            DWMWA_FORCE_ICONIC_REPRESENTATION = 7
'            DWMWA_LAST = 9
'            DWMWA_NCRENDERING_ENABLED = 1
'            DWMWA_NCRENDERING_POLICY = 2
'            DWMWA_NONCLIENT_RTL_LAYOUT = 6
'            DWMWA_TRANSITIONS_FORCEDISABLED = 3
'        End Enum

'        <StructLayout(LayoutKind.Sequential)> _
'        Public Structure UNSIGNED_RATIO
'            Public uiNumerator As Integer
'            Public uiDenominator As Integer
'        End Structure



'        <StructLayout(LayoutKind.Sequential)> _
'        Public Structure MARGINS
'            Public cxLeftWidth As Integer
'            Public cxRightWidth As Integer
'            Public cyTopHeight As Integer
'            Public cyBottomHeight As Integer
'            Public Sub New(Left As Integer, Right As Integer, Top As Integer, Bottom As Integer)
'                Me.cxLeftWidth = Left
'                Me.cxRightWidth = Right
'                Me.cyTopHeight = Top
'                Me.cyBottomHeight = Bottom
'            End Sub
'        End Structure


'        ''' <summary>
'        ''' Do Not Draw The Caption (Text)
'        ''' </summary>
'        Public Shared WTNCA_NODRAWCAPTION As UInteger = &H1
'        ''' <summary>
'        ''' Do Not Draw the Icon
'        ''' </summary>
'        Public Shared WTNCA_NODRAWICON As UInteger = &H2
'        ''' <summary>
'        ''' Do Not Show the System Menu
'        ''' </summary>
'        Public Shared WTNCA_NOSYSMENU As UInteger = &H4
'        ''' <summary>
'        ''' Do Not Mirror the Question mark Symbol
'        ''' </summary>
'        Public Shared WTNCA_NOMIRRORHELP As UInteger = &H8

'        ''' <summary>
'        ''' The Options of What Attributes to Add/Remove
'        ''' </summary>
'        <StructLayout(LayoutKind.Sequential)> _
'        Public Structure WTA_OPTIONS
'            Public Flags As UInteger
'            Public Mask As UInteger
'        End Structure

'        ''' <summary>
'        ''' What Type of Attributes? (Only One is Currently Defined)
'        ''' </summary>
'        Public Enum WindowThemeAttributeType
'            WTA_NONCLIENT = 1
'        End Enum

'        ''' <summary>
'        ''' Set The Window's Theme Attributes
'        ''' </summary>
'        ''' <param name="hWnd">The Handle to the Window</param>
'        ''' <param name="wtype">What Type of Attributes</param>
'        ''' <param name="attributes">The Attributes to Add/Remove</param>
'        ''' <param name="size">The Size of the Attributes Struct</param>
'        ''' <returns>If The Call Was Successful or Not</returns>
'        <DllImport("UxTheme.dll")> _
'        Public Shared Function SetWindowThemeAttribute(hWnd As IntPtr, wtype As WindowThemeAttributeType, ByRef attributes As WTA_OPTIONS, size As UInteger) As Integer
'        End Function
'    End Class

'#Region "WinAPI"



'    Namespace AeroNonClientButtons
'#Region "Api"
'        ' This is the default layout for a structure
'        <StructLayout(LayoutKind.Sequential)> _
'        Public Structure RECT
'            Public Left As Integer
'            Public Top As Integer
'            Public Right As Integer
'            Public Bottom As Integer
'        End Structure

'        ''' <summary>
'        ''' The NCCALCSIZE_PARAMS structure contains information that an application can use 
'        ''' while processing the WM_NCCALCSIZE message to calculate the size, position, and 
'        ''' valid contents of the client area of a window. 
'        ''' </summary>
'        ' This is the default layout for a structure
'        <StructLayout(LayoutKind.Sequential)> _
'        Public Structure NCCALCSIZE_PARAMS
'            Public rect0 As RECT, rect1 As RECT, rect2 As RECT
'            ' Can't use an array here so simulate one
'            Public lppos As IntPtr
'        End Structure
'#End Region

'        Public Enum Win32Messages As UInteger
'            WM_NULL = &H0
'            WM_CREATE = &H1
'            WM_DESTROY = &H2
'            WM_MOVE = &H3
'            WM_SIZE = &H5
'            WM_ACTIVATE = &H6
'            WM_SETFOCUS = &H7
'            WM_KILLFOCUS = &H8
'            WM_ENABLE = &HA
'            WM_SETREDRAW = &HB
'            WM_SETTEXT = &HC
'            WM_GETTEXT = &HD
'            WM_GETTEXTLENGTH = &HE
'            WM_PAINT = &HF
'            WM_CLOSE = &H10
'            WM_QUERYENDSESSION = &H11
'            WM_QUERYOPEN = &H13
'            WM_ENDSESSION = &H16
'            WM_QUIT = &H12
'            WM_ERASEBKGND = &H14
'            WM_SYSCOLORCHANGE = &H15
'            WM_SHOWWINDOW = &H18
'            WM_WININICHANGE = &H1A
'            WM_SETTINGCHANGE = WM_WININICHANGE
'            WM_DEVMODECHANGE = &H1B
'            WM_ACTIVATEAPP = &H1C
'            WM_FONTCHANGE = &H1D
'            WM_TIMECHANGE = &H1E
'            WM_CANCELMODE = &H1F
'            WM_SETCURSOR = &H20
'            WM_MOUSEACTIVATE = &H21
'            WM_CHILDACTIVATE = &H22
'            WM_QUEUESYNC = &H23
'            WM_GETMINMAXINFO = &H24
'            WM_PAINTICON = &H26
'            WM_ICONERASEBKGND = &H27
'            WM_NEXTDLGCTL = &H28
'            WM_SPOOLERSTATUS = &H2A
'            WM_DRAWITEM = &H2B
'            WM_MEASUREITEM = &H2C
'            WM_DELETEITEM = &H2D
'            WM_VKEYTOITEM = &H2E
'            WM_CHARTOITEM = &H2F
'            WM_SETFONT = &H30
'            WM_GETFONT = &H31
'            WM_SETHOTKEY = &H32
'            WM_GETHOTKEY = &H33
'            WM_QUERYDRAGICON = &H37
'            WM_COMPAREITEM = &H39
'            WM_GETOBJECT = &H3D
'            WM_COMPACTING = &H41
'            WM_COMMNOTIFY = &H44
'            WM_WINDOWPOSCHANGING = &H46
'            WM_WINDOWPOSCHANGED = &H47
'            WM_POWER = &H48
'            WM_COPYDATA = &H4A
'            WM_CANCELJOURNAL = &H4B
'            WM_NOTIFY = &H4E
'            WM_INPUTLANGCHANGEREQUEST = &H50
'            WM_INPUTLANGCHANGE = &H51
'            WM_TCARD = &H52
'            WM_HELP = &H53
'            WM_USERCHANGED = &H54
'            WM_NOTIFYFORMAT = &H55
'            WM_CONTEXTMENU = &H7B
'            WM_STYLECHANGING = &H7C
'            WM_STYLECHANGED = &H7D
'            WM_DISPLAYCHANGE = &H7E
'            WM_GETICON = &H7F
'            WM_SETICON = &H80
'            WM_NCCREATE = &H81
'            WM_NCDESTROY = &H82
'            WM_NCCALCSIZE = &H83
'            WM_NCHITTEST = &H84
'            WM_NCPAINT = &H85
'            WM_NCACTIVATE = &H86
'            WM_GETDLGCODE = &H87
'            WM_SYNCPAINT = &H88
'            WM_NCMOUSEMOVE = &HA0
'            WM_NCLBUTTONDOWN = &HA1
'            WM_NCLBUTTONUP = &HA2
'            WM_NCLBUTTONDBLCLK = &HA3
'            WM_NCRBUTTONDOWN = &HA4
'            WM_NCRBUTTONUP = &HA5
'            WM_NCRBUTTONDBLCLK = &HA6
'            WM_NCMBUTTONDOWN = &HA7
'            WM_NCMBUTTONUP = &HA8
'            WM_NCMBUTTONDBLCLK = &HA9
'            WM_NCXBUTTONDOWN = &HAB
'            WM_NCXBUTTONUP = &HAC
'            WM_NCXBUTTONDBLCLK = &HAD
'            WM_INPUT = &HFF
'            WM_KEYFIRST = &H100
'            WM_KEYDOWN = &H100
'            WM_KEYUP = &H101
'            WM_CHAR = &H102
'            WM_DEADCHAR = &H103
'            WM_SYSKEYDOWN = &H104
'            WM_SYSKEYUP = &H105
'            WM_SYSCHAR = &H106
'            WM_SYSDEADCHAR = &H107
'            WM_UNICHAR = &H109
'            WM_KEYLAST = &H108
'            WM_IME_STARTCOMPOSITION = &H10D
'            WM_IME_ENDCOMPOSITION = &H10E
'            WM_IME_COMPOSITION = &H10F
'            WM_IME_KEYLAST = &H10F
'            WM_INITDIALOG = &H110
'            WM_COMMAND = &H111
'            WM_SYSCOMMAND = &H112
'            WM_TIMER = &H113
'            WM_HSCROLL = &H114
'            WM_VSCROLL = &H115
'            WM_INITMENU = &H116
'            WM_INITMENUPOPUP = &H117
'            WM_MENUSELECT = &H11F
'            WM_MENUCHAR = &H120
'            WM_ENTERIDLE = &H121
'            WM_MENURBUTTONUP = &H122
'            WM_MENUDRAG = &H123
'            WM_MENUGETOBJECT = &H124
'            WM_UNINITMENUPOPUP = &H125
'            WM_MENUCOMMAND = &H126
'            WM_CHANGEUISTATE = &H127
'            WM_UPDATEUISTATE = &H128
'            WM_QUERYUISTATE = &H129
'            WM_CTLCOLOR = &H19
'            WM_CTLCOLORMSGBOX = &H132
'            WM_CTLCOLOREDIT = &H133
'            WM_CTLCOLORLISTBOX = &H134
'            WM_CTLCOLORBTN = &H135
'            WM_CTLCOLORDLG = &H136
'            WM_CTLCOLORSCROLLBAR = &H137
'            WM_CTLCOLORSTATIC = &H138
'            WM_MOUSEFIRST = &H200
'            WM_MOUSEMOVE = &H200
'            WM_LBUTTONDOWN = &H201
'            WM_LBUTTONUP = &H202
'            WM_LBUTTONDBLCLK = &H203
'            WM_RBUTTONDOWN = &H204
'            WM_RBUTTONUP = &H205
'            WM_RBUTTONDBLCLK = &H206
'            WM_MBUTTONDOWN = &H207
'            WM_MBUTTONUP = &H208
'            WM_MBUTTONDBLCLK = &H209
'            WM_MOUSEWHEEL = &H20A
'            WM_XBUTTONDOWN = &H20B
'            WM_XBUTTONUP = &H20C
'            WM_XBUTTONDBLCLK = &H20D
'            WM_MOUSELAST = &H20D
'            WM_PARENTNOTIFY = &H210
'            WM_ENTERMENULOOP = &H211
'            WM_EXITMENULOOP = &H212
'            WM_NEXTMENU = &H213
'            WM_SIZING = &H214
'            WM_CAPTURECHANGED = &H215
'            WM_MOVING = &H216
'            WM_POWERBROADCAST = &H218
'            WM_DEVICECHANGE = &H219
'            WM_MDICREATE = &H220
'            WM_MDIDESTROY = &H221
'            WM_MDIACTIVATE = &H222
'            WM_MDIRESTORE = &H223
'            WM_MDINEXT = &H224
'            WM_MDIMAXIMIZE = &H225
'            WM_MDITILE = &H226
'            WM_MDICASCADE = &H227
'            WM_MDIICONARRANGE = &H228
'            WM_MDIGETACTIVE = &H229
'            WM_MDISETMENU = &H230
'            WM_ENTERSIZEMOVE = &H231
'            WM_EXITSIZEMOVE = &H232
'            WM_DROPFILES = &H233
'            WM_MDIREFRESHMENU = &H234
'            WM_IME_SETCONTEXT = &H281
'            WM_IME_NOTIFY = &H282
'            WM_IME_CONTROL = &H283
'            WM_IME_COMPOSITIONFULL = &H284
'            WM_IME_SELECT = &H285
'            WM_IME_CHAR = &H286
'            WM_IME_REQUEST = &H288
'            WM_IME_KEYDOWN = &H290
'            WM_IME_KEYUP = &H291
'            WM_MOUSEHOVER = &H2A1
'            WM_MOUSELEAVE = &H2A3
'            WM_NCMOUSELEAVE = &H2A2
'            WM_WTSSESSION_CHANGE = &H2B1
'            WM_TABLET_FIRST = &H2C0
'            WM_TABLET_LAST = &H2DF
'            WM_CUT = &H300
'            WM_COPY = &H301
'            WM_PASTE = &H302
'            WM_CLEAR = &H303
'            WM_UNDO = &H304
'            WM_RENDERFORMAT = &H305
'            WM_RENDERALLFORMATS = &H306
'            WM_DESTROYCLIPBOARD = &H307
'            WM_DRAWCLIPBOARD = &H308
'            WM_PAINTCLIPBOARD = &H309
'            WM_VSCROLLCLIPBOARD = &H30A
'            WM_SIZECLIPBOARD = &H30B
'            WM_ASKCBFORMATNAME = &H30C
'            WM_CHANGECBCHAIN = &H30D
'            WM_HSCROLLCLIPBOARD = &H30E
'            WM_QUERYNEWPALETTE = &H30F
'            WM_PALETTEISCHANGING = &H310
'            WM_PALETTECHANGED = &H311
'            WM_HOTKEY = &H312
'            WM_PRINT = &H317
'            WM_PRINTCLIENT = &H318
'            WM_APPCOMMAND = &H319
'            WM_THEMECHANGED = &H31A
'            WM_HANDHELDFIRST = &H358
'            WM_HANDHELDLAST = &H35F
'            WM_AFXFIRST = &H360
'            WM_AFXLAST = &H37F
'            WM_PENWINFIRST = &H380
'            WM_PENWINLAST = &H38F
'            WM_USER = &H400
'            WM_REFLECT = &H2000
'            WM_APP = &H8000
'        End Enum
'    End Namespace

'    '=======================================================
'    'Service provided by Telerik (www.telerik.com)
'    'Conversion powered by NRefactory.
'    'Twitter: @telerik
'    'Facebook: facebook.com/telerik
'    '=======================================================

'#End Region

'End Namespace

''=======================================================
''Service provided by Telerik (www.telerik.com)
''Conversion powered by NRefactory.
''Twitter: @telerik
''Facebook: facebook.com/telerik
''=======================================================
