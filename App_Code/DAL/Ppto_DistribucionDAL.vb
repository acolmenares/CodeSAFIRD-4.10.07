Imports Microsoft.ApplicationBlocks.Data
Imports ingNovar.Utilidades2

Public Class Ppto_DistribucionDAL

    Public Shared Function Insertar(ByVal Id_Nivel As Int32, ByVal Valor_USD As Double, ByVal Fecha As DateTime, ByVal Id_Ingreso As Int32, ByVal Id_Tipo_Unidad As Int32, ByVal Fecha_Creacion As DateTime, ByVal Id_Usuario_Creacion As Int32, ByVal Fecha_Modificacion As DateTime, ByVal Id_Usuario_Modificacion As Int32, ByVal Numero_Unidades As Double, ByVal Costo_Unidad As Double, ByVal Id_Proyecto As Int32) As Int32
        Return SqlHelper.ExecuteScalar(strCadenaConexion, "dbo.Ppto_DistribucionInsertar", isNothingToDBNull(Id_Nivel), isNothingToDBNull(Valor_USD), isNothingToDBNull(Fecha), isNothingToDBNull(Id_Ingreso), isNothingToDBNull(Id_Tipo_Unidad), isNothingToDBNull(Fecha_Creacion), isNothingToDBNull(Id_Usuario_Creacion), isNothingToDBNull(Fecha_Modificacion), isNothingToDBNull(Id_Usuario_Modificacion), isNothingToDBNull(Numero_Unidades), isNothingToDBNull(Costo_Unidad), isNothingToDBNull(Id_Proyecto))
    End Function

    Public Shared Sub Actualizar(ByVal Id As Int32, ByVal Id_Nivel As Int32, ByVal Valor_USD As Double, ByVal Fecha As DateTime, ByVal Id_Ingreso As Int32, ByVal Id_Tipo_Unidad As Int32, ByVal Fecha_Creacion As DateTime, ByVal Id_Usuario_Creacion As Int32, ByVal Fecha_Modificacion As DateTime, ByVal Id_Usuario_Modificacion As Int32, ByVal Numero_Unidades As Double, ByVal Costo_Unidad As Double, ByVal Id_Proyecto As Int32)
        SqlHelper.ExecuteNonQuery(strCadenaConexion, "dbo.Ppto_DistribucionActualizar", Id, isNothingToDBNull(Id_Nivel), isNothingToDBNull(Valor_USD), isNothingToDBNull(Fecha), isNothingToDBNull(Id_Ingreso), isNothingToDBNull(Id_Tipo_Unidad), isNothingToDBNull(Fecha_Creacion), isNothingToDBNull(Id_Usuario_Creacion), isNothingToDBNull(Fecha_Modificacion), isNothingToDBNull(Id_Usuario_Modificacion), isNothingToDBNull(Numero_Unidades), isNothingToDBNull(Costo_Unidad), isNothingToDBNull(Id_Proyecto))
    End Sub

    Public Shared Sub Eliminar(ByVal Id As Int32)
        SqlHelper.ExecuteScalar(strCadenaConexion, "dbo.Ppto_DistribucionEliminar", Id)
    End Sub

    Public Shared Function CargarTodos(ByVal Id_proyecto As Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.Ppto_DistribucionConsultarTodos", Id_proyecto)
    End Function

    Public Shared Function CargarPorID(ByVal Id As Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.Ppto_DistribucionConsultarPorID", Id)
    End Function
    
    Public Shared Function CargarPorId_Ingreso(ByVal Id_Ingreso As System.Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.Ppto_DistribucionConsultarPorId_Ingreso", Id_Ingreso)
    End Function

    Public Shared Function CargarPorId_Nivel(ByVal Id_Nivel As System.Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.Ppto_DistribucionConsultarPorId_Nivel", Id_Nivel)
    End Function

    Public Shared Function CargarPorId_Tipo_Unidad(ByVal Id_Tipo_Unidad As System.Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.Ppto_DistribucionConsultarPorId_Tipo_Unidad", Id_Tipo_Unidad)
    End Function

    Public Shared Function CargarPorBusqueda(ByVal fechainicial As String, ByVal fechafinal As String, ByVal Id_TipoUnidad As Int32, ByVal Id_Ingreso As Int32, ByVal Id_nivel As Int32, ByVal Id_Proyecto As Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.Ppto_DistribucionConsultarPorBusqueda", isNothingToDBNull(fechainicial), isNothingToDBNull(fechafinal), isNothingToDBNull(Id_TipoUnidad), isNothingToDBNull(Id_Ingreso), isNothingToDBNull(Id_nivel), isNothingToDBNull(Id_Proyecto))
    End Function

End Class

