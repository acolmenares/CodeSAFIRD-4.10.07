Imports ingNovar.Utilidades2
imports system.data
Imports system.collections.generic


Partial Public Class Ppto_ContratosBrl

    Private _Id As Int32
    Private _Fecha As DateTime
    Private _Numero As String
    Private _Id_Tercero As Int32
    Private _Valor_USD As Double
    Private _TRM As Double
    Private _Valor_COP As Double
    Private _Id_Nivel As Int32
    Private _Observaciones As String
    Private _Id_Tipo_Orden As Int32
    Private _Aprobacion_Financiera As Boolean
    Private _Aprobacion_Pais As Boolean
    Private _Codigo_Proyecto As String
    Private _Fecha_Inicial_Contrato As DateTime
    Private _Fecha_Final_Contrato As DateTime
    Private _Fecha_Creacion As DateTime
    Private _Id_Usuario_Creacion As Int32
    Private _Fecha_Modificacion As DateTime
    Private _Id_Usuario_Modificacion As Int32
    Private _Id_Proyecto As Int32


    Private objListPpto_Ajustes As List(Of Ppto_AjustesBrl)
    Private objListPpto_Pagos As List(Of Ppto_PagosBrl)


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

    Public Event Aprobacion_PaisChanging(ByVal Value As Boolean)
    Public Event Aprobacion_PaisChanged()

    Public Property Aprobacion_Pais() As Boolean
        Get
            Return Me._Aprobacion_Pais
        End Get
        Set(ByVal Value As Boolean)
            If _Aprobacion_Pais <> Value Then
                RaiseEvent Aprobacion_PaisChanging(Value)
                Me._Aprobacion_Pais = Value
                RaiseEvent Aprobacion_PaisChanged()
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

    Public Event Fecha_Inicial_ContratoChanging(ByVal Value As DateTime)
    Public Event Fecha_Inicial_ContratoChanged()

    Public Property Fecha_Inicial_Contrato() As DateTime
        Get
            Return Me._Fecha_Inicial_Contrato
        End Get
        Set(ByVal Value As DateTime)
            If _Fecha_Inicial_Contrato <> Value Then
                RaiseEvent Fecha_Inicial_ContratoChanging(Value)
                Me._Fecha_Inicial_Contrato = Value
                RaiseEvent Fecha_Inicial_ContratoChanged()
            End If
        End Set
    End Property

    Public Event Fecha_Final_ContratoChanging(ByVal Value As DateTime)
    Public Event Fecha_Final_ContratoChanged()

    Public Property Fecha_Final_Contrato() As DateTime
        Get
            Return Me._Fecha_Final_Contrato
        End Get
        Set(ByVal Value As DateTime)
            If _Fecha_Final_Contrato <> Value Then
                RaiseEvent Fecha_Final_ContratoChanging(Value)
                Me._Fecha_Final_Contrato = Value
                RaiseEvent Fecha_Final_ContratoChanged()
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

    Public Property Ppto_Ajustes() As List(Of Ppto_AjustesBrl)
        Get
            If (Me.objListPpto_Ajustes Is Nothing) Then
                objListPpto_Ajustes = Ppto_AjustesBrl.CargarPorId_Contrato(Me.ID)
            End If
            Return Me.objListPpto_Ajustes
        End Get
        Set(ByVal Value As List(Of Ppto_AjustesBrl))
            Me.objListPpto_Ajustes = Value
        End Set
    End Property

    Public Property Ppto_Pagos() As List(Of Ppto_PagosBrl)
        Get
            If (Me.objListPpto_Pagos Is Nothing) Then
                objListPpto_Pagos = Ppto_PagosBrl.CargarPorId_Contrato(Me.ID)
            End If
            Return Me.objListPpto_Pagos
        End Get
        Set(ByVal Value As List(Of Ppto_PagosBrl))
            Me.objListPpto_Pagos = Value
        End Set
    End Property

    Public Readonly Property Nivel() As SubTablasBrl
        Get
            Return SubTablasBrl.CargarPorID(Id_Nivel)
        End Get
    End Property

    Public Readonly Property Ppto_Terceros() As Ppto_TercerosBrl
        Get
            Return Ppto_TercerosBrl.CargarPorID(Id_Tercero)
        End Get
    End Property

    Public ReadOnly Property Tipo_Orden() As SubTablasBrl
        Get
            Return SubTablasBrl.CargarPorID(Id_Tipo_Orden)
        End Get
    End Property

    Public ReadOnly Property DescripcionContrato() As String
        Get
            Return Numero + " por USD " + Format(Valor_USD, "C") + " a nombre de " + Ppto_Terceros.Razon_Social
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
            Me.ID = Ppto_ContratosDAL.Insertar(Fecha, Numero, Id_Tercero, Valor_USD, TRM, Valor_COP, Id_Nivel, Observaciones, Fecha_Creacion, Id_Usuario_Creacion, Fecha_Modificacion, Id_Usuario_Modificacion, Id_Tipo_Orden, Aprobacion_Financiera, Aprobacion_Pais, Codigo_Proyecto, Fecha_Inicial_Contrato, Fecha_Final_Contrato, Id_Proyecto)
            RaiseEvent Inserted()			
		Else
            RaiseEvent Updating()		
            Ppto_ContratosDAL.Actualizar(ID, Fecha, Numero, Id_Tercero, Valor_USD, TRM, Valor_COP, Id_Nivel, Observaciones, Fecha_Creacion, Id_Usuario_Creacion, Fecha_Modificacion, Id_Usuario_Modificacion, Id_Tipo_Orden, Aprobacion_Financiera, Aprobacion_Pais, Codigo_Proyecto, Fecha_Inicial_Contrato, Fecha_Final_Contrato, Id_Proyecto)
            RaiseEvent Updated()			
		End If   
        If Not objListPpto_Ajustes Is Nothing Then
            For Each fila As Ppto_AjustesBrl In objListPpto_Ajustes
                fila.Id_Contrato = Me.ID
                Try
		   fila.Guardar()
		Catch ex as Exception
		
                End Try
            Next
        End If

        If Not objListPpto_Pagos Is Nothing Then
            For Each fila As Ppto_PagosBrl In objListPpto_Pagos
                fila.Id_Contrato = Me.ID
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
            totalHijos += Ppto_Ajustes.Count
            totalHijos += Ppto_Pagos.Count
            If totalHijos > 0 Then Throw New Exception("No se puede eliminar el registro porque existen datos que dependen de él.")
            
			Ppto_ContratosDAL.Eliminar(Me.ID)
			
            RaiseEvent Deleted()
            
        End If
	End Sub
	
    Private Shared Function asignarValoresALasPropiedades(ByVal fila As DataRow) As Ppto_ContratosBrl

        Dim objPpto_Contratos As New Ppto_ContratosBrl

        With objPpto_Contratos
            .ID = fila("Id")
            .Fecha = isDBNullToNothing(fila("Fecha"))
            .Numero = isDBNullToNothing(fila("Numero"))
            .Id_Tercero = isDBNullToNothing(fila("Id_Tercero"))
            .Valor_USD = isDBNullToNothing(fila("Valor_USD"))
            .TRM = isDBNullToNothing(fila("TRM"))
            .Valor_COP = isDBNullToNothing(fila("Valor_COP"))
            .Id_Nivel = isDBNullToNothing(fila("Id_Nivel"))
            .Observaciones = isDBNullToNothing(fila("Observaciones"))
            .Id_Tipo_Orden = isDBNullToNothing(fila("Id_Tipo_Orden"))
            .Aprobacion_Financiera = isDBNullToNothing(fila("Aprobacion_Financiera"))
            .Aprobacion_Pais = isDBNullToNothing(fila("Aprobacion_Pais"))
            .Codigo_Proyecto = isDBNullToNothing(fila("Codigo_Proyecto"))
            .Fecha_Inicial_Contrato = isDBNullToNothing(fila("Fecha_Inicial_Contrato"))
            .Fecha_Final_Contrato = isDBNullToNothing(fila("Fecha_Final_Contrato"))

            .Fecha_Creacion = isDBNullToNothing(fila("Fecha_Creacion"))
            .Id_Usuario_Creacion = isDBNullToNothing(fila("Id_Usuario_Creacion"))
            .Fecha_Modificacion = isDBNullToNothing(fila("Fecha_Modificacion"))
            .Id_Usuario_Modificacion = isDBNullToNothing(fila("Id_Usuario_Modificacion"))
            .Id_Proyecto = isDBNullToNothing(fila("Id_Proyecto"))
        End With

        Return objPpto_Contratos

    End Function
	
	Public Shared Event LoadingPpto_ContratosList(ByVal LoadType As String)
	Public Shared Event LoadedPpto_ContratosList(target As List(Of Ppto_ContratosBrl), ByVal LoadType As String)
	
    Public Shared Function CargarTodos(ByVal Id_Proyecto As Int32) As List(Of Ppto_ContratosBrl)

        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of Ppto_ContratosBrl)

        RaiseEvent LoadingPpto_ContratosList("CargarTodos")

        dsDatos = Ppto_ContratosDAL.CargarTodos(Id_Proyecto)

        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next

        RaiseEvent LoadedPpto_ContratosList(lista, "CargarTodos")

        Return lista

    End Function

	Public Shared Event CargandoPorId(ByVal id As Int32)
    Public Shared Event CargadoPorId(ByVal target As Ppto_ContratosBrl)

	Public Shared Function CargarPorID(ID As Int32) As Ppto_ContratosBrl

		Dim dsDatos As System.Data.DataSet
		Dim objPpto_Contratos As Ppto_ContratosBrl = Nothing 

		dsDatos = Ppto_ContratosDAL.CargarPorID(ID)
        If dsDatos.Tables(0).Rows.Count <> 0 Then objPpto_Contratos = asignarValoresALasPropiedades(dsDatos.Tables(0).Rows(0))
        Return objPpto_Contratos
        
    End Function

	Public Shared Function CargarPorId_Nivel(ByVal Id_Nivel As Int32) As List(Of Ppto_ContratosBrl)

		Dim dsDatos As System.Data.DataSet
		Dim lista As New List(Of Ppto_ContratosBrl)
	
		RaiseEvent LoadingPpto_ContratosList("CargarPorId_Nivel")
		
		dsDatos = Ppto_ContratosDAL.CargarPorId_Nivel(Id_Nivel)

        For Each fila as DataRow in dsDatos.Tables(0).Rows
			lista.Add(asignarValoresALasPropiedades(fila))
        Next
        
        RaiseEvent LoadedPpto_ContratosList(lista, "CargarPorId_Nivel")
        
        Return lista
        
	End Function

    Public Shared Function CargarPorId_Tercero(ByVal Id_Tercero As Int32) As List(Of Ppto_ContratosBrl)

        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of Ppto_ContratosBrl)

        RaiseEvent LoadingPpto_ContratosList("CargarPorId_Tercero")

        dsDatos = Ppto_ContratosDAL.CargarPorId_Tercero(Id_Tercero)

        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next

        RaiseEvent LoadedPpto_ContratosList(lista, "CargarPorId_Tercero")

        Return lista

    End Function

    Public Shared Function CargarPorId_Tipo_Orden(ByVal Id_Tipo_Orden As Int32) As List(Of Ppto_ContratosBrl)

        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of Ppto_ContratosBrl)

        RaiseEvent LoadingPpto_ContratosList("CargarPorId_Tipo_Orden")

        dsDatos = Ppto_ContratosDAL.CargarPorId_Tipo_Orden(Id_Tipo_Orden)

        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next

        RaiseEvent LoadedPpto_ContratosList(lista, "CargarPorId_Tipo_Orden")

        Return lista

    End Function

    Public Shared Function CargarPorAprobacionFinanciera(ByVal Id_Proyecto As Int32) As List(Of Ppto_ContratosBrl)
        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of Ppto_ContratosBrl)
        dsDatos = Ppto_ContratosDAL.CargarPorAprobacionFinanciera(Id_Proyecto)
        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next
        Return lista
    End Function

    Public Shared Function CargarPorAprobacionPais(ByVal Id_Proyecto As Int32) As List(Of Ppto_ContratosBrl)
        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of Ppto_ContratosBrl)
        dsDatos = Ppto_ContratosDAL.CargarPorAprobacionPais(Id_Proyecto)
        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next
        Return lista
    End Function

    Public Shared Function CargarPorBusqueda(ByVal fechainicial As String, ByVal fechafinal As String, ByVal numero As String, ByVal Id_tercero As Int32, ByVal Id_nivel As Int32, ByVal Id_Proyecto As Int32) As List(Of Ppto_ContratosBrl)

        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of Ppto_ContratosBrl)
        dsDatos = Ppto_ContratosDAL.CargarPorBusqueda(fechainicial, fechafinal, numero, Id_tercero, Id_nivel, Id_Proyecto)
        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next
        Return lista

    End Function


End Class


