Imports System.Text
Imports System.Globalization

Module FuncionesTexto

    Public Function ExtraeNumeros(texto As String) As String
        'Toma una cadena de caracteres cualquiera y devuelve la subcadena de caracteres puramente numéricos
        'Por ejemplo, "A12BCD45-sarasa" --> "1245"
        If texto = "" Then Return ("")
        Dim sbTexto As New StringBuilder(texto.Length)
        Dim ch As Char

        For Each ch In texto
            If Char.IsDigit(ch) Then sbTexto.Append(ch)
        Next

        Return sbTexto.ToString

    End Function

    Public Sub PortaPapeles(titulo As String, isbn As String, editorial As String, sello As String, pvp As String)
        'Copia los datos al portapapeles para pegar en la planilla de ventas,
        'y agrega el caracter "´" al ISBN
        If sello <> "-" And sello <> "" Then
            editorial = editorial & " - " & sello
        End If
        Clipboard.SetText("1" & Chr(9) & titulo & Chr(9) & "`" & isbn & _
                          Chr(9) & editorial & Chr(9) & pvp)
    End Sub

    Public Function QuitaAcentos(texto As String) As String
        'Toma una cadena de caracteres cualquiera y devuelve la subcadena de caracteres puramente alfanuméricos
        'Por ejemplo, "áéíóú sarasa" --> "aeiou sarasa"

        Dim textoFormD As String = texto.Normalize(NormalizationForm.FormD)
        Dim sb As New StringBuilder

        For i As Integer = 0 To textoFormD.Length - 1
            Dim uc As UnicodeCategory = CharUnicodeInfo.GetUnicodeCategory(textoFormD(i))
            If uc <> UnicodeCategory.NonSpacingMark Then sb.Append(textoFormD(i))
        Next i

        Return (sb.ToString().Normalize(NormalizationForm.FormC))
    End Function

    Public Function FechaHora() As String
        Return Now.ToString("yy;MM;dd;hh;mm;ss")
    End Function

    Public Function LineaAños() As String
        Dim linea As New List(Of String)
        For i As Integer = 10 To 22
            linea.Add(i.ToString)
        Next
        Return String.Join(";", linea)
    End Function
    Public Function LineaTasas(tasa As List(Of Single)) As String
        Return String.Join(";", tasa)
    End Function

End Module
