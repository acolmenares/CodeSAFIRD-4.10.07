Imports ingNovar.Utilidades2
Imports System.Data
Imports System.Collections.Generic

Partial Public Class OrdenCompra_DocumentosBrl

    Private _Id As Int32
    Private _Id_OrdenCompra As Int32
    Private _Nombre_Archivo As String
    Private _Descripcion As String

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

    Public Event Nombre_ArchivoChanging(ByVal Value As String)
    Public Event Nombre_ArchivoChanged()

    Public Property Nombre_Archivo() As String
        Get
            Return Me._Nombre_Archivo
        End Get
        Set(ByVal Value As String)
            If _Nombre_Archivo <> Value Then
                RaiseEvent Nombre_ArchivoChanging(Value)
                Me._Nombre_Archivo = Value
                RaiseEvent Nombre_ArchivoChanged()
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

    Public ReadOnly Property OrdenCompra() As OrdenCompraBrl
        Get
            Return OrdenCompraBrl.CargarPorID(Id_OrdenCompra)
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
            Me.ID = OrdenCompra_DocumentosDAL.Insertar(Id_OrdenCompra, Nombre_Archivo, Descripcion)
            RaiseEvent Inserted()
        Else
            RaiseEvent Updating()
            OrdenCompra_DocumentosDAL.Actualizar(ID, Id_OrdenCompra, Nombre_Archivo, Descripcion)
            RaiseEvent Updated()
        End If

        RaiseEvent Saved()

    End Sub

    Public Sub Eliminar()
        Dim totalHijos As Long = 0
        If Me.ID <> Nothing Then

            RaiseEvent Deleting()
            If totalHijos > 0 Then Throw New Exception("No se puede eliminar el registro porque existen datos que dependen de él.")
            OrdenCompra_DocumentosDAL.Eliminar(Me.ID)

            RaiseEvent Deleted()

        End If
    End Sub

    Private Shared Function asignarValoresALasPropiedades(ByVal fila As DataRow) As OrdenCompra_DocumentosBrl

        Dim objOrdenCompra_Documentos As New OrdenCompra_DocumentosBrl

        With objOrdenCompra_Documentos
            .ID = fila("Id")
            .Id_OrdenCompra = isDBNullToNothing(fila("Id_OrdenCompra"))
            .Nombre_Archivo = isDBNullToNothing(fila("Nombre_Archivo"))
            .Descripcion = isDBNullToNothing(fila("Descripcion"))
        End With

        Return objOrdenCompra_Documentos

    End Function

    Public Shared Event LoadingOrdenCompra_DocumentosList(ByVal LoadType As String)
    Public Shared Event LoadedOrdenCompra_DocumentosList(ByVal target As List(Of OrdenCompra_DocumentosBrl), ByVal LoadType As String)

    Public Shared Function CargarTodos() As List(Of OrdenCompra_DocumentosBrl)

        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of OrdenCompra_DocumentosBrl)

        RaiseEvent LoadingOrdenCompra_DocumentosList("CargarTodos")

        dsDatos = OrdenCompra_DocumentosDAL.CargarTodos()

        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next

        RaiseEvent LoadedOrdenCompra_DocumentosList(lista, "CargarTodos")

        Return lista

    End Function

    Public Shared Event LoadingPorId(ByVal id As Int32)
    Public Shared Event LoadedPorId(ByVal target As OrdenCompra_RetencionBrl)

    Public Shared Function CargarPorID(ByVal ID As Int32) As OrdenCompra_DocumentosBrl

        Dim dsDatos As System.Data.DataSet
        Dim objOrdenCompra_Documentos As OrdenCompra_DocumentosBrl = Nothing
        dsDatos = OrdenCompra_DocumentosDAL.CargarPorID(ID)
        If dsDatos.Tables(0).Rows.Count <> 0 Then objOrdenCompra_Documentos = asignarValoresALasPropiedades(dsDatos.Tables(0).Rows(0))
        Return objOrdenCompra_Documentos

    End Function

    Public Shared Function CargarPorId_OrdenCompra(ByVal Id_OrdenCompra As Int32) As List(Of OrdenCompra_DocumentosBrl)

        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of OrdenCompra_DocumentosBrl)
        RaiseEvent LoadingOrdenCompra_DocumentosList("CargarPorId_OrdenCompra")
        dsDatos = OrdenCompra_DocumentosDAL.CargarPorId_OrdenCompra(Id_OrdenCompra)
        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next
        RaiseEvent LoadedOrdenCompra_DocumentosList(lista, "CargarPorId_OrdenCompra")
        Return lista

    End Function
End Class


