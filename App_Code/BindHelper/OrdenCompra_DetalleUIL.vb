Imports System.Collections.Generic

Namespace BindHelper
    
    Partial Public NotInheritable Class OrdenCompra_DetalleUIL
        
        Private Shared Sub Bind(ByVal control As ListControl, ByVal Lista As List(Of OrdenCompra_DetalleBRL), Optional ByVal firstItem As ListItem = Nothing)
            control.DataSource = Lista
            control.DataValueField = "ID"
            control.DataTextField = "detalleysaldo"
            control.DataBind
            If Not firstItem Is Nothing  Then
                control.Items.Insert(0, firstItem)
            End If
        End Sub

        Private Shared Sub BindFinanzas(ByVal control As ListControl, ByVal Lista As List(Of OrdenCompra_DetalleBrl), Optional ByVal firstItem As ListItem = Nothing)
            control.DataSource = Lista
            control.DataValueField = "ID"
            control.DataTextField = "DescripcionFinanciera"
            control.DataBind()
            If Not firstItem Is Nothing Then
                control.Items.Insert(0, firstItem)
            End If
        End Sub

        Public Shared Function BindToListControl(ByVal control As ListControl, ByVal Id_proyecto As Int32, Optional ByVal firstItem As ListItem = Nothing) As List(Of OrdenCompra_DetalleBrl)
            Dim Lista As List(Of OrdenCompra_DetalleBrl)
            Lista = OrdenCompra_DetalleBrl.CargarTodos(Id_proyecto)
            Bind(control, Lista, firstItem)
            Return Lista
        End Function

        Public Shared Function BindToListControlFinanzas(ByVal control As ListControl, ByVal Id_proyecto As Int32, Optional ByVal firstItem As ListItem = Nothing) As List(Of OrdenCompra_DetalleBrl)
            Dim Lista As List(Of OrdenCompra_DetalleBrl)
            Lista = OrdenCompra_DetalleBrl.CargarTodos(Id_proyecto)
            BindFinanzas(control, Lista, firstItem)
            Return Lista
        End Function

        Public Shared Function BindToListControlPorId_OrdenCompra(ByVal control As ListControl, ByVal Id_OrdenCompra As Int32, Optional ByVal firstItem As ListItem = Nothing) As List(Of OrdenCompra_DetalleBrl)
            Dim Lista As List(Of OrdenCompra_DetalleBrl)
            Lista = OrdenCompra_DetalleBrl.CargarPorId_OrdenCompra(Id_OrdenCompra)
            Bind(control, Lista, firstItem)
            Return Lista
        End Function
    
        Public Shared Function BindToListControlPorId_Producto(ByVal control As ListControl, ByVal Id_Producto As Int32, Optional ByVal firstItem As ListItem = Nothing) As List(Of OrdenCompra_DetalleBrl)
            Dim Lista As List(Of OrdenCompra_DetalleBrl)
            Lista = OrdenCompra_DetalleBrl.CargarPorId_Producto(Id_Producto)
            Bind(control, Lista, firstItem)
            Return Lista
        End Function

        Public Shared Function BindToListControlPorId_Unidad_Medida(ByVal control As ListControl, ByVal Id_Unidad_Medida As Int32, Optional ByVal firstItem As ListItem = Nothing) As List(Of OrdenCompra_DetalleBrl)
            Dim Lista As List(Of OrdenCompra_DetalleBrl)
            Lista = OrdenCompra_DetalleBrl.CargarPorId_Unidad_Medida(Id_Unidad_Medida)
            Bind(control, Lista, firstItem)
            Return Lista
        End Function
    
        Public Shared Function BindToListControlPorId_Usuario_Creacion(ByVal control As ListControl, ByVal Id_Usuario_Creacion As Int32, Optional ByVal firstItem As ListItem = Nothing) As List(Of OrdenCompra_DetalleBrl)
            Dim Lista As List(Of OrdenCompra_DetalleBrl)
            Lista = OrdenCompra_DetalleBrl.CargarPorId_Usuario_Creacion(Id_Usuario_Creacion)
            Bind(control, Lista, firstItem)
            Return Lista
        End Function

        Public Shared Function BindToListControlPorId_Usuario_Inactivo(ByVal control As ListControl, ByVal Id_Usuario_Inactivo As Int32, Optional ByVal firstItem As ListItem = Nothing) As List(Of OrdenCompra_DetalleBrl)
            Dim Lista As List(Of OrdenCompra_DetalleBrl)
            Lista = OrdenCompra_DetalleBrl.CargarPorId_Usuario_Inactivo(Id_Usuario_Inactivo)
            Bind(control, Lista, firstItem)
            Return Lista
        End Function
    
        Public Shared Function BindToListControlPorId_Usuario_Modificacion(ByVal control As ListControl, ByVal Id_Usuario_Modificacion As Int32, Optional ByVal firstItem As ListItem = Nothing) As List(Of OrdenCompra_DetalleBrl)
            Dim Lista As List(Of OrdenCompra_DetalleBrl)
            Lista = OrdenCompra_DetalleBrl.CargarPorId_Usuario_Modificacion(Id_Usuario_Modificacion)
            Bind(control, Lista, firstItem)
            Return Lista
        End Function

        Public Shared Function BindToListControlPorId_ProductoYId_Regional(ByVal control As ListControl, ByVal Id_Producto As Int32, ByVal Id_Regional As Integer, Optional ByVal firstItem As ListItem = Nothing) As List(Of OrdenCompra_DetalleBrl)
            Dim Lista As List(Of OrdenCompra_DetalleBrl)
            Lista = OrdenCompra_DetalleBrl.CargarPorId_ProductoYId_Regional(Id_Producto, Id_Regional)
            Bind(control, Lista, firstItem)
            Return Lista
        End Function
    End Class
    
End Namespace


