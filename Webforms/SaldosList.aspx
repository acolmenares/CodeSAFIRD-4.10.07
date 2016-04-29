<%@ Page Title="" Language="VB" MasterPageFile="~/Controles/MasterPage.master" AutoEventWireup="false" CodeFile="SaldosList.aspx.vb" Inherits="Webforms_SaldosList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <telerik:RadScriptManager ID="RadScriptManager1" runat="server"/>
    <asp:Panel runat="server" ID="pnl_principal" DefaultButton ="btn_actualizar" Width ="100%">
    <table id="tbl_Interna" border="0" cellpadding="1" cellspacing="0" width="100%" style="border-right: whitesmoke thin solid; border-top: whitesmoke thin solid; border-left: whitesmoke thin solid; border-bottom: whitesmoke thin solid">
        <tr valign ="top">
        <td style="width: 75%;"> 
            <asp:Label ID="lbl_Titulo" runat="server" Text="VISTA GENERAL DE SALDOS FINANCIEROS" Width="100%" CssClass="TitTitulo" BackColor="PeachPuff"></asp:Label><br />
            <asp:Label ID="lblMensaje" runat="server" CssClass="TitMensaje" Text="_" Width="100%" Visible="False"></asp:Label></td>
        <td style="width: 25%" align="right">
            <asp:ImageButton ID="btn_actualizar" runat="server" ImageUrl="~/Images/Reload.jpg" ToolTip="Actualizar la vista actual." />
            <asp:ImageButton ID="btn_buscar" runat="server" ImageUrl="~/Images/Zoom In.jpg" ToolTip="Ver/quitar Sistema de Búsqueda." Visible="False" TabIndex="1" />
            <asp:ImageButton ID="btn_nuevo" runat="server" ImageUrl="~/Images/Add.jpg" ToolTip="Crear Nuevo Registro." Visible="False" TabIndex="2" />
            <asp:ImageButton ID="btn_cerrar" runat="server" ImageUrl="~/Images/Stop.jpg" ToolTip="Cerrar - Volver a la vista anterior." TabIndex="3" />
            <asp:ImageButton ID="btn_home" runat="server" ImageUrl="~/Images/Home.jpg" ToolTip="Ir al Inicio." TabIndex="4" />&nbsp;</td>
        </tr>
        <tr valign ="top">
            <td colspan="2" align="center" >
                <asp:Panel ID="Pnl_Buscar" runat="server" Width="90%" style="text-align: center; border-right: palegoldenrod thin ridge; border-top: palegoldenrod thin ridge; border-left: palegoldenrod thin ridge; border-bottom: palegoldenrod thin ridge;" Visible="False" >
                   
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%" >
                        <tr valign ="top">
                            <td colspan="5" style="text-align: left" align="left">
                                <asp:Label ID="Label2" runat="server" Text="Sistema de Búsqueda Selectiva" Width="90%" Font-Bold="True" Font-Underline="False"></asp:Label></td>
                            <td style="width: 15%" align="right">
                                <asp:ImageButton ID="btn_Procesar" runat="server" ImageUrl="~/Images/Search.jpg" ToolTip="Realizar la Búsqueda." />
                                <asp:ImageButton ID="btn_limpiar" runat="server" ImageUrl="~/Images/New.jpg" ToolTip="Limpiar Campos Búsqueda." /></td>
                        </tr>
                    </table>
                    
                </asp:Panel>
            </td>
        </tr>
        <tr valign ="top">
            <td colspan="2">
            <telerik:RadGrid ID="Rg_Listado" runat="server" Width="100%" ShowStatusBar="True" GridLines="None" AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True" Skin="Outlook" ShowFooter="True" Font-Size="XX-Small" BorderWidth="0px" TabIndex="5">
            <MasterTableView Width="100%" DataKeyNames="ID"  NoDetailRecordsText="No hay informaci&#243;n." NoMasterRecordsText="No hay informaci&#243;n." PageSize="20" AllowPaging="False"  Font-Size="XX-Small" ShowHeadersWhenNoRecords ="False"  >
                <DetailTables>
                    <telerik:GridTableView DataKeyNames="ID" Name="Nivel02" Width="100%" runat="server" NoDetailRecordsText="No hay informaci&#243;n." NoMasterRecordsText="No hay informaci&#243;n." Font-Size="XX-Small"  ShowHeadersWhenNoRecords ="False" >
                        <DetailTables>
                            <telerik:GridTableView DataKeyNames="ID" Name="Nivel03" Width="100%" runat="server" NoDetailRecordsText="No hay informaci&#243;n." NoMasterRecordsText="No hay informaci&#243;n." Font-Size="XX-Small" ShowHeadersWhenNoRecords ="False">
                                <DetailTables  >
                                    <telerik:GridTableView DataKeyNames ="ID" Name="Nivel04" Width="100%" runat="server" NoDetailRecordsText="No hay informaci&#243;n." NoMasterRecordsText="No hay informaci&#243;n."  Font-Size="XX-Small"  ShowHeadersWhenNoRecords ="False" >
                                        <DetailTables>
                                        <telerik:GridTableView DataKeyNames ="ID" Name="Nivel05" Width="100%" runat="server" NoDetailRecordsText="No hay informaci&#243;n." NoMasterRecordsText="No hay informaci&#243;n." Font-Size="XX-Small" ShowHeadersWhenNoRecords ="False">
                                            <Columns>
                                                <telerik:GridBoundColumn SortExpression="Id" HeaderText="Id" HeaderButtonType="TextButton"
                                                    DataField="Id" UniqueName="Id" Visible ="False" DefaultInsertValue="">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn SortExpression="Descripcion" HeaderText="Descripcion" HeaderButtonType="TextButton"
                                                    DataField="Descripcion" UniqueName="Descripcion" DefaultInsertValue="">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                                    <FooterStyle HorizontalAlign="Right" Wrap="True" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn SortExpression="Id_Padre" HeaderText="Id_Padre" HeaderButtonType="TextButton" Visible ="False"
                                                    DataField="Id_Padre" UniqueName="Id_Padre" Aggregate="Sum" DefaultInsertValue="">
                                                </telerik:GridBoundColumn>
 
                                                <telerik:GridTemplateColumn DataField="Numero_Unidades" HeaderText="No. Unidades"
                                                    SortExpression="Numero_Unidades" UniqueName="Numero_Unidades">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Numero_UnidadesLabel" runat="server" Text='<%# Eval("Numero_Unidades", "{0:n}") %>' ToolTip ='<%# Eval("TipoUnidad.Descripcion") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="True"/>
                                                    <FooterStyle HorizontalAlign="Right" Wrap="True" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </telerik:GridTemplateColumn>                                               
                                                <telerik:GridBoundColumn DataField="Costo_Unidad" HeaderText="Costo U." SortExpression="Costo_Unidad" DataFormatString="{0:c}"
                                                    UniqueName="Costo_Unidad" DefaultInsertValue="" >
                                                    <ItemStyle HorizontalAlign="Right" />
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                                    <FooterStyle HorizontalAlign="Right" Wrap="True" />
                                                </telerik:GridBoundColumn> 
                                                <telerik:GridBoundColumn DataField="Distribucion" HeaderText="TPC" SortExpression="Distribucion" DataFormatString="{0:c}"
                                                    UniqueName="Distribucion" Aggregate ="Sum" HeaderTooltip ="Total PRM Cost" DefaultInsertValue="" >
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="True" Font-Bold ="True" />
                                                    <FooterStyle HorizontalAlign="Right" Wrap="True" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </telerik:GridBoundColumn> 

                                                <telerik:GridBoundColumn DataField="Incremento" HeaderText="Incremento" SortExpression="Incremento" DataFormatString="{0:c}"
                                                    UniqueName="Incremento" Aggregate ="Sum" DefaultInsertValue=""  >
                                                    <ItemStyle HorizontalAlign="Right" />
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                                    <FooterStyle HorizontalAlign="Right" Wrap="True" />
                                                </telerik:GridBoundColumn> 

                                                <telerik:GridBoundColumn DataField="Reduccion" HeaderText="Reducci&#243;n" SortExpression="Reduccion" DataFormatString="{0:c}"
                                                    UniqueName="Reduccion" Aggregate ="Sum" DefaultInsertValue=""  >
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                                    <FooterStyle HorizontalAlign="Right" Wrap="True" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </telerik:GridBoundColumn> 

                                                <telerik:GridBoundColumn DataField="Saldo_PRM" HeaderText="Saldo PRM " SortExpression="Saldo_PRM" DataFormatString="{0:c}"
                                                    UniqueName="Saldo_PRM"  Aggregate ="Sum" DefaultInsertValue="" >
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="True" Font-Bold ="True" />
                                                    <FooterStyle HorizontalAlign="Right" Wrap="True" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </telerik:GridBoundColumn> 

                                                <telerik:GridBoundColumn DataField="OrdenCompra" HeaderText="Orden Compra" SortExpression="OrdenCompra" DataFormatString="{0:c}"
                                                    UniqueName="OrdenCompra"  Aggregate ="Sum" DefaultInsertValue="" >
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                                    <FooterStyle HorizontalAlign="Right" Wrap="True" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </telerik:GridBoundColumn> 

                                                <telerik:GridBoundColumn DataField="Contratos" HeaderText="Contratos" SortExpression="Contratos" DataFormatString="{0:c}"
                                                    UniqueName="Contratos" Aggregate ="Sum" DefaultInsertValue=""  >
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                                    <FooterStyle HorizontalAlign="Right" Wrap="True" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </telerik:GridBoundColumn> 

                                                <telerik:GridBoundColumn DataField="Disponible" HeaderText="Disponible" SortExpression="Disponible" DataFormatString="{0:c}"
                                                    UniqueName="Disponible" Aggregate ="Sum" DefaultInsertValue=""  >
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="True" Font-Bold ="True" />
                                                    <FooterStyle HorizontalAlign="Right" Wrap="True" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </telerik:GridBoundColumn> 

                                                <telerik:GridBoundColumn DataField="Ejecutado" HeaderText="Ejecutado" SortExpression="Ejecutado" DataFormatString="{0:c}"
                                                    UniqueName="Ejecutado"  Aggregate ="Sum" DefaultInsertValue="" >
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                                    <FooterStyle HorizontalAlign="Right" Wrap="True" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </telerik:GridBoundColumn> 

                                                <telerik:GridBoundColumn DataField="Por_Ejecutar" HeaderText="Por Ejecutar" SortExpression="Por_Ejecutar" DataFormatString="{0:c}"
                                                    UniqueName="Por_Ejecutar" Aggregate ="Sum" DefaultInsertValue=""  >
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="True"/>
                                                    <FooterStyle HorizontalAlign="Right" Wrap="True" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </telerik:GridBoundColumn> 

                                                <telerik:GridBoundColumn DataField="Balance" HeaderText="Balance" SortExpression="Balance" DataFormatString="{0:c}"
                                                    UniqueName="Balance" Aggregate ="Sum" DefaultInsertValue=""  >
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="True" Font-Bold ="True" />
                                                    <FooterStyle HorizontalAlign="Right" Wrap="True" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </telerik:GridBoundColumn>                                                 
                                                                                                
                                            </Columns>                                        
                                        </telerik:GridTableView>
                                        </DetailTables> 
                                        <Columns>
                                            <telerik:GridBoundColumn SortExpression="Id" HeaderText="Id" HeaderButtonType="TextButton"
                                                DataField="Id" UniqueName="Id" Visible ="False" DefaultInsertValue="" >
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn SortExpression="Descripcion" HeaderText="Descripcion" HeaderButtonType="TextButton"
                                                DataField="Descripcion" UniqueName="Descripcion" DefaultInsertValue="">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn SortExpression="Id_Padre" HeaderText="Id_Padre" HeaderButtonType="TextButton" Visible ="False"
                                                DataField="Id_Padre" UniqueName="Id_Padre" Aggregate="Sum" DefaultInsertValue="">
                                            </telerik:GridBoundColumn>
                                                                                          
                                            <telerik:GridTemplateColumn DataField="Numero_Unidades" HeaderText="No. Unidades"
                                                SortExpression="Numero_Unidades" UniqueName="Numero_Unidades">
                                                <ItemTemplate>
                                                    <asp:Label ID="Numero_UnidadesLabel" runat="server" Text='<%# Eval("Numero_Unidades", "{0:n}") %>' ToolTip ='<%# Eval("TipoUnidad.Descripcion") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" Wrap="True"/>
                                                <FooterStyle HorizontalAlign="Right" Wrap="True" />
                                                <ItemStyle HorizontalAlign="Right" />
                                            </telerik:GridTemplateColumn>                                             
                                            
                                            <telerik:GridBoundColumn DataField="Costo_Unidad" HeaderText="Costo U." SortExpression="Costo_Unidad" DataFormatString="{0:c}"
                                                UniqueName="Costo_Unidad" DefaultInsertValue="" >
                                                <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                                <FooterStyle HorizontalAlign="Right" Wrap="True" />
                                                <ItemStyle HorizontalAlign="Right" />
                                            </telerik:GridBoundColumn> 
                                            
                                            <telerik:GridBoundColumn DataField="Distribucion" HeaderText="TPC" SortExpression="Distribucion" DataFormatString="{0:c}"
                                                UniqueName="Distribucion" Aggregate ="Sum" HeaderTooltip ="Total PRM Cost" DefaultInsertValue="" >
                                                <HeaderStyle HorizontalAlign="Center" Wrap="True" Font-Bold ="True" />
                                                <FooterStyle HorizontalAlign="Right" Wrap="True" />
                                                <ItemStyle HorizontalAlign="Right" />
                                            </telerik:GridBoundColumn> 

                                            <telerik:GridBoundColumn DataField="Incremento" HeaderText="Incremento" SortExpression="Incremento" DataFormatString="{0:c}"
                                                UniqueName="Incremento" Aggregate ="Sum" DefaultInsertValue=""  >
                                                <HeaderStyle HorizontalAlign="Center" Wrap="True"/>
                                                <FooterStyle HorizontalAlign="Right" Wrap="True" />
                                                <ItemStyle HorizontalAlign="Right" />
                                            </telerik:GridBoundColumn> 

                                            <telerik:GridBoundColumn DataField="Reduccion" HeaderText="Reducci&#243;n" SortExpression="Reduccion" DataFormatString="{0:c}"
                                                UniqueName="Reduccion" Aggregate ="Sum" DefaultInsertValue=""  >
                                                <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                                <FooterStyle HorizontalAlign="Right" Wrap="True" />
                                                <ItemStyle HorizontalAlign="Right" />
                                            </telerik:GridBoundColumn> 

                                            <telerik:GridBoundColumn DataField="Saldo_PRM" HeaderText="Saldo PRM " SortExpression="Saldo_PRM" DataFormatString="{0:c}"
                                                UniqueName="Saldo_PRM" Aggregate ="Sum" DefaultInsertValue=""  >
                                                <HeaderStyle HorizontalAlign="Center" Wrap="True" Font-Bold ="True" />
                                                <FooterStyle HorizontalAlign="Right" Wrap="True" />
                                                <ItemStyle HorizontalAlign="Right" />
                                            </telerik:GridBoundColumn> 

                                            <telerik:GridBoundColumn DataField="OrdenCompra" HeaderText="Orden Compra" SortExpression="OrdenCompra" DataFormatString="{0:c}"
                                                UniqueName="OrdenCompra"  Aggregate ="Sum" DefaultInsertValue="" >
                                                <HeaderStyle HorizontalAlign="Center" Wrap="True"  />
                                                <FooterStyle HorizontalAlign="Right" Wrap="True" />
                                                <ItemStyle HorizontalAlign="Right" />
                                            </telerik:GridBoundColumn> 

                                            <telerik:GridBoundColumn DataField="Contratos" HeaderText="Contratos" SortExpression="Contratos" DataFormatString="{0:c}"
                                                UniqueName="Contratos" Aggregate ="Sum" DefaultInsertValue=""  >
                                                <HeaderStyle HorizontalAlign="Center" Wrap="True"  />
                                                <FooterStyle HorizontalAlign="Right" Wrap="True" />
                                                <ItemStyle HorizontalAlign="Right" />
                                            </telerik:GridBoundColumn> 

                                            <telerik:GridBoundColumn DataField="Disponible" HeaderText="Disponible" SortExpression="Disponible" DataFormatString="{0:c}"
                                                UniqueName="Disponible"  Aggregate ="Sum" DefaultInsertValue="" >
                                                <HeaderStyle HorizontalAlign="Center" Wrap="True" Font-Bold ="True" />
                                                <FooterStyle HorizontalAlign="Right" Wrap="True" />
                                                <ItemStyle HorizontalAlign="Right" />
                                            </telerik:GridBoundColumn> 

                                            <telerik:GridBoundColumn DataField="Ejecutado" HeaderText="Ejecutado" SortExpression="Ejecutado" DataFormatString="{0:c}"
                                                UniqueName="Ejecutado" Aggregate ="Sum" DefaultInsertValue=""  >
                                                <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                                <FooterStyle HorizontalAlign="Right" Wrap="True" />
                                                <ItemStyle HorizontalAlign="Right" />
                                            </telerik:GridBoundColumn> 

                                            <telerik:GridBoundColumn DataField="Por_Ejecutar" HeaderText="Por Ejecutar" SortExpression="Por_Ejecutar" DataFormatString="{0:c}"
                                                UniqueName="Por_Ejecutar"  Aggregate ="Sum" DefaultInsertValue="" >
                                                <HeaderStyle HorizontalAlign="Center" Wrap="True"  />
                                                <FooterStyle HorizontalAlign="Right" Wrap="True" />
                                                <ItemStyle HorizontalAlign="Right" />
                                            </telerik:GridBoundColumn> 

                                            <telerik:GridBoundColumn DataField="Balance" HeaderText="Balance" SortExpression="Balance" DataFormatString="{0:c}"
                                                UniqueName="Balance" Aggregate ="Sum" DefaultInsertValue=""  >
                                                <HeaderStyle HorizontalAlign="Center" Wrap="True" Font-Bold ="True" />
                                                <FooterStyle HorizontalAlign="Right" Wrap="True" />
                                                <ItemStyle HorizontalAlign="Right" />
                                            </telerik:GridBoundColumn>                                                 

                                        </Columns>
                                        <ExpandCollapseColumn Visible="True">
                                        </ExpandCollapseColumn>
                                    </telerik:GridTableView>
                                </DetailTables>
                                <Columns>
                                    <telerik:GridBoundColumn SortExpression="Id" HeaderText="Id" HeaderButtonType="TextButton"
                                        DataField="Id" UniqueName="Id" Visible ="False" DefaultInsertValue="">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn SortExpression="Descripcion" HeaderText="Descripcion" HeaderButtonType="TextButton"
                                        DataField="Descripcion" UniqueName="Descripcion" DefaultInsertValue="">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn SortExpression="Id_Padre" HeaderText="Id_Padre" HeaderButtonType="TextButton" Visible ="False"
                                        DataField="Id_Padre" UniqueName="Id_Padre" Aggregate="Sum" DefaultInsertValue="">
                                    </telerik:GridBoundColumn>

                                                                                  
                                    <telerik:GridTemplateColumn DataField="Numero_Unidades" HeaderText="No. Unidades"
                                        SortExpression="Numero_Unidades" UniqueName="Numero_Unidades">
                                        <ItemTemplate>
                                            <asp:Label ID="Numero_UnidadesLabel" runat="server" Text='<%# Eval("Numero_Unidades", "{0:n}") %>' ToolTip ='<%# Eval("TipoUnidad.Descripcion") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Wrap="True"/>
                                        <FooterStyle HorizontalAlign="Right" Wrap="True" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </telerik:GridTemplateColumn>                                                
                                    
                                    <telerik:GridBoundColumn DataField="Costo_Unidad" HeaderText="Costo U." SortExpression="Costo_Unidad" DataFormatString="{0:c}"
                                        UniqueName="Costo_Unidad" DefaultInsertValue="" >
                                        <HeaderStyle HorizontalAlign="Center" Wrap="True"  />
                                        <FooterStyle HorizontalAlign="Right" Wrap="True" />                                        
                                        <ItemStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn> 
                                    
                                    <telerik:GridBoundColumn DataField="Distribucion" HeaderText="TPC" SortExpression="Distribucion" DataFormatString="{0:c}"
                                        UniqueName="Distribucion" Aggregate ="Sum" HeaderTooltip ="Total PRM Cost" DefaultInsertValue="" >
                                        <HeaderStyle HorizontalAlign="Center" Wrap="True" Font-Bold ="True" />
                                        <FooterStyle HorizontalAlign="Right" Wrap="True" />                                        
                                        <ItemStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn> 

                                    <telerik:GridBoundColumn DataField="Incremento" HeaderText="Incremento" SortExpression="Incremento" DataFormatString="{0:c}"
                                        UniqueName="Incremento"  Aggregate ="Sum" DefaultInsertValue="" >
                                        <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                        <FooterStyle HorizontalAlign="Right" Wrap="True" />                                        
                                        <ItemStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn> 

                                    <telerik:GridBoundColumn DataField="Reduccion" HeaderText="Reducci&#243;n" SortExpression="Reduccion" DataFormatString="{0:c}"
                                        UniqueName="Reduccion" Aggregate ="Sum" DefaultInsertValue=""  >
                                        <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                        <FooterStyle HorizontalAlign="Right" Wrap="True" />                                        
                                        <ItemStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn> 

                                    <telerik:GridBoundColumn DataField="Saldo_PRM" HeaderText="Saldo PRM " SortExpression="Saldo_PRM" DataFormatString="{0:c}"
                                        UniqueName="Saldo_PRM" Aggregate ="Sum" DefaultInsertValue=""  >
                                        <HeaderStyle HorizontalAlign="Center" Wrap="True" Font-Bold ="True" />
                                        <FooterStyle HorizontalAlign="Right" Wrap="True" />                                        
                                        <ItemStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn> 

                                    <telerik:GridBoundColumn DataField="OrdenCompra" HeaderText="Orden Compra" SortExpression="OrdenCompra" DataFormatString="{0:c}"
                                        UniqueName="OrdenCompra" Aggregate ="Sum" DefaultInsertValue=""  >
                                        <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                        <FooterStyle HorizontalAlign="Right" Wrap="True" />                                        
                                        <ItemStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn> 

                                    <telerik:GridBoundColumn DataField="Contratos" HeaderText="Contratos" SortExpression="Contratos" DataFormatString="{0:c}"
                                        UniqueName="Contratos" Aggregate ="Sum" DefaultInsertValue=""  >
                                        <HeaderStyle HorizontalAlign="Center" Wrap="True"  />
                                        <FooterStyle HorizontalAlign="Right" Wrap="True" />                                        
                                        <ItemStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn> 

                                    <telerik:GridBoundColumn DataField="Disponible" HeaderText="Disponible" SortExpression="Disponible" DataFormatString="{0:c}"
                                        UniqueName="Disponible" Aggregate ="Sum" DefaultInsertValue=""  >
                                        <HeaderStyle HorizontalAlign="Center" Wrap="True" Font-Bold ="True" />
                                        <FooterStyle HorizontalAlign="Right" Wrap="True" />                                        
                                        <ItemStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn> 

                                    <telerik:GridBoundColumn DataField="Ejecutado" HeaderText="Ejecutado" SortExpression="Ejecutado" DataFormatString="{0:c}"
                                        UniqueName="Ejecutado"  Aggregate ="Sum" DefaultInsertValue="" >
                                        <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                        <FooterStyle HorizontalAlign="Right" Wrap="True" />                                        
                                        <ItemStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn> 

                                    <telerik:GridBoundColumn DataField="Por_Ejecutar" HeaderText="Por Ejecutar" SortExpression="Por_Ejecutar" DataFormatString="{0:c}"
                                        UniqueName="Por_Ejecutar" Aggregate ="Sum" DefaultInsertValue=""  >
                                        <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                        <FooterStyle HorizontalAlign="Right" Wrap="True" />                                        
                                        <ItemStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn> 

                                    <telerik:GridBoundColumn DataField="Balance" HeaderText="Balance" SortExpression="Balance" DataFormatString="{0:c}"
                                        UniqueName="Balance"  Aggregate ="Sum" DefaultInsertValue="" >
                                        <HeaderStyle HorizontalAlign="Center" Wrap="True" Font-Bold ="True" />
                                        <FooterStyle HorizontalAlign="Right" Wrap="True" />                                        
                                        <ItemStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>                                                 

                                </Columns>
                                <ExpandCollapseColumn Visible="True">
                                </ExpandCollapseColumn>
                            </telerik:GridTableView>
                        </DetailTables>
                        <Columns>
                            <telerik:GridBoundColumn SortExpression="Id" HeaderText="Id" HeaderButtonType="TextButton"
                                DataField="Id" UniqueName="Id" Visible="False" DefaultInsertValue="">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn SortExpression="Descripcion" HeaderText="Descripcion" HeaderButtonType="TextButton"
                                DataField="Descripcion" UniqueName="Descripcion" DefaultInsertValue="">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn SortExpression="Id_Padre" HeaderText="Id_Padre" HeaderButtonType="TextButton" Visible ="False"
                                DataField="Id_Padre" UniqueName="Id_Padre" Aggregate="Sum" DefaultInsertValue="">
                            </telerik:GridBoundColumn>

                            <telerik:GridTemplateColumn DataField="Numero_Unidades" HeaderText="No. Unidades"
                                SortExpression="Numero_Unidades" UniqueName="Numero_Unidades">
                                <ItemTemplate>
                                    <asp:Label ID="Numero_UnidadesLabel" runat="server" Text='<%# Eval("Numero_Unidades", "{0:n}") %>' ToolTip ='<%# Eval("TipoUnidad.Descripcion") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Wrap="True"/>
                                <FooterStyle HorizontalAlign="Right" Wrap="True" />
                                <ItemStyle HorizontalAlign="Right" />
                            </telerik:GridTemplateColumn>
                            
                            <telerik:GridBoundColumn DataField="Costo_Unidad" HeaderText="Costo U." SortExpression="Costo_Unidad" DataFormatString="{0:c}"
                                UniqueName="Costo_Unidad" DefaultInsertValue="" >
                                <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                <FooterStyle HorizontalAlign="Right" Wrap="True" /> 
                                <ItemStyle HorizontalAlign="Right" />
                            </telerik:GridBoundColumn> 
                            
                            <telerik:GridBoundColumn DataField="Distribucion" HeaderText="TPC" SortExpression="Distribucion" DataFormatString="{0:c}"
                                UniqueName="Distribucion" Aggregate ="Sum" HeaderTooltip ="Total PRM Cost" DefaultInsertValue=""  >
                                <HeaderStyle HorizontalAlign="Center" Wrap="True" Font-Bold ="True" />
                                <FooterStyle HorizontalAlign="Right" Wrap="True" /> 
                                <ItemStyle HorizontalAlign="Right" />
                            </telerik:GridBoundColumn> 

                            <telerik:GridBoundColumn DataField="Incremento" HeaderText="Incremento" SortExpression="Incremento" DataFormatString="{0:c}"
                                UniqueName="Incremento"  Aggregate ="Sum" DefaultInsertValue="" >
                                <HeaderStyle HorizontalAlign="Center" Wrap="True"/>
                                <FooterStyle HorizontalAlign="Right" Wrap="True" /> 
                                <ItemStyle HorizontalAlign="Right" />
                            </telerik:GridBoundColumn> 

                            <telerik:GridBoundColumn DataField="Reduccion" HeaderText="Reducci&#243;n" SortExpression="Reduccion" DataFormatString="{0:c}"
                                UniqueName="Reduccion" Aggregate ="Sum" DefaultInsertValue=""  >
                                <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                <FooterStyle HorizontalAlign="Right" Wrap="True" /> 
                                <ItemStyle HorizontalAlign="Right" />
                            </telerik:GridBoundColumn> 

                            <telerik:GridBoundColumn DataField="Saldo_PRM" HeaderText="Saldo PRM " SortExpression="Saldo_PRM" DataFormatString="{0:c}"
                                UniqueName="Saldo_PRM"  Aggregate ="Sum" DefaultInsertValue="" >
                                <HeaderStyle HorizontalAlign="Center" Wrap="True" Font-Bold ="True" />
                                <FooterStyle HorizontalAlign="Right" Wrap="True" /> 
                                <ItemStyle HorizontalAlign="Right" />
                            </telerik:GridBoundColumn> 

                            <telerik:GridBoundColumn DataField="OrdenCompra" HeaderText="Orden Compra" SortExpression="OrdenCompra" DataFormatString="{0:c}"
                                UniqueName="OrdenCompra" Aggregate ="Sum" DefaultInsertValue=""  >
                                <HeaderStyle HorizontalAlign="Center" Wrap="True"  />
                                <FooterStyle HorizontalAlign="Right" Wrap="True" /> 
                                <ItemStyle HorizontalAlign="Right" />
                            </telerik:GridBoundColumn> 

                            <telerik:GridBoundColumn DataField="Contratos" HeaderText="Contratos" SortExpression="Contratos" DataFormatString="{0:c}"
                                UniqueName="Contratos" Aggregate ="Sum" DefaultInsertValue="" >
                                <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                <FooterStyle HorizontalAlign="Right" Wrap="True" /> 
                                <ItemStyle HorizontalAlign="Right" />
                            </telerik:GridBoundColumn> 

                            <telerik:GridBoundColumn DataField="Disponible" HeaderText="Disponible" SortExpression="Disponible" DataFormatString="{0:c}"
                                UniqueName="Disponible"  Aggregate ="Sum" DefaultInsertValue="" >
                                <HeaderStyle HorizontalAlign="Center" Wrap="True" Font-Bold ="True" />
                                <FooterStyle HorizontalAlign="Right" Wrap="True" /> 
                                <ItemStyle HorizontalAlign="Right" />
                            </telerik:GridBoundColumn> 

                            <telerik:GridBoundColumn DataField="Ejecutado" HeaderText="Ejecutado" SortExpression="Ejecutado" DataFormatString="{0:c}"
                                UniqueName="Ejecutado" Aggregate ="Sum" DefaultInsertValue="" >
                                <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                <FooterStyle HorizontalAlign="Right" Wrap="True" /> 
                                <ItemStyle HorizontalAlign="Right" />
                            </telerik:GridBoundColumn> 

                            <telerik:GridBoundColumn DataField="Por_Ejecutar" HeaderText="Por Ejecutar" SortExpression="Por_Ejecutar" DataFormatString="{0:c}"
                                UniqueName="Por_Ejecutar" Aggregate ="Sum" DefaultInsertValue=""  >
                                <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                <FooterStyle HorizontalAlign="Right" Wrap="True" /> 
                                <ItemStyle HorizontalAlign="Right" />
                            </telerik:GridBoundColumn> 

                            <telerik:GridBoundColumn DataField="Balance" HeaderText="Balance" SortExpression="Balance" DataFormatString="{0:c}"
                                UniqueName="Balance" Aggregate ="Sum" DefaultInsertValue="" >
                                <HeaderStyle HorizontalAlign="Center" Wrap="True" Font-Bold ="True" />
                                <FooterStyle HorizontalAlign="Right" Wrap="True" /> 
                                <ItemStyle HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>                                                 

                        </Columns>
                        <ExpandCollapseColumn Visible="True">
                        </ExpandCollapseColumn>
                    </telerik:GridTableView>
                </DetailTables>
                        <CommandItemSettings ExportToCsvText ="Exportar a CSV" ExportToExcelText ="Exportar a Excel" ExportToPdfText ="Exportar a PDF"
                             ExportToWordText ="Exportar a Word" RefreshText ="Actualizar" AddNewRecordText =""  AddNewRecordImageUrl ="~/Images/nothing.gif"
                              ShowExportToCsvButton="True" ShowExportToExcelButton="True" ShowExportToPdfButton="True" ShowExportToWordButton ="True"/>
                <ExpandCollapseColumn Visible="True">
                </ExpandCollapseColumn>
                <Columns>
                    <telerik:GridBoundColumn SortExpression="Id" HeaderText="Id" HeaderButtonType="TextButton"
                        DataField="Id" UniqueName="Id"  Visible ="False" DefaultInsertValue="">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn SortExpression="Descripcion" HeaderText="Descripcion" HeaderButtonType="TextButton"
                        DataField="Descripcion" UniqueName="Descripcion" DefaultInsertValue="">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn SortExpression="Id_Padre" HeaderText="Id_Padre" HeaderButtonType="TextButton" Visible ="False"
                        DataField="Id_Padre" UniqueName="Id_Padre" DefaultInsertValue="" >
                    </telerik:GridBoundColumn>
                                                                 
                    <telerik:GridTemplateColumn DataField="Numero_Unidades" HeaderText="No. Unidades"
                        SortExpression="Numero_Unidades" UniqueName="Numero_Unidades">
                        <ItemTemplate>
                            <asp:Label ID="Numero_UnidadesLabel" runat="server" Text='<%# Eval("Numero_Unidades", "{0:n}") %>' ToolTip ='<%# Eval("TipoUnidad.Descripcion") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Wrap="True"/>
                        <FooterStyle HorizontalAlign="Right" Wrap="True" />
                        <ItemStyle HorizontalAlign="Right" />
                    </telerik:GridTemplateColumn>                                                
                    
                    <telerik:GridBoundColumn DataField="Costo_Unidad" HeaderText="Costo U." SortExpression="Costo_Unidad" DataFormatString="{0:c}"
                        UniqueName="Costo_Unidad" DefaultInsertValue="" >
                        <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                        <ItemStyle HorizontalAlign="Right" />
                    </telerik:GridBoundColumn> 
                    
                    <telerik:GridBoundColumn DataField="Distribucion" HeaderText="TPC" SortExpression="Distribucion" DataFormatString="{0:c}"
                        UniqueName="Distribucion" Aggregate ="Sum" HeaderTooltip ="Total PRM Cost" DefaultInsertValue=""  >
                        <HeaderStyle HorizontalAlign="Center" Wrap="True" Font-Bold ="True" />
                        <FooterStyle HorizontalAlign="Right" Wrap="True" /> 
                        <ItemStyle HorizontalAlign="Right" />
                    </telerik:GridBoundColumn> 

                    <telerik:GridBoundColumn DataField="Incremento" HeaderText="Incremento" SortExpression="Incremento" DataFormatString="{0:c}"
                        UniqueName="Incremento" Aggregate ="Sum" DefaultInsertValue=""  >
                        <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                        <FooterStyle HorizontalAlign="Right" Wrap="True" /> 
                        <ItemStyle HorizontalAlign="Right" />
                    </telerik:GridBoundColumn> 

                    <telerik:GridBoundColumn DataField="Reduccion" HeaderText="Reducci&#243;n" SortExpression="Reduccion" DataFormatString="{0:c}"
                        UniqueName="Reduccion" Aggregate ="Sum" DefaultInsertValue=""  >
                        <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                        <FooterStyle HorizontalAlign="Right" Wrap="True" /> 
                        <ItemStyle HorizontalAlign="Right" />
                    </telerik:GridBoundColumn> 

                    <telerik:GridBoundColumn DataField="Saldo_PRM" HeaderText="Saldo PRM" SortExpression="Saldo_PRM" DataFormatString="{0:c}"
                        UniqueName="Saldo_PRM" Aggregate ="Sum" DefaultInsertValue=""  >
                        <HeaderStyle HorizontalAlign="Center" Wrap="True" Font-Bold ="True" />
                        <FooterStyle HorizontalAlign="Right" Wrap="True" /> 
                        <ItemStyle HorizontalAlign="Right" />
                    </telerik:GridBoundColumn> 

                    <telerik:GridBoundColumn DataField="OrdenCompra" HeaderText="Orden Compra" SortExpression="OrdenCompra" DataFormatString="{0:c}"
                        UniqueName="OrdenCompra" Aggregate ="Sum" DefaultInsertValue=""  >
                        <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                        <FooterStyle HorizontalAlign="Right" Wrap="True" /> 
                        <ItemStyle HorizontalAlign="Right" />
                    </telerik:GridBoundColumn> 

                    <telerik:GridBoundColumn DataField="Contratos" HeaderText="Contratos" SortExpression="Contratos" DataFormatString="{0:c}"
                        UniqueName="Contratos" Aggregate ="Sum" DefaultInsertValue=""  >
                        <HeaderStyle HorizontalAlign="Center" Wrap="True"  />
                        <FooterStyle HorizontalAlign="Right" Wrap="True" /> 
                        <ItemStyle HorizontalAlign="Right" />
                    </telerik:GridBoundColumn> 

                    <telerik:GridBoundColumn DataField="Disponible" HeaderText="Disponible" SortExpression="Disponible" DataFormatString="{0:c}"
                        UniqueName="Disponible" Aggregate ="Sum" DefaultInsertValue=""  >
                        <HeaderStyle HorizontalAlign="Center" Wrap="True" Font-Bold ="True" />
                        <FooterStyle HorizontalAlign="Right" Wrap="True" /> 
                        <ItemStyle HorizontalAlign="Right" />
                    </telerik:GridBoundColumn> 

                    <telerik:GridBoundColumn DataField="Ejecutado" HeaderText="Ejecutado" SortExpression="Ejecutado" DataFormatString="{0:c}"
                        UniqueName="Ejecutado"  Aggregate ="Sum" DefaultInsertValue="" >
                        <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                        <FooterStyle HorizontalAlign="Right" Wrap="True" /> 
                        <ItemStyle HorizontalAlign="Right" />
                    </telerik:GridBoundColumn> 

                    <telerik:GridBoundColumn DataField="Por_Ejecutar" HeaderText="Por Ejecutar" SortExpression="Por_Ejecutar" DataFormatString="{0:c}"
                        UniqueName="Por_Ejecutar" Aggregate ="Sum" DefaultInsertValue=""  >
                        <HeaderStyle HorizontalAlign="Center" Wrap="True"  />
                        <FooterStyle HorizontalAlign="Right" Wrap="True" /> 
                        <ItemStyle HorizontalAlign="Right" />
                    </telerik:GridBoundColumn> 

                    <telerik:GridBoundColumn DataField="Balance" HeaderText="Balance" SortExpression="Balance" DataFormatString="{0:c}"
                        UniqueName="Balance"  Aggregate ="Sum" DefaultInsertValue="" >
                        <HeaderStyle HorizontalAlign="Center" Wrap="True" Font-Bold ="True" />
                        <FooterStyle HorizontalAlign="Right" Wrap="True" /> 
                        <ItemStyle HorizontalAlign="Right" />
                    </telerik:GridBoundColumn>                                                 

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
    </table>
    </asp:Panel> 
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btn_actualizar">
                <UpdatedControls>
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

</asp:Content>

