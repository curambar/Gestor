Imports Buscador.Globales
Imports Microsoft.Office.Interop
Public Class fMain

    Private Sub fGestor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Subrutinas.CargaInicial()
        Me.CenterToScreen()
        Me.Icon = My.Resources.Uppsala
        lblID.Text = ""
    End Sub

    Private Sub sProyectar()

        Dim mes As Byte
        Dim ano As Byte
        Dim valor As Decimal

        Try
            mes = CByte(txtMes.Text)
            ano = CByte(txtAno.Text)
            valor = CDec(txtVlr.Text)
        Catch ex As Exception
            MsgBox("Ingrese fecha y monto válidos. Error = " & ex.Message)
            Exit Sub
        End Try

        If mes < 1 Or mes > 12 Then
            MsgBox("Mes incorrecto")
            Exit Sub
        End If

        If ano > Year(Now) - 2000 Then
            MsgBox("Año incorrecto")
            Exit Sub
        End If

        If valor > 999999 Then
            MsgBox("Ingrese un valor menor a 1.000.000")
            Exit Sub
        End If

        LimpiaProyector()
        lblProy.Text = Subrutinas.Proyectar(mes, ano - 10, valor).ToString

    End Sub

    Private Sub LimpiaProyector()
        txtMes.Text = ""
        txtAno.Text = ""
        txtVlr.Text = ""
        txtInput.Focus()
    End Sub

    Private Sub lvResultadosBusqueda_KeyDown(sender As Object, e As KeyEventArgs) Handles lvResultadosBusqueda.KeyDown

        If e.KeyCode = Keys.Enter Then
            Dim itemsSeleccionados As New List(Of Integer)
            Dim textoPrueba As String = ""
            For Each x As ListViewItem In lvResultadosBusqueda.SelectedItems
                Dim renglon As Integer = x.Index
                Dim id As Integer = Convert.ToInt32(lvResultadosBusqueda.Items(renglon).Name)
                itemsSeleccionados.Add(id)
            Next
            Dim valor As String
            If e.Shift Then
                valor = InputBox("1 - Autor" + vbCrLf + "3 - Editorial" + vbCrLf + _
                                 "7 - Sello" + vbCrLf + "8 - Tema", "Cambiar valor")
                If Not IsNumeric(valor) Then Exit Sub
                Dim seleccion As Integer = CInt(valor)

                Dim textoInput As String = ""
                Select Case seleccion
                    Case 1
                        textoInput = "Autor"
                    Case 3
                        textoInput = "Editorial"
                    Case 7
                        textoInput = "Sello"
                    Case 8
                        textoInput = "Tema"
                    Case Else
                        Exit Sub
                End Select
                valor = InputBox("Nuevo valor", "Nuevo " + textoInput)
                If valor = "" Then Exit Sub
                Subrutinas.BulkEdit(itemsSeleccionados, valor, seleccion)
                Subrutinas.GuardarCambiosADisco()
                btnBuscar.PerformClick()
            End If
            If e.Control Then
                valor = InputBox("Nuevo PVP")
                If Not IsNumeric(valor) OrElse CInt(valor) <= 0 Then Exit Sub
                Subrutinas.BulkEdit(itemsSeleccionados, valor, 4)
                Subrutinas.GuardarCambiosADisco()
                btnBuscar.PerformClick()
            End If
        End If
    End Sub

    Private Sub lvData_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvResultadosBusqueda.SelectedIndexChanged
        'captura el indice donde se hizo clic
        Dim renglon As Integer = lvResultadosBusqueda.FocusedItem.Index    'El indice del Listview seleccionado
        Dim id As Integer = Convert.ToInt32(lvResultadosBusqueda.Items(renglon).Name)   'El indice del libro seleccionado
        PresentaDatos(libro(id))
    End Sub



    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        EjecutaBusqueda()
    End Sub

    Private Sub btnProyectar_Click(sender As Object, e As EventArgs) Handles btnProyectar.Click
        sProyectar()
    End Sub

    Private Sub fGestor_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txtInput.Focus()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        TxtClean()
        txtTitulo.Focus()
        txtTitulo.SelectAll()
    End Sub

    Public Sub TxtClean()
        txtTitulo.Text = "Título"
        txtAutor.Text = "Autor"
        txtPVP.Text = "PVP"
        txtFecha.Text = Now.ToString("MM/yy")
        txtISBN.Text = "ISBN"
        txtEditorial.Text = "Editorial"
        txtTema.Text = "Tema"
        txtSello.Text = "Sello"
        lblID.Text = ""

    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click

        If lblID.Text = "" Then Exit Sub
        If MsgBox("¿Eliminar entrada?", _
                  MsgBoxStyle.OkCancel + MsgBoxStyle.DefaultButton2, _
                  "Eliminar entrada") = MsgBoxResult.Cancel Then Exit Sub
        Dim id As Integer
        id = CInt(lblID.Text)
        Subrutinas.EliminaLibro(id)
        Subrutinas.GuardarCambiosADisco()
        lvResultadosBusqueda.Items.Clear()
        btnCancel.PerformClick()
        txtInput.Focus()
        btnBuscar.PerformClick()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not IsNumeric(txtPVP.Text) Then
            MsgBox("Ingrese un PVP válido", MsgBoxStyle.Exclamation, "Error")
            txtPVP.Focus()
            txtPVP.SelectAll()
            Exit Sub
        End If

        Dim id As Integer
        Dim nuevo As Boolean

        If lblID.Text = "" Then
            nuevo = True
            id = libro.Count
        Else
            nuevo = False
            id = CInt(lblID.Text)
        End If

        Dim datos(0 To 9) As String
        datos(0) = txtTitulo.Text
        datos(1) = txtAutor.Text
        datos(2) = ExtraeNumeros(txtISBN.Text)
        datos(3) = txtEditorial.Text
        datos(4) = txtPVP.Text
        datos(5) = Month(Now).ToString
        datos(6) = (Year(Now) - 2000).ToString
        If txtSello.Text = "Sello" Then
            datos(7) = "-"
        Else
            datos(7) = txtSello.Text
        End If
        If txtTema.Text = "Tema" Then
            datos(8) = "-"
        Else
            datos(8) = txtTema.Text
        End If
        datos(9) = id.ToString

        If Not datos(3).StartsWith("*") Then datos(3) = "*" & datos(3)

        Dim item As New Libros(datos)
        Dim texto As String

        If nuevo Then
            texto = "Agregar libro nuevo" & vbCrLf & String.Join(" - ", item.array)
        Else
            texto = "Editar libro" & vbCrLf
            For i As Integer = 0 To 4
                If item.array(i) <> libro(item.id).array(i) Then
                    texto += vbCrLf & item.array(i) & "(NUEVO)" & vbTab & libro(item.id).array(i) & "(ORIGINAL)"
                End If
            Next
        End If

        If MsgBox(texto, MsgBoxStyle.OkCancel, "Confirmación") = MsgBoxResult.Cancel Then
            Exit Sub
        End If

        Subrutinas.EditaAgrega(item, nuevo)
        Subrutinas.GuardarCambiosADisco()
        txtInput.Text = item.isbn
        btnBuscar.PerformClick()
    End Sub

    Public Sub PresentaDatos(item As Libros)
        Dim fecha As String = item.mes.ToString.Trim & "/" & item.ano.ToString.Trim

        txtTitulo.Text = item.titulo
        txtAutor.Text = item.autor
        txtISBN.Text = FuncionesTexto.ExtraeNumeros(item.isbn)
        txtEditorial.Text = item.editorial
        txtPVP.Text = item.pvp.ToString
        txtFecha.Text = fecha
        txtTema.Text = item.tema
        txtSello.Text = item.sello
        lblID.Text = item.id.ToString

        PortaPapeles(item.titulo, item.isbn, item.editorial, item.sello, item.pvp.ToString)

    End Sub

    Private Sub EjecutaBusqueda()
        Dim busqueda As New List(Of Integer)
        If txtInput.Text.IndexOf(":") >= 0 Then
            busqueda = Subrutinas.BusquedaEspacios(txtInput.Text)
        Else
            busqueda = Subrutinas.Buscar(txtInput.Text)
        End If
        If Not IsNothing(busqueda) Then
            historial.Add(New EntradaHistorial(txtInput.Text, busqueda))
        End If
        TxtClean()
        lvResultadosBusqueda.Items.Clear()
        txtInput.Focus()
        txtInput.SelectAll()

        If busqueda Is Nothing Then Exit Sub
        PresentaBusqueda(busqueda)
    End Sub

    Public Shared Sub PresentaBusqueda(items As List(Of Integer))
        For Each f In items
            Dim renglon As New ListViewItem
            renglon = Subrutinas.PreparaListviewItem(libro(f))
            Subrutinas.AgregaItemAListview(renglon, fMain.lvResultadosBusqueda)
            fMain.PresentaDatos(libro(f))
        Next
    End Sub

    Private Sub fGestor_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            txtInput.Focus()
            txtInput.SelectAll()
        End If
        Select Case e.KeyCode
            Case Keys.Escape
                txtInput.Focus()
                txtInput.SelectAll()
            Case Keys.F1
                Subrutinas.MuestraHistorial()
        End Select
    End Sub

    'Textboxes de panel presentación
    Private Sub txtTitulo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTitulo.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtAutor.Focus()
            txtAutor.SelectAll()
            e.Handled = True
        End If
    End Sub

    Private Sub txtAutor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAutor.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtPVP.Focus()
            txtPVP.SelectAll()
            e.Handled = True
        End If
    End Sub

    Private Sub txtPVP_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPVP.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtISBN.Focus()
            txtISBN.SelectAll()
            e.Handled = True
        End If
    End Sub

    Private Sub txtISBN_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtISBN.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtEditorial.Focus()
            txtEditorial.SelectAll()
            e.Handled = True
        End If
    End Sub

    Private Sub txtEditorial_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEditorial.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtSello.Focus()
            txtSello.SelectAll()
            e.Handled = True
        End If
    End Sub

    Private Sub txtSello_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSello.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtTema.Focus()
            txtTema.SelectAll()
            e.Handled = True
        End If
    End Sub

    Private Sub txtTema_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTema.KeyPress
        If Asc(e.KeyChar) = 13 Then
            btnSave.PerformClick()
            e.Handled = True
        End If
    End Sub

    'Textbox de búsqueda estándar
    Private Sub txtInput_Keypress(sender As Object, e As KeyPressEventArgs) Handles txtInput.KeyPress
        If Asc(e.KeyChar) = 13 Then
            btnBuscar.PerformClick()
            e.Handled = True
        End If
    End Sub

    'Textboxes de Proyección
    Private Sub txtMes_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMes.KeyPress
        If Asc(e.KeyChar) = 13 Then
            btnProyectar.PerformClick()
            e.Handled = True
        End If
    End Sub
    Private Sub txtAno_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAno.KeyPress
        If Asc(e.KeyChar) = 13 Then
            btnProyectar.PerformClick()
            e.Handled = True
        End If
    End Sub
    Private Sub txtVlr_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtVlr.KeyPress
        If Asc(e.KeyChar) = 13 Then
            btnProyectar.PerformClick()
            e.Handled = True
        End If
    End Sub

    Private Sub EscribeAExcelTest()
        Dim nombrePlanilla As String = "C:\Uppsala\Planillas\2021\11 - Planilla Ventas Noviembre.xlsx"
        Dim xlApp As Excel.Application
        Dim xlBook As Excel.Workbook
        Dim xlSheet As Excel.Worksheet
        xlApp = CType(System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application"), Excel.Application)
        xlBook = GetObject(nombrePlanilla)
        xlSheet = xlBook.ActiveSheet
        xlSheet.Cells(6, 2).Formula = "Sarasa"
    End Sub

End Class

