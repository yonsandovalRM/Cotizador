<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CotizacionesAnteriores
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
        Me.components = New System.ComponentModel.Container()
        Me.bnBuscar = New System.Windows.Forms.Button()
        Me.dgAnteriores = New System.Windows.Forms.DataGridView()
        Me.COT_NUMERO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COT_EMPRESA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COT_RUT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COT_NOMBRE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COT_EMAIL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COT_ATENCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COT_DIRECCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COT_COMUNA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COT_FONO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COT_FAX = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COT_SUBTOTAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COT_DESCUENTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COT_NETO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COT_IVA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COT_TOTAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COT_FECHA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COT_CELULAR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COT_CIUDAD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COT_MUE1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COT_MUE2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COT_MUE3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COT_MUE4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COT_CARGO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COT_EMAIL2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txEmpresa = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txProductor = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txAtencion = New System.Windows.Forms.TextBox()
        Me.bnAbrir = New System.Windows.Forms.Button()
        Me.bnModificar = New System.Windows.Forms.Button()
        Me.bnEnviar = New System.Windows.Forms.Button()
        Me.bnNueva = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lbSeleccion = New System.Windows.Forms.Label()
        Me.bnEliminar = New System.Windows.Forms.Button()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.dgAnteriores, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'bnBuscar
        '
        Me.bnBuscar.Location = New System.Drawing.Point(971, 22)
        Me.bnBuscar.Name = "bnBuscar"
        Me.bnBuscar.Size = New System.Drawing.Size(102, 23)
        Me.bnBuscar.TabIndex = 0
        Me.bnBuscar.Text = "Buscar"
        Me.bnBuscar.UseVisualStyleBackColor = True
        '
        'dgAnteriores
        '
        Me.dgAnteriores.AllowUserToAddRows = False
        Me.dgAnteriores.AllowUserToDeleteRows = False
        Me.dgAnteriores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgAnteriores.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.COT_NUMERO, Me.COT_EMPRESA, Me.COT_RUT, Me.COT_NOMBRE, Me.COT_EMAIL, Me.COT_ATENCION, Me.COT_DIRECCION, Me.COT_COMUNA, Me.COT_FONO, Me.COT_FAX, Me.COT_SUBTOTAL, Me.COT_DESCUENTO, Me.COT_NETO, Me.COT_IVA, Me.COT_TOTAL, Me.COT_FECHA, Me.COT_CELULAR, Me.COT_CIUDAD, Me.COT_MUE1, Me.COT_MUE2, Me.COT_MUE3, Me.COT_MUE4, Me.COT_CARGO, Me.COT_EMAIL2})
        Me.dgAnteriores.Location = New System.Drawing.Point(12, 61)
        Me.dgAnteriores.Name = "dgAnteriores"
        Me.dgAnteriores.Size = New System.Drawing.Size(1064, 551)
        Me.dgAnteriores.TabIndex = 1
        '
        'COT_NUMERO
        '
        Me.COT_NUMERO.DataPropertyName = "COT_NUMERO"
        Me.COT_NUMERO.HeaderText = "N°"
        Me.COT_NUMERO.Name = "COT_NUMERO"
        Me.COT_NUMERO.ReadOnly = True
        Me.COT_NUMERO.Width = 40
        '
        'COT_EMPRESA
        '
        Me.COT_EMPRESA.DataPropertyName = "COT_EMPRESA"
        Me.COT_EMPRESA.HeaderText = "Empresa"
        Me.COT_EMPRESA.Name = "COT_EMPRESA"
        Me.COT_EMPRESA.ReadOnly = True
        Me.COT_EMPRESA.Width = 200
        '
        'COT_RUT
        '
        Me.COT_RUT.DataPropertyName = "COT_RUT"
        Me.COT_RUT.HeaderText = "Rut"
        Me.COT_RUT.Name = "COT_RUT"
        Me.COT_RUT.ReadOnly = True
        Me.COT_RUT.Visible = False
        '
        'COT_NOMBRE
        '
        Me.COT_NOMBRE.DataPropertyName = "COT_NOMBRE"
        Me.COT_NOMBRE.HeaderText = "Nombre"
        Me.COT_NOMBRE.Name = "COT_NOMBRE"
        Me.COT_NOMBRE.ReadOnly = True
        Me.COT_NOMBRE.Visible = False
        '
        'COT_EMAIL
        '
        Me.COT_EMAIL.DataPropertyName = "COT_EMAIL"
        Me.COT_EMAIL.HeaderText = "Email"
        Me.COT_EMAIL.Name = "COT_EMAIL"
        Me.COT_EMAIL.ReadOnly = True
        Me.COT_EMAIL.Width = 200
        '
        'COT_ATENCION
        '
        Me.COT_ATENCION.DataPropertyName = "COT_ATENCION"
        Me.COT_ATENCION.HeaderText = "Atención"
        Me.COT_ATENCION.Name = "COT_ATENCION"
        Me.COT_ATENCION.ReadOnly = True
        '
        'COT_DIRECCION
        '
        Me.COT_DIRECCION.DataPropertyName = "COT_DIRECCION"
        Me.COT_DIRECCION.HeaderText = "Dirección"
        Me.COT_DIRECCION.Name = "COT_DIRECCION"
        Me.COT_DIRECCION.ReadOnly = True
        Me.COT_DIRECCION.Visible = False
        '
        'COT_COMUNA
        '
        Me.COT_COMUNA.DataPropertyName = "COT_COMUNA"
        Me.COT_COMUNA.HeaderText = "Comuna"
        Me.COT_COMUNA.Name = "COT_COMUNA"
        Me.COT_COMUNA.ReadOnly = True
        Me.COT_COMUNA.Visible = False
        '
        'COT_FONO
        '
        Me.COT_FONO.DataPropertyName = "COT_FONO"
        Me.COT_FONO.HeaderText = "Fono"
        Me.COT_FONO.Name = "COT_FONO"
        Me.COT_FONO.ReadOnly = True
        '
        'COT_FAX
        '
        Me.COT_FAX.DataPropertyName = "COT_FAX"
        Me.COT_FAX.HeaderText = "Fax"
        Me.COT_FAX.Name = "COT_FAX"
        Me.COT_FAX.ReadOnly = True
        Me.COT_FAX.Visible = False
        '
        'COT_SUBTOTAL
        '
        Me.COT_SUBTOTAL.DataPropertyName = "COT_SUBTOTAL"
        Me.COT_SUBTOTAL.HeaderText = "SubTotal"
        Me.COT_SUBTOTAL.Name = "COT_SUBTOTAL"
        Me.COT_SUBTOTAL.ReadOnly = True
        Me.COT_SUBTOTAL.Visible = False
        '
        'COT_DESCUENTO
        '
        Me.COT_DESCUENTO.DataPropertyName = "COT_DESCUENTO"
        Me.COT_DESCUENTO.HeaderText = "Dscto."
        Me.COT_DESCUENTO.Name = "COT_DESCUENTO"
        Me.COT_DESCUENTO.ReadOnly = True
        Me.COT_DESCUENTO.Visible = False
        '
        'COT_NETO
        '
        Me.COT_NETO.DataPropertyName = "COT_NETO"
        Me.COT_NETO.HeaderText = "Neto"
        Me.COT_NETO.Name = "COT_NETO"
        Me.COT_NETO.ReadOnly = True
        Me.COT_NETO.Visible = False
        '
        'COT_IVA
        '
        Me.COT_IVA.DataPropertyName = "COT_IVA"
        Me.COT_IVA.HeaderText = "IVA"
        Me.COT_IVA.Name = "COT_IVA"
        Me.COT_IVA.ReadOnly = True
        Me.COT_IVA.Visible = False
        '
        'COT_TOTAL
        '
        Me.COT_TOTAL.DataPropertyName = "COT_TOTAL"
        Me.COT_TOTAL.HeaderText = "Total"
        Me.COT_TOTAL.Name = "COT_TOTAL"
        Me.COT_TOTAL.ReadOnly = True
        Me.COT_TOTAL.Visible = False
        '
        'COT_FECHA
        '
        Me.COT_FECHA.DataPropertyName = "COT_FECHA"
        Me.COT_FECHA.HeaderText = "Fecha"
        Me.COT_FECHA.Name = "COT_FECHA"
        Me.COT_FECHA.ReadOnly = True
        '
        'COT_CELULAR
        '
        Me.COT_CELULAR.DataPropertyName = "COT_CELULAR"
        Me.COT_CELULAR.HeaderText = "Celular"
        Me.COT_CELULAR.Name = "COT_CELULAR"
        Me.COT_CELULAR.ReadOnly = True
        Me.COT_CELULAR.Visible = False
        '
        'COT_CIUDAD
        '
        Me.COT_CIUDAD.DataPropertyName = "COT_CIUDAD"
        Me.COT_CIUDAD.HeaderText = "Ciudad"
        Me.COT_CIUDAD.Name = "COT_CIUDAD"
        Me.COT_CIUDAD.ReadOnly = True
        '
        'COT_MUE1
        '
        Me.COT_MUE1.DataPropertyName = "COT_MUE1"
        Me.COT_MUE1.HeaderText = "Mue1"
        Me.COT_MUE1.Name = "COT_MUE1"
        Me.COT_MUE1.ReadOnly = True
        Me.COT_MUE1.Width = 50
        '
        'COT_MUE2
        '
        Me.COT_MUE2.DataPropertyName = "COT_MUE2"
        Me.COT_MUE2.HeaderText = "Mue2"
        Me.COT_MUE2.Name = "COT_MUE2"
        Me.COT_MUE2.ReadOnly = True
        Me.COT_MUE2.Width = 50
        '
        'COT_MUE3
        '
        Me.COT_MUE3.DataPropertyName = "COT_MUE3"
        Me.COT_MUE3.HeaderText = "Mue3"
        Me.COT_MUE3.Name = "COT_MUE3"
        Me.COT_MUE3.ReadOnly = True
        Me.COT_MUE3.Width = 50
        '
        'COT_MUE4
        '
        Me.COT_MUE4.DataPropertyName = "COT_MUE4"
        Me.COT_MUE4.HeaderText = "Mue4"
        Me.COT_MUE4.Name = "COT_MUE4"
        Me.COT_MUE4.ReadOnly = True
        Me.COT_MUE4.Width = 50
        '
        'COT_CARGO
        '
        Me.COT_CARGO.DataPropertyName = "COT_CARGO"
        Me.COT_CARGO.HeaderText = "Cargo"
        Me.COT_CARGO.Name = "COT_CARGO"
        Me.COT_CARGO.ReadOnly = True
        Me.COT_CARGO.Visible = False
        '
        'COT_EMAIL2
        '
        Me.COT_EMAIL2.DataPropertyName = "COT_EMAIL2"
        Me.COT_EMAIL2.HeaderText = "Email2"
        Me.COT_EMAIL2.Name = "COT_EMAIL2"
        Me.COT_EMAIL2.ReadOnly = True
        Me.COT_EMAIL2.Visible = False
        '
        'txEmpresa
        '
        Me.txEmpresa.Location = New System.Drawing.Point(399, 25)
        Me.txEmpresa.Name = "txEmpresa"
        Me.txEmpresa.Size = New System.Drawing.Size(170, 20)
        Me.txEmpresa.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(399, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Empresa"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(591, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Productor"
        '
        'txProductor
        '
        Me.txProductor.Location = New System.Drawing.Point(591, 25)
        Me.txProductor.Name = "txProductor"
        Me.txProductor.Size = New System.Drawing.Size(170, 20)
        Me.txProductor.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(784, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Atención a:"
        '
        'txAtencion
        '
        Me.txAtencion.Location = New System.Drawing.Point(784, 25)
        Me.txAtencion.Name = "txAtencion"
        Me.txAtencion.Size = New System.Drawing.Size(170, 20)
        Me.txAtencion.TabIndex = 8
        '
        'bnAbrir
        '
        Me.bnAbrir.Location = New System.Drawing.Point(9, 646)
        Me.bnAbrir.Name = "bnAbrir"
        Me.bnAbrir.Size = New System.Drawing.Size(208, 65)
        Me.bnAbrir.TabIndex = 10
        Me.bnAbrir.Text = "Abrir Archivo"
        Me.bnAbrir.UseVisualStyleBackColor = True
        '
        'bnModificar
        '
        Me.bnModificar.Location = New System.Drawing.Point(223, 646)
        Me.bnModificar.Name = "bnModificar"
        Me.bnModificar.Size = New System.Drawing.Size(208, 65)
        Me.bnModificar.TabIndex = 11
        Me.bnModificar.Text = "Modificar"
        Me.bnModificar.UseVisualStyleBackColor = True
        '
        'bnEnviar
        '
        Me.bnEnviar.Location = New System.Drawing.Point(437, 646)
        Me.bnEnviar.Name = "bnEnviar"
        Me.bnEnviar.Size = New System.Drawing.Size(208, 65)
        Me.bnEnviar.TabIndex = 12
        Me.bnEnviar.Text = "Enviar"
        Me.bnEnviar.UseVisualStyleBackColor = True
        '
        'bnNueva
        '
        Me.bnNueva.Location = New System.Drawing.Point(651, 646)
        Me.bnNueva.Name = "bnNueva"
        Me.bnNueva.Size = New System.Drawing.Size(208, 65)
        Me.bnNueva.TabIndex = 13
        Me.bnNueva.Text = "Nueva"
        Me.bnNueva.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 628)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(127, 13)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Cotización Seleccionada:"
        '
        'lbSeleccion
        '
        Me.lbSeleccion.AutoSize = True
        Me.lbSeleccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbSeleccion.Location = New System.Drawing.Point(142, 626)
        Me.lbSeleccion.Name = "lbSeleccion"
        Me.lbSeleccion.Size = New System.Drawing.Size(0, 15)
        Me.lbSeleccion.TabIndex = 15
        '
        'bnEliminar
        '
        Me.bnEliminar.Location = New System.Drawing.Point(865, 646)
        Me.bnEliminar.Name = "bnEliminar"
        Me.bnEliminar.Size = New System.Drawing.Size(208, 65)
        Me.bnEliminar.TabIndex = 16
        Me.bnEliminar.Text = "Eliminar"
        Me.bnEliminar.UseVisualStyleBackColor = True
        '
        'CotizacionesAnteriores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1089, 724)
        Me.Controls.Add(Me.bnEliminar)
        Me.Controls.Add(Me.lbSeleccion)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.bnNueva)
        Me.Controls.Add(Me.bnEnviar)
        Me.Controls.Add(Me.bnModificar)
        Me.Controls.Add(Me.bnAbrir)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txAtencion)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txProductor)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txEmpresa)
        Me.Controls.Add(Me.dgAnteriores)
        Me.Controls.Add(Me.bnBuscar)
        Me.MaximizeBox = False
        Me.Name = "CotizacionesAnteriores"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CotizacionesAnteriores"
        CType(Me.dgAnteriores, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bnBuscar As System.Windows.Forms.Button
    Friend WithEvents dgAnteriores As System.Windows.Forms.DataGridView
    Friend WithEvents txEmpresa As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txProductor As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txAtencion As System.Windows.Forms.TextBox
    Friend WithEvents bnAbrir As System.Windows.Forms.Button
    Friend WithEvents bnModificar As System.Windows.Forms.Button
    Friend WithEvents bnEnviar As System.Windows.Forms.Button
    Friend WithEvents bnNueva As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lbSeleccion As System.Windows.Forms.Label
    Friend WithEvents bnEliminar As System.Windows.Forms.Button
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents COT_NUMERO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COT_EMPRESA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COT_RUT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COT_NOMBRE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COT_EMAIL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COT_ATENCION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COT_DIRECCION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COT_COMUNA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COT_FONO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COT_FAX As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COT_SUBTOTAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COT_DESCUENTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COT_NETO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COT_IVA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COT_TOTAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COT_FECHA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COT_CELULAR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COT_CIUDAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COT_MUE1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COT_MUE2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COT_MUE3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COT_MUE4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COT_CARGO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COT_EMAIL2 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
