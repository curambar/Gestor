Public Class formHistorial
    Private Sub formHistorial_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape, Keys.F1
                Me.Close()
        End Select
    End Sub
    Private Sub formHistorial_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim posx As Integer = Buscador.fMain.Location.X + Buscador.fMain.Size.Width - 15
        Dim posy As Integer = Buscador.fMain.Location.Y
        Me.Location = New Point(posx, posy)
        For Each x As EntradaHistorial In Globales.historial
            Dim linea As String = x.momento.ToString("yy/MM/dd - hh:mm:ss - ") + x.input
            listHistorial.Items.Add(linea)
        Next
    End Sub
    Private Sub listHistorial_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listHistorial.SelectedIndexChanged
        Dim listBox As ListBox = sender
        Dim indice As Integer = listBox.SelectedIndex
        Dim entrada As EntradaHistorial = Globales.historial(indice)
        fMain.txtInput.Text = entrada.input
        fMain.lvResultadosBusqueda.Items.Clear()
        fMain.PresentaBusqueda(entrada.resultadosBusqueda)
    End Sub
End Class