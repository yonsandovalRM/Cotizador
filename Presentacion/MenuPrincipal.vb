Public Class MenuPrincipal

    Private Sub GenerarInformeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GenerarInformeToolStripMenuItem.Click
        Dim NuevoWF As New GeneraInformeYemas
        NuevoWF.MdiParent = Me
        NuevoWF.Show()
    End Sub

    Private Sub FacturadosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FacturadosToolStripMenuItem.Click
        Dim NuevoWF As New EstadisticasAgrolab
        NuevoWF.MdiParent = Me
        NuevoWF.Show()
    End Sub

    Private Sub CotizaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CotizaToolStripMenuItem.Click
        Dim NuevoWF As New Cotiza
        NuevoWF.MdiParent = Me
        NuevoWF.Show()
    End Sub
End Class