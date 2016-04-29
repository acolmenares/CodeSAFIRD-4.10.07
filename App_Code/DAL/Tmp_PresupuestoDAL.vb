Imports Microsoft.ApplicationBlocks.Data
Imports ingNovar.Utilidades2

Public Class Tmp_PresupuestoDAL

    Public Shared Function Insertar(ByVal Descripcion As String, ByVal Id_padre As Int32, ByVal Id_Tipo_Unidad As Int32, ByVal Numero_Unidades As Double, ByVal Costo_Unidad As Double, ByVal Incremento As Double, ByVal Reduccion As Double, ByVal OrdenCompra As Double, ByVal Contratos As Double, ByVal Ejecutado As Double) As Int32
        Return SqlHelper.ExecuteScalar(strCadenaConexion, "dbo.Tmp_PresupuestoInsertar", isNothingToDBNull(Descripcion), isNothingToDBNull(Id_padre), isNothingToDBNull(Id_Tipo_Unidad), isNothingToDBNull(Numero_Unidades), isNothingToDBNull(Costo_Unidad), isNothingToDBNull(Incremento), isNothingToDBNull(Reduccion), isNothingToDBNull(OrdenCompra), isNothingToDBNull(Contratos), isNothingToDBNull(Ejecutado))
    End Function

    Public Shared Sub Actualizar(ByVal Id As Int32, ByVal Descripcion As String, ByVal Id_padre As Int32, ByVal Id_Tipo_Unidad As Int32, ByVal Numero_Unidades As Double, ByVal Costo_Unidad As Double, ByVal Incremento As Double, ByVal Reduccion As Double, ByVal OrdenCompra As Double, ByVal Contratos As Double, ByVal Ejecutado As Double)
        SqlHelper.ExecuteNonQuery(strCadenaConexion, "dbo.Tmp_PresupuestoActualizar", Id, isNothingToDBNull(Descripcion), isNothingToDBNull(Id_padre), isNothingToDBNull(Id_Tipo_Unidad), isNothingToDBNull(Numero_Unidades), isNothingToDBNull(Costo_Unidad), isNothingToDBNull(Incremento), isNothingToDBNull(Reduccion), isNothingToDBNull(OrdenCompra), isNothingToDBNull(Contratos), isNothingToDBNull(Ejecutado))
    End Sub

    Public Shared Sub Eliminar(ByVal Id As Int32)
        SqlHelper.ExecuteScalar(strCadenaConexion, "dbo.Tmp_PresupuestoEliminar", Id)
    End Sub

    Public Shared Function CargarTodos() As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.Tmp_PresupuestoConsultarTodos")
    End Function

    Public Shared Function CargarPorID(ByVal Id As Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.Tmp_PresupuestoConsultarPorID", Id)
    End Function
    
    Public Shared Function CargarPorId_Padre(ByVal Id_Padre As System.Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.Tmp_PresupuestoConsultarPorId_Padre", isNothingToDBNull(Id_Padre))
    End Function

    Public Shared Function CargarPorId_Tipo_Unidad(ByVal Id_Tipo_Unidad As System.Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.Tmp_PresupuestoConsultarPorId_Tipo_Unidad", Id_Tipo_Unidad)
    End Function

    Public Shared Sub CargarPresupuesto()
        Dim cnn As New System.Data.SqlClient.SqlConnection(strCadenaConexion)
        Dim cmd As System.Data.SqlClient.SqlCommand
        cmd = New System.Data.SqlClient.SqlCommand()
        cnn.Open()
        cmd.Connection = cnn
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = "dbo.CargarEstadoPresupuestal"

        cmd.CommandTimeout = TiempoConexion
        cmd.ExecuteNonQuery()
        cnn.Close()

    End Sub


End Class

