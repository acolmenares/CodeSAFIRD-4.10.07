Imports System.Collections.Generic

Namespace BindHelper
    
    Partial Public NotInheritable Class Ppto_ContratosUIL
        
        Private Shared Sub Bind(ByVal control As ListControl, ByVal Lista As List(Of Ppto_ContratosBRL), Optional ByVal firstItem As ListItem = Nothing)
            control.DataSource = Lista
            control.DataValueField = "ID"
            control.DataTextField = "DescripcionContrato"
            control.DataBind
            If Not firstItem Is Nothing  Then
                control.Items.Insert(0, firstItem)
            End If
        End Sub
        
        Public Shared Function BindToListControl(ByVal control As ListControl, ByVal Id_Proyecto As Int32, Optional ByVal firstItem As ListItem = Nothing) As List(Of Ppto_ContratosBrl)
            Dim Lista As List(Of Ppto_ContratosBrl)
            Lista = Ppto_ContratosBrl.CargarTodos(Id_Proyecto)
            Bind(control, Lista, firstItem)
            Return Lista
        End Function

        Public Shared Function BindToListControlPorId_Nivel(ByVal control As ListControl, ByVal Id_Nivel As Int32, Optional ByVal firstItem As ListItem = Nothing) As List(Of Ppto_ContratosBrl)
            Dim Lista As List(Of Ppto_ContratosBrl)
            Lista = Ppto_ContratosBrl.CargarPorId_Nivel(Id_Nivel)
            Bind(control, Lista, firstItem)
            Return Lista
        End Function
    
        Public Shared Function BindToListControlPorId_Tercero(ByVal control As ListControl, ByVal Id_Tercero As Int32, Optional ByVal firstItem As ListItem = Nothing) As List(Of Ppto_ContratosBrl)
            Dim Lista As List(Of Ppto_ContratosBrl)
            Lista = Ppto_ContratosBrl.CargarPorId_Tercero(Id_Tercero)
            Bind(control, Lista, firstItem)
            Return Lista
        End Function
    
    End Class
    
End Namespace


