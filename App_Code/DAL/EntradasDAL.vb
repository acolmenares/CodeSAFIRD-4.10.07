Imports Microsoft.ApplicationBlocks.Data
Imports ingNovar.Utilidades2

Public Class EntradasDAL

    Public Shared Function Insertar(ByVal Id_Tipo_Entrada As Int32, ByVal Id_Proveedor As Int32, ByVal Numero_Entrada As String, ByVal Numero_Factura_Proveedor As String, ByVal Fecha As DateTime, ByVal Id_Regional As Int32, ByVal Id_Regional_Envia As Int32, ByVal Id_Usuario_Recibio As Int32, ByVal Nombre_Entrego As String, ByVal Identificacion_Entrego As String, ByVal Observacion As String, ByVal Fecha_Creacion As DateTime, ByVal Id_Usuario_Creacion As Int32, ByVal Fecha_Modificacion As DateTime, ByVal Id_Usuario_Modificacion As Int32, ByVal id_salida_traslado As Int32) As Int32
        Return SqlHelper.ExecuteScalar(strCadenaConexion, "dbo.EntradasInsertar", isNothingToDBNull(Id_Tipo_Entrada), isNothingToDBNull(Id_Proveedor), isNothingToDBNull(Numero_Entrada), isNothingToDBNull(Numero_Factura_Proveedor), isNothingToDBNull(Fecha), isNothingToDBNull(Id_Regional), isNothingToDBNull(Id_Regional_Envia), isNothingToDBNull(Id_Usuario_Recibio), isNothingToDBNull(Nombre_Entrego), isNothingToDBNull(Identificacion_Entrego), isNothingToDBNull(Observacion), isNothingToDBNull(Fecha_Creacion), isNothingToDBNull(Id_Usuario_Creacion), isNothingToDBNull(Fecha_Modificacion), isNothingToDBNull(Id_Usuario_Modificacion), isNothingToDBNull(id_salida_traslado))
    End Function

    Public Shared Sub Actualizar(ByVal Id As Int32, ByVal Id_Tipo_Entrada As Int32, ByVal Id_Proveedor As Int32, ByVal Numero_Entrada As String, ByVal Numero_Factura_Proveedor As String, ByVal Fecha As DateTime, ByVal Id_Regional As Int32, ByVal Id_Regional_Envia As Int32, ByVal Id_Usuario_Recibio As Int32, ByVal Nombre_Entrego As String, ByVal Identificacion_Entrego As String, ByVal Observacion As String, ByVal Fecha_Creacion As DateTime, ByVal Id_Usuario_Creacion As Int32, ByVal Fecha_Modificacion As DateTime, ByVal Id_Usuario_Modificacion As Int32, ByVal Id_Salida_Traslado As Int32)
        SqlHelper.ExecuteNonQuery(strCadenaConexion, "dbo.EntradasActualizar", Id, isNothingToDBNull(Id_Tipo_Entrada), isNothingToDBNull(Id_Proveedor), isNothingToDBNull(Numero_Entrada), isNothingToDBNull(Numero_Factura_Proveedor), isNothingToDBNull(Fecha), isNothingToDBNull(Id_Regional), isNothingToDBNull(Id_Regional_Envia), isNothingToDBNull(Id_Usuario_Recibio), isNothingToDBNull(Nombre_Entrego), isNothingToDBNull(Identificacion_Entrego), isNothingToDBNull(Observacion), isNothingToDBNull(Fecha_Creacion), isNothingToDBNull(Id_Usuario_Creacion), isNothingToDBNull(Fecha_Modificacion), isNothingToDBNull(Id_Usuario_Modificacion), isNothingToDBNull(Id_Salida_Traslado))
    End Sub

    Public Shared Sub Eliminar(ByVal Id As Int32)
        SqlHelper.ExecuteScalar(strCadenaConexion, "dbo.EntradasEliminar", Id)
    End Sub

    Public Shared Function CargarTodos() As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.EntradasConsultarTodos")
    End Function

    Public Shared Function CargarPorID(ByVal Id As Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.EntradasConsultarPorID", Id)
    End Function
    
    Public Shared Function CargarPorId_Proveedor(ByVal Id_Proveedor As System.Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.EntradasConsultarPorId_Proveedor", Id_Proveedor)
    End Function

    Public Shared Function CargarPorId_Usuario_Recibio(ByVal Id_Usuario_Recibio As System.Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.EntradasConsultarPorId_Usuario_Recibio", Id_Usuario_Recibio)
    End Function

    Public Shared Function CargarPorId_Regional(ByVal Id_Regional As System.Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.EntradasConsultarPorId_Regional", Id_Regional)
    End Function

    Public Shared Function CargarPorId_Tipo_Entrada(ByVal Id_Tipo_Entrada As System.Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.EntradasConsultarPorId_Tipo_Entrada", Id_Tipo_Entrada)
    End Function

    Public Shared Function CargarPorId_Usuario_Creacion(ByVal Id_Usuario_Creacion As System.Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.EntradasConsultarPorId_Usuario_Creacion", Id_Usuario_Creacion)
    End Function

    Public Shared Function CargarPorId_Usuario_Modificacion(ByVal Id_Usuario_Modificacion As System.Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.EntradasConsultarPorId_Usuario_Modificacion", Id_Usuario_Modificacion)
    End Function

    Public Shared Function CargarPorId_Salida_Traslado(ByVal Id_Salida_Traslado As System.Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.EntradasConsultarPorId_Salida_Traslado", Id_Salida_Traslado)
    End Function

    Public Shared Function CargarPorBusqueda(ByVal Id_Regional As Int32, ByVal id_bodega As Int32, ByVal id_producto As Int32, ByVal fecha_inicial As String, ByVal fecha_final As String, ByVal numero As String, ByVal Id_tipo_entrada As Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.EntradasConsultarPorBusqueda", isNothingToDBNull(Id_Regional), isNothingToDBNull(id_bodega), isNothingToDBNull(id_producto), isNothingToDBNull(fecha_inicial), isNothingToDBNull(fecha_final), isNothingToDBNull(numero), Id_tipo_entrada)
    End Function

End Class

