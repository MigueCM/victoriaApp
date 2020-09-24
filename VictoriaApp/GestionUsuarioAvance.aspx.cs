using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using EL;


namespace VictoriaApp
{
    public partial class GestionUsuarioAvance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargasUsuarios();
                CargasUsuarios2();
            }
        }

        private void CargasUsuarios()
        {

            List<Usuario> lista = UsuarioBLL.Instancia.ObtenerUsuarioAvance();

            StringBuilder innerHtml = new StringBuilder();

            int i = 1;
            foreach (var item in lista)
            {
                int porcentaje = UsuarioCapacitacionBLL.Instancia.ObtenerPorcentajeModulos(item.IdUsuario);
                string fila = "<tr>";
                fila += $"<td>{i++}</td>";
                fila += $"<td>{item.Persona.Nombre} {item.Persona.Apellidos}</td>";
                //fila += $"<td>{item.Perfil.Nombre}</td>";
                fila += $"<td>{item.FechaRegistro}</td>";
                fila += $"<td>";
                fila += $"<div class=\"progress progress-xl mt-2 \" style='height:23px;'>";
                fila += $"<div class=\"progress-bar bg-primary\" role=\"progressbar\" style=\"width:{porcentaje}%\" aria-valuenow=\"50\" aria-valuemin=\"0\" aria-valuemax=\"100\">";
                fila += $"<span class=\"text-progressbar2\">{porcentaje}%</span>";
                fila += $"</div>";
                fila += $"</div>";
                fila += $"</td>";
                fila += $"<td>{item.FechaSesion}</td>";
                fila += "</tr>";

                innerHtml.AppendLine(fila);

            }

            tbody_modulo.InnerHtml = innerHtml.ToString();


        }


        private void CargasUsuarios2()
        {

            List<UsuarioCapacitacion> lista = UsuarioBLL.Instancia.ObtenerUsuarioYModulo();

            StringBuilder innerHtml = new StringBuilder();

            int i = 1;
            foreach (var item in lista)
            {
                string fila = "<tr>";
                fila += $"<td>{i++}</td>";
                fila += $"<td>{item.Nombre}</td>";
                fila += $"<td>{item.ModuloCapacitacion.Nombre}</td>";
                fila += $"<td>{item.Nota}</td>";
                fila += $"<td>{item.Calificacion}</td>";
                fila += "</tr>";

                innerHtml.AppendLine(fila);

            }

            tbody2.InnerHtml = innerHtml.ToString();


        }

    }
}