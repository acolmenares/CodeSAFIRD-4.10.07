<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Menu.ascx.vb" Inherits="Controles_Menu" %>
<telerik:RadMenu ID="RadMenu1" runat="server" Skin="Sunset">
    <Items>
        <telerik:RadMenuItem runat="server" Text="Inicio" NavigateUrl="~/Webforms/Principal.aspx">
        </telerik:RadMenuItem>
        <telerik:RadMenuItem runat="server" Text="Financiero">
            <Items>
                <telerik:RadMenuItem runat="server" NavigateUrl="~/Webforms/Ppto_IngresosList.aspx" Text="Ingresos">
                </telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" NavigateUrl="~/Webforms/Ppto_DistribucionList.aspx" Text="Distribuci&#243;n">
                </telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" NavigateUrl="~/Webforms/Ppto_AjustesList.aspx" Text="Ajustes Financeros">
                </telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" NavigateUrl="~/Webforms/Ppto_TrasladosList.aspx" Text="Traslados">
                </telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" IsSeparator="True" Text="Root RadMenuItem8">
                </telerik:RadMenuItem>                
                <telerik:RadMenuItem runat="server" NavigateUrl="~/Webforms/Ppto_AjustesAprobarList.aspx" Text="Aprobar Ajustes Financieros">
                </telerik:RadMenuItem>
            </Items>
        </telerik:RadMenuItem>
        <telerik:RadMenuItem runat="server" Text="Movimientos">
            <Items>
                <telerik:RadMenuItem runat="server" NavigateUrl="~/Webforms/Ppto_ContratosList.aspx" Text="Contratos" ToolTip="Sistema de Contratos">
                </telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" NavigateUrl="~/Webforms/OrdenCompraList.aspx" Text="Ordenes de Compra" >
                </telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" IsSeparator="True" Text="Root RadMenuItem8">
                </telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" Text="Aprobaci&#243;n de Contratos">
                    <Items>
                        <telerik:RadMenuItem runat="server" NavigateUrl="~/Webforms/Ppto_ContratosAprobarList.aspx?Refrescar=1&amp;TA=1" Text="Direcci&#243;n Financiera " ToolTip="Direcci&#243;n Financiera">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" NavigateUrl="~/Webforms/Ppto_ContratosAprobarList.aspx?Refrescar=1&amp;TA=2" Text="Direcci&#243;n General " ToolTip="Direcci&#243;n General" >
                        </telerik:RadMenuItem>
                    </Items>
                </telerik:RadMenuItem>                
                <telerik:RadMenuItem runat="server" Text="Aprobaci&#243;n de Ordenes de Compra">
                    <Items>
                        <telerik:RadMenuItem runat="server" NavigateUrl="~/Webforms/OrdenCompraAprobarList.aspx?Refrescar=1&amp;TA=1" Text="Log&#237;stica y Servicios " ToolTip="Oficial de Logística">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" NavigateUrl="~/Webforms/OrdenCompraAprobarList.aspx?Refrescar=1&amp;TA=2" Text="Finanzas y Adm. Regional " ToolTip="Oficial de Finanzas" >
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" NavigateUrl="~/Webforms/OrdenCompraAprobarList.aspx?Refrescar=1&amp;TA=6" Text="Coordinación de Logística " ToolTip="Coordinador Logística" >
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" NavigateUrl="~/Webforms/OrdenCompraAprobarList.aspx?Refrescar=1&amp;TA=3" Text="Coodinador Regional" ToolTip="Coordinaci&#243;n de la Regional">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" NavigateUrl="~/Webforms/OrdenCompraAprobarList.aspx?Refrescar=1&amp;TA=4" Text="Operaciones / M&amp;E " ToolTip="Director de Operaciones" >
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" NavigateUrl="~/Webforms/OrdenCompraAprobarList.aspx?Refrescar=1&amp;TA=5" Text="Direcci&#243;n Financiera" ToolTip="Administrac&#243;n y Finanzas Central">
                        </telerik:RadMenuItem>
                    </Items>
                </telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" NavigateUrl="~/Webforms/EliminarAprobaciones.aspx" Text="Deshabilitar Aprobaciones" ToolTip="Volver A Colocar el compromiso en su base inicial"/>

            </Items>
        </telerik:RadMenuItem>
        <telerik:RadMenuItem runat="server" Text="Externos">
            <Items>
                <telerik:RadMenuItem runat="server" Text="Pagos" NavigateUrl="~/Webforms/PagosList.aspx"/>
                <telerik:RadMenuItem runat="server" Text="Terceros" NavigateUrl="~/Webforms/TercerosList.aspx"/>
                <telerik:RadMenuItem runat="server" Text="Cargue de Documentos" NavigateUrl="~/Webforms/CargarDocumentos.aspx"/>
            </Items>
        </telerik:RadMenuItem>

        <telerik:RadMenuItem runat="server" Text="Tablas de Apoyo">
            <Items>
                <telerik:RadMenuItem runat="server" Text="Niveles" NavigateUrl="~/Webforms/NivelesList.aspx"/>
                <telerik:RadMenuItem runat="server" Text="Cuentas Presupuestales" NavigateUrl="~/Webforms/Ppto_CuentasList.aspx"/>
                <telerik:RadMenuItem runat="server" Text="Root RadMenuItem9" IsSeparator="True"/>
                <telerik:RadMenuItem runat="server" Text="Tipos de Unidad" NavigateUrl="~/Webforms/TiposUnidadList.aspx"/>
                <telerik:RadMenuItem runat="server" NavigateUrl="~/Webforms/ProductosList.aspx" Text="Productos"/>
                <telerik:RadMenuItem runat="server" NavigateUrl="~/Webforms/SucursalesList.aspx" Text="Sucursales"/>
            </Items>
        </telerik:RadMenuItem>
        <telerik:RadMenuItem runat="server" Text="Consultas">
            <Items>
                <telerik:RadMenuItem runat="server" NavigateUrl="~/Webforms/SaldosList.aspx" Text="Estado Financiero">
                </telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" NavigateUrl="~/Webforms/OrdenCompraSaldosList.aspx" Text="Saldos de Ordenes Compra">
                </telerik:RadMenuItem>
            </Items>
        </telerik:RadMenuItem>
    </Items>
</telerik:RadMenu>
