Imports ingNovar.Utilidades2

Partial Class Webforms_Ppto_Ingresos
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

        If Request.QueryString.Item("Editar") = 1 Then
            Dim objPpto_Ingresos As Ppto_IngresosBrl = Ppto_IngresosBrl.CargarPorID(Request.QueryString.Item("ID"))

            If objPpto_Ingresos Is Nothing Then
                lblMensaje.Text = "Registro no existe"
                lblMensaje.Visible = True
                Exit Sub
            End If

            rdpFecha.DbSelectedDate = objPpto_Ingresos.Fecha
            txtNombre.Text = objPpto_Ingresos.Nombre_Entrega
            txtValor_USD.Text = Format(objPpto_Ingresos.Valor_USD, "C")
            txtTRM.Text = Format(objPpto_Ingresos.TRM, "C")
            txtValor_COP.Text = Format(objPpto_Ingresos.Valor_COP, "C")
            txtObservaciones.Text = objPpto_Ingresos.Observaciones
        Else
            rdpFecha.SelectedDate = Now
        End If

    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        lblMensaje.Text = ""
        If validar() Then
            lblMensaje.Text = Session("Mensajes")
            lblMensaje.ForeColor = Drawing.Color.Red
            lblMensaje.Visible = True
            Exit Sub
        End If
        Dim ID As Int32

        Try
            ID = Grabar()
            Response.Redirect("Ppto_Ingresos.aspx?Editar=1&Mensaje=1&ID=" & ID)
        Catch ex As Exception
            lblMensaje.Text = ex.Message
            lblMensaje.Visible = True
        End Try

    End Sub

    Private Sub btnGuardarOtro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarOtro.Click

        lblMensaje.Text = ""
        If validar() Then
            lblMensaje.Text = Session("Mensajes")
            lblMensaje.ForeColor = Drawing.Color.Red
            lblMensaje.Visible = True
            Exit Sub
        End If

        Try
            Grabar()
            Response.Redirect("Ppto_Ingresos.aspx?Mensaje=1")
        Catch ex As Exception
            lblMensaje.Text = ex.Message
            lblMensaje.Visible = True
        End Try

    End Sub

    Private Function validar() As Integer
        Dim wmensaje As String = ""

        If rdpFecha.SelectedDate.ToString = "" Then
            wmensaje += "- Falta seleccionar fecha inicial. "
        End If

        If Me.txtNombre.Text = "" Then
            wmensaje += "- Falta nombre de entidad. "
        End If

        If Me.txtTRM.Text = "" Then
            wmensaje += "- Falta tasa TRM. "
        End If

        If Me.txtValor_COP.Text = "" Then
            wmensaje += "- Falta valor COP. "
        End If

        If Me.txtValor_USD.Text = "" Then
            wmensaje += " - Falta Valor USD."
        End If

        If wmensaje = "" Then
            Return False
        Else
            Session("Mensajes") = wmensaje + ".  Revise por favor !!!!"
            Return True
        End If
    End Function

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Session.Remove("Ppto_Ingresos")
        Response.Redirect("Ppto_IngresosList.aspx")
    End Sub

    Private Function Grabar() As Int32

        Dim objPpto_Ingresos As Ppto_IngresosBrl

        If Request.QueryString.Item("Editar") = 1 Then
            objPpto_Ingresos = Ppto_IngresosBrl.CargarPorID(Request.QueryString.Item("ID"))
            objPpto_Ingresos.Fecha_Modificacion = Now
            objPpto_Ingresos.Id_Usuario_Modificacion = CType(Master.FindControl("lblidusuario"), Label).Text

        Else
            objPpto_Ingresos = New Ppto_IngresosBrl
            objPpto_Ingresos.Fecha_Creacion = Now
            objPpto_Ingresos.Id_Usuario_Creacion = CType(Master.FindControl("lblidusuario"), Label).Text
            objPpto_Ingresos.Id_Proyecto = Session("Id_Proyecto")
        End If

        objPpto_Ingresos.Fecha = rdpFecha.DbSelectedDate
        objPpto_Ingresos.Nombre_Entrega = txtNombre.Text
        objPpto_Ingresos.Valor_USD = CType(txtValor_USD.Text, Double)
        objPpto_Ingresos.TRM = CType(txtTRM.Text, Double)
        objPpto_Ingresos.Valor_COP = CType(txtValor_COP.Text, Double)
        objPpto_Ingresos.Observaciones = txtObservaciones.Text

        objPpto_Ingresos.Guardar()

        Return objPpto_Ingresos.ID

    End Function

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        lblMensaje.Text = ""
        Try
            If Request.QueryString.Item("Editar") = 1 Then
                Dim objPpto_Ingresos As Ppto_IngresosBrl
                objPpto_Ingresos = Ppto_IngresosBrl.CargarPorID(Request.QueryString.Item("ID"))
                objPpto_Ingresos.Eliminar()
                Response.Redirect("Ppto_Ingresos.aspx?Mensaje=1")
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
        Response.Redirect("../webforms/Ppto_IngresosList.aspx")
    End Sub

    Protected Sub btn_nuevo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_nuevo.Click
        Response.Redirect("../webforms/Ppto_Ingresos.aspx")
    End Sub

    Protected Sub btn_actualizar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_actualizar.Click
        If Request.QueryString.Item("Id") > 0 Then
            Response.Redirect("../webforms/Ppto_Ingresos.aspx?Editar=1&Id=" + Request.QueryString.Item("Id"))
        Else
            btn_nuevo_Click(sender, e)
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
