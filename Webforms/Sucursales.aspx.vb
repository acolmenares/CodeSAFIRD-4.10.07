Imports ingNovar.Utilidades2

Partial Class Webforms_Sucursales
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

            ' asignando los permisos

            If Request.QueryString.Item("Id") > 0 Then  ' va a editar
                btnGuardar.Enabled = objper_perfil.Peditar
                btnGuardarOtro.Enabled = objper_perfil.Peditar
            Else
                btnGuardar.Enabled = objper_perfil.Pcrear
                btnGuardarOtro.Enabled = objper_perfil.Pcrear
            End If
            btnEliminar.Enabled = objper_perfil.Peliminar
            btn_nuevo.Enabled = objper_perfil.Pcrear

        End If

        If objper_usuario IsNot Nothing Then
            If objper_usuario.Pver = False Or objper_usuario.Pconsultar = False Then
                Response.Redirect(strPaginaError)
                Exit Sub
            End If

            ' asignando los permisos

            If Request.QueryString.Item("Id") > 0 Then  ' va a editar
                btnGuardar.Enabled = objper_usuario.Peditar
                btnGuardarOtro.Enabled = objper_usuario.Peditar
            Else
                btnGuardar.Enabled = objper_usuario.Pcrear
                btnGuardarOtro.Enabled = objper_usuario.Pcrear
            End If
            btnEliminar.Enabled = objper_usuario.Peliminar
            btn_nuevo.Enabled = objper_usuario.Pcrear
        End If

    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If IsPostBack Then Exit Sub

        If Session("IdUsuario") Is Nothing Then
            Session.RemoveAll()
            Response.Redirect("../login.aspx")
            Exit Sub
        End If

        If Session("Id_Proyecto") Is Nothing Then
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

        BindHelper.SubTablasUIL.BindToListControlPorId_Tabla(ddl_regional, 72, New ListItem("Seleccione", 0))

        If Request.QueryString.Item("Mensaje") = 1 Then
            lblMensaje.Text = "Operación exitosa"
            lblMensaje.Visible = True
        End If

        If Request.QueryString.Item("Editar") = 1 Then
            Dim objSucursal As SucursalesBrl = SucursalesBrl.CargarPorID(Request.QueryString.Item("ID"))

            If objSucursal Is Nothing Then
                lblMensaje.Text = "Registro no existe"
                lblMensaje.Visible = True
                Exit Sub
            End If
            txt_Nombre.Text = objSucursal.Nombre
            ddl_regional.SelectedValue = objSucursal.Id_Enlace
            txt_direccion.Text = objSucursal.Direccion
            txt_telefonos.Text = objSucursal.Telefonos
            txt_contacto.Text = objSucursal.Contacto
            txt_TextoFinanciero.Text = objSucursal.Texto_Financiero
            objSucursal.Guardar()

        End If

    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Validate("SUCURSAL")
        If Not IsValid Then Exit Sub

        Dim ID As Int32

        Try
            ID = Grabar()
            Response.Redirect("Sucursales.aspx?Editar=1&Mensaje=1&ID=" & ID)
        Catch ex As Exception
            lblMensaje.Text = ex.Message
            lblMensaje.Visible = True
        End Try

    End Sub

    Private Sub btnGuardarOtro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarOtro.Click
        Validate("SUCURSAL")
        If Not IsValid Then Exit Sub

        Try
            Grabar()
            Response.Redirect("Sucursales.aspx?Mensaje=1")
        Catch ex As Exception
            lblMensaje.Text = ex.Message
            lblMensaje.Visible = True
        End Try

    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Session.Remove("Sucursales")
        Response.Redirect("SucursalesList.aspx?Refrescar=1")
    End Sub

    Private Function Grabar() As Int32

        Dim objSucursal As SucursalesBrl
        If Request.QueryString.Item("Editar") = 1 Then
            objSucursal = SucursalesBrl.CargarPorID(Request.QueryString.Item("ID"))
        Else
            objSucursal = New SucursalesBrl
        End If
        objSucursal.Nombre = txt_Nombre.Text
        objSucursal.Id_Enlace = ddl_regional.SelectedValue
        objSucursal.Contacto = txt_contacto.Text
        objSucursal.Telefonos = txt_telefonos.Text
        objSucursal.Direccion = txt_direccion.Text
        objSucursal.Texto_Financiero = txt_TextoFinanciero.Text
        objSucursal.Guardar()
        Return objSucursal.ID

    End Function

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        lblMensaje.Visible = True
        lblMensaje.Text = ""

        Try
            If Request.QueryString.Item("Editar") = 1 Then
                Dim objSucursal As SucursalesBrl
                objSucursal = SucursalesBrl.CargarPorID(Request.QueryString.Item("ID"))
                objSucursal.Eliminar()
                Response.Redirect("Sucursales.aspx?Mensaje=1")
            Else
                lblMensaje.Text = "No hay registro para eliminar. !!!"
            End If
        Catch ex As Exception
            lblMensaje.Text = ex.Message
            lblMensaje.Visible = True
        End Try

    End Sub

    Protected Sub btn_home_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_home.Click
        Response.Redirect("../webforms/principal.aspx")
    End Sub

    Protected Sub btn_cerrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_cerrar.Click
        Response.Redirect("../webforms/SucursalesList.aspx")
    End Sub

    Protected Sub btn_nuevo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_nuevo.Click
        Response.Redirect("../webforms/Sucursales.aspx")
    End Sub

    Protected Sub btn_actualizar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_actualizar.Click
        If Request.QueryString.Item("Id") > 0 Then
            Response.Redirect("../webforms/Sucursales.aspx?Editar=1&Id=" + Request.QueryString.Item("Id"))
        Else
            btn_nuevo_Click(sender, e)
        End If
    End Sub

End Class
