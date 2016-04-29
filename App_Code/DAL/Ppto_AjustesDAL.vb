Imports Microsoft.ApplicationBlocks.Data
Imports ingNovar.Utilidades2

Public Class Ppto_AjustesDAL

    Public Shared Function Insertar(ByVal Fecha As DateTime, ByVal Tipo As String, ByVal Id_Contrato As Int32, ByVal Id_OrdenCompra_Detalle As Int32, ByVal Valor_USD As Double, ByVal TRM As Double, ByVal Valor_COP As Double, ByVal Aprobado_DirFin As Boolean, ByVal Fecha_Creacion As DateTime, ByVal Id_Usuario_Creacion As Int32, ByVal Fecha_Modificacion As DateTime, ByVal Id_Usuario_Modificacion As Int32, ByVal observaciones As String, ByVal Id_proyecto As Int32) As Int32
        Return SqlHelper.ExecuteScalar(strCadenaConexion, "dbo.Ppto_AjustesInsertar", isNothingToDBNull(Fecha), isNothingToDBNull(Tipo), isNothingToDBNull(Id_Contrato), isNothingToDBNull(Id_OrdenCompra_Detalle), isNothingToDBNull(Valor_USD), isNothingToDBNull(TRM), isNothingToDBNull(Valor_COP), isNothingToDBNull(Aprobado_DirFin), isNothingToDBNull(Fecha_Creacion), isNothingToDBNull(Id_Usuario_Creacion), isNothingToDBNull(Fecha_Modificacion), isNothingToDBNull(Id_Usuario_Modificacion), observaciones, isNothingToDBNull(Id_proyecto))
    End Function

    Public Shared Sub Actualizar(ByVal Id As Int32, ByVal Fecha As DateTime, ByVal Tipo As String, ByVal Id_Contrato As Int32, ByVal Id_OrdenCompra_Detalle As Int32, ByVal Valor_USD As Double, ByVal TRM As Double, ByVal Valor_COP As Double, ByVal Aprobado_DirFin As Boolean, ByVal Fecha_Creacion As DateTime, ByVal Id_Usuario_Creacion As Int32, ByVal Fecha_Modificacion As DateTime, ByVal Id_Usuario_Modificacion As Int32, ByVal observaciones As String, ByVal Id_proyecto As Int32)
        SqlHelper.ExecuteNonQuery(strCadenaConexion, "dbo.Ppto_AjustesActualizar", Id, isNothingToDBNull(Fecha), isNothingToDBNull(Tipo), isNothingToDBNull(Id_Contrato), isNothingToDBNull(Id_OrdenCompra_Detalle), isNothingToDBNull(Valor_USD), isNothingToDBNull(TRM), isNothingToDBNull(Valor_COP), isNothingToDBNull(Aprobado_DirFin), isNothingToDBNull(Fecha_Creacion), isNothingToDBNull(Id_Usuario_Creacion), isNothingToDBNull(Fecha_Modificacion), isNothingToDBNull(Id_Usuario_Modificacion), observaciones, isNothingToDBNull(Id_proyecto))
    End Sub

    Public Shared Sub Eliminar(ByVal Id As Int32)
        SqlHelper.ExecuteScalar(strCadenaConexion, "dbo.Ppto_AjustesEliminar", Id)
    End Sub

    Public Shared Function CargarTodos(ByVal Id_proyecto As Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.Ppto_AjustesConsultarTodos", isNothingToDBNull(Id_proyecto))
    End Function

    Public Shared Function CargarPorID(ByVal Id As Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.Ppto_AjustesConsultarPorID", Id)
    End Function
    
    Public Shared Function CargarPorId_Contrato(ByVal Id_Contrato As System.Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.Ppto_AjustesConsultarPorId_Contrato", Id_Contrato)
    End Function

    Public Shared Function CargarPorId_OrdenCompra_Detalle(ByVal Id_OrdenCompra_Detalle As System.Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.Ppto_AjustesConsultarPorId_OrdenCompra_Detalle", Id_OrdenCompra_Detalle)
    End Function

    Public Shared Function CargarPorBusqueda(ByVal fechainicial As String, ByVal fechafinal As String, ByVal tipo As String, ByVal Id_contrato As Int32, ByVal Id_Orden As Int32, ByVal Id_Proyecto As Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.Ppto_AjustesConsultarPorBusqueda", isNothingToDBNull(fechainicial), isNothingToDBNull(fechafinal), isNothingToDBNull(tipo), isNothingToDBNull(Id_contrato), isNothingToDBNull(Id_Orden), isNothingToDBNull(Id_Proyecto))
    End Function

End Class

