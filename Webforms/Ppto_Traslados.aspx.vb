Imports ingNovar.Utilidades2
Imports System.Collections.Generic
Imports Telerik.Web.UI

Partial Class Webforms_Ppto_Traslados
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
                btn_cargar.Enabled = objper_perfil.Peditar
            Else
                btnGuardar.Enabled = objper_perfil.Pcrear
                btnGuardarOtro.Enabled = objper_perfil.Pcrear
                btn_cargar.Enabled = objper_perfil.Peditar
            End If
            btnEliminar.Enabled = objper_perfil.Peliminar
            btn_nuevo.Enabled = objper_perfil.Pcrear
            chb_editar.Checked = objper_perfil.Peditar
            chb_eliminar.Checked = objper_perfil.Peliminar
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
            chb_editar.Checked = objper_usuario.Peditar
            chb_eliminar.Checked = objper_usuario.Peliminar
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

        Dim radtree, radtree2 As RadTreeView
        radtree = Me.RadComboBox2.Items(0).FindControl("RadTreeView1")
        radtree2 = Me.RadComboBox1.Items(0).FindControl("RadTreeView2")
        BindToDataSet(radtree, Session("Id_Proyecto"))
        BindToDataSet(radtree2, Session("Id_Proyecto"))

        If Request.QueryString.Item("Editar") = 1 Then
            Dim objPpto_Traslados As Ppto_TrasladosBrl = Ppto_TrasladosBrl.CargarPorID(Request.QueryString.Item("ID"))

            If objPpto_Traslados Is Nothing Then
                lblMensaje.Text = "Registro no existe"
                lblMensaje.Visible = True
                Exit Sub
            End If

            rdpFecha.DbSelectedDate = objPpto_Traslados.Fecha
            txtNumero.Text = objPpto_Traslados.Numero

            Dim node As RadTreeNode = radtree.FindNodeByValue(objPpto_Traslados.Id_Nivel_Sale)
            If node IsNot Nothing Then
                node.Selected = True
                node.ExpandParentNodes()
                Me.RadComboBox2.Text = node.Text
            End If

            ddl_Nivel_SelectedIndexChanged(Nothing, Nothing)
            txtObservaciones.Text = objPpto_Traslados.Observaciones

            Session("Ppto_Traslados_Detalle") = objPpto_Traslados.Ppto_Traslados_Detalle
        Else
            Session("Ppto_Traslados_Detalle") = New List(Of Ppto_Traslados_DetalleBrl)
            rdpFecha.SelectedDate = Now
        End If

        Rg_DetalleTraslado.DataSource = Session("Ppto_Traslados_Detalle")
        Rg_DetalleTraslado.DataBind()
    End Sub

    Private Shared Sub BindToDataSet(ByVal treeView As RadTreeView, ByVal Id_Proyecto As Int32)

        Dim NivelesList As List(Of SubTablasBrl) = SubTablasBrl.CargarPorNivelesPorProyecto(Id_Proyecto) ' Niveles
        treeView.DataTextField = "Descripcion"
        treeView.DataFieldID = "Id"
        treeView.DataFieldParentID = "Id_Padre"
        treeView.DataValueField = "Id"

        treeView.DataSource = NivelesList
        treeView.DataBind()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Validate("General")
        If Not IsValid Then Exit Sub

        Dim ID As Int32

        Try
            ID = Grabar()
            Response.Redirect("Ppto_Traslados.aspx?Editar=1&Mensaje=1&ID=" & ID)
        Catch ex As Exception
            lblMensaje.Text = ex.Message
            lblMensaje.Visible = True
        End Try

    End Sub

    Private Sub btnGuardarOtro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarOtro.Click
        Validate("General")
        If Not IsValid Then Exit Sub

        Try
            Grabar()
            Response.Redirect("Ppto_Traslados.aspx?Mensaje=1")
        Catch ex As Exception
            lblMensaje.Text = ex.Message
            lblMensaje.Visible = True
        End Try

    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Session.Remove("Ppto_Traslados")
        Response.Redirect("Ppto_TrasladosList.aspx")
    End Sub

    Private Function Grabar() As Int32

        Dim objPpto_Traslados As Ppto_TrasladosBrl

        If Request.QueryString.Item("Editar") = 1 Then
            objPpto_Traslados = Ppto_TrasladosBrl.CargarPorID(Request.QueryString.Item("ID"))
            objPpto_Traslados.Fecha_Modificacion = Now
            objPpto_Traslados.Id_Usuario_Modificacion = CType(Master.FindControl("lblidusuario"), Label).Text

        Else
            objPpto_Traslados = New Ppto_TrasladosBrl
            objPpto_Traslados.Fecha_Creacion = Now
            objPpto_Traslados.Id_Usuario_Creacion = CType(Master.FindControl("lblidusuario"), Label).Text
            objPpto_Traslados.id_Proyecto = Session("Id_Proyecto")
        End If

        objPpto_Traslados.Fecha = rdpFecha.DbSelectedDate
        objPpto_Traslados.Numero = txtNumero.Text
        Dim tree As RadTreeView = DirectCast(RadComboBox2.Items(0).FindControl("RadTreeView1"), RadTreeView)
        objPpto_Traslados.Id_Nivel_Sale = tree.SelectedNode.Value
        objPpto_Traslados.Observaciones = txtObservaciones.Text

        ' Guardar lo del detalle
        Dim Ppto_TrasladosList As List(Of Ppto_Traslados_DetalleBrl) = Session("Ppto_Traslados_Detalle")

        objPpto_Traslados.Ppto_Traslados_Detalle = Ppto_TrasladosList
        objPpto_Traslados.Guardar()

        Return objPpto_Traslados.ID

    End Function

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Dim objPpto_Traslados As Ppto_TrasladosBrl
        Try
            If Request.QueryString.Item("Editar") = 1 Then
                objPpto_Traslados = Ppto_TrasladosBrl.CargarPorID(Request.QueryString.Item("ID"))

                For Each fila As Ppto_Traslados_DetalleBrl In objPpto_Traslados.Ppto_Traslados_Detalle
                    fila.Eliminar()
                Next
                objPpto_Traslados = Ppto_TrasladosBrl.CargarPorID(Request.QueryString.Item("ID"))
                objPpto_Traslados.Eliminar()
                Response.Redirect("Ppto_Traslados.aspx?Mensaje=1")
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
        Response.Redirect("../webforms/Ppto_TrasladosList.aspx")
    End Sub

    Protected Sub btn_nuevo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_nuevo.Click
        Response.Redirect("../webforms/Ppto_Traslados.aspx")
    End Sub

    Protected Sub btn_actualizar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_actualizar.Click
        If Request.QueryString.Item("Id") > 0 Then
            Response.Redirect("../webforms/Ppto_Traslados.aspx?Editar=1&Id=" + Request.QueryString.Item("Id"))
        Else
            btn_nuevo_Click(sender, e)
        End If
    End Sub

    Protected Sub btn_limpiar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        RadComboBox2.SelectedValue = 0
        txtValor_COP.Text = ""
        txtValor_USD.Text = ""
        txtTRM.Text = ""
        lbl_IdDetalle.Text = ""
        lbl_rubro.Text = ""
        Dim tree As RadTreeView = DirectCast(RadComboBox1.Items(0).FindControl("RadTreeView2"), RadTreeView)

        '      tree.SelectedNode.CollapseParentNodes()
        tree.SelectedNode.Selected = False
        tree.CollapseAllNodes()
        RadComboBox1.Text = Nothing
        SetFocus(RadComboBox2)
    End Sub

    Protected Sub btn_cargar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cargar.Click
        Validate("DETALLE")
        If Not IsValid Then Exit Sub

        Dim Ppto_TrasladosList As List(Of Ppto_Traslados_DetalleBrl) = Session("Ppto_Traslados_Detalle")
        Dim Objppto_Traslado_Detalle As New Ppto_Traslados_DetalleBrl

        If lbl_IdDetalle.Text = "" Then
            Objppto_Traslado_Detalle = New Ppto_Traslados_DetalleBrl
            Objppto_Traslado_Detalle.Fecha_Creacion = Now
            Objppto_Traslado_Detalle.Id_Usuario_Creacion = CType(Master.FindControl("lblidusuario"), Label).Text
        Else
            Objppto_Traslado_Detalle = Ppto_TrasladosList.Item(lbl_IdDetalle.Text)
            Objppto_Traslado_Detalle.Fecha_Modificacion = Now
            Objppto_Traslado_Detalle.Id_Usuario_Modificacion = CType(Master.FindControl("lblidusuario"), Label).Text
        End If

        Dim tree As RadTreeView = DirectCast(RadComboBox1.Items(0).FindControl("RadTreeView2"), RadTreeView)
        Objppto_Traslado_Detalle.Id_Nivel_Entra = tree.SelectedNode.Value

        Objppto_Traslado_Detalle.Valor_COP = CType(txtValor_COP.Text, Double)
        Objppto_Traslado_Detalle.Valor_USD = CType(txtValor_USD.Text, Double)
        Objppto_Traslado_Detalle.TRM = CType(txtTRM.Text, Double)

        If lbl_IdDetalle.Text = "" Then
            Ppto_TrasladosList.Add(Objppto_Traslado_Detalle)
        End If

        Session("Ppto_Traslados_Detalle") = Ppto_TrasladosList
        Rg_DetalleTraslado.DataSource = Session("Ppto_Traslados_Detalle")
        Rg_DetalleTraslado.DataBind()
        btn_limpiar_Click(Nothing, Nothing)

    End Sub

    Protected Sub Rg_DetalleTraslado_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles Rg_DetalleTraslado.NeedDataSource
        Rg_DetalleTraslado.DataSource = Session("Ppto_Traslados_Detalle")
    End Sub

    Public Sub subCommandItem(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles Rg_DetalleTraslado.ItemCommand
        Select Case e.CommandName
            Case "Delete"
                subDelete(sender, e)
            Case "Editar"
                subEditar(sender, e)
        End Select

    End Sub

    Public Sub subDelete(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs)
        Dim item As GridDataItem = DirectCast(e.Item, GridDataItem)
        Dim id As String = item.GetDataKeyValue("Id").ToString()

        Dim Ppto_TrasladosList As List(Of Ppto_Traslados_DetalleBrl) = Session("Ppto_Traslados_Detalle")
        Ppto_TrasladosList.RemoveAt(item.ItemIndex)
        If id <> 0 Then
            Dim ObjPpto_TrasladoDetalle As Ppto_Traslados_DetalleBrl = Ppto_Traslados_DetalleBrl.CargarPorID(id)
            ObjPpto_TrasladoDetalle.Eliminar()
            Session("Ppto_Traslados_Detalle") = Ppto_TrasladosList
            Rg_DetalleTraslado.DataSource = Session("Ppto_Traslados_Detalle")
        End If

        Rg_DetalleTraslado.Rebind()
    End Sub

    Public Sub subEditar(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs)
        Dim item As GridDataItem = DirectCast(e.Item, GridDataItem)
        Dim ObjPpto_Traslados As Ppto_Traslados_DetalleBrl = CType(Session("Ppto_Traslados_Detalle"), List(Of Ppto_Traslados_DetalleBrl)).Item(item.ItemIndex)

        Dim radtree2 As RadTreeView
        radtree2 = Me.RadComboBox1.Items(0).FindControl("RadTreeView2")
        Dim node As RadTreeNode = radtree2.FindNodeByValue(ObjPpto_Traslados.Id_Nivel_Entra)
        If node IsNot Nothing Then
            node.Selected = True
            node.ExpandParentNodes()
            Me.RadComboBox1.Text = node.Text
            ddl_nivel_entra_SelectedIndexChanged(Nothing, Nothing)
        End If

        lbl_IdDetalle.Text = item.ItemIndex
        txtValor_USD.Text = Format(ObjPpto_Traslados.Valor_USD, "C")
        txtTRM.Text = Format(ObjPpto_Traslados.TRM, "C")
        txtValor_COP.Text = Format(ObjPpto_Traslados.Valor_COP, "C")
    End Sub

    Protected Sub ddl_Nivel_SelectedIndexChanged(ByVal sender As Object, ByVal e As RadTreeNodeEventArgs)
        lbl_cantidad.Text = "Asignado : $0"
        Dim tree As RadTreeView = DirectCast(RadComboBox2.Items(0).FindControl("RadTreeView1"), RadTreeView)
        If tree.SelectedNode.Value > 0 Then
            Dim objnivel As SubTablasBrl = SubTablasBrl.CargarPorID(tree.SelectedNode.Value)
            lbl_cantidad.Text = "Asignado : " & Format(objnivel.CantidadDistribucion, "N")
        End If
    End Sub

    Protected Sub ddl_nivel_entra_SelectedIndexChanged(ByVal sender As Object, ByVal e As RadTreeNodeEventArgs)
        Dim tree As RadTreeView = DirectCast(RadComboBox1.Items(0).FindControl("RadTreeView2"), RadTreeView)
        If tree.SelectedNode.Value > 0 Then
            lbl_rubro.Text = SubTablasBrl.CargarPorID(tree.SelectedNode.Value).Descripcion_PadreHijo
        End If
    End Sub

    Protected Sub txtValor_USD_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtValor_USD.TextChanged
        Try
            txtValor_COP.Text = Format((CType(txtTRM.Text, Double) * CType(txtValor_USD.Text, Double)), "C")
        Catch ex As Exception
            txtValor_COP.Text = "0"
        End Try
        txtValor_USD.Text = Format(CType(txtValor_USD.Text, Double), "C")

    End Sub

    Protected Sub txtTRM_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTRM.TextChanged
        Try
            txtValor_COP.Text = Format((CType(txtTRM.Text, Double) * CType(txtValor_USD.Text, Double)), "C")
        Catch ex As Exception
            txtValor_COP.Text = "0"
        End Try
        txtTRM.Text = Format(CType(txtTRM.Text, Double), "C")
    End Sub

    Protected Sub txtValor_COP_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtValor_COP.TextChanged
        Try
            txtValor_USD.Text = Format((CType(txtValor_COP.Text, Double) / CType(txtTRM.Text, Double)), "C")
        Catch ex As Exception
            txtValor_USD.Text = "0"
        End Try
        txtValor_COP.Text = Format(CType(txtValor_COP.Text, Double), "C")
    End Sub

    Protected Sub Rg_DetalleTraslado_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles Rg_DetalleTraslado.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim rg_detalle As RadGrid = DirectCast(e.Item.Parent.Parent.Parent, RadGrid)
            rg_detalle.Columns(5).Visible = chb_editar.Checked
            rg_detalle.Columns(6).Visible = chb_eliminar.Checked
        End If
    End Sub

End Class
