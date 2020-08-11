<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="GestionUsuario.aspx.cs" Inherits="VictoriaApp.GestionUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-12">
            <div class="card">
                <div class="card-body">
                    <h4 class="card-title">Usuario</h4>
                    <hr/>

                    <div class="row">
                        <div class="col-lg-12 col-md-12">
                            <div class="form-group ">
                            
                                <button id="btnNuevo" type="button" class="btn btn-primary" data-toggle="modal" data-target="#modalCreate" OnClick="limpiar()">
                                    Registrar Usuario
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
                                        <th class="search" style="width:50%">Perfil</th>
                                        <th class="search">Usuario</th>
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
                    <div class="modal fade" id="modalCreate" tabindex="-1" role="dialog" aria-labelledby="modalCreate-2" aria-hidden="true">
                        <div class="modal-dialog modal-lg" role="document">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h5 class="modal-title title" id="title" runat="server">Registro de Usuario</h5>
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                    </button>
                                </div>
                                <div class="modal-body">
                                    <input type="hidden" class="txtId" name="txtId" id="txtId" value=""  runat="server" />
                                    <input type="hidden" class="txtPersona" name="txtPersona" id="txtPersona" value=""  runat="server" />
                                    <input type="hidden" class="txtTipo" name="txtTipo" id="txtTipo" value="1"  runat="server" />

                                    <div class="row">
                                        <div class="form-group col-md-6 col-sm-12">
                                            <label for="txtNombre">Nombre</label>
                                            <div class="input-group border-input">
                                                    <div class="input-group-prepend bg-transparent ">
                                                    <span class="input-group-text bg-transparent border-right-0 border-color-principal">
                                                        <i class="fas fa-edit text-primary" aria-hidden="true"></i>
                                                    </span>
                                                    </div>                  

                                                <input name="txtNombre" type="text" id="txtNombre" class="form-control form-control-sm border-color-principal pl-1 txtNombre" placeholder="Nombre" runat="server" required/>
                                            </div>                                     
                                        </div>
                                        <div class="form-group col-md-6 col-sm-12">
                                            <label for="txtApellido">Apellidos</label>
                                            <div class="input-group border-input">
                                                <div class="input-group-prepend bg-transparent ">
                                                    <span class="input-group-text bg-transparent border-right-0 border-color-principal">
                                                        <i class="fas fa-edit text-primary" aria-hidden="true"></i>
                                                    </span>
                                                </div>
                                                <input name="txtApellido" type="text" id="txtApellido" class="form-control form-control-sm border-color-principal pl-1 txtApellido" placeholder="Apellidos" runat="server" required/>
                                            </div>                                     
                                        </div>

                                        <div class="form-group col-md-6 col-sm-12">
                                            <label for="txtDNI">DNI</label>
                                            <div class="input-group border-input">
                                                <div class="input-group-prepend bg-transparent ">
                                                    <span class="input-group-text bg-transparent border-right-0 border-color-principal">
                                                        <i class="far fa-id-card text-primary" aria-hidden="true"></i>
                                                    </span>
                                                </div>
                                                <input name="txtDNI" type="text" id="txtDNI" class="form-control form-control-sm border-color-principal pl-1 txtDNI" placeholder="DNI" runat="server" required/>
                                            </div>                                     
                                        </div>

                                        <div class="form-group col-md-6 col-sm-12 div-ocultar">
                                            <label for="txtEmail">Email</label>
                                            <div class="input-group border-input">
                                                <div class="input-group-prepend bg-transparent ">
                                                    <span class="input-group-text bg-transparent border-right-0 border-color-principal">
                                                        <i class="fas fa-user text-primary" aria-hidden="true"></i>
                                                    </span>
                                                </div>
                                                <input name="txtEmail" type="text" id="txtEmail" class="form-control form-control-sm border-color-principal pl-1 txtEmail" placeholder="Email" runat="server" required/>
                                            </div>                                     
                                        </div>

                                        <div class="form-group col-md-6 col-sm-12 div-ocultar">
                                            <label for="txtContrasenia">Contraseña</label>
                                            <div class="input-group border-input">
                                                <div class="input-group-prepend bg-transparent ">
                                                    <span class="input-group-text bg-transparent border-right-0 border-color-principal">
                                                        <i class="fas fa-lock text-primary" aria-hidden="true"></i>
                                                    </span>
                                                </div>
                                                <input name="txtContrasenia" type="password" id="txtContrasenia" class="form-control form-control-sm border-color-principal pl-1 txtContrasenia" placeholder="Contraseña" runat="server" required/>
                                            </div>                                     
                                        </div>

                                        <div class="form-group col-md-6 col-sm-12 div-ocultar">
                                            <label for="txtContrasenia2">Confirmar Contraseña</label>
                                            <div class="input-group border-input">
                                                <div class="input-group-prepend bg-transparent ">
                                                    <span class="input-group-text bg-transparent border-right-0 border-color-principal">
                                                        <i class="fas fa-lock text-primary" aria-hidden="true"></i>
                                                    </span>
                                                </div>
                                                <input name="txtContrasenia2" type="password" id="txtContrasenia2" class="form-control form-control-sm border-color-principal pl-1 txtContrasenia2" placeholder="Confirmar Contraseña" runat="server" required/>
                                            </div>                                     
                                        </div>

                                        <div class="form-group col-md-6 col-sm-12">
                                            <label for="cbPerfil">Perfil</label>
                                            <div class="input-group border-input">
                                                <select class="form-control form-control-lg pl-1 select-admin cbPerfil" id="cbPerfil" runat="server" required>
                                                    <option selected="selected" value="">Perfil</option>
                                                </select> 
                                            </div>
                                        </div>

                                        <div class="form-group col-md-6 col-sm-12">
                                            <label for="txtFechaNacimiento">Fecha Nacimiento</label>
                                            <div class="input-group border-input">
                                                <div class="input-group-prepend bg-transparent ">
                                                    <span class="input-group-text bg-transparent border-right-0 border-color-principal">
                                                        <i class="fas fa-calendar text-primary" aria-hidden="true"></i>
                                                    </span>
                                                </div>
                                                <input name="txtFechaNacimiento" type="date"  min="01-01-1900" id="txtFechaNacimiento" class="form-control form-control-sm border-color-principal pl-1 txtFechaNacimiento" placeholder="dd/mm/aaaa" runat="server" required/>
                                            </div>                                     
                                        </div>

                                        <div class="form-group col-md-6 col-sm-12">
                                            <label for="cbSexo">Sexo</label>
                                            <div class="input-group border-input">
                                                <select class="form-control form-control-lg pl-1 select-admin cbSexo" id="cbSexo" runat="server" required>
                                                    <option selected="selected" value="">- SELECCIONE SEXO -</option>
                                                    <option value="Femenino">Femenino</option>
                                                    <option value="Masculino">Masculino</option>
                                                    <option value="No especificado">No especificado</option>
                                                </select> 
                                            </div>
                                        </div>

                                    </div>                             

                                    <div class="form-group">
                                        <div class="alert alert-danger text-center" role="alert" runat="server" visible="false" id="divErrores">
                                            <asp:ListBox ID="lbErrores" runat="server" BackColor="Transparent" Width="100%" Enabled="false" CssClass="border-0 accordion text-danger overflow-hidden" Visible="false"></asp:ListBox>
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
    
    <!-- plugin js for this page -->
    <script src="http://www.urbanui.com/wagondash/template/vendors/datatables.net/jquery.dataTables.js"></script>
    <script src="http://www.urbanui.com/wagondash/template/vendors/datatables.net-bs4/dataTables.bootstrap4.js"></script>

    <script>

        $(".modal").on('hidden.bs.modal', () => $("html").css("overflow", "auto"));
        $(".modal").on('shown.bs.modal', () => $("html").css("overflow", "hidden"));

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
            <% 
                divErrores.Visible = false;
                lbErrores.Visible = false;
                lbErrores.Items.Clear();
            %>
            swal({
                title: "¿Desea Editar este usuario?",
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
                        text: "Editar",
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
                        url: 'GestionUsuario.aspx/CargarDataUsuario',
                        dataType: "json",
                        type: 'POST',
                        contentType: "application/json; charset=utf-8",
                        beforeSend: function () {

                        },
                        success: function (response) {
                            var data = JSON.parse(response.d)["objUsuario"];
                            console.log(data);
                            console.log(data["Persona"]);
                            $(".div-ocultar").css("display", "none")
                            $(".txtEmail").prop("required",false);
                            $(".txtContrasenia").prop("required", false);
                            $(".txtContrasenia2").prop("required", false);
                            $(".txtId").val(id);
                            $(".txtPersona").val(data["Persona"]["Id"]);
                            $(".txtNombre").val(data["Persona"]["Nombre"]);
                            $(".txtApellido").val(data["Persona"]["Apellidos"]);
                            $(".txtDNI").val(data["Persona"]["Dni"]);
                            $(".txtFechaNacimiento").val(data["Persona"]["FechaNacimiento"].substring(0,10));
                            $(".cbSexo").val(data["Persona"]["Sexo"]);
                            $(".cbPerfil").val(data["IdPerfil"]);
                            $(".title").html("Actualización de Usuario")
                            $(".btnEnviar").html("Actualizar")
                            $(".txtTipo").val(2)

                            $("#modalCreate").modal("show")
                        },
                        error: function (e) {
                            console.log(e)
                        }
                    });

                } else {
                    swal("Operación cancelada");
                }
            });
            
        }

        function eliminar(id) {
            swal({
                title: "¿Desea Eliminar este usuario?",
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
                        text: "Eliminar",
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
                        url: 'GestionUsuario.aspx/EliminarData',
                        dataType: "json",
                        type: 'POST',
                        contentType: "application/json; charset=utf-8",
                        beforeSend: function () {

                        },
                        success: function (response) {
                            swal("El usuario ha sido eliminado correctamente", {
                                icon: "success",
                            });
                            location.href = "GestionUsuario.aspx";
                        },
                        error: function (e) {
                            console.log(e)
                        }
                    }).done(function (html) {
                        swal("El módulo ha sido eliminado correctamente", {
                            icon: "success",
                            timer: 2000
                        });
                        location.href = "GestionUsuario.aspx";
                    });

                } else {
                    swal("Operación cancelada");
                }
            });
        }

        function limpiar() {
            $(".txtId").val("");
            $(".txtNombre").val("");
            $(".txtApellido").val("");
            $(".txtEmail").val("");
            $(".txtDNI").val("");
            $(".txtContrasenia").val("");
            $(".txtContrasenia2").val("");
            $(".txtFechaNacimiento").val("");
            $(".cbSexo").val("");
            $(".cbPerfil").val("0");
            $(".title").html("Registro de Usuario")
            $(".btnEnviar").html("Agregar")
            $(".txtTipo").val(1)
            $(".div-ocultar").css("display", "block")
            $(".txtEmail").prop("required", true);
            $(".txtContrasenia").prop("required", true);
            $(".txtContrasenia2").prop("required", true);
        }

    </script>
</asp:Content>
