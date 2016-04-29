Imports ingNovar.Utilidades2
Imports System.Collections.Generic

Partial Class Webforms_OrdenCompra
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
        '
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

            ' asignando los permisos

            lnk_Nuevo.Enabled = objper_perfil.Pcrear
            Rg_Listado.MasterTableView.CommandItemSettings.ShowExportToCsvButton = objper_perfil.Pexportarcsv
            Rg_Listado.MasterTableView.CommandItemSettings.ShowExportToExcelButton = objper_perfil.Pexportarexcel
            Rg_Listado.MasterTableView.CommandItemSettings.ShowExportToPdfButton = objper_perfil.Pexportarpdf
            Rg_Listado.MasterTableView.CommandItemSettings.ShowExportToWordButton = objper_perfil.Pexportarword
            ddl_Regional.Enabled = objper_perfil.Pvertodo
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
            '
            lnk_Nuevo.Enabled = objper_usuario.Pcrear
            Rg_Listado.MasterTableView.CommandItemSettings.ShowExportToCsvButton = objper_usuario.Pexportarcsv
            Rg_Listado.MasterTableView.CommandItemSettings.ShowExportToExcelButton = objper_usuario.Pexportarexcel
            Rg_Listado.MasterTableView.CommandItemSettings.ShowExportToPdfButton = objper_usuario.Pexportarpdf
            Rg_Listado.MasterTableView.CommandItemSettings.ShowExportToWordButton = objper_usuario.Pexportarword
            ddl_Regional.Enabled = objper_usuario.Pvertodo
        End If

        ' Definiendo el dato de la regional
        ddl_Regional.SelectedValue = SeguridadUsuarios.Usuarios.RegionalUsuario(CType(Session("IdUsuario"), Integer))

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

        BindHelper.SubTablasUIL.BindToListControlPorId_Tabla(ddl_Regional, 72, New ListItem("Seleccione", 0))
        BindHelper.Ppto_TercerosUIL.BindToListControl(ddl_Terceros, New ListItem("Seleccione", 0))
        BindHelper.SubTablasUIL.BindToListControlPorId_Tabla(ddl_TipoOrden, 84, New ListItem("Seleccione", 0))
        BindHelper.SubTablasUIL.BindToListControlPorId_Tabla(ddl_Conceptos, 85, New ListItem("Seleccione", 0))
        BindHelper.SubTablasUIL.BindToListControlPorId_Tabla(ddl_Solicitado_Operaciones, 4, New ListItem("Seleccione", 0))
        '
        ' Botones de Habilitar enabled 
        '
        ddlRegional_SelectedIndexChanged(Nothing, Nothing)
        lnk_Nuevo.Enabled = False
        btnGuardar.Enabled = True
        btnGuardarOtro.Enabled = True
        btnEliminar.Enabled = True
        btn_Guardar_Retencion.Enabled = False
        btn_limpiar.Enabled = True
        btn_Imprimir.Enabled = False

        Dim ListOrdenCompra_Detalle As List(Of OrdenCompra_DetalleBrl) = Session("ListOrdenCompra_Detalle")

        If Request.QueryString.Item("Refrescar") = 1 Then
            Dim objOrdenCompra As OrdenCompraBrl = OrdenCompraBrl.CargarPorID(Request.QueryString.Item("ID"))

            If objOrdenCompra Is Nothing Then
                lblMensaje.Text = "Registro no existe"
                lblMensaje.Visible = True
                Exit Sub
            End If

            If ddl_Regional.Items.FindByValue(objOrdenCompra.Id_Regional) IsNot Nothing Then ddl_Regional.SelectedValue = objOrdenCompra.Id_Regional
            txtNumero.Text = objOrdenCompra.Numero
            rdpFecha.SelectedDate = objOrdenCompra.Fecha
            If ddl_Terceros.Items.FindByValue(objOrdenCompra.Id_Tercero) IsNot Nothing Then ddl_Terceros.SelectedValue = objOrdenCompra.Id_Tercero
            ddl_Terceros_SelectedIndexChanged(Nothing, Nothing)
            If ddl_TipoOrden.Items.FindByValue(objOrdenCompra.Id_Tipo_Orden) IsNot Nothing Then ddl_TipoOrden.SelectedValue = objOrdenCompra.Id_Tipo_Orden
            If ddl_Solicitado_Operaciones.Items.FindByValue(objOrdenCompra.Id_Solicitado_Operaciones) IsNot Nothing Then ddl_Solicitado_Operaciones.SelectedValue = objOrdenCompra.Id_Solicitado_Operaciones

            txtTiempo_Entrega.Text = objOrdenCompra.Tiempo_Entrega
            txtLugar_Entrega.Text = objOrdenCompra.Lugar_Entrega
            txtObservaciones.Text = objOrdenCompra.Observaciones
            Txt_tasa.Text = Format(objOrdenCompra.Tasa, "C")
            txt_Forma_pago.Text = objOrdenCompra.Forma_Pago
            chkAprobacion_Finanzas_Ofc.Checked = objOrdenCompra.Aprobacion_Finanzas_Ofc
            chkAprobacion_Logistica_Ofc.Checked = objOrdenCompra.Aprobacion_Logistica_Ofc
            chkAprobacion_Coordinacion.Checked = objOrdenCompra.Aprobacion_Coordinacion
            chkAprobacion_Operaciones.Checked = objOrdenCompra.Aprobacion_Operaciones
            chkAprobacion_CooLogistica.Checked = objOrdenCompra.Aprobacion_CooLogistica
            chkAprobacion_Financiera.Checked = objOrdenCompra.Aprobacion_Financiera

            '
            '

            'si no hay una variable de sesión con la lista.
            If ListOrdenCompra_Detalle Is Nothing Or Request.QueryString.Item("Refrescar") = 1 Then
                ListOrdenCompra_Detalle = objOrdenCompra.OrdenCompra_Detalle
                Session("ListOrdenCompra_Detalle") = ListOrdenCompra_Detalle
            End If

            ' cargando las retenciones
            cargarretenciones()

            If Request.QueryString.Item("Editar") = 0 Then
                btnGuardar.Enabled = False
                btnGuardarOtro.Enabled = False
                btnEliminar.Enabled = False
                btn_Guardar_Retencion.Enabled = False
                btn_limpiar.Enabled = False
            Else
                btn_Guardar_Retencion.Enabled = True
                lnk_Nuevo.Enabled = True
            End If
            btn_Imprimir.Enabled = True
        Else
            ListOrdenCompra_Detalle = New List(Of OrdenCompra_DetalleBrl)
            ListOrdenCompra_Detalle = OrdenCompra_DetalleBrl.CargarPorId_OrdenCompra(0)
            Session("ListOrdenCompra_Detalle") = ListOrdenCompra_Detalle
            rdpFecha.SelectedDate = Now

        End If

        Rg_Listado.DataSource = Session("ListOrdenCompra_Detalle")
        Rg_Listado.DataBind()
        ' cargue valor de Base
        Dim wvalorbase As Double = 0
        Try
            For Each fila As OrdenCompra_DetalleBrl In CType(Session("ListOrdenCompra_Detalle"), List(Of OrdenCompra_DetalleBrl))
                wvalorbase += fila.ValorProducto
            Next
            txt_base.Text = Format(wvalorbase, "C")
        Catch ex As Exception
            txt_base.Text = "0"
        End Try


    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Validate("OC")
        If Not IsValid Then Exit Sub

        Dim ID As Int32

        Try
            ID = Grabar()
            Response.Redirect("OrdenCompra.aspx?Editar=1&Refrescar=1&Mensaje=1&ID=" & ID)
        Catch ex As Exception
            lblMensaje.Text = ex.Message
            lblMensaje.Visible = True
        End Try

    End Sub

    Private Sub btnGuardarOtro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarOtro.Click
        Validate("OC")
        If Not IsValid Then Exit Sub

        Try
            Grabar()
            Response.Redirect("OrdenCompra.aspx?Editar=1&Mensaje=1")
        Catch ex As Exception
            lblMensaje.Text = ex.Message
            lblMensaje.Visible = True
        End Try

    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Session.Remove("OrdenCompra")
        If Request.QueryString.Item("TA") >= 1 Then
            Response.Redirect("OrdenCompraAprobarList.aspx?TA=" & Request.QueryString.Item("TA"))
        End If
        Response.Redirect("OrdenCompraList.aspx")
    End Sub

    Private Function Grabar() As Int32

        Dim objOrdenCompra As OrdenCompraBRL

        If Request.QueryString.Item("Refrescar") = 1 Then
            objOrdenCompra = OrdenCompraBrl.CargarPorID(Request.QueryString.Item("ID"))
            objOrdenCompra.Fecha_Modificacion = Now
            objOrdenCompra.Id_Usuario_Modificacion = CType(Master.FindControl("lblidusuario"), Label).Text
        Else
            objOrdenCompra = New OrdenCompraBrl
            objOrdenCompra.Fecha_Creacion = Now
            objOrdenCompra.Id_Usuario_Creacion = CType(Master.FindControl("lblidusuario"), Label).Text
            objOrdenCompra.Id_Proyecto = Session("Id_Proyecto")
        End If

        objOrdenCompra.Id_Regional = ddl_Regional.SelectedValue
        objOrdenCompra.Numero = txtNumero.Text
        objOrdenCompra.Fecha = rdpFecha.SelectedDate
        objOrdenCompra.Id_Tercero = ddl_Terceros.SelectedValue
        objOrdenCompra.Tiempo_Entrega = txtTiempo_Entrega.Text
        objOrdenCompra.Lugar_Entrega = txtLugar_Entrega.Text
        objOrdenCompra.Observaciones = txtObservaciones.Text
        objOrdenCompra.Forma_Pago = txt_Forma_pago.Text
        objOrdenCompra.Tasa = Txt_tasa.Text
        objOrdenCompra.Id_Solicitado_Operaciones = ddl_Solicitado_Operaciones.SelectedValue
        objOrdenCompra.Aprobacion_Finanzas_Ofc = chkAprobacion_Finanzas_Ofc.Checked
        objOrdenCompra.Aprobacion_Logistica_Ofc = chkAprobacion_Logistica_Ofc.Checked
        objOrdenCompra.Aprobacion_Coordinacion = chkAprobacion_Coordinacion.Checked
        objOrdenCompra.Aprobacion_Operaciones = chkAprobacion_Operaciones.Checked
        objOrdenCompra.Aprobacion_CooLogistica = chkAprobacion_CooLogistica.Checked
        objOrdenCompra.Id_Tipo_Orden = ddl_TipoOrden.SelectedValue

        objOrdenCompra.Guardar()

        lnk_Nuevo.Enabled = True
        Return objOrdenCompra.ID

    End Function

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Dim objOrdenCompra As OrdenCompraBrl

        Try
            If Request.QueryString.Item("Editar") = 1 Then
                objOrdenCompra = OrdenCompraBrl.CargarPorID(Request.QueryString.Item("ID"))
                objOrdenCompra.Eliminar()
                Response.Redirect("OrdenCompra.aspx?Mensaje=1")
            End If
        Catch ex As Exception
            lblMensaje.Text = ex.Message
            lblMensaje.Visible = True
        End Try

    End Sub

    Public Sub CambioPaginaRet(ByVal sender As Object, ByVal e As DataGridPageChangedEventArgs) Handles dg_Retenciones.PageIndexChanged
        dg_Retenciones.CurrentPageIndex = e.NewPageIndex
        dg_Retenciones.SelectedIndex = -1
        dg_Retenciones.DataSource = Session("ListaRetenciones")
        dg_Retenciones.DataBind()
    End Sub

    Protected Sub Rg_Listado_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Rg_Listado.SelectedIndexChanged
        Dim item As Telerik.Web.UI.GridDataItem = Me.Rg_Listado.SelectedItems.Item(Rg_Listado.SelectedIndexes.Item(0))
        Response.Redirect("OrdenCompra_Detalle.aspx?Editar=1&ID=" & item("Id").Text.Trim & "&OC=" + Request.QueryString.Item("Id"))
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
        Dim objdetalle As OrdenCompra_DetalleBrl = OrdenCompra_DetalleBrl.CargarPorID(lblId.Text)
        Try
            objdetalle.Eliminar()
            Response.Redirect("OrdenCompra.aspx?Editar=1&Refrescar=1&Id=" + Request.QueryString.Item("Id"))
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub lnk_Nuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnk_Nuevo.Click
        Response.Redirect("OrdenCompra_Detalle.aspx?OC=" + Request.QueryString.Item("Id"))
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_Guardar_Retencion.Click
        Validate("RET")
        If Not IsValid Then Exit Sub

        Dim objretencion As OrdenCompra_RetencionBrl
        If lbl_IdRet.Text = "" Then
            objretencion = New OrdenCompra_RetencionBrl
            objretencion.Id_OrdenCompra = Request.QueryString.Item("Id")
        Else
            objretencion = OrdenCompra_RetencionBrl.CargarPorID(lbl_IdRet.Text)
            If objretencion Is Nothing Then
                objretencion = New OrdenCompra_RetencionBrl
                objretencion.Id_OrdenCompra = Request.QueryString.Item("Id")
            End If
        End If


        objretencion.Porcentaje = txtPorcentaje_Retefuente.Text
        objretencion.Valor = txtValor_Retefuente.Text
        objretencion.Id_Concepto = ddl_Conceptos.SelectedValue
        objretencion.Base_Retencion = txt_base.Text
        objretencion.Guardar()

        cargarretenciones()
        btn_limpiar_Click(Nothing, Nothing)
    End Sub

    Protected Sub cargarretenciones()
        Dim Listretenciones As New List(Of OrdenCompra_RetencionBrl)
        Listretenciones = OrdenCompra_RetencionBrl.CargarPorId_OrdenCompra(Request.QueryString.Item("Id"))
        Session("ListaRetenciones") = Listretenciones
        dg_Retenciones.DataSource = Listretenciones
        dg_Retenciones.DataBind()

        '
        ' Sacando el valor de la factura
        '
        Dim wvalor As Double
        Dim objOrdenCompra As OrdenCompraBrl = OrdenCompraBrl.CargarPorID(Request.QueryString.Item("Id"))
        If objOrdenCompra Is Nothing Then wvalor = 0 Else wvalor = objOrdenCompra.ValorOrdenCompra - objOrdenCompra.ValorRetencionOrdenCompra

        Lbl_ValorFinal.Text = Format(wvalor, "C")


    End Sub

    Public Sub subCommandItemRet(ByVal sender As Object, ByVal e As DataGridCommandEventArgs)
        Select Case e.CommandName
            Case "Edit"
                subEditarRet(sender, e)
            Case "Eliminar"
                subEliminarRet(sender, e)
        End Select
    End Sub

    Public Sub subEditarRet(ByVal sender As Object, ByVal e As DataGridCommandEventArgs)
        Dim lblid As Label
        lblid = e.Item.FindControl("lblId")
        Dim objretencion As OrdenCompra_RetencionBrl = OrdenCompra_RetencionBrl.CargarPorID(lblid.Text)
        If ddl_Conceptos.Items.FindByValue(objretencion.Id_Concepto) IsNot Nothing Then ddl_Conceptos.SelectedValue = objretencion.Id_Concepto
        txtPorcentaje_Retefuente.Text = Format(objretencion.Porcentaje, "C")
        txt_base.Text = Format(objretencion.Base_Retencion, "C")
        txtValor_Retefuente.Text = Format(objretencion.Valor, "C")
        lbl_IdRet.Text = objretencion.ID
    End Sub

    Public Sub subEliminarRet(ByVal sender As Object, ByVal e As DataGridCommandEventArgs)
        lbl_IdRet = e.Item.FindControl("lblId")
        Dim objdetalle As OrdenCompra_RetencionBrl = OrdenCompra_RetencionBrl.CargarPorID(lbl_IdRet.Text)
        Try
            objdetalle.Eliminar()
            cargarretenciones()
        Catch ex As Exception
        End Try
        btn_limpiar_Click(Nothing, Nothing)
    End Sub

    Protected Sub btn_limpiar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        lbl_IdRet.Text = ""
        ddl_Conceptos.SelectedValue = 0
        txtPorcentaje_Retefuente.Text = ""
        txtValor_Retefuente.Text = ""
    End Sub

    Protected Sub dg_Retenciones_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dg_Retenciones.ItemDataBound
        If e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Then
            If Request.QueryString.Item("Editar") = 0 Then
                Dim btneliminarben As ImageButton
                btneliminarben = e.Item.FindControl("btneliminarben")
                btneliminarben.Visible = False

            End If
        End If
    End Sub

    Protected Sub Rg_Listado_NeedDataSource1(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles Rg_Listado.NeedDataSource
        Rg_Listado.DataSource = Session("ListOrdenCompra_Detalle")
    End Sub

    Protected Sub Rg_Listado_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles Rg_Listado.ItemDataBound
        If e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Or e.Item.ItemType = Telerik.Web.UI.GridItemType.Item Then
            If Request.QueryString.Item("Editar") = 0 Then
                Dim btneliminarben As ImageButton
                btneliminarben = e.Item.FindControl("btneliminarben")
                btneliminarben.Visible = False
            End If
        End If
    End Sub

    Protected Sub btn_home_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_home.Click
        Response.Redirect("../webforms/principal.aspx")
    End Sub

    Protected Sub btn_cerrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_cerrar.Click
        Response.Redirect("../webforms/OrdenCompraList.aspx")
    End Sub

    Protected Sub btn_nuevo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_nuevo.Click
        Session.Remove("ListOrdenCompra_Detalle")
        Response.Redirect("../webforms/OrdenCompra.aspx")
    End Sub

    Protected Sub btn_actualizar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_actualizar.Click
        If Request.QueryString.Item("Id") > 0 Then
            Response.Redirect("../webforms/OrdenCompra.aspx?Editar=1&Refrescar=1&Id=" + Request.QueryString.Item("Id"))
        Else
            btn_nuevo_Click(sender, e)
        End If
    End Sub

    Protected Sub btn_Imprimir_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_Imprimir.Click
        If Request.QueryString.Item("Refrescar") = 1 Then
            If txtNumero.Text <> "" Then
                Dim rpURL As String = "OrdenCompraReporte.aspx?No=" + txtNumero.Text
                ScriptManager.RegisterStartupScript(Page, GetType(Page), "Ventana", "<script language='JavaScript'> var ventana = window.open('" + rpURL + "','_reportes','toolbar=no,status=yes,menubar=no,location=no,scrollbars=yes,resizable=yes,width=900,height=600'); ventana.focus();</script>", False)
            End If
        End If
    End Sub

    Protected Sub txt_base_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_base.TextChanged
        Try
            txtValor_Retefuente.Text = Format(CType(txtPorcentaje_Retefuente.Text, Double) / 100 * CType(txt_base.Text, Double), "C")
        Catch ex As Exception
            txtValor_Retefuente.Text = "0"
        End Try
        SetFocus(txtPorcentaje_Retefuente)
    End Sub

    Protected Sub txtPorcentaje_Retefuente_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPorcentaje_Retefuente.TextChanged
        Try
            txtValor_Retefuente.Text = Format(CType(txtPorcentaje_Retefuente.Text, Double) / 100 * CType(txt_base.Text, Double), "C")
        Catch ex As Exception
            txtValor_Retefuente.Text = "0"
        End Try
        txtPorcentaje_Retefuente.Text = Format(CType(txtPorcentaje_Retefuente.Text, Double), "C")
    End Sub

    Protected Sub txt_codprv_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codprv.TextChanged
        If txt_codprv.Text <> "" Then
            Dim objtercero As List(Of Ppto_TercerosBrl) = Ppto_TercerosBrl.CargarPorNombreeIdentificacion(txt_codprv.Text)
            If objtercero.Count > 0 Then
                If ddl_Terceros.Items.FindByValue(objtercero.Item(0).ID) Is Nothing Then
                    lblMensaje.Text = "Código de tercero no Valido. Por Favor Verifique !!!"
                    lblMensaje.Visible = True
                    lblMensaje.ForeColor = Drawing.Color.Red
                    txt_codprv.Text = ""
                    txt_codprv.Focus()
                    ddl_Terceros.SelectedValue = 0
                Else
                    ddl_Terceros.SelectedValue = objtercero.Item(0).ID
                    SetFocus(txtLugar_Entrega)
                End If
            Else
                lblMensaje.Text = "Código de tercero no Valido. Por Favor Verifique !!!"
                lblMensaje.Visible = True
                lblMensaje.ForeColor = Drawing.Color.Red
                txt_codprv.Text = ""
                txt_codprv.Focus()
                ddl_Terceros.SelectedValue = 0
            End If
        Else
            ddl_Terceros.SelectedValue = 0
            txt_codprv.Focus()
        End If
    End Sub

    Protected Sub ddl_Terceros_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_Terceros.SelectedIndexChanged
        If ddl_Terceros.Text <> "" Then
            Dim objterceros As Ppto_TercerosBrl = Ppto_TercerosBrl.CargarPorID(ddl_Terceros.SelectedValue)
            If objterceros IsNot Nothing Then
                txt_codprv.Text = objterceros.Identificacion
            End If
        End If
    End Sub

    Protected Sub ddlRegional_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_Regional.SelectedIndexChanged
        If ddl_Regional.SelectedValue > 0 Then
            Try
                Dim objsucursal As SucursalesBrl = SucursalesBrl.CargarPorId_Enlace(ddl_Regional.SelectedValue).Item(0)
                txtObservaciones.Text = objsucursal.Texto_Financiero
                txtLugar_Entrega.Text = objsucursal.Direccion
            Catch ex As Exception
            End Try
        End If
    End Sub
End Class
