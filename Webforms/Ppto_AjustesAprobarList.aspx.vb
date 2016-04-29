Imports System.Data
Imports System.Collections.Generic
Imports ingNovar.Utilidades2
Imports Especiales

Partial Class Webforms_Ppto_AjustesAprobarList
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

            btn_aprobar.Enabled = objper_perfil.Pcrear
            btn_buscar.Enabled = objper_perfil.Pconsultar
            Rg_Listado.MasterTableView.CommandItemSettings.ShowExportToCsvButton = objper_perfil.Pexportarcsv
            Rg_Listado.MasterTableView.CommandItemSettings.ShowExportToExcelButton = objper_perfil.Pexportarexcel
            Rg_Listado.MasterTableView.CommandItemSettings.ShowExportToPdfButton = objper_perfil.Pexportarpdf
            Rg_Listado.MasterTableView.CommandItemSettings.ShowExportToWordButton = objper_perfil.Pexportarword
        End If

        If objper_usuario IsNot Nothing Then
            If objper_usuario.Pver = False Or objper_usuario.Pconsultar = False Then
                Response.Redirect(strPaginaError)
                Exit Sub
            End If

            ' asignando los permisos

            btn_aprobar.Enabled = objper_usuario.Pcrear
            btn_buscar.Enabled = objper_usuario.Pconsultar
            Rg_Listado.MasterTableView.CommandItemSettings.ShowExportToCsvButton = objper_usuario.Pexportarcsv
            Rg_Listado.MasterTableView.CommandItemSettings.ShowExportToExcelButton = objper_usuario.Pexportarexcel
            Rg_Listado.MasterTableView.CommandItemSettings.ShowExportToPdfButton = objper_usuario.Pexportarpdf
            Rg_Listado.MasterTableView.CommandItemSettings.ShowExportToWordButton = objper_usuario.Pexportarword
        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Me.IsPostBack Then Exit Sub
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

        BindHelper.Ppto_ContratosUIL.BindToListControl(Ddl_Contratos, Session("Id_Proyecto"), New ListItem("Seleccione", "0"))
        BindHelper.OrdenCompraUIL.BindToListControl(ddl_Ordenes, Session("Id_Proyecto"), New ListItem("Seleccione", "0"))


        Dim ListPpto_AjustesAprobar As List(Of Ppto_AjustesBrl) = Session("ListPpto_AjustesAprobar")

        'si no hay una variable de sesión con la lista.
        If ListPpto_AjustesAprobar Is Nothing Or Request.QueryString.Item("Refrescar") = 1 Then
            ListPpto_AjustesAprobar = Ppto_AjustesBrl.CargarPorId_Contrato(0)
            Session("ListPpto_AjustesAprobar") = ListPpto_AjustesAprobar
        End If

        Rg_Listado.DataSource = Session("ListPpto_AjustesAprobar")
        Rg_Listado.DataBind()


    End Sub

    Protected Sub Rg_Listado_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Rg_Listado.SelectedIndexChanged
        Dim item As Telerik.Web.UI.GridDataItem = Me.Rg_Listado.SelectedItems.Item(Rg_Listado.SelectedIndexes.Item(0))
        Response.Redirect("Ppto_Ajustes.aspx?Editar=2&Refrescar=1&ID=" & item("id").Text)
    End Sub

    Protected Sub Rg_Listado_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles Rg_Listado.NeedDataSource
        Rg_Listado.DataSource = Session("ListPpto_AjustesAprobar")
    End Sub

    Protected Sub btn_home_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_home.Click
        Response.Redirect("../webforms/principal.aspx")
    End Sub

    Protected Sub btn_cerrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_cerrar.Click
        Response.Redirect("../webforms/principal.aspx")
    End Sub

    Protected Sub btn_buscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_buscar.Click
        If pnl_buscar.Visible Then
            pnl_buscar.Visible = False
            btn_buscar.ImageUrl = "~/Images/Zoom In.jpg"
        Else
            pnl_buscar.Visible = True
            btn_buscar.ImageUrl = "~/Images/Zoom Out.jpg"
        End If
    End Sub

    Protected Sub btn_actualizar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_actualizar.Click
        Response.Redirect("../webforms/Ppto_AjustesAprobarList.aspx?Refrescar=1")
    End Sub

    Protected Sub btn_limpiar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limpiar.Click
        rdpFechaInicial.SelectedDate = Nothing
        rdpfechaFinal.SelectedDate = Nothing
        Ddl_Contratos.SelectedValue = 0
        rdb_Tipo.SelectedValue = -1
        ddl_Ordenes.SelectedValue = 0
        SetFocus(rdpFechaInicial)
    End Sub

    Protected Sub btn_Procesar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_Procesar.Click

        Dim ListPpto_AjustesAprobar As List(Of Ppto_AjustesBrl)

        Dim wfechainicio As String = ""
        Dim wfechafinal As String = ""
        If rdpFechaInicial.SelectedDate.ToString.Trim <> "" Then
            wfechainicio = ajustarFecha10digitos(rdpFechaInicial.SelectedDate)
        End If
        If rdpfechaFinal.SelectedDate.ToString.Trim <> "" Then
            wfechafinal = ajustarFecha10digitos(rdpfechaFinal.SelectedDate)
        End If

        ListPpto_AjustesAprobar = Ppto_AjustesBrl.CargarPorBusqueda(wfechainicio, wfechafinal, rdb_Tipo.SelectedValue, Ddl_Contratos.SelectedValue, ddl_Ordenes.SelectedValue, Session("Id_Proyecto"))
        Session("ListPpto_AjustesAprobar") = ListPpto_AjustesAprobar
        Rg_Listado.DataSource = Session("ListPpto_AjustesAprobar")
        Rg_Listado.DataBind()

    End Sub

    Protected Sub btn_aprobar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_aprobar.Click
        For Each fila As Telerik.Web.UI.GridItem In Rg_Listado.Items
            Dim chk_aprobar As CheckBox
            Dim lblid As Label
            chk_aprobar = fila.FindControl("chk_aprobar")
            If chk_aprobar.Checked Then
                Try
                    lblid = fila.FindControl("lblid")
                    Dim objajuste As Ppto_AjustesBrl = Ppto_AjustesBrl.CargarPorID(lblid.Text)
                    objajuste.Aprobado_DirFin = True
                    objajuste.Guardar()
                Catch ex As Exception
                End Try
            End If
        Next
        btn_Procesar_Click(Nothing, Nothing)
    End Sub

    Protected Sub Rg_Listado_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles Rg_Listado.ItemDataBound
        If e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Or e.Item.ItemType = Telerik.Web.UI.GridItemType.Item Then
            Dim chk_aprobar As CheckBox
            chk_aprobar = e.Item.FindControl("chk_aprobar")
            If chk_aprobar.Checked Then chk_aprobar.Enabled = False
        End If
    End Sub


End Class
