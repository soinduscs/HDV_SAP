<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ubicacion.aspx.cs" Inherits="MovilUtiles.ubicacion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
  <meta http-equiv="Content-Type" content="text/html"; charset="utf-8"/>
  <meta name="viewport" content="width=device-width", initial-scale="1.0"/>
  <meta http-equiv="X-UA-Compatible" content="ie-edge"/>
    
  <title>HDV - Ubicacion</title>

  <link rel="shortcut icon" href="img/favicon.ico" type="image/x-icon">
  <link rel="icon" href="img/favicon.ico" type="image/x-icon">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
  <link href="css/estiloHDV.css" rel="stylesheet" />

    <style type="text/css">
        .auto-style1 {
            width: 100px;
        }
        .auto-style2 {
            height: 20px;
        }
        </style>

</head>

<body>

<form id="form1" runat="server">

<!-- Cabecera -->
<nav class="navbar navbar-inverse">
  <div class="container-fluid">
    <ul class="nav navbar-nav">
      <li class="active"><label for="user" class="navbar-text">
      <asp:Label ID="lbl_usuario" runat="server" Text="Usuario:"></asp:Label>
      </label></li>
      <a href="Page_Inter.aspx" class="btn btn-primary btn-lg"><span class="glyphicon glyphicon-list-alt"></span> Menu de Ubicación - v 5.5</a>
    </ul>
  </div>
</nav>

<div class="container">

<!-- Numero de Lote -->
    <div style="width: 251px">
        <asp:label for="lote" runat="server" text="Lote"></asp:label>
        <br />
        <asp:TextBox ID="t_lote" runat="server" placeholder="Nro de Lote" Width="98px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" class="btn btn-primary btn-md" OnClick="Button1_Click" Text="Consulta" />
        &nbsp;
    </div>
        
<br />

<!-- Descripcion del Articulo -->
    <div style="width: 295px">
        <asp:Label for="darticulo" runat="server" Text="Label">Articulo</asp:Label>
        <br />
        <asp:TextBox ID="t_darticulo" runat="server" placeholder="Descripción del Articulo" ReadOnly="True" Width="280px"></asp:TextBox>
        &nbsp;
    </div>
    
<br />

<!-- Estado del Lote y Fumigado (Si o No)-->
<table>
  <tr>
    <th><asp:Label for="estado" runat="server" Text="Label">Estado</asp:Label></th>
    <th><asp:Label ID="lfumigado" runat="server" Text="Label">Fumigado</asp:Label></th>
  </tr>
  <tr>
    <td><asp:TextBox ID="t_estado" runat="server" placeholder="Estado" ReadOnly="True" Width="91px"></asp:TextBox></td>
    <td><asp:TextBox ID="t_fumigado" runat="server" placeholder="Si o No" ReadOnly="True" Width="67px"></asp:TextBox></td> 
  </tr>
</table>

<br />

<!-- Nombre del Cliente -->
    <div style="width: 296px; height: 56px;">
        <asp:Label ID="cliente" runat="server" Text="Label">Nombre Cliente</asp:Label>
        <br />
        <asp:TextBox ID="t_cliente" runat="server" placeholder="Nombre Cliente" ReadOnly="True" Width="280px"></asp:TextBox>
    </div>

<br />


<!-- Stock del Articulo y Unidad de Medida-->
<table>
  <tr>
    <th><asp:Label ID="stock" runat="server" Text="Label">Stock</asp:Label></th>
    <th><asp:Label ID="umedida" runat="server" Text="Label">Uni/Medida</asp:Label></th>
  </tr>
  <tr>
    <td><asp:TextBox ID="t_stock" runat="server" placeholder="Stock" ReadOnly="True" Width="80px"></asp:TextBox></td>
    <td><asp:TextBox ID="t_umedida" runat="server" placeholder="Uni/Medida" ReadOnly="True" Width="77px"></asp:TextBox></td> 
  </tr>

</table>

    <br />

<table>
  <tr>
    <th class="auto-style2"><asp:Label ID="stock0" runat="server" Text="Ubicacion Actual"></asp:Label></th>
  </tr>

  <tr>
    <th class="auto-style2"><asp:TextBox ID="t_uactual" runat="server" placeholder="Ubicacion Actual" ReadOnly="True" Width="370px"></asp:TextBox></th>
  </tr>

</table>

    <br />

<table>
  <tr>
    <th class="auto-style2"><asp:Label ID="umedida0" runat="server" Text="Bins"></asp:Label></th>
  </tr>

  <tr>
    <th class="auto-style2"><asp:TextBox ID="t_bins" runat="server" placeholder="Cant. Bins" ReadOnly="True" Width="100px"></asp:TextBox></th>
  </tr>

</table>

<br />

<!-- ubicacion actual -->

<!-- Nueva Ubicacion -->
    <div style="width: 328px">
    <asp:Label for="pubicacion" runat="server" Text="Label">Nueva Ubicacion</asp:Label>
    <br />
    <label><asp:DropDownList ID="ddl_bodega" runat="server" AutoPostBack="True" Width="100%" OnSelectedIndexChanged="ddl_bodega_SelectedIndexChanged">
    </asp:DropDownList></label>
    &nbsp; &nbsp;
    <label><asp:DropDownList ID="ddl_pasillo" runat="server" AutoPostBack="True" Width="100%" OnSelectedIndexChanged="ddl_pasillo_SelectedIndexChanged" >
    </asp:DropDownList></label>
    &nbsp; &nbsp;
    <label><asp:DropDownList ID="ddl_ubicacion" runat="server" Width="100%">
    </asp:DropDownList></label>
    &nbsp; &nbsp;
    </div>

<br />

    <div class="auto-style1">
        <asp:Button ID="grabar" runat="server" class="btn btn-primary btn-md" Text="Modificar Ubicación" OnClick="Grabar_Click" Width="150px" />
    </div>

</div>
</form>

  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

</body>
</html>
