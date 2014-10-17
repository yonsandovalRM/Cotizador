Imports Negocio
Imports AccesoDatos
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO

Public Class GeneraInformeYemas
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click

        Dim cn As New CapaNegocio

        'cn.BuscaDatosDigitaYemas(txtOt.Text)
        Dim cd As New CapaDatos
        Dim ds As New Data.DataSet
        Cjto_Tablas1.Tables("DIG_YEMAS").Clear()
        Cjto_Tablas1.Tables("ORDEN_TRABAJO").Clear()
        Cjto_Tablas1.Tables("OT_YEMAS_ANTECEDENTES").Clear()

        cd.Inicializar()
        cd.AgregarParametro("@OT", Me.txtOt.Text, SqlDbType.Int)
        cd.EjecutarQueryDt("ys_DigitaYemas", Cjto_Tablas1, "DIG_YEMAS")
        ' ds = cd.EjecutarQuery("ys_DigitaYemas")

        cd.Inicializar()
        cd.AgregarParametro("@OT", Me.txtOt.Text, SqlDbType.Int)
        cd.EjecutarQueryDt("ys_OrdenTrabajo", Cjto_Tablas1, "ORDEN_TRABAJO")

        cd.Inicializar()
        cd.AgregarParametro("@OT", Me.txtOt.Text, SqlDbType.Int)
        cd.EjecutarQueryDt("ys_AntecedentesYemas", Cjto_Tablas1, "OT_YEMAS_ANTECEDENTES")

        Dim NLab_Aux, Car, observadas, frutales, Suma_Obs, Suma_Frutal, YemasAct, NumeroYemasMaximo, cargador_formato As Integer
        Dim PorObs, acumulado As Double
        Dim str_Cargador As String
        acumulado = 0 : Suma_Obs = 0 : Suma_Frutal = 0
        NLab_Aux = 0

        NumeroYemasMaximo = 0
        For Each Fila_yemas In Cjto_Tablas1.Tables("DIG_YEMAS").Rows
            observadas = 0 : frutales = 0
            If Fila_yemas("OT_NLAB") <> NLab_Aux Then
                acumulado = 0 : Suma_Obs = 0 : Suma_Frutal = 0
            End If

            '**************************
            'Cantidad de Yemas maximas 
            '**************************
            YemasAct = 0
            For Car = 1 To 40
                str_Cargador = "YEM_CARGADOR" & Car
                If IsDBNull(Fila_yemas(str_Cargador)) = False Then
                    If Fila_yemas(str_Cargador) <> "" Then YemasAct = 1 : Exit For
                End If
            Next
            If YemasAct > 0 Then
                If NumeroYemasMaximo < Fila_yemas("YEM_YEMA") Then
                    NumeroYemasMaximo = Fila_yemas("YEM_YEMA")
                End If
            End If
            '************************
            For Car = 1 To 40
                str_Cargador = "YEM_CARGADOR" & Car
                If IsDBNull(Fila_yemas(str_Cargador)) = False Then
                    If Fila_yemas(str_Cargador) <> "" Then observadas = observadas + 1
                    If Fila_yemas(str_Cargador) = "F" Then frutales = frutales + 1
                End If
            Next
            If cargador_formato < observadas Then cargador_formato = observadas
            If observadas <> 0 Then
                Fila_yemas("YEM_OBSERVADAS") = observadas
                Fila_yemas("YEM_FRUTALES") = frutales
                Suma_Obs = Suma_Obs + observadas : Suma_Frutal = Suma_Frutal + frutales
                If observadas <> 0 Then PorObs = (frutales / observadas) * 100
                If PorObs = 0 Then
                    Fila_yemas("YEM_POROBSERVADAS") = 0
                Else
                    Fila_yemas("YEM_POROBSERVADAS") = Format(PorObs, "##.##")
                End If
                acumulado = (Suma_Frutal / Suma_Obs) * 100
                If acumulado = 0 Then
                    Fila_yemas("YEM_PORACUMULADA") = 0
                Else
                    Fila_yemas("YEM_PORACUMULADA") = Format(acumulado, "##.##")
                End If
                NLab_Aux = Fila_yemas("OT_NLAB")
            End If
        Next
        'Dim nDesde, nHasta As Integer
        'nDesde = 2
        'nHasta = 4

        RptYemas20.SetDataSource(Cjto_Tablas1)

        InformeYemas.CrystalReportViewer1.ReportSource = RptYemas20
        InformeYemas.ShowDialog()
        'Dim escritor As StreamWriter 'declaro la variable escritor

        ''Aqui se crea el archivo html, y tomo el nombre de un TextBox, para que se cree dinámicamente mis archivos
        'escritor = New StreamWriter("F:\Archivos LabSys\YemasHTML\" & nDesde & " - " & nHasta & "Productor.html")

        'With escritor
        '    .WriteLine("<html>") 'crea el encabezado HTML
        '    .WriteLine("<head>") 'crea el HEAD de nuestro html
        '    .WriteLine("<meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"" />") 'escribe los META del archivo html
        '    .WriteLine("<title>Hola</title>") 'escribe la etiqueta TITLE tomada del nombre con el que se graba el html
        '    .WriteLine("</head>") 'cierra la etiqueta HEAD
        '    .WriteLine("<body>") 'escribe la etiqueta BODY
        '    .WriteLine("Aquí va el contenido de mi HTML el cual lo puedes tomar desde un TextBox o desde un editor de HTML implementado") 'escribe el contenido del html
        '    .WriteLine("</body>") 'cierra la etiqueta BODY
        '    .WriteLine("</html>") 'cierra la etiqueta HTML

        '    .Close() 'termina el proceso y crea el archivo
        'End With
    End Sub
End Class
