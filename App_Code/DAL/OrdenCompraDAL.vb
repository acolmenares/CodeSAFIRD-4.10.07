Imports Microsoft.ApplicationBlocks.Data
Imports ingNovar.Utilidades2

Public Class OrdenCompraDAL

    Public Shared Function Insertar(ByVal Id_Regional As Int32, ByVal Numero As String, ByVal Fecha As DateTime, ByVal Tiempo_Entrega As String, ByVal Lugar_Entrega As String, ByVal Observaciones As String, ByVal Aprobacion_Finanzas_Ofc As Boolean, ByVal Aprobacion_Logistica_Ofc As Boolean, ByVal Aprobacion_Coordinacion As Boolean, ByVal Aprobacion_Operaciones As Boolean, ByVal Aprobacion_CooLogistica As Boolean, ByVal Fecha_Creacion As DateTime, ByVal Id_Usuario_Creacion As Int32, ByVal Fecha_Modificacion As DateTime, ByVal Id_Usuario_Modificacion As Int32, ByVal Id_Tercero As Int32, ByVal Id_Tipo_Orden As Int32, ByVal Aprobacion_Financiera As Boolean, ByVal Tasa As Double, ByVal Fecha_Cierre As DateTime, ByVal Cierre As Boolean, ByVal Forma_Pago As String, ByVal Id_Solicitado_Operaciones As Int32, ByVal Id_Proyecto As Int32) As Int32
        Return SqlHelper.ExecuteScalar(strCadenaConexion, "dbo.OrdenCompraInsertar", isNothingToDBNull(Id_Regional), isNothingToDBNull(Numero), isNothingToDBNull(Fecha), isNothingToDBNull(Tiempo_Entrega), isNothingToDBNull(Lugar_Entrega), isNothingToDBNull(Observaciones), isNothingToDBNull(Aprobacion_Finanzas_Ofc), isNothingToDBNull(Aprobacion_Logistica_Ofc), isNothingToDBNull(Aprobacion_Coordinacion), isNothingToDBNull(Aprobacion_Operaciones), isNothingToDBNull(Aprobacion_CooLogistica), isNothingToDBNull(Fecha_Creacion), isNothingToDBNull(Id_Usuario_Creacion), isNothingToDBNull(Fecha_Modificacion), isNothingToDBNull(Id_Usuario_Modificacion), isNothingToDBNull(Id_Tercero), isNothingToDBNull(Id_Tipo_Orden), isNothingToDBNull(Aprobacion_Financiera), isNothingToDBNull(Tasa), isNothingToDBNull(Fecha_Cierre), isNothingToDBNull(Cierre), isNothingToDBNull(Forma_Pago), isNothingToDBNull(Id_Solicitado_Operaciones), isNothingToDBNull(Id_Proyecto))
    End Function

    Public Shared Sub Actualizar(ByVal Id As Int32, ByVal Id_Regional As Int32, ByVal Numero As String, ByVal Fecha As DateTime, ByVal Tiempo_Entrega As String, ByVal Lugar_Entrega As String, ByVal Observaciones As String, ByVal Aprobacion_Finanzas_Ofc As Boolean, ByVal Aprobacion_Logistica_Ofc As Boolean, ByVal Aprobacion_Coordinacion As Boolean, ByVal Aprobacion_Operaciones As Boolean, ByVal Aprobacion_CooLogistica As Boolean, ByVal Fecha_Creacion As DateTime, ByVal Id_Usuario_Creacion As Int32, ByVal Fecha_Modificacion As DateTime, ByVal Id_Usuario_Modificacion As Int32, ByVal Id_Tercero As Int32, ByVal Id_Tipo_Orden As Int32, ByVal Aprobacion_Financiera As Boolean, ByVal Tasa As Double, ByVal Fecha_Cierre As DateTime, ByVal Cierre As Boolean, ByVal Forma_Pago As String, ByVal Id_Solicitado_Operaciones As Int32, ByVal Id_Proyecto As Int32)
        SqlHelper.ExecuteNonQuery(strCadenaConexion, "dbo.OrdenCompraActualizar", Id, isNothingToDBNull(Id_Regional), isNothingToDBNull(Numero), isNothingToDBNull(Fecha), isNothingToDBNull(Tiempo_Entrega), isNothingToDBNull(Lugar_Entrega), isNothingToDBNull(Observaciones), isNothingToDBNull(Aprobacion_Finanzas_Ofc), isNothingToDBNull(Aprobacion_Logistica_Ofc), isNothingToDBNull(Aprobacion_Coordinacion), isNothingToDBNull(Aprobacion_Operaciones), isNothingToDBNull(Aprobacion_CooLogistica), isNothingToDBNull(Fecha_Creacion), isNothingToDBNull(Id_Usuario_Creacion), isNothingToDBNull(Fecha_Modificacion), isNothingToDBNull(Id_Usuario_Modificacion), isNothingToDBNull(Id_Tercero), isNothingToDBNull(Id_Tipo_Orden), isNothingToDBNull(Aprobacion_Financiera), isNothingToDBNull(Tasa), isNothingToDBNull(Fecha_Cierre), isNothingToDBNull(Cierre), isNothingToDBNull(Forma_Pago), isNothingToDBNull(Id_Solicitado_Operaciones), isNothingToDBNull(Id_Proyecto))
    End Sub

    Public Shared Sub Eliminar(ByVal Id As Int32)
        SqlHelper.ExecuteScalar(strCadenaConexion, "dbo.OrdenCompraEliminar", Id)
    End Sub

    Public Shared Function CargarTodos(ByVal Id_Proyecto As Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.OrdenCompraConsultarTodos", Id_Proyecto)
    End Function

    Public Shared Function CargarPorID(ByVal Id As Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.OrdenCompraConsultarPorID", Id)
    End Function
    
    Public Shared Function CargarPorId_Regional(ByVal Id_Regional As System.Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.OrdenCompraConsultarPorId_Regional", Id_Regional)
    End Function

    Public Shared Function CargarPorId_Usuario_Creacion(ByVal Id_Usuario_Creacion As System.Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.OrdenCompraConsultarPorId_Usuario_Creacion", Id_Usuario_Creacion)
    End Function

    Public Shared Function CargarPorId_Usuario_Modificacion(ByVal Id_Usuario_Modificacion As System.Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.OrdenCompraConsultarPorId_Usuario_Modificacion", Id_Usuario_Modificacion)
    End Function

    Public Shared Function CargarPorAprobarLogOfc(ByVal Numero As String, ByVal Id_Tercero As Int32, ByVal Id_regional As Int32, ByVal Fecha_inicial As String, ByVal Fecha_final As String, ByVal Id_Proyecto As Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.OrdenCompraConsultarporAprobarLogOfc", isNothingToDBNull(Numero), isNothingToDBNull(Id_Tercero), isNothingToDBNull(Id_regional), isNothingToDBNull(Fecha_inicial), isNothingToDBNull(Fecha_final), isNothingToDBNull(Id_Proyecto))
    End Function

    Public Shared Function CargarPorAprobarFinOfc(ByVal Numero As String, ByVal Id_Tercero As Int32, ByVal Id_regional As Int32, ByVal Fecha_inicial As String, ByVal Fecha_final As String, ByVal Id_Proyecto As Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.OrdenCompraConsultarporAprobarFinOfc", isNothingToDBNull(Numero), isNothingToDBNull(Id_Tercero), isNothingToDBNull(Id_regional), isNothingToDBNull(Fecha_inicial), isNothingToDBNull(Fecha_final), isNothingToDBNull(Id_Proyecto))
    End Function

    Public Shared Function CargarPorAprobarCooLog(ByVal Numero As String, ByVal Id_Tercero As Int32, ByVal Id_regional As Int32, ByVal Fecha_inicial As String, ByVal Fecha_final As String, ByVal Id_Proyecto As Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.OrdenCompraConsultarporAprobarCooLog", isNothingToDBNull(Numero), isNothingToDBNull(Id_Tercero), isNothingToDBNull(Id_regional), isNothingToDBNull(Fecha_inicial), isNothingToDBNull(Fecha_final), isNothingToDBNull(Id_Proyecto))
    End Function

    Public Shared Function CargarPorAprobarDirOpe(ByVal Numero As String, ByVal Id_Tercero As Int32, ByVal Id_regional As Int32, ByVal Fecha_inicial As String, ByVal Fecha_final As String, ByVal Id_Proyecto As Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.OrdenCompraConsultarporAprobarDirOpe", isNothingToDBNull(Numero), isNothingToDBNull(Id_Tercero), isNothingToDBNull(Id_regional), isNothingToDBNull(Fecha_inicial), isNothingToDBNull(Fecha_final), isNothingToDBNull(Id_Proyecto))
    End Function

    Public Shared Function CargarPorAprobarCooReg(ByVal Numero As String, ByVal Id_Tercero As Int32, ByVal Id_regional As Int32, ByVal Fecha_inicial As String, ByVal Fecha_final As String, ByVal Id_Proyecto As Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.OrdenCompraConsultarporAprobarCoordinador", isNothingToDBNull(Numero), isNothingToDBNull(Id_Tercero), isNothingToDBNull(Id_regional), isNothingToDBNull(Fecha_inicial), isNothingToDBNull(Fecha_final), isNothingToDBNull(Id_Proyecto))
    End Function

    Public Shared Function CargarPorAprobarDirFin(ByVal Numero As String, ByVal Id_Tercero As Int32, ByVal Id_regional As Int32, ByVal Fecha_inicial As String, ByVal Fecha_final As String, ByVal Id_Proyecto As Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.OrdenCompraConsultarporAprobarDirFin", isNothingToDBNull(Numero), isNothingToDBNull(Id_Tercero), isNothingToDBNull(Id_regional), isNothingToDBNull(Fecha_inicial), isNothingToDBNull(Fecha_final), isNothingToDBNull(Id_Proyecto))
    End Function

    Public Shared Function CargarPorBusqueda(ByVal Id_Regional As Int32, ByVal Numero As String, ByVal Fecha_Inicial As String, ByVal Fecha_Final As String, ByVal Id_Producto As Integer, ByVal Id_tercero As Integer, ByVal Id_Proyecto As Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.OrdenCompraConsultarPorBusqueda", isNothingToDBNull(Id_Regional), isNothingToDBNull(Numero), isNothingToDBNull(Fecha_Inicial), isNothingToDBNull(Fecha_Final), isNothingToDBNull(Id_Producto), isNothingToDBNull(Id_tercero), isNothingToDBNull(Id_Proyecto))
    End Function

    Public Shared Function CargarPorId_Tercero(ByVal Id_Tercero As System.Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.OrdenCompraConsultarPorId_Tercero", Id_Tercero)
    End Function

    Public Shared Function CargarPorId_Tipo_Orden(ByVal Id_Tipo_Orden As System.Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.OrdenCompraConsultarPorId_Tipo_Orden", Id_Tipo_Orden)
    End Function

    Public Shared Function CargarPorNumero(ByVal Numero As String) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.OrdenCompraConsultarPorNumero", Numero)
    End Function

End Class

