using BLL;
using EL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace VictoriaApp
{
    public partial class Principal : System.Web.UI.Page
    {
        static int idPersona;
        static int idUsuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarModulos();
                idPersona = Convert.ToInt32(Session["IdPersona"].ToString());
                idUsuario = Convert.ToInt32(Session["idUsuario"]);
            }
            CargarComentarios();
        }

        private void CargarComentarios()
        {
            List<Foro> foros = new List<Foro>();
            foros = ForoBLL.Instancia.ObtenerComentarios();
            StringBuilder innerHtml = new StringBuilder();
            if (foros.Count > 0)
            {
                foreach (var item in foros)
                {
                    string imagen = item.Avatar;
                    string current = Server.MapPath(@"~/Data/Avatar/" + item.Avatar);
                    if (File.Exists(current))
                    {
                        imagen = "Data/Avatar/" + item.Avatar;
                    }

                    if (item.Avatar == null || item.Avatar == "")
                    {
                        imagen = "Data/Avatar/noImage.png";
                    }
                    TimeSpan time = DateTime.Now- item.FechaPregunta;
                    string fila = "<div class=\"d-flex align-items-start profile-feed-item\">";
                    fila += $"<img src=\"{imagen}\" alt=\"profile\" class=\"img-sm rounded-circle\"/>";
                    fila += $"<div class=\"ml-4\">";
                    fila += $"<h6>";
                    fila += item.Titulo;
                    if(time.Days > 0)
                        fila += $"<small class=\"ml-4 text-muted\"><i class=\"mdi mdi-clock mr-1\"></i>{String.Format("{0} días, {1} horas", time.Days, time.Hours)}</small>";
                    else
                        fila += $"<small class=\"ml-4 text-muted\"><i class=\"mdi mdi-clock mr-1\"></i>{String.Format("{0} horas", time.Hours)}</small>";
                    fila += $"</h6>";
                    fila += $"<p>";
                    fila += item.Contenido;
                    fila += $"</p>";
                    fila += $"<p class=\"/*small*/ text-muted mt-2 mb-0\">";
                    fila += $"<span>";
                    fila += $"<i class=\"mdi mdi-star mr-1\" id=\"{item.IdForo}\" onclick=\"Votar()\"></i>{item.Votado}";
                    fila += $"</span>";
                    fila += $"<span class=\"ml-2\">";
                    fila += $"<i class=\"mdi mdi-comment mr-1\"></i>{item.RptCantidad}";
                    fila += $"</span>";
                    fila += $"</p>";
                    fila += $"</div>";
                    fila += $"</div>";
                    Foro foroRespuesta = new Foro();
                    foroRespuesta = ForoBLL.Instancia.ObtenerRespuesta(item.IdForo);
                    if (foroRespuesta != null)
                    {
                        string imagenRpt = foroRespuesta.Avatar;
                        string currentRpt = Server.MapPath(@"~/Data/Avatar/" + foroRespuesta.Avatar);
                        if (File.Exists(currentRpt))
                        {
                            imagenRpt = "Data/Avatar/" + foroRespuesta.Avatar;
                        }

                        if (foroRespuesta.Avatar == null || foroRespuesta.Avatar == "")
                        {
                            imagenRpt = "Data/Avatar/noImage.png";
                        }
                        TimeSpan timeRpt = DateTime.Now - foroRespuesta.FechaRespuesta;
                        fila += "<div class=\"d-flex align-items-start profile-feed-item\">";
                        fila += "<div class=\"row offset-1\">";
                        fila += $"<img src=\"{imagenRpt}\" alt=\"profile\" class=\"img-sm rounded-circle\"/>";
                        fila += $"<div class=\"ml-4\">";
                        fila += $"<h6>";
                        fila += "RESPUESTA A: "+ " " + foroRespuesta.Titulo;
                        if (timeRpt.Days > 0)
                            fila += $"<small class=\"ml-4 text-muted\"><i class=\"mdi mdi-clock mr-1\"></i>{String.Format("{0} días, {1} horas", timeRpt.Days, timeRpt.Hours)}</small>";
                        else
                            fila += $"<small class=\"ml-4 text-muted\"><i class=\"mdi mdi-clock mr-1\"></i>{String.Format("{0} horas", timeRpt.Hours)}</small>";
                        fila += $"</h6>";
                        fila += $"<p>";
                        fila += foroRespuesta.Respuesta;
                        fila += $"</p>";
                        //fila += $"<p class=\"/*small*/ text-muted mt-2 mb-0\">";
                        //fila += $"<span>";
                        //fila += $"<i class=\"mdi mdi-star mr-1\" id=\"{item.IdForo}\" onclick=\"Votar()\"></i>{item.Votado}";
                        //fila += $"</span>";
                        //fila += $"<span class=\"ml-2\">";
                        //fila += $"<i class=\"mdi mdi-comment mr-1\"></i>{item.RptCantidad}";
                        //fila += $"</span>";
                        //fila += $"</p>";
                        fila += $"</div>";
                        fila += $"</div>";
                        fila += $"</div>";
                    }
                    innerHtml.AppendLine(fila);
                }

                Session["Comentarios"] = HttpUtility.HtmlEncode(innerHtml.ToString());
            }
            else
            {

            }
        }

        [WebMethod]
        public static string Votar(string votar)
        {
            Foro foro = new Foro();
            foro.IdForo = Convert.ToInt32(votar);
            ForoBLL.Instancia.ActualizarVotado(foro);
            int newVoto = ForoBLL.Instancia.ObtenerCambioVotado(Convert.ToInt32(votar));
            return JsonConvert.SerializeObject(null);
        }

        [WebMethod]       
        public static List<EL.ModuloCapacitacion> getModules()
        {
            List<EL.ModuloCapacitacion> modulosLista = new List<EL.ModuloCapacitacion>();
            modulosLista = ModuloCapacitacionBLL.Instancia.ObtenerModulos(idUsuario);
            return modulosLista;
        }

        [WebMethod]
        public static string EnviarDatos(string titulo, string contenido, string idModulo)
        {
            string codAlerta, cabecera, body, url, id;
            Foro foro = new Foro();
            foro.IdUsuario = idUsuario;
            foro.Titulo = titulo;
            foro.Contenido = contenido;
            foro.IdModulo = Convert.ToInt32(idModulo);
            if(ForoBLL.Instancia.RegistrarPregunta(foro))
            {
                codAlerta = "success-message";
                cabecera = "Registro Exitoso";
                body = "Pregunta registrada correctamente";
                url = "Principal.aspx";
                id = "0";
                return JsonConvert.SerializeObject(new { codAlerta, cabecera, body, url, id});
            }
            else
            {
                codAlerta = "danger-error";
                cabecera = "Error";
                body = "Error al registrar su pregunta intentelo más tarde";
                url = "Principal.aspx";
                id = "0";
                return JsonConvert.SerializeObject(new { codAlerta, cabecera, body, url, id });
            }
                
        }

        private void CargarModulos()
        {

            List<EL.ModuloCapacitacion> lista = ModuloCapacitacionBLL.Instancia.ObtenerModulosPorUsuario(Convert.ToInt32(Session["idUsuario"]));
            int num_modulo = UsuarioCapacitacionBLL.Instancia.ObtenerModuloDesbloqueado(Convert.ToInt32(Session["idUsuario"]));
            StringBuilder innerHtml = new StringBuilder();

            int numero = 1;
            bool liberado = true;
            foreach (var item in lista)
            {
                string fila = "<tr>";
                fila += $"<td class=\"text-white\">{numero++}. {item.Nombre}</td>";

                if (item.FechaActualizacion != null && Convert.ToInt32(item.FechaActualizacion.ToString("yyyy")) >= 2020)
                    fila += $"<td class=\"text-white text-center\">{item.FechaActualizacion.ToString("M")} {item.FechaActualizacion.ToString("yyyy")}</td>";
                else
                    fila += "<td class=\"text-white text-center\"></td>";

                if (item.Completado == 1)
                {
                    //fila += "<td><button class=\"btn btn-block btn-completado\" onclick=\"showSwal('basic')\">Completado</button></td>";
                    fila += $"<td><a class=\"btn btn-success text-center align-items-center text-white cursor-pointer\" style=\"width:100%;\" onclick=\"verVideo('{item.IdModuloCapacitacion}')\">Completado</a></td>";
                }else if (liberado)
                {
                    fila += $"<td><a class=\"btn btn-danger text-center align-items-center text-white cursor-pointer\" style=\"width:100%;\" onclick=\"verVideo('{item.IdModuloCapacitacion}')\">Pendiente</a></td>";
                }
                else
                {
                    //fila += "<td><a class=\"btn btn-block btn-pendiente\" href=\"Panel.aspx\">Pendiente</a></td>";
                    fila += "<td><a class=\"btn btn-danger text-center align-items-center text-white cursor-pointer\" style=\"width:100%;\" onclick=\"showSwal('basic')\">Pendiente</a></td>";
                }                    
                fila += "</tr>";

                if (num_modulo <= item.Nro)
                {
                    liberado = false;
                }

                innerHtml.AppendLine(fila);

            }

            tableModulos.InnerHtml = innerHtml.ToString();


        }

        [WebMethod(EnableSession = true)]
        public static bool ValidarUsuario(int codigo)
        {

            HttpContext.Current.Session["video_idModulo"] = codigo;

            return true;
        }

    }
}