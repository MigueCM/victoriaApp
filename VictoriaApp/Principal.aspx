<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="VictoriaApp.Principal" %>

<<<<<<< HEAD
<%@ Register Assembly="DevExpress.XtraReports.v20.1.Web.WebForms, Version=20.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>
=======
<%@ Register Assembly="DevExpress.XtraReports.v20.1.Web.WebForms, Version=20.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>
>>>>>>> 9b13467ad0ed3fc4e33d50df387def2c285272f1


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
    
    </script>
    <style>
        .mdi-star:hover{
            color:blue;
            cursor: pointer;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    

        <div class="welcome-message" style="opacity:0.85; border-radius:20px;">
            <div id="divvoluntario" runat="server" visible="true">
                <div class="row">
                    
                    <div class="table-responsive">
                    <table class="table">
                      <thead>
                        <tr>
                          <th class="text-white text-center"><h4>Modulo</h4></th>
                          <th class="text-white text-center"><h4>Fecha</h4></th>
                          <th class="text-white text-center"><h4>Estado</h4></th>
                        </tr>
                      </thead>
                      <tbody id="tableModulos" runat="server">
                        <tr>
                          <td class="text-white">1. Lorem Ipsum is simply dummy text of the</td>
                          <td class="text-white text-center">09 de Julio 2020</td>
                          <td><button class="btn btn-block btn-completado" onclick="showSwal('basic')">Completado</button></td>
                        </tr>
                        <tr>
                          <td class="text-white">2. Lorem Ipsum is simply dummy text of the</td>
                          <td class="text-white text-center"></td>
                          <td><a class="btn btn-block btn-pendiente" href="Panel.aspx">Pendiente</a></td>
                        </tr>
                        <tr>
                          <td class="text-white">3. Lorem Ipsum is simply dummy text of the</td>
                          <td class="text-white text-center"></td>
                          <td><a class="btn btn-block btn-pendiente" href="Panel.aspx">Pendiente</a></td>
                        </tr>
                        <tr>
                          <td class="text-white">4. Lorem Ipsum is simply dummy text of the</td>
                          <td class="text-white text-center"></td>
                          <td><a class="btn btn-block btn-pendiente" href="Panel.aspx">Pendiente</a></td>
                        </tr>
                        <tr>
                          <td class="text-white">5. Lorem Ipsum is simply dummy text of the</td>
                          <td class="text-white text-center"></td>
                          <td><a class="btn btn-block btn-pendiente" href="Panel.aspx">Pendiente</a></td>
                        </tr>
                      </tbody>
                    </table>
                  </div>
                </div>
                <div class="alert alert-fill-success" role="alert" id="dCertificado" runat="server" visible="false">
                    <i class="mdi mdi-alert-circle"></i>
                    Felicitaciones completaste todos los módulos satisfactoriamente.
                    <button type="button" runat="server" id="btnCertificado" onserverclick="btnCertificado_ServerClick" class="btn btn-primary btn-rounded btn-fw" onclick="SetTarget();">Descargar Certificado</button>
                </div>
            </div>
          </div>

    <br />
    <br />

        <div class="row" >
            <div class="col-12">
                <div class="card" style="border-radius:20px;" id="ViewForo">
                    <div class="card-body">
                         <div class="row">
                            <div class="col-lg-9 col-md-9">
                                <h4 class="card-title">PREGUNTAS</h4>
                            </div>
                             <div class="col-lg-3 col-md-3">
                                 <button id="btnNuevaPregunta" type="button" class="btn btn-primary" data-toggle="modal" data-target="#modalAgregarPregunta" OnClick="limpiarForo()">
                                        AGREGAR PREGUNTA
                                    </button>
                            </div>
                        </div>
                        
                        <hr/>
                        <div class="row">
                             <div class="profile-feed col-12" id="feed">
                                 <%=HttpUtility.HtmlDecode((string)(Session["Comentarios"]??"")) %>

                        
                      </div>
                           <%-- cdSDCDS
                             <hr style="width:100%;  align-self:center; ">
                            CASD--%>
                        </div>
                    </div>
                    </div>

            </div>

        </div>


             <%--           <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>--%>
                            <div class="modal fade" id="modalAgregarPregunta" tabindex="-1" role="dialog" aria-labelledby="modalCreate-2" aria-hidden="true">
                            <div class="modal-dialog" role="document">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h5 class="modal-title title" id="H1" runat="server">Registro de Pregunta</h5>
                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                        <span aria-hidden="true">&times;</span>
                                        </button>
                                    </div>
                                    <div class="modal-body">
                                        <input type="hidden" class="txtId" name="txtId" id="txtId" value=""  runat="server" />
                                        <input type="hidden" class="txtTipo" name="txtTipo" id="txtTipo" value="1"  runat="server" />
                                        <div class="form-group">
                                            <label for="txtTitulo">Titulo</label>
                                            <div class="input-group border-input">
                                                  <div class="input-group-prepend bg-transparent ">
                                                    <span class="input-group-text bg-transparent border-right-0 border-color-principal">
                                                        <i class="fas fa-edit text-primary" aria-hidden="true"></i>
                                                    </span>
                                                    </div>                  

                                                <input type="text" id="txtTitulo" class="form-control form-control-sm border-color-principal pl-1 txtNombre" placeholder="Titulo" required/>
                                            </div>                                     
                                        </div>
                                        <div class="form-group">
                                            <label for="txtDescripcionPregunta">Descripción</label>
                                            <div class="input-group border-input">
                                                <textarea class="form-control form-control-sm border-color-principal txtDescripcion" id="txtDescripcionPregunta" placeholder="Descripcion" required></textarea>
                                            </div>                                     
                                        </div>
                                        <div class="form-group">
                                                <label for="cbModulo">Modulo</label>
                                                <select class="form-control form-control-sm border-color-principal pl-1 txtEnlace" id="cbModulo">
                                                </select>            
                                        </div>

                                        <div class="form-group">
                                            <div class="alert alert-danger text-center" role="alert" runat="server" visible="false" id="divErrores">
                                              <asp:ListBox ID="lbErrores" runat="server" BackColor="Transparent" Width="100%" Enabled="false" CssClass="border-0 accordion text-danger overflow-hidden" Visible="false"></asp:ListBox>
                                          </div>
                                        </div>

                                    </div>
                                    
                                    
                                    <div class="modal-footer">
                                        <button id="btnEnviar" type="button" class="btn btn-primary font-weight-medium" onclick="enviarFormulario()">Agregar Pregunta</button>
                                        <button type="reset" class="btn btn-danger" data-dismiss="modal">Cancelar</button>
                                    </div>
                                </div>
                            </div>
                        </div>
    <script src="Scripts/victoria-principal.js"></script>
</asp:Content>
