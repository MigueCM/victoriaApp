function limpiarForo() {
    $("#txtTitulo").val("");
    $("#txtDescripcionPregunta").val("");
    $("#cbModulo").val(0)

}

function enviarFormulario() {
    var titulo = $("#txtTitulo").val();
    var contenido = $("#txtDescripcionPregunta").val();
    var idModulo = $("#cbModulo").val();

    var parametros = "{'titulo': '" + titulo + "', 'contenido': '" + contenido + "', 'idModulo': '" + idModulo + "'}";

    $.ajax({
        data: parametros,
        url: 'Principal.aspx/EnviarDatos',
        dataType: "json",
        type: 'POST',
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            var result = JSON.parse(response.d);
            showSwal(result.codAlerta, result.cabecera, result.body, result.url, result.id);
        },
        error: function (e) {
            console.log(e)
        }
    });
}

function verVideo(codigo) {
    console.log(codigo)
    var parametros = "{'codigo': '" + codigo + "'}";

    $.ajax({
        data: parametros,
        url: 'Principal.aspx/ValidarUsuario',
        dataType: "json",
        type: 'POST',
        contentType: "application/json; charset=utf-8",
        beforeSend: function () {

        },
        success: function (response) {
            console.log(response)
            location.href = "Video.aspx";
        },
        error: function (e) {
            console.log(e)
        }
    });

}

$(function () {
    $.ajax({
        type: "POST",
        url: "Principal.aspx/getModules",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (r) {
            var ddlCustomers = $("[id*=cbModulo]");
            ddlCustomers.empty().append('<option selected="selected" value="0">Seleccione un modulo</option>');
            $.each(r.d, function () {
                ddlCustomers.append($("<option></option>").val(this['IdModuloCapacitacion']).html(this['Nombre']));
            });
        }
    });
});

function Votar() {
    var wasSubmitted = false;
    //var ClickImageId;
    $("#feed").on("click", "i", function (e) {
        if (!wasSubmitted) {
            e.preventDefault();
            var votar = $(this).attr('id');
            var parametros = "{'votar': '" + votar + "'}";
            $.ajax({
                data: parametros,
                url: 'Principal.aspx/Votar',
                dataType: "json",
                type: 'POST',
                contentType: "application/json; charset=utf-8",
                success: function (response) {
                    location.href = "Principal.aspx";
                },
                error: function (e) {
                    console.log(e)
                }
            });
            wasSubmitted = true;
            return wasSubmitted;
        }
        return false;

    });
}