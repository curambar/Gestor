Imports GestorLibros.Rutinas
Public Class frmGestor

    Dim grupoTextbox As List(Of TextBox)
    Private Sub frmGestor_Load(sender As Object, e As EventArgs) Handles Me.Load
        If CargaInicial() Then
            Me.CenterToScreen()
            Me.Icon = My.Resources.Upalala
            lblID.Text = ""
            InitPanelPresentacion()
        End If
    End Sub
    Private Sub VolverFocoInput()
        txtInput.Focus()
        txtInput.SelectAll()
    End Sub
    ''' <summary>
    ''' Popula la lista de resultados de búsqueda
    ''' </summary>
    ''' <param name="indices">
    ''' La lista de índices de los resultados
    ''' </param>
    Sub PresentaBusqueda(indices As List(Of Integer))

        Try
            Dim libro As Libros
            Dim renglon As ListViewItem
            For Each id As Integer In indices
                libro = listaLibros(id)
                renglon = PreparaFilaListView(libro)
                AgregaItemAListview(renglon, Me.lvResultadosBusqueda)
                Me.PresentaDatos(libro)
            Next
        Catch ex As Exception
            MsgBox("Error al presentar resultados de búsqueda. Texto del error: " & ex.ToString)
        End Try

    End Sub
    Private Sub InitPanelHistorial()

    End Sub
    Private Sub InitPanelPresentacion()
        Dim grupoLabel As List(Of Label)

        grupoTextbox = New List(Of TextBox)
        grupoLabel = New List(Of Label)
        For i As Integer = 0 To 7
            Dim t As New TextBox
            Dim l As New Label

            pnlPresentacion.Controls.Add(l)
            pnlPresentacion.Controls.Add(t)
            grupoTextbox.Add(t)
            grupoLabel.Add(l)
            AddHandler t.KeyPress, AddressOf grupoTextbox_KeyPress

            With l
                .AutoSize = False
                .Width = 55
                .Height = 20
                '.BackColor = Color.LightGray
                '.BorderStyle = BorderStyle.FixedSingle
                .Font = New Font(FontFamily.GenericSansSerif, 9.0F, FontStyle.Regular)
                .TextAlign = ContentAlignment.MiddleRight
                .Location = New Point(3, 4 + 21 * i)
                Select Case i
                    Case 0
                        .Text = "Título"
                    Case 1
                        .Text = "Autor"
                    Case 2
                        .Text = "PVP"
                    Case 3
                        .Text = "ISBN"
                    Case 4
                        .Text = "Editorial"
                    Case 5
                        .Text = "Sello"
                    Case 6
                        .Text = "Tema"
                    Case 7
                        .Text = "Fecha"
                End Select
            End With

            With t
                .AutoSize = False
                .Width = 400
                .Height = 20
                .Tag = i
                .TabIndex = i + 8
                .TabStop = True
                .BackColor = pnlPresentacion.BackColor
                .BorderStyle = BorderStyle.None
                .Font = New Font(l.Font, FontStyle.Bold)
                .TextAlign = HorizontalAlignment.Left
                .Location = New Point(68, 6 + 21 * i)
                .Text = "AAA"
            End With

        Next
    End Sub
    Private Sub grupoTextbox_KeyPress(sender As Object, e As KeyPressEventArgs)
        Dim txtbox As TextBox
        Dim tagSender As Integer

        txtbox = TryCast(sender, TextBox)
        tagSender = CInt(txtbox.Tag)
        e.Handled = True

        If tagSender = 7 Then Exit Sub  'Sale si es el textbox de fecha

        If Asc(e.KeyChar) = 13 Then
            If tagSender = 6 Then
                btnSave.PerformClick()
            Else
                grupoTextbox(tagSender + 1).Focus()
                grupoTextbox(tagSender + 1).SelectAll()
            End If

            e.Handled = True
        End If
    End Sub
    ''' <summary>
    ''' Limpia los textboxes del panel presentación
    ''' </summary>
    Public Sub LimpiaDatos()
        For Each txtBox As TextBox In grupoTextbox
            txtBox.Text = ""
            lblID.Text = ""
        Next
    End Sub
    Public Sub PresentaDatos(libro As Libros)
        With libro
            Dim fecha As String = .mes.ToString.Trim & "/" & .año.ToString.Trim

            grupoTextbox(0).Text = .titulo
            grupoTextbox(1).Text = .autor
            grupoTextbox(3).Text = ExtraeNumeros(.isbn)
            grupoTextbox(4).Text = .editorial
            grupoTextbox(2).Text = .pvp.ToString
            grupoTextbox(7).Text = fecha
            grupoTextbox(6).Text = .tema
            grupoTextbox(5).Text = .sello
            lblID.Text = .id.ToString

            PortaPapeles(libro)
        End With


    End Sub

    'Rutinas de captura de inputs
    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim resultadosBusqueda As List(Of Integer)

        lvResultadosBusqueda.Items.Clear()
        LimpiaDatos()
        resultadosBusqueda = EjecutaBusqueda(txtInput.Text)
        If resultadosBusqueda.Count > 0 Then PresentaBusqueda(resultadosBusqueda)
        VolverFocoInput()

    End Sub

End Class
