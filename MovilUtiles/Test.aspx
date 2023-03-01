<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="MovilUtiles.Test" %>

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
  <link href="css/prueba.css" rel="stylesheet" />

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
      <a href="Page_Inter.aspx" class="btn btn-info btn-lg"><span class="glyphicon glyphicon-list-alt"></span> Menu de Ubicación</a>
    </ul>
  </div>
</nav>

<div class="contenido">

    <!-- Texto -->
    <div class="Lote">
        <asp:label for="lote" runat="server" text="Label">Lote</asp:label>
    </div>
    <!-- Numero de Lote -->
    <div class="NumLote">
            <asp:TextBox ID="t_lote" runat="server" placeholder="Nro de Lote" Width="98px"></asp:TextBox>
    </div>
    
    <!-- Boton de Consulta -->
    <div class="Consulta">
       <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Consulta" />  
    </div>

    <!-- Articulo -->
    <div class="articulo">
        <asp:Label for="darticulo" runat="server" Text="Label">Articulo</asp:Label>
    </div> 
    <!-- Descripcion del Articulo -->
    <div class="DescArticulo">
        <asp:TextBox ID="t_darticulo" runat="server" placeholder="Descripción del Articulo" ReadOnly="True" Width="280px"></asp:TextBox>
    </div>
 
    <!-- Estado del Lote -->
    <div class="Estado">
        <asp:Label for="estado" runat="server" Text="Label">Estado</asp:Label>
    </div>
    <div class="DescEstado">
        <asp:TextBox ID="t_estado" runat="server" placeholder="Estado" ReadOnly="True" Width="91px"></asp:TextBox>
    </div>

    <!-- Fumigado (Si o No) -->
    <div class="Fumigado">
        <asp:Label ID="lfumigado" runat="server" Text="Label">Fumigado</asp:Label>
     </div>
     
    <div class="DescFumigado">
        <asp:TextBox ID="t_fumigado" runat="server" placeholder="Si o No" ReadOnly="True" Width="49px"></asp:TextBox>
    </div>

    <!-- Cliente -->
    <div class="Cliente">
        <asp:Label ID="cliente" runat="server" Text="Label">Nombre Cliente</asp:Label>
    </div>

    <!-- Nombre del Cliente -->
    <div class="DescCliente">    
        <asp:TextBox ID="t_cliente" runat="server" placeholder="Nombre Cliente" ReadOnly="True" Width="280px"></asp:TextBox>
    </div>

    <!-- Stock del Articulo -->
    <div class="Stock">
        <asp:Label ID="stock" runat="server" Text="Label">Stock</asp:Label>
    </div>
    <div class="DescStock">
        <asp:TextBox ID="t_stock" runat="server" placeholder="Stock" ReadOnly="True" Width="80px"></asp:TextBox>
    </div>

    <!-- Unidad de Medida -->
    <div class="UniMedida">
        <asp:Label ID="umedida" runat="server" Text="Label">Uni/Medida</asp:Label>
    </div>
    <div class="DescUniMedi">
        <asp:TextBox ID="t_umedida" runat="server" placeholder="Uni/Medida" ReadOnly="True" Width="73px"></asp:TextBox>
    </div>

    <!-- ubicacion actual -->
    <div class="UbiActual">
        <asp:Label ID="uactual" runat="server" Text="Label">Ubicacion Actual</asp:Label>
    
        <asp:TextBox ID="t_uactual" runat="server" placeholder="Ubicacion Actual" ReadOnly="True" Width="124px"></asp:TextBox>
    </div>

    <!-- Nueva Ubicacion -->
    <div class="NuevaUbic">
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

    <!-- BTN Modificar Ubicacion -->
    <div class="ModUbic">
            <button type="button" class="btn btn-info btn-lg">Modificar Ubicacion</button>
    </div>

</div>
</form>

  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

</body>
</html>
