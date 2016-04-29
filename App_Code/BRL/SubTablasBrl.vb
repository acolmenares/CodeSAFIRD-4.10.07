Imports ingNovar.Utilidades2
Imports System.data
Imports System.Collections.Generic

Partial Public Class SubTablasBrl

    Private _Id As Int32
    Private _Id_Tabla As Int32
    Private _Descripcion As String
    Private _Id_Padre As Int32
    Private _Fecha_Creacion As DateTime
    Private _Id_Usuario_Creacion As Int32
    Private _Fecha_Modificacion As DateTime
    Private _Id_Usuario_Modificacion As Int32
    Private _orden As Integer
    Private _Activo As Int32

    Private objListPpto_Contratos As List(Of Ppto_ContratosBrl)
    Private objListPpto_DistribucionNivel As List(Of Ppto_DistribucionBrl)
    Private objListPpto_DistribucionTipoUnidad As List(Of Ppto_DistribucionBrl)
    Private objListPpto_Traslados As List(Of Ppto_TrasladosBrl)
    Private objListPpto_Traslados_Detalle As List(Of Ppto_Traslados_DetalleBrl)

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

    Public Event Id_TablaChanging(ByVal Value As Int32)
    Public Event Id_TablaChanged()
	
    Public Property Id_Tabla() As Int32
        Get
            Return Me._Id_Tabla
        End Get
        Set(ByVal Value As Int32)
            If _Id_Tabla <> Value Then
                RaiseEvent Id_TablaChanging(Value)
				Me._Id_Tabla = Value
                RaiseEvent Id_TablaChanged()
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

    Public Event Id_PadreChanging(ByVal Value As Int32)
    Public Event Id_PadreChanged()

    Public Property Id_Padre() As Int32
        Get
            Return Me._Id_Padre
        End Get
        Set(ByVal Value As Int32)
            If _Id_Padre <> Value Then
                RaiseEvent Id_PadreChanging(Value)
                Me._Id_Padre = Value
                RaiseEvent Id_PadreChanged()
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

    Public Event OrdenChanging(ByVal Value As Int32)
    Public Event OrdenChanged()

    Public Property Orden() As Int32
        Get
            Return Me._orden
        End Get
        Set(ByVal Value As Int32)
            If _orden <> Value Then
                RaiseEvent OrdenChanging(Value)
                Me._orden = Value
                RaiseEvent OrdenChanged()
            End If
        End Set
    End Property

    Public Event ActivoChanging(ByVal Value As Int32)
    Public Event ActivoChanged()

    Public Property Activo() As Int32
        Get
            Return Me._Activo
        End Get
        Set(ByVal Value As Int32)
            If _Activo <> Value Then
                RaiseEvent ActivoChanging(Value)
                Me._Activo = Value
                RaiseEvent ActivoChanged()
            End If
        End Set
    End Property

    Public Property Ppto_Contratos() As List(Of Ppto_ContratosBrl)
        Get
            If (Me.objListPpto_Contratos Is Nothing) Then
                objListPpto_Contratos = Ppto_ContratosBrl.CargarPorId_Nivel(Me.ID)
            End If
            Return Me.objListPpto_Contratos
        End Get
        Set(ByVal Value As List(Of Ppto_ContratosBrl))
            Me.objListPpto_Contratos = Value
        End Set
    End Property

    Public Property Ppto_DistribucionNivel() As List(Of Ppto_DistribucionBrl)
        Get
            If (Me.objListPpto_DistribucionNivel Is Nothing) Then
                objListPpto_DistribucionNivel = Ppto_DistribucionBrl.CargarPorId_Nivel(Me.ID)
            End If
            Return Me.objListPpto_DistribucionNivel
        End Get
        Set(ByVal Value As List(Of Ppto_DistribucionBrl))
            Me.objListPpto_DistribucionNivel = Value
        End Set
    End Property

    Public Property Ppto_DistribucionTipoUnidad() As List(Of Ppto_DistribucionBrl)
        Get
            If (Me.objListPpto_DistribucionTipoUnidad Is Nothing) Then
                objListPpto_DistribucionTipoUnidad = Ppto_DistribucionBrl.CargarPorId_Tipo_Unidad(Me.ID)
            End If
            Return Me.objListPpto_DistribucionTipoUnidad
        End Get
        Set(ByVal Value As List(Of Ppto_DistribucionBrl))
            Me.objListPpto_DistribucionTipoUnidad = Value
        End Set
    End Property

    Public Property Ppto_Traslados() As List(Of Ppto_TrasladosBrl)
        Get
            If (Me.objListPpto_Traslados Is Nothing) Then
                objListPpto_Traslados = Ppto_TrasladosBrl.CargarPorId_Nivel_Sale(Me.ID)
            End If
            Return Me.objListPpto_Traslados
        End Get
        Set(ByVal Value As List(Of Ppto_TrasladosBrl))
            Me.objListPpto_Traslados = Value
        End Set
    End Property

    Public Property Ppto_Traslados_Detalle() As List(Of Ppto_Traslados_DetalleBrl)
        Get
            If (Me.objListPpto_Traslados_Detalle Is Nothing) Then
                objListPpto_Traslados_Detalle = Ppto_Traslados_DetalleBrl.CargarPorId_Nivel_Entra(Me.ID)
            End If
            Return Me.objListPpto_Traslados_Detalle
        End Get
        Set(ByVal Value As List(Of Ppto_Traslados_DetalleBrl))
            Me.objListPpto_Traslados_Detalle = Value
        End Set
    End Property

    Public ReadOnly Property SubTablasPadre() As SubTablasBrl
        Get
            Return SubTablasBrl.CargarPorID(Id_Padre)
        End Get
    End Property


    '
    '
    Public ReadOnly Property CantidadDistribucion() As Double
        Get
            Dim wvalor As Double = 0
            For Each fila As Ppto_DistribucionBrl In Ppto_DistribucionNivel
                wvalor += fila.Valor_USD
            Next
            Return wvalor
        End Get
    End Property

    Public ReadOnly Property Descripcion_PadreHijo() As String
        Get
            Dim wcadena As String = Descripcion
            Dim wpadre As Integer = Id_Padre
            Dim wdescrip As String = ""
            Dim objnivel As SubTablasBrl
            While wpadre <> 0
                objnivel = SubTablasBrl.CargarPorID(wpadre)
                wdescrip = objnivel.Descripcion + " - " + wdescrip
                wpadre = objnivel.Id_Padre
            End While
            If wdescrip <> "" Then
                wcadena = wdescrip + wcadena
            End If
            Return wcadena
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
            Me.ID = SubTablasDAL.Insertar(Id_Tabla, Descripcion, Id_Padre, Fecha_Creacion, Id_Usuario_Creacion, Fecha_Modificacion, Id_Usuario_Modificacion, Orden, Activo)
            RaiseEvent Inserted()
        Else
            RaiseEvent Updating()
            SubTablasDAL.Actualizar(ID, Id_Tabla, Descripcion, Id_Padre, Fecha_Creacion, Id_Usuario_Creacion, Fecha_Modificacion, Id_Usuario_Modificacion, Orden, Activo)
            RaiseEvent Updated()
        End If
        If Not objListPpto_Contratos Is Nothing Then
            For Each fila As Ppto_ContratosBrl In objListPpto_Contratos
                fila.Id_Nivel = Me.ID
                Try
                    fila.Guardar()
                Catch ex As Exception
                End Try
            Next
        End If

        If Not objListPpto_DistribucionNivel Is Nothing Then
            For Each fila As Ppto_DistribucionBrl In objListPpto_DistribucionNivel
                fila.Id_Nivel = Me.ID
                Try
                    fila.Guardar()
                Catch ex As Exception
                End Try
            Next
        End If

        If Not objListPpto_DistribucionTipoUnidad Is Nothing Then
            For Each fila As Ppto_DistribucionBrl In objListPpto_DistribucionTipoUnidad
                fila.Id_Tipo_Unidad = Me.ID
                Try
                    fila.Guardar()
                Catch ex As Exception
                End Try
            Next
        End If

        If Not objListPpto_Traslados Is Nothing Then
            For Each fila As Ppto_TrasladosBrl In objListPpto_Traslados
                fila.Id_Nivel_Sale = Me.ID
                Try
                    fila.Guardar()
                Catch ex As Exception
                End Try
            Next
        End If

        If Not objListPpto_Traslados_Detalle Is Nothing Then
            For Each fila As Ppto_Traslados_DetalleBrl In objListPpto_Traslados_Detalle
                fila.Id_Nivel_Entra = Me.ID
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
            totalHijos += Ppto_Contratos.Count
            totalHijos += Ppto_DistribucionNivel.Count
            totalHijos += Ppto_DistribucionTipoUnidad.Count
            totalHijos += Ppto_Traslados.Count
            totalHijos += Ppto_Traslados_Detalle.Count
            If totalHijos > 0 Then Throw New Exception("No se puede eliminar el registro porque existen datos que dependen de él.")

            SubTablasDAL.Eliminar(Me.ID)

            RaiseEvent Deleted()

        End If
    End Sub


    Private Shared Function asignarValoresALasPropiedades(ByVal fila As DataRow) As SubTablasBrl
        Dim objSubTablas As New SubTablasBrl
        With objSubTablas
            .ID = fila("Id")
            .Id_Tabla = isDBNullToNothing(fila("Id_Tabla"))
            .Descripcion = isDBNullToNothing(fila("Descripcion"))
            .Id_Padre = isDBNullToNothing(fila("Id_Padre"))
            .Fecha_Creacion = isDBNullToNothing(fila("Fecha_Creacion"))
            .Id_Usuario_Creacion = isDBNullToNothing(fila("Id_Usuario_Creacion"))
            .Fecha_Modificacion = isDBNullToNothing(fila("Fecha_Modificacion"))
            .Id_Usuario_Modificacion = isDBNullToNothing(fila("Id_Usuario_Modificacion"))
            .Orden = isDBNullToNothing(fila("Orden"))
            .Activo = isDBNullToNothing(fila("Activo"))
        End With
        Return objSubTablas
    End Function

    Public Shared Event LoadingSubTablasList(ByVal LoadType As String)
    Public Shared Event LoadedSubTablasList(ByVal target As List(Of SubTablasBrl), ByVal LoadType As String)

    Public Shared Function CargarTodos() As List(Of SubTablasBrl)

        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of SubTablasBrl)

        RaiseEvent LoadingSubTablasList("CargarTodos")

        dsDatos = SubTablasDAL.CargarTodos()

        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next

        RaiseEvent LoadedSubTablasList(lista, "CargarTodos")

        Return lista

    End Function

    Public Shared Function CargarBusqueda(ByVal idtabla As Integer, ByVal descripcion As String, ByVal idpadre As Integer) As List(Of SubTablasBrl)
        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of SubTablasBrl)
        dsDatos = SubTablasDAL.CargarPorBusqueda(idtabla, descripcion, idpadre)
        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next
        Return lista
    End Function

    Public Shared Event LoadingPorId(ByVal id As Int32)
    Public Shared Event LoadedPorId(ByVal target As SubTablasBrl)

    Public Shared Function CargarPorID(ByVal ID As Int32) As SubTablasBrl

        Dim dsDatos As System.Data.DataSet
        Dim objSubTablas As SubTablasBrl = Nothing

        dsDatos = SubTablasDAL.CargarPorID(ID)

        If dsDatos.Tables(0).Rows.Count <> 0 Then objSubTablas = asignarValoresALasPropiedades(dsDatos.Tables(0).Rows(0))

        Return objSubTablas

    End Function

    Public Shared Function CargarPorId_Tabla(ByVal Id_Tabla As Int32) As List(Of SubTablasBrl)

        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of SubTablasBrl)
        dsDatos = SubTablasDAL.CargarPorId_Tabla(Id_Tabla)
        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next
        Return lista

    End Function

    Public Shared Function CargarPorId_Padre(ByVal Id_Padre As Int32) As List(Of SubTablasBrl)

        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of SubTablasBrl)
        dsDatos = SubTablasDAL.CargarPorId_Padre(Id_Padre)
        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next
        Return lista

    End Function

    Public Shared Function CargarPorId_TablaPadre(ByVal Id_Tabla As Int32, ByVal Id_Padre As Int32) As List(Of SubTablasBrl)

        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of SubTablasBrl)
        dsDatos = SubTablasDAL.CargarPorId_TablaPadre(Id_Tabla, Id_Padre)
        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next
        Return lista

    End Function

    Public Shared Function CargarPorId_Usuario_Creacion(ByVal Id_Usuario_Creacion As Int32) As List(Of SubTablasBrl)

        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of SubTablasBrl)
        dsDatos = SubTablasDAL.CargarPorId_Usuario_Creacion(Id_Usuario_Creacion)

        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next
        Return lista

    End Function

    Public Shared Function CargarPorId_Usuario_Modificacion(ByVal Id_Usuario_Modificacion As Int32) As List(Of SubTablasBrl)

        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of SubTablasBrl)
        dsDatos = SubTablasDAL.CargarPorId_Usuario_Modificacion(Id_Usuario_Modificacion)

        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next
        Return lista

    End Function

    Public Shared Function CargarPorId_Activo(ByVal Activo As Int32) As List(Of SubTablasBrl)

        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of SubTablasBrl)
        dsDatos = SubTablasDAL.CargarPorActivo(Activo)

        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next
        Return lista

    End Function

    Public Shared Function CargarPorNivelesPorProyecto(ByVal Id_Proyecto As Int32) As List(Of SubTablasBrl)

        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of SubTablasBrl)
        dsDatos = SubTablasDAL.CargarNivelesPorProyecto(Id_Proyecto)
        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next
        Return lista

    End Function


End Class


