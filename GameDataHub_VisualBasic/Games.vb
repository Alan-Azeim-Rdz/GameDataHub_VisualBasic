Public Class Games
    Public Property id As String
    Public Property name As String
    Public Property developer As String
    Public Property platform As String
    Public Property genre As String
    Public Property imageUrl As String

    ' CONSTRUCTOR
    Public Sub New()
        id = String.Empty
        name = String.Empty
        developer = String.Empty
        platform = String.Empty
        genre = String.Empty
        imageUrl = String.Empty
    End Sub
    Public Sub New(id As String, name As String, developer As String, platform As String, genre As String, imageUel As String)
        Me.id = id
        Me.name = name
        Me.developer = developer
        Me.platform = platform
        Me.genre = genre
        imageUrl = imageUel
    End Sub

End Class
