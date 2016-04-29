Imports System.Collections.Generic
Imports System.Data


Namespace BindHelper
    
    Partial Public NotInheritable Class OrdenCompraUIL
        
        Private Shared Sub Bind(ByVal control As ListControl, ByVal Lista As List(Of OrdenCompraBRL), Optional ByVal firstItem As ListItem = Nothing)
            control.DataSource = Lista
            control.DataValueField = "ID"
            control.DataTextField = "DescripcionOrdenCompra"
            control.DataBind
            If Not firstItem Is Nothing  Then
                control.Items.Insert(0, firstItem)
            End If
        End Sub
        
        Public Shared Function BindToListControl(ByVal control As ListControl, ByVal Id_Proyecto As Int32, Optional ByVal firstItem As ListItem = Nothing) As List(Of OrdenCompraBrl)
            Dim Lista As List(Of OrdenCompraBrl)
            Lista = OrdenCompraBrl.CargarTodos(Id_Proyecto)
            Bind(control, Lista, firstItem)
            Return Lista
        End Function

        Public Shared Function BindToListControlPorId_Regional(ByVal control As ListControl, ByVal Id_Regional As Int32, Optional ByVal firstItem As ListItem = Nothing) As List(Of OrdenCompraBrl)
            Dim Lista As List(Of OrdenCompraBrl)
            Lista = OrdenCompraBrl.CargarPorId_Regional(Id_Regional)
            Bind(control, Lista, firstItem)
            Return Lista
        End Function
    
        Public Shared Function BindToListControlPorId_Usuario_Creacion(ByVal control As ListControl, ByVal Id_Usuario_Creacion As Int32, Optional ByVal firstItem As ListItem = Nothing) As List(Of OrdenCompraBrl)
            Dim Lista As List(Of OrdenCompraBrl)
            Lista = OrdenCompraBrl.CargarPorId_Usuario_Creacion(Id_Usuario_Creacion)
            Bind(control, Lista, firstItem)
            Return Lista
        End Function
    
        Public Shared Function BindToListControlPorId_Usuario_Modificacion(ByVal control As ListControl, ByVal Id_Usuario_Modificacion As Int32, Optional ByVal firstItem As ListItem = Nothing) As List(Of OrdenCompraBrl)
            Dim Lista As List(Of OrdenCompraBrl)
            Lista = OrdenCompraBrl.CargarPorId_Usuario_Modificacion(Id_Usuario_Modificacion)
            Bind(control, Lista, firstItem)
            Return Lista
        End Function

        Public Shared Function BindToListControlPorId_Tercero(ByVal control As ListControl, ByVal Id_Tercero As Int32, Optional ByVal firstItem As ListItem = Nothing) As List(Of OrdenCompraBrl)
            Dim Lista As List(Of OrdenCompraBrl)
            Lista = OrdenCompraBrl.CargarPorId_Tercero(Id_Tercero)
            Bind(control, Lista, firstItem)
            Return Lista
        End Function


    End Class
    
End Namespace


