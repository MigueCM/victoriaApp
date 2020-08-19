<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Panel.aspx.cs" Inherits="VictoriaApp.Panel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row" id="div_modulos" runat="server">

        <div class="col-md-4">

            <div class="card card-shadow">
                <img src="images/video.png" class="card-img-top" alt="...">
                <div class="card-body card-body-panel">
                    <h5 class="card-title text-primary card-title-panel">1. Card title that wraps to a new line</h5>
                    <p class="card-text pl-3"> Por <span class="text-primary">Lorem Ipsus</span></p>
                    <p class="card-text pl-3">
                        <i class="fas fa-star color-star"></i> 5 &nbsp;&nbsp;&nbsp;
                        <i class="fas fa-play text-primary"></i> 8,365
                    </p>
                    <div class="text-center">
                        <a href="Video.aspx" class="btn btn-primary">Empezar</a>
                    </div>                             
  
                </div>
                </div>

        </div>

        <div class="col-md-4">

            <div class="card card-shadow">
                <img src="images/video.png" class="card-img-top" alt="...">
                <div class="card-body card-body-panel">
                    <h5 class="card-title text-primary card-title-panel">2. Card title that wraps to a new line</h5>
                    <p class="card-text pl-3"> Por <span class="text-primary">Lorem Ipsus</span></p>
                    <p class="card-text pl-3">
                        <i class="fas fa-star color-star"></i> 5 &nbsp;&nbsp;&nbsp;
                        <i class="fas fa-play text-primary"></i> 8,365
                    </p>
                    <div class="text-center">
                        <a href="Video.aspx" class="btn btn-primary">Empezar</a>
                    </div>
                              
  
                </div>
                </div>

        </div>

        <div class="col-md-4">

            <div class="card card-shadow">
                <img src="images/video.png" class="card-img-top" alt="...">
                <div class="card-body card-body-panel">
                    <h5 class="card-title text-primary card-title-panel">3. Card title that wraps to a new line</h5>
                    <p class="card-text pl-3"> Por <span class="text-primary">Lorem Ipsus</span></p>
                    <p class="card-text pl-3">
                        <i class="fas fa-star color-star"></i> 5 &nbsp;&nbsp;&nbsp;
                        <i class="fas fa-play text-primary"></i> 8,365
                    </p>
                    <div class="text-center">
                        <a href="Video.aspx" class="btn btn-primary">Empezar</a>
                    </div>
                              
  
                </div>
                </div>

        </div>

        <div class="col-md-4">
            <div class="card-bloqueado">
                <div class="image-bloqueado">
                    <img src="images/lock.png" alt="Alternate Text" />
                </div>
                           
                <div class="card card-shadow ">
                <img src="images/video.png" class="card-img-top" alt="...">
                <div class="card-body card-body-panel b-white">
                    <h5 class="card-title text-primary card-title-panel">6. Card title that wraps to a new line</h5>
                    <p class="card-text pl-3"> Por <span class="text-primary">Lorem Ipsus</span></p>
                    <p class="card-text pl-3">
                        <i class="fas fa-star color-star"></i> 5 &nbsp;&nbsp;&nbsp;
                        <i class="fas fa-play text-primary"></i> 8,365
                    </p>
                    <div class="text-center">
                        <a href="javascript: void(0)" class="btn btn-primary btn-cursor-default">Empezar</a>
                    </div>
                              
  
                </div>
                </div>
            </div>
        </div>

        <div class="col-md-4">
            <div class="card-bloqueado">
                <div class="image-bloqueado">
                    <img src="images/lock.png" alt="Alternate Text" />
                </div>
                           
                <div class="card card-shadow ">
                <img src="images/video.png" class="card-img-top" alt="...">
                <div class="card-body card-body-panel b-white">
                    <h5 class="card-title text-primary card-title-panel">6. Card title that wraps to a new line</h5>
                    <p class="card-text pl-3"> Por <span class="text-primary">Lorem Ipsus</span></p>
                    <p class="card-text pl-3">
                        <i class="fas fa-star color-star"></i> 5 &nbsp;&nbsp;&nbsp;
                        <i class="fas fa-play text-primary"></i> 8,365
                    </p>
                    <div class="text-center">
                        <a href="javascript: void(0)" class="btn btn-primary btn-cursor-default">Empezar</a>
                    </div>
                              
  
                </div>
                </div>
            </div>

        </div>

        <div class="col-md-4">

            <div class="card-bloqueado">
                <div class="image-bloqueado">
                    <img src="images/lock.png" alt="Alternate Text" />
                </div>
                           
                <div class="card card-shadow ">
                <img src="images/video.png" class="card-img-top" alt="...">
                <div class="card-body card-body-panel b-white">
                    <h5 class="card-title text-primary card-title-panel">6. Card title that wraps to a new line</h5>
                    <p class="card-text pl-3"> Por <span class="text-primary">Lorem Ipsus</span></p>
                    <p class="card-text pl-3">
                        <i class="fas fa-star color-star"></i> 5 &nbsp;&nbsp;&nbsp;
                        <i class="fas fa-play text-primary"></i> 8,365
                    </p>
                    <div class="text-center">
                        <a href="javascript: void(0)" class="btn btn-primary btn-cursor-default">Empezar</a>
                    </div>
                              
  
                </div>
                </div>
            </div>

        </div>


    </div>

    <script>

        $(function () {
            $('[data-toggle="tooltip"]').tooltip()
        })

        function llamarVideo(codigo) {
            var parametros = "{'codigo': '" + codigo + "'}";

            $.ajax({
                data: parametros,
                url: 'Panel.aspx/ValidarUsuario',
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
    </script>

</asp:Content>
