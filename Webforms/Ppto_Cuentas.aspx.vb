Imports ingNovar.Utilidades2
Imports System.Collections.Generic
Imports Telerik.Web.UI

Partial Class Webforms_Ppto_Cuentas
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
            Else
                btnGuardar.Enabled = objper_perfil.Pcrear
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
            Else
                btnGuardar.Enabled = objper_usuario.Pcrear
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


        If Request.QueryString.Item("Mensaje") = 1 Then
            lblMensaje.Text = "Operación exitosa"
            lblMensaje.Visible = True
        End If

        Dim objPpto_Cuentas As Ppto_CuentasBrl = Ppto_CuentasBrl.CargarPorID(Request.QueryString.Item("ID"))

        If objPpto_Cuentas Is Nothing Then
            lblMensaje.Text = "Registro no existe"
            lblMensaje.Visible = True
            Exit Sub
        End If

        txt_codigo.Text = objPpto_Cuentas.Codigo_Regional
        lbl_Descripcion.Text = objPpto_Cuentas.Descripcion
        chb_visible.Checked = objPpto_Cuentas.Visible
        Session("ListPpto_Cuentas_Detalle") = objPpto_Cuentas.Ppto_Cuentas_Detalle
        Rg_Listado.DataSource = Session("ListPpto_Cuentas_Detalle")
        Rg_Listado.DataBind()

        lblidDetalle.Text = ""

    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        Dim ID As Int32

        Try
            ID = Grabar()
            Response.Redirect("Ppto_Cuentas.aspx?Editar=1&Mensaje=1&ID=" & ID)
        Catch ex As Exception
            lblMensaje.Text = ex.Message
            lblMensaje.Visible = True
        End Try

    End Sub

    Private Function Grabar() As Int32

        Dim objPpto_Cuentas As Ppto_CuentasBrl

        If Request.QueryString.Item("Editar") = 1 Then
            objPpto_Cuentas = Ppto_CuentasBrl.CargarPorID(Request.QueryString.Item("ID"))
        Else
            objPpto_Cuentas = New Ppto_CuentasBrl

        End If

        objPpto_Cuentas.Codigo_Regional = txt_codigo.Text
        objPpto_Cuentas.Visible = chb_visible.Checked

        objPpto_Cuentas.Guardar()

        Return objPpto_Cuentas.ID

    End Function

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        lblMensaje.Text = ""
        Try
            If Request.QueryString.Item("Editar") = 1 Then
                Dim objPpto_Cuentas As Ppto_CuentasBrl
                objPpto_Cuentas = Ppto_CuentasBrl.CargarPorID(Request.QueryString.Item("ID"))
                objPpto_Cuentas.Eliminar()
                Response.Redirect("Ppto_Cuentas.aspx?Mensaje=1")
            Else
                lblMensaje.Text = "No existe registro para eliminar. "
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
        Response.Redirect("../webforms/Ppto_CuentasList.aspx")
    End Sub

    Protected Sub btn_actualizar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_actualizar.Click
        If Request.QueryString.Item("Id") > 0 Then
            Response.Redirect("../webforms/Ppto_Cuentas.aspx?Editar=1&Id=" + Request.QueryString.Item("Id"))

        End If
    End Sub

    Protected Sub Rg_Listado_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Rg_Listado.SelectedIndexChanged
        Dim item As Telerik.Web.UI.GridDataItem = Me.Rg_Listado.SelectedItems.Item(Rg_Listado.SelectedIndexes.Item(0))
        lblidDetalle.Text = item("id").Text
        txt_cuenta.Text = item("Cuenta").Text

        'Response.Redirect("Ppto_Ingresos.aspx?Editar=1&ID=" & item("id").Text)
    End Sub

    Protected Sub Rg_Listado_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles Rg_Listado.NeedDataSource
        Rg_Listado.DataSource = Session("ListPpto_Cuentas_Detalle")
    End Sub

    Protected Sub btnGuardar_Cuenta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar_Cuenta.Click
        Dim objdetallecuenta As Ppto_Cuentas_DetalleBrl
        If lblidDetalle.Text.Trim = "" Then
            ' nuevo
            objdetallecuenta = New Ppto_Cuentas_DetalleBrl
            objdetallecuenta.Id_Ppto_Cuentas = Request.QueryString.Item("Id")
        Else
            ' ya existe
            objdetallecuenta = Ppto_Cuentas_DetalleBrl.CargarPorID(lblidDetalle.Text)

        End If
        objdetallecuenta.Cuenta = txt_cuenta.Text
        objdetallecuenta.Guardar()
        txt_cuenta.Text = ""
        lblidDetalle.Text = ""

        ' Recargar Tabla

        Dim ListPpto_Cuentas_Detalle As List(Of Ppto_Cuentas_DetalleBrl) = Ppto_Cuentas_DetalleBrl.CargarPorId_Ppto_Cuentas(Request.QueryString.Item("Id"))

        Session("ListPpto_Cuentas_Detalle") = ListPpto_Cuentas_Detalle
        Rg_Listado.DataSource = Session("ListPpto_Cuentas_Detalle")
        Rg_Listado.DataBind()


    End Sub

    Public Sub subCommandItem(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs)
        Select Case e.CommandName
            Case "Eliminar"
                subEliminar(sender, e)
        End Select
    End Sub

    Public Sub subEliminar(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs)
        Dim lblId As Label
        lblId = e.Item.FindControl("lblId")
        Dim objdetalle As Ppto_Cuentas_DetalleBrl = Ppto_Cuentas_DetalleBrl.CargarPorID(lblId.Text)
        Try
            objdetalle.Eliminar()
            Response.Redirect("Ppto_Cuentas.aspx?Editar=1&Refrescar=1&Id=" + Request.QueryString.Item("Id"))
        Catch ex As Exception
        End Try
    End Sub


End Class
