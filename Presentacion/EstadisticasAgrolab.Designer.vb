<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EstadisticasAgrolab
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.bntBuscar = New System.Windows.Forms.Button()
        Me.dtDesde = New System.Windows.Forms.DateTimePicker()
        Me.dtHasta = New System.Windows.Forms.DateTimePicker()
        Me.dgvResultado = New System.Windows.Forms.DataGridView()
        Me.FAC_FECHA_EMISION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FAC_NUMERO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DET_CODIGO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DET_TOTAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DET_CANTIDAD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cbTipoMuestra = New System.Windows.Forms.ComboBox()
        Me.txt_Total = New System.Windows.Forms.TextBox()
        Me.txt_Cantidad = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbTipoEstado = New System.Windows.Forms.ComboBox()
        CType(Me.dgvResultado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(137, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Selecione Tipo de Muestra:"
        '
        'bntBuscar
        '
        Me.bntBuscar.Location = New System.Drawing.Point(266, 106)
        Me.bntBuscar.Name = "bntBuscar"
        Me.bntBuscar.Size = New System.Drawing.Size(75, 23)
        Me.bntBuscar.TabIndex = 1
        Me.bntBuscar.Text = "Consultar"
        Me.bntBuscar.UseVisualStyleBackColor = True
        '
        'dtDesde
        '
        Me.dtDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtDesde.Location = New System.Drawing.Point(16, 108)
        Me.dtDesde.Name = "dtDesde"
        Me.dtDesde.Size = New System.Drawing.Size(119, 20)
        Me.dtDesde.TabIndex = 2
        '
        'dtHasta
        '
        Me.dtHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtHasta.Location = New System.Drawing.Point(141, 108)
        Me.dtHasta.Name = "dtHasta"
        Me.dtHasta.Size = New System.Drawing.Size(119, 20)
        Me.dtHasta.TabIndex = 3
        '
        'dgvResultado
        '
        Me.dgvResultado.AllowUserToAddRows = False
        Me.dgvResultado.AllowUserToDeleteRows = False
        Me.dgvResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvResultado.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FAC_FECHA_EMISION, Me.FAC_NUMERO, Me.DET_CODIGO, Me.DET_TOTAL, Me.DET_CANTIDAD})
        Me.dgvResultado.Location = New System.Drawing.Point(16, 145)
        Me.dgvResultado.Name = "dgvResultado"
        Me.dgvResultado.ReadOnly = True
        Me.dgvResultado.Size = New System.Drawing.Size(574, 368)
        Me.dgvResultado.TabIndex = 4
        '
        'FAC_FECHA_EMISION
        '
        Me.FAC_FECHA_EMISION.DataPropertyName = "FAC_FECHA_EMISION"
        Me.FAC_FECHA_EMISION.HeaderText = "Fecha Emision"
        Me.FAC_FECHA_EMISION.Name = "FAC_FECHA_EMISION"
        Me.FAC_FECHA_EMISION.ReadOnly = True
        '
        'FAC_NUMERO
        '
        Me.FAC_NUMERO.DataPropertyName = "FAC_NUMERO"
        Me.FAC_NUMERO.HeaderText = "Factura"
        Me.FAC_NUMERO.Name = "FAC_NUMERO"
        Me.FAC_NUMERO.ReadOnly = True
        '
        'DET_CODIGO
        '
        Me.DET_CODIGO.DataPropertyName = "DET_CODIGO"
        Me.DET_CODIGO.HeaderText = "Codigo"
        Me.DET_CODIGO.Name = "DET_CODIGO"
        Me.DET_CODIGO.ReadOnly = True
        '
        'DET_TOTAL
        '
        Me.DET_TOTAL.DataPropertyName = "DET_TOTAL"
        Me.DET_TOTAL.HeaderText = "Total Neto"
        Me.DET_TOTAL.Name = "DET_TOTAL"
        Me.DET_TOTAL.ReadOnly = True
        Me.DET_TOTAL.Width = 120
        '
        'DET_CANTIDAD
        '
        Me.DET_CANTIDAD.DataPropertyName = "DET_CANTIDAD"
        Me.DET_CANTIDAD.HeaderText = "Cantidad"
        Me.DET_CANTIDAD.Name = "DET_CANTIDAD"
        Me.DET_CANTIDAD.ReadOnly = True
        '
        'cbTipoMuestra
        '
        Me.cbTipoMuestra.FormattingEnabled = True
        Me.cbTipoMuestra.Items.AddRange(New Object() {"FOLIAR", "TEJIDOS", "AGUAS", "SUELOS", "FQUIMICOS", "FORGANICOS", "FITO LAB", "FITO ENSAYO", "OTROS"})
        Me.cbTipoMuestra.Location = New System.Drawing.Point(19, 73)
        Me.cbTipoMuestra.Name = "cbTipoMuestra"
        Me.cbTipoMuestra.Size = New System.Drawing.Size(241, 21)
        Me.cbTipoMuestra.TabIndex = 5
        '
        'txt_Total
        '
        Me.txt_Total.Location = New System.Drawing.Point(356, 519)
        Me.txt_Total.Name = "txt_Total"
        Me.txt_Total.Size = New System.Drawing.Size(128, 20)
        Me.txt_Total.TabIndex = 8
        '
        'txt_Cantidad
        '
        Me.txt_Cantidad.Location = New System.Drawing.Point(490, 519)
        Me.txt_Cantidad.Name = "txt_Cantidad"
        Me.txt_Cantidad.Size = New System.Drawing.Size(100, 20)
        Me.txt_Cantidad.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 560)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(395, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "* Totales correspondientes al registro en las tablas FACTURA y FACTURA DETALLE"
        '
        'cbTipoEstado
        '
        Me.cbTipoEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTipoEstado.FormattingEnabled = True
        Me.cbTipoEstado.Items.AddRange(New Object() {"ANALISIS FACTURADOS", "ANALISIS POR FACTURAR", "ANALISIS INGRESADOS"})
        Me.cbTipoEstado.Location = New System.Drawing.Point(340, 12)
        Me.cbTipoEstado.Name = "cbTipoEstado"
        Me.cbTipoEstado.Size = New System.Drawing.Size(250, 28)
        Me.cbTipoEstado.TabIndex = 12
        Me.cbTipoEstado.Text = "ANALISIS FACTURADOS"
        '
        'EstadisticasAgrolab
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(607, 582)
        Me.Controls.Add(Me.cbTipoEstado)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txt_Cantidad)
        Me.Controls.Add(Me.txt_Total)
        Me.Controls.Add(Me.cbTipoMuestra)
        Me.Controls.Add(Me.dgvResultado)
        Me.Controls.Add(Me.dtHasta)
        Me.Controls.Add(Me.dtDesde)
        Me.Controls.Add(Me.bntBuscar)
        Me.Controls.Add(Me.Label1)
        Me.Name = "EstadisticasAgrolab"
        Me.Text = "EstadisticasAgrolab"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgvResultado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents bntBuscar As System.Windows.Forms.Button
    Friend WithEvents dtDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents dgvResultado As System.Windows.Forms.DataGridView
    Friend WithEvents cbTipoMuestra As System.Windows.Forms.ComboBox
    Friend WithEvents txt_Total As System.Windows.Forms.TextBox
    Friend WithEvents txt_Cantidad As System.Windows.Forms.TextBox
    Friend WithEvents FAC_FECHA_EMISION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FAC_NUMERO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DET_CODIGO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DET_TOTAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DET_CANTIDAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbTipoEstado As System.Windows.Forms.ComboBox
End Class
