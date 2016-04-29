Imports ingNovar.Utilidades2
Imports System.Data
Imports System.Collections.Generic
Imports Telerik.Web.UI

Partial Class Webforms_OrdenCompra_Detalle
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

        BindHelper.SubTablasUIL.BindToListControlPorId_Tabla(ddlProductos, 32, New ListItem("Seleccione", 0))
        BindHelper.SubTablasUIL.BindToListControlPorId_Tabla(ddlUnidadMedida, 33, New ListItem("Seleccione", 0))
        Dim radtree As RadTreeView
        radtree = Me.RadComboBox2.Items(0).FindControl("RadTreeView1")

        BindToDataSet(radtree, Session("Id_Proyecto"))


        If Request.QueryString.Item("Editar") = 1 Then
            Dim objOrdenCompra_Detalle As OrdenCompra_DetalleBRL = OrdenCompra_DetalleBRL.CargarPorID(Request.QueryString.Item("ID"))

            If objOrdenCompra_Detalle Is Nothing Then
                lblMensaje.Text = "Registro no existe"
                lblMensaje.Visible = True
                Exit Sub
            End If

            If ddlProductos.Items.FindByValue(objOrdenCompra_Detalle.Id_Producto) IsNot Nothing Then ddlProductos.SelectedValue = objOrdenCompra_Detalle.Id_Producto
            If ddlUnidadMedida.Items.FindByValue(objOrdenCompra_Detalle.Id_Unidad_Medida) IsNot Nothing Then ddlUnidadMedida.SelectedValue = objOrdenCompra_Detalle.Id_Unidad_Medida

            Dim node As RadTreeNode = radtree.FindNodeByValue(objOrdenCompra_Detalle.Id_Nivel)
            If node IsNot Nothing Then
                node.Selected = True
                node.ExpandParentNodes()
                Me.RadComboBox2.Text = node.Text
            End If

            txtCantidad.Text = Format(objOrdenCompra_Detalle.Cantidad, "N")
            txtValor_Unitario.Text = Format(objOrdenCompra_Detalle.Valor_Unitario, "C")
            txtObservaciones.Text = objOrdenCompra_Detalle.Descripcion_General
            Lbl_ValorTotal.Text = Format(objOrdenCompra_Detalle.ValorProducto, "C")
            txt_Codigo.Text = objOrdenCompra_Detalle.Codigo_Proyecto
        Else
            If Session("NodoActivo") IsNot Nothing Then
                Dim node As RadTreeNode = radtree.FindNodeByValue(Session("NodoActivo"))
                If node IsNot Nothing Then
                    node.Selected = True
                    node.ExpandParentNodes()
                    Me.RadComboBox2.Text = node.Text
                End If
            End If
        End If

        Session("IdOc") = Request.QueryString.Item("OC")


    End Sub

    Private Shared Sub BindToDataSet(ByVal treeView As RadTreeView, ByVal Id_Proyecto As Int32)

        Dim NivelesList As List(Of SubTablasBrl) = SubTablasBrl.CargarPorNivelesPorProyecto(id_Proyecto) ' Niveles
        treeView.DataTextField = "Descripcion"
        treeView.DataFieldID = "Id"
        treeView.DataFieldParentID = "Id_Padre"
        treeView.DataValueField = "Id"

        treeView.DataSource = NivelesList
        treeView.DataBind()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Validate("DETALLE")
        If Not IsValid Then Exit Sub

        Dim ID As Int32

        Try
            ID = Grabar()
            Response.Redirect("OrdenCompra_Detalle.aspx?Editar=1&Mensaje=1&ID=" & ID & "&OC=" + Session("IdOc").ToString)
        Catch ex As Exception
            lblMensaje.Text = ex.Message
            lblMensaje.Visible = True
        End Try

    End Sub

    Private Sub btnGuardarOtro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarOtro.Click
        Validate("DETALLE")
        If Not IsValid Then Exit Sub

        Try
            Grabar()
            Response.Redirect("OrdenCompra_Detalle.aspx?Mensaje=1&OC=" + Session("IdOc").ToString)
        Catch ex As Exception
            lblMensaje.Text = ex.Message
            lblMensaje.Visible = True
        End Try

    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Session.Remove("OrdenCompra_Detalle")
        Response.Redirect("OrdenCompra.aspx?Editar=1&Refrescar=1&ID=" & Session("IdOc").ToString)
    End Sub

    Private Function Grabar() As Int32

        Dim objOrdenCompra_Detalle As OrdenCompra_DetalleBRL

        If Request.QueryString.Item("Editar") = 1 Then
            objOrdenCompra_Detalle = OrdenCompra_DetalleBRL.CargarPorID(Request.QueryString.Item("ID"))
            objOrdenCompra_Detalle.Fecha_Modificacion = Now
            objOrdenCompra_Detalle.Id_Usuario_Modificacion = CType(Master.FindControl("lblidusuario"), Label).Text

        Else
            objOrdenCompra_Detalle = New OrdenCompra_DetalleBrl
            objOrdenCompra_Detalle.Activo = True
            objOrdenCompra_Detalle.Fecha_Creacion = Now
            objOrdenCompra_Detalle.Id_Usuario_Creacion = CType(Master.FindControl("lblidusuario"), Label).Text

        End If

        objOrdenCompra_Detalle.Id_OrdenCompra = Session("IdOc")
        objOrdenCompra_Detalle.Id_Producto = ddlProductos.SelectedValue
        objOrdenCompra_Detalle.Id_Unidad_Medida = ddlUnidadMedida.SelectedValue
        objOrdenCompra_Detalle.Cantidad = txtCantidad.Text
        objOrdenCompra_Detalle.Valor_Unitario = txtValor_Unitario.Text
        Dim tree As RadTreeView = DirectCast(RadComboBox2.Items(0).FindControl("RadTreeView1"), RadTreeView)
        objOrdenCompra_Detalle.Id_Nivel = tree.SelectedNode.Value
        Session("NodoActivo") = tree.SelectedNode.Value
        objOrdenCompra_Detalle.Descripcion_General = txtObservaciones.Text
        objOrdenCompra_Detalle.Codigo_Proyecto = txt_Codigo.Text
        objOrdenCompra_Detalle.Guardar()

        Return objOrdenCompra_Detalle.ID

    End Function

    Private Sub lnkEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        lblMensaje.Visible = True
        lblMensaje.Text = ""
        Try
            If Request.QueryString.Item("Editar") = 1 Then
                Dim objOrdenCompra_Detalle As OrdenCompra_DetalleBrl
                objOrdenCompra_Detalle = OrdenCompra_DetalleBrl.CargarPorID(Request.QueryString.Item("ID"))
                objOrdenCompra_Detalle.Eliminar()
                Response.Redirect("OrdenCompra_Detalle.aspx?Mensaje=1&OC=" + Session("IdOc").ToString)
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
        Response.Redirect("../webforms/OrdenCompra.aspx?Editar=1&Refrescar=1&ID=" & Session("IdOc").ToString)
    End Sub

    Protected Sub btn_nuevo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_nuevo.Click
        Response.Redirect("../webforms/OrdenCompra_Detalle.aspx?OC=" + Request.QueryString.Item("OC"))
    End Sub

    Protected Sub btn_actualizar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_actualizar.Click
        If Request.QueryString.Item("Id") > 0 Then
            Response.Redirect("../webforms/OrdenCompra_Detalle.aspx?Editar=1&Id=" + Request.QueryString.Item("Id") + "&OC=" & Request.QueryString.Item("OC"))
        Else
            btn_nuevo_Click(sender, e)
        End If
    End Sub

    Protected Sub txtCantidad_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCantidad.TextChanged
        Try
            Lbl_ValorTotal.Text = Format((CType(txtCantidad.Text, Double) * CType(txtValor_Unitario.Text, Double)), "C")
        Catch ex As Exception
            Lbl_ValorTotal.Text = "0"
        End Try
        Try
            txtCantidad.Text = Format(CType(txtCantidad.Text, Double), "N")
        Catch ex As Exception
            txtCantidad.Text = "0"
        End Try
    End Sub

    Protected Sub txtValor_Unitario_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtValor_Unitario.TextChanged
        Try
            Lbl_ValorTotal.Text = Format((CType(txtCantidad.Text, Double) * CType(txtValor_Unitario.Text, Double)), "C")
        Catch ex As Exception
            Lbl_ValorTotal.Text = "0"
        End Try
        Try
            txtValor_Unitario.Text = Format(CType(txtValor_Unitario.Text, Double), "C")
        Catch ex As Exception
            txtValor_Unitario.Text = "0"
        End Try

    End Sub
End Class
