<%@ Page Title="" Language="VB" MasterPageFile="~/Controles/MasterPage.master" AutoEventWireup="false" CodeFile="OrdenCompraList.aspx.vb" Inherits="Webforms_OrdenCompraList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <telerik:RadScriptManager ID="RadScriptManager1" runat="server" />

    <script type="text/javascript">
        function ValNumero(fld, e) {
            var strCheck = '012345678 9-';
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

    <asp:Panel runat="server" ID="pnl_pagina" Width="100%" DefaultButton="btn_actualizar">
        <table id="tbl_Interna" border="0" cellpadding="1" cellspacing="0" width="100%" style="border-right: whitesmoke thin solid;
            border-top: whitesmoke thin solid; border-left: whitesmoke thin solid; border-bottom: whitesmoke thin solid">
            <tr valign="top">
                <td style="width: 75%;">
                    <asp:Label ID="lbl_Titulo" runat="server" Text="VISTA GENERAL DE ORDENES DE COMPRA"
                        Width="100%" CssClass="TitTitulo" BackColor="PeachPuff"></asp:Label><br />
                    <asp:Label ID="lblMensaje" runat="server" CssClass="TitMensaje" Text="_" Width="100%"
                        Visible="False"></asp:Label></td>
                <td style="width: 25%" align="right">
                    <asp:ImageButton ID="btn_actualizar" runat="server" ImageUrl="~/Images/Reload.jpg"
                        ToolTip="Actualizar la vista actual." TabIndex="1" /><asp:ImageButton ID="btn_buscar"
                            runat="server" ImageUrl="~/Images/Zoom In.jpg" ToolTip="Ver/quitar Sistema de Búsqueda."
                            TabIndex="2" /><asp:ImageButton ID="btn_nuevo" runat="server" ImageUrl="~/Images/Add.jpg"
                                ToolTip="Crear Nuevo Registro." TabIndex="3" /><asp:ImageButton ID="btn_cerrar" runat="server"
                                    ImageUrl="~/Images/Stop.jpg" ToolTip="Cerrar - Volver a la vista anterior." TabIndex="4" /><asp:ImageButton
                                        ID="btn_home" runat="server" ImageUrl="~/Images/Home.jpg" ToolTip="Ir al Inicio."
                                        TabIndex="5" /></td>
            </tr>
            <tr valign="top">
                <td colspan="2" align="center">
                    <asp:Panel ID="Pnl_Buscar" runat="server" Width="90%" Style="text-align: center;
                        border-right: palegoldenrod thin ridge; border-top: palegoldenrod thin ridge;
                        border-left: palegoldenrod thin ridge; border-bottom: palegoldenrod thin ridge;"
                        Visible="False">
                        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                            <tr valign="top">
                                <td colspan="5" style="text-align: left; width: 85%;" align="left">
                                    <asp:Label ID="Label2" runat="server" Text="Sistema de Búsqueda Selectiva" Width="90%"
                                        Font-Bold="True" Font-Underline="False"></asp:Label></td>
                                <td style="width: 15%" align="right">
                                    <asp:ImageButton ID="btn_Procesar" runat="server" ImageUrl="~/Images/Search.jpg"
                                        ToolTip="Realizar la Búsqueda." TabIndex="6" />
                                    <asp:ImageButton ID="btn_limpiar" runat="server" ImageUrl="~/Images/New.jpg" ToolTip="Limpiar Campos Búsqueda."
                                        TabIndex="7" /></td>
                            </tr>
                            <tr valign="top">
                                <td style="width: 15%;" align="left">
                                    <asp:Label ID="Label5" runat="server" Font-Bold="False" Text="Fecha Inicial" Width="90%"></asp:Label></td>
                                <td style="width: 15%;" align="left">
                                    <telerik:RadDatePicker ID="rdpFechaInicial" runat="server" Culture="Spanish (Colombia)"
                                        MinDate="" Skin="Sunset" ToolTip="Seleccione Fecha ..." Width="95%">
                                        <Calendar Skin="Sunset" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                            ViewSelectorText="x">
                                            <FastNavigationSettings CancelButtonCaption="Cancelar" DateIsOutOfRangeMessage="Fecha Fuera de Rango"
                                                TodayButtonCaption="Hoy">
                                            </FastNavigationSettings>
                                        </Calendar>
                                        <DatePopupButton HoverImageUrl="" ImageUrl="" ToolTip="Abrir el Calendario" />
                                        <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MMMM/yyyy" EmptyMessage="Fecha ...">
                                        </DateInput>
                                    </telerik:RadDatePicker>
                                </td>
                                <td style="width: 15%;" align="left">
                                    <asp:Label ID="Label6" runat="server" Text="Número" Width="90%"></asp:Label></td>
                                <td style="width: 15%;" align="left">
                                    <asp:TextBox ID="txt_numero" runat="server" Width="90%" CssClass="Digitar" MaxLength="12"
                                        onkeypress="return ValNumero(this, event)" TabIndex="2" /></td>
                                <td style="width: 15%" align="left">
                                    <asp:Label ID="Label8" runat="server" Text="Regional" Width="90%"></asp:Label></td>
                                <td style="width: 15%" align="left">
                                    <asp:DropDownList ID="ddl_Regional" runat="server" CssClass="drop01" TabIndex="4" />
                                </td>
                            </tr>
                            <tr valign="top">
                                <td style="width: 15%" align="left">
                                    <asp:Label ID="Label9" runat="server" Text="Fecha Final" Width="90%"></asp:Label></td>
                                <td style="width: 15%" align="left">
                                    <telerik:RadDatePicker ID="rdpfechaFinal" runat="server" Culture="Spanish (Colombia)"
                                        MinDate="" Skin="Sunset" TabIndex="1" ToolTip="Seleccione Fecha ..." Width="95%">
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
                                </td>
                                <td style="width: 15%" align="left">
                                    <asp:Label ID="Label11" runat="server" Text="Tercero" Width="90%"></asp:Label></td>
                                <td style="width: 15%" align="left">
                                    <asp:DropDownList ID="ddl_terceros" runat="server" CssClass="drop01" TabIndex="3" /></td>
                                <td style="width: 15%" align="left">
                                    <asp:Label ID="Label3" runat="server" Text="Producto" Width="90%"></asp:Label>
                                </td>
                                <td style="width: 15%" align="left">
                                    <asp:DropDownList ID="Ddl_Productos" runat="server" CssClass="drop01" TabIndex="5" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr valign="top">
                <td colspan="2">
                    <telerik:RadGrid ID="Rg_Listado" runat="server" AllowSorting="True" GridLines="None"
                        Skin="Simple" Width="100%" AutoGenerateColumns="False" ShowStatusBar="True" TabIndex="6"
                        PageSize="20">
                        <MasterTableView NoDetailRecordsText="No hay informaci&#243;n." NoMasterRecordsText="No hay informaci&#243;n."
                            DataKeyNames="Id" CommandItemDisplay="Top" AllowPaging="True">
                            <Columns>
                                <telerik:GridTemplateColumn HeaderText="No." UniqueName="TemplateColumn5">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblno" Text='<%# ctype(CType(Container.Parent.Parent.Parent,RadGrid).DataSource,IList).IndexOf(Container.DataItem)+1 %>' />
                                        <asp:Label runat="Server" ID="lblid" Visible="False" Text='<%#Container.DataItem.Id%>' />
                                    </ItemTemplate>
                                    <ItemStyle Width="20px" HorizontalAlign="Center" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="Id" DataType="System.Int32" HeaderText="Id" ReadOnly="True"
                                    SortExpression="Id" UniqueName="Id" Display="False">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Fecha" DataType="System.DateTime" HeaderText="Fecha"
                                    DataFormatString="{0:dd/MMM/yyyy}" SortExpression="Fecha" UniqueName="Fecha">
                                    <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                        Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Numero" HeaderText="N&#250;mero" SortExpression="Numero"
                                    UniqueName="Numero">
                                    <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                        Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Terceros.Razon_Social" HeaderText="Razon Social"
                                    SortExpression="Terceros.Razon_Social" UniqueName="Terceros.Razon_Social">
                                    <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                        Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Regional.Descripcion" HeaderText="Regional" Visible="False"
                                    SortExpression="Regional.Descripcion" UniqueName="Regional.Descripcion">
                                    <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                        Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="ValorOrdenCompraUSD" HeaderText="Valor USD" SortExpression="ValorOrdenCompraUSD"
                                    DataFormatString="{0:c}" UniqueName="ValorOrdenCompraUSD" DefaultInsertValue="">
                                    <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                        Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Tasa" HeaderText="Tasa TRM" SortExpression="Tasa"
                                    DataFormatString="{0:c}" UniqueName="Tasa" DefaultInsertValue="">
                                    <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                        Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="ValorOrdenCompra" HeaderText="Valor COP" SortExpression="ValorOrdenCompra"
                                    DataFormatString="{0:c}" UniqueName="ValorOrdenCompra" DefaultInsertValue="">
                                    <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                        Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn HeaderText="LOG" UniqueName="TemplateColumn" HeaderTooltip="Aprobaci&#243;n Logística"
                                    DefaultInsertValue="">
                                    <ItemTemplate>
                                        <asp:CheckBox runat="server" ID="chk_aprblog" Enabled="false" Checked='<%# Eval("Aprobacion_Logistica_OFC")%>' />
                                    </ItemTemplate>
                                    <ItemStyle Width="20px" HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="FIN" UniqueName="TemplateColumn1" HeaderTooltip="Aprobaci&#243;n Financiera"
                                    DefaultInsertValue="">
                                    <ItemTemplate>
                                        <asp:CheckBox runat="server" ID="chk_aprbfin" Enabled="false" Checked='<%# Eval("Aprobacion_Finanzas_OFC")%>' />
                                    </ItemTemplate>
                                    <ItemStyle Width="20px" HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="COL" UniqueName="TemplateColumn4" HeaderTooltip="Aprobaci&#243;n Logística"
                                    DefaultInsertValue="">
                                    <ItemTemplate>
                                        <asp:CheckBox runat="server" ID="chk_aprbcol" Enabled="false" Checked='<%# Eval("Aprobacion_CooLogistica") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Width="20px" HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </telerik:GridTemplateColumn>                                
                                
                                <telerik:GridTemplateColumn HeaderText="COO" UniqueName="TemplateColumn2" HeaderTooltip="Aprobaci&#243;n Coordinaci&#243;n"
                                    DefaultInsertValue="">
                                    <ItemTemplate>
                                        <asp:CheckBox runat="server" ID="chk_aprbcoo" Enabled="false" Checked='<%# Eval("Aprobacion_Coordinacion")%>' />
                                    </ItemTemplate>
                                    <ItemStyle Width="20px" HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="OPE" UniqueName="TemplateColumn3" HeaderTooltip="Aprobaci&#243;n Operaciones"
                                    DefaultInsertValue="">
                                    <ItemTemplate>
                                        <asp:CheckBox runat="server" ID="chk_aprbope" Enabled="false" Checked='<%# Eval("Aprobacion_Operaciones")%>' />
                                    </ItemTemplate>
                                    <ItemStyle Width="20px" HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="DAF" UniqueName="TemplateColumn3" HeaderTooltip="Aprobaci&#243;n Financiera"
                                    DefaultInsertValue="">
                                    <ItemTemplate>
                                        <asp:CheckBox runat="server" ID="chk_aprbdaf" Enabled="false" Checked='<%# Eval("Aprobacion_Financiera")%>' />
                                    </ItemTemplate>
                                    <ItemStyle Width="20px" HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </telerik:GridTemplateColumn>

                                <telerik:GridBoundColumn DataField="Tipo_Orden.Descripcion" HeaderText="Tipo Orden"
                                    Visible="False" SortExpression="Tipo_Orden.Descripcion" UniqueName="Tipo_Orden.Descripcion">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Codigo_Proyecto" HeaderText="Cod. Proyecto" Visible="False"
                                    SortExpression="Codigo_Proyecto" UniqueName="Codigo_Proyecto">
                                </telerik:GridBoundColumn>
                            </Columns>
                            <CommandItemSettings ExportToCsvText="Exportar a CSV" ExportToExcelText="Exportar a Excel"
                                ExportToPdfText="Exportar a PDF" ExportToWordText="Exportar a Word" RefreshText="Actualizar"
                                AddNewRecordText="" AddNewRecordImageUrl="~/Images/nothing.gif" ShowExportToCsvButton="True"
                                ShowExportToExcelButton="True" ShowExportToPdfButton="True" ShowExportToWordButton="True" />
                            <PagerStyle Mode="NumericPages" FirstPageToolTip="Primera" LastPageToolTip="Ultima"
                                NextPagesToolTip="Pr&#243;ximas" NextPageToolTip="Pr&#243;xima" PagerTextFormat="Cambiar P&#225;gina: {4} &amp;nbsp;P&#225;gina &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;, registros &lt;strong&gt;{2}&lt;/strong&gt; a &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;."
                                PrevPageToolTip="Anterior" PrevPagesToolTip="Anteriores" />
                        </MasterTableView>
                        <ClientSettings EnablePostBackOnRowClick="True" EnableRowHoverStyle="True">
                            <Selecting AllowRowSelect="True" />
                        </ClientSettings>
                        <ExportSettings HideStructureColumns="True" FileName="OrdenCompra" ExportOnlyData="True"
                            IgnorePaging="True" OpenInNewWindow="True">
                        </ExportSettings>
                        <SortingSettings SortToolTip="Clic aqui para ordenar..." SortedAscToolTip="Ordenar Ascendente"
                            SortedDescToolTip="Ordenar Descendente" />
                        <PagerStyle Mode="NumericPages" />
                    </telerik:RadGrid>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="LoadingPanel2">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btn_actualizar">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="Rg_Listado" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btn_buscar">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="Pnl_Buscar" />
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
                    <telerik:AjaxUpdatedControl ControlID="ddl_Regional" />
                    <telerik:AjaxUpdatedControl ControlID="rdpfechaFinal" />
                    <telerik:AjaxUpdatedControl ControlID="ddl_terceros" />
                    <telerik:AjaxUpdatedControl ControlID="Ddl_Productos" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="LoadingPanel2" runat="server" BackgroundPosition="Right"
        Height="0px" Transparency="50">
        <asp:Image ID="Image1" runat="server" AlternateText="Cargando..." ImageUrl="~/Images/loading.gif" />
    </telerik:RadAjaxLoadingPanel>

</asp:Content>

