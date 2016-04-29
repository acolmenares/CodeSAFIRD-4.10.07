Imports Microsoft.ApplicationBlocks.Data
Imports ingNovar.Utilidades2

Public Class Ppto_TrasladosDAL

    Public Shared Function Insertar(ByVal Fecha As DateTime, ByVal Numero As String, ByVal Id_Nivel_Sale As Int32, ByVal Observaciones As String, ByVal Fecha_Creacion As DateTime, ByVal Id_Usuario_Creacion As Int32, ByVal Fecha_Modificacion As DateTime, ByVal Id_Usuario_Modificacion As Int32, ByVal Id_proyecto As Int32) As Int32
        Return SqlHelper.ExecuteScalar(strCadenaConexion, "dbo.Ppto_TrasladosInsertar", isNothingToDBNull(Fecha), isNothingToDBNull(Numero), isNothingToDBNull(Id_Nivel_Sale), isNothingToDBNull(Observaciones), isNothingToDBNull(Fecha_Creacion), isNothingToDBNull(Id_Usuario_Creacion), isNothingToDBNull(Fecha_Modificacion), isNothingToDBNull(Id_Usuario_Modificacion), isNothingToDBNull(Id_proyecto))
    End Function

    Public Shared Sub Actualizar(ByVal Id As Int32, ByVal Fecha As DateTime, ByVal Numero As String, ByVal Id_Nivel_Sale As Int32, ByVal Observaciones As String, ByVal Fecha_Creacion As DateTime, ByVal Id_Usuario_Creacion As Int32, ByVal Fecha_Modificacion As DateTime, ByVal Id_Usuario_Modificacion As Int32, ByVal Id_proyecto As Int32)
        SqlHelper.ExecuteNonQuery(strCadenaConexion, "dbo.Ppto_TrasladosActualizar", Id, isNothingToDBNull(Fecha), isNothingToDBNull(Numero), isNothingToDBNull(Id_Nivel_Sale), isNothingToDBNull(Observaciones), isNothingToDBNull(Fecha_Creacion), isNothingToDBNull(Id_Usuario_Creacion), isNothingToDBNull(Fecha_Modificacion), isNothingToDBNull(Id_Usuario_Modificacion), isNothingToDBNull(Id_Proyecto))
    End Sub

    Public Shared Sub Eliminar(ByVal Id As Int32)
        SqlHelper.ExecuteScalar(strCadenaConexion, "dbo.Ppto_TrasladosEliminar", Id)
    End Sub

    Public Shared Function CargarTodos(ByVal Id_Proyecto As Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.Ppto_TrasladosConsultarTodos", Id_Proyecto)
    End Function

    Public Shared Function CargarPorID(ByVal Id As Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.Ppto_TrasladosConsultarPorID", Id)
    End Function
    
    Public Shared Function CargarPorId_Nivel_Sale(ByVal Id_Nivel_Sale As System.Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.Ppto_TrasladosConsultarPorId_Nivel_Sale", Id_Nivel_Sale)
    End Function

    Public Shared Function CargarPorBusqueda(ByVal fechainicial As String, ByVal fechafinal As String, ByVal id_nivel As Int32, ByVal Id_Proyecto As Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.Ppto_TrasladosConsultarPorBusqueda", isNothingToDBNull(fechainicial), isNothingToDBNull(fechafinal), isNothingToDBNull(id_nivel), isNothingToDBNull(Id_Proyecto))
    End Function

End Class

