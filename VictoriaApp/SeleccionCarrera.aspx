<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SeleccionCarrera.aspx.cs" Inherits="VictoriaApp.SeleccionCarrera" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <title></title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/css/bootstrap.min.css" integrity="sha384-TX8t27EcRE3e/ihU7zmQxVncDAy5uIKz4rEkgIXeMed4M0jlfIDPvg6uqKI2xXr2" crossorigin="anonymous"/>
    <link rel="stylesheet" type="text/css" href="//cdn.jsdelivr.net/npm/slick-carousel@1.8.1/slick/slick.css"/>
    <link href="https://kenwheeler.github.io/slick/slick/slick-theme.css" rel="stylesheet" />
    
    <style>

        .contenido{
            background: #fff;
            color: #3498db;
            /*font-size: 36px;
            line-height: 400px;
            margin: 10px;
            padding: 20%;
            height: 60px;*/
            /*position: relative;*/
            text-align: center;
        }

       .slick-prev {
            left: 12%;
                z-index: 10000;
        }

        .slick-next {
            right: 12%;
                z-index: 10000;
        }

        

        .slick-prev, .slick-next {
            width: 10%;
            height: 80px;
            
        }

        /*.slick-prev:before, .slick-next:before {
            color: black;
        }*/
    
        .puerta-titulo img, .puerta-carrera img{
            display:inline-block;
        }

        .puerta-titulo img{
            width:80%;
        }

        .puerta-carrera img{
            cursor:pointer;
            width:50%;
        }

        .btnAtras img{
            width: 100%;
        }

        .tituloPrincipal img{
             width: 100%;
        }

        .slick-slide:focus{

                outline: none

            }

        #corrousel{
            padding: 0 15em 3em;
        }

        .body{
             background-repeat: no-repeat; 
             background-size: cover; 
             max-height:100vh;
        }

        @media (max-width: 600px) {
            .puerta-titulo img, .puerta-carrera img {
                width: 64%;
            }

            .btnAtras img{
                
                /*width: 3em;*/
                height: 90px;
                width: 100px;
            }

            .btnAtras{
               /* width: 10%;*/
            }

            .tituloPrincipal{
                width: 100%;
            }

            #corrousel{
                padding: 0;
            }

            .slick-prev{
                left: 4%;
            }

            .slick-next {
                right: 4%;
            }
            
            .body{
                background-size: initial; 
            }

            .slick-prev{
                z-index: 600;
            }

        }

    </style>
