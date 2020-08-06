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
    public partial class PreguntaCapacitacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargasPreguntas();
                CargarComboOrden();
            }
        }

        private void CargasPreguntas()
        {
            int idModulo = Convert.ToInt32(Session["idModuloCapacitacion"]);

            List<EL.PreguntaCapacitacion> lista = PreguntaCapacitacionBLL.Instancia.ObtenerPreguntas(idModulo);

            StringBuilder innerHtml = new StringBuilder();

           
            foreach (var item in lista)
            {
                string fila = "<tr>";
                fila += $"<td>{item.Orden}</td>";                
                fila += $"<td>{item.Descripcion}</td>";
                fila += $"<td><button class=\"btn btn-outline-primary\" onClick=\"cargarData({item.IdPreguntaCapacitacion});\">Editar</button>";
                fila += $"<button class=\"btn btn-outline-danger\" onClick=\"eliminar({item.IdPreguntaCapacitacion});\">Eliminar</button></td>";
                fila += "</tr>";

                innerHtml.AppendLine(fila);

            }

            tbody_modulo.InnerHtml = innerHtml.ToString();


        }

        private void CargarComboOrden()
        {
            int idModulo = Convert.ToInt32(Session["idModuloCapacitacion"]);

            int orden = PreguntaCapacitacionBLL.Instancia.ObtenerUltimoNumero(idModulo);

            StringBuilder innerHtml = new StringBuilder();
            innerHtml.AppendLine("<option value=\"\">Seleccione Orden</option>");

            List<ComboItem> items = new List<ComboItem>();

            items.Add(new ComboItem()
            {
                ID = "",
                Text = "Seleccione Orden"
            });

            for (int i = 0; i <= orden; i++)
            {

                items.Add(new ComboItem()
                {
                    ID = ""+(i + 1),
                    Text = ""+(i + 1)
                });
                
            }
            cboOrden.DataSource = items;
            cboOrden.DataTextField = "Text";
            cboOrden.DataValueField = "ID";
            cboOrden.SelectedIndex = orden + 1;
            cboOrden.DataBind();
        }

        class ComboItem
        {
            public string ID { get; set; }
            public string Text { get; set; }
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            string pregunta = txtDescripcion.Value;
            int orden = Convert.ToInt32(cboOrden.Value);
            string alternativa1 = txtAlternativa1.Value;
            string alternativa2 = txtAlternativa2.Value;
            string alternativa3 = txtAlternativa3.Value;
            string alternativa4 = txtAlternativa4.Value;
            string alternativa5 = txtAlternativa5.Value;
            string respuesta = cboAlternativa.Value;
            
            string tipo = txtTipo.Value;
            int idModulo = Convert.ToInt32(Session["idModuloCapacitacion"]);

            EL.PreguntaCapacitacion objPreguntas = new EL.PreguntaCapacitacion();
            objPreguntas.IdModuloCapacitacion = idModulo;
            objPreguntas.Descripcion = pregunta;
            objPreguntas.Orden = orden;
            objPreguntas.Alternativa1 = alternativa1;
            objPreguntas.Alternativa2 = alternativa2;
            objPreguntas.Alternativa3 = alternativa3;
            objPreguntas.Alternativa4 = alternativa4;
            objPreguntas.Alternativa5 = alternativa5;
            objPreguntas.Respuesta = respuesta;

            bool exito = false;

            if(tipo == "1")
            {
                exito = PreguntaCapacitacionBLL.Instancia.RegistrarPregunta(objPreguntas);
            }
            else if(tipo == "2")
            {
                objPreguntas.IdPreguntaCapacitacion = Convert.ToInt32(txtId.Value);
                exito = PreguntaCapacitacionBLL.Instancia.EditarPregunta(objPreguntas);
            }

            if (exito)
            {
                string currentPage = this.Page.Request.AppRelativeCurrentExecutionFilePath;
                Response.Redirect(currentPage);
            }




        }

        [WebMethod]
        public static string CargarDataPreguntas(int id)
        {

            EL.PreguntaCapacitacion objPreguntas = PreguntaCapacitacionBLL.Instancia.ObtenerPreguntasPorId(id);

            return JsonConvert.SerializeObject(
                new
                {
                    objPreguntas

                }
                );

        }
        
        [WebMethod]
        public static bool EliminarData(int id)
        {
            return PreguntaCapacitacionBLL.Instancia.EliminarPregunta(id);
        }

    }
}