<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="VictoriaApp.Principal" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="welcome-message">
            <div id="divvoluntario" runat="server" visible="true">
                <div class="row">
                    
                    <div class="table-responsive">
                    <table class="table">
                      <thead>
                        <tr>
                          <th class="text-white text-center"><h4>Modulo</h4></th>
                          <th class="text-white text-center"><h4>Fecha</h4></th>
                          <th class="text-white text-center"><h4>Estado</h4></th>
                        </tr>
                      </thead>
                      <tbody id="tableModulos" runat="server">
                        <tr>
                          <td class="text-white">1. Lorem Ipsum is simply dummy text of the</td>
                          <td class="text-white text-center">09 de Julio 2020</td>
                          <td><button class="btn btn-block btn-completado" onclick="showSwal('basic')">Completado</button></td>
                        </tr>
                        <tr>
                          <td class="text-white">2. Lorem Ipsum is simply dummy text of the</td>
                          <td class="text-white text-center"></td>
                          <td><a class="btn btn-block btn-pendiente" href="Panel.aspx">Pendiente</a></td>
                        </tr>
                        <tr>
                          <td class="text-white">3. Lorem Ipsum is simply dummy text of the</td>
                          <td class="text-white text-center"></td>
                          <td><a class="btn btn-block btn-pendiente" href="Panel.aspx">Pendiente</a></td>
                        </tr>
                        <tr>
                          <td class="text-white">4. Lorem Ipsum is simply dummy text of the</td>
                          <td class="text-white text-center"></td>
                          <td><a class="btn btn-block btn-pendiente" href="Panel.aspx">Pendiente</a></td>
                        </tr>
                        <tr>
                          <td class="text-white">5. Lorem Ipsum is simply dummy text of the</td>
                          <td class="text-white text-center"></td>
                          <td><a class="btn btn-block btn-pendiente" href="Panel.aspx">Pendiente</a></td>
                        </tr>
                      </tbody>
                    </table>
                  </div>
                </div>
            </div>
          </div>

    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha256-4+XzXVhsDmqanXGHaHvgh1gMQKX40OUvDEBTu8JcmNs=" crossorigin="anonymous"></script>
    <script src="vendors/jquery.avgrund/jquery.avgrund.min.js"></script>
    <script src="Scripts/sweetalert.min.js"></script>
    <script src="Scripts/alerts.js"></script>
    <script src="Scripts/avgrund.js"></script>
</asp:Content>
