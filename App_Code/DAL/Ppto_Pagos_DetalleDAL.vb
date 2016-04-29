Imports Microsoft.ApplicationBlocks.Data
Imports ingNovar.Utilidades2

Public Class Ppto_Pagos_DetalleDAL

    Public Shared Function Insertar(ByVal Id_Ppto_Pago As Int32, ByVal Ano As String, ByVal Periodo As String, ByVal Tipo As String, ByVal Numero As String, ByVal Fecha As DateTime, ByVal Cuenta As Double, ByVal Sucursal As String, ByVal Codigo_Tercero As String, ByVal Descripcion As String, ByVal Cheque As String, ByVal Debito As Double, ByVal Credito As Double, ByVal Nivel As String, ByVal Code As String, ByVal Tasa As Double, ByVal Nombre_Tercero As String) As Int32
        Return SqlHelper.ExecuteScalar(strCadenaConexion, "dbo.Ppto_Pagos_DetalleInsertar", isNothingToDBNull(Id_Ppto_Pago), isNothingToDBNull(Ano), isNothingToDBNull(Periodo), isNothingToDBNull(Tipo), isNothingToDBNull(Numero), isNothingToDBNull(Fecha), isNothingToDBNull(Cuenta), isNothingToDBNull(Sucursal), isNothingToDBNull(Codigo_Tercero), isNothingToDBNull(Descripcion), isNothingToDBNull(Cheque), isNothingToDBNull(Debito), isNothingToDBNull(Credito), isNothingToDBNull(Nivel), isNothingToDBNull(Code), isNothingToDBNull(Tasa), isNothingToDBNull(Nombre_Tercero))
    End Function

    Public Shared Sub Actualizar(ByVal Id As Int32, ByVal Id_Ppto_Pago As Int32, ByVal Ano As String, ByVal Periodo As String, ByVal Tipo As String, ByVal Numero As String, ByVal Fecha As DateTime, ByVal Cuenta As Double, ByVal Sucursal As String, ByVal Codigo_Tercero As String, ByVal Descripcion As String, ByVal Cheque As String, ByVal Debito As Double, ByVal Credito As Double, ByVal Nivel As String, ByVal Code As String, ByVal Tasa As Double, ByVal Nombre_Tercero As String)
        SqlHelper.ExecuteNonQuery(strCadenaConexion, "dbo.Ppto_Pagos_DetalleActualizar", Id, isNothingToDBNull(Id_Ppto_Pago), isNothingToDBNull(Ano), isNothingToDBNull(Periodo), isNothingToDBNull(Tipo), isNothingToDBNull(Numero), isNothingToDBNull(Fecha), isNothingToDBNull(Cuenta), isNothingToDBNull(Sucursal), isNothingToDBNull(Codigo_Tercero), isNothingToDBNull(Descripcion), isNothingToDBNull(Cheque), isNothingToDBNull(Debito), isNothingToDBNull(Credito), isNothingToDBNull(Nivel), isNothingToDBNull(Code), isNothingToDBNull(Tasa), isNothingToDBNull(Nombre_Tercero))
    End Sub

    Public Shared Sub Eliminar(ByVal Id As Int32)
        SqlHelper.ExecuteScalar(strCadenaConexion, "dbo.Ppto_Pagos_DetalleEliminar", Id)
    End Sub

    Public Shared Function CargarTodos() As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.Ppto_Pagos_DetalleConsultarTodos")
    End Function

    Public Shared Function CargarPorID(ByVal Id As Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.Ppto_Pagos_DetalleConsultarPorID", Id)
    End Function
    
    Public Shared Function CargarPorId_Ppto_Pago(ByVal Id_Ppto_Pago As System.Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.Ppto_Pagos_DetalleConsultarPorId_Ppto_Pago", Id_Ppto_Pago)
    End Function

    Public Shared Function CargarPorPendientes() As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.Ppto_Pagos_DetalleConsultarPorPendientes")
    End Function

    Public Shared Function CargarPorProcesadas() As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.Ppto_Pagos_DetalleConsultarPorProcesadas")
    End Function

End Class

