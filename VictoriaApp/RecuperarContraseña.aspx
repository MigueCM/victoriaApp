<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecuperarContraseña.aspx.cs" Inherits="VictoriaApp.RecuperarContraseña" %>


<!DOCTYPE html>
<html lang="en">

<head>
  <!-- Required meta tags -->
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
  <title>Victoria</title>
  <!-- base:css -->
  <link rel="stylesheet" href="../vendors/mdi/css/materialdesignicons.min.css">
  <link rel="stylesheet" href="../vendors/css/vendor.bundle.base.css">
  <!-- endinject -->
  <!-- plugin css for this page -->
  <!-- End plugin css for this page -->
  <!-- inject:css -->
  <link rel="stylesheet" href="../css/style.css">
  <link rel="stylesheet" href="../css/estilos.css">
  <!-- endinject -->
  <link rel="shortcut icon" href="images/logo_reducido.png" />
</head>

<body>
  <div class="container-scroller">
    <div class="container-fluid page-body-wrapper full-page-wrapper">
      <div class="content-wrapper d-flex align-items-stretch auth auth-img-bg">
        <div class="row flex-grow">
          <div class="col-lg-6 d-flex align-items-center justify-content-center animated fadeIn">
            <div class="auth-form-transparent text-left p-login">
              <div class="brand-logo text-center">
                <img src="../images/logo_victoria.png" alt="logo">
              </div>
              <form class="pt-5" runat="server">
                <div class="form-group">
                  <label for="examplePassword1">Contraseña nueva</label>
                  <%--<input type="password" class="form-control text-center" id="password1" placeholder="Password">--%>
                    <div class="input-group border-input">
                        <div class="input-group-prepend bg-transparent">
                          <span class="input-group-text bg-transparent border-right-0">
                            <i class="fas fa-lock text-primary"></i>
                          </span>
                        </div>
                        <asp:TextBox ID="password1" runat="server" class="form-control form-control-sm"  placeholder="Password" TextMode="Password"></asp:TextBox>
                    </div>
    
                </div>
                 <div class="form-group">
                    <label for="examplePassword1">Repetir Contraseña</label>
                    <div class="input-group border-input">
                        <div class="input-group-prepend bg-transparent">
                          <span class="input-group-text bg-transparent border-right-0">
                            <i class="fas fa-lock text-primary"></i>
                          </span>
                        </div>
                        <asp:TextBox ID="password2" runat="server" class="form-control form-control-sm"  placeholder="Repetir Password" TextMode="Password"></asp:TextBox>
                    
                    </div>
                 </div>
                <div class="mt-5">
                    
                  <%--<a class="btn btn-block btn-success btn-lg font-weight-medium" href="../../index.html">Modificar Contraseña</a>--%>
                    <asp:Button ID="btnModificar" runat="server" Text="Modificar Contraseña" CssClass="btn btn-block btn-primary btn-lg font-weight-medium auth-form-btn border-button" OnClick="btnModificar_Click"/>
                </div>

                  <div class="alert alert-danger text-center mt-2" role="alert" runat="server" visible="false" id="lblError">
                  Usuario y/o contraseña incorrectas
                </div>
                 
                <div class="mt-3 text-center">
                  <%--<a href="#" class="auth-link text-white" onclick="location.href='/Login.aspx'">Regresar al login</a>--%>
                </div>

                

              </form>
            </div>
          </div>
            <div class="col-lg-6 login-half-bg d-flex flex-row banner-none animated fadeIn">
            <p class="text-white font-weight-medium text-center flex-grow align-self-end">Copyright &copy; <%=DateTime.Now.Year.ToString()%>  Todos los derechos registrados.</p>
          </div>
        </div>
      </div>
      <!-- content-wrapper ends -->
    </div>
    <!-- page-body-wrapper ends -->
  </div>
  <!-- container-scroller -->
  <!-- base:js -->
  <script src="../vendors/js/vendor.bundle.base.js"></script>
  <!-- endinject -->
  <!-- inject:js -->
  <script src="../Scripts/js/off-canvas.js"></script>
  <script src="../Scripts/js/hoverable-collapse.js"></script>
  <script src="../Scripts/js/template.js"></script>
  <script src="../Scripts/js/settings.js"></script>
  <script src="../Scripts/js/todolist.js"></script>
    <script src="https://kit.fontawesome.com/81717efc38.js" crossorigin="anonymous"></script>

    <script type="text/javascript">

        $("#password1 , #password2").blur(function () {
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
  <!-- endinject -->
</body>

</html>

