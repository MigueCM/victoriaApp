using BLL;
using EL;
using System;
using System.Collections.Generic;
using System.Text;
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


            List<EL.ModuloCapacitacion> lista = ModuloCapacitacionBLL.Instancia.ObtenerModulosPorUsuario(Convert.ToInt32(Session["idUsuario"]));
            int num_modulo = UsuarioCapacitacionBLL.Instancia.ObtenerModuloDesbloqueado(Convert.ToInt32(Session["idUsuario"]));

            StringBuilder innerHtml = new StringBuilder();

            int numero = 1;

            foreach (var item in lista)
            {
                string fila = "<div class=\"col-md-4\">";

                string color = "";
                if (!(item.Completado == 1 || num_modulo == item.Nro))
                {
                    color = "b-white";

                    fila += "<div class=\"card-bloqueado\">";
                    fila += "<div class=\"image-bloqueado\">";
                    fila += "<img src=\"images/lock.png\" alt=\"Alternate Text\" />";
                    fila += "</div>";
                }

                string imagen = "Data/"+item.Imagen;

                if(item.Imagen == "")
                {
                    imagen = "images/video.png";
                }

                fila += "<div class=\"card card-shadow\">";
                fila += $"<img src=\"{imagen}\" class=\"card-img-top\" alt=\"Imagen de {item.Nombre}\">";
                fila += $"<div class=\"card-body card-body-panel {color} \">";
                fila += $"<h5 class=\"card-title text-primary card-title-panel\">{numero++}. {item.Nombre}</h5>";
                fila += $"<p class=\"card-text pl-3\"> Por<span class=\"text-primary\"> {item.Autor}</span></p>";
                fila += "<p class=\"card-text pl-3\">";
                fila += "<i class=\"fas fa-star color-star\"></i> 5 &nbsp;&nbsp;&nbsp;";
                fila += "<i class=\"fas fa-play text-primary\"></i> 8,365";
                fila += "</p>";
                fila += "<div class=\"text-center\">";
                if (!(item.Completado == 1 || num_modulo == item.Nro))
                {
                    fila += "<a href=\"javascript: void(0)\" class=\"btn btn-primary btn-cursor-default\">Empezar</a>";
                }
                else
                {
                    fila += "<a href=\"Video.aspx\" class=\"btn btn-primary\">Empezar</a>";
                }

                fila += "</div>";
                fila += "</div>";
                fila += "</div>";
                fila += "</div>";
                if (!(item.Completado == 1 || num_modulo == item.Nro))
                {
                    fila += "</div>";
                }

                innerHtml.AppendLine(fila);

            }

            div_modulos.InnerHtml = innerHtml.ToString();


        }
    }
}