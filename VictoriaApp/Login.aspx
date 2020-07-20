<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="VictoriaApp.Login" %>

<!DOCTYPE html>
<html lang="en">


<!-- Mirrored from www.urbanui.com/wagondash/template/demo/horizontal-default-light/pages/samples/login-2.html by HTTrack Website Copier/3.x [XR&CO'2014], Fri, 10 Jul 2020 02:00:28 GMT -->
<head>
  <!-- Required meta tags -->
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
  <title>Victoria</title>
  <!-- base:css -->
  <link rel="stylesheet" href="vendors/mdi/css/materialdesignicons.min.css">
  <link rel="stylesheet" href="vendors/css/vendor.bundle.base.css">
  <!-- endinject -->
  <!-- plugin css for this page -->
  <!-- End plugin css for this page -->
  <!-- inject:css -->
  <link rel="stylesheet" href="css/style.css">
  <link rel="stylesheet" href="css/estilos.css">
  <!-- endinject -->
  <link rel="shortcut icon" href="images/favicon.png" />
</head>

<body>
  <div class="">
    <div class="container-fluid page-body-wrapper full-page-wrapper">
      <div class="content-wrapper d-flex align-items-stretch auth auth-img-bg">
        <div class="row flex-grow">
          <div class="col-lg-6 d-flex align-items-center justify-content-center animated fadeIn">
            <div class="auth-form-transparent text-left p-login ">
              <div class="brand-logo text-center">
                <img src="images/logo_victoria.png" alt="logo">
              </div>
              <h4 class="font-weight-bold">!Hola de nuevo!</h4>
              <h6 class="font-weight-light">¡Felices de que vuelvas!</h6>
              <form class="pt-3" runat="server">
                <div class="form-group">
                  <label for="exampleInputEmail">Usuario</label>
                  <div class="input-group border-input">
                    <div class="input-group-prepend bg-transparent">
                      <span class="input-group-text bg-transparent border-right-0">
                        <i class="fas fa-user text-primary"></i>
                      </span>
                    </div>
                    <%--<input type="text" class="form-control form-control-sm " id="txtUsuario" placeholder="Usuario"" >--%>

                    <asp:TextBox ID="txtUsuario" runat="server" class="form-control form-control-sm" placeholder="Email"></asp:TextBox>
                  </div>
                </div>
                <div class="form-group">
                  <label for="exampleInputPassword">Contraseña</label>
                  <div class="input-group border-input">
                    <div class="input-group-prepend bg-transparent">
                      <span class="input-group-text bg-transparent border-right-0">
                        <i class="fas fa-lock text-primary"></i>
                      </span>
                    </div>

                    <asp:TextBox ID="txtPassword" runat="server" class="form-control form-control-sm" placeholder="Contraseña" TextMode="Password"></asp:TextBox>
                    <%--<input type="password" class="form-control form-control-sm border-input" id="exampleInputPassword" placeholder="Contraseña">--%>                        
                  </div>
                </div>

               
                <div class="alert alert-danger text-center" role="alert" runat="server" visible="false" id="lblError">
                  Usuario y/o contraseña incorrectas
                </div>

                <div class="my-2 d-flex justify-content-between align-items-center">
                  <!--div class="form-check">
                    <label class="form-check-label text-muted">
                      <input type="checkbox" class="form-check-input">
                      Keep me signed in
                    </label>
                  </div!-->
                  <a href="#" class="auth-link text-principal" data-toggle="modal" data-target="#modalRecover">¿Olvidaste tu contraseña?</a>
                </div>
                <div class="my-3">

                    <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" CssClass="btn btn-block btn-primary btn-lg font-weight-medium auth-form-btn border-button" OnClick="Ingresar_Click" />

                  <%--<a class="btn btn-block btn-primary btn-lg font-weight-medium auth-form-btn" href="http://www.urbanui.com/wagondash/template/demo/horizontal-default-light/index.html">INGRESAR</a>--%>
                </div>
                <!--div class="mb-2 d-flex">
                  <button type="button" class="btn btn-facebook auth-form-btn flex-grow mr-1">
                    <i class="mdi mdi-facebook mr-2"></i>Facebook
                  </button>
                  <button type="button" class="btn btn-google auth-form-btn flex-grow ml-1">
                    <i class="mdi mdi-google mr-2"></i>Google
                  </button>
                </div!-->
                <div class="text-center mt-4 font-weight-light">
                    <h6>
                        ¿No tienes cuenta? <a href="Registro.aspx" class="text-primary">Crear cuenta</a>
                    </h6>
                  
                </div>


                

              </form>
            </div>
          </div>
          <div class="col-lg-6 login-half-bg d-flex flex-row banner-none animated fadeIn">
            <p class="text-black font-weight-medium text-center flex-grow align-self-end">Copyright &copy; <%=DateTime.Now.Year.ToString()%>  Todos los derechos registrados.</p>
          </div>
        </div>
      </div>
      <!-- content-wrapper ends -->
    </div>
    <!-- page-body-wrapper ends -->
  </div>

    <!-- Begin modal -->

                <div class="modal fade" id="modalRecover" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel-2" aria-hidden="true">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="exampleModalLabel-2">Recuperación de contraseña</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                                <div class="form-group">
                                    <label for="txtEmailRecover">Email</label>
                                    <div class="input-group border-input">
                                        <div class="input-group-prepend bg-transparent ">
                                            <span class="input-group-text bg-transparent border-right-0 border-color-principal">
                                                <i class="fas fa-envelope text-primary" aria-hidden="true"></i>
                                            </span>
                                         </div>                  

                                        <input name="txtEmailRecover" type="email" id="txtEmailRecover" class="form-control form-control-sm border-color-principal" placeholder="Email" required>
                                    </div>
                                     
                                </div>
                            <div class="alert alert-danger text-center d-none" role="alert" id="errorEmail">
                              Correo Invalido
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button id="btnEnviar" type="button" class="btn btn-primary font-weight-medium" onclick="validarEmail()">Enviar</button>
                            <button type="button" class="btn btn-danger" data-dismiss="modal">Cancelar</button>
                        </div>
                        </div>
                    </div>
                    </div>

                <!-- End modal -->

  <!-- container-scroller -->
  <!-- base:js -->
  <script src="vendors/js/vendor.bundle.base.js"></script>
  <!-- endinject -->
  <!-- Plugin js for this page-->
  <!-- End plugin js for this page-->
  <!-- inject:js -->
  <script src="Scripts/js/off-canvas.js"></script>
  <script src="Scripts/js/hoverable-collapse.js"></script>
  <script src="Scripts/js/template.js"></script>
  <script src="Scripts/js/settings.js"></script>
  <script src="Scripts/js/todolist.js"></script>
  <!-- endinject -->
  <script src="https://kit.fontawesome.com/81717efc38.js" crossorigin="anonymous"></script>
  <!-- plugin js for this page -->
  <!-- End plugin js for this page -->
  <!-- Custom js for this page-->
  <!-- End custom js for this page-->

  <script type="text/javascript">


      

      if ($(".p-login form").children("#lblError").length > 0){
          $(".p-login").addClass("p-login-alert");
      } else{
          $(".p-login").removeClass("p-login-alert");
      }

      //$("#btnEnviar").click(location.href="RecuperarContraseña.aspx")


      function validarEmail() {
          //location.href = 'RecuperarContraseña.aspx';
          var email = $("#txtEmailRecover").val();

          var parametros = "{'email': '" + email + "'}";

          $.ajax({
              data: parametros,
              url: 'Login.aspx/EnviarEmail',
              dataType: "json",
              type: 'POST',
              contentType: "application/json; charset=utf-8",
              beforeSend: function () {
                  
              },
              success: function (response) {

                  var data = JSON.parse(response.d);

                  $("#errorEmail").html(data["mensaje"]);
                  $("#errorEmail").removeClass("d-none");
                  if (data["correoValido"] === true) {
                      $("#errorEmail").append(data["token"]);
                      $("#errorEmail").addClass("alert-success");
                      $("#errorEmail").removeClass("alert-danger");
                  } else {
                      
                      $("#errorEmail").removeClass("alert-success");
                      $("#errorEmail").addClass("alert-danger");
                      
                  }

              },
              error: function (e) {
                  console.log(e)
              }
          });
          /*
          if (/^(([^<>()[\]\.,;:\s@\"]+(\.[^<>()[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/i.test(email)) {

              

          } else {
              alert("La dirección de email es incorrecta!.");
          }
          */

          

      }


      $("#txtUsuario , #txtPassword").blur(function () {
          if ($(this).val().length != 0) {
              $(this).css({ "background": "#A8A8F2" })
              $(this).css({ "color": "#ffff" })
          } else {
              $(this).css({ "background": "transparent" })
              $(this).css({ "color": "#495057" })
          }
      });

     /* $("#txtPassword").blur(function () {
          if ($(this).val().length != 0) {
              $(this).css({ "background": "#A8A8F2" })
              $(this).css({ "color": "#ffff" })
          }
      });*/


  </script>

</body>


<!-- Mirrored from www.urbanui.com/wagondash/template/demo/horizontal-default-light/pages/samples/login-2.html by HTTrack Website Copier/3.x [XR&CO'2014], Fri, 10 Jul 2020 02:00:34 GMT -->
</html>

