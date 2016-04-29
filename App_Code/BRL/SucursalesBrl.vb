Imports ingNovar.Utilidades2
imports system.data
Imports system.collections.generic


Partial Public Class SucursalesBrl

    Private _Id As Int32
    Private _Id_Enlace As Int32
    Private _Nombre As String
    Private _Direccion As String
    Private _Contacto As String
    Private _Telefonos As String
    Private _Texto_Financiero As String


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

    Public Event Id_EnlaceChanging(ByVal Value As Int32)
    Public Event Id_EnlaceChanged()
	
    Public Property Id_Enlace() As Int32
        Get
            Return Me._Id_Enlace
        End Get
        Set(ByVal Value As Int32)
            If _Id_Enlace <> Value Then
                RaiseEvent Id_EnlaceChanging(Value)
				Me._Id_Enlace = Value
                RaiseEvent Id_EnlaceChanged()
            End If
        End Set
    End Property

    Public Event NombreChanging(ByVal Value As String)
    Public Event NombreChanged()
	
    Public Property Nombre() As String
        Get
            Return Me._Nombre
        End Get
        Set(ByVal Value As String)
            If _Nombre <> Value Then
                RaiseEvent NombreChanging(Value)
				Me._Nombre = Value
                RaiseEvent NombreChanged()
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

    Public Event ContactoChanging(ByVal Value As String)
    Public Event ContactoChanged()
	
    Public Property Contacto() As String
        Get
            Return Me._Contacto
        End Get
        Set(ByVal Value As String)
            If _Contacto <> Value Then
                RaiseEvent ContactoChanging(Value)
				Me._Contacto = Value
                RaiseEvent ContactoChanged()
            End If
        End Set
    End Property

    Public Event TelefonosChanging(ByVal Value As String)
    Public Event TelefonosChanged()
	
    Public Property Telefonos() As String
        Get
            Return Me._Telefonos
        End Get
        Set(ByVal Value As String)
            If _Telefonos <> Value Then
                RaiseEvent TelefonosChanging(Value)
				Me._Telefonos = Value
                RaiseEvent TelefonosChanged()
            End If
        End Set
    End Property

    Public Event Texto_FinancieroChanging(ByVal Value As String)
    Public Event Texto_FinancieroChanged()
	
    Public Property Texto_Financiero() As String
        Get
            Return Me._Texto_Financiero
        End Get
        Set(ByVal Value As String)
            If _Texto_Financiero <> Value Then
                RaiseEvent Texto_FinancieroChanging(Value)
				Me._Texto_Financiero = Value
                RaiseEvent Texto_FinancieroChanged()
            End If
        End Set
    End Property

    Public Readonly Property Regionales() As SubTablasBrl
        Get
            Return SubTablasBrl.CargarPorID(Id_Enlace)
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
			Me.ID = SucursalesDAL.Insertar(Id_Enlace, Nombre, Direccion, Contacto, Telefonos, Texto_Financiero)
            RaiseEvent Inserted()			
		Else
            RaiseEvent Updating()		
			SucursalesDAL.Actualizar(ID, Id_Enlace, Nombre, Direccion, Contacto, Telefonos, Texto_Financiero)
            RaiseEvent Updated()			
		End If   


        RaiseEvent Saved()
        
	End Sub
	
	Public Sub Eliminar()
		Dim totalHijos As Long = 0
		If Me.ID <> Nothing Then 
			
            RaiseEvent Deleting()
            If totalHijos > 0 Then Throw New Exception("No se puede eliminar el registro porque existen datos que dependen de él.")
            SucursalesDAL.Eliminar(Me.ID)
			
            RaiseEvent Deleted()
            
        End If
	End Sub
	
    Private Shared Function asignarValoresALasPropiedades(ByVal fila As DataRow) As SucursalesBrl

        Dim objSucursales As New SucursalesBrl

        With objSucursales
            .ID = fila("Id")
            .Id_Enlace = isDBNullToNothing(fila("Id_Enlace"))
            .Nombre = isDBNullToNothing(fila("Nombre"))
            .Direccion = isDBNullToNothing(fila("Direccion"))
            .Contacto = isDBNullToNothing(fila("Contacto"))
            .Telefonos = isDBNullToNothing(fila("Telefonos"))
            .Texto_Financiero = isDBNullToNothing(fila("Texto_Financiero"))

        End With

        Return objSucursales

    End Function
	
	Public Shared Event LoadingSucursalesList(ByVal LoadType As String)
	Public Shared Event LoadedSucursalesList(target As List(Of SucursalesBrl), ByVal LoadType As String)
	
	Public Shared Function CargarTodos() As List(Of SucursalesBrl)

		Dim dsDatos As System.Data.DataSet
		Dim lista As New List(Of SucursalesBrl)
	
		RaiseEvent LoadingSucursalesList("CargarTodos")
	
		dsDatos = SucursalesDAL.CargarTodos()

        For Each fila as DataRow in dsDatos.Tables(0).Rows
			lista.Add(asignarValoresALasPropiedades(fila))
        Next
        
        RaiseEvent LoadedSucursalesList(lista, "CargarTodos")
        
        Return lista
        
    End Function

	Public Shared Event CargandoPorId(ByVal id As Int32)
    Public Shared Event CargadoPorId(ByVal target As SucursalesBrl)

	Public Shared Function CargarPorID(ID As Int32) As SucursalesBrl

		Dim dsDatos As System.Data.DataSet
		Dim objSucursales As SucursalesBrl = Nothing 
		
		'RaiseEvent CargandoPorId(ID)
			
		dsDatos = SucursalesDAL.CargarPorID(ID)
		
		If dsDatos.Tables(0).Rows.Count <> 0 Then objSucursales = asignarValoresALasPropiedades(dsDatos.Tables(0).Rows(0))
		
		'RaiseEvent CargadoPorId(objJoven)

        Return objSucursales
        
    End Function
	Public Shared Function CargarPorId_Enlace(ByVal Id_Enlace As Int32) As List(Of SucursalesBrl)

		Dim dsDatos As System.Data.DataSet
		Dim lista As New List(Of SucursalesBrl)
	
		RaiseEvent LoadingSucursalesList("CargarPorId_Enlace")
		
		dsDatos = SucursalesDAL.CargarPorId_Enlace(Id_Enlace)

        For Each fila as DataRow in dsDatos.Tables(0).Rows
			lista.Add(asignarValoresALasPropiedades(fila))
        Next
        
        RaiseEvent LoadedSucursalesList(lista, "CargarPorId_Enlace")
        
        Return lista
        
	End Function



End Class


