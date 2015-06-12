Public Module AirOS

    Public ReadOnly Property OSDataPath As String
        Get
            Return Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\AppData\Local\AirOS_Config"
        End Get
    End Property

    Private _currentuser As String = ""
    Public Property CurrentUser As String
        Get
            Return _currentuser
        End Get
        Set(value As String)
            _currentuser = value
        End Set
    End Property

    'GLOBAL USER VARIABLES AND WILL ALWAYS CHANGE ON NEW LOGIN SO NO WORRIES... :)
    Private _pw As String = ""
    Public Property UserPassword As String
        Get
            Return _pw
        End Get
        Set(value As String)
            _pw = value
        End Set
    End Property

    Private _name As String = ""
    Public Property UserFullName As String
        Get
            Return _name
        End Get
        Set(value As String)
            _name = value
        End Set
    End Property

    Private _profile As Image = My.Resources.person
    Public Property UserProfile As Image
        Get
            Return _profile
        End Get
        Set(value As Image)
            _profile = value
        End Set
    End Property

End Module
