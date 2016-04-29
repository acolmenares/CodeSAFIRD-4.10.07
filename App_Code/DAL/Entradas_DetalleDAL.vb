Imports Microsoft.ApplicationBlocks.Data
Imports ingNovar.Utilidades2

Public Class Entradas_DetalleDAL

    Public Shared Function Insertar(ByVal Id_Entrada As Int32, ByVal Id_Producto As Int32, ByVal Id_Capacidad As Int32, ByVal Cantidad As Double, ByVal Valor_Unitario As Double, ByVal Valor_Descuento As Double, ByVal Fecha_Creacion As DateTime, ByVal Id_Usuario_Creacion As Int32, ByVal Fecha_Modificacion As DateTime, ByVal Id_Usuario_Modificacion As Int32, ByVal id_salida_detalle_entrada As Int32) As Int32
        Return SqlHelper.ExecuteScalar(strCadenaConexion, "dbo.Entradas_DetalleInsertar", isNothingToDBNull(Id_Entrada), isNothingToDBNull(Id_Producto), isNothingToDBNull(Id_Capacidad), isNothingToDBNull(Cantidad), isNothingToDBNull(Valor_Unitario), isNothingToDBNull(Valor_Descuento), isNothingToDBNull(Fecha_Creacion), isNothingToDBNull(Id_Usuario_Creacion), isNothingToDBNull(Fecha_Modificacion), isNothingToDBNull(Id_Usuario_Modificacion), isNothingToDBNull(id_salida_detalle_entrada))
    End Function

    Public Shared Sub Actualizar(ByVal Id As Int32, ByVal Id_Entrada As Int32, ByVal Id_Producto As Int32, ByVal Id_Capacidad As Int32, ByVal Cantidad As Double, ByVal Valor_Unitario As Double, ByVal Valor_Descuento As Double, ByVal Fecha_Creacion As DateTime, ByVal Id_Usuario_Creacion As Int32, ByVal Fecha_Modificacion As DateTime, ByVal Id_Usuario_Modificacion As Int32, ByVal id_salida_detalle_entrada As Int32)
        SqlHelper.ExecuteNonQuery(strCadenaConexion, "dbo.Entradas_DetalleActualizar", Id, isNothingToDBNull(Id_Entrada), isNothingToDBNull(Id_Producto), isNothingToDBNull(Id_Capacidad), isNothingToDBNull(Cantidad), isNothingToDBNull(Valor_Unitario), isNothingToDBNull(Valor_Descuento), isNothingToDBNull(Fecha_Creacion), isNothingToDBNull(Id_Usuario_Creacion), isNothingToDBNull(Fecha_Modificacion), isNothingToDBNull(Id_Usuario_Modificacion), isNothingToDBNull(id_salida_detalle_entrada))
    End Sub

    Public Shared Sub Eliminar(ByVal Id As Int32)
        SqlHelper.ExecuteScalar(strCadenaConexion, "dbo.Entradas_DetalleEliminar", Id)
    End Sub

    Public Shared Function CargarTodos() As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.Entradas_DetalleConsultarTodos")
    End Function

    Public Shared Function CargarPorID(ByVal Id As Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.Entradas_DetalleConsultarPorID", Id)
    End Function
    
    Public Shared Function CargarPorId_Entrada(ByVal Id_Entrada As System.Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.Entradas_DetalleConsultarPorId_Entrada", Id_Entrada)
    End Function


    Public Shared Function CargarPorId_Capacidad(ByVal Id_Capacidad As System.Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.Entradas_DetalleConsultarPorId_Capacidad", Id_Capacidad)
    End Function


    Public Shared Function CargarPorId_Producto(ByVal Id_Producto As System.Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.Entradas_DetalleConsultarPorId_Producto", Id_Producto)
    End Function


    Public Shared Function CargarPorId_Usuario_Creacion(ByVal Id_Usuario_Creacion As System.Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.Entradas_DetalleConsultarPorId_Usuario_Creacion", Id_Usuario_Creacion)
    End Function


    Public Shared Function CargarPorId_Usuario_Modificacion(ByVal Id_Usuario_Modificacion As System.Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.Entradas_DetalleConsultarPorId_Usuario_Modificacion", Id_Usuario_Modificacion)
    End Function



End Class

