Imports System.Collections.Generic

Namespace BindHelper
    
    Partial Public NotInheritable Class Ppto_PagosUIL
        
        Private Shared Sub Bind(ByVal control As ListControl, ByVal Lista As List(Of Ppto_PagosBRL), Optional ByVal firstItem As ListItem = Nothing)
            control.DataSource = Lista
            control.DataValueField = "ID"
            control.DataTextField = "ID"
            control.DataBind
            If Not firstItem Is Nothing  Then
                control.Items.Insert(0, firstItem)
            End If
        End Sub
        
        Public Shared Function BindToListControl(ByVal control As ListControl, Optional ByVal firstItem As ListItem = Nothing) As List(Of Ppto_PagosBRL)
            Dim Lista As List(Of Ppto_PagosBRL)
            Lista = Ppto_PagosBRL.CargarTodos()
            Bind(control, Lista, firstItem)
            Return Lista
        End Function
        
        	Public Shared Function BindToListControlPorId_Contrato(ByVal control As ListControl, ByVal Id_Contrato As Int32, Optional ByVal firstItem As ListItem = Nothing) As List(Of Ppto_PagosBRL)
            Dim Lista As List(Of Ppto_PagosBRL)
            Lista = Ppto_PagosBRL.CargarPorId_Contrato(Id_Contrato)
            Bind(control, Lista, firstItem)
            Return Lista
    End Function
    
        Public Shared Function BindToListControlPorId_OrdenCompra(ByVal control As ListControl, ByVal Id_OrdenCompra As Int32, Optional ByVal firstItem As ListItem = Nothing) As List(Of Ppto_PagosBrl)
            Dim Lista As List(Of Ppto_PagosBrl)
            Lista = Ppto_PagosBrl.CargarPorId_OrdenCompra(Id_OrdenCompra)
            Bind(control, Lista, firstItem)
            Return Lista
        End Function
    
        Public Shared Function BindToListControlPorId_Tercero(ByVal control As ListControl, ByVal Id_Tercero As Int32, Optional ByVal firstItem As ListItem = Nothing) As List(Of Ppto_PagosBrl)
            Dim Lista As List(Of Ppto_PagosBrl)
            Lista = Ppto_PagosBrl.CargarPorId_Tercero(Id_Tercero)
            Bind(control, Lista, firstItem)
            Return Lista
        End Function
    
    End Class
    
End Namespace


