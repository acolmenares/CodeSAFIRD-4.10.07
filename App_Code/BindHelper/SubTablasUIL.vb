Imports System.Collections.Generic

Namespace BindHelper
    
    Partial Public NotInheritable Class SubTablasUIL
        
        Private Shared Sub Bind(ByVal control As ListControl, ByVal Lista As List(Of SubTablasBRL), Optional ByVal firstItem As ListItem = Nothing)
            control.DataSource = Lista
            control.DataValueField = "ID"
            control.DataTextField = "Descripcion"
            control.DataBind
            If Not firstItem Is Nothing  Then
                control.Items.Insert(0, firstItem)
            End If
        End Sub

        Public Shared Function BindToListControl(ByVal control As ListControl, Optional ByVal firstItem As ListItem = Nothing) As List(Of SubTablasBrl)
            Dim Lista As List(Of SubTablasBrl)
            Lista = SubTablasBrl.CargarTodos()
            Bind(control, Lista, firstItem)
            Return Lista
        End Function
        
        Public Shared Function BindToListControlPorId_Padre(ByVal control As ListControl, ByVal Id_Padre As Int32, Optional ByVal firstItem As ListItem = Nothing) As List(Of SubTablasBrl)
            Dim Lista As List(Of SubTablasBrl)
            Lista = SubTablasBrl.CargarPorId_Padre(Id_Padre)
            Bind(control, Lista, firstItem)
            Return Lista
        End Function

        Public Shared Function BindToListControlPorId_Tabla(ByVal control As ListControl, ByVal Id_Tabla As Int32, Optional ByVal firstItem As ListItem = Nothing) As List(Of SubTablasBrl)
            Dim Lista As List(Of SubTablasBrl)
            Lista = SubTablasBrl.CargarPorId_Tabla(Id_Tabla)
            Bind(control, Lista, firstItem)
            Return Lista
        End Function
    
        Public Shared Function BindToListControlPorId_Usuario_Creacion(ByVal control As ListControl, ByVal Id_Usuario_Creacion As Int32, Optional ByVal firstItem As ListItem = Nothing) As List(Of SubTablasBrl)
            Dim Lista As List(Of SubTablasBrl)
            Lista = SubTablasBrl.CargarPorId_Usuario_Creacion(Id_Usuario_Creacion)
            Bind(control, Lista, firstItem)
            Return Lista
        End Function
    
        Public Shared Function BindToListControlPorId_Usuario_Modificacion(ByVal control As ListControl, ByVal Id_Usuario_Modificacion As Int32, Optional ByVal firstItem As ListItem = Nothing) As List(Of SubTablasBrl)
            Dim Lista As List(Of SubTablasBrl)
            Lista = SubTablasBrl.CargarPorId_Usuario_Modificacion(Id_Usuario_Modificacion)
            Bind(control, Lista, firstItem)
            Return Lista
        End Function


        '
        '  Otra seccion de Listas
        '

        Private Shared Sub BindTotal(ByVal control As ListControl, ByVal Lista As List(Of SubTablasBrl), Optional ByVal firstItem As ListItem = Nothing)
            control.DataSource = Lista
            control.DataValueField = "ID"
            control.DataTextField = "Descripcion_PadreHijo"
            control.DataBind()
            If Not firstItem Is Nothing Then
                control.Items.Insert(0, firstItem)
            End If
        End Sub

        Public Shared Function BindTotalToListControlPorId_Tabla(ByVal control As ListControl, ByVal Id_Proyecto As Int32, Optional ByVal firstItem As ListItem = Nothing) As List(Of SubTablasBrl)
            Dim Lista As List(Of SubTablasBrl)
            Lista = SubTablasBrl.CargarPorNivelesPorProyecto(Id_Proyecto)
            BindTotal(control, Lista, firstItem)
            Return Lista
        End Function
    End Class
End Namespace


