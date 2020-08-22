using BLL;
using EL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
                    ObtenerCalificacion();
                }
                    
            }
        }


        private void ObtenerCalificacion()
        {
            int calificacion = UsuarioCapacitacionBLL.Instancia.ObtenerCalificacion(Convert.ToInt32(Session["video_idModulo"]));
            int num_visualizacion = UsuarioCapacitacionBLL.Instancia.ObtenerVisualizacion(Convert.ToInt32(Session["video_idModulo"]));

            StringBuilder innerHtml = new StringBuilder();
            string fila = $"<i class=\"fas fa-star color-star\"></i>{calificacion} &nbsp;&nbsp;&nbsp;";
            fila += $"<i class=\"fas fa-play text-primary\"></i> {num_visualizacion}";

            innerHtml.AppendLine(fila);

            div_calificacion.InnerHtml = innerHtml.ToString();

        }

        private void CargarDatos()
        {
            EL.ModuloCapacitacion objModulo = ModuloCapacitacionBLL.Instancia.ObtenerModulosPorId(Convert.ToInt32(Session["video_idModulo"]));

            num_intentos.Value = "0";//UsuarioCapacitacionBLL.Instancia.ObtenerIntento(Convert.ToInt32(Session["video_idModulo"]), Convert.ToInt32(Session["idUsuario"])).ToString();
            estado_aprobado.Value = UsuarioCapacitacionBLL.Instancia.ObtenerEstadoModulo(Convert.ToInt32(Session["video_idModulo"]), Convert.ToInt32(Session["idUsuario"])).ToString();
            Session["video"] = "";

            if(objModulo != null)
            {
                title_modulo.InnerHtml = objModulo.Nombre;

                descripcion_modulo.InnerHtml = objModulo.Descripcion;               

                Session["video"] = Globales.ObtenerIdVideo(objModulo.Enlace);

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
        public static string ValidarData(string respuestas, string calificacion)
        {
            //int num_intentos = UsuarioCapacitacionBLL.Instancia.ObtenerIntento(Convert.ToInt32(HttpContext.Current.Session["video_idModulo"]), Convert.ToInt32(HttpContext.Current.Session["idUsuario"]));

            //if(num_intentos > 2)
            //{
            //    return false;
            //}


            string[] arreglo = respuestas.Split(',');
            bool aprobado = true;
            int respuestas_correctas = 0;
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
                    
                    objUsuario.ListaUsuarioPregunta.Add(obj);

                    if(item.Respuesta != arreglo[i])
                    {
                        aprobado = false;
                    }
                    else
                    {
                        respuestas_correctas += 1;
                    }
                    i++;
                }

                objUsuario.Aprobado = aprobado?1:0;
                objUsuario.Nota = (int)(((Double)respuestas_correctas / listaPreguntas.Count) * 20);

                if (UsuarioCapacitacionBLL.Instancia.RegistrarCapacitacion(objUsuario))
                {
                    int porcentaje = UsuarioCapacitacionBLL.Instancia.ObtenerPorcentajeModulos(objUsuario.IdUsuario);

                    HttpContext.Current.Session["prog_value"] = $"width: {porcentaje}%";
                    HttpContext.Current.Session["prog_text"] = $"{porcentaje}% Avance";
                    return JsonConvert.SerializeObject(
                    new
                    {
                        aprobado,
                        guardar = true
                    }
                    );
                }
                else
                {
                    return JsonConvert.SerializeObject(
                    new
                    {
                        aprobado,
                        guardar = false
                    }
                    );
                }

                
            }

            return JsonConvert.SerializeObject(
                new
                {
                    aprobado,
                    guardar = false
                }
                );
        }

        [WebMethod(EnableSession = true)]
        public static bool ValidarSiguienteModulo()
        {

            List<EL.ModuloCapacitacion> lista = ModuloCapacitacionBLL.Instancia.ObtenerModulosCalificacionPorUsuario(Convert.ToInt32(HttpContext.Current.Session["idUsuario"]));
            int primerModuloDesbloqueado = lista.FindAll(item => item.Completado == 0 || item.Aprobado == 0).First().IdModuloCapacitacion;
            int siguienteModulo = lista.Find(item => item.IdModuloCapacitacion > Convert.ToInt32(HttpContext.Current.Session["video_idModulo"])).IdModuloCapacitacion;

            if(primerModuloDesbloqueado < siguienteModulo)
            {
                return false;
            }
            else
            {
                HttpContext.Current.Session["video_idModulo"] = siguienteModulo;
                return true;
            }


            
        }

    }
}