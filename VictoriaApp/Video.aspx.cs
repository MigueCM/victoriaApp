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
            string[] arreglo = respuestas.Split(',');

            List<EL.PreguntaCapacitacion> listaPreguntas = (List<EL.PreguntaCapacitacion>)(HttpContext.Current.Session["lista_preguntas"]??new List<EL.PreguntaCapacitacion>());

            if(arreglo.Length == listaPreguntas.Count)
            {
                int i = 0;
                UsuarioCapacitacion objUsuario = new UsuarioCapacitacion();
                objUsuario.IdUsuario = Convert.ToInt32(HttpContext.Current.Session["idUsuario"] ?? 0);
                objUsuario.IdModuloCapacitacion = Convert.ToInt32(HttpContext.Current.Session["video_idModulo"] ?? 0);
                objUsuario.Calificacion = Convert.ToInt32(calificacion);
                objUsuario.ListaUsuarioPregunta = new List<UsuarioPregunta>();

                foreach (EL.PreguntaCapacitacion item in listaPreguntas)
                {

                    UsuarioPregunta obj = new UsuarioPregunta();
                    obj.IdPreguntaCapacitacion = item.IdPreguntaCapacitacion;
                    obj.Respuesta = arreglo[i];
                    i++;
                    objUsuario.ListaUsuarioPregunta.Add(obj);
                }

                if (UsuarioCapacitacionBLL.Instancia.RegistrarCapacitacion(objUsuario))
                {
                    int porcentaje = UsuarioCapacitacionBLL.Instancia.ObtenerPorcentajeModulos(objUsuario.IdUsuario);

                    HttpContext.Current.Session["prog_value"] = $"width: {porcentaje}%";
                    HttpContext.Current.Session["prog_text"] = $"{porcentaje}% Avance";
                    return true;
                }
                else
                {
                    return false;
                }

                
            }

            return false;
        }

    }
}