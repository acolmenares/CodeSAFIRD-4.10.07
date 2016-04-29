Imports System.Collections.Generic

Namespace BindHelper
    
    Partial Public NotInheritable Class Ppto_Traslados_DetalleUIL
        
        Private Shared Sub Bind(ByVal control As ListControl, ByVal Lista As List(Of Ppto_Traslados_DetalleBRL), Optional ByVal firstItem As ListItem = Nothing)
            control.DataSource = Lista
            control.DataValueField = "ID"
            control.DataTextField = "ID"
            control.DataBind
            If Not firstItem Is Nothing  Then
                control.Items.Insert(0, firstItem)
            End If
        End Sub
        
        Public Shared Function BindToListControl(ByVal control As ListControl, Optional ByVal firstItem As ListItem = Nothing) As List(Of Ppto_Traslados_DetalleBRL)
            Dim Lista As List(Of Ppto_Traslados_DetalleBRL)
            Lista = Ppto_Traslados_DetalleBRL.CargarTodos()
            Bind(control, Lista, firstItem)
            Return Lista
        End Function
        
        	Public Shared Function BindToListControlPorId_Nivel_Entra(ByVal control As ListControl, ByVal Id_Nivel_Entra As Int32, Optional ByVal firstItem As ListItem = Nothing) As List(Of Ppto_Traslados_DetalleBRL)
            Dim Lista As List(Of Ppto_Traslados_DetalleBRL)
            Lista = Ppto_Traslados_DetalleBRL.CargarPorId_Nivel_Entra(Id_Nivel_Entra)
            Bind(control, Lista, firstItem)
            Return Lista
    End Function
    


	Public Shared Function BindToListControlPorId_Traslado(ByVal control As ListControl, ByVal Id_Traslado As Int32, Optional ByVal firstItem As ListItem = Nothing) As List(Of Ppto_Traslados_DetalleBRL)
            Dim Lista As List(Of Ppto_Traslados_DetalleBRL)
            Lista = Ppto_Traslados_DetalleBRL.CargarPorId_Traslado(Id_Traslado)
            Bind(control, Lista, firstItem)
            Return Lista
    End Function
    




        
    End Class
    
End Namespace


