<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="VictoriaApp.Registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta charset="utf-8" />
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
<script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha256-4+XzXVhsDmqanXGHaHvgh1gMQKX40OUvDEBTu8JcmNs=" crossorigin="anonymous"></script>
<%--<script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>--%>
    <script src="Scripts/sweetalert.min.js"></script>
    <script src="Scripts/alerts.js"></script>
<script src="vendors/jquery.avgrund/jquery.avgrund.min.js"></script>
<script src="Scripts/avgrund.js"></script>
  <link rel="shortcut icon" href="images/Victoria.ico" />
</head>
<body>
    <form runat="server" id="form1">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <%--<div class="col-md-4 col-sm-6 grid-margin stretch-card">
                             
                                <div class="square-box-loader">
                                  <div class="square-box-loader-container">
                                    <div class="square-box-loader-corner-top"></div>
                                    <div class="square-box-loader-corner-bottom"></div>
                                  </div>
                                  <div class="square-box-loader-square"></div>
                                </div>
                              
                            </div>--%>
          <div class="loader">
            <div>
                <div class="loader-animation">
                </div>
                <br/>
                <div class="square-box-loader">
                                  <div class="square-box-loader-container">
                                    <div class="square-box-loader-corner-top"></div>
                                    <div class="square-box-loader-corner-bottom"></div>
                                  </div>
                                  <div class="square-box-loader-square"></div>
                                </div>
                <p class="text-mute">
                    <br/>
                    cargando...
                </p>
            </div>
        </div>
    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
    <div class="<%--container-scroller--%>">
    <div class="container-fluid page-body-wrapper full-page-wrapper">
      <div class="content-wrapper d-flex align-items-stretch auth auth-img-bg">
        <div class="row flex-grow">
          <div class="col-lg-6 d-flex align-items-center justify-content-center">
            <div class="auth-form-transparent text-left p-3 animated fadeIn">
              <div class="brand-logo text-center">
                <img src="images/logo_victoria2.png" alt="logo"/>
              </div>
              <h4>Eres nuevo?</h4>
              <h6 class="font-weight-light">Únete, bríndandonos tu información</h6>
              <div class="pt-0" runat="server" id="signupForm">
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
                        <label>Dni</label>
                        <div class="input-group border-input">
                            <div class="input-group-prepend bg-transparent">
                                <span class="input-group-text bg-transparent border-right-0">
                                    <i class="fas fa-address-card text-primary"></i>
                                </span>
                            </div>
                            <input type="text" class="form-control form-control-lg border-left-0 border-input" placeholder="DNI" runat="server" id="txtDni"/>
                        </div>
                    </div>
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
                  </div>
                  <div class="row">
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
                      <div class="form-group col-md-6">
                      <label>Confirmar Contraseña</label>
                      <div class="input-group border-input">
                        <div class="input-group-prepend bg-transparent">
                          <span class="input-group-text bg-transparent border-right-0">
                            <i class="fas fa-lock text-primary"></i>
                          </span>
                        </div>
                        <input type="password" class="form-control form-control-lg border-left-0 border-input" id="txtVerificarPassword" runat="server" placeholder="Contraseña"/>
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
                        <input type="date"  min="01-01-1900" class="form-control form-control-lg border-left-0 border-input" runat="server" id="deFechaNacimiento" placeholder="dd/mm/aaaa"/>
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
                      <label>Departamento</label>
                        <select class="form-control form-control-lg select-css" id="cbDepartamento" runat="server">
                            <option selected="selected">Departamento</option>
                            <option >La Libertad</option>
                        </select>
                    </div>
                </div>
                    <div class="row">
                    
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
                        <%--<a href="#" id="show">--%>
                  <div class="form-check">
                        <label class="form-check-label text-muted" id="show">
                         <input type="checkbox" class="form-check-input" runat="server" id="chkTerminos"/>
                            Acepto los terminos, condiciones y politicas de privacidad.
                        </label>
                  </div>
                            <%--</a>--%>
                </div>
                    <div class="alert alert-danger text-center" role="alert" runat="server" visible="false" id="divErrores">
                      <asp:ListBox ID="lbErrores" runat="server" BackColor="Transparent" Width="100%" Enabled="false" CssClass="border-0 accordion text-danger overflow-hidden" Visible="false"></asp:ListBox>
                  </div>
                  
                <div class="mt-3">
                    <asp:Button ID="btnRegistrar" runat="server" CssClass="btn btn-block btn-primary btn-lg font-weight-medium auth-form-btn" Text="UNIRSE A VICTORIA" OnClick="btnRegistrar_Click"/>
                </div>
                <div class="text-center mt-4 font-weight-light">
                 <h6> Ya tienes una cuenta? <a class="text-primary" runat="server" href="Login.aspx">Inicia Sesión</a></h6>
                </div>
                      
              </div>
            </div>
          </div>
          <div class="col-lg-6 register-half-bg d-flex flex-row banner-none animated fadeIn">
            <p class="text-white font-weight-medium text-center flex-grow align-self-end">Copyright &copy; <%=DateTime.Now.Year.ToString()%>  Todos los derechos registrados.</p>
          </div>
        </div>
      </div>
      <!-- content-wrapper ends -->
    </div>
    <!-- page-body-wrapper ends -->
  </div>
        <%--</ContentTemplate>
                  </asp:UpdatePanel>--%>
                  <%--<asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                      <ProgressTemplate>
                          <div id="Background">
                              <div id="Progress">
                          <div class="col-md-4 col-sm-6 grid-margin stretch-card">
                             
                                <div class="square-box-loader">
                                  <div class="square-box-loader-container">
                                    <div class="square-box-loader-corner-top"></div>
                                    <div class="square-box-loader-corner-bottom"></div>
                                  </div>
                                  <div class="square-box-loader-square"></div>
                                </div>
                              
                            </div></div></div>
                      </ProgressTemplate>
                  </asp:UpdateProgress>--%>
    </form>
    <script>
       
        //$(document).ready(function () {
        <%--$('#<%=UpdateProgress1.ClientID %>').show(1000, 'linear', function () { $('#<%=UpdateProgress1.ClientID %>').hide(); });});--%>
    </script>
    
    
    <script src="Scripts/funciones.js"></script>
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
