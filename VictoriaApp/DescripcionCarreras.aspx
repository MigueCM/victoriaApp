<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DescripcionCarreras.aspx.cs" Inherits="VictoriaApp.DescripcionCarreras" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <title>Victoria</title>
    <!-- base:css -->
    <link rel="stylesheet" href="vendors/mdi/css/materialdesignicons.min.css">
    <link href="vendors/css/vendor.bundle.base.css" rel="stylesheet" />
    <!-- endinject -->
    <!-- plugin css for this page -->
    <!-- End plugin css for this page -->
    <!-- inject:css -->
    <link href="css/style.css" rel="stylesheet" />
    <!-- endinject -->

    <link rel="shortcut icon" href="images/logo_reducido.png" />
    <link href="css/estilos.css" rel="stylesheet" />
    <script src="vendors/js/vendor.bundle.base.js"></script>
    <script src="Scripts/js/off-canvas.js"></script>
    <script src="Scripts/js/hoverable-collapse.js"></script>
    <script src="Scripts/js/template.js"></script>
    <script src="Scripts/js/settings.js"></script>
    <script src="Scripts/js/todolist.js"></script>

    <script src="Scripts/sweetalert.min.js"></script>
    <script src="Scripts/alerts.js"></script>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/css/bootstrap.min.css" integrity="sha384-TX8t27EcRE3e/ihU7zmQxVncDAy5uIKz4rEkgIXeMed4M0jlfIDPvg6uqKI2xXr2" crossorigin="anonymous"/>
    <link rel="stylesheet" type="text/css" href="//cdn.jsdelivr.net/npm/slick-carousel@1.8.1/slick/slick.css"/>
    <link href="https://kenwheeler.github.io/slick/slick/slick-theme.css" rel="stylesheet" />
    <style>

        .card-header a.acordion-header{
            font-weight: bold !important;
            font-size: 25px !important;
        }

        .btnAtras img{
            width: 100%;
        }

        .btnLogo img{
            width: 100%;
        }

        .accordion .card .card-header{
            background-color: #410060;
            color: #ffffff;
        }

        .acordion-body{
            font-size: 17px;
        }

        @media (max-width: 600px) {
           

            .btnAtras img{
                width: 3em;
                /*height: 90px;
                width: 100px;*/
            }

            .btnAtras{
                width: 10%;
            }
            


        }
        
        .image{
        max-height:100%; 
        height:40em;
    }


    @media (max-width: 1450px) {

        .image{
                max-height:100%; 
                height:30em;
            }
           

            


    }

    @media (max-width: 1100px) {

        .body{
            height: 100vh;
        }
           

            


    }

    </style>
</head>
<%--<<body style="background: url('images/Simulador/carreras/aeronautica/fondo-pregunta.jpg');
 background-repeat: no-repeat; background-size: cover; min-height:100vh;">--%>
