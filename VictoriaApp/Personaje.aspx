<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Personaje.aspx.cs" Inherits="VictoriaApp.Personaje" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width, initial-scale=1"/>
<meta charset="utf-8" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/css/bootstrap.min.css" integrity="sha384-TX8t27EcRE3e/ihU7zmQxVncDAy5uIKz4rEkgIXeMed4M0jlfIDPvg6uqKI2xXr2" crossorigin="anonymous"/>
    <title></title>
    <style>
* {
  box-sizing: border-box;
}

.zoom {
/*  padding: 50px;*/
  transition: transform .2s;
  margin: 0 auto;
}

.zoom:hover {
  -ms-transform: scale(1.25); /* IE 9 */
  -webkit-transform: scale(1.25); /* Safari 3-8 */
  transform: scale(1.25); 
}
</style>
</head>
<body style="background: url('images/Simulador/FONDO-09.jpg');
 background-repeat: no-repeat; background-size: cover;">
    <form id="form1" runat="server">
        <div class="container-fluid d-flex flex-column h-100" >
            <div class="row fixed-top">
                <div class="col-sm-12"  onclick="javascript:history.back();">
                    <img src="images/Simulador/atras-simulador.png" style="height:90px; width:100px;"/>       
                </div>
<%--            </div>
            <div class="row fixed-top" style="margin-top: 2em;">--%>
                <%--<div class="col-sm-12 center-block text-center">
                    <img src="images/Simulador/victoria-simulador.png" style="height:200px;" />                    
                </div>--%>
            </div>

            <div class="row fixed-bottom" style="margin-bottom: 2em;">
                <div class="col-md-6 center-block text-right">
                    <h1 style="
    padding-right: 150px;
">HOMBRE</h1>
                    <img class="zoom" src="images/Simulador/HOMBRE-INTRO.gif"  style="max-height:100%; height:40em; " onclick="location.href='SeleccionCarrera.aspx'"/>                
                </div>
                <div class="col-md-6 center-block text-left">
                    <h1 style="
    padding-left: 30px;
">MUJER</h1>
                    <img class="zoom" src="images/Simulador/HOMBRE-INTRO.gif"  style="max-height:100%; height:40em; " onclick="location.href='SeleccionCarrera.aspx'"/>                
                </div>
            </div>
            <%--<div class="row fixed-bottom" style="margin-bottom: 5em;">
                 <div class="col-sm-12 center-block text-center" >
                    <button type="button"  onclick="location.href='SeleccionCarrera.aspx'" style="background-color:white; color:purple; font-size:30px; height:80px; width:300px; font-weight:bold; border-radius:10px;">EMPEZAR</button>
                </div>
            </div>--%>
            <div class="row fixed-bottom" style="margin-bottom: 1em;">
                <div class="col-sm-5 fixed-bottom">
                    <img src="images/Simulador/musica-simulador.png" style="height:90px; width:100px;"/>
                </div>
            </div>
        </div>
            
        
    </form>

   
</body>
</html>

