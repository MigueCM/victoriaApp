using BLL;
using EL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VictoriaApp
{
    public partial class GestionUsuarioAprobados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargasUsuarios();
            }
        }

        private void CargasUsuarios()
        {

            List<UsuarioCapacitacion> lista = UsuarioCapacitacionBLL.Instancia.ObtenerUsuariosCapacitados();

            StringBuilder innerHtml = new StringBuilder();

            int i = 1;
            foreach (var item in lista)
            {
                string fila = "<tr>";
                fila += $"<td>{i++}</td>";
                fila += $"<td>{item.Nombre}</td>";
                //fila += $"<td>{item.Perfil.Nombre}</td>";
                fila += $"<td>{item.User}</td>";
                fila += $"<td>{item.FechaRegistro.ToString("dd'/'MM'/'yyyy")}</td>";
                //fila += $"<td><button class=\"btn w-100 btn-outline-primary mb-1\" onClick=\"cargarData({item.IdUsuario});\">Editar</button>";
                //fila += $"<button class=\"btn w-100 btn-outline-danger\" onClick=\"eliminar({item.IdUsuario});\">Eliminar</button></td>";
                fila += "</tr>";

                innerHtml.AppendLine(fila);

            }

            tbody_modulo.InnerHtml = innerHtml.ToString();


        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            string ruta = @"~/archivos/plantilla.xlsx";

            if (File.Exists(ruta))
            {

            }

        }
    }
}