<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formHistorial
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
        Me.listHistorial = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'listHistorial
        '
        Me.listHistorial.FormattingEnabled = True
        Me.listHistorial.Location = New System.Drawing.Point(12, 12)
        Me.listHistorial.Name = "listHistorial"
        Me.listHistorial.Size = New System.Drawing.Size(200, 316)
        Me.listHistorial.TabIndex = 0
        '
        'formHistorial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(224, 337)
        Me.Controls.Add(Me.listHistorial)
        Me.KeyPreview = True
        Me.Name = "formHistorial"
        Me.Text = "formHistorial"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents listHistorial As System.Windows.Forms.ListBox
End Class
