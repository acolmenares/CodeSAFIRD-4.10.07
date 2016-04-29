Imports ingNovar.Utilidades2
Imports System.Data
Imports System.Collections.Generic
Imports SeguridadUsuarios

Partial Public Class OrdenCompra_DetalleBrl

    Private _Id As Int32
    Private _Id_OrdenCompra As Int32
    Private _Id_Producto As Int32
    Private _Id_Unidad_Medida As Int32
    Private _Cantidad As Double
    Private _Valor_Unitario As Double
    Private _Activo As Boolean
    Private _Motivo_Cancelacion As String
    Private _Id_Usuario_Inactivo As Int32
    Private _Id_Nivel As Int32
    Private _Descripcion_General As String
    Private _Codigo_Proyecto As String
    Private _Fecha_Creacion As DateTime
    Private _Id_Usuario_Creacion As Int32
    Private _Fecha_Modificacion As DateTime
    Private _Id_Usuario_Modificacion As Int32
    Private _Fecha_Cierre As DateTime
    Private _Cierre As Boolean

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

    Public Event Id_Unidad_MedidaChanging(ByVal Value As Int32)
    Public Event Id_Unidad_MedidaChanged()

    Public Property Id_Unidad_Medida() As Int32
        Get
            Return Me._Id_Unidad_Medida
        End Get
        Set(ByVal Value As Int32)
            If _Id_Unidad_Medida <> Value Then
                RaiseEvent Id_Unidad_MedidaChanging(Value)
				Me._Id_Unidad_Medida = Value
                RaiseEvent Id_Unidad_MedidaChanged()
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

    Public Event ActivoChanging(ByVal Value As Boolean)
    Public Event ActivoChanged()
	
    Public Property Activo() As Boolean
        Get
            Return Me._Activo
        End Get
        Set(ByVal Value As Boolean)
            If _Activo <> Value Then
                RaiseEvent ActivoChanging(Value)
                Me._Activo = Value
                RaiseEvent ActivoChanged()
            End If
        End Set
    End Property

    Public Event Motivo_CancelacionChanging(ByVal Value As String)
    Public Event Motivo_CancelacionChanged()
	
    Public Property Motivo_Cancelacion() As String
        Get
            Return Me._Motivo_Cancelacion
        End Get
        Set(ByVal Value As String)
            If _Motivo_Cancelacion <> Value Then
                RaiseEvent Motivo_CancelacionChanging(Value)
                Me._Motivo_Cancelacion = Value
                RaiseEvent Motivo_CancelacionChanged()
            End If
        End Set
    End Property

    Public Event Id_Usuario_InactivoChanging(ByVal Value As Int32)
    Public Event Id_Usuario_InactivoChanged()
	
    Public Property Id_Usuario_Inactivo() As Int32
        Get
            Return Me._Id_Usuario_Inactivo
        End Get
        Set(ByVal Value As Int32)
            If _Id_Usuario_Inactivo <> Value Then
                RaiseEvent Id_Usuario_InactivoChanging(Value)
                Me._Id_Usuario_Inactivo = Value
                RaiseEvent Id_Usuario_InactivoChanged()
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

    Public Event Descripcion_GeneralChanging(ByVal Value As String)
    Public Event Descripcion_GeneralChanged()

    Public Property Descripcion_General() As String
        Get
            Return Me._Descripcion_General
        End Get
        Set(ByVal Value As String)
            If _Descripcion_General <> Value Then
                RaiseEvent Descripcion_GeneralChanging(Value)
                Me._Descripcion_General = Value
                RaiseEvent Descripcion_GeneralChanged()
            End If
        End Set
    End Property

    Public Event Codigo_ProyectoChanging(ByVal Value As String)
    Public Event Codigo_ProyectoChanged()

    Public Property Codigo_Proyecto() As String
        Get
            Return Me._Codigo_Proyecto
        End Get
        Set(ByVal Value As String)
            If _Codigo_Proyecto <> Value Then
                RaiseEvent Codigo_ProyectoChanging(Value)
                Me._Codigo_Proyecto = Value
                RaiseEvent Codigo_ProyectoChanged()
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
                objListEntradas_OrdenCompra = Entradas_OrdenCompraBrl.CargarPorId_OrdenCompra_Detalle(Me.ID)
            End If
            Return Me.objListEntradas_OrdenCompra
        End Get
        Set(ByVal Value As List(Of Entradas_OrdenCompraBrl))
            Me.objListEntradas_OrdenCompra = Value
        End Set
    End Property

    Public ReadOnly Property OrdenCompra() As OrdenCompraBrl
        Get
            Return OrdenCompraBrl.CargarPorID(Id_OrdenCompra)
        End Get
    End Property

    Public ReadOnly Property Productos() As SubTablasBrl
        Get
            Return SubTablasBrl.CargarPorID(Id_Producto)
        End Get
    End Property

    Public ReadOnly Property UnidadMedida() As SubTablasBrl
        Get
            Return SubTablasBrl.CargarPorID(Id_Unidad_Medida)
        End Get
    End Property

    Public ReadOnly Property Nivel() As SubTablasBrl
        Get
            Return SubTablasBrl.CargarPorID(Id_Nivel)
        End Get
    End Property

    Public ReadOnly Property UsuariosCreacion() As UsuariosBrl
        Get
            Return UsuariosBrl.CargarPorID(Id_Usuario_Creacion)
        End Get
    End Property

    Public Readonly Property UsuariosInactivo() As UsuariosBrl
        Get
            Return UsuariosBrl.CargarPorID(Id_Usuario_Inactivo)
        End Get
    End Property

    Public ReadOnly Property UsuariosModificacion() As UsuariosBrl
        Get
            Return UsuariosBrl.CargarPorID(Id_Usuario_Modificacion)
        End Get
    End Property

    Public ReadOnly Property ValorProducto() As Double
        Get
            Return cantidad * valor_unitario
        End Get
    End Property

    Public ReadOnly Property detalleysaldo() As String ' Especial con filtro de regional y producto
        Get
            Dim wcadena As String
            wcadena = OrdenCompra.Numero.ToString & " Por :" & Cantidad.ToString & " - Entradas : " & Entradas_OrdenCompraBrl.CantidadEntradaOC(Me.ID) & " - Saldo : " & Cantidad - Entradas_OrdenCompraBrl.CantidadEntradaOC(Me.ID)
            Return wcadena
        End Get
    End Property

    Public ReadOnly Property DescripcionFinanciera() As String ' Especial para Finanzas
        Get
            Dim wcadena As String
            Try
                wcadena = OrdenCompra.Numero.ToString & " Por " & Format(ValorProducto, "C") & " de " & Productos.Descripcion
            Catch ex As Exception
                wcadena = ""
            End Try

            Return wcadena
        End Get
    End Property

    Public ReadOnly Property cantidadentrada() As Double
        Get
            Dim wvalor As Double = 0
            For Each fila As Entradas_OrdenCompraBrl In Entradas_OrdenCompra
                wvalor += fila.Cantidad
            Next
            Return wvalor
        End Get
    End Property

    Public ReadOnly Property saldo() As Double
        Get
            Return Cantidad - cantidadentrada
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
            Me.ID = OrdenCompra_DetalleDAL.Insertar(Id_OrdenCompra, Id_Producto, Id_Unidad_Medida, Cantidad, Valor_Unitario, Activo, Motivo_Cancelacion, Id_Usuario_Inactivo, Fecha_Creacion, Id_Usuario_Creacion, Fecha_Modificacion, Id_Usuario_Modificacion, Id_Nivel, Descripcion_General, Codigo_Proyecto, Fecha_Cierre, Cierre)
            RaiseEvent Inserted()
        Else
            RaiseEvent Updating()
            OrdenCompra_DetalleDAL.Actualizar(ID, Id_OrdenCompra, Id_Producto, Id_Unidad_Medida, Cantidad, Valor_Unitario, Activo, Motivo_Cancelacion, Id_Usuario_Inactivo, Fecha_Creacion, Id_Usuario_Creacion, Fecha_Modificacion, Id_Usuario_Modificacion, Id_Nivel, Descripcion_General, Codigo_Proyecto, Fecha_Cierre, Cierre)
            RaiseEvent Updated()
        End If

        RaiseEvent Saved()

    End Sub

    Public Sub Eliminar()
        Dim totalHijos As Long = 0
        If Me.ID <> Nothing Then

            RaiseEvent Deleting()
            If totalHijos > 0 Then Throw New Exception("No se puede eliminar el registro porque existen datos que dependen de él.")
            OrdenCompra_DetalleDAL.Eliminar(Me.ID)

            RaiseEvent Deleted()

        End If
    End Sub

    Private Shared Function asignarValoresALasPropiedades(ByVal fila As DataRow) As OrdenCompra_DetalleBrl

        Dim objOrdenCompra_Detalle As New OrdenCompra_DetalleBrl

        With objOrdenCompra_Detalle
            .ID = fila("Id")
            .Id_OrdenCompra = isDBNullToNothing(fila("Id_OrdenCompra"))
            .Id_Producto = isDBNullToNothing(fila("Id_Producto"))
            .Id_Unidad_Medida = isDBNullToNothing(fila("Id_Unidad_Medida"))
            .Cantidad = isDBNullToNothing(fila("Cantidad"))
            .Valor_Unitario = isDBNullToNothing(fila("Valor_Unitario"))
            .Activo = isDBNullToNothing(fila("Activo"))
            .Motivo_Cancelacion = isDBNullToNothing(fila("Motivo_Cancelacion"))
            .Id_Usuario_Inactivo = isDBNullToNothing(fila("Id_Usuario_Inactivo"))
            .Id_Nivel = isDBNullToNothing(fila("Id_Nivel"))
            .Descripcion_General = isDBNullToNothing(fila("Descripcion_General"))
            .Codigo_Proyecto = isDBNullToNothing(fila("Codigo_Proyecto"))
            .Fecha_Creacion = isDBNullToNothing(fila("Fecha_Creacion"))
            .Id_Usuario_Creacion = isDBNullToNothing(fila("Id_Usuario_Creacion"))
            .Fecha_Modificacion = isDBNullToNothing(fila("Fecha_Modificacion"))
            .Id_Usuario_Modificacion = isDBNullToNothing(fila("Id_Usuario_Modificacion"))
            .Fecha_Cierre = isDBNullToNothing(fila("Fecha_Cierre"))
            .Cierre = isDBNullToNothing(fila("Cierre"))
        End With

        Return objOrdenCompra_Detalle

    End Function

    Public Shared Event LoadingOrdenCompra_DetalleList(ByVal LoadType As String)
    Public Shared Event LoadedOrdenCompra_DetalleList(ByVal target As List(Of OrdenCompra_DetalleBrl), ByVal LoadType As String)

    Public Shared Function CargarTodos(ByVal Id_Proyecto As Int32) As List(Of OrdenCompra_DetalleBrl)

        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of OrdenCompra_DetalleBrl)

        RaiseEvent LoadingOrdenCompra_DetalleList("CargarTodos")

        dsDatos = OrdenCompra_DetalleDAL.CargarTodos(Id_Proyecto)

        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next

        RaiseEvent LoadedOrdenCompra_DetalleList(lista, "CargarTodos")

        Return lista

    End Function

    Public Shared Event LoadingPorId(ByVal id As Int32)
    Public Shared Event LoadedPorId(ByVal target As OrdenCompra_DetalleBrl)

    Public Shared Function CargarPorID(ByVal ID As Int32) As OrdenCompra_DetalleBrl

        Dim dsDatos As System.Data.DataSet
        Dim objOrdenCompra_Detalle As OrdenCompra_DetalleBrl = Nothing
        dsDatos = OrdenCompra_DetalleDAL.CargarPorID(ID)
        If dsDatos.Tables(0).Rows.Count <> 0 Then objOrdenCompra_Detalle = asignarValoresALasPropiedades(dsDatos.Tables(0).Rows(0))
        Return objOrdenCompra_Detalle

    End Function

    Public Shared Function CargarPorId_OrdenCompra(ByVal Id_OrdenCompra As Int32) As List(Of OrdenCompra_DetalleBrl)

        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of OrdenCompra_DetalleBrl)
        RaiseEvent LoadingOrdenCompra_DetalleList("CargarPorId_OrdenCompra")
        dsDatos = OrdenCompra_DetalleDAL.CargarPorId_OrdenCompra(Id_OrdenCompra)
        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next
        RaiseEvent LoadedOrdenCompra_DetalleList(lista, "CargarPorId_OrdenCompra")
        Return lista

    End Function

    Public Shared Function CargarPorId_Producto(ByVal Id_Producto As Int32) As List(Of OrdenCompra_DetalleBrl)

        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of OrdenCompra_DetalleBrl)
        RaiseEvent LoadingOrdenCompra_DetalleList("CargarPorId_Producto")
        dsDatos = OrdenCompra_DetalleDAL.CargarPorId_Producto(Id_Producto)
        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next
        RaiseEvent LoadedOrdenCompra_DetalleList(lista, "CargarPorId_Producto")
        Return lista

    End Function

    Public Shared Function CargarPorId_Unidad_Medida(ByVal Id_Unidad_Medida As Int32) As List(Of OrdenCompra_DetalleBrl)

        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of OrdenCompra_DetalleBrl)

        RaiseEvent LoadingOrdenCompra_DetalleList("CargarPorId_Unidad_Medida")
        dsDatos = OrdenCompra_DetalleDAL.CargarPorId_Unidad_Medida(Id_Unidad_Medida)
        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next
        RaiseEvent LoadedOrdenCompra_DetalleList(lista, "CargarPorId_Unidad_Medida")
        Return lista

    End Function

    Public Shared Function CargarPorId_Usuario_Creacion(ByVal Id_Usuario_Creacion As Int32) As List(Of OrdenCompra_DetalleBrl)

        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of OrdenCompra_DetalleBrl)
        RaiseEvent LoadingOrdenCompra_DetalleList("CargarPorId_Usuario_Creacion")
        dsDatos = OrdenCompra_DetalleDAL.CargarPorId_Usuario_Creacion(Id_Usuario_Creacion)
        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next
        RaiseEvent LoadedOrdenCompra_DetalleList(lista, "CargarPorId_Usuario_Creacion")

        Return lista

    End Function

    Public Shared Function CargarPorId_Usuario_Inactivo(ByVal Id_Usuario_Inactivo As Int32) As List(Of OrdenCompra_DetalleBrl)

        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of OrdenCompra_DetalleBrl)

        RaiseEvent LoadingOrdenCompra_DetalleList("CargarPorId_Usuario_Inactivo")
        dsDatos = OrdenCompra_DetalleDAL.CargarPorId_Usuario_Inactivo(Id_Usuario_Inactivo)
        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next
        RaiseEvent LoadedOrdenCompra_DetalleList(lista, "CargarPorId_Usuario_Inactivo")

        Return lista

    End Function

    Public Shared Function CargarPorId_Usuario_Modificacion(ByVal Id_Usuario_Modificacion As Int32) As List(Of OrdenCompra_DetalleBrl)

        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of OrdenCompra_DetalleBrl)
        RaiseEvent LoadingOrdenCompra_DetalleList("CargarPorId_Usuario_Modificacion")
        dsDatos = OrdenCompra_DetalleDAL.CargarPorId_Usuario_Modificacion(Id_Usuario_Modificacion)
        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next
        RaiseEvent LoadedOrdenCompra_DetalleList(lista, "CargarPorId_Usuario_Modificacion")

        Return lista
    End Function

    Public Shared Function CargarPorId_ProductoYId_Regional(ByVal Id_Producto As Int32, ByVal Id_Regional As Int32) As List(Of OrdenCompra_DetalleBrl)

        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of OrdenCompra_DetalleBrl)
        RaiseEvent LoadingOrdenCompra_DetalleList("CargarPorId_ProductoYId_Regional")
        dsDatos = OrdenCompra_DetalleDAL.CargarPorId_ProductoyId_Regional(Id_Producto, Id_Regional)
        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next
        RaiseEvent LoadedOrdenCompra_DetalleList(lista, "CargarPorId_ProductoYId_Regional")
        Return lista

    End Function


    Public Shared Function CargarPorId_Nivel(ByVal Id_Nivel As Int32) As List(Of OrdenCompra_DetalleBrl)
        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of OrdenCompra_DetalleBrl)
        dsDatos = OrdenCompra_DetalleDAL.CargarPorId_Nivel(Id_Nivel)
        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next
        Return lista

    End Function

End Class


