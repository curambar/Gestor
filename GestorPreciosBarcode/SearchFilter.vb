Public Class SearchFilter
    Public text As String
    Public type As FilterType
    Public setDate As Date
    Public isStrict As Boolean

    Enum FilterType
        title
        author
        isbn
        publisher
        label
        description
        setDate
        isCustom
    End Enum

    Sub New(ByVal input As String)
        Dim filterArray() As String
        filterArray = Parse(input)
        If IsNothing(filterArray) Then Return
        isStrict = False
        text = NormalizeText(filterArray(1))
        type = Validate(filterArray(0))
        If type = FilterType.setDate Then
            Try
                setDate = DateTime.ParseExact(Me.text, "yyMMdd", System.Globalization.CultureInfo.InvariantCulture)
            Catch ex As Exception
                Try
                    setDate = DateTime.ParseExact(Me.text, "yyMM", System.Globalization.CultureInfo.InvariantCulture)
                Catch ex2 As Exception
                    Return
                End Try
                Return
            End Try
        End If
        If text.Contains("$") Then isStrict = True
        text.Replace("$", "")
    End Sub

    Private Function Parse(filterText As String) As String()
        Dim parseResult(2) As String

        If filterText = "" Then Return Nothing
        Try
            parseResult = filterText.Split(":")
        Catch ex As Exception
            Return Nothing
        End Try

        Return parseResult
    End Function

    Private Function Validate(filterTypeText As String) As FilterType
        Select Case filterTypeText
            Case "t", "titulo", "tit", "título"
                Return FilterType.title
            Case "a", "autor", "aut"
                Return FilterType.author
            Case "e", "edit", "editorial"
                Return FilterType.publisher
            Case "s", "sello"
                Return FilterType.label
            Case "tema", "d", "desc", "descripcion"
                Return FilterType.description
            Case "f", "fecha"
                Return FilterType.setDate
            Case "m", "mod", "modificado"
                Return FilterType.isCustom
            Case Else
                Return Nothing
        End Select
    End Function

End Class