<body style="background: url('images/Simulador/carreras/<%=(string)(Session["UrlBackground"]??"")%>');
 background-repeat: no-repeat; background-size: cover; min-height:100vh;">

    <%--<h2 runat="server" id="carreraTitulo" style="text-align:center; margin-top:2em; color:white">Selección de Carreras</h2>--%>

    <div class="container-fluid pt-4">

        <div class="row ">
            <div class="col-sm-1 btnAtras" onclick="location.href='SeleccionCarrera.aspx'" style="cursor:pointer;">
                <img src="images/Simulador/botonAtras.png" alt="Alternate Text" />
            </div>
            <div class="col-sm-10 tituloPrincipal">
                <%--<img src="images/Simulador/tituloSimuladorCarrera.png" alt="Alternate Text"  />--%>
            </div>
            <div class="col-sm-1 btnLogo">
                <img src="images/Simulador/victoria-simulador.png" alt="Alternate Text" />
            </div>
        </div>

    </div>
    
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-sm-6">
                <img id="personaje" src="images/Simulador/carreras/<%=(string)(Session["DesCarrera"]??"")%>/<%=(string)(Session["Genero"]??"")%>.png" class="image offset-sm-2" />
                    </div>
                <div class="col-sm-6 ">
                    <div class="accordion accordion-solid-header" id="accordion-4" role="tablist">
                        <div class="card">
                            <div class="card-header" role="tab" id="heading-10">
                              <h6 class="mb-0">
                                <a data-toggle="collapse" href="#collapse-10" aria-expanded="true" aria-controls="collapse-10" class="text-center acordion-header">
                                  ¿QUÉ ES?
                                </a>
                              </h6>
                            </div>
                            <div id="collapse-10" class="collapse show" role="tabpanel" aria-labelledby="heading-10" data-parent="#accordion-4" style="">
                              <div class="card-body">
                                <div class="row">
                                  <div class="col-12">
                                    <p class="mb-0 text-white text-center acordion-body">
                                        <%--Es la ingeniería que gestiona eficientemente las operaciones para la extracción y aprovechamiento
                                        de recursos mineros, evaluando el impacto en el medio ambiente y las comunidades.
                                        <br />
                                        <br />
                                        Desarrolla las competencias y habilidades para la investigación, prospección, explotación y producción
                                        de yacimientos minero.--%>
                                        <%=HttpUtility.HtmlDecode((string)(Session["Text1"]??"")) %>
                                        
                                    </p>                             
                                  </div>
                                </div>
                              </div>
                            </div>
                        </div>

                        <div class="card">
                            <div class="card-header" role="tab" id="heading-11">
                              <h6 class="mb-0">
                                <a data-toggle="collapse" href="#collapse-11" aria-expanded="true" aria-controls="collapse-11" class="text-center acordion-header">
                                  ¿QUÉ CUALIDADES DEMANDA?
                                </a>
                              </h6>
                            </div>
                            <div id="collapse-11" class="collapse" role="tabpanel" aria-labelledby="heading-11" data-parent="#accordion-4" style="">
                              <div class="card-body">
                                <div class="row">
                                  <div class="col-12">
                                    <p class="mb-0 text-white text-center acordion-body">
                                        <%--Se trata de una carrera con bastantes oportunidades para los jóvenes
                                        con espiritu competitivo y que estén dispuestos a prepararse constantemente. --%>
                                        <%=HttpUtility.HtmlDecode((string)(Session["Text2"]??"")) %>
                                    </p>                             
                                  </div>
                                </div>
                              </div>
                            </div>
                        </div>

                        <div class="card">
                            <div class="card-header" role="tab" id="heading-12">
                              <h6 class="mb-0">
                                <a data-toggle="collapse" href="#collapse-12" aria-expanded="true" aria-controls="collapse-12" class="text-center acordion-header">
                                  CAMPO LABORAL
                                </a>
                              </h6>
                            </div>
                            <div id="collapse-12" class="collapse" role="tabpanel" aria-labelledby="heading-12" data-parent="#accordion-4" style="">
                              <div class="card-body">
                                <div class="row">
                                  <div class="col-12">
                                    <p class="mb-0 text-white text-center acordion-body">
                                       <%-- Operaciones <br />
                                        Planeamiento <br />
                                        Desarrollo y evaluación de proyectos <br />
                                        Servicios auxiliares <br />
                                        Seguridad minera <br />
                                        Medio ambiente <br />
                                        Investigación <br />
                                        Servicios de consultoría o de gestión a nivel general en empresas
                                        y organizaciones relacionadas con este sector<br />--%>
                                        <%=HttpUtility.HtmlDecode((string)(Session["Text3"]??"")) %>

                                    </p>                             
                                  </div>
                                </div>
                              </div>
                            </div>
                        </div>

                        <%--<%=HttpUtility.HtmlDecode((string)(Session["ACarreras"]??"")) %>--%>
                    </div>
                </div>
            </div>

            
        </div>
        
    </form>
    <script type="text/javascript" src="https://code.jquery.com/jquery-3.5.1.min.js"></script>
</body>
</html>