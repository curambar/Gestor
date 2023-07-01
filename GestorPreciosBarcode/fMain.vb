Imports Buscador.Globales
Public Class fMain
    Dim grupoTextbox As New List(Of TextBox)
    Private Sub fGestor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Subrutinas.CargaInicial()
        Me.CenterToScreen()
        Me.Icon = My.Resources.Uppsala
        panelInfo.Tag = ""
        pnlBotones.BackColor = darkColor
        pnlInput.BackColor = darkColor
        pnlProyectar.BackColor = darkColor

        'GeneraTextbox()
        GenerateInfoPanel()
        Timer1.Start()
    End Sub
    Public Shared Function GetChildControls(Of TControl As Control)(ByVal control As Control) As IEnumerable(Of TControl)
        Dim children = If(control.Controls IsNot Nothing, control.Controls.OfType(Of TControl)(), Enumerable.Empty(Of TControl)())
        Return children.SelectMany(Function(c) CType(GetChildControls(Of TControl)(c), IEnumerable(Of TControl))).Concat(children)
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
    Private Sub GenerateInfoPanel()
        Dim fontFamily As New FontFamily("Arial")
        Dim bigFont As New Font(fontFamily, 32, FontStyle.Bold, GraphicsUnit.Pixel)
        Dim mediumFont As New Font(fontFamily, 16, FontStyle.Bold, GraphicsUnit.Pixel)
        Dim smallFont As New Font(fontFamily, 10, FontStyle.Bold, GraphicsUnit.Pixel)
        Dim buttonList As New List(Of Button)
        Dim textList As List(Of TextBox) = GetTextBoxes(panelInfo)

        With buttonEdit
            .Text = "Editar"
            .Location = New Point(189, 130)
        End With
        With buttonDelete
            .Text = "Eliminar"
            .Location = New Point(251, 130)
        End With
        With buttonSave
            .Text = "Guardar"
            .Location = New Point(313, 130)
        End With
        buttonList.Add(buttonEdit)
        buttonList.Add(buttonDelete)
        buttonList.Add(buttonSave)
        panelInfo.BackColor = Color.FromArgb(32, 32, 32)

        For i As Integer = 0 To 2
            With buttonList(i)
                .AutoSize = False
                .Height = 25
                .Width = 62
                .BackColor = Color.FromArgb(64, 64, 64)
                .ForeColor = Color.White
                .FlatStyle = FlatStyle.Flat
                .FlatAppearance.BorderColor = .BackColor
            End With
        Next

        For i As Integer = 0 To textList.Count - 1
            AddHandler textList(i).TextChanged, AddressOf textInfo_TextChanged
            With textList(i)
                .AutoSize = False
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
        InfoClean()

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
        'PresentaDatos(libro(id))
        PopulateInfo(libro(id))
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
    Public Sub InfoClean()
        Dim textboxList As List(Of TextBox) = GetTextBoxes(panelInfo)
        textboxList(0).Text = "titulo"
        textboxList(1).Text = "autor"
        textboxList(2).Text = "editorial"
        textboxList(3).Text = "isbn"
        textboxList(4).Text = "sello"
        textboxList(5).Text = "pvp"
        textboxList(6).Text = "descuento"
        textboxList(7).Text = "fecha"
        textboxList(8).Text = "tema"

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
        panelInfo.Tag = ""
    End Sub
    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If panelInfo.Tag = "" Then Exit Sub
        If MsgBox("¿Eliminar entrada?",
                  MsgBoxStyle.OkCancel + MsgBoxStyle.DefaultButton2,
                  "Eliminar entrada") = MsgBoxResult.Cancel Then Exit Sub
        Dim id As Integer
        id = CInt(panelInfo.Tag)
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
        If panelInfo.Tag = "" Then
            nuevo = True
            id = libro.Count
        Else
            nuevo = False
            id = CInt(panelInfo.Tag)
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
    Public Sub PopulateInfo(item As Libros)
        Dim culture As New System.Globalization.CultureInfo("es-ES", False)
        Dim mes As Integer = CInt(item.mes)
        Dim año As Integer = CInt(item.año)
        Dim fecha As String = item.mes.Trim & "/" & item.año.Trim
        Dim priceBase As Integer = Redondea(item.pvp, 100)
        Dim priceAdjusted As Integer = Subrutinas.Redondea(priceBase * Globales.recargo, 100)
        Dim priceProjected As Integer = Redondea(Proyectar(mes, año - 10, priceAdjusted), 100)
        Dim pBaseText As String = priceBase.ToString("##,#", culture.NumberFormat)
        Dim pAdjustedText As String = priceAdjusted.ToString("##,#", culture.NumberFormat)
        Dim pProjectedText As String = priceProjected.ToString("##,#", culture.NumberFormat)
        Dim tboxDateText As String = fecha + " (" + pProjectedText + ")"
        Dim tboxList As List(Of TextBox) = GetTextBoxes(panelInfo)


        tboxList(0).Text = item.titulo
        tboxList(1).Text = item.autor
        tboxList(2).Text = item.editorial
        tboxList(3).Text = item.isbn
        tboxList(4).Text = item.sello
        tboxList(5).Text = pAdjustedText
        tboxList(6).Text = pBaseText
        tboxList(7).Text = tboxDateText
        tboxList(8).Text = item.tema

        panelInfo.Tag = item.id.ToString
        Try
            PortaPapeles(item.titulo, item.isbn, item.editorial, item.sello, priceAdjusted.ToString)
        Catch ex As Exception
            MsgBox("Error al copiar al portapapeles" + vbCrLf + "Mensaje del error: " + ex.ToString)
        End Try
    End Sub
    'Public Sub PresentaDatos(item As Libros)
    '    Dim fecha As String = item.mes.ToString.Trim & "/" & item.año.ToString.Trim
    '    Dim pvpBase As Integer = Redondea(item.pvp, 100)
    '    Dim pvpRecargado As Integer = Subrutinas.Redondea(pvpBase * Globales.recargo, 100)
    '    Dim pvp As String = pvpRecargado.ToString
    '    'pvp = pvp & " (" & item.pvp.ToString & ")"
    '    grupoTextbox(0).Text = item.titulo
    '    grupoTextbox(1).Text = item.autor
    '    grupoTextbox(2).Text = pvpBase.ToString
    '    txtPriceAdjusted.Text = pvpRecargado.ToString
    '    grupoTextbox(3).Text = fecha
    '    grupoTextbox(4).Text = FuncionesTexto.ExtraeNumeros(item.isbn)
    '    grupoTextbox(5).Text = item.editorial
    '    grupoTextbox(6).Text = item.sello
    '    grupoTextbox(7).Text = item.tema
    '    panelInfo.Tag = item.id.ToString
    '    Try
    '        PortaPapeles(item.titulo, item.isbn, item.editorial, item.sello, pvpRecargado.ToString)
    '    Catch ex As Exception
    '        MsgBox("Error al copiar al portapapeles" + vbCrLf + "Mensaje del error: " + ex.ToString)
    '    End Try
    'End Sub
    Private Sub EjecutaBusqueda()
        Dim busqueda As New List(Of Integer)
        Dim texto As String = txtInput.Text
        If texto.First = "*"c Then texto = texto.Replace("*", "")

        If texto.IndexOf(":") >= 0 Then
            busqueda = Subrutinas.BusquedaPorCampos(texto)
        Else
            busqueda = Subrutinas.Buscar(texto)
        End If
        InfoClean()
        'TxtClean()
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
            'fMain.PresentaDatos(libro(f))
            fMain.PopulateInfo(libro(f))
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
    'Private Sub GeneraTextbox()
    '    Dim nombre As String = "txtDetalles"
    '    For i = 0 To 7
    '        Dim t As TextBox
    '        t = pnlDetalles.Controls(nombre + i.ToString)
    '        grupoTextbox.Add(t)
    '        AddHandler t.KeyDown, AddressOf grupoTextbox_KeyDown
    '        AddHandler t.GotFocus, AddressOf grupoTextbox_GotFocus
    '    Next
    'End Sub
    'Private Sub grupoTextbox_GotFocus(sender As Object, e As EventArgs)
    '    TryCast(sender, TextBox).SelectAll()
    'End Sub
    'Private Sub grupoTextbox_KeyDown(sender As Object, e As KeyEventArgs)
    '    Dim txtBox As TextBox = TryCast(sender, TextBox)
    '    Dim tag As Integer = CInt(txtBox.Tag)
    '    If tag = 3 Then
    '        e.Handled = True
    '        Return
    '    End If
    '    Select Case e.KeyCode
    '        Case Keys.Enter
    '            If tag = 7 Then
    '                btnSave.PerformClick()
    '            ElseIf tag = 2 Then
    '                grupoTextbox(4).Focus()
    '            Else
    '                grupoTextbox(tag + 1).Focus()
    '            End If
    '            e.Handled = True
    '            e.SuppressKeyPress = True
    '    End Select
    'End Sub

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

    Private Sub DynamicFontSize(ByRef tBox As TextBox)

        If tBox.Text.Length = 0 Then
            Return
        End If

        Dim height As Single = tBox.Height * 0.9F
        Dim width As Single = tBox.Width * 0.9F

        tBox.SuspendLayout()

        Dim tryFont As Font = tBox.Font
        Dim tempSize As Size = TextRenderer.MeasureText(tBox.Text, tryFont)

        Dim heightRatio As Single = height / tempSize.Height
        Dim widthRatio As Single = width / tempSize.Width
        Dim minRatio As Single = Math.Min(widthRatio, heightRatio)
        Dim fontSize As Single = Math.Max(8, tryFont.Size * Math.Min(widthRatio, heightRatio))
        tryFont = New Font(tryFont.FontFamily, fontSize, tryFont.Style)

        tBox.Font = tryFont
        tBox.ResumeLayout()
    End Sub

    Private Sub textInfo_TextChanged(sender As Object, e As EventArgs)
        DynamicFontSize(TryCast(sender, TextBox))
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        hue += 5
        If hue > 360 Then hue -= 360
        Me.BackColor = toRGB(hue, 0.5, 0.5)
    End Sub
End Class