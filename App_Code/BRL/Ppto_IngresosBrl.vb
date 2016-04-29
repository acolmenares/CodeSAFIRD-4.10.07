Imports ingNovar.Utilidades2
imports system.data
Imports system.collections.generic


Partial Public Class Ppto_IngresosBrl

    Private _Id As Int32
    Private _Fecha As DateTime
    Private _Nombre_Entrega As String
    Private _Valor_USD As Double
    Private _TRM As Double
    Private _Valor_COP As Double
    Private _Observaciones As String
    Private _Fecha_Creacion As DateTime
    Private _Id_Usuario_Creacion As Int32
    Private _Fecha_Modificacion As DateTime
    Private _Id_Usuario_Modificacion As Int32
    Private _Id_Proyecto As Int32

    Private objListPpto_Distribucion As List(Of Ppto_DistribucionBrl)


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

    Public Event Nombre_EntregaChanging(ByVal Value As String)
    Public Event Nombre_EntregaChanged()
	
    Public Property Nombre_Entrega() As String
        Get
            Return Me._Nombre_Entrega
        End Get
        Set(ByVal Value As String)
            If _Nombre_Entrega <> Value Then
                RaiseEvent Nombre_EntregaChanging(Value)
				Me._Nombre_Entrega = Value
                RaiseEvent Nombre_EntregaChanged()
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

    Public Property Ppto_Distribucion() As List(Of Ppto_DistribucionBrl)
        Get
            If (Me.objListPpto_Distribucion Is Nothing) Then
                objListPpto_Distribucion = Ppto_DistribucionBrl.CargarPorId_Ingreso(Me.ID)
            End If
            Return Me.objListPpto_Distribucion
        End Get
        Set(ByVal Value As List(Of Ppto_DistribucionBrl))
            Me.objListPpto_Distribucion = Value
        End Set
    End Property

    '
    ' Variables de Manejo de la Clase
    '
    Public ReadOnly Property Descripcion() As String
        Get
            Return "De " & Format(Fecha, "dd/MMM/yyyy") & " - " & Mid(Nombre_Entrega, 1, 20) & " por " & Format(Valor_USD, "C").ToString
        End Get
    End Property

    Public Function MontoDistribuido() As Double
        Dim wcantidad As Double = 0
        For Each fila As Ppto_DistribucionBrl In Ppto_Distribucion
            wcantidad += fila.Valor_USD
        Next
        Return wcantidad
    End Function

    Public Function SaldoIngreso() As Double
        Return Valor_USD - MontoDistribuido()
    End Function

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
            Me.ID = Ppto_IngresosDAL.Insertar(Fecha, Nombre_Entrega, Valor_USD, TRM, Valor_COP, Observaciones, Fecha_Creacion, Id_Usuario_Creacion, Fecha_Modificacion, Id_Usuario_Modificacion, Id_Proyecto)
            RaiseEvent Inserted()
        Else
            RaiseEvent Updating()
            Ppto_IngresosDAL.Actualizar(ID, Fecha, Nombre_Entrega, Valor_USD, TRM, Valor_COP, Observaciones, Fecha_Creacion, Id_Usuario_Creacion, Fecha_Modificacion, Id_Usuario_Modificacion, Id_Proyecto)
            RaiseEvent Updated()
        End If
        If Not objListPpto_Distribucion Is Nothing Then
            For Each fila As Ppto_DistribucionBrl In objListPpto_Distribucion
                fila.Id_Ingreso = Me.ID
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
            totalHijos += Ppto_Distribucion.Count
            If totalHijos > 0 Then Throw New Exception("No se puede eliminar el registro porque existen datos que dependen de él.")
            Ppto_IngresosDAL.Eliminar(Me.ID)
            RaiseEvent Deleted()

        End If
    End Sub

    Private Shared Function asignarValoresALasPropiedades(ByVal fila As DataRow) As Ppto_IngresosBrl

        Dim objPpto_Ingresos As New Ppto_IngresosBrl

        With objPpto_Ingresos
            .ID = fila("Id")
            .Fecha = isDBNullToNothing(fila("Fecha"))
            .Nombre_Entrega = isDBNullToNothing(fila("Nombre_Entrega"))
            .Valor_USD = isDBNullToNothing(fila("Valor_USD"))
            .TRM = isDBNullToNothing(fila("TRM"))
            .Valor_COP = isDBNullToNothing(fila("Valor_COP"))
            .Observaciones = isDBNullToNothing(fila("Observaciones"))
            .Fecha_Creacion = isDBNullToNothing(fila("Fecha_Creacion"))
            .Id_Usuario_Creacion = isDBNullToNothing(fila("Id_Usuario_Creacion"))
            .Fecha_Modificacion = isDBNullToNothing(fila("Fecha_Modificacion"))
            .Id_Usuario_Modificacion = isDBNullToNothing(fila("Id_Usuario_Modificacion"))
            .Id_Proyecto = isDBNullToNothing(fila("Id_Proyecto"))
        End With

        Return objPpto_Ingresos

    End Function

    Public Shared Event LoadingPpto_IngresosList(ByVal LoadType As String)
    Public Shared Event LoadedPpto_IngresosList(ByVal target As List(Of Ppto_IngresosBrl), ByVal LoadType As String)

    Public Shared Function CargarTodos(ByVal Id_Proyecto As Int32) As List(Of Ppto_IngresosBrl)

        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of Ppto_IngresosBrl)

        RaiseEvent LoadingPpto_IngresosList("CargarTodos")

        dsDatos = Ppto_IngresosDAL.CargarTodos(Id_Proyecto)

        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next

        RaiseEvent LoadedPpto_IngresosList(lista, "CargarTodos")

        Return lista

    End Function

    Public Shared Event CargandoPorId(ByVal id As Int32)
    Public Shared Event CargadoPorId(ByVal target As Ppto_IngresosBrl)

    Public Shared Function CargarPorID(ByVal ID As Int32) As Ppto_IngresosBrl

        Dim dsDatos As System.Data.DataSet
        Dim objPpto_Ingresos As Ppto_IngresosBrl = Nothing
        dsDatos = Ppto_IngresosDAL.CargarPorID(ID)
        If dsDatos.Tables(0).Rows.Count <> 0 Then objPpto_Ingresos = asignarValoresALasPropiedades(dsDatos.Tables(0).Rows(0))
        Return objPpto_Ingresos

    End Function

    Public Shared Function CargarPorBusqueda(ByVal fechainicial As String, ByVal fechafinal As String, ByVal nombre As String, ByVal Id_Proyecto As Int32) As List(Of Ppto_IngresosBrl)
        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of Ppto_IngresosBrl)
        dsDatos = Ppto_IngresosDAL.CargarPorBusqueda(fechainicial, fechafinal, nombre, Id_Proyecto)
        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next
        Return lista
    End Function

End Class


