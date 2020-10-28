<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SeleccionCarrera.aspx.cs" Inherits="VictoriaApp.SeleccionCarrera" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/css/bootstrap.min.css" integrity="sha384-TX8t27EcRE3e/ihU7zmQxVncDAy5uIKz4rEkgIXeMed4M0jlfIDPvg6uqKI2xXr2" crossorigin="anonymous"/>
    <link rel="stylesheet" type="text/css" href="//cdn.jsdelivr.net/npm/slick-carousel@1.8.1/slick/slick.css"/>
    <link href="https://kenwheeler.github.io/slick/slick/slick-theme.css" rel="stylesheet" />
    <style>
        .contenido{
            background: #fff;
    color: #3498db;
    font-size: 36px;
    line-height: 400px;
    margin: 10px;
    padding: 20%;
    height: 60px;
    position: relative;
    text-align: center;
    display: inline;
        }

           .slick-prev {
    left: 12%;
}

           .slick-next {
    right: 12%;
}
           .slick-prev:before, .slick-next:before {
               color: black;
           }
    </style>
</head>
<body style="background: url('images/Simulador/FONDO-09.jpg');
 background-repeat: no-repeat; background-size: cover;">
    
    <h2 style="text-align:center; margin-top:2em; color:white">Selección de Carreras</h2>

    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div id="corrousel" style="margin-top: 2em; padding: 0 15em;">
            <a style="display:inline" id="1" onclick="clickaction(this)">
                 <h3 class="contenido">Carrera 1</h3> 
            </a>
            <a style="display:inline" id="2" onclick="clickaction(this)">
                  <h3 class="contenido">Carrera 2</h3> 
            </a>
            <a style="display:inline" id="3" onclick="clickaction(this)">
                 <h3 class="contenido">Carrera 3</h3> 
            </a>
            <a style="display:inline" id="4" onclick="clickaction(this)">
                  <h3 class="contenido">Carrera 4</h3> 
            </a>
            <a style="display:inline" id="5" onclick="clickaction(this)">
                 <h3 class="contenido">Carrera 5</h3> 
            </a>
        </div>
    </form>
    <script type="text/javascript" src="https://code.jquery.com/jquery-3.5.1.min.js"></script>
    <script type="text/javascript" src="//cdn.jsdelivr.net/npm/slick-carousel@1.8.1/slick/slick.min.js"></script>

    <script>
        
        $('#corrousel').slick({
              infinite: true,
              slidesToShow: 3,
              slidesToScroll: 3
            });
        function clickaction(b) {
            // Accion por defecto para Buttons;
            //console.log(b.id);
            __doPostBack('miPostBack', b.id);
            //var parametros = "{'id': '" + b.id + "'}";
            //$.ajax({
            //    data: parametros,
            //    url: 'SeleccionCarrera.aspx/Carrera',
            //    dataType: "json",
            //    type: 'POST',
            //    contentType: "application/json; charset=utf-8",
            //    success: function (response) {
            //        l
            //    },
            //    error: function (e) {
            //        console.log(e)
            //    }
            //});
            }
    </script>
</body>
</html>
