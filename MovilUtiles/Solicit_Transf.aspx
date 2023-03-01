<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Solicit_Transf.aspx.cs" Inherits="MovilUtiles.Solicit_Transf" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
  <meta http-equiv="Content-Type" content="text/html"; charset="utf-8"/>
  <meta name="viewport" content="width=device-width", initial-scale="1.0"/>
  <meta http-equiv="X-UA-Compatible" content="ie-edge"/>
    
  <title>HDV - Solicitud de Transferencia</title>

  <link rel="shortcut icon" href="img/favicon.ico" type="image/x-icon">
  <link rel="icon" href="img/favicon.ico" type="image/x-icon">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
  <link href="css/estilo_stock_ubicacion.css" rel="stylesheet" />

</head>

<body>
<form id="form1" runat="server">

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

<div class="container">
  
    
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />

    <asp:GridView ID="Grid1" runat="server" Width="422px" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" Font-Size="Smaller">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            
            <asp:HyperLinkField DataTextField="DocEntry" HeaderText="N° Docum." Text="N° Docum." DataNavigateUrlFields="DocEntry" DataNavigateUrlFormatString = "Solicit_Transf1.aspx?DocEntry={0}" />
            
            <asp:BoundField DataField="CardName" HeaderText="Socio de Negocio" >
                <ItemStyle Font-Size="Smaller" />
            </asp:BoundField>
            
            <asp:BoundField HeaderText="De Almacén" DataField="Filler" >
            <ItemStyle Font-Size="Smaller" Width="60px" />
            </asp:BoundField>

            <asp:BoundField HeaderText="Fecha Venc." DataField="DocDate" >
            <ItemStyle Font-Size="Smaller" HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="U_NAME" HeaderText="Solicitante" Visible="False">
                <ItemStyle Font-Size="Smaller" HorizontalAlign="Left" />
            </asp:BoundField>

        </Columns>
        <EditRowStyle BackColor="#7C6F57" />
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#1C5E55" BorderColor="#CC6600" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#E3EAEB" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F8FAFA" />
        <SortedAscendingHeaderStyle BackColor="#246B61" />
        <SortedDescendingCellStyle BackColor="#D4DFE1" />
        <SortedDescendingHeaderStyle BackColor="#15524A" />
    </asp:GridView>

    &nbsp;&nbsp;&nbsp;&nbsp;
        
    &nbsp;<br />
    
</div>
</form>

  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

</body>
</html>

