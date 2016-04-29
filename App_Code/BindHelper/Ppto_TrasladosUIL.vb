Imports System.Collections.Generic

Namespace BindHelper
    
    Partial Public NotInheritable Class Ppto_TrasladosUIL
        
        Private Shared Sub Bind(ByVal control As ListControl, ByVal Lista As List(Of Ppto_TrasladosBRL), Optional ByVal firstItem As ListItem = Nothing)
            control.DataSource = Lista
            control.DataValueField = "ID"
            control.DataTextField = "ID"
            control.DataBind
            If Not firstItem Is Nothing  Then
                control.Items.Insert(0, firstItem)
            End If
        End Sub
        
        Public Shared Function BindToListControl(ByVal control As ListControl, ByVal Id_proyecto As Int32, Optional ByVal firstItem As ListItem = Nothing) As List(Of Ppto_TrasladosBrl)
            Dim Lista As List(Of Ppto_TrasladosBrl)
            Lista = Ppto_TrasladosBrl.CargarTodos(Id_Proyecto)
            Bind(control, Lista, firstItem)
            Return Lista
        End Function
        
        Public Shared Function BindToListControlPorId_Nivel_Sale(ByVal control As ListControl, ByVal Id_Nivel_Sale As Int32, Optional ByVal firstItem As ListItem = Nothing) As List(Of Ppto_TrasladosBrl)
            Dim Lista As List(Of Ppto_TrasladosBrl)
            Lista = Ppto_TrasladosBrl.CargarPorId_Nivel_Sale(Id_Nivel_Sale)
            Bind(control, Lista, firstItem)
            Return Lista
        End Function

    End Class
    
End Namespace


