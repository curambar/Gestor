Imports Buscador.Globales
Imports Microsoft.Office.Interop
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
                Dim renglon As Integer = x.Index
                Dim id As Integer = Convert.ToInt32(lvResultadosBusqueda.Items(renglon).Name)
                itemsSeleccionados.Add(id)
            Next
            If MsgBox("Confirma la eliminación de estos títulos?", vbOKCancel + MsgBoxStyle.DefaultButton2, "Confirma eliminación") = MsgBoxResult.Cancel Then
                Exit Sub
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
        grupoTextbox(7).Text = Now.ToString("MM/yy")
        grupoTextbox(3).Text = "ISBN"
        grupoTextbox(4).Text = "Editorial"
        grupoTextbox(6).Text = "Tema"
        grupoTextbox(5).Text = "Sello"
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

        Dim datos(0 To 9) As String
        datos(0) = grupoTextbox(0).Text
        datos(1) = grupoTextbox(1).Text
        datos(2) = ExtraeNumeros(grupoTextbox(3).Text)
        datos(3) = grupoTextbox(4).Text
        datos(4) = grupoTextbox(2).Text
        datos(5) = Month(Now).ToString
        datos(6) = (Year(Now) - 2000).ToString
        If grupoTextbox(5).Text = "Sello" Then
            datos(7) = "-"
        Else
            datos(7) = grupoTextbox(5).Text
        End If
        If grupoTextbox(6).Text = "Tema" Then
            datos(8) = "-"
        Else
            datos(8) = grupoTextbox(6).Text
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
        Subrutinas.GuardaCSV()
        txtInput.Text = item.isbn
        btnBuscar.PerformClick()
    End Sub

    Public Sub PresentaDatos(item As Libros)
        Dim fecha As String = item.mes.ToString.Trim & "/" & item.ano.ToString.Trim

        grupoTextbox(0).Text = item.titulo
        grupoTextbox(1).Text = item.autor
        grupoTextbox(3).Text = FuncionesTexto.ExtraeNumeros(item.isbn)
        grupoTextbox(4).Text = item.editorial
        grupoTextbox(2).Text = item.pvp.ToString
        grupoTextbox(7).Text = fecha
        grupoTextbox(6).Text = item.tema
        grupoTextbox(5).Text = item.sello
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

    Private Sub GeneraTextbox()
        For i = 0 To 7
            Dim t As New TextBox
            pnlPresentacion.Controls.Add(t)
            t.Width = 365
            t.Height = 25
            t.Tag = i
            t.TabIndex = i + 8
            t.TabStop = True
            t.BackColor = Color.LightGray
            t.BorderStyle = BorderStyle.FixedSingle
            t.Font = btnSave.Font
            t.TextAlign = HorizontalAlignment.Center
            Select Case i
                Case 0
                    t.Text = "Título"
                    t.Location = New Point(3, 3)
                Case 1
                    t.Text = "Autor"
                    t.Location = New Point(3, 27)
                Case 2
                    t.Text = "PVP"
                    t.Location = New Point(3, 51)
                    t.Width = 69
                Case 3
                    t.Text = "ISBN"
                    t.Location = New Point(253, 51)
                    t.Width = 115
                Case 4
                    t.Text = "Editorial"
                    t.Location = New Point(3, 75)
                    t.Width = 168
                Case 5
                    t.Text = "Sello"
                    t.Location = New Point(170, 75)
                    t.Width = 198
                Case 6
                    t.Text = "Tema"
                    t.Location = New Point(3, 99)
                Case 7
                    t.Text = "Fecha"
                    t.Location = New Point(130, 51)
                    t.Width = 69
                    t.TabStop = False
            End Select
            grupoTextbox.Add(t)
            AddHandler t.KeyPress, AddressOf grupoTextbox_KeyPress
        Next
    End Sub

    Private Sub grupoTextbox_KeyPress(sender As Object, e As KeyPressEventArgs)
        Dim tagSender = sender.Tag

        If tagSender = 7 Then   'Sale si es el textbox de fecha
            e.Handled = True
            Exit Sub
        End If

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

    Private Sub ActualizarToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ActualizarToolStripMenuItem1.Click
        'Abre un CSV conteniendo actualizacion de precios
        'Arma una lista de "libro" con los datos a actualizar
        'Finalmente ejecuta la rutina de actualizacion

        Dim myStream As System.IO.Stream = Nothing
        Dim openFileDialog1 As New OpenFileDialog()
        openFileDialog1.InitialDirectory = System.AppDomain.CurrentDomain.BaseDirectory()
        openFileDialog1.Filter = "CSV (*.csv)|*.csv|Excel (*.xlsx)|*.xlsx|Excel 97 (*.xls)|*.xls"
        openFileDialog1.FilterIndex = 2
        openFileDialog1.RestoreDirectory = True

        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim datos As New List(Of List(Of String))
            datos = Subrutinas.ExtraeDatos(openFileDialog1.FileName)
            Dim formDatos As New formDatosActualizacion
            Dim tablaDatos As New ListView
            formDatos.Controls.Add(tablaDatos)
            tablaDatos.Bounds = New Rectangle(New Point(10, 10), New Size(300, 200))
            formDatos.Show()
        End If
    End Sub
End Class

