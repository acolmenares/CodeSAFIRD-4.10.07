<%@ Page Title="" Language="VB" MasterPageFile="~/Controles/MasterPage.master" AutoEventWireup="false" CodeFile="EliminarAprobaciones.aspx.vb" Inherits="Webforms_EliminarAprobaciones" %>
<%@ Register Src="../Controles/ucContratos.ascx" TagName="ucContratos" TagPrefix="uc1" %>
<%@ Register Src="../Controles/ucOrdenCompra.ascx" TagName="ucOrdenCompra" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <telerik:RadScriptManager ID="RadScriptManager1" runat="server"/>
    <asp:Panel runat="server" ID="pnl_principal" DefaultButton ="btn_cerrar" Width ="100%">
    <table id="TablaContenido" border="0" cellpadding="0" cellspacing="0" class="ContentTable"
        style="width: 100%">
        <tr valign ="top">
            <td style="width: 75%">
                <asp:Label ID="lbl_Titulo" runat="server" BackColor="PeachPuff" CssClass="TitTitulo"
                    Text="SISTEMA DE DESHABILITAR APROBACIONES" Width="90%"></asp:Label><br />
                <asp:Label ID="lblMensaje" runat="server" CssClass="TitMensaje" Text="_" Visible="False"
                    Width="90%"></asp:Label>
            </td>
            <td align="right" style="width: 25%">
                <asp:ImageButton ID="btn_cerrar" runat="server" ImageUrl="~/Images/Stop.jpg" ToolTip="Cerrar - Volver a la vista anterior." />
                <asp:ImageButton ID="btn_home" runat="server" ImageUrl="~/Images/Home.jpg" ToolTip="Ir al Inicio." />&nbsp;</td>
        </tr>
        <tr valign ="top">
            <td colspan="2">
                <telerik:RadPanelBar ID="RadPanelBar1" runat="server" Skin="Outlook" Width="90%" ExpandMode="SingleExpandedItem">
                    <CollapseAnimation Type="None"></CollapseAnimation>
                    <Items>
                        <telerik:RadPanelItem runat="server"  Text="Contratos">
                            <Items>
                            <telerik:RadPanelItem runat="server" Value="rpi_Contrato">
                                <ItemTemplate>
                                    <uc1:ucContratos ID="ucContratos1" runat="server" />
                                </ItemTemplate>
                            </telerik:RadPanelItem> 
                            </Items>     
                        </telerik:RadPanelItem>
                        <telerik:RadPanelItem runat="server" Text="Orden de Compra">
                            <Items>
                            <telerik:RadPanelItem runat="server" Value="rpi_OrdenCompra">
                                <ItemTemplate>
                                    <uc2:ucOrdenCompra ID="ucOrdenCompra1" runat="server" />
                                </ItemTemplate>
                            </telerik:RadPanelItem>
                            </Items> 
                        </telerik:RadPanelItem> 
                    </Items>
                </telerik:RadPanelBar>
            </td>
        </tr>
    </table>
    </asp:Panel> 

</asp:Content>

