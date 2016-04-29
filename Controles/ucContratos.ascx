<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucContratos.ascx.vb" Inherits="Controles_ucContratos" %>

<table id="tbl_contratos" border="1" cellpadding="1" cellspacing="1" style="width: 100%">
    <tr valign ="top">
        <td style="width: 40%">
            <asp:Label ID="Label1" runat="server" CssClass="LabelsDigitar" Text="Seleccione Contrato"
                Width="90%"></asp:Label></td>
        <td style="width: 60%">
            <asp:DropDownList ID="ddl_contratos" runat="server" CssClass="drop01" Width="95%">
            </asp:DropDownList>
            <asp:ImageButton ID="btn_buscar" runat="server" ImageUrl="~/Images/Accept.jpg" ToolTip="Buscar Orden de Compra" /></td>
    </tr>
    <tr valign ="top">
        <td colspan="2" style="width: 100%; background-color: #ff9933">
        </td>
    </tr>
    <tr valign ="top">
        <td colspan="2">
            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                <tr valign ="top">
                    <td style="width: 16%;">
                        <asp:Label ID="lblFecha" runat="server" Width="90%">Fecha</asp:Label></td>
                    <td style="width: 16%;">
                        <asp:Label ID="lbl_fecha" runat="server" Width="90%" CssClass="Digitar"></asp:Label></td>
                    <td style="width: 16%;">
                        <asp:Label ID="lblNumero" runat="server" Width="90%">Numero</asp:Label></td>
                    <td style="width: 16%;">
                        <asp:Label ID="lbl_numero" runat="server" Width="90%" CssClass="Digitar"></asp:Label></td>
                    <td style="width: 16%;">
                        <asp:Label ID="Label2" runat="server" Width="90%">Tipo de Contrato</asp:Label></td>
                    <td style="width: 16%;">
                        <asp:Label ID="lbl_tipocontrato" runat="server" Width="90%" CssClass="Digitar"></asp:Label></td>
                </tr>
                <tr valign ="top">
                    <td style="width: 16%">
                        <asp:Label ID="lblPpto_Terceros" runat="server" Width="90%">Tercero / Proveedor</asp:Label></td>
                    <td colspan="3">
                        <asp:Label ID="lbl_tercero" runat="server" Width="90%" CssClass="Digitar"></asp:Label></td>
                    <td style="width: 16%">
                        <asp:Label ID="lblid" runat="server" CssClass="Digitar" Visible="False" Width="90%"></asp:Label></td>
                    <td style="width: 16%">
                    </td>
                </tr>
                <tr valign ="top">
                    <td style="width: 16%">
                        <asp:Label ID="lblValor_USD" runat="server" Width="90%">Valor USD</asp:Label></td>
                    <td style="width: 16%">
                        <asp:Label ID="lbl_valorUSD" runat="server" Width="90%" CssClass="Digitar"></asp:Label></td>
                    <td style="width: 16%">
                        <asp:Label ID="lblTRM" runat="server" Text="TRM (Tasa)" Width="90%"></asp:Label></td>
                    <td style="width: 16%">
                        <asp:Label ID="lbl_tasa" runat="server" Width="90%" CssClass="Digitar"></asp:Label></td>
                    <td style="width: 16%">
                        <asp:Label ID="lblValor_COP" runat="server" Width="90%">Valor Pesos</asp:Label></td>
                    <td style="width: 16%">
                        <asp:Label ID="lbl_valorCOP" runat="server" Width="90%" CssClass="Digitar"></asp:Label></td>
                </tr>
                <tr valign ="top">
                    <td style="width: 16%">
                        <asp:Label ID="lblNivelId_Nivel" runat="server" Width="90%">Rubro a Aplicar Contrato</asp:Label></td>
                    <td colspan="5">
                        <asp:Label ID="lbl_rubro" runat="server" Width="90%" CssClass="Digitar"></asp:Label></td>
                </tr>
                <tr valign ="top">
                    <td class="LabelCell" style="width: 15%">
                        &nbsp;<asp:Label ID="lblAprobacion_Financiera" runat="server" Font-Bold="False">Aprobación Financiera</asp:Label></td>
                    <td align="center" class="ControlCell" rowspan="1" style="width: 15%">
                        <asp:CheckBox ID="chkAprobacion_Financiera" runat="server" Enabled="False" Text="." /></td>
                    <td class="ControlCell" rowspan="1" style="width: 15%">
                        <asp:Label ID="lblAprobacion_Pais" runat="server" Font-Bold="False">Aprobación País</asp:Label></td>
                    <td align="center" class="ControlCell" rowspan="1" style="width: 15%">
                        <asp:CheckBox ID="chkAprobacion_pais" runat="server" Enabled="False" Text="." /></td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr valign ="top">
        <td colspan="2" style="width: 100%; background-color: #ff9933">
        </td>
    </tr>
    <tr valign ="top">
        <td colspan="2">
            <div style="width: 100%; text-align: center">
                <asp:Button ID="btn_contratos" runat="server" CssClass="Boton" Text="Deshabilitar Contrato"
                    Width="128px" /></div>
        </td>
    </tr>
</table>
<telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server" >
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="btn_buscar">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="ddl_contratos" />
                <telerik:AjaxUpdatedControl ControlID="lbl_fecha" />
                <telerik:AjaxUpdatedControl ControlID="lbl_numero" />
                <telerik:AjaxUpdatedControl ControlID="lbl_tipocontrato" />
                <telerik:AjaxUpdatedControl ControlID="lbl_tercero" />
                <telerik:AjaxUpdatedControl ControlID="lblid" />
                <telerik:AjaxUpdatedControl ControlID="lbl_valorUSD" />
                <telerik:AjaxUpdatedControl ControlID="lbl_tasa" />
                <telerik:AjaxUpdatedControl ControlID="lbl_valorCOP" />
                <telerik:AjaxUpdatedControl ControlID="lbl_rubro" />
                <telerik:AjaxUpdatedControl ControlID="chkAprobacion_Financiera" />
                <telerik:AjaxUpdatedControl ControlID="chkAprobacion_pais" />
                <telerik:AjaxUpdatedControl ControlID="btn_contratos" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="btn_contratos">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="ddl_contratos" />
                <telerik:AjaxUpdatedControl ControlID="lbl_fecha" LoadingPanelID="LoadingPanel2" />
                <telerik:AjaxUpdatedControl ControlID="lbl_numero" />
                <telerik:AjaxUpdatedControl ControlID="lbl_tipocontrato" />
                <telerik:AjaxUpdatedControl ControlID="lblPpto_Terceros" />
                <telerik:AjaxUpdatedControl ControlID="lbl_tercero" />
                <telerik:AjaxUpdatedControl ControlID="lblid" />
                <telerik:AjaxUpdatedControl ControlID="lbl_valorUSD" />
                <telerik:AjaxUpdatedControl ControlID="lbl_tasa" />
                <telerik:AjaxUpdatedControl ControlID="lbl_valorCOP" />
                <telerik:AjaxUpdatedControl ControlID="lbl_rubro" />
                <telerik:AjaxUpdatedControl ControlID="chkAprobacion_Financiera" />
                <telerik:AjaxUpdatedControl ControlID="chkAprobacion_pais" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<telerik:RadAjaxLoadingPanel ID="LoadingPanel2" runat="server" BackgroundPosition="Right"
    Height="0px" Transparency="50">
    <asp:Image ID="Image1" runat="server" AlternateText="Cargando..." ImageUrl="~/Images/loading.gif" />
</telerik:RadAjaxLoadingPanel>
