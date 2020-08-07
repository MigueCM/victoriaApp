<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Webinars.aspx.cs" Inherits="VictoriaApp.Webinars" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-12">
            <div class="card">
                <div class="card-body">
                    <h4 class="card-title">Webinars</h4>
                    <hr/>
                    <div class="row">
                        <div class="col-lg-12 col-md-12">
                            <div class="form-group ">
                                <button id="btnNuevo" type="button" class="btn btn-primary" data-toggle="modal" data-target="#modalCreate" OnClick="limpiar()">
                                        Registrar Webinar
                                </button>
                            </div>
                        </div>
                    
                        <div class="col-lg-12 col-md-12">
                            <div class="table-responsive">
                                <table id="tabla-modulos" class="table">
                                    <thead>
                                    <tr>
                                        <th>#</th>
                                        <th class="search">Titulo</th>
                                        <th class="search" style="width:50%">Descripcion</th>
                                        <th class="search">Autor</th>
                                        <th>Imagen</th>
                                        <th>Opciones</th>
                                    </tr>
                                    </thead>
                                    <tbody runat="server" id="tbody_modulo">
                                    <%--    <tr>
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
                                        </tr>--%>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
                <form method="post" runat="server" enctype="multipart/form-data">             
                    <div class="modal fade" id="modalCreate" tabindex="-1" role="dialog" aria-labelledby="modalCreate-2" aria-hidden="true">
                        <div class="modal-dialog" role="document">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h5 class="modal-title title" id="title" runat="server">Registro de Webinar</h5>
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
                                                    <i class="fas fa-pen-square text-primary" aria-hidden="true"></i>
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
                                        <label for="txtAutor">Autor</label>
                                        <div class="input-group border-input">
                                                <div class="input-group-prepend bg-transparent ">
                                                <span class="input-group-text bg-transparent border-right-0 border-color-principal">
                                                    <i class="fab fa-youtube text-primary" aria-hidden="true"></i>
                                                </span>
                                                </div>                  

                                            <input name="txtAutor" type="text" id="txtAutor" class="form-control form-control-sm border-color-principal pl-1 txtAutor" placeholder="Autor" required runat="server"/>
                                        </div>                                     
                                    </div>
                                    <div class="form-group">
                                        <label for="txtFile">Imagen</label>
                                        <div class="input-group border-input">        
                                            <div class="input-group-prepend bg-transparent ">
                                                <span class="input-group-text bg-transparent border-right-0 border-color-principal">
                                                    <i class="far fa-file-image text-primary" aria-hidden="true"></i>
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
                </form>
            </div>
        </div>
    </div>

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
                url: 'Webinars.aspx/CargarDataWebinars',
                dataType: "json",
                type: 'POST',
                contentType: "application/json; charset=utf-8",
                beforeSend: function () {

                },
                success: function (response) {
                    var data = JSON.parse(response.d)["objWebinar"];

                    $(".txtId").val(id);
                    $(".txtNombre").val(data["Titulo"]);
                    $(".txtDescripcion").val(data["Descripcion"]);
                    $(".txtAutor").val(data["Autor"]);
                    $(".txtImagen").val(data["Imagen"]);
                    $(".title").html("Actualización de Webinar")
                    $(".btnEnviar").html("Actualizar")
                    $(".txtTipo").val(2)
                    $(".txtFile").prop("required", false)
                    $("#modalCreate").modal("show")
                },
                error: function (e) {
                    console.log(e)
                }
            });
        }

        function eliminar(id) {

            //if (confirm("Desea Eliminar este módulo")) {
            //if (showSwal("delete-module","¿Desea Eliminar este módulo?", "Esta acción no se podrá revertir", "")) {

            //}
            swal({
                title: "¿Desea Eliminar este webinar?",
                text: "Esta acción no se podrá revertir",
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3f51b5',
                cancelButtonColor: '#ff4081',
                confirmButtonText: 'Great ',
                buttons: {
                    cancel: {
                        text: "Cancelar",
                        value: null,
                        visible: true,
                        className: "btn btn-danger",
                        closeModal: true,
                    },
                    confirm: {
                        text: "OK",
                        value: true,
                        visible: true,
                        className: "btn btn-primary",
                        closeModal: true
                    }
                }
            }).then((willDelete) => {
                if (willDelete) {
                    var parametros = "{'id': '" + id + "'}";

                    $.ajax({
                        data: parametros,
                        url: 'Webinars.aspx/EliminarData',
                        dataType: "json",
                        type: 'POST',
                        contentType: "application/json; charset=utf-8",
                        beforeSend: function () {

                        },
                    }).done(function (html) {
                        swal("El webinar ha sido eliminado correctamente", {
                            icon: "success",
                            timer: 2000
                        });
                        location.href = "Webinars.aspx";
                    });

                } else {
                    swal("Operación cancelada");
                }
            });
        }

        function limpiar() {
            $(".txtId").val("");
            $(".txtNombre").val("");
            $(".txtDescripcion").val("");
            $(".txtAutor").val("");
            $(".txtImagen").val("");
            $(".title").html("Registro de Webinar")
            $(".btnEnviar").html("Agregar")
            $(".txtTipo").val(1)
            $(".txtFile").prop("required", true)
        }

    </script>

</asp:Content>
