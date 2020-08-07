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
                fila += $"<td>{item.Calificacion} <i class=\"fa fa-star\"></i></td>";
                fila += $"<td><button class=\"btn btn-outline-primary mb-1\" onClick=\"cargarData({item.IdModuloCapacitacion});\">Editar</button>";
                fila += $"<button class=\"btn btn-outline-success mb-1\" onClick=\"redireccionPreguntas({item.IdModuloCapacitacion});\">Agregar Preguntas</button>";
                fila += $"<button class=\"btn btn-outline-danger \" onClick=\"eliminar({item.IdModuloCapacitacion});\">Eliminar</button></td>";
                fila += "</tr>";

                innerHtml.AppendLine(fila);

            }

            tbody_modulo.InnerHtml = innerHtml.ToString();


        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            divErrores.Visible = false;
            lbErrores.Visible = false;
            lbErrores.Items.Clear();

            //string nombre = txtNombre.Value;
            //string descripcion = txtDescripcion.Value;
            //string enlace = txtEnlace.Value;
            //string imagen = txtImagen.Value;
            //string id = txtId.Value;
            string tipo = txtTipo.Value;

            if (tipo == "1")
                RegistrarModulo();
            else
                ActualizarModulo();

            //txtTipo.Value = "1";
            //txtId.Value = "";
            //txtImagen.Value = "";

            if (lbErrores.Items.Count > 0)
            {
                divErrores.Visible = true;
                lbErrores.Visible = true;
            }

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

        [WebMethod]
        public static bool EliminarData(int id)
        {
            return ModuloCapacitacionBLL.Instancia.EliminarModulo(id);
        }

        public void RegistrarModulo()
        {
            string nombre = txtNombre.Value;
            string descripcion = txtDescripcion.Value;
            string enlace = txtEnlace.Value;
            
            if (string.IsNullOrEmpty(nombre))
            {
                lbErrores.Items.Add("Debe ingresar el nombre del módulo ");
            }

            if (string.IsNullOrEmpty(descripcion))
            {
                lbErrores.Items.Add("Debe ingresar el enlace");
            }

            if (string.IsNullOrEmpty(enlace))
            {
                lbErrores.Items.Add("Debe ingresar la descripción");
            }

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
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "registrarModulo", "showSwal('auto-close', 'Registro exitoso!', 'Módulo registrado correctamente', 'ModuloCapacitacion.aspx', '')", true);
                    }
                    catch (Exception ex)
                    {
                        Response.Write("Error: " + ex.Message);//Note: Exception.Message returns a detailed message that describes the current exception. //For security reasons, we do not recommend that you return Exception.Message to end users in //production environments. It would be better to put a generic error message. 
                    }
                }


            }
            else
            {
                lbErrores.Items.Add("Debe seleccionar una imagen");
            }

            

        }

        public void ActualizarModulo()
        {
            string nombre = txtNombre.Value;
            string descripcion = txtDescripcion.Value;
            string enlace = txtEnlace.Value;
            string imagen = txtImagen.Value;
            int id = Convert.ToInt32(txtId.Value);

            if (string.IsNullOrEmpty(nombre))
            {
                lbErrores.Items.Add("Debe ingresar el nombre del módulo ");
            }

            if (string.IsNullOrEmpty(descripcion))
            {
                lbErrores.Items.Add("Debe ingresar el enlace");
            }

            if (string.IsNullOrEmpty(enlace))
            {
                lbErrores.Items.Add("Debe ingresar la descripción");
            }


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
                ScriptManager.RegisterStartupScript(this, this.GetType(), "editarModulo", "showSwal('auto-close', 'Edición exitosa!', 'Módulo editado correctamente', 'ModuloCapacitacion.aspx', '')", true);
                //Response.Redirect(currentPage);
            }



        }

        
        

    }
}