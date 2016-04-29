Imports Microsoft.ApplicationBlocks.Data
Imports ingNovar.Utilidades2

Public Class Entradas_ImpuestosDAL

    Public Shared Function Insertar(ByVal Id_Entrada As Int32, ByVal Porcentaje As Double, ByVal Valor As Double, ByVal Concepto As String) As Int32
        Return SqlHelper.ExecuteScalar(strCadenaConexion, "dbo.Entradas_ImpuestosInsertar", isNothingToDBNull(Id_Entrada), isNothingToDBNull(Porcentaje), isNothingToDBNull(Valor), isNothingToDBNull(Concepto))
    End Function

    Public Shared Sub Actualizar(ByVal Id As Int32, ByVal Id_OrdenCompra As Int32, ByVal Porcentaje As Double, ByVal Valor As Double, ByVal Concepto As String)
        SqlHelper.ExecuteNonQuery(strCadenaConexion, "dbo.Entradas_ImpuestosActualizar", Id, isNothingToDBNull(Id_OrdenCompra), isNothingToDBNull(Porcentaje), isNothingToDBNull(Valor), isNothingToDBNull(Concepto))
    End Sub

    Public Shared Sub Eliminar(ByVal Id As Int32)
        SqlHelper.ExecuteScalar(strCadenaConexion, "dbo.Entradas_ImpuestosEliminar", Id)
    End Sub

    Public Shared Function CargarTodos() As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.Entradas_ImpuestosConsultarTodos")
    End Function

    Public Shared Function CargarPorID(ByVal Id As Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.Entradas_ImpuestosConsultarPorID", Id)
    End Function

    Public Shared Function CargarPorId_Entrada(ByVal Id_Entrada As System.Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.Entradas_ImpuestosConsultarPorId_Entrada", Id_Entrada)
    End Function

End Class

