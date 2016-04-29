<%@ Control Language="VB" AutoEventWireup="false" CodeFile="UcOrdenCompra.ascx.vb" Inherits="Controles_UcOrdenCompra" %>
<table id="tbl_contratos" border="1" cellpadding="1" cellspacing="1" style="width: 100%">
    <tr valign ="top">
        <td style="width: 40%">
            <asp:Label ID="Label1" runat="server" CssClass="LabelsDigitar" Text="Seleccione Orden de Compra"
                Width="90%"></asp:Label></td>
        <td style="width: 60%">
            <asp:DropDownList ID="ddl_ordenes" runat="server" CssClass="drop01" Width="80%">
            </asp:DropDownList>
            <asp:ImageButton ID="btn_buscar" runat="server" ImageUrl="~/Images/Accept.jpg" ToolTip="Buscar Orden de Compra" /></td>
    </tr>
    <tr valign ="top">
        <td colspan="2" style="width: 100%; background-color: #ff9933">
        </td>
    </tr>
    <tr valign ="top">
        <td colspan="2">
            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                <tr valign ="top">
                    <td align="left" class="LabelCell" style="width: 15%">
                        <asp:Label ID="lblRegional" runat="server" CssClass="LabelsDigitar" Width="90%">Regional</asp:Label>
                    </td>
                    <td align="left" class="ControlCell" style="width: 15%">
                        <asp:Label ID="lbl_regionaloc" runat="server" CssClass="Digitar" Width="90%"></asp:Label></td>
                    <td align="left" class="ControlCell" style="width: 15%">
                        <asp:Label ID="lblNumero" runat="server" Width="90%">Numero</asp:Label></td>
                    <td align="left" class="ControlCell" style="width: 15%">
                        <asp:Label ID="lbl_numero" runat="server" CssClass="Digitar" Width="90%"></asp:Label></td>
                    <td align="left" class="ControlCell" style="width: 15%">
                        <asp:Label ID="lblTercero" runat="server" Width="90%">Tercero</asp:Label></td>
                    <td align="left" class="ControlCell" style="width: 25%">
                        <asp:Label ID="lbl_Tercero" runat="server" CssClass="Digitar" Width="90%"></asp:Label></td>
                </tr>
                <tr valign ="top">
                    <td align="left" class="LabelCell" style="width: 15%; height: 14px">
                        <asp:Label ID="lblForma_Pago" runat="server" CssClass="LabelsDigitar" Width="90%">Forma de Pago</asp:Label></td>
                    <td align="left" class="ControlCell" style="width: 15%; height: 14px">
                        <asp:Label ID="lbl_Forma" runat="server" CssClass="Digitar" Width="90%"></asp:Label></td>
                    <td align="left" class="ControlCell" style="width: 15%; height: 14px">
                        <asp:Label ID="lblLugar_Entrega" runat="server" CssClass="LabelsDigitar" Width="90%">Lugar de Entrega</asp:Label></td>
                    <td align="left" class="ControlCell" style="width: 15%; height: 14px">
                        <asp:Label ID="lbl_Lugar" runat="server" CssClass="Digitar" Width="90%"></asp:Label></td>
                    <td align="left" class="ControlCell" style="width: 15%; height: 14px">
                        <asp:Label ID="lblFecha" runat="server" Width="90%">Fecha</asp:Label></td>
                    <td align="left" class="ControlCell" style="width: 25%; height: 14px">
                        <asp:Label ID="lbl_fecha" runat="server" CssClass="Digitar" Width="90%"></asp:Label></td>
                </tr>
                <tr valign ="top">
                    <td align="left" class="LabelCell" style="width: 15%">
                        <asp:Label ID="Label4" runat="server" CssClass="LabelsDigitar" Width="90%">Tasa TRM</asp:Label></td>
                    <td align="left" class="ControlCell" style="width: 15%">
                        <asp:Label ID="lbl_Tasa" runat="server" CssClass="Digitar" Width="90%"></asp:Label></td>
                    <td align="left" class="ControlCell" style="width: 15%">
                    </td>
                    <td align="left" class="ControlCell" style="width: 15%">
                    </td>
                    <td align="left" class="ControlCell" style="width: 15%">
                    </td>
                    <td align="left" class="ControlCell" style="width: 25%">
                    </td>
                </tr>
                    <tr  valign="top">
                        <td class="LabelCell" colspan="4" style="background-color: #ffc080">
                            <asp:Label ID="Label3" runat="server" BackColor="#FFC080" Font-Bold="True" ForeColor="Navy"
                                Width="90%">Sistema de Aprobación de la Orden de Compra</asp:Label></td>
                        <td align="center" class="LabelCell" colspan="2" style="background-color: #ffc080">
                            <asp:Label ID="Label6" runat="server" Width="90%" CssClass="LabelsDigitar">Resumen de las Retenciones</asp:Label></td>
                    </tr>
                    <tr  valign="top">
                        <td class="LabelCell" style="width: 15%" align="center">
                            &nbsp;<asp:Label id="lblAprobacion_Logistica_OFC" runat="server" Font-Bold="True" CssClass="LabelsDigitarEsp">Logística Regional</asp:Label></td>
                        <td class="ControlCell" rowspan="1" style="width: 15%" align="center">
                            <asp:checkbox id="chkAprobacion_Logistica_Ofc" runat="server" Text="." Enabled="False"  /></td>
                        <td align="center" class="ControlCell" rowspan="1" style="width: 15%">
                            &nbsp;<asp:Label id="lblAprobacion_Coordinacion" runat="server" Font-Bold="True" CssClass="LabelsDigitarEsp">Coordinación Regional</asp:Label></td>
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
                                Font-Bold="True">Coodinación Logística</asp:Label></td>
                        <td class="ControlCell" rowspan="1" style="width: 15%;" align="center">
                            <asp:CheckBox ID="chkAprobacion_CooLogistica" runat="server" Enabled="False" Text="." /></td>
                        <td align="center" class="ControlCell" rowspan="1" style="width: 15%">
                            <asp:Label id="Label5" runat="server" Font-Bold="True" CssClass="LabelsDigitarEsp">Dirección Financiera</asp:Label></td>
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
                
                <tr valign ="top">
                    <td align="center" colspan="6" style="background-color: #ffc080">
                        <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="Navy" Width="39%">Detalle de la Orden de Compra</asp:Label></td>
                </tr>
                <tr valign ="top">
                    <td colspan="6">
                        <telerik:RadGrid ID="Rg_Listado" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                            GridLines="None" PageSize="20" ShowFooter="True" Skin="Simple" TabIndex="8" Width="100%">
                            <MasterTableView AllowPaging="True" DataKeyNames="Id" NoDetailRecordsText="No hay informaci&#243;n."
                                NoMasterRecordsText="No hay informaci&#243;n.">
                                <Columns>
                                    <telerik:GridTemplateColumn HeaderText="No." DefaultInsertValue="" UniqueName="TemplateColumn1">
                                        <ItemTemplate>
                                            <asp:Label ID="lblno" runat="server" Text='<%# ctype(CType(Container.Parent.Parent.Parent,RadGrid).DataSource,IList).IndexOf(Container.DataItem)+1 %>'></asp:Label>
                                            <asp:Label ID="lblid" runat="Server" Text='<%#Container.DataItem.Id%>' Visible="False"></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn DataField="Id" DataType="System.Int32"
                                        HeaderText="Id" ReadOnly="True" SortExpression="Id" UniqueName="Id" Visible="False">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Nivel.Descripcion_PadreHijo"
                                        HeaderText="R. Presupuestal" SortExpression="Nivel.Descripcion_PadreHijo" UniqueName="Nivel.Descripcion_PadreHijo">
                                        <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                            Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Productos.Descripcion"
                                        HeaderText="Productos" SortExpression="Productos.Descripcion" UniqueName="Productos.Descripcion">
                                        <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                            Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn Aggregate="Sum" DataField="Cantidad" DataFormatString="{0:N}" HeaderText="Cantidad" SortExpression="Cantidad" UniqueName="Cantidad">
                                        <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                            Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                                        <ItemStyle HorizontalAlign="Right" />
                                        <FooterStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="UnidadMedida.Descripcion"
                                        HeaderText="Medida" SortExpression="UnidadMedida.Descripcion" UniqueName="UnidadMedida.Descripcion">
                                        <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                            Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Valor_Unitario" DataFormatString="{0:c}"
                                        HeaderText="Valor Unitario" SortExpression="Valor_Unitario" UniqueName="Valor_Unitario">
                                        <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                            Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn Aggregate="Sum" DataField="ValorProducto" DataFormatString="{0:c}" HeaderText="Valor Total" SortExpression="ValorProducto"
                                        UniqueName="ValorProducto">
                                        <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                            Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                                        <ItemStyle HorizontalAlign="Right" />
                                        <FooterStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn HeaderText="Activo" UniqueName="TemplateColumn" DefaultInsertValue="">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chk_activo" runat="server" Checked='<%#Container.DataItem.Activo%>'
                                                Enabled="false" ToolTip='<%#Container.DataItem.Motivo_Cancelacion%>' />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </telerik:GridTemplateColumn>
                                </Columns>
                                <PagerStyle FirstPageToolTip="Primera" LastPageToolTip="Ultima" Mode="NumericPages"
                                    NextPagesToolTip="Pr&#243;ximas" NextPageToolTip="Pr&#243;xima" PagerTextFormat="Cambiar P&#225;gina: {4} &amp;nbsp;P&#225;gina &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;, registros &lt;strong&gt;{2}&lt;/strong&gt; a &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;."
                                    PrevPagesToolTip="Anteriores" PrevPageToolTip="Anterior" />
                            </MasterTableView>
                            <ClientSettings EnableRowHoverStyle="True">
                                <Selecting AllowRowSelect="True" />
                            </ClientSettings>
                            <SortingSettings SortedAscToolTip="Ordenar Ascendente" SortedDescToolTip="Ordenar Descendente"
                                SortToolTip="Clic aqui para ordenar..." />
                            <PagerStyle Mode="NumericPages" />
                        </telerik:RadGrid></td>
                </tr>
            </table>
        </td>
    </tr>
    <tr valign ="top">
        <td colspan="2" style="width: 100%; background-color: #ff9933">
        </td>
    </tr>
    <tr valign ="top">
        <td colspan="2">
            <div style="width: 100%; text-align: center">
                <asp:Button ID="btn_contratos" runat="server" CssClass="Boton" Text="Deshabilitar Orden de Compra"
                    Width="200px" />
                <asp:Label ID="lblid" runat="server" CssClass="Digitar" Visible="False"></asp:Label></div>
        </td>
    </tr>
