<%@ Page Title="" Language="VB" MasterPageFile="~/Controles/MasterPage.master" AutoEventWireup="false" CodeFile="Sucursales.aspx.vb" Inherits="Webforms_Sucursales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <telerik:RadScriptManager ID="RadScriptManager1" runat="server"/>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="SUCURSAL" />
    
    <asp:Panel ID="pnl_principal" runat="server" DefaultButton ="btnGuardar" Width ="100%">
    <table id="TablaContenido" cellspacing="0" cellpadding="0" border="0" class="ContentTable" style="width: 100%">
        <tr valign="top">
        <td style="width: 75%"> 
            <asp:Label ID="lbl_Titulo" runat="server" Text="CREACION / MODIFICACION DE SUCURSALES" Width="90%" CssClass="TitTitulo" BackColor="PeachPuff"></asp:Label><br />
            <asp:Label ID="lblMensaje" runat="server" CssClass="TitMensaje" Text="_" Width="90%" Visible="False"/>
        </td>
        <td style="width: 25%" align="right">
            <asp:ImageButton ID="btn_actualizar" runat="server" ImageUrl="~/Images/Reload.jpg" ToolTip="Actualizar la vista actual." TabIndex="10" />
            <asp:ImageButton ID="btn_nuevo" runat="server" ImageUrl="~/Images/Add.jpg" ToolTip="Crear Nuevo Registro." TabIndex="11" />
            <asp:ImageButton ID="btn_cerrar" runat="server" ImageUrl="~/Images/Stop.jpg" ToolTip="Cerrar - Volver a la vista anterior." TabIndex="12" />
            <asp:ImageButton ID="btn_home" runat="server" ImageUrl="~/Images/Home.jpg" ToolTip="Ir al Inicio." TabIndex="13" />&nbsp;</td>
        </tr>

        <tr valign="top">
            <td>
                <table id="tblContenido" class="EditControlsTable" cellspacing="0" cellpadding="0" border="0" style="width: 100%">
                    <tr valign="top">
                        <td  class="LabelCell" style="width: 30%; height: 16px;">
                            <asp:Label ID="Label5" runat="server" Width="90%">Regional enlazada con el SIIRD</asp:Label></td>
                        <td class="ControlCell" style="width: 70%; height: 16px;">
                            <asp:DropDownList ID="ddl_regional" runat="server" CssClass="drop01" Width="50%">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfv_enlace" runat="server" ControlToValidate="ddl_regional"
                                EnableClientScript="False" ErrorMessage="Falta la Relación con el SIIRD" ValidationGroup="SUCURSAL">*</asp:RequiredFieldValidator></td>
                    </tr>
                    <tr valign="top">
                        <td  class="LabelCell" style="width: 30%">
                            <asp:Label id="lblNumero" runat="server" Width="90%">Nombre de la Sucursal</asp:Label>
                        </td>
                        <td class="ControlCell" style="width: 70%">
                            <asp:TextBox id="txt_Nombre" runat = "server" Width="90%" CssClass="Digitar" TabIndex="1"/>
                            <asp:RequiredFieldValidator ID="rfv_Nombre" runat="server" ControlToValidate="txt_Nombre"
                                EnableClientScript="False" ErrorMessage="Falta el Nombre de Sucursal" ValidationGroup="SUCURSAL">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr valign="top">
                        <td class="LabelCell" style="width: 30%">
                            <asp:Label ID="Label1" runat="server" Width="90%">Dirección</asp:Label></td>
                        <td class="ControlCell" style="width: 70%">
                            <asp:TextBox id="txt_direccion" runat = "server" Width="90%" CssClass="Digitar" MaxLength="800" Rows="3" TextMode="MultiLine" TabIndex="2"/></td>
                    </tr>
                    <tr valign="top">
                        <td class="LabelCell" style="width: 30%">
                            <asp:Label ID="Label2" runat="server" Width="90%">Telefonos de Contacto</asp:Label></td>
                        <td class="ControlCell" style="width: 70%">
                            <asp:TextBox id="txt_telefonos" runat = "server" Width="90%" CssClass="Digitar" TabIndex="3"/></td>
                    </tr>
                    <tr valign="top">
                        <td class="LabelCell" style="width: 30%">
                            <asp:Label ID="Label3" runat="server" Width="90%">Nombre del Contacto en la Sucursal</asp:Label></td>
                        <td class="ControlCell" style="width: 70%">
                            <asp:TextBox id="txt_contacto" runat = "server" Width="90%" CssClass="Digitar" TabIndex="4"/></td>
                    </tr>
                    <tr valign="top">
                        <td class="LabelCell" style="width: 30%">
                            <asp:Label ID="Label4" runat="server" Width="90%">Texto Financiero</asp:Label></td>
                        <td class="ControlCell" style="width: 70%">
                            <asp:TextBox id="txt_TextoFinanciero" runat = "server" Width="90%" CssClass="Digitar" MaxLength="800" Rows="3" TextMode="MultiLine" TabIndex="5"/></td>
                    </tr>
                </table>
            </td>
            <td style="width: 33%"></td>
        </tr>
    </table>
    
    <asp:Panel ID="pnl_final" runat="server" Width="100%" style="vertical-align: middle; text-align: center" >
    <table border="0" cellpadding="0" cellspacing="0" style="width: 90%">
        <tr valign="top">
            <td style="width: 15%; height: 16px;">
            </td>
            <td style="width: 15%; height: 16px;">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" cssClass="Boton" Width="100px" TabIndex="6"></asp:Button>
            </td>
            <td style="width: 16%; height: 16px;">
                <asp:Button ID="btnGuardarOtro" runat="server" Text="Guardar y agregar otro" cssClass="Boton" Width="150px" TabIndex="7"></asp:Button>
            </td>
            <td style="width: 15%; height: 16px;">
                <asp:Button ID="btnEliminar" runat="server" Text='Eliminar' CssClass="Boton" Width="100px" TabIndex="8"></asp:Button>
            </td>
            <td style="width: 15%; height: 16px;">
                <asp:Button ID="btnCerrar" runat="server" Text="Cerrar" cssClass="Boton" Width="100px" TabIndex="9"></asp:Button>
            </td>
            <td style="width: 15%; height: 16px;">
            </td>
        </tr>
    </table>
    </asp:Panel>     
    </asp:Panel>                    
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="LoadingPanel2">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btn_actualizar">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="pnl_principal" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btn_nuevo">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="pnl_principal" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnGuardar">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ValidationSummary1" />
                    <telerik:AjaxUpdatedControl ControlID="lblMensaje" />
                    <telerik:AjaxUpdatedControl ControlID="ddl_regional" />
                    <telerik:AjaxUpdatedControl ControlID="txt_Nombre" />
                    <telerik:AjaxUpdatedControl ControlID="txt_direccion" />
                    <telerik:AjaxUpdatedControl ControlID="txt_telefonos" />
                    <telerik:AjaxUpdatedControl ControlID="txt_contacto" />
                    <telerik:AjaxUpdatedControl ControlID="txt_TextoFinanciero" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnGuardarOtro">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ValidationSummary1" />
                    <telerik:AjaxUpdatedControl ControlID="lblMensaje" />
                    <telerik:AjaxUpdatedControl ControlID="ddl_regional" />
                    <telerik:AjaxUpdatedControl ControlID="txt_Nombre" />
                    <telerik:AjaxUpdatedControl ControlID="txt_direccion" />
                    <telerik:AjaxUpdatedControl ControlID="txt_telefonos" />
                    <telerik:AjaxUpdatedControl ControlID="txt_contacto" />
                    <telerik:AjaxUpdatedControl ControlID="txt_TextoFinanciero" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnEliminar">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="pnl_principal" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="LoadingPanel2" runat="server" BackgroundPosition="Right"
        Height="0px" Transparency="50">
        <asp:Image ID="Image1" runat="server" AlternateText="Cargando..." ImageUrl="~/Images/loading.gif" />
    </telerik:RadAjaxLoadingPanel>

</asp:Content>

