Imports Microsoft.ApplicationBlocks.Data
Imports ingNovar.Utilidades2

Public Class Ppto_IngresosDAL

    Public Shared Function Insertar(ByVal Fecha As DateTime, ByVal Nombre_Entrega As String, ByVal Valor_USD As Double, ByVal TRM As Double, ByVal Valor_COP As Double, ByVal Observaciones As String, ByVal Fecha_Creacion As DateTime, ByVal Id_Usuario_Creacion As Int32, ByVal Fecha_Modificacion As DateTime, ByVal Id_Usuario_Modificacion As Int32, ByVal Id_Proyecto As Int32) As Int32
        Return SqlHelper.ExecuteScalar(strCadenaConexion, "dbo.Ppto_IngresosInsertar", isNothingToDBNull(Fecha), isNothingToDBNull(Nombre_Entrega), isNothingToDBNull(Valor_USD), isNothingToDBNull(TRM), isNothingToDBNull(Valor_COP), isNothingToDBNull(Observaciones), isNothingToDBNull(Fecha_Creacion), isNothingToDBNull(Id_Usuario_Creacion), isNothingToDBNull(Fecha_Modificacion), isNothingToDBNull(Id_Usuario_Modificacion), isNothingToDBNull(Id_Proyecto))
    End Function

    Public Shared Sub Actualizar(ByVal Id As Int32, ByVal Fecha As DateTime, ByVal Nombre_Entrega As String, ByVal Valor_USD As Double, ByVal TRM As Double, ByVal Valor_COP As Double, ByVal Observaciones As String, ByVal Fecha_Creacion As DateTime, ByVal Id_Usuario_Creacion As Int32, ByVal Fecha_Modificacion As DateTime, ByVal Id_Usuario_Modificacion As Int32, ByVal Id_Proyecto As Int32)
        SqlHelper.ExecuteNonQuery(strCadenaConexion, "dbo.Ppto_IngresosActualizar", Id, isNothingToDBNull(Fecha), isNothingToDBNull(Nombre_Entrega), isNothingToDBNull(Valor_USD), isNothingToDBNull(TRM), isNothingToDBNull(Valor_COP), isNothingToDBNull(Observaciones), isNothingToDBNull(Fecha_Creacion), isNothingToDBNull(Id_Usuario_Creacion), isNothingToDBNull(Fecha_Modificacion), isNothingToDBNull(Id_Usuario_Modificacion), isNothingToDBNull(Id_Proyecto))
    End Sub

    Public Shared Sub Eliminar(ByVal Id As Int32)
        SqlHelper.ExecuteScalar(strCadenaConexion, "dbo.Ppto_IngresosEliminar", Id)
    End Sub

    Public Shared Function CargarTodos(ByVal Id_Proyecto As Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.Ppto_IngresosConsultarTodos", Id_Proyecto)
    End Function

    Public Shared Function CargarPorID(ByVal Id As Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.Ppto_IngresosConsultarPorID", Id)
    End Function
    
    Public Shared Function CargarPorBusqueda(ByVal fechainicial As String, ByVal fechafinal As String, ByVal nombre As String, ByVal Id_Proyecto As Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.Ppto_IngresosConsultarPorBusqueda", isNothingToDBNull(fechainicial), isNothingToDBNull(fechafinal), isNothingToDBNull(nombre), isNothingToDBNull(Id_Proyecto))
    End Function


End Class

