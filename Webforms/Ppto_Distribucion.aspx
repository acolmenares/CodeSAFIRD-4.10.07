<%@ Page Title="" Language="VB" MasterPageFile="~/Controles/MasterPage.master" AutoEventWireup="false" CodeFile="Ppto_Distribucion.aspx.vb" Inherits="Webforms_Ppto_Distribucion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <telerik:RadScriptManager ID="RadScriptManager1" runat="server"/>
    <asp:Panel runat="server" ID="pnl_principal" DefaultButton ="btnGuardar" Width ="100%">
    <table id="TablaContenido" cellspacing="0" cellpadding="0" border="0" class="ContentTable" style="width: 100%">
        <tr valign="top">
        <td style="width: 75%"> 
            <asp:Label ID="lbl_Titulo" runat="server" Text="CREACION / MODIFICACION DE DISTRIBUCIÓN DE INGRESOS" Width="90%" CssClass="TitTitulo" BackColor="PeachPuff"></asp:Label><br />
            <asp:Label ID="lblMensaje" runat="server" CssClass="TitMensaje" Text="_" Width="90%" Visible="False"/>
        </td>
        <td style="width: 25%" align="right">
            <asp:ImageButton ID="btn_actualizar" runat="server" ImageUrl="~/Images/Reload.jpg" ToolTip="Actualizar la vista actual." TabIndex="11" />
            <asp:ImageButton ID="btn_nuevo" runat="server" ImageUrl="~/Images/Add.jpg" ToolTip="Crear Nuevo Registro." TabIndex="12" />
            <asp:ImageButton ID="btn_cerrar" runat="server" ImageUrl="~/Images/Stop.jpg" ToolTip="Cerrar - Volver a la vista anterior." TabIndex="13" />
            <asp:ImageButton ID="btn_home" runat="server" ImageUrl="~/Images/Home.jpg" ToolTip="Ir al Inicio." TabIndex="14" />&nbsp;</td>
        </tr>

        <tr valign="top">
            <td style="width: 75%">
                <table id="tblContenido" class="EditControlsTable" cellspacing="0" cellpadding="0" border="0" style="width: 100%">
                    <tr valign="top">
                        <td class="LabelCell" style="height: 25px">
                            <asp:Label ID="lblPpto_Terceros" runat="server" Width="90%">Ingreso al Cual registrar el cargo</asp:Label></td>
                        <td class="ControlCell" colspan="3" style="height: 25px">
                            <asp:dropdownlist id="ddl_Ingresos" runat="server" CssClass="drop01" AutoPostBack="True" Width="90%"/></td>
                    </tr>
                    <tr valign="top">
                        <td class="LabelCell" style="height: 25px">
                            <asp:Label ID="Label3" runat="server" Width="90%">Estado general del Ingreso</asp:Label></td>
                        <td class="ControlCell" colspan="3" style="height: 25px">
                            <asp:Label ID="lbl_Ingreso" runat="server" Width="40%">Valor Ingreso : $ 0.00</asp:Label>
                            <asp:Label ID="Lbl_Pendiente" runat="server" Width="40%">Pendiente por Asignar : $</asp:Label></td>
                    </tr>
                    <tr valign="top">
                        <td class="LabelCell" colspan="4">
                            <hr style="color: orange" />
                        </td>
                    </tr>
                    <tr valign="top">
                        <td  class="LabelCell" style="height: 25px">
                            <asp:Label id="lblFecha" runat="server" Width="90%">Fecha</asp:Label>
                        </td>
                        <td class="ControlCell" colspan="3" style="height: 25px">
                            <telerik:RadDatePicker ID="rdpFecha" runat="server"  MinDate=""
                                Skin="Sunset" Width="50%" ToolTip="Seleccione Fecha ..." TabIndex="1" Culture="Spanish (Colombia)">
                                <Calendar Skin="Sunset" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                ViewSelectorText="x">
                                    <FastNavigationSettings CancelButtonCaption="Cancelar" DateIsOutOfRangeMessage="Fecha fuera de rango."
                                        TodayButtonCaption="Hoy">
                                    </FastNavigationSettings>
                                </Calendar>
                            <DatePopupButton HoverImageUrl="" ImageUrl="" ToolTip="Abrir el Calendario" TabIndex="1" />
                            <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MMMM/yyyy"  EmptyMessage="Fecha ..." TabIndex="1"/>
                            </telerik:RadDatePicker>
                            </td>
                    </tr>
                    <tr valign="top">
                        <td  class="LabelCell" style="height: 25px">
                            <asp:Label id="lblValor_COP" runat="server" Width="90%">Tipo de Unidad</asp:Label></td>
                        <td class="ControlCell" colspan="3" style="height: 25px">
                        <asp:dropdownlist id="ddl_TipoUnidad" runat="server" CssClass="drop01" Width="90%" TabIndex="2" /></td>
                    </tr>
                    <tr valign="top">
                        <td class="LabelCell" style="height: 25px">
                            <asp:Label id="lblTRM" runat="server" Width="90%" Text='Nivel o Rubro a Aplicar'/></td>
                        <td class="ControlCell" colspan="3" style="height: 25px">
                            <telerik:RadComboBox ID="RadComboBox2" Width="90%" Height="300px" 
                            AllowCustomText="true" EmptyMessage="Seleccione el rubro presupuestal" OnClientDropDownClosing="OnClientDropDownClosingHandler"
                            runat="server" TabIndex="3">
                            <ItemTemplate>
                                <div onclick="StopPropagation(event)">
                                    <telerik:RadTreeView ID="RadTreeView1" runat="server" OnClientNodeClicking="OnClientNodeClickingHandler">
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
                        <td class="LabelCell" style="height: 25px">
                            <asp:Label ID="Label1" runat="server" Width="90%">Número de Unidades</asp:Label></td>
                        <td class="ControlCell" colspan="3" style="height: 25px">
                            <asp:TextBox id="txtNumero_Unidades" runat = "server" style="text-align: right" onkeypress="return ValNumero(this, event)" CssClass="Digitar" Width="176px" AutoPostBack="True" TabIndex="4"/></td>
                    </tr>
                    <tr valign="top">
                        <td class="LabelCell" style="height: 25px">
                            <asp:Label ID="Label2" runat="server" Width="90%">Costo por Unidad</asp:Label></td>
                        <td class="ControlCell" style="height: 25px">
                            <asp:TextBox id="txt_Costo_Unidad" runat = "server" style="text-align: right" onkeypress="return ValNumero(this, event)" CssClass="Digitar" Width="176px" AutoPostBack="True" TabIndex="5"/></td>
                        <td class="LabelCell" style="height: 25px">
                            <asp:Label ID="Label4" runat="server" Width="90%">Costo Total</asp:Label></td>
                        <td class="ControlCell" style="height: 25px">
                            <asp:TextBox id="Txt_Costo_Total" runat = "server" style="text-align: right" onkeypress="return ValNumero(this, event)" CssClass="Digitar" Width="176px" AutoPostBack="True" TabIndex="6"/></td>
                                
                    </tr>
                </table>
            </td>
            <td style="width: 25%"></td>
        </tr>
    </table>
    
    <asp:Panel ID="pnl_final" runat="server" Width="100%" style="vertical-align: middle; text-align: center" >
    <table border="0" cellpadding="0" cellspacing="0" style="width: 90%">
        <tr valign="top">
            <td style="width: 15%;">
            </td>
            <td style="width: 15%;">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" cssClass="Boton" Width="100px" TabIndex="7"></asp:Button>
            </td>
            <td style="width: 16%;">
                <asp:Button ID="btnGuardarOtro" runat="server" Text="Guardar y agregar otro" cssClass="Boton" Width="150px" TabIndex="8"></asp:Button>
            </td>
            <td style="width: 15%;">
                <asp:Button ID="btnEliminar" runat="server" Text='Eliminar' CssClass="Boton" Width="100px" TabIndex="9"></asp:Button>
            </td>
            <td style="width: 15%;">
                <asp:Button ID="btnCerrar" runat="server" Text="Cerrar" cssClass="Boton" Width="100px" TabIndex="10"></asp:Button>
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
            <telerik:AjaxSetting AjaxControlID="ddl_Ingresos">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="lbl_Ingreso" />
                    <telerik:AjaxUpdatedControl ControlID="Lbl_Pendiente" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="txtNumero_Unidades">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="txtNumero_Unidades" />
                    <telerik:AjaxUpdatedControl ControlID="txt_Costo_Unidad" />
                    <telerik:AjaxUpdatedControl ControlID="Txt_Costo_Total" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="txt_Costo_Unidad">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="txtNumero_Unidades" />
                    <telerik:AjaxUpdatedControl ControlID="txt_Costo_Unidad" />
                    <telerik:AjaxUpdatedControl ControlID="Txt_Costo_Total" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="Txt_Costo_Total">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="txtNumero_Unidades" />
                    <telerik:AjaxUpdatedControl ControlID="txt_Costo_Unidad" />
                    <telerik:AjaxUpdatedControl ControlID="Txt_Costo_Total" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnGuardar">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="lblMensaje" />
                    <telerik:AjaxUpdatedControl ControlID="lbl_Ingreso" />
                    <telerik:AjaxUpdatedControl ControlID="Lbl_Pendiente" />
                    <telerik:AjaxUpdatedControl ControlID="rdpFecha" />
                    <telerik:AjaxUpdatedControl ControlID="ddl_TipoUnidad" />
                    <telerik:AjaxUpdatedControl ControlID="RadComboBox2" />
                    <telerik:AjaxUpdatedControl ControlID="txtNumero_Unidades" />
                    <telerik:AjaxUpdatedControl ControlID="txt_Costo_Unidad" />
                    <telerik:AjaxUpdatedControl ControlID="Txt_Costo_Total" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnGuardarOtro">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="lblMensaje" />
                    <telerik:AjaxUpdatedControl ControlID="lbl_Ingreso" />
                    <telerik:AjaxUpdatedControl ControlID="Lbl_Pendiente" />
                    <telerik:AjaxUpdatedControl ControlID="rdpFecha" />
                    <telerik:AjaxUpdatedControl ControlID="ddl_TipoUnidad" />
                    <telerik:AjaxUpdatedControl ControlID="RadComboBox2" />
                    <telerik:AjaxUpdatedControl ControlID="txtNumero_Unidades" />
                    <telerik:AjaxUpdatedControl ControlID="txt_Costo_Unidad" />
                    <telerik:AjaxUpdatedControl ControlID="Txt_Costo_Total" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnEliminar">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="lblMensaje" />
                    <telerik:AjaxUpdatedControl ControlID="ddl_Ingresos" />
                    <telerik:AjaxUpdatedControl ControlID="lbl_Ingreso" />
                    <telerik:AjaxUpdatedControl ControlID="Lbl_Pendiente" />
                    <telerik:AjaxUpdatedControl ControlID="rdpFecha" />
                    <telerik:AjaxUpdatedControl ControlID="ddl_TipoUnidad" />
                    <telerik:AjaxUpdatedControl ControlID="RadComboBox2" />
                    <telerik:AjaxUpdatedControl ControlID="txtNumero_Unidades" />
                    <telerik:AjaxUpdatedControl ControlID="txt_Costo_Unidad" />
                    <telerik:AjaxUpdatedControl ControlID="Txt_Costo_Total" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="LoadingPanel2" runat="server" BackgroundPosition="Right"
        Height="0px" Transparency="50">
        <asp:Image ID="Image1" runat="server" AlternateText="Cargando..." ImageUrl="~/Images/loading.gif" />
    </telerik:RadAjaxLoadingPanel>

</asp:Content>

