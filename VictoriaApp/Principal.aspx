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
                          <th class="text-white"><h4>Modulo</h4></th>
                          <th class="text-white"><h4>Fecha</h4></th>
                          <th class="text-white"><h4>Estado</h4></th>
                        </tr>
                      </thead>
                      <tbody>
                        <tr>
                          <td>Jacob</td>
                          <td>12 May 2017</td>
                          <td><label class="badge badge-danger">Pending</label></td>
                        </tr>
                        <tr>
                          <td>Messsy</td>
                          <td>15 May 2017</td>
                          <td><label class="badge badge-warning">In progress</label></td>
                        </tr>
                        <tr>
                          <td>John</td>
                          <td>14 May 2017</td>
                          <td><label class="badge badge-info">Fixed</label></td>
                        </tr>
                        <tr>
                          <td>Peter</td>
                          <td>16 May 2017</td>
                          <td><label class="badge badge-success">Completed</label></td>
                        </tr>
                        <tr>
                          <td>Dave</td>
                          <td>20 May 2017</td>
                          <td><label class="badge badge-warning">In progress</label></td>
                        </tr>
                      </tbody>
                    </table>
                  </div>
                </div>
            </div>
          </div>
</asp:Content>
