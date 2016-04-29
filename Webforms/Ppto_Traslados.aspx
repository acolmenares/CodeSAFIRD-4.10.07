<%@ Page Title="" Language="VB" MasterPageFile="~/Controles/MasterPage.master" AutoEventWireup="false" CodeFile="Ppto_Traslados.aspx.vb" Inherits="Webforms_Ppto_Traslados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <telerik:RadScriptManager ID="RadScriptManager1" runat="server"/>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="GENERAL" /><asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="DETALLE" />
    <asp:Panel runat="server" ID="pnl_principal" DefaultButton ="btnGuardar" Width ="100%">
    <table id="TablaContenido" cellspacing="0" cellpadding="0" border="0" class="ContentTable" style="width: 100%">
        <tr valign="top">
        <td style="width: 75%"> 
            <asp:Label ID="lbl_Titulo" runat="server" Text="CREACION / MODIFICACION DE TRASLADOS DE VALORES ENTRE RUBROS" Width="90%" CssClass="TitTitulo" BackColor="PeachPuff"></asp:Label><br />
            <asp:Label ID="lblMensaje" runat="server" CssClass="TitMensaje" Text="_" Width="90%" Visible="False"/>
        </td>
        <td style="width: 25%" align="right">
            <asp:ImageButton ID="btn_actualizar" runat="server" ImageUrl="~/Images/Reload.jpg" ToolTip="Actualizar la vista actual." TabIndex="15" />
            <asp:ImageButton ID="btn_nuevo" runat="server" ImageUrl="~/Images/Add.jpg" ToolTip="Crear Nuevo Registro." TabIndex="16" />
            <asp:ImageButton ID="btn_cerrar" runat="server" ImageUrl="~/Images/Stop.jpg" ToolTip="Cerrar - Volver a la vista anterior." TabIndex="17" />
            <asp:ImageButton ID="btn_home" runat="server" ImageUrl="~/Images/Home.jpg" ToolTip="Ir al Inicio." TabIndex="18" />&nbsp;</td>
        </tr>

        <tr valign="top">
            <td colspan="2">
                <table id="tblContenido" class="EditControlsTable" cellspacing="0" cellpadding="0" border="0" style="width: 100%">
                    <tr valign="top">
                        <td  class="LabelCell" style="width: 40%">
                            <asp:Label id="lblFecha" runat="server" Width="90%">Fecha</asp:Label>
                        </td>
                        <td class="ControlCell" style="width: 60%">
                            <telerik:RadDatePicker ID="rdpFecha" runat="server"  MinDate=""
                                Skin="Sunset" Width="45%" ToolTip="Seleccione Fecha ..." Culture="Spanish (Colombia)">
                                <Calendar Skin="Sunset" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                ViewSelectorText="x">
                                    <FastNavigationSettings CancelButtonCaption="Cancelar" DateIsOutOfRangeMessage="Fecha fuera de rango"
                                        TodayButtonCaption="Hoy">
                                    </FastNavigationSettings>
                                </Calendar>
                            <DatePopupButton HoverImageUrl="" ImageUrl="" ToolTip="Abrir el Calendario" />
                            <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MMMM/yyyy"  EmptyMessage="Fecha ..."/>
                            </telerik:RadDatePicker>
                            <asp:RequiredFieldValidator ID="rfv_fecha" runat="server" ControlToValidate="rdpFecha"
                                EnableClientScript="False" ErrorMessage="Falta la fecha de registro" ValidationGroup="GENERAL">*</asp:RequiredFieldValidator></td>
                    </tr>
                    <tr valign="top">
                        <td  class="LabelCell" style="width: 40%">
                            <asp:Label id="lblNumero" runat="server" Width="90%">Número</asp:Label>
                        </td>
                        <td class="ControlCell" style="width: 60%">
                            <asp:TextBox id="txtNumero" runat = "server" style="text-align: right" CssClass="Digitar" MaxLength="10" Width="160px" TabIndex="1"/>
                            <asp:RequiredFieldValidator ID="rfv_Contrato" runat="server" ControlToValidate="txtNumero"
                                EnableClientScript="False" ErrorMessage="Falta el Número del Contrato" ValidationGroup="GENERAL">*</asp:RequiredFieldValidator>
                            <asp:CheckBox ID="chb_editar" runat="server" Visible="False" />
                            <asp:CheckBox ID="chb_eliminar" runat="server" Visible="False" /></td>
                    </tr>
                    <tr valign="top">
                        <td  class="LabelCell" style="width: 40%">
                            <asp:Label ID="lblNivelId_Nivel" runat="server" Width="90%">Rubro a descargar el Valor</asp:Label></td>
                        <td class="ControlCell" style="width: 60%">
                            <telerik:RadComboBox ID="RadComboBox2" runat="server" AllowCustomText="true"
                                EmptyMessage="Seleccione el rubro presupuestal" Height="300px" OnClientDropDownClosing="OnClientDropDownClosingHandler"
                                Width="90%" TabIndex="2">
                                <ItemTemplate>
                                    <div onclick="StopPropagation(event)">
                                        <telerik:RadTreeView ID="RadTreeView1" runat="server" OnClientNodeClicking="OnClientNodeClickingHandler" OnNodeClick = "ddl_Nivel_SelectedIndexChanged">
                                            <DataBindings>
                                                <telerik:RadTreeNodeBinding Category="Make" Depth="0" />
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
                        <td class="LabelCell" style="width: 40%;">
                        </td>
                        <td class="ControlCell" style="width: 60%;">
                            <asp:Label id="lbl_cantidad" runat="server" Width="40%" Text='_' ForeColor="Navy"/></td>
                    </tr>
                    <tr valign="top">
                        <td  class="LabelCell" style="width: 40%">
                            <asp:Label id="lblObservaciones" runat="server" Width="90%">Observaciones</asp:Label>
                        </td>
                        <td class="ControlCell" style="width: 60%">
                            <asp:TextBox id="txtObservaciones" runat = "server" MaxLength="400" Rows="3" TextMode="MultiLine" Width="95%" TabIndex="3"></asp:TextBox>
                        </td>
                    </tr>
                    <tr valign="top">
                        <td align="center" class="LabelCell" colspan="2" style="background-color: inactivecaption;">
                            <asp:Label ID="Label3" runat="server" Font-Bold="True" Width="40%">Distribución del traslado</asp:Label></td>
                    </tr>
                    <tr valign="top">
                        <td class="LabelCell" colspan="2" style="width: 100%">
                            <table id="tbl_RubrosInternos" border="0" cellpadding="0" cellspacing="0" style="width: 100%; background-color: inactivecaption;">
                                <tr valign ="top">
                                    <td align="center" colspan="2" style="background-color: menu; width: 20%;">
                                        <asp:Label ID="Label4" runat="server" Font-Bold="True" Width="90%">Seleccione a donde asigna los recursos</asp:Label></td>
                                    <td colspan="2" rowspan="7" style="width: 60%; background-color: menu;">
                                        <telerik:RadGrid ID="Rg_DetalleTraslado" runat="server" Skin="Office2007" GridLines="None" Width="96%" AutoGenerateColumns="False" OnItemCommand="subCommandItem"  
                                           AllowAutomaticDeletes="True" AllowAutomaticInserts="True"  AllowAutomaticUpdates="True" ShowStatusBar ="True" ShowFooter ="True" TabIndex="14" >
                                            <MasterTableView  NoDetailRecordsText="No hay informaci&#243;n." NoMasterRecordsText="No hay informaci&#243;n." DataKeyNames="Id" >
                                                <Columns>
                                                    <telerik:GridBoundColumn DataField="Id" DataType="System.Int32" HeaderText="Id" ReadOnly="True"
                                                        SortExpression="Id" UniqueName="Id"  Visible ="False" DefaultInsertValue="">
                                                    </telerik:GridBoundColumn>
                                                    
                                                    <telerik:GridBoundColumn DataField="Nivel.Descripcion_PadreHijo" HeaderText="Nivel Aplicado"
                                                        SortExpression="Nivel.Descripcion_PadreHijo" UniqueName="Nivel.Descripcion_PadreHijo" DefaultInsertValue="" >
                                                        <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                            Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                                                        <ItemStyle HorizontalAlign="Left" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Wrap="True" />    
                                                    </telerik:GridBoundColumn> 
                                                                                               
                                                    <telerik:GridBoundColumn DataField="Valor_USD" HeaderText="Valor USD" SortExpression="Valor_USD" DataFormatString="{0:c}"
                                                        UniqueName="Valor_USD" Aggregate="Sum" DefaultInsertValue="" >
                                                        <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                            Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                                                        <ItemStyle HorizontalAlign="Right" />
                                                        <FooterStyle HorizontalAlign ="Right" />
                                                    </telerik:GridBoundColumn>
                                                    
                                                    <telerik:GridBoundColumn DataField="TRM" HeaderText="Tasa TRM" SortExpression="TRM" DataFormatString="{0:c}"
                                                        UniqueName="TRM" DefaultInsertValue="" >
                                                        <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                            Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                                                        <ItemStyle HorizontalAlign="Right" />
                                                    </telerik:GridBoundColumn>            

                                                    <telerik:GridBoundColumn DataField="Valor_COP" HeaderText="Valor COP" SortExpression="Valor_COP" DataFormatString="{0:c}"
                                                        UniqueName="Valor_COP" Aggregate="Sum" DefaultInsertValue="" >
                                                        <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                            Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                                                        <ItemStyle HorizontalAlign="Right" />
                                                        <FooterStyle HorizontalAlign ="Right" />
                                                    </telerik:GridBoundColumn>
                                                    
                                                    <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Editar" 
                                                        ImageUrl="../Images/Edit1.gif" UniqueName="Editar">
                                                        <ItemStyle Width="10px" />
                                                    </telerik:GridButtonColumn>
                                                    
                                                    <telerik:GridButtonColumn ConfirmText="Desea eliminar este registro?" ConfirmDialogType="RadWindow"  
                                                        ConfirmTitle="Borrar Traslado"  CommandName="Delete" UniqueName="Borrar" ButtonType="ImageButton" ImageUrl="../Images/balde.gif">
                                                        <ItemStyle Width="10px" />
                                                    </telerik:GridButtonColumn>
                                                </Columns>
                                                <PagerStyle Mode="NumericPages" FirstPageToolTip="Primera" LastPageToolTip="Ultima" NextPagesToolTip="Pr&#243;ximas" NextPageToolTip="Pr&#243;xima" PagerTextFormat="Cambiar P&#225;gina: {4} &amp;nbsp;P&#225;gina &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;, registros &lt;strong&gt;{2}&lt;/strong&gt; a &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PrevPageToolTip="Anterior"  PrevPagesToolTip="Anteriores" />
                                            </MasterTableView>
                                            <ClientSettings EnablePostBackOnRowClick="True" EnableRowHoverStyle ="True" >
                                                <Selecting AllowRowSelect ="True"  />
                                            </ClientSettings>
                                            <SortingSettings SortToolTip="Clic aqui para ordenar..." />
                                            <PagerStyle Mode="NumericPages" />
                                        </telerik:RadGrid></td>
                                </tr>
                                <tr valign ="top">
                                    <td style="width: 20%; background-color: menu;">
                                        <asp:Label ID="Label1" runat="server" Width="90%">Rubro a asignar el Valor</asp:Label></td>
                                    <td style="width: 20%; background-color: menu;">
                                       <telerik:RadComboBox ID="RadComboBox1" runat="server" AllowCustomText="true"
                                            EmptyMessage="Seleccione el rubro presupuestal" Height="300px" Width="90%" TabIndex="4">
                                            <ItemTemplate>
                                                <div onclick="StopPropagation(event)">
                                                    <telerik:RadTreeView ID="RadTreeView2" runat="server"  OnNodeClick ="ddl_nivel_entra_SelectedIndexChanged">
                                                        <DataBindings>
                                                            <telerik:RadTreeNodeBinding Category="Make" Depth="0" />
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
                                <tr valign ="top">
                                    <td colspan="2" style="background-color: menu">
                                        <asp:Label ID="lbl_rubro" runat="server" Width="100%" ForeColor="Navy">Rubro</asp:Label></td>
                                </tr>
                                <tr valign ="top">
                                    <td style="width: 20%; background-color: menu;">
                                        <asp:Label ID="lblValor_USD" runat="server" Width="90%">Valor USD</asp:Label></td>
                                    <td style="width: 20%; background-color: menu;"><asp:TextBox id="txtValor_USD" runat = "server" style="text-align: right" onkeypress="return ValNumero(this, event)" Width="104px" CssClass="Digitar" AutoPostBack="True" TabIndex="5"/>
                                        <asp:RequiredFieldValidator ID="rfv_valorUSD" runat="server" ControlToValidate="txtValor_USD"
                                            EnableClientScript="False" ErrorMessage="Falta el Valor en USD" ValidationGroup="DETALLE">*</asp:RequiredFieldValidator></td>
                                </tr>
                                <tr valign ="top">
                                    <td style="width: 20%; background-color: menu;">
                                        <asp:Label ID="Label2" runat="server" Width="90%">TRM</asp:Label></td>
                                    <td style="width: 20%; background-color: menu;"><asp:TextBox id="txtTRM" runat = "server" style="text-align: right" onkeypress="return ValNumero(this, event)" Width="104px" CssClass="Digitar" AutoPostBack="True" TabIndex="6"/>
                                        <asp:RequiredFieldValidator ID="rfv_tasa" runat="server" ControlToValidate="txtTRM"
                                            EnableClientScript="False" ErrorMessage="Falta el Valor en TRM" ValidationGroup="DETALLE">*</asp:RequiredFieldValidator></td>
                                </tr>
                                <tr valign ="top">
                                    <td style="width: 20%; background-color: menu;">
                                        <asp:Label ID="Label5" runat="server" Width="90%">Valor COP</asp:Label></td>
                                    <td style="width: 20%; background-color: menu;"><asp:TextBox id="txtValor_COP" runat = "server" style="text-align: right" onkeypress="return ValNumero(this, event)" Width="104px" CssClass="Digitar" AutoPostBack="True" TabIndex="7"/>
                                        <asp:RequiredFieldValidator ID="rfv_ValorCOP" runat="server" ControlToValidate="txtValor_COP"
                                            EnableClientScript="False" ErrorMessage="Falta el Valor en COP" ValidationGroup="DETALLE">*</asp:RequiredFieldValidator>
                                        <asp:Label ID="lbl_IdDetalle" runat="server" Width="90%" Visible="False"></asp:Label></td>
                                </tr>
                                <tr valign ="top">
                                    <td align="center" style="width: 20%; background-color: menu;">
                                        <asp:Button ID="btn_cargar" runat="server" CssClass="Boton" Text="Cargar" Width="100px" TabIndex="8" /></td>
                                    <td align="center" style="width: 20%; background-color: menu;">
                                        <asp:Button ID="btn_limpiar" runat="server" CssClass="Boton" Text="Limpiar" Width="100px" TabIndex="9" /></td>
                                </tr>
                            </table>
                        </td>
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
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" cssClass="Boton" Width="100px" TabIndex="10"></asp:Button>
            </td>
            <td style="width: 16%;">
                <asp:Button ID="btnGuardarOtro" runat="server" Text="Guardar y agregar otro" cssClass="Boton" Width="150px" TabIndex="11"></asp:Button>
            </td>
            <td style="width: 15%;">
                <asp:Button ID="btnEliminar" runat="server" Text='Eliminar' CssClass="Boton" Width="100px" TabIndex="12"></asp:Button>
            </td>
            <td style="width: 15%;">
                <asp:Button ID="btnCerrar" runat="server" Text="Cerrar" cssClass="Boton" Width="100px" TabIndex="13"></asp:Button>
            </td>
            <td style="width: 15%;">
            </td>
        </tr>
    </table>
    </asp:Panel>  
     </asp:Panel>
     
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

</asp:Content>

