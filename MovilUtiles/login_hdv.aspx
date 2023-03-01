<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login_hdv.aspx.cs" Inherits="WebApplication1.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1.0"/>

    <title>HDV - Informatica</title>

    <link href="css/estiloHDV.css" rel="stylesheet" />
</head>

<body>
<form id="form1" runat="server">
<div class="container">
   
    <div class="izq">
        <img src="img/img_sap.jpg" />
    </div>

     <div class="der1">
        <label for="user">&nbsp;Usuario</label>
        <asp:TextBox ID="t_usuario" runat="server" placeholder="Tu Usuraio" Height="16px" Width="129px"></asp:TextBox>
         <asp:Label ID="lbl_error" runat="server" Font-Bold="True" ForeColor="#FF3300" Text="..."></asp:Label>
      </div>
     <div class="der2">
        <label for="password">Contraseña</label>
        <asp:TextBox ID="t_Clave" runat="server" placeholder="Contraseña" Height="16px" TextMode="Password" Width="134px"></asp:TextBox>
     </div>
    
     <div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Ingresar" />
     </div>

</div>
</form>

</body>
</html>
