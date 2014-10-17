Imports System.Data.SqlClient
Imports System.Data
Imports AccesoDatos



Public Class CapaNegocio
    'Public Cjto_Tablas1 As Cjto_Tablas = New Cjto_Tablas



    Public Function ValidaUsuario(ByVal usuario, ByVal clave)
        Dim cd As New CapaDatos
        Dim ds As New Data.DataSet
        Dim sClave As String
        Dim res As Boolean

        cd.Inicializar()
        cd.AgregarParametro("@usuario", usuario, SqlDbType.VarChar)
        ds = cd.EjecutarQuery("ys_validaUsuario")

        If ds.Tables(0).Rows.Count <> 0 Then
            sClave = ds.Tables(0).Rows(0).Item(0)
            If clave = sClave Then
                res = True
            Else
                res = False
            End If
        Else
            res = False
        End If

        Return res
    End Function
    Public Function buscaOT(ByVal nlab As String)
        Dim cd As New CapaDatos
        Dim ds As New DataSet

        cd.Inicializar()
        cd.AgregarParametro("@Nlab", nlab, SqlDbType.VarChar)
        ds = cd.EjecutarQuery("ls_BuscaOTconNLab")

        Return ds
    End Function
    Public Function BuscaEstadisticas(ByVal f1 As DateTime, ByVal f2 As DateTime, ByVal tipo As Integer)
        Dim cd As New CapaDatos
        Dim ds As New Data.DataSet

        cd.Inicializar()
        cd.AgregarParametro("@F1", f1, SqlDbType.DateTime)
        cd.AgregarParametro("@F2", f2, SqlDbType.DateTime)
        cd.AgregarParametro("@Tipo", tipo, SqlDbType.Int)
        ds = cd.EjecutarQuery("LISTAANALISISXFACTURA")


        Return ds
    End Function
    Public Function BuscaEstadisticas2(ByVal f1 As DateTime, ByVal f2 As DateTime, ByVal tipo As Integer)
        Dim cd As New CapaDatos
        Dim ds As New Data.DataSet

        cd.Inicializar()
        cd.AgregarParametro("@F1", f1, SqlDbType.DateTime)
        cd.AgregarParametro("@F2", f2, SqlDbType.DateTime)
        cd.AgregarParametro("@Tipo", tipo, SqlDbType.Int)
        ds = cd.EjecutarQuery("LISTAANALISISXFACTURAR")


        Return ds
    End Function
    Public Function BuscaEstadisticas3(ByVal f1 As DateTime, ByVal f2 As DateTime, ByVal tipo As Integer)
        Dim cd As New CapaDatos
        Dim ds As New Data.DataSet

        cd.Inicializar()
        cd.AgregarParametro("@F1", f1, SqlDbType.DateTime)
        cd.AgregarParametro("@F2", f2, SqlDbType.DateTime)
        cd.AgregarParametro("@Tipo", tipo, SqlDbType.Int)
        ds = cd.EjecutarQuery("LISTAANALISISINGRESADOS")


        Return ds
    End Function
    Public Function BuscaDatosInformeYemas(ByVal ot As Integer)
        Dim cd As New CapaDatos
        Dim ds As New Data.DataSet

        cd.Inicializar()
        cd.AgregarParametro("@NumOT", ot, SqlDbType.Int)
        ds = cd.EjecutarQuery("usp_SelectAntecedentesYemas")


        Return ds
    End Function
    'Public Function BuscaDatosEmpresa(ByVal empresa As String)
    '    Dim cd As New CapaDatos
    '    Dim ds As New Data.DataSet

    '    cd.Inicializar()
    '    cd.AgregarParametro("@empresa", empresa, SqlDbType.NVarChar)
    '    ds = cd.EjecutarQuery("ysCotizaEmpresa")


    '    Return ds
    'End Function
    Public Function CargaAnalisis(ByVal tipo As Integer)
        Dim cd As New CapaDatos
        Dim ds As New Data.DataSet

        Select Case tipo
            Case 1
                cd.Inicializar()
                ds = cd.EjecutarQuery("ysTodosFoliar")
            Case 2
                cd.Inicializar()
                ds = cd.EjecutarQuery("ysTodosTejidos")
            Case 3
                cd.Inicializar()
                ds = cd.EjecutarQuery("ysTodosAguas")
            Case 4
                cd.Inicializar()
                ds = cd.EjecutarQuery("ysTodosSuelos")
            Case 5
                cd.Inicializar()
                ds = cd.EjecutarQuery("ysTodosQuimicos")
            Case 6
                cd.Inicializar()
                ds = cd.EjecutarQuery("ysTodosOrganicos")
            Case 7
                cd.Inicializar()
                ds = cd.EjecutarQuery("ysTodosFitos")
            Case 8
                cd.Inicializar()
                ds = cd.EjecutarQuery("ysTodosOtros")
            Case Else

        End Select

        Return ds
    End Function
    Public Function CargaNotas()
        Dim cd As New CapaDatos
        Dim ds As New Data.DataSet

        cd.Inicializar()
        ds = cd.EjecutarQuery("ysCargaNotas")

        Return ds
    End Function
    Public Function CargaEmpresas()
        Dim cd As New CapaDatos
        Dim ds As New Data.DataSet

        cd.Inicializar()
        ds = cd.EjecutarQuery("ysEmpresas")

        Return ds
    End Function
    Public Function BuscaEmpresa(ByVal empresa As String)
        Dim cd As New CapaDatos
        Dim ds As New Data.DataSet

        cd.Inicializar()
        cd.AgregarParametro("@EMPRESA", empresa, SqlDbType.NVarChar)
        ds = cd.EjecutarQuery("ysBuscaEmpresa")

        Return ds
    End Function
    Public Function BuscaProductor(ByVal productor As String)
        Dim cd As New CapaDatos
        Dim ds As New Data.DataSet

        cd.Inicializar()
        cd.AgregarParametro("@PRODUCTOR", productor, SqlDbType.NVarChar)
        ds = cd.EjecutarQuery("ysBuscaProductor")

        Return ds
    End Function
    Public Function BuscaDatosCotizacion(ByVal numero As String)
        Dim cd As New CapaDatos
        Dim ds As New Data.DataSet

        cd.Inicializar()
        cd.AgregarParametro("@NUMERO", numero, SqlDbType.NVarChar)
        ds = cd.EjecutarQuery("ysBuscaDatosCotizacion")

        Return ds
    End Function
    Public Function ObtieneSubMuestra(ByVal anaCodigo As String)
        Dim cd As New CapaDatos
        Dim ds As New Data.DataSet

        cd.Inicializar()
        cd.AgregarParametro("@ANA_CODIGO", anaCodigo, SqlDbType.NVarChar)
        ds = cd.EjecutarQuery("ysObtieneSubmuestra")

        Return ds
    End Function
    Public Function ObtieneNumeroCotizacion()
        Dim cd As New CapaDatos
        Dim ds As New Data.DataSet

        cd.Inicializar()
        ds = cd.EjecutarQuery("ysObtieneNumeroCotizacion")

        Return ds
    End Function

    Public Function HistoricoCotiza(ByVal filtro As String, ByVal dato As String)
        Dim cd As New CapaDatos
        Dim ds As New Data.DataSet

        Select Case filtro
            Case "porEmpresa"
                cd.Inicializar()
                cd.AgregarParametro("@FILTRO", dato, SqlDbType.NVarChar)
                ds = cd.EjecutarQuery("ysBuscaHistoricoCotizaE")
            Case "porProductor"
                cd.Inicializar()
                cd.AgregarParametro("@FILTRO", dato, SqlDbType.NVarChar)
                ds = cd.EjecutarQuery("ysBuscaHistoricoCotizaP")
            Case "porAtencion"
                cd.Inicializar()
                cd.AgregarParametro("@FILTRO", dato, SqlDbType.NVarChar)
                ds = cd.EjecutarQuery("ysBuscaHistoricoCotizaA")
            Case Else

        End Select


        Return ds
    End Function

    Public Sub BuscaDatosDigitaYemas(ByVal ot As Integer)
        'Dim cd As New CapaDatos
        'Dim ds As New Data.DataSet
        'Cjto_Tablas1.Tables("DIG_YEMAS").Clear()
        'Cjto_Tablas1.Tables("ORDEN_TRABAJO").Clear()
        'Cjto_Tablas1.Tables("OT_YEMAS_ANTECEDENTES").Clear()

        'cd.Inicializar()
        'cd.AgregarParametro("@OT", ot, SqlDbType.Int)
        'cd.EjecutarQueryDt("ys_DigitaYemas", Cjto_Tablas1, "DIG_YEMAS")
        '' ds = cd.EjecutarQuery("ys_DigitaYemas")

        'cd.Inicializar()
        'cd.AgregarParametro("@OT", ot, SqlDbType.Int)
        'cd.EjecutarQueryDt("ys_OrdenTrabajo", Cjto_Tablas1, "ORDEN_TRABAJO")

        'cd.Inicializar()
        'cd.AgregarParametro("@OT", ot, SqlDbType.Int)
        'cd.EjecutarQueryDt("ys_AntecedentesYemas", Cjto_Tablas1, "OT_YEMAS_ANTECEDENTES")

        'Dim NLab_Aux, Ye, Car, observadas, frutales, PorAcu, Suma_Obs, Suma_Frutal, YemasAct, NumeroYemasMaximo, cargador_formato As Integer
        'Dim PorObs, acumulado As Double
        'Dim str_Cargador As String
        'acumulado = 0 : Suma_Obs = 0 : Suma_Frutal = 0
        'NLab_Aux = 0

        'NumeroYemasMaximo = 0
        'For Each Fila_yemas In Cjto_Tablas1.Tables("DIG_YEMAS").Rows
        '    observadas = 0 : frutales = 0
        '    If Fila_yemas("OT_NLAB") <> NLab_Aux Then
        '        acumulado = 0 : Suma_Obs = 0 : Suma_Frutal = 0
        '    End If

        '    '*************************
        '    'Cantidad de Yemas maximas 
        '    '*************************
        '    YemasAct = 0
        '    For Car = 1 To 40
        '        str_Cargador = "YEM_CARGADOR" & Car
        '        If IsDBNull(Fila_yemas(str_Cargador)) = False Then
        '            If Fila_yemas(str_Cargador) <> "" Then YemasAct = 1 : Exit For
        '        End If
        '    Next
        '    If YemasAct > 0 Then
        '        If NumeroYemasMaximo < Fila_yemas("YEM_YEMA") Then
        '            NumeroYemasMaximo = Fila_yemas("YEM_YEMA")
        '        End If
        '    End If
        '    '************************

        '    For Car = 1 To 40
        '        str_Cargador = "YEM_CARGADOR" & Car
        '        If IsDBNull(Fila_yemas(str_Cargador)) = False Then
        '            If Fila_yemas(str_Cargador) <> "" Then observadas = observadas + 1
        '            If Fila_yemas(str_Cargador) = "F" Then frutales = frutales + 1
        '        End If
        '    Next
        '    If cargador_formato < observadas Then cargador_formato = observadas
        '    If observadas <> 0 Then
        '        Fila_yemas("YEM_OBSERVADAS") = observadas
        '        Fila_yemas("YEM_FRUTALES") = frutales
        '        Suma_Obs = Suma_Obs + observadas : Suma_Frutal = Suma_Frutal + frutales
        '        If observadas <> 0 Then PorObs = (frutales / observadas) * 100
        '        If PorObs = 0 Then
        '            Fila_yemas("YEM_POROBSERVADAS") = 0
        '        Else
        '            Fila_yemas("YEM_POROBSERVADAS") = Format(PorObs, "##.##")
        '        End If
        '        acumulado = (Suma_Frutal / Suma_Obs) * 100
        '        If acumulado = 0 Then
        '            Fila_yemas("YEM_PORACUMULADA") = 0
        '        Else
        '            Fila_yemas("YEM_PORACUMULADA") = Format(acumulado, "##.##")
        '        End If
        '        NLab_Aux = Fila_yemas("OT_NLAB")
        '    End If
        'Next

        'RptYemas.SetDataSource(Cjto_Tablas1)



    End Sub

    Public Sub GrabaCotizacion(ByVal numero, ByVal empresa, ByVal email, ByVal atencion, ByVal fono, ByVal subtotal, ByVal descuento, ByVal neto, ByVal iva, ByVal total, ByVal fecha)
        Dim cd As New CapaDatos

        With cd
            .Inicializar()
            .AgregarParametro("@COT_NUMERO", numero, SqlDbType.Int)
            .AgregarParametro("@COT_NOMBRE", empresa, SqlDbType.NVarChar)
            .AgregarParametro("@COT_EMAIL", email, SqlDbType.NVarChar)
            .AgregarParametro("@COT_ATENCION", atencion, SqlDbType.NVarChar)
            .AgregarParametro("@COT_FONO", fono, SqlDbType.NVarChar)
            .AgregarParametro("@COT_SUBTOTAL", subtotal, SqlDbType.Int)
            .AgregarParametro("@COT_DESCUENTO", descuento, SqlDbType.Int)
            .AgregarParametro("@COT_NETO", neto, SqlDbType.Int)
            .AgregarParametro("@COT_IVA", iva, SqlDbType.Int)
            .AgregarParametro("@COT_TOTAL", total, SqlDbType.Int)
            .AgregarParametro("@COT_FECHA", fecha, SqlDbType.DateTime)
          
            .EjecutarEscalar("ys_GrabaCotizacion")
        End With
    End Sub
    Public Sub GrabaCotizacionAnalisis(ByVal numero, ByVal codigo, ByVal precioUnitario, ByVal porDescuento, ByVal neto)
        Dim cd As New CapaDatos
        With cd
            .Inicializar()
            .AgregarParametro("@COT_NUMERO", numero, SqlDbType.Int)
            .AgregarParametro("@CTD_ANALISIS", codigo, SqlDbType.Int)
            .AgregarParametro("@CTA_UNITARIO", precioUnitario, SqlDbType.Int)
            .AgregarParametro("@CTA_DESCUENTO", porDescuento, SqlDbType.Int)
            .AgregarParametro("@CTA_NETO", neto, SqlDbType.Int)

            .EjecutarEscalar("ys_GrabaCotizacionAnalisis")
        End With
    End Sub
    Public Sub GrabaCotizacionDetalle(ByVal numero, ByVal codigo, ByVal cantidad, ByVal precioUnitario, ByVal subtotal, ByVal porDescuento, ByVal neto, ByVal descripcion)
        Dim cd As New CapaDatos
        With cd
            .Inicializar()
            .AgregarParametro("@COT_NUMERO", numero, SqlDbType.Int)
            .AgregarParametro("@CTD_ANALISIS", codigo, SqlDbType.Int)
            .AgregarParametro("@CTD_CANTIDAD", cantidad, SqlDbType.Int)
            .AgregarParametro("@CTD_UNITARIO", precioUnitario, SqlDbType.Int)
            .AgregarParametro("@CTD_SUBTOTAL", subtotal, SqlDbType.Int)
            .AgregarParametro("@CTD_DESCUENTO", porDescuento, SqlDbType.Int)
            .AgregarParametro("@CTD_TOTAL", neto, SqlDbType.Int)
            .AgregarParametro("@ANA_ANALISIS", descripcion, SqlDbType.NVarChar)


            .EjecutarEscalar("ys_GrabaCotizacionDetalle")
        End With
    End Sub
    Public Sub GrabaYemas(ByVal ot, ByVal nlab, ByVal yema, ByVal c1, ByVal c2, ByVal c3, ByVal c4, ByVal c5, ByVal c6, ByVal c7, ByVal c8, ByVal c9, ByVal c10, ByVal c11, ByVal c12, ByVal c13, ByVal c14, ByVal c15, ByVal c16, ByVal c17, ByVal c18, ByVal c19, ByVal c20, ByVal c21, ByVal c22, ByVal c23, ByVal c24, ByVal c25, ByVal c26, ByVal c27, ByVal c28, ByVal c29, ByVal c30, ByVal c31, ByVal c32, ByVal c33, ByVal c34, ByVal c35, ByVal c36, ByVal c37, ByVal c38, ByVal c39, ByVal c40)
        Dim cd As New CapaDatos
        With cd
            .Inicializar()
            .AgregarParametro("@OT_NUMERO", ot, SqlDbType.Int)
            .AgregarParametro("@OT_NLAB", nlab, SqlDbType.Int)
            .AgregarParametro("@YEM_YEMA", yema, SqlDbType.Int)
            .AgregarParametro("@YEM_CARGADOR1", c1, SqlDbType.NVarChar)
            .AgregarParametro("@YEM_CARGADOR2", c2, SqlDbType.NVarChar)
            .AgregarParametro("@YEM_CARGADOR3", c3, SqlDbType.NVarChar)
            .AgregarParametro("@YEM_CARGADOR4", c4, SqlDbType.NVarChar)
            .AgregarParametro("@YEM_CARGADOR5", c5, SqlDbType.NVarChar)
            .AgregarParametro("@YEM_CARGADOR6", c6, SqlDbType.NVarChar)
            .AgregarParametro("@YEM_CARGADOR7", c7, SqlDbType.NVarChar)
            .AgregarParametro("@YEM_CARGADOR8", c8, SqlDbType.NVarChar)
            .AgregarParametro("@YEM_CARGADOR9", c9, SqlDbType.NVarChar)
            .AgregarParametro("@YEM_CARGADOR10", c10, SqlDbType.NVarChar)
            .AgregarParametro("@YEM_CARGADOR11", c11, SqlDbType.NVarChar)
            .AgregarParametro("@YEM_CARGADOR12", c12, SqlDbType.NVarChar)
            .AgregarParametro("@YEM_CARGADOR13", c13, SqlDbType.NVarChar)
            .AgregarParametro("@YEM_CARGADOR14", c14, SqlDbType.NVarChar)
            .AgregarParametro("@YEM_CARGADOR15", c15, SqlDbType.NVarChar)
            .AgregarParametro("@YEM_CARGADOR16", c16, SqlDbType.NVarChar)
            .AgregarParametro("@YEM_CARGADOR17", c17, SqlDbType.NVarChar)
            .AgregarParametro("@YEM_CARGADOR18", c18, SqlDbType.NVarChar)
            .AgregarParametro("@YEM_CARGADOR19", c19, SqlDbType.NVarChar)
            .AgregarParametro("@YEM_CARGADOR20", c20, SqlDbType.NVarChar)
            .AgregarParametro("@YEM_CARGADOR21", c21, SqlDbType.NVarChar)
            .AgregarParametro("@YEM_CARGADOR22", c22, SqlDbType.NVarChar)
            .AgregarParametro("@YEM_CARGADOR23", c23, SqlDbType.NVarChar)
            .AgregarParametro("@YEM_CARGADOR24", c24, SqlDbType.NVarChar)
            .AgregarParametro("@YEM_CARGADOR25", c25, SqlDbType.NVarChar)
            .AgregarParametro("@YEM_CARGADOR26", c26, SqlDbType.NVarChar)
            .AgregarParametro("@YEM_CARGADOR27", c27, SqlDbType.NVarChar)
            .AgregarParametro("@YEM_CARGADOR28", c28, SqlDbType.NVarChar)
            .AgregarParametro("@YEM_CARGADOR29", c29, SqlDbType.NVarChar)
            .AgregarParametro("@YEM_CARGADOR30", c30, SqlDbType.NVarChar)
            .AgregarParametro("@YEM_CARGADOR31", c31, SqlDbType.NVarChar)
            .AgregarParametro("@YEM_CARGADOR32", c32, SqlDbType.NVarChar)
            .AgregarParametro("@YEM_CARGADOR33", c33, SqlDbType.NVarChar)
            .AgregarParametro("@YEM_CARGADOR34", c34, SqlDbType.NVarChar)
            .AgregarParametro("@YEM_CARGADOR35", c35, SqlDbType.NVarChar)
            .AgregarParametro("@YEM_CARGADOR36", c36, SqlDbType.NVarChar)
            .AgregarParametro("@YEM_CARGADOR37", c37, SqlDbType.NVarChar)
            .AgregarParametro("@YEM_CARGADOR38", c38, SqlDbType.NVarChar)
            .AgregarParametro("@YEM_CARGADOR39", c39, SqlDbType.NVarChar)
            .AgregarParametro("@YEM_CARGADOR40", c40, SqlDbType.NVarChar)
            .EjecutarQuery("agrolab_carga_yemas")
        End With
    End Sub

End Class

