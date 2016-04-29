<%@ Page Title="" Language="VB" MasterPageFile="~/Controles/MasterPage.master" AutoEventWireup="false" CodeFile="OrdenCompra.aspx.vb" Inherits="Webforms_OrdenCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <telerik:RadScriptManager ID="RadScriptManager1" runat="server"/>
   
    <asp:Panel runat="server" ID="pnl_principal" DefaultButton ="btnGuardar" Width ="100%">
    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="OC" /><asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="RET" />
    
    <table id="TablaContenido" cellspacing="0" cellpadding="0" border="0" class="ContentTable" style="width: 100%">
        <tr valign="top">
        <td style="width: 75%"> 
            <asp:Label ID="lbl_Titulo" runat="server" Text="CREACION / MODIFICACION DE ORDENES DE COMPRA" Width="90%" CssClass="TitTitulo" BackColor="PeachPuff"></asp:Label><br />
            <asp:Label ID="lblMensaje" runat="server" CssClass="TitMensaje" Text="_" Width="90%" Visible="False"/></td>
        <td style="width: 25%" align="right">
            <asp:ImageButton ID="btn_Imprimir" runat="server" ImageUrl="~/Images/Printer.jpg" ToolTip="Imprimir la Orden de Compra" TabIndex="16" /><asp:ImageButton ID="btn_actualizar" runat="server" ImageUrl="~/Images/Reload.jpg" ToolTip="Actualizar la vista actual." TabIndex="17" />
            <asp:ImageButton ID="btn_nuevo" runat="server" ImageUrl="~/Images/Add.jpg" ToolTip="Crear Nuevo Registro." TabIndex="18" />
            <asp:ImageButton ID="btn_cerrar" runat="server" ImageUrl="~/Images/Stop.jpg" ToolTip="Cerrar - Volver a la vista anterior." TabIndex="19" />
            <asp:ImageButton ID="btn_home" runat="server" ImageUrl="~/Images/Home.jpg" ToolTip="Ir al Inicio." TabIndex="20" />&nbsp;</td>
        </tr>                        
        
        <tr  valign="top">

            <td colspan ="2">
                <table id="tblContenido" class="EditControlsTable" cellspacing="0" cellpadding="0" border="0" style="width: 100%">

                    <tr  valign="top"><td  class="LabelCell" style="width: 17%">
                    <asp:Label id="lblRegional" runat="server" Width="90%">Regional</asp:Label>


                    </td><td class="ControlCell" style="width: 17%">
                    <asp:dropdownlist id="ddl_Regional" runat="server" Font-Size="X-Small" Width="90%" CssClass="drop01" AutoPostBack="True" ></asp:dropdownlist>        
                        <asp:RegularExpressionValidator ID="rev_Regional" runat="server" ControlToValidate="ddl_Regional"
                            ErrorMessage="Falta Regional" ValidationExpression="^[1-9]+[0-9]*$" EnableClientScript="False" ValidationGroup="OC">*</asp:RegularExpressionValidator></td>
                        <td class="ControlCell" style="width: 17%">
                    <asp:Label id="lblFecha" runat="server" Width="90%">Fecha</asp:Label></td>
                        <td class="ControlCell" style="width: 17%">
                            <telerik:RadDatePicker ID="rdpFecha" runat="server" Culture="Spanish (Colombia)"
                                FocusedDate="2012-12-18" MinDate="" Skin="Sunset" TabIndex="1" ToolTip="Seleccione Fecha ..."
                                Width="90%">
                                <Calendar Skin="Sunset" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                    ViewSelectorText="x">
                                    <FastNavigationSettings CancelButtonCaption="Cancelar" DateIsOutOfRangeMessage="Fecha Fuera de Rango"
                                        TodayButtonCaption="Hoy">
                                    </FastNavigationSettings>
                                </Calendar>
                                <DatePopupButton HoverImageUrl="" ImageUrl="" TabIndex="1" ToolTip="Abrir el Calendario" />
                                <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MMMM/yyyy" EmptyMessage="Fecha ..."
                                    TabIndex="1">
                                </DateInput>
                            </telerik:RadDatePicker>
                            <asp:RequiredFieldValidator ID="rfv_Fecha" runat="server" ControlToValidate="rdpFecha"
                                EnableClientScript="False" ErrorMessage="Falta Fecha de la Orden de Compra" ValidationGroup="OC">*</asp:RequiredFieldValidator></td>
                        <td class="ControlCell" style="width: 17%">
                            <asp:Label ID="Label11" runat="server" Width="90%">Tasa TRM</asp:Label></td>
                        <td class="ControlCell" style="width: 17%">
                            <asp:TextBox ID="Txt_tasa" runat="server" Font-Size="X-Small" MaxLength="10" onkeypress="return ValNumero(this, event)"
                                Style="text-align: right" Width="90%" TabIndex="2"></asp:TextBox><asp:RequiredFieldValidator ID="rfv_Tasa"
                                    runat="server" ControlToValidate="Txt_tasa" CssClass="Digitar" EnableClientScript="False"
                                    ErrorMessage="Falta Tasa TRM" ValidationGroup="OC">*</asp:RequiredFieldValidator></td>
                    </tr>

                    <tr  valign="top"><td  class="LabelCell" style="width: 17%;">
                    <asp:Label id="lblNumero" runat="server" Width="90%">Numero</asp:Label>


                    </td><td class="ControlCell" style="width: 17%;">
                    <asp:TextBox id="txtNumero" runat = "server" Width="87%"  Font-Size="X-Small" MaxLength="12" CssClass="Digitar" TabIndex="3"></asp:TextBox><asp:RequiredFieldValidator ID="rfv_Numero" runat="server" ControlToValidate="txtNumero"
                            EnableClientScript="False" ErrorMessage="Falta Número de Orden de compra" ValidationGroup="OC">*</asp:RequiredFieldValidator></td>
                        <td class="ControlCell" style="width: 17%;">
                            <asp:Label ID="Label7" runat="server" Width="90%">Tipo de Orden</asp:Label></td>
                        <td class="ControlCell" style="width: 17%;">
                            <asp:dropdownlist id="ddl_TipoOrden" runat="server" Font-Size="X-Small" Width="90%" CssClass="drop01" TabIndex="4" /><asp:RegularExpressionValidator ID="rev_TipoOrden" runat="server" ControlToValidate="ddl_TipoOrden"
                                EnableClientScript="False" ErrorMessage="Falta Tipo de Orden" ValidationExpression="^[1-9]+[0-9]*$"
                                ValidationGroup="OC">*</asp:RegularExpressionValidator></td>
                        <td class="ControlCell" style="width: 17%">
                            <asp:Label ID="Label12" runat="server" Width="90%">Tiempo de Entrega</asp:Label></td>
                        <td class="ControlCell" style="width: 17%">
                    <asp:TextBox id="txtTiempo_Entrega" runat = "server" Width="90%" Font-Size="X-Small" CssClass="Digitar" MaxLength="100" TabIndex="5"></asp:TextBox>      
                        <asp:RequiredFieldValidator ID="rfv_tiempo_entrega" runat="server" ControlToValidate="txtTiempo_Entrega" ErrorMessage="Falta Tiempo de Entrega" ValidationGroup="OC">*</asp:RequiredFieldValidator></td>
                    </tr>
                    <tr valign="top">
                        <td class="LabelCell" style="width: 17%">
                    <asp:Label id="lblTercero" runat="server" Width="90%">Tercero</asp:Label></td>
                        <td class="ControlCell">
                            <asp:TextBox ID="txt_codprv" runat="server" AutoPostBack="True" CssClass="Digitar"
                                Width="87%" TabIndex="6"></asp:TextBox>
                        </td>
                        <td class="ControlCell" colspan="4" style="width: 68%">
                            <asp:dropdownlist id="ddl_Terceros" runat="server" Font-Size="X-Small" Width="97%" CssClass="drop01" AutoPostBack="True" TabIndex="7" ></asp:dropdownlist>
                            <asp:RegularExpressionValidator ID="rev_tercero" runat="server" ControlToValidate="ddl_Terceros"
                                EnableClientScript="False" ErrorMessage="Falta Tercero" ValidationExpression="^[1-9]+[0-9]*$" ValidationGroup="OC">*</asp:RegularExpressionValidator></td>
                    </tr>
                    <tr valign="top">
                        <td class="LabelCell" style="width: 17%">
                    <asp:Label id="lblLugar_Entrega" runat="server" Width="90%">Lugar de Entrega</asp:Label></td>
                        <td class="ControlCell" colspan="3" style="width: 51%">
                    <asp:TextBox id="txtLugar_Entrega" runat = "server" Width="96%" Font-Size="X-Small" MaxLength="800" CssClass="Digitar" TextMode="MultiLine" Rows="3" TabIndex="8"></asp:TextBox>      
                        <asp:RequiredFieldValidator ID="rfv_Lugar" runat="server" ControlToValidate="txtLugar_Entrega" ErrorMessage="Falta Lugar de Entrega" ValidationGroup="OC">*</asp:RequiredFieldValidator>&nbsp;</td>
                        <td class="ControlCell" style="width: 17%">
                        <asp:Label id="lblTiempo_Entrega" runat="server" Width="90%">Forma de Pago</asp:Label></td>
                        <td class="ControlCell" style="width: 17%">
                            <asp:TextBox ID="txt_Forma_pago" runat="server" CssClass="Digitar" Font-Size="X-Small"
                                MaxLength="200" TextMode="MultiLine" Width="90%" Rows="3" TabIndex="9"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv_FormaPago" runat="server" ControlToValidate="txt_Forma_pago"
                                ErrorMessage="Falta Forma de Pago" ValidationGroup="OC">*</asp:RequiredFieldValidator></td>
                    </tr>

                    <tr  valign="top"><td  class="LabelCell" style="width: 17%">
                        <asp:Label id="lblObservaciones" runat="server" Width="90%">Observaciones</asp:Label>


                    </td>
                        <td class="ControlCell" colspan="5" rowspan="1" style="width: 82%">
                        <asp:TextBox id="txtObservaciones" runat = "server" Rows="3" TextMode="MultiLine" Width="98%" Font-Size="X-Small" MaxLength="800" CssClass="Digitar" TabIndex="10"></asp:TextBox>      
                        </td>
                    </tr>
                    <tr valign="top">
                        <td class="LabelCell" style="width: 17%">
                            <asp:Label ID="Label13" runat="server" Width="90%">Solicitado Por Operaciones</asp:Label></td>
                        <td class="ControlCell" colspan="5" rowspan="1" style="width: 82%">
                            <asp:dropdownlist id="ddl_Solicitado_Operaciones" runat="server" Font-Size="X-Small" Width="120px" CssClass="drop01" TabIndex="4" />
                            <asp:RegularExpressionValidator ID="rev_Solicitado" runat="server" ControlToValidate="ddl_Solicitado_Operaciones"
                                EnableClientScript="False" ErrorMessage="Falta Si es solicitado por Operaciones"
                                ValidationExpression="^[1-9]+[0-9]*$" ValidationGroup="OC">*</asp:RegularExpressionValidator></td>
                    </tr>
                    <tr  valign="top">
                        <td align="center" class="LabelCell" colspan="6" style="height: 40px" valign="middle">
                              <div>
                            <asp:Button ID="btnGuardar" runat="server" CssClass="Boton" Text="Guardar" Width="100px" TabIndex="11" />
                            <asp:Button ID="btnGuardarOtro" runat="server" CssClass="Boton" Text="Guardar y agregar otro" Width="150px" TabIndex="12" />
                            <asp:Button ID="btnEliminar" runat="server" CssClass="Boton" Text="Eliminar" Width="100px" TabIndex="13" />
                            <asp:Button ID="btnCerrar" runat="server" CssClass="Boton" Text="Cerrar" Width="100px" TabIndex="14" /></div>
                        </td>
                    </tr>

                    <tr  valign="top">
                        <td class="LabelCell" colspan="6" style="height: 14px">
                            <asp:Label ID="Label1" runat="server" BackColor="#FFC080" Font-Bold="True" ForeColor="Navy"
                                Width="100%">Sistema de Aprobación de la Orden de Compra</asp:Label></td>
                    </tr>
                    <tr  valign="top">
                                    <td align="center" style="width: 17%">
                                        <asp:Label id="lblAprobacion_Logistica_OFC" runat="server" Font-Bold="True" ForeColor="#C00000">Logística Regional</asp:Label></td>
                                    <td align="center" style="width: 17%">
                                        <asp:Label id="lblAprobacion_Finanzas_Ofc" runat="server" Font-Bold="True" ForeColor="#C00000">Finanzas Regional</asp:Label></td>
                                    <td align="center" style="width: 17%">
                                        <asp:Label id="lblAprobacion_Direccion" runat="server" Font-Bold="True" ForeColor="#C00000">Coordinador Logística</asp:Label></td>
                                    <td align="center" style="width: 17%">
                                        &nbsp;<asp:Label id="lblAprobacion_Coordinacion" runat="server" Font-Bold="True" ForeColor="#C00000">Coordinación Reg.</asp:Label></td>
                                    <td align="center" style="width: 17%">
                                        <asp:Label id="lblAprobacion_Operaciones" runat="server" Font-Bold="True" ForeColor="#C00000">Dir. Operaciones</asp:Label></td>
                                    <td align="center" style="width: 17%">
                                        <asp:Label ID="Label9" runat="server" Font-Bold="True" ForeColor="#C00000">Dir. Financiera</asp:Label></td>
                                </tr>
                                <tr  valign="top">
                                    <td align="center" style="width: 17%">
                                        <asp:checkbox id="chkAprobacion_Logistica_Ofc" runat="server" Text="" Enabled="False"/></td>
                                    <td align="center" style="width: 17%">
                                        <asp:checkbox id="chkAprobacion_Finanzas_Ofc" runat="server" Text="" Enabled="False"  />
                                    </td>
                                    <td align="center" style="width: 17%">
                                        <asp:checkbox id="chkAprobacion_CooLogistica" runat="server" Enabled="False"  ></asp:checkbox></td>
                                    <td align="center" style="width: 17%">
                                        &nbsp;
                                        <asp:checkbox id="chkAprobacion_Coordinacion" runat="server" Text="" Enabled="False"  /></td>
                                    <td align="center" style="width: 17%">
                                        <asp:checkbox id="chkAprobacion_Operaciones" runat="server" Text="" Enabled="False"  /></td>
                                    <td align="center" style="width: 17%">
                                        &nbsp;<asp:checkbox id="chkAprobacion_Financiera" runat="server" Text="" Enabled="False"  /></td>
                                </tr>
                    <tr  valign="top">
                        <td class="LabelCell" colspan="5" style="background-color: coral; height: 24px;" align="center">
                            <asp:Label ID="Label2" runat="server" BackColor="Coral" Font-Bold="True" ForeColor="Navy"
                                Width="80%">Detalle de la Orden de Compra</asp:Label>
                            </td>
                        <td align="center" class="LabelCell" colspan="1" style="height: 24px; background-color: #ffc080">
                            <asp:LinkButton ID="lnk_Nuevo" runat="server" Font-Bold="True" Font-Underline="True" TabIndex="15">Nuevo Producto</asp:LinkButton></td>
                    </tr>

                    <tr  valign="top">
                        <td class="LabelCell" colspan="6">
                        <telerik:RadGrid ID="Rg_Listado" runat="server" OnItemCommand="subCommandItem" 
                            AllowSorting="True" GridLines="None" Skin="Simple" Width="100%" AutoGenerateColumns="False" TabIndex="8" PageSize="20" ShowFooter="True" ShowStatusBar="True">
                            <MasterTableView  NoDetailRecordsText="No hay informaci&#243;n." NoMasterRecordsText="No hay informaci&#243;n." DataKeyNames="Id" AllowPaging="True">
                                <Columns>
                                     
                                   <telerik:GridTemplateColumn HeaderText="No." DefaultInsertValue="" UniqueName="TemplateColumn2">
                                        <ItemTemplate>
                                            <asp:label runat="server" id="lblno" text='<%# ctype(CType(Container.Parent.Parent.Parent,RadGrid).DataSource,IList).IndexOf(Container.DataItem)+1 %>' />
                                            <asp:Label runat="Server" Id="lblid" Visible ="False" Text ='<%#Container.DataItem.Id%>'/>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>                                
                                                                                
                                    <telerik:GridBoundColumn DataField="Id" DataType="System.Int32" HeaderText="Id" ReadOnly="True"
                                        SortExpression="Id" UniqueName="Id"  Display ="False">
                                    </telerik:GridBoundColumn>
                                    
                                    <telerik:GridBoundColumn DataField="Nivel.Descripcion_PadreHijo" HeaderText="R. Presupuestal" SortExpression="Nivel.Descripcion_PadreHijo"
                                        UniqueName="Nivel.Descripcion_PadreHijo" >
                                        <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                            Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                                        <ItemStyle HorizontalAlign ="Left" />    
                                    </telerik:GridBoundColumn> 
                                       
                                    <telerik:GridBoundColumn DataField="Productos.Descripcion" HeaderText="Productos"
                                        SortExpression="Productos.Descripcion" UniqueName="Productos.Descripcion" >
                                        <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                            Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                                        <ItemStyle HorizontalAlign ="Center" />    
                                    </telerik:GridBoundColumn>       
                                                                               
                                    <telerik:GridBoundColumn DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad" DataFormatString="{0:N}"
                                        UniqueName="Cantidad" Aggregate="Sum" FooterAggregateFormatString ="{0:n}" >
                                        <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                            Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                                        <ItemStyle HorizontalAlign="Right" />
                                        <FooterStyle HorizontalAlign ="Right"  />
                                    </telerik:GridBoundColumn>
                                    
                                    <telerik:GridBoundColumn DataField="UnidadMedida.Descripcion" HeaderText="Medida" SortExpression="UnidadMedida.Descripcion" 
                                        UniqueName="UnidadMedida.Descripcion" >
                                        <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                            Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>            

                                    <telerik:GridBoundColumn DataField="Valor_Unitario" HeaderText="Valor Unitario" SortExpression="Valor_Unitario" DataFormatString="{0:c}"
                                        UniqueName="Valor_Unitario" >
                                        <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                            Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    
                                    <telerik:GridBoundColumn DataField="ValorProducto" HeaderText="Valor Total" SortExpression="ValorProducto" DataFormatString="{0:c}"
                                        UniqueName="ValorProducto" Aggregate="Sum" >
                                        <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                            Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                                        <ItemStyle HorizontalAlign="Right" />
                                        <FooterStyle HorizontalAlign ="Right" />
                                    </telerik:GridBoundColumn>

                                    <telerik:GridTemplateColumn HeaderText="Activo" UniqueName="TemplateColumn" DefaultInsertValue=""  >
		                                <ItemTemplate>
		                                   <asp:CheckBox runat="server" ID="chk_activo" Enabled ="false" Checked = '<%#Container.DataItem.Activo%>'  ToolTip ='<%#Container.DataItem.Motivo_Cancelacion%>'/>
		                                </ItemTemplate>
		                                <ItemStyle HorizontalAlign ="Center" />
		                                <HeaderStyle  HorizontalAlign ="Center"  />
                                    </telerik:GridTemplateColumn>
  
                                    <telerik:GridButtonColumn ConfirmText="Desea eliminar este registro?" ConfirmDialogType="RadWindow"   HeaderTooltip = "Eliminar Producto de la OC" HeaderText ="X"
                                        ConfirmTitle="Borrar Item de la Orden de Compra"  CommandName="Eliminar" UniqueName="Borrar" ButtonType="ImageButton" ImageUrl="../Images/balde.gif">
                                        <ItemStyle Width="10px" HorizontalAlign ="Center" />
                                        <HeaderStyle HorizontalAlign ="Center"  />
                                    </telerik:GridButtonColumn>
                                </Columns>
                                <PagerStyle Mode="NumericPages" FirstPageToolTip="Primera" LastPageToolTip="Ultima" NextPagesToolTip="Pr&#243;ximas" NextPageToolTip="Pr&#243;xima" PagerTextFormat="Cambiar P&#225;gina: {4} &amp;nbsp;P&#225;gina &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;, registros &lt;strong&gt;{2}&lt;/strong&gt; a &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PrevPageToolTip="Anterior"  PrevPagesToolTip="Anteriores" />
                            </MasterTableView>
                            <ClientSettings EnablePostBackOnRowClick="True" EnableRowHoverStyle ="True" >
                            <Selecting AllowRowSelect ="True"  />
                            </ClientSettings>
                            <SortingSettings SortToolTip="Clic aqui para ordenar..."  SortedAscToolTip ="Ordenar Ascendente" SortedDescToolTip ="Ordenar Descendente" />
                            <PagerStyle Mode="NumericPages"    />
                        </telerik:RadGrid>                                        
                        </td>
                    </tr>
                    <tr  valign="top">
                        <td class="LabelCell" colspan="6" style="background-color: #ffc080">
                            <asp:Label ID="Label4" runat="server" BackColor="#FFC080" Font-Bold="True" ForeColor="Navy"
                                Width="100%">Detalle de las Retenciones a aplicar en esta Orden de Compra</asp:Label></td>
                    </tr>
                    <tr  valign="top">
                        <td class="LabelCell" style="width: 17%">
                            <asp:Label ID="Label5" runat="server" Width="90%">Concepto de la Retención</asp:Label></td>
                        <td class="ControlCell" rowspan="1" colspan="2">
                        <asp:dropdownlist id="ddl_Conceptos" runat="server" Font-Size="X-Small" Width="80%" CssClass="drop01" >
                        </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfv_concepto" runat="server" ControlToValidate="ddl_Conceptos"
                                EnableClientScript="False" ErrorMessage="Falta Concepto de la retención" ValidationGroup="RET">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="REV_CONCEPTO" runat="server" ControlToValidate="ddl_Conceptos"
                                EnableClientScript="False" ErrorMessage="Falta Concepto" ValidationExpression="^[1-9]+[0-9]*$"
                                ValidationGroup="RET">*</asp:RegularExpressionValidator></td>
                        <td class="ControlCell" rowspan="4" style="width: 17%" valign="middle">
                            &nbsp;<asp:Label ID="Label6" runat="server" Width="90%">Resumen de las Retenciones</asp:Label></td>
                        <td align="left" class="ControlCell" colspan="2" rowspan="4" style="width: 34%"
                            valign="top">
                           <asp:DataGrid ID="dg_Retenciones" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="2" ForeColor="Black" GridLines="None"
                            OnItemCommand="subCommandItemRet" OnPageIndexChanged="CambioPaginaret" PageSize="3"
                            Width="100%" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px">
                            <FooterStyle BackColor="Tan" CssClass="DataGridFooterStyle" />
                            <EditItemStyle CssClass="DataGridEditItemStyle" />
                            <SelectedItemStyle BackColor="DarkSlateBlue" CssClass="DataGridSelectedItemStyle"
                                ForeColor="GhostWhite" />
                            <PagerStyle BackColor="PaleGoldenrod" CssClass="PagerStyle" ForeColor="DarkSlateBlue" HorizontalAlign="Center" Visible="False" />
                            <AlternatingItemStyle BackColor="PaleGoldenrod" CssClass="DataGridAlternatingItemStyle" />
                            <ItemStyle CssClass="DataGridItemStyle" />
                            <Columns>
                                <asp:TemplateColumn HeaderText="No.">
                                    <ItemTemplate>
                                        <%# ctype(CType(Container.Parent.Parent,DataGrid).DataSource,IList).IndexOf(Container.DataItem)+1 %>
                                    </ItemTemplate>
                                    <HeaderStyle Width="20px" />
                                    <ItemStyle Width="20px" />
                                </asp:TemplateColumn>
                                <asp:TemplateColumn Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblId" runat="server" Text='<%# Container.DataItem.ID %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Concepto" SortExpression="Concepto.Descripcion">
                                    <ItemTemplate>
                                        <%#Container.DataItem.Concepto.Descripcion%>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                
                                <asp:TemplateColumn HeaderText="Base" SortExpression="Base_Retencion">
                                    <ItemTemplate>
                                        <%#String.Format("{0:n2}", Container.DataItem.Base_Retencion)%>
                                    </ItemTemplate>
                                    <HeaderStyle  HorizontalAlign="Center"/>
                                    <ItemStyle  HorizontalAlign="Right"/>
                                </asp:TemplateColumn>

                                <asp:TemplateColumn HeaderText="%" SortExpression="Porcentaje">
                                    <ItemTemplate>
                                        <%#String.Format("{0:n2}", Container.DataItem.Porcentaje)%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="50px" HorizontalAlign ="Center" />
                                    <ItemStyle Width="50px"  HorizontalAlign ="Center"/>
                                </asp:TemplateColumn>

                                <asp:TemplateColumn HeaderText="Valor" SortExpression="Valor">
                                    <ItemTemplate>
                                        <%#String.Format("{0:n2}", Container.DataItem.Valor)%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center"/>
                                    <ItemStyle  HorizontalAlign="Right"/>
                                </asp:TemplateColumn>

                                <asp:EditCommandColumn HeaderImageUrl="~/Images/Edit1.gif" EditText="Abrir" >
                                    <HeaderStyle HorizontalAlign ="Center"  />
                                    <ItemStyle HorizontalAlign ="Center"   />                                
                                </asp:EditCommandColumn>
                                
                                <asp:TemplateColumn >
                                    <ItemTemplate>
                                        <asp:ImageButton runat="server" ID="btneliminarben" CommandName ="Eliminar"  ImageUrl ="~/Images/delete.gif" ToolTip ="Eliminar Impuesto" />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign ="Center"  />
                                    <ItemStyle HorizontalAlign ="Center"  />
                                </asp:TemplateColumn>
                            </Columns>
                            <HeaderStyle BackColor="Tan" CssClass="DataGridHeaderStyle" Font-Bold="True" />
                        </asp:DataGrid></td>
                    </tr>
                    <tr valign="top">
                        <td class="LabelCell" style="width: 17%">
                            <asp:Label ID="Label8" runat="server" Width="90%">Base de Retención</asp:Label></td>
                        <td class="ControlCell" rowspan="1" colspan="2">
                            <asp:TextBox id="txt_base" onkeypress="return ValNumero(this, event)" runat = "server" style="text-align: right" Font-Size="X-Small" Width="150px" CssClass="Digitar" AutoPostBack="True"/>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_base"
                                EnableClientScript="False" ErrorMessage="Falta Dato de base de Retención" ValidationGroup="RET">*</asp:RequiredFieldValidator></td>
                    </tr>
                    <tr  valign="top">
                        <td class="LabelCell" style="width: 17%;">
                            <asp:Label ID="lblPorcentaje_Retefuente" runat="server" Width="90%">Porcentaje </asp:Label></td>
                        <td class="ControlCell" rowspan="1" colspan="2">
                            <asp:TextBox id="txtPorcentaje_Retefuente" onkeypress="return ValNumero(this, event)" runat = "server" style="text-align: right" Font-Size="X-Small" MaxLength="5" Width="150px" CssClass="Digitar" AutoPostBack="True"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv_porcentaje" runat="server" ControlToValidate="txtPorcentaje_Retefuente" ErrorMessage="Falta Dato de % Retefuente" ValidationGroup="RET" EnableClientScript="False">*</asp:RequiredFieldValidator></td>
                    </tr>
                    <tr  valign="top">
                        <td class="LabelCell" style="width: 17%;">
                            <asp:Label id="lblValor_Retefuente" runat="server" Width="90%">Valor de la Retefuente</asp:Label></td>
                        <td class="ControlCell" rowspan="1" colspan="2">
                            <asp:TextBox id="txtValor_Retefuente" onkeypress="return ValNumero(this, event)" runat = "server" style="text-align: right" Font-Size="X-Small" MaxLength="10" Width="150px" CssClass="Digitar" ReadOnly="True"/>
                            <asp:RequiredFieldValidator ID="rfv_retefuente" runat="server" ControlToValidate="txtValor_Retefuente" ErrorMessage="Falta Dato de Retefuente" ValidationGroup="RET" EnableClientScript="False">*</asp:RequiredFieldValidator>
                            <asp:Label ID="lbl_IdRet" runat="server" Width="25%" Visible="False"></asp:Label></td>
                    </tr>
                    <tr  valign="top">
                        <td class="LabelCell" colspan="3" align="center"><asp:Button ID="btn_Guardar_Retencion" runat="server" CssClass="Boton" Text="Guardar Retención" Width="150px" />
                            <asp:Button ID="btn_limpiar" runat="server" CssClass="Boton" Text="Limpiar" Width="150px" /></td>
                        <td align="center" class="LabelCell" colspan="1">
                            <asp:Label ID="Label3" runat="server" BackColor="#FFFFC0" Font-Size="Large" ForeColor="Navy"
                                Width="100%">Valor Total :</asp:Label></td>
                        <td align="center" class="LabelCell" colspan="2" style="width: 34%; background-color: #87bbdd">
                            <asp:Label ID="Lbl_ValorFinal" runat="server" Font-Bold="True" Font-Italic="True"
                                Font-Names="Courier New" Font-Size="Large" ForeColor="Maroon">0</asp:Label></td>
                    </tr>

                    <tr  valign="top">
                        <td class="LabelCell" colspan="6">
                            <asp:Label ID="Label10" runat="server" BackColor="#FFC080" Font-Bold="True" ForeColor="Navy"
                                Width="100%"></asp:Label></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    
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
            <telerik:AjaxSetting AjaxControlID="ddlRegional">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="txtLugar_Entrega" />
                    <telerik:AjaxUpdatedControl ControlID="txtObservaciones" />
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
                    <telerik:AjaxUpdatedControl ControlID="lblMensaje" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="dg_Retenciones">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ddl_Conceptos" />
                    <telerik:AjaxUpdatedControl ControlID="txt_base" />
                    <telerik:AjaxUpdatedControl ControlID="txtPorcentaje_Retefuente" />
                    <telerik:AjaxUpdatedControl ControlID="txtValor_Retefuente" />
                    <telerik:AjaxUpdatedControl ControlID="lbl_IdRet" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="txt_base">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="txtPorcentaje_Retefuente" />
                    <telerik:AjaxUpdatedControl ControlID="txtValor_Retefuente" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="txtPorcentaje_Retefuente">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="txt_base" />
                    <telerik:AjaxUpdatedControl ControlID="txtValor_Retefuente" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btn_Guardar_Retencion">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ddl_Conceptos" />
                    <telerik:AjaxUpdatedControl ControlID="dg_Retenciones" />
                    <telerik:AjaxUpdatedControl ControlID="txt_base" />
                    <telerik:AjaxUpdatedControl ControlID="txtPorcentaje_Retefuente" />
                    <telerik:AjaxUpdatedControl ControlID="txtValor_Retefuente" />
                    <telerik:AjaxUpdatedControl ControlID="lbl_IdRet" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btn_limpiar">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ddl_Conceptos" />
                    <telerik:AjaxUpdatedControl ControlID="dg_Retenciones" />
                    <telerik:AjaxUpdatedControl ControlID="txt_base" />
                    <telerik:AjaxUpdatedControl ControlID="txtPorcentaje_Retefuente" />
                    <telerik:AjaxUpdatedControl ControlID="txtValor_Retefuente" />
                    <telerik:AjaxUpdatedControl ControlID="lbl_IdRet" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="LoadingPanel2" runat="server" BackgroundPosition="Right"
        Height="0px" Transparency="50">
        <asp:Image ID="Image1" runat="server" AlternateText="Cargando..." ImageUrl="~/Images/loading.gif" />
    </telerik:RadAjaxLoadingPanel>


  <script type="text/javascript">

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
        </script>    

</asp:Content>

