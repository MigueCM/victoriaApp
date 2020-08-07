<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="TerminosCondiciones.aspx.cs" Inherits="VictoriaApp.TerminosCondiciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="row">
            <div class="col-12">
                <div class="card">
                    <div class="card-body">
                        <h4 class="card-title">Términos y Condiciones</h4>
                        <hr/>

                        <div class="row">
                            <div class="col-lg-12 col-md-12">
                                
                                <div class="form-group">
                                    <label for="txtTitulo">Título</label>
                                    <div class="input-group border-input">
                                            <div class="input-group-prepend bg-transparent ">
                                            <span class="input-group-text bg-transparent border-right-0 border-color-principal">
                                                <i class="fas fa-align-justify text-primary" aria-hidden="true"></i>
                                            </span>
                                            </div>                  

                                        <input name="txtTitulo" type="text" id="txtTitulo" class="form-control form-control-sm border-color-principal pl-1 txtNombre" placeholder="Título" runat="server"/>
                                    </div>                                     
                                </div>
                                <div class="form-group">
                                    <label for="txtDescripcion">Descripción</label>
                                    <div class="input-group border-input">
                                            <%--<div class="input-group-prepend bg-transparent ">
                                            <span class="input-group-text bg-transparent border-right-0 border-color-principal">
                                                <i class="fas fa-align-justify text-primary" aria-hidden="true"></i>
                                            </span>
                                            </div>  --%>                

                                        <textarea name="txtDescripcion" type="text" id="txtDescripcion" class="form-control form-control-sm border-color-principal pl-1 txtNombre" placeholder="Descripción" runat="server"/>
                                    </div>                                     
                                </div>
                               <div class="alert alert-danger text-center" role="alert" runat="server" visible="false" id="divErrores">
                                  <asp:ListBox ID="lbErrores" runat="server" BackColor="Transparent" Width="100%" Enabled="false" CssClass="border-0 accordion text-danger overflow-hidden" Visible="false"></asp:ListBox>
                              </div>
                                <div class="form-group ">
                                    <asp:Button ID="btnRegistrar" runat="server" Text="Registrar"  class="btn btn-primary"  OnClick="btnRegistrar_Click"/>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                             </div>
                    </div>
                    </div>

            </div>

        </div>
        </form>
</asp:Content>
