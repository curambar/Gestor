Imports System.Text
Imports System.Globalization
Module FuncionesTexto
    ''' <summary>
    ''' Devuelve la subcadena numérica. De "a12bcd4" devuelve "124"
    ''' </summary>
    Public Function ExtraeNumeros(texto As String) As String
        If texto = "" Then Return ("")
        Dim sbTexto As New StringBuilder(texto.Length)
        Dim ch As Char
        For Each ch In texto
            If Char.IsDigit(ch) Then sbTexto.Append(ch)
        Next
        Return sbTexto.ToString
    End Function
    ''' <summary>
    ''' Copia los datos al portapapeles para pegar en la planilla de ventas agregando el caracter "`" al ISBN
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub PortaPapeles(titulo As String, isbn As String, editorial As String, sello As String, pvp As String)
        Dim texto As String
        If sello <> "-" And sello <> "" Then
            editorial = editorial & " - " & sello
        End If
        texto = "1" & Chr(9) & titulo & Chr(9) & "`" & isbn & Chr(9) & editorial & Chr(9) & pvp
        Try
            Clipboard.SetText(texto)
        Catch ex As Exception
            MsgBox("Error al copiar texto al portapapeles" + vbCrLf + "Mensaje de error: " + ex.ToString)
        End Try
    End Sub
    ''' <summary>
    ''' Devuelve la subcadena alfanumérica estándar en mayúsculas. Por ejemplo, "áéíóú" devuelve "AEIOU"
    ''' </summary>
    ''' <param name="texto"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function QuitaAcentos(texto As String) As String
        Dim textoFormD As String = texto.Normalize(NormalizationForm.FormD)
        Dim sb As New StringBuilder
        For i As Integer = 0 To textoFormD.Length - 1
            Dim uc As UnicodeCategory = CharUnicodeInfo.GetUnicodeCategory(textoFormD(i))
            If uc <> UnicodeCategory.NonSpacingMark Then sb.Append(textoFormD(i))
        Next i
        Return (sb.ToString().Normalize(NormalizationForm.FormC).ToUpper)
    End Function
End Module
