<%@ Page Title="" Language="VB" MasterPageFile="~/Controles/MasterPage.master" AutoEventWireup="false" CodeFile="NivelesList.aspx.vb" Inherits="Webforms_NivelesList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <telerik:RadScriptManager ID="RadScriptManager1" runat="server"/>
    <asp:Panel runat="server" ID="pnl_principal" DefaultButton ="btn_GrabarNivel" Width ="100%">
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="NIVEL" />
    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr valign="top">
        <td style="width: 75%"> 
            <asp:Label ID="lbl_Titulo" runat="server" Text="MANEJO GENERAL DE NIVELES PRESUPUESTALES" Width="90%" CssClass="TitTitulo" BackColor="PeachPuff"></asp:Label><br />
            <asp:Label ID="lblMensaje" runat="server" CssClass="TitMensaje" Text="_" Width="90%" Visible="False"/></td>
        <td style="width: 25%" align="right">
            <asp:ImageButton ID="btn_actualizar" runat="server" ImageUrl="~/Images/Reload.jpg" ToolTip="Actualizar la vista actual." TabIndex="7" />&nbsp;
            <asp:ImageButton ID="btn_cerrar" runat="server" ImageUrl="~/Images/Stop.jpg" ToolTip="Cerrar - Volver a la vista anterior." TabIndex="8" />
            <asp:ImageButton ID="btn_home" runat="server" ImageUrl="~/Images/Home.jpg" ToolTip="Ir al Inicio." TabIndex="9" />&nbsp;</td>
        </tr> 
     </table>        
     <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr valign ="top">
            <td align="center" colspan="2" style="height: 16px">
                <asp:Label ID="Label1" runat="server" Text="Arbol de Distribución de Niveles" CssClass="Labelsdigitar"></asp:Label></td>
            <td align="center" colspan="2" style="height: 16px">
                <asp:Label ID="Label2" runat="server" Text="Creación Manual de Item" CssClass="Labelsdigitar"></asp:Label></td>
        </tr>
        <tr valign ="top">
            <td rowspan="7" colspan="2">
                <telerik:RadTreeView ID="RTree_Niveles" runat="server" Skin="Outlook" Width="94%" AllowNodeEditing="True" BorderColor="NavajoWhite"
                 BorderStyle="Groove">
                <ContextMenus>
                    <telerik:RadTreeViewContextMenu ID="MainContextMenu" runat="server">
                        <Items>
                            <telerik:RadMenuItem Value="New" Text="Nuevo" ImageUrl ="../Images/nueva.jpg"  >
                            </telerik:RadMenuItem>
                            <telerik:RadMenuItem Value="Edit" Text="Editar" ImageUrl ="../Images/edit1.gif" >
                            </telerik:RadMenuItem>
                            <telerik:RadMenuItem Value="Delete" Text="Eliminar" ImageUrl ="../Images/delete.gif" >
                            </telerik:RadMenuItem>
                        </Items>
                        <CollapseAnimation Type="none" />
                    </telerik:RadTreeViewContextMenu>
                </ContextMenus>                    
                    <DataBindings>
                        <telerik:RadTreeNodeBinding  />
                    </DataBindings>
                </telerik:RadTreeView>
                
            </td>
            <td style="width: 25%;">
            </td>
            <td style="width: 25%;">
            </td>
        </tr>
        <tr valign ="top">
            <td style="width: 25%;">
                <asp:Label ID="Label3" runat="server" Text="Descripción Nivel" CssClass="Labelsdigitar"></asp:Label></td>
            <td style="width: 25%;">
                <asp:TextBox ID="txt_nombre" runat="server" CssClass="Digitar" Width="94%" TabIndex="1"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_nombre" runat="server" ControlToValidate="txt_nombre"
                    EnableClientScript="False" ErrorMessage="Falta la descripción del nivel" ValidationGroup="NIVEL">*</asp:RequiredFieldValidator></td>
        </tr>
        <tr valign ="top">
            <td style="width: 25%">
                <asp:Label ID="Label4" runat="server" Text="Nivel que lo administra" CssClass="Labelsdigitar"></asp:Label></td>
            <td style="width: 25%">
                <asp:DropDownList ID="ddl_niveles" runat="server" CssClass="drop01" AutoPostBack="True" TabIndex="2">
                </asp:DropDownList></td>
        </tr>
         <tr valign ="top">
             <td colspan="2">
                 <asp:Label ID="lbl_descripcion_nivel" runat="server"></asp:Label></td>
         </tr>
        <tr valign ="top">
            <td align="center" colspan="2" style="height: 20px">
                <asp:Button ID="btn_GrabarNivel" runat="server" CssClass="Boton" Text="Grabar Nivel" Width="150px" TabIndex="3" />
                &nbsp; &nbsp; &nbsp;<asp:Button ID="btn_LimpiarCampos" runat="server" CssClass="Boton" Text="Limpiar Campos" Width="150px" TabIndex="4" /></td>
        </tr>
        <tr valign ="top">
            <td colspan="2">
                <hr style="color: #ff9933" />
            </td>
        </tr>
        <tr valign ="top">
            <td align="center" colspan="2">
                <asp:Button ID="Btn_GrabarArbol" runat="server" CssClass="Boton" Text="Grabar Arbol" Width="150px" TabIndex="5" />
                &nbsp; &nbsp;
                <asp:Button
                    ID="btn_RecargarArbol" runat="server" CssClass="Boton" Text="Recargar Arbol" Width="150px" TabIndex="6" /></td>
        </tr>
    </table>
    </asp:Panel>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="LoadingPanel2">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btn_actualizar">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RTree_Niveles" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btn_GrabarNivel">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="txt_nombre" />
                    <telerik:AjaxUpdatedControl ControlID="ddl_niveles" />
                    <telerik:AjaxUpdatedControl ControlID="lbl_descripcion_nivel" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btn_LimpiarCampos">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="txt_nombre" />
                    <telerik:AjaxUpdatedControl ControlID="ddl_niveles" />
                    <telerik:AjaxUpdatedControl ControlID="lbl_descripcion_nivel" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="Btn_GrabarArbol">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RTree_Niveles" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btn_RecargarArbol">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RTree_Niveles" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="LoadingPanel2" runat="server" BackgroundPosition="Right"
        Height="0px" Transparency="50">
        <asp:Image ID="Image1" runat="server" AlternateText="Cargando..." ImageUrl="~/Images/loading.gif" />
    </telerik:RadAjaxLoadingPanel>

</asp:Content>

