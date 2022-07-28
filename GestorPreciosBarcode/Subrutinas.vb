'Imports System.Text
Imports Buscador.Globales
Public Class Subrutinas

    Public Class Condicion
        Public input As String
        Public espacio As String
        Public estricto As Boolean
        Sub New(ByVal _espacio As String, ByVal _input As String)
            espacio = _espacio
            input = QuitaAcentos(_input).ToUpper
            estricto = False
            If input.Substring(input.Length - 1) = "$" Then
                estricto = True
                input = input.Replace("$", "")
            End If
        End Sub
    End Class

    Public Shared Sub CargaInicial()
        Dim rutaRaiz As String = System.AppDomain.CurrentDomain.BaseDirectory()
        Dim nombreArchivo As String = "Precios.csv"
        Dim nombreBackup As String = "Backup\" & FechaHora() & nombreArchivo
        Dim archivoPrecios As String = My.Computer.FileSystem.CombinePath(rutaRaiz, nombreArchivo)
        Dim archivoBackup As String = My.Computer.FileSystem.CombinePath(rutaRaiz, nombreBackup)
        Dim archivoTasas As String = My.Computer.FileSystem.CombinePath(rutaRaiz, "Tasas.txt")

        libro.Clear()

        Using tPrecios As New FileIO.TextFieldParser(archivoPrecios, System.Text.Encoding.GetEncoding(1252))
            tPrecios.TextFieldType = FileIO.FieldType.Delimited
            tPrecios.SetDelimiters(";")

            Dim id As Integer = 0

            While Not tPrecios.EndOfData
                Dim linea As String()
                linea = tPrecios.ReadFields()
                linea(2) = ExtraeNumeros(linea(2))
                linea(4) = Redondea(CInt(linea(4)), 50)
                linea(9) = id.ToString
                id += 1
                libro.Add(New Libros(linea))
            End While
        End Using

        Using sr As New System.IO.StreamReader(archivoTasas)
            Do While sr.Peek() <> -1
                Dim lineaTasa As Single = CSng(sr.ReadLine())
                tasa.Add(lineaTasa / 100)
            Loop
        End Using

        System.IO.File.Copy(archivoPrecios, archivoBackup)
    End Sub

    Public Shared Function Buscar(_input As String) As List(Of Integer)
        If _input = "" Then Return Nothing
        Dim input As String = _input
        Dim datosbusqueda As New List(Of Integer)

        If IsNumeric(input) And input.Length > 9 Then
            'probable isbn, recorta las puntas para armar un ISBN-9
            input = Mid(input, input.Length - 9, 9)
        End If

        input = QuitaAcentos(input).ToUpper

        'Rutina de búsqueda
        For i As Single = 0 To libro.Count - 1
            Dim titulo As String = QuitaAcentos(libro(i).titulo).ToUpper
            Dim autor As String = QuitaAcentos(libro(i).autor).ToUpper
            Dim isbn As String = libro(i).isbn

            Dim isbnInput As String = ExtraeNumeros(input)

            If isbnInput <> "" And isbnInput.Length > 4 And isbn.IndexOf(isbnInput) >= 0 Then
                datosbusqueda.Add(i)
            End If
            If titulo.IndexOf(input) >= 0 Then datosbusqueda.Add(i)
            If autor.IndexOf(input) >= 0 Then datosbusqueda.Add(i)

            If datosbusqueda.Count > 100 Then
                MsgBox("Demasiados resultados, mostrando los primeros 100")
                Return datosbusqueda
            End If
        Next i

        Return datosbusqueda

    End Function

    Public Shared Function BusquedaEspacios(inputEspacios As String) As List(Of Integer)

        Dim subInput() As String = inputEspacios.Split(";")
        Dim condiciones As New List(Of Condicion)
        For Each x As String In subInput
            If x = "" Then Exit For
            Dim key() As String = x.Split(":")
            If key.Length <> 2 Then
                MsgBox("Busqueda avanzada mal formada, intente nuevamente")
                Return Nothing
            End If
            condiciones.Add(New Condicion(key(0), key(1)))
        Next

        Dim datosBusqueda As New List(Of Integer)
        For i As Single = 0 To libro.Count - 1
            Dim matches As Integer = 0

            For Each x As Condicion In condiciones
                Dim texto As String
                Select Case x.espacio
                    Case "id"
                        texto = libro(i).id
                    Case "titulo", "t"
                        texto = QuitaAcentos(libro(i).titulo).ToUpper
                    Case "autor", "a"
                        texto = QuitaAcentos(libro(i).autor).ToUpper
                    Case "editorial", "e"
                        texto = QuitaAcentos(libro(i).editorial).ToUpper
                    Case "sello", "s"
                        texto = QuitaAcentos(libro(i).sello).ToUpper
                    Case "tema"
                        texto = QuitaAcentos(libro(i).tema).ToUpper
                    Case Else
                        MsgBox("espacio no reconocido: " & x.espacio, vbOKOnly)
                        Return Nothing
                End Select
                If texto.IndexOf(x.input) >= 0 Then
                    If x.estricto Then
                        Dim palabras() As String = texto.Split(" ")
                        Dim match As Boolean = False
                        For Each palabra As String In palabras
                            If palabra = x.input Then
                                match = True
                                Console.WriteLine(palabra)
                            End If
                        Next
                        If match Then matches += 1
                    Else
                        matches += 1
                    End If
                End If

            Next
            If matches = condiciones.Count Then datosBusqueda.Add(i)
            If datosBusqueda.Count > 100 Then
                MsgBox("Demasiados resultados, mostrando los primeros 100")
                Return datosBusqueda
            End If
        Next i

        Return datosBusqueda

        Return Nothing
    End Function

    Public Shared Function PreparaListviewItem(item As Libros) As ListViewItem
        Dim aux(0 To 8) As String
        aux(0) = item.titulo
        aux(1) = item.autor
        aux(2) = item.isbn
        aux(3) = item.editorial
        aux(4) = item.pvp.ToString
        aux(5) = item.fecha
        aux(6) = Proyectar(item.mes, item.ano - 10, item.pvp).ToString
        aux(7) = item.sello
        aux(8) = item.tema

        PortaPapeles(item.titulo, item.isbn, item.editorial, item.sello, item.pvp.ToString)
        Dim renglon As New ListViewItem(aux)
        renglon.Name = item.id.ToString
        Return renglon

    End Function

    Public Shared Sub AgregaItemAListview(renglon As ListViewItem, lview As ListView)
        Dim colorback As Color = Color.FromArgb(192, 192, 192)
        If lview.Items.Count Mod 2 = 0 Then
            renglon.BackColor = colorback
            renglon.UseItemStyleForSubItems = True
        End If
        lview.Items.Add(renglon)
    End Sub

    Public Shared Function Proyectar(mesDato As Integer, anoDato As Integer, valor As Single) As Single

        Dim a_index As Integer
        Dim mesActual As Integer = Month(Now)
        Dim anoActual As Integer = Year(Now) - 2010
        Dim mes As New List(Of Integer)
        Dim ano As New List(Of Integer)

        If tasa.Count < anoActual Then
            MsgBox("Actualice el archivo de tasas de interés")
            Proyectar = 0
            fMain.Close()
            Exit Function
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

        For i = 0 To anoActual
            ano(i) = Math.Floor(mes(i) / 12)
            mes(i) = mes(i) Mod 12
            valor = valor * ((1 + tasa(i)) ^ ano(i)) * (1 + tasa(i) * mes(i) / 12)
        Next i

        Return (Math.Ceiling(valor / 10) * 10)

    End Function

    Public Shared Sub EditaAgrega(item As Libros, nuevo As Boolean)
        If nuevo Then
            libro.Add(item)
            Exit Sub
        Else
            libro(item.id) = item
        End If
    End Sub

    Public Shared Sub EditLibro(_libro As Libros, valores() As String)
        'Reemplaza todos los valores de un libro; actualiza la fecha y lo marca como editado
        Dim mes As String = Month(Now).ToString
        Dim ano As String = (Year(Now) - 2000).ToString
        If Not valores(3).StartsWith("*") Then valores(3) = "*" & valores(3)
        valores(5) = mes
        valores(6) = ano

        _libro.updateFromArray(valores)
    End Sub

    Public Shared Sub BulkEdit(listaId As List(Of Integer), nuevoValor As String, tipo As Integer)
        
        For Each x In listaId
            Dim aux() As String
            aux = libro(x).array

            'Actualiza valor solicitado
            aux(tipo) = nuevoValor

            'Actualiza datos del libro
            EditLibro(libro(x), aux)
        Next
    End Sub

    Public Shared Sub EliminaLibro(id As Integer)
        Dim i As Integer = 0
        libro.RemoveAt(id)
        i = 0
        For Each x In libro
            x.id = i
            i += 1
        Next

    End Sub

    Public Shared Sub GuardarCambiosADisco()
        Dim rutaRaiz As String = System.AppDomain.CurrentDomain.BaseDirectory()
        Dim archivoPrecios As String = My.Computer.FileSystem.CombinePath(rutaRaiz, "Precios.csv")
        Dim textoCompleto As New List(Of String)

        For Each x In libro
            textoCompleto.Add(x.linea)
        Next

        System.IO.File.WriteAllLines(archivoPrecios, textoCompleto, System.Text.Encoding.GetEncoding(1252))
    End Sub

    Public Shared Function ExtraeEditoriales() As List(Of String)
        Dim editoriales As New List(Of String)
        For Each item In libro.Distinct.GroupBy(Function(x) x.editorial).Select(Function(d) d.First()).ToList()
            editoriales.Add(item.editorial)
        Next
        Return editoriales
    End Function

    Public Shared Function ExtraeAutores() As List(Of String)
        Dim autores As New List(Of String)
        For Each item In libro.Distinct.GroupBy(Function(x) x.autor).Select(Function(d) d.First()).ToList()
            autores.Add(item.autor)
        Next
        Return autores
    End Function

    Public Shared Function Redondea(valor As Decimal, minimo As Integer)
        Return ((minimo * Math.Ceiling(valor / minimo)).ToString)
    End Function

    Public Shared Sub MuestraHistorial()
        Dim fHistorial As New formHistorial
        fHistorial.Text = "Historial"

        fHistorial.Show()
        'Dim texto As String
        'texto = String.Join(vbCrLf, historial)
        'MsgBox(texto, MsgBoxStyle.Information, "Historial")
    End Sub
End Class
