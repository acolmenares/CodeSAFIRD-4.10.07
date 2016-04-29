Imports System.Collections.Generic

Namespace BindHelper
    
    Partial Public NotInheritable Class Ppto_AjustesUIL
        
        Private Shared Sub Bind(ByVal control As ListControl, ByVal Lista As List(Of Ppto_AjustesBRL), Optional ByVal firstItem As ListItem = Nothing)
            control.DataSource = Lista
            control.DataValueField = "ID"
            control.DataTextField = "ID"
            control.DataBind
            If Not firstItem Is Nothing  Then
                control.Items.Insert(0, firstItem)
            End If
        End Sub
        
        Public Shared Function BindToListControl(ByVal control As ListControl, ByVal Id_Proyecto As Int32, Optional ByVal firstItem As ListItem = Nothing) As List(Of Ppto_AjustesBrl)
            Dim Lista As List(Of Ppto_AjustesBrl)
            Lista = Ppto_AjustesBrl.CargarTodos(Id_Proyecto)
            Bind(control, Lista, firstItem)
            Return Lista
        End Function
        
        Public Shared Function BindToListControlPorId_Contrato(ByVal control As ListControl, ByVal Id_Contrato As Int32, Optional ByVal firstItem As ListItem = Nothing) As List(Of Ppto_AjustesBrl)
            Dim Lista As List(Of Ppto_AjustesBrl)
            Lista = Ppto_AjustesBrl.CargarPorId_Contrato(Id_Contrato)
            Bind(control, Lista, firstItem)
            Return Lista
        End Function
    
        Public Shared Function BindToListControlPorId_OrdenCompra_Detalle(ByVal control As ListControl, ByVal Id_OrdenCompra_Detalle As Int32, Optional ByVal firstItem As ListItem = Nothing) As List(Of Ppto_AjustesBrl)
            Dim Lista As List(Of Ppto_AjustesBrl)
            Lista = Ppto_AjustesBrl.CargarPorId_OrdenCompra_Detalle(Id_OrdenCompra_Detalle)
            Bind(control, Lista, firstItem)
            Return Lista
        End Function
    End Class
    
End Namespace


