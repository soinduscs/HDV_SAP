<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="prueba.aspx.cs" Inherits="MovilUtiles.prueba" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    

        <label for="user">Nombre</label>
      </div>
      <div class="auto-style1">
          <asp:TextBox ID="t_email" runat="server" placeholder="Tu e-mail" Height="17px"></asp:TextBox>
&nbsp;</div>
    </div>
    <div class="row">
      <div class="col-25">
        <label for="password">Contraseña</label>
      </div>
      <div class="auto-style2">
        &nbsp;<asp:TextBox ID="t_Clave" runat="server" placeholder="Contraseña" Height="27px" TextMode="Password"></asp:TextBox>
&nbsp;</div>
        <asp:Label ID="lbl_error" runat="server" Font-Bold="True" ForeColor="#FF3300" Text="..."></asp:Label>
    </div>
    </div>
    </form>
</body>
</html>
