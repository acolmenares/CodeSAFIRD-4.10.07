Imports Microsoft.ApplicationBlocks.Data
Imports ingNovar.Utilidades2

Public Class Ppto_Cuentas_DetalleDAL

    Public Shared Function Insertar(ByVal Id_Ppto_Cuentas As Int32, ByVal Cuenta As String) As Int32
        Return SqlHelper.ExecuteScalar(strCadenaConexion, "dbo.Ppto_Cuentas_DetalleInsertar", isNothingToDBNull(Id_Ppto_Cuentas), isNothingToDBNull(Cuenta))
    End Function

    Public Shared Sub Actualizar(ByVal Id As Int32, ByVal Id_Ppto_Cuentas As Int32, ByVal Cuenta As String)
        SqlHelper.ExecuteNonQuery(strCadenaConexion, "dbo.Ppto_Cuentas_DetalleActualizar", Id, isNothingToDBNull(Id_Ppto_Cuentas), isNothingToDBNull(Cuenta))
    End Sub

    Public Shared Sub Eliminar(ByVal Id As Int32)
        SqlHelper.ExecuteScalar(strCadenaConexion, "dbo.Ppto_Cuentas_DetalleEliminar", Id)
    End Sub

    Public Shared Function CargarTodos() As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.Ppto_Cuentas_DetalleConsultarTodos")
    End Function

    Public Shared Function CargarPorID(ByVal Id As Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.Ppto_Cuentas_DetalleConsultarPorID", Id)
    End Function

    Public Shared Function CargarPorId_Ppto_Cuentas(ByVal Id_Ppto_Cuentas As System.Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.Ppto_Cuentas_DetalleConsultarPorId_Ppto_Cuenta", Id_Ppto_Cuentas)
    End Function


End Class

