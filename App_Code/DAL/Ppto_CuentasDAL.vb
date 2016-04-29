Imports Microsoft.ApplicationBlocks.Data
Imports ingNovar.Utilidades2

Public Class Ppto_CuentasDAL

    Public Shared Function Insertar(ByVal Id_Nivel As Int32, ByVal Codigo_Regional As String, ByVal Descripcion As String, ByVal visible As Boolean) As Int32
        Return SqlHelper.ExecuteScalar(strCadenaConexion, "dbo.Ppto_CuentasInsertar", isNothingToDBNull(Id_Nivel), isNothingToDBNull(Codigo_Regional), isNothingToDBNull(Descripcion), visible)
    End Function

    Public Shared Sub Actualizar(ByVal Id As Int32, ByVal Id_Nivel As Int32, ByVal Codigo_Regional As String, ByVal Descripcion As String, ByVal visible As Boolean)
        SqlHelper.ExecuteNonQuery(strCadenaConexion, "dbo.Ppto_CuentasActualizar", Id, isNothingToDBNull(Id_Nivel), isNothingToDBNull(Codigo_Regional), isNothingToDBNull(Descripcion), visible)
    End Sub

    Public Shared Sub Eliminar(ByVal Id As Int32)
        SqlHelper.ExecuteScalar(strCadenaConexion, "dbo.Ppto_CuentasEliminar", Id)
    End Sub

    Public Shared Function CargarTodos(ByVal Id_Proyecto As Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.Ppto_CuentasConsultarTodos", isNothingToDBNull(Id_Proyecto))
    End Function

    Public Shared Function CargarPorID(ByVal Id As Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.Ppto_CuentasConsultarPorID", Id)
    End Function

    Public Shared Function CargarPorId_Nivel(ByVal Id_Nivel As System.Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.Ppto_CuentasConsultarPorId_Nivel", Id_Nivel)
    End Function

End Class

