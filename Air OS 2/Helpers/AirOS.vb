Public Module AirOS

    Public ReadOnly Property OSDataPath As String
        Get
            Return Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\AppData\Local\AirOS_Config"
        End Get
    End Property
End Module
