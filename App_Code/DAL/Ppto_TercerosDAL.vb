Imports Microsoft.ApplicationBlocks.Data
Imports ingNovar.Utilidades2

Public Class Ppto_TercerosDAL

    Public Shared Function Insertar(ByVal Identificacion As String, ByVal Razon_Social As String, ByVal Direccion As String, ByVal Telefono1 As String, ByVal Telefono2 As String, ByVal DV As String, ByVal Nombre_Empresa As String) As Int32
        Return SqlHelper.ExecuteScalar(strCadenaConexion, "dbo.Ppto_TercerosInsertar", isNothingToDBNull(Identificacion), isNothingToDBNull(Razon_Social), isNothingToDBNull(Direccion), isNothingToDBNull(Telefono1), isNothingToDBNull(Telefono2), isNothingToDBNull(DV), isNothingToDBNull(Nombre_Empresa))
    End Function

    Public Shared Sub Actualizar(ByVal Id As Int32, ByVal Identificacion As String, ByVal Razon_Social As String, ByVal Direccion As String, ByVal Telefono1 As String, ByVal Telefono2 As String, ByVal DV As String, ByVal Nombre_Empresa As String)
        SqlHelper.ExecuteNonQuery(strCadenaConexion, "dbo.Ppto_TercerosActualizar", Id, isNothingToDBNull(Identificacion), isNothingToDBNull(Razon_Social), isNothingToDBNull(Direccion), isNothingToDBNull(Telefono1), isNothingToDBNull(Telefono2), isNothingToDBNull(DV), isNothingToDBNull(Nombre_empresa))
    End Sub

    Public Shared Sub Eliminar(ByVal Id As Int32)
        SqlHelper.ExecuteScalar(strCadenaConexion, "dbo.Ppto_TercerosEliminar", Id)
    End Sub

    Public Shared Function CargarTodos() As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.Ppto_TercerosConsultarTodos")
    End Function

    Public Shared Function CargarPorID(ByVal Id As Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.Ppto_TercerosConsultarPorID", Id)
    End Function

    Public Shared Function CargueTerceros(ByVal wcamino As String) As Integer
        Return SqlHelper.ExecuteScalar(strCadenaConexion, "dbo.CargarTerceros", isNothingToDBNull(wcamino))
    End Function

    Public Shared Sub ProcesarDatosTerceros(ByVal wvalor As Int32)
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

    Public Shared Function CargarPorNombreeIdentificacion(ByVal dato As String) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.Ppto_TercerosConsultarNombreeIdentificacion", isNothingToDBNull(dato))
    End Function
End Class

