Imports ingNovar.Utilidades2
imports system.data
Imports system.collections.generic


Partial Public Class Ppto_Traslados_DetalleBrl

    Private _Id As Int32
    Private _Id_Traslado As Int32
    Private _Id_Nivel_Entra As Int32
    Private _Valor_USD As Double
    Private _TRM As Double
    Private _Valor_COP As Double
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

    Public Event Id_TrasladoChanging(ByVal Value As Int32)
    Public Event Id_TrasladoChanged()
	
    Public Property Id_Traslado() As Int32
        Get
            Return Me._Id_Traslado
        End Get
        Set(ByVal Value As Int32)
            If _Id_Traslado <> Value Then
                RaiseEvent Id_TrasladoChanging(Value)
				Me._Id_Traslado = Value
                RaiseEvent Id_TrasladoChanged()
            End If
        End Set
    End Property

    Public Event Id_Nivel_EntraChanging(ByVal Value As Int32)
    Public Event Id_Nivel_EntraChanged()
	
    Public Property Id_Nivel_Entra() As Int32
        Get
            Return Me._Id_Nivel_Entra
        End Get
        Set(ByVal Value As Int32)
            If _Id_Nivel_Entra <> Value Then
                RaiseEvent Id_Nivel_EntraChanging(Value)
				Me._Id_Nivel_Entra = Value
                RaiseEvent Id_Nivel_EntraChanged()
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

    Public Readonly Property Nivel() As SubTablasBrl
        Get
            Return SubTablasBrl.CargarPorID(Id_Nivel_Entra)
        End Get
    End Property

    Public Readonly Property Ppto_Traslados() As Ppto_TrasladosBrl
        Get
            Return Ppto_TrasladosBrl.CargarPorID(Id_Traslado)
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
			Me.ID = Ppto_Traslados_DetalleDAL.Insertar(Id_Traslado, Id_Nivel_Entra, Valor_USD, TRM, Valor_COP, Fecha_Creacion, Id_Usuario_Creacion, Fecha_Modificacion, Id_Usuario_Modificacion)
            RaiseEvent Inserted()			
		Else
            RaiseEvent Updating()		
			Ppto_Traslados_DetalleDAL.Actualizar(ID, Id_Traslado, Id_Nivel_Entra, Valor_USD, TRM, Valor_COP, Fecha_Creacion, Id_Usuario_Creacion, Fecha_Modificacion, Id_Usuario_Modificacion)
            RaiseEvent Updated()			
		End If   


        RaiseEvent Saved()
        
	End Sub
	
	Public Sub Eliminar()
		Dim totalHijos As Long = 0
		If Me.ID <> Nothing Then 
			
            RaiseEvent Deleting()
            
            
            
            If totalHijos > 0 Then Throw New Exception("No se puede eliminar el registro porque existen datos que dependen de él.")
            
			Ppto_Traslados_DetalleDAL.Eliminar(Me.ID)
			
            RaiseEvent Deleted()
            
        End If
	End Sub
	

    Private Shared Function asignarValoresALasPropiedades(ByVal fila As DataRow) As Ppto_Traslados_DetalleBrl
		
		Dim objPpto_Traslados_Detalle As New Ppto_Traslados_DetalleBrl
		
		With objPpto_Traslados_Detalle
			.ID = fila("Id")
			.Id_Traslado = isDBNullToNothing(fila("Id_Traslado"))
			.Id_Nivel_Entra = isDBNullToNothing(fila("Id_Nivel_Entra"))
			.Valor_USD = isDBNullToNothing(fila("Valor_USD"))
			.TRM = isDBNullToNothing(fila("TRM"))
			.Valor_COP = isDBNullToNothing(fila("Valor_COP"))
			.Fecha_Creacion = isDBNullToNothing(fila("Fecha_Creacion"))
			.Id_Usuario_Creacion = isDBNullToNothing(fila("Id_Usuario_Creacion"))
			.Fecha_Modificacion = isDBNullToNothing(fila("Fecha_Modificacion"))
			.Id_Usuario_Modificacion = isDBNullToNothing(fila("Id_Usuario_Modificacion"))

		End With
		
		Return objPpto_Traslados_Detalle
		
    End Function
	
	Public Shared Event LoadingPpto_Traslados_DetalleList(ByVal LoadType As String)
	Public Shared Event LoadedPpto_Traslados_DetalleList(target As List(Of Ppto_Traslados_DetalleBrl), ByVal LoadType As String)
	
	Public Shared Function CargarTodos() As List(Of Ppto_Traslados_DetalleBrl)

		Dim dsDatos As System.Data.DataSet
		Dim lista As New List(Of Ppto_Traslados_DetalleBrl)
	
		RaiseEvent LoadingPpto_Traslados_DetalleList("CargarTodos")
	
		dsDatos = Ppto_Traslados_DetalleDAL.CargarTodos()

        For Each fila as DataRow in dsDatos.Tables(0).Rows
			lista.Add(asignarValoresALasPropiedades(fila))
        Next
        
        RaiseEvent LoadedPpto_Traslados_DetalleList(lista, "CargarTodos")
        
        Return lista
        
    End Function

	Public Shared Event CargandoPorId(ByVal id As Int32)
    Public Shared Event CargadoPorId(ByVal target As Ppto_Traslados_DetalleBrl)

	Public Shared Function CargarPorID(ID As Int32) As Ppto_Traslados_DetalleBrl

		Dim dsDatos As System.Data.DataSet
		Dim objPpto_Traslados_Detalle As Ppto_Traslados_DetalleBrl = Nothing 
		
		'RaiseEvent CargandoPorId(ID)
			
		dsDatos = Ppto_Traslados_DetalleDAL.CargarPorID(ID)
		
		If dsDatos.Tables(0).Rows.Count <> 0 Then objPpto_Traslados_Detalle = asignarValoresALasPropiedades(dsDatos.Tables(0).Rows(0))
		
		'RaiseEvent CargadoPorId(objJoven)

        Return objPpto_Traslados_Detalle
        
    End Function
	Public Shared Function CargarPorId_Nivel_Entra(ByVal Id_Nivel_Entra As Int32) As List(Of Ppto_Traslados_DetalleBrl)

		Dim dsDatos As System.Data.DataSet
		Dim lista As New List(Of Ppto_Traslados_DetalleBrl)
	
		RaiseEvent LoadingPpto_Traslados_DetalleList("CargarPorId_Nivel_Entra")
		
		dsDatos = Ppto_Traslados_DetalleDAL.CargarPorId_Nivel_Entra(Id_Nivel_Entra)

        For Each fila as DataRow in dsDatos.Tables(0).Rows
			lista.Add(asignarValoresALasPropiedades(fila))
        Next
        
        RaiseEvent LoadedPpto_Traslados_DetalleList(lista, "CargarPorId_Nivel_Entra")
        
        Return lista
        
	End Function


	Public Shared Function CargarPorId_Traslado(ByVal Id_Traslado As Int32) As List(Of Ppto_Traslados_DetalleBrl)

		Dim dsDatos As System.Data.DataSet
		Dim lista As New List(Of Ppto_Traslados_DetalleBrl)
	
		RaiseEvent LoadingPpto_Traslados_DetalleList("CargarPorId_Traslado")
		
		dsDatos = Ppto_Traslados_DetalleDAL.CargarPorId_Traslado(Id_Traslado)

        For Each fila as DataRow in dsDatos.Tables(0).Rows
			lista.Add(asignarValoresALasPropiedades(fila))
        Next
        
        RaiseEvent LoadedPpto_Traslados_DetalleList(lista, "CargarPorId_Traslado")
        
        Return lista
        
	End Function



End Class


