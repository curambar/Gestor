<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGestor
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.lvResultadosBusqueda = New System.Windows.Forms.ListView()
        Me.colTitulo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colAutor = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colISBN = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colEditorial = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colPVP = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colFecha = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colProyeccion = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.pnlInput = New System.Windows.Forms.Panel()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.txtInput = New System.Windows.Forms.TextBox()
        Me.pnlPresentacion = New System.Windows.Forms.Panel()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.lblID = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.pnlAyuda = New System.Windows.Forms.Panel()
        Me.pnlHistorial = New System.Windows.Forms.Panel()
        Me.lvHistorial = New System.Windows.Forms.ListView()
        Me.cHora = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cBusqueda = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.pnlInput.SuspendLayout()
        Me.pnlPresentacion.SuspendLayout()
        Me.pnlHistorial.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(707, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'lvResultadosBusqueda
        '
        Me.lvResultadosBusqueda.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colTitulo, Me.colAutor, Me.colISBN, Me.colEditorial, Me.colPVP, Me.colFecha, Me.colProyeccion})
        Me.lvResultadosBusqueda.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.lvResultadosBusqueda.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.lvResultadosBusqueda.FullRowSelect = True
        Me.lvResultadosBusqueda.GridLines = True
        Me.lvResultadosBusqueda.Location = New System.Drawing.Point(6, 267)
        Me.lvResultadosBusqueda.Name = "lvResultadosBusqueda"
        Me.lvResultadosBusqueda.Size = New System.Drawing.Size(696, 200)
        Me.lvResultadosBusqueda.TabIndex = 16
        Me.lvResultadosBusqueda.UseCompatibleStateImageBehavior = False
        Me.lvResultadosBusqueda.View = System.Windows.Forms.View.Details
        '
        'colTitulo
        '
        Me.colTitulo.Text = "Título"
        Me.colTitulo.Width = 166
        '
        'colAutor
        '
        Me.colAutor.Text = "Autor"
        Me.colAutor.Width = 166
        '
        'colISBN
        '
        Me.colISBN.Text = "ISBN"
        Me.colISBN.Width = 100
        '
        'colEditorial
        '
        Me.colEditorial.Text = "Editorial"
        Me.colEditorial.Width = 90
        '
        'colPVP
        '
        Me.colPVP.Text = "PVP"
        Me.colPVP.Width = 54
        '
        'colFecha
        '
        Me.colFecha.Text = "Fecha"
        Me.colFecha.Width = 54
        '
        'colProyeccion
        '
        Me.colProyeccion.Text = "Proy"
        Me.colProyeccion.Width = 54
        '
        'pnlInput
        '
        Me.pnlInput.AutoSize = True
        Me.pnlInput.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlInput.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.pnlInput.Controls.Add(Me.btnBuscar)
        Me.pnlInput.Controls.Add(Me.txtInput)
        Me.pnlInput.Location = New System.Drawing.Point(6, 27)
        Me.pnlInput.Name = "pnlInput"
        Me.pnlInput.Size = New System.Drawing.Size(185, 31)
        Me.pnlInput.TabIndex = 17
        '
        'btnBuscar
        '
        Me.btnBuscar.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnBuscar.FlatAppearance.BorderSize = 2
        Me.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBuscar.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.btnBuscar.Location = New System.Drawing.Point(122, 3)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(60, 25)
        Me.btnBuscar.TabIndex = 17
        Me.btnBuscar.TabStop = False
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = False
        '
        'txtInput
        '
        Me.txtInput.Location = New System.Drawing.Point(7, 3)
        Me.txtInput.Name = "txtInput"
        Me.txtInput.Size = New System.Drawing.Size(109, 25)
        Me.txtInput.TabIndex = 1
        '
        'pnlPresentacion
        '
        Me.pnlPresentacion.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.pnlPresentacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlPresentacion.Controls.Add(Me.btnEliminar)
        Me.pnlPresentacion.Controls.Add(Me.lblID)
        Me.pnlPresentacion.Controls.Add(Me.btnCancel)
        Me.pnlPresentacion.Controls.Add(Me.btnSave)
        Me.pnlPresentacion.Location = New System.Drawing.Point(6, 64)
        Me.pnlPresentacion.Name = "pnlPresentacion"
        Me.pnlPresentacion.Size = New System.Drawing.Size(500, 197)
        Me.pnlPresentacion.TabIndex = 18
        Me.pnlPresentacion.Tag = "0"
        '
        'btnEliminar
        '
        Me.btnEliminar.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnEliminar.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!)
        Me.btnEliminar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnEliminar.Location = New System.Drawing.Point(394, 3)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(101, 25)
        Me.btnEliminar.TabIndex = 15
        Me.btnEliminar.TabStop = False
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = False
        '
        'lblID
        '
        Me.lblID.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!)
        Me.lblID.Location = New System.Drawing.Point(5, 167)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(59, 24)
        Me.lblID.TabIndex = 15
        Me.lblID.Text = "ID"
        Me.lblID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCancel.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!)
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCancel.Location = New System.Drawing.Point(394, 34)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(101, 25)
        Me.btnCancel.TabIndex = 16
        Me.btnCancel.TabStop = False
        Me.btnCancel.Text = "Borrar"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSave.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!)
        Me.btnSave.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSave.Location = New System.Drawing.Point(394, 65)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(101, 25)
        Me.btnSave.TabIndex = 9
        Me.btnSave.TabStop = False
        Me.btnSave.Text = "Guardar"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'pnlAyuda
        '
        Me.pnlAyuda.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlAyuda.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.pnlAyuda.Location = New System.Drawing.Point(194, 27)
        Me.pnlAyuda.Name = "pnlAyuda"
        Me.pnlAyuda.Size = New System.Drawing.Size(508, 31)
        Me.pnlAyuda.TabIndex = 19
        '
        'pnlHistorial
        '
        Me.pnlHistorial.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlHistorial.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.pnlHistorial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlHistorial.Controls.Add(Me.lvHistorial)
        Me.pnlHistorial.Location = New System.Drawing.Point(512, 64)
        Me.pnlHistorial.Name = "pnlHistorial"
        Me.pnlHistorial.Size = New System.Drawing.Size(190, 197)
        Me.pnlHistorial.TabIndex = 20
        '
        'lvHistorial
        '
        Me.lvHistorial.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.cHora, Me.cBusqueda})
        Me.lvHistorial.Location = New System.Drawing.Point(3, 3)
        Me.lvHistorial.Name = "lvHistorial"
        Me.lvHistorial.Size = New System.Drawing.Size(179, 188)
        Me.lvHistorial.TabIndex = 0
        Me.lvHistorial.UseCompatibleStateImageBehavior = False
        '
        'cHora
        '
        Me.cHora.Text = "Hora"
        '
        'cBusqueda
        '
        Me.cBusqueda.Text = "Búsqueda"
        Me.cBusqueda.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'frmGestor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(707, 461)
        Me.Controls.Add(Me.pnlHistorial)
        Me.Controls.Add(Me.pnlAyuda)
        Me.Controls.Add(Me.pnlPresentacion)
        Me.Controls.Add(Me.pnlInput)
        Me.Controls.Add(Me.lvResultadosBusqueda)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "frmGestor"
        Me.Text = "Gestor"
        Me.pnlInput.ResumeLayout(False)
        Me.pnlInput.PerformLayout()
        Me.pnlPresentacion.ResumeLayout(False)
        Me.pnlHistorial.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents lvResultadosBusqueda As ListView
    Friend WithEvents colTitulo As ColumnHeader
    Friend WithEvents colAutor As ColumnHeader
    Friend WithEvents colISBN As ColumnHeader
    Friend WithEvents colEditorial As ColumnHeader
    Friend WithEvents colPVP As ColumnHeader
    Friend WithEvents colFecha As ColumnHeader
    Friend WithEvents colProyeccion As ColumnHeader
    Friend WithEvents pnlInput As Panel
    Friend WithEvents btnBuscar As Button
    Friend WithEvents txtInput As TextBox
    Friend WithEvents pnlPresentacion As Panel
    Friend WithEvents btnEliminar As Button
    Friend WithEvents lblID As Label
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents pnlAyuda As Panel
    Friend WithEvents pnlHistorial As Panel
    Friend WithEvents lvHistorial As ListView
    Friend WithEvents cHora As ColumnHeader
    Friend WithEvents cBusqueda As ColumnHeader
End Class
