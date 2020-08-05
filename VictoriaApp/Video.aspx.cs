using BLL;
using EL;
using System;

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
                    CargarDatos();
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

        }
    }
}