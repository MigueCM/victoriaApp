<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Video.aspx.cs" Inherits="VictoriaApp.Video" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row"> 
        <div class="col-md-12 ">
            <div class="card">
                <div class="card-body" id="cardVideo">
                    
                        <img src="images/video.png" style="width:100%" onClick="$('#modalVideo').modal('show')"/>
                      
                      <div class="row">
                        <div class="col-sm-12">
                            <h1 style="padding-top:10px; padding-left:10px; color:#561179" runat="server" id="title_modulo">1. Lorem Ipsum is simply dummy text of the</h1>
                            <h2 style="padding-top:10px; padding-left:10px;" runat="server" id="autor_modulo">Por Lorem Ipsum</h2>
                            <p style="padding-top:10px; padding-left:10px; padding-right:10px; font-size:15px; color:#AFAFAF; text-align:justify" runat="server" id="descripcion_modulo">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus vitae felis justo. In suscipit purus id sem pharetra pulvinar. Nunc imperdiet nulla vel malesuada molestie. Aliquam rutrum egestas nibh bibendum tincidunt. Nulla viverra leo quis ultricies porta. Curabitur et semper erat. Suspendisse orci ex, lacinia scelerisque aliquet sit amet, porta at sapien</p>
                        </div>
                      </div>
                    <div class="row">
                        <div class="col-sm-9" style="padding-left:1rem; padding-bottom:10px;">
                            <i class="fas fa-star color-star"></i> 5 &nbsp;&nbsp;&nbsp;
                            <i class="fas fa-play text-primary"></i> 8,365
                        </div>
                        <div class="col-sm-3" style="padding-left:1rem; padding-bottom:10px;">
                            <button style="border-radius:20px; background-color:#27003A; color:#ffff;">Siguiente módulo</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="modalVideo" tabindex="-1" role="dialog" aria-labelledby="modalCreate-2" aria-hidden="true">
                            <div class="modal-dialog" role="document">
                                <div class="modal-content" style="width: 560px;">
                                    <div class="modal-header">
                                        <h5 class="modal-title title" id="title" runat="server">Registro de Pregunta</h5>
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
                        <h2 class="text-primary text-center">Lorem Ipsum</h2>

                        <div class="mt-4">                           
                            
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

                            <button class="btn btn-primary" style="float:right">Enviar</button>

                        </div>
                    </div>
                </div>
            </div>
        </div>

    <script src="https://www.youtube.com/iframe_api"></script>
    <script>
        $("#modalVideo").on('hidden.bs.modal', function () {
            if (done == true) {
                $("#modalCuestionario").modal('show');
                done = false;
            } else {
                pauseVideo();
            }
        });
        $("#modalVideo").on('shown.bs.modal	', function () {
            playVideo();
        });
        var player;
        function onYouTubeIframeAPIReady() {
            player = new YT.Player('player', {
                height: '360',
                width: '560',
                videoId: 'bQL2FsHe7G4',
                playerVars: { 'controls': 0 },
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
                $("#modalVideo").modal('hide')                
                
                
            }

            /*if (event.data == YT.PlayerState.PLAYING && !done) {
                setTimeout(stopVideo, 6000);
                done = true;
            }*/
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
        

    </script>
</asp:Content>
