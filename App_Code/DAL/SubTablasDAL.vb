Imports Microsoft.ApplicationBlocks.Data
Imports ingNovar.Utilidades2

Public Class SubTablasDAL

    Public Shared Function Insertar(ByVal Id_Tabla As Int32, ByVal Descripcion As String, ByVal Id_Padre As Int32, ByVal Fecha_Creacion As DateTime, ByVal Id_Usuario_Creacion As Int32, ByVal Fecha_Modificacion As DateTime, ByVal Id_Usuario_Modificacion As Int32, ByVal orden As Integer, ByVal activo As Int32) As Int32
        Return SqlHelper.ExecuteScalar(strCadenaConexion, "dbo.SubTablasInsertar", isNothingToDBNull(Id_Tabla), isNothingToDBNull(Descripcion), isNothingToDBNull(Id_Padre), isNothingToDBNull(Fecha_Creacion), isNothingToDBNull(Id_Usuario_Creacion), isNothingToDBNull(Fecha_Modificacion), isNothingToDBNull(Id_Usuario_Modificacion), isNothingToDBNull(orden), isNothingToDBNull(activo))
    End Function

    Public Shared Sub Actualizar(ByVal Id As Int32, ByVal Id_Tabla As Int32, ByVal Descripcion As String, ByVal Id_Padre As Int32, ByVal Fecha_Creacion As DateTime, ByVal Id_Usuario_Creacion As Int32, ByVal Fecha_Modificacion As DateTime, ByVal Id_Usuario_Modificacion As Int32, ByVal orden As Integer, ByVal activo As Int32)
        SqlHelper.ExecuteNonQuery(strCadenaConexion, "dbo.SubTablasActualizar", Id, isNothingToDBNull(Id_Tabla), isNothingToDBNull(Descripcion), isNothingToDBNull(Id_Padre), isNothingToDBNull(Fecha_Creacion), isNothingToDBNull(Id_Usuario_Creacion), isNothingToDBNull(Fecha_Modificacion), isNothingToDBNull(Id_Usuario_Modificacion), isNothingToDBNull(orden), isNothingToDBNull(activo))
    End Sub

    Public Shared Sub Eliminar(ByVal Id As Int32)
        SqlHelper.ExecuteScalar(strCadenaConexion, "dbo.SubTablasEliminar", Id)
    End Sub

    Public Shared Function CargarTodos() As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.SubTablasConsultarTodos")
    End Function

    Public Shared Function CargarPorID(ByVal Id As Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.SubTablasConsultarPorID", Id)
    End Function
    
    Public Shared Function CargarPorId_Tabla(ByVal Id_Tabla As System.Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.SubTablasConsultarPorId_Tabla", Id_Tabla)
    End Function

    Public Shared Function CargarPorGruposLibres() As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.SubtablasConsultarGruposLibres")
    End Function

    Public Shared Function CargarPorId_Padre(ByVal Id_Padre As System.Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.SubTablasConsultarPorId_Padre", Id_Padre)
    End Function

    Public Shared Function CargarPorId_TablaPadre(ByVal Id_Tabla As System.Int32, ByVal Id_Padre As System.Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.SubTablasConsultarPorId_TablaPadre", Id_Tabla, Id_Padre)
    End Function

    Public Shared Function CargarPorId_Usuario_Creacion(ByVal Id_Usuario_Creacion As System.Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.SubTablasConsultarPorId_Usuario_Creacion", Id_Usuario_Creacion)
    End Function

    Public Shared Function CargarPorId_Usuario_Modificacion(ByVal Id_Usuario_Modificacion As System.Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.SubTablasConsultarPorId_Usuario_Modificacion", Id_Usuario_Modificacion)
    End Function

    Public Shared Function CargarPorBusqueda(ByVal idtabla As Integer, ByVal descripcion As String, ByVal idpadre As Integer) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.SubTablasConsultarBusqueda", isNothingToDBNull(idtabla), isNothingToDBNull(descripcion), isNothingToDBNull(idpadre))
    End Function

    Public Shared Function CargarPorActivo(ByVal Activo As System.Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.SubTablasConsultarPorId_Activo", Activo)
    End Function

    Public Shared Function CargarNivelesPorProyecto(ByVal Id_Proyecto As System.Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.SubtablasConsultarNivelesProyecto", Id_Proyecto)
    End Function

End Class

