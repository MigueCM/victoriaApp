<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ModuloCapacitacion.aspx.cs" Inherits="VictoriaApp.ModuloCapacitacion" %>
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
                                <div class="form-group ">
                            
                                    <button id="btnNuevo" type="button" class="btn btn-primary" data-toggle="modal" data-target="#modalCreate" OnClick="limpiar()">
                                        Registrar Modulo
                                    </button>

                                   
                                
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-lg-12 col-md-12">
                                <div class="table-responsive">
                                    <table id="tabla-modulos" class="table">
                                      <thead>
                                        <tr>
                                            <th>#</th>
                                            <th class="search">Nombre</th>
                                            <th class="search" style="width:50%">Descripcion</th>
                                            <th class="search">Enlace</th>
                                            <th>Calificación</th>
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
                                              <button class="btn btn-outline-danger">Eliminar</button>
                                            </td>
                                        </tr>
                                      </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>

                    <form method="post" runat="server" enctype="multipart/form-data">
             <%--           <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>--%>
                         <div class="modal fade" id="modalCreate" tabindex="-1" role="dialog" aria-labelledby="modalCreate-2" aria-hidden="true">
                            <div class="modal-dialog" role="document">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h5 class="modal-title title" id="title" runat="server">Registro de Módulo</h5>
                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                        <span aria-hidden="true">&times;</span>
                                        </button>
                                    </div>
                                    <div class="modal-body">
                                        <input type="hidden" class="txtId" name="txtId" id="txtId" value=""  runat="server" />
                                        <input type="hidden" class="txtTipo" name="txtTipo" id="txtTipo" value="1"  runat="server" />
                                        <div class="form-group">
                                            <label for="txtNombre">Nombre</label>
                                            <div class="input-group border-input">
                                                  <div class="input-group-prepend bg-transparent ">
                                                    <span class="input-group-text bg-transparent border-right-0 border-color-principal">
                                                        <i class="fas fa-envelope text-primary" aria-hidden="true"></i>
                                                    </span>
                                                    </div>                  

                                                <input name="txtNombre" type="text" id="txtNombre" class="form-control form-control-sm border-color-principal pl-1 txtNombre" placeholder="Nombre" required runat="server"/>
                                            </div>                                     
                                        </div>
                                        <div class="form-group">
                                            <label for="txtDescripcion">Descripción</label>
                                            <div class="input-group border-input">
                                                <textarea class="form-control form-control-sm border-color-principal txtDescripcion" id="txtDescripcion" placeholder="Descripcion" runat="server"></textarea>
                                            </div>                                     
                                        </div>
                                        <div class="form-group">
                                            <label for="txtEnlace">Enlace</label>
                                            <div class="input-group border-input">
                                                  <div class="input-group-prepend bg-transparent ">
                                                    <span class="input-group-text bg-transparent border-right-0 border-color-principal">
                                                        <i class="fas fa-envelope text-primary" aria-hidden="true"></i>
                                                    </span>
                                                    </div>                  

                                                <input name="txtEnlace" type="text" id="txtEnlace" class="form-control form-control-sm border-color-principal pl-1 txtEnlace" placeholder="Enlace" required runat="server"/>
                                            </div>                                     
                                        </div>
                                        <div class="form-group">
                                            <label for="txtFile">Enlace</label>
                                            <div class="input-group border-input">        
                                                <div class="input-group-prepend bg-transparent ">
                                                    <span class="input-group-text bg-transparent border-right-0 border-color-principal">
                                                        <i class="fas fa-envelope text-primary" aria-hidden="true"></i>
                                                    </span>
                                                    </div>
                                                <input name="txtFile" type="file" id="txtFile" class="form-control form-control-sm border-color-principal pl-1 txtFile" required runat="server" accept="image/*" />
                                                <input type="hidden" name="txtImagen" id="txtImagen" class="txtImagen" runat="server" />
                                            </div>                                     
                                        </div>
                                    </div>
                                    <div class="modal-footer">
                                         <asp:Button ID="btnEnviar" runat="server" Text="Agregar" class="btn btn-primary font-weight-medium btnEnviar" OnClick="btnEnviar_Click"/>
                                        
                                        <button type="reset" class="btn btn-danger" data-dismiss="modal">Cancelar</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <%-- <div class="modal fade" id="modalUpdate" tabindex="-1" role="dialog" aria-labelledby="modalCreate-2" aria-hidden="true">
                            <div class="modal-dialog" role="document">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h5 class="modal-title">Actualizar de Módulo</h5>
                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                        <span aria-hidden="true">&times;</span>
                                        </button>
                                    </div>
                                    <div class="modal-body">
                                        <input type="hidden" class="txtId" name="txtId" id="txtId" value=""  runat="server" />
                                        <div class="form-group">
                                            <label for="txtNombreE">Nombre</label>
                                            <div class="input-group border-input">
                                                  <div class="input-group-prepend bg-transparent ">
                                                    <span class="input-group-text bg-transparent border-right-0 border-color-principal">
                                                        <i class="fas fa-envelope text-primary" aria-hidden="true"></i>
                                                    </span>
                                                    </div>                  

                                                <input name="txtNombreE" type="text" id="txtNombreE" class="form-control form-control-sm border-color-principal pl-1 txtNombreE" placeholder="Nombre" required runat="server"/>
                                            </div>                                     
                                        </div>
                                        <div class="form-group">
                                            <label for="txtDescripcionE">Descripción</label>
                                            <div class="input-group border-input">
                                                <textarea class="form-control form-control-sm border-color-principal txtDescripcionE" id="txtDescripcionE" placeholder="Descripcion" runat="server"></textarea>
                                            </div>                                     
                                        </div>
                                        <div class="form-group">
                                            <label for="txtEnlaceE">Enlace</label>
                                            <div class="input-group border-input">
                                                  <div class="input-group-prepend bg-transparent ">
                                                    <span class="input-group-text bg-transparent border-right-0 border-color-principal">
                                                        <i class="fas fa-envelope text-primary" aria-hidden="true"></i>
                                                    </span>
                                                    </div>                  

                                                <input name="txtEnlaceE" type="text" id="txtEnlaceE" class="form-control form-control-sm border-color-principal pl-1 txtEnlaceE" placeholder="Enlace" required runat="server"/>
                                            </div>                                     
                                        </div>
                                        <div class="form-group">
                                            <label for="txtFileE">Enlace</label>
                                            <div class="input-group border-input">        
                                                <div class="input-group-prepend bg-transparent ">
                                                    <span class="input-group-text bg-transparent border-right-0 border-color-principal">
                                                        <i class="fas fa-envelope text-primary" aria-hidden="true"></i>
                                                    </span>
                                                    </div>
                                                <input name="txtFileE" type="file" id="txtFileE" class="form-control form-control-sm border-color-principal pl-1" runat="server" accept="image/*" />
                                                <input type="hidden" name="txtImagen" id="txtImagen" class="txtImagen" runat="server" />
                                            </div>                                     
                                        </div>
                                    </div>
                                    <div class="modal-footer">
                                         <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" class="btn btn-primary font-weight-medium" OnClick="btnActualizar_Click"/>
                                        
                                        <button type="reset" class="btn btn-danger" data-dismiss="modal">Cancelar</button>
                                    </div>
                                </div>
                            </div>
                        </div>--%>
                    </form>

                </div>

            </div>

        </div>
    
  <!-- plugin js for this page -->
  <script src="http://www.urbanui.com/wagondash/template/vendors/datatables.net/jquery.dataTables.js"></script>
  <script src="http://www.urbanui.com/wagondash/template/vendors/datatables.net-bs4/dataTables.bootstrap4.js"></script>

    <script>

        $('#tabla-modulos thead tr').clone(true).appendTo('#tabla-modulos thead');
        $('#tabla-modulos thead tr:eq(1) th').each(function (i) {
           
            if ($(this).hasClass("search")) {
                var title = $(this).text();
                $(this).html('<input type="text" class="w-100 p-1" placeholder="' + title + '" />');

                $('input', this).on('keyup change', function () {
                    if (table.column(i).search() !== this.value) {
                        table
                            .column(i)
                            .search(this.value)
                            .draw();
                    }
                });
            } else {
                $(this).html("")
            }
            
        });

        var table = $('#tabla-modulos').DataTable({
            "aLengthMenu": [
                [5, 10, 15, -1],
                [5, 10, 15, "All"]
            ],
            "iDisplayLength": 10,
            "language": {
                search: ""
            },
            orderCellsTop: true,
            fixedHeader: true
        });

        function cargarData(id) {
                        
            var parametros = "{'id': '" + id + "'}";

            $.ajax({
                data: parametros,
                url: 'ModuloCapacitacion.aspx/CargarDataModulo',
                dataType: "json",
                type: 'POST',
                contentType: "application/json; charset=utf-8",
                beforeSend: function () {

                },
                success: function (response) {
                    var data = JSON.parse(response.d)["objModulo"];

                    $(".txtId").val(id);
                    $(".txtNombre").val(data["Nombre"]);
                    $(".txtDescripcion").val(data["Descripcion"]);
                    $(".txtEnlace").val(data["Enlace"]);
                    $(".txtImagen").val(data["Imagen"]);
                    $(".title").html("Actualización de Módulo")
                    $(".btnEnviar").html("Actualizar")
                    $(".txtTipo").val(2)
                    $(".txtFile").prop("required",false)
                    $("#modalCreate").modal("show")
                },
                error: function (e) {
                    console.log(e)
                }
            });
        }

        function eliminar(id) {
            if (confirm("Desea Eliminar este módulo")) {
                var parametros = "{'id': '" + id + "'}";

                $.ajax({
                    data: parametros,
                    url: 'ModuloCapacitacion.aspx/EliminarData',
                    dataType: "json",
                    type: 'POST',
                    contentType: "application/json; charset=utf-8",
                    beforeSend: function () {

                    },
                    success: function (response) {
                        console.log(response)
                        location.href = "ModuloCapacitacion.aspx";
                    },
                    error: function (e) {
                        console.log(e)
                    }
                });
            }

        }

        function redireccionPreguntas(id) {
            var parametros = "{'id': '" + id + "'}";

            $.ajax({
                data: parametros,
                url: 'ModuloCapacitacion.aspx/RedireccionPreguntas',
                dataType: "json",
                type: 'POST',
                contentType: "application/json; charset=utf-8",
                beforeSend: function () {

                },
                success: function (response) {
                    location.href = "PreguntaCapacitacion.aspx";
                },
                error: function (e) {
                    console.log(e)
                }
            });
        }

        function limpiar() {
            $(".txtId").val("");
            $(".txtNombre").val("");
            $(".txtDescripcion").val("");
            $(".txtEnlace").val("");
            $(".txtImagen").val("");
            $(".title").html("Registro de Módulo")
            $(".btnEnviar").html("Agregar")
            $(".txtTipo").val(1)
            $(".txtFile").prop("required", true)
        }

    </script>

</asp:Content>
