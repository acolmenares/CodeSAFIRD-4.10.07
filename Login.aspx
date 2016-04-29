<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Login.aspx.vb" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
   <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
   <meta name="author" content="Ricardo Ortiz"/>
   <meta name="description" content="Operaciones y Monitoreo"/>
   <title>Contact - SAFIRD</title>
   <link rel="stylesheet" type="text/css" media="all" href="Styles/main1.css"/>
   <link rel="stylesheet" type="text/css" media="all" href="colorschemes/colorscheme9/colorscheme.css"/>
   <link rel="stylesheet" type="text/css" media="all" href="Styles/style1.css"/>
   <script type="text/javascript" src="live_tinc.js"></script>
      <style type="text/css">
          .style1
          {
              width: 724px;
              height: 185px;
          }
          </style>
   </head>

<body id="main_body"  >
<form id="id_form" runat="server" >
      
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table  border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                <div id="container" >
                    <div id="header">
                        <div id="logo"></div>
                        <div id="key_visual"><img alt="" class="style1" src="Images/Captura.JPG" /></div>
                    </div>
                    <div id="main_container">
                        <table id="layout_table">
                            <tr>
                                <td id="right_column" style="width: 206px">
                                    <div id="sub_container1">
                                        <div id="main_nav_container">
                                            <div id="sub_nav_container">
                                                <img src="Images/22269817.jpg" style="width: 92px; height: 117px" /></div>
                                        </div>
                                    </div>
                                </td>
                                <td id="left_column">
                                    <div id="sub_container2" align="left" >
                                        <div id="slogan">Sistema de Administracion y Finanzas<br />
                                        </div>
                                        <div class="content" id="content_container">
                                            <table runat="server"  ID="tbl_principal"   style="width: 80%" cellpadding="0" cellspacing="0" align="left">
                                                <tr>
                                                    <td align="center" colspan="2">
                                                        <asp:Label ID="Label31" runat="server" Text="Acceso al Aplicativo" Width="90%"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 40%" align="center">
                                                        <asp:Label ID="Label1" runat="server" Text="Usuario" Width="80%"></asp:Label>
                                                    </td>
                                                    <td style="width: 40%" align="center">
                                                        <telerik:RadTextBox ID="txt_login" runat="server" Width="80%" MaxLength="10" 
                                                            LabelWidth="40%" Resize="None" Skin="Telerik"></telerik:RadTextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 40%" align="center">
                                                        <asp:Label ID="Label2" runat="server" Text="Contraseña" Width="80%"></asp:Label>
                                                    </td>
                                                    <td style="width: 40%" align="center">
                                                        <telerik:RadTextBox ID="txt_contrasena" runat="server" Width="80%" 
                                                            MaxLength="20" TextMode="Password" Skin="Telerik"></telerik:RadTextBox></td>
                                                </tr>
                                                <tr>
                                                    <td align="center" style="width: 40%">
                                                        <asp:Label ID="Label3" runat="server" Text="Proyecto" Width="80%"></asp:Label></td>
                                                    <td align="center" style="width: 40%">
                                                        <asp:DropDownList ID="ddl_Proyecto" runat="server" Width="90%">
                                                            <asp:ListItem Value="1">PRM V</asp:ListItem>
                                                            <asp:ListItem Value="2">PRM VI</asp:ListItem>
                                                            <asp:ListItem Value="7">PRM VII</asp:ListItem>
                                                            <asp:ListItem Selected="True" Value="7">PRM VII</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 40%" align="center">
                                                        <asp:Label ID="lbl_error" runat="server" ForeColor="Red" Text="Usuario o Contraseña incorrecta"
                                                            Width="94%" Visible="False"></asp:Label></td>
                                                    <td style="width: 40%" align="center">
                                                        <asp:Button ID="imgok" runat="server" Text="Ingresar" Width="100px" /></td>
                                                </tr>
                                            </table>                
                                        </div>
                                    </div>
                                    <div id="sub_container3"></div>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div id="footer_text">
                        SAFIRD : Manejo Administrativo, Presupuestal y Financiero.</div>
                </div>
            </td>
        </tr>
    </table> 
</form>
</body>
</html>
