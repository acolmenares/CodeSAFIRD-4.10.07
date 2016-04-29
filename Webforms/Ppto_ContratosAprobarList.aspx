<%@ Page Title="" Language="VB" MasterPageFile="~/Controles/MasterPage.master" AutoEventWireup="false" CodeFile="Ppto_ContratosAprobarList.aspx.vb" Inherits="Webforms_Ppto_ContratosAprobarList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <telerik:RadScriptManager ID="RadScriptManager1" runat="server"/>
    <asp:Panel runat="server" ID="pnl_principal" DefaultButton ="btn_actualizar" Width ="100%">
    <table id="tbl_Interna" border="0" cellpadding="1" cellspacing="0" width="100%" style="border-right: whitesmoke thin solid; border-top: whitesmoke thin solid; border-left: whitesmoke thin solid; border-bottom: whitesmoke thin solid">
        <tr valign ="top">
        <td style="width: 75%;"> 
            <asp:Label ID="lbl_Titulo" runat="server" Text="VISTA GENERAL DE CONTRATOS - Aprobación Financiera" Width="100%" CssClass="TitTitulo" BackColor="PeachPuff"></asp:Label><br />
            <asp:Label ID="lblMensaje" runat="server" CssClass="TitMensaje" Text="_" Width="100%" Visible="False"></asp:Label></td>
        <td style="width: 25%" align="right">
            <asp:ImageButton ID="btn_aprobar" runat="server" ImageUrl="~/Images/DBActive.jpg"
                ToolTip="Aprobar Proceso" TabIndex="1" />
            <asp:ImageButton ID="btn_actualizar" runat="server" ImageUrl="~/Images/Reload.jpg" ToolTip="Actualizar la vista actual." TabIndex="2" />
            <asp:ImageButton ID="btn_buscar" runat="server" ImageUrl="~/Images/Zoom In.jpg" ToolTip="Ver/quitar Sistema de Búsqueda." TabIndex="3" />
            <asp:ImageButton ID="btn_nuevo" runat="server" ImageUrl="~/Images/Add.jpg" ToolTip="Crear Nuevo Registro." Visible="False" TabIndex="4" />
            <asp:ImageButton ID="btn_cerrar" runat="server" ImageUrl="~/Images/Stop.jpg" ToolTip="Cerrar - Volver a la vista anterior." TabIndex="5" />
            <asp:ImageButton ID="btn_home" runat="server" ImageUrl="~/Images/Home.jpg" ToolTip="Ir al Inicio." TabIndex="6" />&nbsp;</td>
        </tr>
        <tr valign ="top">
            <td colspan="2" align="center" >
                <asp:Panel ID="pnl_buscar" runat="server" Width="90%" style="text-align: center; border-right: palegoldenrod thin ridge; border-top: palegoldenrod thin ridge; border-left: palegoldenrod thin ridge; border-bottom: palegoldenrod thin ridge;" Visible="False" >
                   
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%" >
                        <tr valign ="top">
                            <td colspan="5" style="text-align: left" align="left">
                                <asp:Label ID="Label1" runat="server" Text="Sistema de Búsqueda Selectiva" Width="90%" Font-Bold="True" Font-Underline="False"></asp:Label></td>
                            <td style="width: 15%" align="right">
                                <asp:ImageButton ID="btn_Procesar" runat="server" ImageUrl="~/Images/Search.jpg" ToolTip="Realizar la Búsqueda." TabIndex="5" />
                                <asp:ImageButton ID="btn_limpiar" runat="server" ImageUrl="~/Images/New.jpg" ToolTip="Limpiar Campos Búsqueda." TabIndex="6" /></td>
                        </tr>
                        <tr valign ="top">
                            <td style="width: 15%;" align="left">
                                <asp:Label ID="Label2" runat="server" Font-Bold="False" Text="Fecha Inicial" Width="90%"></asp:Label></td>
                            <td style="width: 15%;" align="left">
                                <telerik:RadDatePicker ID="rdpFechaInicial" runat="server" Culture="Spanish (Colombia)"
                                    MinDate="" Skin="Sunset" ToolTip="Seleccione Fecha ..." Width="95%">
                                    <Calendar Skin="Sunset" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                        ViewSelectorText="x">
                                        <FastNavigationSettings CancelButtonCaption="Cancelar" DateIsOutOfRangeMessage="Fecha fuera de rango."
                                            TodayButtonCaption="Hoy">
                                        </FastNavigationSettings>
                                    </Calendar>
                                    <DatePopupButton HoverImageUrl="" ImageUrl="" ToolTip="Abrir el Calendario" />
                                    <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MMMM/yyyy" EmptyMessage="Fecha ...">
                                    </DateInput>
                                </telerik:RadDatePicker>
                            </td>
                            <td style="width: 15%;" align="left">
                                <asp:Label ID="Label4" runat="server" Text="Número" Width="90%"></asp:Label></td>
                            <td style="width: 15%;" align="left">
                                <asp:TextBox ID="txt_numero" runat="server"  Width="90%" CssClass="Digitar" MaxLength="10" TabIndex="2" ></asp:TextBox></td>
                            <td style="width: 15%" align="left">
                                <asp:Label ID="Label6" runat="server" Text="Nivel / Recurso" Width="90%"></asp:Label></td>
                            <td style="width: 15%" align="left">
                                <asp:DropDownList ID="ddl_nivel" runat="server" CssClass="drop01" TabIndex="4"/>
                            </td>
                        </tr>
                        <tr valign ="top">
                            <td style="width: 15%" align="left">
                                <asp:Label ID="Label3" runat="server" Text="fecha Final" Width="90%"></asp:Label></td>
                            <td style="width: 15%" align="left">
                                <telerik:RadDatePicker ID="rdpfechaFinal" runat="server" Culture="Spanish (Colombia)"
                                    MinDate="" Skin="Sunset" TabIndex="1" ToolTip="Seleccione Fecha ..." Width="95%">
                                    <Calendar Skin="Sunset" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                        ViewSelectorText="x">
                                        <FastNavigationSettings CancelButtonCaption="Cancelar" DateIsOutOfRangeMessage="Fecha fuera de rango."
                                            TodayButtonCaption="Hoy">
                                        </FastNavigationSettings>
                                    </Calendar>
                                    <DatePopupButton HoverImageUrl="" ImageUrl="" TabIndex="1" ToolTip="Abrir el Calendario" />
                                    <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MMMM/yyyy" EmptyMessage="Fecha ..."
                                        TabIndex="1">
                                    </DateInput>
                                </telerik:RadDatePicker>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:Label ID="Label5" runat="server" Text="Tercero" Width="90%"></asp:Label></td>
                            <td style="width: 15%" align="left">
                                <asp:DropDownList ID="ddl_terceros" runat="server" CssClass="drop01" TabIndex="3"/></td>
                            <td style="width: 15%" align="left">
                            </td>
                            <td style="width: 15%" align="left">
                            </td>
                        </tr>
                    </table>
                    
                </asp:Panel>
            </td>
        </tr>
        <tr valign ="top">
            <td colspan="2">
                <telerik:RadGrid ID="Rg_Listado" runat="server"
                    AllowSorting="True" GridLines="None" Skin="Simple" Width="100%" AutoGenerateColumns="False" ShowStatusBar="True" TabIndex="7" PageSize="20" ShowFooter ="True">
                    <MasterTableView  NoDetailRecordsText="No hay informaci&#243;n." NoMasterRecordsText="No hay informaci&#243;n." DataKeyNames="Id" CommandItemDisplay ="Top" AllowPaging="True">
                        <Columns>
                           <telerik:GridTemplateColumn HeaderText="No." DefaultInsertValue="" UniqueName="TemplateColumn">
                                <ItemTemplate>
                                    <asp:label runat="server" id="lblno" text='<%# ctype(CType(Container.Parent.Parent.Parent,RadGrid).DataSource,IList).IndexOf(Container.DataItem)+1 %>' />
                                    <asp:Label runat="Server" Id="lblid" Visible ="False" Text ='<%#Container.DataItem.Id%>'/>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>                                
                        
                            <telerik:GridBoundColumn DataField="Id" DataType="System.Int32" HeaderText="Id" ReadOnly="True"
                                SortExpression="Id" UniqueName="Id"  Visible ="False">
                            </telerik:GridBoundColumn>
                            
                            <telerik:GridBoundColumn DataField="Fecha" DataType="System.DateTime" HeaderText="Fecha" DataFormatString="{0:dd/MMM/yyyy}"
                                SortExpression="Fecha" UniqueName="Fecha" >
                                <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                    Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                            </telerik:GridBoundColumn>
                               
                            <telerik:GridBoundColumn DataField="Numero" HeaderText="N&#250;mero" SortExpression="Numero"
                                UniqueName="Numero" >
                                <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                    Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                            </telerik:GridBoundColumn> 
                            
                            <telerik:GridBoundColumn DataField="Ppto_Terceros.Razon_Social" HeaderText="Razon Social"
                                SortExpression="Ppto_Terceros.Razon_Social" UniqueName="Ppto_Terceros.Razon_Social" >
                                <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                    Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                            </telerik:GridBoundColumn>       

                            <telerik:GridBoundColumn DataField="Ppto_Terceros.Identificacion" HeaderText="Identificaci&#243;n"
                                SortExpression="Ppto_Terceros.Identificacion" UniqueName="Ppto_Terceros.Identificacion" >
                                <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                    Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                            </telerik:GridBoundColumn>   
                                                                       
                            <telerik:GridBoundColumn DataField="Valor_USD" HeaderText="Valor USD" SortExpression="Valor_USD" DataFormatString="{0:c}"
                                UniqueName="Valor_USD" Aggregate="Sum" FooterAggregateFormatString ="{0:n}">
                                <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                    Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                                <ItemStyle HorizontalAlign="Right" />
                                <FooterStyle HorizontalAlign ="Right" />
                            </telerik:GridBoundColumn>
                            
                            <telerik:GridBoundColumn DataField="TRM" HeaderText="Tasa TRM" SortExpression="TRM" DataFormatString="{0:c}"
                                UniqueName="TRM" >
                                <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                    Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                                <ItemStyle HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>            

                            <telerik:GridBoundColumn DataField="Valor_COP" HeaderText="Valor COP" SortExpression="Valor_COP" DataFormatString="{0:c}"
                                UniqueName="Valor_COP" Aggregate="Sum" FooterAggregateFormatString ="{0:n}" >
                                <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                    Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                                <ItemStyle HorizontalAlign="Right" />
                                <FooterStyle HorizontalAlign ="Right" />
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="Nivel.Descripcion" HeaderText="Nivel Aplicado"
                                SortExpression="Nivel.Descripcion" UniqueName="Nivel.Descripcion" >
                                <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                    Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                                <ItemStyle HorizontalAlign="Right" />    
                            </telerik:GridBoundColumn> 

							<telerik:GridTemplateColumn HeaderText="D.F." UniqueName="AprobarDirFin"  HeaderTooltip ="Direcci&#243;n Financiera" DefaultInsertValue="">
					            <ItemTemplate>
					               <asp:CheckBox runat="server" ID="chk_financiera"  Checked = '<%# Eval("Aprobacion_Financiera")%>' Enabled="False" />
					            </ItemTemplate>
					            <ItemStyle HorizontalAlign ="Center" />
					            <HeaderStyle  HorizontalAlign ="Center"  />
				            </telerik:GridTemplateColumn>  
				            

							<telerik:GridTemplateColumn HeaderText="Aprobar" UniqueName="AprobarDirPai" DefaultInsertValue="" >
					            <ItemTemplate>
					               <asp:CheckBox runat="server" ID="chk_aprobar" />
					            </ItemTemplate>
					            <ItemStyle HorizontalAlign ="Center" />
					            <HeaderStyle  HorizontalAlign ="Center"  />
				            </telerik:GridTemplateColumn>                              

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
                       HideStructureColumns="True" filename ="Contratos" ExportOnlyData="True" IgnorePaging="True" OpenInNewWindow="True">
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
            <telerik:AjaxSetting AjaxControlID="btn_aprobar">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="Rg_Listado" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btn_buscar">
                <UpdatedControls>
                    
                    <telerik:AjaxUpdatedControl ControlID="pnl_buscar" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btn_Procesar">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="Rg_Listado" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btn_limpiar">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rdpFechaInicial" />
                    <telerik:AjaxUpdatedControl ControlID="txt_numero" />
                    <telerik:AjaxUpdatedControl ControlID="ddl_nivel" />
                    <telerik:AjaxUpdatedControl ControlID="rdpfechaFinal" />
                    <telerik:AjaxUpdatedControl ControlID="ddl_terceros" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="LoadingPanel2" runat="server" BackgroundPosition="Right"
        Height="0px" Transparency="50">
        <asp:Image ID="Image1" runat="server" AlternateText="Cargando..." ImageUrl="~/Images/loading.gif" />
    </telerik:RadAjaxLoadingPanel>

</asp:Content>

