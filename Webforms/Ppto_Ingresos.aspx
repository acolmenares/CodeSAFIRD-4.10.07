<%@ Page Title="" Language="VB" MasterPageFile="~/Controles/MasterPage.master" AutoEventWireup="false" CodeFile="Ppto_Ingresos.aspx.vb" Inherits="Webforms_Ppto_Ingresos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <telerik:RadScriptManager ID="RadScriptManager1" runat="server"/>
    
    <asp:Panel runat="Server" DefaultButton ="btnGuardar" ID="pnl_principal" Width ="100%">
    <table id="TablaContenido" cellspacing="0" cellpadding="0" border="0" class="ContentTable" style="width: 100%">
        <tr valign="top">
        <td style="width: 75%"> 
            <asp:Label ID="lbl_Titulo" runat="server" Text="CREACION / MODIFICACION DE INGRESOS" Width="90%" CssClass="TitTitulo" BackColor="PeachPuff"></asp:Label><br />
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
                        <td  class="LabelCell" style="width: 40%">
                            <asp:Label id="lblFecha" runat="server" Width="90%">Fecha</asp:Label>
                        </td>
                        <td class="ControlCell" style="width: 60%">
                            <telerik:RadDatePicker ID="rdpFecha" runat="server"  MinDate=""
                                Skin="Sunset" Width="50%" ToolTip="Seleccione Fecha ..." Culture="Spanish (Colombia)">
                                <Calendar Skin="Sunset" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                ViewSelectorText="x">
                                    <FastNavigationSettings CancelButtonCaption="Cancelar" DateIsOutOfRangeMessage="Fecha fuera de rango"
                                        TodayButtonCaption="Hoy">
                                    </FastNavigationSettings>
                                </Calendar>
                            <DatePopupButton HoverImageUrl="" ImageUrl="" ToolTip="Abrir el Calendario" />
                            <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MMMM/yyyy"  EmptyMessage="Fecha ..."/>
                            </telerik:RadDatePicker>
                            </td>
                    </tr>
                    <tr valign="top">
                        <td  class="LabelCell" style="width: 40%">
                            <asp:Label id="lblNombre" runat="server" Width="90%">Nombre de Entidad</asp:Label>
                        </td>
                        <td class="ControlCell" style="width: 60%">
                            <asp:TextBox id="txtNombre" runat = "server" Width="90%" CssClass="Digitar" TabIndex="1"/></td>
                    </tr>
                    <tr valign="top">
                        <td class="LabelCell" style="width: 40%">
                            <asp:Label id="lblValor_USD" runat="server" Width="90%">Valor USD</asp:Label>
                        </td>
                        <td class="ControlCell" style="width: 60%">
                            <asp:TextBox id="txtValor_USD" runat = "server" style="text-align: right" onkeypress="return ValNumero(this, event)" CssClass="Digitar" Width="50%" AutoPostBack="True" TabIndex="2"/></td>
                    </tr>
                    <tr valign="top">
                        <td  class="LabelCell" style="width: 40%">
                            <asp:Label id="lblTRM" runat="server" Width="90%" Text='TRM (Tasa)'/>
                        </td>
                        <td class="ControlCell" style="width: 60%">
                            <asp:TextBox id="txtTRM" runat = "server" style="text-align: right" onkeypress="return ValNumero(this, event)" CssClass="Digitar" Width="50%" AutoPostBack="True" TabIndex="3"/></td>
                    </tr>
                    <tr valign="top">
                        <td  class="LabelCell" style="width: 40%">
                            <asp:Label id="lblValor_COP" runat="server" Width="90%">Valor Pesos</asp:Label>
                        </td>
                        <td class="ControlCell" style="width: 60%">
                            <asp:TextBox id="txtValor_COP" runat = "server" style="text-align: right" onkeypress="return ValNumero(this, event)" CssClass="Digitar" Width="50%" AutoPostBack="True" TabIndex="4"/></td>
                    </tr>
                    <tr valign="top">
                        <td  class="LabelCell" style="width: 40%">
                            <asp:Label id="lblObservaciones" runat="server" Width="90%">Observaciones</asp:Label>
                        </td>
                        <td class="ControlCell" style="width: 60%">
                            <asp:TextBox id="txtObservaciones" runat = "server" MaxLength="400" Rows="3" TextMode="MultiLine" Width="90%" CssClass="Digitar" TabIndex="5"></asp:TextBox>
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
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" cssClass="Boton" Width="100px" TabIndex="6" ToolTip="Guardar el registro y quedar en el"></asp:Button>
            </td>
            <td style="width: 16%;">
                <asp:Button ID="btnGuardarOtro" runat="server" Text="Guardar y agregar otro" cssClass="Boton" Width="150px" TabIndex="7" ToolTip="Guardar el registro y alistarse para uno nuevo"></asp:Button>
            </td>
            <td style="width: 15%;">
                <asp:Button ID="btnEliminar" runat="server" Text='Eliminar' CssClass="Boton" Width="100px" TabIndex="8" ToolTip="Eliminar registro actual"></asp:Button>
            </td>
            <td style="width: 15%;">
                <asp:Button ID="btnCerrar" runat="server" Text="Cerrar" cssClass="Boton" Width="100px" TabIndex="9" ToolTip="Cerrar Vista Actual "></asp:Button>
            </td>
            <td style="width: 15%;">
            </td>
        </tr>
    </table>
    </asp:Panel>  
    
