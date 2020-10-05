<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="GestionUsuarioAprobados.aspx.cs" Inherits="VictoriaApp.GestionUsuarioAprobados" %>
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
                            
                                <%--<button id="btnNuevo" type="button" class="btn btn-primary" data-toggle="modal" data-target="#modalCreate" OnClick="limpiar()">
                                    Registrar Usuario
                                </button>--%>

                                <asp:Button ID="btnExportar" runat="server" Text="Button" OnClick="btnExportar_Click" />   
                                
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
                                        <th class="search">Usuario</th>
                                        <th class="search">Fecha</th>
                                        <%--<th>Opciones</th>--%>
                                    </tr>
                                    </thead>
                                    <tbody runat="server" id="tbody_modulo">
                                    <%--    <tr>
                                            <td>1</td>
                                            <td></td>
                                            <td>
                                            </td>
                                        </tr>--%>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>


            </div>

        </div>
    </div>
    
    <!-- plugin js for this page -->
<%--    <script src="http://www.urbanui.com/wagondash/template/vendors/datatables.net/jquery.dataTables.js"></script>
    <script src="http://www.urbanui.com/wagondash/template/vendors/datatables.net-bs4/dataTables.bootstrap4.js"></script>--%>

    <script src="vendors/datatables.net/jquery.dataTables.js"></script>
    <script src="vendors/datatables.net-bs4/dataTables.bootstrap4.js"></script>
    <script src="Scripts/js/datatable.js"></script>
    <script>

        $(".modal").on('hidden.bs.modal', () => $("html").css("overflow", "auto"));
        $(".modal").on('shown.bs.modal', () => $("html").css("overflow", "hidden"));


        function cargarData(id) {
           
            swal({
                title: "¿Desea Editar este usuario?",
                text: "Esta acción no se podrá revertir",
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3f51b5',
                cancelButtonColor: '#ff4081',
                confirmButtonText: 'Great ',
                buttons: {
                    
                    confirm: {
                        text: "Editar",
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
                            $(".btnEnviar").val("Actualizar")
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
                        swal("El usuario ha sido eliminado correctamente", {
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
            $(".btnEnviar").val("Agregar")
            $(".txtTipo").val(1)
            $(".div-ocultar").css("display", "block")
            $(".txtEmail").prop("required", true);
            $(".txtContrasenia").prop("required", true);
            $(".txtContrasenia2").prop("required", true);
        }

    </script>
</asp:Content>
