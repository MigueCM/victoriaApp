using BLL;
using EL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Services;

namespace VictoriaApp
{
    public partial class Video : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["video_idModulo"] == null)// || Request.UrlReferrer.LocalPath.ToLower() != "/panel.aspx")
                    Response.Redirect("Panel.aspx");
                else
                {
                    CargarDatos();
                }
                    
            }
        }

        private void CargarDatos()
        {
            EL.ModuloCapacitacion objModulo = ModuloCapacitacionBLL.Instancia.ObtenerModulosPorId(Convert.ToInt32(Session["video_idModulo"]));

            if(objModulo != null)
            {
                title_modulo.InnerHtml = objModulo.Nombre;
                autor_modulo.InnerHtml = $"Por {objModulo.Autor}";
                descripcion_modulo.InnerHtml = objModulo.Descripcion;
            }

            List<EL.PreguntaCapacitacion> listaPreguntas = PreguntaCapacitacionBLL.Instancia.ObtenerPreguntas(Convert.ToInt32(Session["video_idModulo"]));
            Session["lista_preguntas"] = listaPreguntas;
            StringBuilder innerHtml = new StringBuilder();
            int cont = 1;
            foreach (EL.PreguntaCapacitacion item in listaPreguntas)
            {
                string fila = "<div class=\"form-group\">";
                fila += $"<label class=\"mb-0\">{cont}. {item.Descripcion}</label>";

                fila += "<div class=\"form-check form-check-primary\">";
                fila += "<label class=\"form-check-label\">";
                fila += $"<input type=\"radio\" class=\"form-check-input\" name=\"rb-{cont}\" value=\"1\">";
                fila += item.Alternativa1;
                fila += "<i class=\"input-helper\"></i></label>";
                fila += "</div>";

                fila += "<div class=\"form-check form-check-primary\">";
                fila += "<label class=\"form-check-label\">";
                fila += $"<input type=\"radio\" class=\"form-check-input\" name=\"rb-{cont}\" value=\"2\">";
                fila += item.Alternativa2;
                fila += "<i class=\"input-helper\"></i></label>";
                fila += "</div>";

                fila += "<div class=\"form-check form-check-primary\">";
                fila += "<label class=\"form-check-label\">";
                fila += $"<input type=\"radio\" class=\"form-check-input\" name=\"rb-{cont}\" value=\"3\">";
                fila += item.Alternativa3;
                fila += "<i class=\"input-helper\"></i></label>";
                fila += "</div>";

                fila += "<div class=\"form-check form-check-primary\">";
                fila += "<label class=\"form-check-label\">";
                fila += $"<input type=\"radio\" class=\"form-check-input\" name=\"rb-{cont}\" value=\"4\">";
                fila += item.Alternativa4;
                fila += "<i class=\"input-helper\"></i></label>";
                fila += "</div>";

                fila += "<div class=\"form-check form-check-primary\">";
                fila += "<label class=\"form-check-label\">";
                fila += $"<input type=\"radio\" class=\"form-check-input\" name=\"rb-{cont}\" value=\"5\">";
                fila += item.Alternativa5;
                fila += "<i class=\"input-helper\"></i></label>";
                fila += "</div>";

                fila += "</div>";

                innerHtml.AppendLine(fila);
                cont++;
            }

            div_cuestionario.InnerHtml = innerHtml.ToString();
            div_cuestionario.Attributes.Add("data-num", listaPreguntas.Count.ToString());
        }
        
        [WebMethod(EnableSession = true)]
        public static bool ValidarData(string respuestas, string calificacion)
        {
            string validar = calificacion;
            string[] arreglo = respuestas.Split(',');

            List<EL.PreguntaCapacitacion> listaPreguntas = (List<EL.PreguntaCapacitacion>)(HttpContext.Current.Session["lista_preguntas"]??new List<EL.PreguntaCapacitacion>());

            if(arreglo.Length == listaPreguntas.Count)
            {
                foreach (EL.PreguntaCapacitacion item in listaPreguntas)
                {
                    
                }
                return true;
            }

            

            return false;
        }

    }
}