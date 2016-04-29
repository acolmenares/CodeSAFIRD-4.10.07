Imports System.Collections.Generic

Namespace BindHelper
    
    Partial Public NotInheritable Class Ppto_TercerosUIL
        
        Private Shared Sub Bind(ByVal control As ListControl, ByVal Lista As List(Of Ppto_TercerosBRL), Optional ByVal firstItem As ListItem = Nothing)
            control.DataSource = Lista
            control.DataValueField = "ID"
            control.DataTextField = "Razon_Social"
            control.DataBind
            If Not firstItem Is Nothing  Then
                control.Items.Insert(0, firstItem)
            End If
        End Sub
        
        Public Shared Function BindToListControl(ByVal control As ListControl, Optional ByVal firstItem As ListItem = Nothing) As List(Of Ppto_TercerosBRL)
            Dim Lista As List(Of Ppto_TercerosBRL)
            Lista = Ppto_TercerosBRL.CargarTodos()
            Bind(control, Lista, firstItem)
            Return Lista
        End Function
    End Class
    
End Namespace


