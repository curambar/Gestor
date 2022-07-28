<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fMain))
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
        Me.pnlProyectar = New System.Windows.Forms.Panel()
        Me.btnProyectar = New System.Windows.Forms.Button()
        Me.lblProy = New System.Windows.Forms.Label()
        Me.lblValor = New System.Windows.Forms.Label()
        Me.lblAno = New System.Windows.Forms.Label()
        Me.lblMes = New System.Windows.Forms.Label()
        Me.txtVlr = New System.Windows.Forms.TextBox()
        Me.txtAno = New System.Windows.Forms.TextBox()
        Me.txtMes = New System.Windows.Forms.TextBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.pnlPresentacion = New System.Windows.Forms.Panel()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.lblID = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.txtFecha = New System.Windows.Forms.TextBox()
        Me.txtSello = New System.Windows.Forms.TextBox()
        Me.txtEditorial = New System.Windows.Forms.TextBox()
        Me.txtTema = New System.Windows.Forms.TextBox()
        Me.txtISBN = New System.Windows.Forms.TextBox()
        Me.txtPVP = New System.Windows.Forms.TextBox()
        Me.txtAutor = New System.Windows.Forms.TextBox()
        Me.txtTitulo = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlInput.SuspendLayout()
        Me.pnlProyectar.SuspendLayout()
        Me.pnlPresentacion.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lvResultadosBusqueda
        '
        Me.lvResultadosBusqueda.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colTitulo, Me.colAutor, Me.colISBN, Me.colEditorial, Me.colPVP, Me.colFecha, Me.colProyeccion})
        Me.lvResultadosBusqueda.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.lvResultadosBusqueda.FullRowSelect = True
        Me.lvResultadosBusqueda.GridLines = True
        Me.lvResultadosBusqueda.Location = New System.Drawing.Point(11, 173)
        Me.lvResultadosBusqueda.Name = "lvResultadosBusqueda"
        Me.lvResultadosBusqueda.Size = New System.Drawing.Size(773, 183)
        Me.lvResultadosBusqueda.TabIndex = 15
        Me.lvResultadosBusqueda.UseCompatibleStateImageBehavior = False
        Me.lvResultadosBusqueda.View = System.Windows.Forms.View.Details
        '
        'colTitulo
        '
        Me.colTitulo.Text = "Título"
        Me.colTitulo.Width = 185
        '
        'colAutor
        '
        Me.colAutor.Text = "Autor"
        Me.colAutor.Width = 185
        '
        'colISBN
        '
        Me.colISBN.Text = "ISBN"
        Me.colISBN.Width = 110
        '
        'colEditorial
        '
        Me.colEditorial.Text = "Editorial"
        Me.colEditorial.Width = 100
        '
        'colPVP
        '
        Me.colPVP.Text = "PVP"
        '
        'colFecha
        '
        Me.colFecha.Text = "Fecha"
        '
        'colProyeccion
        '
        Me.colProyeccion.Text = "Proy"
        '
        'pnlInput
        '
        Me.pnlInput.BackColor = System.Drawing.Color.DimGray
        Me.pnlInput.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlInput.Controls.Add(Me.btnBuscar)
        Me.pnlInput.Controls.Add(Me.txtInput)
        Me.pnlInput.Location = New System.Drawing.Point(6, 12)
        Me.pnlInput.Name = "pnlInput"
        Me.pnlInput.Size = New System.Drawing.Size(213, 50)
        Me.pnlInput.TabIndex = 4
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Location = New System.Drawing.Point(144, 11)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(60, 24)
        Me.btnBuscar.TabIndex = 17
        Me.btnBuscar.TabStop = False
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'txtInput
        '
        Me.txtInput.Location = New System.Drawing.Point(7, 14)
        Me.txtInput.Name = "txtInput"
        Me.txtInput.Size = New System.Drawing.Size(131, 20)
        Me.txtInput.TabIndex = 1
        '
        'pnlProyectar
        '
        Me.pnlProyectar.BackColor = System.Drawing.Color.DimGray
        Me.pnlProyectar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlProyectar.Controls.Add(Me.btnProyectar)
        Me.pnlProyectar.Controls.Add(Me.lblProy)
        Me.pnlProyectar.Controls.Add(Me.lblValor)
        Me.pnlProyectar.Controls.Add(Me.lblAno)
        Me.pnlProyectar.Controls.Add(Me.lblMes)
        Me.pnlProyectar.Controls.Add(Me.txtVlr)
        Me.pnlProyectar.Controls.Add(Me.txtAno)
        Me.pnlProyectar.Controls.Add(Me.txtMes)
        Me.pnlProyectar.Location = New System.Drawing.Point(6, 68)
        Me.pnlProyectar.Name = "pnlProyectar"
        Me.pnlProyectar.Size = New System.Drawing.Size(213, 99)
        Me.pnlProyectar.TabIndex = 5
        '
        'btnProyectar
        '
        Me.btnProyectar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProyectar.Location = New System.Drawing.Point(134, 11)
        Me.btnProyectar.Name = "btnProyectar"
        Me.btnProyectar.Size = New System.Drawing.Size(60, 24)
        Me.btnProyectar.TabIndex = 33
        Me.btnProyectar.TabStop = False
        Me.btnProyectar.Text = "Proyectar"
        Me.btnProyectar.UseVisualStyleBackColor = True
        '
        'lblProy
        '
        Me.lblProy.BackColor = System.Drawing.SystemColors.Control
        Me.lblProy.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProy.ForeColor = System.Drawing.Color.Black
        Me.lblProy.Location = New System.Drawing.Point(134, 38)
        Me.lblProy.Name = "lblProy"
        Me.lblProy.Size = New System.Drawing.Size(60, 42)
        Me.lblProy.TabIndex = 32
        Me.lblProy.Text = "-"
        Me.lblProy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblValor
        '
        Me.lblValor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValor.ForeColor = System.Drawing.Color.Silver
        Me.lblValor.Location = New System.Drawing.Point(29, 63)
        Me.lblValor.Name = "lblValor"
        Me.lblValor.Size = New System.Drawing.Size(36, 13)
        Me.lblValor.TabIndex = 31
        Me.lblValor.Text = "Valor"
        '
        'lblAno
        '
        Me.lblAno.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAno.ForeColor = System.Drawing.Color.Silver
        Me.lblAno.Location = New System.Drawing.Point(29, 39)
        Me.lblAno.Name = "lblAno"
        Me.lblAno.Size = New System.Drawing.Size(36, 13)
        Me.lblAno.TabIndex = 30
        Me.lblAno.Text = "Año"
        '
        'lblMes
        '
        Me.lblMes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMes.ForeColor = System.Drawing.Color.Silver
        Me.lblMes.Location = New System.Drawing.Point(29, 15)
        Me.lblMes.Name = "lblMes"
        Me.lblMes.Size = New System.Drawing.Size(36, 13)
        Me.lblMes.TabIndex = 29
        Me.lblMes.Text = "Mes"
        '
        'txtVlr
        '
        Me.txtVlr.Location = New System.Drawing.Point(68, 60)
        Me.txtVlr.Name = "txtVlr"
        Me.txtVlr.Size = New System.Drawing.Size(60, 20)
        Me.txtVlr.TabIndex = 4
        '
        'txtAno
        '
        Me.txtAno.Location = New System.Drawing.Point(68, 36)
        Me.txtAno.Name = "txtAno"
        Me.txtAno.Size = New System.Drawing.Size(60, 20)
        Me.txtAno.TabIndex = 3
        '
        'txtMes
        '
        Me.txtMes.Location = New System.Drawing.Point(68, 12)
        Me.txtMes.Name = "txtMes"
        Me.txtMes.Size = New System.Drawing.Size(60, 20)
        Me.txtMes.TabIndex = 2
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSave.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!)
        Me.btnSave.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSave.Location = New System.Drawing.Point(267, 127)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(101, 25)
        Me.btnSave.TabIndex = 9
        Me.btnSave.TabStop = False
        Me.btnSave.Text = "Guardar"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'pnlPresentacion
        '
        Me.pnlPresentacion.BackColor = System.Drawing.Color.DimGray
        Me.pnlPresentacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlPresentacion.Controls.Add(Me.btnEliminar)
        Me.pnlPresentacion.Controls.Add(Me.lblID)
        Me.pnlPresentacion.Controls.Add(Me.btnCancel)
        Me.pnlPresentacion.Controls.Add(Me.btnSave)
        Me.pnlPresentacion.Controls.Add(Me.txtFecha)
        Me.pnlPresentacion.Controls.Add(Me.txtSello)
        Me.pnlPresentacion.Controls.Add(Me.txtEditorial)
        Me.pnlPresentacion.Controls.Add(Me.txtTema)
        Me.pnlPresentacion.Controls.Add(Me.txtISBN)
        Me.pnlPresentacion.Controls.Add(Me.txtPVP)
        Me.pnlPresentacion.Controls.Add(Me.txtAutor)
        Me.pnlPresentacion.Controls.Add(Me.txtTitulo)
        Me.pnlPresentacion.Location = New System.Drawing.Point(402, 12)
        Me.pnlPresentacion.Name = "pnlPresentacion"
        Me.pnlPresentacion.Size = New System.Drawing.Size(376, 155)
        Me.pnlPresentacion.TabIndex = 0
        Me.pnlPresentacion.Tag = "0"
        '
        'btnEliminar
        '
        Me.btnEliminar.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnEliminar.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!)
        Me.btnEliminar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnEliminar.Location = New System.Drawing.Point(55, 127)
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
        Me.lblID.Location = New System.Drawing.Point(3, 127)
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
        Me.btnCancel.Location = New System.Drawing.Point(160, 127)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(101, 25)
        Me.btnCancel.TabIndex = 16
        Me.btnCancel.TabStop = False
        Me.btnCancel.Text = "Borrar"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'txtFecha
        '
        Me.txtFecha.BackColor = System.Drawing.Color.LightGray
        Me.txtFecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFecha.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!)
        Me.txtFecha.Location = New System.Drawing.Point(130, 51)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Size = New System.Drawing.Size(69, 25)
        Me.txtFecha.TabIndex = 12
        Me.txtFecha.TabStop = False
        Me.txtFecha.Tag = "5"
        Me.txtFecha.Text = "Fecha"
        Me.txtFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtFecha.Visible = False
        '
        'txtSello
        '
        Me.txtSello.BackColor = System.Drawing.Color.LightGray
        Me.txtSello.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSello.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!)
        Me.txtSello.Location = New System.Drawing.Point(170, 75)
        Me.txtSello.Name = "txtSello"
        Me.txtSello.Size = New System.Drawing.Size(198, 25)
        Me.txtSello.TabIndex = 13
        Me.txtSello.Tag = "7"
        Me.txtSello.Text = "Sello"
        Me.txtSello.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtSello.Visible = False
        '
        'txtEditorial
        '
        Me.txtEditorial.BackColor = System.Drawing.Color.LightGray
        Me.txtEditorial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEditorial.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!)
        Me.txtEditorial.Location = New System.Drawing.Point(3, 75)
        Me.txtEditorial.Name = "txtEditorial"
        Me.txtEditorial.Size = New System.Drawing.Size(168, 25)
        Me.txtEditorial.TabIndex = 12
        Me.txtEditorial.Tag = "3"
        Me.txtEditorial.Text = "Editorial"
        Me.txtEditorial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtEditorial.Visible = False
        '
        'txtTema
        '
        Me.txtTema.BackColor = System.Drawing.Color.LightGray
        Me.txtTema.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTema.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!)
        Me.txtTema.Location = New System.Drawing.Point(3, 99)
        Me.txtTema.Name = "txtTema"
        Me.txtTema.Size = New System.Drawing.Size(365, 25)
        Me.txtTema.TabIndex = 14
        Me.txtTema.Tag = "8"
        Me.txtTema.Text = "Tema"
        Me.txtTema.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtTema.Visible = False
        '
        'txtISBN
        '
        Me.txtISBN.BackColor = System.Drawing.Color.LightGray
        Me.txtISBN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtISBN.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!)
        Me.txtISBN.Location = New System.Drawing.Point(253, 51)
        Me.txtISBN.Name = "txtISBN"
        Me.txtISBN.Size = New System.Drawing.Size(115, 25)
        Me.txtISBN.TabIndex = 11
        Me.txtISBN.Tag = "2"
        Me.txtISBN.Text = "ISBN"
        Me.txtISBN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtISBN.Visible = False
        '
        'txtPVP
        '
        Me.txtPVP.BackColor = System.Drawing.Color.LightGray
        Me.txtPVP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPVP.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!)
        Me.txtPVP.Location = New System.Drawing.Point(3, 51)
        Me.txtPVP.Name = "txtPVP"
        Me.txtPVP.Size = New System.Drawing.Size(69, 25)
        Me.txtPVP.TabIndex = 10
        Me.txtPVP.Tag = "4"
        Me.txtPVP.Text = "PVP"
        Me.txtPVP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtPVP.Visible = False
        '
        'txtAutor
        '
        Me.txtAutor.BackColor = System.Drawing.Color.LightGray
        Me.txtAutor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAutor.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!)
        Me.txtAutor.Location = New System.Drawing.Point(3, 27)
        Me.txtAutor.Name = "txtAutor"
        Me.txtAutor.Size = New System.Drawing.Size(365, 25)
        Me.txtAutor.TabIndex = 9
        Me.txtAutor.Tag = "1"
        Me.txtAutor.Text = "Autor"
        Me.txtAutor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtAutor.Visible = False
        '
        'txtTitulo
        '
        Me.txtTitulo.BackColor = System.Drawing.Color.LightGray
        Me.txtTitulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTitulo.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!)
        Me.txtTitulo.Location = New System.Drawing.Point(3, 3)
        Me.txtTitulo.Name = "txtTitulo"
        Me.txtTitulo.Size = New System.Drawing.Size(365, 25)
        Me.txtTitulo.TabIndex = 8
        Me.txtTitulo.Tag = "0"
        Me.txtTitulo.Text = "Título"
        Me.txtTitulo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtTitulo.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(225, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(171, 155)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 16
        Me.PictureBox1.TabStop = False
        '
        'fMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkGray
        Me.ClientSize = New System.Drawing.Size(784, 361)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.pnlPresentacion)
        Me.Controls.Add(Me.pnlProyectar)
        Me.Controls.Add(Me.pnlInput)
        Me.Controls.Add(Me.lvResultadosBusqueda)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "fMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "Off"
        Me.Text = "Buscador"
        Me.pnlInput.ResumeLayout(False)
        Me.pnlInput.PerformLayout()
        Me.pnlProyectar.ResumeLayout(False)
        Me.pnlProyectar.PerformLayout()
        Me.pnlPresentacion.ResumeLayout(False)
        Me.pnlPresentacion.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lvResultadosBusqueda As System.Windows.Forms.ListView
    Friend WithEvents pnlInput As System.Windows.Forms.Panel
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents txtInput As System.Windows.Forms.TextBox
    Friend WithEvents pnlProyectar As System.Windows.Forms.Panel
    Friend WithEvents btnProyectar As System.Windows.Forms.Button
    Friend WithEvents lblProy As System.Windows.Forms.Label
    Friend WithEvents lblValor As System.Windows.Forms.Label
    Friend WithEvents lblAno As System.Windows.Forms.Label
    Friend WithEvents lblMes As System.Windows.Forms.Label
    Friend WithEvents txtVlr As System.Windows.Forms.TextBox
    Friend WithEvents txtAno As System.Windows.Forms.TextBox
    Friend WithEvents txtMes As System.Windows.Forms.TextBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents pnlPresentacion As System.Windows.Forms.Panel
    Friend WithEvents txtSello As System.Windows.Forms.TextBox
    Friend WithEvents txtEditorial As System.Windows.Forms.TextBox
    Friend WithEvents txtTema As System.Windows.Forms.TextBox
    Friend WithEvents txtISBN As System.Windows.Forms.TextBox
    Friend WithEvents txtPVP As System.Windows.Forms.TextBox
    Friend WithEvents txtAutor As System.Windows.Forms.TextBox
    Friend WithEvents txtTitulo As System.Windows.Forms.TextBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents txtFecha As System.Windows.Forms.TextBox
    Friend WithEvents colTitulo As System.Windows.Forms.ColumnHeader
    Friend WithEvents colAutor As System.Windows.Forms.ColumnHeader
    Friend WithEvents colISBN As System.Windows.Forms.ColumnHeader
    Friend WithEvents colEditorial As System.Windows.Forms.ColumnHeader
    Friend WithEvents colPVP As System.Windows.Forms.ColumnHeader
    Friend WithEvents colFecha As System.Windows.Forms.ColumnHeader
    Friend WithEvents colProyeccion As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblID As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btnEliminar As System.Windows.Forms.Button

End Class
