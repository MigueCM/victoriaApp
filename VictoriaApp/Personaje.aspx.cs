using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VictoriaApp
{
    public partial class Personaje : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Hombre_ServerClick(object sender, EventArgs e)
        {
            Session["Genero"] = "HOMBRE";
            Response.Redirect("SeleccionCarrera.aspx");
        }

        protected void Mujer_ServerClick(object sender, EventArgs e)
        {
            Session["Genero"] = "MUJER";
            Response.Redirect("SeleccionCarrera.aspx");
        }
    }
}