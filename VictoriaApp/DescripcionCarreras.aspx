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

    <h2 runat="server" id="carreraTitulo" style="text-align:center; margin-top:2em; color:white">Selección de Carreras</h2>

    <form id="form1" runat="server">
        <div class="container">
            <div class="accordion accordion-solid-header" id="accordion-4" role="tablist">
                     <%-- <div class="card">
                        <div class="card-header" role="tab" id="heading-10">
                          <h6 class="mb-0">
                            <a data-toggle="collapse" href="#collapse-10" aria-expanded="true" aria-controls="collapse-10" class="">
                              How can I pay for an order I placed?
                            </a>
                          </h6>
                        </div>
                        <div id="collapse-10" class="collapse show" role="tabpanel" aria-labelledby="heading-10" data-parent="#accordion-4" style="">
                          <div class="card-body">
                            <div class="row">
                              <div class="col-3">
                                <img src="../../../../images/samples/300x300/10.jpg" class="mw-100" alt="image">                              
                              </div>
                              <div class="col-9">
                                <p class="mb-0 text-white">You can pay for the product you have purchased using credit cards, debit cards, or via online banking. 
                                We also on-delivery services.</p>                             
                              </div>
                            </div>
                          </div>
                            </div>
                          </div>
                <div class="card">
                        <div class="card-header" role="tab" id="heading-11">
                          <h6 class="mb-0">
                            <a data-toggle="collapse" href="#collapse-11" aria-expanded="true" aria-controls="collapse-11" class="">
                              How can I pay for an order I placed?
                            </a>
                          </h6>
                        </div>
                        <div id="collapse-11" class="collapse" role="tabpanel" aria-labelledby="heading-11" data-parent="#accordion-4" style="">
                          <div class="card-body">
                            <div class="row">
                              <div class="col-3">
                                <img src="../../../../images/samples/300x300/10.jpg" class="mw-100" alt="image">                              
                              </div>
                              <div class="col-9">
                                <p class="mb-0 text-white">You can pay for the product you have purchased using credit cards, debit cards, or via online banking. 
                                We also on-delivery services.</p>                             
                              </div>
                            </div>
                          </div>
                            </div>
                          </div>--%>
                <%=HttpUtility.HtmlDecode((string)(Session["ACarreras"]??"")) %>
                </div>
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

    </script>
</body>
</html>