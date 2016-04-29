Imports Microsoft.ApplicationBlocks.Data
Imports ingNovar.Utilidades2

Public Class OrdenCompra_DocumentosDAL

    Public Shared Function Insertar(ByVal Id_OrdenCompra As Int32, ByVal Nombre_Archivo As String, ByVal Descripcion As String) As Int32
        Return SqlHelper.ExecuteScalar(strCadenaConexion, "dbo.OrdenCompra_DocumentosInsertar", isNothingToDBNull(Id_OrdenCompra), isNothingToDBNull(Nombre_Archivo), isNothingToDBNull(Descripcion))
    End Function

    Public Shared Sub Actualizar(ByVal Id As Int32, ByVal Id_OrdenCompra As Int32, ByVal Nombre_Archivo As String, ByVal Descripcion As String)
        SqlHelper.ExecuteNonQuery(strCadenaConexion, "dbo.OrdenCompra_DocumentosActualizar", Id, isNothingToDBNull(Id_OrdenCompra), isNothingToDBNull(Nombre_Archivo), isNothingToDBNull(Descripcion))
    End Sub

    Public Shared Sub Eliminar(ByVal Id As Int32)
        SqlHelper.ExecuteScalar(strCadenaConexion, "dbo.OrdenCompra_DocumentosEliminar", Id)
    End Sub

    Public Shared Function CargarTodos() As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.OrdenCompra_DocumentosConsultarTodos")
    End Function

    Public Shared Function CargarPorID(ByVal Id As Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.OrdenCompra_DocumentosConsultarPorID", Id)
    End Function

    Public Shared Function CargarPorId_OrdenCompra(ByVal Id_OrdenCompra As System.Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.OrdenCompra_DocumentosConsultarPorId_OrdenCompra", Id_OrdenCompra)
    End Function

End Class

