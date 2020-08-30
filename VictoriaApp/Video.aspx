<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Video.aspx.cs" Inherits="VictoriaApp.Video" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row"> 
        <div class="col-md-12 ">
            <div class="card">
                <div class="card-body" id="cardVideo">
                    
                    <div class="miniatura-video">
                        <img src="https://img.youtube.com/vi/<%=Session["video"]%>/sd1.jpg" style="width:100%;" onClick="$('#modalVideo').modal('show')" id="img_video" class="cursor-pointer"/>
                    </div>
                    
                      
                    <%--<div id="player2"></div>--%>

                    <div class="row">
                        <div class="col-sm-12">
                            <h1 style="padding-top:10px; padding-left:10px; color:#561179" runat="server" id="title_modulo">1. Lorem Ipsum is simply dummy text of the</h1>
                            <%--<h2 style="padding-top:10px; padding-left:10px;" runat="server" id="autor_modulo">Por Lorem Ipsum</h2>--%>
                            <p style="padding-top:10px; padding-left:10px; padding-right:10px; font-size:15px; color:#AFAFAF; text-align:justify" runat="server" id="descripcion_modulo">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus vitae felis justo. In suscipit purus id sem pharetra pulvinar. Nunc imperdiet nulla vel malesuada molestie. Aliquam rutrum egestas nibh bibendum tincidunt. Nulla viverra leo quis ultricies porta. Curabitur et semper erat. Suspendisse orci ex, lacinia scelerisque aliquet sit amet, porta at sapien</p>
                        </div>
                      </div>
                    <div class="row">
                        <div class="col-sm-9" style="padding-left:1rem; padding-bottom:10px;" id="div_calificacion" runat="server">
                            <i class="fas fa-star color-star"></i> 5 &nbsp;&nbsp;&nbsp;
                            <i class="fas fa-play text-primary"></i> 8,365
                        </div>
                        <div class="col-sm-3" style="padding-left:1rem; padding-bottom:10px;">
                            <button style="border-radius:20px; background-color:#27003A; color:#ffff;" id="btnSiguiente">Siguiente módulo</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <input type="hidden" name="num_intentos" id="num_intentos" class="num_intentos" runat="server" />
    <input type="hidden" name="ultimo_modulo" id="ultimo_modulo" class="ultimo_modulo" runat="server" />
    <input type="hidden" name="estado_aprobado" id="estado_aprobado" class="estado_aprobado" runat="server" />

    <div class="modal fade" id="modalVideo" tabindex="-1" role="dialog" aria-labelledby="modalCreate-2" aria-hidden="true">
                            <div class="modal-dialog" role="document">
                                <div class="modal-content" style="width: 620px;">
                                    <div class="modal-header">
                                        <h5 class="modal-title title" id="title" runat="server"></h5>
                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                        <span aria-hidden="true">&times;</span>
                                        </button>
                                    </div>
                                    <div class="modal-body p-0">
                                        <div id="player">

                                        </div>
                                    </div>
                                    <%--<div class="modal-footer">
                                         <asp:Button ID="btnEnviar" runat="server" Text="Agregar" class="btn btn-primary font-weight-medium btnEnviar" OnClick="btnEnviar_Click"/>
                                        
                                        <button type="reset" class="btn btn-danger" data-dismiss="modal">Cancelar</button>
                                    </div>--%>
                                </div>
                            </div>
                        </div>

    <div class="modal fade" id="modalCuestionario" tabindex="-1" role="dialog" aria-labelledby="modalCreate-2" aria-hidden="true">
            <div class="modal-dialog mt-3" role="document">
                <div class="modal-content modal-border">
                   <%-- <div class="modal-header">
                        <h5 class="modal-title title" id="H1" runat="server">Cuestionario</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                        </button>
                    </div>--%>
                    <div class="modal-body">
                        <h2 class="text-primary text-center">Cuestionario</h2>

                        <div class="mt-4 div_cuestionario" runat="server" id="div_cuestionario">                           
                            
                            <div class="form-group">
                                <label class="mb-0">1. Lorem Ipsum asd asd asd asd asd asd</label>
                                <div class="form-check form-check-primary">
                                    <label class="form-check-label">
                                      <input type="radio" class="form-check-input" name="rb-1">
                                      Lorem ipsum
                                    <i class="input-helper"></i></label>
                                </div>
                                <div class="form-check form-check-primary">
                                    <label class="form-check-label">
                                      <input type="radio" class="form-check-input" name="rb-1">
                                      Lorem ipsum
                                    <i class="input-helper"></i></label>
                                </div>
                                <div class="form-check form-check-primary">
                                    <label class="form-check-label">
                                      <input type="radio" class="form-check-input" name="rb-1">
                                      Lorem ipsum
                                    <i class="input-helper"></i></label>
                                </div>
                                <div class="form-check form-check-primary">
                                    <label class="form-check-label">
                                      <input type="radio" class="form-check-input" name="rb-1">
                                      Lorem ipsum
                                    <i class="input-helper"></i></label>
                                </div>
                            </div>
                             <div class="form-group">
                                <label class="mb-0">2. Lorem Ipsum asd asd asd asd asd asd</label>
                                <div class="form-check form-check-primary">
                                    <label class="form-check-label">
                                      <input type="radio" class="form-check-input" name="rb-2">
                                      Lorem ipsum
                                    <i class="input-helper"></i></label>
                                </div>
                                <div class="form-check form-check-primary">
                                    <label class="form-check-label">
                                      <input type="radio" class="form-check-input" name="rb-2">
                                      Lorem ipsum
                                    <i class="input-helper"></i></label>
                                </div>
                                <div class="form-check form-check-primary">
                                    <label class="form-check-label">
                                      <input type="radio" class="form-check-input" name="rb-2">
                                      Lorem ipsum
                                    <i class="input-helper"></i></label>
                                </div>
                                <div class="form-check form-check-primary">
                                    <label class="form-check-label">
                                      <input type="radio" class="form-check-input" name="rb-2">
                                      Lorem ipsum
                                    <i class="input-helper"></i></label>
                                </div>
                            </div>
                             <div class="form-group">
                                <label class="mb-0">3. Lorem Ipsum asd asd asd asd asd asd</label>
                                <div class="form-check form-check-primary">
                                    <label class="form-check-label">
                                      <input type="radio" class="form-check-input" name="rb-2">
                                      Lorem ipsum
                                    <i class="input-helper"></i></label>
                                </div>
                                <div class="form-check form-check-primary">
                                    <label class="form-check-label">
                                      <input type="radio" class="form-check-input" name="rb-2">
                                      Lorem ipsum
                                    <i class="input-helper"></i></label>
                                </div>
                                <div class="form-check form-check-primary">
                                    <label class="form-check-label">
                                      <input type="radio" class="form-check-input" name="rb-2">
                                      Lorem ipsum
                                    <i class="input-helper"></i></label>
                                </div>
                                <div class="form-check form-check-primary">
                                    <label class="form-check-label">
                                      <input type="radio" class="form-check-input" name="rb-2">
                                      Lorem ipsum
                                    <i class="input-helper"></i></label>
                                </div>
                            </div>
                             <div class="form-group">
                                <label class="mb-0">4. Lorem Ipsum asd asd asd asd asd asd</label>
                                <div class="form-check form-check-primary">
                                    <label class="form-check-label">
                                      <input type="radio" class="form-check-input" name="rb-2">
                                      Lorem ipsum
                                    <i class="input-helper"></i></label>
                                </div>
                                <div class="form-check form-check-primary">
                                    <label class="form-check-label">
                                      <input type="radio" class="form-check-input" name="rb-2">
                                      Lorem ipsum
                                    <i class="input-helper"></i></label>
                                </div>
                                <div class="form-check form-check-primary">
                                    <label class="form-check-label">
                                      <input type="radio" class="form-check-input" name="rb-2">
                                      Lorem ipsum
                                    <i class="input-helper"></i></label>
                                </div>
                                <div class="form-check form-check-primary">
                                    <label class="form-check-label">
                                      <input type="radio" class="form-check-input" name="rb-2">
                                      Lorem ipsum
                                    <i class="input-helper"></i></label>
                                </div>
                            </div>
                             <div class="form-group">
                                <label class="mb-0">5. Lorem Ipsum asd asd asd asd asd asd</label>
                                <div class="form-check form-check-primary">
                                    <label class="form-check-label">
                                      <input type="radio" class="form-check-input" name="rb-2">
                                      Lorem ipsum
                                    <i class="input-helper"></i></label>
                                </div>
                                <div class="form-check form-check-primary">
                                    <label class="form-check-label">
                                      <input type="radio" class="form-check-input" name="rb-2">
                                      Lorem ipsum
                                    <i class="input-helper"></i></label>
                                </div>
                                <div class="form-check form-check-primary">
                                    <label class="form-check-label">
                                      <input type="radio" class="form-check-input" name="rb-2">
                                      Lorem ipsum
                                    <i class="input-helper"></i></label>
                                </div>
                                <div class="form-check form-check-primary">
                                    <label class="form-check-label">
                                      <input type="radio" class="form-check-input" name="rb-2">
                                      Lorem ipsum
                                    <i class="input-helper"></i></label>
                                </div>
                            </div>
                        </div>
                        <div class="mt-5">
                            <label class="h4 text-primary mr-4">Califica este módulo</label>
                            <p class="clasificacion">
                                <input id="radio1" type="radio" name="estrellas" value="5">
                                <label for="radio1">★</label>
                                <input id="radio2" type="radio" name="estrellas" value="4">
                                <label for="radio2">★</label>
                                <input id="radio3" type="radio" name="estrellas" value="3">
                                <label for="radio3">★</label>
                                <input id="radio4" type="radio" name="estrellas" value="2">
                                <label for="radio4">★</label>
                                <input id="radio5" type="radio" name="estrellas" value="1">
                                <label for="radio5">★</label>
                              </p>

                            <button class="btn btn-primary btn-validar" style="float:right;height: 33px;" onclick="ValidarCampos()" type="button">Completar</button>
                            <button class="btn btn-primary btn-loading" style="float:right" type="button">
                                <div class="dot-opacity-loader">
                                      <span></span>
                                      <span></span>
                                      <span></span>
                                </div>
                            </button>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    <div class="modal fade" id="modalCertificado" tabindex="-1" role="dialog" aria-labelledby="modalCreate-2" aria-hidden="true">
            <div class="modal-dialog mt-3" role="document">
                <div class="modal-content modal-border">
                   
                    <div class="modal-body">
                        <h2 class="text-primary text-center">Certificado</h2>

                        <div class="mt-4 text-center">                           
                            <h3 class="text-primary">Felicitaciones completaste todos los módulos satisfactoriamente. </h3>
                            <button type="button" runat="server" id="btnCertificado" onserverclick="btnCertificado_ServerClick" class="btn btn-primary btn-rounded btn-fw" onclick="SetTarget();">Descargar Certificado</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    <script src="https://www.youtube.com/iframe_api"></script>
    <script>

        if ($(".ultimo_modulo").val() == "1") {
            $("#btnSiguiente").css("display", "none");
        }

        $(".btn-loading").hide();
        $("#modalCuestionario").on('hidden.bs.modal', () => $("html").css("overflow", "auto"));
        $("#modalCuestionario").on('shown.bs.modal', () => $("html").css("overflow", "hidden"));
        $("#modalCertificado").on('hidden.bs.modal', () => location.href = "Principal.aspx");

        $("#modalVideo").on('hidden.bs.modal', function () {
            $("html").css("overflow", "auto");
            if (done == true && $(".num_intentos").val() < 3 && $(".estado_aprobado").val() == 0) {
                $("html").css("overflow", "hidden")
                $("#modalCuestionario").modal('show');
                done = false;
            } else {
                pauseVideo();
            }
        });
        $("#modalVideo").on('shown.bs.modal	', function () {
            $("html").css("overflow", "hidden");
            playVideo();
        });
        var player;
        function onYouTubeIframeAPIReady() {
            player = new YT.Player('player', {
                height: '420',
                width: '620',
                videoId: '<%=Session["video"]%>',
                //playerVars: { 'controls': 0 },
                events: {
                    //'onReady': onPlayerReady,
                    'onStateChange': onPlayerStateChange
                }
            });

        }


        function onPlayerReady(event) {
            event.target.playVideo();
        }

        var done = false;
        function onPlayerStateChange(event) {
            if (event.data == YT.PlayerState.ENDED) {
                done = true;
                $("#modalVideo").modal('hide');
            }
        }

        function onPlayerStateChange2(event) {

        }

        function stopVideo() {
            player.stopVideo();
        }

        function pauseVideo() {
            player.pauseVideo();
        }

        function playVideo() {
            player.playVideo();
        }

        function SetTarget() {
            document.forms[0].target = "_blank";
        }

        function ValidarCampos() {
            //console.log("entro");
            $(".btn-validar").hide();
            $(".btn-loading").show();
            var num_preguntas = $(".div_cuestionario").data("num");

            var flag = true;
            var arreglo = [];
            for (var i = 1; i <= num_preguntas; i++) {
                var value = $(".div_cuestionario input[name=rb-" + i + "]:checked").val();
                arreglo.push(value);
                if ($(".div_cuestionario input[name=rb-"+i+"]:checked").length == 0)
                    flag = false;

            }


            if (flag == true) {

                if ($(".clasificacion input[type=radio]:checked").length == 0) {
                    $(".btn-validar").show();
                    $(".btn-loading").hide();
                    swal("Error", "Debe calificar este módulo", "error");
                } else {

                    if ($(".num_intentos").val() < 3) {
                        var parametros = "{'respuestas': '" + arreglo + "', 'calificacion':" + $(".clasificacion input[type=radio]:checked").val() + "}";

                        console.log(arreglo);
                        $.ajax({
                            data: parametros,
                            url: 'Video.aspx/ValidarData',
                            dataType: "json",
                            type: 'POST',
                            contentType: "application/json; charset=utf-8",
                            beforeSend: function () {
                                
                            },
                            success: function (response) {
                                $(".btn-validar").show();
                                $(".btn-loading").hide();
                                var data = JSON.parse(response.d)
                                console.log(data)
                                $(".num_intentos").val(parseInt($(".num_intentos").val()) + 1) ;
                                if (data["aprobado"]) {
                                    if (data["porcentaje"] > 99.90) {
                                        $("#modalCuestionario").modal('hide');
                                        $("#modalCertificado").modal("show");
                                    } else {
                                        location.href = "Panel.aspx";
                                    }
                                    
                                } else {
                                   
                                    if ($(".num_intentos").val() > 2) {
                                        $("#modalCuestionario").modal('hide');
                                        $(".num_intentos").val(0)
                                        swal("Error", "No ha contestado correctamente todas las preguntas. Ya supero el numero de intentos permitidos", "error");
                                        limpiarCuestionario();
                                    } else {
                                        swal("Error", "No ha contestado correctamente todas las preguntas.", "error");
                                    }
                                }
                            },
                            error: function (e) {
                                console.log(e)
                            }
                        });
                    } else {
                        $(".btn-validar").show();
                        $(".btn-loading").hide();
                        swal("Error", "Ya supero los numeros de intentos permitidos", "error");
                        $("#modalCuestionario").modal('hide');
                        $(".num_intentos").val(0)
                        limpiarCuestionario();
                    }

                }
            }
            else {
                $(".btn-validar").show();
                $(".btn-loading").hide();
                swal("Error", "Debe responder todas las preguntas", "error");
            }     
        }

        function limpiarCuestionario() {
            $(".clasificacion input[type=radio]").prop("checked", false)
            $(".div_cuestionario input[type=radio]").prop("checked", false)
        }

        $("#btnSiguiente").click(function () {
            $.ajax({
                //data: parametros,
                url: 'Video.aspx/ValidarSiguienteModulo',
                dataType: "json",
                type: 'POST',
                contentType: "application/json; charset=utf-8",
                beforeSend: function () {

                },
                success: function (response) {
                    console.log(response)
                    if (response["d"] == true)
                        location.href = "Video.aspx";
                    else
                        swal("Error", "Debe completar otros modulos", "error");
                },
                error: function (e) {
                    console.log(e)
                }
            });
        });

    </script>
</asp:Content>
