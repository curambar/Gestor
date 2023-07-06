Imports System.Text
Imports System.Globalization
Module TextTools

    Public Function NumericSubstring(text As String) As String
        Dim charToRemoveArray As Char()
        Dim sbText As New StringBuilder(text.Length)
        Dim ch As Char

        charToRemoveArray = {"*"}
        text.Trim(charToRemoveArray)
        For Each ch In text
            If Char.IsDigit(ch) Then sbText.Append(ch)
        Next
        Return sbText.ToString
    End Function

    Public Sub CopyToClipboard(title As String, isbn As String, publisher As String, label As String, price As String)
        Dim text As String
        If label <> "-" And label <> "" Then
            publisher += " - " + label
        End If
        text = "1" & Chr(9) & title & Chr(9) & "`" & isbn & Chr(9) & publisher & Chr(9) & price
        Try
            Clipboard.SetText(text)
        Catch ex As Exception
            MsgBox("Error al copiar texto al portapapeles" + vbCrLf + "Mensaje de error: " + ex.ToString)
        End Try
    End Sub

    Public Function NormalizeText(text As String) As String
        Dim textFormD As String = text.Normalize(NormalizationForm.FormD)
        Dim sb As New StringBuilder
        For i As Integer = 0 To textFormD.Length - 1
            Dim uc As UnicodeCategory = CharUnicodeInfo.GetUnicodeCategory(textFormD(i))
            If uc <> UnicodeCategory.NonSpacingMark Then sb.Append(textFormD(i))
        Next i
        Return (sb.ToString().Normalize(NormalizationForm.FormC).ToUpper)
    End Function

End Module
