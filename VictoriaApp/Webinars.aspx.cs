using BLL;
using EL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Web;
using System.Web.Hosting;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VictoriaApp
{
    public partial class Webinars : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarWebinars();
            }
        }

        private void CargarWebinars()
        {
            List<Webinar> lista = WebinarBLL.Instancia.ObtenerWebinar();

            StringBuilder innerHtml = new StringBuilder();

            int numero = 1;

            foreach (var item in lista)
            {
                string imagen = "images/webinar.jpg";
                string current = Server.MapPath(@"~/images/webinars/"+item.Imagen);
                if (File.Exists(current)){
                    imagen = "images/webinars/" + item.Imagen;
                }

                string fecha = item.FechaWebinar.ToString("dd'/'MM'/'yyyy") + ' ' + item.HoraWebinar.Trim();

                if(item.FechaWebinar.Year == 1)
                {
                    fecha = "";
                }

                string fila = "<tr>";
                fila += $"<td>{numero++}</td>";
                fila += $"<td>{item.Titulo}</td>";
                fila += $"<td>{item.Descripcion}</td>";
                fila += $"<td>{item.Autor}</td>";
                fila += $"<td>{fecha}</td>";
                fila += $"<td><img class='img-table' src='{imagen}' ></td>";
                fila += $"<td><button class=\"btn btn-outline-primary w-100 mb-1\" onClick=\"enviarCorreos({item.IdWebinar});\">Enviar Email</button></td>";
                fila += $"<td><button class=\"btn btn-outline-primary w-100 mb-1\" onClick=\"cargarData({item.IdWebinar});\">Editar</button>";
                fila += $"<button class=\"btn btn-outline-danger w-100 \" onClick=\"eliminar({item.IdWebinar});\">Eliminar</button></td>";
                fila += "</tr>";

                innerHtml.AppendLine(fila);

            }

            tbody_modulo.InnerHtml = innerHtml.ToString();


        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Value;
            string descripcion = txtDescripcion.Value;
            string autor = txtAutor.Value;
            string imagen = txtImagen.Value;
            string id = txtId.Value;
            string tipo = txtTipo.Value;

            if (tipo == "1")
                RegistrarWebinar();
            else
                ActualizarWebinar();

        }

        public void RegistrarWebinar()
        {
            string titulo = txtNombre.Value;
            string descripcion = txtDescripcion.Value;
            string autor = txtAutor.Value;
            string fecha = txtFecha.Value;
            string hora = txtHora.Value;

            if ((txtFile.PostedFile != null) && (txtFile.PostedFile.ContentLength > 0))
            {
                //string fn = System.IO.Path.GetFileName(txtFile.PostedFile.FileName);
                string ext = System.IO.Path.GetExtension(txtFile.PostedFile.FileName);
                string fileImagen = DateTime.Now.ToString("yyyyMMddHHmmss") + ext;
                string rutaImagen = Server.MapPath("images/webinars") + "\\" + fileImagen;

                Webinar objWebinar = new Webinar();
                objWebinar.Titulo = titulo;
                objWebinar.Descripcion = descripcion;
                objWebinar.Autor = autor;
                objWebinar.Imagen = fileImagen;
                objWebinar.FechaWebinar = Convert.ToDateTime(fecha);
                objWebinar.HoraWebinar = hora;
                objWebinar.IdUsuarioRegistro = Convert.ToInt32(Session["idUsuario"] ?? 1);

                if (WebinarBLL.Instancia.RegistrarWebinar(objWebinar))
                {
                    try
                    {
                        txtFile.PostedFile.SaveAs(rutaImagen);
                        Response.Write("The file has been uploaded.");
                        //string currentPage = this.Page.Request.AppRelativeCurrentExecutionFilePath;
                        //Response.Redirect(currentPage);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "showSwal('success-message-terminos', 'Registro exitoso!', 'Se ha registrado correctamente', 'Webinars.aspx', '')", true);

                        
                        

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

        public void ActualizarWebinar()
        {
            string titulo = txtNombre.Value;
            string descripcion = txtDescripcion.Value;
            string autor = txtAutor.Value;
            string imagen = txtImagen.Value;
            string fecha = txtFecha.Value;
            string hora = txtHora.Value;
            int id = Convert.ToInt32(txtId.Value);

            if ((txtFile.PostedFile != null) && (txtFile.PostedFile.ContentLength > 0))
            {

                string rutaImagenDelete = Server.MapPath("images/webinars") + "\\" + imagen;

                if (File.Exists(rutaImagenDelete))
                {
                    File.Delete(rutaImagenDelete);
                }

                //string fn = System.IO.Path.GetFileName(txtFile.PostedFile.FileName);
                string ext = System.IO.Path.GetExtension(txtFile.PostedFile.FileName);
                imagen = DateTime.Now.ToString("yyyyMMddHHmmss") + ext;
                string rutaImagen = Server.MapPath("images/webinars") + "\\" + imagen;

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

            Webinar objWebinar = new Webinar();
            objWebinar.Titulo = titulo;
            objWebinar.Descripcion = descripcion;
            objWebinar.Autor = autor;
            objWebinar.Imagen = imagen;
            objWebinar.FechaWebinar = Convert.ToDateTime(fecha);
            objWebinar.HoraWebinar = hora;
            objWebinar.IdUsuarioEdicion = Convert.ToInt32(Session["idUsuario"] ?? 1);

            objWebinar.IdWebinar = id;

            if (WebinarBLL.Instancia.EditarWebinar(objWebinar))
            {
                //string currentPage = this.Page.Request.AppRelativeCurrentExecutionFilePath;
                //Response.Redirect(currentPage);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "showSwal('success-message-terminos', 'Actualización exitoso!', 'Se ha editado correctamente', 'Webinars.aspx', '')", true);
            }



        }

        [WebMethod]
        public static string CargarDataWebinars(int id)
        {

            Webinar objWebinar = WebinarBLL.Instancia.ObtenerWebinarPorId(id);


            return JsonConvert.SerializeObject(
                new
                {
                    objWebinar

                }
                );

        }

        [WebMethod]
        public static bool EliminarData(int id)
        {
            return WebinarBLL.Instancia.EliminarWebinar(id);
        }


        [WebMethod]
        public static bool EnviarCorreoWeb(int id)
        {
            List<string> listaCorreos = new List<string>();
            listaCorreos = WebinarBLL.Instancia.ObtenerCorreos();
            Webinar objWebinar = WebinarBLL.Instancia.ObtenerWebinarPorId(id);
            //ScriptManager.RegisterStartupScript((Page)(HttpContext.Current.Handler), typeof(Page), "show", "ShowDiv();", true);
            bool valor = true;
            foreach (var item in listaCorreos)
            {
                valor = enviaremail(item, objWebinar.Titulo, objWebinar.Descripcion, objWebinar.Imagen);//Path.ChangeExtension(objWebinar.Imagen, "jpg"));
            }
            return valor;
            //return WebinarBLL.Instancia.EliminarWebinar(id);
        }


        protected static bool enviaremail(string correo, string titulo, string contenido, string img)
        {
            try
            {
                SmtpClient sc = new SmtpClient("smtp.gmail.com");
                sc.UseDefaultCredentials = false;
                sc.Credentials = new System.Net.NetworkCredential("aulavirtualeducacccion@gmail.com", "Danper20203%");
                sc.EnableSsl = true;
                sc.Port = 587;
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("inscripciones@aulavirtual-juntoscrecemos.pe", "Victoria");
                mail.To.Add(new MailAddress(correo));
                mail.Subject = "Proximo Webinar";
                mail.To.Add(correo);
                string mailbody = "<br/><html><body><div style='text-align:center'><h3>" + titulo + "</h3><p>" + contenido + "</p><img style='width: 500px; height:500px;' src=\"cid:Email\"></div></body></html>";
                AlternateView AlternateView_Html = AlternateView.CreateAlternateViewFromString(mailbody, null, MediaTypeNames.Text.Html);
                LinkedResource Picture = new LinkedResource(HostingEnvironment.MapPath(@"~/images/webinars/" + img), MediaTypeNames.Image.Jpeg);
                Picture.ContentId = "Email";
                AlternateView_Html.LinkedResources.Add(Picture);
                mail.AlternateViews.Add(AlternateView_Html);
                mail.Body = mailbody;
                sc.Send(mail);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            
        }
    }


}