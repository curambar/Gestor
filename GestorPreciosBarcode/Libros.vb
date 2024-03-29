﻿Public Class Libros
    Public id As Integer
    Public titulo As String
    Public autor As String
    Public isbn As String
    Public editorial As String
    Public pvp As Integer
    Public mes As Integer
    Public año As Integer
    Public sello As String
    Public tema As String
    Public array() As String

    Sub New(ByVal libro() As String)
        id = CInt(libro(9))
        titulo = libro(0)
        autor = libro(1)
        isbn = libro(2)
        editorial = libro(3)
        pvp = CInt(libro(4))
        mes = CInt(libro(5))
        año = CInt(libro(6))
        sello = libro(7)
        tema = libro(8)

        libro(2) = "`" & libro(2)
        libro(9) = id.ToString
        array = libro
    End Sub

    Function fecha() As String
        Return (mes.ToString.PadLeft(2, "0") & "/" & año.ToString.PadLeft(2, "0"))
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
        mes = CInt(aux(5))
        año = CInt(aux(6))
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