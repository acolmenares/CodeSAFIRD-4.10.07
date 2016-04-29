Imports Telerik.Web.UI

Partial Class Webforms_EliminarAprobaciones
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

        '        Asignando los permisos

        Dim uc As New Controles_ucContratos
        uc = DirectCast(RadPanelBar1.FindItemByValue("rpi_Contrato").FindControl("ucContratos1"), UserControl)
        Dim btn_buscar As ImageButton
        Dim btn_contratos As Button
        btn_buscar = uc.FindControl("btn_buscar")
        btn_contratos = uc.FindControl("btn_contratos")
        If objper_perfil IsNot Nothing Then
            btn_buscar.Enabled = objper_perfil.Pconsultar
            btn_contratos.Enabled = objper_perfil.Peditar
        End If
        If objper_usuario IsNot Nothing Then
            btn_buscar.Enabled = objper_usuario.Pconsultar
            btn_contratos.Enabled = objper_usuario.Peditar
        End If


        '
        ' Ordenes de Compra
        '

        Dim uoc As New Controles_UcOrdenCompra
        uoc = DirectCast(RadPanelBar1.FindItemByValue("rpi_OrdenCompra").FindControl("ucOrdenCompra1"), UserControl)
        btn_buscar = uoc.FindControl("btn_buscar")
        btn_contratos = uoc.FindControl("btn_contratos")

        If objper_perfil IsNot Nothing Then
            btn_buscar.Enabled = objper_perfil.Pconsultar
            btn_contratos.Enabled = objper_perfil.Peditar
        End If
        If objper_usuario IsNot Nothing Then
            btn_buscar.Enabled = objper_usuario.Pconsultar
            btn_contratos.Enabled = objper_usuario.Peditar
        End If

    End Sub

    Protected Sub btn_home_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_home.Click
        Response.Redirect("../webforms/principal.aspx")
    End Sub

    Protected Sub btn_cerrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_cerrar.Click
        Response.Redirect("../webforms/EliminarAprobaciones.aspx")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then Exit Sub

        If Session("IdUsuario") Is Nothing Then
            Session.RemoveAll()
            Response.Redirect("../login.aspx")
            Exit Sub
        End If

        Dim lblidUsuario As Label
        lblidUsuario = Master.FindControl("lblidusuario")
        lblidUsuario.Text = Session("IdUsuario")

        Dim LblNombreUsuario As Label
        LblNombreUsuario = Master.FindControl("LblNombreUsuario")
        LblNombreUsuario.Text = Session("NombreUsuario")

        Dim Lbl_regional As Label
        Lbl_regional = Master.FindControl("Lbl_regional")
        Lbl_regional.Text = Session("NombreRegional")

        Dim Lbl_usuario As Label
        Lbl_usuario = Master.FindControl("Lbl_usuario")
        Lbl_usuario.Text = Session("LoginUsuario")

        Dim Lbl_perfil As Label
        Lbl_perfil = Master.FindControl("Lbl_perfil")
        Lbl_perfil.Text = Session("NombrePerfil")
    End Sub


End Class
