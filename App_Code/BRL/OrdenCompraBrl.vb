Imports ingNovar.Utilidades2
Imports System.Data
Imports System.Collections.Generic
Imports SeguridadUsuarios

Partial Public Class OrdenCompraBrl

    Private _Id As Int32
    Private _Id_Regional As Int32
    Private _Numero As String
    Private _Fecha As DateTime
    Private _Tiempo_Entrega As String
    Private _Lugar_Entrega As String
    Private _Observaciones As String
    Private _Aprobacion_Finanzas_Ofc As Boolean
    Private _Aprobacion_Logistica_Ofc As Boolean
    Private _Aprobacion_Coordinacion As Boolean
    Private _Aprobacion_Operaciones As Boolean
    Private _Aprobacion_Financiera As Boolean
    Private _Aprobacion_CooLogistica As Boolean
    Private _Id_Tercero As Int32
    Private _Id_Tipo_Orden As Int32
    Private _Tasa As Double
    Private _Fecha_Creacion As DateTime
    Private _Id_Usuario_Creacion As Int32
    Private _Fecha_Modificacion As DateTime
    Private _Id_Usuario_Modificacion As Int32
    Private _Fecha_Cierre As DateTime
    Private _Cierre As Boolean
    Private _Forma_Pago As String
    Private _Id_Solicitado_Operaciones As Int32
    Private _Id_Proyecto As Int32

    Private objListOrdenCompra_Detalle As List(Of OrdenCompra_DetalleBrl)
    Private objListOrdenCompra_Retencion As List(Of OrdenCompra_RetencionBrl)


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

    Public Event Id_RegionalChanging(ByVal Value As Int32)
    Public Event Id_RegionalChanged()

    Public Property Id_Regional() As Int32
        Get
            Return Me._Id_Regional
        End Get
        Set(ByVal Value As Int32)
            If _Id_Regional <> Value Then
                RaiseEvent Id_RegionalChanging(Value)
                Me._Id_Regional = Value
                RaiseEvent Id_RegionalChanged()
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

    Public Event Tiempo_EntregaChanging(ByVal Value As String)
    Public Event Tiempo_EntregaChanged()

    Public Property Tiempo_Entrega() As String
        Get
            Return Me._Tiempo_Entrega
        End Get
        Set(ByVal Value As String)
            If _Tiempo_Entrega <> Value Then
                RaiseEvent Tiempo_EntregaChanging(Value)
                Me._Tiempo_Entrega = Value
                RaiseEvent Tiempo_EntregaChanged()
            End If
        End Set
    End Property

    Public Event Lugar_EntregaChanging(ByVal Value As String)
    Public Event Lugar_EntregaChanged()

    Public Property Lugar_Entrega() As String
        Get
            Return Me._Lugar_Entrega
        End Get
        Set(ByVal Value As String)
            If _Lugar_Entrega <> Value Then
                RaiseEvent Lugar_EntregaChanging(Value)
                Me._Lugar_Entrega = Value
                RaiseEvent Lugar_EntregaChanged()
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

    Public Event Forma_PagoChanging(ByVal Value As String)
    Public Event Forma_PagoChanged()

    Public Property Forma_Pago() As String
        Get
            Return Me._Forma_Pago
        End Get
        Set(ByVal Value As String)
            If _Forma_Pago <> Value Then
                RaiseEvent Forma_PagoChanging(Value)
                Me._Forma_Pago = Value
                RaiseEvent Forma_PagoChanged()
            End If
        End Set
    End Property

    Public Event Aprobacion_Finanzas_OfcChanging(ByVal Value As Boolean)
    Public Event Aprobacion_Finanzas_OfcChanged()

    Public Property Aprobacion_Finanzas_Ofc() As Boolean
        Get
            Return Me._Aprobacion_Finanzas_Ofc
        End Get
        Set(ByVal Value As Boolean)
            If _Aprobacion_Finanzas_Ofc <> Value Then
                RaiseEvent Aprobacion_Finanzas_OfcChanging(Value)
                Me._Aprobacion_Finanzas_Ofc = Value
                RaiseEvent Aprobacion_Finanzas_OfcChanged()
            End If
        End Set
    End Property

    Public Event Aprobacion_Logistica_OfcChanging(ByVal Value As Boolean)
    Public Event Aprobacion_Logistica_OfcChanged()

    Public Property Aprobacion_Logistica_Ofc() As Boolean
        Get
            Return Me._Aprobacion_Logistica_Ofc
        End Get
        Set(ByVal Value As Boolean)
            If _Aprobacion_Logistica_Ofc <> Value Then
                RaiseEvent Aprobacion_Logistica_OfcChanging(Value)
                Me._Aprobacion_Logistica_Ofc = Value
                RaiseEvent Aprobacion_Logistica_OfcChanged()
            End If
        End Set
    End Property

    Public Event Aprobacion_CoordinacionChanging(ByVal Value As Boolean)
    Public Event Aprobacion_CoordinacionChanged()

    Public Property Aprobacion_Coordinacion() As Boolean
        Get
            Return Me._Aprobacion_Coordinacion
        End Get
        Set(ByVal Value As Boolean)
            If _Aprobacion_Coordinacion <> Value Then
                RaiseEvent Aprobacion_CoordinacionChanging(Value)
                Me._Aprobacion_Coordinacion = Value
                RaiseEvent Aprobacion_CoordinacionChanged()
            End If
        End Set
    End Property

    Public Event Aprobacion_OperacionesChanging(ByVal Value As Boolean)
    Public Event Aprobacion_OperacionesChanged()

    Public Property Aprobacion_Operaciones() As Boolean
        Get
            Return Me._Aprobacion_Operaciones
        End Get
        Set(ByVal Value As Boolean)
            If _Aprobacion_Operaciones <> Value Then
                RaiseEvent Aprobacion_OperacionesChanging(Value)
                Me._Aprobacion_Operaciones = Value
                RaiseEvent Aprobacion_OperacionesChanged()
            End If
        End Set
    End Property

    Public Event Aprobacion_FinancieraChanging(ByVal Value As Boolean)
    Public Event Aprobacion_FinancieraChanged()

    Public Property Aprobacion_Financiera() As Boolean
        Get
            Return Me._Aprobacion_Financiera
        End Get
        Set(ByVal Value As Boolean)
            If _Aprobacion_Financiera <> Value Then
                RaiseEvent Aprobacion_FinancieraChanging(Value)
                Me._Aprobacion_Financiera = Value
                RaiseEvent Aprobacion_FinancieraChanged()
            End If
        End Set
    End Property

    Public Event Aprobacion_CooLogisticaChanging(ByVal Value As Boolean)
    Public Event Aprobacion_CooLogisticaChanged()

    Public Property Aprobacion_CooLogistica() As Boolean
        Get
            Return Me._Aprobacion_CooLogistica
        End Get
        Set(ByVal Value As Boolean)
            If _Aprobacion_CooLogistica <> Value Then
                RaiseEvent Aprobacion_CooLogisticaChanging(Value)
                Me._Aprobacion_CooLogistica = Value
                RaiseEvent Aprobacion_CooLogisticaChanged()
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

    Public Event Id_Tipo_OrdenChanging(ByVal Value As Int32)
    Public Event Id_Tipo_OrdenChanged()

    Public Property Id_Tipo_Orden() As Int32
        Get
            Return Me._Id_Tipo_Orden
        End Get
        Set(ByVal Value As Int32)
            If _Id_Tipo_Orden <> Value Then
                RaiseEvent Id_Tipo_OrdenChanging(Value)
                Me._Id_Tipo_Orden = Value
                RaiseEvent Id_Tipo_OrdenChanged()
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

    Public Event TasaChanging(ByVal Value As Double)
    Public Event TasaChanged()

    Public Property Tasa() As Double
        Get
            Return Me._Tasa
        End Get
        Set(ByVal Value As Double)
            If _Tasa <> Value Then
                RaiseEvent TasaChanging(Value)
                Me._Tasa = Value
                RaiseEvent TasaChanged()
            End If
        End Set
    End Property

    Public Event Fecha_CierreChanging(ByVal Value As DateTime)
    Public Event Fecha_CierreChanged()

    Public Property Fecha_Cierre() As DateTime
        Get
            Return Me._Fecha_Cierre
        End Get
        Set(ByVal Value As DateTime)
            If _Fecha_Cierre <> Value Then
                RaiseEvent Fecha_CierreChanging(Value)
                Me._Fecha_Cierre = Value
                RaiseEvent Fecha_CierreChanged()
            End If
        End Set
    End Property

    Public Event CierreChanging(ByVal Value As Boolean)
    Public Event CierreChanged()

    Public Property Cierre() As Boolean
        Get
            Return Me._Cierre
        End Get
        Set(ByVal Value As Boolean)
            If _Cierre <> Value Then
                RaiseEvent CierreChanging(Value)
                Me._Cierre = Value
                RaiseEvent CierreChanged()
            End If
        End Set
    End Property

    Public Event Id_Solicitado_OperacionesChanging(ByVal Value As Int32)
    Public Event Id_Solicitado_OperacionesChanged()

    Public Property Id_Solicitado_Operaciones() As Int32
        Get
            Return Me._Id_Solicitado_Operaciones
        End Get
        Set(ByVal Value As Int32)
            If _Id_Solicitado_Operaciones <> Value Then
                RaiseEvent Id_Solicitado_OperacionesChanging(Value)
                Me._Id_Solicitado_Operaciones = Value
                RaiseEvent Id_Solicitado_OperacionesChanged()
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

    Public Property OrdenCompra_Detalle() As List(Of OrdenCompra_DetalleBrl)
        Get
            If (Me.objListOrdenCompra_Detalle Is Nothing) Then
                objListOrdenCompra_Detalle = OrdenCompra_DetalleBrl.CargarPorId_OrdenCompra(Me.ID)
            End If
            Return Me.objListOrdenCompra_Detalle
        End Get
        Set(ByVal Value As List(Of OrdenCompra_DetalleBrl))
            Me.objListOrdenCompra_Detalle = Value
        End Set
    End Property

    Public Property OrdenCompra_Retencion() As List(Of OrdenCompra_RetencionBrl)
        Get
            If (Me.objListOrdenCompra_Retencion Is Nothing) Then
                objListOrdenCompra_Retencion = OrdenCompra_RetencionBrl.CargarPorId_OrdenCompra(Me.ID)
            End If
            Return Me.objListOrdenCompra_Retencion
        End Get
        Set(ByVal Value As List(Of OrdenCompra_RetencionBrl))
            Me.objListOrdenCompra_Retencion = Value
        End Set
    End Property

    Public ReadOnly Property Regional() As SubTablasBrl
        Get
            Return SubTablasBrl.CargarPorID(Id_Regional)
        End Get
    End Property

    Public ReadOnly Property UsuariosCreacion() As UsuariosBrl
        Get
            Return UsuariosBrl.CargarPorID(Id_Usuario_Creacion)
        End Get
    End Property

    Public ReadOnly Property Solicitado_Operaciones() As SubTablasBrl
        Get
            Return SubTablasBrl.CargarPorID(Id_Solicitado_Operaciones)
        End Get
    End Property

    Public ReadOnly Property UsuariosModificacion() As UsuariosBrl
        Get
            Return UsuariosBrl.CargarPorID(Id_Usuario_Modificacion)
        End Get
    End Property

    Public ReadOnly Property EstadoOrden() As String
        Get
            Dim wsaldo As Double = 0
            For Each fila As OrdenCompra_DetalleBrl In OrdenCompra_Detalle
                wsaldo += fila.saldo
            Next
            If wsaldo = 0 Then Return ("OK")
            Return "PD"
        End Get
    End Property

    '' Este no se borra pertenece solo a Modulo Finanzas
    Public ReadOnly Property Terceros() As Ppto_TercerosBrl
        Get
            Return Ppto_TercerosBrl.CargarPorID(Id_Tercero)
        End Get
    End Property

    Public ReadOnly Property Tipo_Orden() As SubTablasBrl
        Get
            Return SubTablasBrl.CargarPorID(Id_Tipo_Orden)
        End Get
    End Property

    Public ReadOnly Property ValorOrdenCompra() As Double
        Get
            Dim wvalor As Double = 0
            For Each fila As OrdenCompra_DetalleBrl In OrdenCompra_Detalle
                wvalor += fila.ValorProducto
            Next
            Return wvalor
        End Get
    End Property

    Public ReadOnly Property ValorOrdenCompraUSD() As Double
        Get
            If ValorOrdenCompra = 0 Then Return 0
            Return ValorOrdenCompra / Tasa
        End Get
    End Property

    Public ReadOnly Property DescripcionOrdenCompra() As String
        Get
            Try
                Return Numero + " por " + Format(ValorOrdenCompra, "C") + " a : " + Terceros.Razon_Social
            Catch ex As Exception
                Return Numero + " por " + Format(ValorOrdenCompra, "C")
            End Try

        End Get
    End Property

    Public ReadOnly Property ValorRetencionOrdenCompra() As Double
        Get
            Dim wvalor As Double = 0
            For Each fila As OrdenCompra_RetencionBrl In OrdenCompra_Retencion
                wvalor += fila.Valor
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
            Me.ID = OrdenCompraDAL.Insertar(Id_Regional, Numero, Fecha, Tiempo_Entrega, Lugar_Entrega, Observaciones, Aprobacion_Finanzas_Ofc, Aprobacion_Logistica_Ofc, Aprobacion_Coordinacion, Aprobacion_Operaciones, Aprobacion_CooLogistica, Fecha_Creacion, Id_Usuario_Creacion, Fecha_Modificacion, Id_Usuario_Modificacion, Id_Tercero, Id_Tipo_Orden, Aprobacion_Financiera, Tasa, Fecha_Cierre, Cierre, Forma_Pago, Id_Solicitado_Operaciones, Id_Proyecto)
            RaiseEvent Inserted()
        Else
            RaiseEvent Updating()
            OrdenCompraDAL.Actualizar(ID, Id_Regional, Numero, Fecha, Tiempo_Entrega, Lugar_Entrega, Observaciones, Aprobacion_Finanzas_Ofc, Aprobacion_Logistica_Ofc, Aprobacion_Coordinacion, Aprobacion_Operaciones, Aprobacion_CooLogistica, Fecha_Creacion, Id_Usuario_Creacion, Fecha_Modificacion, Id_Usuario_Modificacion, Id_Tercero, Id_Tipo_Orden, Aprobacion_Financiera, Tasa, Fecha_Cierre, Cierre, Forma_Pago, Id_Solicitado_Operaciones, Id_Proyecto)
            RaiseEvent Updated()
        End If
        If Not objListOrdenCompra_Detalle Is Nothing Then
            For Each fila As OrdenCompra_DetalleBrl In objListOrdenCompra_Detalle
                fila.Id_OrdenCompra = Me.ID
                Try
                    fila.Guardar()
                Catch ex As Exception
                End Try
            Next
        End If

        If Not objListOrdenCompra_Retencion Is Nothing Then
            For Each fila As OrdenCompra_RetencionBrl In objListOrdenCompra_Retencion
                fila.Id_OrdenCompra = Me.ID
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
            totalHijos += OrdenCompra_Detalle.Count
            totalHijos += OrdenCompra_Retencion.Count
            If totalHijos > 0 Then Throw New Exception("No se puede eliminar el registro porque existen datos que dependen de él.")
            OrdenCompraDAL.Eliminar(Me.ID)
            RaiseEvent Deleted()

        End If
    End Sub

    Private Shared Function asignarValoresALasPropiedades(ByVal fila As DataRow) As OrdenCompraBrl

        Dim objOrdenCompra As New OrdenCompraBrl

        With objOrdenCompra
            .ID = fila("Id")
            .Id_Regional = isDBNullToNothing(fila("Id_Regional"))
            .Numero = isDBNullToNothing(fila("Numero"))
            .Fecha = isDBNullToNothing(fila("Fecha"))
            .Tiempo_Entrega = isDBNullToNothing(fila("Tiempo_Entrega"))
            .Lugar_Entrega = isDBNullToNothing(fila("Lugar_Entrega"))
            .Observaciones = isDBNullToNothing(fila("Observaciones"))
            .Aprobacion_Finanzas_Ofc = isDBNullToNothing(fila("Aprobacion_Finanzas_Ofc"))
            .Aprobacion_Logistica_Ofc = isDBNullToNothing(fila("Aprobacion_Logistica_Ofc"))
            .Aprobacion_Coordinacion = isDBNullToNothing(fila("Aprobacion_Coordinacion"))
            .Aprobacion_Operaciones = isDBNullToNothing(fila("Aprobacion_Operaciones"))
            .Aprobacion_Financiera = isDBNullToNothing(fila("Aprobacion_Financiera"))
            .Aprobacion_CooLogistica = isDBNullToNothing(fila("Aprobacion_CooLogistica"))
            .Id_Tercero = isDBNullToNothing(fila("Id_Tercero"))
            .Id_Tipo_Orden = isDBNullToNothing(fila("Id_Tipo_Orden"))
            .Fecha_Creacion = isDBNullToNothing(fila("Fecha_Creacion"))
            .Id_Usuario_Creacion = isDBNullToNothing(fila("Id_Usuario_Creacion"))
            .Fecha_Modificacion = isDBNullToNothing(fila("Fecha_Modificacion"))
            .Id_Usuario_Modificacion = isDBNullToNothing(fila("Id_Usuario_Modificacion"))
            .Tasa = isDBNullToNothing(fila("Tasa"))
            .Fecha_Cierre = isDBNullToNothing(fila("Fecha_Cierre"))
            .Cierre = isDBNullToNothing(fila("Cierre"))
            .Forma_Pago = isDBNullToNothing(fila("Forma_Pago"))
            .Id_Solicitado_Operaciones = isDBNullToNothing(fila("Id_Solicitado_Operaciones"))
            .Id_Proyecto = isDBNullToNothing(fila("Id_Proyecto"))
        End With

        Return objOrdenCompra

    End Function

    Public Shared Event LoadingOrdenCompraList(ByVal LoadType As String)
    Public Shared Event LoadedOrdenCompraList(ByVal target As List(Of OrdenCompraBrl), ByVal LoadType As String)

    Public Shared Function CargarTodos(ByVal Id_Proyecto As Int32) As List(Of OrdenCompraBrl)

        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of OrdenCompraBrl)
        RaiseEvent LoadingOrdenCompraList("CargarTodos")
        dsDatos = OrdenCompraDAL.CargarTodos(Id_Proyecto)
        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next
        RaiseEvent LoadedOrdenCompraList(lista, "CargarTodos")

        Return lista

    End Function

    Public Shared Event LoadingPorId(ByVal id As Int32)
    Public Shared Event LoadedPorId(ByVal target As OrdenCompraBrl)

    Public Shared Function CargarPorID(ByVal ID As Int32) As OrdenCompraBrl

        Dim dsDatos As System.Data.DataSet
        Dim objOrdenCompra As OrdenCompraBrl = Nothing
        dsDatos = OrdenCompraDAL.CargarPorID(ID)
        If dsDatos.Tables(0).Rows.Count <> 0 Then objOrdenCompra = asignarValoresALasPropiedades(dsDatos.Tables(0).Rows(0))
        Return objOrdenCompra

    End Function

    Public Shared Function CargarPorId_Regional(ByVal Id_Regional As Int32) As List(Of OrdenCompraBrl)

        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of OrdenCompraBrl)
        RaiseEvent LoadingOrdenCompraList("CargarPorId_Regional")
        dsDatos = OrdenCompraDAL.CargarPorId_Regional(Id_Regional)
        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next
        RaiseEvent LoadedOrdenCompraList(lista, "CargarPorId_Regional")
        Return lista

    End Function

    Public Shared Function CargarPorId_Usuario_Creacion(ByVal Id_Usuario_Creacion As Int32) As List(Of OrdenCompraBrl)

        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of OrdenCompraBrl)
        RaiseEvent LoadingOrdenCompraList("CargarPorId_Usuario_Creacion")
        dsDatos = OrdenCompraDAL.CargarPorId_Usuario_Creacion(Id_Usuario_Creacion)
        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next
        RaiseEvent LoadedOrdenCompraList(lista, "CargarPorId_Usuario_Creacion")

        Return lista

    End Function

    Public Shared Function CargarPorId_Usuario_Modificacion(ByVal Id_Usuario_Modificacion As Int32) As List(Of OrdenCompraBrl)

        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of OrdenCompraBrl)

        RaiseEvent LoadingOrdenCompraList("CargarPorId_Usuario_Modificacion")
        dsDatos = OrdenCompraDAL.CargarPorId_Usuario_Modificacion(Id_Usuario_Modificacion)
        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next
        RaiseEvent LoadedOrdenCompraList(lista, "CargarPorId_Usuario_Modificacion")
        Return lista

    End Function

    Public Shared Function CargarPorAprobarLogOfc(ByVal Numero As String, ByVal Id_Tercero As Int32, ByVal Id_regional As Int32, ByVal Fecha_inicial As String, ByVal Fecha_final As String, ByVal Id_proyecto As Integer) As List(Of OrdenCompraBrl)

        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of OrdenCompraBrl)
        RaiseEvent LoadingOrdenCompraList("CargarPorAprobarLogOfc")
        dsDatos = OrdenCompraDAL.CargarPorAprobarLogOfc(Numero, Id_Tercero, Id_regional, Fecha_inicial, Fecha_final, Id_proyecto)
        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next
        RaiseEvent LoadedOrdenCompraList(lista, "CargarPorAprobarLogOfc")
        Return lista

    End Function

    Public Shared Function CargarPorAprobarFinOfc(ByVal Numero As String, ByVal Id_Tercero As Int32, ByVal Id_regional As Int32, ByVal Fecha_inicial As String, ByVal Fecha_final As String, ByVal Id_proyecto As Integer) As List(Of OrdenCompraBrl)

        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of OrdenCompraBrl)
        RaiseEvent LoadingOrdenCompraList("CargarPorAprobarFinOfc")
        dsDatos = OrdenCompraDAL.CargarPorAprobarFinOfc(Numero, Id_Tercero, Id_regional, Fecha_inicial, Fecha_final, Id_proyecto)
        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next
        RaiseEvent LoadedOrdenCompraList(lista, "CargarPorAprobarFinOfc")

        Return lista

    End Function

    Public Shared Function CargarPorAprobarCooLog(ByVal Numero As String, ByVal Id_Tercero As Int32, ByVal Id_regional As Int32, ByVal Fecha_inicial As String, ByVal Fecha_final As String, ByVal Id_proyecto As Integer) As List(Of OrdenCompraBrl)

        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of OrdenCompraBrl)
        RaiseEvent LoadingOrdenCompraList("CargarPorAprobarCooLog")
        dsDatos = OrdenCompraDAL.CargarPorAprobarCooLog(Numero, Id_Tercero, Id_regional, Fecha_inicial, Fecha_final, Id_proyecto)
        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next
        RaiseEvent LoadedOrdenCompraList(lista, "CargarPorAprobarCooLog")

        Return lista

    End Function

    Public Shared Function CargarPorAprobarDirOpe(ByVal Numero As String, ByVal Id_Tercero As Int32, ByVal Id_regional As Int32, ByVal Fecha_inicial As String, ByVal Fecha_final As String, ByVal Id_proyecto As Integer) As List(Of OrdenCompraBrl)

        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of OrdenCompraBrl)
        RaiseEvent LoadingOrdenCompraList("CargarPorAprobarDirOpe")
        dsDatos = OrdenCompraDAL.CargarPorAprobarDirOpe(Numero, Id_Tercero, Id_Tercero, Fecha_inicial, Fecha_final, Id_proyecto)
        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next
        RaiseEvent LoadedOrdenCompraList(lista, "CargarPorAprobarDirOpe")

        Return lista

    End Function

    Public Shared Function CargarPorAprobarDirFin(ByVal Numero As String, ByVal Id_Tercero As Int32, ByVal Id_regional As Int32, ByVal Fecha_inicial As String, ByVal Fecha_final As String, ByVal Id_proyecto As Integer) As List(Of OrdenCompraBrl)

        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of OrdenCompraBrl)
        RaiseEvent LoadingOrdenCompraList("CargarPorAprobarDirFin")
        dsDatos = OrdenCompraDAL.CargarPorAprobarDirFin(Numero, Id_Tercero, Id_regional, Fecha_inicial, Fecha_final, Id_proyecto)
        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next
        RaiseEvent LoadedOrdenCompraList(lista, "CargarPorAprobarDirFin")

        Return lista

    End Function

    Public Shared Function CargarPorAprobarCooReg(ByVal Numero As String, ByVal Id_Tercero As Int32, ByVal Id_regional As Int32, ByVal Fecha_inicial As String, ByVal Fecha_final As String, ByVal Id_proyecto As Integer) As List(Of OrdenCompraBrl)

        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of OrdenCompraBrl)
        RaiseEvent LoadingOrdenCompraList("CargarPorAprobarcooreg")
        dsDatos = OrdenCompraDAL.CargarPorAprobarCooReg(Numero, Id_Tercero, Id_regional, Fecha_inicial, Fecha_final, Id_proyecto)
        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next
        RaiseEvent LoadedOrdenCompraList(lista, "CargarPorAprobarCooReg")

        Return lista

    End Function

    Public Shared Function CargarPorBusqueda(ByVal Id_Regional As Int32, ByVal Numero As String, ByVal Fecha_Inicial As String, ByVal Fecha_Final As String, ByVal Id_Producto As Integer, ByVal Id_Tercero As Integer, ByVal Id_proyecto As Integer) As List(Of OrdenCompraBrl)

        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of OrdenCompraBrl)
        RaiseEvent LoadingOrdenCompraList("CargarPorBusqueda")
        dsDatos = OrdenCompraDAL.CargarPorBusqueda(Id_Regional, Numero, Fecha_Inicial, Fecha_Final, Id_Producto, Id_Tercero, Id_proyecto)
        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next
        RaiseEvent LoadedOrdenCompraList(lista, "CargarPorBusqueda")
        Return lista

    End Function

    Public Shared Function CargarPorId_Tercero(ByVal Id_Tercero As Int32) As List(Of OrdenCompraBrl)

        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of OrdenCompraBrl)

        RaiseEvent LoadingOrdenCompraList("CargarPorId_Tercero")
        dsDatos = OrdenCompraDAL.CargarPorId_Tercero(Id_Tercero)
        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next
        RaiseEvent LoadedOrdenCompraList(lista, "CargarPorId_Tercero")

        Return lista

    End Function

    Public Shared Function CargarPorId_Tipo_Orden(ByVal Id_Tipo_Orden As Int32) As List(Of OrdenCompraBrl)
        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of OrdenCompraBrl)
        dsDatos = OrdenCompraDAL.CargarPorId_Tipo_Orden(Id_Tipo_Orden)
        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next
        Return lista
    End Function

    Public Shared Function CargarPorNumero(ByVal Numero As String) As OrdenCompraBrl

        Dim dsDatos As System.Data.DataSet
        Dim objOrdenCompra As OrdenCompraBrl = Nothing
        dsDatos = OrdenCompraDAL.CargarPorNumero(Numero)
        If dsDatos.Tables(0).Rows.Count <> 0 Then objOrdenCompra = asignarValoresALasPropiedades(dsDatos.Tables(0).Rows(0))
        Return objOrdenCompra

    End Function

End Class


