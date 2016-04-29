Imports ingNovar.Utilidades2
imports system.data
Imports system.collections.generic

Partial Public Class Ppto_CuentasBrl

    Private _Id As Int32
    Private _Id_Nivel As Int32
    Private _Descripcion As String
    Private _Visible As Boolean
    Private _Codigo_Regional As String

    Private objListPpto_Cuentas_Detalle As List(Of Ppto_Cuentas_DetalleBrl)

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

    Public Event VisibleChanging(ByVal Value As Boolean)
    Public Event VisibleChanged()

    Public Property Visible() As Boolean
        Get
            Return Me._Visible
        End Get
        Set(ByVal Value As Boolean)
            If _Visible <> Value Then
                RaiseEvent VisibleChanging(Value)
                Me._Visible = Value
                RaiseEvent VisibleChanged()
            End If
        End Set
    End Property

    Public Event Codigo_RegionalChanging(ByVal Value As String)
    Public Event Codigo_RegionalChanged()

    Public Property Codigo_Regional() As String
        Get
            Return Me._Codigo_Regional
        End Get
        Set(ByVal Value As String)
            If _Codigo_Regional <> Value Then
                RaiseEvent Codigo_RegionalChanging(Value)
                Me._Codigo_Regional = Value
                RaiseEvent Codigo_RegionalChanged()
            End If
        End Set
    End Property

    Public ReadOnly Property Nivel() As SubTablasBrl
        Get
            Return SubTablasBrl.CargarPorID(Id_Nivel)
        End Get
    End Property

    Public Property Ppto_Cuentas_Detalle() As List(Of Ppto_Cuentas_DetalleBrl)
        Get
            If (Me.objListPpto_Cuentas_Detalle Is Nothing) Then
                objListPpto_Cuentas_Detalle = Ppto_Cuentas_DetalleBrl.CargarPorId_Ppto_Cuentas(Me.ID)
            End If
            Return Me.objListPpto_Cuentas_Detalle
        End Get
        Set(ByVal Value As List(Of Ppto_Cuentas_DetalleBrl))
            Me.objListPpto_Cuentas_Detalle = Value
        End Set
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
            Me.ID = Ppto_CuentasDAL.Insertar(Id_Nivel, Codigo_Regional, Descripcion, Visible)
            RaiseEvent Inserted()
        Else
            RaiseEvent Updating()
            Ppto_CuentasDAL.Actualizar(ID, Id_Nivel, Codigo_Regional, Descripcion, Visible)
            RaiseEvent Updated()
        End If

        RaiseEvent Saved()

    End Sub

    Public Sub Eliminar()
        Dim totalHijos As Long = 0
        If Me.ID <> Nothing Then

            RaiseEvent Deleting()
            If totalHijos > 0 Then Throw New Exception("No se puede eliminar el registro porque existen datos que dependen de él.")
            Ppto_CuentasDAL.Eliminar(Me.ID)

            RaiseEvent Deleted()

        End If
    End Sub

    Private Shared Function asignarValoresALasPropiedades(ByVal fila As DataRow) As Ppto_CuentasBrl

        Dim objPpto_Cuentas As New Ppto_CuentasBrl

        With objPpto_Cuentas
            .ID = fila("Id")
            .Id_Nivel = isDBNullToNothing(fila("Id_Nivel"))
            .Codigo_Regional = isDBNullToNothing(fila("Codigo_Regional"))
            .Descripcion = isDBNullToNothing(fila("Descripcion"))
            .Visible = isDBNullToNothing(fila("Visible"))
        End With

        Return objPpto_Cuentas

    End Function

    Public Shared Event LoadingPpto_CuentasList(ByVal LoadType As String)
    Public Shared Event LoadedPpto_CuentasList(ByVal target As List(Of Ppto_CuentasBrl), ByVal LoadType As String)

    Public Shared Function CargarTodos(ByVal Id_Proyecto As Int32) As List(Of Ppto_CuentasBrl)

        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of Ppto_CuentasBrl)

        RaiseEvent LoadingPpto_CuentasList("CargarTodos")

        dsDatos = Ppto_CuentasDAL.CargarTodos(Id_Proyecto)

        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next

        RaiseEvent LoadedPpto_CuentasList(lista, "CargarTodos")

        Return lista

    End Function

    Public Shared Event CargandoPorId(ByVal id As Int32)
    Public Shared Event CargadoPorId(ByVal target As Ppto_CuentasBrl)

    Public Shared Function CargarPorID(ByVal ID As Int32) As Ppto_CuentasBrl

        Dim dsDatos As System.Data.DataSet
        Dim objPpto_Cuentas As Ppto_CuentasBrl = Nothing
        dsDatos = Ppto_CuentasDAL.CargarPorID(ID)
        If dsDatos.Tables(0).Rows.Count <> 0 Then objPpto_Cuentas = asignarValoresALasPropiedades(dsDatos.Tables(0).Rows(0))
        Return objPpto_Cuentas

    End Function

    Public Shared Function CargarPorId_Nivel(ByVal Id_Nivel As Int32) As List(Of Ppto_CuentasBrl)

        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of Ppto_CuentasBrl)

        RaiseEvent LoadingPpto_CuentasList("CargarPorId_Contrato")

        dsDatos = Ppto_CuentasDAL.CargarPorId_Nivel(Id_Nivel)

        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next

        RaiseEvent LoadedPpto_CuentasList(lista, "CargarPorId_Contrato")

        Return lista

    End Function

End Class


