using BLL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VictoriaApp
{
    public partial class ModuloCapacitacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarModulos();
            }
        }

        private void CargarModulos()
        {
            List<EL.ModuloCapacitacion> lista = ModuloCapacitacionBLL.Instancia.ObtenerModulos();

            StringBuilder innerHtml = new StringBuilder();

            int numero = 1;

            foreach (var item in lista)
            {
                string fila = "<tr>";
                fila += $"<td>{numero++}</td>";
                fila += $"<td>{item.Nombre}</td>";
                fila += $"<td>{item.Descripcion}</td>";
                fila += $"<td>{item.Enlace}</td>";
                fila += $"<td>5 <i class=\"fa fa-star\"></i></td>";
                fila += $"<td><button class=\"btn btn-outline-primary\" onClick=\"cargarData({item.IdModuloCapacitacion});\">Editar</button>";
                fila += $"<button class=\"btn btn-outline-success\" onClick=\"redireccionPreguntas({item.IdModuloCapacitacion});\">Agregar Preguntas</button></td>";
                fila += "</tr>";

                innerHtml.AppendLine(fila);

            }

            tbody_modulo.InnerHtml = innerHtml.ToString();


        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Value;
            string descripcion = txtDescripcion.Value;
            string enlace = txtEnlace.Value;
            string imagen = txtImagen.Value;
            string id = txtId.Value;
            string tipo = txtTipo.Value;

            if (tipo == "1")
                RegistrarModulo();
            else
                ActualizarModulo();

            txtTipo.Value = "1";
            txtId.Value = "";
            txtImagen.Value = "";

        }

        [WebMethod]
        public static string CargarDataModulo(int id)
        {

            EL.ModuloCapacitacion objModulo = ModuloCapacitacionBLL.Instancia.ObtenerModulosPorId(id);

             


            return JsonConvert.SerializeObject(
                new
                {
                    objModulo

                }
                );

        }

        [WebMethod(EnableSession = true)]
        public static void RedireccionPreguntas(int id)
        {
            HttpContext.Current.Session["idModuloCapacitacion"] = id;
        }

        public void RegistrarModulo()
        {
            string nombre = txtNombre.Value;
            string descripcion = txtDescripcion.Value;
            string enlace = txtEnlace.Value;

            if ((txtFile.PostedFile != null) && (txtFile.PostedFile.ContentLength > 0))
            {
                //string fn = System.IO.Path.GetFileName(txtFile.PostedFile.FileName);
                string ext = System.IO.Path.GetExtension(txtFile.PostedFile.FileName);
                string fileImagen = DateTime.Now.ToString("yyyyMMddHHmmss") + ext;
                string rutaImagen = Server.MapPath("Data") + "\\" + fileImagen;

                EL.ModuloCapacitacion objModulo = new EL.ModuloCapacitacion();
                objModulo.Nombre = nombre;
                objModulo.Descripcion = descripcion;
                objModulo.Enlace = enlace;
                objModulo.Autor = "Lorem Ipsum";
                objModulo.Imagen = fileImagen;
                objModulo.IdUsuarioRegistro = Convert.ToInt32(Session["idUsuario"] ?? 1);
                objModulo.Estado = 1;

                if (ModuloCapacitacionBLL.Instancia.RegistrarModulo(objModulo))
                {
                    try
                    {
                        txtFile.PostedFile.SaveAs(rutaImagen);
                        Response.Write("The file has been uploaded.");

                        string currentPage = this.Page.Request.AppRelativeCurrentExecutionFilePath;
                        Response.Redirect(currentPage);

                    }
                    catch (Exception ex)
                    {
                        Response.Write("Error: " + ex.Message);//Note: Exception.Message returns a detailed message that describes the current exception. //For security reasons, we do not recommend that you return Exception.Message to end users in //production environments. It would be better to put a generic error message. 
                    }
                }


            }
            else
            {
                Response.Write("Please select a file to upload.");
            }

        }


        public void ActualizarModulo()
        {
            string nombre = txtNombre.Value;
            string descripcion = txtDescripcion.Value;
            string enlace = txtEnlace.Value;
            string imagen = txtImagen.Value;
            int id = Convert.ToInt32(txtId.Value);

            if ((txtFile.PostedFile != null) && (txtFile.PostedFile.ContentLength > 0))
            {

                string rutaImagenDelete = Server.MapPath("Data") + "\\" + imagen;

                if (File.Exists(rutaImagenDelete))
                {
                    File.Delete(rutaImagenDelete);
                }

                //string fn = System.IO.Path.GetFileName(txtFile.PostedFile.FileName);
                string ext = System.IO.Path.GetExtension(txtFile.PostedFile.FileName);
                imagen = DateTime.Now.ToString("yyyyMMddHHmmss") + ext;
                string rutaImagen = Server.MapPath("Data") + "\\" + imagen;

                try
                {
                    txtFile.PostedFile.SaveAs(rutaImagen);
                    Response.Write("The file has been uploaded.");                   

                }
                catch (Exception ex)
                {
                    Response.Write("Error: " + ex.Message);//Note: Exception.Message returns a detailed message that describes the current exception. //For security reasons, we do not recommend that you return Exception.Message to end users in //production environments. It would be better to put a generic error message. 
                }

            }

            EL.ModuloCapacitacion objModulo = new EL.ModuloCapacitacion();
            objModulo.Nombre = nombre;
            objModulo.Descripcion = descripcion;
            objModulo.Enlace = enlace;
            objModulo.Autor = "Lorem Ipsum";
            objModulo.Imagen = imagen;
            objModulo.IdUsuarioRegistro = Convert.ToInt32(Session["idUsuario"] ?? 1);
            objModulo.Estado = 1;
            objModulo.IdModuloCapacitacion = id;

            if (ModuloCapacitacionBLL.Instancia.EditarModulo(objModulo))
            {
                string currentPage = this.Page.Request.AppRelativeCurrentExecutionFilePath;
                Response.Redirect(currentPage);
            }



        }

    }
}