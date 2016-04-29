Imports ingNovar.Utilidades2
imports system.data
Imports system.collections.generic


Partial Public Class Ppto_Pagos_DetalleBrl

    Private _Id As Int32
    Private _Id_Ppto_Pago As Int32
    Private _Ano As String
    Private _Periodo As String
    Private _Tipo As String
    Private _Numero As String
    Private _Fecha As DateTime
    Private _Cuenta As Double
    Private _Sucursal As String
    Private _Codigo_Tercero As String
    Private _Descripcion As String
    Private _Cheque As String
    Private _Debito As Double
    Private _Credito As Double
    Private _Nivel As String
    Private _Code As String
    Private _Tasa As Double
    Private _Nombre_Tercero As String


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

    Public Event Id_Ppto_PagoChanging(ByVal Value As Int32)
    Public Event Id_Ppto_PagoChanged()
	
    Public Property Id_Ppto_Pago() As Int32
        Get
            Return Me._Id_Ppto_Pago
        End Get
        Set(ByVal Value As Int32)
            If _Id_Ppto_Pago <> Value Then
                RaiseEvent Id_Ppto_PagoChanging(Value)
				Me._Id_Ppto_Pago = Value
                RaiseEvent Id_Ppto_PagoChanged()
            End If
        End Set
    End Property

    Public Event AnoChanging(ByVal Value As String)
    Public Event AnoChanged()
	
    Public Property Ano() As String
        Get
            Return Me._Ano
        End Get
        Set(ByVal Value As String)
            If _Ano <> Value Then
                RaiseEvent AnoChanging(Value)
				Me._Ano = Value
                RaiseEvent AnoChanged()
            End If
        End Set
    End Property

    Public Event PeriodoChanging(ByVal Value As String)
    Public Event PeriodoChanged()
	
    Public Property Periodo() As String
        Get
            Return Me._Periodo
        End Get
        Set(ByVal Value As String)
            If _Periodo <> Value Then
                RaiseEvent PeriodoChanging(Value)
				Me._Periodo = Value
                RaiseEvent PeriodoChanged()
            End If
        End Set
    End Property

    Public Event TipoChanging(ByVal Value As String)
    Public Event TipoChanged()
	
    Public Property Tipo() As String
        Get
            Return Me._Tipo
        End Get
        Set(ByVal Value As String)
            If _Tipo <> Value Then
                RaiseEvent TipoChanging(Value)
				Me._Tipo = Value
                RaiseEvent TipoChanged()
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

    Public Event CuentaChanging(ByVal Value As Double)
    Public Event CuentaChanged()
	
    Public Property Cuenta() As Double
        Get
            Return Me._Cuenta
        End Get
        Set(ByVal Value As Double)
            If _Cuenta <> Value Then
                RaiseEvent CuentaChanging(Value)
				Me._Cuenta = Value
                RaiseEvent CuentaChanged()
            End If
        End Set
    End Property

    Public Event SucursalChanging(ByVal Value As String)
    Public Event SucursalChanged()
	
    Public Property Sucursal() As String
        Get
            Return Me._Sucursal
        End Get
        Set(ByVal Value As String)
            If _Sucursal <> Value Then
                RaiseEvent SucursalChanging(Value)
				Me._Sucursal = Value
                RaiseEvent SucursalChanged()
            End If
        End Set
    End Property

    Public Event Codigo_TerceroChanging(ByVal Value As String)
    Public Event Codigo_TerceroChanged()
	
    Public Property Codigo_Tercero() As String
        Get
            Return Me._Codigo_Tercero
        End Get
        Set(ByVal Value As String)
            If _Codigo_Tercero <> Value Then
                RaiseEvent Codigo_TerceroChanging(Value)
				Me._Codigo_Tercero = Value
                RaiseEvent Codigo_TerceroChanged()
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

    Public Event ChequeChanging(ByVal Value As String)
    Public Event ChequeChanged()
	
    Public Property Cheque() As String
        Get
            Return Me._Cheque
        End Get
        Set(ByVal Value As String)
            If _Cheque <> Value Then
                RaiseEvent ChequeChanging(Value)
				Me._Cheque = Value
                RaiseEvent ChequeChanged()
            End If
        End Set
    End Property

    Public Event DebitoChanging(ByVal Value As Double)
    Public Event DebitoChanged()
	
    Public Property Debito() As Double
        Get
            Return Me._Debito
        End Get
        Set(ByVal Value As Double)
            If _Debito <> Value Then
                RaiseEvent DebitoChanging(Value)
				Me._Debito = Value
                RaiseEvent DebitoChanged()
            End If
        End Set
    End Property

    Public Event CreditoChanging(ByVal Value As Double)
    Public Event CreditoChanged()
	
    Public Property Credito() As Double
        Get
            Return Me._Credito
        End Get
        Set(ByVal Value As Double)
            If _Credito <> Value Then
                RaiseEvent CreditoChanging(Value)
				Me._Credito = Value
                RaiseEvent CreditoChanged()
            End If
        End Set
    End Property

    Public Event NivelChanging(ByVal Value As String)
    Public Event NivelChanged()
	
    Public Property Nivel() As String
        Get
            Return Me._Nivel
        End Get
        Set(ByVal Value As String)
            If _Nivel <> Value Then
                RaiseEvent NivelChanging(Value)
				Me._Nivel = Value
                RaiseEvent NivelChanged()
            End If
        End Set
    End Property

    Public Event CodeChanging(ByVal Value As String)
    Public Event CodeChanged()
	
    Public Property Code() As String
        Get
            Return Me._Code
        End Get
        Set(ByVal Value As String)
            If _Code <> Value Then
                RaiseEvent CodeChanging(Value)
				Me._Code = Value
                RaiseEvent CodeChanged()
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

    Public Event Nombre_TerceroChanging(ByVal Value As String)
    Public Event Nombre_TerceroChanged()
	
    Public Property Nombre_Tercero() As String
        Get
            Return Me._Nombre_Tercero
        End Get
        Set(ByVal Value As String)
            If _Nombre_Tercero <> Value Then
                RaiseEvent Nombre_TerceroChanging(Value)
				Me._Nombre_Tercero = Value
                RaiseEvent Nombre_TerceroChanged()
            End If
        End Set
    End Property

    Public Readonly Property Ppto_Pagos() As Ppto_PagosBrl
        Get
            Return Ppto_PagosBrl.CargarPorID(Id_Ppto_Pago)
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
            Me.ID = Ppto_Pagos_DetalleDAL.Insertar(Id_Ppto_Pago, Ano, Periodo, Tipo, Numero, Fecha, Cuenta, Sucursal, Codigo_Tercero, Descripcion, Cheque, Debito, Credito, Nivel, Code, Tasa, Nombre_Tercero)
            RaiseEvent Inserted()
        Else
            RaiseEvent Updating()
            Ppto_Pagos_DetalleDAL.Actualizar(ID, Id_Ppto_Pago, Ano, Periodo, Tipo, Numero, Fecha, Cuenta, Sucursal, Codigo_Tercero, Descripcion, Cheque, Debito, Credito, Nivel, Code, Tasa, Nombre_Tercero)
            RaiseEvent Updated()
        End If


        RaiseEvent Saved()

    End Sub
	
	Public Sub Eliminar()
		Dim totalHijos As Long = 0
		If Me.ID <> Nothing Then 
			
            RaiseEvent Deleting()
            If totalHijos > 0 Then Throw New Exception("No se puede eliminar el registro porque existen datos que dependen de él.")
            
			Ppto_Pagos_DetalleDAL.Eliminar(Me.ID)
			
            RaiseEvent Deleted()
            
        End If
	End Sub
	

    Private Shared Function asignarValoresALasPropiedades(ByVal fila As DataRow) As Ppto_Pagos_DetalleBrl
		
		Dim objPpto_Pagos_Detalle As New Ppto_Pagos_DetalleBrl
		
		With objPpto_Pagos_Detalle
			.ID = fila("Id")
			.Id_Ppto_Pago = isDBNullToNothing(fila("Id_Ppto_Pago"))
			.Ano = isDBNullToNothing(fila("Ano"))
			.Periodo = isDBNullToNothing(fila("Periodo"))
			.Tipo = isDBNullToNothing(fila("Tipo"))
			.Numero = isDBNullToNothing(fila("Numero"))
			.Fecha = isDBNullToNothing(fila("Fecha"))
			.Cuenta = isDBNullToNothing(fila("Cuenta"))
			.Sucursal = isDBNullToNothing(fila("Sucursal"))
			.Codigo_Tercero = isDBNullToNothing(fila("Codigo_Tercero"))
			.Descripcion = isDBNullToNothing(fila("Descripcion"))
			.Cheque = isDBNullToNothing(fila("Cheque"))
			.Debito = isDBNullToNothing(fila("Debito"))
			.Credito = isDBNullToNothing(fila("Credito"))
			.Nivel = isDBNullToNothing(fila("Nivel"))
			.Code = isDBNullToNothing(fila("Code"))
			.Tasa = isDBNullToNothing(fila("Tasa"))
			.Nombre_Tercero = isDBNullToNothing(fila("Nombre_Tercero"))

		End With
		
		Return objPpto_Pagos_Detalle
		
    End Function
	
	Public Shared Event LoadingPpto_Pagos_DetalleList(ByVal LoadType As String)
	Public Shared Event LoadedPpto_Pagos_DetalleList(target As List(Of Ppto_Pagos_DetalleBrl), ByVal LoadType As String)
	
	Public Shared Function CargarTodos() As List(Of Ppto_Pagos_DetalleBrl)

		Dim dsDatos As System.Data.DataSet
		Dim lista As New List(Of Ppto_Pagos_DetalleBrl)
	
		RaiseEvent LoadingPpto_Pagos_DetalleList("CargarTodos")
	
		dsDatos = Ppto_Pagos_DetalleDAL.CargarTodos()

        For Each fila as DataRow in dsDatos.Tables(0).Rows
			lista.Add(asignarValoresALasPropiedades(fila))
        Next
        
        RaiseEvent LoadedPpto_Pagos_DetalleList(lista, "CargarTodos")
        
        Return lista
        
    End Function

	Public Shared Event CargandoPorId(ByVal id As Int32)
    Public Shared Event CargadoPorId(ByVal target As Ppto_Pagos_DetalleBrl)

	Public Shared Function CargarPorID(ID As Int32) As Ppto_Pagos_DetalleBrl

		Dim dsDatos As System.Data.DataSet
		Dim objPpto_Pagos_Detalle As Ppto_Pagos_DetalleBrl = Nothing 
		
		'RaiseEvent CargandoPorId(ID)
			
		dsDatos = Ppto_Pagos_DetalleDAL.CargarPorID(ID)
		
		If dsDatos.Tables(0).Rows.Count <> 0 Then objPpto_Pagos_Detalle = asignarValoresALasPropiedades(dsDatos.Tables(0).Rows(0))
		
		'RaiseEvent CargadoPorId(objJoven)

        Return objPpto_Pagos_Detalle
        
    End Function

	Public Shared Function CargarPorId_Ppto_Pago(ByVal Id_Ppto_Pago As Int32) As List(Of Ppto_Pagos_DetalleBrl)

		Dim dsDatos As System.Data.DataSet
		Dim lista As New List(Of Ppto_Pagos_DetalleBrl)
	
		RaiseEvent LoadingPpto_Pagos_DetalleList("CargarPorId_Ppto_Pago")
		
		dsDatos = Ppto_Pagos_DetalleDAL.CargarPorId_Ppto_Pago(Id_Ppto_Pago)

        For Each fila as DataRow in dsDatos.Tables(0).Rows
			lista.Add(asignarValoresALasPropiedades(fila))
        Next
        
        RaiseEvent LoadedPpto_Pagos_DetalleList(lista, "CargarPorId_Ppto_Pago")
        
        Return lista
    End Function

    Public Shared Function CargarPorPendientes() As List(Of Ppto_Pagos_DetalleBrl)

        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of Ppto_Pagos_DetalleBrl)
        dsDatos = Ppto_Pagos_DetalleDAL.CargarPorPendientes()
        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next
        Return lista

    End Function

    Public Shared Function CargarPorProcesadas() As List(Of Ppto_Pagos_DetalleBrl)

        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of Ppto_Pagos_DetalleBrl)
        dsDatos = Ppto_Pagos_DetalleDAL.CargarPorProcesadas()
        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next
        Return lista

    End Function

End Class


