Imports Negocio
Imports System
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports Microsoft.Office.Interop
Imports System.IO
Public Class Cotiza
    Dim vaCantidad, vaCodigo, vaNeto, vaTotal, vaSubtotal, vaFila As Integer
    Dim vaPorcD As Integer = 0
    Dim notaCapturada As String
    Dim vaDescripcion, vaTipo, vafecha, vaNotas, vaFirma, vaSubmuestra, vaSubmuestrads As String



    Private Sub Cotiza_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim cn As New CapaNegocio
        Dim ds As New DataSet
        Dim dt As New DataTable

        ObtieneNumero()

        ds = cn.CargaAnalisis(1)
        dt = ds.Tables(0)
        BindingSource1.DataSource = dt
        dgFoliar.DataSource = BindingSource1
        Multi_LineGrid(dgFoliar)

        ds = cn.CargaAnalisis(2)
        dt = ds.Tables(0)
        BindingSource2.DataSource = dt
        dgTejidos.DataSource = BindingSource2
        Multi_LineGrid(dgTejidos)

        ds = cn.CargaAnalisis(3)
        dt = ds.Tables(0)
        BindingSource3.DataSource = dt
        dgAguas.DataSource = BindingSource3
        Multi_LineGrid(dgAguas)

        ds = cn.CargaAnalisis(4)
        dt = ds.Tables(0)
        BindingSource4.DataSource = dt
        dgSuelos.DataSource = BindingSource4
        Multi_LineGrid(dgSuelos)

        ds = cn.CargaAnalisis(5)
        dt = ds.Tables(0)
        BindingSource5.DataSource = dt
        dgQuimicos.DataSource = BindingSource5
        Multi_LineGrid(dgQuimicos)

        ds = cn.CargaAnalisis(6)
        dt = ds.Tables(0)
        BindingSource6.DataSource = dt
        dgOrganicos.DataSource = BindingSource6
        Multi_LineGrid(dgOrganicos)

        ds = cn.CargaAnalisis(7)
        dt = ds.Tables(0)
        BindingSource7.DataSource = dt
        dgFitopatologicos.DataSource = BindingSource7
        Multi_LineGrid(dgFitopatologicos)

        ds = cn.CargaAnalisis(8)
        dt = ds.Tables(0)
        BindingSource8.DataSource = dt
        dgOtros.DataSource = BindingSource8
        Multi_LineGrid(dgOtros)

        ds = cn.CargaNotas()
        dt = ds.Tables(0)
        BindingSource9.DataSource = dt
        dgNotasAnalisis.DataSource = BindingSource9
        Multi_LineGrid(dgNotasAnalisis)
        formatearGrillas()
        txEmpresa.AutoCompleteCustomSource = AutocompletarEmpresa()
        txEmpresa.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txEmpresa.AutoCompleteSource = AutoCompleteSource.CustomSource

        txt_notaBaja.Text = "El envío de muestras se puede realizar a través de Chilexpress o las líneas de buses,  a nombre de  AGROLAB Ltda. a nuestra dirección o con aviso al fono 225 8087. Después de realizar el envío, avise al laboratorio el nombre de la empresa de transporte y el número de la boleta del despacho realizado." + vbCrLf + vbCrLf + "Es recomendable cancelar los análisis al ingresar las muestras al laboratorio o abonar el 50% y pagar el saldo al retirar los análisis junto con la factura." + vbCrLf + vbCrLf + "Para cualquier consulta o información adicional que requiera estamos a su disposición." + vbCrLf + vbCrLf + "Sin otro particular saludan atentamente a usted,"

    End Sub
    

    Public Sub Multi_LineGrid(ByRef List As DataGridView)
        'List.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        List.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        List.DefaultCellStyle.WrapMode = DataGridViewTriState.True
    End Sub
#Region "filtros"
    Private Sub TextBox16_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox16.TextChanged
        Dim filt

        If TextBox16.Text <> "" Then
            filt = String.Format("ANA_CODIGO = '{0}'", TextBox16.Text)
            BindingSource1.Filter = filt
        Else
            BindingSource1.Filter = ""

        End If

    End Sub

    Private Sub TextBox15_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox15.TextChanged
        Dim filt

        If TextBox15.Text <> "" Then
            filt = String.Format("ANA_DESCRIPCION LIKE '%{0}%'", TextBox15.Text)
            BindingSource1.Filter = filt
        Else
            BindingSource1.Filter = ""

        End If
    End Sub

    Private Sub TextBox13_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox13.TextChanged
        Dim filt

        If TextBox13.Text <> "" Then
            filt = String.Format("ANA_CODIGO = '{0}'", TextBox13.Text)
            BindingSource2.Filter = filt
        Else
            BindingSource2.Filter = ""

        End If
    End Sub

    Private Sub TextBox14_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox14.TextChanged
        Dim filt

        If TextBox14.Text <> "" Then
            filt = String.Format("ANA_DESCRIPCION LIKE '%{0}%'", TextBox14.Text)
            BindingSource2.Filter = filt
        Else
            BindingSource2.Filter = ""

        End If
    End Sub

    Private Sub TextBox12_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox12.TextChanged
        Dim filt

        If TextBox12.Text <> "" Then
            filt = String.Format("ANA_DESCRIPCION LIKE '%{0}%'", TextBox12.Text)
            BindingSource3.Filter = filt
        Else
            BindingSource3.Filter = ""

        End If
    End Sub

    Private Sub TextBox10_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox10.TextChanged
        Dim filt

        If TextBox10.Text <> "" Then
            filt = String.Format("ANA_DESCRIPCION LIKE '%{0}%'", TextBox10.Text)
            BindingSource4.Filter = filt
        Else
            BindingSource4.Filter = ""

        End If
    End Sub

    Private Sub TextBox8_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox8.TextChanged
        Dim filt

        If TextBox8.Text <> "" Then
            filt = String.Format("ANA_DESCRIPCION LIKE '%{0}%'", TextBox8.Text)
            BindingSource5.Filter = filt
        Else
            BindingSource5.Filter = ""

        End If
    End Sub

    Private Sub TextBox6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox6.TextChanged
        Dim filt

        If TextBox6.Text <> "" Then
            filt = String.Format("ANA_DESCRIPCION LIKE '%{0}%'", TextBox6.Text)
            BindingSource6.Filter = filt
        Else
            BindingSource6.Filter = ""

        End If
    End Sub

    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.TextChanged
        Dim filt

        If TextBox4.Text <> "" Then
            filt = String.Format("ANA_DESCRIPCION LIKE '%{0}%'", TextBox4.Text)
            BindingSource7.Filter = filt
        Else
            BindingSource7.Filter = ""

        End If
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
        Dim filt

        If TextBox2.Text <> "" Then
            filt = String.Format("ANA_DESCRIPCION LIKE '%{0}%'", TextBox2.Text)
            BindingSource8.Filter = filt
        Else
            BindingSource8.Filter = ""

        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        Dim filt

        If TextBox1.Text <> "" Then
            filt = String.Format("ANA_CODIGO = '{0}'", TextBox1.Text)
            BindingSource8.Filter = filt
        Else
            BindingSource8.Filter = ""

        End If
    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged
        Dim filt

        If TextBox3.Text <> "" Then
            filt = String.Format("ANA_CODIGO = '{0}'", TextBox3.Text)
            BindingSource7.Filter = filt
        Else
            BindingSource7.Filter = ""

        End If
    End Sub

    Private Sub TextBox5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox5.TextChanged
        Dim filt

        If TextBox5.Text <> "" Then
            filt = String.Format("ANA_CODIGO = '{0}'", TextBox5.Text)
            BindingSource6.Filter = filt
        Else
            BindingSource6.Filter = ""

        End If
    End Sub

    Private Sub TextBox7_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox7.TextChanged
        Dim filt

        If TextBox7.Text <> "" Then
            filt = String.Format("ANA_CODIGO = '{0}'", TextBox7.Text)
            BindingSource5.Filter = filt
        Else
            BindingSource5.Filter = ""

        End If
    End Sub

    Private Sub TextBox9_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox9.TextChanged
        Dim filt
        If TextBox9.Text <> "" Then
            filt = String.Format("ANA_CODIGO = '{0}'", TextBox9.Text)
            BindingSource4.Filter = filt
        Else
            BindingSource4.Filter = ""
        End If
    End Sub

    Private Sub TextBox11_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox11.TextChanged
        Dim filt
        If TextBox11.Text <> "" Then
            filt = String.Format("ANA_CODIGO = '{0}'", TextBox11.Text)
            BindingSource3.Filter = filt
        Else
            BindingSource3.Filter = ""

        End If
    End Sub
