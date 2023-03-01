<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Consumo_of.aspx.cs" Inherits="MovilUtiles.Consumo_of" %>

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
  
    <div style="width: 251px">
    <asp:label for="lote" runat="server" text="Label">Lote</asp:label>
    <br />
    <asp:TextBox ID="t_lote" runat="server" placeholder="Nro de Lote" Width="98px"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Consulta" />
    &nbsp;</div>

    <div style="width: 295px">
    <asp:Label for="darticulo" runat="server" Text="Label">Articulo</asp:Label>
    <br />
    <asp:TextBox ID="t_darticulo" runat="server" placeholder="Descripción del Articulo" ReadOnly="True" Width="280px"></asp:TextBox>
    &nbsp;</div>
    <br />

    <div style="width: 295px">
    <asp:Label for="almacen" runat="server" Text="Almacén"></asp:Label>
    <asp:TextBox ID="t_almacen" runat="server" placeholder="Almacen" ReadOnly="True" Width="67px"></asp:TextBox>
    &nbsp;
    <asp:Label ID="lfumigado" runat="server" Text="Stock"></asp:Label>
    &nbsp;
    <asp:TextBox ID="t_stock" runat="server" placeholder="Stock" ReadOnly="True" Width="66px"></asp:TextBox>
    </div>
    <br />

    <div class="auto-style1">
    <asp:Label ID="bins" runat="server" Text="Bins"></asp:Label>
    &nbsp;
    <asp:TextBox ID="t_bins" runat="server" placeholder="Bins" ReadOnly="True" Width="49px"></asp:TextBox>
    <asp:Label ID="volteados" runat="server" Text="Volteados"></asp:Label>
    &nbsp;
    <asp:TextBox ID="t_volteados" runat="server" placeholder="Volteados" ReadOnly="True" Width="47px"></asp:TextBox>
    </div>

    <div style="width: 155px">
    <asp:Label ID="numof" runat="server" Text="Orden de Fabricación"></asp:Label>
    <br />
    <asp:TextBox ID="t_numof" runat="server" placeholder="Num. OF" ReadOnly="True" Width="124px"></asp:TextBox>
    </div>

    <br />

    <div class="auto-style1">
    <asp:Button ID="grabar" runat="server" Text="Generar Consumo" OnClick="Grabar_Click" Width="180px" />
    &nbsp; &nbsp;
    </div>

</div>
</form>

  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

    <p>
&nbsp;&nbsp;&nbsp;
    </p>

</body>
</html>

