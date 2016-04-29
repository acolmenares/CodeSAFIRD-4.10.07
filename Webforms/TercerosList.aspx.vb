Imports System.Data
Imports System.Collections.Generic

Partial Class Webforms_TercerosList
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
            btn_buscar.Enabled = objper_perfil.Pconsultar
            ImgCargueTerceros.Enabled = objper_perfil.Pcrear
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
            btn_buscar.Enabled = objper_usuario.Pconsultar
            ImgCargueTerceros.Enabled = objper_usuario.Pcrear
            Rg_Listado.MasterTableView.CommandItemSettings.ShowExportToCsvButton = objper_usuario.Pexportarcsv
            Rg_Listado.MasterTableView.CommandItemSettings.ShowExportToExcelButton = objper_usuario.Pexportarexcel
            Rg_Listado.MasterTableView.CommandItemSettings.ShowExportToPdfButton = objper_usuario.Pexportarpdf
            Rg_Listado.MasterTableView.CommandItemSettings.ShowExportToWordButton = objper_usuario.Pexportarword
        End If

    End Sub

    Protected Sub ImgCargueTerceros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgCargueTerceros.Click
        Dim wrpta, wrpta1 As Integer
        If RUCargueTerceros.UploadedFiles.Count > 0 Then
            If RUCargueTerceros.UploadedFiles.Item(0).FileName <> "" Then
                Try
                    If RUCargueTerceros.UploadedFiles.Item(0).GetExtension.Trim.ToLower = ".txt" Then
                        ' Server.MapPath("~/Mantto/Upload/") &
                        wrpta = Ppto_TercerosDAL.CargueTerceros(Server.MapPath("~/Upload/") & RUCargueTerceros.UploadedFiles.Item(0).GetName)
                        If wrpta = 1 Then ' paso bien el cargue
                            wrpta1 = 0
                            If chk_actualizar.Checked Then
                                wrpta1 = 1
                            End If
                            Ppto_TercerosDAL.ProcesarDatosTerceros(wrpta1)

                            '
                            ' Proceso Realizado
                            '
                            Dim ListPpto_Terceros As List(Of Ppto_TercerosBrl)
                            ListPpto_Terceros = Ppto_TercerosBrl.CargarTodos
                            Session("ListPpto_Terceros") = ListPpto_Terceros
                            Rg_Listado.DataSource = Session("ListPpto_Terceros")
                            Rg_Listado.DataBind()
                            lblresultado.Text = "Cargue de información Completa."

                        End If
                    Else
                        lblresultado.Text = "Archivo en formato diferente."
                    End If
                Catch ex As Exception
                    lblresultado.Text = ex.Message
                End Try
            End If
        Else
            lblresultado.Text = "Seleccione un Archivo por favor "
        End If
        lblresultado.Visible = True
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

        Dim ListPpto_Terceros As List(Of Ppto_TercerosBrl) = Session("ListPpto_Terceros")

        'si no hay una variable de sesión con la lista.
        If ListPpto_Terceros Is Nothing Or Request.QueryString.Item("Refrescar") = 1 Then
            ListPpto_Terceros = Ppto_TercerosBrl.CargarTodos
            Session("ListPpto_Terceros") = ListPpto_Terceros
        End If

        Rg_Listado.DataSource = Session("ListPpto_Terceros")
        Rg_Listado.DataBind()

    End Sub

    Protected Sub Rg_Listado_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles Rg_Listado.NeedDataSource
        Rg_Listado.DataSource = Session("ListPpto_Terceros")
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
        Response.Redirect("../webforms/tercerosList.aspx?Refrescar=1")
    End Sub

    Protected Sub Rg_Listado_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Rg_Listado.SelectedIndexChanged
        Dim item As Telerik.Web.UI.GridDataItem = Me.Rg_Listado.SelectedItems.Item(Rg_Listado.SelectedIndexes.Item(0))
        lbl_nombre.Text = item("Razon_Social").Text
        lbl_Identificacion.Text = item("Identificacion").Text
        Lbl_Direccion.Text = item("Direccion").Text
        lbl_telefono1.Text = item("Telefono1").Text
        lbl_telefono2.Text = item("Telefono2").Text
        lbl_Nombre_Empresa.Text = item("Nombre_Empresa").Text
    End Sub

    Protected Sub btn_limpiar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limpiar.Click
        txt_nombre.Text = ""
        SetFocus(txt_nombre)
    End Sub

    Protected Sub btn_Procesar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_Procesar.Click
        Dim ListPpto_Terceros As List(Of Ppto_TercerosBrl)
        ListPpto_Terceros = Ppto_TercerosBrl.CargarPorNombreeIdentificacion(txt_nombre.Text)
        Session("ListPpto_Terceros") = ListPpto_Terceros
        Rg_Listado.DataSource = Session("ListPpto_Terceros")
        Rg_Listado.DataBind()

    End Sub

End Class
