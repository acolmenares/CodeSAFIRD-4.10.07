Imports ingNovar.Utilidades2
imports system.data
Imports system.collections.generic

Partial Public Class Ppto_Cuentas_DetalleBrl

    Private _Id As Int32
    Private _Id_Ppto_Cuentas As Int32
    Private _Cuenta As String

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

    Public Event Id_Ppto_CuentasChanging(ByVal Value As Int32)
    Public Event Id_Ppto_CuentasChanged()

    Public Property Id_Ppto_Cuentas() As Int32
        Get
            Return Me._Id_Ppto_Cuentas
        End Get
        Set(ByVal Value As Int32)
            If _Id_Ppto_Cuentas <> Value Then
                RaiseEvent Id_Ppto_CuentasChanging(Value)
                Me._Id_Ppto_Cuentas = Value
                RaiseEvent Id_Ppto_CuentasChanged()
            End If
        End Set
    End Property

    Public Event CuentaChanging(ByVal Value As String)
    Public Event CuentaChanged()

    Public Property Cuenta() As String
        Get
            Return Me._Cuenta
        End Get
        Set(ByVal Value As String)
            If _Cuenta <> Value Then
                RaiseEvent CuentaChanging(Value)
                Me._Cuenta = Value
                RaiseEvent CuentaChanged()
            End If
        End Set
    End Property

    Public ReadOnly Property Ppto_Cuentas() As Ppto_CuentasBrl
        Get
            Return Ppto_CuentasBrl.CargarPorID(Id_Ppto_Cuentas)
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
            Me.ID = Ppto_Cuentas_DetalleDAL.Insertar(Id_Ppto_Cuentas, Cuenta)
            RaiseEvent Inserted()
        Else
            RaiseEvent Updating()
            Ppto_Cuentas_DetalleDAL.Actualizar(ID, Id_Ppto_Cuentas, Cuenta)
            RaiseEvent Updated()
        End If

        RaiseEvent Saved()

    End Sub

    Public Sub Eliminar()
        Dim totalHijos As Long = 0
        If Me.ID <> Nothing Then

            RaiseEvent Deleting()
            If totalHijos > 0 Then Throw New Exception("No se puede eliminar el registro porque existen datos que dependen de él.")
            Ppto_Cuentas_DetalleDAL.Eliminar(Me.ID)

            RaiseEvent Deleted()

        End If
    End Sub

    Private Shared Function asignarValoresALasPropiedades(ByVal fila As DataRow) As Ppto_Cuentas_DetalleBrl

        Dim objPpto_Cuentas_Detalle As New Ppto_Cuentas_DetalleBrl

        With objPpto_Cuentas_Detalle
            .ID = fila("Id")
            .Id_Ppto_Cuentas = isDBNullToNothing(fila("Id_Ppto_Cuentas"))
            .Cuenta = isDBNullToNothing(fila("Cuenta"))
        End With

        Return objPpto_Cuentas_Detalle

    End Function

    Public Shared Event LoadingPpto_Cuentas_DetalleList(ByVal LoadType As String)
    Public Shared Event LoadedPpto_Cuentas_DetalleList(ByVal target As List(Of Ppto_Cuentas_DetalleBrl), ByVal LoadType As String)

    Public Shared Function CargarTodos() As List(Of Ppto_Cuentas_DetalleBrl)

        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of Ppto_Cuentas_DetalleBrl)

        dsDatos = Ppto_Cuentas_DetalleDAL.CargarTodos()

        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next

        Return lista

    End Function

    Public Shared Event CargandoPorId(ByVal id As Int32)
    Public Shared Event CargadoPorId(ByVal target As Ppto_Cuentas_DetalleBrl)

    Public Shared Function CargarPorID(ByVal ID As Int32) As Ppto_Cuentas_DetalleBrl

        Dim dsDatos As System.Data.DataSet
        Dim objPpto_Cuentas_Detalle As Ppto_Cuentas_DetalleBrl = Nothing
        dsDatos = Ppto_Cuentas_DetalleDAL.CargarPorID(ID)
        If dsDatos.Tables(0).Rows.Count <> 0 Then objPpto_Cuentas_Detalle = asignarValoresALasPropiedades(dsDatos.Tables(0).Rows(0))
        Return objPpto_Cuentas_Detalle

    End Function

    Public Shared Function CargarPorId_Ppto_Cuentas(ByVal Id_Ppto_Cuentas As Int32) As List(Of Ppto_Cuentas_DetalleBrl)

        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of Ppto_Cuentas_DetalleBrl)

        dsDatos = Ppto_Cuentas_DetalleDAL.CargarPorId_Ppto_Cuentas(Id_Ppto_Cuentas)

        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next


        Return lista
    End Function

End Class


