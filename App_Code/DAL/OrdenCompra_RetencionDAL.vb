Imports Microsoft.ApplicationBlocks.Data
Imports ingNovar.Utilidades2

Public Class OrdenCompra_RetencionDAL

    Public Shared Function Insertar(ByVal Id_OrdenCompra As Int32, ByVal Porcentaje As Double, ByVal Valor As Double, ByVal Id_Concepto As Int32, ByVal Base As Double, ByVal Fecha_Cierre As DateTime, ByVal Cierre As Boolean) As Int32
        Return SqlHelper.ExecuteScalar(strCadenaConexion, "dbo.OrdenCompra_RetencionInsertar", isNothingToDBNull(Id_OrdenCompra), isNothingToDBNull(Porcentaje), isNothingToDBNull(Valor), isNothingToDBNull(Id_Concepto), isNothingToDBNull(Base), isNothingToDBNull(Fecha_Cierre), isNothingToDBNull(Cierre))
    End Function

    Public Shared Sub Actualizar(ByVal Id As Int32, ByVal Id_OrdenCompra As Int32, ByVal Porcentaje As Double, ByVal Valor As Double, ByVal Id_Concepto As Int32, ByVal Base As Double, ByVal Fecha_Cierre As DateTime, ByVal Cierre As Boolean)
        SqlHelper.ExecuteNonQuery(strCadenaConexion, "dbo.OrdenCompra_RetencionActualizar", Id, isNothingToDBNull(Id_OrdenCompra), isNothingToDBNull(Porcentaje), isNothingToDBNull(Valor), isNothingToDBNull(Id_Concepto), isNothingToDBNull(Base), isNothingToDBNull(Fecha_Cierre), isNothingToDBNull(Cierre))
    End Sub

    Public Shared Sub Eliminar(ByVal Id As Int32)
        SqlHelper.ExecuteScalar(strCadenaConexion, "dbo.OrdenCompra_RetencionEliminar", Id)
    End Sub

    Public Shared Function CargarTodos() As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.OrdenCompra_RetencionConsultarTodos")
    End Function

    Public Shared Function CargarPorID(ByVal Id As Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.OrdenCompra_RetencionConsultarPorID", Id)
    End Function

    Public Shared Function CargarPorId_OrdenCompra(ByVal Id_OrdenCompra As System.Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.OrdenCompra_RetencionConsultarPorId_OrdenCompra", Id_OrdenCompra)
    End Function

    Public Shared Function CargarPorId_Concepto(ByVal Id_Concepto As System.Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.OrdenCompra_RetencionConsultarPorId_Concepto", Id_Concepto)
    End Function
End Class

