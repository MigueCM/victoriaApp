<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="landingPage.aspx.cs" Inherits="VictoriaApp.landingPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <!-- Required meta tags -->
  <meta charset="utf-8"/>
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
  <title>Victoria</title>
  <!-- base:css -->
  <link rel="stylesheet" href="vendors/mdi/css/materialdesignicons.min.css"/>
  <link rel="stylesheet" href="vendors/css/vendor.bundle.base.css"/>
  <!-- endinject -->
  <!-- inject:css -->
  <link rel="stylesheet" href="css/horizontal-layout-light/style.css"/>
  <!-- endinject -->
    <link rel="shortcut icon" href="images/logo_reducido.png" />
</head>
<body class="landingPage">
    <form id="form1" runat="server">
        <div class="container-scroller" >
            <div class="container-fluid page-body-wrapper full-page-wrapper "  >
              <div class="content-wrapper d-flex align-items-center text-center error-page bg-primary"  style="background-image: url(images/Simulador.png) !important; background-size: cover">
                <div class="row flex-grow">
                  <div class="col-lg-12 mx-auto text-white">
                    <div class="row align-items-center d-flex flex-row">
                      <div class="col-lg-12 text-lg-center pr-lg-0">
                        <h1 class="display-1 mb-0 text-white">PROXIMAMENTE</h1>
                      </div>
             
                    </div>
                    <div class="row mt-5">
                      <div class="col-12 text-center mt-xl-2">
                            <button class="btn btn-primary btn-options"  onclick="location.href='Principal.aspx'" type="button">VOLVER A INICIO</button>
                      </div>
                    </div>
                    <div class="row mt-5">
                      <div class="col-12 mt-xl-2">
                        <p class="text-white font-weight-medium text-center">Copyright &copy;
                                                    <%=DateTime.Now.Year.ToString()%> Todos los derechos registrados.</p>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
              <!-- content-wrapper ends -->
            </div>
            <!-- page-body-wrapper ends -->
          </div>
    </form>
    <%--<script src="vendors/js/vendor.bundle.base.js"></script>
  <!-- endinject -->
  <!-- inject:js -->
  <script src="js/off-canvas.js"></script>
  <script src="js/hoverable-collapse.js"></script>
  <script src="js/template.js"></script>
  <script src="js/settings.js"></script>
  <script src="js/todolist.js"></script>--%>
</body>
</html>
