Imports System.Collections.Generic
Imports ingNovar.Utilidades2
Imports Especiales
Imports Telerik.Web.UI

Partial Class Webforms_OrdenCompraAprobarList
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

        '
        ' esta validacion  es especial por que utilizo la pagina para varias aprobaciones.
        '
        ' Pagina
        '
        Dim wpagina As String = Request.FilePath
        If Request.QueryString.Item("TA") > 0 Then
            wpagina += "?TA=" + Request.QueryString.Item("TA").Trim
        End If

        Dim objpagina As SeguridadUsuarios.PaginasBrl
        objpagina = SeguridadUsuarios.PaginasBrl.CargarPorURL(wpagina)
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
            btn_buscar.Enabled = objper_perfil.Pconsultar
            btn_aprobar.Enabled = objper_perfil.Pcrear
            Rg_Listado.MasterTableView.CommandItemSettings.ShowExportToCsvButton = objper_perfil.Pexportarcsv
            Rg_Listado.MasterTableView.CommandItemSettings.ShowExportToExcelButton = objper_perfil.Pexportarexcel
            Rg_Listado.MasterTableView.CommandItemSettings.ShowExportToPdfButton = objper_perfil.Pexportarpdf
            Rg_Listado.MasterTableView.CommandItemSettings.ShowExportToWordButton = objper_perfil.Pexportarword
            ddl_regional.Enabled = objper_perfil.Pvertodo
        End If

        If objper_usuario IsNot Nothing Then
            If objper_usuario.Pver = False Or objper_usuario.Pconsultar = False Then
                Response.Redirect(strPaginaError)
                Exit Sub
            End If

            ' asignando los permisos

            btn_buscar.Enabled = objper_usuario.Pconsultar
            btn_aprobar.Enabled = objper_usuario.Pcrear
            Rg_Listado.MasterTableView.CommandItemSettings.ShowExportToCsvButton = objper_usuario.Pexportarcsv
            Rg_Listado.MasterTableView.CommandItemSettings.ShowExportToExcelButton = objper_usuario.Pexportarexcel
            Rg_Listado.MasterTableView.CommandItemSettings.ShowExportToPdfButton = objper_usuario.Pexportarpdf
            Rg_Listado.MasterTableView.CommandItemSettings.ShowExportToWordButton = objper_usuario.Pexportarword
            ddl_regional.Enabled = objper_usuario.Pvertodo
        End If

        ' Definiendo el dato de la regional
        ddl_regional.SelectedValue = SeguridadUsuarios.Usuarios.RegionalUsuario(CType(Session("IdUsuario"), Integer))

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

        Dim ListOrdenCompra As List(Of OrdenCompraBrl) = Session("ListOrdenCompraAprobar")

        BindHelper.Ppto_TercerosUIL.BindToListControl(ddl_Terceros, New ListItem("Seleccione", 0))
        BindHelper.SubTablasUIL.BindToListControlPorId_Tabla(ddl_regional, 72, New ListItem("Seleccione", 0))
        BindHelper.SubTablasUIL.BindToListControlPorId_Tabla(ddl_Productos, 32, New ListItem("Seleccione", 0))

        'si no hay una variable de sesión con la lista.
        If ListOrdenCompra Is Nothing Or Request.QueryString.Item("Refrescar") = 1 Then

            Dim wfechainicio As String = ""
            Dim wfechafinal As String = ""
            If rdpFechaInicial.SelectedDate.ToString.Trim <> "" Then
                wfechainicio = ajustarFecha10digitos(rdpFechaInicial.SelectedDate)
            End If
            If rdpfechaFinal.SelectedDate.ToString.Trim <> "" Then
                wfechafinal = ajustarFecha10digitos(rdpfechaFinal.SelectedDate)
            End If

            Select Case Request.QueryString.Item("TA")  '' Tipo de Aprobacion
                Case Is = 1
                    ListOrdenCompra = OrdenCompraBrl.CargarPorAprobarLogOfc(txt_numero.Text, ddl_Terceros.SelectedValue, ddl_regional.SelectedValue, wfechainicio, wfechafinal, Session("Id_Proyecto"))
                Case Is = 2
                    ListOrdenCompra = OrdenCompraBrl.CargarPorAprobarFinOfc(txt_numero.Text, ddl_Terceros.SelectedValue, ddl_regional.SelectedValue, wfechainicio, wfechafinal, Session("Id_Proyecto"))
                Case Is = 3
                    ListOrdenCompra = OrdenCompraBrl.CargarPorAprobarCooReg(txt_numero.Text, ddl_Terceros.SelectedValue, ddl_regional.SelectedValue, wfechainicio, wfechafinal, Session("Id_Proyecto"))
                Case Is = 4
                    ListOrdenCompra = OrdenCompraBrl.CargarPorAprobarDirOpe(txt_numero.Text, ddl_Terceros.SelectedValue, ddl_regional.SelectedValue, wfechainicio, wfechafinal, Session("Id_Proyecto"))
                Case Is = 5
                    ListOrdenCompra = OrdenCompraBrl.CargarPorAprobarDirFin(txt_numero.Text, ddl_Terceros.SelectedValue, ddl_regional.SelectedValue, wfechainicio, wfechafinal, Session("Id_Proyecto"))
                Case Is = 6
                    ListOrdenCompra = OrdenCompraBrl.CargarPorAprobarCooLog(txt_numero.Text, ddl_Terceros.SelectedValue, ddl_regional.SelectedValue, wfechainicio, wfechafinal, Session("Id_Proyecto"))

                Case Else
                    ListOrdenCompra = OrdenCompraBrl.CargarTodos(Session("Id_Proyecto"))
            End Select
            Session("ListOrdenCompraAprobar") = ListOrdenCompra
        End If

        Rg_Listado.DataSource = Session("ListOrdenCompraAprobar")
        Rg_Listado.DataBind()

    End Sub

    Protected Sub Rg_Listado_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles Rg_Listado.NeedDataSource
        Rg_Listado.DataSource = Session("ListOrdenCompraAprobar")
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

    Protected Sub btn_aprobar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_aprobar.Click
        For Each fila As Telerik.Web.UI.GridItem In Rg_Listado.Items
            Dim chk_aprobar As CheckBox
            Dim lblid As Label
            chk_aprobar = fila.FindControl("chk_aprobar")
            If chk_aprobar.Checked Then
                Try
                    lblid = fila.FindControl("lblid")
                    Dim objordencompra As OrdenCompraBrl = OrdenCompraBrl.CargarPorID(lblid.Text)
                    Select Case Request.QueryString.Item("TA")
                        Case Is = 1
                            objordencompra.Aprobacion_Logistica_Ofc = True
                        Case Is = 2
                            objordencompra.Aprobacion_Finanzas_Ofc = True
                        Case Is = 3
                            objordencompra.Aprobacion_Coordinacion = True
                        Case Is = 4
                            objordencompra.Aprobacion_Operaciones = True
                        Case Is = 5
                            objordencompra.Aprobacion_Financiera = True
                        Case Is = 6
                            objordencompra.Aprobacion_CooLogistica = True
                    End Select
                    objordencompra.Guardar()
                Catch ex As Exception
                End Try
            End If
        Next
        imb_buscar_Click(Nothing, Nothing)
    End Sub

    Protected Sub imb_buscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imb_buscar.Click
        Dim ListOrdenCompra As New List(Of OrdenCompraBrl)
        Dim wfechainicio As String = ""
        Dim wfechafinal As String = ""
        If rdpFechaInicial.SelectedDate.ToString.Trim <> "" Then
            wfechainicio = ajustarFecha10digitos(rdpFechaInicial.SelectedDate)
        End If
        If rdpfechaFinal.SelectedDate.ToString.Trim <> "" Then
            wfechafinal = ajustarFecha10digitos(rdpfechaFinal.SelectedDate)
        End If

        Select Case Request.QueryString.Item("TA")
            Case Is = 1
                ListOrdenCompra = OrdenCompraBrl.CargarPorAprobarLogOfc(txt_numero.Text, ddl_Terceros.SelectedValue, ddl_regional.SelectedValue, wfechainicio, wfechafinal, Session("Id_Proyecto"))
            Case Is = 2
                ListOrdenCompra = OrdenCompraBrl.CargarPorAprobarFinOfc(txt_numero.Text, ddl_Terceros.SelectedValue, ddl_regional.SelectedValue, wfechainicio, wfechafinal, Session("Id_Proyecto"))
            Case Is = 3
                ListOrdenCompra = OrdenCompraBrl.CargarPorAprobarCooReg(txt_numero.Text, ddl_Terceros.SelectedValue, ddl_regional.SelectedValue, wfechainicio, wfechafinal, Session("Id_Proyecto"))
            Case Is = 4
                ListOrdenCompra = OrdenCompraBrl.CargarPorAprobarDirOpe(txt_numero.Text, ddl_Terceros.SelectedValue, ddl_regional.SelectedValue, wfechainicio, wfechafinal, Session("Id_Proyecto"))
            Case Is = 5
                ListOrdenCompra = OrdenCompraBrl.CargarPorAprobarDirFin(txt_numero.Text, ddl_Terceros.SelectedValue, ddl_regional.SelectedValue, wfechainicio, wfechafinal, Session("Id_Proyecto"))
            Case Is = 6
                ListOrdenCompra = OrdenCompraBrl.CargarPorAprobarCooLog(txt_numero.Text, ddl_Terceros.SelectedValue, ddl_regional.SelectedValue, wfechainicio, wfechafinal, Session("Id_Proyecto"))
            Case Else
                ListOrdenCompra = OrdenCompraBrl.CargarTodos(Session("Id_Proyecto"))
        End Select
        Session("ListOrdenCompraAprobar") = ListOrdenCompra

        Rg_Listado.DataSource = Session("ListOrdenCompraAprobar")
        Rg_Listado.DataBind()
    End Sub

    Protected Sub Rg_Listado_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Rg_Listado.SelectedIndexChanged
        Dim item As Telerik.Web.UI.GridDataItem = Me.Rg_Listado.SelectedItems.Item(Rg_Listado.SelectedIndexes.Item(0))
        Response.Redirect("OrdenCompraSaldos.aspx?Refrescar=1&ID=" + item("id").Text + "&Envio=2&TA=" & Request.QueryString.Item("TA"))
    End Sub

    Protected Sub btn_actualizar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_actualizar.Click
        Response.Redirect("OrdencompraAprobarList.aspx?Refrescar=1&TA=" + Request.QueryString.Item("TA"))
    End Sub

    Protected Sub imb_todos_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imb_todos.Click
        txt_numero.Text = ""
        ddl_regional.SelectedValue = SeguridadUsuarios.Usuarios.RegionalUsuario(CType(Session("IdUsuario"), Integer))
        rdpFechaInicial.SelectedDate = Nothing
        rdpfechaFinal.SelectedDate = Nothing
        ddl_Terceros.SelectedValue = 0
        ddl_Productos.SelectedValue = 0
    End Sub

End Class
