Public Class Globales
    Public Shared libro As New List(Of BookData)
    Public Shared tasa As New List(Of Integer)
    Public Shared historial As New List(Of EntradaHistorial)
    Public Shared hora As String
    Public Shared recargo As Decimal = 10 / 9
    Public Shared darkColor As Color = Color.FromArgb(32, 32, 32)
    Public Shared hue As Integer = 0
    Public Shared authorList As New List(Of String)
    Public Shared publisherList As New Dictionary(Of String, List(Of String))

End Class
