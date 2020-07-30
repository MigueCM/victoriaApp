$(window).on('load', function () {
    /*loader hide */
    setTimeout(function () {
        $('.loader').fadeOut();
    }, 500);
    /* fixed header specific style */
    if ($('.header').hasClass('fixed-top') === true) {
        $('main').css('padding-top', $('.fixed-top').outerHeight());
        $(window).on('scroll', function () {
            if ($(this).scrollTop() >= 100) {
                $('.header').addClass('fill-header shadow-sm')
            } else {
                $('.header').removeClass('fill-header shadow-sm')
            }
        });
    }
});

deFechaNacimiento.max = new Date().toISOString().split("T")[0];
$("#cbEnterar").blur(function () {
    if (document.getElementById("cbEnterar").selectedIndex != 0) {
        $(this).css({ "background": "#A8A8F2" })
        $(this).css({ "color": "#ffff" })
    } else {
        $(this).css({ "background": "transparent" })
        $(this).css({ "color": "#495057" })
    }
});
$("#cbDepartamento").blur(function () {
    if (document.getElementById("cbDepartamento").selectedIndex != 0) {
        $(this).css({ "background": "#A8A8F2" })
        $(this).css({ "color": "#ffff" })
    } else {
        $(this).css({ "background": "transparent" })
        $(this).css({ "color": "#495057" })
    }
});
$("#cbCiudad").blur(function () {
    if (document.getElementById("cbCiudad").selectedIndex != 0) {
        $(this).css({ "background": "#A8A8F2" })
        $(this).css({ "color": "#ffff" })
    } else {
        $(this).css({ "background": "transparent" })
        $(this).css({ "color": "#495057" })
    }
});
$("#cbSexo").blur(function () {
    if (document.getElementById("cbSexo").selectedIndex != 0) {
        $(this).css({ "background": "#A8A8F2" })
        $(this).css({ "color": "#ffff" })
    } else {
        $(this).css({ "background": "transparent" })
        $(this).css({ "color": "#495057" })
    }
});
$("#txtDni").blur(function () {
    if ($('#txtDni').val().length != 0) {
        $(this).css({ "background": "#A8A8F2" })
        $(this).css({ "color": "#ffff" })
    } else {
        $(this).css({ "background": "transparent" })
        $(this).css({ "color": "#495057" })
    }
});
$("#txtNombre").blur(function () {
    if ($('#txtNombre').val().length != 0) {
        $(this).css({ "background": "#A8A8F2" })
        $(this).css({ "color": "#ffff" })
    } else {
        $(this).css({ "background": "transparent" })
        $(this).css({ "color": "#495057" })
    }
});
$("#txtApellidos").blur(function () {
    if ($('#txtApellidos').val().length != 0) {
        $(this).css({ "background": "#A8A8F2" })
        $(this).css({ "color": "#ffff" })
    } else {
        $(this).css({ "background": "transparent" })
        $(this).css({ "color": "#495057" })
    }
});
$("#txtUsuario").blur(function () {
    if ($('#txtUsuario').val().length != 0) {
        $(this).css({ "background": "#A8A8F2" })
        $(this).css({ "color": "#ffff" })
    } else {
        $(this).css({ "background": "transparent" })
        $(this).css({ "color": "#495057" })
    }
});
$("#txtPassword").blur(function () {
    if ($('#txtPassword').val().length != 0) {
        $(this).css({ "background": "#A8A8F2" })
        $(this).css({ "color": "#ffff" })
    } else {
        $(this).css({ "background": "transparent" })
        $(this).css({ "color": "#495057" })
    }
});
$("#deFechaNacimiento").blur(function () {
    if ($('#deFechaNacimiento').val().length != 0) {
        $(this).css({ "background": "#A8A8F2" })
        $(this).css({ "color": "#ffff" })
    } else {
        $(this).css({ "background": "transparent" })
        $(this).css({ "color": "#495057" })
    }
});
$("#txtCorreo").blur(function () {
    if ($('#txtCorreo').val().length != 0) {
        $(this).css({ "background": "#A8A8F2" })
        $(this).css({ "color": "#ffff" })
    } else {
        $(this).css({ "background": "transparent" })
        $(this).css({ "color": "#495057" })
    }
});
$("#txtCelular").blur(function () {
    if ($('#txtCelular').val().length != 0) {
        $(this).css({ "background": "#A8A8F2" })
        $(this).css({ "color": "#ffff" })
    } else {
        $(this).css({ "background": "transparent" })
        $(this).css({ "color": "#495057" })
    }
});