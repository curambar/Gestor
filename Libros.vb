Public Class Libros
    Public id As Integer
    Public titulo As String
    Public autor As String
    Public isbn As String
    Public editorial As String
    Public pvp As Integer
    Public mes As String
    Public año As String
    Public sello As String
    Public tema As String
    Public array() As String

    Sub New(ByVal libro() As String, index As Integer)
        titulo = libro(0)
        autor = libro(1)
        isbn = FuncionesTexto.ExtraeNumeros(libro(2))
        editorial = libro(3)
        'pvp = CInt(libro(4))
        'pvp = Subrutinas.Redondea(Globales.recargo * CInt(libro(4)), 100)
        pvp = Subrutinas.Redondea(CInt(libro(4)), 100)
        mes = libro(5)
        año = libro(6)
        sello = libro(7)
        tema = libro(8)
        libro(2) = "`" + isbn
        array = libro
        id = index
    End Sub
    Function fecha() As String
        Return (mes.PadLeft(2, "0") & "/" & año.PadLeft(2, "0"))
    End Function
    Function linea() As String
        Return String.Join(";", array)
    End Function
    Sub updateFromArray(aux() As String)
        array = aux
        titulo = aux(0)
        autor = aux(1)
        isbn = aux(2)
        editorial = aux(3)
        pvp = CInt(aux(4))
        mes = aux(5)
        año = aux(6)
        sello = aux(7)
        tema = aux(8)
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