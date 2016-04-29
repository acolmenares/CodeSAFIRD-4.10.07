Imports ingNovar.Utilidades2
imports system.data
Imports system.collections.generic
Imports SeguridadUsuarios

Partial Public Class Entradas_DetalleBrl

    Private _Id As Int32
    Private _Id_Entrada As Int32
    Private _Id_Producto As Int32
    Private _Id_Capacidad As Int32
    Private _Cantidad As Double
    Private _Valor_Unitario As Double
    Private _Valor_Descuento As Double
    Private _Fecha_Creacion As DateTime
    Private _Id_Usuario_Creacion As Int32
    Private _Fecha_Modificacion As DateTime
    Private _Id_Usuario_Modificacion As Int32
    Private _Id_Salida_Detalle_Entrada As Int32

    Private objListEntradas_Distribucion As List(Of Entradas_DistribucionBrl)
    Private objListEntradas_OrdenCompra As List(Of Entradas_OrdenCompraBrl)

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

    Public Event Id_EntradaChanging(ByVal Value As Int32)
    Public Event Id_EntradaChanged()
	
    Public Property Id_Entrada() As Int32
        Get
            Return Me._Id_Entrada
        End Get
        Set(ByVal Value As Int32)
            If _Id_Entrada <> Value Then
                RaiseEvent Id_EntradaChanging(Value)
				Me._Id_Entrada = Value
                RaiseEvent Id_EntradaChanged()
            End If
        End Set
    End Property

    Public Event Id_ProductoChanging(ByVal Value As Int32)
    Public Event Id_ProductoChanged()
	
    Public Property Id_Producto() As Int32
        Get
            Return Me._Id_Producto
        End Get
        Set(ByVal Value As Int32)
            If _Id_Producto <> Value Then
                RaiseEvent Id_ProductoChanging(Value)
				Me._Id_Producto = Value
                RaiseEvent Id_ProductoChanged()
            End If
        End Set
    End Property

    Public Event Id_CapacidadChanging(ByVal Value As Int32)
    Public Event Id_CapacidadChanged()
	
    Public Property Id_Capacidad() As Int32
        Get
            Return Me._Id_Capacidad
        End Get
        Set(ByVal Value As Int32)
            If _Id_Capacidad <> Value Then
                RaiseEvent Id_CapacidadChanging(Value)
				Me._Id_Capacidad = Value
                RaiseEvent Id_CapacidadChanged()
            End If
        End Set
    End Property

    Public Event CantidadChanging(ByVal Value As Double)
    Public Event CantidadChanged()
	
    Public Property Cantidad() As Double
        Get
            Return Me._Cantidad
        End Get
        Set(ByVal Value As Double)
            If _Cantidad <> Value Then
                RaiseEvent CantidadChanging(Value)
				Me._Cantidad = Value
                RaiseEvent CantidadChanged()
            End If
        End Set
    End Property

    Public Event Valor_UnitarioChanging(ByVal Value As Double)
    Public Event Valor_UnitarioChanged()
	
    Public Property Valor_Unitario() As Double
        Get
            Return Me._Valor_Unitario
        End Get
        Set(ByVal Value As Double)
            If _Valor_Unitario <> Value Then
                RaiseEvent Valor_UnitarioChanging(Value)
				Me._Valor_Unitario = Value
                RaiseEvent Valor_UnitarioChanged()
            End If
        End Set
    End Property

    Public Event Valor_DescuentoChanging(ByVal Value As Double)
    Public Event Valor_DescuentoChanged()
	
    Public Property Valor_Descuento() As Double
        Get
            Return Me._Valor_Descuento
        End Get
        Set(ByVal Value As Double)
            If _Valor_Descuento <> Value Then
                RaiseEvent Valor_DescuentoChanging(Value)
				Me._Valor_Descuento = Value
                RaiseEvent Valor_DescuentoChanged()
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

    Public Event Id_Salida_Detalle_EntradaChanging(ByVal Value As Int32)
    Public Event Id_Salida_Detalle_EntradaChanged()

    Public Property Id_Salida_Detalle_Entrada() As Int32
        Get
            Return Me._Id_Salida_Detalle_Entrada
        End Get
        Set(ByVal Value As Int32)
            If _Id_Salida_Detalle_Entrada <> Value Then
                RaiseEvent Id_Salida_Detalle_EntradaChanging(Value)
                Me._Id_Salida_Detalle_Entrada = Value
                RaiseEvent Id_Salida_Detalle_EntradaChanged()
            End If
        End Set
    End Property

    Public Readonly Property Entradas() As EntradasBrl
        Get
            Return EntradasBrl.CargarPorID(Id_Entrada)
        End Get
    End Property

    Public Property Entradas_Distribucion() As List(Of Entradas_DistribucionBrl)
        Get
            If (Me.objListEntradas_Distribucion Is Nothing) Then
                objListEntradas_Distribucion = Entradas_DistribucionBrl.CargarPorId_Entrada_Detalle(Me.ID)
            End If
            Return Me.objListEntradas_Distribucion
        End Get
        Set(ByVal Value As List(Of Entradas_DistribucionBrl))
            Me.objListEntradas_Distribucion = Value
        End Set
    End Property

    Public Property Entradas_OrdenCompra() As List(Of Entradas_OrdenCompraBrl)
        Get
            If (Me.objListEntradas_OrdenCompra Is Nothing) Then
                objListEntradas_OrdenCompra = Entradas_OrdenCompraBrl.CargarPorId_Entrada_Detalle(Me.ID)
            End If
            Return Me.objListEntradas_OrdenCompra
        End Get
        Set(ByVal Value As List(Of Entradas_OrdenCompraBrl))
            Me.objListEntradas_OrdenCompra = Value
        End Set
    End Property

    Public ReadOnly Property Capacidad() As SubTablasBrl
        Get
            Return SubTablasBrl.CargarPorID(Id_Capacidad)
        End Get
    End Property

    Public ReadOnly Property Producto() As SubTablasBrl
        Get
            Return SubTablasBrl.CargarPorID(Id_Producto)
        End Get
    End Property

    Public Readonly Property UsuariosCreacion() As UsuariosBrl
        Get
            Return UsuariosBrl.CargarPorID(Id_Usuario_Creacion)
        End Get
    End Property

    Public Readonly Property UsuariosModificacion() As UsuariosBrl
        Get
            Return UsuariosBrl.CargarPorID(Id_Usuario_Modificacion)
        End Get
    End Property

    Public ReadOnly Property ValorProducto() As Double
        Get
            Return Cantidad * Valor_Unitario
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

    Private Shared Function asignarValoresALasPropiedades(ByVal fila As DataRow) As Entradas_DetalleBrl

        Dim objEntradas_Detalle As New Entradas_DetalleBrl
        With objEntradas_Detalle
            .ID = fila("Id")
            .Id_Entrada = isDBNullToNothing(fila("Id_Entrada"))
            .Id_Producto = isDBNullToNothing(fila("Id_Producto"))
            .Id_Capacidad = isDBNullToNothing(fila("Id_Capacidad"))
            .Cantidad = isDBNullToNothing(fila("Cantidad"))
            .Valor_Unitario = isDBNullToNothing(fila("Valor_Unitario"))
            .Valor_Descuento = isDBNullToNothing(fila("Valor_Descuento"))
            .Fecha_Creacion = isDBNullToNothing(fila("Fecha_Creacion"))
            .Id_Usuario_Creacion = isDBNullToNothing(fila("Id_Usuario_Creacion"))
            .Fecha_Modificacion = isDBNullToNothing(fila("Fecha_Modificacion"))
            .Id_Usuario_Modificacion = isDBNullToNothing(fila("Id_Usuario_Modificacion"))
            .Id_Salida_Detalle_Entrada = isDBNullToNothing(fila("Id_Salida_Detalle_Entrada"))

        End With

        Return objEntradas_Detalle

    End Function
	
	Public Shared Event LoadingEntradas_DetalleList(ByVal LoadType As String)
	Public Shared Event LoadedEntradas_DetalleList(target As List(Of Entradas_DetalleBrl), ByVal LoadType As String)
	
	Public Shared Function CargarTodos() As List(Of Entradas_DetalleBrl)

		Dim dsDatos As System.Data.DataSet
		Dim lista As New List(Of Entradas_DetalleBrl)
	
		RaiseEvent LoadingEntradas_DetalleList("CargarTodos")
	
		dsDatos = Entradas_DetalleDAL.CargarTodos()

        For Each fila as DataRow in dsDatos.Tables(0).Rows
			lista.Add(asignarValoresALasPropiedades(fila))
        Next
        
        RaiseEvent LoadedEntradas_DetalleList(lista, "CargarTodos")
        
        Return lista
        
    End Function

	Public Shared Event CargandoPorId(ByVal id As Int32)
    Public Shared Event CargadoPorId(ByVal target As Entradas_DetalleBrl)

	Public Shared Function CargarPorID(ID As Int32) As Entradas_DetalleBrl
        Dim dsDatos As System.Data.DataSet
		Dim objEntradas_Detalle As Entradas_DetalleBrl = Nothing 
        dsDatos = Entradas_DetalleDAL.CargarPorID(ID)
        If dsDatos.Tables(0).Rows.Count <> 0 Then objEntradas_Detalle = asignarValoresALasPropiedades(dsDatos.Tables(0).Rows(0))
        Return objEntradas_Detalle
        
    End Function

	Public Shared Function CargarPorId_Entrada(ByVal Id_Entrada As Int32) As List(Of Entradas_DetalleBrl)

		Dim dsDatos As System.Data.DataSet
		Dim lista As New List(Of Entradas_DetalleBrl)
	
		RaiseEvent LoadingEntradas_DetalleList("CargarPorId_Entrada")
        dsDatos = Entradas_DetalleDAL.CargarPorId_Entrada(Id_Entrada)
        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next
        RaiseEvent LoadedEntradas_DetalleList(lista, "CargarPorId_Entrada")
        Return lista
        
	End Function


	Public Shared Function CargarPorId_Capacidad(ByVal Id_Capacidad As Int32) As List(Of Entradas_DetalleBrl)

		Dim dsDatos As System.Data.DataSet
		Dim lista As New List(Of Entradas_DetalleBrl)
	
		RaiseEvent LoadingEntradas_DetalleList("CargarPorId_Capacidad")
		
		dsDatos = Entradas_DetalleDAL.CargarPorId_Capacidad(Id_Capacidad)

        For Each fila as DataRow in dsDatos.Tables(0).Rows
			lista.Add(asignarValoresALasPropiedades(fila))
        Next
        
        RaiseEvent LoadedEntradas_DetalleList(lista, "CargarPorId_Capacidad")
        
        Return lista
        
	End Function


	Public Shared Function CargarPorId_Producto(ByVal Id_Producto As Int32) As List(Of Entradas_DetalleBrl)

		Dim dsDatos As System.Data.DataSet
		Dim lista As New List(Of Entradas_DetalleBrl)
	
		RaiseEvent LoadingEntradas_DetalleList("CargarPorId_Producto")
		
		dsDatos = Entradas_DetalleDAL.CargarPorId_Producto(Id_Producto)

        For Each fila as DataRow in dsDatos.Tables(0).Rows
			lista.Add(asignarValoresALasPropiedades(fila))
        Next
        
        RaiseEvent LoadedEntradas_DetalleList(lista, "CargarPorId_Producto")
        
        Return lista
        
	End Function


	Public Shared Function CargarPorId_Usuario_Creacion(ByVal Id_Usuario_Creacion As Int32) As List(Of Entradas_DetalleBrl)

		Dim dsDatos As System.Data.DataSet
		Dim lista As New List(Of Entradas_DetalleBrl)
	
		RaiseEvent LoadingEntradas_DetalleList("CargarPorId_Usuario_Creacion")
		
		dsDatos = Entradas_DetalleDAL.CargarPorId_Usuario_Creacion(Id_Usuario_Creacion)

        For Each fila as DataRow in dsDatos.Tables(0).Rows
			lista.Add(asignarValoresALasPropiedades(fila))
        Next
        
        RaiseEvent LoadedEntradas_DetalleList(lista, "CargarPorId_Usuario_Creacion")
        
        Return lista
        
	End Function


	Public Shared Function CargarPorId_Usuario_Modificacion(ByVal Id_Usuario_Modificacion As Int32) As List(Of Entradas_DetalleBrl)

		Dim dsDatos As System.Data.DataSet
		Dim lista As New List(Of Entradas_DetalleBrl)
	
		RaiseEvent LoadingEntradas_DetalleList("CargarPorId_Usuario_Modificacion")
		
		dsDatos = Entradas_DetalleDAL.CargarPorId_Usuario_Modificacion(Id_Usuario_Modificacion)

        For Each fila as DataRow in dsDatos.Tables(0).Rows
			lista.Add(asignarValoresALasPropiedades(fila))
        Next
        
        RaiseEvent LoadedEntradas_DetalleList(lista, "CargarPorId_Usuario_Modificacion")
        
        Return lista
        
	End Function



End Class


