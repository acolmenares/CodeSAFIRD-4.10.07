<%@ Page Title="" Language="VB" MasterPageFile="~/Controles/MasterPage.master" AutoEventWireup="false" CodeFile="OrdenCompra_Detalle.aspx.vb" Inherits="Webforms_OrdenCompra_Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <telerik:RadScriptManager ID="RadScriptManager1" runat="server"/>
    
    <asp:Panel runat="server" ID="pnl_principal" DefaultButton ="btnGuardar" Width="100%">
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="DETALLE" />
    <table id="Table1" cellspacing="0" cellpadding="0" border="0" class="ContentTable" style="width: 100%">
        <tr valign="top">
        <td style="width: 75%"> 
            <asp:Label ID="lbl_Titulo" runat="server" Text="CREACION / MODIFICACION DE PRODUCTOS EN ORDEN DE COMPRA" Width="90%" CssClass="TitTitulo" BackColor="PeachPuff"></asp:Label><br />
            <asp:Label ID="lblMensaje" runat="server" CssClass="TitMensaje" Text="_" Width="90%" Visible="False"/>
        </td>
        <td style="width: 25%" align="right">
            <asp:ImageButton ID="btn_actualizar" runat="server" ImageUrl="~/Images/Reload.jpg" ToolTip="Actualizar la vista actual." TabIndex="11" />
            <asp:ImageButton ID="btn_nuevo" runat="server" ImageUrl="~/Images/Add.jpg" ToolTip="Crear Nuevo Registro." TabIndex="12" />
            <asp:ImageButton ID="btn_cerrar" runat="server" ImageUrl="~/Images/Stop.jpg" ToolTip="Cerrar - Volver a la vista anterior." TabIndex="13" />
            <asp:ImageButton ID="btn_home" runat="server" ImageUrl="~/Images/Home.jpg" ToolTip="Ir al Inicio." TabIndex="14" />&nbsp;</td>
        </tr>

        <tr valign="top">
            <td>
                <table id="Table2" class="EditControlsTable" cellspacing="0" cellpadding="0" border="1" style="width: 100%">
                    <tr valign="top">
                        <td style="width: 75%">
                                <table id="tblContenido" class="EditControlsTable" cellspacing="0" cellpadding="0" border="0" style="width: 100%">

                                    <tr valign ="top">
                                    <td  class="LabelCell" style="width: 25%">
                                    <asp:Label id="lblProductosId_Producto" runat="server" Width="90%">Producto</asp:Label>


                                    </td><td class="ControlCell" style="width: 25%">
                                    <asp:dropdownlist id="ddlProductos" runat="server" Font-Size="X-Small" Width="90%" CssClass="drop01" ></asp:dropdownlist>        
                                        <asp:RegularExpressionValidator ID="rev_producto" runat="server" ControlToValidate="ddlProductos"
                                            EnableClientScript="False" ErrorMessage="Falta Producto" ValidationExpression="^[1-9]+[0-9]*$" ValidationGroup="DETALLE">*</asp:RegularExpressionValidator></td>
                                        <td class="ControlCell" style="width: 25%">
                                    <asp:Label id="lblUnidadMedidaId_Unidad_Medida" runat="server" Width="90%">Unidad de Medida</asp:Label></td>
                                        <td class="ControlCell" style="width: 25%">
                                    <asp:dropdownlist id="ddlUnidadMedida" runat="server" Font-Size="X-Small" Width="87%" CssClass="drop01" TabIndex="1" ></asp:dropdownlist>        
                                            <asp:RegularExpressionValidator ID="rev_Unidad" runat="server" ControlToValidate="ddlUnidadMedida"
                                                EnableClientScript="False" ErrorMessage="Falta Unidad de Medida" ValidationExpression="^[1-9]+[0-9]*$" ValidationGroup="DETALLE">*</asp:RegularExpressionValidator></td>
                                    </tr>

                                    <tr valign ="top"><td  class="LabelCell" style="width: 25%">
                                    <asp:Label id="lblCantidad" runat="server" Width="90%">Cantidad</asp:Label></td><td class="ControlCell" style="width: 25%">
                                    <asp:TextBox id="txtCantidad" onkeypress="return ValNumero(this, event)"  runat = "server" style="text-align: right" Font-Size="X-Small" MaxLength="10" CssClass="Digitar" AutoPostBack="True" TabIndex="2"></asp:TextBox>      
                                        <asp:RequiredFieldValidator ID="rfv_Cantidad" runat="server" ControlToValidate="txtCantidad"
                                            EnableClientScript="False" ErrorMessage="Falta Cantidad" ValidationGroup="DETALLE">*</asp:RequiredFieldValidator></td>
                                        <td class="ControlCell" style="width: 25%">
                                    <asp:Label id="lblValor_Unitario" runat="server" Width="90%">Valor Unitario</asp:Label></td>
                                        <td class="ControlCell" style="width: 25%">
                                    <asp:TextBox id="txtValor_Unitario" onkeypress="return ValNumero(this, event)"  runat = "server" style="text-align: right" Font-Size="X-Small" MaxLength="10" CssClass="Digitar" AutoPostBack="True" TabIndex="3"></asp:TextBox>      
                                        <asp:RequiredFieldValidator ID="rfv_Valor_unitario" runat="server" ControlToValidate="txtValor_Unitario"
                                            EnableClientScript="False" ErrorMessage="Falta Valor Unitario" ValidationGroup="DETALLE">*</asp:RequiredFieldValidator></td>
                                    </tr>
                                    <tr valign ="top">
                                        <td class="LabelCell" style="width: 25%;">
                                            <asp:Label ID="Label5" runat="server" Width="90%">Código del Proyecto</asp:Label></td>
                                        <td class="ControlCell" style="width: 25%;">
                                            <asp:TextBox ID="txt_Codigo" runat="server" AutoPostBack="True" CssClass="Digitar"
                                                Font-Size="X-Small" MaxLength="12" Style="text-align: right" TabIndex="4"/>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_Codigo"
                                                EnableClientScript="False" ErrorMessage="Falta Código de Proyecto" ValidationGroup="DETALLE">*</asp:RequiredFieldValidator></td>
                                        <td class="ControlCell" style="width: 25%;">
                                            <asp:Label ID="Label4" runat="server" Width="90%">Valor Total</asp:Label></td>
                                        <td class="ControlCell" style="width: 25%; text-align: center;">
                                            <asp:Label ID="Lbl_ValorTotal" runat="server" Width="75%" CssClass="labelsDigitar"></asp:Label></td>
                                    </tr>
                                    <tr valign ="top">
                                        <td class="LabelCell" style="width: 25%">
                                            <asp:Label ID="Label1" runat="server" Width="90%">Nivel / Rubro Presupuestal</asp:Label></td>
                                        <td class="ControlCell" colspan="3" style="width: 75%">
                                        <telerik:RadComboBox ID="RadComboBox2" Width="90%" Height="300px" 
                                            AllowCustomText="true" EmptyMessage="Seleccione el rubro presupuestal" OnClientDropDownClosing="OnClientDropDownClosingHandler"
                                            runat="server" TabIndex="5">
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
                                    <tr valign ="top">
                                        <td class="LabelCell" style="width: 25%">
                                            <asp:Label ID="Label3" runat="server" Width="90%">Descripción General del Producto</asp:Label></td>
                                        <td class="ControlCell" colspan="3" style="width: 75%">
                                            <asp:TextBox ID="txtObservaciones" runat="server" CssClass="Digitar" Font-Size="X-Small"
                                                MaxLength="400" Rows="3" TextMode="MultiLine" Width="95%" TabIndex="6"></asp:TextBox></td>
                                    </tr>
                                    <tr valign ="top">
                                        <td class="LabelCell" colspan="4">
                                            <hr style="width: 100%; color: #ff6600; text-align: center" />
    
                                        </td>
                                    </tr>

                                </table>
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
  
  
          function ValNumero(fld, e) {
                var strCheck = '0123456789.,-/';
                var whichCode = (window.Event) ? e.which : e.keyCode;
                var key;
                if (e && e.which) {
                e = e
                key = e.which
                }
                else {
                e = event
                key = e.keyCode
                }
                key = String.fromCharCode(key);
                if (strCheck.indexOf(key) == -1) return false; //valida que slo sea numerico o punto
                if (fld.value.indexOf(".") != -1 && key == ".") return false; //valida que slo permita un punto decimal
                if (fld.value == "" && key == ".") return false; //valida que no sea vacio o que no tenga un punto sin nmeros
                }
            
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
            <telerik:AjaxSetting AjaxControlID="txtCantidad">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="txtCantidad" />
                    <telerik:AjaxUpdatedControl ControlID="txtValor_Unitario" />
                    <telerik:AjaxUpdatedControl ControlID="Lbl_ValorTotal" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="txtValor_Unitario">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="txtCantidad" />
                    <telerik:AjaxUpdatedControl ControlID="txtValor_Unitario" />
                    <telerik:AjaxUpdatedControl ControlID="Lbl_ValorTotal" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnGuardar">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="pnl_principal" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnGuardarOtro">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="pnl_principal" />
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

