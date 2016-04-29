Imports ingNovar.Utilidades2
Imports System.Collections.Generic
Imports Telerik.Web.UI

Partial Class Webforms_Ppto_Distribucion
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

        BindHelper.Ppto_IngresosUIL.BindToListControl(ddl_Ingresos, Session("Id_Proyecto"), New ListItem("Seleccione", 0))
        BindHelper.SubTablasUIL.BindToListControlPorId_Tabla(ddl_TipoUnidad, 83, New ListItem("Seleccione", 0))

        Dim radtree As RadTreeView
        radtree = Me.RadComboBox2.Items(0).FindControl("RadTreeView1")
        BindToDataSet(radtree, Session("Id_Proyecto"))

        If Request.QueryString.Item("Editar") = 1 Then
            Dim objPpto_Distribucion As Ppto_DistribucionBrl = Ppto_DistribucionBrl.CargarPorID(Request.QueryString.Item("ID"))

            If objPpto_Distribucion Is Nothing Then
                lblMensaje.Text = "Registro no existe"
                lblMensaje.Visible = True
                Exit Sub
            End If

            rdpFecha.DbSelectedDate = objPpto_Distribucion.Fecha
            If ddl_Ingresos.Items.FindByValue(objPpto_Distribucion.Id_Ingreso) IsNot Nothing Then ddl_Ingresos.SelectedValue = objPpto_Distribucion.Id_Ingreso
            ddl_Ingresos_SelectedIndexChanged(Nothing, Nothing)
            txtNumero_Unidades.Text = Format(objPpto_Distribucion.Numero_Unidades, "N")
            txt_Costo_Unidad.Text = Format(objPpto_Distribucion.Costo_Unidad, "C")
            Txt_Costo_Total.Text = Format(objPpto_Distribucion.Valor_USD, "C")

            Dim node As RadTreeNode = radtree.FindNodeByValue(objPpto_Distribucion.Id_Nivel)
            If node IsNot Nothing Then
                node.Selected = True
                node.ExpandParentNodes()
                Me.RadComboBox2.Text = node.Text
            End If

            If ddl_TipoUnidad.Items.FindByValue(objPpto_Distribucion.Id_Tipo_Unidad) IsNot Nothing Then ddl_TipoUnidad.SelectedValue = objPpto_Distribucion.Id_Tipo_Unidad
        Else
            rdpFecha.SelectedDate = Now
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

    Private Function validar() As Integer
        Dim wvalor As Integer = 0
        Dim valorvalidar As Double = 0
        Dim wmensaje As String = ""
        If Request.QueryString.Item("Id") > 0 Then
            Dim objvalidar As Ppto_DistribucionBrl = Ppto_DistribucionBrl.CargarPorID(Request.QueryString.Item("Id"))
            If objvalidar IsNot Nothing Then
                valorvalidar = objvalidar.Valor_USD
            End If
        End If

        If Val(Txt_Costo_Total.Text) > (CType(Session("ValorPendiente"), Double) + valorvalidar) Then
            wmensaje += "-El valor a distribuir no puede superar al tope de ingresos."
        End If

        If ddl_Ingresos.SelectedValue = 0 Then
            wmensaje += "- Falta la información del ingreso."
        End If

        If Me.ddl_TipoUnidad.SelectedValue = 0 Then
            wmensaje += "- Falta seleccionar el tipo de unidad."
        End If

        If rdpFecha.SelectedDate.ToString = "" Then
            wmensaje += "- Falta seleccionar fecha inicial. "
        End If

        If Me.txtNumero_Unidades.Text = "" Then
            wmensaje += "- Falta número de unidades. "
        End If

        If Me.txt_Costo_Unidad.Text = "" Then
            wmensaje += "- Falta costo de unidades. "
        End If

        If Me.Txt_Costo_Total.Text = "" Then
            wmensaje += "- Falta costo totales. "
        End If

        If Me.RadComboBox2.Text = "" Then
            wmensaje += " - Falta Rubro Presupuestal."
        End If

        If wmensaje = "" Then
            Return False
        Else
            Session("Mensajes") = wmensaje + ".  Revise por favor !!!!"
            Return True
        End If
    End Function

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
            Response.Redirect("Ppto_Distribucion.aspx?Editar=1&Mensaje=1&ID=" & ID)
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
            Response.Redirect("Ppto_Distribucion.aspx?Mensaje=1")
        Catch ex As Exception
            lblMensaje.Text = ex.Message
            lblMensaje.Visible = True
        End Try

    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Session.Remove("Ppto_Distribucion")
        Response.Redirect("Ppto_DistribucionList.aspx")
    End Sub

    Private Function Grabar() As Int32

        '
        '  Validar Presupuesto
        '

        Dim objPpto_Distribucion As Ppto_DistribucionBrl

        If Request.QueryString.Item("Editar") = 1 Then
            objPpto_Distribucion = Ppto_DistribucionBrl.CargarPorID(Request.QueryString.Item("ID"))
            objPpto_Distribucion.Fecha_Modificacion = Now
            objPpto_Distribucion.Id_Usuario_Modificacion = CType(Master.FindControl("lblidusuario"), Label).Text

        Else
            objPpto_Distribucion = New Ppto_DistribucionBrl
            objPpto_Distribucion.Fecha_Creacion = Now
            objPpto_Distribucion.Id_Usuario_Creacion = CType(Master.FindControl("lblidusuario"), Label).Text
            objPpto_Distribucion.Id_Proyecto = Session("Id_Proyecto")
        End If

        objPpto_Distribucion.Fecha = rdpFecha.DbSelectedDate
        objPpto_Distribucion.Id_Ingreso = ddl_Ingresos.SelectedValue
        objPpto_Distribucion.Numero_Unidades = CType(txtNumero_Unidades.Text, Double)
        objPpto_Distribucion.Costo_Unidad = CType(txt_Costo_Unidad.Text, Double)
        objPpto_Distribucion.Valor_USD = CType(Txt_Costo_Total.Text, Double)
        Dim tree As RadTreeView = DirectCast(RadComboBox2.Items(0).FindControl("RadTreeView1"), RadTreeView)
        objPpto_Distribucion.Id_Nivel = tree.SelectedNode.Value
        objPpto_Distribucion.Id_Tipo_Unidad = ddl_TipoUnidad.SelectedValue
        objPpto_Distribucion.Guardar()

        Return objPpto_Distribucion.ID

    End Function

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        lblMensaje.Text = ""
        Try
            If Request.QueryString.Item("Editar") = 1 Then
                Dim objPpto_Distribucion As Ppto_DistribucionBrl
                objPpto_Distribucion = Ppto_DistribucionBrl.CargarPorID(Request.QueryString.Item("ID"))
                objPpto_Distribucion.Eliminar()
                Response.Redirect("Ppto_Distribucion.aspx?Mensaje=1")
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
        Response.Redirect("../webforms/Ppto_DistribucionList.aspx?Refrescar=1")
    End Sub

    Protected Sub btn_nuevo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_nuevo.Click
        Response.Redirect("../webforms/Ppto_Distribucion.aspx")
    End Sub

    Protected Sub btn_actualizar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_actualizar.Click
        If Request.QueryString.Item("Id") > 0 Then
            Response.Redirect("../webforms/Ppto_Distribucion.aspx?Editar=1&Id=" + Request.QueryString.Item("Id"))
        Else
            btn_nuevo_Click(sender, e)
        End If
    End Sub

    Protected Sub ddl_Ingresos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_Ingresos.SelectedIndexChanged
        lbl_Ingreso.Text = "Valor Ingreso : 0 "
        Lbl_Pendiente.Text = "Pendiente : 0 "
        Session("ValorPendiente") = 0
        If ddl_Ingresos.SelectedValue > 0 Then
            Dim ObjIngresos As Ppto_IngresosBrl = Ppto_IngresosBrl.CargarPorID(ddl_Ingresos.SelectedValue)
            lbl_Ingreso.Text = "Valor Ingreso : " & Format(ObjIngresos.Valor_USD, "C")
            Lbl_Pendiente.Text = "Pendiente : " & Format(ObjIngresos.SaldoIngreso, "C")
            Session("ValorPendiente") = ObjIngresos.SaldoIngreso
        End If

    End Sub

    Protected Sub txt_Costo_Unidad_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_Costo_Unidad.TextChanged
        Try
            Txt_Costo_Total.Text = Format(CType(txtNumero_Unidades.Text, Double) * CType(txt_Costo_Unidad.Text, Double), "C")
        Catch ex As Exception
            Txt_Costo_Total.Text = "0"
        End Try
        txt_Costo_Unidad.Text = Format(CType(txt_Costo_Unidad.Text, Double), "C")
    End Sub

    Protected Sub Txt_Costo_Total_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Costo_Total.TextChanged
        Try
            txt_Costo_Unidad.Text = Format(CType(Txt_Costo_Total.Text, Double) / CType(txtNumero_Unidades.Text, Double), "C")
        Catch ex As Exception
            txt_Costo_Unidad.Text = "0"
        End Try
        Txt_Costo_Total.Text = Format(CType(Txt_Costo_Total.Text, Double), "C")
    End Sub

    Protected Sub txtNumero_Unidades_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumero_Unidades.TextChanged
        Try
            Txt_Costo_Total.Text = Format(CType(txtNumero_Unidades.Text, Double) * CType(txt_Costo_Unidad.Text, Double), "C")
        Catch ex As Exception
            Txt_Costo_Total.Text = "0"
        End Try
        txtNumero_Unidades.Text = Format(CType(txtNumero_Unidades.Text, Double), "C")
    End Sub

End Class
