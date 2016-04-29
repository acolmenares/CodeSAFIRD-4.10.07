<%@ Page Title="" Language="VB" MasterPageFile="~/Controles/MasterPage.master" AutoEventWireup="false" CodeFile="OrdenCompraSaldosList.aspx.vb" Inherits="Webforms_OrdenCompraSaldosList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

   <telerik:RadScriptManager ID="RadScriptManager1" runat="server"/>
    <asp:Panel runat="server" ID="pnl_principal" DefaultButton ="imb_buscar" Width ="100%">
    <table id="tbl_Interna" border="0" cellpadding="1" cellspacing="0" width="100%" style="border-right: whitesmoke thin solid; border-top: whitesmoke thin solid; border-left: whitesmoke thin solid; border-bottom: whitesmoke thin solid">
        <tr valign="top">
        <td style="width: 75%;"> 
            <asp:Label ID="lbl_Titulo" runat="server" Text="VISTA GENERAL DE SALDOS DE ORDENES DE COMPRA" Width="100%" CssClass="TitTitulo" BackColor="PeachPuff"></asp:Label><br />
            <asp:Label ID="lblMensaje" runat="server" CssClass="TitMensaje" Text="_" Width="100%" Visible="False"></asp:Label>
        </td>
        <td style="width: 25%" align="right">
            <asp:ImageButton ID="btn_actualizar" runat="server" ImageUrl="~/Images/Reload.jpg" ToolTip="Actualizar la vista actual." TabIndex="1" />
            <asp:ImageButton ID="btn_buscar" runat="server" ImageUrl="~/Images/Zoom In.jpg" ToolTip="Ver/quitar Sistema de Búsqueda." TabIndex="2" />
            <asp:ImageButton ID="btn_nuevo" runat="server" ImageUrl="~/Images/Add.jpg" ToolTip="Crear Nuevo Registro." Visible="False" TabIndex="3" />
            <asp:ImageButton ID="btn_cerrar" runat="server" ImageUrl="~/Images/Stop.jpg" ToolTip="Cerrar - Volver a la vista anterior." TabIndex="4" />
            <asp:ImageButton ID="btn_home" runat="server" ImageUrl="~/Images/Home.jpg" ToolTip="Ir al Inicio." TabIndex="5" />&nbsp;</td>
        </tr>
        <tr valign="top">
            <td colspan="2" align="center">    
                <asp:Panel ID="pnl_buscar" runat="server" HorizontalAlign="Center" Width="90%" style="text-align: center; border-right: palegoldenrod thin ridge; border-top: palegoldenrod thin ridge; border-left: palegoldenrod thin ridge; border-bottom: palegoldenrod thin ridge;" Visible="False"  >
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; text-align: left">
                        <tr valign="top">
                            <td colspan="5">
                                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Underline="False" Text="Sistema de Búsqueda Selectiva"
                                    Width="90%"></asp:Label></td>
                            <td colspan="1">
                                <asp:ImageButton ID="imb_todos" runat="server" ImageAlign="Right" ImageUrl="~/Images/New.jpg"
                                    ToolTip="Limpiar los parámetros de búsqueda" TabIndex="7" />
                                <asp:ImageButton ID="imb_buscar" runat="server" ImageAlign="Right" ImageUrl="~/Images/Search.jpg"
                                    ToolTip="Carga la Información del Filtro" TabIndex="6" />
                            </td>
                        </tr>
                        <tr valign="top">
                            <td style="width: 15%">
                                <asp:Label ID="Label1" runat="server" Text="Número" Width="94%"></asp:Label></td>
                            <td style="width: 15%">
                                <asp:TextBox ID="txt_Numero" runat="server" Font-Size="X-Small" MaxLength="10" Width="90%" CssClass="Digitar"></asp:TextBox></td>
                            <td style="width: 15%">
                                <asp:Label ID="Label10" runat="server" Text="Fecha Inicial " Width="94%"></asp:Label></td>
                            <td style="width: 15%">
                                <telerik:RadDatePicker ID="rdpFechaInicial" runat="server" Culture="Spanish (Colombia)"
                                    MinDate="" Skin="Sunset" TabIndex="2" ToolTip="Seleccione Fecha ..." Width="95%">
                                    <Calendar Skin="Sunset" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                        ViewSelectorText="x">
                                        <FastNavigationSettings CancelButtonCaption="Cancelar" DateIsOutOfRangeMessage="Fecha Fuera de Rango"
                                            TodayButtonCaption="Hoy">
                                        </FastNavigationSettings>
                                    </Calendar>
                                    <DatePopupButton HoverImageUrl="" ImageUrl="" TabIndex="2" ToolTip="Abrir el Calendario" />
                                    <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MMMM/yyyy" EmptyMessage="Fecha ..."
                                        TabIndex="2">
                                    </DateInput>
                                </telerik:RadDatePicker>
                            </td>
                            <td style="width: 15%">
                                <asp:Label ID="Label7" runat="server" Text="Proveedor / Tercero" Width="94%"></asp:Label></td>
                            <td style="width: 15%">
                                <asp:DropDownList ID="ddl_Terceros" runat="server" Font-Size="X-Small" CssClass="drop01" TabIndex="4">
                                </asp:DropDownList></td>
                        </tr>
                        <tr valign="top">
                            <td style="width: 15%">
                                <asp:Label ID="Label4" runat="server" Text="Regional" Width="94%"></asp:Label></td>
                            <td style="width: 15%">
                                <asp:DropDownList ID="ddl_regional" runat="server" Font-Size="X-Small" CssClass="drop01" TabIndex="1">
                                </asp:DropDownList></td>
                            <td style="width: 15%">
                                <asp:Label ID="Label12" runat="server" Text="Fecha Final" Width="94%"></asp:Label></td>
                            <td style="width: 15%">
                                <telerik:RadDatePicker ID="rdpfechaFinal" runat="server" Culture="Spanish (Colombia)"
                                    MinDate="" Skin="Sunset" TabIndex="3" ToolTip="Seleccione Fecha ..." Width="95%">
                                    <Calendar Skin="Sunset" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                        ViewSelectorText="x">
                                        <FastNavigationSettings CancelButtonCaption="Cancelar" DateIsOutOfRangeMessage="Fecha Fuera de Rango"
                                            TodayButtonCaption="Hoy">
                                        </FastNavigationSettings>
                                    </Calendar>
                                    <DatePopupButton HoverImageUrl="" ImageUrl="" TabIndex="3" ToolTip="Abrir el Calendario" />
                                    <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MMMM/yyyy" EmptyMessage="Fecha ..."
                                        TabIndex="3">
                                    </DateInput>
                                </telerik:RadDatePicker>
                            </td>
                            <td style="width: 15%">
                                <asp:Label ID="Label22" runat="server" Text="Producto" Width="94%"></asp:Label></td>
                            <td style="width: 15%">
                                <asp:DropDownList ID="ddl_Productos" runat="server" Font-Size="X-Small" CssClass="drop01" TabIndex="5">
                                </asp:DropDownList></td>
                        </tr>
                    </table>
                </asp:Panel>
			</td>
		</tr>
		<tr valign="top">
			<td  class="DataGridFormList" colspan="2">
                <telerik:RadGrid ID="Rg_Listado" runat="server" AllowSorting="True" GridLines="None" Skin="Simple" Width="100%" AutoGenerateColumns="False" ShowStatusBar="True" TabIndex="7" PageSize="15">
                    <MasterTableView  NoDetailRecordsText="No hay informaci&#243;n." NoMasterRecordsText="No hay informaci&#243;n." DataKeyNames="Id" CommandItemDisplay ="Top" AllowPaging="True" PageSize="20">
                        <Columns>
                           <telerik:GridTemplateColumn HeaderText="No." DefaultInsertValue="" UniqueName="TemplateColumn5">
                                <ItemTemplate>
                                    <asp:label runat="server" id="lblno" text='<%# ctype(CType(Container.Parent.Parent.Parent,RadGrid).DataSource,IList).IndexOf(Container.DataItem)+1 %>' />
                                    <asp:Label runat="Server" Id="lblid" Visible ="False" Text ='<%#Container.DataItem.Id%>'/>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>                                
                        
                            <telerik:GridBoundColumn DataField="Id" DataType="System.Int32" HeaderText="Id" ReadOnly="True"
                                SortExpression="Id" UniqueName="Id"  Display ="False" DefaultInsertValue="">
                            </telerik:GridBoundColumn>
                            
                            <telerik:GridBoundColumn DataField="Fecha" DataType="System.DateTime" HeaderText="Fecha" DataFormatString="{0:dd/MMM/yyyy}"
                                SortExpression="Fecha" UniqueName="Fecha" DefaultInsertValue="" >
                                <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                    Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                            </telerik:GridBoundColumn>
                               
                            <telerik:GridBoundColumn DataField="Numero" HeaderText="N&#250;mero" SortExpression="Numero"
                                UniqueName="Numero" DefaultInsertValue="" >
                                <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                    Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                            </telerik:GridBoundColumn> 
                            
                            <telerik:GridBoundColumn DataField="Terceros.Razon_Social" HeaderText="Razon Social"
                                SortExpression="Terceros.Razon_Social" UniqueName="Terceros.Razon_Social" DefaultInsertValue="" >
                                <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                    Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                            </telerik:GridBoundColumn>       

                            <telerik:GridBoundColumn DataField="Regional.Descripcion" HeaderText="Regional"
                                SortExpression="Regional.Descripcion" UniqueName="Regional.Descripcion" DefaultInsertValue="" >
                                <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                    Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                            </telerik:GridBoundColumn>  
                            
					        <telerik:GridTemplateColumn HeaderText="LOG" UniqueName="TemplateColumn" HeaderTooltip="Aprobaci&#243;n Logística" >
			                    <ItemTemplate>
			                       <asp:CheckBox runat="server" ID="chk_aprblog" Enabled ="false" Checked = '<%# Eval("Aprobacion_Logistica_OFC")%>' />
			                    </ItemTemplate>
			                    <ItemStyle HorizontalAlign ="Center" />
			                    <HeaderStyle HorizontalAlign ="Center"  />
		                    </telerik:GridTemplateColumn>
			            
					        <telerik:GridTemplateColumn HeaderText="FIN" UniqueName="TemplateColumn1" HeaderTooltip="Aprobaci&#243;n Financiera">
			                    <ItemTemplate>
			                       <asp:CheckBox runat="server" ID="chk_aprbfin" Enabled ="false" Checked = '<%# Eval("Aprobacion_Finanzas_OFC")%>' />
			                    </ItemTemplate>
			                    <ItemStyle HorizontalAlign ="Center" />
			                    <HeaderStyle HorizontalAlign ="Center" />
		                    </telerik:GridTemplateColumn>	

					        <telerik:GridTemplateColumn HeaderText="COL" UniqueName="TemplateColumn4" HeaderTooltip="Aprobaci&#243;n Coordinación Logística" >
			                    <ItemTemplate>
			                       <asp:CheckBox runat="server" ID="chk_aprbcol" Enabled ="false" Checked = '<%# Eval("Aprobacion_CooLogistica") %>' />
			                    </ItemTemplate>
			                    <ItemStyle HorizontalAlign ="Center" />
			                    <HeaderStyle HorizontalAlign ="Center" />
		                    </telerik:GridTemplateColumn>

					        <telerik:GridTemplateColumn HeaderText="COO" UniqueName="TemplateColumn2" HeaderTooltip="Aprobaci&#243;n Coordinaci&#243;n" >
			                    <ItemTemplate>
			                       <asp:CheckBox runat="server" ID="chk_aprbcoo" Enabled ="false" Checked = '<%# Eval("Aprobacion_Coordinacion")%>' />
			                    </ItemTemplate>
			                    <ItemStyle  HorizontalAlign ="Center" />
			                    <HeaderStyle  HorizontalAlign ="Center" />
		                    </telerik:GridTemplateColumn>

					        <telerik:GridTemplateColumn HeaderText="OPE" UniqueName="TemplateColumn3" HeaderTooltip="Aprobaci&#243;n Operaciones" >
			                    <ItemTemplate>
			                       <asp:CheckBox runat="server" ID="chk_aprbope" Enabled ="false" Checked = '<%# Eval("Aprobacion_Operaciones")%>' />
			                    </ItemTemplate>
			                    <ItemStyle  HorizontalAlign ="Center" />
			                    <HeaderStyle  HorizontalAlign ="Center" />
		                    </telerik:GridTemplateColumn>

					        <telerik:GridTemplateColumn HeaderText="DAF" UniqueName="TemplateColumn3" HeaderTooltip="Aprobaci&#243;n Financiera" >
			                    <ItemTemplate>
			                       <asp:CheckBox runat="server" ID="chk_aprbdaf" Enabled ="false" Checked = '<%# Eval("Aprobacion_Financiera")%>' />
			                    </ItemTemplate>
			                    <ItemStyle  HorizontalAlign ="Center" />
			                    <HeaderStyle  HorizontalAlign ="Center" />
		                    </telerik:GridTemplateColumn>

                            <telerik:GridBoundColumn DataField="Tipo_Orden.Descripcion" HeaderText="Tipo Orden" Visible ="False"
                                SortExpression="Tipo_Orden.Descripcion" UniqueName="Tipo_Orden.Descripcion" DefaultInsertValue="" >
                            </telerik:GridBoundColumn>  
                            				            
                            <telerik:GridBoundColumn DataField="Codigo_Proyecto" HeaderText="Cod. Proyecto" Visible ="False"
                                SortExpression="Codigo_Proyecto" UniqueName="Codigo_Proyecto" DefaultInsertValue="" >
                            </telerik:GridBoundColumn>  				            

                            <telerik:GridBoundColumn DataField="EstadoOrden" HeaderText="Estado"
                                SortExpression="EstadoOrden" UniqueName="EstadoOrden" DefaultInsertValue="" >
                                <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                    Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                            </telerik:GridBoundColumn>  
                        </Columns>
                        <CommandItemSettings ExportToCsvText ="Exportar a CSV" ExportToExcelText ="Exportar a Excel" ExportToPdfText ="Exportar a PDF"
                             ExportToWordText ="Exportar a Word" RefreshText ="Actualizar" AddNewRecordText =""  AddNewRecordImageUrl ="~/Images/nothing.gif"
                              ShowExportToCsvButton="True" ShowExportToExcelButton="True" ShowExportToPdfButton="True" ShowExportToWordButton ="True"/>
                        <PagerStyle Mode="NumericPages" FirstPageToolTip="Primera" LastPageToolTip="Ultima" NextPagesToolTip="Pr&#243;ximas" NextPageToolTip="Pr&#243;xima" PagerTextFormat="Cambiar P&#225;gina: {4} &amp;nbsp;P&#225;gina &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;, registros &lt;strong&gt;{2}&lt;/strong&gt; a &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PrevPageToolTip="Anterior"  PrevPagesToolTip="Anteriores" />
                    </MasterTableView>
                    <ClientSettings EnablePostBackOnRowClick="True" EnableRowHoverStyle ="True" >
                    <Selecting AllowRowSelect ="True"  />
                    </ClientSettings>
                    
                     <ExportSettings
                       HideStructureColumns="True" filename ="OrdenCompraSaldos" ExportOnlyData="True" IgnorePaging="True" OpenInNewWindow="True">
                    </ExportSettings>
                    <SortingSettings SortToolTip="Clic aqui para ordenar..."  SortedAscToolTip ="Ordenar Ascendente" SortedDescToolTip ="Ordenar Descendente" />
                    <PagerStyle Mode="NumericPages"    />
                </telerik:RadGrid>					
            </td>
		</tr>
	</table>
    </asp:Panel> 	
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="LoadingPanel2">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btn_actualizar">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="pnl_buscar" />
                    <telerik:AjaxUpdatedControl ControlID="Rg_Listado" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btn_buscar">
                <UpdatedControls>
                    
                    <telerik:AjaxUpdatedControl ControlID="pnl_buscar" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="imb_todos">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="txt_Numero" />
                    <telerik:AjaxUpdatedControl ControlID="rdpFechaInicial" />
                    <telerik:AjaxUpdatedControl ControlID="ddl_Terceros" />
                    <telerik:AjaxUpdatedControl ControlID="ddl_regional" />
                    <telerik:AjaxUpdatedControl ControlID="rdpfechaFinal" />
                    <telerik:AjaxUpdatedControl ControlID="ddl_Productos" />
                    <telerik:AjaxUpdatedControl ControlID="Rg_Listado" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="imb_buscar">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="txt_Numero" />
                    <telerik:AjaxUpdatedControl ControlID="rdpFechaInicial" />
                    <telerik:AjaxUpdatedControl ControlID="ddl_Terceros" />
                    <telerik:AjaxUpdatedControl ControlID="ddl_regional" />
                    <telerik:AjaxUpdatedControl ControlID="rdpfechaFinal" />
                    <telerik:AjaxUpdatedControl ControlID="ddl_Productos" />
                    <telerik:AjaxUpdatedControl ControlID="Rg_Listado" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="Rg_Listado">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="Rg_Listado" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="LoadingPanel2" runat="server" BackgroundPosition="Right" Height="0px" Transparency="50">
        <asp:Image ID="Image1" runat="server" AlternateText="Cargando..." ImageUrl="~/Images/loading.gif" />
    </telerik:RadAjaxLoadingPanel>

</asp:Content>

