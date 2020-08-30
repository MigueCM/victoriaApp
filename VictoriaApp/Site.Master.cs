using BLL;
using EL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;

namespace VictoriaApp
{
    public partial class SiteMaster : MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
<<<<<<< HEAD
                if (Session["IdPersona"] == null || Session["idUsuario"] == null)
                    Response.Redirect("Login.aspx");
=======
>>>>>>> 9b13467ad0ed3fc4e33d50df387def2c285272f1
                CargarWebinar(); 
                CargarCntNotificaciones();
                CargarNotificaciones();
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

                

                fila += "<div class=\"col-12\">";
                fila += $"<p class=\"mb-0 color-white text-justify\">{item.Descripcion}</p>";
                fila += "</div>";

                fila += "<div class=\"col-12 text-center\">";
                fila += $"<img src=\"{imagen}\" class=\"mw-100 mt-3 max-height\" alt=\"image\">";
                fila += "</div>";

                fila += $"<div class=\"col-12 text-center mt-4 webinar-guardar\" data-id='{item.IdWebinar}'>";

                if(WebinarNotificacionBLL.Instancia.ObtenerNotificacion(item.IdWebinar , Convert.ToInt32(Session["IdUsuario"])) == 0)
                {
                    fila += $"<button type='button' class='btn btn-success ' onclick=\"AgendarWebinar({item.IdWebinar},'{item.FechaWebinar}','{item.HoraWebinar.Trim()}')\">Agendar</button>";
                }
                else
                {
                    fila += $"<a class=\"btn btn-success text-center align-items-center text-white cursor-pointer\" href='javascript:void(0);'>Agendado</a>";
                }

                
                
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


        private void CargarCntNotificaciones()
        {
            int valor = ForoBLL.Instancia.ObtenerCntNotificaciones(Convert.ToInt32(Session["IdUsuario"].ToString()));
            StringBuilder innerHtml = new StringBuilder();

            string fila = null;
            if (valor>0)
            {
                fila = $"<span class=\"count bg-success\">{valor}</span>";
            }
            
                innerHtml.AppendLine(fila);

            Session["cntNotificaciones"] = HttpUtility.HtmlEncode(innerHtml.ToString());
        }

        private void CargarNotificaciones()
        {
            List<Foro> listaNotificaciones = ForoBLL.Instancia.ObtenerNotificaciones(Convert.ToInt32(Session["IdUsuario"].ToString()));
            StringBuilder innerHtml = new StringBuilder();

            foreach (var item in listaNotificaciones)
            {
                string fila =  $"<a class=\"dropdown-item preview-item\" id=\"{item.IdForo}\" onclick=\"mylinkfunction({item.IdForo})\">";
                fila += $"<div class=\"preview-thumbnail\">";
                fila += $"<div class=\"preview-icon bg-warning\">";
                fila += "<i class=\"mdi mdi-information mx-0\"></i>";
                fila += $"</div>";
                fila += $"</div>";
                fila += $"<div class=\"preview-item-content\">";
                fila += $"<h6 class=\"preview-subject font-weight-normal\">{item.Titulo}</h6>";
                fila += "<p class=\"font-weight-light small-text mb-0\">";
                fila += "Tú pregunta ha sido respondida";
                fila += "</p>";
                fila += "</div>";
                fila += "</a>";

                innerHtml.AppendLine(fila);
            }

            Session["Notificaciones"] = HttpUtility.HtmlEncode(innerHtml.ToString());
        }
    }
}