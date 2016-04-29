Imports ingNovar.Utilidades2
Imports System.Collections.Generic

Partial Class Webforms_OrdenCompraSaldos
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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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

        If Request.QueryString.Item("Mensaje") = 1 Then
            lblMensaje.Text = "Operación exitosa"
            lblMensaje.Visible = True
        End If

        If Request.QueryString.Item("Refrescar") = 1 Then
            Dim objOrdenCompra As OrdenCompraBrl = OrdenCompraBrl.CargarPorID(Request.QueryString.Item("ID"))

            If objOrdenCompra Is Nothing Then
                lblMensaje.Text = "Registro no existe"
                lblMensaje.Visible = True
                Exit Sub
            End If

            lbl_regionaloc.Text = objOrdenCompra.Regional.Descripcion
            lbl_numero.Text = objOrdenCompra.Numero
            lbl_fecha.Text = Format(objOrdenCompra.Fecha, "dddd, MMM d yyyy")
            Try
                lbl_Tercero.Text = objOrdenCompra.Terceros.Razon_Social
            Catch ex As Exception
                lbl_Tercero.Text = "Pendiente de Crear Tercero"
            End Try

            lbl_Forma.Text = objOrdenCompra.Tiempo_Entrega
            lbl_Lugar.Text = objOrdenCompra.Lugar_Entrega
            lbl_Observaciones.Text = objOrdenCompra.Observaciones
            lbl_Tasa.Text = Format(objOrdenCompra.Tasa, "C")
            chkAprobacion_Finanzas_Ofc.Checked = objOrdenCompra.Aprobacion_Finanzas_Ofc
            chkAprobacion_Logistica_Ofc.Checked = objOrdenCompra.Aprobacion_Logistica_Ofc
            chkAprobacion_Coordinacion.Checked = objOrdenCompra.Aprobacion_Coordinacion
            chkAprobacion_Operaciones.Checked = objOrdenCompra.Aprobacion_Operaciones
            chkAprobacion_CooLogistica.Checked = objOrdenCompra.Aprobacion_CooLogistica
            chkAprobacion_Financiera.Checked = objOrdenCompra.Aprobacion_Financiera

            Dim ListOrdenCompra_Detalle As List(Of OrdenCompra_DetalleBrl) = Session("ListOrdenCompra_Detalle")

            ListOrdenCompra_Detalle = objOrdenCompra.OrdenCompra_Detalle
            Session("ListOrdenCompra_DetalleSaldos") = ListOrdenCompra_Detalle

            Rg_Listado.DataSource = Session("ListOrdenCompra_DetalleSaldos")
            Rg_Listado.DataBind()

            Dim Listretenciones As New List(Of OrdenCompra_RetencionBrl)
            Listretenciones = objOrdenCompra.OrdenCompra_Retencion
            Session("ListaRetenciones") = Listretenciones
            dg_Retenciones.DataSource = Listretenciones
            dg_Retenciones.DataBind()

        End If

    End Sub

    Public Sub CambioPaginaRet(ByVal sender As Object, ByVal e As DataGridPageChangedEventArgs) Handles dg_Retenciones.PageIndexChanged
        dg_Retenciones.CurrentPageIndex = e.NewPageIndex
        dg_Retenciones.SelectedIndex = -1
        dg_Retenciones.DataSource = Session("ListaRetenciones")
        dg_Retenciones.DataBind()
    End Sub

    Protected Sub btn_actualizar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_actualizar.Click
        Response.Redirect("OrdenCompraSaldos.aspx?Id=" + Request.QueryString.Item("Id"))
    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        If lbl_numero.Text <> "" Then
            Dim rpURL As String = "OrdenCompraReporte.aspx?No=" + lbl_numero.Text
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "Ventana", "<script language='JavaScript'> var ventana = window.open('" + rpURL + "','_reportes','toolbar=no,status=yes,menubar=no,location=no,scrollbars=yes,resizable=yes,width=900,height=600'); ventana.focus();</script>", False)
        End If
    End Sub

    Protected Sub btn_cerrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_cerrar.Click
        Session.Remove("ListOrdenCompra_DetalleSaldos")
        Session.Remove("ListaRetenciones")
        Select Case Request.QueryString.Item("Envio")
            Case 1
                Response.Redirect("OrdenCompraSaldosList.aspx")
            Case 2
                Response.Redirect("OrdenCompraAprobarList.aspx?TA=" + Request.QueryString.Item("TA"))
            Case Else
                Response.Redirect("OrdenCompraSaldosList.aspx")
        End Select

    End Sub

    Protected Sub btn_home_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_home.Click
        Response.Redirect("../webforms/principal.aspx")
    End Sub

End Class
