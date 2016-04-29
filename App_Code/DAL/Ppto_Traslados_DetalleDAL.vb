Imports Microsoft.ApplicationBlocks.Data
Imports ingNovar.Utilidades2

Public Class Ppto_Traslados_DetalleDAL

    Public Shared Function Insertar(ByVal Id_Traslado As Int32, ByVal Id_Nivel_Entra As Int32, ByVal Valor_USD As Double, ByVal TRM As Double, ByVal Valor_COP As Double, ByVal Fecha_Creacion As DateTime, ByVal Id_Usuario_Creacion As Int32, ByVal Fecha_Modificacion As DateTime, ByVal Id_Usuario_Modificacion As Int32) As Int32
        Return SqlHelper.ExecuteScalar(strCadenaConexion, "dbo.Ppto_Traslados_DetalleInsertar", isNothingToDBNull(Id_Traslado), isNothingToDBNull(Id_Nivel_Entra), isNothingToDBNull(Valor_USD), isNothingToDBNull(TRM), isNothingToDBNull(Valor_COP), isNothingToDBNull(Fecha_Creacion), isNothingToDBNull(Id_Usuario_Creacion), isNothingToDBNull(Fecha_Modificacion), isNothingToDBNull(Id_Usuario_Modificacion))
    End Function

    Public Shared Sub Actualizar(ByVal Id As Int32, ByVal Id_Traslado As Int32, ByVal Id_Nivel_Entra As Int32, ByVal Valor_USD As Double, ByVal TRM As Double, ByVal Valor_COP As Double, ByVal Fecha_Creacion As DateTime, ByVal Id_Usuario_Creacion As Int32, ByVal Fecha_Modificacion As DateTime, ByVal Id_Usuario_Modificacion As Int32)
        SqlHelper.ExecuteNonQuery(strCadenaConexion, "dbo.Ppto_Traslados_DetalleActualizar", Id, isNothingToDBNull(Id_Traslado), isNothingToDBNull(Id_Nivel_Entra), isNothingToDBNull(Valor_USD), isNothingToDBNull(TRM), isNothingToDBNull(Valor_COP), isNothingToDBNull(Fecha_Creacion), isNothingToDBNull(Id_Usuario_Creacion), isNothingToDBNull(Fecha_Modificacion), isNothingToDBNull(Id_Usuario_Modificacion))
    End Sub

    Public Shared Sub Eliminar(ByVal Id As Int32)
        SqlHelper.ExecuteScalar(strCadenaConexion, "dbo.Ppto_Traslados_DetalleEliminar", Id)
    End Sub

    Public Shared Function CargarTodos() As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.Ppto_Traslados_DetalleConsultarTodos")
    End Function

    Public Shared Function CargarPorID(ByVal Id As Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.Ppto_Traslados_DetalleConsultarPorID", Id)
    End Function
    
    Public Shared Function CargarPorId_Nivel_Entra(ByVal Id_Nivel_Entra As System.Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.Ppto_Traslados_DetalleConsultarPorId_Nivel_Entra", Id_Nivel_Entra)
    End Function


    Public Shared Function CargarPorId_Traslado(ByVal Id_Traslado As System.Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.Ppto_Traslados_DetalleConsultarPorId_Traslado", Id_Traslado)
    End Function



End Class

