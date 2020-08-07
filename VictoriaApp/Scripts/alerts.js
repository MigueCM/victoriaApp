(function ($) {
    showSwal = function (type, titulo,mensaje, url, id) {
        'use strict';
        if (type === 'basic') {
            swal({
                text: 'Este módulo ya ha sido completado',
                button: {
                    text: "OK",
                    value: true,
                    visible: true,
                    className: "btn btn-primary"
                }
            })

        } else if (type === 'title-and-text') {
            swal({
                title: 'Read the alert!',
                text: 'Click OK to close this alert',
                button: {
                    text: "OK",
                    value: true,
                    visible: true,
                    className: "btn btn-primary"
                }
            })

        } else if (type === 'success-message') {
            swal({
                title: titulo,
                text: mensaje,
                icon: 'success',
                button: {
                    text: "Aceptar",
                    value: true,
                    visible: true,
                    className: "btn btn-primary"
                }
            }).then(function () { window.location.href = url;})

        } else if (type === 'auto-close') {
            swal({
                title: titulo,
                text: mensaje,
                icon: 'success',
                timer: 2000,
                button: false
            }).then(
                function () { },
                // handling the promise rejection
                function (dismiss) {
                    if (dismiss === 'timer') {
                        console.log('I was closed by the timer')
                    }
                }
            )
        } else if (type === 'warning-message-and-cancel') {
            swal({
                title: titulo,
                text: mensaje,
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
                    swal("Poof! Your imaginary file has been deleted!", {
                        icon: "success",
                    });
                } else {
                    swal("Your imaginary file is safe!");
                }
            });

        } else if (type === 'custom-html') {
            swal({
                content: {
                    element: "input",
                    attributes: {
                        placeholder: "Seleccione un archivo",
                        type: "file",
                        class: 'form-control'
                    },
                },
                button: {
                    text: "OK",
                    value: true,
                    visible: true,
                    className: "btn btn-primary",
                    id: "btnImagen",
                    onclick: "btnImagen_Click",
                    runat: "server"
                }
            })
        }
        else if (type === 'delete-module') {
            swal({
                title: "¿Desea Eliminar este módulo?",
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
                        url: 'ModuloCapacitacion.aspx/EliminarData',
                        dataType: "json",
                        type: 'POST',
                        contentType: "application/json; charset=utf-8",
                        beforeSend: function () {

                        },
                         success: function (response) {
                            swal("El módulo ha sido eliminado correctamente", {
                                icon: "success",
                            });
                            location.href = "ModuloCapacitacion.aspx";
                        },
                        error: function (e) {
                            console.log(e)
                        }
                    }).done(function (html) {
                        swal("El módulo ha sido eliminado correctamente", {
                            icon: "success",
                            timer: 2000
                        });
                        location.href = "ModuloCapacitacion.aspx";
                    });

                } else {
                    swal("Operación cancelada");
                }
            });
        }
        else if (type === 'success-message-terminos') {
            swal({
                title: titulo,
                text: mensaje,
                icon: 'success',
                button: {
                    text: "Aceptar",
                    value: true,
                    visible: true,
                    className: "btn btn-primary"
                }
            }).then(function () { window.location.href = url; })

        }
        else if (type === 'update-module') {
            swal({
                title: "¿Desea Editar este módulo?",
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
                            $(".txtFile").prop("required", false)
                            $("#modalCreate").modal("show")
                        },
                        error: function (e) {
                            console.log(e)
                        }
                    });
                    //$.ajax({
                    //    data: parametros,
                    //    url: 'ModuloCapacitacion.aspx/EliminarData',
                    //    dataType: "json",
                    //    type: 'POST',
                    //    contentType: "application/json; charset=utf-8",
                    //    beforeSend: function () {

                    //    },
                    //    success: function (response) {
                    //        swal("El módulo ha sido eliminado correctamente", {
                    //            icon: "success",
                    //        });
                    //        location.href = "ModuloCapacitacion.aspx";
                    //    },
                    //    error: function (e) {
                    //        console.log(e)
                    //    }
                    //}).done(function (html) {
                    //    swal("El módulo ha sido eliminado correctamente", {
                    //        icon: "success",
                    //        timer: 2000
                    //    });
                    //    location.href = "ModuloCapacitacion.aspx";
                    //});

                } else {
                    swal("Operación cancelada");
                }
            });
        }
    }

})(jQuery);