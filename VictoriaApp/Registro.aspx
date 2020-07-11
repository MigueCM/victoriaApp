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
    <div class="container-scroller">
    <div class="container-fluid page-body-wrapper full-page-wrapper">
      <div class="content-wrapper d-flex align-items-stretch auth auth-img-bg">
        <div class="row flex-grow">
          <div class="col-lg-6 d-flex align-items-center justify-content-center">
            <div class="auth-form-transparent text-left p-3">
              <div class="brand-logo">
                <img src="images/logo_victoria.png" alt="logo"/>
              </div>
              <h4>Eres nuevo?</h4>
              <h6 class="font-weight-light">Únete, bríndandonos tu información</h6>
              <form class="pt-0" runat="server">
                <div class="form-group">
                  <label>Username</label>
                  <div class="input-group border-input">
                    <div class="input-group-prepend bg-transparent">
                      <span class="input-group-text bg-transparent border-right-0">
                        <i class="mdi mdi-account-outline text-primary"></i>
                      </span>
                    </div>
                    <input type="text" class="form-control form-control-lg border-left-0 border-input" placeholder="Nombre" runat="server" id="txtNombre"/>
                  </div>
                </div>
                <div class="form-group">
                  <label>Apellidos</label>
                  <div class="input-group border-input">
                    <div class="input-group-prepend bg-transparent">
                      <span class="input-group-text bg-transparent border-right-0">
                        <i class="mdi mdi-account-outline text-primary"></i>
                      </span>
                    </div>
                    <input type="text" class="form-control form-control-lg border-left-0 border-input" placeholder="Apellidos" runat="server" id="txtApellidos"/>
                  </div>
                </div>
                  <div class="form-group">
                  <label>Fecha de Nacimiento</label>
                  <div class="input-group border-input">
                    <div class="input-group-prepend bg-transparent">
                      <span class="input-group-text bg-transparent border-right-0">
                        <i class="mdi mdi-calendar-outline text-primary"></i>
                      </span>
                    </div>
                    <input type="date" class="form-control form-control-lg border-left-0 border-input" runat="server" id="deFechaNacimiento"/>
                  </div>
                </div>
                <div class="form-group">
                  <label>Email</label>
                  <div class="input-group border-input">
                    <div class="input-group-prepend bg-transparent">
                      <span class="input-group-text bg-transparent border-right-0">
                        <i class="mdi mdi-email-outline text-primary"></i>
                      </span>
                    </div>
                    <input type="email" class="form-control form-control-lg border-left-0 border-input" placeholder="Email" runat="server" id="txtCorreo"/>
                  </div>
                </div>
<%--                <div class="form-group">
                  <label>Country</label>
                  <select class="form-control form-control-lg" id="exampleFormControlSelect2">
                    <option>Country</option>
                    <option>United States of America</option>
                    <option>United Kingdom</option>
                    <option>India</option>
                    <option>Germany</option>
                    <option>Argentina</option>
                  </select>
                </div>--%>
                <div class="form-group">
                  <label>Password</label>
                  <div class="input-group border-input">
                    <div class="input-group-prepend bg-transparent">
                      <span class="input-group-text bg-transparent border-right-0">
                        <i class="mdi mdi-lock-outline text-primary"></i>
                      </span>
                    </div>
                    <input type="password" class="form-control form-control-lg border-left-0 border-input" id="txtPassword" runat="server" placeholder="Password"/>                        
                  </div>
                </div>
                  <div class="form-group">
                  <label>Celular</label>
                  <div class="input-group border-input">
                    <div class="input-group-prepend bg-transparent">
                      <span class="input-group-text bg-transparent border-right-0">
                        <i class="mdi mdi-account-outline text-primary"></i>
                      </span>
                    </div>
                    <input type="text" class="form-control form-control-lg border-left-0 border-input" placeholder="Celular" runat="server" id="txtCelular"/>
                  </div>
                </div>
                <div class="mb-4">
                  <div class="form-check">
                    <label class="form-check-label text-muted">
                      <input type="checkbox" class="form-check-input" runat="server" id="chkTerminos"/>
                      I agree to all Terms & Conditions
                    </label>
                  </div>
                </div>
                <div class="mt-3">
                    <asp:Button ID="btnRegistrar" runat="server" CssClass="btn btn-block btn-primary btn-lg font-weight-medium auth-form-btn" Text="REGISTRAR" OnClick="btnRegistrar_Click" />
                </div>
                <div class="text-center mt-4 font-weight-light">
                  Already have an account? <a href="Login.aspx" class="text-primary">Iniciar Sesion</a>
                </div>
              </form>
            </div>
          </div>
          <div class="col-lg-6 register-half-bg d-flex flex-row">
            <p class="text-white font-weight-medium text-center flex-grow align-self-end">Copyright &copy; 2018  All rights reserved.</p>
          </div>
        </div>
      </div>
      <!-- content-wrapper ends -->
    </div>
    <!-- page-body-wrapper ends -->
  </div>

    <script src="vendors/js/vendor.bundle.base.js"></script>
    <script src="Scripts/js/hoverable-collapse.js"></script>
    <script src="Scripts/js/off-canvas.js"></script>
    <script src="Scripts/js/settings.js"></script>
    <script src="Scripts/js/template.js"></script>
    <script src="Scripts/js/todolist.js"></script>
    <script src="https://kit.fontawesome.com/81717efc38.js" crossorigin="anonymous"></script>
</body>
</html>
