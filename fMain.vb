Imports Buscador.Globales
Public Class fMain
    Dim grupoTextbox As New List(Of TextBox)
    Private Sub fGestor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Subrutinas.CargaInicial()
        Me.CenterToScreen()
        Me.Icon = My.Resources.Uppsala
        lblID.Text = ""
        GeneraTextbox()
    End Sub
    Private Sub sProyectar()
        Dim mes As Byte
        Dim ano As Byte
        Dim valor As Decimal
        Dim texto As String
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
        texto = Redondea(Proyectar(mes, ano - 10, valor), 100).ToString
        lblProy.Text = texto
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
            Dim textoCuadroSeleccion As String
            textoCuadroSeleccion = "1 - Autor" + vbCrLf + "3 - Editorial" + vbCrLf + "7 - Sello" + vbCrLf + "8 - Tema"
            For Each x As ListViewItem In lvResultadosBusqueda.SelectedItems
                itemsSeleccionados.Add(CInt(x.Name))
            Next
            Dim valor As String
            If e.Shift Then
                valor = InputBox(textoCuadroSeleccion, "Cambiar valor")
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
                Subrutinas.GuardaCSV()
                btnBuscar.PerformClick()
            End If
            If e.Control Then
                valor = InputBox("Nuevo PVP")
                If Not IsNumeric(valor) OrElse CInt(valor) <= 0 Then Exit Sub
                Subrutinas.BulkEdit(itemsSeleccionados, valor, 4)
                Subrutinas.GuardaCSV()
                btnBuscar.PerformClick()
            End If
        End If
        If e.KeyCode = Keys.Delete And e.Control Then
            Dim itemsSeleccionados As New List(Of Integer)
            For Each x As ListViewItem In lvResultadosBusqueda.SelectedItems
                itemsSeleccionados.Add(CInt(x.Name))
            Next
            If MsgBox("Confirma la eliminación de estos títulos?", vbOKCancel + MsgBoxStyle.DefaultButton2, "Confirma eliminación") = MsgBoxResult.Cancel Then
                Return
            End If
            itemsSeleccionados.Sort(Function(x, y) y.CompareTo(x))
            Subrutinas.BulkDelete(itemsSeleccionados)
            Subrutinas.GuardaCSV()
            lvResultadosBusqueda.Items.Clear()
            txtInput.Focus()
            btnBuscar.PerformClick()
        End If
    End Sub
    Private Sub lvData_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvResultadosBusqueda.SelectedIndexChanged
        'captura el indice donde se hizo clic
        If My.Computer.Keyboard.CtrlKeyDown Then Exit Sub
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
        grupoTextbox(0).Focus()
        grupoTextbox(0).SelectAll()
    End Sub
    Public Sub TxtClean()
        grupoTextbox(0).Text = "Título"
        grupoTextbox(1).Text = "Autor"
        grupoTextbox(2).Text = "PVP"
        grupoTextbox(3).Text = Now.ToString("MM/yy")
        grupoTextbox(4).Text = "ISBN"
        grupoTextbox(5).Text = "Editorial"
        grupoTextbox(7).Text = "Tema"
        grupoTextbox(6).Text = "Sello"
        lblID.Text = ""
    End Sub
    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If lblID.Text = "" Then Exit Sub
        If MsgBox("¿Eliminar entrada?",
                  MsgBoxStyle.OkCancel + MsgBoxStyle.DefaultButton2,
                  "Eliminar entrada") = MsgBoxResult.Cancel Then Exit Sub
        Dim id As Integer
        id = CInt(lblID.Text)
        Subrutinas.EliminaLibro(id)
        Subrutinas.GuardaCSV()
        lvResultadosBusqueda.Items.Clear()
        btnCancel.PerformClick()
        txtInput.Focus()
        btnBuscar.PerformClick()
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not IsNumeric(grupoTextbox(2).Text) Then
            MsgBox("Ingrese un PVP válido", MsgBoxStyle.Exclamation, "Error")
            grupoTextbox(2).Focus()
            grupoTextbox(2).SelectAll()
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
        Dim datos(0 To 8) As String
        datos(0) = grupoTextbox(0).Text                 'Título
        datos(1) = grupoTextbox(1).Text                 'Autor
        datos(2) = ExtraeNumeros(grupoTextbox(4).Text)  'ISBN
        datos(3) = grupoTextbox(5).Text                 'Editorial
        datos(4) = grupoTextbox(2).Text                 'PVP
        datos(5) = Month(Now).ToString                  'Mes
        datos(6) = (Year(Now) - 2000).ToString          'Año
        datos(7) = grupoTextbox(6).Text                 'Sello
        datos(8) = grupoTextbox(7).Text                 'Tema
        If grupoTextbox(6).Text = "Sello" Then datos(7) = "-"
        If grupoTextbox(6).Text = "Tema" Then datos(8) = "-"
        If Not datos(3).StartsWith("*") Then datos(3) = "*" & datos(3)
        Dim item As New Libros(datos, id)
        Dim texto As String
        If nuevo Then
            texto = "Agregar libro nuevo" & vbCrLf & String.Join(" - ", item.array)
        Else
            texto = "Editar libro" & vbCrLf
            For i As Integer = 0 To 4
                If item.array(i) <> libro(id).array(i) Then
                    texto += vbCrLf & item.array(i) & "(NUEVO)" & vbTab & libro(id).array(i) & "(ORIGINAL)"
                End If
            Next
        End If
        If MsgBox(texto, MsgBoxStyle.OkCancel, "Confirmación") = MsgBoxResult.Cancel Then Return
        Subrutinas.EditaAgrega(item, nuevo)
        Subrutinas.GuardaCSV()
        txtInput.Text = item.isbn
        btnBuscar.PerformClick()
    End Sub
    Public Sub PresentaDatos(item As Libros)
        Dim fecha As String = item.mes.ToString.Trim & "/" & item.año.ToString.Trim
        Dim pvpRecargado As Integer = Subrutinas.Redondea(item.pvp * Globales.recargo, 100)
        Dim pvp As String = pvpRecargado.ToString
        pvp = pvp & " (" & item.pvp.ToString & ")"
        grupoTextbox(0).Text = item.titulo
        grupoTextbox(1).Text = item.autor
        'grupoTextbox(2).Text = item.pvp.ToString
        grupoTextbox(2).Text = pvp
        grupoTextbox(3).Text = fecha
        grupoTextbox(4).Text = FuncionesTexto.ExtraeNumeros(item.isbn)
        grupoTextbox(5).Text = item.editorial
        grupoTextbox(6).Text = item.sello
        grupoTextbox(7).Text = item.tema
        lblID.Text = item.id.ToString
        Try
            PortaPapeles(item.titulo, item.isbn, item.editorial, item.sello, pvpRecargado.ToString)
        Catch ex As Exception
            MsgBox("Error al copiar al portapapeles" + vbCrLf + "Mensaje del error: " + ex.ToString)
        End Try
    End Sub
    Private Sub EjecutaBusqueda()
        Dim busqueda As New List(Of Integer)
        Dim texto As String = txtInput.Text
        If texto.First = "*"c Then texto = texto.Replace("*", "")

        If texto.IndexOf(":") >= 0 Then
            busqueda = Subrutinas.BusquedaPorCampos(texto)
        Else
            busqueda = Subrutinas.Buscar(texto)
        End If
        TxtClean()
        lvResultadosBusqueda.Items.Clear()
        txtInput.Focus()
        txtInput.SelectAll()
        If IsNothing(busqueda) Then Return
        historial.Add(New EntradaHistorial(texto, busqueda))
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
    Private Sub GeneraTextbox()
        Dim nombre As String = "txtDetalles"
        For i = 0 To 7
            Dim t As TextBox
            t = pnlDetalles.Controls(nombre + i.ToString)
            grupoTextbox.Add(t)
            AddHandler t.KeyDown, AddressOf grupoTextbox_KeyDown
            AddHandler t.GotFocus, AddressOf grupoTextbox_GotFocus
        Next
    End Sub
    Private Sub grupoTextbox_GotFocus(sender As Object, e As EventArgs)
        TryCast(sender, TextBox).SelectAll()
    End Sub
    Private Sub grupoTextbox_KeyDown(sender As Object, e As KeyEventArgs)
        Dim txtBox As TextBox = TryCast(sender, TextBox)
        Dim tag As Integer = CInt(txtBox.Tag)
        If tag = 3 Then
            e.Handled = True
            Return
        End If
        Select Case e.KeyCode
            Case Keys.Enter
                If tag = 7 Then
                    btnSave.PerformClick()
                ElseIf tag = 2 Then
                    grupoTextbox(4).Focus()
                Else
                    grupoTextbox(tag + 1).Focus()
                End If
                e.Handled = True
                e.SuppressKeyPress = True
        End Select
    End Sub
    Private Sub txtDetalles3_MouseDown(sender As Object, e As MouseEventArgs) Handles txtDetalles3.MouseDown
        'Agregar rutina para actualiar fecha al hacer CTRL-Click
    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Dim ofd As New OpenFileDialog
        ofd.Title = "Seleccione archivo de precios nuevos"
        ofd.Filter = "Archivos CSV|*.csv"
        ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        If ofd.ShowDialog <> Windows.Forms.DialogResult.OK Then Return
        ActualizaPrecios(ofd.FileName)
        'Dim frm As New frmActualizar(ofd.FileName)
        'frm.ShowDialog()
    End Sub
End Class