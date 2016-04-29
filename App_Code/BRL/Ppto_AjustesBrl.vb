Imports ingNovar.Utilidades2
imports system.data
Imports system.collections.generic


Partial Public Class Ppto_AjustesBrl

    Private _Id As Int32
    Private _Fecha As DateTime
    Private _Tipo As String
    Private _Id_Contrato As Int32
    Private _Id_OrdenCompra_Detalle As Int32
    Private _Valor_USD As Double
    Private _TRM As Double
    Private _Valor_COP As Double
    Private _Aprobado_DirFin As Boolean
    Private _Fecha_Creacion As DateTime
    Private _Id_Usuario_Creacion As Int32
    Private _Fecha_Modificacion As DateTime
    Private _Id_Usuario_Modificacion As Int32
    Private _Observaciones As String
    Private _Id_Proyecto As Int32

	Public Event Creating()
    Public Event Created()
    
    Public Sub New()
        RaiseEvent Creating()
        'Adicionar código al costructor aquí
        
        RaiseEvent Created()        
    End Sub
    Public Event IDChanging(ByVal Value As Int32)
    Public Event IDChanged()
	
    Public Property ID() As Int32
        Get
            Return Me._Id
        End Get
        Set(ByVal Value As Int32)
            If _Id <> Value Then
                RaiseEvent IDChanging(Value)
				Me._Id = Value
                RaiseEvent IDChanged()
            End If
        End Set
    End Property

    Public Event FechaChanging(ByVal Value As DateTime)
    Public Event FechaChanged()
	
    Public Property Fecha() As DateTime
        Get
            Return Me._Fecha
        End Get
        Set(ByVal Value As DateTime)
            If _Fecha <> Value Then
                RaiseEvent FechaChanging(Value)
				Me._Fecha = Value
                RaiseEvent FechaChanged()
            End If
        End Set
    End Property

    Public Event TipoChanging(ByVal Value As String)
    Public Event TipoChanged()
	
    Public Property Tipo() As String
        Get
            Return Me._Tipo
        End Get
        Set(ByVal Value As String)
            If _Tipo <> Value Then
                RaiseEvent TipoChanging(Value)
				Me._Tipo = Value
                RaiseEvent TipoChanged()
            End If
        End Set
    End Property

    Public Event Id_ContratoChanging(ByVal Value As Int32)
    Public Event Id_ContratoChanged()
	
    Public Property Id_Contrato() As Int32
        Get
            Return Me._Id_Contrato
        End Get
        Set(ByVal Value As Int32)
            If _Id_Contrato <> Value Then
                RaiseEvent Id_ContratoChanging(Value)
				Me._Id_Contrato = Value
                RaiseEvent Id_ContratoChanged()
            End If
        End Set
    End Property

    Public Event Id_OrdenCompra_DetalleChanging(ByVal Value As Int32)
    Public Event Id_OrdenCompra_DetalleChanged()
	
    Public Property Id_OrdenCompra_Detalle() As Int32
        Get
            Return Me._Id_OrdenCompra_Detalle
        End Get
        Set(ByVal Value As Int32)
            If _Id_OrdenCompra_Detalle <> Value Then
                RaiseEvent Id_OrdenCompra_DetalleChanging(Value)
				Me._Id_OrdenCompra_Detalle = Value
                RaiseEvent Id_OrdenCompra_DetalleChanged()
            End If
        End Set
    End Property

    Public Event Valor_USDChanging(ByVal Value As Double)
    Public Event Valor_USDChanged()
	
    Public Property Valor_USD() As Double
        Get
            Return Me._Valor_USD
        End Get
        Set(ByVal Value As Double)
            If _Valor_USD <> Value Then
                RaiseEvent Valor_USDChanging(Value)
				Me._Valor_USD = Value
                RaiseEvent Valor_USDChanged()
            End If
        End Set
    End Property

    Public Event TRMChanging(ByVal Value As Double)
    Public Event TRMChanged()
	
    Public Property TRM() As Double
        Get
            Return Me._TRM
        End Get
        Set(ByVal Value As Double)
            If _TRM <> Value Then
                RaiseEvent TRMChanging(Value)
				Me._TRM = Value
                RaiseEvent TRMChanged()
            End If
        End Set
    End Property

    Public Event Valor_COPChanging(ByVal Value As Double)
    Public Event Valor_COPChanged()
	
    Public Property Valor_COP() As Double
        Get
            Return Me._Valor_COP
        End Get
        Set(ByVal Value As Double)
            If _Valor_COP <> Value Then
                RaiseEvent Valor_COPChanging(Value)
				Me._Valor_COP = Value
                RaiseEvent Valor_COPChanged()
            End If
        End Set
    End Property

    Public Event Aprobado_DirFinChanging(ByVal Value As Boolean)
    Public Event Aprobado_DirFinChanged()
	
    Public Property Aprobado_DirFin() As Boolean
        Get
            Return Me._Aprobado_DirFin
        End Get
        Set(ByVal Value As Boolean)
            If _Aprobado_DirFin <> Value Then
                RaiseEvent Aprobado_DirFinChanging(Value)
                Me._Aprobado_DirFin = Value
                RaiseEvent Aprobado_DirFinChanged()
            End If
        End Set
    End Property

    Public Event Fecha_CreacionChanging(ByVal Value As DateTime)
    Public Event Fecha_CreacionChanged()
	
    Public Property Fecha_Creacion() As DateTime
        Get
            Return Me._Fecha_Creacion
        End Get
        Set(ByVal Value As DateTime)
            If _Fecha_Creacion <> Value Then
                RaiseEvent Fecha_CreacionChanging(Value)
				Me._Fecha_Creacion = Value
                RaiseEvent Fecha_CreacionChanged()
            End If
        End Set
    End Property

    Public Event Id_Usuario_CreacionChanging(ByVal Value As Int32)
    Public Event Id_Usuario_CreacionChanged()
	
    Public Property Id_Usuario_Creacion() As Int32
        Get
            Return Me._Id_Usuario_Creacion
        End Get
        Set(ByVal Value As Int32)
            If _Id_Usuario_Creacion <> Value Then
                RaiseEvent Id_Usuario_CreacionChanging(Value)
				Me._Id_Usuario_Creacion = Value
                RaiseEvent Id_Usuario_CreacionChanged()
            End If
        End Set
    End Property

    Public Event Fecha_ModificacionChanging(ByVal Value As DateTime)
    Public Event Fecha_ModificacionChanged()
	
    Public Property Fecha_Modificacion() As DateTime
        Get
            Return Me._Fecha_Modificacion
        End Get
        Set(ByVal Value As DateTime)
            If _Fecha_Modificacion <> Value Then
                RaiseEvent Fecha_ModificacionChanging(Value)
				Me._Fecha_Modificacion = Value
                RaiseEvent Fecha_ModificacionChanged()
            End If
        End Set
    End Property

    Public Event Id_Usuario_ModificacionChanging(ByVal Value As Int32)
    Public Event Id_Usuario_ModificacionChanged()
	
    Public Property Id_Usuario_Modificacion() As Int32
        Get
            Return Me._Id_Usuario_Modificacion
        End Get
        Set(ByVal Value As Int32)
            If _Id_Usuario_Modificacion <> Value Then
                RaiseEvent Id_Usuario_ModificacionChanging(Value)
				Me._Id_Usuario_Modificacion = Value
                RaiseEvent Id_Usuario_ModificacionChanged()
            End If
        End Set
    End Property

    Public Event ObservacionesChanging(ByVal Value As String)
    Public Event ObservacionesChanged()

    Public Property Observaciones() As String
        Get
            Return Me._Observaciones
        End Get
        Set(ByVal Value As String)
            If _Observaciones <> Value Then
                RaiseEvent ObservacionesChanging(Value)
                Me._Observaciones = Value
                RaiseEvent ObservacionesChanged()
            End If
        End Set
    End Property

    Public Event Id_ProyectoChanging(ByVal Value As Int32)
    Public Event Id_ProyectoChanged()

    Public Property Id_Proyecto() As Int32
        Get
            Return Me._Id_Proyecto
        End Get
        Set(ByVal Value As Int32)
            If _Id_Proyecto <> Value Then
                RaiseEvent Id_ProyectoChanging(Value)
                Me._Id_Proyecto = Value
                RaiseEvent Id_ProyectoChanged()
            End If
        End Set
    End Property

    Public Readonly Property Ppto_Contratos() As Ppto_ContratosBrl
        Get
            Return Ppto_ContratosBrl.CargarPorID(Id_Contrato)
        End Get
    End Property

    Public Readonly Property OrdenCompra_Detalle() As OrdenCompra_DetalleBrl
        Get
            Return OrdenCompra_DetalleBrl.CargarPorID(Id_OrdenCompra_Detalle)
        End Get
    End Property

    Public Event Saving()
    Public Event Saved()

    Public Event Inserting()
    Public Event Inserted()

    Public Event Updating()
    Public Event Updated()

    Public Event Deleting()
    Public Event Deleted()

	
	Public Sub Guardar()
        RaiseEvent Saving()
		If (Me.ID = Nothing) Then
            RaiseEvent Inserting()		
            Me.ID = Ppto_AjustesDAL.Insertar(Fecha, Tipo, Id_Contrato, Id_OrdenCompra_Detalle, Valor_USD, TRM, Valor_COP, Aprobado_DirFin, Fecha_Creacion, Id_Usuario_Creacion, Fecha_Modificacion, Id_Usuario_Modificacion, Observaciones, Id_Proyecto)
            RaiseEvent Inserted()			
		Else
            RaiseEvent Updating()		
            Ppto_AjustesDAL.Actualizar(ID, Fecha, Tipo, Id_Contrato, Id_OrdenCompra_Detalle, Valor_USD, TRM, Valor_COP, Aprobado_DirFin, Fecha_Creacion, Id_Usuario_Creacion, Fecha_Modificacion, Id_Usuario_Modificacion, Observaciones, Id_Proyecto)
            RaiseEvent Updated()			
		End If   

        RaiseEvent Saved()
        
	End Sub
	
	Public Sub Eliminar()
		Dim totalHijos As Long = 0
		If Me.ID <> Nothing Then 
			
            RaiseEvent Deleting()
            If totalHijos > 0 Then Throw New Exception("No se puede eliminar el registro porque existen datos que dependen de él.")
            Ppto_AjustesDAL.Eliminar(Me.ID)
			
            RaiseEvent Deleted()
            
        End If
	End Sub
	

    Private Shared Function asignarValoresALasPropiedades(ByVal fila As DataRow) As Ppto_AjustesBrl
		
		Dim objPpto_Ajustes As New Ppto_AjustesBrl
		
		With objPpto_Ajustes
			.ID = fila("Id")
			.Fecha = isDBNullToNothing(fila("Fecha"))
			.Tipo = isDBNullToNothing(fila("Tipo"))
			.Id_Contrato = isDBNullToNothing(fila("Id_Contrato"))
			.Id_OrdenCompra_Detalle = isDBNullToNothing(fila("Id_OrdenCompra_Detalle"))
			.Valor_USD = isDBNullToNothing(fila("Valor_USD"))
			.TRM = isDBNullToNothing(fila("TRM"))
			.Valor_COP = isDBNullToNothing(fila("Valor_COP"))
			.Aprobado_DirFin = isDBNullToNothing(fila("Aprobado_DirFin"))
			.Fecha_Creacion = isDBNullToNothing(fila("Fecha_Creacion"))
			.Id_Usuario_Creacion = isDBNullToNothing(fila("Id_Usuario_Creacion"))
			.Fecha_Modificacion = isDBNullToNothing(fila("Fecha_Modificacion"))
            .Id_Usuario_Modificacion = isDBNullToNothing(fila("Id_Usuario_Modificacion"))
            .Observaciones = isDBNullToNothing(fila("Observaciones"))
            .Id_Proyecto = isDBNullToNothing(fila("Id_Proyecto"))
		End With
		
		Return objPpto_Ajustes
		
    End Function
	
	Public Shared Event LoadingPpto_AjustesList(ByVal LoadType As String)
	Public Shared Event LoadedPpto_AjustesList(target As List(Of Ppto_AjustesBrl), ByVal LoadType As String)
	
    Public Shared Function CargarTodos(ByVal Id_Proyecto As Int32) As List(Of Ppto_AjustesBrl)

        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of Ppto_AjustesBrl)

        RaiseEvent LoadingPpto_AjustesList("CargarTodos")

        dsDatos = Ppto_AjustesDAL.CargarTodos(Id_Proyecto)

        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next

        RaiseEvent LoadedPpto_AjustesList(lista, "CargarTodos")

        Return lista

    End Function

	Public Shared Event CargandoPorId(ByVal id As Int32)
    Public Shared Event CargadoPorId(ByVal target As Ppto_AjustesBrl)

	Public Shared Function CargarPorID(ID As Int32) As Ppto_AjustesBrl

		Dim dsDatos As System.Data.DataSet
		Dim objPpto_Ajustes As Ppto_AjustesBrl = Nothing 
        dsDatos = Ppto_AjustesDAL.CargarPorID(ID)
        If dsDatos.Tables(0).Rows.Count <> 0 Then objPpto_Ajustes = asignarValoresALasPropiedades(dsDatos.Tables(0).Rows(0))
        Return objPpto_Ajustes
        
    End Function

	Public Shared Function CargarPorId_Contrato(ByVal Id_Contrato As Int32) As List(Of Ppto_AjustesBrl)

		Dim dsDatos As System.Data.DataSet
		Dim lista As New List(Of Ppto_AjustesBrl)
	
		RaiseEvent LoadingPpto_AjustesList("CargarPorId_Contrato")
		
		dsDatos = Ppto_AjustesDAL.CargarPorId_Contrato(Id_Contrato)

        For Each fila as DataRow in dsDatos.Tables(0).Rows
			lista.Add(asignarValoresALasPropiedades(fila))
        Next
        
        RaiseEvent LoadedPpto_AjustesList(lista, "CargarPorId_Contrato")
        
        Return lista
        
	End Function

	Public Shared Function CargarPorId_OrdenCompra_Detalle(ByVal Id_OrdenCompra_Detalle As Int32) As List(Of Ppto_AjustesBrl)

		Dim dsDatos As System.Data.DataSet
		Dim lista As New List(Of Ppto_AjustesBrl)
	
		RaiseEvent LoadingPpto_AjustesList("CargarPorId_OrdenCompra_Detalle")
		
		dsDatos = Ppto_AjustesDAL.CargarPorId_OrdenCompra_Detalle(Id_OrdenCompra_Detalle)

        For Each fila as DataRow in dsDatos.Tables(0).Rows
			lista.Add(asignarValoresALasPropiedades(fila))
        Next
        
        RaiseEvent LoadedPpto_AjustesList(lista, "CargarPorId_OrdenCompra_Detalle")
        
        Return lista
        
	End Function

    Public Shared Function CargarPorBusqueda(ByVal fechainicial As String, ByVal fechafinal As String, ByVal tipo As String, ByVal Id_contrato As Int32, ByVal id_Orden As Int32, ByVal Id_Proyecto As Int32) As List(Of Ppto_AjustesBrl)

        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of Ppto_AjustesBrl)
        dsDatos = Ppto_AjustesDAL.CargarPorBusqueda(fechainicial, fechafinal, tipo, Id_contrato, id_Orden, Id_Proyecto)

        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next
        Return lista

    End Function
End Class


