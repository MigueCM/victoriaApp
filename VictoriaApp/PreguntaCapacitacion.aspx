<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="PreguntaCapacitacion.aspx.cs" Inherits="VictoriaApp.PreguntaCapacitacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
            <div class="col-12">
                <div class="card">
                    <div class="card-body">
                        <h4 class="card-title">Preguntas</h4>
                        <hr />

                        <div class="row">
                            <div class="col-lg-12 col-md-12">
                                <div class="form-group ">
                            
                                    <button id="btnNuevo" type="button" class="btn btn-primary" data-toggle="modal" data-target="#modalCreate" onClick="limpiar()">
                                        Registrar Preguntas
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
                                            <th>Orden</th>
                                            <th class="search">Pregunta</th>
                                            <th>Opciones</th>
                                        </tr>
                                      </thead>
                                      <tbody runat="server" id="tbody_modulo">
                                        <tr>
                                            <td>1</td>
                                            <td>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore 
                                                magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo 
                                                consequat.
                                            </td>
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

                    <form method="post" runat="server">
             <%--           <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>--%>
                         <div class="modal fade" id="modalCreate" tabindex="-1" role="dialog" aria-labelledby="modalCreate-2" aria-hidden="true">
                            <div class="modal-dialog" role="document">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h5 class="modal-title title" id="title" runat="server">Registro de Pregunta</h5>
                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                        <span aria-hidden="true">&times;</span>
                                        </button>
                                    </div>
                                    <div class="modal-body">
                                        <input type="hidden" class="txtId" name="txtId" id="txtId" value=""  runat="server" />
                                        <input type="hidden" class="txtTipo" name="txtTipo" id="txtTipo" value="1"  runat="server" />                                        
                                        <div class="form-group">
                                            <label for="txtDescripcion">Descripción</label>
                                            <div class="input-group border-input">
                                                <textarea class="form-control form-control-sm border-color-principal txtDescripcion" id="txtDescripcion" placeholder="Descripcion" runat="server" required></textarea>
                                            </div>                                     
                                        </div>
                                        <div class="form-group">
                                            <label for="cboOrden">Orden</label>
                                            <div class="input-group border-input">
                                                <select class="form-control form-control-sm select-admin cboOrden" id="cboOrden" runat="server" required>
                                                    <%--<option value="">Seleccione Orden</option>
                                                    <option value="1">1</option>--%>
                                                </select>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="txtAlternativa1">Alternativa 1</label>
                                            <div class="input-group border-input">
                                                <textarea class="form-control form-control-sm border-color-principal txtAlternativa1" id="txtAlternativa1" placeholder="Alternativa 1" runat="server" required></textarea>
                                            </div>                                     
                                        </div>
                                        <div class="form-group">
                                            <label for="txtAlternativa2">Alternativa 2</label>
                                            <div class="input-group border-input">
                                                <textarea class="form-control form-control-sm border-color-principal txtAlternativa2" id="txtAlternativa2" placeholder="Alternativa 2" runat="server" required></textarea>
                                            </div>                                     
                                        </div>
                                        <div class="form-group">
                                            <label for="txtAlternativa3">Alternativa 3</label>
                                            <div class="input-group border-input">
                                                <textarea class="form-control form-control-sm border-color-principal txtAlternativa3" id="txtAlternativa3" placeholder="Alternativa 3" runat="server" required></textarea>
                                            </div>                                     
                                        </div>
                                        <div class="form-group">
                                            <label for="txtAlternativa4">Alternativa 4</label>
                                            <div class="input-group border-input">
                                                <textarea class="form-control form-control-sm border-color-principal txtAlternativa4" id="txtAlternativa4" placeholder="Alternativa 4" runat="server" required></textarea>
                                            </div>                                     
                                        </div>
                                        <div class="form-group">
                                            <label for="txtAlternativa5">Alternativa 5</label>
                                            <div class="input-group border-input">
                                                <textarea class="form-control form-control-sm border-color-principal txtAlternativa5" id="txtAlternativa5" placeholder="Alternativa 5" runat="server" required></textarea>
                                            </div>                                     
                                        </div>
                                       <div class="form-group">
                                            <label for="cboAlternativa">Respuesta</label>
                                            <div class="input-group border-input">
                                                <select class="form-control form-control-sm select-admin cboAlternativa" id="cboAlternativa" runat="server" required>
                                                    <option value="">Seleccione Alternativa</option>
                                                    <option value="1">Alternativa 1</option>
                                                    <option value="2">Alternativa 2</option>
                                                    <option value="3">Alternativa 3</option>
                                                    <option value="4">Alternativa 4</option>
                                                    <option value="5">Alternativa 5</option>
                                                </select>
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
            orderCellsTop: true,
            fixedHeader: true
        });

        function cargarData(id) {

            var parametros = "{'id': '" + id + "'}";

            $.ajax({
                data: parametros,
                url: 'PreguntaCapacitacion.aspx/CargarDataPreguntas',
                dataType: "json",
                type: 'POST',
                contentType: "application/json; charset=utf-8",
                beforeSend: function () {

                },
                success: function (response) {
                    var data = JSON.parse(response.d)["objPreguntas"];

                    $(".txtId").val(id);
                    $(".cboOrden").val(data["Orden"]);
                    $(".txtDescripcion").val(data["Descripcion"]);
                    $(".txtAlternativa1").val(data["Alternativa1"]);
                    $(".txtAlternativa2").val(data["Alternativa2"]);
                    $(".txtAlternativa3").val(data["Alternativa3"]);
                    $(".txtAlternativa4").val(data["Alternativa4"]);
                    $(".txtAlternativa5").val(data["Alternativa5"]);
                    $(".cboAlternativa").val(data["Respuesta"]);
                    $(".title").html("Actualización de Pregunta")
                    $(".btnEnviar").html("Actualizar")
                    $(".txtTipo").val(2)
                    
                    $("#modalCreate").modal("show")
                },
                error: function (e) {
                    console.log(e)
                }
            });
        }

        function eliminar(id) {
            if (confirm("Desea Eliminar esta pregunta")) {
                var parametros = "{'id': '" + id + "'}";

                $.ajax({
                    data: parametros,
                    url: 'PreguntaCapacitacion.aspx/EliminarData',
                    dataType: "json",
                    type: 'POST',
                    contentType: "application/json; charset=utf-8",
                    beforeSend: function () {

                    },
                    success: function (response) {
                        console.log(response)
                        location.href = "PreguntaCapacitacion.aspx";
                    },
                    error: function (e) {
                        console.log(e)
                    }
                });
            }
            
        }

        function limpiar() {
            $(".txtId").val("");
            $(".cboOrden").val($(".cboOrden option:last").val());
            $(".txtDescripcion").val("");
            $(".txtAlternativa1").val("");
            $(".txtAlternativa2").val("");
            $(".txtAlternativa3").val("");
            $(".txtAlternativa4").val("");
            $(".txtAlternativa5").val("");
            $(".cboAlternativa").val("");
            $(".title").html("Registro de Pregunta")
            $(".btnEnviar").html("Agregar")
            $(".txtTipo").val(1)
        }

    </script>

</asp:Content>
