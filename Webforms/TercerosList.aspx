<%@ Page Title="" Language="VB" MasterPageFile="~/Controles/MasterPage.master" AutoEventWireup="false" CodeFile="TercerosList.aspx.vb" Inherits="Webforms_TercerosList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <telerik:RadScriptManager ID="RadScriptManager1" runat="server"/>
    <asp:Panel runat="server" ID="pnl_principal" DefaultButton ="btn_actualizar" Width ="100%">
    <table id="tbl_Interna" border="1" cellpadding="1" cellspacing="0" style="border-right: whitesmoke thin solid;
        border-top: whitesmoke thin solid; border-left: whitesmoke thin solid; width: 100%;
        border-bottom: whitesmoke thin solid; background-color: menu;">
        <tr valign ="top">
            <td style="width: 75%">
                <asp:Label ID="lbl_Titulo" runat="server" BackColor="PeachPuff" CssClass="TitTitulo"
                    Text="VISTA GENERAL DE TERCEROS" Width="100%"></asp:Label><br />
                <asp:Label ID="lblMensaje" runat="server" CssClass="TitMensaje" Text="_" Visible="False"
                    Width="100%"></asp:Label></td>
            <td align="right" style="width: 25%">
                <asp:ImageButton ID="btn_actualizar" runat="server" ImageUrl="~/Images/Reload.jpg"
                    ToolTip="Actualizar la vista actual." TabIndex="1" />
                <asp:ImageButton ID="btn_buscar" runat="server" ImageUrl="~/Images/Zoom In.jpg"
                    ToolTip="Ver/quitar Sistema de Búsqueda." TabIndex="2" />
                <asp:ImageButton ID="btn_cerrar" runat="server" ImageUrl="~/Images/Stop.jpg" ToolTip="Cerrar - Volver a la vista anterior." TabIndex="3" />
                <asp:ImageButton ID="btn_home" runat="server" ImageUrl="~/Images/Home.jpg" ToolTip="Ir al Inicio." TabIndex="4" />&nbsp;</td>
        </tr>
        <tr valign ="top">
            <td align="center" colspan="2">
                <asp:Panel ID="pnl_buscar" runat="server" Style="border-right: palegoldenrod thin ridge;
                    border-top: palegoldenrod thin ridge; border-left: palegoldenrod thin ridge;
                    border-bottom: palegoldenrod thin ridge; text-align: center" Width="90%" Visible="False">
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                        <tr valign ="top">
                            <td align="left" colspan="3" style="text-align: left">
                                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Underline="False" Text="Sistema de Búsqueda Selectiva"
                                    Width="90%"></asp:Label></td>
                            <td align="left" style="width: 15%">
                                <asp:Label ID="Label4" runat="server" Style="text-align: left" Text="Nombre / Identificación" Width="90%"></asp:Label>&nbsp;</td>
                            <td align="left" style="width: 15%">
                                <asp:TextBox ID="txt_nombre" runat="server" Width="88%" MaxLength="30" CssClass="Digitar"/></td>
                            <td align="right" style="width: 15%">
                                <asp:ImageButton ID="btn_Procesar" runat="server" ImageUrl="~/Images/Search.jpg" ToolTip="Realizar la Búsqueda." TabIndex="1" />
                                <asp:ImageButton ID="btn_limpiar" runat="server" ImageUrl="~/Images/New.jpg" ToolTip="Limpiar Campos Búsqueda." TabIndex="2" /></td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr valign ="top">
            <td rowspan="7" style="width: 60%" valign="top">
                <telerik:RadGrid ID="Rg_Listado" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                    GridLines="None" PageSize="20" ShowStatusBar="True" Skin="Simple" TabIndex="8"
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
                           <telerik:GridTemplateColumn HeaderText="No.">
                                <ItemTemplate>
                                    <asp:label runat="server" id="lblno" text='<%# ctype(CType(Container.Parent.Parent.Parent,RadGrid).DataSource,IList).IndexOf(Container.DataItem)+1 %>' />
                                    <asp:Label runat="Server" Id="lblid" Visible ="False" Text ='<%#Container.DataItem.Id%>'/>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>                                
                        
                            <telerik:GridBoundColumn DataField="Id" DataType="System.Int32" HeaderText="Id" ReadOnly="True"
                                SortExpression="Id" UniqueName="Id" Visible="False" DefaultInsertValue="">
                            </telerik:GridBoundColumn>
                            
                            <telerik:GridBoundColumn DataField="Razon_Social" HeaderText="Nombre del Tercero" SortExpression="Razon_Social"
                                UniqueName="Razon_Social" DefaultInsertValue="">
                                <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                    Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                                    <ItemStyle Width="400px" />
                            </telerik:GridBoundColumn>
                            
                            <telerik:GridBoundColumn DataField="Identificacion"  HeaderText="Identificaci&#243;n"
                                SortExpression="Identificacion" UniqueName="Identificacion" DefaultInsertValue="">
                                <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                    Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                                <ItemStyle HorizontalAlign="Right" Width ="100px" />
                            </telerik:GridBoundColumn>
                            
                            <telerik:GridBoundColumn DataField="Direccion"  HeaderText="Direcci&#243;n" Visible ="False"
                                SortExpression="Direccion" UniqueName="Direccion" DefaultInsertValue="">
                            </telerik:GridBoundColumn>
                            
                            <telerik:GridBoundColumn DataField="Telefono1"  HeaderText="Tel&#233;fono 1" Visible ="False"
                                SortExpression="Telefono1" UniqueName="Telefono1" DefaultInsertValue="">
                            </telerik:GridBoundColumn>
                            
                            <telerik:GridBoundColumn DataField="Telefono2"  HeaderText="Tel&#233;fono 2" Visible ="False"
                                SortExpression="Telefono2" UniqueName="Telefono2" DefaultInsertValue="">
                            </telerik:GridBoundColumn>
                            
                            <telerik:GridBoundColumn DataField="Nombre_Empresa"   Visible ="False"
                                SortExpression="Nombre_Empresa" UniqueName="Nombre_Empresa" DefaultInsertValue="">
                            </telerik:GridBoundColumn>

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
            </td>
            <td style="width: 40%">
                </td>
        </tr>
        <tr valign ="top">
            <td style="width: 40%" align="center">
                <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Underline="False" Text="VISTA DE TERCERO"
                    Width="90%"></asp:Label></td>
        </tr>
        <tr valign ="top">
            <td style="width: 40%; height: 281px;" align="center" valign="top">
                &nbsp;
                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                    <tr valign ="top">
                        <td colspan="2">
                            <img height="150" src="../Images/nophoto.jpg" /></td>
                    </tr>
                    <tr valign ="top">
                        <td style="width: 40%">
                        </td>
                        <td style="width: 60%">
                        </td>
                    </tr>
                    <tr valign ="top">
                        <td align="left" style="width: 40%">
                            <asp:Label ID="Label5" runat="server" Text="Nombre" CssClass="Labelsdigitar" Width="90%"></asp:Label></td>
                        <td align="left" style="width: 60%">
                            <asp:Label ID="lbl_nombre" runat="server" Text="_"></asp:Label></td>
                    </tr>
                    <tr valign ="top">
                        <td align="left" style="width: 40%">
                            <asp:Label ID="Label6" runat="server" Text="Identificación" CssClass="Labelsdigitar" Width="90%"></asp:Label></td>
                        <td align="left" style="width: 60%">
                            <asp:Label ID="lbl_Identificacion" runat="server" Text="_"></asp:Label></td>
                    </tr>
                    <tr valign ="top">
                        <td align="left" style="width: 40%">
                            <asp:Label ID="Label7" runat="server" Text="Dirección" CssClass="Labelsdigitar" Width="90%"></asp:Label></td>
                        <td align="left" style="width: 60%">
                            <asp:Label ID="Lbl_Direccion" runat="server" Text="_"></asp:Label></td>
                    </tr>
                    <tr valign ="top">
                        <td align="left" style="width: 40%; height: 16px">
                            <asp:Label ID="Label8" runat="server" Text="Telefono 1" CssClass="Labelsdigitar" Width="90%"></asp:Label></td>
                        <td align="left" style="width: 60%; height: 16px">
                            <asp:Label ID="lbl_telefono1" runat="server" Text="_"></asp:Label></td>
                    </tr>
                    <tr valign ="top">
                        <td align="left" style="width: 40%">
                            <asp:Label ID="Label9" runat="server" Text="Telefono 2" CssClass="Labelsdigitar" Width="90%"></asp:Label></td>
                        <td align="left" style="width: 60%">
                            <asp:Label ID="lbl_telefono2" runat="server" Text="_"></asp:Label></td>
                    </tr>
                    <tr valign ="top">
                        <td align="left" colspan="2">
                            <asp:Label ID="lbl_Nombre_Empresa" runat="server" CssClass="Labelsdigitar" Text="_" Width="90%"></asp:Label></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr valign ="top">
            <td style="width: 40%;" align="center">
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Underline="False" Text="CARGUE DE TERCEROS DE NOVASOFT"
                    Width="90%"></asp:Label></td>
        </tr>
        <tr valign ="top">
            <td style="width: 40%" align="left">
                &nbsp;
                <telerik:RadUpload ID="RUCargueTerceros" runat="server" Width="50%" ControlObjectsVisibility="None" MaxFileInputsCount="1" ToolTip="Elegir archivo Plano para cargar" Culture="Spanish (Colombia)" AllowedFileExtensions=".txt" InputSize="40" Skin="Sunset" TargetFolder="../Upload" OverwriteExistingFiles="True" CssClass="Digitar" TabIndex="5" >
                    <Localization Select="Seleccionar" />
                    
                </telerik:RadUpload>
                &nbsp; &nbsp;
            </td>
        </tr>
        <tr valign ="top">
            <td align="center" style="width: 40%">
                <asp:ImageButton ID="ImgCargueTerceros" runat="server" ImageAlign="Middle" ImageUrl="~/Images/UpDownArrows.jpg" Width="32px" ToolTip="Actualizar Terceros" TabIndex="7" />
                <asp:CheckBox ID="chk_actualizar" runat="server" Text="Actualizar Datos" TabIndex="6" /></td>
        </tr>
        <tr valign ="top">
            <td style="width: 40%">
                <asp:Label ID="lblresultado" runat="server" ForeColor="Green" Width="100%"></asp:Label></td>
        </tr>
        <tr valign ="top">
            <td align="left" colspan="2">
                </td>
        </tr>
    </table>
    </asp:Panel> 

</asp:Content>

