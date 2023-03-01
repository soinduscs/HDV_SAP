<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Solicit_Transf1.aspx.cs" Inherits="MovilUtiles.Solicit_Transf1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
  <meta http-equiv="Content-Type" content="text/html"; charset="utf-8"/>
  <meta name="viewport" content="width=device-width", initial-scale="1.0"/>
  <meta http-equiv="X-UA-Compatible" content="ie-edge"/>
    
  <title>HDV - Solicitud de traslado</title>

  <link rel="shortcut icon" href="img/favicon.ico" type="image/x-icon">
  <link rel="icon" href="img/favicon.ico" type="image/x-icon">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
  <link href="css/estiloHDV.css" rel="stylesheet" />

    <style type="text/css">
        .auto-style1 {
            width: 292px;
            height: 36px;
        }
        .auto-style2 {
            width: 295px;
        }
        .auto-style3 {
            width: 104px;
        }
        .auto-style4 {
            width: 101px;
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
      <a href="Menu_hdv.aspx" class="btn btn-info btn-lg"><span class="glyphicon glyphicon-list-alt"></span> Menu Princial</a>
    </ul>
  </div>
</nav>

<div class="container">
  
    <div class="auto-style2">
      <div class="auto-style3">

          Solicitud<br />
    <asp:TextBox ID="t_docentry" runat="server" placeholder="Bins" ReadOnly="True" Width="70px"></asp:TextBox>

      </div>

        <div class="auto-style4">

            Solicitante<br />
    <asp:TextBox ID="t_solicitante" runat="server" placeholder="Bins" ReadOnly="True" Width="70px"></asp:TextBox>

      </div>

                <div class="auto-style4">

                    De almacén<br />
    <asp:TextBox ID="t_de_almacen" runat="server" placeholder="Bins" ReadOnly="True" Width="70px"></asp:TextBox>

      </div>


    </div>

    <div class="auto-style2">
    <asp:label for="lote" runat="server" text="Label">Lote</asp:label>
    <br />
    <asp:TextBox ID="t_lote" runat="server" placeholder="Nro de Lote" Width="98px"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Capturar" />
    &nbsp;</div>

    <div style="width: 295px">
    <asp:TextBox ID="t_referencia" runat="server" placeholder="Descripción del Articulo" ReadOnly="True" Width="280px" ForeColor="#FF3300"></asp:TextBox>
    &nbsp;</div>

    <br />

    <asp:GridView ID="Grid1" runat="server" Width="422px" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" Font-Size="Smaller">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            
            <asp:BoundField DataField="ItemName" HeaderText="Artículo" >
            </asp:BoundField>
            
            <asp:BoundField DataField="MdAbsEntry" HeaderText="Lote" />
            <asp:BoundField HeaderText="Lote Ref." DataField="MdAbsEntry1" />
            <asp:BoundField DataField="AllocQty" HeaderText="Peso" >
            
            <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            
            <asp:BoundField HeaderText="De" DataField="WhsCode" >
            </asp:BoundField>

            <asp:BoundField DataField="FromWhsCod" HeaderText="Para" />
            <asp:BoundField DataField="LineNum" HeaderText="LineNum" />

            <asp:BoundField DataField="ItemCode" HeaderText="ItemCode" />
            <asp:BoundField DataField="OcrCode" HeaderText="Dimension1" />
            <asp:BoundField DataField="OcrCode2" HeaderText="Dimension2" />
            <asp:BoundField DataField="OcrCode3" HeaderText="Dimension3" />

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

    <br />

    
    <br />

    <div class="auto-style1">
    <asp:Button ID="grabar" runat="server" Text="Generar Transferencia" OnClick="Grabar_Click" Width="180px" />
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


