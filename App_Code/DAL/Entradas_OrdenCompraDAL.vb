Imports Microsoft.ApplicationBlocks.Data
Imports ingNovar.Utilidades2

Public Class Entradas_OrdenCompraDAL

    Public Shared Function Insertar(ByVal Id_Entrada_Detalle As Int32, ByVal Cantidad As Double, ByVal Id_OrdenCompra_Detalle As Int32, ByVal Fecha_Creacion As DateTime, ByVal Id_Usuario_Creacion As Int32, ByVal Fecha_Modificacion As DateTime, ByVal Id_Usuario_Modificacion As Int32) As Int32
        Return SqlHelper.ExecuteScalar(strCadenaConexion, "dbo.Entradas_OrdenCompraInsertar", isNothingToDBNull(Id_Entrada_Detalle), isNothingToDBNull(Cantidad), isNothingToDBNull(Id_OrdenCompra_Detalle), isNothingToDBNull(Fecha_Creacion), isNothingToDBNull(Id_Usuario_Creacion), isNothingToDBNull(Fecha_Modificacion), isNothingToDBNull(Id_Usuario_Modificacion))
    End Function

    Public Shared Sub Actualizar(ByVal Id As Int32, ByVal Id_Entrada_Detalle As Int32, ByVal Cantidad As Double, ByVal Id_OrdenCompra_Detalle As Int32, ByVal Fecha_Creacion As DateTime, ByVal Id_Usuario_Creacion As Int32, ByVal Fecha_Modificacion As DateTime, ByVal Id_Usuario_Modificacion As Int32)
        SqlHelper.ExecuteNonQuery(strCadenaConexion, "dbo.Entradas_OrdenCompraActualizar", Id, isNothingToDBNull(Id_Entrada_Detalle), isNothingToDBNull(Cantidad), isNothingToDBNull(Id_OrdenCompra_Detalle), isNothingToDBNull(Fecha_Creacion), isNothingToDBNull(Id_Usuario_Creacion), isNothingToDBNull(Fecha_Modificacion), isNothingToDBNull(Id_Usuario_Modificacion))
    End Sub

    Public Shared Sub Eliminar(ByVal Id As Int32)
        SqlHelper.ExecuteScalar(strCadenaConexion, "dbo.Entradas_OrdenCompraEliminar", Id)
    End Sub

    Public Shared Function CargarTodos() As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.Entradas_OrdenCompraConsultarTodos")
    End Function

    Public Shared Function CargarPorID(ByVal Id As Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.Entradas_OrdenCompraConsultarPorID", Id)
    End Function
    
    Public Shared Function CargarPorId_Entrada_Detalle(ByVal Id_Entrada_Detalle As System.Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.Entradas_OrdenCompraConsultarPorId_Entrada_Detalle", Id_Entrada_Detalle)
    End Function

    Public Shared Function CargarPorId_OrdenCompra_Detalle(ByVal Id_OrdenCompra_Detalle As System.Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.Entradas_OrdenCompraConsultarPorId_OrdenCompra_Detalle", Id_OrdenCompra_Detalle)
    End Function

    Public Shared Function CantidadEntradaOC(ByVal Id_OrdenCompra_Detalle As System.Int32) As Double
        Return SqlHelper.ExecuteScalar(strCadenaConexion, "dbo.Entradas_OrdenCompraConsultarPorCantidadEntradaOC", Id_OrdenCompra_Detalle)
    End Function

End Class

