Imports Microsoft.ApplicationBlocks.Data
Imports ingNovar.Utilidades2

Public Class Entradas_DistribucionDAL

    Public Shared Function Insertar(ByVal Id_Entrada_Detalle As Int32, ByVal Id_Bodega As Int32, ByVal Cantidad As Double, ByVal Id_Capacidad As Int32, ByVal Observacion As String, ByVal Fecha_Creacion As DateTime, ByVal Id_Usuario_Creacion As Int32, ByVal Fecha_Modificacion As DateTime, ByVal Id_Usuario_Modificacion As Int32) As Int32
        Return SqlHelper.ExecuteScalar(strCadenaConexion, "dbo.Entradas_DistribucionInsertar", isNothingToDBNull(Id_Entrada_Detalle), isNothingToDBNull(Id_Bodega), isNothingToDBNull(Cantidad), isNothingToDBNull(Id_Capacidad), isNothingToDBNull(Observacion), isNothingToDBNull(Fecha_Creacion), isNothingToDBNull(Id_Usuario_Creacion), isNothingToDBNull(Fecha_Modificacion), isNothingToDBNull(Id_Usuario_Modificacion))
    End Function

    Public Shared Sub Actualizar(ByVal Id As Int32, ByVal Id_Entrada_Detalle As Int32, ByVal Id_Bodega As Int32, ByVal Cantidad As Double, ByVal Id_Capacidad As Int32, ByVal Observacion As String, ByVal Fecha_Creacion As DateTime, ByVal Id_Usuario_Creacion As Int32, ByVal Fecha_Modificacion As DateTime, ByVal Id_Usuario_Modificacion As Int32)
        SqlHelper.ExecuteNonQuery(strCadenaConexion, "dbo.Entradas_DistribucionActualizar", Id, isNothingToDBNull(Id_Entrada_Detalle), isNothingToDBNull(Id_Bodega), isNothingToDBNull(Cantidad), isNothingToDBNull(Id_Capacidad), isNothingToDBNull(Observacion), isNothingToDBNull(Fecha_Creacion), isNothingToDBNull(Id_Usuario_Creacion), isNothingToDBNull(Fecha_Modificacion), isNothingToDBNull(Id_Usuario_Modificacion))
    End Sub

    Public Shared Sub Eliminar(ByVal Id As Int32)
        SqlHelper.ExecuteScalar(strCadenaConexion, "dbo.Entradas_DistribucionEliminar", Id)
    End Sub

    Public Shared Function CargarTodos() As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.Entradas_DistribucionConsultarTodos")
    End Function

    Public Shared Function CargarPorID(ByVal Id As Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.Entradas_DistribucionConsultarPorID", Id)
    End Function
    
    Public Shared Function CargarPorId_Bodega(ByVal Id_Bodega As System.Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.Entradas_DistribucionConsultarPorId_Bodega", Id_Bodega)
    End Function

    Public Shared Function CargarPorId_Capacidad(ByVal Id_Capacidad As System.Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.Entradas_DistribucionConsultarPorId_Capacidad", Id_Capacidad)
    End Function

    Public Shared Function CargarPorId_Entrada_Detalle(ByVal Id_Entrada_Detalle As System.Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.Entradas_DistribucionConsultarPorId_Entrada_Detalle", Id_Entrada_Detalle)
    End Function

    Public Shared Function CargarPorId_Usuario_Creacion(ByVal Id_Usuario_Creacion As System.Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.Entradas_DistribucionConsultarPorId_Usuario_Creacion", Id_Usuario_Creacion)
    End Function

    Public Shared Function CargarPorId_Usuario_Modificacion(ByVal Id_Usuario_Modificacion As System.Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.Entradas_DistribucionConsultarPorId_Usuario_Modificacion", Id_Usuario_Modificacion)
    End Function

    Public Shared Function CargarPorId_BodegayId_Producto(ByVal Id_Bodega As System.Int32, ByVal id_producto As Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.Entradas_DistribucionConsultarPorId_BodegayId_Producto", Id_Bodega, id_producto)
    End Function

End Class

