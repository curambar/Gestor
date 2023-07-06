Imports Buscador.Globales
'Imports Microsoft.Office.Interop
Imports System.IO
Imports Buscador

Public Module Tools

    Public Sub EditMode(pnl As Control)
        Dim currentPanelBackcolor As Color = pnl.BackColor
        Dim tblist As List(Of TextBox) = GetControls(Of TextBox)(pnl)
        Dim row, column As Integer

        pnl.BackColor = Color.Turquoise

        For Each tBox As TextBox In tblist
            row = CInt(tBox.Tag) Mod 5
            column = CInt(tBox.Tag) \ 5
            With tBox
                .Size = New Size(120, 25)
                .Location = New Point(190 * column + 60, 25 * row)
                .BorderStyle = BorderStyle.FixedSingle
                .Font = New Font(New FontFamily("Arial"), 16, FontStyle.Bold, GraphicsUnit.Pixel)
                .ForeColor = Color.Black
                .BackColor = Color.White
                .Enabled = True
            End With
        Next


    End Sub


    Public Sub DisplayMode(pnl As Control)
        Dim tbList As List(Of TextBox) = GetControls(Of TextBox)(pnl)
        Dim fontFamily As New FontFamily("Arial")
        Dim bigFont As New Font(fontFamily, 32, FontStyle.Bold, GraphicsUnit.Pixel)
        Dim mediumFont As New Font(fontFamily, 16, FontStyle.Bold, GraphicsUnit.Pixel)
        Dim smallFont As New Font(fontFamily, 10, FontStyle.Bold, GraphicsUnit.Pixel)

        For Each tBox As TextBox In tbList
            Dim i As Integer = CInt(tBox.Tag)
            With tBox
                .BackColor = Color.FromArgb(32, 32, 32)
                .ForeColor = Color.FromArgb(192, 192, 192)
                .BorderStyle = BorderStyle.None
                .CharacterCasing = CharacterCasing.Upper
                .TextAlign = HorizontalAlignment.Center
                .Width = 188
                .Height = 25
                .Font = mediumFont
                .ReadOnly = True

                Select Case i
                    Case 0
                        .Tag = "Title"
                        .Height = 40
                        .Width = 376
                        .Location = New Point(0, 0)
                        .Text = "Titulo"
                        .Font = bigFont
                        .ForeColor = Color.FromArgb(192, 192, 0)
                    Case 1
                        .Tag = "Author"
                        .Location = New Point(0, 40)
                        .Text = "autor"
                    Case 2
                        .Tag = "Publisher"
                        .Location = New Point(189, 40)
                        .Text = "editorial"
                    Case 3
                        .Tag = "ISBN"
                        .Location = New Point(0, 65)
                        .Text = "isbn"
                    Case 4
                        .Tag = "Editorial"
                        .Location = New Point(189, 65)
                        .Text = "sello"
                    Case 5
                        .Tag = "PriceAdjusted"
                        .Height = 40
                        .Font = bigFont
                        .ForeColor = Color.Cyan
                        .Location = New Point(0, 90)
                        .Text = "PVP"
                    Case 6
                        .Tag = "PriceBase"
                        .Location = New Point(189, 90)
                        .Height = 20
                        .ForeColor = Color.SpringGreen
                        .Text = "PVP base"
                    Case 7
                        .Tag = "DateAndProjected"
                        .Location = New Point(189, 110)
                        .Height = 20
                        .ForeColor = Color.DarkSalmon
                        .Text = "Fecha + proyectado"
                    Case 8
                        .Tag = "Description"
                        .Location = New Point(0, 130)
                        .Height = 25
                        .Width = 185
                        .Text = "Tema"
                    Case 9

                    Case Else
                End Select
            End With
        Next

    End Sub


    Public Function ValidateDate(yearint As Integer, monthInt As String) As Date
        Try
            Return New DateTime(yearint, monthInt, 1)
        Catch ex As Exception
            Return DateTime.MinValue
        End Try

    End Function


    Public Sub InitialSetup()
        libro.Clear()
        tasa = GetRates()
        libro = LoadBooks("Precios.csv")
        BackupBookData()
    End Sub
    Private Function LoadBooks(filePath As String) As List(Of BookData)
        Dim bookList As New List(Of BookData)
        Dim stringList As New List(Of String())
        stringList = CsvToList(filePath)
        'From 1 to skip the header row
        For i As Integer = 1 To stringList.Count - 1
            If stringList(i).Count <> 9 Then
                Dim text As String
                text = "Error en archivo Precios.csv en línea " + i.ToString
                text += vbCrLf + "Número de elementos incorrecto"
                text += vbCrLf + stringList(i).ToString
                MsgBox(text, vbOKOnly)
                Return Nothing
            End If
            bookList.Add(New BookData(stringList(i), i))
        Next
        Return bookList
    End Function
    Public Sub BackupBookData()
        Dim i As Integer
        For i = 8 To 0 Step -1
            Dim name1 As String = "Backup\Precios" + i.ToString + ".csv"
            Dim name2 As String = "Backup\Precios" + (i + 1).ToString + ".csv"
            If System.IO.File.Exists(name1) Then
                My.Computer.FileSystem.CopyFile(name1, name2, True)
            End If
        Next
        System.IO.File.Copy("Precios.csv", "Backup\Precios0.csv", True)
    End Sub
    Public Function GetRates() As List(Of Integer)
        Dim fileName As String = "Tasas.txt"
        Dim rateList As New List(Of Integer)
        Dim sr As StreamReader
        Dim row As String
        sr = New StreamReader(fileName)
        While Not sr.EndOfStream
            row = sr.ReadLine
            rateList.Add(CInt(row))
        End While
        sr.Dispose()
        Return rateList
    End Function
    Public Function Search(input As String) As List(Of Integer)
        If input = "" Then Return Nothing
        Dim title, author, isbn, isbnInput As String
        Dim searchResults As New List(Of Integer)

        input = NormalizeText(input)
        If IsNumeric(input) And input.Length > 9 Then input = Mid(input, input.Length - 9, 9)
        'input = QuitaAcentos(input)

        For i As Integer = 0 To libro.Count - 1
            title = NormalizeText(libro(i).title)
            author = NormalizeText(libro(i).author)
            isbn = libro(i).isbn
            isbnInput = NumericSubstring(input)
            If isbnInput <> "" And isbnInput.Length > 4 And isbn.IndexOf(isbnInput) >= 0 Then searchResults.Add(i)
            If title.IndexOf(input) >= 0 Then searchResults.Add(i)
            If author.IndexOf(input) >= 0 Then searchResults.Add(i)
            If searchResults.Count > 50 Then
                MsgBox("Demasiados resultados, mostrando los primeros 50")
                Return searchResults
            End If
        Next i
        Return searchResults
    End Function
    Public Function SearchWithFilters(input As String) As List(Of Integer)
        'First we parse the input
        Dim inputArray() As String = input.Split(";")
        Dim filters As New List(Of SearchFilter)
        Dim searchResults As New List(Of Integer)
        Dim matchText As String
        Dim matches As Integer

        For Each filter As String In inputArray
            filters.Add(New SearchFilter(filter))

        Next
        For i As Single = 0 To libro.Count - 1
            matches = 0
            For Each filter As SearchFilter In filters
                If filter.type < 6 Then
                    'First 5 filters correspond directly to the 5 first book array strings
                    matchText = NormalizeText(libro(i).array(filter.type))
                    matches += GetMatches(filter.text, matchText, filter.isStrict)
                ElseIf filter.type = SearchFilter.FilterType.setDate Then
                    If libro(i).setDate >= filter.setDate Then matches += 1
                ElseIf filter.type = SearchFilter.FilterType.isCustom Then
                    If libro(i).isCustom = (filter.text = "1") Then matches += 1
                Else
                    MsgBox("Filtro desconocido: " & filter.type.ToString, vbOKOnly)
                    'TODO:
                    'Add list of valid filters
                    Return Nothing
                End If
            Next
            If matches = filters.Count Then searchResults.Add(i)
            If searchResults.Count > 50 Then
                MsgBox("Demasiados resultados, mostrando los primeros 50")
                Return searchResults
            End If
        Next i
        Return searchResults
    End Function

    Private Function GetMatches(toFind As String, text As String, strict As Boolean) As Integer
        If text.IndexOf(toFind) >= 0 Then
            If strict Then
                For Each word As String In text.Split(" ")
                    If word = toFind Then Return 1
                Next
                Return 0
            Else
                Return 1
            End If
        End If
        Return 0
    End Function

    Public Function PrepareRow(item As BookData) As ListViewItem
        Dim aux(0 To 8) As String
        Dim priceBase As Integer = item.price
        Dim priceAdjusted As Integer = RoundUp(priceBase * Globales.recargo, 100)
        Dim priceProjected As Integer = ApplyInterest(item.setDate, priceAdjusted)
        aux(0) = item.title
        aux(1) = item.author
        aux(2) = item.isbn
        aux(3) = item.publisher
        aux(4) = CStr(priceAdjusted)
        aux(5) = item.setDate().ToString("MM/yy")
        aux(6) = CStr(priceProjected)
        aux(7) = item.label
        aux(8) = item.description
        Try
            CopyToClipboard(item.title, item.isbn, item.publisher, item.label, CStr(priceAdjusted))
        Catch ex As Exception
            MsgBox("Error al copiar al portapapeles" + vbCrLf + "Mensaje del error: " + ex.ToString)
        End Try
        Dim renglon As New ListViewItem(aux)
        If item.isCustom Then renglon.ForeColor = Color.Turquoise
        renglon.Name = item.id.ToString
        Return renglon
    End Function
    Public Function PreparaListviewItem(item As BookData) As ListViewItem
        Dim aux(0 To 8) As String
        Dim priceBase As Integer = item.price
        Dim priceAdjusted As Integer = RoundUp(priceBase * Globales.recargo, 100)
        Dim priceProjected As Integer = ApplyInterest(item.setDate, priceAdjusted)
        aux(0) = item.title
        aux(1) = item.author
        aux(2) = item.isbn
        aux(3) = item.publisher
        aux(4) = CStr(priceAdjusted)
        aux(5) = item.setDate.ToString("MM/YYYY")
        aux(6) = CStr(priceProjected)
        aux(7) = item.label
        aux(8) = item.description
        Try
            CopyToClipboard(item.title, item.isbn, item.publisher, item.label, CStr(priceAdjusted))
        Catch ex As Exception
            MsgBox("Error al copiar al portapapeles" + vbCrLf + "Mensaje del error: " + ex.ToString)
        End Try
        Dim renglon As New ListViewItem(aux)
        renglon.Name = item.id.ToString
        Return renglon
    End Function
    Public Sub AgregaItemAListview(renglon As ListViewItem, lview As ListView)
        Dim backColor(2) As Color
        backColor(0) = Color.FromArgb(32, 32, 32)
        backColor(1) = Color.FromArgb(64, 64, 64)
        renglon.BackColor = backColor(lview.Items.Count Mod 2)
        'If lview.Items.Count Mod 2 = 0 Then
        '    renglon.BackColor = backColor
        '    renglon.UseItemStyleForSubItems = True
        'End If
        lview.Items.Add(renglon)
    End Sub


    Public Sub EditaAgrega(item As BookData, nuevo As Boolean)
        'TODO:
        'Ver opciones, como separar en dos funciones
        If nuevo Then
            libro.Add(item)
        Else
            libro(item.id) = item
        End If
    End Sub
    Public Sub EditLibro(libro As BookData, valores() As String)
        'Reemplaza todos los valores de un libro; actualiza la fecha y lo marca como editado
        'TODO:
        'See if the book can be directly edited
        Dim mes As String = Month(Now).ToString
        Dim ano As String = (Year(Now) - 2000).ToString
        valores(5) = mes
        valores(6) = ano
        libro.updateFromArray(valores)
    End Sub
    Public Sub BulkEdit(listaId As List(Of Integer), nuevoValor As String, categoria As Integer)
        For Each x In listaId
            Dim aux() As String
            aux = libro(x).array
            aux(categoria) = nuevoValor
            EditLibro(libro(x), aux)
        Next
        SaveCSV()
    End Sub
    Public Sub BulkDelete(itemsSeleccionados As List(Of Integer))
        For Each x As Integer In itemsSeleccionados
            libro.RemoveAt(x)
        Next
        Dim i As Integer = 0
        For Each x As BookData In libro
            x.id = i
            i += 1
        Next
        SaveCSV()
    End Sub
    Public Sub DeleteBookAt(id As Integer)
        libro.RemoveAt(id)
        Dim i As Integer = 0
        For Each x In libro
            x.id = i
            i += 1
        Next
    End Sub
    Public Sub SaveCSV()
        Dim rootPath As String = System.AppDomain.CurrentDomain.BaseDirectory()
        Dim fileFullPath As String = My.Computer.FileSystem.CombinePath(rootPath, "Precios.csv")
        Dim fullText As New List(Of String)
        For Each x In libro
            fullText.Add(x.line)
        Next
        System.IO.File.WriteAllLines(fileFullPath, fullText, System.Text.Encoding.GetEncoding(1252))
        fullText = Nothing
    End Sub
    Friend Sub PopulateLists()
        authorList = GetAuthors()
        Dim publishers As List(Of String) = GetPublishers()
        For Each publisher In publishers
            publisherList.Add(publisher, GetLabels(publisher))
        Next
    End Sub
    Public Function GetPublishers() As List(Of String)
        Dim publisherList As New List(Of String)
        Dim bookList As New List(Of BookData)
        bookList = libro.Distinct.GroupBy(Function(x) x.publisher).Select(Function(d) d.First()).ToList()
        For Each item In bookList
            publisherList.Add(item.publisher)
        Next
        Return publisherList
    End Function
    Public Function GetLabels(publisher As String) As List(Of String)
        Dim labelList As New List(Of String)
        Dim bookList As New List(Of BookData)
        bookList = libro.Distinct.GroupBy(Function(x) x.label).Select(Function(d) d.First()).Where(Function(y) y.publisher = publisher).ToList
        For Each item In bookList
            labelList.Add(item.publisher)
        Next
        Return labelList
    End Function
    Public Function GetAuthors() As List(Of String)
        Dim authorList As New List(Of String)
        Dim listLibros As New List(Of BookData)
        listLibros = libro.Distinct.GroupBy(Function(x) x.author).Select(Function(d) d.First()).ToList()
        For Each item In listLibros
            authorList.Add(item.author)
        Next
        Return authorList
    End Function
    Public Function RoundUp(value As Decimal, min As Integer) As Integer
        Return ((min * Math.Ceiling(value / min)).ToString)
    End Function
    Public Sub MuestraHistorial()
        Dim fHistorial As New formHistorial
        fHistorial.Text = "Historial"
        fHistorial.Show()
    End Sub

    Public Sub UpdateByPublisher(filePath As String)
        Dim currentBookList, newBookList, updatedBookList As List(Of BookData)
        Dim publisher As String
        Dim result As DialogResult
        Dim textMsgbox As String

        newBookList = LoadBooks(filePath)
        publisher = newBookList(0).publisher
        textMsgbox = String.Format("Actualizar {0}?", publisher)
        result = MessageBox.Show(textMsgbox, "Confirmar", MessageBoxButtons.OKCancel,
                                 MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If result <> DialogResult.OK Then Return
        currentBookList = BooksByPublisher(publisher)
        updatedBookList = GetUpdatedBooks(currentBookList, newBookList)
        DeleteByPublisher(publisher)
        libro.AddRange(updatedBookList)
        SaveCSV()
    End Sub

    Public Function GetUpdatedBooks(oldBooks As List(Of BookData), newBooks As List(Of BookData)) As List(Of BookData)
        Dim updatedBooks As New List(Of BookData)
        Dim frm As Form = frmMain
        Dim pnl As Panel = frm.Controls("panelUpdate")
        Dim bar As ProgressBar = frm.Controls("pBar1")
        Dim progress As Integer
        Dim temp() As String

        bar.Maximum = oldBooks.Count
        bar.Visible = True

        For i As Integer = oldBooks.Count - 1 To 0 Step -1
            temp = oldBooks(i).array  'copia los datos del libro viejo
            bar.PerformStep()
            progress = CInt(100 - (100 * i / oldBooks.Count))

            For j As Integer = newBooks.Count - 1 To 0 Step -1
                Dim x As BookData = newBooks(j)
                If oldBooks(i).isbn = x.isbn Then     'Encuentra coincidencia de ISBN
                    'Al encontrar coincidencia de ISBN actualizamos los valores siempre que
                    'No este mas caro
                    'TODO:
                    'Agregar variable booleana allowDiscount para decidir si sobreescribir
                    'por un valor menor
                    If oldBooks(i).price <= x.price Then  'Si el nuevo es mas caro
                        temp(3) = x.publisher
                        temp(4) = x.label
                        If x.description <> "-" Then temp(5) = x.description
                        temp(6) = CStr(x.price)
                        temp(7) = Now.ToString("YYYY-MM-DD HH:mm")
                        temp(8) = 0     'TODO: Es automatizado? Agregar variable?
                    End If
                    newBooks.RemoveAt(j)          'finalmente elimina el libro nuevo ya usado
                    Exit For
                End If
                'Si no hubo coincidencia, el libro TEMP es igual al viejo
            Next
            'En cualquier caso, se agrega el libro viejo original o modificado
            'a la lista temporal, con su indice sin modificar
            updatedBooks.Add(New BookData(temp, i))
        Next

        bar.Visible = False
        'finalmente se agregan todos los libros newBooks restantes
        'con índices consecutivos
        Dim num As Integer = libro.Count
        For i As Integer = 0 To newBooks.Count - 1
            temp = newBooks(i).array
            updatedBooks.Add(New BookData(temp, i + num))
        Next
        Return updatedBooks
    End Function
    Private Function BooksByPublisher(publisher As String) As List(Of BookData)
        Return libro.Where(Function(x) x.publisher.IndexOf(publisher) >= 0).ToList
    End Function
    Public Function CsvToList(filePath As String) As List(Of String())
        Dim listString As New List(Of String())
        Using parser As New FileIO.TextFieldParser(filePath, System.Text.Encoding.GetEncoding(1252))
            parser.TextFieldType = FileIO.FieldType.Delimited
            parser.SetDelimiters(";")
            While Not parser.EndOfData
                listString.Add(parser.ReadFields)
            End While
        End Using
        Return listString
    End Function
    Private Sub DeleteByPublisher(publisher As String)
        For i As Integer = libro.Count - 1 To 0 Step -1
            If libro(i).publisher.IndexOf(publisher) >= 0 Then libro.RemoveAt(i)
        Next
    End Sub

    Public Function GetTextBoxes(TControl As Control) As List(Of TextBox)
        Dim textBoxes = New List(Of TextBox)
        For Each c As Control In TControl.Controls
            If TypeOf c Is TextBox Then
                textBoxes.Add(c)
            End If
        Next
        Return textBoxes
    End Function
    Public Function GetControls(Of T As Control)(ByVal parent As Control) As List(Of T)
        Dim Controls As New List(Of T)
        For Each ctrl As T In parent.Controls.OfType(Of T)()
            Controls.Add(ctrl)
        Next
        Return Controls
    End Function

    Public Sub ToggleControls(Of T As Control)(ByVal parent As Control)
        For Each ctrl As T In parent.Controls.OfType(Of T)()
            ctrl.Visible = Not ctrl.Visible
        Next
    End Sub


    Public Function ApplyInterest(setDate As Date, value As Integer) As Integer
        Dim stageIndex As Integer
        Dim currentMonth As Integer = Month(Now)
        Dim currentYear As Integer = Year(Now) - 2010
        Dim setMonth As Integer = Month(setDate)
        Dim setYear As Integer = Year(setDate) - 2010
        Dim monthList As New List(Of Integer)
        Dim yearList As New List(Of Integer)
        Dim finalPrice As Integer

        'Las tasas estan estructuradas en etapas:
        'Etapa 0 - Hasta el año 2010, inclusive = t0
        'Etapa 1 - Año 2011 = t1
        'Etapa 2 - Año 2012 = t2
        '...
        'Etapa 13 - Año 2023 = t13
        '
        'La cantidad de etapas debe ser igual a currentYear
        If tasa.Count < currentYear Then
            MsgBox("Actualice el archivo de tasas de interés")
            frmMain.Close()
            Return 0
        End If
        For i As Integer = 0 To currentYear
            'Estas variables guardan la cantidad de meses y años a aplicar por cada etapa
            'Esto es debido a que la etapa 0 es especial por aplicar a varios años
            'Por ejemplo, proyectar un libro del 09-2005 al 07-2023 aplicaria la etapa 0 de la siguiente manera:
            'Etapa 0 - meses 9 al 12 del año 2005 = 3 meses de interes a tasa t0
            'Etapa 0 - años completos del 2006 al 2010 = 5 años de interes a tasa t0
            'Etapa 1 - año 2011 a tasa t1
            '...
            'Etapa 13 - meses 1 al 7 del año 2023 = 6 meses de interes a tasa t13
            monthList.Add(0)
            yearList.Add(0)
        Next
        If setYear = currentYear Then
            'Solo tenemos los meses transcurridos en el año actual, con tasa tx,
            'guardamos esa cantidad en al array de meses correspondientes a la etapa x
            monthList(currentYear) += currentMonth - setMonth
            yearList(currentYear) = 0
        Else
            'En la etapa x guardamos los meses transcurridos de este año
            monthList(currentYear) = currentMonth - 1
            stageIndex = currentYear
            If stageIndex < 0 Then stageIndex = 0   'Esto asegura que los años anteriores a 2010 no generen un indice negativo
            monthList(stageIndex) = 13 - setMonth   'En el año dato solo aplican los meses entre mes dato y fin de año
            For i As Integer = stageIndex + 1 To currentYear - 1
                monthList(i) = 12   'Todos los años en el medio aplican los 12 meses completos
            Next
        End If
        If setYear < 1 Then
            'Si el año dato es 2010 o anterior, la cantidad de meses a aplicarle tasa t0 es
            '12 por cada año completo entre la fecha dato y finales de 2010,
            'y la cantidad especifica de meses entre la fecha dato y su fin de año
            Dim fullYearsElapsed As Integer = -setYear
            Dim monthsRemaining As Integer = 13 - setMonth
            monthList(0) = 12 * fullYearsElapsed + monthsRemaining
        End If

        'Aplicamos interes compuesto por los meses totales transcurridos
        finalPrice = value
        For i As Integer = 0 To currentYear
            yearList(i) = Math.Floor(monthList(i) / 12) 'Esto es para aplicar tasa t0 a los años enteros que corresponda
            monthList(i) = monthList(i) Mod 12  'Solo es mayor a cero si no es un año completo
            'Las tasas estan en valores porcentuales, convertimos a decimal
            Dim rate As Single = tasa(i) / 100
            finalPrice *= (1 + rate) ^ yearList(i)          'Aplicamos la tasa anual compuesta a los años completos
            finalPrice *= (1 + monthList(i) * rate / 12)    'Aplicamos tasa mensual simple a los años 'incompletos'
        Next
        Return RoundUp(finalPrice, 100)
    End Function

End Module
