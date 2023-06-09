<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class fMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
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
        Me.pnlDetalles = New System.Windows.Forms.Panel()
        Me.txtDetalles7 = New System.Windows.Forms.TextBox()
        Me.txtDetalles6 = New System.Windows.Forms.TextBox()
        Me.txtDetalles5 = New System.Windows.Forms.TextBox()
        Me.txtDetalles4 = New System.Windows.Forms.TextBox()
        Me.txtDetalles3 = New System.Windows.Forms.TextBox()
        Me.txtDetalles2 = New System.Windows.Forms.TextBox()
        Me.txtDetalles1 = New System.Windows.Forms.TextBox()
        Me.txtDetalles0 = New System.Windows.Forms.TextBox()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.lblID = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlBotones = New System.Windows.Forms.Panel()
        Me.btnActualizar = New System.Windows.Forms.Button()
        Me.pBar1 = New System.Windows.Forms.ProgressBar()
        Me.pnlInput.SuspendLayout()
        Me.pnlProyectar.SuspendLayout()
        Me.pnlDetalles.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBotones.SuspendLayout()
        Me.SuspendLayout()
        '
        'lvResultadosBusqueda
        '
        Me.lvResultadosBusqueda.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colTitulo, Me.colAutor, Me.colISBN, Me.colEditorial, Me.colPVP, Me.colFecha, Me.colProyeccion})
        Me.lvResultadosBusqueda.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.lvResultadosBusqueda.FullRowSelect = True
        Me.lvResultadosBusqueda.GridLines = True
        Me.lvResultadosBusqueda.Location = New System.Drawing.Point(6, 169)
        Me.lvResultadosBusqueda.Name = "lvResultadosBusqueda"
        Me.lvResultadosBusqueda.Size = New System.Drawing.Size(773, 206)
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
        Me.pnlInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlInput.Controls.Add(Me.btnBuscar)
        Me.pnlInput.Controls.Add(Me.txtInput)
        Me.pnlInput.Location = New System.Drawing.Point(6, 8)
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
        Me.pnlProyectar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlProyectar.Controls.Add(Me.btnProyectar)
        Me.pnlProyectar.Controls.Add(Me.lblProy)
        Me.pnlProyectar.Controls.Add(Me.lblValor)
        Me.pnlProyectar.Controls.Add(Me.lblAno)
        Me.pnlProyectar.Controls.Add(Me.lblMes)
        Me.pnlProyectar.Controls.Add(Me.txtVlr)
        Me.pnlProyectar.Controls.Add(Me.txtAno)
        Me.pnlProyectar.Controls.Add(Me.txtMes)
        Me.pnlProyectar.Location = New System.Drawing.Point(6, 64)
        Me.pnlProyectar.Name = "pnlProyectar"
        Me.pnlProyectar.Size = New System.Drawing.Size(213, 99)
        Me.pnlProyectar.TabIndex = 5
        '
        'btnProyectar
        '
        Me.btnProyectar.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!)
        Me.btnProyectar.Location = New System.Drawing.Point(133, 11)
        Me.btnProyectar.Margin = New System.Windows.Forms.Padding(0)
        Me.btnProyectar.Name = "btnProyectar"
        Me.btnProyectar.Size = New System.Drawing.Size(60, 32)
        Me.btnProyectar.TabIndex = 33
        Me.btnProyectar.TabStop = False
        Me.btnProyectar.Text = "Proy"
        Me.btnProyectar.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnProyectar.UseVisualStyleBackColor = True
        '
        'lblProy
        '
        Me.lblProy.BackColor = System.Drawing.SystemColors.Control
        Me.lblProy.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProy.ForeColor = System.Drawing.Color.Black
        Me.lblProy.Location = New System.Drawing.Point(134, 46)
        Me.lblProy.Name = "lblProy"
        Me.lblProy.Size = New System.Drawing.Size(57, 33)
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
        'pnlDetalles
        '
        Me.pnlDetalles.BackColor = System.Drawing.Color.DimGray
        Me.pnlDetalles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlDetalles.Controls.Add(Me.txtDetalles7)
        Me.pnlDetalles.Controls.Add(Me.txtDetalles6)
        Me.pnlDetalles.Controls.Add(Me.txtDetalles5)
        Me.pnlDetalles.Controls.Add(Me.txtDetalles4)
        Me.pnlDetalles.Controls.Add(Me.txtDetalles3)
        Me.pnlDetalles.Controls.Add(Me.txtDetalles2)
        Me.pnlDetalles.Controls.Add(Me.txtDetalles1)
        Me.pnlDetalles.Controls.Add(Me.txtDetalles0)
        Me.pnlDetalles.Controls.Add(Me.btnEliminar)
        Me.pnlDetalles.Controls.Add(Me.lblID)
        Me.pnlDetalles.Controls.Add(Me.btnCancel)
        Me.pnlDetalles.Controls.Add(Me.btnSave)
        Me.pnlDetalles.Location = New System.Drawing.Point(402, 8)
        Me.pnlDetalles.Name = "pnlDetalles"
        Me.pnlDetalles.Size = New System.Drawing.Size(376, 155)
        Me.pnlDetalles.TabIndex = 0
        Me.pnlDetalles.Tag = "0"
        '
        'txtDetalles7
        '
        Me.txtDetalles7.BackColor = System.Drawing.Color.LightGray
        Me.txtDetalles7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDetalles7.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!)
        Me.txtDetalles7.Location = New System.Drawing.Point(3, 99)
        Me.txtDetalles7.Name = "txtDetalles7"
        Me.txtDetalles7.Size = New System.Drawing.Size(365, 25)
        Me.txtDetalles7.TabIndex = 7
        Me.txtDetalles7.Tag = "7"
        Me.txtDetalles7.Text = "Tema"
        Me.txtDetalles7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtDetalles6
        '
        Me.txtDetalles6.BackColor = System.Drawing.Color.LightGray
        Me.txtDetalles6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDetalles6.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!)
        Me.txtDetalles6.Location = New System.Drawing.Point(170, 75)
        Me.txtDetalles6.Name = "txtDetalles6"
        Me.txtDetalles6.Size = New System.Drawing.Size(198, 25)
        Me.txtDetalles6.TabIndex = 6
        Me.txtDetalles6.Tag = "6"
        Me.txtDetalles6.Text = "Sello"
        Me.txtDetalles6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtDetalles5
        '
        Me.txtDetalles5.BackColor = System.Drawing.Color.LightGray
        Me.txtDetalles5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDetalles5.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!)
        Me.txtDetalles5.Location = New System.Drawing.Point(3, 75)
        Me.txtDetalles5.Name = "txtDetalles5"
        Me.txtDetalles5.Size = New System.Drawing.Size(168, 25)
        Me.txtDetalles5.TabIndex = 5
        Me.txtDetalles5.Tag = "5"
        Me.txtDetalles5.Text = "Editorial"
        Me.txtDetalles5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtDetalles4
        '
        Me.txtDetalles4.BackColor = System.Drawing.Color.LightGray
        Me.txtDetalles4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDetalles4.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!)
        Me.txtDetalles4.Location = New System.Drawing.Point(253, 51)
        Me.txtDetalles4.Name = "txtDetalles4"
        Me.txtDetalles4.Size = New System.Drawing.Size(115, 25)
        Me.txtDetalles4.TabIndex = 4
        Me.txtDetalles4.Tag = "4"
        Me.txtDetalles4.Text = "ISBN"
        Me.txtDetalles4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtDetalles3
        '
        Me.txtDetalles3.BackColor = System.Drawing.Color.LightGray
        Me.txtDetalles3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDetalles3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!)
        Me.txtDetalles3.Location = New System.Drawing.Point(130, 51)
        Me.txtDetalles3.Name = "txtDetalles3"
        Me.txtDetalles3.Size = New System.Drawing.Size(69, 25)
        Me.txtDetalles3.TabIndex = 3
        Me.txtDetalles3.TabStop = False
        Me.txtDetalles3.Tag = "3"
        Me.txtDetalles3.Text = "Fecha"
        Me.txtDetalles3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtDetalles2
        '
        Me.txtDetalles2.BackColor = System.Drawing.Color.LightGray
        Me.txtDetalles2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDetalles2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!)
        Me.txtDetalles2.Location = New System.Drawing.Point(3, 51)
        Me.txtDetalles2.Name = "txtDetalles2"
        Me.txtDetalles2.Size = New System.Drawing.Size(69, 25)
        Me.txtDetalles2.TabIndex = 2
        Me.txtDetalles2.Tag = "2"
        Me.txtDetalles2.Text = "PVP"
        Me.txtDetalles2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtDetalles1
        '
        Me.txtDetalles1.BackColor = System.Drawing.Color.LightGray
        Me.txtDetalles1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDetalles1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!)
        Me.txtDetalles1.Location = New System.Drawing.Point(3, 27)
        Me.txtDetalles1.Name = "txtDetalles1"
        Me.txtDetalles1.Size = New System.Drawing.Size(365, 25)
        Me.txtDetalles1.TabIndex = 1
        Me.txtDetalles1.Tag = "1"
        Me.txtDetalles1.Text = "Autor"
        Me.txtDetalles1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtDetalles0
        '
        Me.txtDetalles0.BackColor = System.Drawing.Color.LightGray
        Me.txtDetalles0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDetalles0.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!)
        Me.txtDetalles0.Location = New System.Drawing.Point(3, 3)
        Me.txtDetalles0.Name = "txtDetalles0"
        Me.txtDetalles0.Size = New System.Drawing.Size(365, 25)
        Me.txtDetalles0.TabIndex = 0
        Me.txtDetalles0.Tag = "0"
        Me.txtDetalles0.Text = "Título"
        Me.txtDetalles0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
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
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(225, 64)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(171, 99)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 16
        Me.PictureBox1.TabStop = False
        '
        'pnlBotones
        '
        Me.pnlBotones.BackColor = System.Drawing.Color.DimGray
        Me.pnlBotones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlBotones.Controls.Add(Me.btnActualizar)
        Me.pnlBotones.Location = New System.Drawing.Point(225, 8)
        Me.pnlBotones.Name = "pnlBotones"
        Me.pnlBotones.Size = New System.Drawing.Size(171, 50)
        Me.pnlBotones.TabIndex = 17
        '
        'btnActualizar
        '
        Me.btnActualizar.AutoSize = True
        Me.btnActualizar.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!)
        Me.btnActualizar.Location = New System.Drawing.Point(3, 11)
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(163, 27)
        Me.btnActualizar.TabIndex = 0
        Me.btnActualizar.Text = "Actualizar Precios"
        Me.btnActualizar.UseVisualStyleBackColor = True
        '
        'pBar1
        '
        Me.pBar1.Location = New System.Drawing.Point(228, 66)
        Me.pBar1.Minimum = 1
        Me.pBar1.Name = "pBar1"
        Me.pBar1.Size = New System.Drawing.Size(166, 95)
        Me.pBar1.Step = 1
        Me.pBar1.TabIndex = 18
        Me.pBar1.Value = 1
        Me.pBar1.Visible = False
        '
        'fMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkGray
        Me.ClientSize = New System.Drawing.Size(784, 397)
        Me.Controls.Add(Me.pBar1)
        Me.Controls.Add(Me.pnlBotones)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.pnlDetalles)
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
        Me.pnlDetalles.ResumeLayout(False)
        Me.pnlDetalles.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBotones.ResumeLayout(False)
        Me.pnlBotones.PerformLayout()
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
    Friend WithEvents pnlDetalles As System.Windows.Forms.Panel
    Friend WithEvents btnCancel As System.Windows.Forms.Button
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
    Friend WithEvents txtDetalles0 As TextBox
    Friend WithEvents txtDetalles1 As TextBox
    Friend WithEvents txtDetalles2 As TextBox
    Friend WithEvents txtDetalles3 As TextBox
    Friend WithEvents txtDetalles4 As TextBox
    Friend WithEvents txtDetalles5 As TextBox
    Friend WithEvents txtDetalles6 As TextBox
    Friend WithEvents txtDetalles7 As TextBox
    Friend WithEvents pnlBotones As System.Windows.Forms.Panel
    Friend WithEvents btnActualizar As System.Windows.Forms.Button
    Friend WithEvents pBar1 As ProgressBar
End Class
