Imports System.ComponentModel
Imports Buscador.Globales
Imports Buscador.Tools
Public Class frmMain
    Dim grupoTextbox As New List(Of TextBox)
    Private Sub fGestor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitialSetup()
        PopulateLists()
        Me.CenterToScreen()
        Me.Icon = My.Resources.Uppsala


        'panels
        pnlInfo.Tag = ""
        pnlUpdate.BackColor = darkColor
        pnlInput.BackColor = darkColor
        pnlInterest.BackColor = darkColor

        'pnlInfo
        pnlInfo.BackColor = Color.FromArgb(32, 32, 32)
        Dim tbInfoList As New List(Of TextBox)
        Dim lblInfoList As New List(Of Label)
        Dim row, column As Integer
        'tbInfo
        For i As Integer = 0 To 9
            Dim tBox As New TextBox
            tBox.Tag = i
            pnlInfo.Controls.Add(tBox)
        Next
        'Dim tbInfoList As List(Of TextBox) = GetControls(Of TextBox)(pnlInfo)
        'TODO:
        'Decidir si generar los texboxes en codigo o en diseño
        'Idem labels
        For Each tBox As TextBox In tbInfoList
            AddHandler tBox.TextChanged, AddressOf tbInfo_TextChanged
            AddHandler tBox.KeyPress, AddressOf tbInfo_KeyPress
            AddHandler tBox.GotFocus, AddressOf tbInfo_GetFocus
            tBox.AutoSize = False
        Next
        For i = 0 To 9
            Dim lbl As New Label
            pnlInfo.Controls.Add(lbl)
            row = i Mod 5
            column = i \ 5
            With lbl
                .Name = "lblInfo" + i.ToString("0")
                .BorderStyle = BorderStyle.None
                .BackColor = pnlInfo.BackColor
                .ForeColor = Color.Black
                .Size = New Size(60, 25)
                .Font = New Font(New FontFamily("Arial"), 16, FontStyle.Bold, GraphicsUnit.Pixel)
                .Location = New Point(190 * column, 25 * row)
                .Text = "Label" + i.ToString
            End With
            pnlInfo.Controls.Add(lbl)

        Next

        DisplayMode(pnlInfo)

        'pnlInterest
        AddHandler tbMonth.KeyPress, AddressOf tBoxInterest_KeyPress
        AddHandler tbYear.KeyPress, AddressOf tBoxInterest_KeyPress
        AddHandler tbInitValue.KeyPress, AddressOf tBoxInterest_KeyPress
        AddHandler tbMonth.GotFocus, AddressOf tBoxInterest_GotFocus
        AddHandler tbYear.GotFocus, AddressOf tBoxInterest_GotFocus
        AddHandler tbInitValue.GotFocus, AddressOf tBoxInterest_GotFocus
    End Sub

    Private Sub CleanProjectWindow()
        tbMonth.Text = ""
        tbYear.Text = ""
        tbInitValue.Text = ""
        tbInput.Focus()
    End Sub
    Private Sub lvResultadosBusqueda_KeyDown(sender As Object, e As KeyEventArgs) Handles lvResultadosBusqueda.KeyDown
        'TODO:
        'Cambiar a DataGridView
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
                BulkEdit(itemsSeleccionados, valor, seleccion)
                PerformSearch(tbInput.Text)
            End If
            If e.Control Then
                valor = InputBox("Nuevo PVP")
                If Not IsNumeric(valor) OrElse CInt(valor) <= 0 Then Exit Sub
                BulkEdit(itemsSeleccionados, valor, 4)
                PerformSearch(tbInput.Text)
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
            BulkDelete(itemsSeleccionados)
            lvResultadosBusqueda.Items.Clear()
            tbInput.Focus()
            PerformSearch(tbInput.Text)
        End If
    End Sub
    Private Sub lvData_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvResultadosBusqueda.SelectedIndexChanged
        'captura el indice donde se hizo clic
        If My.Computer.Keyboard.CtrlKeyDown Then Exit Sub
        Dim renglon As Integer = lvResultadosBusqueda.FocusedItem.Index
        Dim id As Integer = Convert.ToInt32(lvResultadosBusqueda.Items(renglon).Name)
        PopulateInfo(libro(id))
    End Sub
    Private Sub buttonSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        PerformSearch(tbInput.Text)
    End Sub
    Private Sub btnApplyInterest_Click(sender As Object, e As EventArgs) Handles btnApplyInterest.Click
        CalculateInterest(tbYear.Text, tbMonth.Text, tbInitValue.Text)
    End Sub
    Private Sub formMain_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        tbInput.Focus()
    End Sub

    Public Sub InfoClean()
        Dim textboxList As List(Of TextBox) = GetTextBoxes(pnlInfo)
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

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs)
        'TODO:
        'Refactorear para nuevo form EDIT
        If pnlInfo.Tag = "" Then Exit Sub
        If MsgBox("¿Eliminar entrada?",
                  MsgBoxStyle.OkCancel + MsgBoxStyle.DefaultButton2,
                  "Eliminar entrada") = MsgBoxResult.Cancel Then Exit Sub
        Dim id As Integer
        id = CInt(pnlInfo.Tag)
        DeleteBookAt(id)
        SaveCSV()
        lvResultadosBusqueda.Items.Clear()
        'btnCancel.PerformClick()
        tbInput.Focus()
        PerformSearch(tbInput.Text)
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs)
        'TODO:
        'Refactorear para nuevo form EDIT
        If Not IsNumeric(grupoTextbox(2).Text) Then
            MsgBox("Ingrese un PVP válido", MsgBoxStyle.Exclamation, "Error")
            grupoTextbox(2).Focus()
            grupoTextbox(2).SelectAll()
            Exit Sub
        End If
        Dim id As Integer
        Dim nuevo As Boolean
        If pnlInfo.Tag = "" Then
            nuevo = True
            id = libro.Count
        Else
            nuevo = False
            id = CInt(pnlInfo.Tag)
        End If
        Dim datos(0 To 8) As String
        datos(0) = grupoTextbox(0).Text                 'Título
        datos(1) = grupoTextbox(1).Text                 'Autor
        datos(2) = NumericSubstring(grupoTextbox(4).Text)  'ISBN
        datos(3) = grupoTextbox(5).Text                 'Editorial
        datos(4) = grupoTextbox(2).Text                 'PVP
        datos(5) = Month(Now).ToString                  'Mes
        datos(6) = (Year(Now) - 2000).ToString          'Año
        datos(7) = grupoTextbox(6).Text                 'Sello
        datos(8) = grupoTextbox(7).Text                 'Tema
        If grupoTextbox(6).Text = "Sello" Then datos(7) = "-"
        If grupoTextbox(6).Text = "Tema" Then datos(8) = "-"
        If Not datos(3).StartsWith("*") Then datos(3) = "*" & datos(3)
        Dim item As New BookData(datos, id)
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
        EditaAgrega(item, nuevo)
        SaveCSV()
        tbInput.Text = item.isbn
        PerformSearch(tbInput.Text)
    End Sub
    Public Sub PopulateInfo(item As BookData)
        Dim culture As New System.Globalization.CultureInfo("es-ES", False)
        Dim priceBase, priceAdjusted, priceProjected As Integer
        Dim pBaseText, priceAdjustedText, priceProjectedText, textBoxDateText As String
        Dim tboxList As List(Of TextBox) = GetTextBoxes(pnlInfo)

        priceBase = item.price
        priceAdjusted = RoundUp(priceBase * Globales.recargo, 100)
        priceProjected = ApplyInterest(item.setDate(), priceAdjusted)
        pBaseText = priceBase.ToString("##,#", culture.NumberFormat)
        priceAdjustedText = priceAdjusted.ToString("##,#", culture.NumberFormat)
        priceProjectedText = priceProjected.ToString("##,#", culture.NumberFormat)
        textBoxDateText = item.setDate().ToString("yyyy-MM-dd HH:mm") + " (" + priceProjectedText + ")"

        tboxList(0).Text = item.title
        tboxList(1).Text = item.author
        tboxList(2).Text = item.publisher
        tboxList(3).Text = item.isbn
        tboxList(4).Text = item.label
        tboxList(5).Text = priceAdjustedText
        tboxList(6).Text = pBaseText
        tboxList(7).Text = textBoxDateText
        tboxList(8).Text = item.description
        pnlInfo.Tag = item.id.ToString

        Try
            CopyToClipboard(item.title, item.isbn, item.publisher, item.label, CStr(priceAdjusted))
        Catch ex As Exception
            MsgBox("Error al copiar al portapapeles" + vbCrLf + "Mensaje del error: " + ex.ToString)
        End Try

    End Sub

    Private Sub PerformSearch(text As String)
        Dim searchResults As List(Of Integer)
        If text.First = "*"c Then text = text.Replace("*", "")
        If text.IndexOf(":") >= 0 Then
            searchResults = SearchWithFilters(text)
        Else
            searchResults = Search(text)
        End If
        InfoClean()
        lvResultadosBusqueda.Items.Clear()
        tbInput.Focus()
        tbInput.SelectAll()
        If IsNothing(searchResults) Then Return
        historial.Add(New EntradaHistorial(text, searchResults))
        ShowResults(searchResults)
    End Sub

    Public Shared Sub ShowResults(items As List(Of Integer))
        For Each f In items
            Dim row As New ListViewItem
            row = PrepareRow(libro(f))
            'row = PreparaListviewItem(libro(f))
            AgregaItemAListview(row, frmMain.lvResultadosBusqueda)

            frmMain.PopulateInfo(libro(f))
        Next
    End Sub
    Private Sub formMain_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                tbInput.Focus()
                tbInput.SelectAll()
            Case Keys.F1
                MuestraHistorial()
        End Select
    End Sub
    'Textbox de búsqueda estándar
    Private Sub textBoxInput_Keypress(sender As Object, e As KeyPressEventArgs) Handles tbInput.KeyPress
        If Asc(e.KeyChar) = 13 Then
            PerformSearch(tbInput.Text)
            e.Handled = True
        End If
    End Sub

    'TextBoxes in panel Interest
    Private Sub tBoxInterest_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            CalculateInterest(tbYear.Text, tbMonth.Text, tbInitValue.Text)
            e.Handled = True
        End If
    End Sub
    Private Sub tBoxInterest_GotFocus(sender As TextBox, e As EventArgs)
        sender.SelectAll()
    End Sub

    'Panel Info
    Private Sub tbInfo_TextChanged(sender As Object, e As EventArgs)
        DynamicFontSize(TryCast(sender, TextBox))
    End Sub
    Private Sub tbInfo_KeyPress(sender As Object, e As KeyPressEventArgs)
        '
    End Sub
    Private Sub tbInfo_GetFocus(sender As Object, e As EventArgs)
        Dim tb As TextBox = TryCast(sender, TextBox)
        tb.SelectAll()
    End Sub
    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        ToggleControls(Of Button)(pnlInfo)
        EditMode(pnlInfo)
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        ToggleControls(Of Button)(pnlInfo)
        DisplayMode(pnlInfo)
    End Sub

    Private Sub buttonUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim ofd As New OpenFileDialog
        ofd.Title = "Seleccione archivo de precios nuevos"
        ofd.Filter = "Archivos CSV|*.csv"
        ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        If ofd.ShowDialog <> Windows.Forms.DialogResult.OK Then Return
        UpdateByPublisher(ofd.FileName)
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



    Private Sub CalculateInterest(yearStr As String, monthStr As String, valueStr As String)
        Dim yearInt As Integer
        Dim monthInt As Integer
        Dim setDate As Date
        Dim initValue As Integer
        Dim finalValue As Integer

        Try
            yearInt = Convert.ToInt32(yearStr)
        Catch ex As Exception
            MsgBox("Ingrese un año menor o igual a" + Year(Now).ToString("YY"))
            Return
        End Try
        Try
            monthInt = Convert.ToInt32(monthStr)
        Catch ex As Exception
            MsgBox("Ingrese un número del 1 al 12")
            Return
        End Try
        Try
            initValue = Convert.ToInt32(valueStr)
        Catch ex As Exception
            MsgBox("Ingrese un número entero menor a 1 millón")
            Return
        End Try

        setDate = ValidateDate(2000 + yearInt, monthInt)
        If setDate = DateTime.MinValue Then
            MsgBox("Error al convertir fecha")
            Return
        End If
        finalValue = ApplyInterest(setDate, initValue)
        lblFinalValue.Text = CStr(finalValue)
        tbMonth.Focus()
    End Sub


End Class