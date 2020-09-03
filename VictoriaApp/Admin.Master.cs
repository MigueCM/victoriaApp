using BLL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VictoriaApp
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if(Session["IdPerfil"] == null)
                    Response.Redirect("Login.aspx");
                if (Session["IdPerfil"].ToString() == "2")
                    Response.Redirect("Principal.aspx");
                CargarCntNotificaciones();
                CargarNotificaciones();
            }
            
        }

        private void CargarCntNotificaciones()
        {
            int valor = ForoBLL.Instancia.ObtenerCntNotificacionesAdmin();
            StringBuilder innerHtml = new StringBuilder();

            string fila = null;
            if (valor > 0)
            {
                fila = $"<span class=\"count bg-success\">{valor}</span>";
            }

            innerHtml.AppendLine(fila);

            Session["cntNotificaciones"] = HttpUtility.HtmlEncode(innerHtml.ToString());
        }

        private void CargarNotificaciones()
        {
            List<Foro> listaNotificaciones = ForoBLL.Instancia.ObtenerNotificacionesAdmin();
            StringBuilder innerHtml = new StringBuilder();

            foreach (var item in listaNotificaciones)
            {
                string fila = $"<a class=\"dropdown-item preview-item\" id=\"{item.IdForo}\" onclick=\"mylinkfunction()\">";
                fila += $"<div class=\"preview-thumbnail\">";
                fila += $"<div class=\"preview-icon bg-warning\">";
                fila += "<i class=\"mdi mdi-information mx-0\"></i>";
                fila += $"</div>";
                fila += $"</div>";
                fila += $"<div class=\"preview-item-content\">";
                fila += $"<h6 class=\"preview-subject font-weight-normal\">{item.Titulo}</h6>";
                fila += "<p class=\"font-weight-light small-text mb-0\">";
                fila += "Nueva pregunta";
                fila += "</p>";
                fila += "</div>";
                fila += "</a>";

                innerHtml.AppendLine(fila);
            }

            Session["Notificaciones"] = HttpUtility.HtmlEncode(innerHtml.ToString());
        }
    }
}