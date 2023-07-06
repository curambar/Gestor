<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
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
        Me.lvResultadosBusqueda = New System.Windows.Forms.ListView()
        Me.colTitulo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colAutor = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colISBN = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colEditorial = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colPVP = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colFecha = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colProyeccion = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.pnlInput = New System.Windows.Forms.Panel()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.tbInput = New System.Windows.Forms.TextBox()
        Me.pnlInterest = New System.Windows.Forms.Panel()
        Me.btnApplyInterest = New System.Windows.Forms.Button()
        Me.lblFinalValue = New System.Windows.Forms.Label()
        Me.lblValue = New System.Windows.Forms.Label()
        Me.lblYear = New System.Windows.Forms.Label()
        Me.lblMonth = New System.Windows.Forms.Label()
        Me.tbInitValue = New System.Windows.Forms.TextBox()
        Me.tbYear = New System.Windows.Forms.TextBox()
        Me.tbMonth = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlUpdate = New System.Windows.Forms.Panel()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.pBar1 = New System.Windows.Forms.ProgressBar()
        Me.pnlInfo = New System.Windows.Forms.Panel()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.tbInfo9 = New System.Windows.Forms.TextBox()
        Me.tbInfo8 = New System.Windows.Forms.TextBox()
        Me.tbInfo7 = New System.Windows.Forms.TextBox()
        Me.tbInfo6 = New System.Windows.Forms.TextBox()
        Me.tbInfo5 = New System.Windows.Forms.TextBox()
        Me.tbInfo4 = New System.Windows.Forms.TextBox()
        Me.tbInfo3 = New System.Windows.Forms.TextBox()
        Me.tbInfo2 = New System.Windows.Forms.TextBox()
        Me.tbInfo1 = New System.Windows.Forms.TextBox()
        Me.tbInfo0 = New System.Windows.Forms.TextBox()
        Me.btnSell = New System.Windows.Forms.Button()
        Me.btnErase = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.pnlInput.SuspendLayout()
        Me.pnlInterest.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlUpdate.SuspendLayout()
        Me.pnlInfo.SuspendLayout()
        Me.SuspendLayout()
        '
        'lvResultadosBusqueda
        '
        Me.lvResultadosBusqueda.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lvResultadosBusqueda.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colTitulo, Me.colAutor, Me.colISBN, Me.colEditorial, Me.colPVP, Me.colFecha, Me.colProyeccion})
        Me.lvResultadosBusqueda.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.lvResultadosBusqueda.ForeColor = System.Drawing.Color.White
        Me.lvResultadosBusqueda.FullRowSelect = True
        Me.lvResultadosBusqueda.GridLines = True
        Me.lvResultadosBusqueda.HideSelection = False
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
        Me.pnlInput.Controls.Add(Me.btnSearch)
        Me.pnlInput.Controls.Add(Me.tbInput)
        Me.pnlInput.Location = New System.Drawing.Point(6, 8)
        Me.pnlInput.Name = "pnlInput"
        Me.pnlInput.Size = New System.Drawing.Size(213, 50)
        Me.pnlInput.TabIndex = 4
        '
        'btnSearch
        '
        Me.btnSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(144, 11)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(60, 24)
        Me.btnSearch.TabIndex = 17
        Me.btnSearch.TabStop = False
        Me.btnSearch.Text = "Buscar"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'tbInput
        '
        Me.tbInput.Location = New System.Drawing.Point(7, 14)
        Me.tbInput.Name = "tbInput"
        Me.tbInput.Size = New System.Drawing.Size(131, 20)
        Me.tbInput.TabIndex = 1
        '
        'pnlInterest
        '
        Me.pnlInterest.BackColor = System.Drawing.Color.DimGray
        Me.pnlInterest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlInterest.Controls.Add(Me.btnApplyInterest)
        Me.pnlInterest.Controls.Add(Me.lblFinalValue)
        Me.pnlInterest.Controls.Add(Me.lblValue)
        Me.pnlInterest.Controls.Add(Me.lblYear)
        Me.pnlInterest.Controls.Add(Me.lblMonth)
        Me.pnlInterest.Controls.Add(Me.tbInitValue)
        Me.pnlInterest.Controls.Add(Me.tbYear)
        Me.pnlInterest.Controls.Add(Me.tbMonth)
        Me.pnlInterest.Location = New System.Drawing.Point(6, 64)
        Me.pnlInterest.Name = "pnlInterest"
        Me.pnlInterest.Size = New System.Drawing.Size(213, 99)
        Me.pnlInterest.TabIndex = 5
        '
        'btnApplyInterest
        '
        Me.btnApplyInterest.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!)
        Me.btnApplyInterest.Location = New System.Drawing.Point(133, 11)
        Me.btnApplyInterest.Margin = New System.Windows.Forms.Padding(0)
        Me.btnApplyInterest.Name = "btnApplyInterest"
        Me.btnApplyInterest.Size = New System.Drawing.Size(60, 32)
        Me.btnApplyInterest.TabIndex = 33
        Me.btnApplyInterest.TabStop = False
        Me.btnApplyInterest.Text = "Proy"
        Me.btnApplyInterest.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnApplyInterest.UseVisualStyleBackColor = True
        '
        'lblFinalValue
        '
        Me.lblFinalValue.BackColor = System.Drawing.SystemColors.Control
        Me.lblFinalValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFinalValue.ForeColor = System.Drawing.Color.Black
        Me.lblFinalValue.Location = New System.Drawing.Point(134, 46)
        Me.lblFinalValue.Name = "lblFinalValue"
        Me.lblFinalValue.Size = New System.Drawing.Size(57, 33)
        Me.lblFinalValue.TabIndex = 32
        Me.lblFinalValue.Text = "-"
        Me.lblFinalValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblValue
        '
        Me.lblValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValue.ForeColor = System.Drawing.Color.Silver
        Me.lblValue.Location = New System.Drawing.Point(29, 63)
        Me.lblValue.Name = "lblValue"
        Me.lblValue.Size = New System.Drawing.Size(36, 13)
        Me.lblValue.TabIndex = 31
        Me.lblValue.Text = "Valor"
        '
        'lblYear
        '
        Me.lblYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYear.ForeColor = System.Drawing.Color.Silver
        Me.lblYear.Location = New System.Drawing.Point(29, 39)
        Me.lblYear.Name = "lblYear"
        Me.lblYear.Size = New System.Drawing.Size(36, 13)
        Me.lblYear.TabIndex = 30
        Me.lblYear.Text = "Año"
        '
        'lblMonth
        '
        Me.lblMonth.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonth.ForeColor = System.Drawing.Color.Silver
        Me.lblMonth.Location = New System.Drawing.Point(29, 15)
        Me.lblMonth.Name = "lblMonth"
        Me.lblMonth.Size = New System.Drawing.Size(36, 13)
        Me.lblMonth.TabIndex = 29
        Me.lblMonth.Text = "Mes"
        '
        'tbInitValue
        '
        Me.tbInitValue.Location = New System.Drawing.Point(68, 60)
        Me.tbInitValue.Name = "tbInitValue"
        Me.tbInitValue.Size = New System.Drawing.Size(60, 20)
        Me.tbInitValue.TabIndex = 4
        '
        'tbYear
        '
        Me.tbYear.Location = New System.Drawing.Point(68, 36)
        Me.tbYear.Name = "tbYear"
        Me.tbYear.Size = New System.Drawing.Size(60, 20)
        Me.tbYear.TabIndex = 3
        '
        'tbMonth
        '
        Me.tbMonth.Location = New System.Drawing.Point(68, 12)
        Me.tbMonth.Name = "tbMonth"
        Me.tbMonth.Size = New System.Drawing.Size(60, 20)
        Me.tbMonth.TabIndex = 2
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.PictureBox1.Image = Global.Buscador.My.Resources.Resources.Uppsala2
        Me.PictureBox1.Location = New System.Drawing.Point(225, 64)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(171, 99)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 16
        Me.PictureBox1.TabStop = False
        '
        'pnlUpdate
        '
        Me.pnlUpdate.BackColor = System.Drawing.Color.DimGray
        Me.pnlUpdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlUpdate.Controls.Add(Me.btnUpdate)
        Me.pnlUpdate.Location = New System.Drawing.Point(225, 8)
        Me.pnlUpdate.Name = "pnlUpdate"
        Me.pnlUpdate.Size = New System.Drawing.Size(171, 50)
        Me.pnlUpdate.TabIndex = 17
        '
        'btnUpdate
        '
        Me.btnUpdate.AutoSize = True
        Me.btnUpdate.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!)
        Me.btnUpdate.Location = New System.Drawing.Point(3, 11)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(163, 27)
        Me.btnUpdate.TabIndex = 0
        Me.btnUpdate.Text = "Actualizar Precios"
        Me.btnUpdate.UseVisualStyleBackColor = True
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
        'pnlInfo
        '
        Me.pnlInfo.BackColor = System.Drawing.Color.Black
        Me.pnlInfo.Controls.Add(Me.tbInfo9)
        Me.pnlInfo.Controls.Add(Me.tbInfo8)
        Me.pnlInfo.Controls.Add(Me.tbInfo7)
        Me.pnlInfo.Controls.Add(Me.tbInfo6)
        Me.pnlInfo.Controls.Add(Me.tbInfo5)
        Me.pnlInfo.Controls.Add(Me.tbInfo4)
        Me.pnlInfo.Controls.Add(Me.tbInfo3)
        Me.pnlInfo.Controls.Add(Me.tbInfo2)
        Me.pnlInfo.Controls.Add(Me.tbInfo1)
        Me.pnlInfo.Controls.Add(Me.tbInfo0)
        Me.pnlInfo.Controls.Add(Me.btnCancel)
        Me.pnlInfo.Controls.Add(Me.btnDelete)
        Me.pnlInfo.Controls.Add(Me.btnEdit)
        Me.pnlInfo.Controls.Add(Me.btnSave)
        Me.pnlInfo.Controls.Add(Me.btnSell)
        Me.pnlInfo.Controls.Add(Me.btnErase)
        Me.pnlInfo.Location = New System.Drawing.Point(402, 8)
        Me.pnlInfo.Name = "pnlInfo"
        Me.pnlInfo.Size = New System.Drawing.Size(376, 155)
        Me.pnlInfo.TabIndex = 19
        '
        'btnSave
        '
        Me.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!)
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Location = New System.Drawing.Point(313, 130)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(62, 25)
        Me.btnSave.TabIndex = 12
        Me.btnSave.TabStop = False
        Me.btnSave.Text = "Guardar"
        Me.btnSave.UseVisualStyleBackColor = False
        Me.btnSave.Visible = False
        '
        'btnDelete
        '
        Me.btnDelete.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!)
        Me.btnDelete.ForeColor = System.Drawing.Color.White
        Me.btnDelete.Location = New System.Drawing.Point(190, 130)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(62, 25)
        Me.btnDelete.TabIndex = 11
        Me.btnDelete.TabStop = False
        Me.btnDelete.Text = "Eliminar"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'btnEdit
        '
        Me.btnEdit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnEdit.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnEdit.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEdit.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!)
        Me.btnEdit.ForeColor = System.Drawing.Color.White
        Me.btnEdit.Location = New System.Drawing.Point(251, 130)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(60, 25)
        Me.btnEdit.TabIndex = 10
        Me.btnEdit.TabStop = False
        Me.btnEdit.Text = "Editar"
        Me.btnEdit.UseVisualStyleBackColor = False
        '
        'tbInfo9
        '
        Me.tbInfo9.BackColor = System.Drawing.Color.Black
        Me.tbInfo9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbInfo9.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbInfo9.Location = New System.Drawing.Point(189, 104)
        Me.tbInfo9.Name = "tbInfo9"
        Me.tbInfo9.Size = New System.Drawing.Size(188, 20)
        Me.tbInfo9.TabIndex = 9
        Me.tbInfo9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbInfo8
        '
        Me.tbInfo8.BackColor = System.Drawing.Color.Black
        Me.tbInfo8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbInfo8.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbInfo8.Location = New System.Drawing.Point(189, 78)
        Me.tbInfo8.Name = "tbInfo8"
        Me.tbInfo8.Size = New System.Drawing.Size(188, 20)
        Me.tbInfo8.TabIndex = 8
        Me.tbInfo8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbInfo7
        '
        Me.tbInfo7.BackColor = System.Drawing.Color.Black
        Me.tbInfo7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbInfo7.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbInfo7.Location = New System.Drawing.Point(189, 52)
        Me.tbInfo7.Name = "tbInfo7"
        Me.tbInfo7.Size = New System.Drawing.Size(188, 20)
        Me.tbInfo7.TabIndex = 7
        Me.tbInfo7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbInfo6
        '
        Me.tbInfo6.BackColor = System.Drawing.Color.Black
        Me.tbInfo6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbInfo6.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbInfo6.Location = New System.Drawing.Point(189, 26)
        Me.tbInfo6.Name = "tbInfo6"
        Me.tbInfo6.Size = New System.Drawing.Size(188, 20)
        Me.tbInfo6.TabIndex = 6
        Me.tbInfo6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbInfo5
        '
        Me.tbInfo5.BackColor = System.Drawing.Color.Black
        Me.tbInfo5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbInfo5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbInfo5.Location = New System.Drawing.Point(188, 0)
        Me.tbInfo5.Name = "tbInfo5"
        Me.tbInfo5.Size = New System.Drawing.Size(188, 20)
        Me.tbInfo5.TabIndex = 5
        Me.tbInfo5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbInfo4
        '
        Me.tbInfo4.BackColor = System.Drawing.Color.Black
        Me.tbInfo4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbInfo4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbInfo4.Location = New System.Drawing.Point(0, 104)
        Me.tbInfo4.Name = "tbInfo4"
        Me.tbInfo4.Size = New System.Drawing.Size(188, 20)
        Me.tbInfo4.TabIndex = 4
        Me.tbInfo4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbInfo3
        '
        Me.tbInfo3.BackColor = System.Drawing.Color.Black
        Me.tbInfo3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbInfo3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbInfo3.Location = New System.Drawing.Point(0, 78)
        Me.tbInfo3.Name = "tbInfo3"
        Me.tbInfo3.Size = New System.Drawing.Size(188, 20)
        Me.tbInfo3.TabIndex = 3
        Me.tbInfo3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbInfo2
        '
        Me.tbInfo2.BackColor = System.Drawing.Color.Black
        Me.tbInfo2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbInfo2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbInfo2.Location = New System.Drawing.Point(0, 52)
        Me.tbInfo2.Name = "tbInfo2"
        Me.tbInfo2.Size = New System.Drawing.Size(188, 20)
        Me.tbInfo2.TabIndex = 2
        Me.tbInfo2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbInfo1
        '
        Me.tbInfo1.BackColor = System.Drawing.Color.Black
        Me.tbInfo1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbInfo1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbInfo1.Location = New System.Drawing.Point(0, 26)
        Me.tbInfo1.Name = "tbInfo1"
        Me.tbInfo1.Size = New System.Drawing.Size(188, 20)
        Me.tbInfo1.TabIndex = 1
        Me.tbInfo1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbInfo0
        '
        Me.tbInfo0.BackColor = System.Drawing.Color.Black
        Me.tbInfo0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbInfo0.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbInfo0.Location = New System.Drawing.Point(0, 0)
        Me.tbInfo0.Name = "tbInfo0"
        Me.tbInfo0.Size = New System.Drawing.Size(188, 20)
        Me.tbInfo0.TabIndex = 0
        Me.tbInfo0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnSell
        '
        Me.btnSell.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnSell.BackColor = System.Drawing.Color.Black
        Me.btnSell.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSell.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!)
        Me.btnSell.ForeColor = System.Drawing.Color.Yellow
        Me.btnSell.Location = New System.Drawing.Point(312, 130)
        Me.btnSell.Name = "btnSell"
        Me.btnSell.Size = New System.Drawing.Size(62, 25)
        Me.btnSell.TabIndex = 13
        Me.btnSell.TabStop = False
        Me.btnSell.Text = "VENDER"
        Me.btnSell.UseVisualStyleBackColor = False
        '
        'btnErase
        '
        Me.btnErase.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnErase.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnErase.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnErase.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnErase.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!)
        Me.btnErase.ForeColor = System.Drawing.Color.White
        Me.btnErase.Location = New System.Drawing.Point(251, 130)
        Me.btnErase.Name = "btnErase"
        Me.btnErase.Size = New System.Drawing.Size(60, 25)
        Me.btnErase.TabIndex = 14
        Me.btnErase.TabStop = False
        Me.btnErase.Text = "Borrar"
        Me.btnErase.UseVisualStyleBackColor = False
        Me.btnErase.Visible = False
        '
        'btnCancel
        '
        Me.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!)
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Location = New System.Drawing.Point(190, 130)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(62, 25)
        Me.btnCancel.TabIndex = 15
        Me.btnCancel.TabStop = False
        Me.btnCancel.Text = "Salir"
        Me.btnCancel.UseVisualStyleBackColor = False
        Me.btnCancel.Visible = False
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(784, 397)
        Me.Controls.Add(Me.pnlInfo)
        Me.Controls.Add(Me.pBar1)
        Me.Controls.Add(Me.pnlUpdate)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.pnlInterest)
        Me.Controls.Add(Me.pnlInput)
        Me.Controls.Add(Me.lvResultadosBusqueda)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "Off"
        Me.Text = "Buscador"
        Me.pnlInput.ResumeLayout(False)
        Me.pnlInput.PerformLayout()
        Me.pnlInterest.ResumeLayout(False)
        Me.pnlInterest.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlUpdate.ResumeLayout(False)
        Me.pnlUpdate.PerformLayout()
        Me.pnlInfo.ResumeLayout(False)
        Me.pnlInfo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lvResultadosBusqueda As System.Windows.Forms.ListView
    Friend WithEvents pnlInput As System.Windows.Forms.Panel
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents tbInput As System.Windows.Forms.TextBox
    Friend WithEvents pnlInterest As System.Windows.Forms.Panel
    Friend WithEvents btnApplyInterest As System.Windows.Forms.Button
    Friend WithEvents lblFinalValue As System.Windows.Forms.Label
    Friend WithEvents lblValue As System.Windows.Forms.Label
    Friend WithEvents lblYear As System.Windows.Forms.Label
    Friend WithEvents lblMonth As System.Windows.Forms.Label
    Friend WithEvents tbInitValue As System.Windows.Forms.TextBox
    Friend WithEvents tbYear As System.Windows.Forms.TextBox
    Friend WithEvents tbMonth As System.Windows.Forms.TextBox
    Friend WithEvents colTitulo As System.Windows.Forms.ColumnHeader
    Friend WithEvents colAutor As System.Windows.Forms.ColumnHeader
    Friend WithEvents colISBN As System.Windows.Forms.ColumnHeader
    Friend WithEvents colEditorial As System.Windows.Forms.ColumnHeader
    Friend WithEvents colPVP As System.Windows.Forms.ColumnHeader
    Friend WithEvents colFecha As System.Windows.Forms.ColumnHeader
    Friend WithEvents colProyeccion As System.Windows.Forms.ColumnHeader
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents pnlUpdate As System.Windows.Forms.Panel
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents pBar1 As ProgressBar
    Friend WithEvents pnlInfo As Panel
    Friend WithEvents tbInfo9 As TextBox
    Friend WithEvents tbInfo8 As TextBox
    Friend WithEvents tbInfo7 As TextBox
    Friend WithEvents tbInfo6 As TextBox
    Friend WithEvents tbInfo5 As TextBox
    Friend WithEvents tbInfo4 As TextBox
    Friend WithEvents tbInfo3 As TextBox
    Friend WithEvents tbInfo2 As TextBox
    Friend WithEvents tbInfo1 As TextBox
    Friend WithEvents tbInfo0 As TextBox
    Friend WithEvents btnSave As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnErase As Button
    Friend WithEvents btnSell As Button
End Class
