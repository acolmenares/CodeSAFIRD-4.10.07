Imports ingNovar.Utilidades2
Imports System.Data
Imports System.Collections.Generic

Partial Public Class OrdenCompra_RetencionBrl

    Private _Id As Int32
    Private _Id_OrdenCompra As Int32
    Private _Porcentaje As Double
    Private _Valor As Double
    Private _Id_Concepto As Int32
    Private _Base_Retencion As Double
    Private _Fecha_Cierre As DateTime
    Private _Cierre As Boolean

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

    Public Event PorcentajeChanging(ByVal Value As Double)
    Public Event PorcentajeChanged()

    Public Property Porcentaje() As Double
        Get
            Return Me._Porcentaje
        End Get
        Set(ByVal Value As Double)
            If _Porcentaje <> Value Then
                RaiseEvent PorcentajeChanging(Value)
                Me._Porcentaje = Value
                RaiseEvent PorcentajeChanged()
            End If
        End Set
    End Property

    Public Event ValorChanging(ByVal Value As Double)
    Public Event ValorChanged()

    Public Property Valor() As Double
        Get
            Return Me._Valor
        End Get
        Set(ByVal Value As Double)
            If _Valor <> Value Then
                RaiseEvent ValorChanging(Value)
                Me._Valor = Value
                RaiseEvent ValorChanged()
            End If
        End Set
    End Property

    Public Event Id_ConceptoChanging(ByVal Value As Int32)
    Public Event Id_ConceptoChanged()

    Public Property Id_Concepto() As Int32
        Get
            Return Me._Id_Concepto
        End Get
        Set(ByVal Value As Int32)
            If _Id_Concepto <> Value Then
                RaiseEvent Id_ConceptoChanging(Value)
                Me._Id_Concepto = Value
                RaiseEvent Id_ConceptoChanged()
            End If
        End Set
    End Property

    Public Event Base_RetencionChanging(ByVal Value As Double)
    Public Event Base_RetencionChanged()

    Public Property Base_Retencion() As Double
        Get
            Return Me._Base_Retencion
        End Get
        Set(ByVal Value As Double)
            If _Base_Retencion <> Value Then
                RaiseEvent Base_RetencionChanging(Value)
                Me._Base_Retencion = Value
                RaiseEvent Base_RetencionChanged()
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

    Public ReadOnly Property OrdenCompra() As OrdenCompraBrl
        Get
            Return OrdenCompraBrl.CargarPorID(Id_OrdenCompra)
        End Get
    End Property

    Public ReadOnly Property Concepto() As SubTablasBrl
        Get
            Return SubTablasBrl.CargarPorID(Id_Concepto)
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
            Me.ID = OrdenCompra_RetencionDAL.Insertar(Id_OrdenCompra, Porcentaje, Valor, Id_Concepto, Base_Retencion, Fecha_Cierre, Cierre)
            RaiseEvent Inserted()
        Else
            RaiseEvent Updating()
            OrdenCompra_RetencionDAL.Actualizar(ID, Id_OrdenCompra, Porcentaje, Valor, Id_Concepto, Base_Retencion, Fecha_Cierre, Cierre)
            RaiseEvent Updated()
        End If

        RaiseEvent Saved()

    End Sub

    Public Sub Eliminar()
        Dim totalHijos As Long = 0
        If Me.ID <> Nothing Then

            RaiseEvent Deleting()
            If totalHijos > 0 Then Throw New Exception("No se puede eliminar el registro porque existen datos que dependen de él.")
            OrdenCompra_RetencionDAL.Eliminar(Me.ID)

            RaiseEvent Deleted()

        End If
    End Sub

    Private Shared Function asignarValoresALasPropiedades(ByVal fila As DataRow) As OrdenCompra_RetencionBrl

        Dim objOrdenCompra_Retencion As New OrdenCompra_RetencionBrl

        With objOrdenCompra_Retencion
            .ID = fila("Id")
            .Id_OrdenCompra = isDBNullToNothing(fila("Id_OrdenCompra"))
            .Porcentaje = isDBNullToNothing(fila("Porcentaje"))
            .Valor = isDBNullToNothing(fila("Valor"))
            .Id_Concepto = isDBNullToNothing(fila("Id_Concepto"))
            .Base_Retencion = isDBNullToNothing(fila("Base_Retencion"))
            .Fecha_Cierre = isDBNullToNothing(fila("Fecha_Cierre"))
            .Cierre = isDBNullToNothing(fila("Cierre"))
        End With

        Return objOrdenCompra_Retencion

    End Function

    Public Shared Event LoadingOrdenCompra_RetencionList(ByVal LoadType As String)
    Public Shared Event LoadedOrdenCompra_RetencionList(ByVal target As List(Of OrdenCompra_RetencionBrl), ByVal LoadType As String)

    Public Shared Function CargarTodos() As List(Of OrdenCompra_RetencionBrl)

        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of OrdenCompra_RetencionBrl)

        RaiseEvent LoadingOrdenCompra_RetencionList("CargarTodos")

        dsDatos = OrdenCompra_RetencionDAL.CargarTodos()

        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next

        RaiseEvent LoadedOrdenCompra_RetencionList(lista, "CargarTodos")

        Return lista

    End Function

    Public Shared Event LoadingPorId(ByVal id As Int32)
    Public Shared Event LoadedPorId(ByVal target As OrdenCompra_RetencionBrl)

    Public Shared Function CargarPorID(ByVal ID As Int32) As OrdenCompra_RetencionBrl

        Dim dsDatos As System.Data.DataSet
        Dim objOrdenCompra_Retencion As OrdenCompra_RetencionBrl = Nothing
        dsDatos = OrdenCompra_RetencionDAL.CargarPorID(ID)
        If dsDatos.Tables(0).Rows.Count <> 0 Then objOrdenCompra_Retencion = asignarValoresALasPropiedades(dsDatos.Tables(0).Rows(0))
        Return objOrdenCompra_Retencion

    End Function

    Public Shared Function CargarPorId_OrdenCompra(ByVal Id_OrdenCompra As Int32) As List(Of OrdenCompra_RetencionBrl)

        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of OrdenCompra_RetencionBrl)
        RaiseEvent LoadingOrdenCompra_RetencionList("CargarPorId_OrdenCompra")
        dsDatos = OrdenCompra_RetencionDAL.CargarPorId_OrdenCompra(Id_OrdenCompra)
        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next
        RaiseEvent LoadedOrdenCompra_RetencionList(lista, "CargarPorId_OrdenCompra")
        Return lista

    End Function

    Public Shared Function CargarPorId_Concepto(ByVal Id_Concepto As Int32) As List(Of OrdenCompra_RetencionBrl)

        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of OrdenCompra_RetencionBrl)
        RaiseEvent LoadingOrdenCompra_RetencionList("CargarPorId_Concepto")
        dsDatos = OrdenCompra_RetencionDAL.CargarPorId_Concepto(Id_Concepto)
        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next
        RaiseEvent LoadedOrdenCompra_RetencionList(lista, "CargarPorId_Concepto")
        Return lista

    End Function

End Class


