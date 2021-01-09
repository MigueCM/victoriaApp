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
                if (Session["IdCarreraSeleccionada"] != null && Session["Genero"] != null)
                {
                    string genero = Session["Genero"].ToString();
                    string image = "";
                    switch (Convert.ToInt32(Session["IdCarreraSeleccionada"].ToString()))
                    {
                        case 1:
                            Session["DesCarrera"] = "ingenieria-minas";
                            image = "ingenieria-minas/fondo-pregunta.png";
                            break;
                        case 2:
                            Session["DesCarrera"] = "ingenieria-aeronautica";
                            image = "ingenieria-aeronautica/fondo-pregunta.jpg";
                            break;
                        case 3:
                            Session["DesCarrera"] = "ingenieria-sistemas";
                            image = "ingenieria-sistemas/fondo-pregunta.png";
                            break;
                        case 4:
                            Session["DesCarrera"] = "arquitectura-datos";
                            image = "arquitectura-datos/fondo-pregunta.png";
                            break;
                        case 5:
                            Session["DesCarrera"] = "biologia-marina";
                            image = "biologia-marina/fondo-pregunta.png";
                            break;
                        case 6:
                            Session["DesCarrera"] = "mecatronica";
                            image = "mecatronica/fondo-pregunta.png";
                            break;
                        case 7:
                            Session["DesCarrera"] = "deportes";
                            image = "deportes/fondo-pregunta.png";
                            break;
                        case 8:
                            Session["DesCarrera"] = "economia";
                            image = "economia/fondo-pregunta.png";
                            break;
                        case 9:
                            Session["DesCarrera"] = "biotecnologia";
                            image = "biotecnologia/fondo-pregunta.png";
                            break;
                        case 10:
                            Session["DesCarrera"] = "fisica";
                            image = "fisica/fondo-pregunta.png";
                            break;
                        default:
                            break;

                            
                    }

                    Session["UrlBackground"] = image;

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