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
    public partial class DescripcionCarreras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["IdCarreraSeleccionada"] != null)
                {
                    switch (Convert.ToInt32(Session["IdCarreraSeleccionada"].ToString()))
                    {
                        case 1:
                            carreraTitulo.InnerText = "Carrera 1";
                            break;
                        case 2:
                            carreraTitulo.InnerText = "Carrera 2";
                            break;
                        case 3:
                            carreraTitulo.InnerText = "Carrera 3";
                            break;
                        case 4:
                            carreraTitulo.InnerText = "Carrera 4";
                            break;
                        case 5:
                            carreraTitulo.InnerText = "Carrera 5";
                            break;
                        default:
                            break;
                    }
                    Cargardescripcion();
                }
            }
        }

        private void Cargardescripcion()
        {
            StringBuilder innerHtml = new StringBuilder();
            for (int i = 1; i <= 3; i++)
            {
                string fila = "<div class=\"card\">";

                fila += $"<div class=\"card-header\" role=\"tab\" id=\"heading-{i}\">";
                fila += "<h6 class=\"mb-0\">";
                fila += $"<a data-toggle=\"collapse\" href=\"#collapse-{i}\" aria-expanded=\"true\" aria-controls=\"collapse-{i}\"> How can I pay for an order I placed?</a>";
                fila += "   </h6>";
                fila += " </div>";
                fila += $"<div id =\"collapse-{i}\" class=\"collapse\" role=\"tabpanel\" aria-labelledby=\"heading-{i}\" data-parent=\"#accordion-4\" >";
                fila += "   <div class=\"card-body\">";
                fila += "  <div class=\"row\">";
                fila += " <div class=\"col-9\">";
                              fila += "  <p class=\"mb -0 text-white\">You can pay for the product you have purchased using credit cards, debit cards, or via online banking. We also on-delivery services.</p>";
                fila += "</div>";
                fila += "  </div>";
                fila += "    </div>";
                fila += "   </div>";
                fila += "    </div>";
                innerHtml.AppendLine(fila);
            }
               
               

            Session["ACarreras"] = HttpUtility.HtmlEncode(innerHtml.ToString());
        }
    }
}