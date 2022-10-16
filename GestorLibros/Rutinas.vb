Imports System.IO
Imports GestorLibros.Libros
Imports GestorLibros.datosCSV
Imports GestorLibros.EntradaHistorial
Imports GestorLibros.Condicion
Imports System.Text
Imports System.Globalization

Public Class Rutinas
    Public Shared listaLibros As List(Of Libros)
    Public Shared tasas As List(Of Single)
    Public Shared historial As List(Of EntradaHistorial)
    Private hora As String

    ''' <summary>
    ''' Hace un backup del archivo de precios, y mantiene
    ''' los últimos 9 backups.
    ''' </summary>
    Public Shared Function ActualizaBackup() As Boolean

        Try
            If Not FileIO.FileSystem.DirectoryExists("Backup") Then
                FileSystem.MkDir("Backup")
            End If
            For i As Integer = 8 To 0 Step -1
                Dim nombre1 As String = "Backup\Precios" + i.ToString + ".csv"
                Dim nombre2 As String = "Backup\Precios" + (i + 1).ToString + ".csv"

                If File.Exists(nombre1) Then
                    File.Copy(nombre1, nombre2, True)
                End If
            Next
            File.Copy("Precios.csv", "Backup\Precios0.csv", True)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    ''' <summary>
    ''' Guarda los datos del archivo de precios en una lista.
    ''' Produce un archivo backup y mantiene una lista de los
    ''' últimos 9 backups
    ''' </summary>
    Public Shared Function CargaInicial() As Boolean
        Try
            listaLibros = New List(Of Libros)
            historial = New List(Of EntradaHistorial)
            tasas = New List(Of Single)

            Try
                listaLibros = LeeCSV("Precios.csv")
            Catch ex As Exception
                MsgBox("Error al leer CSV")
            End Try

            Try
                tasas = LeeTXT("tasas.txt")
            Catch ex As Exception
                MsgBox("Error al leer tasas")
            End Try

            ActualizaBackup()
            Return True
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try
    End Function
    ''' <summary>
    ''' Lee las tasas de interés del archivo
    ''' y las almacena en una lista
    ''' </summary>
    ''' <param name="archivo">
    ''' Nombre de archivo, incluyendo su ruta
    ''' </param>
    Public Shared Function LeeTXT(archivo As String) As List(Of Single)
        Dim listaTasa As List(Of Single)
        Dim linea As String
        Dim sr As StreamReader

        sr = New StreamReader(archivo)
        listaTasa = New List(Of Single)
        While Not sr.EndOfStream
            linea = sr.ReadLine
            listaTasa.Add(CSng(linea) / 100)
        End While
        sr = Nothing

        Return listaTasa

    End Function
    ''' <summary>
    ''' Lee los libros del archivo de Precios
    ''' y los almacena en una lista
    ''' </summary>
    Public Shared Function LeeCSV(archivo As String) As List(Of Libros)
        Dim id As Integer
        Dim listaCsv As List(Of Libros)
        Dim linea() As String
        Dim libro As Libros
        id = 0
        listaCsv = New List(Of Libros)

        Try
            Dim sr As StreamReader
            sr = New StreamReader(archivo, Encoding.GetEncoding(1252))
            While Not sr.EndOfStream
                linea = sr.ReadLine.Split(CChar(";"))
                libro = New Libros(linea, id)
                listaCsv.Add(libro)
                id += 1
            End While
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return listaCsv

    End Function
    ''' <summary>
    ''' Toma una cadena de caracteres "texto" y devuelve 
    ''' una subcadena contentiendo sus caracteres puramente numéricos.
    ''' Por ejemplo, "A12 sarasa45" devuelve "1245"
    ''' </summary>
    Public Shared Function ExtraeNumeros(texto As String) As String
        Try
            Dim sbTexto As New StringBuilder(texto.Length)
            Dim ch As Char

            For Each ch In texto
                If Char.IsDigit(ch) Then sbTexto.Append(ch)
            Next

            Return sbTexto.ToString
        Catch ex As Exception
            Return ("")
        End Try

    End Function
    ''' <summary>
    ''' Devuelve un valor redondeado hacia arriba, múltiplo de "mínimo"
    ''' Por ejemplo, (123, 10) devuelve 130; mientras que
    ''' (123,50) devuelve 150
    ''' </summary>
    ''' <param name="valor">
    ''' El valor a redondear
    ''' </param>
    ''' <param name="minimo">
    ''' El múltiplo deseado
    ''' </param>
    ''' <returns></returns>
    Public Shared Function Redondea(valor As Single, minimo As Integer) As Integer
        Dim valorRedondeado As Integer
        valorRedondeado = minimo * CInt(Math.Ceiling(CDec(valor / minimo)))
        Return (valorRedondeado)
    End Function
    ''' <summary>
    '''Toma una cadena de caracteres cualquiera y devuelve la subcadena
    '''de caracteres ASCII en mayúsculas. 
    '''Por ejemplo, "áéíóú sarasa" --> "AEIOU SARASA"
    ''' </summary>
    Public Shared Function QuitaAcentos(texto As String) As String

        Dim textoFormD As String
        Dim sb As StringBuilder

        textoFormD = texto.Normalize(NormalizationForm.FormD)
        sb = New StringBuilder

        For i As Integer = 0 To textoFormD.Length - 1
            Dim uc As UnicodeCategory
            uc = CharUnicodeInfo.GetUnicodeCategory(textoFormD(i))
            If uc <> UnicodeCategory.NonSpacingMark Then sb.Append(textoFormD(i))
        Next i

        Return (sb.ToString().Normalize(NormalizationForm.FormC).ToUpper)
    End Function
    ''' <summary>
    ''' Devuelve una lista de índices donde se encontró el input
    ''' </summary>
    Public Shared Function EjecutaBusqueda(input As String) As List(Of Integer)
        Dim busqueda As New List(Of Integer)

        If input.IndexOf(":") >= 0 Then
            busqueda = BuscarCampos(input)
        Else
            busqueda = Buscar(input)
        End If

        If busqueda.Count > 0 Then
            'historial.Add(New EntradaHistorial(input))

            Dim hora As String
            hora = Now().ToString("HH:mm:ss")

        End If

        Return busqueda
    End Function
    ''' <summary>
    ''' Proyecta un precio según su antigüedad
    ''' y las tasas de interés
    ''' </summary>
    Public Shared Function Proyectar(mesDato As Integer, añoDato As Integer, valor As Integer) As Integer

        Dim a_index As Integer
        Dim mesActual As Integer = Month(Now)
        Dim añoActual As Integer = Year(Now) - 2010
        Dim mes As New List(Of Integer)
        Dim año As New List(Of Integer)

        If tasas.Count < añoActual Then
            MsgBox("Actualice el archivo de tasas de interés")
            Return (-1)
            Exit Function
        End If

        'Crea una variable por cada periodo (de un año excepto los años
        'anteriores al 2010, cuyo período es múltiple)
        'y almacena los meses y o años transcurridos en dicho periodo
        For i As Integer = 0 To añoActual   'Inicializa las variables
            mes.Add(0)
            año.Add(0)
        Next i

        If añoDato = añoActual Then
            'Solo se calculan los meses transcurridos
            mes(añoActual) += mesActual - mesDato
            año(añoActual) = 0
        Else
            'Cantidad de meses transcurridos en este año
            mes(añoActual) = mesActual - 1
            a_index = añoDato
            'Años anteriores al 2010 se establecen como 2010
            If a_index < 0 Then a_index = 0
            'Cantidad de meses entre fecha dato y fin de ese año
            mes(a_index) = 13 - mesDato
            'Para todos los años intermedios, doce meses cada uno.
            For i As Integer = a_index + 1 To añoActual - 1
                mes(i) = 12
            Next i
        End If

        'Para años anteriores al 2010, la variable mes(0) contiene la
        'cantidad total de meses entre la fecha original y finales de 2010
        If añoDato < 1 Then mes(0) = 12 * (1 - añoDato) - mesDato + 1

        For i As Integer = 0 To añoActual
            'La siguiente rutina establece año(i)=1; mes(i)=0 para
            'años completos; año(i)=0, mes(i) = n para años incompletos;
            'y año(0)=m, mes(0)=n para años<2010
            año(i) = CInt(Math.Floor(mes(i) / 12))
            mes(i) = mes(i) Mod 12
            valor = CInt(valor * ((1 + tasas(i)) ^ año(i)) * (1 + tasas(i) * mes(i) / 12))
        Next i

        Return Redondea(valor, 50)

    End Function
    ''' <summary>
    ''' Función de búsqueda básica. Devuelve una lista
    ''' con los índices donde de encontró el texto "input"
    ''' </summary>
    ''' <param name="input">
    ''' Texto a buscar
    ''' </param>
    Public Shared Function Buscar(input As String) As List(Of Integer)
        If input = "" Then Return Nothing

        Dim datosbusqueda As List(Of Integer)
        Dim libro As Libros
        Dim titulo, autor, isbn, inputNumerico As String

        If IsNumeric(input) And input.Length > 9 Then
            'probable isbn, recorta las puntas para armar un ISBN-9
            input = Mid(input, input.Length - 9, 9)
        End If

        input = QuitaAcentos(input)
        inputNumerico = ExtraeNumeros(input)
        datosbusqueda = New List(Of Integer)
        For i As Integer = 0 To listaLibros.Count - 1
            libro = listaLibros(i)
            titulo = QuitaAcentos(libro.titulo)
            autor = QuitaAcentos(libro.autor)
            isbn = libro.isbn

            'Agrega resultados donde hay al menos 5 dígitos de ISBN
            If inputNumerico <> "" And inputNumerico.Length > 4 And
                isbn.IndexOf(inputNumerico) >= 0 Then datosbusqueda.Add(i)
            'Agrega resultados donde hay parte de título o autor
            If titulo.IndexOf(input) >= 0 Then datosbusqueda.Add(i)
            If autor.IndexOf(input) >= 0 Then datosbusqueda.Add(i)

            If datosbusqueda.Count > 50 Then
                MsgBox("Demasiados resultados, mostrando los primeros 50")
                Return datosbusqueda
            End If
        Next i

        Return datosbusqueda

    End Function
    ''' <summary>
    ''' Función de búsqueda avanzada.
    ''' Permite buscar libros que cumplan una o más condiciones
    ''' según los campos autor, título, editorial, sello o tema
    ''' </summary>
    Public Shared Function BuscarCampos(input As String) As List(Of Integer)
        Dim subInput() As String
        Dim condiciones As List(Of Condicion)
        Dim libro As Libros
        Dim datosBusqueda As List(Of Integer)
        Dim matches As Integer

        'separa el input en sus componentes individuales
        subInput = input.Split(CChar(";"))
        condiciones = New List(Of Condicion)

        For Each x As String In subInput
            If x = "" Then Exit For
            'separa el campo key(0) del texto a buscar key(1)
            Dim key() As String = x.Split(CChar(":"))
            If key.Length <> 2 Then
                MsgBox("Busqueda avanzada mal formada, intente nuevamente")
                Return Nothing
            End If
            condiciones.Add(New Condicion(key(0), key(1)))
        Next

        datosBusqueda = New List(Of Integer)
        For i As Integer = 0 To listaLibros.Count - 1
            libro = listaLibros(i)
            matches = 0

            For Each x As Condicion In condiciones
                'prepara el texto sobre el que se realiza la
                'búsqueda, según el campo asignado a cada condición
                Dim texto As String
                Select Case x.campo
                    Case "id"
                        texto = libro.id.ToString
                    Case "titulo", "t"
                        texto = QuitaAcentos(libro.titulo)
                    Case "autor", "a"
                        texto = QuitaAcentos(libro.autor)
                    Case "editorial", "e"
                        texto = QuitaAcentos(libro.editorial)
                    Case "sello", "s"
                        texto = QuitaAcentos(libro.sello)
                    Case "tema"
                        texto = QuitaAcentos(libro.tema)
                    Case Else
                        MsgBox("espacio no reconocido: " & x.campo, vbOKOnly)
                        Return Nothing
                End Select

                If texto.IndexOf(x.input) >= 0 Then
                    If x.estricto Then
                        Dim palabras() As String = texto.Split(CChar(" "))
                        Dim match As Boolean = False
                        'Busca si la palabra está entera
                        For Each palabra As String In palabras
                            If palabra = x.input Then match = True
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
    Public Shared Function PreparaFilaListView(libro As Libros) As ListViewItem
        Dim aux(0 To 8) As String
        aux(0) = libro.titulo
        aux(1) = libro.autor
        aux(2) = libro.isbn
        aux(3) = libro.editorial
        aux(4) = libro.pvp.ToString
        aux(5) = libro.fecha
        aux(6) = Proyectar(libro.mes, libro.año - 10, libro.pvp).ToString
        aux(7) = libro.sello
        aux(8) = libro.tema

        If Not PortaPapeles(libro) Then MsgBox("error")
        Dim renglon As New ListViewItem(aux)
        renglon.Name = libro.id.ToString
        Return renglon
    End Function
    ''' <summary>
    ''' Copia los datos al portapapeles para pegar 
    ''' en la planilla de ventas.
    ''' Agrega el caracter "´" al ISBN
    ''' </summary>
    Public Shared Function PortaPapeles(libro As Libros) As Boolean
        Dim titulo, sello, editorial, isbn, pvp As String

        Try
            With libro
                titulo = .titulo
                sello = .sello
                editorial = .editorial
                isbn = .isbn
                pvp = .pvp.ToString
            End With

            If sello <> "-" And sello <> "" Then
                editorial = editorial & " - " & sello
            End If
            Clipboard.SetText("1" & Chr(9) & titulo & Chr(9) & "`" & isbn &
                              Chr(9) & editorial & Chr(9) & pvp)
            Return True
        Catch ex As Exception
            MsgBox("Error al copiar al portapapeles. Error: " & ex.ToString)
            Return False
        End Try

    End Function
    ''' <summary>
    ''' Agrega el ListViewItem renglon al ListView lView,
    ''' alternando los colores de las filas
    ''' </summary>
    Public Shared Function AgregaItemAListview(renglon As ListViewItem, lView As ListView) As Boolean
        Try
            Dim backColor As Color = Color.FromArgb(255, 224, 192)
            If lView.Items.Count Mod 2 = 0 Then
                renglon.BackColor = backColor
                renglon.UseItemStyleForSubItems = True
            End If
            lView.Items.Add(renglon)
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function
End Class

