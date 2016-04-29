Imports ingNovar.Utilidades2
Imports system.data
Imports system.collections.generic
Imports SeguridadUsuarios

Partial Public Class Entradas_DistribucionBrl

    Private _Id As Int32
    Private _Id_Entrada_Detalle As Int32
    Private _Id_Bodega As Int32
    Private _Cantidad As Double
    Private _Id_Capacidad As Int32
    Private _Observacion As String

    Private _Fecha_Creacion As DateTime
    Private _Id_Usuario_Creacion As Int32
    Private _Fecha_Modificacion As DateTime
    Private _Id_Usuario_Modificacion As Int32


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

    Public Event Id_Entrada_DetalleChanging(ByVal Value As Int32)
    Public Event Id_Entrada_DetalleChanged()
	
    Public Property Id_Entrada_Detalle() As Int32
        Get
            Return Me._Id_Entrada_Detalle
        End Get
        Set(ByVal Value As Int32)
            If _Id_Entrada_Detalle <> Value Then
                RaiseEvent Id_Entrada_DetalleChanging(Value)
				Me._Id_Entrada_Detalle = Value
                RaiseEvent Id_Entrada_DetalleChanged()
            End If
        End Set
    End Property

    Public Event Id_BodegaChanging(ByVal Value As Int32)
    Public Event Id_BodegaChanged()
	
    Public Property Id_Bodega() As Int32
        Get
            Return Me._Id_Bodega
        End Get
        Set(ByVal Value As Int32)
            If _Id_Bodega <> Value Then
                RaiseEvent Id_BodegaChanging(Value)
				Me._Id_Bodega = Value
                RaiseEvent Id_BodegaChanged()
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

    Public Event ObservacionChanging(ByVal Value As String)
    Public Event ObservacionChanged()
	
    Public Property Observacion() As String
        Get
            Return Me._Observacion
        End Get
        Set(ByVal Value As String)
            If _Observacion <> Value Then
                RaiseEvent ObservacionChanging(Value)
				Me._Observacion = Value
                RaiseEvent ObservacionChanged()
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

    Public ReadOnly Property Bodegas() As SubTablasBrl
        Get
            Return SubTablasBrl.CargarPorID(Id_Bodega)
        End Get
    End Property

    Public ReadOnly Property Capacidad() As SubTablasBrl
        Get
            Return SubTablasBrl.CargarPorID(Id_Capacidad)
        End Get
    End Property

    Public Readonly Property Entradas_Detalle() As Entradas_DetalleBrl
        Get
            Return Entradas_DetalleBrl.CargarPorID(Id_Entrada_Detalle)
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

    Public Event Saving()
    Public Event Saved()

    Public Event Inserting()
    Public Event Inserted()

    Public Event Updating()
    Public Event Updated()

    Public Event Deleting()
    Public Event Deleted()

    Private Shared Function asignarValoresALasPropiedades(ByVal fila As DataRow) As Entradas_DistribucionBrl
        Dim objEntradas_Distribucion As New Entradas_DistribucionBrl
        With objEntradas_Distribucion
            .ID = fila("Id")
            .Id_Entrada_Detalle = isDBNullToNothing(fila("Id_Entrada_Detalle"))
            .Id_Bodega = isDBNullToNothing(fila("Id_Bodega"))
            .Cantidad = isDBNullToNothing(fila("Cantidad"))
            .Id_Capacidad = isDBNullToNothing(fila("Id_Capacidad"))
            .Observacion = isDBNullToNothing(fila("Observacion"))
            .Fecha_Creacion = isDBNullToNothing(fila("Fecha_Creacion"))
            .Id_Usuario_Creacion = isDBNullToNothing(fila("Id_Usuario_Creacion"))
            .Fecha_Modificacion = isDBNullToNothing(fila("Fecha_Modificacion"))
            .Id_Usuario_Modificacion = isDBNullToNothing(fila("Id_Usuario_Modificacion"))

        End With
        Return objEntradas_Distribucion

    End Function
	
	Public Shared Event LoadingEntradas_DistribucionList(ByVal LoadType As String)
	Public Shared Event LoadedEntradas_DistribucionList(target As List(Of Entradas_DistribucionBrl), ByVal LoadType As String)
	
	Public Shared Function CargarTodos() As List(Of Entradas_DistribucionBrl)

		Dim dsDatos As System.Data.DataSet
		Dim lista As New List(Of Entradas_DistribucionBrl)
	
		RaiseEvent LoadingEntradas_DistribucionList("CargarTodos")
	
		dsDatos = Entradas_DistribucionDAL.CargarTodos()

        For Each fila as DataRow in dsDatos.Tables(0).Rows
			lista.Add(asignarValoresALasPropiedades(fila))
        Next
        
        RaiseEvent LoadedEntradas_DistribucionList(lista, "CargarTodos")
        
        Return lista
        
    End Function

	Public Shared Event CargandoPorId(ByVal id As Int32)
    Public Shared Event CargadoPorId(ByVal target As Entradas_DistribucionBrl)

	Public Shared Function CargarPorID(ID As Int32) As Entradas_DistribucionBrl

		Dim dsDatos As System.Data.DataSet
		Dim objEntradas_Distribucion As Entradas_DistribucionBrl = Nothing 
		
		'RaiseEvent CargandoPorId(ID)
			
		dsDatos = Entradas_DistribucionDAL.CargarPorID(ID)
		
		If dsDatos.Tables(0).Rows.Count <> 0 Then objEntradas_Distribucion = asignarValoresALasPropiedades(dsDatos.Tables(0).Rows(0))
		
		'RaiseEvent CargadoPorId(objJoven)

        Return objEntradas_Distribucion
        
    End Function

    Public Shared Function CargarPorId_Bodega(ByVal Id_Bodega As Int32) As List(Of Entradas_DistribucionBrl)

        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of Entradas_DistribucionBrl)
        RaiseEvent LoadingEntradas_DistribucionList("CargarPorId_Bodega")
        dsDatos = Entradas_DistribucionDAL.CargarPorId_Bodega(Id_Bodega)
        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next
        RaiseEvent LoadedEntradas_DistribucionList(lista, "CargarPorId_Bodega")
        Return lista

    End Function


	Public Shared Function CargarPorId_Capacidad(ByVal Id_Capacidad As Int32) As List(Of Entradas_DistribucionBrl)

		Dim dsDatos As System.Data.DataSet
		Dim lista As New List(Of Entradas_DistribucionBrl)
	
		RaiseEvent LoadingEntradas_DistribucionList("CargarPorId_Capacidad")
		
		dsDatos = Entradas_DistribucionDAL.CargarPorId_Capacidad(Id_Capacidad)

        For Each fila as DataRow in dsDatos.Tables(0).Rows
			lista.Add(asignarValoresALasPropiedades(fila))
        Next
        
        RaiseEvent LoadedEntradas_DistribucionList(lista, "CargarPorId_Capacidad")
        
        Return lista
        
	End Function


	Public Shared Function CargarPorId_Entrada_Detalle(ByVal Id_Entrada_Detalle As Int32) As List(Of Entradas_DistribucionBrl)

		Dim dsDatos As System.Data.DataSet
		Dim lista As New List(Of Entradas_DistribucionBrl)
	
		RaiseEvent LoadingEntradas_DistribucionList("CargarPorId_Entrada_Detalle")
		
		dsDatos = Entradas_DistribucionDAL.CargarPorId_Entrada_Detalle(Id_Entrada_Detalle)

        For Each fila as DataRow in dsDatos.Tables(0).Rows
			lista.Add(asignarValoresALasPropiedades(fila))
        Next
        
        RaiseEvent LoadedEntradas_DistribucionList(lista, "CargarPorId_Entrada_Detalle")
        
        Return lista
        
	End Function


	Public Shared Function CargarPorId_Usuario_Creacion(ByVal Id_Usuario_Creacion As Int32) As List(Of Entradas_DistribucionBrl)

		Dim dsDatos As System.Data.DataSet
		Dim lista As New List(Of Entradas_DistribucionBrl)
	
		RaiseEvent LoadingEntradas_DistribucionList("CargarPorId_Usuario_Creacion")
		
		dsDatos = Entradas_DistribucionDAL.CargarPorId_Usuario_Creacion(Id_Usuario_Creacion)

        For Each fila as DataRow in dsDatos.Tables(0).Rows
			lista.Add(asignarValoresALasPropiedades(fila))
        Next
        
        RaiseEvent LoadedEntradas_DistribucionList(lista, "CargarPorId_Usuario_Creacion")
        
        Return lista
        
	End Function

    Public Shared Function CargarPorId_Usuario_Modificacion(ByVal Id_Usuario_Modificacion As Int32) As List(Of Entradas_DistribucionBrl)

        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of Entradas_DistribucionBrl)

        RaiseEvent LoadingEntradas_DistribucionList("CargarPorId_Usuario_Modificacion")

        dsDatos = Entradas_DistribucionDAL.CargarPorId_Usuario_Modificacion(Id_Usuario_Modificacion)

        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next

        RaiseEvent LoadedEntradas_DistribucionList(lista, "CargarPorId_Usuario_Modificacion")

        Return lista

    End Function

    Public Shared Function CargarPorId_BodegayId_Producto(ByVal Id_Bodega As Int32, ByVal id_producto As Int32) As List(Of Entradas_DistribucionBrl)

        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of Entradas_DistribucionBrl)

        dsDatos = Entradas_DistribucionDAL.CargarPorId_BodegayId_Producto(Id_Bodega, id_producto)
        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next
        Return lista

    End Function



End Class


