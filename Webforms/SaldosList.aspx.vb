Imports System.Collections.Generic
Imports ingNovar.Utilidades2
Imports Especiales
Imports System.Reflection
Imports Telerik.Web.UI

Partial Class Webforms_SaldosList
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


        Dim ListSaldos As List(Of Tmp_PresupuestoBrl) = Session("ListSaldos")

        'si no hay una variable de sesión con la lista.
        If ListSaldos Is Nothing Or Request.QueryString.Item("Refrescar") = 1 Then
            Tmp_PresupuestoDAL.CargarPresupuesto()
            ListSaldos = Tmp_PresupuestoBrl.CargarPorId_padre(0)
            Session("ListSaldos") = ListSaldos
        End If

        Rg_Listado.DataSource = Session("ListSaldos")
        Rg_Listado.DataBind()
    End Sub

    Protected Sub Rg_Listado_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles Rg_Listado.NeedDataSource
        Rg_Listado.DataSource = Session("ListSaldos")
    End Sub

    Protected Sub btn_home_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_home.Click
        Response.Redirect("../webforms/principal.aspx")
    End Sub

    Protected Sub btn_cerrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_cerrar.Click
        Session.Remove("ListSaldos")
        Response.Redirect("../webforms/principal.aspx")
    End Sub

    Protected Sub btn_actualizar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_actualizar.Click
        Response.Redirect("../webforms/SaldosList.aspx?Refrescar=1")
    End Sub

    Protected Sub RadGrid1_DetailTableDataBind(ByVal source As Object, ByVal e As GridDetailTableDataBindEventArgs) Handles Rg_Listado.DetailTableDataBind
        Dim dataItem As GridDataItem = CType(e.DetailTableView.ParentItem, GridDataItem)
        Select Case e.DetailTableView.Name
            Case "Nivel02"
                Dim IDNivel01 As String = dataItem.GetDataKeyValue("ID").ToString()
                Dim objnivel02 As List(Of Tmp_PresupuestoBrl) = Tmp_PresupuestoBrl.CargarPorId_padre(IDNivel01)
                e.DetailTableView.DataSource = objnivel02
            Case "Nivel03"
                Dim IDNivel02 As String = dataItem.GetDataKeyValue("ID").ToString()
                Dim objnivel03 As List(Of Tmp_PresupuestoBrl) = Tmp_PresupuestoBrl.CargarPorId_padre(IDNivel02)
                e.DetailTableView.DataSource = objnivel03
            Case "Nivel04"
                Dim IDNivel03 As String = dataItem.GetDataKeyValue("ID").ToString()
                Dim objnivel04 As List(Of Tmp_PresupuestoBrl) = Tmp_PresupuestoBrl.CargarPorId_padre(IDNivel03)
                e.DetailTableView.DataSource = objnivel04
            Case "Nivel05"
                Dim IDNivel04 As String = dataItem.GetDataKeyValue("ID").ToString()
                Dim objnivel05 As List(Of Tmp_PresupuestoBrl) = Tmp_PresupuestoBrl.CargarPorId_padre(IDNivel04)
                e.DetailTableView.DataSource = objnivel05
        End Select
    End Sub

End Class
