using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VictoriaApp
{
    public partial class SeleccionCarrera : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.Request.Params["__EVENTTARGET"] == "miPostBack")
            {
                CarreraSeleccionada(Page.Request.Params["__EVENTARGUMENT"].ToString());
            }
        }

        private void CarreraSeleccionada(string parametros)
        {
            Session["IdCarreraSeleccionada"] = parametros;
            Response.Redirect("DescripcionCarreras.aspx");
        }
    }
}