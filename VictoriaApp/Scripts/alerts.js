(function ($) {
    showSwal = function (type, titulo,mensaje, url) {
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
                title: 'Auto close alert!',
                text: 'I will close in 2 seconds.',
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
                        placeholder: "Type your password",
                        type: "password",
                        class: 'form-control'
                    },
                },
                button: {
                    text: "OK",
                    value: true,
                    visible: true,
                    className: "btn btn-primary"
                }
            })
        }
        else if (type === 'delete-module') {
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
                    swal("El módulo ha sido eliminado correctamente", {
                        icon: "success",
                    });
                } else {
                    swal("Operación cancelada");
                }
            })
                .then(json => {
                    console.log(json);
                });

        }
    }

})(jQuery);