Imports ingNovar.Utilidades2
imports system.data
Imports system.collections.generic


Partial Public Class Ppto_TrasladosBrl

    Private _Id As Int32
    Private _Fecha As DateTime
    Private _Numero As String
    Private _Id_Nivel_Sale As Int32
    Private _Observaciones As String
    Private _Fecha_Creacion As DateTime
    Private _Id_Usuario_Creacion As Int32
    Private _Fecha_Modificacion As DateTime
    Private _Id_Usuario_Modificacion As Int32
    Private _Id_Proyecto As Int32
    Private objListPpto_Traslados_Detalle As List(Of Ppto_Traslados_DetalleBrl)


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

    Public Event NumeroChanging(ByVal Value As String)
    Public Event NumeroChanged()
	
    Public Property Numero() As String
        Get
            Return Me._Numero
        End Get
        Set(ByVal Value As String)
            If _Numero <> Value Then
                RaiseEvent NumeroChanging(Value)
				Me._Numero = Value
                RaiseEvent NumeroChanged()
            End If
        End Set
    End Property

    Public Event Id_Nivel_SaleChanging(ByVal Value As Int32)
    Public Event Id_Nivel_SaleChanged()
	
    Public Property Id_Nivel_Sale() As Int32
        Get
            Return Me._Id_Nivel_Sale
        End Get
        Set(ByVal Value As Int32)
            If _Id_Nivel_Sale <> Value Then
                RaiseEvent Id_Nivel_SaleChanging(Value)
				Me._Id_Nivel_Sale = Value
                RaiseEvent Id_Nivel_SaleChanged()
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

    Public Property Ppto_Traslados_Detalle() As List(Of Ppto_Traslados_DetalleBrl)
        Get
            If (Me.objListPpto_Traslados_Detalle Is Nothing) Then
                objListPpto_Traslados_Detalle = Ppto_Traslados_DetalleBrl.CargarPorId_Traslado(Me.ID)
            End If
            Return Me.objListPpto_Traslados_Detalle
        End Get
        Set(ByVal Value As List(Of Ppto_Traslados_DetalleBrl))
            Me.objListPpto_Traslados_Detalle = Value
        End Set
    End Property

    Public Readonly Property Nivel() As SubTablasBrl
        Get
            Return SubTablasBrl.CargarPorID(Id_Nivel_Sale)
        End Get
    End Property

    Public ReadOnly Property Suma_Valor_USD() As Double
        Get
            Dim wvalor As Double = 0
            For Each fila As Ppto_Traslados_DetalleBrl In Ppto_Traslados_Detalle
                wvalor += fila.Valor_USD
            Next
            Return wvalor
        End Get
    End Property

    Public ReadOnly Property Suma_Valor_COP() As Double
        Get
            Dim wvalor As Double = 0
            For Each fila As Ppto_Traslados_DetalleBrl In Ppto_Traslados_Detalle
                wvalor += fila.Valor_COP
            Next
            Return wvalor
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
            Me.ID = Ppto_TrasladosDAL.Insertar(Fecha, Numero, Id_Nivel_Sale, Observaciones, Fecha_Creacion, Id_Usuario_Creacion, Fecha_Modificacion, Id_Usuario_Modificacion, Id_Proyecto)
            RaiseEvent Inserted()
        Else
            RaiseEvent Updating()
            Ppto_TrasladosDAL.Actualizar(ID, Fecha, Numero, Id_Nivel_Sale, Observaciones, Fecha_Creacion, Id_Usuario_Creacion, Fecha_Modificacion, Id_Usuario_Modificacion, Id_Proyecto)
            RaiseEvent Updated()
        End If
        If Not objListPpto_Traslados_Detalle Is Nothing Then
            For Each fila As Ppto_Traslados_DetalleBrl In objListPpto_Traslados_Detalle
                fila.Id_Traslado = Me.ID
                Try
                    fila.Guardar()
                Catch ex As Exception

                End Try
            Next
        End If

        RaiseEvent Saved()

    End Sub
	
	Public Sub Eliminar()
		Dim totalHijos As Long = 0
		If Me.ID <> Nothing Then 
			
            RaiseEvent Deleting()
            totalHijos += Ppto_Traslados_Detalle.Count
            If totalHijos > 0 Then Throw New Exception("No se puede eliminar el registro porque existen datos que dependen de él.")
            
			Ppto_TrasladosDAL.Eliminar(Me.ID)
			
            RaiseEvent Deleted()
            
        End If
	End Sub
	
    Private Shared Function asignarValoresALasPropiedades(ByVal fila As DataRow) As Ppto_TrasladosBrl

        Dim objPpto_Traslados As New Ppto_TrasladosBrl

        With objPpto_Traslados
            .ID = fila("Id")
            .Fecha = isDBNullToNothing(fila("Fecha"))
            .Numero = isDBNullToNothing(fila("Numero"))
            .Id_Nivel_Sale = isDBNullToNothing(fila("Id_Nivel_Sale"))
            .Observaciones = isDBNullToNothing(fila("Observaciones"))
            .Fecha_Creacion = isDBNullToNothing(fila("Fecha_Creacion"))
            .Id_Usuario_Creacion = isDBNullToNothing(fila("Id_Usuario_Creacion"))
            .Fecha_Modificacion = isDBNullToNothing(fila("Fecha_Modificacion"))
            .Id_Usuario_Modificacion = isDBNullToNothing(fila("Id_Usuario_Modificacion"))
            .Id_Proyecto = isDBNullToNothing(fila("Id_Proyecto"))
        End With

        Return objPpto_Traslados

    End Function
	
	Public Shared Event LoadingPpto_TrasladosList(ByVal LoadType As String)
	Public Shared Event LoadedPpto_TrasladosList(target As List(Of Ppto_TrasladosBrl), ByVal LoadType As String)
	
    Public Shared Function CargarTodos(ByVal Id_Proyecto As Int32) As List(Of Ppto_TrasladosBrl)

        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of Ppto_TrasladosBrl)

        RaiseEvent LoadingPpto_TrasladosList("CargarTodos")

        dsDatos = Ppto_TrasladosDAL.CargarTodos(Id_Proyecto)

        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next

        RaiseEvent LoadedPpto_TrasladosList(lista, "CargarTodos")

        Return lista

    End Function

	Public Shared Event CargandoPorId(ByVal id As Int32)
    Public Shared Event CargadoPorId(ByVal target As Ppto_TrasladosBrl)

	Public Shared Function CargarPorID(ID As Int32) As Ppto_TrasladosBrl

		Dim dsDatos As System.Data.DataSet
		Dim objPpto_Traslados As Ppto_TrasladosBrl = Nothing 
        dsDatos = Ppto_TrasladosDAL.CargarPorID(ID)
		
		If dsDatos.Tables(0).Rows.Count <> 0 Then objPpto_Traslados = asignarValoresALasPropiedades(dsDatos.Tables(0).Rows(0))

        Return objPpto_Traslados
        
    End Function

	Public Shared Function CargarPorId_Nivel_Sale(ByVal Id_Nivel_Sale As Int32) As List(Of Ppto_TrasladosBrl)

		Dim dsDatos As System.Data.DataSet
		Dim lista As New List(Of Ppto_TrasladosBrl)
	
		RaiseEvent LoadingPpto_TrasladosList("CargarPorId_Nivel_Sale")
		
		dsDatos = Ppto_TrasladosDAL.CargarPorId_Nivel_Sale(Id_Nivel_Sale)

        For Each fila as DataRow in dsDatos.Tables(0).Rows
			lista.Add(asignarValoresALasPropiedades(fila))
        Next
        
        RaiseEvent LoadedPpto_TrasladosList(lista, "CargarPorId_Nivel_Sale")
        
        Return lista
        
	End Function

    Public Shared Function CargarPorBusqueda(ByVal fechainicial As String, ByVal fechafinal As String, ByVal id_nivel As Int32, ByVal Id_proyecto As Int32) As List(Of Ppto_TrasladosBrl)

        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of Ppto_TrasladosBrl)
        dsDatos = Ppto_TrasladosDAL.CargarPorBusqueda(fechainicial, fechafinal, id_nivel, Id_proyecto)
        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next
        Return lista

    End Function


End Class


