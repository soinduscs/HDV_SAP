<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="formulario_hdv.aspx.cs" Inherits="MovilUtiles.formulario_hdv" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1.0"/>

    <title>Transferencias HDV</title>
    
<link href="css/estiloHDV.css" rel="stylesheet" />
<link href="css/estilo_form.css" rel="stylesheet"/>

<style type="text/css">
        .auto-style1 {
            float: left;
            width: 100%;
            height: 26px;
            margin-top: 0;
        }
        .auto-style2 {
            float: left;
            width: 100%;
            height: 64px;
            margin-top: 0;
        }
</style>
    
</head>

<body>
    <form id="form1" runat="server">
<fieldset>
<legend><h2>TRANSFERENCIAS HDV</h2></legend>

<div class="container">
    <div class="row">
      <div class="col-25">

<label>Almacen Origen</label>
<input list="Almacenes" name="list" />
<datalist id="Almacen">
    <option label="BPT" value="BPT">
    <option label="BSE" value="BSE">
    <option label="BMP" value="BMP">
</datalist>

<label>Almacen Destino</label>
<input list="Almacenes" name="list" />
<datalist id="Almacen">
    <option label="BPT" value="BPT">
    <option label="BSE" value="BSE">
    <option label="BMP" value="BMP">
</datalist>



    <div class="row">
      <div class="col-25">
        
<img src="img/logo_hdv.png" />
    </div>
    
</div>
       </div>
        </div>
       </div>
</fieldset>
    </form>
</body>
</html>
