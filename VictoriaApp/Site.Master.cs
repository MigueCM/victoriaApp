﻿using BLL;
using EL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;

namespace VictoriaApp
{
    public partial class SiteMaster : MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarWebinar();
            }
           
        }

        protected void btnImagen_Click(object sender, EventArgs e)
        {

            if ((txtFile.PostedFile != null) && (txtFile.PostedFile.ContentLength > 0))
            {
                //string fn = System.IO.Path.GetFileName(txtFile.PostedFile.FileName);
                string ext = System.IO.Path.GetExtension(txtFile.PostedFile.FileName);
                string fileImagen = Session["IdPersona"].ToString().Trim() + Session["nombre"].ToString().Trim() + ext;
                string rutaImagen = Server.MapPath("Data\\Avatar") + "\\" + fileImagen;

                if (PersonaBLL.Instancia.ActualizarAvatar(fileImagen, Convert.ToInt32(Session["IdPersona"].ToString())))
                {

                    try
                    {
                        if (File.Exists(rutaImagen))
                            File.Delete(rutaImagen);
                        txtFile.PostedFile.SaveAs(rutaImagen);
                        //Response.Write("The file has been uploaded.");
                        Session["AvatarPersona"] = "Data/Avatar/" + PersonaBLL.Instancia.ObtenerAvatar(Convert.ToInt32(Session["IdPersona"].ToString()));
                        string currentPage = this.Page.Request.AppRelativeCurrentExecutionFilePath;
                        Response.Redirect(currentPage);
                    }
                    catch (Exception ex)
                    {
                        //Response.Write("Error: " + ex.Message);//Note: Exception.Message returns a detailed message that describes the current exception. //For security reasons, we do not recommend that you return Exception.Message to end users in //production environments. It would be better to put a generic error message. 
                    }
                }


            }
            else
            {
                Response.Write("Please select a file to upload.");
            }
        }

        private void CargarWebinar()
        {
            List<Webinar> listaWebinars = WebinarBLL.Instancia.ObtenerWebinar();

            StringBuilder innerHtml = new StringBuilder();

            int i = 1;

            foreach (Webinar item in listaWebinars)
            {

                string imagen = "images/webinar.jpg";
                string current = Server.MapPath(@"~/images/webinars/" + item.Imagen);
                if (File.Exists(current))
                {
                    imagen = "images/webinars/" + item.Imagen;
                }


                if (item.Imagen == null || item.Imagen == "")
                {
                    imagen = "images/webinar.jpg";
                }

                string fila = "<div class=\"card webinar-shadow\">";

                fila += $"<div class=\"card-header\" role=\"tab\" id=\"heading-{i}\">";

                fila += "<h6 class=\"mb-0\">";
                fila += $"<a data-toggle=\"collapse\" href=\"#collapse-{i}\" aria-expanded=\"false\" aria-controls=\"collapse-{i}\" class=\"collapsed\">";
                fila += $"<span class=\"h3 text-primary\">{item.Titulo}</span>";
                fila += $"<span class=\"webinar-autor\">Por {item.Autor}</span>";
                fila += "</a>";
                fila += "</h6>";

                fila += "</div>";

                fila += $"<div id=\"collapse-{i}\" class=\"collapse\" role=\"tabpanel\" aria-labelledby=\"heading-{i}\" data-parent=\"#accordion-4\">";

                fila += "<div class=\"card-body animated fadeIn\">";

                fila += "<div class=\"row\">";

                fila += "<div class=\"col-3\">";
                fila += $"<img src=\"{imagen}\" class=\"mw-100\" alt=\"image\">";
                fila += "</div>";

                fila += "<div class=\"col-9\">";
                fila += $"<p class=\"mb-0 color-white\">{item.Descripcion}</p>";
                fila += "</div>";

                fila += "</div>";

                fila += "</div>";

                fila += "</div>";


                fila += "</div>";

                innerHtml.AppendLine(fila);

                i++;
            }

            Session["webinar"] = HttpUtility.HtmlEncode(innerHtml.ToString());
        }


    }
}