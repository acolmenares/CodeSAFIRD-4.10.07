Imports ingNovar.Utilidades2
imports system.data
Imports system.collections.generic


Partial Public Class Ppto_PagosBrl

    Private _Id As Int32
    Private _Fecha As DateTime
    Private _Id_Tercero As Int32
    Private _Tipo As String
    Private _Id_Contrato As Int32
    Private _Fecha_Creacion As DateTime
    Private _Id_Usuario_Creacion As Int32
    Private _Fecha_Modificacion As DateTime
    Private _Id_Usuario_Modificacion As Int32
    Private _Id_OrdenCompra As Int32
    Private objListPpto_Pagos_Detalle As List(Of Ppto_Pagos_DetalleBrl)

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

    Public Event Id_TerceroChanging(ByVal Value As Int32)
    Public Event Id_TerceroChanged()
	
    Public Property Id_Tercero() As Int32
        Get
            Return Me._Id_Tercero
        End Get
        Set(ByVal Value As Int32)
            If _Id_Tercero <> Value Then
                RaiseEvent Id_TerceroChanging(Value)
				Me._Id_Tercero = Value
                RaiseEvent Id_TerceroChanged()
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

    Public Event Id_OrdenCompraChanging(ByVal Value As Int32)
    Public Event Id_OrdenCompraChanged()
	
    Public Property Id_OrdenCompra() As Int32
        Get
            Return Me._Id_OrdenCompra
        End Get
        Set(ByVal Value As Int32)
            If _Id_OrdenCompra <> Value Then
                RaiseEvent Id_OrdenCompraChanging(Value)
                Me._Id_OrdenCompra = Value
                RaiseEvent Id_OrdenCompraChanged()
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

    Public Readonly Property Ppto_Contratos() As Ppto_ContratosBrl
        Get
            Return Ppto_ContratosBrl.CargarPorID(Id_Contrato)
        End Get
    End Property

    Public ReadOnly Property OrdenCompra() As OrdenCompraBrl
        Get
            Return OrdenCompraBrl.CargarPorID(Id_OrdenCompra)
        End Get
    End Property

    Public Readonly Property Ppto_Terceros() As Ppto_TercerosBrl
        Get
            Return Ppto_TercerosBrl.CargarPorID(Id_Tercero)
        End Get
    End Property

    Public Property Ppto_Pagos_Detalle() As List(Of Ppto_Pagos_DetalleBrl)
        Get
            If (Me.objListPpto_Pagos_Detalle Is Nothing) Then
                objListPpto_Pagos_Detalle = Ppto_Pagos_DetalleBrl.CargarPorId_Ppto_Pago(Me.ID)
            End If
            Return Me.objListPpto_Pagos_Detalle
        End Get
        Set(ByVal Value As List(Of Ppto_Pagos_DetalleBrl))
            Me.objListPpto_Pagos_Detalle = Value
        End Set
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
            Me.ID = Ppto_PagosDAL.Insertar(Fecha, Id_Tercero, Tipo, Id_Contrato, Fecha_Creacion, Id_Usuario_Creacion, Fecha_Modificacion, Id_Usuario_Modificacion, Id_OrdenCompra, 0)
            RaiseEvent Inserted()			
		Else
            RaiseEvent Updating()		
            Ppto_PagosDAL.Actualizar(ID, Fecha, Id_Tercero, Tipo, Id_Contrato, Fecha_Creacion, Id_Usuario_Creacion, Fecha_Modificacion, Id_Usuario_Modificacion, Id_OrdenCompra)
            RaiseEvent Updated()			
		End If   


        RaiseEvent Saved()
        
	End Sub
	
	Public Sub Eliminar()
		Dim totalHijos As Long = 0
		If Me.ID <> Nothing Then 
			
            RaiseEvent Deleting()
            If totalHijos > 0 Then Throw New Exception("No se puede eliminar el registro porque existen datos que dependen de él.")
            
			Ppto_PagosDAL.Eliminar(Me.ID)
			
            RaiseEvent Deleted()
            
        End If
	End Sub
	

    Private Shared Function asignarValoresALasPropiedades(ByVal fila As DataRow) As Ppto_PagosBrl
		
		Dim objPpto_Pagos As New Ppto_PagosBrl
		
		With objPpto_Pagos
			.ID = fila("Id")
			.Fecha = isDBNullToNothing(fila("Fecha"))
			.Id_Tercero = isDBNullToNothing(fila("Id_Tercero"))
			.Tipo = isDBNullToNothing(fila("Tipo"))
			.Id_Contrato = isDBNullToNothing(fila("Id_Contrato"))
            .Id_OrdenCompra = isDBNullToNothing(fila("Id_OrdenCompra"))
            .Fecha_Creacion = isDBNullToNothing(fila("Fecha_Creacion"))
			.Id_Usuario_Creacion = isDBNullToNothing(fila("Id_Usuario_Creacion"))
			.Fecha_Modificacion = isDBNullToNothing(fila("Fecha_Modificacion"))
			.Id_Usuario_Modificacion = isDBNullToNothing(fila("Id_Usuario_Modificacion"))

		End With
		
		Return objPpto_Pagos
		
    End Function
	
	Public Shared Event LoadingPpto_PagosList(ByVal LoadType As String)
	Public Shared Event LoadedPpto_PagosList(target As List(Of Ppto_PagosBrl), ByVal LoadType As String)
	
	Public Shared Function CargarTodos() As List(Of Ppto_PagosBrl)

		Dim dsDatos As System.Data.DataSet
		Dim lista As New List(Of Ppto_PagosBrl)
	
		RaiseEvent LoadingPpto_PagosList("CargarTodos")
	
		dsDatos = Ppto_PagosDAL.CargarTodos()

        For Each fila as DataRow in dsDatos.Tables(0).Rows
			lista.Add(asignarValoresALasPropiedades(fila))
        Next
        
        RaiseEvent LoadedPpto_PagosList(lista, "CargarTodos")
        
        Return lista
        
    End Function

	Public Shared Event CargandoPorId(ByVal id As Int32)
    Public Shared Event CargadoPorId(ByVal target As Ppto_PagosBrl)

	Public Shared Function CargarPorID(ID As Int32) As Ppto_PagosBrl

		Dim dsDatos As System.Data.DataSet
		Dim objPpto_Pagos As Ppto_PagosBrl = Nothing 
        dsDatos = Ppto_PagosDAL.CargarPorID(ID)
        If dsDatos.Tables(0).Rows.Count <> 0 Then objPpto_Pagos = asignarValoresALasPropiedades(dsDatos.Tables(0).Rows(0))
        'RaiseEvent CargadoPorId(objJoven)
        Return objPpto_Pagos
        
    End Function

	Public Shared Function CargarPorId_Contrato(ByVal Id_Contrato As Int32) As List(Of Ppto_PagosBrl)

		Dim dsDatos As System.Data.DataSet
		Dim lista As New List(Of Ppto_PagosBrl)
	
		RaiseEvent LoadingPpto_PagosList("CargarPorId_Contrato")
		
		dsDatos = Ppto_PagosDAL.CargarPorId_Contrato(Id_Contrato)

        For Each fila as DataRow in dsDatos.Tables(0).Rows
			lista.Add(asignarValoresALasPropiedades(fila))
        Next
        
        RaiseEvent LoadedPpto_PagosList(lista, "CargarPorId_Contrato")
        
        Return lista
        
	End Function


    Public Shared Function CargarPorId_OrdenCompra(ByVal Id_OrdenCompra As Int32) As List(Of Ppto_PagosBrl)

        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of Ppto_PagosBrl)

        RaiseEvent LoadingPpto_PagosList("CargarPorId_OrdenCompra")

        dsDatos = Ppto_PagosDAL.CargarPorId_OrdenCompra(Id_OrdenCompra)

        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next

        RaiseEvent LoadedPpto_PagosList(lista, "CargarPorId_OrdenCompra")

        Return lista

    End Function


	Public Shared Function CargarPorId_Tercero(ByVal Id_Tercero As Int32) As List(Of Ppto_PagosBrl)

		Dim dsDatos As System.Data.DataSet
		Dim lista As New List(Of Ppto_PagosBrl)
	
		RaiseEvent LoadingPpto_PagosList("CargarPorId_Tercero")
		
		dsDatos = Ppto_PagosDAL.CargarPorId_Tercero(Id_Tercero)

        For Each fila as DataRow in dsDatos.Tables(0).Rows
			lista.Add(asignarValoresALasPropiedades(fila))
        Next
        
        RaiseEvent LoadedPpto_PagosList(lista, "CargarPorId_Tercero")
        
        Return lista
        
	End Function

End Class


