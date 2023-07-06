Imports Buscador.Globales
'Imports Microsoft.Office.Interop
Imports System.IO
Imports Buscador
Public Module Subrutinas
    Public Class Condicion
        Public input As String
        Public espacio As String
        Public estricto As Boolean
        Sub New(ByVal _espacio As String, ByVal _input As String)
            espacio = _espacio
            input = QuitaAcentos(_input)
            estricto = False
            If input.Substring(input.Length - 1) = "$" Then
                estricto = True
                input = input.Replace("$", "")
            End If
        End Sub
    End Class

    Public Sub CargaInicial()
        libro.Clear()
        libro = LoadBooks("Precios.csv")
        tasa = CargaTasas()
        ActualizaBackup()
    End Sub
    Private Function LoadBooks(filePath As String) As List(Of Libros)
        Dim listBooks As New List(Of Libros)
        Dim listString As New List(Of String())
        listString = CsvToList(filePath)
        For i As Integer = 0 To listString.Count - 1
            If listString(i).Count <> 9 Then
                Dim text As String
                text = "Error en archivo Precios.csv en línea " + i.ToString
                text += vbCrLf + "Número de elementos incorrecto"
                MsgBox(text, vbOKOnly)
                Return Nothing
            End If

            listBooks.Add(New Libros(listString(i), i))
        Next
        Return listBooks
    End Function
    Public Sub ActualizaBackup()
        Dim i As Integer
        For i = 8 To 0 Step -1
            Dim nombre1 As String = "Backup\Precios" + i.ToString + ".csv"
            Dim nombre2 As String = "Backup\Precios" + (i + 1).ToString + ".csv"
            If System.IO.File.Exists(nombre1) Then
                My.Computer.FileSystem.CopyFile(nombre1, nombre2, True)
            End If
        Next
        System.IO.File.Copy("Precios.csv", "Backup\Precios0.csv", True)
    End Sub
    Public Function CargaTasas() As List(Of Integer)
        Dim archivo As String = "Tasas.txt"
        Dim listaTasas As New List(Of Integer)
        Dim sr As StreamReader
        Dim linea As String
        sr = New StreamReader(archivo)
        While Not sr.EndOfStream
            linea = sr.ReadLine
            listaTasas.Add(CInt(linea))
        End While
        sr = Nothing
        Return listaTasas
    End Function
    Public Function Buscar(input As String) As List(Of Integer)
        If input = "" Then Return Nothing
        Dim titulo, autor, isbn, isbnInput As String
        Dim datosBusqueda As New List(Of Integer)
        If IsNumeric(input) And input.Length > 9 Then input = Mid(input, input.Length - 9, 9)
        input = QuitaAcentos(input)
        For i As Single = 0 To libro.Count - 1
            titulo = QuitaAcentos(libro(i).titulo)
            autor = QuitaAcentos(libro(i).autor)
            isbn = libro(i).isbn
            isbnInput = ExtraeNumeros(input)
            If isbnInput <> "" And isbnInput.Length > 4 And isbn.IndexOf(isbnInput) >= 0 Then datosBusqueda.Add(i)
            If titulo.IndexOf(input) >= 0 Then datosBusqueda.Add(i)
            If autor.IndexOf(input) >= 0 Then datosBusqueda.Add(i)
            If datosBusqueda.Count > 50 Then
                MsgBox("Demasiados resultados, mostrando los primeros 50")
                Return datosBusqueda
            End If
        Next i
        Return datosBusqueda
    End Function
    Public Function BusquedaPorCampos(inputEspacios As String) As List(Of Integer)
        Dim subInput() As String = inputEspacios.Split(";")
        Dim condiciones As New List(Of Condicion)
        Dim datosBusqueda As New List(Of Integer)
        Dim key() As String
        Dim texto As String
        Dim matches As Integer
        For Each x As String In subInput
            If x = "" Then Exit For
            key = x.Split(":")
            If key.Length <> 2 Then
                MsgBox("Busqueda avanzada mal formada, intente nuevamente")
                Return Nothing
            End If
            condiciones.Add(New Condicion(key(0), key(1)))
        Next
        For i As Single = 0 To libro.Count - 1
            matches = 0
            For Each x As Condicion In condiciones
                Select Case x.espacio
                    Case "id"
                        texto = libro(i).id
                    Case "titulo", "t"
                        texto = QuitaAcentos(libro(i).titulo)
                    Case "autor", "a"
                        texto = QuitaAcentos(libro(i).autor)
                    Case "editorial", "e"
                        texto = QuitaAcentos(libro(i).editorial)
                    Case "sello", "s"
                        texto = QuitaAcentos(libro(i).sello)
                    Case "tema"
                        texto = QuitaAcentos(libro(i).tema)
                    Case Else
                        MsgBox("espacio no reconocido: " & x.espacio, vbOKOnly)
                        Return Nothing
                End Select
                If texto.IndexOf(x.input) >= 0 Then
                    If x.estricto Then
                        Dim match As Boolean = False
                        For Each palabra As String In texto.Split(" ")
                            'If palabra = x.input Then match = True
                            match = (palabra = x.input)
                        Next
                        If match Then matches += 1
                    Else
                        matches += 1
                    End If
                End If
            Next
            If matches = condiciones.Count Then datosBusqueda.Add(i)
            If datosBusqueda.Count > 50 Then
                MsgBox("Demasiados resultados, mostrando los primeros 50")
                Return datosBusqueda
            End If
        Next i
        Return datosBusqueda
    End Function
    Public Function PreparaListviewItem(item As Libros) As ListViewItem
        Dim aux(0 To 8) As String
        Dim pvp As Integer = item.pvp
        Dim pvpRecargado As Integer = Redondea(pvp * Globales.recargo, 100)
        Dim pvpProyectado As Integer = Proyectar(item.mes, item.año - 10, pvpRecargado)
        pvpProyectado = Redondea(pvpProyectado, 100)
        aux(0) = item.titulo
        aux(1) = item.autor
        aux(2) = item.isbn
        aux(3) = item.editorial
        'aux(4) = item.pvp.ToString
        aux(4) = pvpRecargado.ToString
        aux(5) = item.fecha
        'aux(6) = Proyectar(item.mes, item.año - 10, item.pvp).ToString
        aux(6) = pvpProyectado.ToString
        aux(7) = item.sello
        aux(8) = item.tema
        Try
            PortaPapeles(item.titulo, item.isbn, item.editorial, item.sello, pvpRecargado.ToString)
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
    Public Function Project(setDate As Date, value As Integer) As Integer
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
            fMain.Close()
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
            Dim rateYear As Single = 1 + tasa(i) / 100
            Dim rateMonth As Single = 1 + tasa(i) / 1200
            finalPrice *= rateYear * yearList(i)    'Aplicamos la tasa anual a los años completos
            finalPrice *= rateMonth * monthList(i)  'Aplicamos la tasa mensual a los años 'incompletos'
        Next
        Return finalPrice
    End Function
    Public Function Proyectar(mesDato As Integer, anoDato As Integer, valor As Single) As Single
        Dim a_index As Integer
        Dim mesActual As Integer = Month(Now)
        Dim anoActual As Integer = Year(Now) - 2010
        Dim mes As New List(Of Integer)
        Dim ano As New List(Of Integer)
        Dim resultado As Integer
        If tasa.Count < anoActual Then
            MsgBox("Actualice el archivo de tasas de interés")
            fMain.Close()
            Return 0
        End If
        'Crea una variable por cada indice de tasa de interes para almacenar el tiempo transcurrido
        For i As Integer = 0 To anoActual
            mes.Add(0)
            ano.Add(0)
        Next i
        If anoDato = anoActual Then
            mes(anoActual) += mesActual - mesDato
            ano(anoActual) = 0
        Else
            mes(anoActual) = mesActual - 1
            a_index = anoDato
            If a_index < 0 Then a_index = 0
            mes(a_index) = 13 - mesDato
            For i = a_index + 1 To anoActual - 1
                mes(i) = 12
            Next i
        End If
        If anoDato < 1 Then mes(0) = 12 * (1 - anoDato) - mesDato + 1
        resultado = valor
        For i = 0 To anoActual
            ano(i) = Math.Floor(mes(i) / 12)
            mes(i) = mes(i) Mod 12
            resultado *= ((1 + tasa(i) / 100) ^ ano(i)) * (1 + tasa(i) * mes(i) / 1200)
        Next i
        Return (resultado)
    End Function
    Public Sub EditaAgrega(item As Libros, nuevo As Boolean)
        If nuevo Then
            libro.Add(item)
        Else
            libro(item.id) = item
        End If
    End Sub
    Public Sub EditLibro(libro As Libros, valores() As String)
        'Reemplaza todos los valores de un libro; actualiza la fecha y lo marca como editado
        Dim mes As String = Month(Now).ToString
        Dim ano As String = (Year(Now) - 2000).ToString
        valores(5) = mes
        valores(6) = ano
        libro.updateFromArray(valores, True)
    End Sub
    Public Sub BulkEdit(listaId As List(Of Integer), nuevoValor As String, categoria As Integer)
        For Each x In listaId
            Dim aux() As String
            aux = libro(x).array
            aux(categoria) = nuevoValor
            EditLibro(libro(x), aux)
        Next
    End Sub
    Public Sub BulkDelete(itemsSeleccionados As List(Of Integer))
        For Each x As Integer In itemsSeleccionados
            libro.RemoveAt(x)
        Next
        Dim i As Integer = 0
        For Each x As Libros In libro
            x.id = i
            i += 1
        Next
    End Sub
    Public Sub EliminaLibro(id As Integer)
        libro.RemoveAt(id)
        Dim i As Integer = 0
        For Each x In libro
            x.id = i
            i += 1
        Next
    End Sub
    Public Sub GuardaCSV()
        Dim rutaRaiz As String = System.AppDomain.CurrentDomain.BaseDirectory()
        Dim archivoPrecios As String = My.Computer.FileSystem.CombinePath(rutaRaiz, "Precios.csv")
        Dim textoCompleto As New List(Of String)
        For Each x In libro
            textoCompleto.Add(x.linea)
        Next
        System.IO.File.WriteAllLines(archivoPrecios, textoCompleto, System.Text.Encoding.GetEncoding(1252))
        textoCompleto = Nothing
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
        Dim bookList As New List(Of Libros)
        bookList = libro.Distinct.GroupBy(Function(x) x.editorial).Select(Function(d) d.First()).ToList()
        For Each item In bookList
            publisherList.Add(item.editorial)
        Next
        Return publisherList
    End Function
    Public Function GetLabels(publisher As String) As List(Of String)
        Dim labelList As New List(Of String)
        Dim bookList As New List(Of Libros)
        bookList = libro.Distinct.GroupBy(Function(x) x.sello).Select(Function(d) d.First()).Where(Function(y) y.editorial = publisher).ToList
        For Each item In bookList
            labelList.Add(item.editorial)
        Next
        Return labelList
    End Function
    Public Function GetAuthors() As List(Of String)
        Dim authorList As New List(Of String)
        Dim listLibros As New List(Of Libros)
        listLibros = libro.Distinct.GroupBy(Function(x) x.autor).Select(Function(d) d.First()).ToList()
        For Each item In listLibros
            authorList.Add(item.autor)
        Next
        Return authorList
    End Function
    Public Function Redondea(valor As Decimal, minimo As Integer) As Integer
        Return ((minimo * Math.Ceiling(valor / minimo)).ToString)
    End Function
    Public Sub MuestraHistorial()
        Dim fHistorial As New formHistorial
        fHistorial.Text = "Historial"
        fHistorial.Show()
    End Sub
    ''' <summary>
    ''' Actualiza los precios de una editorial dada. El archivo CSV debe estar preformateado
    ''' a 9 columnas título-autor-isbn-editorial-pvp-mes-año-sello-tema
    ''' </summary>
    ''' <param name="filePath">La ruta al archivo CSV conteniendo los precios nuevos</param>
    ''' <remarks></remarks>
    Public Sub ActualizaPrecios(filePath As String)
        Dim librosViejos As List(Of Libros)
        Dim librosNuevos As List(Of Libros)
        Dim librosActualizados As List(Of Libros)
        Dim editorial As String
        Dim respuesta As DialogResult
        Dim textoMsgbox As String

        librosNuevos = LoadBooks(filePath)
        editorial = librosNuevos(0).editorial
        textoMsgbox = String.Format("Actualizar {0}?", editorial)
        respuesta = MessageBox.Show(textoMsgbox, "Confirmar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If respuesta <> DialogResult.OK Then Return
        librosViejos = LibrosPorEditorial(editorial)
        librosActualizados = ListaActualizada(librosViejos, librosNuevos)
        EliminaLibroPorEditorial(editorial)
        libro.AddRange(librosActualizados)
        GuardaCSV()
    End Sub
    ''' <summary>
    ''' Devuelve una lista combinando libros viejos y nuevos.
    ''' Compara el ISBN de cada libro viejo con toda la lista nueva.
    ''' Si encuentra coincidencia, agrega a la lista final el libro de mayor PVP, y elimina
    ''' el libro nuevo de la lista de nuevos.
    ''' Si no encuentra coincidencia, agrega el libro viejo.
    ''' Luego de iterar toda la lista de viejos, agrega los nuevos sin procesar.
    ''' </summary>
    ''' <param name="viejos"></param>
    ''' <param name="nuevos"></param>
    ''' <returns></returns>
    Public Function ListaActualizada(viejos As List(Of Libros), nuevos As List(Of Libros)) As List(Of Libros)
        Dim listTemp As New List(Of Libros)
        Dim frm As Form = fMain
        Dim pnl As Panel = frm.Controls("pnlBotones")
        Dim bar As ProgressBar = frm.Controls("pBar1")
        Dim progreso As Integer
        Dim temp() As String

        bar.Maximum = viejos.Count
        bar.Visible = True

        For i As Integer = viejos.Count - 1 To 0 Step -1
            temp = viejos(i).array  'copia los datos del libro viejo
            bar.PerformStep()
            progreso = CInt(100 - (100 * i / viejos.Count))

            For j As Integer = nuevos.Count - 1 To 0 Step -1
                Dim x As Libros = nuevos(j)
                If viejos(i).isbn = x.isbn Then     'Encuentra coincidencia de ISBN
                    If viejos(i).pvp <= x.pvp Then  'Si el nuevo es mas caro
                        temp(3) = x.editorial       'Actualiza la editorial por si tenía un asterisco,
                        temp(4) = x.pvp.ToString    'actualiza el pvp,
                        temp(5) = x.mes             'el mes,
                        temp(6) = x.año             'y el año.
                    End If
                    If x.sello <> "-" Then temp(7) = x.sello 'Actualiza sello y tema
                    If x.tema <> "-" Then temp(8) = x.tema 'siempre que no estén vacíos
                    nuevos.RemoveAt(j)          'finalmente elimina el libro nuevo ya usado
                    Exit For
                End If
                'Si no hubo coincidencia, el libro TEMP es igual al viejo
            Next
            'En cualquier caso, se agrega el libro viejo original o modificado
            'a la lista temporal, con su indice sin modificar
            listTemp.Add(New Libros(temp, i))
        Next

        bar.Visible = False
        'finalmente se agregan todos los libros nuevos restantes
        'con índices consecutivos
        Dim num As Integer = libro.Count
        For i As Integer = 0 To nuevos.Count - 1
            temp = nuevos(i).array
            listTemp.Add(New Libros(temp, i + num))
        Next
        Return listTemp
    End Function
    ''' <summary>
    ''' Devuelve una sublista de la lista principal de precios
    ''' conteniendo solo la editorial especificada
    ''' </summary>
    ''' <param name="editorial"></param>
    Private Function LibrosPorEditorial(editorial As String) As List(Of Libros)
        Return libro.Where(Function(x) x.editorial.IndexOf(editorial) >= 0).ToList
    End Function
    Public Function CsvToList(filePath As String) As List(Of String())
        Dim listString As New List(Of String())
        Using parser As New FileIO.TextFieldParser(filePath, System.Text.Encoding.GetEncoding(1252))
            parser.TextFieldType = FileIO.FieldType.Delimited
            parser.SetDelimiters(";")
            'Dim linea As String()
            While Not parser.EndOfData
                'linea = parser.ReadFields
                listString.Add(parser.ReadFields)
            End While
        End Using
        Return listString
    End Function
    Private Sub EliminaLibroPorEditorial(editorial As String)
        For i As Integer = libro.Count - 1 To 0 Step -1
            If libro(i).editorial.IndexOf(editorial) >= 0 Then libro.RemoveAt(i)
        Next
    End Sub
    Public Function toRGB(h As Single, s As Single, v As Single) As Color
        Dim r, g, b As Integer
        Dim rh, gh, bh As Single
        Dim C As Single
        Dim X As Single
        Dim m As Single

        C = s * (1 - Math.Abs(2 * v - 1))
        X = C * (1 - Math.Abs((h / 60) Mod 2 - 1))
        m = v - (C / 2)

        Select Case h
            Case 0 To 59
                rh = C
                gh = X
                bh = 0
            Case 60 To 119
                rh = X
                gh = C
                bh = 0
            Case 120 To 179
                rh = 0
                gh = C
                bh = X
            Case 180 To 239
                rh = 0
                gh = X
                bh = C
            Case 240 To 299
                rh = X
                gh = 0
                bh = C
            Case 300 To 360
                rh = C
                gh = 0
                bh = X
        End Select
        r = CInt(255 * (rh + m))
        g = CInt(255 * (gh + m))
        b = CInt(255 * (bh + m))
        Return Color.FromArgb(r, g, b)
    End Function
    Public Function HSBtoRGB(h As Single, s As Single, v As Single) As Color
        Dim r, g, b As Single
        Dim hf, f, pv, qv, tv As Single
        Dim i As Integer
        If v <= 0 Then Return Color.FromArgb(0, 0, 0)
        If s <= 0 Then Return Color.FromArgb(v, v, v)
        hf = h / 60.0
        i = Math.Floor(hf)
        f = hf - i
        PV = v * (1 - s)
        qv = v * (1 - s * f)
        tv = v * (1 - s * (1 - f))
        Select Case i
            Case 0
                r = v
                g = tv
                b = pv

            Case 1
                r = qv
                g = v
                b = pv

            Case 2
                r = pv
                g = v
                b = tv

            Case 3
                r = pv
                g = qv
                b = v

            Case 4
                r = tv
                g = pv
                b = v

            Case 5
                r = v
                g = pv
                b = qv

            Case 6
                r = v
                g = tv
                b = pv

            Case -1
                r = v
                g = pv
                b = qv

            Case Else
                Return Color.Black
        End Select
        Return Color.FromArgb(Clamp(r * 255), Clamp(g * 255), Clamp(b * 255))
    End Function

    Private Function Clamp(n As Integer) As Integer
        If n < 0 Then Return 0
        If n > 255 Then Return 255
        Return n
    End Function

    Public Function GetTextBoxes(TControl As Control) As List(Of TextBox)
        Dim textBoxes = New List(Of TextBox)
        For Each c As Control In TControl.Controls
            If TypeOf c Is TextBox Then
                textBoxes.Add(c)
            End If
        Next
        Return textBoxes
    End Function

    'Public Function GetControls(TControl As Control, ) As List(Of TextBox)
    '    Dim textBoxes = New List(Of TextBox)
    '    For Each c As Control In TControl.Controls
    '        If TypeOf c Is TextBox Then
    '            textBoxes.Add(c)
    '        End If
    '    Next
    '    Return textBoxes
    'End Function

End Module
