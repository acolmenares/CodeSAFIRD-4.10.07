Imports System.Collections.Generic

Namespace BindHelper
    
    Partial Public NotInheritable Class Ppto_IngresosUIL
        
        Private Shared Sub Bind(ByVal control As ListControl, ByVal Lista As List(Of Ppto_IngresosBRL), Optional ByVal firstItem As ListItem = Nothing)
            control.DataSource = Lista
            control.DataValueField = "ID"
            control.DataTextField = "Descripcion"
            control.DataBind
            If Not firstItem Is Nothing  Then
                control.Items.Insert(0, firstItem)
            End If
        End Sub
        
        Public Shared Function BindToListControl(ByVal control As ListControl, ByVal Id_proyecto As Int32, Optional ByVal firstItem As ListItem = Nothing) As List(Of Ppto_IngresosBrl)
            Dim Lista As List(Of Ppto_IngresosBrl)
            Lista = Ppto_IngresosBrl.CargarTodos(Id_proyecto)
            Bind(control, Lista, firstItem)
            Return Lista
        End Function
    End Class
    
End Namespace


