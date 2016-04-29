Imports Microsoft.Reporting.WebForms

Partial Class Webforms_OrdenCompraReporte
    Inherits System.Web.UI.Page

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Dim objper_perfil As New SeguridadUsuarios.Permisos_PerfilBrl
        Dim objper_usuario As New SeguridadUsuarios.Permisos_UsuarioBrl
        '
        ' Ingresa Primero aca
        ' Validamos la seguridad
        '
        ' Perfil
        Dim objusuario As SeguridadUsuarios.UsuariosBrl
        objusuario = SeguridadUsuarios.UsuariosBrl.CargarPorID(CType(Session("IdUsuario"), Integer))
        If objusuario Is Nothing Then
            Response.Redirect(strPaginaError)
            Exit Sub
        End If
        ' Pagina

        Dim objpagina As SeguridadUsuarios.PaginasBrl
        objpagina = SeguridadUsuarios.PaginasBrl.CargarPorURL(Request.FilePath)
        If objpagina Is Nothing Then
            Response.Redirect(strPaginaError)
            Exit Sub
        End If

        ' Permisos por Perfil

        objper_perfil = SeguridadUsuarios.Usuarios.EstadoPerPagina(objusuario.Id_Perfil, objpagina.ID)
        objper_usuario = SeguridadUsuarios.Usuarios.EstadoPerUsuario(objusuario.ID, objpagina.ID)

        If objper_perfil Is Nothing And objper_usuario Is Nothing Then
            Response.Redirect(strPaginaError)
            Exit Sub
        End If

        ' En alguno de los dos hay permisos
        ' Hay datos en la pagina de perfiles, se inicia la validacion de datos
        If objper_perfil IsNot Nothing Then
            If objper_perfil.Pver = False Or objper_perfil.Pconsultar = False Then
                Response.Redirect(strPaginaError)
                Exit Sub
            End If

        End If

        If objper_usuario IsNot Nothing Then
            If objper_usuario.Pver = False Or objper_usuario.Pconsultar = False Then
                Response.Redirect(strPaginaError)
                Exit Sub
            End If

        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim westado As Integer = 0
        'Le indicamos al Control que la invocación del reporte será de modo remoto
        ReportViewer1.ProcessingMode = ProcessingMode.Remote
        'Le indicamos la URL donde se encuentra hospedado Reporting Services
        ReportViewer1.ServerReport.ReportServerUrl = New Uri(ConfigurationManager.AppSettings("ReportesServidor").ToString())

        ' Definimos si mandamos el reporte sin aprobacion o el oficial
        Dim objordencompra As OrdenCompraBrl = OrdenCompraBrl.CargarPorNumero(Request.QueryString.Item("No"))
        If objordencompra Is Nothing Then
            Exit Sub
        Else
            If objordencompra.Aprobacion_Financiera Then
                westado = 0  ' Oficial
            Else
                westado = 1 ' Documento con Marca de Agua
            End If
        End If


        'Le indicamos la carpeta y el Reporte que deseamos Ver
        If westado = 0 Then
            ReportViewer1.ServerReport.ReportPath = ConfigurationManager.AppSettings("ReportesAdmin").ToString()
        Else
            ReportViewer1.ServerReport.ReportPath = ConfigurationManager.AppSettings("ReportesAdminSA").ToString()
        End If

        'Definimos los parámetros
        Dim Parametro As New ReportParameter
        Parametro.Name = "Numero"
        Parametro.Values.Add(Request.QueryString.Item("No"))
        'Aqui le indicaremos si queremos que el parámetro 
        'sea visible para el usuario o no
        Parametro.Visible = False
        ' colocando el nombre de la pagina
        Header.Title = "Orden de Compra # " + Request.QueryString.Item("No")
        'Crearemos un arreglo de parámetros
        Dim rp(0) As ReportParameter
        rp(0) = Parametro
        'Ahora agregamos el parámetro en al reporte
        ReportViewer1.ServerReport.SetParameters(rp)
        ReportViewer1.ServerReport.Refresh()
    End Sub
End Class
