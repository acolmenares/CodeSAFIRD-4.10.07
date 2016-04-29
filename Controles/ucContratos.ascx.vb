Imports System.Collections.Generic

Partial Class Controles_ucContratos
    Inherits System.Web.UI.UserControl

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If IsPostBack Then Exit Sub
        BindHelper.Ppto_ContratosUIL.BindToListControl(ddl_contratos, Session("Id_Proyecto"), New ListItem("Seleccione", 0))
    End Sub

    Protected Sub btn_buscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_buscar.Click
        If ddl_contratos.SelectedValue <> 0 Then
            Dim objPpto_Contratos As Ppto_ContratosBrl = Ppto_ContratosBrl.CargarPorID(ddl_contratos.SelectedValue)

            lbl_fecha.Text = Format(objPpto_Contratos.Fecha, "dddd, MMM d yyyy")
            lbl_numero.Text = objPpto_Contratos.Numero
            lbl_tercero.Text = objPpto_Contratos.Ppto_Terceros.Razon_Social
            lbl_valorUSD.Text = Format(objPpto_Contratos.Valor_USD, "C")
            lbl_tasa.Text = Format(objPpto_Contratos.TRM, "C")
            lbl_valorCOP.Text = Format(objPpto_Contratos.Valor_COP, "C")
            lbl_tipocontrato.Text = objPpto_Contratos.Tipo_Orden.Descripcion
            lbl_rubro.Text = objPpto_Contratos.Nivel.Descripcion_PadreHijo
            lblid.Text = objPpto_Contratos.ID
            chkAprobacion_Financiera.Checked = objPpto_Contratos.Aprobacion_Financiera
            chkAprobacion_pais.Checked = objPpto_Contratos.Aprobacion_Pais
        Else
            lbl_fecha.Text = ""
            lbl_numero.Text = ""
            lbl_tercero.Text = ""
            lbl_valorUSD.Text = ""
            lbl_tasa.Text = ""
            lbl_valorCOP.Text = ""
            lbl_tipocontrato.Text = ""
            lbl_rubro.Text = ""
            lblid.Text = ""
            chkAprobacion_Financiera.Checked = False
            chkAprobacion_pais.Checked = False
        End If

    End Sub

    Protected Sub btn_contratos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_contratos.Click
        Dim objContrato As Ppto_ContratosBrl = Ppto_ContratosBrl.CargarPorID(lblid.Text)
        objContrato.Aprobacion_Financiera = False
        objContrato.Aprobacion_Pais = False
        objContrato.Guardar()
        ddl_contratos.SelectedValue = 0
        btn_buscar_Click(Nothing, Nothing)
    End Sub
End Class
