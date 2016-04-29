<%@ Page Title="" Language="VB" MasterPageFile="~/Controles/MasterPage.master" AutoEventWireup="false" CodeFile="Ppto_Ajustes.aspx.vb" Inherits="Webforms_Ppto_Ajustes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <telerik:RadScriptManager ID="RadScriptManager1" runat="server"/>
    <asp:Panel runat="server" ID="pnl_principal" DefaultButton ="btnGuardar" Width ="100%">
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />

    <table id="TablaContenido" cellspacing="0" cellpadding="0" border="0" class="ContentTable" style="width: 100%">
        <tr valign="top">
        <td style="width: 75%"> 
            <asp:Label ID="lbl_Titulo" runat="server" Text="CREACION / MODIFICACION DE AJUSTES" Width="90%" CssClass="TitTitulo" BackColor="PeachPuff"></asp:Label><br />
            <asp:Label ID="lblMensaje" runat="server" CssClass="TitMensaje" Text="_" Width="90%" Visible="False"/></td>
        <td style="width: 25%" align="right">
            <asp:ImageButton ID="btn_actualizar" runat="server" ImageUrl="~/Images/Reload.jpg" ToolTip="Actualizar la vista actual." TabIndex="12" />
            <asp:ImageButton ID="btn_nuevo" runat="server" ImageUrl="~/Images/Add.jpg" ToolTip="Crear Nuevo Registro." TabIndex="13" />
            <asp:ImageButton ID="btn_cerrar" runat="server" ImageUrl="~/Images/Stop.jpg" ToolTip="Cerrar - Volver a la vista anterior." TabIndex="14" />
            <asp:ImageButton ID="btn_home" runat="server" ImageUrl="~/Images/Home.jpg" ToolTip="Ir al Inicio." TabIndex="15" />&nbsp;</td>
        </tr>

        <tr valign="top">
            <td>
                <table id="tblContenido" class="EditControlsTable" cellspacing="0" cellpadding="0" border="0" style="width: 100%">
                    <tr valign="top">
                        <td  class="LabelCell">
                            <asp:Label id="lblFecha" runat="server" Width="90%">Fecha</asp:Label>
                        </td>
                        <td class="ControlCell">
                            <telerik:RadDatePicker ID="rdpFecha" runat="server"  MinDate=""
                                Skin="Sunset" Width="50%" ToolTip="Seleccione Fecha ..." Culture="Spanish (Colombia)">
                                <Calendar Skin="Sunset" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                ViewSelectorText="x">
                                    <FastNavigationSettings CancelButtonCaption="Cancelar" DateIsOutOfRangeMessage="Fecha fuera de rango."
                                        TodayButtonCaption="Hoy">
                                    </FastNavigationSettings>
                                </Calendar>
                            <DatePopupButton HoverImageUrl="" ImageUrl="" ToolTip="Abrir el Calendario" />
                            <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MMMM/yyyy"  EmptyMessage="Fecha ..."/>
                            </telerik:RadDatePicker>
                            <asp:RequiredFieldValidator ID="rfv_fecha" runat="server" ControlToValidate="rdpFecha"
                                EnableClientScript="False" ErrorMessage="Falta la fecha de registro">*</asp:RequiredFieldValidator></td>
                    </tr>
                    <tr valign="top">
                        <td  class="LabelCell">
                            <asp:Label id="lblNumero" runat="server" Width="90%">Tipo de Ajuste</asp:Label>
                        </td>
                        <td class="ControlCell">
                            <asp:RadioButtonList ID="rdb_Tipo" runat="server" AutoPostBack="True" RepeatColumns="2"
                                RepeatDirection="Horizontal" CssClass="Digitar" TabIndex="1">
                                <asp:ListItem Value="C">Contrato</asp:ListItem>
                                <asp:ListItem Value="O">Orden de Compra</asp:ListItem>
                            </asp:RadioButtonList></td>
                    </tr>
                    <tr valign="top">
                        <td  class="LabelCell" style="height: 18px">
                            <asp:Label id="lblPpto_Terceros" runat="server" Width="90%">Contrato</asp:Label>
                        </td>
                        <td class="ControlCell" style="height: 18px">
                            <asp:dropdownlist id="ddl_Contratos" runat="server" CssClass="drop01" Enabled="False" TabIndex="2"/>
                            <asp:RegularExpressionValidator ID="rev_Contratos" runat="server" ControlToValidate="ddl_Contratos"
                                EnableClientScript="False" ErrorMessage="Falta Seleccionar el tercero" ValidationExpression="^[1-9]+[0-9]*$">*</asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr valign="top">
                        <td class="LabelCell" style="height: 18px">
                            <asp:Label ID="Label1" runat="server" Width="90%">Detalle de Orden de  Compra</asp:Label></td>
                        <td class="ControlCell" style="height: 18px">
                            <asp:dropdownlist id="ddl_Ordenes" runat="server" CssClass="drop01" Enabled="False" TabIndex="3"/>
                            <asp:RegularExpressionValidator ID="Rev_Ordenes" runat="server" ControlToValidate="ddl_Ordenes"
                                EnableClientScript="False" ErrorMessage="Falta Seleccionar la Orden de Compra"
                                ValidationExpression="^[1-9]+[0-9]*$">*</asp:RegularExpressionValidator></td>
                    </tr>
                    <tr valign="top">
                        <td class="LabelCell">
                            <asp:Label id="lblValor_USD" runat="server" Width="90%">Valor USD</asp:Label>
                        </td>
                        <td class="ControlCell">
                            <asp:TextBox id="txtValor_USD" runat = "server" style="text-align: right" onkeypress="return ValNumero(this, event)" CssClass="Digitar" AutoPostBack="True" TabIndex="4"/>
                            <asp:RequiredFieldValidator ID="rfv_valorUSD" runat="server" ControlToValidate="txtValor_USD"
                                EnableClientScript="False" ErrorMessage="Falta el Valor en USD">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr valign="top">
                        <td  class="LabelCell">
                            <asp:Label id="lblTRM" runat="server" Width="90%" Text='TRM (Tasa)'/>
                        </td>
                        <td class="ControlCell">
                            <asp:TextBox id="txtTRM" runat = "server" style="text-align: right" onkeypress="return ValNumero(this, event)" CssClass="Digitar" AutoPostBack="True" TabIndex="5"/>
                            <asp:RequiredFieldValidator ID="rfv_Tasa" runat="server" ControlToValidate="txtTRM"
                                EnableClientScript="False" ErrorMessage="Falta la TRM">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr valign="top">
                        <td  class="LabelCell">
                            <asp:Label id="lblValor_COP" runat="server" Width="90%">Valor Pesos</asp:Label>
                        </td>
                        <td class="ControlCell">
                            <asp:TextBox id="txtValor_COP" runat = "server" style="text-align: right" onkeypress="return ValNumero(this, event)" CssClass="Digitar" AutoPostBack="True" TabIndex="6"/>
                            <asp:RequiredFieldValidator ID="rfv_Valor_Pesos" runat="server" ControlToValidate="txtValor_COP"
                                EnableClientScript="False" ErrorMessage="Falta el valor del Contrato en Pesos">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr valign="top">
                        <td class="LabelCell">
                            <asp:Label ID="lblObservaciones" runat="server" Width="90%">Observaciones</asp:Label>
                        </td>
                        <td class="ControlCell">
                            <asp:TextBox ID="txtObservaciones" runat="server" CssClass="Digitar" MaxLength="400"
                                Rows="3" TextMode="MultiLine" Width="90%" TabIndex="7"></asp:TextBox>
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
            <td style="width: 15%; height: 16px;">
            </td>
            <td style="width: 15%; height: 16px;">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" cssClass="Boton" Width="100px" TabIndex="8"></asp:Button>
            </td>
            <td style="width: 16%; height: 16px;">
                <asp:Button ID="btnGuardarOtro" runat="server" Text="Guardar y agregar otro" cssClass="Boton" Width="150px" TabIndex="9"></asp:Button>
            </td>
            <td style="width: 15%; height: 16px;">
                <asp:Button ID="btnEliminar" runat="server" Text='Eliminar' CssClass="Boton" Width="100px" TabIndex="10"></asp:Button>
            </td>
            <td style="width: 15%; height: 16px;">
                <asp:Button ID="btnCerrar" runat="server" Text="Cerrar" cssClass="Boton" Width="100px" TabIndex="11"></asp:Button>
            </td>
            <td style="width: 15%; height: 16px;">
            </td>
        </tr>
    </table>
    </asp:Panel>                         
    </asp:Panel>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="LoadingPanel2">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="rdb_Tipo">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ddl_Contratos" />
                    <telerik:AjaxUpdatedControl ControlID="ddl_Ordenes" />
                </UpdatedControls>
            </telerik:AjaxSetting>
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
                    <telerik:AjaxUpdatedControl ControlID="rdpFecha" />
                    <telerik:AjaxUpdatedControl ControlID="lblNumero" />
                    <telerik:AjaxUpdatedControl ControlID="rdb_Tipo" />
                    <telerik:AjaxUpdatedControl ControlID="ddl_Contratos" />
                    <telerik:AjaxUpdatedControl ControlID="ddl_Ordenes" />
                    <telerik:AjaxUpdatedControl ControlID="txtValor_USD" />
                    <telerik:AjaxUpdatedControl ControlID="txtTRM" />
                    <telerik:AjaxUpdatedControl ControlID="txtValor_COP" />
                    <telerik:AjaxUpdatedControl ControlID="txtObservaciones" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnGuardarOtro">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rdpFecha" />
                    <telerik:AjaxUpdatedControl ControlID="rdb_Tipo" />
                    <telerik:AjaxUpdatedControl ControlID="ddl_Contratos" />
                    <telerik:AjaxUpdatedControl ControlID="ddl_Ordenes" />
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

