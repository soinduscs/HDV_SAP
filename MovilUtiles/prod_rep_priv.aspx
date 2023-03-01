<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="principal.aspx.cs" Inherits="WebApplication1.principal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>PRODUCTORES / REPORTES PRIVADOS</title>
  
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link href="css/estiloHDV.css" rel="stylesheet"/>
  <link href="css/reportes.css" rel="stylesheet"/>
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
  <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css"/>
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    
</head>
<body>

<form id="form1" runat="server">
<nav class="menu">
  <div class="container-fluid">
    <ul>
      <li><a href="login_hdv.aspx">CLIENTES</a></li>
      <li><a href="login_hdv.aspx">CLIENTES DE SERVICIOS INDUSTRIALES</a></li>
      <li><a href="login_hdv.aspx">FINANZAS</a></li>
    </ul>
  </div>
</nav>
<nav class="menu1">
  <div class="container-fluid">
    <ul>
      <li><a href="principal.aspx">INICIO</a></li>
      <li><a href="productores.aspx">VOLVER A PRODUCTORES HDV</a></li>
      <li><a href="login_hdv.aspx">CAPA</a></li>
      <li><a href="login_hdv.aspx">CANOGAL</a></li>
      <li><a href="login_hdv.aspx">CLUB HDV</a></li>
      <li><a href="login_hdv.aspx">INDUSTRIA NUECES</a></li>
      <li><a href="login_hdv.aspx">INDUSTRIA ALMENDRAS</a></li>
    </ul>
  </div>
</nav>

<nav class="navbar navbar-inverse">
  <div class="container-fluid">
    <div class="navbar-header">
      <a class="navbar-brand" href="#">PRODUCTOR HDV: AGRICOLA EL ROBLE LIMITADA / USUARIO: RAMON ARAYA</a>
    </div>
  </div>
</nav>

<div class="gallery">
  <a target="_blank" href="reportes.aspx">
    <img src="img/Nuez_calidad.png" alt="5Terre" width="600" height="400">
  </a>
  <div class="desc">Reportes de Pesaje</div>
</div>

<div class="gallery">
  <a target="_blank" href="img_forest.jpg">
    <img src="img/cuenta-corriente.jpg" alt="Forest" width="600" height="400">
  </a>
  <div class="desc">Cuenta Corriente</div>
</div>

<div class="gallery">
  <a target="_blank" href="img_lights.jpg">
    <img src="img/LAB-fruta.jpg" alt="Northern Lights" width="600" height="400">
  </a>
  <div class="desc">Reportes de Calidad</div>
</div>

<div class="gallery">
  <a target="_blank" href="img_mountains.jpg">
    <img src="img/economia.jpg" alt="Mountains" width="600" height="400">
  </a>
  <div class="desc">Reportes de Liquidacion</div>
</div>

    </form>
</body>
</html>