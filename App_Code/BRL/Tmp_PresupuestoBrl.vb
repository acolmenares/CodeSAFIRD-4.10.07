Imports ingNovar.Utilidades2
imports system.data
Imports system.collections.generic


Partial Public Class Tmp_PresupuestoBrl

    Private _Id As Int32
    Private _Descripcion As String
    Private _Id_padre As Int32
    Private _Id_Tipo_Unidad As Int32
    Private _Numero_Unidades As Double
    Private _Costo_Unidad As Double
    Private _Incremento As Double
    Private _Reduccion As Double
    Private _OrdenCompra As Double
    Private _Contratos As Double
    Private _Ejecutado As Double
    Private _Distribucion As Double


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

    Public Event DescripcionChanging(ByVal Value As String)
    Public Event DescripcionChanged()
	
    Public Property Descripcion() As String
        Get
            Return Me._Descripcion
        End Get
        Set(ByVal Value As String)
            If _Descripcion <> Value Then
                RaiseEvent DescripcionChanging(Value)
				Me._Descripcion = Value
                RaiseEvent DescripcionChanged()
            End If
        End Set
    End Property

    Public Event Id_padreChanging(ByVal Value As Int32)
    Public Event Id_padreChanged()
	
    Public Property Id_padre() As Int32
        Get
            Return Me._Id_padre
        End Get
        Set(ByVal Value As Int32)
            If _Id_padre <> Value Then
                RaiseEvent Id_padreChanging(Value)
				Me._Id_padre = Value
                RaiseEvent Id_padreChanged()
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

    Public Event IncrementoChanging(ByVal Value As Double)
    Public Event IncrementoChanged()
	
    Public Property Incremento() As Double
        Get
            Return Me._Incremento
        End Get
        Set(ByVal Value As Double)
            If _Incremento <> Value Then
                RaiseEvent IncrementoChanging(Value)
				Me._Incremento = Value
                RaiseEvent IncrementoChanged()
            End If
        End Set
    End Property

    Public Event ReduccionChanging(ByVal Value As Double)
    Public Event ReduccionChanged()
	
    Public Property Reduccion() As Double
        Get
            Return Me._Reduccion
        End Get
        Set(ByVal Value As Double)
            If _Reduccion <> Value Then
                RaiseEvent ReduccionChanging(Value)
				Me._Reduccion = Value
                RaiseEvent ReduccionChanged()
            End If
        End Set
    End Property

    Public Event OrdenCompraChanging(ByVal Value As Double)
    Public Event OrdenCompraChanged()
	
    Public Property OrdenCompra() As Double
        Get
            Return Me._OrdenCompra
        End Get
        Set(ByVal Value As Double)
            If _OrdenCompra <> Value Then
                RaiseEvent OrdenCompraChanging(Value)
				Me._OrdenCompra = Value
                RaiseEvent OrdenCompraChanged()
            End If
        End Set
    End Property

    Public Event ContratosChanging(ByVal Value As Double)
    Public Event ContratosChanged()
	
    Public Property Contratos() As Double
        Get
            Return Me._Contratos
        End Get
        Set(ByVal Value As Double)
            If _Contratos <> Value Then
                RaiseEvent ContratosChanging(Value)
				Me._Contratos = Value
                RaiseEvent ContratosChanged()
            End If
        End Set
    End Property

    Public Event EjecutadoChanging(ByVal Value As Double)
    Public Event EjecutadoChanged()
	
    Public Property Ejecutado() As Double
        Get
            Return Me._Ejecutado
        End Get
        Set(ByVal Value As Double)
            If _Ejecutado <> Value Then
                RaiseEvent EjecutadoChanging(Value)
				Me._Ejecutado = Value
                RaiseEvent EjecutadoChanged()
            End If
        End Set
    End Property

    Public Event DistribucionChanging(ByVal Value As Double)
    Public Event DistribucionChanged()

    Public Property Distribucion() As Double
        Get
            Return Me._Distribucion
        End Get
        Set(ByVal Value As Double)
            If _Distribucion <> Value Then
                RaiseEvent DistribucionChanging(Value)
                Me._Distribucion = Value
                RaiseEvent DistribucionChanged()
            End If
        End Set
    End Property

    Public Readonly Property Padre() As SubTablasBrl
        Get
            Return SubTablasBrl.CargarPorID(Id_Padre)
        End Get
    End Property

    Public Readonly Property TipoUnidad() As SubTablasBrl
        Get
            Return SubTablasBrl.CargarPorID(Id_Tipo_Unidad)
        End Get
    End Property

    Public ReadOnly Property Saldo_PRM() As Double
        Get
            Return Distribucion - Reduccion + Incremento
        End Get
    End Property

    Public ReadOnly Property disponible() As Double
        Get
            Return Saldo_PRM - Contratos - OrdenCompra
        End Get
    End Property

    Public ReadOnly Property Por_Ejecutar() As Double
        Get
            Return Contratos + OrdenCompra - Ejecutado
        End Get
    End Property

    Public ReadOnly Property Balance() As Double
        Get
            Return Saldo_PRM - Ejecutado
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
            Me.ID = Tmp_PresupuestoDAL.Insertar(Descripcion, Id_padre, Id_Tipo_Unidad, Numero_Unidades, Costo_Unidad, Incremento, Reduccion, OrdenCompra, Contratos, Ejecutado)
            RaiseEvent Inserted()
        Else
            RaiseEvent Updating()
            Tmp_PresupuestoDAL.Actualizar(ID, Descripcion, Id_padre, Id_Tipo_Unidad, Numero_Unidades, Costo_Unidad, Incremento, Reduccion, OrdenCompra, Contratos, Ejecutado)
            RaiseEvent Updated()
        End If

        RaiseEvent Saved()

    End Sub

    Public Sub Eliminar()
        Dim totalHijos As Long = 0
        If Me.ID <> Nothing Then

            RaiseEvent Deleting()

            If totalHijos > 0 Then Throw New Exception("No se puede eliminar el registro porque existen datos que dependen de él.")

            Tmp_PresupuestoDAL.Eliminar(Me.ID)

            RaiseEvent Deleted()

        End If
    End Sub


    Private Shared Function asignarValoresALasPropiedades(ByVal fila As DataRow) As Tmp_PresupuestoBrl

        Dim objTmp_Presupuesto As New Tmp_PresupuestoBrl

        With objTmp_Presupuesto
            .ID = fila("Id")
            .Descripcion = isDBNullToNothing(fila("Descripcion"))
            .Id_padre = isDBNullToNothing(fila("Id_padre"))
            .Id_Tipo_Unidad = isDBNullToNothing(fila("Id_Tipo_Unidad"))
            .Numero_Unidades = isDBNullToNothing(fila("Numero_Unidades"))
            .Costo_Unidad = isDBNullToNothing(fila("Costo_Unidad"))
            .Incremento = isDBNullToNothing(fila("Incremento"))
            .Reduccion = isDBNullToNothing(fila("Reduccion"))
            .OrdenCompra = isDBNullToNothing(fila("OrdenCompra"))
            .Contratos = isDBNullToNothing(fila("Contratos"))
            .Ejecutado = isDBNullToNothing(fila("Ejecutado"))
            .Distribucion = isDBNullToNothing(fila("Distribucion"))
        End With

        Return objTmp_Presupuesto

    End Function

    Public Shared Event LoadingTmp_PresupuestoList(ByVal LoadType As String)
    Public Shared Event LoadedTmp_PresupuestoList(ByVal target As List(Of Tmp_PresupuestoBrl), ByVal LoadType As String)

    Public Shared Function CargarTodos() As List(Of Tmp_PresupuestoBrl)

        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of Tmp_PresupuestoBrl)

        RaiseEvent LoadingTmp_PresupuestoList("CargarTodos")

        dsDatos = Tmp_PresupuestoDAL.CargarTodos()

        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next

        RaiseEvent LoadedTmp_PresupuestoList(lista, "CargarTodos")

        Return lista

    End Function

    Public Shared Event CargandoPorId(ByVal id As Int32)
    Public Shared Event CargadoPorId(ByVal target As Tmp_PresupuestoBrl)

    Public Shared Function CargarPorID(ByVal ID As Int32) As Tmp_PresupuestoBrl

        Dim dsDatos As System.Data.DataSet
        Dim objTmp_Presupuesto As Tmp_PresupuestoBrl = Nothing
        dsDatos = Tmp_PresupuestoDAL.CargarPorID(ID)

        If dsDatos.Tables(0).Rows.Count <> 0 Then objTmp_Presupuesto = asignarValoresALasPropiedades(dsDatos.Tables(0).Rows(0))

        Return objTmp_Presupuesto

    End Function

    Public Shared Function CargarPorId_padre(ByVal Id_padre As Int32) As List(Of Tmp_PresupuestoBrl)

        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of Tmp_PresupuestoBrl)

        RaiseEvent LoadingTmp_PresupuestoList("CargarPorId_padre")

        dsDatos = Tmp_PresupuestoDAL.CargarPorId_Padre(Id_padre)

        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next

        RaiseEvent LoadedTmp_PresupuestoList(lista, "CargarPorId_padre")

        Return lista

    End Function

    Public Shared Function CargarPorId_Tipo_Unidad(ByVal Id_Tipo_Unidad As Int32) As List(Of Tmp_PresupuestoBrl)

        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of Tmp_PresupuestoBrl)

        RaiseEvent LoadingTmp_PresupuestoList("CargarPorId_Tipo_Unidad")

        dsDatos = Tmp_PresupuestoDAL.CargarPorId_Tipo_Unidad(Id_Tipo_Unidad)

        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next

        RaiseEvent LoadedTmp_PresupuestoList(lista, "CargarPorId_Tipo_Unidad")

        Return lista

    End Function

End Class


