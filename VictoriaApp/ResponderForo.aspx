<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ResponderForo.aspx.cs" Inherits="VictoriaApp.ResponderForo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
            <div class="row">
            <div class="col-12">
                <div class="card">
                    <div class="card-body">
                        <h4 class="card-title">Módulos</h4>
                        <hr/>
                        <div class="row">
                            <div class="col-lg-12 col-md-12">
                                <div class="table-responsive">
                                    <table id="tabla-modulos" class="table">
                                      <thead>
                                        <tr>
                                            <th>#</th>
                                            <th class="search">Usuario</th>
                                            <th class="search">Pregunta</th>
                                            <th class="search" style="width:40%">Contenido</th>
                                            <th class="search">Fecha Pregunta</th>
                                            <th>Opciones</th>
                                        </tr>
                                      </thead>
                                      <tbody runat="server" id="tbody_modulo">
                                        <tr>
                                            <td>1</td>
                                            <td>Modulo I</td>
                                            <td>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore 
                                                magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo 
                                                consequat.
                                            </td>
                                            <td>www.youtube.com</td>
                                            <td>5 <i class="fa fa-star"></i></td>
                                            <td>
                                              <button class="btn btn-outline-primary">Editar</button>
                                            </td>
                                        </tr>
                                      </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>

                    <form method="post" runat="server" enctype="multipart/form-data">
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
             <%--           <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>--%>
                         <div class="modal fade" id="modalResponder" tabindex="-1" role="dialog" aria-labelledby="modalCreate-2" aria-hidden="true">
                            <div class="modal-dialog" role="document">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h5 class="modal-title title" id="title" runat="server">Registro de Respuesta</h5>
                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                        <span aria-hidden="true">&times;</span>
                                        </button>
                                    </div>
                                    <div class="modal-body">
                                        <input type="hidden" class="txtId" name="txtId" id="txtId" value=""  runat="server" />
                                        <div class="form-group">
                                            <label for="txtNombre">Usuario</label>
                                            <div class="input-group border-input">
                                                  <div class="input-group-prepend bg-transparent ">
                                                    <span class="input-group-text bg-transparent border-right-0 border-color-principal">
                                                        <i class="fas fa-edit text-primary" aria-hidden="true"></i>
                                                    </span>
                                                    </div>                  

                                                <input name="txtNombre" type="text" id="txtNombre" class="form-control form-control-sm border-color-principal pl-1 txtNombre" placeholder="Nombre" runat="server" disabled/>
                                            </div>                                     
                                        </div>
                                        <div class="form-group">
                                            <label for="txtNombre">Titulo</label>
                                            <div class="input-group border-input">
                                                  <div class="input-group-prepend bg-transparent ">
                                                    <span class="input-group-text bg-transparent border-right-0 border-color-principal">
                                                        <i class="fas fa-edit text-primary" aria-hidden="true"></i>
                                                    </span>
                                                    </div>                  

                                                <input name="txtTitulo" type="text" id="txtTitulo" class="form-control form-control-sm border-color-principal pl-1 txtTitulo" placeholder="Nombre" runat="server" disabled/>
                                            </div>                                     
                                        </div>
                                        <div class="form-group">
                                            <label for="txtDescripcion">Descripción</label>
                                            <div class="input-group border-input">
                                                <textarea class="form-control form-control-sm border-color-principal txtDescripcion" id="txtDescripcion" placeholder="Descripcion" runat="server" disabled></textarea>
                                            </div>                                     
                                        </div>
                                        <div class="form-group">
                                            <label for="txtRespuestaPregunta">Respuesta</label>
                                            <div class="input-group border-input">
                                                <textarea class="form-control form-control-sm border-color-principal txtRespuestaPregunta" id="txtRespuestaPregunta" name="txtRespuestaPregunta" placeholder="Respuesta" runat="server"></textarea>
                                            </div>                                     
                                        </div>
                                        <div class="form-group">
                                            <div class="alert alert-danger text-center" role="alert" runat="server" visible="false" id="divErrores">
                                              <asp:ListBox ID="lbErrores" runat="server" BackColor="Transparent" Width="100%" Enabled="false" CssClass="border-0 accordion text-danger overflow-hidden" Visible="false"></asp:ListBox>
                                          </div>
                                        </div>

                                    </div>
                                    
                                    
                                    <div class="modal-footer">
                                         <asp:Button ID="btnRespuesta" runat="server" Text="Responder" class="btn btn-primary font-weight-medium" OnClick="btnRespuesta_Click"/>
                                        
                                        <button type="reset" class="btn btn-danger" data-dismiss="modal">Cancelar</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </form>

                </div>

            </div>

        </div>
    
  <!-- plugin js for this page -->
 <%-- <script src="http://www.urbanui.com/wagondash/template/vendors/datatables.net/jquery.dataTables.js"></script>
  <script src="http://www.urbanui.com/wagondash/template/vendors/datatables.net-bs4/dataTables.bootstrap4.js"></script>--%>
  <script src="vendors/datatables.net/jquery.dataTables.js"></script>
  <script src="vendors/datatables.net-bs4/dataTables.bootstrap4.js"></script>
  <script src="Scripts/js/datatable.js"></script>
    <script>
        function redireccionPreguntas(id) {
            <% 
                divErrores.Visible = false;
                lbErrores.Visible = false;
                lbErrores.Items.Clear();
            %>
            showSwal("responder-pregunta", "", "", "", id); 
        }

        function eliminar(id) {
            swal({
                title: "¿Desea Eliminar esta pregunta?",
                text: "Esta acción no se podrá revertir",
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3f51b5',
                cancelButtonColor: '#ff4081',
                confirmButtonText: 'Great ',
                buttons: {
                    confirm: {
                        text: "Eliminar",
                        value: true,
                        visible: true,
                        className: "btn btn-primary",
                        closeModal: true
                    },
                    cancel: {
                        text: "Cancelar",
                        value: null,
                        visible: true,
                        className: "btn btn-danger",
                        closeModal: true,
                    }

                }
            }).then((willDelete) => {
                if (willDelete) {
                    var parametros = "{'id': '" + id + "'}";

                    $.ajax({
                        data: parametros,
                        url: 'ResponderForo.aspx/EliminarData',
                        dataType: "json",
                        type: 'POST',
                        contentType: "application/json; charset=utf-8",
                        beforeSend: function () {

                        },
                        success: function (response) {
                            swal("El foro ha sido eliminado correctamente", {
                                icon: "success",
                            });
                            location.href = "ResponderForo.aspx";
                        },
                        error: function (e) {
                            console.log(e)
                        }
                    }).done(function (html) {
                        swal("El foro ha sido eliminado correctamente", {
                            icon: "success",
                            timer: 2000
                        });
                        location.href = "ResponderForo.aspx";
                    });

                } else {
                    swal("Operación cancelada");
                }
            });
        }

    </script>
</asp:Content>
