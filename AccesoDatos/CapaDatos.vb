Imports System.Data.SqlClient
Imports System.Data
Imports System.Configuration

Public Class CapaDatos
    Protected Shared Cmd As SqlCommand
    Protected Shared SqlConexion As SqlConnection


    Public Sub New()

        SqlConexion = New SqlConnection(My.Settings.cn)
        Cmd = New SqlCommand
        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.Connection = SqlConexion
    End Sub


    Public Sub Inicializar()

        'Limpio los parametros Agregados
        Cmd.Parameters.Clear()

    End Sub

    Public Overloads Sub AgregarParametro( _
                                            ByVal NombreParametro As String, _
                                            ByVal ValorParametro As Object, _
                                            ByVal TipoDato As SqlDbType, _
                                            Optional ByVal Direccion As System.Data.ParameterDirection = ParameterDirection.Input)

        Cmd.Parameters.Add(NombreParametro, TipoDato).Direction = Direccion
        Cmd.Parameters(NombreParametro).Value = ValorParametro

    End Sub

    'Public Overloads Sub AgregarParametro( _
    '                                        ByVal NombreParametro As String, _
    '                                        ByVal ValorParametro As Object, _
    '                                        ByVal TipoDato As SqlDbType, _
    '                                        ByVal TamanoParametro As Integer, _
    '                                        Optional ByVal Direccion As System.Data.ParameterDirection = ParameterDirection.Input)

    '    Cmd.Parameters.Add(NombreParametro, TipoDato, TamanoParametro).Direction = Direccion
    '    Cmd.Parameters(NombreParametro).Value = ValorParametro

    'End Sub

    Public Overloads Function EjecutarQuery(ByVal NombreProcedimiento As String) As DataSet

        Try

            Cmd.CommandText = NombreProcedimiento
            If Cmd.Connection.State <> ConnectionState.Closed Then
                Cmd.Connection.Close()
            End If
            Cmd.Connection.Open() 'Abro la Db
            Cmd.ExecuteReader()
            Cmd.Connection.Close() 'Cierro La Db
            Dim ds As New DataSet
            Dim Adapter As New SqlDataAdapter(Cmd)

            Adapter.Fill(ds)
            Normalizar(ds) 'Los integer o decimales duros los devuelve como 0
            Return ds

        Finally

        End Try

    End Function


    Public Overloads Sub EjecutarQueryDt(ByVal NombreProcedimiento As String, ByVal NombreDataset As DataSet, ByVal NombreTabla As String)

        Try

            Cmd.CommandText = NombreProcedimiento 'Nombre del Procedimiento Almacenado
            If Cmd.Connection.State <> ConnectionState.Closed Then
                Cmd.Connection.Close()
            End If
            Cmd.Connection.Open() 'Abro la Db
            Cmd.ExecuteReader()
            Cmd.Connection.Close() 'Cierra La Db
            Dim Adapter As New SqlDataAdapter(Cmd)
            Adapter.Fill(NombreDataset, NombreTabla)

        Finally
            Cmd.Connection.Close() 'Cierra La Db
        End Try

    End Sub


    Public Overloads Function EjecutarEscalar(ByVal NombreProcedimiento As String) As Integer

        Try
            Dim Retorno As Integer = 0
            Cmd.CommandText = NombreProcedimiento 'Nombre del Procedimiento Almacenado
            If Cmd.Connection.State <> ConnectionState.Closed Then
                Cmd.Connection.Close()
            End If
            Cmd.Connection.Open() 'Abro la Db
            Retorno = Cmd.ExecuteScalar() 'Ejecuta el procedimiento 
            Cmd.Connection.Close() 'Cierra La Db
            Return Retorno

        Finally
            Cmd.Connection.Close() 'Cierra La Db
        End Try

    End Function

    Public Overloads Function EjecutarEscalar2(ByVal NombreProcedimiento As String) As Double

        Try
            Dim Retorno As Double = 0
            Cmd.CommandText = NombreProcedimiento 'Nombre del Procedimiento Almacenado
            If Cmd.Connection.State <> ConnectionState.Closed Then
                Cmd.Connection.Close()
            End If
            Cmd.Connection.Open() 'Abro la Db
            Retorno = Cmd.ExecuteScalar() 'Ejecuta el procedimiento 
            Cmd.Connection.Close() 'Cierra La Db
            Return Retorno

        Finally
            Cmd.Connection.Close() 'Cierra La Db
        End Try

    End Function

    Public Overloads Function EjecutarEscalar3(ByVal NombreProcedimiento As String) As String

        Try
            Dim Retorno As String = ""
            Cmd.CommandText = NombreProcedimiento 'Nombre del Procedimiento Almacenado
            If Cmd.Connection.State <> ConnectionState.Closed Then
                Cmd.Connection.Close()
            End If
            Cmd.Connection.Open() 'Abro la Db
            Retorno = Cmd.ExecuteScalar() 'Ejecuta el procedimiento 
            Cmd.Connection.Close() 'Cierra La Db
            Return Retorno
        Finally
            Cmd.Connection.Close() 'Cierra La Db
        End Try

    End Function


    Public Overloads Function EjecutarAccion(ByVal NombreProcedimiento As String) As Boolean

        Try
            Cmd.CommandText = NombreProcedimiento 'Nombre del Procedimiento Almacenado
            If Cmd.Connection.State <> ConnectionState.Closed Then
                Cmd.Connection.Close()
            End If
            Cmd.Connection.Open() 'Abro la Db
            Cmd.ExecuteNonQuery() 'Ejecuta el procedimiento     
            Cmd.Connection.Close() 'Cierra La Db
            Return True
        Catch ex As Exception
            Cmd.Connection.Close() 'Cierra La Db
            Return False
        End Try

    End Function

    Public Overloads Function ObtenerParametro(ByVal NombreParametro As String) As Object

        Return Cmd.Parameters(NombreParametro).Value

    End Function

    Protected Sub Normalizar(ByRef ds As DataSet)

        For Each tabla As DataTable In ds.Tables
            For Each column As DataColumn In tabla.Columns
                If (column.DataType Is GetType(Integer)) Or (column.DataType Is GetType(Decimal)) Then
                    For Each row As DataRow In tabla.Rows
                        If row(column) Is System.DBNull.Value Then
                            row(column) = 0
                        End If
                    Next
                End If
            Next
        Next

    End Sub





End Class
