<%@ Page Title="" Language="VB" MasterPageFile="~/Controles/MasterPage.master" AutoEventWireup="false" CodeFile="OrdenCompraSaldos.aspx.vb" Inherits="Webforms_OrdenCompraSaldos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <telerik:RadScriptManager ID="RadScriptManager1" runat="server"/>
    <asp:Panel runat="server" ID="pnl_principal" DefaultButton ="btn_actualizar" Width ="100%">
    <table id="TablaContenido" cellspacing="0" cellpadding="0" border="0" class="ContentTable" style="width: 100%">
        <tr valign="top">
        <td style="width: 75%"> 
            <asp:Label ID="lbl_Titulo" runat="server" Text="CONSULTA DE ORDEN DE COMPRA" Width="90%" CssClass="TitTitulo" BackColor="PeachPuff"></asp:Label><br />
            <asp:Label ID="lblMensaje" runat="server" CssClass="TitMensaje" Text="_" Width="90%" Visible="False"/>
        </td>
        <td style="width: 25%" align="right">
            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/Printer.jpg" ToolTip="Imprimir " />
            <asp:ImageButton ID="btn_actualizar" runat="server" ImageUrl="~/Images/Reload.jpg" ToolTip="Actualizar la vista actual." TabIndex="1" />
            <asp:ImageButton ID="btn_nuevo" runat="server" ImageUrl="~/Images/Add.jpg" ToolTip="Crear Nuevo Registro." Visible="False" TabIndex="2" />
            <asp:ImageButton ID="btn_cerrar" runat="server" ImageUrl="~/Images/Stop.jpg" ToolTip="Cerrar - Volver a la vista anterior." TabIndex="3" />
            <asp:ImageButton ID="btn_home" runat="server" ImageUrl="~/Images/Home.jpg" ToolTip="Ir al Inicio." TabIndex="4" />&nbsp;</td>
        </tr>

        <tr valign="top">
            <td colspan="2">
                <table id="tblContenido" class="EditControlsTable" cellspacing="0" cellpadding="0" border="0" style="width: 100%">

                    <tr  valign="top">
                        <td  class="LabelCell" style="width: 15%;" align="left">
                            <asp:Label id="lblRegional" runat="server" Width="90%" CssClass="LabelsDigitar">Regional</asp:Label>
                        </td>
                        <td class="ControlCell" style="width: 15%;" align="left">
                            <asp:Label ID="lbl_regionaloc" runat="server" CssClass="Digitar" Width="90%"></asp:Label></td>
                        <td align="left" class="ControlCell" style="width: 15%">
                            <asp:Label id="lblNumero" runat="server" Width="90%">Número</asp:Label></td>
                        <td align="left" class="ControlCell" style="width: 15%">
                            <asp:Label ID="lbl_numero" runat="server" CssClass="Digitar" Width="90%"></asp:Label></td>
                        <td class="ControlCell" style="width: 15%;" align="left">
                            <asp:Label id="lblTercero" runat="server" Width="90%">Tercero</asp:Label></td>
                        <td class="ControlCell" style="width: 25%;" align="left">
                            <asp:Label ID="lbl_Tercero" runat="server" CssClass="Digitar" Width="90%"></asp:Label></td>
                    </tr>

                    <tr  valign="top"><td  class="LabelCell" style="width: 15%; height: 14px;" align="left">
                    <asp:Label id="lblForma_Pago" runat="server" Width="90%" CssClass="LabelsDigitar">Forma de Pago</asp:Label></td><td class="ControlCell" style="width: 15%; height: 14px;" align="left">
                        <asp:Label ID="lbl_Forma" runat="server" CssClass="Digitar" Width="90%"></asp:Label></td>
                        <td align="left" class="ControlCell" style="width: 15%; height: 14px;">
                    <asp:Label id="lblLugar_Entrega" runat="server" Width="90%" CssClass="LabelsDigitar">Lugar de Entrega</asp:Label></td>
                        <td align="left" class="ControlCell" style="width: 15%; height: 14px;">
                        <asp:Label ID="lbl_Lugar" runat="server" CssClass="Digitar" Width="90%"></asp:Label></td>
                        <td class="ControlCell" style="width: 15%; height: 14px;" align="left">
                    <asp:Label id="lblFecha" runat="server" Width="90%">Fecha</asp:Label></td>
                        <td class="ControlCell" style="width: 25%; height: 14px;" align="left">
                            <asp:Label ID="lbl_fecha" runat="server" CssClass="Digitar" Width="90%"></asp:Label></td>
                    </tr>

                    <tr  valign="top"><td  class="LabelCell" style="width: 15%;" align="left">
                        <asp:Label ID="Label4" runat="server" CssClass="LabelsDigitar" Width="90%">Tasa TRM</asp:Label></td><td class="ControlCell" align="left" style="width: 15%;">
                        <asp:Label ID="lbl_Tasa" runat="server" CssClass="Digitar" Width="90%"></asp:Label></td>
                        <td align="left" class="ControlCell" style="width: 15%">
                        </td>
                        <td align="left" class="ControlCell" style="width: 15%">
                        </td>
                        <td align="left" class="ControlCell" style="width: 15%;">
                            </td>
                        <td align="left" class="ControlCell" style="width: 25%;">
                            </td>
                    </tr>

                    <tr  valign="top"><td  class="LabelCell" style="width: 15%" align="left">
                    <asp:Label id="lblObservaciones" runat="server" Width="90%" CssClass="LabelsDigitar">Observaciones</asp:Label>


                    </td><td class="ControlCell" colspan="5" rowspan="1" align="left" style="width: 85%">
                        <asp:Label ID="lbl_Observaciones" runat="server" CssClass="Digitar" Height="60px"
                            Width="96%"></asp:Label></td>
                    </tr>
                    <tr  valign="top">
                        <td class="LabelCell" colspan="4" style="background-color: #ffc080">
                            <asp:Label ID="Label1" runat="server" BackColor="#FFC080" Font-Bold="True" ForeColor="Navy"
                                Width="47%">Sistema de Aprobación de la Orden de Compra</asp:Label></td>
                        <td align="center" class="LabelCell" colspan="2" style="background-color: #ffc080">
                            <asp:Label ID="Label6" runat="server" Width="41%" CssClass="LabelsDigitar">Resumen de las Retenciones</asp:Label></td>
                    </tr>
                    <tr  valign="top">
                        <td class="LabelCell" style="width: 15%" align="center">
                            &nbsp;<asp:Label id="lblAprobacion_Logistica_Ofc" runat="server" Font-Bold="True" CssClass="LabelsDigitarEsp">Logística Regional</asp:Label></td>
                        <td class="ControlCell" rowspan="1" style="width: 15%" align="center">
                            <asp:checkbox id="chkAprobacion_Logistica_Ofc" runat="server" Text="." Enabled="False"  /></td>
                        <td align="center" class="ControlCell" rowspan="1" style="width: 15%">
                            <asp:Label id="lblAprobacion_Coordinacion" runat="server" Font-Bold="True" CssClass="LabelsDigitarEsp">Coordinación</asp:Label>
                        </td>
                        <td align="center" class="ControlCell" rowspan="1" style="width: 15%">
                            <asp:checkbox id="chkAprobacion_Coordinacion" runat="server" Text="." Enabled="False"  /></td>
                        <td class="ControlCell" colspan="2" rowspan="4" style="width: 40%; vertical-align: middle; text-align: center;" align="center">
                           <asp:DataGrid ID="dg_Retenciones" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="2" ForeColor="Black" GridLines="None"
                            OnPageIndexChanged="CambioPaginaret" PageSize="3"
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
                                        <%#Container.DataItem.Base_Retencion%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center"/>
                                    <ItemStyle HorizontalAlign="Right"/>
                                </asp:TemplateColumn>
                                                                
                                <asp:TemplateColumn HeaderText="%" SortExpression="Porcentaje">
                                    <ItemTemplate>
                                        <%#Container.DataItem.Porcentaje%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign ="Center" />
                                    <ItemStyle HorizontalAlign ="Center"/>
                                </asp:TemplateColumn>
                                
                                <asp:TemplateColumn HeaderText="Valor" SortExpression="Valor">
                                    <ItemTemplate>
                                        <%#Container.DataItem.Valor%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center"/>
                                    <ItemStyle HorizontalAlign="Right"/>
                                </asp:TemplateColumn>

                            </Columns>
                            <HeaderStyle BackColor="Tan" CssClass="DataGridHeaderStyle" Font-Bold="True" />
                        </asp:DataGrid></td>
                    </tr>
                    <tr  valign="top">
                        <td class="LabelCell" style="width: 15%;" align="center">
                            &nbsp;<asp:Label id="lblAprobacion_Finanzas_Ofc" runat="server" Font-Bold="True" CssClass="LabelsDigitarEsp">Finanzas Regional</asp:Label></td>
                        <td class="ControlCell" rowspan="1" style="width: 15%;" align="center">
                            <asp:checkbox id="chkAprobacion_Finanzas_Ofc" runat="server" Text="." Enabled="False"  /></td>
                        <td align="center" class="ControlCell" rowspan="1" style="width: 15%">
                            <asp:Label id="lblAprobacion_Operaciones" runat="server" Font-Bold="True" CssClass="LabelsDigitarEsp">Operaciones</asp:Label></td>
                        <td align="center" class="ControlCell" rowspan="1" style="width: 15%">
                            <asp:checkbox id="chkAprobacion_Operaciones" runat="server" Text="." Enabled="False"  ></asp:checkbox></td>
                    </tr>
                    <tr  valign="top">
                        <td class="LabelCell" style="width: 15%;" align="center">
                            &nbsp;<asp:Label ID="lblAprobacion_Direccion" runat="server" CssClass="LabelsDigitarEsp"
                                Font-Bold="True">Coordinador Logística</asp:Label></td>
                        <td class="ControlCell" rowspan="1" style="width: 15%;" align="center">
                            <asp:CheckBox ID="chkAprobacion_CooLogistica" runat="server" Enabled="False" Text="." /></td>
                        <td align="center" class="ControlCell" rowspan="1" style="width: 15%">
                            <asp:Label id="Label3" runat="server" Font-Bold="True" CssClass="LabelsDigitarEsp">Dirección Financiera</asp:Label></td>
                        <td align="center" class="ControlCell" rowspan="1" style="width: 15%">
                            <asp:checkbox id="chkAprobacion_Financiera" runat="server" Enabled="False" Text="."  ></asp:checkbox></td>
                    </tr>
                    <tr valign="top">
                        <td class="LabelCell" style="width: 15%" align="left">
                            </td>
                        <td class="ControlCell" rowspan="1" style="width: 15%" align="left">
                            </td>
                        <td align="left" class="ControlCell" rowspan="1" style="width: 15%">
                        </td>
                        <td align="left" class="ControlCell" rowspan="1" style="width: 15%">
                        </td>
                    </tr>
                    <tr  valign="top">
                        <td class="LabelCell" colspan="6" style="height: 14px">
                            </td>
                    </tr>
                    <tr  valign="top">
                        <td class="LabelCell" colspan="6" style="background-color: #ffc080;" align="center">
                            <asp:Label ID="Label2" runat="server" BackColor="#FFC080" Font-Bold="True" ForeColor="Navy"
                                Width="80%">Detalle de la Orden de Compra</asp:Label>
                            </td>
                    </tr>

                    <tr  valign="top">
                        <td  class="LabelCell" colspan="6">
                            <telerik:RadGrid ID="Rg_Listado" runat="server" 
                                AllowSorting="True" GridLines="None" Skin="Simple" Width="100%" AutoGenerateColumns="False" TabIndex="8" PageSize="20" ShowFooter="True">
                            <MasterTableView  NoDetailRecordsText="No hay informaci&#243;n." NoMasterRecordsText="No hay informaci&#243;n." DataKeyNames="Id" AllowPaging="True">
                                <Columns>
                                     
                                   <telerik:GridTemplateColumn HeaderText="No.">
                                        <ItemTemplate>
                                            <asp:label runat="server" id="lblno" text='<%# ctype(CType(Container.Parent.Parent.Parent,RadGrid).DataSource,IList).IndexOf(Container.DataItem)+1 %>' />
                                            <asp:Label runat="Server" Id="lblid" Visible ="False" Text ='<%#Container.DataItem.Id%>'/>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>                                
                                                                                
                                    <telerik:GridBoundColumn DataField="Id" DataType="System.Int32" HeaderText="Id" ReadOnly="True"
                                        SortExpression="Id" UniqueName="Id"  Visible ="False" DefaultInsertValue="">
                                    </telerik:GridBoundColumn>
                                    
                                    <telerik:GridBoundColumn DataField="Nivel.Descripcion_PadreHijo" HeaderText="R. Presupuestal" SortExpression="Nivel.Descripcion_PadreHijo"
                                        UniqueName="Nivel.Descripcion_PadreHijo" DefaultInsertValue="" >
                                        <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                            Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                                        <ItemStyle HorizontalAlign ="Left" />    
                                    </telerik:GridBoundColumn> 
                                       
                                    <telerik:GridBoundColumn DataField="Productos.Descripcion" HeaderText="Productos"
                                        SortExpression="Productos.Descripcion" UniqueName="Productos.Descripcion" DefaultInsertValue="" >
                                        <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                            Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                                        <ItemStyle HorizontalAlign ="Center" />    
                                    </telerik:GridBoundColumn>       
                                                                               
                                    <telerik:GridBoundColumn DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad" DataFormatString="{0:N}"
                                        UniqueName="Cantidad" Aggregate="Sum" DefaultInsertValue="" >
                                        <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                            Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                                        <ItemStyle HorizontalAlign="Right" />
                                        <FooterStyle HorizontalAlign ="Right" />
                                    </telerik:GridBoundColumn>
                                    
                                    <telerik:GridBoundColumn DataField="UnidadMedida.Descripcion" HeaderText="Medida" SortExpression="UnidadMedida.Descripcion" 
                                        UniqueName="UnidadMedida.Descripcion" DefaultInsertValue="" >
                                        <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                            Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>            

                                    <telerik:GridBoundColumn DataField="Valor_Unitario" HeaderText="Valor Unitario" SortExpression="Valor_Unitario" DataFormatString="{0:c}"
                                        UniqueName="Valor_Unitario" DefaultInsertValue="" >
                                        <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                            Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    
                                    <telerik:GridBoundColumn DataField="ValorProducto" HeaderText="Valor Total" SortExpression="ValorProducto" DataFormatString="{0:c}"
                                        UniqueName="ValorProducto" Aggregate="Sum" DefaultInsertValue="" >
                                        <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                            Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                                        <ItemStyle HorizontalAlign="Right" />
                                        <FooterStyle HorizontalAlign ="Right" />
                                    </telerik:GridBoundColumn>

                                    <telerik:GridBoundColumn DataField="cantidadentrada" HeaderText="Entrada" SortExpression="cantidadentrada" DataFormatString="{0:N}"
                                        UniqueName="cantidadentrada" Aggregate="Sum" DefaultInsertValue="" >
                                        <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                            Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                                        <ItemStyle HorizontalAlign="Right" />
                                        <FooterStyle HorizontalAlign ="Right" />
                                    </telerik:GridBoundColumn>

                                    <telerik:GridBoundColumn DataField="Saldo" HeaderText="Saldo" SortExpression="Saldo" DataFormatString="{0:N}"
                                        UniqueName="Saldo" Aggregate="Sum" DefaultInsertValue="" >
                                        <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                            Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                                        <ItemStyle HorizontalAlign="Right" />
                                        <FooterStyle HorizontalAlign ="Right" />
                                    </telerik:GridBoundColumn>

                                    <telerik:GridTemplateColumn HeaderText="Activo" UniqueName="TemplateColumn"  >
		                                <ItemTemplate>
		                                   <asp:CheckBox runat="server" ID="chk_activo" Enabled ="false" Checked = '<%#Container.DataItem.Activo%>'  ToolTip ='<%#Container.DataItem.Motivo_Cancelacion%>'/>
		                                </ItemTemplate>
		                                <ItemStyle HorizontalAlign ="Center" />
		                                <HeaderStyle  HorizontalAlign ="Center"  />
                                    </telerik:GridTemplateColumn>

                                </Columns>
                                <PagerStyle Mode="NumericPages" FirstPageToolTip="Primera" LastPageToolTip="Ultima" NextPagesToolTip="Pr&#243;ximas" NextPageToolTip="Pr&#243;xima" PagerTextFormat="Cambiar P&#225;gina: {4} &amp;nbsp;P&#225;gina &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;, registros &lt;strong&gt;{2}&lt;/strong&gt; a &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PrevPageToolTip="Anterior"  PrevPagesToolTip="Anteriores" />
                            </MasterTableView>
                            <ClientSettings EnablePostBackOnRowClick="False" EnableRowHoverStyle ="True" >
                            <Selecting AllowRowSelect ="True"  />
                            </ClientSettings>
                            <SortingSettings SortToolTip="Clic aqui para ordenar..."  SortedAscToolTip ="Ordenar Ascendente" SortedDescToolTip ="Ordenar Descendente" />
                            <PagerStyle Mode="NumericPages"    />
                        </telerik:RadGrid>                      
                        </td>
                    </tr>

                </table>
            </td>

        </tr>
    </table>
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

