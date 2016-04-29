<%@ Page Title="" Language="VB" MasterPageFile="~/Controles/MasterPage.master" AutoEventWireup="false" CodeFile="Principal.aspx.vb" Inherits="Webforms_Principal" %>
<%@ Register Src="../Controles/Menu.ascx" TagName="Menu" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <telerik:RadScriptManager ID="RadScriptManager1" runat="server"/>
    <uc1:Menu id="Menu1" runat="server"/>
    <br />
    <asp:Panel runat="server" ID="pnl_principal" DefaultButton ="" Width ="100%">
    <table id="table1" border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr valign="top">
            <td align="center" colspan="2" rowspan="2" valign="middle" style="width: 50%">
                <div class="TitContenido" >
                    <asp:Image ID="Image1" runat="server" Height="70%" ImageUrl="~/Images/siluetacolombia.jpg"
                        Style="vertical-align: top; text-align: center" Width="70%" />
                </div>
            </td>
            <td style="width: 25%" align="center" valign="middle">
                <div class="TitContenido" style="padding-right: 4px; padding-left: 4px; padding-bottom: 4px; padding-top: 4px">
                    <p style="font-weight: bold; vertical-align: middle; text-align: center">
                        <asp:Label ID="lbltexto01" runat="server">SISTEMA DE PRESUPUESTO FINANCIERO</asp:Label>
                    </p>
                    <p style="text-align: justify">
                        <br />
                        <asp:Label ID="lbltexto02" runat="server">A traves de este nuevo modulo se manejara la proyección presupuestal de todos los ingresos de la Organización.
                        <br /><br />
                        La información ingresada a este sistema de Ambiente WEB sera verificada y validada desde la oficina Principal</asp:Label>
                    </p>
                </div>
            </td>
            <td align="center" style="width: 25%" valign="middle">
                <div class="TitContenido"><asp:Image ID="Image2" runat="server" ImageUrl="~/Images/foto02.jpg" Style="vertical-align: middle;
                        text-align: center" Width="240px" />&nbsp;</div>
            </td>
        </tr>
        <tr valign="top">
            <td style="width: 25%;" align="center" valign="middle">
                <div class="TitContenido" style="left: 0px; width: 250px; top: 0px;">
                    <asp:Image ID="ImgFoto02" runat="server" ImageUrl="~/Images/foto01.jpg" Style="vertical-align: middle;
                        text-align: center" Width="240px" />
                </div>
            </td>
            <td style="width: 25%;" align="center" valign="middle">
                <div class="TitContenido" style="padding-right: 4px; padding-left: 4px; padding-bottom: 4px; vertical-align: middle; direction: ltr; padding-top: 4px; text-align: center">
                    <p style="text-align: justify">
                        <asp:Label ID="lbltexto03" runat="server" Width="100%" >
                            Los contratos, Las ordenes de Compra de cualquier indole y los manejos de la caja menor deben ser registrados en este sistema.         
                            <br /><br />
                            Se agradece que cualquier mejora, error o inconsistencia con los recursos aqui asignado sean remitidos al area de informacion para su pronto ajuste.  <br /><br />
                            </asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="lbltexto04" runat="server" style="text-align: center" Width="100%" Font-Bold="True" ForeColor="#C00000">SAFIRD ...  Ver. 4.10.07</asp:Label>
                    </p>
                </div>
            </td>
        </tr>
        <tr valign="top">
            <td colspan="4">
                <div style="left: 0px; vertical-align: middle; width: 100%; text-align: center">
                    <hr />
                    <table id="tblanuncio" runat="server" border="0" cellpadding="0" cellspacing="0"
                        style="vertical-align: middle; text-align: center" width="90%">
                        <tr valign="top">
                            <td align="center" valign="top">
                                <asp:Label ID="lblnombre" runat="server" CssClass="lblanuncio" Text="Nombre Empresa:"></asp:Label>
                                <asp:Label ID="lblnombre1" runat="server" CssClass="lblanuncio" ForeColor="Maroon"></asp:Label>
                                <asp:Label ID="lblsep" runat="server" Text=" - "></asp:Label>
                                <asp:Label ID="lblweb" runat="server" CssClass="lblanuncio" Text="Página WEB:"></asp:Label>
                                <asp:HyperLink ID="lblweb1" runat="server" CssClass="lblanuncio" ForeColor="Maroon">[lblweb1]</asp:HyperLink>
                                <asp:Label ID="lblsep2" runat="server" Text=" - "></asp:Label>
                                <asp:Label ID="lblcorreo" runat="server" CssClass="lblanuncio" Text="Correo Electrónico:"></asp:Label>
                                <asp:HyperLink ID="lblcorreo1" runat="server" CssClass="lblanuncio" ForeColor="Maroon">[lblcorreo1]</asp:HyperLink>
                            </td>
                        </tr>
                        <tr valign="top">
                            <td align="center" style="height: 16px" valign="top">
                                <asp:Label ID="Lbltel" runat="server" CssClass="lblanuncio" Text="Teléfono:"></asp:Label>
                                <asp:Label ID="Lbltel1" runat="server" CssClass="lblanuncio" ForeColor="Maroon"></asp:Label>
                                <asp:Label ID="lblsep3" runat="server" Text=" - "></asp:Label>
                                <asp:Label ID="lblfax" runat="server" CssClass="lblanuncio" Text="Fax:"></asp:Label>
                                <asp:Label ID="lblfax1" runat="server" CssClass="lblanuncio" ForeColor="Maroon"></asp:Label>
                                <asp:Label ID="lblsep4" runat="server" Text=" - "></asp:Label>
                                <asp:Label ID="lblDirecion" runat="server" CssClass="lblanuncio" Text="Dirección:"></asp:Label>
                                <asp:Label ID="lbldireccion1" runat="server" CssClass="lblanuncio" ForeColor="Maroon"></asp:Label>
                            </td>
                        </tr>
                        <tr valign="top">
                            <td align="center" valign="top">
                                <asp:Label ID="lbloa" runat="server" CssClass="lblanuncio" Text="Nota:"></asp:Label>
                                <asp:Label ID="lbloa1" runat="server" CssClass="lblanuncio" ForeColor="Maroon"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
    </asp:Panel> 
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="LoadingPanel2">
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="LoadingPanel2" runat="server" BackgroundPosition="Right"
        Height="0px" Transparency="50">
        <asp:Image ID="Image3" runat="server" AlternateText="Cargando..." ImageUrl="~/Images/loading.gif" />
    </telerik:RadAjaxLoadingPanel>

</asp:Content>

