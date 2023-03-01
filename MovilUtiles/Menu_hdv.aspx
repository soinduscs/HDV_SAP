<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu_hdv.aspx.cs" Inherits="MovilUtiles.Menu_hdv" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
<meta http-equiv="Content-Type" content="text/html"; charset="utf-8"/>
<meta name="viewport" content="width=device-width", initial-scale="1.0"/>
<meta http-equiv="X-UA-Compatible" content="ie-edge"/>
    
    <title>Menu HDV-Web</title>

  <link rel="shortcut icon" href="img/favicon.ico" type="image/x-icon">
  <link rel="icon" href="img/favicon.ico" type="image/x-icon">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
  <link href="css/reportes.css" rel="stylesheet"/>

</head>
<body>

<form id="form1" runat="server">
<fieldset>
<nav class="navbar navbar-inverse">
    
  <div class="container-fluid">

    <ul class="nav navbar-nav">
       <li class="active"><label for="user" class="navbar-text">
       <img src="Img/logo_nvar.png" class="nav"/>
       <asp:Label ID="lbl_usuario" runat="server" Text="Usuario:"></asp:Label>
      </label></li>
    </ul>
  </div>
</nav>

<div class="responsive">
<div class="gallery">
  <a href="Page_Inter.aspx">
    <img src="img/temp/Ubicacion.jpg" alt="Ubicacion"/>
  </a>
  <div class="desc">Ubicacion</div>
</div>
</div>

<div class="responsive">
<div class="gallery">
  <a href="Consumo_of.aspx">
    <img src="img/temp/OF.jpg" alt="Consumo"/>
  </a>
  <div class="desc">Consumo de OF</div>
</div>
</div>

<div class="responsive">
<div class="gallery">
  <a href="Solicit_Transf.aspx">
    <img src="img/temp/transf_stock.jpg" alt="Transferencia"/>
  </a>
  <div class="desc">Transferencia de Stock</div>
</div>
</div>

<div class="responsive">
<div class="gallery">
  <a href="#">
    <img src="img/temp/PackingList.jpg" alt="packing"/>
  </a>
  <div class="desc">Packing List</div>
</div>
</div>

<div class="clearfix"></div>

</fieldset>
</form>

  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

</body>
</html>