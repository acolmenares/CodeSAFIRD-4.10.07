Imports Telerik.Web.UI
Imports System.Collections.Generic

Partial Class Webforms_NivelesList
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

        ' Asignando los permisos

        If objper_perfil IsNot Nothing Then
            btn_GrabarNivel.Enabled = objper_perfil.Pcrear
            Btn_GrabarArbol.Enabled = objper_perfil.Pcrear
            Btn_GrabarArbol.Enabled = objper_perfil.Peditar
            MainContextMenu.Items(0).Enabled = objper_perfil.Pcrear
            MainContextMenu.Items(1).Enabled = objper_perfil.Peditar
            MainContextMenu.Items(2).Enabled = objper_perfil.Peliminar

        End If

        If objper_usuario IsNot Nothing Then
            btn_GrabarNivel.Enabled = objper_usuario.Pcrear
            Btn_GrabarArbol.Enabled = objper_usuario.Pcrear
            Btn_GrabarArbol.Enabled = objper_usuario.Peditar
            MainContextMenu.Items(0).Enabled = objper_usuario.Pcrear
            MainContextMenu.Items(1).Enabled = objper_usuario.Peditar
            MainContextMenu.Items(2).Enabled = objper_usuario.Peliminar

        End If

    End Sub

    Private Shared Sub BindToDataSet(ByVal treeView As RadTreeView, ByVal ID_Proyecto As Int32)

        Dim NivelesList As List(Of SubTablasBrl) = SubTablasBrl.CargarPorNivelesPorProyecto(ID_Proyecto) ' Niveles
        treeView.DataTextField = "Descripcion"
        treeView.DataFieldID = "Id"
        treeView.DataFieldParentID = "Id_Padre"
        treeView.DataValueField = "Id"

        treeView.DataSource = NivelesList
        treeView.DataBind()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

        BindHelper.SubTablasUIL.BindTotalToListControlPorId_Tabla(ddl_niveles, Session("Id_Proyecto"), New ListItem("Seleccione", "0"))
        BindToDataSet(RTree_Niveles, Session("Id_Proyecto"))

    End Sub

    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_RecargarArbol.Click
        BindToDataSet(RTree_Niveles, Session("Id_Proyecto"))
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_LimpiarCampos.Click
        txt_nombre.Text = ""
        ddl_niveles.SelectedValue = 0
        SetFocus(txt_nombre)
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_GrabarNivel.Click
        Validate("NIVEL")
        If Not IsValid Then Exit Sub

        Dim objnivel As New SubTablasBrl
        objnivel.Descripcion = txt_nombre.Text
        objnivel.Id_Tabla = 82 '  Niveles
        objnivel.Id_Padre = ddl_niveles.SelectedValue
        objnivel.Id_Usuario_Creacion = CType(Master.FindControl("lblidusuario"), Label).Text
        objnivel.Fecha_Creacion = Now
        objnivel.Orden = Session("Id_Proyecto")
        objnivel.Activo = 1
        Try
            objnivel.Guardar()
            BindHelper.SubTablasUIL.BindToListControlPorId_Tabla(ddl_niveles, 82, New ListItem("Seleccione", "0"))
            Button2_Click(Nothing, Nothing)
            Button4_Click(Nothing, Nothing)

        Catch ex As Exception
        End Try
    End Sub

    Protected Sub HandleNodeEdit(ByVal sender As Object, ByVal e As RadTreeNodeEditEventArgs) Handles RTree_Niveles.NodeEdit
        Dim nodeEdited As RadTreeNode = e.Node
        Dim newText As String = e.Text
        nodeEdited.Text = newText
        '
        'Actualizando el valor en la tabla 
        '
        If nodeEdited.Value > 0 Then
            Dim objnivel As SubTablasBrl = SubTablasBrl.CargarPorID(nodeEdited.Value)
            objnivel.Descripcion = nodeEdited.Text
            objnivel.Id_Usuario_Modificacion = CType(Master.FindControl("lblidusuario"), Label).Text
            objnivel.Fecha_Modificacion = Now
            objnivel.Guardar()
            BindHelper.SubTablasUIL.BindTotalToListControlPorId_Tabla(ddl_niveles, 82, New ListItem("Seleccione", "0"))
        End If

    End Sub

    Protected Sub RTree_Niveles_ContextMenuItemClick(ByVal sender As Object, ByVal e As RadTreeViewContextMenuEventArgs) Handles RTree_Niveles.ContextMenuItemClick
        Dim clickedNode As RadTreeNode = e.Node

        Select Case e.MenuItem.Value
            Case "New"
                Dim newFolder As New RadTreeNode(String.Format("Nuevo Nivel", clickedNode.Nodes.Count + 1))
                newFolder.Selected = True
                newFolder.ImageUrl = clickedNode.ImageUrl
                clickedNode.Nodes.Add(newFolder)
                clickedNode.Expanded = True
                clickedNode.Font.Bold = True
                ' Grabando el nuevo nivel
                Dim objnivel As New SubTablasBrl
                objnivel.Descripcion = clickedNode.Text
                objnivel.Id_Tabla = 82 '  Niveles
                objnivel.Id_Padre = clickedNode.Value
                objnivel.Id_Usuario_Creacion = CType(Master.FindControl("lblidusuario"), Label).Text
                objnivel.Fecha_Creacion = Now
                objnivel.Orden = Session("Id_Proyecto")
                objnivel.Activo = 1
                Try
                    objnivel.Guardar()
                    newFolder.Value = objnivel.ID
                    BindHelper.SubTablasUIL.BindToListControlPorId_Tabla(ddl_niveles, 82, New ListItem("Seleccione", "0"))
                Catch ex As Exception
                    newFolder.Value = 0
                End Try
                startNodeInEditMode(newFolder.Value)
                Exit Select
            Case "Delete"
                '
                ' Borrar de la tabla
                '
                Dim wvalornodo As Double = e.Node.Value
                clickedNode.Remove()
                '
                Dim objnivel As SubTablasBrl = SubTablasBrl.CargarPorID(wvalornodo)
                If objnivel IsNot Nothing Then
                    objnivel.Eliminar()
                End If
                '
                Exit Select
            Case "Edit"
                clickedNode.Font.Bold = True
                startNodeInEditMode(clickedNode.Value)
                Exit Select
        End Select
    End Sub

    Private Sub startNodeInEditMode(ByVal nodeValue As String)
        'find the node by its Value and edit it when page loads
        Dim js As String = "Sys.Application.add_load(editNode); function editNode(){ "
        js += "var tree = $find(""" + RTree_Niveles.ClientID + """);"
        js += "var node = tree.findNodeByValue('" + nodeValue + "');"
        js += "if (node) node.startEdit();"
        js += "Sys.Application.remove_load(editNode);};"

        RadScriptManager.RegisterStartupScript(Page, Page.[GetType](), "nodeEdit", js, True)
    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_GrabarArbol.Click
        Dim objnivel As SubTablasBrl
        For Each fila As RadTreeNode In RTree_Niveles.Nodes
            objnivel = SubTablasBrl.CargarPorID(fila.Value)
            objnivel.Descripcion = fila.Text
            objnivel.Guardar()
        Next
        lblMensaje.Text = "Arbol de Niveles Presupuestales Grabado a satisfacción."
    End Sub

    Protected Sub btn_home_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_home.Click
        Response.Redirect("../webforms/principal.aspx")
    End Sub

    Protected Sub btn_cerrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_cerrar.Click
        Response.Redirect("../webforms/Principal.aspx")
    End Sub

    Protected Sub btn_actualizar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_actualizar.Click
        Response.Redirect("../webforms/NivelesList.aspx")
    End Sub

    Protected Sub ddl_niveles_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_niveles.SelectedIndexChanged
        lbl_descripcion_nivel.Text = ddl_niveles.Items(ddl_niveles.SelectedIndex).Text
    End Sub
End Class
