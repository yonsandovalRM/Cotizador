Imports Negocio
Public Class CotizacionesAnteriores
    Dim vafiltro, nCotiza, vaEmpresa, vaEmail, vaAtencion, vaFono As String

    Private Sub txEmpresa_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txEmpresa.KeyPress
        Me.txAtencion.Text = ""
        Me.txProductor.Text = ""
        Me.vafiltro = "porEmpresa"
    End Sub

    Private Sub txProductor_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txProductor.KeyPress
        Me.txAtencion.Text = ""
        Me.txEmpresa.Text = ""
        Me.vafiltro = "porProductor"
    End Sub

    Private Sub txAtencion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txAtencion.KeyPress
        Me.txProductor.Text = ""
        Me.txEmpresa.Text = ""
        Me.vafiltro = "porAtencion"
    End Sub

    Private Sub bnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bnBuscar.Click
        Dim cn As New CapaNegocio
        Dim ds As New DataSet
        Dim dt As New DataTable

        If txAtencion.Text <> "" Then
            ds = cn.HistoricoCotiza(vafiltro, txAtencion.Text)
        End If
        If txEmpresa.Text <> "" Then
            ds = cn.HistoricoCotiza(vafiltro, txEmpresa.Text)
        End If
        If txProductor.Text <> "" Then
            ds = cn.HistoricoCotiza(vafiltro, txProductor.Text)
        End If

        If ds.Tables.Count <> 0 Then
            dt = ds.Tables(0)
            BindingSource1.DataSource = dt
            dgAnteriores.DataSource = BindingSource1
        End If

    End Sub

    Private Sub txEmpresa_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txEmpresa.KeyUp
        If e.KeyCode = Keys.Enter Then
            bnBuscar.Focus()
        End If
    End Sub
    Private Sub dgAnteriores_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgAnteriores.CellDoubleClick
        nCotiza = dgAnteriores.Rows(e.RowIndex).Cells("COT_NUMERO").Value
        vaEmpresa = dgAnteriores.Rows(e.RowIndex).Cells("COT_EMPRESA").Value
        vaAtencion = dgAnteriores.Rows(e.RowIndex).Cells("COT_ATENCION").Value
        vaFono = dgAnteriores.Rows(e.RowIndex).Cells("COT_FONO").Value
        vaEmail = dgAnteriores.Rows(e.RowIndex).Cells("COT_EMAIL").Value

        lbSeleccion.Text = nCotiza
    End Sub

    Private Sub bnAbrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bnAbrir.Click
        Me.bnAbrir.Enabled = False
        Dim sRutaDest, subString, vaRuta As String
        Dim arr() As String
        Dim vaTamanoNumero As Integer
        sRutaDest = "F:\Cotizacion\"

        If Me.lbSeleccion.Text <> "" Then
            Dim Archivo As System.Collections.ObjectModel.ReadOnlyCollection(Of String)
            Archivo = My.Computer.FileSystem.GetFiles(sRutaDest)
            For Each names As String In Archivo

                vaTamanoNumero = nCotiza.Length
                arr = Split(names, "\")

                vaRuta = arr(2)

                subString = Microsoft.VisualBasic.Left(vaRuta, vaTamanoNumero)

                If nCotiza = subString Then
                    Shell("explorer.exe root = " & names & "", vbNormalFocus)
                    Exit For
                End If
            Next
        End If


        Me.bnAbrir.Enabled = True

    End Sub
    Private Sub bnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bnModificar.Click
        If Me.lbSeleccion.Text <> "" Then

        Else

        End If
    End Sub

    Private Sub bnNueva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bnNueva.Click
        If Me.lbSeleccion.Text <> "" Then
            Cotiza.txEmpresa.Text = vaEmpresa
            Cotiza.txEmail.Text = vaEmail
            Cotiza.txAtencion.Text = vaAtencion
            Cotiza.txTelefono.Text = vaFono
            Me.Close()
        Else

        End If
    End Sub

    Private Sub bnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bnEliminar.Click
        If Me.lbSeleccion.Text <> "" Then

        Else

        End If
    End Sub

    Private Sub bnEnviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bnEnviar.Click
        If Me.lbSeleccion.Text <> "" Then

        Else

        End If
    End Sub

    Private Sub CotizacionesAnteriores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class