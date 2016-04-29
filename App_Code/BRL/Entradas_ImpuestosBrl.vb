Imports ingNovar.Utilidades2
Imports System.Data
Imports System.Collections.Generic

Partial Public Class Entradas_ImpuestosBrl

    Private _Id As Int32
    Private _Id_Entrada As Int32
    Private _Porcentaje As Double
    Private _Valor As Double
    Private _Concepto As String

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

    Public Event Id_EntradaChanging(ByVal Value As Int32)
    Public Event Id_EntradaChanged()

    Public Property Id_Entrada() As Int32
        Get
            Return Me._Id_Entrada
        End Get
        Set(ByVal Value As Int32)
            If _Id_Entrada <> Value Then
                RaiseEvent Id_EntradaChanging(Value)
                Me._Id_Entrada = Value
                RaiseEvent Id_EntradaChanged()
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

    Public Event ConceptoChanging(ByVal Value As String)
    Public Event ConceptoChanged()

    Public Property Concepto() As String
        Get
            Return Me._Concepto
        End Get
        Set(ByVal Value As String)
            If _Concepto <> Value Then
                RaiseEvent ConceptoChanging(Value)
                Me._Concepto = Value
                RaiseEvent ConceptoChanged()
            End If
        End Set
    End Property

    Public ReadOnly Property Entrada() As EntradasBrl
        Get
            Return EntradasBrl.CargarPorID(Id_Entrada)
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
            Me.ID = Entradas_ImpuestosDAL.Insertar(Id_Entrada, Porcentaje, Valor, Concepto)
            RaiseEvent Inserted()
        Else
            RaiseEvent Updating()
            Entradas_ImpuestosDAL.Actualizar(ID, Id_Entrada, Porcentaje, Valor, Concepto)
            RaiseEvent Updated()
        End If

        RaiseEvent Saved()

    End Sub

    Public Sub Eliminar()
        Dim totalHijos As Long = 0
        If Me.ID <> Nothing Then

            RaiseEvent Deleting()
            If totalHijos > 0 Then Throw New Exception("No se puede eliminar el registro porque existen datos que dependen de él.")
            Entradas_ImpuestosDAL.Eliminar(Me.ID)

            RaiseEvent Deleted()

        End If
    End Sub

    Private Shared Function asignarValoresALasPropiedades(ByVal fila As DataRow) As Entradas_ImpuestosBrl

        Dim objEntradas_Impuestos As New Entradas_ImpuestosBrl

        With objEntradas_Impuestos
            .ID = fila("Id")
            .Id_Entrada = isDBNullToNothing(fila("Id_Entrada"))
            .Porcentaje = isDBNullToNothing(fila("Porcentaje"))
            .Valor = isDBNullToNothing(fila("Valor"))
            .Concepto = isDBNullToNothing(fila("Concepto"))
        End With

        Return objEntradas_Impuestos

    End Function

    Public Shared Event LoadingEntradas_ImpuestosList(ByVal LoadType As String)
    Public Shared Event LoadedEntradas_ImpuestosList(ByVal target As List(Of Entradas_ImpuestosBrl), ByVal LoadType As String)

    Public Shared Function CargarTodos() As List(Of Entradas_ImpuestosBrl)

        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of Entradas_ImpuestosBrl)

        RaiseEvent LoadingEntradas_ImpuestosList("CargarTodos")

        dsDatos = Entradas_ImpuestosDAL.CargarTodos()

        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next

        RaiseEvent LoadedEntradas_ImpuestosList(lista, "CargarTodos")

        Return lista

    End Function

    Public Shared Event LoadingPorId(ByVal id As Int32)
    Public Shared Event LoadedPorId(ByVal target As Entradas_ImpuestosBrl)

    Public Shared Function CargarPorID(ByVal ID As Int32) As Entradas_ImpuestosBrl

        Dim dsDatos As System.Data.DataSet
        Dim objEntradas_Impuestos As Entradas_ImpuestosBrl = Nothing
        dsDatos = Entradas_ImpuestosDAL.CargarPorID(ID)
        If dsDatos.Tables(0).Rows.Count <> 0 Then objEntradas_Impuestos = asignarValoresALasPropiedades(dsDatos.Tables(0).Rows(0))
        Return objEntradas_Impuestos

    End Function

    Public Shared Function CargarPorId_Entrada(ByVal Id_Entrada As Int32) As List(Of Entradas_ImpuestosBrl)

        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of Entradas_ImpuestosBrl)
        RaiseEvent LoadingEntradas_ImpuestosList("CargarPorId_Entrada")
        dsDatos = Entradas_ImpuestosDAL.CargarPorId_Entrada(Id_Entrada)
        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next
        RaiseEvent LoadedEntradas_ImpuestosList(lista, "CargarPorId_Entrada")
        Return lista

    End Function

End Class


