<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Page_Inter.aspx.cs" Inherits="MovilUtiles.Page_Inter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
  <meta http-equiv="Content-Type" content="text/html"; charset="utf-8"/>
  <meta name="viewport" content="width=device-width", initial-scale="1.0"/>
  <meta http-equiv="X-UA-Compatible" content="ie-edge"/>

  <title>Menu Principal</title>

  <link rel="shortcut icon" href="img/favicon.ico" type="image/x-icon">
  <link rel="icon" href="img/favicon.ico" type="image/x-icon">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
  <link rel="stylesheet" href="css/estilo_pi.css"/>

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

<div class="contenedor">
    <main class="contenido">
        <a href="ubicacion.aspx"><img  src="img/def_ubicacion.jpg" alt="Definir Ubicación" width="150" height="100"/></a>
    </main>
    <div class="desc1">Definir Ubicación</div> 
    
     <aside class="sidebar">
         <a href="Stock_Ubicacion.aspx"><img src="img/stock_ubicacion.jpg" alt="Stock de Ubicación" width="150" height="100"/></a> 
     </aside>
    <div class="desc2">Stock de Ubicación</div>
</div>
</form>

  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

</body>
</html>
