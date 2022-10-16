Imports GestorLibros.Rutinas

''' <summary>
''' Provee plantilla de Libros
''' </summary>
Public Class Libros
    Dim inId As Integer
    Dim inPvp As Integer
    Dim inMes As Integer
    Dim inAno As Integer
    Dim stTitulo As String
    Dim stAutor As String
    Dim stIsbn As String
    Dim stEditorial As String
    Dim stSello As String
    Dim stTema As String
    Dim arDatos() As String

    ''' <summary>
    ''' Índice interno del libro
    ''' </summary>
    Public Property id As Integer
        Set(value As Integer)
            inId = value
        End Set
        Get
            Return inId
        End Get
    End Property
    ''' <summary>
    ''' Título del libro
    ''' </summary>
    Public Property titulo As String
        Set(value As String)
            stTitulo = value
        End Set
        Get
            Return stTitulo
        End Get
    End Property
    ''' <summary>
    ''' Autor del libro
    ''' </summary>
    Public Property autor As String
        Set(value As String)
            stAutor = value
        End Set
        Get
            Return stAutor
        End Get
    End Property
    ''' <summary>
    ''' ISBN o código de barras
    ''' </summary>
    Public Property isbn As String
        Set(value As String)
            stIsbn = ExtraeNumeros(value)
        End Set
        Get
            Return stIsbn
        End Get
    End Property
    ''' <summary>
    ''' Editorial que publica el libro
    ''' </summary>
    Public Property editorial As String
        Set(value As String)
            stEditorial = value
        End Set
        Get
            Return stEditorial
        End Get
    End Property
    ''' <summary>
    ''' Precio de venta al público
    ''' </summary>
    Public Property pvp As Integer
        Set(value As Integer)
            inPvp = Redondea(value, 50)
        End Set
        Get
            Return inPvp
        End Get
    End Property
    ''' <summary>
    ''' Mes donde el precio es vigente
    ''' </summary>
    Public Property mes As Integer
        Set(value As Integer)
            inMes = value
        End Set
        Get
            Return inMes
        End Get
    End Property
    ''' <summary>
    ''' Año donde el precio es vigente
    ''' </summary>
    Public Property año As Integer
        Set(value As Integer)
            inAno = value
        End Set
        Get
            Return inAno
        End Get
    End Property
    ''' <summary>
    ''' Sello de la editorial que publica el libro
    ''' </summary>
    Public Property sello As String
        Set(value As String)
            stSello = value
        End Set
        Get
            Return stSello
        End Get
    End Property
    ''' <summary>
    ''' Temática del libro
    ''' </summary>
    Public Property tema As String
        Set(value As String)
            stTema = value
        End Set
        Get
            Return stTema
        End Get
    End Property
    ''' <summary>
    ''' Array que contiene todos los datos del libro
    ''' </summary>
    Public Property array As String()
        Set(value As String())

            arDatos = value
        End Set
        Get
            Return arDatos
        End Get
    End Property

    Sub New(lineaLibro() As String, id As Integer)
        Me.id = id
        Me.titulo = lineaLibro(0)
        Me.autor = lineaLibro(1)
        Me.isbn = lineaLibro(2)
        Me.editorial = lineaLibro(3)
        Me.pvp = CInt(lineaLibro(4))
        Me.mes = CInt(lineaLibro(5))
        Me.año = CInt(lineaLibro(6))
        Me.sello = lineaLibro(7)
        Me.tema = lineaLibro(8)

        lineaLibro(2) = "`" & lineaLibro(2)
        Me.array = lineaLibro
    End Sub

    ''' <summary>
    ''' Devuelve la fecha con formato MM/AA
    ''' </summary>
    Function fecha() As String
        Return (mes.ToString.PadLeft(2, CChar("0")) & "/" & año.ToString.PadLeft(2, CChar("0")))
    End Function

    ''' <summary>
    ''' Devuelve una linea concatenando los datos con el caracter ";"
    ''' </summary>
    ''' <returns></returns>
    Function linea() As String
        Return String.Join(";", array)
    End Function

    ''' <summary>
    ''' Actualiza los datos del libro con el array provisto
    ''' </summary>
    ''' <param name="aux">
    ''' Array conteniendo los datos actualizados
    ''' </param>
    Sub updateFromArray(aux() As String)
        Me.array = aux
        Me.titulo = aux(0)
        Me.autor = aux(1)
        Me.isbn = aux(2)
        Me.editorial = aux(3)
        Me.pvp = CInt(aux(4))
        Me.mes = CInt(aux(5))
        Me.año = CInt(aux(6))
        Me.sello = aux(7)
        Me.tema = aux(8)
    End Sub

End Class
''' <summary>
''' Cada Entrada contiene el input original y la hora de la búsqueda
''' </summary>
Public Class EntradaHistorial
    Dim stInput As String
    Dim dtHora As Date

    ''' <summary>
    ''' Texto original de la búsqueda
    ''' </summary>
    Public Property input As String
        Set(value As String)
            stInput = value
        End Set
        Get
            Return stInput
        End Get
    End Property

    ''' <summary>
    ''' Hora original de la búsqueda
    ''' </summary>
    ''' <returns></returns>
    Public Property hora As Date
        Set(value As Date)
            dtHora = value
        End Set
        Get
            Return dtHora
        End Get
    End Property

    Sub New(input As String)
        Me.input = input
        Me.hora = Now()
    End Sub
End Class

''' <summary>
''' Contiene las filas de datos de un archivo CSV
''' como una lista de arrays de string.
''' También contiene el nombre del archivo original.
''' </summary>
Public Class datosCSV
    Public filas As List(Of String())
    Public nombre As String
End Class

''' <summary>
''' Contiene el texto de búsqueda, el campo a buscar,
''' y la opción de búsqueda por texto estricta.
''' </summary>
Public Class Condicion
    Dim stInput As String
    Dim stCampo As String
    Dim blEstricto As Boolean
    ''' <summary>
    ''' El texto a buscar
    ''' </summary>
    Public Property input As String
        Set(value As String)
            stInput = value
        End Set
        Get
            Return stInput
        End Get
    End Property
    ''' <summary>
    ''' El campo de busqueda (Titulo, autor, editorial, etc)
    ''' </summary>
    Public Property campo As String
        Set(value As String)
            stCampo = value
        End Set
        Get
            Return stCampo
        End Get
    End Property
    ''' <summary>
    ''' Un valor TRUE sólo encuentra el texto completo, por ejemplo
    ''' el input "hola" sólo devolverá "hola" pero no "holanda"
    ''' </summary>
    Public Property estricto As Boolean
        Set(value As Boolean)
            blEstricto = value
        End Set
        Get
            Return blEstricto
        End Get
    End Property

    Sub New(campo As String, input As String)
        Me.campo = campo
        Me.input = input.ToUpper
        'Me.input = QuitaAcentos(input).ToUpper
        Me.estricto = False
        'Si el input comienza con "$", es una búsqueda estricta.
        If input.Substring(input.Length - 1) = "$" Then
            Me.estricto = True
            Me.input = Me.input.Replace("$", "")
        End If
    End Sub

End Class