#End Region
    Private Sub ObtieneNumero()
        Dim cn As New CapaNegocio
        Dim ds As New DataSet
        Dim dt As New DataTable
        ds = cn.ObtieneNumeroCotizacion
        dt = ds.Tables(0)
        lbCotizacion.Text = dt.Rows(0).Item(0).ToString + 1
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If txCantidad.Text <> "" Then
            vaCantidad = txCantidad.Text

            vaSubtotal = vaNeto * vaCantidad
            vaTotal = vaSubtotal - ((vaSubtotal * vaPorcD) / 100)
            dgCotiza.Rows.Add(vaCodigo, vaDescripcion, vaTipo, vaNeto, vaCantidad, vaSubtotal, vaPorcD, vaTotal)
            dgCotiza.Sort(dgCotiza.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
            Multi_LineGrid(dgCotiza)
            calcularTotales()
            Me.Panel18.Visible = False
        End If

    End Sub
    Private Sub calculacantidad()
        If txCantidad.Text <> "" Then
            vaCantidad = txCantidad.Text

            vaSubtotal = vaNeto * vaCantidad
            vaTotal = vaSubtotal - ((vaSubtotal * vaPorcD) / 100)
            dgCotiza.Rows.Add(vaCodigo, vaDescripcion, vaTipo, vaNeto, vaCantidad, vaSubtotal, vaPorcD, vaTotal)
            dgCotiza.Sort(dgCotiza.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
            Multi_LineGrid(dgCotiza)
            calcularTotales()
        End If
    End Sub
    Private Sub txCantidad_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txCantidad.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.Button1.Focus()
        End If
    End Sub
    Private Sub dgFoliar_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgFoliar.CellDoubleClick
        'Me.Panel18.Visible = True

        vaCodigo = dgFoliar.Rows(e.RowIndex).Cells(0).Value
        vaDescripcion = dgFoliar.Rows(e.RowIndex).Cells(1).Value.ToString()
        vaNeto = dgFoliar.Rows(e.RowIndex).Cells(2).Value
        vaTipo = dgFoliar.Rows(e.RowIndex).Cells(3).Value.ToString()

        txReciente.Text = vaDescripcion
        calculacantidad()
        ' Me.txCantidad.Focus()
    End Sub

    Private Sub dgTejidos_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgTejidos.CellDoubleClick


        vaCodigo = dgTejidos.Rows(e.RowIndex).Cells(0).Value
        vaDescripcion = dgTejidos.Rows(e.RowIndex).Cells(1).Value.ToString()
        vaNeto = dgTejidos.Rows(e.RowIndex).Cells(2).Value
        vaTipo = dgTejidos.Rows(e.RowIndex).Cells(3).Value.ToString()
        txReciente.Text = vaDescripcion
        calculacantidad()
    End Sub

    Private Sub dgAguas_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgAguas.CellDoubleClick

        vaCodigo = dgAguas.Rows(e.RowIndex).Cells(0).Value
        vaDescripcion = dgAguas.Rows(e.RowIndex).Cells(1).Value.ToString()
        vaNeto = dgAguas.Rows(e.RowIndex).Cells(2).Value
        vaTipo = dgAguas.Rows(e.RowIndex).Cells(3).Value.ToString()
        txReciente.Text = vaDescripcion

        calculacantidad()
    End Sub

    Private Sub dgFitopatologicos_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgFitopatologicos.CellDoubleClick


        vaCodigo = dgFitopatologicos.Rows(e.RowIndex).Cells(0).Value
        vaDescripcion = dgFitopatologicos.Rows(e.RowIndex).Cells(1).Value.ToString()
        vaNeto = dgFitopatologicos.Rows(e.RowIndex).Cells(2).Value
        vaTipo = dgFitopatologicos.Rows(e.RowIndex).Cells(3).Value.ToString()
        txReciente.Text = vaDescripcion

        calculacantidad()
    End Sub

    Private Sub dgOrganicos_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgOrganicos.CellDoubleClick


        vaCodigo = dgOrganicos.Rows(e.RowIndex).Cells(0).Value
        vaDescripcion = dgOrganicos.Rows(e.RowIndex).Cells(1).Value.ToString()
        vaNeto = dgOrganicos.Rows(e.RowIndex).Cells(2).Value
        vaTipo = dgOrganicos.Rows(e.RowIndex).Cells(3).Value.ToString()
        txReciente.Text = vaDescripcion

        calculacantidad()
    End Sub

    Private Sub dgOtros_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgOtros.CellDoubleClick


        vaCodigo = dgOtros.Rows(e.RowIndex).Cells(0).Value
        vaDescripcion = dgOtros.Rows(e.RowIndex).Cells(1).Value.ToString()
        vaNeto = dgOtros.Rows(e.RowIndex).Cells(2).Value
        vaTipo = dgOtros.Rows(e.RowIndex).Cells(3).Value.ToString()
        txReciente.Text = vaDescripcion

        calculacantidad()
    End Sub

    Private Sub dgQuimicos_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgQuimicos.CellDoubleClick


        vaCodigo = dgQuimicos.Rows(e.RowIndex).Cells(0).Value
        vaDescripcion = dgQuimicos.Rows(e.RowIndex).Cells(1).Value.ToString()
        vaNeto = dgQuimicos.Rows(e.RowIndex).Cells(2).Value
        vaTipo = dgQuimicos.Rows(e.RowIndex).Cells(3).Value.ToString()
        txReciente.Text = vaDescripcion

        calculacantidad()
    End Sub

    Private Sub dgSuelos_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSuelos.CellDoubleClick


        vaCodigo = dgSuelos.Rows(e.RowIndex).Cells(0).Value
        vaDescripcion = dgSuelos.Rows(e.RowIndex).Cells(1).Value.ToString()
        vaNeto = dgSuelos.Rows(e.RowIndex).Cells(2).Value
        vaTipo = dgSuelos.Rows(e.RowIndex).Cells(3).Value.ToString()
        txReciente.Text = vaDescripcion

        calculacantidad()
    End Sub

    Private Sub bnEmpresa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bnEmpresa.Click
        CotizacionesAnteriores.Show()
    End Sub
    Private Sub limpiarControles()

        txEmpresa.Text = ""
        txTelefono.Text = ""
        txEmail.Text = ""
        txAtencion.Text = ""
        txReciente.Text = ""

    End Sub
    Private Sub mostrar(ByVal dt As DataTable)

        txEmpresa.Text = dt.Rows(0).Item("PRO_FAC_RSOCIAL").ToString
        txTelefono.Text = dt.Rows(0).Item("PRO_FONO1").ToString
        txEmail.Text = dt.Rows(0).Item("PRO_EMAIL1").ToString
        txAtencion.Text = dt.Rows(0).Item("PRO_DESP_ATENCION").ToString
        txLocalidad.Text = dt.Rows(0).Item("PRO_LOCALIDAD").ToString

    End Sub

    Public Function AutocompletarEmpresa() As AutoCompleteStringCollection
        Dim cn As New CapaNegocio
        Dim dt As New DataTable
        Dim ds As New DataSet

        ds = cn.CargaEmpresas()
        dt = ds.Tables(0)


        Dim coleccion As New AutoCompleteStringCollection()
        'Recorrer y cargar los items para el Autocompletado
        For Each row As DataRow In dt.Rows
            coleccion.Add(Convert.ToString(row("PRO_FAC_RSOCIAL")))
        Next

        Return coleccion
    End Function
    Public Function AutocompletarProductor() As AutoCompleteStringCollection
        Dim cn As New CapaNegocio
        Dim dt As New DataTable
        Dim ds As New DataSet

        ds = cn.CargaEmpresas()
        dt = ds.Tables(0)


        Dim coleccion As New AutoCompleteStringCollection()
        'Recorrer y cargar los items para el Autocompletado
        For Each row As DataRow In dt.Rows
            coleccion.Add(Convert.ToString(row("PRO_PRODUCTOR")))
        Next

        Return coleccion
    End Function
    Private Sub txEmpresa_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txEmpresa.KeyUp
        If e.KeyCode = Keys.Enter Then
            If txEmpresa.Text <> "" Then
                Dim cn As New CapaNegocio
                Dim dt As New DataTable
                Dim ds As New DataSet

                ds = cn.BuscaEmpresa(txEmpresa.Text)
                dt = ds.Tables(0)

                If dt.Rows.Count <> 0 Then
                    limpiarControles()
                    mostrar(dt)
                Else
                    limpiarControles()
                End If

            End If
        End If
    End Sub



    Private Sub dgCotiza_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgCotiza.CellEndEdit

        vaNeto = dgCotiza.Rows(e.RowIndex).Cells(3).Value
        vaCantidad = dgCotiza.Rows(e.RowIndex).Cells(4).Value
        vaSubtotal = dgCotiza.Rows(e.RowIndex).Cells(5).Value
        vaPorcD = dgCotiza.Rows(e.RowIndex).Cells(6).Value
        vaTotal = dgCotiza.Rows(e.RowIndex).Cells(7).Value

        vaSubtotal = vaCantidad * vaNeto
        vaTotal = vaSubtotal - ((vaSubtotal * vaPorcD) / 100)
        dgCotiza.Rows(e.RowIndex).Cells(7).Value = vaTotal
        dgCotiza.Rows(e.RowIndex).Cells(5).Value = vaSubtotal
        'SubTotal(-((SubTotal * vaPorcD) / 100))
        calcularTotales()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim mensajeBx As String
        mensajeBx = ""

        If txEmpresa.Text = "" Then
            MsgBox("¡Falta completar el campo (Srs/Emp.)!", MsgBoxStyle.Information, "Información")
        ElseIf txEmail.Text = "" Then
            mensajeBx += "¡Falta completar el campo (Email)!"
        Else
            construirNotas()
            Try
                creo_reporte()
                'guardaCotizacion()
                'guardaCotizacionAnalisis()
                'guardaCotizacionDetalle()
                'adjuntaPDF()
            Catch ex As Exception

            End Try
            MsgBox("!Cotización N°: " & lbCotizacion.Text & " Guardada Correctamente!")
            ObtieneNumero()
            vaSubmuestra = ""
            limpiarControles()
        End If

    End Sub
    Private Sub guardaCotizacion()
        Dim cn As New CapaNegocio
        cn.GrabaCotizacion(lbCotizacion.Text, txEmpresa.Text, txEmail.Text, txAtencion.Text, txTelefono.Text, txSubTotal.Text, txTotalDescuento.Text, txTotal.Text, txIVA.Text, txTotalConIVA.Text, txFecha.Text)
    End Sub
    Private Sub guardaCotizacionAnalisis()
        Dim cn As New CapaNegocio
        For Each Row As DataGridViewRow In dgCotiza.Rows
            cn.GrabaCotizacionAnalisis(lbCotizacion.Text, Row.Cells(0).Value.ToString, Row.Cells(3).Value.ToString, Row.Cells(6).Value.ToString, Row.Cells(7).Value.ToString)
        Next

    End Sub
    Private Sub guardaCotizacionDetalle()
        Dim cn As New CapaNegocio
        For Each Row As DataGridViewRow In dgCotiza.Rows
            cn.GrabaCotizacionDetalle(lbCotizacion.Text, Row.Cells(0).Value.ToString, Row.Cells(4).Value.ToString, Row.Cells(3).Value.ToString, Row.Cells(5).Value.ToString, Row.Cells(6).Value.ToString, Row.Cells(7).Value.ToString, Row.Cells(1).Value.ToString)
        Next
    End Sub
    Private Sub construirNotas()

        vaNotas = ""
        vaNotas = vaNotas + txt_notaMedia.Text + vbCrLf + vbCrLf + txt_notaBaja.Text
        'If chConvenio.Checked = True Then
        '    vaNotas = vaNotas + "Cabe señalar que el valor de los análisis ya incluye un descuento considerando el convenio con vuestra empresa."
        'End If
        'If chTomaMuestras.Checked = True Then
        '    If vaNotas = "" Then
        '        vaNotas = "En caso de necesitar indicaciones para la toma de muestras puede solicitarlas al laboratorio o visitar nuestra pagina web (www.agrolab.cl)."
        '    Else
        '        vaNotas = vaNotas + vbNewLine + vbNewLine + "En caso de necesitar indicaciones para la toma de muestras puede solicitarlas al laboratorio o visitar nuestra pagina web (www.agrolab.cl)."
        '    End If
        'End If
        'If chOpcionesEnvio.Checked = True Then
        '    If vaNotas = "" Then
        '        vaNotas = "El envío de muestras se puede realizar a través de Chilexpress o las líneas de buses,  a nombre de  AGROLAB Ltda. a nuestra dirección o con aviso al fono 225 8087. Después de realizar el envío, avise al laboratorio el nombre de la empresa de transporte y el número de la boleta del despacho realizado."
        '    Else
        '        vaNotas = vaNotas + vbNewLine + vbNewLine + "El envío de muestras se puede realizar a través de Chilexpress o las líneas de buses,  a nombre de  AGROLAB Ltda. a nuestra dirección o con aviso al fono 225 8087. Después de realizar el envío, avise al laboratorio el nombre de la empresa de transporte y el número de la boleta del despacho realizado."
        '    End If

        'End If
        'If chRecomPago.Checked = True Then
        '    If vaNotas = "" Then
        '        vaNotas = "Es recomendable cancelar los análisis al ingresar las muestras al laboratorio o abonar el 50% y pagar el saldo al retirar los análisis junto con la factura."
        '    Else
        '        vaNotas = vaNotas + vbNewLine + vbNewLine + "Es recomendable cancelar los análisis al ingresar las muestras al laboratorio o abonar el 50% y pagar el saldo al retirar los análisis junto con la factura."
        '    End If

        'End If
        'If chSinOtro.Checked = True Then
        '    If vaNotas = "" Then
        '        vaNotas = "Ante cualquier consulta o información adicional que requiera estamos a su disposición."
        '        vaNotas = vaNotas + vbNewLine + vbNewLine + "Sin otro particular saludan atentamente a usted,"
        '    Else
        '        vaNotas = vaNotas + vbNewLine + vbNewLine + "Para cualquier consulta o información adicional que requiera estamos a su disposición."
        '        vaNotas = vaNotas + vbNewLine + vbNewLine + "Sin otro particular saludan atentamente a usted,"
        '    End If
        'End If

    End Sub
    Private Structure stColumna
        Dim MargenDerecho As Single
        Dim MargenIzquierdo As Single
    End Structure
    Sub creo_reporte()
        Dim reporte As iTextSharp.text.Document = New iTextSharp.text.Document(iTextSharp.text.PageSize.LETTER) 'tipo carta 

        Dim Frase As iTextSharp.text.Phrase
        Dim Chuck As iTextSharp.text.Chunk
        Dim Parrafo As iTextSharp.text.Paragraph
        Dim Header_Footer As iTextSharp.text.HeaderFooter
        Dim pdfw As iTextSharp.text.pdf.PdfWriter

        pdfw = iTextSharp.text.pdf.PdfWriter.GetInstance(reporte, New IO.FileStream("F:\Archivos LabSys\Cotizacion\" & lbCotizacion.Text & " - " & txEmpresa.Text & ".pdf", IO.FileMode.Create))

        Dim Tabla As iTextSharp.text.pdf.PdfPTable
        Dim Celda As iTextSharp.text.pdf.PdfPCell

        Parrafo = New iTextSharp.text.Paragraph()
        Parrafo.Alignment = iTextSharp.text.Element.ALIGN_RIGHT
        Parrafo.Leading = 10.0!

        '  Creo el encabezado
        Chuck = New iTextSharp.text.Chunk("COTIZACIÓN" & vbNewLine, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA_BOLD, 14, iTextSharp.text.Color.BLACK))
        Parrafo.Add(Chuck)

        Chuck = New iTextSharp.text.Chunk("SOCIEDAD DE SERVICIOS DE ANALISIS AGRICOLAS LTDA.", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, 10, iTextSharp.text.Color.BLACK))
        Parrafo.Add(Chuck)




        Header_Footer = New iTextSharp.text.HeaderFooter(Parrafo, False)

        Header_Footer.Alignment = iTextSharp.text.Element.ALIGN_RIGHT
        Header_Footer.Border = 0


        'aqui agrego el encabezado
        reporte.Header = Header_Footer


        'ahora agregamos un nuevo parrafo para agregar el pie de pagina
        Parrafo = New iTextSharp.text.Paragraph()
        Parrafo.Alignment = iTextSharp.text.Element.ALIGN_CENTER
        Parrafo.Leading = 8.0!

        Chuck = New iTextSharp.text.Chunk("José Domingo Cañas # 2914  -  Ñuñoa  -  Santiago  -  Teléfono: (02) 2 225 80 87  -  Email: laboratorio@agrolab.cl", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, 9, New Color(36, 65, 160)))
        Parrafo.Add(Chuck)

        Header_Footer = New iTextSharp.text.HeaderFooter(Parrafo, False)

        Header_Footer.Alignment = iTextSharp.text.Element.ALIGN_CENTER
        Header_Footer.Border = 0

        'aqui agrego el pie de pagina
        reporte.Footer = Header_Footer

        'ahora abro el documento para agregar los campos de texto
        reporte.Open()

        '********************************************

        'Dim linea As PdfContentByte 'declaración de la linea

        'linea = pdfw.DirectContent 'código necesario antes de dar coordenadas a la linea

        'linea.SetLineWidth(1) 'configurando el ancho de linea
        'linea.MoveTo(150, 750) 'MoveTo indica el punto de inicio
        'linea.LineTo(590, 750) 'LineTo indica hacia donde se dibuja la linea 
        'linea.Stroke() 'traza la linea actual y se puede iniciar una nueva

        '********************************************
        Dim jpga As Image = Image.GetInstance("F:\Mis documentos\Mis Imagenes\Logos,firmas,hojas\Logo  mediano Agro.jpg")
        jpga.ScaleAbsolute(111, 51)       'Tamaño de la imagen
        jpga.SetAbsolutePosition(25, 730) 'posiscion x, y

        reporte.Add(jpga)                 'agrego la imagen


        'TEXTO +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        Const INTERLINEADO As Single = 14
        Const MARGEN_INFERIOR As Single = 50
        Dim ct As ColumnText
        Dim arrColumnas(1) As stColumna
        Dim iEstado As Integer = 0, iColumna As Integer = 0
        Dim cb As PdfContentByte
        cb = pdfw.DirectContent
        ct = New ColumnText(cb)

        arrColumnas(0).MargenIzquierdo = 35
        arrColumnas(0).MargenDerecho = 550


        'Asignamos texto, texto y mas texto ...
        obtieneFecha()
        ct.AddText(New Phrase(vafecha & vbNewLine & vbNewLine, FontFactory.GetFont(FontFactory.HELVETICA, 10)))

        ct.AddText(New Phrase("Señor(es)    : " & txEmpresa.Text & "" & vbNewLine, FontFactory.GetFont(FontFactory.HELVETICA, 10)))
        ct.AddText(New Phrase("Atención      : " & txAtencion.Text & "" & vbNewLine, FontFactory.GetFont(FontFactory.HELVETICA, 10)))
        ct.AddText(New Phrase("Teléfono      : " & txTelefono.Text & "" & vbNewLine, FontFactory.GetFont(FontFactory.HELVETICA, 10)))
        ct.AddText(New Phrase("Email           : " & txEmail.Text & "" & vbNewLine, FontFactory.GetFont(FontFactory.HELVETICA, 10)))
        ct.AddText(New Phrase("Ref.             : Cotización N°" & lbCotizacion.Text & "" & vbNewLine & vbNewLine, FontFactory.GetFont(FontFactory.HELVETICA, 10)))

        ct.AddText(New Phrase("De nuestra consideración," & vbNewLine, FontFactory.GetFont(FontFactory.HELVETICA, 10)))
        ct.AddText(New Phrase("tenemos el agrado de presentar a ud(s)., la siguiente cotización:" & vbNewLine, FontFactory.GetFont(FontFactory.HELVETICA, 10)))
        'Mientras haya texto

        While (iEstado <> ColumnText.NO_MORE_TEXT)

            'Seteamos el rectángulo donde escribir ...
            ct.SetSimpleColumn(arrColumnas(iColumna).MargenDerecho, MARGEN_INFERIOR, arrColumnas(iColumna).MargenIzquierdo, 710, INTERLINEADO, Element.ALIGN_LEFT)

            ' ... y escribimos
            iEstado = ct.Go()

            'Si la columna no fue suficiente:
            If (iEstado = ColumnText.NO_MORE_COLUMN) Then
                iColumna = iColumna + 1

                'Si se alcanzó la cantidad de columnas por página
                If iColumna > (arrColumnas.Length - 1) Then
                    'Salto de pagina
                    reporte.NewPage()
                    iColumna = 0
                End If

            End If
        End While
        'TEXTO +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        'ENCABEZADO TABLA +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        Dim vaColor As New Color(70, 130, 180)
        Dim vaColorTexto As New Color(34, 34, 34)
        Dim vaColorTitulo As New Color(34, 34, 34)
        Dim vaColorBGTitulo As New Color(213, 244, 255)
        Dim vatamano10 = 10
        Dim vatamano9 = 9


        If chTotales.Checked = True Then

            Parrafo = New iTextSharp.text.Paragraph()
            Parrafo.SpacingAfter = 170.0F ' agrego un parrafo para que la tabla se ubique mas abajo
            reporte.Add(Parrafo)


            Tabla = New iTextSharp.text.pdf.PdfPTable(6)
            Tabla.WidthPercentage = 100.0!
            Tabla.SetWidths(New Single() {7.0!, 60.0!, 7.0!, 8.0!, 9.0!, 9.0!})

            Frase = New iTextSharp.text.Phrase("Cód.", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, iTextSharp.text.Color.WHITE))
            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
            Celda.Border = Rectangle.BOTTOM_BORDER
            Celda.BackgroundColor = vaColor
            Tabla.AddCell(Celda)

            Frase = New iTextSharp.text.Phrase("Descripción", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, iTextSharp.text.Color.WHITE))
            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
            Celda.Border = Rectangle.BOTTOM_BORDER
            Celda.BackgroundColor = vaColor
            Tabla.AddCell(Celda)

            Frase = New iTextSharp.text.Phrase("Cant.", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, iTextSharp.text.Color.WHITE))
            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
            Celda.Border = 0
            Celda.BackgroundColor = vaColor
            Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
            Tabla.AddCell(Celda)

            Frase = New iTextSharp.text.Phrase("$Unit.", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, iTextSharp.text.Color.WHITE))
            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
            Celda.Border = 0
            Celda.BackgroundColor = vaColor
            Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
            Tabla.AddCell(Celda)

            Frase = New iTextSharp.text.Phrase("Subt.", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, iTextSharp.text.Color.WHITE))
            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
            Celda.Border = 0
            Celda.BackgroundColor = vaColor
            Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
            Tabla.AddCell(Celda)

            'Frase = New iTextSharp.text.Phrase("%Dcto", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, iTextSharp.text.Color.WHITE))
            'Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
            'Celda.Border = 0
            'Celda.BackgroundColor = vaColor
            'Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
            'Tabla.AddCell(Celda)

            Frase = New iTextSharp.text.Phrase("$Total", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, iTextSharp.text.Color.WHITE))
            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
            Celda.Border = 0
            Celda.BackgroundColor = vaColor
            Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT
            Tabla.AddCell(Celda)

            reporte.Add(Tabla)
        Else

            Parrafo = New iTextSharp.text.Paragraph()
            Parrafo.SpacingAfter = 170.0F ' agrego un parrafo para que la tabla se ubique mas abajo
            reporte.Add(Parrafo)


            Tabla = New iTextSharp.text.pdf.PdfPTable(4)
            Tabla.WidthPercentage = 100.0!
            Tabla.SetWidths(New Single() {10.0!, 70.0!, 10.0!, 10.0!})

            Frase = New iTextSharp.text.Phrase("Cód.", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, iTextSharp.text.Color.WHITE))
            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
            Celda.Border = 1
            Celda.BackgroundColor = vaColor
            Tabla.AddCell(Celda)

            Frase = New iTextSharp.text.Phrase("Descripción", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, iTextSharp.text.Color.WHITE))
            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
            Celda.Border = 1
            Celda.BackgroundColor = vaColor
            Tabla.AddCell(Celda)

            Frase = New iTextSharp.text.Phrase("Cant.", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, iTextSharp.text.Color.WHITE))
            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
            Celda.Border = 1
            Celda.BackgroundColor = vaColor
            Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
            Tabla.AddCell(Celda)

            Frase = New iTextSharp.text.Phrase("$ Neto", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, iTextSharp.text.Color.WHITE))
            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
            Celda.Border = 1
            Celda.BackgroundColor = vaColor
            Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
            Tabla.AddCell(Celda)


            reporte.Add(Tabla)


        End If

        '##############################################################################

        If chTotales.Checked = True Then
            'detalle tabla +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            Tabla = New iTextSharp.text.pdf.PdfPTable(6)
            Tabla.WidthPercentage = 100.0!
            Tabla.SetWidths(New Single() {7.0!, 60.0!, 7.0!, 8.0!, 9.0!, 9.0!})


            Dim tipoCelda As Integer

            tipoCelda = 1
            Dim entroFol, entroTej, entroAgu, entroSue, entroFeq, entroFor, entroFit, entroKit, entroOtr, entroOtr2 As Integer
            entroFol = 1
            entroTej = 1
            entroAgu = 1
            entroSue = 1
            entroFeq = 1
            entroFor = 1
            entroFit = 1
            entroKit = 1
            entroOtr = 1
            entroOtr2 = 1


            For Each Row As DataGridViewRow In dgCotiza.Rows

                'If tipoCelda = 1 Then
                '    vaColor = Color.WHITE
                '    tipoCelda = 2
                'Else
                '    vaColor = New Color(233, 233, 233)
                '    tipoCelda = 1
                'End If

                vaColor = New Color(243, 249, 255)

                'descripcion
                If Row.Cells(0).Value.ToString >= 1000 And Row.Cells(0).Value.ToString <= 1999 And entroFol > 0 Then
                    entroFol = 0 'si es un titulo pinta de un color mas suave

                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)

                    'cantidad
                    Frase = New iTextSharp.text.Phrase("TEJIDOS VEGETALES", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTitulo))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)

                    'cantidad
                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)

                    'precio unitario

                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)

                    'subtotal

                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    Tabla.AddCell(Celda)

                    ''% descuento
                    'Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    'Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    'Celda.Border = 0
                    'Celda.BackgroundColor = vaColorBGTitulo
                    'Tabla.AddCell(Celda)

                    'total

                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)

                    Dim cn As New CapaNegocio
                    Dim ds As New DataSet
                    Dim dt As New DataTable
                    ds = cn.ObtieneSubMuestra(Row.Cells(0).Value.ToString)
                    dt = ds.Tables(0)


                    If dt.Rows.Count <> 0 Then
                        vaSubmuestrads = dt.Rows(0).Item(0).ToString

                        If vaSubmuestra <> vaSubmuestrads Then
                            'codigo
                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)
                            'submuestra
                            Frase = New iTextSharp.text.Phrase(vaSubmuestrads, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTitulo))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)

                            'cantidad
                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)

                            'precio unitario

                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)

                            'subtotal

                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                            Tabla.AddCell(Celda)

                            ''% descuento
                            'Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            'Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            'Celda.Border = 0
                            'Celda.BackgroundColor = vaColorBGTitulo
                            'Tabla.AddCell(Celda)

                            'total

                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)


                            vaSubmuestra = vaSubmuestrads
                        End If
                    End If

                    'ahora introcuce los datos
                    'codigo
                    Frase = New iTextSharp.text.Phrase(Row.Cells(0).Value.ToString, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT
                    Tabla.AddCell(Celda)

                    'descripcion
                    Frase = New iTextSharp.text.Phrase(Row.Cells(1).Value.ToString, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT
                    Tabla.AddCell(Celda)

                    'cantidad
                    Frase = New iTextSharp.text.Phrase(Row.Cells(4).Value.ToString, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    Tabla.AddCell(Celda)

                    'precio unitario


                    Frase = New iTextSharp.text.Phrase(Format(Row.Cells(3).Value, "####,####"), iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    Tabla.AddCell(Celda)


                    'subtotal

                    Frase = New iTextSharp.text.Phrase(Format(Row.Cells(5).Value, "####,####"), iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    Tabla.AddCell(Celda)


                    ''% descuento
                    'Frase = New iTextSharp.text.Phrase(Row.Cells(6).Value.ToString, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    'Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    'Celda.Border = 0
                    'Celda.BackgroundColor = vaColor
                    'Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    'Tabla.AddCell(Celda)

                    'total

                    Frase = New iTextSharp.text.Phrase(Format(Row.Cells(7).Value, "####,####"), iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT
                    Tabla.AddCell(Celda)

                ElseIf Row.Cells(0).Value.ToString >= 2000 And Row.Cells(0).Value.ToString <= 2999 And entroTej > 0 Then
                    entroTej = 0 'si es un titulo pinta de un color mas suave
                    'codigo
                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)

                    Frase = New iTextSharp.text.Phrase("FRUTOS", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTitulo))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)

                    'cantidad
                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)

                    'precio unitario

                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)

                    'subtotal

                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    Tabla.AddCell(Celda)

                    ''% descuento
                    'Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    'Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    'Celda.Border = 0
                    'Celda.BackgroundColor = vaColorBGTitulo
                    'Tabla.AddCell(Celda)

                    'total

                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)


                    Dim cn As New CapaNegocio
                    Dim ds As New DataSet
                    Dim dt As New DataTable
                    ds = cn.ObtieneSubMuestra(Row.Cells(0).Value.ToString)
                    dt = ds.Tables(0)


                    If dt.Rows.Count <> 0 Then
                        vaSubmuestrads = dt.Rows(0).Item(0).ToString

                        If vaSubmuestra <> vaSubmuestrads Then
                            'codigo
                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)
                            'submuestra
                            Frase = New iTextSharp.text.Phrase(vaSubmuestrads, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTitulo))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)

                            'cantidad
                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)

                            'precio unitario

                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)

                            'subtotal

                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                            Tabla.AddCell(Celda)

                            ''% descuento
                            'Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            'Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            'Celda.Border = 0
                            'Celda.BackgroundColor = vaColorBGTitulo
                            'Tabla.AddCell(Celda)

                            'total

                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)


                            vaSubmuestra = vaSubmuestrads
                        End If
                    End If

                    'ahora introcuce los datos
                    'codigo
                    Frase = New iTextSharp.text.Phrase(Row.Cells(0).Value.ToString, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT
                    Tabla.AddCell(Celda)
                    'descripcion
                    Frase = New iTextSharp.text.Phrase(Row.Cells(1).Value.ToString, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT
                    Tabla.AddCell(Celda)

                    'cantidad
                    Frase = New iTextSharp.text.Phrase(Row.Cells(4).Value.ToString, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    Tabla.AddCell(Celda)

                    'precio unitario


                    Frase = New iTextSharp.text.Phrase(Format(Row.Cells(3).Value, "####,####"), iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    Tabla.AddCell(Celda)


                    'subtotal

                    Frase = New iTextSharp.text.Phrase(Format(Row.Cells(5).Value, "####,####"), iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    Tabla.AddCell(Celda)


                    ''% descuento
                    'Frase = New iTextSharp.text.Phrase(Row.Cells(6).Value.ToString, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    'Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    'Celda.Border = 0
                    'Celda.BackgroundColor = vaColor
                    'Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    'Tabla.AddCell(Celda)

                    'total

                    Frase = New iTextSharp.text.Phrase(Format(Row.Cells(7).Value, "####,####"), iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT
                    Tabla.AddCell(Celda)

                ElseIf Row.Cells(0).Value.ToString >= 3000 And Row.Cells(0).Value.ToString <= 3999 And entroAgu > 0 Then
                    entroAgu = 0 'si es un titulo pinta de un color mas suave
                    'codigo
                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT
                    Tabla.AddCell(Celda)

                    'descripcion

                    Frase = New iTextSharp.text.Phrase("AGUAS", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTitulo))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)

                    'cantidad
                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)

                    'precio unitario

                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)

                    'subtotal

                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    Tabla.AddCell(Celda)

                    ''% descuento
                    'Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    'Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    'Celda.Border = 0
                    'Celda.BackgroundColor = vaColorBGTitulo
                    'Tabla.AddCell(Celda)

                    'total

                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)


                    Dim cn As New CapaNegocio
                    Dim ds As New DataSet
                    Dim dt As New DataTable
                    ds = cn.ObtieneSubMuestra(Row.Cells(0).Value.ToString)
                    dt = ds.Tables(0)


                    If dt.Rows.Count <> 0 Then
                        vaSubmuestrads = dt.Rows(0).Item(0).ToString

                        If vaSubmuestra <> vaSubmuestrads Then
                            'codigo
                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)
                            'submuestra
                            Frase = New iTextSharp.text.Phrase(vaSubmuestrads, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTitulo))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)

                            'cantidad
                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)

                            'precio unitario

                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)

                            'subtotal

                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                            Tabla.AddCell(Celda)

                            ''% descuento
                            'Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            'Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            'Celda.Border = 0
                            'Celda.BackgroundColor = vaColorBGTitulo
                            'Tabla.AddCell(Celda)

                            'total

                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)


                            vaSubmuestra = vaSubmuestrads
                        End If
                    End If

                    'ahora introcuce los datos
                    'codigo
                    Frase = New iTextSharp.text.Phrase(Row.Cells(0).Value.ToString, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT
                    Tabla.AddCell(Celda)

                    'descripcion
                    Frase = New iTextSharp.text.Phrase(Row.Cells(1).Value.ToString, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT
                    Tabla.AddCell(Celda)

                    'cantidad
                    Frase = New iTextSharp.text.Phrase(Row.Cells(4).Value.ToString, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    Tabla.AddCell(Celda)

                    'precio unitario


                    Frase = New iTextSharp.text.Phrase(Format(Row.Cells(3).Value, "####,####"), iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    Tabla.AddCell(Celda)


                    'subtotal

                    Frase = New iTextSharp.text.Phrase(Format(Row.Cells(5).Value, "####,####"), iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    Tabla.AddCell(Celda)


                    ''% descuento
                    'Frase = New iTextSharp.text.Phrase(Row.Cells(6).Value.ToString, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    'Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    'Celda.Border = 0
                    'Celda.BackgroundColor = vaColor
                    'Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    'Tabla.AddCell(Celda)

                    'total

                    Frase = New iTextSharp.text.Phrase(Format(Row.Cells(7).Value, "####,####"), iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT
                    Tabla.AddCell(Celda)

                ElseIf Row.Cells(0).Value.ToString >= 4000 And Row.Cells(0).Value.ToString <= 4999 And entroSue > 0 Then
                    entroSue = 0 'si es un titulo pinta de un color mas suave
                    'codigo
                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT
                    Tabla.AddCell(Celda)

                    'descripcion
                    Frase = New iTextSharp.text.Phrase("SUELOS", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTitulo))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)

                    'cantidad
                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)

                    'precio unitario

                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)

                    'subtotal

                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    Tabla.AddCell(Celda)

                    ''% descuento
                    'Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    'Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    'Celda.Border = 0
                    'Celda.BackgroundColor = vaColorBGTitulo
                    'Tabla.AddCell(Celda)

                    'total

                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)


                    Dim cn As New CapaNegocio
                    Dim ds As New DataSet
                    Dim dt As New DataTable
                    ds = cn.ObtieneSubMuestra(Row.Cells(0).Value.ToString)
                    dt = ds.Tables(0)


                    If dt.Rows.Count <> 0 Then
                        vaSubmuestrads = dt.Rows(0).Item(0).ToString

                        If vaSubmuestra <> vaSubmuestrads Then
                            'codigo
                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)
                            'submuestra
                            Frase = New iTextSharp.text.Phrase(vaSubmuestrads, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTitulo))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)
                            'cantidad
                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)

                            'precio unitario

                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)

                            'subtotal

                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                            Tabla.AddCell(Celda)

                            ''% descuento
                            'Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            'Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            'Celda.Border = 0
                            'Celda.BackgroundColor = vaColorBGTitulo
                            'Tabla.AddCell(Celda)

                            'total

                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)


                            vaSubmuestra = vaSubmuestrads
                        End If
                    End If

                    'ahora introcuce los datos
                    'codigo
                    Frase = New iTextSharp.text.Phrase(Row.Cells(0).Value.ToString, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT
                    Tabla.AddCell(Celda)

                    'descripcion
                    Frase = New iTextSharp.text.Phrase(Row.Cells(1).Value.ToString, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT
                    Tabla.AddCell(Celda)

                    'cantidad
                    Frase = New iTextSharp.text.Phrase(Row.Cells(4).Value.ToString, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    Tabla.AddCell(Celda)

                    'precio unitario


                    Frase = New iTextSharp.text.Phrase(Format(Row.Cells(3).Value, "####,####"), iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    Tabla.AddCell(Celda)


                    'subtotal

                    Frase = New iTextSharp.text.Phrase(Format(Row.Cells(5).Value, "####,####"), iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    Tabla.AddCell(Celda)


                    ''% descuento
                    'Frase = New iTextSharp.text.Phrase(Row.Cells(6).Value.ToString, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    'Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    'Celda.Border = 0
                    'Celda.BackgroundColor = vaColor
                    'Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    'Tabla.AddCell(Celda)

                    'total

                    Frase = New iTextSharp.text.Phrase(Format(Row.Cells(7).Value, "####,####"), iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT
                    Tabla.AddCell(Celda)


                ElseIf Row.Cells(0).Value.ToString >= 5000 And Row.Cells(0).Value.ToString <= 5999 And entroFeq > 0 Then
                    entroFeq = 0 'si es un titulo pinta de un color mas suave
                    'codigo
                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT
                    Tabla.AddCell(Celda)

                    'descripcion

                    Frase = New iTextSharp.text.Phrase("FERTLIZANTES QUIMICOS", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTitulo))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)

                    'cantidad
                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)

                    'precio unitario

                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)

                    'subtotal

                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    Tabla.AddCell(Celda)

                    ''% descuento
                    'Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    'Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    'Celda.Border = 0
                    'Celda.BackgroundColor = vaColorBGTitulo
                    'Tabla.AddCell(Celda)

                    'total

                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Tabla.AddCell(Celda)


                    Dim cn As New CapaNegocio
                    Dim ds As New DataSet
                    Dim dt As New DataTable
                    ds = cn.ObtieneSubMuestra(Row.Cells(0).Value.ToString)
                    dt = ds.Tables(0)


                    If dt.Rows.Count <> 0 Then
                        vaSubmuestrads = dt.Rows(0).Item(0).ToString

                        If vaSubmuestra <> vaSubmuestrads Then
                            'codigo
                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)
                            'submuestra
                            Frase = New iTextSharp.text.Phrase(vaSubmuestrads, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTitulo))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)
                            'cantidad
                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)

                            'precio unitario

                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)

                            'subtotal

                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                            Tabla.AddCell(Celda)

                            ''% descuento
                            'Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            'Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            'Celda.Border = 0
                            'Celda.BackgroundColor = vaColorBGTitulo
                            'Tabla.AddCell(Celda)

                            'total

                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)


                            vaSubmuestra = vaSubmuestrads
                        End If
                    End If

                    'ahora introcuce los datos
                    'codigo
                    Frase = New iTextSharp.text.Phrase(Row.Cells(0).Value.ToString, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT
                    Tabla.AddCell(Celda)

                    'descripcion
                    Frase = New iTextSharp.text.Phrase(Row.Cells(1).Value.ToString, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT
                    Tabla.AddCell(Celda)

                    'cantidad
                    Frase = New iTextSharp.text.Phrase(Row.Cells(4).Value.ToString, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    Tabla.AddCell(Celda)

                    'precio unitario


                    Frase = New iTextSharp.text.Phrase(Format(Row.Cells(3).Value, "####,####"), iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    Tabla.AddCell(Celda)


                    'subtotal

                    Frase = New iTextSharp.text.Phrase(Format(Row.Cells(5).Value, "####,####"), iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    Tabla.AddCell(Celda)


                    ''% descuento
                    'Frase = New iTextSharp.text.Phrase(Row.Cells(6).Value.ToString, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    'Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    'Celda.Border = 0
                    'Celda.BackgroundColor = vaColor
                    'Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    'Tabla.AddCell(Celda)

                    'total

                    Frase = New iTextSharp.text.Phrase(Format(Row.Cells(7).Value, "####,####"), iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT
                    Tabla.AddCell(Celda)


                ElseIf Row.Cells(0).Value.ToString >= 6000 And Row.Cells(0).Value.ToString <= 6999 And entroFor > 0 Then
                    entroFor = 0 'si es un titulo pinta de un color mas suave
                    'codigo
                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT
                    Tabla.AddCell(Celda)

                    'descripcion
                    Frase = New iTextSharp.text.Phrase("FERTILIZANTES ORGANICOS", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTitulo))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)

                    'cantidad
                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)

                    'precio unitario

                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)

                    'subtotal

                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    Tabla.AddCell(Celda)

                    ''% descuento
                    'Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    'Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    'Celda.Border = 0
                    'Celda.BackgroundColor = vaColorBGTitulo
                    'Tabla.AddCell(Celda)

                    'total

                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)


                    Dim cn As New CapaNegocio
                    Dim ds As New DataSet
                    Dim dt As New DataTable
                    ds = cn.ObtieneSubMuestra(Row.Cells(0).Value.ToString)
                    dt = ds.Tables(0)


                    If dt.Rows.Count <> 0 Then
                        vaSubmuestrads = dt.Rows(0).Item(0).ToString

                        If vaSubmuestra <> vaSubmuestrads Then
                            'codigo
                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)
                            'submuestra
                            Frase = New iTextSharp.text.Phrase(vaSubmuestrads, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTitulo))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)

                            'cantidad
                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)

                            'precio unitario

                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)

                            'subtotal

                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                            Tabla.AddCell(Celda)

                            ''% descuento
                            'Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            'Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            'Celda.Border = 0
                            'Celda.BackgroundColor = vaColorBGTitulo
                            'Tabla.AddCell(Celda)

                            'total

                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)


                            vaSubmuestra = vaSubmuestrads
                        End If
                    End If

                    'ahora introcuce los datos
                    'codigo
                    Frase = New iTextSharp.text.Phrase(Row.Cells(0).Value.ToString, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT
                    Tabla.AddCell(Celda)

                    'descripcion
                    Frase = New iTextSharp.text.Phrase(Row.Cells(1).Value.ToString, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT
                    Tabla.AddCell(Celda)

                    'cantidad
                    Frase = New iTextSharp.text.Phrase(Row.Cells(4).Value.ToString, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    Tabla.AddCell(Celda)

                    'precio unitario


                    Frase = New iTextSharp.text.Phrase(Format(Row.Cells(3).Value, "####,####"), iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    Tabla.AddCell(Celda)


                    'subtotal

                    Frase = New iTextSharp.text.Phrase(Format(Row.Cells(5).Value, "####,####"), iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    Tabla.AddCell(Celda)


                    ''% descuento
                    'Frase = New iTextSharp.text.Phrase(Row.Cells(6).Value.ToString, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    'Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    'Celda.Border = 0
                    'Celda.BackgroundColor = vaColor
                    'Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    'Tabla.AddCell(Celda)

                    'total

                    Frase = New iTextSharp.text.Phrase(Format(Row.Cells(7).Value, "####,####"), iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT
                    Tabla.AddCell(Celda)


                ElseIf Row.Cells(0).Value.ToString >= 7300 And Row.Cells(0).Value.ToString <= 7316 And entroFit > 0 Then
                    entroFit = 0 'si es un titulo pinta de un color mas suave
                    'codigo
                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT
                    Tabla.AddCell(Celda)

                    'descripcion
                    Frase = New iTextSharp.text.Phrase("FITOPATOLOGICOS", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTitulo))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)

                    'cantidad
                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)

                    'precio unitario

                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)

                    'subtotal

                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    Tabla.AddCell(Celda)

                    ''% descuento
                    'Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    'Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    'Celda.Border = 0
                    'Celda.BackgroundColor = vaColorBGTitulo
                    'Tabla.AddCell(Celda)

                    'total

                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)


                    Dim cn As New CapaNegocio
                    Dim ds As New DataSet
                    Dim dt As New DataTable
                    ds = cn.ObtieneSubMuestra(Row.Cells(0).Value.ToString)
                    dt = ds.Tables(0)


                    If dt.Rows.Count <> 0 Then
                        vaSubmuestrads = dt.Rows(0).Item(0).ToString

                        If vaSubmuestra <> vaSubmuestrads Then
                            'codigo
                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)
                            'submuestra
                            Frase = New iTextSharp.text.Phrase(vaSubmuestrads, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTitulo))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)

                            'cantidad
                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)

                            'precio unitario

                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)

                            'subtotal

                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                            Tabla.AddCell(Celda)

                            ''% descuento
                            'Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            'Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            'Celda.Border = 0
                            'Celda.BackgroundColor = vaColorBGTitulo
                            'Tabla.AddCell(Celda)

                            'total

                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)


                            vaSubmuestra = vaSubmuestrads
                        End If
                    End If

                    'ahora introcuce los datos
                    'codigo
                    Frase = New iTextSharp.text.Phrase(Row.Cells(0).Value.ToString, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT
                    Tabla.AddCell(Celda)

                    'descripcion
                    Frase = New iTextSharp.text.Phrase(Row.Cells(1).Value.ToString, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT
                    Tabla.AddCell(Celda)

                    'cantidad
                    Frase = New iTextSharp.text.Phrase(Row.Cells(4).Value.ToString, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    Tabla.AddCell(Celda)

                    'precio unitario


                    Frase = New iTextSharp.text.Phrase(Format(Row.Cells(3).Value, "####,####"), iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    Tabla.AddCell(Celda)


                    'subtotal

                    Frase = New iTextSharp.text.Phrase(Format(Row.Cells(5).Value, "####,####"), iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    Tabla.AddCell(Celda)


                    ''% descuento
                    'Frase = New iTextSharp.text.Phrase(Row.Cells(6).Value.ToString, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    'Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    'Celda.Border = 0
                    'Celda.BackgroundColor = vaColor
                    'Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    'Tabla.AddCell(Celda)

                    'total

                    Frase = New iTextSharp.text.Phrase(Format(Row.Cells(7).Value, "####,####"), iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT
                    Tabla.AddCell(Celda)

                ElseIf Row.Cells(0).Value.ToString >= 7000 And Row.Cells(0).Value.ToString <= 7256 And entroOtr > 0 Or Row.Cells(0).Value.ToString >= 7317 And Row.Cells(0).Value.ToString <= 7466 And entroOtr > 0 Then
                    entroOtr = 0 'si es un titulo pinta de un color mas suave

                    'codigo
                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT
                    Tabla.AddCell(Celda)

                    'descripcion
                    Frase = New iTextSharp.text.Phrase("OTROS", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTitulo))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)

                    'cantidad
                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)

                    'precio unitario

                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)

                    'subtotal

                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    Tabla.AddCell(Celda)

                    ''% descuento
                    'Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    'Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    'Celda.Border = 0
                    'Celda.BackgroundColor = vaColorBGTitulo
                    'Tabla.AddCell(Celda)

                    'total

                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)


                    Dim cn As New CapaNegocio
                    Dim ds As New DataSet
                    Dim dt As New DataTable
                    ds = cn.ObtieneSubMuestra(Row.Cells(0).Value.ToString)
                    dt = ds.Tables(0)


                    If dt.Rows.Count <> 0 Then
                        vaSubmuestrads = dt.Rows(0).Item(0).ToString

                        If vaSubmuestra <> vaSubmuestrads Then
                            'codigo
                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)
                            'submuestra
                            Frase = New iTextSharp.text.Phrase(vaSubmuestrads, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTitulo))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)

                            'cantidad
                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)

                            'precio unitario

                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)

                            'subtotal

                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                            Tabla.AddCell(Celda)

                            ''% descuento
                            'Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            'Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            'Celda.Border = 0
                            'Celda.BackgroundColor = vaColorBGTitulo
                            'Tabla.AddCell(Celda)

                            'total

                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)


                            vaSubmuestra = vaSubmuestrads
                        End If
                    End If

                    'ahora introcuce los datos
                    'codigo
                    Frase = New iTextSharp.text.Phrase(Row.Cells(0).Value.ToString, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT
                    Tabla.AddCell(Celda)

                    'descripcion
                    Frase = New iTextSharp.text.Phrase(Row.Cells(1).Value.ToString, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT
                    Tabla.AddCell(Celda)

                    'cantidad
                    Frase = New iTextSharp.text.Phrase(Row.Cells(4).Value.ToString, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    Tabla.AddCell(Celda)

                    'precio unitario


                    Frase = New iTextSharp.text.Phrase(Format(Row.Cells(3).Value, "####,####"), iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    Tabla.AddCell(Celda)


                    'subtotal

                    Frase = New iTextSharp.text.Phrase(Format(Row.Cells(5).Value, "####,####"), iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    Tabla.AddCell(Celda)


                    ''% descuento
                    'Frase = New iTextSharp.text.Phrase(Row.Cells(6).Value.ToString, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    'Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    'Celda.Border = 0
                    'Celda.BackgroundColor = vaColor
                    'Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    'Tabla.AddCell(Celda)

                    'total

                    Frase = New iTextSharp.text.Phrase(Format(Row.Cells(7).Value, "####,####"), iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT
                    Tabla.AddCell(Celda)


                ElseIf Row.Cells(0).Value.ToString >= 8000 And Row.Cells(0).Value.ToString <= 8356 And entroKit > 0 Then
                    entroKit = 0 'si es un titulo pinta de un color mas suave

                    'codigo
                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT
                    Tabla.AddCell(Celda)

                    'descripcion

                    Frase = New iTextSharp.text.Phrase("KITS", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTitulo))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)

                    'cantidad
                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)

                    'precio unitario

                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)

                    'subtotal

                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    Tabla.AddCell(Celda)

                    ''% descuento
                    'Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    'Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    'Celda.Border = 0
                    'Celda.BackgroundColor = vaColorBGTitulo
                    'Tabla.AddCell(Celda)

                    'total

                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)


                    Dim cn As New CapaNegocio
                    Dim ds As New DataSet
                    Dim dt As New DataTable
                    ds = cn.ObtieneSubMuestra(Row.Cells(0).Value.ToString)
                    dt = ds.Tables(0)


                    If dt.Rows.Count <> 0 Then
                        vaSubmuestrads = dt.Rows(0).Item(0).ToString

                        If vaSubmuestra <> vaSubmuestrads Then
                            'codigo
                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)
                            'submuestra
                            Frase = New iTextSharp.text.Phrase(vaSubmuestrads, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTitulo))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)

                            'cantidad
                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)

                            'precio unitario

                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)

                            'subtotal

                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                            Tabla.AddCell(Celda)

                            ''% descuento
                            'Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            'Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            'Celda.Border = 0
                            'Celda.BackgroundColor = vaColorBGTitulo
                            'Tabla.AddCell(Celda)

                            'total

                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)


                            vaSubmuestra = vaSubmuestrads
                        End If
                    End If

                    'ahora introcuce los datos
                    'codigo
                    Frase = New iTextSharp.text.Phrase(Row.Cells(0).Value.ToString, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT
                    Tabla.AddCell(Celda)

                    'descripcion
                    Frase = New iTextSharp.text.Phrase(Row.Cells(1).Value.ToString, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT
                    Tabla.AddCell(Celda)

                    'cantidad
                    Frase = New iTextSharp.text.Phrase(Row.Cells(4).Value.ToString, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    Tabla.AddCell(Celda)

                    'precio unitario


                    Frase = New iTextSharp.text.Phrase(Format(Row.Cells(3).Value, "####,####"), iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    Tabla.AddCell(Celda)


                    'subtotal

                    Frase = New iTextSharp.text.Phrase(Format(Row.Cells(5).Value, "####,####"), iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    Tabla.AddCell(Celda)


                    ''% descuento
                    'Frase = New iTextSharp.text.Phrase(Row.Cells(6).Value.ToString, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    'Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    'Celda.Border = 0
                    'Celda.BackgroundColor = vaColor
                    'Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    'Tabla.AddCell(Celda)

                    'total

                    Frase = New iTextSharp.text.Phrase(Format(Row.Cells(7).Value, "####,####"), iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT
                    Tabla.AddCell(Celda)


                ElseIf Row.Cells(0).Value.ToString >= 8357 And Row.Cells(0).Value.ToString <= 9000 And entroOtr2 > 0 Then
                    entroOtr2 = 0 'si es un titulo pinta de un color mas suave
                    'codigo
                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT
                    Tabla.AddCell(Celda)

                    'descripcion

                    Frase = New iTextSharp.text.Phrase("OTROS", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTitulo))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)

                    'cantidad
                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)

                    'precio unitario

                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)

                    'subtotal

                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    Tabla.AddCell(Celda)

                    ''% descuento
                    'Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    'Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    'Celda.Border = 0
                    'Celda.BackgroundColor = vaColorBGTitulo
                    'Tabla.AddCell(Celda)

                    'total

                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)


                    Dim cn As New CapaNegocio
                    Dim ds As New DataSet
                    Dim dt As New DataTable
                    ds = cn.ObtieneSubMuestra(Row.Cells(0).Value.ToString)
                    dt = ds.Tables(0)


                    If dt.Rows.Count <> 0 Then
                        vaSubmuestrads = dt.Rows(0).Item(0).ToString

                        If vaSubmuestra <> vaSubmuestrads Then
                            'codigo
                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)
                            'submuestra
                            Frase = New iTextSharp.text.Phrase(vaSubmuestrads, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTitulo))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)

                            'cantidad
                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)

                            'precio unitario

                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)

                            'subtotal

                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                            Tabla.AddCell(Celda)

                            ''% descuento
                            'Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            'Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            'Celda.Border = 0
                            'Celda.BackgroundColor = vaColorBGTitulo
                            'Tabla.AddCell(Celda)

                            'total

                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)


                            vaSubmuestra = vaSubmuestrads
                        End If
                    End If

                    'ahora introcuce los datos
                    'codigo
                    Frase = New iTextSharp.text.Phrase(Row.Cells(0).Value.ToString, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT
                    Tabla.AddCell(Celda)

                    'descripcion
                    Frase = New iTextSharp.text.Phrase(Row.Cells(1).Value.ToString, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT
                    Tabla.AddCell(Celda)

                    'cantidad
                    Frase = New iTextSharp.text.Phrase(Row.Cells(4).Value.ToString, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    Tabla.AddCell(Celda)

                    'precio unitario


                    Frase = New iTextSharp.text.Phrase(Format(Row.Cells(3).Value, "####,####"), iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    Tabla.AddCell(Celda)


                    'subtotal

                    Frase = New iTextSharp.text.Phrase(Format(Row.Cells(5).Value, "####,####"), iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    Tabla.AddCell(Celda)


                    ''% descuento
                    'Frase = New iTextSharp.text.Phrase(Row.Cells(6).Value.ToString, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    'Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    'Celda.Border = 0
                    'Celda.BackgroundColor = vaColor
                    'Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    'Tabla.AddCell(Celda)

                    'total

                    Frase = New iTextSharp.text.Phrase(Format(Row.Cells(7).Value, "####,####"), iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT
                    Tabla.AddCell(Celda)
                Else

                    Dim cn As New CapaNegocio
                    Dim ds As New DataSet
                    Dim dt As New DataTable
                    ds = cn.ObtieneSubMuestra(Row.Cells(0).Value.ToString)
                    dt = ds.Tables(0)


                    If dt.Rows.Count <> 0 Then
                        vaSubmuestrads = dt.Rows(0).Item(0).ToString

                        If vaSubmuestra <> vaSubmuestrads Then
                            'codigo
                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)
                            'submuestra
                            Frase = New iTextSharp.text.Phrase(vaSubmuestrads, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTitulo))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)
                            'cantidad
                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)

                            'precio unitario

                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)

                            'subtotal

                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                            Tabla.AddCell(Celda)

                            ''% descuento
                            'Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            'Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            'Celda.Border = 0
                            'Celda.BackgroundColor = vaColorBGTitulo
                            'Tabla.AddCell(Celda)

                            'total

                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)


                            vaSubmuestra = vaSubmuestrads
                        End If
                    End If

                    'codigo
                    Frase = New iTextSharp.text.Phrase(Row.Cells(0).Value.ToString, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT
                    Tabla.AddCell(Celda)

                    'descripcion
                    Frase = New iTextSharp.text.Phrase(Row.Cells(1).Value.ToString, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT
                    Tabla.AddCell(Celda)

                    'cantidad
                    Frase = New iTextSharp.text.Phrase(Row.Cells(4).Value.ToString, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    Tabla.AddCell(Celda)

                    'precio unitario

                    Frase = New iTextSharp.text.Phrase(Format(Row.Cells(3).Value, "####,####"), iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    Tabla.AddCell(Celda)

                    'subtotal

                    Frase = New iTextSharp.text.Phrase(Format(Row.Cells(5).Value, "####,####"), iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    Tabla.AddCell(Celda)


                    ''% descuento
                    'Frase = New iTextSharp.text.Phrase(Row.Cells(6).Value.ToString, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    'Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    'Celda.Border = 0
                    'Celda.BackgroundColor = vaColor
                    'Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    'Tabla.AddCell(Celda)

                    'total

                    Frase = New iTextSharp.text.Phrase(Format(Row.Cells(7).Value, "####,####"), iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT
                    Tabla.AddCell(Celda)

                End If

            Next
            reporte.Add(Tabla)

            'totales +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            vaColor = Color.WHITE
            vaColorTexto = Color.BLACK

            Tabla = New iTextSharp.text.pdf.PdfPTable(3)
            Tabla.WidthPercentage = 100.0!
            Tabla.SetWidths(New Single() {82.0!, 9.0!, 9.0!})
            ''subtotal
            'Frase = New iTextSharp.text.Phrase(" ", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTexto))
            'Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
            'Celda.Border = 1
            'Celda.BackgroundColor = vaColor
            'Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT
            'Tabla.AddCell(Celda)

            'Frase = New iTextSharp.text.Phrase("Subtotal ", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTexto))
            'Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
            'Celda.Border = 1
            'Celda.BackgroundColor = vaColor
            'Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT
            'Tabla.AddCell(Celda)

            'Frase = New iTextSharp.text.Phrase(Format(CInt(txSubTotal.Text), "####,####"), iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTexto))
            'Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
            'Celda.Border = 1
            'Celda.BackgroundColor = vaColor
            'Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT
            'Tabla.AddCell(Celda)


            ''Descuento
            'Frase = New iTextSharp.text.Phrase(" ", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTexto))
            'Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
            'Celda.Border = 0
            'Celda.BackgroundColor = vaColor
            'Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT
            'Tabla.AddCell(Celda)

            'Frase = New iTextSharp.text.Phrase("Descuento ", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTexto))
            'Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
            'Celda.Border = 0
            'Celda.BackgroundColor = vaColor
            'Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT
            'Tabla.AddCell(Celda)

            'If txTotalDescuento.Text <> 0 Then
            '    Frase = New iTextSharp.text.Phrase(Format(CInt(txTotalDescuento.Text), "####,####"), iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTexto))
            '    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
            '    Celda.Border = 0
            '    Celda.BackgroundColor = vaColor
            '    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT
            '    Tabla.AddCell(Celda)
            'Else
            '    Frase = New iTextSharp.text.Phrase("0", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTexto))
            '    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
            '    Celda.Border = 0
            '    Celda.BackgroundColor = vaColor
            '    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT
            '    Tabla.AddCell(Celda)
            'End If


            'Neto
            Frase = New iTextSharp.text.Phrase(" ", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTexto))
            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
            Celda.Border = 0
            Celda.BackgroundColor = vaColor
            Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT
            Tabla.AddCell(Celda)

            Frase = New iTextSharp.text.Phrase("Neto ", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTexto))
            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
            Celda.Border = 0
            Celda.BackgroundColor = vaColor
            Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT
            Tabla.AddCell(Celda)

            Frase = New iTextSharp.text.Phrase(Format(CInt(txTotal.Text), "####,####"), iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTexto))
            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
            Celda.Border = 0
            Celda.BackgroundColor = vaColor
            Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT
            Tabla.AddCell(Celda)


            'IVA
            Frase = New iTextSharp.text.Phrase(" ", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTexto))
            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
            Celda.Border = 0
            Celda.BackgroundColor = vaColor
            Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT
            Tabla.AddCell(Celda)

            Frase = New iTextSharp.text.Phrase("IVA ", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTexto))
            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
            Celda.Border = 0
            Celda.BackgroundColor = vaColor
            Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT
            Tabla.AddCell(Celda)

            Frase = New iTextSharp.text.Phrase(Format(CInt(txIVA.Text), "####,####"), iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTexto))
            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
            Celda.Border = 0
            Celda.BackgroundColor = vaColor
            Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT
            Tabla.AddCell(Celda)

            'TOTAL
            Frase = New iTextSharp.text.Phrase(" ", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTexto))
            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
            Celda.Border = 0
            Celda.BackgroundColor = vaColor
            Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT
            Tabla.AddCell(Celda)

            Frase = New iTextSharp.text.Phrase("Total $", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTexto))
            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
            Celda.Border = 0
            Celda.BackgroundColor = vaColor
            Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT
            Tabla.AddCell(Celda)

            Frase = New iTextSharp.text.Phrase(Format(CInt(txTotalConIVA.Text), "####,####"), iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTexto))
            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
            Celda.Border = 0
            Celda.BackgroundColor = vaColor
            Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT
            Tabla.AddCell(Celda)


            reporte.Add(Tabla)
            ' FIN TABLA +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        Else         ' SIN TOTALES ##############################################################################
            'detalle tabla +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            Tabla = New iTextSharp.text.pdf.PdfPTable(4)
            Tabla.WidthPercentage = 100.0!
            Tabla.SetWidths(New Single() {10.0!, 70.0!, 10.0!, 10.0!})


            Dim tipoCelda As Integer

            tipoCelda = 1
            Dim entroFol, entroTej, entroAgu, entroSue, entroFeq, entroFor, entroFit, entroKit, entroOtr, entroOtr2 As Integer
            entroFol = 1
            entroTej = 1
            entroAgu = 1
            entroSue = 1
            entroFeq = 1
            entroFor = 1
            entroFit = 1
            entroKit = 1
            entroOtr = 1
            entroOtr2 = 1


            For Each Row As DataGridViewRow In dgCotiza.Rows

                'If tipoCelda = 1 Then
                '    vaColor = Color.WHITE
                '    tipoCelda = 2
                'Else
                '    vaColor = New Color(233, 233, 233)
                '    tipoCelda = 1
                'End If

                vaColor = New Color(243, 249, 255)

                'descripcion
                If Row.Cells(0).Value.ToString >= 1000 And Row.Cells(0).Value.ToString <= 1999 And entroFol > 0 Then
                    entroFol = 0 'si es un titulo pinta de un color mas suave
                    'codigo
                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)

                    'descripcion
                    Frase = New iTextSharp.text.Phrase("TEJIDOS VEGETALES", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTitulo))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)

                    'cantidad
                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)

                    'precio unitario

                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)

                    Dim cn As New CapaNegocio
                    Dim ds As New DataSet
                    Dim dt As New DataTable
                    ds = cn.ObtieneSubMuestra(Row.Cells(0).Value.ToString)
                    dt = ds.Tables(0)


                    If dt.Rows.Count <> 0 Then
                        vaSubmuestrads = dt.Rows(0).Item(0).ToString

                        If vaSubmuestra <> vaSubmuestrads Then
                            'codigo
                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)

                            'submuestra
                            Frase = New iTextSharp.text.Phrase(vaSubmuestrads, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTitulo))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)

                            'cantidad
                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)

                            'precio Neto con descuento

                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)




                            vaSubmuestra = vaSubmuestrads
                        End If
                    End If

                    'ahora introcuce los datos
                    'codigo
                    Frase = New iTextSharp.text.Phrase(Row.Cells(0).Value.ToString, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT
                    Tabla.AddCell(Celda)

                    'descripcion
                    Frase = New iTextSharp.text.Phrase(Row.Cells(1).Value.ToString, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT
                    Tabla.AddCell(Celda)

                    'cantidad
                    Frase = New iTextSharp.text.Phrase(Row.Cells(4).Value.ToString, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    Tabla.AddCell(Celda)

                    'precio Neto con descuento

                    Frase = New iTextSharp.text.Phrase(Format(Row.Cells(7).Value, "####,####"), iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    Tabla.AddCell(Celda)


                ElseIf Row.Cells(0).Value.ToString >= 2000 And Row.Cells(0).Value.ToString <= 2999 And entroTej > 0 Then
                    entroTej = 0 'si es un titulo pinta de un color mas suave
                    'codigo
                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)

                    'descripcion
                    Frase = New iTextSharp.text.Phrase("FRUTOS", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTitulo))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)

                    'cantidad
                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)

                    'precio unitario

                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)

                    Dim cn As New CapaNegocio
                    Dim ds As New DataSet
                    Dim dt As New DataTable
                    ds = cn.ObtieneSubMuestra(Row.Cells(0).Value.ToString)
                    dt = ds.Tables(0)


                    If dt.Rows.Count <> 0 Then
                        vaSubmuestrads = dt.Rows(0).Item(0).ToString

                        If vaSubmuestra <> vaSubmuestrads Then
                            'codigo
                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)

                            'submuestra
                            Frase = New iTextSharp.text.Phrase(vaSubmuestrads, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTitulo))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)

                            'cantidad
                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)

                            'precio Neto con descuento

                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)




                            vaSubmuestra = vaSubmuestrads
                        End If
                    End If

                    'ahora introcuce los datos
                    'codigo
                    Frase = New iTextSharp.text.Phrase(Row.Cells(0).Value.ToString, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT
                    Tabla.AddCell(Celda)

                    'descripcion
                    Frase = New iTextSharp.text.Phrase(Row.Cells(1).Value.ToString, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT
                    Tabla.AddCell(Celda)

                    'cantidad
                    Frase = New iTextSharp.text.Phrase(Row.Cells(4).Value.ToString, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    Tabla.AddCell(Celda)

                    'precio Neto con descuento

                    Frase = New iTextSharp.text.Phrase(Format(Row.Cells(7).Value, "####,####"), iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    Tabla.AddCell(Celda)


                ElseIf Row.Cells(0).Value.ToString >= 3000 And Row.Cells(0).Value.ToString <= 3999 And entroAgu > 0 Then
                    entroAgu = 0 'si es un titulo pinta de un color mas suave
                    'codigo
                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)

                    'descripcion
                    Frase = New iTextSharp.text.Phrase("AGUAS", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTitulo))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)

                    'cantidad
                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)

                    'precio unitario

                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)

                    Dim cn As New CapaNegocio
                    Dim ds As New DataSet
                    Dim dt As New DataTable
                    ds = cn.ObtieneSubMuestra(Row.Cells(0).Value.ToString)
                    dt = ds.Tables(0)


                    If dt.Rows.Count <> 0 Then
                        vaSubmuestrads = dt.Rows(0).Item(0).ToString

                        If vaSubmuestra <> vaSubmuestrads Then
                            'codigo
                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)

                            'submuestra
                            Frase = New iTextSharp.text.Phrase(vaSubmuestrads, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTitulo))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)

                            'cantidad
                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)

                            'precio Neto con descuento

                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)




                            vaSubmuestra = vaSubmuestrads
                        End If
                    End If

                    'ahora introcuce los datos
                    'codigo
                    Frase = New iTextSharp.text.Phrase(Row.Cells(0).Value.ToString, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT
                    Tabla.AddCell(Celda)

                    'descripcion
                    Frase = New iTextSharp.text.Phrase(Row.Cells(1).Value.ToString, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT
                    Tabla.AddCell(Celda)

                    'cantidad
                    Frase = New iTextSharp.text.Phrase(Row.Cells(4).Value.ToString, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    Tabla.AddCell(Celda)


                    'precio Neto con descuento


                    Frase = New iTextSharp.text.Phrase(Format(Row.Cells(7).Value, "####,####"), iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    Tabla.AddCell(Celda)




                ElseIf Row.Cells(0).Value.ToString >= 4000 And Row.Cells(0).Value.ToString <= 4999 And entroSue > 0 Then
                    entroSue = 0 'si es un titulo pinta de un color mas suave
                    'codigo
                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)

                    'descripcion
                    Frase = New iTextSharp.text.Phrase("SUELOS", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTitulo))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)

                    'cantidad
                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)

                    'precio unitario

                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)

                    Dim cn As New CapaNegocio
                    Dim ds As New DataSet
                    Dim dt As New DataTable
                    ds = cn.ObtieneSubMuestra(Row.Cells(0).Value.ToString)
                    dt = ds.Tables(0)


                    If dt.Rows.Count <> 0 Then
                        vaSubmuestrads = dt.Rows(0).Item(0).ToString

                        If vaSubmuestra <> vaSubmuestrads Then
                            'codigo
                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)

                            'submuestra
                            Frase = New iTextSharp.text.Phrase(vaSubmuestrads, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTitulo))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)

                            'cantidad
                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)

                            'precio Neto con descuento

                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)




                            vaSubmuestra = vaSubmuestrads
                        End If
                    End If
                    'ahora introcuce los datos
                    'codigo
                    Frase = New iTextSharp.text.Phrase(Row.Cells(0).Value.ToString, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT
                    Tabla.AddCell(Celda)

                    'descripcion
                    Frase = New iTextSharp.text.Phrase(Row.Cells(1).Value.ToString, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT
                    Tabla.AddCell(Celda)

                    'cantidad
                    Frase = New iTextSharp.text.Phrase(Row.Cells(4).Value.ToString, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    Tabla.AddCell(Celda)


                    'precio Neto con descuento


                    Frase = New iTextSharp.text.Phrase(Format(Row.Cells(7).Value, "####,####"), iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    Tabla.AddCell(Celda)




                ElseIf Row.Cells(0).Value.ToString >= 5000 And Row.Cells(0).Value.ToString <= 5999 And entroFeq > 0 Then
                    entroFeq = 0 'si es un titulo pinta de un color mas suave
                    'codigo
                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)

                    'descripcion
                    Frase = New iTextSharp.text.Phrase("FERTILIZANTES QUIMICOS", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTitulo))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)

                    'cantidad
                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)

                    'precio unitario

                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)


                    Dim cn As New CapaNegocio
                    Dim ds As New DataSet
                    Dim dt As New DataTable
                    ds = cn.ObtieneSubMuestra(Row.Cells(0).Value.ToString)
                    dt = ds.Tables(0)


                    If dt.Rows.Count <> 0 Then
                        vaSubmuestrads = dt.Rows(0).Item(0).ToString

                        If vaSubmuestra <> vaSubmuestrads Then
                            'codigo
                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)

                            'submuestra
                            Frase = New iTextSharp.text.Phrase(vaSubmuestrads, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTitulo))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)

                            'cantidad
                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)

                            'precio Neto con descuento

                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)




                            vaSubmuestra = vaSubmuestrads
                        End If
                    End If
                    'ahora introcuce los datos
                    'codigo
                    Frase = New iTextSharp.text.Phrase(Row.Cells(0).Value.ToString, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT
                    Tabla.AddCell(Celda)

                    'descripcion
                    Frase = New iTextSharp.text.Phrase(Row.Cells(1).Value.ToString, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT
                    Tabla.AddCell(Celda)

                    'cantidad
                    Frase = New iTextSharp.text.Phrase(Row.Cells(4).Value.ToString, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    Tabla.AddCell(Celda)


                    'precio Neto con descuento


                    Frase = New iTextSharp.text.Phrase(Format(Row.Cells(7).Value, "####,####"), iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    Tabla.AddCell(Celda)





                ElseIf Row.Cells(0).Value.ToString >= 6000 And Row.Cells(0).Value.ToString <= 6999 And entroFor > 0 Then
                    entroFor = 0 'si es un titulo pinta de un color mas suave
                    'codigo
                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)

                    'descripcion
                    Frase = New iTextSharp.text.Phrase("FERTILIZANTES ORGANICOS", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTitulo))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)

                    'cantidad
                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)

                    'precio unitario

                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)


                    Dim cn As New CapaNegocio
                    Dim ds As New DataSet
                    Dim dt As New DataTable
                    ds = cn.ObtieneSubMuestra(Row.Cells(0).Value.ToString)
                    dt = ds.Tables(0)


                    If dt.Rows.Count <> 0 Then
                        vaSubmuestrads = dt.Rows(0).Item(0).ToString

                        If vaSubmuestra <> vaSubmuestrads Then
                            'codigo
                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)

                            'submuestra
                            Frase = New iTextSharp.text.Phrase(vaSubmuestrads, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTitulo))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)

                            'cantidad
                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)

                            'precio Neto con descuento

                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)




                            vaSubmuestra = vaSubmuestrads
                        End If
                    End If

                    'ahora introcuce los datos
                    'codigo
                    Frase = New iTextSharp.text.Phrase(Row.Cells(0).Value.ToString, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT
                    Tabla.AddCell(Celda)

                    'descripcion
                    Frase = New iTextSharp.text.Phrase(Row.Cells(1).Value.ToString, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT
                    Tabla.AddCell(Celda)

                    'cantidad
                    Frase = New iTextSharp.text.Phrase(Row.Cells(4).Value.ToString, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    Tabla.AddCell(Celda)


                    'precio Neto con descuento


                    Frase = New iTextSharp.text.Phrase(Format(Row.Cells(7).Value, "####,####"), iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    Tabla.AddCell(Celda)



                ElseIf Row.Cells(0).Value.ToString >= 7300 And Row.Cells(0).Value.ToString <= 7316 And entroFit > 0 Then
                    entroFit = 0 'si es un titulo pinta de un color mas suave
                    'codigo
                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)

                    'descripcion
                    Frase = New iTextSharp.text.Phrase("FITOPATOLOGICOS", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTitulo))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)

                    'cantidad
                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)

                    'precio unitario

                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)


                    Dim cn As New CapaNegocio
                    Dim ds As New DataSet
                    Dim dt As New DataTable
                    ds = cn.ObtieneSubMuestra(Row.Cells(0).Value.ToString)
                    dt = ds.Tables(0)


                    If dt.Rows.Count <> 0 Then
                        vaSubmuestrads = dt.Rows(0).Item(0).ToString

                        If vaSubmuestra <> vaSubmuestrads Then
                            'codigo
                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)

                            'submuestra
                            Frase = New iTextSharp.text.Phrase(vaSubmuestrads, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTitulo))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)

                            'cantidad
                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)

                            'precio Neto con descuento

                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)




                            vaSubmuestra = vaSubmuestrads
                        End If
                    End If
                    'ahora introcuce los datos
                    'codigo
                    Frase = New iTextSharp.text.Phrase(Row.Cells(0).Value.ToString, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT
                    Tabla.AddCell(Celda)

                    'descripcion
                    Frase = New iTextSharp.text.Phrase(Row.Cells(1).Value.ToString, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT
                    Tabla.AddCell(Celda)

                    'cantidad
                    Frase = New iTextSharp.text.Phrase(Row.Cells(4).Value.ToString, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    Tabla.AddCell(Celda)


                    'precio Neto con descuento


                    Frase = New iTextSharp.text.Phrase(Format(Row.Cells(7).Value, "####,####"), iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    Tabla.AddCell(Celda)




                ElseIf Row.Cells(0).Value.ToString >= 7000 And Row.Cells(0).Value.ToString <= 7256 And entroOtr > 0 Or Row.Cells(0).Value.ToString >= 7317 And Row.Cells(0).Value.ToString <= 7466 And entroOtr > 0 Then
                    entroOtr = 0 'si es un titulo pinta de un color mas suave
                    'codigo
                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)

                    'descripcion
                    Frase = New iTextSharp.text.Phrase("OTROS", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTitulo))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)

                    'cantidad
                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)

                    'precio unitario

                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)


                    Dim cn As New CapaNegocio
                    Dim ds As New DataSet
                    Dim dt As New DataTable
                    ds = cn.ObtieneSubMuestra(Row.Cells(0).Value.ToString)
                    dt = ds.Tables(0)


                    If dt.Rows.Count <> 0 Then
                        vaSubmuestrads = dt.Rows(0).Item(0).ToString

                        If vaSubmuestra <> vaSubmuestrads Then
                            'codigo
                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)

                            'submuestra
                            Frase = New iTextSharp.text.Phrase(vaSubmuestrads, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTitulo))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)

                            'cantidad
                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)

                            'precio Neto con descuento

                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)




                            vaSubmuestra = vaSubmuestrads
                        End If
                    End If
                    'ahora introcuce los datos
                    'codigo
                    Frase = New iTextSharp.text.Phrase(Row.Cells(0).Value.ToString, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT
                    Tabla.AddCell(Celda)

                    'descripcion
                    Frase = New iTextSharp.text.Phrase(Row.Cells(1).Value.ToString, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT
                    Tabla.AddCell(Celda)

                    'cantidad
                    Frase = New iTextSharp.text.Phrase(Row.Cells(4).Value.ToString, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    Tabla.AddCell(Celda)


                    'precio Neto con descuento


                    Frase = New iTextSharp.text.Phrase(Format(Row.Cells(7).Value, "####,####"), iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    Tabla.AddCell(Celda)





                ElseIf Row.Cells(0).Value.ToString >= 8000 And Row.Cells(0).Value.ToString <= 8356 And entroKit > 0 Then
                    entroKit = 0 'si es un titulo pinta de un color mas suave
                    'codigo
                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)

                    'descripcion
                    Frase = New iTextSharp.text.Phrase("KITS", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTitulo))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)

                    'cantidad
                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)

                    'precio unitario

                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)


                    Dim cn As New CapaNegocio
                    Dim ds As New DataSet
                    Dim dt As New DataTable
                    ds = cn.ObtieneSubMuestra(Row.Cells(0).Value.ToString)
                    dt = ds.Tables(0)


                    If dt.Rows.Count <> 0 Then
                        vaSubmuestrads = dt.Rows(0).Item(0).ToString

                        If vaSubmuestra <> vaSubmuestrads Then
                            'codigo
                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)

                            'submuestra
                            Frase = New iTextSharp.text.Phrase(vaSubmuestrads, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTitulo))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)

                            'cantidad
                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)

                            'precio Neto con descuento

                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)




                            vaSubmuestra = vaSubmuestrads
                        End If
                    End If
                    'ahora introcuce los datos
                    'codigo
                    Frase = New iTextSharp.text.Phrase(Row.Cells(0).Value.ToString, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT
                    Tabla.AddCell(Celda)

                    'descripcion
                    Frase = New iTextSharp.text.Phrase(Row.Cells(1).Value.ToString, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT
                    Tabla.AddCell(Celda)

                    'cantidad
                    Frase = New iTextSharp.text.Phrase(Row.Cells(4).Value.ToString, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    Tabla.AddCell(Celda)


                    'precio Neto con descuento


                    Frase = New iTextSharp.text.Phrase(Format(Row.Cells(7).Value, "####,####"), iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    Tabla.AddCell(Celda)




                ElseIf Row.Cells(0).Value.ToString >= 8357 And Row.Cells(0).Value.ToString <= 9000 And entroOtr2 > 0 Then
                    entroOtr2 = 0 'si es un titulo pinta de un color mas suave
                    'codigo
                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)

                    'descripcion
                    Frase = New iTextSharp.text.Phrase("OTROS", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTitulo))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)

                    'cantidad
                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)

                    'precio unitario

                    Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColorBGTitulo
                    Tabla.AddCell(Celda)

                    Dim cn As New CapaNegocio
                    Dim ds As New DataSet
                    Dim dt As New DataTable
                    ds = cn.ObtieneSubMuestra(Row.Cells(0).Value.ToString)
                    dt = ds.Tables(0)


                    If dt.Rows.Count <> 0 Then
                        vaSubmuestrads = dt.Rows(0).Item(0).ToString

                        If vaSubmuestra <> vaSubmuestrads Then
                            'codigo
                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)

                            'submuestra
                            Frase = New iTextSharp.text.Phrase(vaSubmuestrads, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTitulo))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)

                            'cantidad
                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)

                            'precio Neto con descuento

                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)




                            vaSubmuestra = vaSubmuestrads
                        End If
                    End If

                    'ahora introcuce los datos
                    'codigo
                    Frase = New iTextSharp.text.Phrase(Row.Cells(0).Value.ToString, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT
                    Tabla.AddCell(Celda)

                    'descripcion
                    Frase = New iTextSharp.text.Phrase(Row.Cells(1).Value.ToString, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT
                    Tabla.AddCell(Celda)

                    'cantidad
                    Frase = New iTextSharp.text.Phrase(Row.Cells(4).Value.ToString, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    Tabla.AddCell(Celda)

                    'precio Neto con descuento

                    Frase = New iTextSharp.text.Phrase(Format(Row.Cells(7).Value, "####,####"), iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    Tabla.AddCell(Celda)



                Else
                    Dim cn As New CapaNegocio
                    Dim ds As New DataSet
                    Dim dt As New DataTable
                    ds = cn.ObtieneSubMuestra(Row.Cells(0).Value.ToString)
                    dt = ds.Tables(0)


                    If dt.Rows.Count <> 0 Then
                        vaSubmuestrads = dt.Rows(0).Item(0).ToString

                        If vaSubmuestra <> vaSubmuestrads Then
                            'codigo
                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)

                            'submuestra
                            Frase = New iTextSharp.text.Phrase(vaSubmuestrads, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTitulo))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)

                            'cantidad
                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)

                            'precio Neto con descuento

                            Frase = New iTextSharp.text.Phrase("", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                            Celda.Border = 0
                            Celda.BackgroundColor = vaColorBGTitulo
                            Tabla.AddCell(Celda)




                            vaSubmuestra = vaSubmuestrads
                        End If
                    End If
                    'descripcion
                    Frase = New iTextSharp.text.Phrase(Row.Cells(1).Value.ToString, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano9, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT
                    Tabla.AddCell(Celda)

                    'cantidad
                    Frase = New iTextSharp.text.Phrase(Row.Cells(4).Value.ToString, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    Tabla.AddCell(Celda)


                    'precio Neto con descuento


                    Frase = New iTextSharp.text.Phrase(Format(Row.Cells(7).Value, "####,####"), iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
                    Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
                    Celda.Border = 0
                    Celda.BackgroundColor = vaColor
                    Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    Tabla.AddCell(Celda)


                End If

            Next
            reporte.Add(Tabla)

            Tabla = New iTextSharp.text.pdf.PdfPTable(1)
            Tabla.WidthPercentage = 100.0!
            Tabla.SetWidths(New Single() {100.0!})
            'Linea
            Frase = New iTextSharp.text.Phrase(" ", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, vatamano10, vaColorTexto))
            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
            Celda.Border = 1
            Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT
            Tabla.AddCell(Celda)

            reporte.Add(Tabla)
            ' FIN TABLA +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        End If



        ' NOTAS +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        Parrafo = New iTextSharp.text.Paragraph()
        Parrafo.Alignment = iTextSharp.text.Element.ALIGN_LEFT
        Parrafo.Leading = 14.0!


        Frase = New iTextSharp.text.Phrase(vbNewLine & vaNotas, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, 10, iTextSharp.text.Color.BLACK))
        Parrafo.Add(Frase)
        reporte.Add(Parrafo)

        ' NOTAS +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        ' FIRMAS +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        Parrafo = New iTextSharp.text.Paragraph()
        Parrafo.Alignment = iTextSharp.text.Element.ALIGN_LEFT
        Parrafo.Leading = 20.0!


        Frase = New iTextSharp.text.Phrase(vbNewLine & vbNewLine & vbNewLine, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, 10, iTextSharp.text.Color.BLACK))
        Parrafo.Add(Frase)
        reporte.Add(Parrafo)


        Tabla = New iTextSharp.text.pdf.PdfPTable(1)
        Tabla.WidthPercentage = 100.0!
        Tabla.SetWidths(New Single() {100.0!})
        vaColor = Color.WHITE
        If chFirmaRosita.Checked = True Then

            Frase = New iTextSharp.text.Phrase("Rosa Espinoza A.", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, 10, iTextSharp.text.Color.BLACK))
            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
            Celda.Border = 0
            Celda.BackgroundColor = vaColor
            Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
            Tabla.AddCell(Celda)


            Frase = New iTextSharp.text.Phrase("Jefe Laboratorio", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, 10, iTextSharp.text.Color.BLACK))
            Celda = New iTextSharp.text.pdf.PdfPCell(Frase)
            Celda.Border = 0
            Celda.BackgroundColor = vaColor
            Celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
            Tabla.AddCell(Celda)

        End If
        reporte.Add(Tabla)

        'Dim imagenFirma As iTextSharp.text.Image
        'Dim position As Integer

        'position = 0
        'imagenFirma = iTextSharp.text.Image.GetInstance("F:\Mis documentos\Mis Imagenes\Logos,firmas,hojas\firma_resultado.jpg") 'Dirreccion a la imagen que se hace referencia

        'imagenFirma.SetAbsolutePosition(50, 550 + position) 'Posicion en el eje cartesiano
        'position += 165 'Incrementamos la posición con la de las imágenes
        'imagenFirma.ScaleAbsoluteWidth(200) 'Ancho de la imagen
        'imagenFirma.ScaleAbsoluteHeight(165) 'Altura de la imagen
        'reporte.Add(imagenFirma) ' Agrega la imagen al documento


        ' END FIRMAS +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++


        reporte.Close() 'cierro el documento
        If chVer.Checked = True Then
            System.Diagnostics.Process.Start("F:\Archivos LabSys\Cotizacion\" & lbCotizacion.Text & " - " & txEmpresa.Text & ".pdf")

        Else
            'MsgBox("¡Guardado con éxito!", MsgBoxStyle.Information, "Información")

        End If


    End Sub

    Private Sub calcularTotales()
        Dim subtot, tot, reg, i, iva As Integer

        subtot = 0
        reg = dgCotiza.Rows.Count

        While i < reg
            If dgCotiza.Rows(i).Cells(5).Value.ToString <> "" And dgCotiza.Rows(i).Cells(7).Value.ToString <> "" Then
                subtot += CInt(dgCotiza.Rows(i).Cells(5).Value)
                tot += CInt(dgCotiza.Rows(i).Cells(7).Value)
            End If

            i = i + 1
        End While

        iva = tot * 0.19
        txTotalConIVA.Text = iva + tot
        Me.txIVA.Text = iva
        Me.txSubTotal.Text = subtot
        Me.txTotal.Text = tot
        Me.txTotalDescuento.Text = subtot - tot

    End Sub
    Private Sub obtieneFecha()
        vafecha = txFecha.Text
        Dim mes As String

        Select Case Month(vafecha)
            Case 1
                mes = "Enero"
            Case 2
                mes = "Febrero"
            Case 3
                mes = "Marzo"
            Case 4
                mes = "Abril"
            Case 5
                mes = "Mayo"
            Case 6
                mes = "Junio"
            Case 7
                mes = "Julio"
            Case 8
                mes = "Agosto"
            Case 9
                mes = "Septiembre"
            Case 10
                mes = "Octubre"
            Case 11
                mes = "Noviembre"
            Case 12
                mes = "Diciembre"
            Case Else
                mes = "Indefinido"

        End Select

        vafecha = "Santiago, " & Microsoft.VisualBasic.DateAndTime.Day(vafecha) & " de " & mes & " de " & Year(Today) & ""
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim mensajeBx As String
        mensajeBx = ""

        If txEmpresa.Text = "" Then
            mensajeBx = "¡Falta completar el campo (Srs/Emp.)!"
        ElseIf txEmail.Text = "" Then
            mensajeBx += "¡Falta completar el campo (Email)!"
        Else
            creo_reporte()
            limpiarControles()
        End If
        If mensajeBx <> "" Then
            MsgBox(mensajeBx, MsgBoxStyle.Information, "Información")
        End If

    End Sub
    Private Sub TabControl1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.Click
        TabControl1.BringToFront()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim mensajeBx As String
        mensajeBx = ""

        If txEmpresa.Text = "" Then
            MsgBox("¡Falta completar el campo (Srs/Emp.)!", MsgBoxStyle.Information, "Información")
        ElseIf txEmail.Text = "" Then
            mensajeBx += "¡Falta completar el campo (Email)!"
        Else
            construirNotas()
            Try
                creo_reporte()
                'guardaCotizacion()
                'guardaCotizacionAnalisis()
                'guardaCotizacionDetalle()
                adjuntaPDF()
            Catch ex As Exception

            End Try
            'MsgBox("!Cotización N°: " & lbCotizacion.Text & " Guardada Correctamente!")
            ObtieneNumero()
            vaSubmuestra = ""
            limpiarControles()
        End If
    End Sub

    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Shell("explorer.exe root = F:\Archivos LabSys\Cotizacion", vbNormalFocus)
    End Sub

    Private Sub dgCotiza_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgCotiza.CellClick
        Try
            If dgCotiza.Columns(e.ColumnIndex).Name = "quitar" AndAlso Me.dgCotiza.Rows(e.RowIndex).IsNewRow = False Then
                Me.dgCotiza.EndEdit()
                Me.dgCotiza.Rows.RemoveAt(e.RowIndex)
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub dgNotasAnalisis_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgNotasAnalisis.CellFormatting
        If dgNotasAnalisis.Columns(e.ColumnIndex).Name = "NOTA_FRECUENCIA" Then

            Dim row As DataGridViewRow = dgNotasAnalisis.Rows(e.RowIndex)
            Dim cell As DataGridViewCell = dgNotasAnalisis.Rows(e.RowIndex).Cells("NOTA_FRECUENCIA")

            If CStr(cell.Value) = "P" Then
                row.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E4F5FF")
            End If

            If CStr(cell.Value) = "M" Then
                row.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#C7FBD7")
            End If

            If CStr(cell.Value) = "I" Then
                row.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FBF6C7")
            End If

            If CStr(cell.Value) = "A" Then
                row.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FBDCC7")
            End If

            If CStr(cell.Value) = "B" Then
                row.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#C7DAFB")
            End If


        End If
    End Sub


    Private Sub dgNotasAnalisis_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgNotasAnalisis.CellContentClick
        notaCapturada = dgNotasAnalisis.Rows(e.RowIndex).Cells(0).Value
    End Sub



    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Me.txt_notaMedia.Text = ""
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        Me.txt_notaBaja.Text = ""
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        If txt_notaMedia.Text = "" Then
            txt_notaMedia.Text = notaCapturada
        Else
            txt_notaMedia.Text = txt_notaMedia.Text + vbCrLf + vbCrLf + notaCapturada
        End If
    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        If txt_notaBaja.Text = "" Then
            txt_notaBaja.Text = notaCapturada
        Else
            txt_notaBaja.Text = txt_notaBaja.Text + vbCrLf + vbCrLf + notaCapturada
        End If
    End Sub


    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Shell("explorer.exe root = F:\Cotizacion", vbNormalFocus)
    End Sub
    Sub adjuntaPDF()
        Dim mOutLookApp As Outlook.Application
        Dim mNameSpace As Outlook.NameSpace
        Dim mItem As Outlook.MailItem
        Dim colAttach As Outlook.Attachments
        Dim l_Attach As Outlook.Attachment
        Dim dsOT As New DataSet

        Dim nompr, carpr, via, ate, email, archivoPDF As String


        nompr = txEmpresa.Text
        ate = txAtencion.Text

        If ate <> "" Then ate = "Atención: " & ate & Chr(13) Else ate = ""
        via = ""
        For f = 1 To Len(nompr)
            carpr = Mid(nompr, f, 1)
            If carpr = "." Then carpr = " "
            via = via + carpr
        Next
        email = txEmail.Text
        mOutLookApp = New Outlook.Application
        mNameSpace = mOutLookApp.GetNamespace("MAPI")
        mItem = mOutLookApp.CreateItem(0)
        mItem.To = email
        mItem.Subject = "Resultado Análisis Agrolab Ltda."
        mItem.Body = "Señor(es): " & Chr(13) & _
                     nompr & Chr(13) & _
                     ate & Chr(13) & _
                     "Adjunto cotización solicitada. Si tiene alguna duda acerca de esta, envíenos un mail o llamenos a nuestro fono donde con gusto resolveremos su inquietud." & Chr(13) & _
                     "Atentamente," & Chr(13) & Chr(13) & _
                     "Agrolab Ltda." & Chr(13) & Chr(13) & _
                     "Fono   : (02) 2 225 8087" & Chr(13) & _
                     "e-mail : laboratorio@agrolab.cl" & Chr(13) & _
                     "Web    : www.agrolab.cl" & Chr(13) & Chr(13)

        colAttach = mItem.Attachments

        archivoPDF = "F:\Archivos LabSys\Cotizacion\" + lbCotizacion.Text + " - " + txEmpresa.Text + ".pdf"

        If File.Exists(archivoPDF) Then
            l_Attach = colAttach.Add(archivoPDF)
        End If

        mItem.Display()

    End Sub

    Private Sub dgFoliar_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgFoliar.CellFormatting
        'If dgFoliar.Columns(e.ColumnIndex).Name = "DataGridViewTextBoxColumn3" Then

        '    Dim row As DataGridViewRow = dgFoliar.Rows(e.RowIndex)
        '    Dim cell As DataGridViewCell = dgFoliar.Rows(e.RowIndex).Cells("DataGridViewTextBoxColumn3")

        '    If CStr(cell.Value) = 0 Then
        '        row.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFB161")
        '    End If

        'End If
    End Sub

    Private Sub chkTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodos.CheckedChanged
        formatearGrillas()
    End Sub
    Private Sub formatearGrillas()
        Dim filt

        If chkTodos.Checked = False Then

            filt = String.Format("ANA_NIVEL_PRECIO Like '{0}%'", "CFR")
            BindingSource1.Filter = filt
            BindingSource2.Filter = filt
            BindingSource3.Filter = filt
            BindingSource4.Filter = filt
            BindingSource5.Filter = filt
            BindingSource6.Filter = filt
            BindingSource7.Filter = filt
            BindingSource8.Filter = filt
        Else
            BindingSource1.Filter = ""
            BindingSource2.Filter = ""
            BindingSource3.Filter = ""
            BindingSource4.Filter = ""
            BindingSource5.Filter = ""
            BindingSource6.Filter = ""
            BindingSource7.Filter = ""
            BindingSource8.Filter = ""

        End If
        pintaCeldas()
    End Sub

    Sub pintaCeldas()

        Dim i, r As Integer
        r = Me.dgFoliar.Rows.Count

        While i < r
            If CInt(Me.dgFoliar.Rows.Item(i).Cells.Item(2).Value) = 0 Or Me.dgFoliar.Rows.Item(i).Cells.Item(2).Value.ToString = "" Then
                Me.dgFoliar.Rows.Item(i).DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFB161")
            End If
            i = i + 1
        End While

        i = 0
        r = Me.dgTejidos.Rows.Count

        While i < r
            If CInt(Me.dgTejidos.Rows.Item(i).Cells.Item(2).Value) = 0 Or Me.dgTejidos.Rows.Item(i).Cells.Item(2).Value.ToString = "" Then
                Me.dgTejidos.Rows.Item(i).DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFB161")
            End If
            i = i + 1
        End While

        i = 0
        r = Me.dgAguas.Rows.Count

        While i < r
            If CInt(Me.dgAguas.Rows.Item(i).Cells.Item(2).Value) = 0 Or Me.dgAguas.Rows.Item(i).Cells.Item(2).Value.ToString = "" Then
                Me.dgAguas.Rows.Item(i).DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFB161")
            End If
            i = i + 1
        End While

        i = 0
        r = Me.dgSuelos.Rows.Count

        While i < r
            If CInt(Me.dgSuelos.Rows.Item(i).Cells.Item(2).Value) = 0 Or Me.dgSuelos.Rows.Item(i).Cells.Item(2).Value.ToString = "" Then
                Me.dgSuelos.Rows.Item(i).DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFB161")
            End If
            i = i + 1
        End While

        i = 0
        r = Me.dgQuimicos.Rows.Count

        While i < r
            If CInt(Me.dgQuimicos.Rows.Item(i).Cells.Item(2).Value) = 0 Or Me.dgQuimicos.Rows.Item(i).Cells.Item(2).Value.ToString = "" Then
                Me.dgQuimicos.Rows.Item(i).DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFB161")
            End If
            i = i + 1
        End While

        i = 0
        r = Me.dgOrganicos.Rows.Count

        While i < r
            If CInt(Me.dgOrganicos.Rows.Item(i).Cells.Item(2).Value) = 0 Or Me.dgOrganicos.Rows.Item(i).Cells.Item(2).Value.ToString = "" Then
                Me.dgOrganicos.Rows.Item(i).DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFB161")
            End If
            i = i + 1
        End While

        i = 0
        r = Me.dgFitopatologicos.Rows.Count

        While i < r
            If CInt(Me.dgFitopatologicos.Rows.Item(i).Cells.Item(2).Value) = 0 Or Me.dgFitopatologicos.Rows.Item(i).Cells.Item(2).Value.ToString = "" Then
                Me.dgFitopatologicos.Rows.Item(i).DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFB161")
            End If
            i = i + 1
        End While

        i = 0
        r = Me.dgOtros.Rows.Count

        While i < r
            If CInt(Me.dgOtros.Rows.Item(i).Cells.Item(2).Value) = 0 Or Me.dgOtros.Rows.Item(i).Cells.Item(2).Value.ToString = "" Then
                Me.dgOtros.Rows.Item(i).DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFB161")
            End If
            i = i + 1
        End While

    End Sub

    Private Sub TabPage2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage2.Enter
        formatearGrillas()
    End Sub

    Private Sub TabPage1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage1.Enter
        formatearGrillas()
    End Sub

    Private Sub TabPage4_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage4.Enter
        formatearGrillas()
    End Sub

    Private Sub TabPage5_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage5.Enter
        formatearGrillas()
    End Sub

    Private Sub TabPage6_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage6.Enter
        formatearGrillas()
    End Sub

    Private Sub TabPage7_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage7.Enter
        formatearGrillas()
    End Sub

    Private Sub TabPage8_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage8.Enter
        formatearGrillas()
    End Sub
End Class