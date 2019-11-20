Public Class Libros
    Public dato(0 To 6) As String

    Sub New(ByVal libro())
        For i = 0 To 6
            dato(i) = libro(i)
        Next
    End Sub
End Class
