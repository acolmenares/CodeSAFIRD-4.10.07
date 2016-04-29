Imports ingNovar.Utilidades2
Imports System.Collections.Generic
Imports Telerik.Web.UI

Partial Class Webforms_Ppto_Contratos
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

        BindHelper.Ppto_TercerosUIL.BindToListControl(ddl_Terceros, New ListItem("Seleccione", 0))
        BindHelper.SubTablasUIL.BindToListControlPorId_Tabla(ddl_Tipo_Orden, 84, New ListItem("Seleccione", 0))
        Dim radtree As RadTreeView
        radtree = Me.RadComboBox2.Items(0).FindControl("RadTreeView1")

        BindToDataSet(radtree, Session("Id_Proyecto"))

        If Val(Request.QueryString.Item("Id")) > 0 Then
            Dim objPpto_Contratos As Ppto_ContratosBrl = Ppto_ContratosBrl.CargarPorID(Request.QueryString.Item("ID"))

            If objPpto_Contratos Is Nothing Then
                lblMensaje.Text = "Registro no existe"
                lblMensaje.Visible = True
                Exit Sub
            End If

            rdpFecha.DbSelectedDate = objPpto_Contratos.Fecha
            txtNumero.Text = objPpto_Contratos.Numero
            If ddl_Terceros.Items.FindByValue(objPpto_Contratos.Id_Tercero) IsNot Nothing Then ddl_Terceros.SelectedValue = objPpto_Contratos.Id_Tercero
            ddl_Terceros_SelectedIndexChanged(Nothing, Nothing)
            txtValor_USD.Text = Format(objPpto_Contratos.Valor_USD, "C")
            txtTRM.Text = Format(objPpto_Contratos.TRM, "C")
            txtValor_COP.Text = Format(objPpto_Contratos.Valor_COP, "C")
            If ddl_Tipo_Orden.Items.FindByValue(objPpto_Contratos.Id_Tipo_Orden) IsNot Nothing Then ddl_Tipo_Orden.SelectedValue = objPpto_Contratos.Id_Tipo_Orden

            Dim node As RadTreeNode = radtree.FindNodeByValue(objPpto_Contratos.Id_Nivel)
            If node IsNot Nothing Then
                node.Selected = True
                node.ExpandParentNodes()
                Me.RadComboBox2.Text = node.Text
            End If

            txtObservaciones.Text = objPpto_Contratos.Observaciones
            Txt_CodigoProyecto.Text = objPpto_Contratos.Codigo_Proyecto
            rdp_Fecha_Inicial_Contrato.DbSelectedDate = objPpto_Contratos.Fecha_Inicial_Contrato
            rdp_Fecha_Final_Contrato.DbSelectedDate = objPpto_Contratos.Fecha_Final_Contrato
        Else
            rdpFecha.SelectedDate = Now
        End If

        rdpFecha.Enabled = True
        txtNumero.Enabled = True
        ddl_Terceros.Enabled = True
        txtValor_USD.Enabled = True
        txtTRM.Enabled = True
        txtValor_COP.Enabled = True
        ddl_Tipo_Orden.Enabled = True
        RadComboBox2.Enabled = True
        txtObservaciones.Enabled = True
        txt_codprv.Enabled = True
        btnGuardar.Visible = True
        btnGuardarOtro.Visible = True
        btnEliminar.Visible = True


        If Request.QueryString.Item("Editar") = 2 Then
            rdpFecha.Enabled = False
            txtNumero.Enabled = False
            ddl_Terceros.Enabled = False
            txtValor_USD.Enabled = False
            txtTRM.Enabled = False
            txtValor_COP.Enabled = False
            ddl_Tipo_Orden.Enabled = False
            RadComboBox2.Enabled = False
            txtObservaciones.Enabled = False
            txt_codprv.Enabled = False
            btnGuardar.Visible = False
            btnGuardarOtro.Visible = False
            btnEliminar.Visible = False
        End If

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
        Validate("PROD")
        If Not IsValid Then Exit Sub

        Dim ID As Int32

        Try
            ID = Grabar()
            Response.Redirect("Ppto_Contratos.aspx?Editar=1&Mensaje=1&ID=" & ID)
        Catch ex As Exception
            lblMensaje.Text = ex.Message
            lblMensaje.Visible = True
        End Try

    End Sub

    Private Sub btnGuardarOtro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarOtro.Click
        Validate("PROD")
        If Not IsValid Then Exit Sub

        Try
            Grabar()
            Response.Redirect("Ppto_Contratos.aspx?Mensaje=1")
        Catch ex As Exception
            lblMensaje.Text = ex.Message
            lblMensaje.Visible = True
        End Try

    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Session.Remove("Ppto_Contratos")
        If Request.QueryString.Item("Editar") = 2 Then
            Response.Redirect("../webforms/Ppto_ContratosAprobarList.aspx?Refrescar=1&TA=" + Request.QueryString.Item("TA"))
        Else
            Response.Redirect("../webforms/Ppto_ContratosList.aspx")
        End If
    End Sub

    Private Function Grabar() As Int32

        Dim objPpto_Contratos As Ppto_ContratosBRL

        If Request.QueryString.Item("Editar") = 1 Then
            objPpto_Contratos = Ppto_ContratosBRL.CargarPorID(Request.QueryString.Item("ID"))
            objPpto_Contratos.Fecha_Modificacion = Now
            objPpto_Contratos.Id_Usuario_Modificacion = CType(Master.FindControl("lblidusuario"), Label).Text

        Else
            objPpto_Contratos = New Ppto_ContratosBrl
            objPpto_Contratos.Fecha_Creacion = Now
            objPpto_Contratos.Id_Usuario_Creacion = CType(Master.FindControl("lblidusuario"), Label).Text
            objPpto_Contratos.Id_Proyecto = Session("Id_Proyecto")

        End If

        objPpto_Contratos.Fecha = rdpFecha.DbSelectedDate
        objPpto_Contratos.Numero = txtNumero.Text
        objPpto_Contratos.Id_Tercero = ddl_Terceros.SelectedValue
        objPpto_Contratos.Valor_USD = CType(txtValor_USD.Text, Double)
        objPpto_Contratos.TRM = CType(txtTRM.Text, Double)
        objPpto_Contratos.Valor_COP = CType(txtValor_COP.Text, Double)
        Dim tree As RadTreeView = DirectCast(RadComboBox2.Items(0).FindControl("RadTreeView1"), RadTreeView)
        objPpto_Contratos.Id_Nivel = tree.SelectedNode.Value
        objPpto_Contratos.Observaciones = txtObservaciones.Text
        objPpto_Contratos.Id_Tipo_Orden = ddl_Tipo_Orden.SelectedValue
        objPpto_Contratos.Codigo_Proyecto = Txt_CodigoProyecto.Text
        objPpto_Contratos.Fecha_Inicial_Contrato = rdp_Fecha_Inicial_Contrato.DbSelectedDate
        objPpto_Contratos.Fecha_Final_Contrato = rdp_Fecha_Final_Contrato.DbSelectedDate

        objPpto_Contratos.Guardar()

        Return objPpto_Contratos.ID

    End Function

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        lblMensaje.Text = ""
        lblMensaje.Visible = True

        Dim objPpto_Contratos As Ppto_ContratosBRL

        Try
            If Request.QueryString.Item("Editar") = 1 Then
                objPpto_Contratos = Ppto_ContratosBRL.CargarPorID(Request.QueryString.Item("ID"))
                objPpto_Contratos.Eliminar()
                Response.Redirect("Ppto_Contratos.aspx?Mensaje=1")
            Else
                lblMensaje.Text = "No existe registro para eliminar. !!! "
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
        If Request.QueryString.Item("Editar") = 2 Then
            Response.Redirect("../webforms/Ppto_ContratosAprobarList.aspx?Refrescar=1&TA=" + Request.QueryString.Item("TA"))
        Else
            Response.Redirect("../webforms/Ppto_ContratosList.aspx")
        End If

    End Sub

    Protected Sub btn_nuevo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_nuevo.Click
        Response.Redirect("../webforms/Ppto_Contratos.aspx")
    End Sub

    Protected Sub btn_actualizar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_actualizar.Click
        If Request.QueryString.Item("Id") > 0 Then
            Response.Redirect("../webforms/Ppto_Contratos.aspx?Editar=1&Id=" + Request.QueryString.Item("Id"))
        Else
            btn_nuevo_Click(sender, e)
        End If
    End Sub

    Protected Sub txtValor_USD_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtValor_USD.TextChanged
        Try
            txtValor_COP.Text = Format(CType(txtTRM.Text, Double) * CType(txtValor_USD.Text, Double), "C")
        Catch ex As Exception
            txtValor_COP.Text = "0"
        End Try
        txtValor_USD.Text = Format(CType(txtValor_USD.Text, Double), "C")
    End Sub

    Protected Sub txtTRM_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTRM.TextChanged
        Try
            txtValor_COP.Text = Format(CType(txtTRM.Text, Double) * CType(txtValor_USD.Text, Double), "C")
        Catch ex As Exception
            txtValor_COP.Text = "0"
        End Try
        txtTRM.Text = Format(CType(txtTRM.Text, Double), "C")
    End Sub

    Protected Sub txtValor_COP_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtValor_COP.TextChanged
        Try
            txtValor_USD.Text = Format(CType(txtValor_COP.Text, Double) / CType(txtTRM.Text, Double), "C")
        Catch ex As Exception
            txtValor_USD.Text = "0"
        End Try
        txtValor_COP.Text = Format(CType(txtValor_COP.Text, Double), "C")
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
                    ddl_Tipo_Orden.Focus()
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

End Class
