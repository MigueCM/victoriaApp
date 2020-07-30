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
    public partial class Principal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if( !Page.IsPostBack )
            {
                CargarModulos();
            }
        }


        private void CargarModulos()
        {


            List<ModuloCapacitacion> lista = ModuloCapacitacionBLL.Instancia.ObtenerModulos(Convert.ToInt32( Session["idUsuario"]));

            StringBuilder innerHtml = new StringBuilder();

            int numero = 1;

            foreach (var item in lista)
            {
                string fila = "<tr>";
                fila +=  $"<td class=\"text-white\">{numero++}. {item.Nombre}</td>";

                if(item.FechaActualizacion != null && Convert.ToInt32(item.FechaActualizacion.ToString("yyyy")) >= 2020)
                    fila +=  $"<td class=\"text-white text-center\">{item.FechaActualizacion.ToString("M")} {item.FechaActualizacion.ToString("yyyy")}</td>";
                else
                    fila += "<td class=\"text-white text-center\"></td>";

                if (item.Completado == 1)
                    fila += "<td><button class=\"btn btn-block btn-completado\" onclick=\"showSwal('basic')\">Completado</button></td>";
                else
                    fila += "<td><a class=\"btn btn-block btn-pendiente\" href=\"Panel.aspx\">Pendiente</a></td>";
                fila += "</tr>";

                innerHtml.AppendLine(fila);

            }

            tableModulos.InnerHtml = innerHtml.ToString();


        }
    }
}