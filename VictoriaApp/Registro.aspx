<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="VictoriaApp.Registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Victoria</title>
  <!-- base:css -->
  <link rel="stylesheet" href="vendors/mdi/css/materialdesignicons.min.css"/>
  <link rel="stylesheet" href="vendors/css/vendor.bundle.base.css"/>
  <!-- endinject -->
  <!-- plugin css for this page -->
  <!-- End plugin css for this page -->
  <!-- inject:css -->
  <link rel="stylesheet" href="css/style.css"/>
  <link rel="stylesheet" href="css/estilos.css"/>
  <!-- endinject -->
  <link rel="shortcut icon" href="images/favicon.png" />
</head>
<body>
    <div class="<%--container-scroller--%>">
    <div class="container-fluid page-body-wrapper full-page-wrapper">
      <div class="content-wrapper d-flex align-items-stretch auth auth-img-bg">
        <div class="row flex-grow">
          <div class="col-lg-6 d-flex align-items-center justify-content-center">
            <div class="auth-form-transparent text-left p-3 animated fadeIn">
              <div class="brand-logo text-center">
                <img src="images/logo_victoria.png" alt="logo"/>
              </div>
              <h4>Eres nuevo?</h4>
              <h6 class="font-weight-light">Únete, bríndandonos tu información</h6>
              <form class="pt-0" runat="server" id="signupForm">
                <div class="row">
                    <div class="form-group col-md-6">
                        <label>Nombre/s</label>
                        <div class="input-group border-input">
                        <div class="input-group-prepend bg-transparent">
                            <span class="input-group-text bg-transparent border-right-0">
                                <i class="fas fa-edit text-primary"></i>
                            </span>
                        </div>
                        <input type="text" class="form-control form-control-lg border-left-0 border-input" placeholder="Nombre" runat="server" id="txtNombre"/>
                    </div>
                    </div>
                    <div class="form-group col-md-6">
                      <label>Apellidos</label>
                      <div class="input-group border-input">
                        <div class="input-group-prepend bg-transparent">
                          <span class="input-group-text bg-transparent border-right-0">
                            <i class="fas fa-edit text-primary"></i>
                          </span>
                        </div>
                        <input type="text" class="form-control form-control-lg border-left-0 border-input" placeholder="Apellidos" runat="server" id="txtApellidos"/>
                      </div>
                    </div>
                  </div>
                  <div class="row">
                    <div class="form-group col-md-6">
                        <label>Email</label>
                        <div class="input-group border-input">
                        <div class="input-group-prepend bg-transparent">
                            <span class="input-group-text bg-transparent border-right-0">
                                <i class="fas fa-user text-primary"></i>
                            </span>
                        </div>
                        <input type="text" class="form-control form-control-lg border-left-0 border-input" placeholder="Email" runat="server" id="txtUsuario"/>
                    </div>
                    </div>
                    <div class="form-group col-md-6">
                      <label>Contraseña</label>
                      <div class="input-group border-input">
                        <div class="input-group-prepend bg-transparent">
                          <span class="input-group-text bg-transparent border-right-0">
                            <i class="fas fa-lock text-primary"></i>
                          </span>
                        </div>
                        <input type="password" class="form-control form-control-lg border-left-0 border-input" id="txtPassword" runat="server" placeholder="Contraseña"/>
                      </div>
                    </div>
                  </div>
                <div class="row">
                  <div class="form-group col-md-6">
                      <label>Fecha de Nacimiento</label>
                      <div class="input-group border-input">
                        <div class="input-group-prepend bg-transparent">
                          <span class="input-group-text bg-transparent border-right-0">
                            <i class="fas fa-calendar-alt text-primary"></i>
                          </span>
                        </div>
                        <input type="date" class="form-control form-control-lg border-left-0 border-input" runat="server" id="deFechaNacimiento"/>
                      </div>
                    </div>
                    <div class="form-group col-md-6">
                      <label>Sexo</label>
                        <select class="form-control form-control-lg select-css" id="cbSexo" runat="server">
                            <option selected="selected">Sexo</option>
                            <option>Femenino</option>
                            <option>Masculino</option>
                            <option>No especificado</option>
                        </select>
                    </div>
                </div>
                <div class="row">
                    <div class="form-group col-md-6">
                      <label>Celular</label>
                      <div class="input-group border-input">
                        <div class="input-group-prepend bg-transparent">
                          <span class="input-group-text bg-transparent border-right-0" id="spanCel">
                            <i class="fas fa-mobile-alt text-primary"></i>
                          </span>
                        </div>
                        <input type="text" class="form-control form-control-lg border-left-0 border-input" placeholder="Celular" runat="server" id="txtCelular"/>
                      </div>
                    </div>
                    <div class="form-group col-md-6">
                      <label>País</label>
                        <select class="form-control form-control-lg select-css" id="cbPais" runat="server">
                            <option selected="selected">País</option>
                            <option >Perú</option>
                        </select>
                    </div>
                </div>
                <div class="row">
                    <div class="form-group col-md-6">
                      <label>Ciudad</label>
                        <select class="form-control form-control-lg select-css" id="cbCiudad" runat="server">
                            <option selected="selected">Ciudad</option>
                            <option >Trujillo</option>
                        </select>
                    </div>
                    <div class="form-group col-md-6">
                        <label>¿Cómo te enteraste de Victoria?</label>
                        <select class="form-control form-control-lg select-css" id="cbEnterar" runat="server">
                            <option selected="selected">¿Cómo te enteraste?</option>
                            <option>Facebook</option>
                            <option>Instagram</option>
                            <option>LinkedIn</option>
                            <option>Recomendacion de un amigo</option>
                            <option>Otros</option>
                        </select>
                    </div>
                </div>
                <div class="mb-4 offset-2">
                  <div class="form-check"><a href="#" id="show">
                    <label class="form-check-label text-muted">
                      <input type="checkbox" class="form-check-input" runat="server" id="chkTerminos"/>
                      Acepto los terminos, condiciones y politicas de privacidad
                    </label></a>
                  </div>
                </div>
                  <div class="alert alert-danger text-center" role="alert" runat="server" visible="false" id="divErrores">
                      <asp:ListBox ID="lbErrores" runat="server" BackColor="Transparent" Width="100%" Enabled="false" CssClass="border-0 accordion text-danger overflow-hidden" Visible="false"></asp:ListBox>
                  </div>
                  
                <div class="mt-3">
                    <asp:Button ID="btnRegistrar" runat="server" CssClass="btn btn-block btn-primary btn-lg font-weight-medium auth-form-btn" Text="UNIRSE A VICTORIA" OnClick="btnRegistrar_Click" />
                </div>
                <div class="text-center mt-4 font-weight-light">
                 <h6> Ya tienes una cuenta? <a href="Login.aspx" class="text-primary">Inicia Sesión</a></h6>
                </div>
              </form>
            </div>
          </div>
          <div class="col-lg-6 register-half-bg d-flex flex-row banner-none animated fadeIn">
            <p class="text-white font-weight-medium text-center flex-grow align-self-end">Copyright &copy; 2020  All rights reserved.</p>
          </div>
        </div>
      </div>
      <!-- content-wrapper ends -->
    </div>
    <!-- page-body-wrapper ends -->
  </div>
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha256-4+XzXVhsDmqanXGHaHvgh1gMQKX40OUvDEBTu8JcmNs=" crossorigin="anonymous"></script>
    <%--<script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>--%>
    <script src="vendors/jquery.avgrund/jquery.avgrund.min.js"></script>
    <script src="Scripts/avgrund.js"></script>
    <script>
        $("#cbEnterar").blur(function () {
            if (document.getElementById("cbEnterar").selectedIndex != 0) {
                $(this).css({ "background": "#A8A8F2" })
                $(this).css({ "color": "#ffff" })
            }
        });
        $("#cbPais").blur(function () {
            if (document.getElementById("cbPais").selectedIndex != 0) {
                $(this).css({ "background": "#A8A8F2" })
                $(this).css({ "color": "#ffff" })
            }
        });
        $("#cbCiudad").blur(function () {
            if (document.getElementById("cbCiudad").selectedIndex != 0) {
                $(this).css({ "background": "#A8A8F2" })
                $(this).css({ "color": "#ffff" })
            }
        });
        $("#cbSexo").blur(function () {
            if (document.getElementById("cbSexo").selectedIndex != 0) {
                $(this).css({ "background": "#A8A8F2" })
                $(this).css({ "color": "#ffff" })
            }
        });
        $("#txtNombre").blur(function () {
            if ($('#txtNombre').val().length != 0) {
                $(this).css({ "background": "#A8A8F2" })
                $(this).css({ "color": "#ffff" })
            }
        });
        $("#txtApellidos").blur(function () {
            if ($('#txtApellidos').val().length != 0) {
                $(this).css({ "background": "#A8A8F2" })
                $(this).css({ "color": "#ffff" })
            }
        });
        $("#txtUsuario").blur(function () {
            if ($('#txtUsuario').val().length != 0) {
                $(this).css({ "background": "#A8A8F2" })
                $(this).css({ "color": "#ffff" })
            }
        });
        $("#txtPassword").blur(function () {
            if ($('#txtPassword').val().length != 0) {
                $(this).css({ "background": "#A8A8F2" })
                $(this).css({ "color": "#ffff" })
            }
        });
        $("#deFechaNacimiento").blur(function () {
            if ($('#deFechaNacimiento').val().length != 0) {
                $(this).css({ "background": "#A8A8F2" })
                $(this).css({ "color": "#ffff" })
            }
        });
        $("#txtCorreo").blur(function () {
            if ($('#txtCorreo').val().length != 0) {
                $(this).css({ "background": "#A8A8F2" })
                $(this).css({ "color": "#ffff" })
            }
        });
        $("#txtCelular").blur(function () {
            if ($('#txtCelular').val().length != 0) {
                $(this).css({ "background": "#A8A8F2" })
                $(this).css({ "color": "#ffff" })
            }
         });
//$(".input").focus(function(){
//  $(this).css({"background":"rgb(82, 179, 126)"})
//})
    </script>
    <script src="vendors/js/vendor.bundle.base.js"></script>
    <script src="Scripts/js/hoverable-collapse.js"></script>
    <script src="Scripts/js/off-canvas.js"></script>
    <script src="Scripts/js/settings.js"></script>
    <script src="Scripts/js/template.js"></script>
    <script src="Scripts/js/todolist.js"></script>
    <script src="https://kit.fontawesome.com/81717efc38.js" crossorigin="anonymous"></script>
    <%--<script src="vendors/jquery-validation/jquery.validate.min.js"></script>
    <script src="Scripts/form-validation.js"></script>--%>
</body>
</html>
