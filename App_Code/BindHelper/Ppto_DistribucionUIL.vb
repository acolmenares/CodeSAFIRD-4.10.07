Imports System.Collections.Generic

Namespace BindHelper
    
    Partial Public NotInheritable Class Ppto_DistribucionUIL
        
        Private Shared Sub Bind(ByVal control As ListControl, ByVal Lista As List(Of Ppto_DistribucionBRL), Optional ByVal firstItem As ListItem = Nothing)
            control.DataSource = Lista
            control.DataValueField = "ID"
            control.DataTextField = "ID"
            control.DataBind
            If Not firstItem Is Nothing  Then
                control.Items.Insert(0, firstItem)
            End If
        End Sub
        
        Public Shared Function BindToListControl(ByVal control As ListControl, ByVal Id_Proyecto As Int32, Optional ByVal firstItem As ListItem = Nothing) As List(Of Ppto_DistribucionBrl)
            Dim Lista As List(Of Ppto_DistribucionBrl)
            Lista = Ppto_DistribucionBrl.CargarTodos(Id_Proyecto)
            Bind(control, Lista, firstItem)
            Return Lista
        End Function
        
        Public Shared Function BindToListControlPorId_Ingreso(ByVal control As ListControl, ByVal Id_Ingreso As Int32, Optional ByVal firstItem As ListItem = Nothing) As List(Of Ppto_DistribucionBrl)
            Dim Lista As List(Of Ppto_DistribucionBrl)
            Lista = Ppto_DistribucionBrl.CargarPorId_Ingreso(Id_Ingreso)
            Bind(control, Lista, firstItem)
            Return Lista
        End Function

	Public Shared Function BindToListControlPorId_Nivel(ByVal control As ListControl, ByVal Id_Nivel As Int32, Optional ByVal firstItem As ListItem = Nothing) As List(Of Ppto_DistribucionBRL)
            Dim Lista As List(Of Ppto_DistribucionBRL)
            Lista = Ppto_DistribucionBRL.CargarPorId_Nivel(Id_Nivel)
            Bind(control, Lista, firstItem)
            Return Lista
    End Function

	Public Shared Function BindToListControlPorId_Tipo_Unidad(ByVal control As ListControl, ByVal Id_Tipo_Unidad As Int32, Optional ByVal firstItem As ListItem = Nothing) As List(Of Ppto_DistribucionBRL)
            Dim Lista As List(Of Ppto_DistribucionBRL)
            Lista = Ppto_DistribucionBRL.CargarPorId_Tipo_Unidad(Id_Tipo_Unidad)
            Bind(control, Lista, firstItem)
            Return Lista
    End Function
    
    End Class
    
End Namespace


