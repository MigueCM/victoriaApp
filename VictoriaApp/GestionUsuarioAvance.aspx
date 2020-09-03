<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="GestionUsuarioAvance.aspx.cs" Inherits="VictoriaApp.GestionUsuarioAvance" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-12">
            <div class="card">
                <div class="card-body">
                    <h4 class="card-title">Usuario</h4>
                    <hr/>

                    <div class="row">
                        <div class="col-lg-12 col-md-12">
                            <div class="form-group ">
                            
                                <%--<button id="btnNuevo" type="button" class="btn btn-primary" data-toggle="modal" data-target="#modalCreate" OnClick="limpiar()">
                                    Registrar Usuario
                                </button>--%>

                                   
                                
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-lg-12 col-md-12">
                            <div class="table-responsive">
                                <table id="tabla-modulos" class="table">
                                    <thead>
                                    <tr>
                                        <th>#</th>
                                        <th class="search">Nombre</th>
                                        <th class="search">Documento</th>
                                        <th class="search">Módulos</th>
                                        <%--<th>Opciones</th>--%>
                                    </tr>
                                    </thead>
                                    <tbody runat="server" id="tbody_modulo">
                                    <%--    <tr>
                                            <td>1</td>
                                            <td></td>
                                            <td>
                                            </td>
                                        </tr>--%>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>


            </div>

        </div>
    </div>
    
    <!-- plugin js for this page -->
<%--    <script src="http://www.urbanui.com/wagondash/template/vendors/datatables.net/jquery.dataTables.js"></script>
    <script src="http://www.urbanui.com/wagondash/template/vendors/datatables.net-bs4/dataTables.bootstrap4.js"></script>--%>

    <script src="vendors/datatables.net/jquery.dataTables.js"></script>
    <script src="vendors/datatables.net-bs4/dataTables.bootstrap4.js"></script>
    <script src="Scripts/js/datatable.js"></script>
    <script>


    </script>
</asp:Content>
