<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fGestor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fGestor))
        Me.gbBuscador = New System.Windows.Forms.GroupBox()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.txtInput = New System.Windows.Forms.TextBox()
        Me.gbTitulo = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gbProyector = New System.Windows.Forms.GroupBox()
        Me.btnProy = New System.Windows.Forms.Button()
        Me.lblProy = New System.Windows.Forms.Label()
        Me.lblValor = New System.Windows.Forms.Label()
        Me.lblAno = New System.Windows.Forms.Label()
        Me.lblMes = New System.Windows.Forms.Label()
        Me.txtVlr = New System.Windows.Forms.TextBox()
        Me.txtAno = New System.Windows.Forms.TextBox()
        Me.txtMes = New System.Windows.Forms.TextBox()
        Me.lvData = New System.Windows.Forms.ListView()
        Me.gbBuscador.SuspendLayout()
        Me.gbTitulo.SuspendLayout()
        Me.gbProyector.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbBuscador
        '
        Me.gbBuscador.Controls.Add(Me.btnSalir)
        Me.gbBuscador.Controls.Add(Me.btnOk)
        Me.gbBuscador.Controls.Add(Me.txtInput)
        Me.gbBuscador.Location = New System.Drawing.Point(12, 12)
        Me.gbBuscador.Name = "gbBuscador"
        Me.gbBuscador.Size = New System.Drawing.Size(231, 117)
        Me.gbBuscador.TabIndex = 0
        Me.gbBuscador.TabStop = False
        Me.gbBuscador.Text = "Buscador"
        '
        'btnSalir
        '
        Me.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Location = New System.Drawing.Point(105, 57)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(85, 42)
        Me.btnSalir.TabIndex = 4
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.Location = New System.Drawing.Point(14, 57)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(85, 43)
        Me.btnOk.TabIndex = 1
        Me.btnOk.Text = "Buscar"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'txtInput
        '
        Me.txtInput.Location = New System.Drawing.Point(14, 19)
        Me.txtInput.Name = "txtInput"
        Me.txtInput.Size = New System.Drawing.Size(176, 20)
        Me.txtInput.TabIndex = 0
        '
        'gbTitulo
        '
        Me.gbTitulo.Controls.Add(Me.Label1)
        Me.gbTitulo.Location = New System.Drawing.Point(249, 13)
        Me.gbTitulo.Name = "gbTitulo"
        Me.gbTitulo.Size = New System.Drawing.Size(249, 116)
        Me.gbTitulo.TabIndex = 1
        Me.gbTitulo.TabStop = False
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 27.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Green
        Me.Label1.Location = New System.Drawing.Point(6, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(237, 97)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Uppsala"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gbProyector
        '
        Me.gbProyector.Controls.Add(Me.btnProy)
        Me.gbProyector.Controls.Add(Me.lblProy)
        Me.gbProyector.Controls.Add(Me.lblValor)
        Me.gbProyector.Controls.Add(Me.lblAno)
        Me.gbProyector.Controls.Add(Me.lblMes)
        Me.gbProyector.Controls.Add(Me.txtVlr)
        Me.gbProyector.Controls.Add(Me.txtAno)
        Me.gbProyector.Controls.Add(Me.txtMes)
        Me.gbProyector.Location = New System.Drawing.Point(504, 13)
        Me.gbProyector.Name = "gbProyector"
        Me.gbProyector.Size = New System.Drawing.Size(271, 116)
        Me.gbProyector.TabIndex = 2
        Me.gbProyector.TabStop = False
        Me.gbProyector.Text = "Proyector"
        '
        'btnProy
        '
        Me.btnProy.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProy.Location = New System.Drawing.Point(184, 19)
        Me.btnProy.Name = "btnProy"
        Me.btnProy.Size = New System.Drawing.Size(71, 46)
        Me.btnProy.TabIndex = 7
        Me.btnProy.Text = "Proyectar"
        Me.btnProy.UseVisualStyleBackColor = True
        '
        'lblProy
        '
        Me.lblProy.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProy.ForeColor = System.Drawing.Color.Red
        Me.lblProy.Location = New System.Drawing.Point(56, 72)
        Me.lblProy.Name = "lblProy"
        Me.lblProy.Size = New System.Drawing.Size(122, 27)
        Me.lblProy.TabIndex = 6
        Me.lblProy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblValor
        '
        Me.lblValor.AutoSize = True
        Me.lblValor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValor.Location = New System.Drawing.Point(11, 48)
        Me.lblValor.Name = "lblValor"
        Me.lblValor.Size = New System.Drawing.Size(36, 13)
        Me.lblValor.TabIndex = 5
        Me.lblValor.Text = "Valor"
        '
        'lblAno
        '
        Me.lblAno.AutoSize = True
        Me.lblAno.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAno.Location = New System.Drawing.Point(102, 22)
        Me.lblAno.Name = "lblAno"
        Me.lblAno.Size = New System.Drawing.Size(29, 13)
        Me.lblAno.TabIndex = 4
        Me.lblAno.Text = "Año"
        '
        'lblMes
        '
        Me.lblMes.AutoSize = True
        Me.lblMes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMes.Location = New System.Drawing.Point(11, 22)
        Me.lblMes.Name = "lblMes"
        Me.lblMes.Size = New System.Drawing.Size(30, 13)
        Me.lblMes.TabIndex = 3
        Me.lblMes.Text = "Mes"
        '
        'txtVlr
        '
        Me.txtVlr.Location = New System.Drawing.Point(56, 45)
        Me.txtVlr.Name = "txtVlr"
        Me.txtVlr.Size = New System.Drawing.Size(122, 20)
        Me.txtVlr.TabIndex = 2
        '
        'txtAno
        '
        Me.txtAno.Location = New System.Drawing.Point(138, 19)
        Me.txtAno.Name = "txtAno"
        Me.txtAno.Size = New System.Drawing.Size(40, 20)
        Me.txtAno.TabIndex = 1
        '
        'txtMes
        '
        Me.txtMes.Location = New System.Drawing.Point(56, 19)
        Me.txtMes.Name = "txtMes"
        Me.txtMes.Size = New System.Drawing.Size(40, 20)
        Me.txtMes.TabIndex = 0
        '
        'lvData
        '
        Me.lvData.FullRowSelect = True
        Me.lvData.GridLines = True
        Me.lvData.Location = New System.Drawing.Point(12, 135)
        Me.lvData.Name = "lvData"
        Me.lvData.Size = New System.Drawing.Size(763, 242)
        Me.lvData.TabIndex = 3
        Me.lvData.UseCompatibleStateImageBehavior = False
        Me.lvData.View = System.Windows.Forms.View.Details
        '
        'fGestor
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnSalir
        Me.ClientSize = New System.Drawing.Size(785, 389)
        Me.Controls.Add(Me.lvData)
        Me.Controls.Add(Me.gbProyector)
        Me.Controls.Add(Me.gbTitulo)
        Me.Controls.Add(Me.gbBuscador)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "fGestor"
        Me.Text = "Gestor"
        Me.gbBuscador.ResumeLayout(False)
        Me.gbBuscador.PerformLayout()
        Me.gbTitulo.ResumeLayout(False)
        Me.gbProyector.ResumeLayout(False)
        Me.gbProyector.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbBuscador As System.Windows.Forms.GroupBox
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents txtInput As System.Windows.Forms.TextBox
    Friend WithEvents gbTitulo As System.Windows.Forms.GroupBox
    Friend WithEvents gbProyector As System.Windows.Forms.GroupBox
    Friend WithEvents lvData As System.Windows.Forms.ListView
    Friend WithEvents btnProy As System.Windows.Forms.Button
    Friend WithEvents lblProy As System.Windows.Forms.Label
    Friend WithEvents lblValor As System.Windows.Forms.Label
    Friend WithEvents lblAno As System.Windows.Forms.Label
    Friend WithEvents lblMes As System.Windows.Forms.Label
    Friend WithEvents txtVlr As System.Windows.Forms.TextBox
    Friend WithEvents txtAno As System.Windows.Forms.TextBox
    Friend WithEvents txtMes As System.Windows.Forms.TextBox
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