</asp:Panel>                           
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="LoadingPanel2">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="txtValor_USD">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="txtValor_USD" />
                    <telerik:AjaxUpdatedControl ControlID="txtTRM" />
                    <telerik:AjaxUpdatedControl ControlID="txtValor_COP" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="txtTRM">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="txtValor_USD" />
                    <telerik:AjaxUpdatedControl ControlID="txtTRM" />
                    <telerik:AjaxUpdatedControl ControlID="txtValor_COP" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="txtValor_COP">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="txtValor_USD" />
                    <telerik:AjaxUpdatedControl ControlID="txtTRM" />
                    <telerik:AjaxUpdatedControl ControlID="txtValor_COP" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnGuardar">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="lblMensaje" />
                    <telerik:AjaxUpdatedControl ControlID="rdpFecha" />
                    <telerik:AjaxUpdatedControl ControlID="txtNombre" />
                    <telerik:AjaxUpdatedControl ControlID="txtValor_USD" />
                    <telerik:AjaxUpdatedControl ControlID="txtTRM" />
                    <telerik:AjaxUpdatedControl ControlID="txtValor_COP" />
                    <telerik:AjaxUpdatedControl ControlID="txtObservaciones" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnGuardarOtro">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="lblMensaje" />
                    <telerik:AjaxUpdatedControl ControlID="rdpFecha" />
                    <telerik:AjaxUpdatedControl ControlID="txtNombre" />
                    <telerik:AjaxUpdatedControl ControlID="txtValor_USD" />
                    <telerik:AjaxUpdatedControl ControlID="txtTRM" />
                    <telerik:AjaxUpdatedControl ControlID="txtValor_COP" />
                    <telerik:AjaxUpdatedControl ControlID="txtObservaciones" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnEliminar">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="lblMensaje" />
                    <telerik:AjaxUpdatedControl ControlID="rdpFecha" />
                    <telerik:AjaxUpdatedControl ControlID="txtNombre" />
                    <telerik:AjaxUpdatedControl ControlID="txtValor_USD" />
                    <telerik:AjaxUpdatedControl ControlID="txtTRM" />
                    <telerik:AjaxUpdatedControl ControlID="txtValor_COP" />
                    <telerik:AjaxUpdatedControl ControlID="txtObservaciones" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
     <telerik:RadAjaxLoadingPanel ID="LoadingPanel2" runat="server" BackgroundPosition="Right"
        Height="0px" Transparency="50">
        <asp:Image ID="Image1" runat="server" AlternateText="Cargando..." ImageUrl="~/Images/loading.gif" />
    </telerik:RadAjaxLoadingPanel>

</asp:Content>

