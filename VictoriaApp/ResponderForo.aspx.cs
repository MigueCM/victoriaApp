using BLL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VictoriaApp
{
    public partial class ResponderForo : Page
    {
        static int idUsuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                idUsuario = Convert.ToInt32(Session["IdUsuario"].ToString());
                CargarForo();
            }
        }

        private void CargarForo()
        {
            List<EL.Foro> lista = ForoBLL.Instancia.ObtenerComentarios();

            StringBuilder innerHtml = new StringBuilder();

            int numero = 1;

            foreach (var item in lista)
            {
                string fila = "<tr>";
                fila += $"<td>{numero++}</td>";
                fila += $"<td>{item.Nombre + " " + item.Apellidos}</td>";
                fila += $"<td>{item.Titulo}</td>";
                fila += $"<td>{item.Contenido}</td>";
                fila += $"<td>{item.FechaPregunta}</td>";
                //fila += $"<td><button class=\"btn btn-outline-primary mb-1\" onClick=\"cargarData({item.IdModuloCapacitacion});\">Editar</button>";
                if (item.RptCantidad > 0)
                {
                    fila += $"<td><button class=\"btn btn-outline-success mb-1\" onClick=\"redireccionPreguntas({item.IdForo});\">Responder Pregunta</button></td>";
                }
                else
                {
                    fila += $"<td><button class=\"btn btn-outline-danger mb-1\" onClick=\"redireccionPreguntas({item.IdForo});\">Responder Pregunta</button></td>";
                }
                
                //fila += $"<button class=\"btn btn-outline-danger \" onClick=\"eliminar({item.IdModuloCapacitacion});\">Eliminar</button></td>";
                fila += "</tr>";

                innerHtml.AppendLine(fila);

            }
            tbody_modulo.InnerHtml = innerHtml.ToString();
        }

        [WebMethod]
        public static string CargarDataForo(int id)
        {
            EL.Foro objForo = ForoBLL.Instancia.ObtenerComentarioResponder(id);
            return JsonConvert.SerializeObject(new{ objForo });
        }

        protected void btnRespuesta_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Value.Trim());
            string respuesta = txtRespuestaPregunta.Value.Trim();
            if (ForoBLL.Instancia.ActualizarRespuesta(id, idUsuario, respuesta))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "showSwal('auto-close', 'Registro exitoso!', 'Tú respuesta ha sido registrada', 'ResponderForo.aspx', '')", true);
            }
        }

        [WebMethod]
        public static string LeerTodas()
        {
            ForoBLL.Instancia.MarcarLeidosAdmin();
            //Foro foro = new Foro();
            //foro.IdForo = Convert.ToInt32(votar);
            //ForoBLL.Instancia.ActualizarVotado(foro);
            //int newVoto = ForoBLL.Instancia.ObtenerCambioVotado(Convert.ToInt32(votar));
            return JsonConvert.SerializeObject(null);
        }
    }
}