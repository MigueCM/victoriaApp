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