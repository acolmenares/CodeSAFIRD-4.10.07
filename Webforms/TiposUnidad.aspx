<%@ Page Title="" Language="VB" MasterPageFile="~/Controles/MasterPage.master" AutoEventWireup="false" CodeFile="TiposUnidad.aspx.vb" Inherits="Webforms_TiposUnidad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <telerik:RadScriptManager ID="RadScriptManager1" runat="server"/>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    <asp:Panel runat="server" ID="pnl_principal" DefaultButton ="btn_actualizar" Width ="100%">
    
    <table id="TablaContenido" cellspacing="0" cellpadding="0" border="0" class="ContentTable" style="width: 100%">
        <tr valign="top">
        <td style="width: 75%"> 
            <asp:Label ID="lbl_Titulo" runat="server" Text="CREACION / MODIFICACION DE TIPOS DE UNIDAD" Width="90%" CssClass="TitTitulo" BackColor="PeachPuff"></asp:Label><br />
            <asp:Label ID="lblMensaje" runat="server" CssClass="TitMensaje" Text="_" Width="90%" Visible="False"/>
        </td>
        <td style="width: 25%" align="right">
            <asp:ImageButton ID="btn_actualizar" runat="server" ImageUrl="~/Images/Reload.jpg" ToolTip="Actualizar la vista actual." TabIndex="5" />
            <asp:ImageButton ID="btn_nuevo" runat="server" ImageUrl="~/Images/Add.jpg" ToolTip="Crear Nuevo Registro." TabIndex="6" />
            <asp:ImageButton ID="btn_cerrar" runat="server" ImageUrl="~/Images/Stop.jpg" ToolTip="Cerrar - Volver a la vista anterior." TabIndex="7" />
            <asp:ImageButton ID="btn_home" runat="server" ImageUrl="~/Images/Home.jpg" ToolTip="Ir al Inicio." TabIndex="8" />&nbsp;</td>
        </tr>

        <tr valign="top">
            <td>
                <table id="tblContenido" class="EditControlsTable" cellspacing="0" cellpadding="0" border="0" style="width: 100%">
                    <tr valign="top">
                        <td  class="LabelCell" style="width: 30%">
                        </td>
                        <td class="ControlCell" style="width: 70%">
                            </td>
                    </tr>
                    <tr valign="top">
                        <td  class="LabelCell" style="width: 30%">
                            <asp:Label id="lblNumero" runat="server" Width="90%">Descripción Tipo de Unidad</asp:Label>
                        </td>
                        <td class="ControlCell" style="width: 70%">
                            <asp:TextBox id="txtNombre" runat = "server" Width="90%" CssClass="Digitar"/>
                            <asp:RequiredFieldValidator ID="rfv_Nombre" runat="server" ControlToValidate="txtNombre"
                                EnableClientScript="False" ErrorMessage="Falta el Nombre de Tipo de Unidad">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
            </td>
            <td style="width: 33%"></td>
        </tr>
    </table>
    
    <asp:Panel ID="pnl_final" runat="server" Width="100%" style="vertical-align: middle; text-align: center" >
    <table border="0" cellpadding="0" cellspacing="0" style="width: 90%">
        <tr valign="top">
            <td style="width: 15%;">
            </td>
            <td style="width: 15%;">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" cssClass="Boton" Width="100px" TabIndex="1"></asp:Button>
            </td>
            <td style="width: 16%;">
                <asp:Button ID="btnGuardarOtro" runat="server" Text="Guardar y agregar otro" cssClass="Boton" Width="150px" TabIndex="2"></asp:Button>
            </td>
            <td style="width: 15%;">
                <asp:Button ID="btnEliminar" runat="server" Text='Eliminar' CssClass="Boton" Width="100px" TabIndex="3"></asp:Button>
            </td>
            <td style="width: 15%;">
                <asp:Button ID="btnCerrar" runat="server" Text="Cerrar" cssClass="Boton" Width="100px" TabIndex="4"></asp:Button>
            </td>
            <td style="width: 15%;">
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
            <telerik:AjaxSetting AjaxControlID="btnGuardar">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ValidationSummary1" />
                    <telerik:AjaxUpdatedControl ControlID="txtNombre" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnGuardarOtro">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ValidationSummary1" />
                    <telerik:AjaxUpdatedControl ControlID="txtNombre" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="LoadingPanel2" runat="server" BackgroundPosition="Right"
        Height="0px" Transparency="50">
        <asp:Image ID="Image1" runat="server" AlternateText="Cargando..." ImageUrl="~/Images/loading.gif" />
    </telerik:RadAjaxLoadingPanel>

</asp:Content>

