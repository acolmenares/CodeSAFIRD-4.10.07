Imports ingNovar.Utilidades2
imports system.data
Imports system.collections.generic


Partial Public Class Ppto_DistribucionBrl

    Private _Id As Int32
    Private _Id_Nivel As Int32
    Private _Valor_USD As Double
    Private _Fecha As DateTime
    Private _Id_Ingreso As Int32
    Private _Id_Tipo_Unidad As Int32
    Private _Fecha_Creacion As DateTime
    Private _Id_Usuario_Creacion As Int32
    Private _Fecha_Modificacion As DateTime
    Private _Id_Usuario_Modificacion As Int32
    Private _Numero_Unidades As Double
    Private _Costo_Unidad As Double
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

    Public Event Id_NivelChanging(ByVal Value As Int32)
    Public Event Id_NivelChanged()
	
    Public Property Id_Nivel() As Int32
        Get
            Return Me._Id_Nivel
        End Get
        Set(ByVal Value As Int32)
            If _Id_Nivel <> Value Then
                RaiseEvent Id_NivelChanging(Value)
				Me._Id_Nivel = Value
                RaiseEvent Id_NivelChanged()
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

    Public Event Id_IngresoChanging(ByVal Value As Int32)
    Public Event Id_IngresoChanged()
	
    Public Property Id_Ingreso() As Int32
        Get
            Return Me._Id_Ingreso
        End Get
        Set(ByVal Value As Int32)
            If _Id_Ingreso <> Value Then
                RaiseEvent Id_IngresoChanging(Value)
				Me._Id_Ingreso = Value
                RaiseEvent Id_IngresoChanged()
            End If
        End Set
    End Property

    Public Event Id_Tipo_UnidadChanging(ByVal Value As Int32)
    Public Event Id_Tipo_UnidadChanged()
	
    Public Property Id_Tipo_Unidad() As Int32
        Get
            Return Me._Id_Tipo_Unidad
        End Get
        Set(ByVal Value As Int32)
            If _Id_Tipo_Unidad <> Value Then
                RaiseEvent Id_Tipo_UnidadChanging(Value)
				Me._Id_Tipo_Unidad = Value
                RaiseEvent Id_Tipo_UnidadChanged()
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

    Public Event Numero_UnidadesChanging(ByVal Value As Double)
    Public Event Numero_UnidadesChanged()

    Public Property Numero_Unidades() As Double
        Get
            Return Me._Numero_Unidades
        End Get
        Set(ByVal Value As Double)
            If _Numero_Unidades <> Value Then
                RaiseEvent Numero_UnidadesChanging(Value)
                Me._Numero_Unidades = Value
                RaiseEvent Numero_UnidadesChanged()
            End If
        End Set
    End Property

    Public Event Costo_UnidadChanging(ByVal Value As Double)
    Public Event Costo_UnidadChanged()

    Public Property Costo_Unidad() As Double
        Get
            Return Me._Costo_Unidad
        End Get
        Set(ByVal Value As Double)
            If _Costo_Unidad <> Value Then
                RaiseEvent Costo_UnidadChanging(Value)
                Me._Costo_Unidad = Value
                RaiseEvent Costo_UnidadChanged()
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

    Public ReadOnly Property Ppto_Ingresos() As Ppto_IngresosBrl
        Get
            Return Ppto_IngresosBrl.CargarPorID(Id_Ingreso)
        End Get
    End Property

    Public Readonly Property Nivel() As SubTablasBrl
        Get
            Return SubTablasBrl.CargarPorID(Id_Nivel)
        End Get
    End Property

    Public Readonly Property Tipo_Unidad() As SubTablasBrl
        Get
            Return SubTablasBrl.CargarPorID(Id_Tipo_Unidad)
        End Get
    End Property

    '
    '  Variables Locales
    '
    Public ReadOnly Property Valor_Pesos() As Double
        Get
            Return Valor_USD * Ppto_Ingresos.TRM
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
            Me.ID = Ppto_DistribucionDAL.Insertar(Id_Nivel, Valor_USD, Fecha, Id_Ingreso, Id_Tipo_Unidad, Fecha_Creacion, Id_Usuario_Creacion, Fecha_Modificacion, Id_Usuario_Modificacion, Numero_Unidades, Costo_Unidad, Id_Proyecto)
            RaiseEvent Inserted()
        Else
            RaiseEvent Updating()
            Ppto_DistribucionDAL.Actualizar(ID, Id_Nivel, Valor_USD, Fecha, Id_Ingreso, Id_Tipo_Unidad, Fecha_Creacion, Id_Usuario_Creacion, Fecha_Modificacion, Id_Usuario_Modificacion, Numero_Unidades, Costo_Unidad, Id_Proyecto)
            RaiseEvent Updated()
        End If

        RaiseEvent Saved()

    End Sub

    Public Sub Eliminar()
        Dim totalHijos As Long = 0
        If Me.ID <> Nothing Then

            RaiseEvent Deleting()
            If totalHijos > 0 Then Throw New Exception("No se puede eliminar el registro porque existen datos que dependen de él.")

            Ppto_DistribucionDAL.Eliminar(Me.ID)

            RaiseEvent Deleted()

        End If
    End Sub

    Private Shared Function asignarValoresALasPropiedades(ByVal fila As DataRow) As Ppto_DistribucionBrl

        Dim objPpto_Distribucion As New Ppto_DistribucionBrl

        With objPpto_Distribucion
            .ID = fila("Id")
            .Id_Nivel = isDBNullToNothing(fila("Id_Nivel"))
            .Valor_USD = isDBNullToNothing(fila("Valor_USD"))
            .Fecha = isDBNullToNothing(fila("Fecha"))
            .Id_Ingreso = isDBNullToNothing(fila("Id_Ingreso"))
            .Id_Tipo_Unidad = isDBNullToNothing(fila("Id_Tipo_Unidad"))
            .Fecha_Creacion = isDBNullToNothing(fila("Fecha_Creacion"))
            .Id_Usuario_Creacion = isDBNullToNothing(fila("Id_Usuario_Creacion"))
            .Fecha_Modificacion = isDBNullToNothing(fila("Fecha_Modificacion"))
            .Id_Usuario_Modificacion = isDBNullToNothing(fila("Id_Usuario_Modificacion"))
            .Numero_Unidades = isDBNullToNothing(fila("Numero_Unidades"))
            .Costo_Unidad = isDBNullToNothing(fila("Costo_Unidad"))
            .Id_Proyecto = isDBNullToNothing(fila("Id_Proyecto"))
        End With

        Return objPpto_Distribucion

    End Function

    Public Shared Event LoadingPpto_DistribucionList(ByVal LoadType As String)
    Public Shared Event LoadedPpto_DistribucionList(ByVal target As List(Of Ppto_DistribucionBrl), ByVal LoadType As String)

    Public Shared Function CargarTodos(ByVal Id_Proyecto As Int32) As List(Of Ppto_DistribucionBrl)

        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of Ppto_DistribucionBrl)

        RaiseEvent LoadingPpto_DistribucionList("CargarTodos")

        dsDatos = Ppto_DistribucionDAL.CargarTodos(Id_Proyecto)

        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next

        RaiseEvent LoadedPpto_DistribucionList(lista, "CargarTodos")

        Return lista

    End Function

    Public Shared Event CargandoPorId(ByVal id As Int32)
    Public Shared Event CargadoPorId(ByVal target As Ppto_DistribucionBrl)

    Public Shared Function CargarPorID(ByVal ID As Int32) As Ppto_DistribucionBrl

        Dim dsDatos As System.Data.DataSet
        Dim objPpto_Distribucion As Ppto_DistribucionBrl = Nothing

        dsDatos = Ppto_DistribucionDAL.CargarPorID(ID)
        If dsDatos.Tables(0).Rows.Count <> 0 Then objPpto_Distribucion = asignarValoresALasPropiedades(dsDatos.Tables(0).Rows(0))
        Return objPpto_Distribucion

    End Function

    Public Shared Function CargarPorId_Ingreso(ByVal Id_Ingreso As Int32) As List(Of Ppto_DistribucionBrl)

        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of Ppto_DistribucionBrl)

        RaiseEvent LoadingPpto_DistribucionList("CargarPorId_Ingreso")

        dsDatos = Ppto_DistribucionDAL.CargarPorId_Ingreso(Id_Ingreso)

        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next

        RaiseEvent LoadedPpto_DistribucionList(lista, "CargarPorId_Ingreso")

        Return lista

    End Function

    Public Shared Function CargarPorId_Nivel(ByVal Id_Nivel As Int32) As List(Of Ppto_DistribucionBrl)

        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of Ppto_DistribucionBrl)

        RaiseEvent LoadingPpto_DistribucionList("CargarPorId_Nivel")

        dsDatos = Ppto_DistribucionDAL.CargarPorId_Nivel(Id_Nivel)

        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next

        RaiseEvent LoadedPpto_DistribucionList(lista, "CargarPorId_Nivel")

        Return lista

    End Function

    Public Shared Function CargarPorId_Tipo_Unidad(ByVal Id_Tipo_Unidad As Int32) As List(Of Ppto_DistribucionBrl)

        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of Ppto_DistribucionBrl)

        RaiseEvent LoadingPpto_DistribucionList("CargarPorId_Tipo_Unidad")

        dsDatos = Ppto_DistribucionDAL.CargarPorId_Tipo_Unidad(Id_Tipo_Unidad)

        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next

        RaiseEvent LoadedPpto_DistribucionList(lista, "CargarPorId_Tipo_Unidad")

        Return lista

    End Function

    Public Shared Function CargarPorBusqueda(ByVal fechainicial As String, ByVal fechafinal As String, ByVal Id_TipoUnidad As Int32, ByVal Id_Ingreso As Int32, ByVal Id_nivel As Int32, ByVal Id_Proyecto As Int32) As List(Of Ppto_DistribucionBrl)

        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of Ppto_DistribucionBrl)
        dsDatos = Ppto_DistribucionDAL.CargarPorBusqueda(fechainicial, fechafinal, Id_TipoUnidad, Id_Ingreso, Id_nivel, Id_Proyecto)
        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next
        Return lista

    End Function



End Class


