<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="MovilUtiles.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
<meta http-equiv="Content-Type" content="text/html"; charset="utf-8"/>
<meta name="viewport" content="width=device-width", initial-scale="1.0"/>
<meta http-equiv="X-UA-Compatible" content="ie-edge"/>

    <title>HDV - Web</title>

  <link rel="shortcut icon" href="img/favicon.ico" type="image/x-icon">
  <link rel="icon" href="img/favicon.ico" type="image/x-icon">

    <!--JQUERY-->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    
    <!-- FRAMEWORK BOOTSTRAP para el estilo de la pagina-->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css">
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    
    <!-- Los iconos tipo Solid de Fontawesome-->
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.0.8/css/solid.css">
    <script src="https://use.fontawesome.com/releases/v5.0.7/js/all.js"></script>

    <!-- Nuestro css-->
    <link rel="stylesheet" type="text/css" href="static/css/index.css" th:href="@{/css/index.css}">

    <style type="text/css">
        .auto-style1 {
            width: 106px;
        }
    </style>

</head>
<body>

<form id="form1" runat="server">
<fieldset>


    <div class="modal-dialog text-center">
        <div class="col-sm-8 main-section">
            <div class="modal-content">
                <div class="col-12 user-img">
                    <img src="img/logo_hdv.png" th:src="@{/img/user.png}" class="auto-style1"/>
                </div>

                    <div class="form-group" id="user-group">
                        <asp:TextBox ID="t_usuario" class="form-control" runat="server" placeholder="Tu usuario" name="username"></asp:TextBox>

                    </div>
                    <div class="form-group" id="contrasena-group">
                        <asp:TextBox ID="t_Clave" runat="server" class="form-control" placeholder="Contraseña" TextMode="Password"></asp:TextBox>

                    </div>

                <asp:Button ID="Button1" runat="server" class="btn btn-primary" OnClick="Button1_Click" Text="  Ingresar  " />

                <div class="col-12 forgot">
                    <a href="#"></a>
                </div>

                <div th:if="${param.error}" class="alert alert-danger" role="alert">
		            <asp:Label ID="lbl_error" runat="server" Font-Bold="True" ForeColor="#FF3300" Text="..."></asp:Label>
		        </div>

            </div>

        </div>

    </div>

</fieldset>
</form>

</body>
</html>

