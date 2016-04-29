Imports Microsoft.ApplicationBlocks.Data
Imports ingNovar.Utilidades2

Public Class SucursalesDAL

    Public Shared Function Insertar(ByVal Id_Enlace As Int32, ByVal Nombre As String, ByVal Direccion As String, ByVal Contacto As String, ByVal Telefonos As String, ByVal Texto_Financiero As String) As Int32
        Return SqlHelper.ExecuteScalar(strCadenaConexion, "dbo.SucursalesInsertar", isNothingToDBNull(Id_Enlace), isNothingToDBNull(Nombre), isNothingToDBNull(Direccion), isNothingToDBNull(Contacto), isNothingToDBNull(Telefonos), isNothingToDBNull(Texto_Financiero))
    End Function

    Public Shared Sub Actualizar(ByVal Id As Int32, ByVal Id_Enlace As Int32, ByVal Nombre As String, ByVal Direccion As String, ByVal Contacto As String, ByVal Telefonos As String, ByVal Texto_Financiero As String)
        SqlHelper.ExecuteNonQuery(strCadenaConexion, "dbo.SucursalesActualizar", Id, isNothingToDBNull(Id_Enlace), isNothingToDBNull(Nombre), isNothingToDBNull(Direccion), isNothingToDBNull(Contacto), isNothingToDBNull(Telefonos), isNothingToDBNull(Texto_Financiero))
    End Sub

    Public Shared Sub Eliminar(ByVal Id As Int32)
        SqlHelper.ExecuteScalar(strCadenaConexion, "dbo.SucursalesEliminar", Id)
    End Sub

    Public Shared Function CargarTodos() As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.SucursalesConsultarTodos")
    End Function

    Public Shared Function CargarPorID(ByVal Id As Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.SucursalesConsultarPorID", Id)
    End Function
    
    Public Shared Function CargarPorId_Enlace(ByVal Id_Enlace As System.Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.SucursalesConsultarPorId_Enlace", Id_Enlace)
    End Function



End Class

