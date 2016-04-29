Imports ingNovar.Utilidades2
Imports System.Data
Imports System.Collections.Generic

Partial Public Class Entradas_OrdenCompraBrl

    Private _Id As Int32
    Private _Id_Entrada_Detalle As Int32
    Private _Cantidad As Double
    Private _Id_OrdenCompra_Detalle As Int32
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

    Public Event Id_OrdenCompra_DetalleChanging(ByVal Value As Int32)
    Public Event Id_OrdenCompra_DetalleChanged()

    Public Property Id_OrdenCompra_Detalle() As Int32
        Get
            Return Me._Id_OrdenCompra_Detalle
        End Get
        Set(ByVal Value As Int32)
            If _Id_OrdenCompra_Detalle <> Value Then
                RaiseEvent Id_OrdenCompra_DetalleChanging(Value)
                Me._Id_OrdenCompra_Detalle = Value
                RaiseEvent Id_OrdenCompra_DetalleChanged()
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

    Public ReadOnly Property Entradas_Detalle() As Entradas_DetalleBrl
        Get
            Return Entradas_DetalleBrl.CargarPorID(Id_Entrada_Detalle)
        End Get
    End Property

    Public ReadOnly Property OrdenCompra_Detalle() As OrdenCompra_DetalleBrl
        Get
            Return OrdenCompra_DetalleBrl.CargarPorID(Id_OrdenCompra_Detalle)
        End Get
    End Property

    Public ReadOnly Property CantidadEntregada() As Integer
        Get
            Return Entradas_OrdenCompraBrl.CantidadEntradaOC(Id_OrdenCompra_Detalle)
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


    Private Shared Function asignarValoresALasPropiedades(ByVal fila As DataRow) As Entradas_OrdenCompraBrl

        Dim objEntradas_OrdenCompra As New Entradas_OrdenCompraBrl

        With objEntradas_OrdenCompra
            .ID = fila("Id")
            .Id_Entrada_Detalle = isDBNullToNothing(fila("Id_Entrada_Detalle"))
            .Cantidad = isDBNullToNothing(fila("Cantidad"))
            .Id_OrdenCompra_Detalle = isDBNullToNothing(fila("Id_OrdenCompra_Detalle"))
            .Fecha_Creacion = isDBNullToNothing(fila("Fecha_Creacion"))
            .Id_Usuario_Creacion = isDBNullToNothing(fila("Id_Usuario_Creacion"))
            .Fecha_Modificacion = isDBNullToNothing(fila("Fecha_Modificacion"))
            .Id_Usuario_Modificacion = isDBNullToNothing(fila("Id_Usuario_Modificacion"))

        End With

        Return objEntradas_OrdenCompra

    End Function

    Public Shared Event LoadingEntradas_OrdenCompraList(ByVal LoadType As String)
    Public Shared Event LoadedEntradas_OrdenCompraList(ByVal target As List(Of Entradas_OrdenCompraBrl), ByVal LoadType As String)

    Public Shared Function CargarTodos() As List(Of Entradas_OrdenCompraBrl)

        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of Entradas_OrdenCompraBrl)

        RaiseEvent LoadingEntradas_OrdenCompraList("CargarTodos")

        dsDatos = Entradas_OrdenCompraDAL.CargarTodos()

        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next

        RaiseEvent LoadedEntradas_OrdenCompraList(lista, "CargarTodos")

        Return lista

    End Function

    Public Shared Event LoadingPorId(ByVal id As Int32)
    Public Shared Event LoadedPorId(ByVal target As Entradas_OrdenCompraBrl)

    Public Shared Function CargarPorID(ByVal ID As Int32) As Entradas_OrdenCompraBrl

        Dim dsDatos As System.Data.DataSet
        Dim objEntradas_OrdenCompra As Entradas_OrdenCompraBrl = Nothing

        dsDatos = Entradas_OrdenCompraDAL.CargarPorID(ID)

        If dsDatos.Tables(0).Rows.Count <> 0 Then objEntradas_OrdenCompra = asignarValoresALasPropiedades(dsDatos.Tables(0).Rows(0))

        Return objEntradas_OrdenCompra

    End Function

    Public Shared Function CargarPorId_Entrada_Detalle(ByVal Id_Entrada_Detalle As Int32) As List(Of Entradas_OrdenCompraBrl)

        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of Entradas_OrdenCompraBrl)

        RaiseEvent LoadingEntradas_OrdenCompraList("CargarPorId_Entrada_Detalle")

        dsDatos = Entradas_OrdenCompraDAL.CargarPorId_Entrada_Detalle(Id_Entrada_Detalle)

        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next

        RaiseEvent LoadedEntradas_OrdenCompraList(lista, "CargarPorId_Entrada_Detalle")

        Return lista

    End Function

    Public Shared Function CargarPorId_OrdenCompra_Detalle(ByVal Id_OrdenCompra_Detalle As Int32) As List(Of Entradas_OrdenCompraBrl)

        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of Entradas_OrdenCompraBrl)

        RaiseEvent LoadingEntradas_OrdenCompraList("CargarPorId_OrdenCompra_Detalle")

        dsDatos = Entradas_OrdenCompraDAL.CargarPorId_OrdenCompra_Detalle(Id_OrdenCompra_Detalle)

        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next

        RaiseEvent LoadedEntradas_OrdenCompraList(lista, "CargarPorId_OrdenCompra_Detalle")

        Return lista

    End Function

End Class


