Imports ingNovar.Utilidades2
imports system.data
Imports system.collections.generic


Partial Public Class Ppto_TercerosBrl

    Private _Id As Int32
    Private _Identificacion As String
    Private _Razon_Social As String
    Private _Direccion As String
    Private _Telefono1 As String
    Private _Telefono2 As String
    Private _DV As String
    Private _Nombre_Empresa As String

    Private objListPpto_Contratos As List(Of Ppto_ContratosBrl)
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

    Public Event IdentificacionChanging(ByVal Value As String)
    Public Event IdentificacionChanged()
	
    Public Property Identificacion() As String
        Get
            Return Me._Identificacion
        End Get
        Set(ByVal Value As String)
            If _Identificacion <> Value Then
                RaiseEvent IdentificacionChanging(Value)
				Me._Identificacion = Value
                RaiseEvent IdentificacionChanged()
            End If
        End Set
    End Property

    Public Event Razon_SocialChanging(ByVal Value As String)
    Public Event Razon_SocialChanged()
	
    Public Property Razon_Social() As String
        Get
            Return Me._Razon_Social
        End Get
        Set(ByVal Value As String)
            If _Razon_Social <> Value Then
                RaiseEvent Razon_SocialChanging(Value)
				Me._Razon_Social = Value
                RaiseEvent Razon_SocialChanged()
            End If
        End Set
    End Property

    Public Event DireccionChanging(ByVal Value As String)
    Public Event DireccionChanged()
	
    Public Property Direccion() As String
        Get
            Return Me._Direccion
        End Get
        Set(ByVal Value As String)
            If _Direccion <> Value Then
                RaiseEvent DireccionChanging(Value)
				Me._Direccion = Value
                RaiseEvent DireccionChanged()
            End If
        End Set
    End Property

    Public Event Telefono1Changing(ByVal Value As String)
    Public Event Telefono1Changed()
	
    Public Property Telefono1() As String
        Get
            Return Me._Telefono1
        End Get
        Set(ByVal Value As String)
            If _Telefono1 <> Value Then
                RaiseEvent Telefono1Changing(Value)
				Me._Telefono1 = Value
                RaiseEvent Telefono1Changed()
            End If
        End Set
    End Property

    Public Event Telefono2Changing(ByVal Value As String)
    Public Event Telefono2Changed()
	
    Public Property Telefono2() As String
        Get
            Return Me._Telefono2
        End Get
        Set(ByVal Value As String)
            If _Telefono2 <> Value Then
                RaiseEvent Telefono2Changing(Value)
				Me._Telefono2 = Value
                RaiseEvent Telefono2Changed()
            End If
        End Set
    End Property

    Public Event DVChanging(ByVal Value As String)
    Public Event DVChanged()
	
    Public Property DV() As String
        Get
            Return Me._DV
        End Get
        Set(ByVal Value As String)
            If _DV <> Value Then
                RaiseEvent DVChanging(Value)
				Me._DV = Value
                RaiseEvent DVChanged()
            End If
        End Set
    End Property

    Public Event Nombre_EmpresaChanging(ByVal Value As String)
    Public Event Nombre_EmpresaChanged()

    Public Property Nombre_Empresa() As String
        Get
            Return Me._Nombre_Empresa
        End Get
        Set(ByVal Value As String)
            If _Direccion <> Value Then
                RaiseEvent Nombre_EmpresaChanging(Value)
                Me._Nombre_Empresa = Value
                RaiseEvent Nombre_EmpresaChanged()
            End If
        End Set
    End Property

    Public Property Ppto_Contratos() As List(Of Ppto_ContratosBrl)
        Get
            If (Me.objListPpto_Contratos Is Nothing) Then
                objListPpto_Contratos = Ppto_ContratosBrl.CargarPorId_Tercero(Me.ID)
            End If
            Return Me.objListPpto_Contratos
        End Get
        Set(ByVal Value As List(Of Ppto_ContratosBrl))
            Me.objListPpto_Contratos = Value
        End Set
    End Property

    Public Property Ppto_Pagos() As List(Of Ppto_PagosBrl)
        Get
            If (Me.objListPpto_Pagos Is Nothing) Then
                objListPpto_Pagos = Ppto_PagosBrl.CargarPorId_Tercero(Me.ID)
            End If
            Return Me.objListPpto_Pagos
        End Get
        Set(ByVal Value As List(Of Ppto_PagosBrl))
            Me.objListPpto_Pagos = Value
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
            Me.ID = Ppto_TercerosDAL.Insertar(Identificacion, Razon_Social, Direccion, Telefono1, Telefono2, DV, Nombre_Empresa)
            RaiseEvent Inserted()			
		Else
            RaiseEvent Updating()		
            Ppto_TercerosDAL.Actualizar(ID, Identificacion, Razon_Social, Direccion, Telefono1, Telefono2, DV, Nombre_Empresa)
            RaiseEvent Updated()			
		End If   
        If Not objListPpto_Contratos Is Nothing Then
            For Each fila As Ppto_ContratosBrl In objListPpto_Contratos
                fila.Id_Tercero = Me.ID
                Try
		   fila.Guardar()
		Catch ex as Exception
		
                End Try
            Next
        End If

        If Not objListPpto_Pagos Is Nothing Then
            For Each fila As Ppto_PagosBrl In objListPpto_Pagos
                fila.Id_Tercero = Me.ID
                Try
		   fila.Guardar()
		Catch ex as Exception
		
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
            totalHijos += Ppto_Pagos.Count
            If totalHijos > 0 Then Throw New Exception("No se puede eliminar el registro porque existen datos que dependen de él.")
            
			Ppto_TercerosDAL.Eliminar(Me.ID)
			
            RaiseEvent Deleted()
            
        End If
	End Sub
	

    Private Shared Function asignarValoresALasPropiedades(ByVal fila As DataRow) As Ppto_TercerosBrl
		
		Dim objPpto_Terceros As New Ppto_TercerosBrl
		
		With objPpto_Terceros
			.ID = fila("Id")
			.Identificacion = isDBNullToNothing(fila("Identificacion"))
			.Razon_Social = isDBNullToNothing(fila("Razon_Social"))
			.Direccion = isDBNullToNothing(fila("Direccion"))
			.Telefono1 = isDBNullToNothing(fila("Telefono1"))
			.Telefono2 = isDBNullToNothing(fila("Telefono2"))
            .DV = isDBNullToNothing(fila("DV"))
            .Nombre_Empresa = isDBNullToNothing(fila("Nombre_Empresa"))

		End With
		
		Return objPpto_Terceros
		
    End Function
	
	Public Shared Event LoadingPpto_TercerosList(ByVal LoadType As String)
	Public Shared Event LoadedPpto_TercerosList(target As List(Of Ppto_TercerosBrl), ByVal LoadType As String)
	
	Public Shared Function CargarTodos() As List(Of Ppto_TercerosBrl)

		Dim dsDatos As System.Data.DataSet
		Dim lista As New List(Of Ppto_TercerosBrl)
	
		RaiseEvent LoadingPpto_TercerosList("CargarTodos")
	
		dsDatos = Ppto_TercerosDAL.CargarTodos()

        For Each fila as DataRow in dsDatos.Tables(0).Rows
			lista.Add(asignarValoresALasPropiedades(fila))
        Next
        
        RaiseEvent LoadedPpto_TercerosList(lista, "CargarTodos")
        
        Return lista
        
    End Function

	Public Shared Event CargandoPorId(ByVal id As Int32)
    Public Shared Event CargadoPorId(ByVal target As Ppto_TercerosBrl)

	Public Shared Function CargarPorID(ID As Int32) As Ppto_TercerosBrl

		Dim dsDatos As System.Data.DataSet
		Dim objPpto_Terceros As Ppto_TercerosBrl = Nothing 
        dsDatos = Ppto_TercerosDAL.CargarPorID(ID)
		
		If dsDatos.Tables(0).Rows.Count <> 0 Then objPpto_Terceros = asignarValoresALasPropiedades(dsDatos.Tables(0).Rows(0))
        Return objPpto_Terceros
        
    End Function

    Public Shared Function CargarPorNombreeIdentificacion(ByVal dato As String) As List(Of Ppto_TercerosBrl)

        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of Ppto_TercerosBrl)

        dsDatos = Ppto_TercerosDAL.CargarPorNombreeIdentificacion(dato)

        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next
        Return lista
    End Function



End Class


