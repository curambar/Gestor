Imports Buscador.Globales
Imports Microsoft.Office.Interop
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
        aux(0) = item.titulo
        aux(1) = item.autor
        aux(2) = item.isbn
        aux(3) = item.editorial
        'aux(4) = item.pvp.ToString
        aux(4) = pvpRecargado.ToString
        aux(5) = item.fecha
        'aux(6) = Proyectar(item.mes, item.año - 10, item.pvp).ToString
        aux(6) = Proyectar(item.mes, item.año - 10, pvpRecargado).ToString
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
        Dim backColor As Color = Color.FromArgb(192, 192, 192)
        If lview.Items.Count Mod 2 = 0 Then
            renglon.BackColor = backColor
            renglon.UseItemStyleForSubItems = True
        End If
        lview.Items.Add(renglon)
    End Sub
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
        If Not valores(3).StartsWith("*") Then valores(3) = "*" & valores(3)
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
    Public Function ExtraeEditoriales() As List(Of String)
        Dim editoriales As New List(Of String)
        Dim listLibros As New List(Of Libros)
        listLibros = libro.Distinct.GroupBy(Function(x) x.editorial).Select(Function(d) d.First()).ToList()
        For Each item In listLibros
            editoriales.Add(item.editorial)
        Next
        Return editoriales
    End Function
    Public Function ExtraeAutores() As List(Of String)
        Dim autores As New List(Of String)
        Dim listLibros As New List(Of Libros)
        listLibros = libro.Distinct.GroupBy(Function(x) x.autor).Select(Function(d) d.First()).ToList()
        For Each item In listLibros
            autores.Add(item.autor)
        Next
        Return autores
    End Function
    Public Function Redondea(valor As Decimal, minimo As Integer)
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
End Module