</table>
<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="LoadingPanel2">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="btn_buscar">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="ddl_ordenes" />
                <telerik:AjaxUpdatedControl ControlID="lbl_regionaloc" />
                <telerik:AjaxUpdatedControl ControlID="lbl_numero" />
                <telerik:AjaxUpdatedControl ControlID="lbl_Tercero" />
                <telerik:AjaxUpdatedControl ControlID="lbl_Forma" />
                <telerik:AjaxUpdatedControl ControlID="lbl_Lugar" />
                <telerik:AjaxUpdatedControl ControlID="lbl_fecha" />
                <telerik:AjaxUpdatedControl ControlID="lbl_Tasa" />
                <telerik:AjaxUpdatedControl ControlID="chkAprobacion_Logistica_OFC" />
                <telerik:AjaxUpdatedControl ControlID="chkAprobacion_Operaciones" />
                <telerik:AjaxUpdatedControl ControlID="dg_Retenciones" />
                <telerik:AjaxUpdatedControl ControlID="chkAprobacion_Finanzas_Ofc" />
                <telerik:AjaxUpdatedControl ControlID="chkAprobacion_Financiera" />
                <telerik:AjaxUpdatedControl ControlID="chkAprobacion_Coordinacion" />
                <telerik:AjaxUpdatedControl ControlID="chkAprobacion_Direccion" />
                <telerik:AjaxUpdatedControl ControlID="Rg_Listado" />
                <telerik:AjaxUpdatedControl ControlID="lblid" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="btn_contratos">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="ddl_ordenes" />
                <telerik:AjaxUpdatedControl ControlID="lbl_regionaloc" />
                <telerik:AjaxUpdatedControl ControlID="lbl_numero" />
                <telerik:AjaxUpdatedControl ControlID="lbl_Tercero" />
                <telerik:AjaxUpdatedControl ControlID="lbl_Forma" />
                <telerik:AjaxUpdatedControl ControlID="lbl_Lugar" />
                <telerik:AjaxUpdatedControl ControlID="lbl_fecha" />
                <telerik:AjaxUpdatedControl ControlID="lbl_Tasa" />
                <telerik:AjaxUpdatedControl ControlID="chkAprobacion_Logistica_OFC" />
                <telerik:AjaxUpdatedControl ControlID="chkAprobacion_Operaciones" />
                <telerik:AjaxUpdatedControl ControlID="dg_Retenciones" />
                <telerik:AjaxUpdatedControl ControlID="chkAprobacion_Finanzas_Ofc" />
                <telerik:AjaxUpdatedControl ControlID="chkAprobacion_Financiera" />
                <telerik:AjaxUpdatedControl ControlID="chkAprobacion_Coordinacion" />
                <telerik:AjaxUpdatedControl ControlID="chkAprobacion_Direccion" />
                <telerik:AjaxUpdatedControl ControlID="Rg_Listado" />
                <telerik:AjaxUpdatedControl ControlID="lblid" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManager>
<telerik:RadAjaxLoadingPanel ID="LoadingPanel2" runat="server" BackgroundPosition="Right"
    Height="0px" Transparency="50">
    <asp:Image ID="Image1" runat="server" AlternateText="Cargando..." ImageUrl="~/Images/loading.gif" />
</telerik:RadAjaxLoadingPanel>
