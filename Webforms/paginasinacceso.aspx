<%@ Page Title="" Language="VB" MasterPageFile="~/Controles/MasterPage.master" AutoEventWireup="false" CodeFile="paginasinacceso.aspx.vb" Inherits="Webforms_paginasinacceso" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <telerik:RadScriptManager ID="RadScriptManager1" runat="server"/>
    <asp:Panel runat="server" ID="pnl_principal" DefaultButton ="Button1" Width ="100%">
        <table style="width: 100%;" cellpadding="0" cellspacing="0" border="0">
            <tr valign="top">
                <td align="center" style="height: 30px" >
                </td>
            </tr>
            <tr valign="top">
                <td align="center" >
                    <img src="../Images/restrictedZone.JPG" /></td>
            </tr>
            <tr valign="top">
                <td align="center" style="vertical-align: middle; height: 50px; text-align: center" >
                    <asp:Button ID="Button1" runat="server" CssClass="Boton" Text="Regresar al Menú Principal" Width="200px" /></td>
            </tr>
        </table>
    </asp:Panel>

</asp:Content>

