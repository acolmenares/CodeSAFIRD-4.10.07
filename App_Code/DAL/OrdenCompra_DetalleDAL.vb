Imports Microsoft.ApplicationBlocks.Data
Imports ingNovar.Utilidades2

Public Class OrdenCompra_DetalleDAL

    Public Shared Function Insertar(ByVal Id_OrdenCompra As Int32, ByVal Id_Producto As Int32, ByVal Id_Unidad_Medida As Int32, ByVal Cantidad As Double, ByVal Valor_Unitario As Double, ByVal Activo As Boolean, ByVal Motivo_Cancelacion As String, ByVal Id_Usuario_Inactivo As Int32, ByVal Fecha_Creacion As DateTime, ByVal Id_Usuario_Creacion As Int32, ByVal Fecha_Modificacion As DateTime, ByVal Id_Usuario_Modificacion As Int32, ByVal Id_Nivel As Int32, ByVal Descripcion_General As String, ByVal Codigo_Proyecto As String, ByVal Fecha_Cierre As DateTime, ByVal Cierre As Boolean) As Int32
        Return SqlHelper.ExecuteScalar(strCadenaConexion, "dbo.OrdenCompra_DetalleInsertar", isNothingToDBNull(Id_OrdenCompra), isNothingToDBNull(Id_Producto), isNothingToDBNull(Id_Unidad_Medida), isNothingToDBNull(Cantidad), isNothingToDBNull(Valor_Unitario), isNothingToDBNull(Activo), isNothingToDBNull(Motivo_Cancelacion), isNothingToDBNull(Id_Usuario_Inactivo), isNothingToDBNull(Fecha_Creacion), isNothingToDBNull(Id_Usuario_Creacion), isNothingToDBNull(Fecha_Modificacion), isNothingToDBNull(Id_Usuario_Modificacion), isNothingToDBNull(Id_Nivel), isNothingToDBNull(Descripcion_General), isNothingToDBNull(Codigo_Proyecto), isNothingToDBNull(Fecha_Cierre), isNothingToDBNull(Cierre))
    End Function

    Public Shared Sub Actualizar(ByVal Id As Int32, ByVal Id_OrdenCompra As Int32, ByVal Id_Producto As Int32, ByVal Id_Unidad_Medida As Int32, ByVal Cantidad As Double, ByVal Valor_Unitario As Double, ByVal Activo As Boolean, ByVal Motivo_Cancelacion As String, ByVal Id_Usuario_Inactivo As Int32, ByVal Fecha_Creacion As DateTime, ByVal Id_Usuario_Creacion As Int32, ByVal Fecha_Modificacion As DateTime, ByVal Id_Usuario_Modificacion As Int32, ByVal Id_Nivel As Int32, ByVal Descripcion_General As String, ByVal Codigo_Proyecto As String, ByVal Fecha_Cierre As DateTime, ByVal Cierre As Boolean)
        SqlHelper.ExecuteNonQuery(strCadenaConexion, "dbo.OrdenCompra_DetalleActualizar", Id, isNothingToDBNull(Id_OrdenCompra), isNothingToDBNull(Id_Producto), isNothingToDBNull(Id_Unidad_Medida), isNothingToDBNull(Cantidad), isNothingToDBNull(Valor_Unitario), isNothingToDBNull(Activo), isNothingToDBNull(Motivo_Cancelacion), isNothingToDBNull(Id_Usuario_Inactivo), isNothingToDBNull(Fecha_Creacion), isNothingToDBNull(Id_Usuario_Creacion), isNothingToDBNull(Fecha_Modificacion), isNothingToDBNull(Id_Usuario_Modificacion), isNothingToDBNull(Id_Nivel), isNothingToDBNull(Descripcion_General), isNothingToDBNull(Codigo_Proyecto), isNothingToDBNull(Fecha_Cierre), isNothingToDBNull(Cierre))
    End Sub

    Public Shared Sub Eliminar(ByVal Id As Int32)
        SqlHelper.ExecuteScalar(strCadenaConexion, "dbo.OrdenCompra_DetalleEliminar", Id)
    End Sub

    Public Shared Function CargarTodos(ByVal Id_Proyecto As Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.OrdenCompra_DetalleConsultarTodos", Id_Proyecto)
    End Function

    Public Shared Function CargarPorID(ByVal Id As Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.OrdenCompra_DetalleConsultarPorID", Id)
    End Function
    
    Public Shared Function CargarPorId_OrdenCompra(ByVal Id_OrdenCompra As System.Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.OrdenCompra_DetalleConsultarPorId_OrdenCompra", Id_OrdenCompra)
    End Function

    Public Shared Function CargarPorId_Producto(ByVal Id_Producto As System.Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.OrdenCompra_DetalleConsultarPorId_Producto", Id_Producto)
    End Function

    Public Shared Function CargarPorId_Unidad_Medida(ByVal Id_Unidad_Medida As System.Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.OrdenCompra_DetalleConsultarPorId_Unidad_Medida", Id_Unidad_Medida)
    End Function

    Public Shared Function CargarPorId_Usuario_Creacion(ByVal Id_Usuario_Creacion As System.Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.OrdenCompra_DetalleConsultarPorId_Usuario_Creacion", Id_Usuario_Creacion)
    End Function

    Public Shared Function CargarPorId_Usuario_Inactivo(ByVal Id_Usuario_Inactivo As System.Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.OrdenCompra_DetalleConsultarPorId_Usuario_Inactivo", Id_Usuario_Inactivo)
    End Function

    Public Shared Function CargarPorId_Usuario_Modificacion(ByVal Id_Usuario_Modificacion As System.Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.OrdenCompra_DetalleConsultarPorId_Usuario_Modificacion", Id_Usuario_Modificacion)
    End Function

    Public Shared Function CargarPorId_ProductoyId_Regional(ByVal Id_Producto As System.Int32, ByVal id_regional As Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.OrdenCompra_DetalleConsultarPorId_ProductoyId_Regional", Id_Producto, id_regional)
    End Function

    Public Shared Function CargarPorId_Nivel(ByVal Id_Nivel As System.Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.OrdenCompra_DetalleConsultarPorId_Nivel", Id_Nivel)
    End Function

End Class

