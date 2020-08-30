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
    public partial class Panel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarModulos();
            }
        }

        private void CargarModulos()
        {


            List<EL.ModuloCapacitacion> lista = ModuloCapacitacionBLL.Instancia.ObtenerModulosPorUsuarioPanel(Convert.ToInt32(Session["idUsuario"]));
            int num_modulo = UsuarioCapacitacionBLL.Instancia.ObtenerModuloDesbloqueado(Convert.ToInt32(Session["idUsuario"]));            

            StringBuilder innerHtml = new StringBuilder();

            int numero = 1;

            //List<EL.ModuloCapacitacion> listaAux = lista.FindAll(item => item.Completado == 1 || num_modulo == item.Nro);
            //bool mostrar = true;
            bool liberado = true;
            foreach (var item in lista)
            {

                int num_visualizacion = UsuarioCapacitacionBLL.Instancia.ObtenerVisualizacion(item.IdModuloCapacitacion);

                string fila = "<div class=\"col-md-4\">";

                string color = "";
                //if (!(item.Completado == 1 || (num_modulo <= item.Nro)) && !(listaAux.Count == 0 && mostrar))
                if (!(item.Completado == 1) && !liberado)
                {
                    color = "b-white";

                    fila += "<div class=\"card-bloqueado\">";
                    fila += "<div class=\"image-bloqueado\">";
                    fila += "<img src=\"images/lock.png\" alt=\"Alternate Text\" />";
                    fila += "</div>";
                }

               /* string imagen = "images/video.png";

                string current = Server.MapPath(@"~/Data/" + item.Imagen);
                if (File.Exists(current))
                {
                    imagen = "Data/" + item.Imagen;
                }

                if (item.Imagen == "")
                {
                    imagen = "images/video.png";
                }*/

                fila += "<div class=\"card card-shadow\">";

                string imagen = "https://img.youtube.com/vi/" + Globales.ObtenerIdVideo(item.Enlace) + "/mq1.jpg";
                
                fila += $"<img src=\"{imagen}\" class=\"card-img-top\" alt=\"Imagen de {item.Nombre}\">";



                fila += $"<div class=\"card-body card-body-panel {color} \">";
                fila += $"<h5 class=\"card-title text-primary card-title-panel\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"{item.Nombre}\">{numero++}. {item.Nombre}</h5>";
                //fila += $"<p class=\"card-text pl-3\"> Por<span class=\"text-primary\"> {item.Autor}</span></p>";
                fila += "<p class=\"card-text pl-3\">";
                fila += $"<i class=\"fas fa-star color-star\"></i> {item.Calificacion} &nbsp;&nbsp;&nbsp;";
                fila += $"<i class=\"fas fa-play text-primary\"></i> {num_visualizacion}";
                fila += "</p>";
                fila += "<div class=\"text-center\">";
                if (!(item.Completado == 1 ) && !liberado)
                {
                    
                    fila += "<a href=\"javascript: void(0)\" class=\"btn btn-primary btn-cursor-default\">Empezar</a>";
                }
                else
                {
                    
                    fila += $"<a href=\"javascript: void(0)\" class=\"btn btn-primary cursor-pointer\" onClick=\"llamarVideo({item.IdModuloCapacitacion})\">Empezar</a>";
                }

                fila += "</div>";
                fila += "</div>";
                fila += "</div>";
                fila += "</div>";
                if (!(item.Completado == 1 ) && !liberado)
                {
                    fila += "</div>";
                }
                //else
                //{
                //    mostrar = false;
                //}

                if(num_modulo <= item.IdModuloCapacitacion)
                {
                    liberado = false;
                }

                innerHtml.AppendLine(fila);

            }

            div_modulos.InnerHtml = innerHtml.ToString();


        }
    
        [WebMethod(EnableSession = true)]
        public static bool ValidarUsuario(int codigo)
        {

            HttpContext.Current.Session["video_idModulo"] = codigo;

            return true;
        }


    }
}