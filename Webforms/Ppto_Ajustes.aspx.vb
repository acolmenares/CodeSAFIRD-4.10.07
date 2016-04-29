Imports ingNovar.Utilidades2

Partial Class Webforms_Ppto_Ajustes
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

        BindHelper.Ppto_ContratosUIL.BindToListControl(ddl_Contratos, Session("Id_Proyecto"), New ListItem("Seleccione", 0))
        BindHelper.OrdenCompra_DetalleUIL.BindToListControlFinanzas(ddl_Ordenes, Session("Id_Proyecto"), New ListItem("Seleccione", 0))

        btnGuardar.Enabled = True
        btnGuardarOtro.Enabled = True
        btnEliminar.Enabled = True
        ddl_Contratos.Enabled = False
        ddl_Ordenes.Enabled = False
        rdb_Tipo.Enabled = True
        txtTRM.ReadOnly = False
        txtValor_COP.ReadOnly = False
        txtValor_USD.ReadOnly = False

        If Request.QueryString.Item("Refrescar") = 1 Then
            Dim objPpto_Ajustes As Ppto_AjustesBrl = Ppto_AjustesBrl.CargarPorID(Request.QueryString.Item("ID"))

            If objPpto_Ajustes Is Nothing Then
                lblMensaje.Text = "Registro no existe"
                lblMensaje.Visible = True
                Exit Sub
            End If

            rdpFecha.DbSelectedDate = objPpto_Ajustes.Fecha
            rdb_Tipo.SelectedValue = objPpto_Ajustes.Tipo
            rdb_Tipo_SelectedIndexChanged(Nothing, Nothing)
            If ddl_Contratos.Items.FindByValue(objPpto_Ajustes.Id_Contrato) IsNot Nothing Then ddl_Contratos.SelectedValue = objPpto_Ajustes.Id_Contrato
            If ddl_Ordenes.Items.FindByValue(objPpto_Ajustes.Id_OrdenCompra_Detalle) IsNot Nothing Then ddl_Ordenes.SelectedValue = objPpto_Ajustes.Id_OrdenCompra_Detalle
            txtValor_USD.Text = Format(objPpto_Ajustes.Valor_USD, "C")
            txtTRM.Text = Format(objPpto_Ajustes.TRM, "C")
            txtValor_COP.Text = Format(objPpto_Ajustes.Valor_COP, "C")
            txtObservaciones.Text = objPpto_Ajustes.Observaciones

            If (Request.QueryString.Item("Editar") = 2) Or (objPpto_Ajustes.Aprobado_DirFin = True) Then
                btnGuardar.Enabled = False
                btnGuardarOtro.Enabled = False
                btnEliminar.Enabled = False
                rdb_Tipo.Enabled = False
                txtTRM.ReadOnly = True
                txtValor_COP.ReadOnly = True
                txtValor_USD.ReadOnly = True
            End If


        Else
            rdpFecha.SelectedDate = Now
        End If

    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Validate()
        If Not IsValid Then Exit Sub

        Dim ID As Int32

        Try
            ID = Grabar()
            Response.Redirect("Ppto_Ajustes.aspx?Refrescar=1&Mensaje=1&ID=" & ID & "&Editar=" & Request.QueryString.Item("Editar"))
        Catch ex As Exception
            lblMensaje.Text = ex.Message
            lblMensaje.Visible = True
        End Try

    End Sub

    Private Sub btnGuardarOtro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarOtro.Click
        Validate()
        If Not IsValid Then Exit Sub

        Try
            Grabar()
            Response.Redirect("Ppto_Ajustes.aspx?Editar=0&Mensaje=1")
        Catch ex As Exception
            lblMensaje.Text = ex.Message
            lblMensaje.Visible = True
        End Try

    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Session.Remove("Ppto_Ajustes")
        Response.Redirect("Ppto_AjustesList.aspx")
    End Sub

    Private Function Grabar() As Int32

        Dim objPpto_Ajustes As Ppto_AjustesBrl

        If Request.QueryString.Item("Refrescar") = 1 Then
            objPpto_Ajustes = Ppto_AjustesBrl.CargarPorID(Request.QueryString.Item("ID"))
            objPpto_Ajustes.Fecha_Modificacion = Now
            objPpto_Ajustes.Id_Usuario_Modificacion = CType(Master.FindControl("lblidusuario"), Label).Text

        Else
            objPpto_Ajustes = New Ppto_AjustesBrl
            objPpto_Ajustes.Fecha_Creacion = Now
            objPpto_Ajustes.Id_Usuario_Creacion = CType(Master.FindControl("lblidusuario"), Label).Text
            objPpto_Ajustes.Id_Proyecto = Session("Id_Proyecto")
        End If

        objPpto_Ajustes.Fecha = rdpFecha.DbSelectedDate

        objPpto_Ajustes.Id_Contrato = ddl_Contratos.SelectedValue
        objPpto_Ajustes.Valor_USD = CType(txtValor_USD.Text, Double)
        objPpto_Ajustes.TRM = CType(txtTRM.Text, Double)
        objPpto_Ajustes.Valor_COP = CType(txtValor_COP.Text, Double)
        objPpto_Ajustes.Id_OrdenCompra_Detalle = ddl_Ordenes.SelectedValue
        objPpto_Ajustes.Tipo = rdb_Tipo.SelectedValue
        objPpto_Ajustes.Observaciones = txtObservaciones.Text
        objPpto_Ajustes.Guardar()

        Return objPpto_Ajustes.ID

    End Function

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Validate()
        If Not IsValid Then Exit Sub

        Dim objPpto_Ajustes As Ppto_AjustesBrl

        Try
            If Request.QueryString.Item("Refrescar") = 1 Then
                objPpto_Ajustes = Ppto_AjustesBrl.CargarPorID(Request.QueryString.Item("ID"))
                objPpto_Ajustes.Eliminar()
                Response.Redirect("Ppto_Ajustes.aspx?Mensaje=1")
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
            Response.Redirect("../webforms/Ppto_AjustesAprobarList.aspx")
        Else
            Response.Redirect("../webforms/Ppto_AjustesList.aspx")
        End If

    End Sub

    Protected Sub btn_nuevo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_nuevo.Click
        Response.Redirect("../webforms/Ppto_Ajustes.aspx")
    End Sub

    Protected Sub btn_actualizar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_actualizar.Click
        If Request.QueryString.Item("Id") > 0 Then
            Response.Redirect("../webforms/Ppto_Ajustes.aspx?Refrescar=1&Id=" + Request.QueryString.Item("Id") + "&Editar=" + Request.QueryString.Item("Editar"))
        Else
            btn_nuevo_Click(sender, e)
        End If
    End Sub

    Protected Sub rdb_Tipo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdb_Tipo.SelectedIndexChanged
        Rev_Ordenes.Enabled = False
        ddl_Ordenes.Enabled = False
        rev_Contratos.Enabled = False
        ddl_Contratos.Enabled = False
        If rdb_Tipo.SelectedValue = "C" Then
            rev_Contratos.Enabled = True
            ddl_Contratos.Enabled = True
            ddl_Ordenes.SelectedValue = 0
        End If
        If rdb_Tipo.SelectedValue = "O" Then
            Rev_Ordenes.Enabled = True
            ddl_Ordenes.Enabled = True
            ddl_Contratos.SelectedValue = 0
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

End Class
