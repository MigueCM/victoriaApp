<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Simulador.aspx.cs" Inherits="VictoriaApp.Simulador" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width, initial-scale=1"/>
<meta charset="utf-8" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/css/bootstrap.min.css" integrity="sha384-TX8t27EcRE3e/ihU7zmQxVncDAy5uIKz4rEkgIXeMed4M0jlfIDPvg6uqKI2xXr2" crossorigin="anonymous"/>
    <title></title>
</head>
<body style="background: url('images/Simulador/FONDO.png');
 background-repeat: no-repeat; background-size: cover;">
    <form id="form1" runat="server">
        <div class="container-fluid d-flex flex-column h-100" style="margin-top: 0.5em">
            <div class="row">
                <div class="col-sm-5" >
                    <img class="pointer-event" src="images/Simulador/atras-simulador.png" style="height:90px; width:100px;" onclick="javascript:history.back();"/>       
                </div>
            <%--</div>
            <div class="row fixed-top" style="margin-top: 2em;">--%>
                <div class="col-sm-12 center-block text-center">
                    <img src="images/Simulador/victoria-simulador.png" style="height:200px;" />                    
                </div>
            </div>

            <div class="row" style="margin-top: 2em;">
                <div class="col-md-12 center-block text-center">
                    <h1 style="font-size:80px; color:white;">SIMULADOR DE CARRERAS</h1>                    
                </div>
            </div>
            <div class="row fixed-bottom" style="margin-bottom: 5em;">
                 <div class="col-sm-12 center-block text-center" >
                    <button type="button"  onclick="location.href='Personaje.aspx'" style="background-color:white; color:purple; font-size:30px; height:80px; width:300px; font-weight:bold; border-radius:10px;">EMPEZAR</button>
                </div>
            </div>
            <div class="row fixed-bottom" style="margin-bottom: 1em;">
                <div class="col-sm-5 fixed-bottom">
                    <img src="images/Simulador/musica-simulador.png" style="height:90px; width:100px;"/>
                </div>
               
            </div>
        </div>
            
        
    </form>
</body>
</html>
