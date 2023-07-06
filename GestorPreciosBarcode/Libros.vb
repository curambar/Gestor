Imports Buscador.Tools
Public Class BookData
    Public id As Integer
    Public title As String
    Public author As String
    Public isbn As String
    Public publisher As String
    Public label As String
    Public description As String
    Public price As Integer
    Public textDate As String
    Public isCustom As Boolean
    Public array() As String

    Sub New(ByVal bookArray() As String, index As Integer)
        If True Then

        End If
        title = bookArray(0)
        author = bookArray(1)
        isbn = TextTools.NumericSubstring(bookArray(2))
        'TODO:
        'verificar isbn, convertir a isbn13
        publisher = bookArray(3)
        label = bookArray(4)
        description = bookArray(5)
        price = Tools.RoundUp(CInt(bookArray(6)), 100)
        textDate = bookArray(7).Replace("*", "")
        isCustom = (bookArray(8) = "1")
        bookArray(2) = "*" + isbn
        array = bookArray
        id = index
    End Sub

    Function setDate() As Date
        Dim tempDate As Date
        tempDate = Date.ParseExact(textDate, "yyMMdd HH:mm", System.Globalization.CultureInfo.InvariantCulture)
        Return tempDate
    End Function

    Function line() As String
        Return String.Join(";", array)
    End Function
    Sub updateFromArray(aux() As String)
        'TODO:
        'Ver si se puede modificar el item directamente para descartar esta subrutina
        array = aux
        title = aux(0)
        author = aux(1)
        isbn = aux(2)
        publisher = aux(3)
        label = aux(4)
        description = aux(5)
        price = CInt(aux(6))
        textDate = aux(7)
        isCustom = aux(8)
    End Sub
End Class

Public Class EntradaHistorial
    Public input As String
    Public momento As Date
    Public resultadosBusqueda As List(Of Integer)

    Sub New(ByVal _input As String, _resultados As List(Of Integer))
        input = _input
        momento = Now()
        resultadosBusqueda = _resultados
    End Sub
End Class