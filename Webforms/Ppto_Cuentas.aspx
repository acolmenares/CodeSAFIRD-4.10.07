<%@ Page Title="Cuenta Presupuestal" Language="VB" MasterPageFile="~/Controles/MasterPage.master" AutoEventWireup="false" CodeFile="Ppto_Cuentas.aspx.vb" Inherits="Webforms_Ppto_Cuentas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <telerik:RadScriptManager ID="RadScriptManager1" runat="server"/>
    
    <asp:Panel runat="Server" DefaultButton ="btnGuardar" ID="pnl_principal" Width ="100%">
    <table id="TablaContenido" cellspacing="0" cellpadding="0" border="0" class="ContentTable" style="width: 100%">
        <tr valign="top">
        <td style="width: 75%"> 
            <asp:Label ID="lbl_Titulo" runat="server" 
                Text="CREACION / MODIFICACION DE CUENTAS ASOCIADAS" Width="90%" CssClass="TitTitulo" 
                BackColor="PeachPuff"></asp:Label><br />
            <asp:Label ID="lblMensaje" runat="server" CssClass="TitMensaje" Text="_" Width="90%" Visible="False"/>
        </td>
        <td style="width: 25%" align="right">
            <asp:ImageButton ID="btn_actualizar" runat="server" ImageUrl="~/Images/Reload.jpg" ToolTip="Actualizar la vista actual." TabIndex="10" />
            <asp:ImageButton ID="btn_nuevo" runat="server" ImageUrl="~/Images/Add.jpg" ToolTip="Crear Nuevo Registro." TabIndex="11" />
            <asp:ImageButton ID="btn_cerrar" runat="server" ImageUrl="~/Images/Stop.jpg" ToolTip="Cerrar - Volver a la vista anterior." TabIndex="12" />
            <asp:ImageButton ID="btn_home" runat="server" ImageUrl="~/Images/Home.jpg" ToolTip="Ir al Inicio." TabIndex="13" />&nbsp;</td>
        </tr>

        <tr valign="top">
            <td style="width: 75%" colspan="1">
                <table id="tblContenido" class="EditControlsTable" cellspacing="0" cellpadding="0" border="0" style="width: 100%">
                    <tr valign="top">
                      <td style="width: 100%; text-align: left; background-color: #FF6600;" colspan="4">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label2" runat="server" Width="90%" 
                                style="font-weight: 700; color: #000099">INFORMACION DE LA CUENTA PRINCIPAL</asp:Label>
                
                      </td>
                    </tr>
                    <tr valign="top">
                        <td class="LabelCell" style="width: 25%">
                            <asp:Label ID="lblFecha" runat="server" Width="90%">Descripción Cuenta</asp:Label>
                        </td>
                        <td class="ControlCell" colspan="2" style="width: 50%">
                            <asp:Label ID="lbl_Descripcion" runat="server" Height="22px" Text="...." 
                                Width="90%" />
                        </td>
                        <td class="ControlCell" style="width: 25%; height: 19px;">
                            <asp:Button ID="btnGuardar" runat="server" cssClass="Boton" TabIndex="6" 
                                Text="Guardar" ToolTip="Guardar el registro y quedar en el" Width="100px" />
                        </td>
                    </tr>
                    <tr valign="top">
                        <td  class="LabelCell" style="width: 25%; height: 19px;">
                            <asp:Label id="lblNombre" runat="server" Width="90%">Código Regional</asp:Label>
                        </td>
                        <td class="ControlCell" style="width: 25%; height: 19px;">
                            <asp:TextBox id="txt_codigo" runat = "server" Width="26%" CssClass="Digitar" 
                                TabIndex="1"/></td>
                        <td class="ControlCell" style="width: 25%; height: 19px;">
                            <asp:CheckBox ID="chb_visible" runat="server" Text="Cuenta Visible" />
                        </td>
                        <td class="ControlCell" style="width: 25%; height: 19px;">
                            <asp:Button ID="btnEliminar" runat="server" CssClass="Boton" TabIndex="8" 
                                Text="Eliminar" ToolTip="Eliminar registro actual" Width="100px" />
                        </td>
                    </tr>
                </table>
            </td>
            <td style="width: 25%" align="right"></td>
        </tr>
        <tr valign="top">
          <td style="width: 75%; text-align: left; background-color: #FF6600;" colspan="1">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblidDetalle0" runat="server" 
                    Width="90%" style="font-weight: 700; color: #000099">INFORMACION DE LAS CUENTAS ASOCIADAS</asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         </td>
         <td style="width: 25%" align="right"></td>
        </tr>
        

        <tr valign="top">
          <td style="width: 75%; background-color: #FF9933">
              <asp:Label ID="Label4" runat="server" Width="90%">.</asp:Label>
          </td>
          <td style="width: 25%" align="right"></td>
        </tr>
         <tr valign="top">
            <td style="width: 75%" colspan="1">
                <table id="Table1" class="EditControlsTable" cellspacing="0" cellpadding="0" border="0" style="width: 100%">
                    <tr valign="top">
                        <td  class="LabelCell" style="width: 25%; height: 19px;">
                            <asp:Label id="Label3" runat="server" Width="90%">Cuenta Contable</asp:Label>
                        </td>
                        <td class="ControlCell" style="width: 25%; height: 19px;">
                            <asp:TextBox id="txt_cuenta" runat = "server" Width="58%" CssClass="Digitar" 
                                TabIndex="1"/></td>
                        <td class="ControlCell" style="width: 25%; height: 19px;">
                            <asp:Button ID="btnGuardar_Cuenta" runat="server" cssClass="Boton" TabIndex="6" 
                                Text="Guardar Cuenta Asociada" ToolTip="Guardar el registro y quedar en el" 
                                Width="179px" />
                        </td>
                        <td class="ControlCell" style="width: 25%; height: 19px;">
                            <asp:Label ID="lblidDetalle" runat="server" Visible="False" Width="10px">ID</asp:Label>
                        </td>
                    </tr>
                    <tr valign="top">
                      <td style="background-color: #FF9933" colspan="4">
                          <asp:Label ID="Label1" runat="server" Width="90%">.</asp:Label>
                      </td>
                    </tr>
                    <tr valign="top">
                        <td class="LabelCell" colspan="4" style="height: 19px;">
                            <telerik:RadGrid ID="Rg_Listado" runat="server" AutoGenerateColumns="False" OnItemCommand="subCommandItem" 
                                GridLines="None" PageSize="40" ShowStatusBar="True" Skin="Simple" TabIndex="6" Width="99%">
                                <MasterTableView CommandItemDisplay="Top" DataKeyNames="Id" 
                                    NoDetailRecordsText="No hay información." 
                                    NoMasterRecordsText="No hay información." PageSize="20">
                                    <Columns>
                                        <telerik:GridTemplateColumn DefaultInsertValue="" HeaderText="No." 
                                            UniqueName="TemplateColumn2">
                                            <ItemTemplate>
                                                <asp:Label ID="lblno" runat="server" 
                                                    text="<%# ctype(CType(Container.Parent.Parent.Parent,RadGrid).DataSource,IList).IndexOf(Container.DataItem)+1 %>" />
                                                <asp:Label ID="lblid" runat="Server" Text="<%#Container.DataItem.Id%>" Visible="False" />
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn DataField="Id" DataType="System.Int32" HeaderText="Id" 
                                            ReadOnly="True" SortExpression="Id" UniqueName="Id" Visible="False">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Cuenta" HeaderText="Cuenta" 
                                            SortExpression="Cuenta" UniqueName="Cuenta">
                                            <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" 
                                                Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </telerik:GridBoundColumn>

                                    <telerik:GridButtonColumn ConfirmText="Desea eliminar este registro?" ConfirmDialogType="RadWindow"   HeaderTooltip = "Eliminar Cuenta Asociada ?" HeaderText ="X"
                                        ConfirmTitle="Borrar Item de la Orden de Compra"  CommandName="Eliminar" UniqueName="Borrar" ButtonType="ImageButton" ImageUrl="../Images/balde.gif">
                                        <ItemStyle Width="10px" HorizontalAlign ="Center" />
                                        <HeaderStyle HorizontalAlign ="Center"  />
                                    </telerik:GridButtonColumn>
                                        
                                    </Columns>
                                    <CommandItemSettings AddNewRecordImageUrl="~/Images/nothing.gif" 
                                        AddNewRecordText="" ExportToCsvText="Exportar a CSV" 
                                        ExportToExcelText="Exportar a Excel" ExportToPdfText="Exportar a PDF" 
                                        ExportToWordText="Exportar a Word" RefreshText="Actualizar" 
                                        ShowExportToCsvButton="True" ShowExportToExcelButton="True" 
                                        ShowExportToPdfButton="True" ShowExportToWordButton="True" />
                                    <PagerStyle FirstPageToolTip="Primera" LastPageToolTip="Ultima" 
                                        Mode="NumericPages" NextPagesToolTip="Próximas" NextPageToolTip="Próxima" 
                                        PagerTextFormat="Cambiar Página: {4} &amp;nbsp;Página &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;, registros &lt;strong&gt;{2}&lt;/strong&gt; a &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." 
                                        PrevPagesToolTip="Anteriores" PrevPageToolTip="Anterior" />
                                </MasterTableView>
                                <ClientSettings EnablePostBackOnRowClick="True" EnableRowHoverStyle="True">
                                    <Selecting AllowRowSelect="True" />
                                </ClientSettings>
                                <ExportSettings ExportOnlyData="True" filename="Cuentas" 
                                    HideStructureColumns="True" IgnorePaging="True" OpenInNewWindow="True">
                                </ExportSettings>
                                <SortingSettings SortedAscToolTip="Ordenar Ascendente" 
                                    SortedDescToolTip="Ordenar Descendente" 
                                    SortToolTip="Clic aqui para ordenar..." />
                                <PagerStyle Mode="NumericPages" />
                            </telerik:RadGrid>
                        </td>
                    </tr>
                </table>
            </td>
            <td style="width: 25%" align="right"></td>
        </tr>
    </table>
  
    
</asp:Panel>    


</asp:Content>

