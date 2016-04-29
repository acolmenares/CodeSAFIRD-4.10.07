Imports Microsoft.ApplicationBlocks.Data
Imports ingNovar.Utilidades2

Public Class Ppto_PagosDAL

    Public Shared Function Insertar(ByVal Fecha As DateTime, ByVal Id_Tercero As Int32, ByVal Tipo As String, ByVal Id_Contrato As Int32, ByVal Fecha_Creacion As DateTime, ByVal Id_Usuario_Creacion As Int32, ByVal Fecha_Modificacion As DateTime, ByVal Id_Usuario_Modificacion As Int32, ByVal Id_OrdenCompra As Int32, ByVal idoutput As Int32) As Int32
        Return SqlHelper.ExecuteScalar(strCadenaConexion, "dbo.Ppto_PagosInsertar", isNothingToDBNull(Fecha), isNothingToDBNull(Id_Tercero), isNothingToDBNull(Tipo), isNothingToDBNull(Id_Contrato), isNothingToDBNull(Fecha_Creacion), isNothingToDBNull(Id_Usuario_Creacion), isNothingToDBNull(Fecha_Modificacion), isNothingToDBNull(Id_Usuario_Modificacion), isNothingToDBNull(Id_OrdenCompra), isNothingToDBNull(idoutput))
    End Function

    Public Shared Sub Actualizar(ByVal Id As Int32, ByVal Fecha As DateTime, ByVal Id_Tercero As Int32, ByVal Tipo As String, ByVal Id_Contrato As Int32, ByVal Fecha_Creacion As DateTime, ByVal Id_Usuario_Creacion As Int32, ByVal Fecha_Modificacion As DateTime, ByVal Id_Usuario_Modificacion As Int32, ByVal Id_OrdenCompra As Int32)
        SqlHelper.ExecuteNonQuery(strCadenaConexion, "dbo.Ppto_PagosActualizar", Id, isNothingToDBNull(Fecha), isNothingToDBNull(Id_Tercero), isNothingToDBNull(Tipo), isNothingToDBNull(Id_Contrato), isNothingToDBNull(Fecha_Creacion), isNothingToDBNull(Id_Usuario_Creacion), isNothingToDBNull(Fecha_Modificacion), isNothingToDBNull(Id_Usuario_Modificacion), isNothingToDBNull(Id_OrdenCompra))
    End Sub

    Public Shared Sub Eliminar(ByVal Id As Int32)
        SqlHelper.ExecuteScalar(strCadenaConexion, "dbo.Ppto_PagosEliminar", Id)
    End Sub

    Public Shared Function CargarTodos() As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.Ppto_PagosConsultarTodos")
    End Function

    Public Shared Function CargarPorID(ByVal Id As Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.Ppto_PagosConsultarPorID", Id)
    End Function
    
    Public Shared Function CargarPorId_Contrato(ByVal Id_Contrato As System.Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.Ppto_PagosConsultarPorId_Contrato", Id_Contrato)
    End Function

    Public Shared Function CargarPorId_OrdenCompra(ByVal Id_OrdenCompra As System.Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.Ppto_PagosConsultarPorId_OrdenCompra", Id_OrdenCompra)
    End Function

    Public Shared Function CargarPorId_Tercero(ByVal Id_Tercero As System.Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.Ppto_PagosConsultarPorId_Tercero", Id_Tercero)
    End Function

    Public Shared Function CarguePagos(ByVal wcamino As String) As Integer
        Return SqlHelper.ExecuteScalar(strCadenaConexion, "dbo.CargarPagos", isNothingToDBNull(wcamino))
    End Function

    Public Shared Sub ProcesarDatosPagos(ByVal wvalor As Int32)
        Dim cnn As New System.Data.SqlClient.SqlConnection(strCadenaConexion)
        Dim cmd As System.Data.SqlClient.SqlCommand
        cmd = New System.Data.SqlClient.SqlCommand()
        cnn.Open()
        cmd.Connection = cnn
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = "dbo.ProcesarDatosTerceros"

        cmd.Parameters.Add("@Valor", Data.SqlDbType.Int, 20).Value = isNothingToDBNull(wvalor)
        cmd.CommandTimeout = TiempoConexion
        cmd.ExecuteNonQuery()
        cnn.Close()
    End Sub

    Public Shared Sub SubirPagos()
        SqlHelper.ExecuteNonQuery(strCadenaConexion, "dbo.SubirPagosDetalle")
    End Sub

    Public Shared Sub GenerarPagos()
        SqlHelper.ExecuteNonQuery(strCadenaConexion, "dbo.GenerarPagos")
    End Sub

End Class

