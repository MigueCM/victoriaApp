<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Video.aspx.cs" Inherits="VictoriaApp.Video" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row"> 
        <div class="col-md-12 ">
            <div class="card">
                <div class="card-body" id="cardVideo">
                    
                        <img src="images/video.png" style="width:100%" />
                      
                      <div class="row">
                        <div class="col-sm-12">
                            <h1 style="padding-top:10px; padding-left:10px; color:#561179">1. Lorem Ipsum is simply dummy text of the</h1>
                            <h2 style="padding-top:10px; padding-left:10px;">Por Lorem Ipsum</h2>
                            <p style="padding-top:10px; padding-left:10px; padding-right:10px; font-size:15px; color:#AFAFAF; text-align:justify">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus vitae felis justo. In suscipit purus id sem pharetra pulvinar. Nunc imperdiet nulla vel malesuada molestie. Aliquam rutrum egestas nibh bibendum tincidunt. Nulla viverra leo quis ultricies porta. Curabitur et semper erat. Suspendisse orci ex, lacinia scelerisque aliquet sit amet, porta at sapien</p>
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
</asp:Content>
