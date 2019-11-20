Public Class fGestor
    Public sDatos As New List(Of Libros)
    Dim tasa As New List(Of Single)

    Private Sub fGestor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sDato(0 To 6) As String
        Dim sPath As String
        Dim sArchivo As String
        Dim sTasas As String

        'Define ruta de archivos de datos
        sPath = System.AppDomain.CurrentDomain.BaseDirectory()
        sArchivo = My.Computer.FileSystem.CombinePath(sPath, "Precios.csv")
        sTasas = My.Computer.FileSystem.CombinePath(sPath, "Tasas.txt")

        'Ejecuta el parser y almacena en sDatos
        Using tPrecios As New Microsoft.VisualBasic.FileIO.TextFieldParser(sArchivo, System.Text.Encoding.Default)
            tPrecios.TextFieldType = FileIO.FieldType.Delimited
            tPrecios.SetDelimiters(";")
            Dim sLinea As String()
            While Not tPrecios.EndOfData
                sLinea = tPrecios.ReadFields()
                Dim dato As String
                Dim i As Integer
                i = 0
                For Each dato In sLinea
                    sDato(i) = dato
                    i += 1
                Next
                sDatos.Add(New Libros(sDato))
            End While
        End Using

        'Almacena las tasas en la lista tasa
        Using sr As New System.IO.StreamReader(sTasas)
            Dim sLineaTasa As String
            Do While sr.Peek() <> -1
                sLineaTasa = Val(sr.ReadLine())
                tasa.Add(sLineaTasa / 100)
            Loop
        End Using

        'Configura columnas de datos
        lvData.Columns.Add("Título", 185, HorizontalAlignment.Left)
        lvData.Columns.Add("Autor", 185, HorizontalAlignment.Left)
        lvData.Columns.Add("ISBN", 110, HorizontalAlignment.Left)
        lvData.Columns.Add("Editorial", 100, HorizontalAlignment.Left)
        lvData.Columns.Add("PVP", 50, HorizontalAlignment.Left)
        lvData.Columns.Add("Fecha", 50, HorizontalAlignment.Left)
        lvData.Columns.Add("Proy", 60, HorizontalAlignment.Left)

    End Sub


    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click

        Dim tInput As String
        Dim datosbusqueda As New List(Of Single)

        'Lee entrada
        tInput = txtInput.Text
        If tInput = "" Then Exit Sub
        If IsNumeric(tInput) And Len(tInput) = 13 Then  'ISBN
            tInput = Mid(tInput, 4, 9)
        Else
            'tInput = QuitaAcentos(tInput).ToUpper
            tInput = tInput.ToUpper
        End If


        'Rutina de búsqueda
        For i As Single = 0 To sDatos.Count - 1
            For j As Single = 0 To 2
                Dim origen As String = sDatos(i).dato(j).ToUpper
                If origen.IndexOf(tInput) >= 0 Then datosbusqueda.Add(i)
            Next j
        Next i

        lvData.Items.Clear()
        txtInput.Focus()
        txtInput.SelectAll()

        If datosbusqueda.Count = 0 Then Exit Sub
        For Each f In datosbusqueda
            agrega(f)
            Clipboard.SetText("1" & Chr(9) & sDatos(f).dato(0) & " - " & sDatos(f).dato(3) & Chr(9) & sDatos(f).dato(4))
        Next

    End Sub

    Private Sub agrega(n As Single)

        Dim aux(0 To 6) As String
        Dim sombra As Color = Color.FromArgb(128, 255, 128)

        'Agrega items al array auxiliar
        For i As Integer = 0 To 4
            aux(i) = sDatos(n).dato(i)
        Next

        'Limpia entrada de ISBN
        aux(2) = Mid(aux(2), 2)

        'Proyecta precio
        Dim mes As Integer = Val(sDatos(n).dato(5))
        Dim ano As Integer = Val(sDatos(n).dato(6))
        Dim vlr As Integer = Val(sDatos(n).dato(4))
        aux(6) = Str(proyectar(mes, ano - 10, vlr))

        'Fecha
        If mes < 10 Then aux(5) = "0"
        aux(5) = aux(5) & sDatos(n).dato(5) & "/" & sDatos(n).dato(6)

        'Agrega al listview
        Dim itm As ListViewItem
        itm = New ListViewItem(aux)

        'Colores
        If lvData.Items.Count Mod 2 = 0 Then
            itm.BackColor = sombra
            itm.UseItemStyleForSubItems = True
        End If

        lvData.Items.Add(itm)

    End Sub

    Private Shared Function QuitaAcentos(stIn As String) As String

        'Dim stFormD As String = stIn.Normalize(System.Text.NormalizationForm.FormD)
        'Dim sb As New System.Text.StringBuilder

        'For ich As Integer = 0 To stFormD.Length - 1
        '   Dim uc As System.Globalization.UnicodeCategory = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(stFormD(ich))
        '   If uc <> System.Globalization.UnicodeCategory.NonSpacingMark Then sb.Append(stFormD(ich))
        'Next ich

        'Return (sb.ToString().Normalize(System.Text.NormalizationForm.FormC))

    End Function

    Private Function Proyectar(mesDato As Integer, anoDato As Integer, valor As Single)

        Dim a_index As Integer
        Dim mesActual As Integer = Month(Now)
        Dim anoActual As Integer = Year(Now) - 2010
        Dim mes As New List(Of Integer)
        Dim ano As New List(Of Integer)

        If tasa.Count < anoActual Then
            MsgBox("Actualice el archivo de tasas de interés")
            Proyectar = 0
            Me.Close()
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

        valor = (Int(100 * valor)) / 100
        valor = Math.Round(2 * valor, 0) / 2

        Proyectar = valor

    End Function


    Private Sub btnProy_Click(sender As Object, e As EventArgs) Handles btnProy.Click

        Dim mes, ano, vlr As Integer

        If IsNumeric(txtMes.Text) Then mes = Val(txtMes.Text)
        If IsNumeric(txtAno.Text) Then ano = Val(txtAno.Text)
        If IsNumeric(txtVlr.Text) Then vlr = Val(txtVlr.Text)

        If mes < 1 Or mes > 12 Then
            MsgBox("Ingrese un mes válido")
            LimpiaProyector()
            Exit Sub
        End If

        If vlr > 9999 Then
            MsgBox("Ingrese un valor menor a 10.000")
            LimpiaProyector()
            Exit Sub
        End If

        If (ano = Year(Now) - 2000 And mes > Month(Now)) Or ano > Year(Now) - 2000 Then
            MsgBox("Este proyector no puede utilizarse como máquina del tiempo." & Chr(13) & "Ingrese una fecha válida.")
            LimpiaProyector()
            Exit Sub
        End If

        lblProy.Text = Str(Proyectar(mes, ano - 10, vlr))

        txtMes.Text = ""
        txtAno.Text = ""
        txtVlr.Text = ""

        txtInput.Focus()

    End Sub

    Private Sub LimpiaProyector()
        txtMes.Text = ""
        txtAno.Text = ""
        txtVlr.Text = ""
        txtMes.Focus()
    End Sub

    Private Sub gbBuscador_Enter(sender As Object, e As EventArgs) Handles gbBuscador.Enter

        Me.AcceptButton = btnOk

    End Sub

    Private Sub gbProyector_Enter(sender As Object, e As EventArgs) Handles gbProyector.Enter

        Me.AcceptButton = btnProy

    End Sub

    Private Sub lvData_DoubleClick(sender As Object, e As EventArgs) Handles lvData.DoubleClick

        Dim i As Integer, strText As String = ""

        Clipboard.Clear()

        i = lvData.FocusedItem.Index

        With lvData.Items(i)
            strText = "1" & Chr(9) & .SubItems(0).Text & " - " & .SubItems(3).Text & Chr(9) & .SubItems(4).Text
        End With

        Clipboard.SetText(strText)
        txtInput.Focus()

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click

        Me.Close()

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

        If Label1.Text = "Uppsala" Then
            Label1.Text = "Viva Perón"
        Else
            Label1.Text = "Uppsala"
        End If

    End Sub

End Class
