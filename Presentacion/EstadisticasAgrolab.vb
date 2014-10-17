Imports Negocio

Public Class EstadisticasAgrolab
    Dim vaEstado As String

    Private Sub bntBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bntBuscar.Click
        If Me.cbTipoMuestra.Text <> "" Then
            Dim sTipo As Integer
            Dim cn As New CapaNegocio
            Dim ds As DataSet

            Select Case cbTipoMuestra.Text
                Case "FOLIAR"
                    sTipo = 1
                Case "TEJIDOS"
                    sTipo = 2
                Case "AGUAS"
                    sTipo = 3
                Case "SUELOS"
                    sTipo = 4
                Case "FQUIMICOS"
                    sTipo = 5
                Case "FORGANICOS"
                    sTipo = 6
                Case "FITO LAB"
                    sTipo = 7
                Case "FITO ENSAYO"
                    sTipo = 8
                Case "OTROS"
                    sTipo = 9
                Case Else
                    sTipo = 1
            End Select

            If vaEstado = "fac" Or vaEstado = "" Then
                ds = cn.BuscaEstadisticas(dtDesde.Text, dtHasta.Text, sTipo)
                dgvResultado.DataSource = ds.Tables(0)
            ElseIf vaEstado = "xfac" Then
                ds = cn.BuscaEstadisticas2(dtDesde.Text, dtHasta.Text, sTipo)
                dgvResultado.DataSource = ds.Tables(0)
            ElseIf vaEstado = "Ing" Then
                ds = cn.BuscaEstadisticas3(dtDesde.Text, dtHasta.Text, sTipo)
                dgvResultado.DataSource = ds.Tables(0)
            End If


            Dim table As DataTable
            table = ds.Tables(0)
            Dim total As Object = table.Compute("SUM(DET_TOTAL)", Nothing)
            Dim cantidad As Object = table.Compute("SUM(DET_CANTIDAD)", Nothing)
            ' visualizar el resultado en la barra
            Me.txt_Total.Text = total.ToString
            Me.txt_Cantidad.Text = cantidad.ToString
        Else
            MsgBox("Seleccione Tipo de muestra")
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbTipoEstado.SelectedIndexChanged
        If cbTipoEstado.Text = "ANALISIS FACTURADOS" Then
            Label3.Text = "* Totales correspondientes al registro en las tablas FACTURA y FACTURA DETALLE"
            vaEstado = "fac"
        ElseIf cbTipoEstado.Text = "ANALISIS POR FACTURAR" Then
            Label3.Text = "* Totales correspondientes al registro en las tablas ORDEN_TRABAJO y OT_CODIFICACION"
            vaEstado = "xfac"
        ElseIf cbTipoEstado.Text = "ANALISIS INGRESADOS" Then
            Label3.Text = "* Totales correspondientes al registro en las tablas ORDEN_TRABAJO, OT_CODIFICACION y DIGITA_RESULTADOS"
            vaEstado = "Ing"
        End If
    End Sub
End Class