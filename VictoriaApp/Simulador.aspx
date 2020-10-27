<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Simulador.aspx.cs" Inherits="VictoriaApp.Simulador" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/css/bootstrap.min.css" integrity="sha384-TX8t27EcRE3e/ihU7zmQxVncDAy5uIKz4rEkgIXeMed4M0jlfIDPvg6uqKI2xXr2" crossorigin="anonymous"/>
    <title></title>
</head>
<body style="background: url('images/Simulador/FONDO-09.jpg');
 background-repeat: no-repeat; background-size: cover;">
    <form id="form1" runat="server">
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-6">
                    
                    <div style="height:90vh;">
                        <button type="button" class="btn btn-primary btn-options" style="position:absolute; left:50%; bottom:0; ">HOMBRE</button>
                        <img src="images/Simulador/HOMBRE-INTRO-unscreen%20(1)%20(1).gif" style="position:absolute; left:50%; bottom:0; height:60vh;"/>
                    </div>
                    
                </div>
                 <div class="col-md-6">
                     <button type="button" class="btn btn-primary btn-options">MUJER</button>
                     <div style="height:90vh;">
                         <img src="images/Simulador/MUJER-INTRO-unscreen%20(1).gif" style=" position:absolute; bottom:0; height:60vh;"/>
                    </div>
                    
                </div>
                
            </div>
            </div>
    </form>
</body>
</html>
