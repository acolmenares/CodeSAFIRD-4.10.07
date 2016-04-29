<%@ Page Title="" Language="VB" MasterPageFile="~/Controles/MasterPage.master" AutoEventWireup="false" CodeFile="Ppto_Contratos.aspx.vb" Inherits="Webforms_Ppto_Contratos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <telerik:RadScriptManager ID="RadScriptManager1" runat="server"/>
    
    <asp:Panel ID="pnl_principal" runat="server" DefaultButton="btnGuardar" Width="100%">
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="PROD" />
      <table id="TablaContenido" cellspacing="0" cellpadding="0" border="0" class="ContentTable" style="width: 100%">
        <tr valign="top">
        <td style="width: 75%"> 
            <asp:Label ID="lbl_Titulo" runat="server" Text="CREACION / MODIFICACION DE CONTRATOS" Width="90%" CssClass="TitTitulo" BackColor="PeachPuff"></asp:Label><br />
            <asp:Label ID="lblMensaje" runat="server" CssClass="TitMensaje" Text="_" Width="90%" Visible="False"/></td>
        <td style="width: 25%" align="right">
            <asp:ImageButton ID="btn_actualizar" runat="server" ImageUrl="~/Images/Reload.jpg" ToolTip="Actualizar la vista actual." TabIndex="17" />
            <asp:ImageButton ID="btn_nuevo" runat="server" ImageUrl="~/Images/Add.jpg" ToolTip="Crear Nuevo Registro." TabIndex="18" />
            <asp:ImageButton ID="btn_cerrar" runat="server" ImageUrl="~/Images/Stop.jpg" ToolTip="Cerrar - Volver a la vista anterior." TabIndex="19" />
            <asp:ImageButton ID="btn_home" runat="server" ImageUrl="~/Images/Home.jpg" ToolTip="Ir al Inicio." TabIndex="20" />&nbsp;</td>
        </tr>

        <tr valign="top">
            <td colspan="2">
                <table id="tblContenido" class="EditControlsTable" cellspacing="0" cellpadding="0" border="0" style="width: 100%">
                    <tr valign="top">
                        <td  class="LabelCell" style="width: 30%">
                            <asp:Label id="lblFecha" runat="server" Width="90%">Fecha</asp:Label>
                        </td>
                        <td class="ControlCell" style="width: 70%" colspan="">
                            <telerik:RadDatePicker ID="rdpFecha" runat="server"  MinDate=""
                                Skin="Sunset" Width="30%" ToolTip="Seleccione Fecha ..." Culture="Spanish (Colombia)">
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
                                EnableClientScript="False" ErrorMessage="Falta la fecha de registro" ValidationGroup="PROD">*</asp:RequiredFieldValidator></td>
                    </tr>
                    <tr valign="top">
                        <td  class="LabelCell" style="width: 30%">
                            <asp:Label id="lblNumero" runat="server" Width="90%">Numero</asp:Label>
                        </td>
                        <td class="ControlCell" style="width: 70%">
                            <asp:TextBox id="txtNumero" runat = "server"  CssClass="Digitar" MaxLength="10" TabIndex="1"/>
                            <asp:RequiredFieldValidator ID="rfv_Contrato" runat="server" ControlToValidate="txtNumero"
                                EnableClientScript="False" ErrorMessage="Falta el Número del Contrato" ValidationGroup="PROD">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr valign="top">
                        <td  class="LabelCell" style="width: 30%;">
                            <asp:Label id="lblPpto_Terceros" runat="server" Width="90%">Tercero / Proveedor</asp:Label>
                        </td>
                        <td class="ControlCell" style="width: 70%;">
                            <asp:TextBox ID="txt_codprv" runat="server" AutoPostBack="True" CssClass="Digitar" TabIndex="2"></asp:TextBox><asp:dropdownlist id="ddl_Terceros" runat="server" CssClass="drop01" AutoPostBack="True" TabIndex="3"/><asp:RegularExpressionValidator ID="rev_Grupo" runat="server" ControlToValidate="ddl_Terceros"
                                EnableClientScript="False" ErrorMessage="Falta Seleccionar el tercero" ValidationExpression="^[1-9]+[0-9]*$" ValidationGroup="PROD">*</asp:RegularExpressionValidator></td>
                    </tr>
                    <tr valign="top">
                        <td class="LabelCell" style="width: 30%">
                            <asp:Label ID="Label1" runat="server" Width="90%">Tipo de Contrato</asp:Label></td>
                        <td class="ControlCell" style="width: 70%">
                            <asp:dropdownlist id="ddl_Tipo_Orden" runat="server" CssClass="drop01" AutoPostBack="True" TabIndex="4"/>
                            <asp:RegularExpressionValidator ID="rev_Tipo_Orden" runat="server" ControlToValidate="ddl_Tipo_Orden"
                                EnableClientScript="False" ErrorMessage="Falta Seleccionar el tipo de Contrato"
                                ValidationExpression="^[1-9]+[0-9]*$" ValidationGroup="PROD">*</asp:RegularExpressionValidator></td>
                    </tr>
                    <tr valign="top">
                        <td class="LabelCell" style="width: 30%">
                            <asp:Label id="lblValor_USD" runat="server" Width="90%">Valor USD</asp:Label>
                        </td>
                        <td class="ControlCell" style="width: 70%">
                            <asp:TextBox id="txtValor_USD" runat = "server" style="text-align: right" onkeypress="return ValNumero(this, event)" CssClass="Digitar" Width="30%" AutoPostBack="True" TabIndex="5"/>
                            <asp:RequiredFieldValidator ID="rfv_valorUSD" runat="server" ControlToValidate="txtValor_USD"
                                EnableClientScript="False" ErrorMessage="Falta el Valor en USD" ValidationGroup="PROD">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr valign="top">
                        <td  class="LabelCell" style="width: 30%">
                            <asp:Label id="lblTRM" runat="server" Width="90%" Text='TRM (Tasa)'/>
                        </td>
                        <td class="ControlCell" style="width: 70%">
                            <asp:TextBox id="txtTRM" runat = "server" style="text-align: right" onkeypress="return ValNumero(this, event)" CssClass="Digitar" Width="30%" AutoPostBack="True" TabIndex="6"/>
                            <asp:RequiredFieldValidator ID="rfv_Tasa" runat="server" ControlToValidate="txtTRM"
                                EnableClientScript="False" ErrorMessage="Falta la TRM" ValidationGroup="PROD">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr valign="top">
                        <td  class="LabelCell" style="width: 30%">
                            <asp:Label id="lblValor_COP" runat="server" Width="90%">Valor Pesos</asp:Label>
                        </td>
                        <td class="ControlCell" style="width: 70%">
                            <asp:TextBox id="txtValor_COP" runat = "server" style="text-align: right" onkeypress="return ValNumero(this, event)" CssClass="Digitar" Width="30%" AutoPostBack="True" TabIndex="7"/>
                            <asp:RequiredFieldValidator ID="rfv_Valor_Pesos" runat="server" ControlToValidate="txtValor_COP"
                                EnableClientScript="False" ErrorMessage="Falta el valor del Contrato en Pesos" ValidationGroup="PROD">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr valign="top">
                        <td class="LabelCell" style="width: 30%">
                            <asp:Label ID="Label2" runat="server" Width="90%">Código del Proyecto</asp:Label></td>
                        <td class="ControlCell" style="width: 70%">
                            <asp:TextBox id="Txt_CodigoProyecto" runat = "server"  CssClass="Digitar" MaxLength="10" Width="30%" TabIndex="8"/>
                            <asp:RequiredFieldValidator ID="rfv_CodigoProyecto" runat="server" ControlToValidate="Txt_CodigoProyecto"
                                EnableClientScript="False" ErrorMessage="Falta el Código del Proyecto" ValidationGroup="PROD">*</asp:RequiredFieldValidator></td>
                    </tr>
                    <tr valign="top">
                        <td class="LabelCell" style="width: 30%">
                            <asp:Label ID="Label3" runat="server" Width="90%">Fecha Inicial del Contrato</asp:Label></td>
                        <td class="ControlCell" style="width: 70%">
                            <telerik:RadDatePicker ID="rdp_Fecha_Inicial_Contrato" runat="server"  MinDate=""
                                Skin="Sunset" Width="30%" ToolTip="Seleccione Fecha ..." TabIndex="9" Culture="Spanish (Colombia)">
                                <Calendar Skin="Sunset" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                ViewSelectorText="x">
                                    <FastNavigationSettings CancelButtonCaption="Cancelar" DateIsOutOfRangeMessage="Fecha fuera de rango."
                                        TodayButtonCaption="Hoy">
                                    </FastNavigationSettings>
                                </Calendar>
                                <DatePopupButton HoverImageUrl="" ImageUrl="" ToolTip="Abrir el Calendario" TabIndex="9" />
                                <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MMMM/yyyy"  EmptyMessage="Fecha ..." TabIndex="9"/>
                            </telerik:RadDatePicker>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="rdp_Fecha_Inicial_Contrato"
                                EnableClientScript="False" ErrorMessage="Falta la fecha de inicio de contrato"
                                ValidationGroup="PROD">*</asp:RequiredFieldValidator></td>
                    </tr>
                    <tr valign="top">
                        <td class="LabelCell" style="width: 30%;">
                            <asp:Label ID="Label4" runat="server" Width="90%">Fecha Final del Contrato</asp:Label></td>
                        <td class="ControlCell" style="width: 70%;">
                            <telerik:RadDatePicker ID="rdp_Fecha_Final_Contrato" runat="server"  MinDate=""
                                Skin="Sunset" Width="30%" ToolTip="Seleccione Fecha ..." TabIndex="10" Culture="Spanish (Colombia)">
                                <Calendar Skin="Sunset" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                ViewSelectorText="x">
                                    <FastNavigationSettings CancelButtonCaption="Cancelar" DateIsOutOfRangeMessage="Fecha fuera de rango."
                                        TodayButtonCaption="Hoy">
                                    </FastNavigationSettings>
                                </Calendar>
                                <DatePopupButton HoverImageUrl="" ImageUrl="" ToolTip="Abrir el Calendario" TabIndex="10" />
                                <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MMMM/yyyy"  EmptyMessage="Fecha ..." TabIndex="10"/>
                            </telerik:RadDatePicker>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="rdp_Fecha_Final_Contrato"
                                EnableClientScript="False" ErrorMessage="Falta la fecha final del contrato" ValidationGroup="PROD">*</asp:RequiredFieldValidator></td>
                    </tr>
                    <tr valign="top">
                        <td  class="LabelCell" style="width: 30%">
                            <asp:Label id="lblNivelId_Nivel" runat="server" Width="90%">Rubro a Aplicar Contrato</asp:Label>
                        </td>
                        <td class="ControlCell" style="width: 70%">
                            <telerik:RadComboBox ID="RadComboBox2" Width="90%" 
                                AllowCustomText="true" EmptyMessage="Seleccione el rubro presupuestal" OnClientDropDownClosing="OnClientDropDownClosingHandler"
                                runat="server" TabIndex="11" Height="300px">
                                <ItemTemplate>
                                    <div onclick="StopPropagation(event)">
                                        <telerik:RadTreeView ID="RadTreeView1" runat="server" OnClientNodeClicking="OnClientNodeClickingHandler" >
                                            <DataBindings>
                                                <telerik:RadTreeNodeBinding Depth="0" Category="Make"  />
                                            </DataBindings>
                                        </telerik:RadTreeView>
                                    </div>
                                </ItemTemplate>
                                <Items>
                                    <telerik:RadComboBoxItem runat="server" />
                                </Items>
                            </telerik:RadComboBox>                        
                        
                        </td>
                    </tr>
                    <tr valign="top">
                        <td  class="LabelCell" style="width: 30%">
                            <asp:Label id="lblObservaciones" runat="server" Width="90%">Observaciones</asp:Label>
                        </td>
                        <td class="ControlCell" style="width: 70%">
                            <asp:TextBox id="txtObservaciones" runat = "server" MaxLength="400" Rows="3" TextMode="MultiLine" Width="90%" CssClass="Digitar" TabIndex="12"></asp:TextBox>
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
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" cssClass="Boton" Width="100px" TabIndex="13"></asp:Button>
            </td>
            <td style="width: 16%;">
                <asp:Button ID="btnGuardarOtro" runat="server" Text="Guardar y agregar otro" cssClass="Boton" Width="150px" TabIndex="14"></asp:Button>
            </td>
            <td style="width: 15%;">
                <asp:Button ID="btnEliminar" runat="server" Text='Eliminar' CssClass="Boton" Width="100px" TabIndex="15"></asp:Button>
            </td>
            <td style="width: 15%;">
                <asp:Button ID="btnCerrar" runat="server" Text="Cerrar" cssClass="Boton" Width="100px" TabIndex="16"></asp:Button>
            </td>
            <td style="width: 15%;">
            </td>
        </tr>
    </table>
    
    <script type="text/javascript">
        /* <![CDATA[ */
            var cancelDropDownClosing = false;
            
            function StopPropagation(e)
            {
                //cancel bubbling
                e.cancelBubble = true;
                if (e.stopPropagation)
                {
                    e.stopPropagation();
                }
            }

            function onDropDownClosing()
            {
                cancelDropDownClosing = false;
            }



            //this method hides the nodes of the treeeview depending on 
            //the checked items in the first combobox
            function updateTreeView(values)
            {
                var arrValues = values.split(",");
                var combo2 = $find("<%= RadComboBox2.ClientID %>");
                var tree = combo2.get_items().getItem(0).findControl("RadTreeView1");
                var nodes = tree.get_allNodes(); 
             
                for (var i = 0; i < nodes.length; i++)
                {
                    var node = nodes[i];
                    //set all nodes visible initially
                    node.set_visible(true);
                    //hide all leaf nodes which value does not exist in the values string
                    if (values.indexOf(node.get_value()) == -1 && node.get_value() && values.length > 0)
                    {
                        node.set_visible(false);
                    }
                }
             
                //loop through loop nodes only and hide
                //the ones that does not have any visible child node
                //expand the others
                var rootNodes = tree.get_nodes();
                for (var i = 0; i < rootNodes.get_count(); i++)
                {
                    var root = rootNodes.getNode(i);
                    var showTheRootNode = false;
                    for (var j = 0; j < root.get_nodes().get_count(); j++)
                    {
                        if (root.get_nodes().getNode(j).get_visible())
                        {
                            root.expand();
                            showTheRootNode = true;
                            break;
                        } 
                    }
                    root.set_visible(showTheRootNode);
                }
            } 

            //this method removes the ending comma from a string
            function removeLastComma(str)
            {
                return str.replace(/,$/,"");
            }

            function OnClientNodeClickingHandler(sender, e)
            {
                var node = e.get_node();
                //check if we have clicked on a Make
                if (node.get_category() == "Make")
                {
                    node.toggle();
                }
                else
                {
                    //find the combobox, set its text and close it
                    var combo = $find("<%= RadComboBox2.ClientID %>"); 
                    combo.set_text(node.get_text());
                    cancelDropDownClosing = false;
                    combo.hideDropDown();
                }
            }

            function OnClientDropDownClosingHandler(sender, e)
            {
                //do not close the second combo if 
                //a checkbox from the first is clicked
                e.set_cancel(cancelDropDownClosing);
            }
           
           
        /* ]]> */ 
        </script>
    
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
            <telerik:AjaxSetting AjaxControlID="txt_codprv">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ddl_Terceros" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ddl_Terceros">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="txt_codprv" />
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
                    <telerik:AjaxUpdatedControl ControlID="lblMensaje" />
                    <telerik:AjaxUpdatedControl ControlID="rdpFecha" />
                    <telerik:AjaxUpdatedControl ControlID="txtNumero" />
                    <telerik:AjaxUpdatedControl ControlID="txt_codprv" />
                    <telerik:AjaxUpdatedControl ControlID="ddl_Terceros" />
                    <telerik:AjaxUpdatedControl ControlID="ddl_Tipo_Orden" />
                    <telerik:AjaxUpdatedControl ControlID="txtValor_USD" />
                    <telerik:AjaxUpdatedControl ControlID="txtTRM" />
                    <telerik:AjaxUpdatedControl ControlID="txtValor_COP" />
                    <telerik:AjaxUpdatedControl ControlID="Txt_CodigoProyecto" />
                    <telerik:AjaxUpdatedControl ControlID="rdp_Fecha_Inicial_Contrato" />
                    <telerik:AjaxUpdatedControl ControlID="rdp_Fecha_Final_Contrato" />
                    <telerik:AjaxUpdatedControl ControlID="RadComboBox2" />
                    <telerik:AjaxUpdatedControl ControlID="txtObservaciones" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnGuardarOtro">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="lblMensaje" />
                    <telerik:AjaxUpdatedControl ControlID="rdpFecha" />
                    <telerik:AjaxUpdatedControl ControlID="txtNumero" />
                    <telerik:AjaxUpdatedControl ControlID="txt_codprv" />
                    <telerik:AjaxUpdatedControl ControlID="ddl_Terceros" />
                    <telerik:AjaxUpdatedControl ControlID="ddl_Tipo_Orden" />
                    <telerik:AjaxUpdatedControl ControlID="txtValor_USD" />
                    <telerik:AjaxUpdatedControl ControlID="txtTRM" />
                    <telerik:AjaxUpdatedControl ControlID="txtValor_COP" />
                    <telerik:AjaxUpdatedControl ControlID="Txt_CodigoProyecto" />
                    <telerik:AjaxUpdatedControl ControlID="rdp_Fecha_Inicial_Contrato" />
                    <telerik:AjaxUpdatedControl ControlID="RadComboBox2" />
                    <telerik:AjaxUpdatedControl ControlID="txtObservaciones" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnEliminar">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="lblMensaje" />
                    <telerik:AjaxUpdatedControl ControlID="rdpFecha" />
                    <telerik:AjaxUpdatedControl ControlID="txtNumero" />
                    <telerik:AjaxUpdatedControl ControlID="txt_codprv" />
                    <telerik:AjaxUpdatedControl ControlID="ddl_Terceros" />
                    <telerik:AjaxUpdatedControl ControlID="ddl_Tipo_Orden" />
                    <telerik:AjaxUpdatedControl ControlID="txtValor_USD" />
                    <telerik:AjaxUpdatedControl ControlID="txtTRM" />
                    <telerik:AjaxUpdatedControl ControlID="txtValor_COP" />
                    <telerik:AjaxUpdatedControl ControlID="Txt_CodigoProyecto" />
                    <telerik:AjaxUpdatedControl ControlID="rdp_Fecha_Inicial_Contrato" />
                    <telerik:AjaxUpdatedControl ControlID="rdp_Fecha_Final_Contrato" />
                    <telerik:AjaxUpdatedControl ControlID="RadComboBox2" />
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

