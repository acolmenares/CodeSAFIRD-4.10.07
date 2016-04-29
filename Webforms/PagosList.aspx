<%@ Page Title="" Language="VB" MasterPageFile="~/Controles/MasterPage.master" AutoEventWireup="false" CodeFile="PagosList.aspx.vb" Inherits="Webforms_PagosList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <table id="tbl_Interna" border="1" cellpadding="1" cellspacing="0" style="border-right: whitesmoke thin solid;
        border-top: whitesmoke thin solid; border-left: whitesmoke thin solid; width: 100%;
        border-bottom: whitesmoke thin solid; background-color: menu;">
        <tr valign ="top">
            <td style="width: 75%">
                <asp:Label ID="lbl_Titulo" runat="server" BackColor="PeachPuff" CssClass="TitTitulo"
                    Text="VISTA GENERAL DE PAGOS REALIZADOS" Width="100%"></asp:Label><br />
                <asp:Label ID="lblMensaje" runat="server" CssClass="TitMensaje" Text="_" Visible="False"
                    Width="100%"></asp:Label></td>
            <td align="right" style="width: 25%">
                <asp:ImageButton ID="btn_actualizar" runat="server" ImageUrl="~/Images/Reload.jpg"
                    ToolTip="Actualizar la vista actual." />
                <asp:ImageButton ID="btn_buscar" runat="server" ImageUrl="~/Images/Zoom In.jpg"
                    ToolTip="Ver/quitar Sistema de Búsqueda." />
                <asp:ImageButton ID="btn_cerrar" runat="server" ImageUrl="~/Images/Stop.jpg" ToolTip="Cerrar - Volver a la vista anterior." />
                <asp:ImageButton ID="btn_home" runat="server" ImageUrl="~/Images/Home.jpg" ToolTip="Ir al Inicio." />&nbsp;</td>
        </tr>
        <tr valign ="top">
            <td align="center" colspan="2">
                <asp:Panel ID="pnl_buscar" runat="server" Style="border-right: palegoldenrod thin ridge;
                    border-top: palegoldenrod thin ridge; border-left: palegoldenrod thin ridge;
                    border-bottom: palegoldenrod thin ridge; text-align: center" Width="90%" Visible="False">
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                        <tr valign ="top">
                            <td align="left" colspan="5" style="text-align: left">
                                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Underline="False" Text="Sistema de Búsqueda Selectiva"
                                    Width="90%"></asp:Label></td>
                            <td align="right" style="width: 15%">
                                <asp:ImageButton ID="btn_Procesar" runat="server" ImageUrl="~/Images/Search.jpg"
                                    ToolTip="Realizar la Búsqueda." />
                                <asp:ImageButton ID="btn_limpiar" runat="server" ImageUrl="~/Images/New.jpg" ToolTip="Limpiar Campos Búsqueda." /></td>
                        </tr>
                        <tr valign ="top">
                            <td align="left" style="width: 15%">
                                <asp:Label ID="Label_FechaInicial" runat="server" Font-Bold="False" Text="Fecha Inicial" Width="90%"></asp:Label></td>
                            <td align="left" style="width: 15%">
                                &nbsp;</td>
                            <td align="left" style="width: 15%">
                                <asp:Label ID="Label_FechaFinal" runat="server" Text="Número" Width="90%"></asp:Label></td>
                            <td align="left" style="width: 15%">
                                </td>
                            <td align="left" style="width: 15%">
                                </td>
                            <td align="left" style="width: 15%">
                                &nbsp;</td>
                        </tr>
                        <tr valign ="top">
                            <td align="left" style="width: 15%">
                                <asp:Label ID="Label10" runat="server" Text="fecha Final" Width="90%"></asp:Label></td>
                            <td align="left" style="width: 15%">
                                &nbsp;</td>
                            <td align="left" style="width: 15%">
                                <asp:Label ID="Label11" runat="server" Text="Tercero" Width="90%"></asp:Label></td>
                            <td align="left" style="width: 15%">
                                </td>
                            <td align="left" style="width: 15%">
                                </td>
                            <td align="left" style="width: 15%"></td>
                        </tr>
                    </table>
                </asp:Panel>
                </td>
        </tr>
        <tr valign ="top">
            <td rowspan="7" style="width: 60%" valign="top" colspan="2">
                <telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="RadMultiPage1"
                    SelectedIndex="0" Skin="Windows7">
                    <Tabs>
                        <telerik:RadTab runat="server" PageViewID="RadPageView1" Selected="True" Text="Pendientes por Procesar">
                        </telerik:RadTab>
                        <telerik:RadTab runat="server" PageViewID="RadPageView2" Text="Pagos Procesados">
                        </telerik:RadTab>
                        <telerik:RadTab runat="server" Text="Historia">
                        </telerik:RadTab>
                        <telerik:RadTab runat="server" Text="Cargue de Informaci&#243;n">
                        </telerik:RadTab>
                    </Tabs>
                </telerik:RadTabStrip>
                <telerik:RadMultiPage ID="RadMultiPage1" runat="server" Width="100%" SelectedIndex="0">
                    <telerik:RadPageView ID="RadPageView1" runat="server" Selected="True">
                        <telerik:RadGrid ID="Rg_Pendientes" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                            GridLines="None" PageSize="20" ShowStatusBar="True" Skin="Sitefinity" TabIndex="8"
                            Width="100%" AllowPaging="True">
                            <ExportSettings ExportOnlyData="True" FileName="Terceros" HideStructureColumns="True"
                                IgnorePaging="True" OpenInNewWindow="True">
                            </ExportSettings>
                            <PagerStyle Mode="NumericPages" />
                            <MasterTableView CommandItemDisplay="Top" DataKeyNames="Id" NoDetailRecordsText="No hay informaci&#243;n."
                                NoMasterRecordsText="No hay informaci&#243;n.">
                                <CommandItemSettings AddNewRecordImageUrl="~/Images/nothing.gif" AddNewRecordText=""
                                    ExportToCsvText="Exportar a CSV" ExportToExcelText="Exportar a Excel" ExportToPdfText="Exportar a PDF"
                                    ExportToWordText="Exportar a Word" RefreshText="Actualizar" ShowExportToCsvButton="True"
                                    ShowExportToExcelButton="True" ShowExportToPdfButton="True" ShowExportToWordButton="True" />
                                <Columns>
                                    <telerik:GridBoundColumn DataField="Id" DataType="System.Int32" HeaderText="Id" ReadOnly="True"
                                        SortExpression="Id" UniqueName="Id" Visible="False" DefaultInsertValue="">
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
                                    
                                    <telerik:GridBoundColumn DataField="Ano" HeaderText="A&#241;o"
                                        SortExpression="Ano" UniqueName="Ano" DefaultInsertValue="" >
                                        <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                            Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                                    </telerik:GridBoundColumn>  
                                    
                                   <telerik:GridBoundColumn DataField="Tipo" HeaderText="Tipo" SortExpression="Tipo"
                                        UniqueName="Tipo" DefaultInsertValue="" >
                                        <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                            Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                                        <ItemStyle HorizontalAlign ="Center" />    
                                    </telerik:GridBoundColumn> 
                                       
                                    <telerik:GridBoundColumn DataField="Nombre_Tercero" HeaderText="Nombre de Tercero" 
                                        SortExpression="Nombre_Tercero" UniqueName="Nombre_Tercero" DefaultInsertValue="" >
                                        <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                            Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                                        <ItemStyle HorizontalAlign ="Left"  />    
                                    </telerik:GridBoundColumn>       

                                    <telerik:GridBoundColumn DataField="Debito" HeaderText="Debito" DataFormatString="{0:c}"
                                        SortExpression="Debito" UniqueName="Debito" DefaultInsertValue="" >
                                        <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                            Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                                        <ItemStyle HorizontalAlign ="Center" />    
                                    </telerik:GridBoundColumn>   
                                    <telerik:GridBoundColumn DataField="Credito" HeaderText="Cr&#233;dito" DataFormatString="{0:c}"
                                        SortExpression="Credito" UniqueName="Credito">
                                    </telerik:GridBoundColumn>
                                    
                                    <telerik:GridBoundColumn DataField="Descripcion" HeaderText="Descripción"
                                        SortExpression="Descripcion" UniqueName="Descripcion" HeaderTooltip="Descripcion" DefaultInsertValue="" >
                                        <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                            Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                                        <ItemStyle HorizontalAlign ="Center" Width ="300px" />    
                                    </telerik:GridBoundColumn> 
                                    
							        <telerik:GridTemplateColumn HeaderText="Aprobar" UniqueName="TemplateColumn6" >
					                    <ItemTemplate>
					                       <asp:CheckBox runat="server" ID="chk_aprobar" />
					                       <asp:Label ID="lblid" runat ="server" Text ='<%#Container.DataItem.Id%>' Visible ="False" />
					                    </ItemTemplate>
					                    <ItemStyle HorizontalAlign ="Center" />
					                    <HeaderStyle  HorizontalAlign ="Center"  />
					                    
				                    </telerik:GridTemplateColumn>  
                                </Columns>
                                <PagerStyle FirstPageToolTip="Primera" LastPageToolTip="Ultima" Mode="NumericPages"
                                    NextPagesToolTip="Pr&#243;ximas" NextPageToolTip="Pr&#243;xima" PagerTextFormat="Cambiar P&#225;gina: {4} &amp;nbsp;P&#225;gina &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;, registros &lt;strong&gt;{2}&lt;/strong&gt; a &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;."
                                    PrevPagesToolTip="Anteriores" PrevPageToolTip="Anterior" />
                            </MasterTableView>
                            <ClientSettings EnablePostBackOnRowClick="False" EnableRowHoverStyle="True">
                                <Selecting AllowRowSelect="True" />
                            </ClientSettings>
                            <SortingSettings SortedAscToolTip="Ordenar Ascendente" SortedDescToolTip="Ordenar Descendente"
                                SortToolTip="Clic aqui para ordenar..." />
                        </telerik:RadGrid>
                        <table border="1" cellpadding="0" cellspacing="0" style="width: 100%">
                            <tr>
                                <td align="center" rowspan="2" style="text-align: center" valign="middle">
                                    <asp:RadioButtonList ID="rdb_opcion" runat="server" AutoPostBack="True">
                                        <asp:ListItem Selected="True" Value="O">Orden de Compra</asp:ListItem>
                                        <asp:ListItem Value="C">Contratos</asp:ListItem>
                                    </asp:RadioButtonList></td>
                                <td>
                                <asp:Label ID="lbl_Contrato" runat="server" Text="Seleccion el contrato a Aplicar" Width="40%"></asp:Label>
                                    <asp:DropDownList ID="ddl_Contratos_Pendientes" runat="server" CssClass="drop01" Width="50%">
                                    </asp:DropDownList></td>
                                <td style="width: 12px">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                <asp:Label ID="Lbl_OrdenCompra" runat="server" Text="Seleccione la Orden De Compra a Aplicar" Width="40%"></asp:Label>
                                    <asp:DropDownList ID="ddl_OrdenesCompra_Pendientes" runat="server" CssClass="drop01" Width="50%">
                                    </asp:DropDownList></td>
                                <td style="width: 12px">
                                    <asp:Button ID="btn_AplicarPago" runat="server" CssClass="Boton" Text="Aplicar el Pago" /></td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="RadPageView2" runat="server">
                    <telerik:RadGrid ID="Rg_Procesados" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                        GridLines="None" PageSize="20" ShowStatusBar="True" Skin="Sitefinity" TabIndex="8"
                        Width="100%" AllowPaging="True">
                        <ExportSettings ExportOnlyData="True" FileName="Procesados" HideStructureColumns="True"
                        IgnorePaging="True" OpenInNewWindow="True">
                        </ExportSettings>
                        <PagerStyle Mode="NumericPages" />
                        <MasterTableView CommandItemDisplay="Top" DataKeyNames="Id" NoDetailRecordsText="No hay informaci&#243;n."
                        NoMasterRecordsText="No hay informaci&#243;n.">
                            <CommandItemSettings AddNewRecordImageUrl="~/Images/nothing.gif" AddNewRecordText=""
                            ExportToCsvText="Exportar a CSV" ExportToExcelText="Exportar a Excel" ExportToPdfText="Exportar a PDF"
                            ExportToWordText="Exportar a Word" RefreshText="Actualizar" ShowExportToCsvButton="True"
                            ShowExportToExcelButton="True" ShowExportToPdfButton="True" ShowExportToWordButton="True" />
                            <Columns>
                                 <telerik:GridBoundColumn DataField="Id" DataType="System.Int32" HeaderText="Id" ReadOnly="True"
                                    SortExpression="Id" UniqueName="Id" Visible="False" DefaultInsertValue="">
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
                                
                                <telerik:GridBoundColumn DataField="Ano" HeaderText="A&#241;o"
                                    SortExpression="Ano" UniqueName="Ano" DefaultInsertValue="" >
                                    <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                        Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                                </telerik:GridBoundColumn>  
                                
                               <telerik:GridBoundColumn DataField="Tipo" HeaderText="Tipo" SortExpression="Tipo"
                                    UniqueName="Tipo" DefaultInsertValue="" >
                                    <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                        Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                                    <ItemStyle HorizontalAlign ="Center" />    
                                </telerik:GridBoundColumn> 
                                   
                                <telerik:GridBoundColumn DataField="Nombre_Tercero" HeaderText="Nombre de Tercero" 
                                    SortExpression="Nombre_Tercero" UniqueName="Nombre_Tercero" DefaultInsertValue="" >
                                    <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                        Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                                    <ItemStyle HorizontalAlign ="Left"  />    
                                </telerik:GridBoundColumn>       

                                <telerik:GridBoundColumn DataField="Debito" HeaderText="Debito" DataFormatString="{0:c}"
                                    SortExpression="Debito" UniqueName="Debito" DefaultInsertValue="" >
                                    <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                        Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                                    <ItemStyle HorizontalAlign ="Center" />    
                                </telerik:GridBoundColumn>   
                                <telerik:GridBoundColumn DataField="Credito" HeaderText="Cr&#233;dito" DataFormatString="{0:c}"
                                    SortExpression="Credito" UniqueName="Credito">
                                </telerik:GridBoundColumn>
                                
                                <telerik:GridBoundColumn DataField="Descripcion" HeaderText="Descripción"
                                    SortExpression="Descripcion" UniqueName="Descripcion" HeaderTooltip="Descripcion" DefaultInsertValue="" >
                                    <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                        Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                                    <ItemStyle HorizontalAlign ="Center" Width ="300px" />    
                                </telerik:GridBoundColumn> 
                                
							    <telerik:GridTemplateColumn HeaderText="Eliminar" UniqueName="TemplateColumn6" >
					                <ItemTemplate>
					                   <asp:CheckBox runat="server" ID="chk_aprobar" />
					                   <asp:Label ID="lblid" runat ="server" Text ='<%#Container.DataItem.Id%>' Visible ="False" />
					                </ItemTemplate>
					                <ItemStyle HorizontalAlign ="Center" />
					                <HeaderStyle  HorizontalAlign ="Center"  />
				                </telerik:GridTemplateColumn>                                  
                                
                            </Columns>
                            <PagerStyle FirstPageToolTip="Primera" LastPageToolTip="Ultima" Mode="NumericPages"
                            NextPagesToolTip="Pr&#243;ximas" NextPageToolTip="Pr&#243;xima" PagerTextFormat="Cambiar P&#225;gina: {4} &amp;nbsp;P&#225;gina &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;, registros &lt;strong&gt;{2}&lt;/strong&gt; a &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;."
                            PrevPagesToolTip="Anteriores" PrevPageToolTip="Anterior" />
                        </MasterTableView>
                        <ClientSettings EnablePostBackOnRowClick="True" EnableRowHoverStyle="True">
                            <Selecting AllowRowSelect="True" />
                        </ClientSettings>
                        <SortingSettings SortedAscToolTip="Ordenar Ascendente" SortedDescToolTip="Ordenar Descendente"
                        SortToolTip="Clic aqui para ordenar..." />
                    </telerik:RadGrid>
                        <table border="1" cellpadding="0" cellspacing="0" style="width: 100%">
                            <tr>
                                <td align="center" rowspan="1" style="text-align: center" valign="middle">
                                </td>
                                <td style="width: 691px" align="right">
                                    <asp:Label ID="Label12" runat="server" Text="Esta Seguro de eliminar los registros seleccionados?"
                                        Width="40%"></asp:Label>
                                </td>
                                <td style="width: 12px">
                                    <asp:Button ID="btn_eliminar" runat="server" CssClass="Boton" Text="Eliminar Procesos" /></td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="RadPageView3" runat="server">
                        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                            <tr>
                                <td style="width: 30%">
                                    <asp:Label ID="Label13" runat="server" Text="Seleccione la Orden de Compra a Buscar? "></asp:Label>
                                </td>
                                <td style="width: 60%">
                                    <asp:DropDownList ID="ddl_Ordenes" runat="server" CssClass="drop01">
                                    </asp:DropDownList></td>
                                <td align="center" style="width: 5%">
                                    <asp:ImageButton ID="imb_ordencompra" runat="server" ImageUrl="~/Images/Accept.jpg" /></td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <telerik:RadGrid ID="Rg_Ordenes_Resumen" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                        GridLines="None" PageSize="20" ShowStatusBar="True" Skin="Sitefinity" TabIndex="8" Width="100%">
                                        <ExportSettings ExportOnlyData="True" FileName="Terceros" HideStructureColumns="True"
                        IgnorePaging="True" OpenInNewWindow="True">
                                        </ExportSettings>
                                        <PagerStyle Mode="NumericPages" />
                                        <MasterTableView CommandItemDisplay="Top" DataKeyNames="Id" NoDetailRecordsText="No hay informaci&#243;n."
                        NoMasterRecordsText="No hay informaci&#243;n." AllowPaging="True">
                                            <CommandItemSettings AddNewRecordImageUrl="~/Images/nothing.gif" AddNewRecordText=""
                            ExportToCsvText="Exportar a CSV" ExportToExcelText="Exportar a Excel" ExportToPdfText="Exportar a PDF"
                            ExportToWordText="Exportar a Word" RefreshText="Actualizar" ShowExportToCsvButton="True"
                            ShowExportToExcelButton="True" ShowExportToPdfButton="True" ShowExportToWordButton="True" />
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="Id" DataType="System.Int32" HeaderText="Id" ReadOnly="True"
                                    SortExpression="Id" UniqueName="Id" Visible="False">
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
                                                <telerik:GridBoundColumn DataField="Ano" HeaderText="A&#241;o"
                                    SortExpression="Ano" UniqueName="Ano" >
                                                    <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                        Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Tipo" HeaderText="Tipo" SortExpression="Tipo"
                                    UniqueName="Tipo" >
                                                    <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                        Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                                                    <ItemStyle HorizontalAlign ="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Nombre_Tercero" HeaderText="Nombre de Tercero" 
                                                    SortExpression="Nombre_Tercero" UniqueName="Nombre_Tercero" DefaultInsertValue="" >
                                                    <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                        Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                                                    <ItemStyle HorizontalAlign ="Left"  />    
                                                </telerik:GridBoundColumn>       

                                                <telerik:GridBoundColumn DataField="Debito" HeaderText="Debito" DataFormatString="{0:c}"
                                                    SortExpression="Debito" UniqueName="Debito" DefaultInsertValue="" >
                                                    <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                        Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                                                    <ItemStyle HorizontalAlign ="Center" />    
                                                </telerik:GridBoundColumn>   
                                                <telerik:GridBoundColumn DataField="Credito" HeaderText="Cr&#233;dito" DataFormatString="{0:c}"
                                                    SortExpression="Credito" UniqueName="Credito">
                                                </telerik:GridBoundColumn>
                                                
                                                <telerik:GridBoundColumn DataField="Descripcion" HeaderText="Descripción"
                                                    SortExpression="Descripcion" UniqueName="Descripcion" HeaderTooltip="Descripcion" DefaultInsertValue="" >
                                                    <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                        Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                                                    <ItemStyle HorizontalAlign ="Center" Width ="300px" />    
                                                </telerik:GridBoundColumn> 
 
							                    <telerik:GridTemplateColumn HeaderText="Eliminar" UniqueName="TemplateColumn6" >
					                                <ItemTemplate>
					                                   <asp:CheckBox runat="server" ID="chk_aprobar" />
					                                   <asp:Label ID="lblid" runat ="server" Text ='<%#Container.DataItem.Id%>' Visible ="False" />
					                                </ItemTemplate>
					                                <ItemStyle HorizontalAlign ="Center" />
					                                <HeaderStyle  HorizontalAlign ="Center"  />
				                                </telerik:GridTemplateColumn>                                                  
                                                
                                            </Columns>
                                            <PagerStyle FirstPageToolTip="Primera" LastPageToolTip="Ultima" Mode="NumericPages"
                            NextPagesToolTip="Pr&#243;ximas" NextPageToolTip="Pr&#243;xima" PagerTextFormat="Cambiar P&#225;gina: {4} &amp;nbsp;P&#225;gina &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;, registros &lt;strong&gt;{2}&lt;/strong&gt; a &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;."
                            PrevPagesToolTip="Anteriores" PrevPageToolTip="Anterior" />
                                        </MasterTableView>
                                        <ClientSettings EnablePostBackOnRowClick="True" EnableRowHoverStyle="True">
                                            <Selecting AllowRowSelect="True" />
                                        </ClientSettings>
                                        <SortingSettings SortedAscToolTip="Ordenar Ascendente" SortedDescToolTip="Ordenar Descendente"
                        SortToolTip="Clic aqui para ordenar..." />
                                    </telerik:RadGrid>
                                    <table border="1" cellpadding="0" cellspacing="0" style="width: 100%">
                                        <tr>
                                            <td align="center" rowspan="1" style="text-align: center" valign="middle">
                                            </td>
                                            <td style="width: 691px" align="right">
                                                <asp:Label ID="Label4" runat="server" Text="Esta Seguro de eliminar los registros seleccionados?"
                                                    Width="40%"></asp:Label>
                                            </td>
                                            <td style="width: 12px">
                                                <asp:Button ID="btn_eliminar_Ordens" runat="server" CssClass="Boton" Text="Eliminar Procesos" /></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 14px">
                                    <asp:Label ID="Label14" runat="server" Text="Seleccione el Contrato a Buscar? "></asp:Label></td>
                                <td style="height: 14px">
                                    <asp:DropDownList ID="ddl_contratos" runat="server" CssClass="drop01">
                                    </asp:DropDownList></td>
                                <td align="center" style="height: 14px">
                                    <asp:ImageButton ID="imb_contratos" runat="server" ImageUrl="~/Images/Accept.jpg" /></td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <telerik:RadGrid ID="Rg_Contratos_Resumen" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                    GridLines="None" PageSize="20" ShowStatusBar="True" Skin="Sitefinity" TabIndex="8"
                    Width="100%">
                                        <ExportSettings ExportOnlyData="True" FileName="Terceros" HideStructureColumns="True"
                        IgnorePaging="True" OpenInNewWindow="True">
                                        </ExportSettings>
                                        <PagerStyle Mode="NumericPages" />
                                        <MasterTableView CommandItemDisplay="Top" DataKeyNames="Id" NoDetailRecordsText="No hay informaci&#243;n."
                        NoMasterRecordsText="No hay informaci&#243;n." AllowPaging="True">
                                            <CommandItemSettings AddNewRecordImageUrl="~/Images/nothing.gif" AddNewRecordText=""
                            ExportToCsvText="Exportar a CSV" ExportToExcelText="Exportar a Excel" ExportToPdfText="Exportar a PDF"
                            ExportToWordText="Exportar a Word" RefreshText="Actualizar" ShowExportToCsvButton="True"
                            ShowExportToExcelButton="True" ShowExportToPdfButton="True" ShowExportToWordButton="True" />
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="Id" DataType="System.Int32" HeaderText="Id" ReadOnly="True"
                                    SortExpression="Id" UniqueName="Id" Visible="False" DefaultInsertValue="">
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
                                                <telerik:GridBoundColumn DataField="Ano" HeaderText="A&#241;o"
                                    SortExpression="Ano" UniqueName="Ano" DefaultInsertValue="" >
                                                    <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                        Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Tipo" HeaderText="Tipo" SortExpression="Tipo"
                                    UniqueName="Tipo" DefaultInsertValue="" >
                                                    <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                        Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                                                    <ItemStyle HorizontalAlign ="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Nombre_Tercero" HeaderText="Nombre de Tercero" 
                                                    SortExpression="Nombre_Tercero" UniqueName="Nombre_Tercero" DefaultInsertValue="" >
                                                    <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                        Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                                                    <ItemStyle HorizontalAlign ="Left"  />    
                                                </telerik:GridBoundColumn>       

                                                <telerik:GridBoundColumn DataField="Debito" HeaderText="Debito" DataFormatString="{0:c}"
                                                    SortExpression="Debito" UniqueName="Debito" DefaultInsertValue="" >
                                                    <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                        Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                                                    <ItemStyle HorizontalAlign ="Center" />    
                                                </telerik:GridBoundColumn>   
                                                <telerik:GridBoundColumn DataField="Credito" HeaderText="Cr&#233;dito" DataFormatString="{0:c}"
                                                    SortExpression="Credito" UniqueName="Credito">
                                                </telerik:GridBoundColumn>
                                                
                                                <telerik:GridBoundColumn DataField="Descripcion" HeaderText="Descripción"
                                                    SortExpression="Descripcion" UniqueName="Descripcion" HeaderTooltip="Descripcion" DefaultInsertValue="" >
                                                    <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                        Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                                                    <ItemStyle HorizontalAlign ="Center" Width ="300px" />    
                                                </telerik:GridBoundColumn> 
                                                
							                    <telerik:GridTemplateColumn HeaderText="Eliminar" UniqueName="TemplateColumn6" DefaultInsertValue="" >
					                                <ItemTemplate>
					                                   <asp:CheckBox runat="server" ID="chk_aprobar" />
					                                   <asp:Label ID="lblid" runat ="server" Text ='<%#Container.DataItem.Id%>' Visible ="False" />
					                                </ItemTemplate>
					                                <ItemStyle HorizontalAlign ="Center" />
					                                <HeaderStyle  HorizontalAlign ="Center"  />
				                                </telerik:GridTemplateColumn>                                                  
                                                
                                            </Columns>
                                            <PagerStyle FirstPageToolTip="Primera" LastPageToolTip="Ultima" Mode="NumericPages"
                                                NextPagesToolTip="Pr&#243;ximas" NextPageToolTip="Pr&#243;xima" PagerTextFormat="Cambiar P&#225;gina: {4} &amp;nbsp;P&#225;gina &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;, registros &lt;strong&gt;{2}&lt;/strong&gt; a &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;."
                                                PrevPagesToolTip="Anteriores" PrevPageToolTip="Anterior" />
                                        </MasterTableView>
                                        <ClientSettings EnablePostBackOnRowClick="True" EnableRowHoverStyle="True">
                                            <Selecting AllowRowSelect="True" />
                                        </ClientSettings>
                                        <SortingSettings SortedAscToolTip="Ordenar Ascendente" SortedDescToolTip="Ordenar Descendente" SortToolTip="Clic aqui para ordenar..." />
                                    </telerik:RadGrid>
                                    <table border="1" cellpadding="0" cellspacing="0" style="width: 100%">
                                        <tr>
                                            <td align="center" rowspan="1" style="text-align: center" valign="middle">
                                            </td>
                                            <td style="width: 691px" align="right">
                                                <asp:Label ID="Label15" runat="server" Text="Esta Seguro de eliminar los registros seleccionados?"
                                                    Width="40%"></asp:Label>
                                            </td>
                                            <td style="width: 12px">
                                                <asp:Button ID="btn_eliminar_contratos" runat="server" CssClass="Boton" Text="Eliminar Procesos" /></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="RadPageView4" runat="server">
                        <table border="1" cellpadding="0" cellspacing="0" style="width: 100%">
                            <tr>
                                <td align="center" rowspan="1" style="text-align: center; width: 20%;" valign="middle">
                                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Underline="False" Text="CARGUE DE PAGOS DE NOVASOFT"
                                        Width="90%"></asp:Label></td>
                                <td style="width: 60%" align="right">
                                    <telerik:RadUpload ID="RUCarguePagos" runat="server" Width="100%" ControlObjectsVisibility="None" MaxFileInputsCount="1" ToolTip="Elegir archivo Plano para cargar" Culture="Spanish (Colombia)" AllowedFileExtensions=".txt" InputSize="40" Skin="Sunset" TargetFolder="../Upload" OverwriteExistingFiles="True" CssClass="Digitar" >
                                        <Localization Select="Seleccionar" />
                                    </telerik:RadUpload>
                                    <asp:Label ID="lblresultado" runat="server" ForeColor="Green" Width="100%"></asp:Label>
                                </td>
                                <td style="width: 20%" align="center">
                                    <asp:ImageButton ID="ImgCargueTerceros" runat="server" ImageAlign="Middle" ImageUrl="~/Images/UpDownArrows.jpg" Width="32px" ToolTip="Actualizar Terceros" TabIndex="-1" /></td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>

    </table>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="LoadingPanel2">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btn_actualizar">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="Rg_Pendientes" />
                    <telerik:AjaxUpdatedControl ControlID="Rg_Procesados" />
                    <telerik:AjaxUpdatedControl ControlID="Rg_Ordenes_Resumen" />
                    <telerik:AjaxUpdatedControl ControlID="Rg_Contratos_Resumen" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="Rg_Pendientes">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="Rg_Pendientes" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rdb_opcion">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="lbl_Contrato" />
                    <telerik:AjaxUpdatedControl ControlID="ddl_Contratos_Pendientes" />
                    <telerik:AjaxUpdatedControl ControlID="Lbl_OrdenCompra" />
                    <telerik:AjaxUpdatedControl ControlID="ddl_OrdenesCompra_Pendientes" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btn_AplicarPago">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="Rg_Pendientes" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="Rg_Procesados">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="Rg_Procesados" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="imb_ordencompra">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="Rg_Ordenes_Resumen" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btn_eliminar_Ordens">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ddl_Ordenes" />
                    <telerik:AjaxUpdatedControl ControlID="Rg_Ordenes_Resumen" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="imb_contratos">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="Rg_Contratos_Resumen" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btn_eliminar_contratos">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ddl_contratos" />
                    <telerik:AjaxUpdatedControl ControlID="Rg_Contratos_Resumen" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="LoadingPanel2" runat="server" BackgroundPosition="Right"
        Height="0px" Transparency="50">
        <asp:Image ID="Image1" runat="server" AlternateText="Cargando..." ImageUrl="~/Images/loading.gif" />
    </telerik:RadAjaxLoadingPanel>

</asp:Content>

