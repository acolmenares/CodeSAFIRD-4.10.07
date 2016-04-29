Imports System.Collections.Generic

Partial Class Controles_UcOrdenCompra
    Inherits System.Web.UI.UserControl

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If IsPostBack Then Exit Sub
        BindHelper.OrdenCompraUIL.BindToListControl(ddl_ordenes, Session("Id_Proyecto"), New ListItem("Seleccione", 0))
    End Sub

    Protected Sub btn_buscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_buscar.Click
        If ddl_ordenes.SelectedValue <> 0 Then
            Dim objOrdenCompra As OrdenCompraBrl = OrdenCompraBrl.CargarPorID(ddl_ordenes.SelectedValue)
            lbl_regionaloc.Text = objOrdenCompra.Regional.Descripcion
            lbl_numero.Text = objOrdenCompra.Numero
            lbl_fecha.Text = Format(objOrdenCompra.Fecha, "dddd, MMM d yyyy")
            Try
                lbl_Tercero.Text = objOrdenCompra.Terceros.Razon_Social
            Catch ex As Exception
                lbl_Tercero.Text = "Pendiente de Crear Tercero"
            End Try

            lbl_Forma.Text = objOrdenCompra.Tiempo_Entrega
            lbl_Lugar.Text = objOrdenCompra.Lugar_Entrega
            lbl_Tasa.Text = Format(objOrdenCompra.Tasa, "C")
            lblid.Text = objOrdenCompra.ID
            chkAprobacion_Finanzas_Ofc.Checked = objOrdenCompra.Aprobacion_Finanzas_Ofc
            chkAprobacion_Logistica_Ofc.Checked = objOrdenCompra.Aprobacion_Logistica_Ofc
            chkAprobacion_Coordinacion.Checked = objOrdenCompra.Aprobacion_Coordinacion
            chkAprobacion_Operaciones.Checked = objOrdenCompra.Aprobacion_Operaciones
            chkAprobacion_CooLogistica.Checked = objOrdenCompra.Aprobacion_CooLogistica
            chkAprobacion_Financiera.Checked = objOrdenCompra.Aprobacion_Financiera
            Dim ListOrdenCompra_Detalle As List(Of OrdenCompra_DetalleBrl)

            ListOrdenCompra_Detalle = objOrdenCompra.OrdenCompra_Detalle
            Session("ListOrdenCompra_DetalleSaldos") = ListOrdenCompra_Detalle

            Rg_Listado.DataSource = Session("ListOrdenCompra_DetalleSaldos")
            Rg_Listado.DataBind()

            Dim Listretenciones As List(Of OrdenCompra_RetencionBrl)
            Listretenciones = objOrdenCompra.OrdenCompra_Retencion
            Session("ListaRetenciones") = Listretenciones
            dg_Retenciones.DataSource = Listretenciones
            dg_Retenciones.DataBind()
        Else
            lbl_regionaloc.Text = ""
            lbl_numero.Text = ""
            lbl_fecha.Text = ""
            lbl_Tercero.Text = ""
            lbl_Forma.Text = ""
            lbl_Lugar.Text = ""
            lbl_Tasa.Text = ""
            lblid.Text = ""
            chkAprobacion_Finanzas_Ofc.Checked = False
            chkAprobacion_Logistica_Ofc.Checked = False
            chkAprobacion_Coordinacion.Checked = False
            chkAprobacion_Operaciones.Checked = False
            chkAprobacion_CooLogistica.Checked = False
            chkAprobacion_Financiera.Checked = False
            Dim ListOrdenCompra_Detalle As New List(Of OrdenCompra_DetalleBrl)
            Session("ListOrdenCompra_DetalleSaldos") = ListOrdenCompra_Detalle
            Rg_Listado.DataSource = Session("ListOrdenCompra_DetalleSaldos")
            Rg_Listado.DataBind()

            Dim Listretenciones As New List(Of OrdenCompra_RetencionBrl)
            Session("ListaRetenciones") = Listretenciones
            dg_Retenciones.DataSource = Listretenciones
            dg_Retenciones.DataBind()

        End If
    End Sub

    Protected Sub btn_contratos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_contratos.Click
        Dim objOrdenCompra As OrdenCompraBrl = OrdenCompraBrl.CargarPorID(lblid.Text)
        objOrdenCompra.Aprobacion_Coordinacion = False
        objOrdenCompra.Aprobacion_CooLogistica = False
        objOrdenCompra.Aprobacion_Finanzas_Ofc = False
        objOrdenCompra.Aprobacion_Logistica_Ofc = False
        objOrdenCompra.Aprobacion_Operaciones = False
        objOrdenCompra.Guardar()
        ddl_ordenes.SelectedValue = 0
        btn_buscar_Click(Nothing, Nothing)
    End Sub

    Public Sub CambioPaginaRet(ByVal sender As Object, ByVal e As DataGridPageChangedEventArgs) Handles dg_Retenciones.PageIndexChanged
        dg_Retenciones.CurrentPageIndex = e.NewPageIndex
        dg_Retenciones.SelectedIndex = -1
        dg_Retenciones.DataSource = Session("ListaRetenciones")
        dg_Retenciones.DataBind()
    End Sub
End Class
