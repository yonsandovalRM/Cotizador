Imports Negocio
Public Class TraspasoYemas


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim cn As New CapaNegocio
            Dim nombrePagina As String
            Dim dt, dtY As New DataTable
            Dim dsY As New DataSet
            Dim valor As String
            Dim i, j As Integer
            i = 0
            j = 3
            nombrePagina = "DIGITA YEMAS"
            'Me.dgYemas.Rows.Clear()
            If System.IO.File.Exists(Me.txRuta.Text) Then ' //compruebo que el archivo exista

                Dim objDataSet As System.Data.DataSet
                Dim objDataAdapter As System.Data.OleDb.OleDbDataAdapter

                ' // Declarar la Cadena de conexión  
                Dim sCs As String = "provider=Microsoft.Jet.OLEDB.4.0; " & "data source=" & Me.txRuta.Text & "; Extended Properties=Excel 8.0;"
                Dim objOleConnection As System.Data.OleDb.OleDbConnection
                objOleConnection = New System.Data.OleDb.OleDbConnection(sCs)

                ' // Declarar la consulta SQL que indica el libro y el rango de la hoja  
                Dim sSql As String = "select * from " & "[" & nombrePagina & "$]"
                ' // Obtener los datos  
                objDataAdapter = New System.Data.OleDb.OleDbDataAdapter(sSql, objOleConnection)

                ' // Crear DataSet y llenarlo  
                objDataSet = New System.Data.DataSet

                objDataAdapter.Fill(objDataSet)
                ' // Cerrar la conexión  
                objOleConnection.Close()
                dt = objDataSet.Tables(0)

                Dim r As Integer = dt.Rows.Count
                ' Dim arr(r, 43) As String

                If dt.Rows.Item(i).Item(0).ToString <> "" Then
                    While i < r
                        Dim dgvRow As New DataGridViewRow
                        Dim dgvCell As DataGridViewCell
                        valor = dt.Rows.Item(i).Item(0).ToString
                        'dtY.Rows.Item(i - 1).Item(0) = valor
                        dgvCell = New DataGridViewTextBoxCell()
                        dgvCell.Value = valor
                        dgvRow.Cells.Add(dgvCell)
                        '   arr(i, 0) = valor
                        valor = dt.Rows.Item(i).Item(1).ToString
                        'dtY.Rows.Item(i - 1).Item(1) = valor
                        dgvCell = New DataGridViewTextBoxCell()
                        dgvCell.Value = valor
                        dgvRow.Cells.Add(dgvCell)
                        'arr(i, 1) = valor

                        valor = dt.Rows.Item(i).Item(2).ToString
                        'dtY.Rows.Item(i - 1).Item(2) = valor
                        dgvCell = New DataGridViewTextBoxCell()
                        dgvCell.Value = valor
                        dgvRow.Cells.Add(dgvCell)
                        'arr(i, 2) = valor

                        While j < 43
                            If IsNumeric(dt.Rows.Item(i).Item(j).ToString()) Then
                                Select Case (dt.Rows.Item(i).Item(j).ToString())
                                    Case 1
                                        valor = "F"
                                    Case 2
                                        valor = "V"
                                    Case 3
                                        valor = "MV"
                                    Case 4
                                        valor = "MF"
                                    Case 5
                                        valor = "MM"
                                    Case 6
                                        valor = "A"
                                    Case 7
                                        valor = ""
                                End Select
                            Else
                                valor = "ERROR"
                                If CDbl("0" & dt.Rows.Item(i).Item(j).ToString()) = 0 Then
                                    valor = ""
                                End If
                            End If
                            'dtY.Rows.Item(i - 1).Item(j) = valor
                            dgvCell = New DataGridViewTextBoxCell()
                            dgvCell.Value = valor
                            dgvRow.Cells.Add(dgvCell)

                            '  arr(i, j) = valor
                            j = j + 1
                        End While
                        Call grabaYemas(dgvRow)
                        Me.dgYemas.Rows.Add(dgvRow)
                        j = 3
                        i = i + 1
                    End While
                Else
                    Dim entro As String
                    Dim desde, hasta As Integer
                    entro = "no"
                    If (dt.Rows.Item(i).Item(1).ToString() <> "") Then
                        dsY = Nothing
                        entro = "si"
                        dsY = cn.buscaOT(dt.Rows.Item(i).Item(1).ToString())
                        If dsY.Tables(0).Rows.Item(0).Item(0).ToString = Nothing Then
                            MsgBox("No existe la orden para este Nlab. error : ", MsgBoxStyle.Information)
                            Exit Sub
                        End If
                    End If
                    desde = CInt(dsY.Tables(0).Rows.Item(0).Item(1).ToString())
                    hasta = CInt(dsY.Tables(0).Rows.Item(0).Item(2).ToString())
                    While i < r


                        Dim dgvRow As New DataGridViewRow
                        Dim dgvCell As DataGridViewCell


                        If (dt.Rows.Item(i).Item(1).ToString() <> "" And entro <> "si") Then
                            desde = desde + 1
                            If desde > hasta Then
                                dsY = Nothing
                                entro = "no"
                                dsY = cn.buscaOT(dt.Rows.Item(i).Item(1).ToString())
                                desde = CInt(dsY.Tables(0).Rows.Item(0).Item(1).ToString())
                                hasta = CInt(dsY.Tables(0).Rows.Item(0).Item(2).ToString())
                            End If
                        End If

                        entro = "no"

                        dgvCell = New DataGridViewTextBoxCell()
                        dgvCell.Value = dsY.Tables(0).Rows.Item(0).Item(0).ToString
                        dgvRow.Cells.Add(dgvCell)

                        valor = dt.Rows.Item(i).Item(1).ToString
                        dgvCell = New DataGridViewTextBoxCell()
                        dgvCell.Value = desde
                        dgvRow.Cells.Add(dgvCell)

                        valor = dt.Rows.Item(i).Item(2).ToString
                        dgvCell = New DataGridViewTextBoxCell()
                        dgvCell.Value = valor
                        dgvRow.Cells.Add(dgvCell)

                        While j < 43
                            If IsNumeric(dt.Rows.Item(i).Item(j).ToString()) Then
                                Select Case (dt.Rows.Item(i).Item(j).ToString())
                                    Case 1
                                        valor = "F"
                                    Case 2
                                        valor = "V"
                                    Case 3
                                        valor = "MV"
                                    Case 4
                                        valor = "MF"
                                    Case 5
                                        valor = "MM"
                                    Case 6
                                        valor = "A"
                                    Case 7
                                        valor = ""
                                End Select
                            Else
                                valor = "ERROR"
                                If CDbl("0" & dt.Rows.Item(i).Item(j).ToString()) = 0 Then
                                    valor = ""
                                End If
                            End If

                            dgvCell = New DataGridViewTextBoxCell()
                            dgvCell.Value = valor
                            dgvRow.Cells.Add(dgvCell)


                            j = j + 1
                        End While


                        Call grabaYemas(dgvRow)

                        Me.dgYemas.Rows.Add(dgvRow)

                        j = 3
                        i = i + 1
                    End While
                End If
                Me.txRuta.Text = valor


            End If
        Catch ex As Exception
            MsgBox("error")
        End Try


    End Sub

    Private Sub grabaYemas(ByVal row As DataGridViewRow)

        Dim cn As New CapaNegocio
        Dim ot, nlab, yema As Integer
        Dim c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15, c16, c17, c18, c19, c20, c21, c22, c23, c24, c25, c26, c27, c28, c29, c30, c31, c32, c33, c34, c35, c36, c37, c38, c39, c40 As String


        ot = CInt(row.Cells.Item(0).Value)
        nlab = CInt(row.Cells.Item(1).Value)
        yema = CInt(row.Cells.Item(2).Value)

        c1 = row.Cells.Item(3).Value
        c2 = row.Cells.Item(4).Value
        c3 = row.Cells.Item(5).Value
        c4 = row.Cells.Item(6).Value
        c5 = row.Cells.Item(7).Value
        c6 = row.Cells.Item(8).Value
        c7 = row.Cells.Item(9).Value
        c8 = row.Cells.Item(10).Value
        c9 = row.Cells.Item(11).Value
        c10 = row.Cells.Item(12).Value
        c11 = row.Cells.Item(13).Value
        c12 = row.Cells.Item(14).Value
        c13 = row.Cells.Item(15).Value
        c14 = row.Cells.Item(16).Value
        c15 = row.Cells.Item(17).Value
        c16 = row.Cells.Item(18).Value
        c17 = row.Cells.Item(19).Value
        c18 = row.Cells.Item(20).Value
        c19 = row.Cells.Item(21).Value
        c20 = row.Cells.Item(22).Value
        c21 = row.Cells.Item(23).Value
        c22 = row.Cells.Item(24).Value
        c23 = row.Cells.Item(25).Value
        c24 = row.Cells.Item(26).Value
        c25 = row.Cells.Item(27).Value
        c26 = row.Cells.Item(28).Value
        c27 = row.Cells.Item(29).Value
        c28 = row.Cells.Item(30).Value
        c29 = row.Cells.Item(31).Value
        c30 = row.Cells.Item(32).Value
        c31 = row.Cells.Item(33).Value
        c32 = row.Cells.Item(34).Value
        c33 = row.Cells.Item(35).Value
        c34 = row.Cells.Item(36).Value
        c35 = row.Cells.Item(37).Value
        c36 = row.Cells.Item(38).Value
        c37 = row.Cells.Item(39).Value
        c38 = row.Cells.Item(40).Value
        c39 = row.Cells.Item(41).Value
        c40 = row.Cells.Item(42).Value

        cn.GrabaYemas(ot, nlab, yema, c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15, c16, c17, c18, c19, c20, c21, c22, c23, c24, c25, c26, c27, c28, c29, c30, c31, c32, c33, c34, c35, c36, c37, c38, c39, c40)

    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.openDialog.ShowDialog()
        Me.txRuta.Text = Me.openDialog.FileName
    End Sub

End Class