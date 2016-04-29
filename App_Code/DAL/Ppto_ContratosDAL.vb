Imports Microsoft.ApplicationBlocks.Data
Imports ingNovar.Utilidades2

Public Class Ppto_ContratosDAL

    Public Shared Function Insertar(ByVal Fecha As DateTime, ByVal Numero As String, ByVal Id_Tercero As Int32, ByVal Valor_USD As Double, ByVal TRM As Double, ByVal Valor_COP As Double, ByVal Id_Nivel As Int32, ByVal Observaciones As String, ByVal Fecha_Creacion As DateTime, ByVal Id_Usuario_Creacion As Int32, ByVal Fecha_Modificacion As DateTime, ByVal Id_Usuario_Modificacion As Int32, ByVal Id_Tipo_Orden As Int32, ByVal Aprobacion_Financiera As Boolean, ByVal Aprobacion_Pais As Boolean, ByVal Codigo_Proyecto As String, ByVal Fecha_Inicial_Contrato As DateTime, ByVal Fecha_Final_Contrato As DateTime, ByVal Id_Proyecto As Int32) As Int32
        Return SqlHelper.ExecuteScalar(strCadenaConexion, "dbo.Ppto_ContratosInsertar", isNothingToDBNull(Fecha), isNothingToDBNull(Numero), isNothingToDBNull(Id_Tercero), isNothingToDBNull(Valor_USD), isNothingToDBNull(TRM), isNothingToDBNull(Valor_COP), isNothingToDBNull(Id_Nivel), isNothingToDBNull(Observaciones), isNothingToDBNull(Fecha_Creacion), isNothingToDBNull(Id_Usuario_Creacion), isNothingToDBNull(Fecha_Modificacion), isNothingToDBNull(Id_Usuario_Modificacion), isNothingToDBNull(Id_Tipo_Orden), isNothingToDBNull(Aprobacion_Financiera), isNothingToDBNull(Aprobacion_Pais), isNothingToDBNull(Codigo_Proyecto), isNothingToDBNull(Fecha_Inicial_Contrato), isNothingToDBNull(Fecha_Final_Contrato), isNothingToDBNull(Id_Proyecto))
    End Function

    Public Shared Sub Actualizar(ByVal Id As Int32, ByVal Fecha As DateTime, ByVal Numero As String, ByVal Id_Tercero As Int32, ByVal Valor_USD As Double, ByVal TRM As Double, ByVal Valor_COP As Double, ByVal Id_Nivel As Int32, ByVal Observaciones As String, ByVal Fecha_Creacion As DateTime, ByVal Id_Usuario_Creacion As Int32, ByVal Fecha_Modificacion As DateTime, ByVal Id_Usuario_Modificacion As Int32, ByVal Id_Tipo_Orden As Int32, ByVal Aprobacion_Financiera As Boolean, ByVal Aprobacion_Pais As Boolean, ByVal Codigo_Proyecto As String, ByVal Fecha_Inicial_Contrato As DateTime, ByVal Fecha_Final_Contrato As DateTime, ByVal Id_Proyecto As Int32)
        SqlHelper.ExecuteNonQuery(strCadenaConexion, "dbo.Ppto_ContratosActualizar", Id, isNothingToDBNull(Fecha), isNothingToDBNull(Numero), isNothingToDBNull(Id_Tercero), isNothingToDBNull(Valor_USD), isNothingToDBNull(TRM), isNothingToDBNull(Valor_COP), isNothingToDBNull(Id_Nivel), isNothingToDBNull(Observaciones), isNothingToDBNull(Fecha_Creacion), isNothingToDBNull(Id_Usuario_Creacion), isNothingToDBNull(Fecha_Modificacion), isNothingToDBNull(Id_Usuario_Modificacion), isNothingToDBNull(Id_Tipo_Orden), isNothingToDBNull(Aprobacion_Financiera), isNothingToDBNull(Aprobacion_Pais), isNothingToDBNull(Codigo_Proyecto), isNothingToDBNull(Fecha_Inicial_Contrato), isNothingToDBNull(Fecha_Final_Contrato), isNothingToDBNull(Id_Proyecto))
    End Sub

    Public Shared Sub Eliminar(ByVal Id As Int32)
        SqlHelper.ExecuteScalar(strCadenaConexion, "dbo.Ppto_ContratosEliminar", Id)
    End Sub

    Public Shared Function CargarTodos(ByVal Id_Proyecto As Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.Ppto_ContratosConsultarTodos", Id_Proyecto)
    End Function

    Public Shared Function CargarPorID(ByVal Id As Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.Ppto_ContratosConsultarPorID", Id)
    End Function
    
    Public Shared Function CargarPorId_Nivel(ByVal Id_Nivel As System.Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.Ppto_ContratosConsultarPorId_Nivel", Id_Nivel)
    End Function

    Public Shared Function CargarPorId_Tercero(ByVal Id_Tercero As System.Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.Ppto_ContratosConsultarPorId_Tercero", Id_Tercero)
    End Function

    Public Shared Function CargarPorId_Tipo_Orden(ByVal Id_Tipo_Orden As System.Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.Ppto_ContratosConsultarPorId_Tipo_Orden", Id_Tipo_Orden)
    End Function

    Public Shared Function CargarPorAprobacionFinanciera(ByVal Id_Proyecto As Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.Ppto_ContratosConsultarPorAprobacion_Financiera", Id_Proyecto)
    End Function

    Public Shared Function CargarPorAprobacionPais(ByVal Id_Proyecto As Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.Ppto_ContratosConsultarPorAprobacion_Pais", Id_Proyecto)
    End Function

    Public Shared Function CargarPorBusqueda(ByVal fechainicial As String, ByVal fechafinal As String, ByVal numero As String, ByVal Id_tercero As Int32, ByVal Id_nivel As Int32, ByVal Id_Proyecto As Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.Ppto_ContratosConsultarPorBusqueda", isNothingToDBNull(fechainicial), isNothingToDBNull(fechafinal), isNothingToDBNull(numero), isNothingToDBNull(Id_tercero), isNothingToDBNull(Id_nivel), isNothingToDBNull(Id_Proyecto))
    End Function

End Class

