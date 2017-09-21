<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Target.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=8"/>
    <title>TargetApp</title>    
    <script type="text/javascript">
        function abrir_ventana() {
            var window_width = 500;
            var window_height = 250;
            var newfeatures = 'scrollbars=no,resizable=no';
            var window_top = (screen.height - window_height) / 2;
            var window_left = (screen.width - window_width) / 2;
            newWindow = window.open('AccesoDenegado.aspx', 'titulo', 'width=' + window_width + ',height=' + window_height + ',top=' + window_top + ',left=' + window_left + ',features=' + newfeatures + '');
        }
    </script>
 </head>
<body style="background-image:url(images/Login/login_background.gif); background-repeat:repeat; font-family: Trebuchet MS, Verdana, Tahoma, Arial !important; font-size:14px" scroll="no">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>   
            
                <table border="0" width="490" cellspacing="0" cellpadding="0" class="normal" align="center" style="margin-top:80px;">
                    <tr>
                        <td><img border="0" src="images/Login/login_top_left.gif" alt="" width="21" height="48"></td>
                        <td style="background-image:url(images/Login/login_top.gif)" width="100%">
                                <span>.: TargetApp</span>
                        </td>
                        <td><img border="0" src="images/Login/login_top_right.gif" alt="" width="21" height="48"></td>
                    </tr>
                    <tr>
                        <td style="background-image:url(images/Login/login_left.gif)">&nbsp;</td>
                        <td bgcolor="#FFFFFF">
                            <p>
			                    <font color="#696969">
				                    Sistema TargetApp - Banco Santander S.A.
				                </font>
			                </p>
                            <table id="idlogin" class="normal" border="0">
                                <tr>
                                    <td rowspan="3" valign="top">
                                        <img src="images/Login/Login.jpg" alt="" width="210" height="78"/>
                                    </td>                                
                                </tr>
		                       <tr>
                                    
  
                                    <th style="color:gray; font-size:small"; width="100%" >
                                        Ingrese Rut Usuario:                                       
                                        
                                       <asp:TextBox onkeypress="return isNumberKey(event)"  MaxLength="9" runat="server" ID="txtUsuario" Width="80px">
                                        </asp:TextBox>                                   
                                     </th>

                                </tr>
                                <tr>                                         
				                    <td  style="text-align:right; width="100%">
                                        <asp:Button ID="btnLogin" runat="server" Text="Ingresar"  CssClass="button_big" onclick="btnIngresar_Click"/>                             
                                    </td>
				                </tr>				                                        
			                </table>
            			
			                <p align="center" style="font-size:x-small">
		                            <font color="gray">
		                                Optimizado para Google Chrome-*-- o superior, resolución 1024x768<br>
		                                Grupo Santander - Todos los derechos son reservados <%= DateTime.Now.Year %>                                        
		                            </font>
                                </p> 

                            </td>
		                <td style="background-image:url(images/Login/login_right.gif)">&nbsp;</td>
	                </tr>
                    <tr>
                      <td><img border="0" src="images/Login/login_bottom_left.gif" alt="" width="21" height="21" /></td>
                      <td style="background-image:url(images/Login/login_bottom.gif)"></td>
                      <td><img border="0" src="images/Login/login_bottom_right.gif" alt="" width="21" height="21" /></td>
                    </tr>
                </table>
                    
    </form>
</body>
</html>
