Imports System.Data
Imports System.Collections.Generic

Partial Class Webforms_PagosList
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

            btn_buscar.Enabled = objper_perfil.Pconsultar
            ImgCargueTerceros.Enabled = objper_perfil.Pcrear
            Rg_Pendientes.MasterTableView.CommandItemSettings.ShowExportToCsvButton = objper_perfil.Pexportarcsv
            Rg_Pendientes.MasterTableView.CommandItemSettings.ShowExportToExcelButton = objper_perfil.Pexportarexcel
            Rg_Pendientes.MasterTableView.CommandItemSettings.ShowExportToPdfButton = objper_perfil.Pexportarpdf
            Rg_Pendientes.MasterTableView.CommandItemSettings.ShowExportToWordButton = objper_perfil.Pexportarword
        End If

        If objper_usuario IsNot Nothing Then
            If objper_usuario.Pver = False Or objper_usuario.Pconsultar = False Then
                Response.Redirect(strPaginaError)
                Exit Sub
            End If

            ' asignando los permisos
            btn_buscar.Enabled = objper_usuario.Pconsultar
            ImgCargueTerceros.Enabled = objper_usuario.Pcrear
            Rg_Pendientes.MasterTableView.CommandItemSettings.ShowExportToCsvButton = objper_usuario.Pexportarcsv
            Rg_Pendientes.MasterTableView.CommandItemSettings.ShowExportToExcelButton = objper_usuario.Pexportarexcel
            Rg_Pendientes.MasterTableView.CommandItemSettings.ShowExportToPdfButton = objper_usuario.Pexportarpdf
            Rg_Pendientes.MasterTableView.CommandItemSettings.ShowExportToWordButton = objper_usuario.Pexportarword
        End If

    End Sub

    Protected Sub ImgCargueTerceros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgCargueTerceros.Click
        Dim wrpta As Integer
        If RUCarguePagos.UploadedFiles.Count > 0 Then
            If RUCarguePagos.UploadedFiles.Item(0).FileName <> "" Then
                Try
                    If RUCarguePagos.UploadedFiles.Item(0).GetExtension.Trim.ToLower = ".txt" Then
                        ' Server.MapPath("~/Mantto/Upload/") &
                        wrpta = Ppto_PagosDAL.CarguePagos(Server.MapPath("~/Upload/") & RUCarguePagos.UploadedFiles.Item(0).GetName) ' Carga Archivo
                        Ppto_PagosDAL.SubirPagos() ' Sube los pagos del temporal al archivo detalle de pagos
                        Ppto_PagosDAL.GenerarPagos() ' Enlaza los documentos

                        '
                        ' Proceso Realizado
                        '
                        Dim ListPagosPendientes As List(Of Ppto_Pagos_DetalleBrl)
                        ListPagosPendientes = Ppto_Pagos_DetalleBrl.CargarPorPendientes
                        Session("ListPagosPendientes") = ListPagosPendientes
                        Rg_Pendientes.DataSource = Session("ListPagosPendientes")
                        Rg_Pendientes.DataBind()

                        Dim ListPagosProcesados As List(Of Ppto_Pagos_DetalleBrl) = Session("ListPagosProcesados")
                        ListPagosProcesados = Ppto_Pagos_DetalleBrl.CargarPorProcesadas
                        Session("ListPagosProcesados") = ListPagosProcesados
                        Rg_Procesados.DataSource = Session("ListPagosProcesados")
                        Rg_Procesados.DataBind()

                        lblresultado.Text = "Cargue de información Completa."

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

        BindHelper.Ppto_ContratosUIL.BindToListControl(ddl_contratos, Session("Id_Proyecto"), New ListItem("Seleccione", 0))
        BindHelper.Ppto_ContratosUIL.BindToListControl(ddl_Contratos_Pendientes, Session("Id_Proyecto"), New ListItem("Seleccione", 0))
        BindHelper.OrdenCompraUIL.BindToListControl(ddl_Ordenes, Session("Id_Proyecto"), New ListItem("Seleccione", 0))
        BindHelper.OrdenCompraUIL.BindToListControl(ddl_OrdenesCompra_Pendientes, Session("Id_Proyecto"), New ListItem("Seleccione", 0))

        Dim ListPagosPendientes As List(Of Ppto_Pagos_DetalleBrl) = Session("ListPagosPendientes")

        'si no hay una variable de sesión con la lista.
        If ListPagosPendientes Is Nothing Or Request.QueryString.Item("Refrescar") = 1 Then
            ListPagosPendientes = Ppto_Pagos_DetalleBrl.CargarPorPendientes
            Session("ListPagosPendientes") = ListPagosPendientes
        End If

        Rg_Pendientes.DataSource = Session("ListPagosPendientes")
        Rg_Pendientes.DataBind()

        rdb_opcion_SelectedIndexChanged(Nothing, Nothing)

        Dim ListPagosProcesados As List(Of Ppto_Pagos_DetalleBrl) = Session("ListPagosProcesados")

        'si no hay una variable de sesión con la lista.
        If ListPagosProcesados Is Nothing Or Request.QueryString.Item("Refrescar") = 1 Then
            ListPagosProcesados = Ppto_Pagos_DetalleBrl.CargarPorProcesadas
            Session("ListPagosProcesados") = ListPagosProcesados
        End If

        Rg_Procesados.DataSource = Session("ListPagosProcesados")
        Rg_Procesados.DataBind()

    End Sub

    Protected Sub Rg_Listado_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles Rg_Pendientes.NeedDataSource
        Rg_Pendientes.DataSource = Session("ListPagosPendientes")
    End Sub

    Protected Sub Rg_Procesados_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles Rg_Procesados.NeedDataSource
        Rg_Procesados.DataSource = Session("ListPagosProcesados")
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
        Response.Redirect("../webforms/PagosList.aspx?Refrescar=1")
    End Sub

    Protected Sub btn_Procesar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_Procesar.Click
        Rg_Pendientes.DataSource = Session("ListPagosPendientes")
        Rg_Pendientes.DataBind()
    End Sub

    Protected Sub rdb_opcion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdb_opcion.SelectedIndexChanged
        If rdb_opcion.SelectedValue = "O" Then
            Lbl_OrdenCompra.Visible = True
            ddl_OrdenesCompra_Pendientes.Visible = True
            lbl_Contrato.Visible = False
            ddl_Contratos_Pendientes.SelectedValue = 0
            ddl_Contratos_Pendientes.Visible = False
        Else
            Lbl_OrdenCompra.Visible = False
            ddl_OrdenesCompra_Pendientes.Visible = False
            lbl_Contrato.Visible = True
            ddl_OrdenesCompra_Pendientes.SelectedValue = 0
            ddl_Contratos_Pendientes.Visible = True
        End If
    End Sub

    Protected Sub btn_AplicarPago_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_AplicarPago.Click
        lblMensaje.Text = ""
        lblMensaje.Visible = False

        For Each fila As Telerik.Web.UI.GridItem In Rg_Pendientes.Items
            Dim chk_aprobar As CheckBox
            Dim lblid As Label
            Dim id_pago As Integer = 0
            chk_aprobar = fila.FindControl("chk_aprobar")
            If chk_aprobar.Checked Then
                Dim ListPagos As List(Of Ppto_PagosBrl)
                Dim ObjPagoPendiente As Ppto_Pagos_DetalleBrl
                Dim ListTerceros As List(Of Ppto_TercerosBrl)
                Try
                    lblid = fila.FindControl("lblid")
                    ObjPagoPendiente = Ppto_Pagos_DetalleBrl.CargarPorID(lblid.Text)
                    If rdb_opcion.SelectedValue = "O" Then
                        If ddl_OrdenesCompra_Pendientes.SelectedValue <> 0 Then
                            ListPagos = Ppto_PagosBrl.CargarPorId_OrdenCompra(ddl_OrdenesCompra_Pendientes.SelectedValue)
                            If ListPagos.Count = 0 Then  ' No exite el registro de la orden de compra
                                ' se procede a crear el pago de la orden de compra
                                ListTerceros = Ppto_TercerosBrl.CargarPorNombreeIdentificacion(ObjPagoPendiente.Codigo_Tercero)
                                If ListTerceros.Count = 1 Then
                                    Try
                                        id_pago = Ppto_PagosDAL.Insertar(ObjPagoPendiente.Fecha, ListTerceros.Item(0).ID, "O", 0, Now, CType(Master.FindControl("lblidusuario"), Label).Text, Nothing, Nothing, ddl_OrdenesCompra_Pendientes.SelectedValue, 0)
                                        ObjPagoPendiente.Id_Ppto_Pago = id_pago
                                        ObjPagoPendiente.Guardar()
                                    Catch ex As Exception
                                        lblMensaje.Text = lblMensaje.Text + ex.Message
                                        Exit Sub
                                    End Try
                                Else
                                    If ListTerceros.Count > 1 Then
                                        lblMensaje.Text = lblMensaje.Text + " - Existen demasiados items con ese documento "
                                    Else
                                        lblMensaje.Text = lblMensaje.Text + " - El Tercero no existe en la base de terceros, "
                                    End If

                                End If
                            Else
                                ' existe el registro de la orden de compra en los pagos
                                ObjPagoPendiente.Id_Ppto_Pago = ListPagos.Item(0).ID
                                ObjPagoPendiente.Guardar()
                            End If
                        Else
                            lblMensaje.Text = lblMensaje.Text + "- No se ha seleccionado Orden de compra para relacionar."

                        End If
                    Else ' contrato
                        If ddl_Contratos_Pendientes.SelectedValue <> 0 Then
                            ListPagos = Ppto_PagosBrl.CargarPorId_Contrato(ddl_Contratos_Pendientes.SelectedValue)
                            If ListPagos.Count = 0 Then  ' No exite el registro del contrato
                                ' se procede a crear el pago del contrato
                                ListTerceros = Ppto_TercerosBrl.CargarPorNombreeIdentificacion(ObjPagoPendiente.Codigo_Tercero)
                                If ListTerceros.Count = 1 Then
                                    Try
                                        id_pago = Ppto_PagosDAL.Insertar(ObjPagoPendiente.Fecha, ListTerceros.Item(0).ID, "C", ddl_Contratos_Pendientes.SelectedValue, Now, CType(Master.FindControl("lblidusuario"), Label).Text, Nothing, Nothing, Nothing, 0)
                                        ObjPagoPendiente.Id_Ppto_Pago = id_pago
                                        ObjPagoPendiente.Guardar()
                                    Catch ex As Exception
                                        lblMensaje.Text = lblMensaje.Text + ex.Message
                                        Exit Sub
                                    End Try
                                Else
                                    If ListTerceros.Count > 1 Then
                                        lblMensaje.Text = lblMensaje.Text + " - Existen demasiados items con ese documento "
                                    Else
                                        lblMensaje.Text = lblMensaje.Text + " - El Tercero no existe en la base de terceros, "
                                    End If

                                End If
                            Else
                                ' existe el registro del contratoa en los pagos
                                ObjPagoPendiente.Id_Ppto_Pago = ListPagos.Item(0).ID
                                ObjPagoPendiente.Guardar()
                            End If
                        Else
                            lblMensaje.Text = lblMensaje.Text + "- No se ha seleccionado Contrato para relacionar."
                        End If

                    End If
                Catch ex As Exception
                    lblMensaje.Text = lblMensaje.Text + ex.Message
                End Try
            End If
        Next

        If lblMensaje.Text = "" Then
            lblMensaje.Text = "Operacion exitosa!!!"
            Dim ListPagosPendientes As List(Of Ppto_Pagos_DetalleBrl) = Ppto_Pagos_DetalleBrl.CargarPorPendientes
            Session("ListPagosPendientes") = ListPagosPendientes
            Rg_Pendientes.DataSource = Session("ListPagosPendientes")
            Rg_Pendientes.DataBind()

        End If
        lblMensaje.Visible = True


    End Sub

    Protected Sub btn_eliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_eliminar.Click
        ' Proceso para eliminar trabajo ya realizado
        lblMensaje.Text = ""
        lblMensaje.Visible = False
        Dim id_pago As Integer = 0
        For Each fila As Telerik.Web.UI.GridItem In Rg_Pendientes.Items
            Dim chk_aprobar As CheckBox
            Dim lblid As Label

            chk_aprobar = fila.FindControl("chk_aprobar")
            If chk_aprobar.Checked Then
                Dim ObjPagoPendiente As Ppto_Pagos_DetalleBrl
                Try
                    lblid = fila.FindControl("lblid")
                    ObjPagoPendiente = Ppto_Pagos_DetalleBrl.CargarPorID(lblid.Text)
                    id_pago = ObjPagoPendiente.Id_Ppto_Pago
                    ObjPagoPendiente.Id_Ppto_Pago = 0
                    ObjPagoPendiente.Guardar()
                Catch ex As Exception
                    lblMensaje.Text = lblMensaje.Text + ex.Message
                End Try
            End If
        Next
        If id_pago <> 0 Then
            Dim ListPpto_pagosDetalle As List(Of Ppto_Pagos_DetalleBrl) = Ppto_Pagos_DetalleBrl.CargarPorId_Ppto_Pago(id_pago)
            If ListPpto_pagosDetalle.Count = 0 Then
                Dim objpago As Ppto_PagosBrl = Ppto_PagosBrl.CargarPorID(id_pago)
                objpago.Eliminar()
            End If
        End If
        If lblMensaje.Text = "" Then
            lblMensaje.Text = "Operacion exitosa!!!"
        End If
        lblMensaje.Visible = True
    End Sub

    Protected Sub btn_eliminar_Ordens_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_eliminar_Ordens.Click
        ' Proceso para eliminar trabajo ya realizado
        lblMensaje.Text = ""
        lblMensaje.Visible = False
        Dim id_pago As Integer = 0
        For Each fila As Telerik.Web.UI.GridItem In Rg_Ordenes_Resumen.Items
            Dim chk_aprobar As CheckBox
            Dim lblid As Label

            chk_aprobar = fila.FindControl("chk_aprobar")
            If chk_aprobar.Checked Then
                Dim ObjPagoPendiente As Ppto_Pagos_DetalleBrl
                Try
                    lblid = fila.FindControl("lblid")
                    ObjPagoPendiente = Ppto_Pagos_DetalleBrl.CargarPorID(lblid.Text)
                    id_pago = ObjPagoPendiente.Id_Ppto_Pago
                    ObjPagoPendiente.Id_Ppto_Pago = 0
                    ObjPagoPendiente.Guardar()

                Catch ex As Exception
                    lblMensaje.Text = lblMensaje.Text + ex.Message
                End Try
            End If
        Next
        Try
            Dim objpago As Ppto_PagosBrl = Ppto_PagosBrl.CargarPorID(id_pago)
            objpago.Eliminar()
        Catch ex As Exception
        End Try

        imb_ordencompra_Click(Nothing, Nothing)
        If lblMensaje.Text = "" Then
            lblMensaje.Text = "Operacion exitosa!!!"
        End If
        lblMensaje.Visible = True
    End Sub

    Protected Sub btn_eliminar_contratos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_eliminar_contratos.Click
        ' Proceso para eliminar trabajo ya realizado
        lblMensaje.Text = ""
        lblMensaje.Visible = False
        Dim id_pago As Integer = 0
        For Each fila As Telerik.Web.UI.GridItem In Rg_Contratos_Resumen.Items
            Dim chk_aprobar As CheckBox
            Dim lblid As Label
            chk_aprobar = fila.FindControl("chk_aprobar")
            If chk_aprobar.Checked Then
                Dim ObjPagoPendiente As Ppto_Pagos_DetalleBrl
                Try
                    lblid = fila.FindControl("lblid")
                    ObjPagoPendiente = Ppto_Pagos_DetalleBrl.CargarPorID(lblid.Text)
                    id_pago = ObjPagoPendiente.Id_Ppto_Pago
                    ObjPagoPendiente.Id_Ppto_Pago = 0
                    ObjPagoPendiente.Guardar()
                Catch ex As Exception
                    lblMensaje.Text = lblMensaje.Text + ex.Message
                End Try
            End If
        Next
        Try
            Dim objpago As Ppto_PagosBrl = Ppto_PagosBrl.CargarPorID(id_pago)
            objpago.Eliminar()
        Catch ex As Exception
        End Try
        imb_contratos_Click(Nothing, Nothing)

        If lblMensaje.Text = "" Then
            lblMensaje.Text = "Operacion exitosa!!!"
        End If
        lblMensaje.Visible = True
    End Sub

    Protected Sub imb_ordencompra_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imb_ordencompra.Click
        lblMensaje.Visible = False
        If ddl_Ordenes.SelectedValue <> 0 Then
            Dim objOrdenConsulta As Ppto_PagosBrl
            Dim ListOrdenConsulta As List(Of Ppto_PagosBrl)
            Try
                ListOrdenConsulta = Ppto_PagosBrl.CargarPorId_OrdenCompra(ddl_Ordenes.SelectedValue)
                If ListOrdenConsulta.Count = 0 Then
                    Session("OrdenCompraConsulta") = ListOrdenConsulta
                Else
                    objOrdenConsulta = ListOrdenConsulta.Item(0)
                    Session("OrdenCompraConsulta") = objOrdenConsulta.Ppto_Pagos_Detalle
                End If
                Rg_Ordenes_Resumen.DataSource = Session("OrdenCompraConsulta")
                Rg_Ordenes_Resumen.DataBind()
            Catch ex As Exception
                lblMensaje.Text = ex.Message
                lblMensaje.Visible = True
            End Try

        End If
    End Sub

    Protected Sub Rg_Ordenes_Resumen_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles Rg_Ordenes_Resumen.NeedDataSource
        Rg_Ordenes_Resumen.DataSource = Session("OrdenCompraConsulta")
    End Sub

    Protected Sub imb_contratos_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imb_contratos.Click
        lblMensaje.Visible = False
        If ddl_contratos.SelectedValue <> 0 Then
            Dim objOrdenConsulta As Ppto_PagosBrl
            Dim ListOrdenConsulta As List(Of Ppto_PagosBrl)
            Try
                ListOrdenConsulta = Ppto_PagosBrl.CargarPorId_Contrato(ddl_contratos.SelectedValue)
                If ListOrdenConsulta.Count = 0 Then
                    Session("ContratosConsulta") = ListOrdenConsulta
                Else
                    objOrdenConsulta = ListOrdenConsulta.Item(0)
                    Session("ContratosConsulta") = objOrdenConsulta.Ppto_Pagos_Detalle
                End If
                Rg_Contratos_Resumen.DataSource = Session("ContratosConsulta")
                Rg_Contratos_Resumen.DataBind()
            Catch ex As Exception
                lblMensaje.Text = ex.Message
                lblMensaje.Visible = True
            End Try

        End If
    End Sub

    Protected Sub Rg_Contratos_Resumen_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles Rg_Contratos_Resumen.NeedDataSource
        Rg_Contratos_Resumen.DataSource = Session("ContratosConsulta")
    End Sub

End Class