</head>
<body class="body" style="background: url('images/Simulador/fondoCarrera.png');
">
    
    <%--<h2 style="text-align:center; margin-top:2em; color:white">Selección de Carreras</h2>--%>
    <div class="container-fluid pt-4">

        <div class="row ">
            <div class="col-sm-1 btnAtras" onclick="location.href='Personaje.aspx'" style="cursor:pointer;">
                <img src="images/Simulador/botonAtras.png" alt="Alternate Text" />
            </div>
            <div class="col-sm-10 tituloPrincipal">
                <img src="images/Simulador/tituloSimuladorCarrera.png" alt="Alternate Text"  />
            </div>
        </div>

    </div>
    

    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div id="corrousel" style="">

            <div  >
                <div class="puerta-titulo text-center">
                    <img src="images/Simulador/carreras/ingenieria-minas/titulo.png" alt="Alternate Text"  />
                </div>

                <div class="puerta-carrera text-center">
                    <img id="1" onclick="clickaction(this)" src="images/Simulador/carreras/ingenieria-minas/puerta.png" alt="Alternate Text"  />
                </div>                
            </div>

            <div  >
                <div class="puerta-titulo text-center">
                    <img src="images/Simulador/carreras/ingenieria-aeronautica/titulo.png" alt="Alternate Text"  />
                </div>

                <div class="puerta-carrera text-center">
                    <img id="2" onclick="clickaction(this)" src="images/Simulador/carreras/ingenieria-aeronautica/puerta.png" alt="Alternate Text"  />
                </div>                
            </div>

            <div  class="text-center" >
                <div class="puerta-titulo ">
                    <img src="images/Simulador/carreras/ingenieria-sistemas/titulo.png" alt="Alternate Text"  />
                </div>

                <div class="puerta-carrera text-center">
                    <img id="3" onclick="clickaction(this)" src="images/Simulador/carreras/ingenieria-sistemas/puerta.png" alt="Alternate Text"  />
                </div>                
            </div>

            <div  class="text-center" >
                <div class="puerta-titulo ">
                    <img src="images/Simulador/carreras/arquitectura-datos/titulo.png" alt="Alternate Text"  />
                </div>

                <div class="puerta-carrera text-center">
                    <img id="4" onclick="clickaction(this)" src="images/Simulador/carreras/arquitectura-datos/puerta.png" alt="Alternate Text"  />
                </div>                
            </div>

            <div  class="text-center" >
                <div class="puerta-titulo ">
                    <img src="images/Simulador/carreras/biologia-marina/titulo.png" alt="Alternate Text" style="width:60%;" />
                </div>

                <div class="puerta-carrera text-center">
                    <img id="5" onclick="clickaction(this)" src="images/Simulador/carreras/biologia-marina/puerta.png" alt="Alternate Text"  />
                </div>                
            </div>

            <div  class="text-center" >
                <div class="puerta-titulo ">
                    <img src="images/Simulador/carreras/mecatronica/titulo.png" alt="Alternate Text"  />
                </div>

                <div class="puerta-carrera text-center">
                    <img id="6" onclick="clickaction(this)" src="images/Simulador/carreras/mecatronica/puerta.png" alt="Alternate Text"  />
                </div>                
            </div>

            <div  class="text-center" >
                <div class="puerta-titulo ">
                    <img src="images/Simulador/carreras/deportes/titulo.png" alt="Alternate Text"  />
                </div>

                <div class="puerta-carrera text-center">
                    <img id="7" onclick="clickaction(this)" src="images/Simulador/carreras/deportes/puerta.png" alt="Alternate Text"  />
                </div>                
            </div>

            <div  class="text-center">
                <div class="puerta-titulo ">
                    <img src="images/Simulador/carreras/economia/titulo.png" alt="Alternate Text"  />
                </div>

                <div class="puerta-carrera text-center">
                    <img id="8" onclick="clickaction(this)" src="images/Simulador/carreras/economia/puerta.png" alt="Alternate Text"  />
                </div>                
            </div>

            <div  class="text-center">
                <div class="puerta-titulo ">
                    <img src="images/Simulador/carreras/biotecnologia/titulo.png" alt="Alternate Text" style="width:50%;" />
                </div>

                <div class="puerta-carrera text-center">
                    <img id="9" onclick="clickaction(this)" src="images/Simulador/carreras/biotecnologia/puerta.png" alt="Alternate Text"  />
                </div>                
            </div>

            <div  class="text-center">
                <div class="puerta-titulo ">
                    <img src="images/Simulador/carreras/fisica/titulo.png" alt="Alternate Text" style="width:28%;" />
                </div>

                <div class="puerta-carrera text-center">
                    <img id="10" onclick="clickaction(this)" src="images/Simulador/carreras/fisica/puerta.png" alt="Alternate Text"  />
                </div>                
            </div>

            <%--<a id="1" onclick="clickaction(this)">
                 <h3 class="contenido">Carrera 1</h3> 
            </a>
            <a id="2" onclick="clickaction(this)">
                  <h3 class="contenido">Carrera 2</h3> 
            </a>
            <a id="3" onclick="clickaction(this)">
                 <h3 class="contenido">Carrera 3</h3> 
            </a>
            <a id="4" onclick="clickaction(this)">
                  <h3 class="contenido">Carrera 4</h3> 
            </a>
            <a id="5" onclick="clickaction(this)">
                 <h3 class="contenido">Carrera 5</h3> 
            </a>--%>
        </div>
    </form>
    <script type="text/javascript" src="https://code.jquery.com/jquery-3.5.1.min.js"></script>
    <script type="text/javascript" src="//cdn.jsdelivr.net/npm/slick-carousel@1.8.1/slick/slick.min.js"></script>

    <script>
        
        $('#corrousel').slick({
              infinite: true,
              slidesToShow: 1,
            slidesToScroll: 1,
           
             prevArrow: "<img class='a-left control-c prev slick-prev' src='images/Simulador/slickAtras.png'>",
            nextArrow: "<img class='a-right control-c next slick-next' src='images/Simulador/slickSiguiente.png'>",
            //responsive: [
            //    {
            //        breakpoint: 600,
            //        settings: {
            //            slidesToShow: 1,
            //            slidesToScroll: 1,
            //            dots: true,
            //        }
            //    },
            //    ]
                });
        function clickaction(b) {
            console.log(b)
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
