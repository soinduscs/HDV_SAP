<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Transf_Stock.aspx.cs" Inherits="MovilUtiles.Transf_Stock" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
  <meta http-equiv="Content-Type" content="text/html"; charset="utf-8"/>
  <meta name="viewport" content="width=device-width", initial-scale="1.0"/>
  <meta http-equiv="X-UA-Compatible" content="ie-edge"/>
    
  <title>HDV - Consumo mat. prima</title>

  <link rel="shortcut icon" href="img/favicon.ico" type="image/x-icon">
  <link rel="icon" href="img/favicon.ico" type="image/x-icon">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
  <link href="css/estiloHDV.css" rel="stylesheet" />

    <style type="text/css">
        .auto-style1 {
            width: 292px;
            height: 36px;
        }
    </style>

</head>

<body>

<form id="form1" runat="server">

<nav class="navbar navbar-inverse">
  <div class="container-fluid">
    <ul class="nav navbar-nav">
      <li class="active"><label for="user" class="navbar-text">
      <asp:Label ID="lbl_usuario" runat="server" Text="Usuario:"></asp:Label>
      </label></li>
      <a href="Menu_hdv.aspx" class="btn btn-primary btn-lg"><span class="glyphicon glyphicon-list-alt"></span> Menu Princial</a>
    </ul>
  </div>
</nav>

<div class="container">
  
    <div class="auto-style6">
        <asp:Label for="ddl_bodega" runat="server" Text="Label">Bodega</asp:Label>
        &nbsp;<br />
        <asp:DropDownList ID="DropDownList1" runat="server" Width="158px" Height="16px">
        </asp:DropDownList>
    </div>

    <div class="auto-style9">
        <asp:Label for="ddl_pasillo" runat="server" Text="Label">Pasillo</asp:Label>
        &nbsp;<br />
        <asp:DropDownList ID="DropDownList2" runat="server" Width="124px">
        </asp:DropDownList>
    </div>

        <div class="auto-style8">
    <asp:Label ID="nlote" runat="server" Text="Label">Lote</asp:Label>
        <br />
    <asp:TextBox ID="t_nlote" runat="server" placeholder="Lote" ReadOnly="True" Width="90px"></asp:TextBox>
    </div>
       &nbsp;<br />
    <div style="width: 295px"> 
    <asp:Label for="nposicion" runat="server" Text="Label">Descripcion</asp:Label>
        <br />
    <asp:TextBox ID="t_descripcion" runat="server" placeholder="Descripcion" ReadOnly="True" Width="259px"></asp:TextBox>
    </div>
       &nbsp;<br />
    <table class="auto-style5">
            <tr>
                <td class="auto-style4">Origen</td>
                <td class="auto-style5">Destino</td>
            </tr>
            <tr>
                <td class="auto-style4">        <asp:DropDownList ID="DropDownList3" runat="server" Width="137px" Height="16px">
        </asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList4" runat="server" Width="129px" Height="16px" CssClass="col-xs-offset-0">
            </asp:DropDownList></td>
            </tr>
            
        </table>
           &nbsp;<br />
    <div class="auto-style1">
    <asp:Label ID="ncantidad" runat="server" Text="Label">Cantidad</asp:Label>
        &nbsp;&nbsp;
    <asp:TextBox ID="t_ncantidad" runat="server" placeholder="Cantidad" ReadOnly="True" Width="52px"></asp:TextBox>
    </div>
    <br />
    <div style="width: 295px">
    &nbsp;
    <asp:Label ID="lfumigado" runat="server" Text="Label">Fumigado</asp:Label>
    &nbsp;
    <asp:TextBox ID="t_fumigado" runat="server" placeholder="Si o No" ReadOnly="True" Width="66px"></asp:TextBox>
    </div>
</div>
</form>
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
</body>
</html>
