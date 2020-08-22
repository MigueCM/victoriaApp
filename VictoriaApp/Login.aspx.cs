using BLL;
using EL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;

namespace VictoriaApp
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["IdUsuario"] != null)
                {
                    Response.Redirect("Principal.aspx");
                }
            }

        }

        protected void Ingresar_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;

            string usuario = txtUsuario.Text;
            string password = Globales.CifrarClave(txtPassword.Text);

            Usuario objUsuario = UsuarioBLL.Instancia.ObtenerUsuario(usuario, password);

            if (objUsuario != null)
            {
                UsuarioHistorialBLL.Instancia.InsertarHistorial(objUsuario.IdUsuario);

                Session["IdUsuario"] = objUsuario.IdUsuario;
                Session["IdPerfil"] = objUsuario.IdPerfil;
                Session["IdPersona"] = objUsuario.IdPersona;
                if (objUsuario.Persona != null)
                {
                    Session["nombre"] = objUsuario.Persona.Nombre;
                    Session["apellidos"] = objUsuario.Persona.Apellidos;
                    Session["UsuarioDni"] = objUsuario.Persona.Dni;
                    Session["UbicacionUsuario"] = objUsuario.Persona.Departamento + ", " + objUsuario.Persona.Ciudad;
                    if (string.IsNullOrEmpty(objUsuario.Persona.Avatar) || objUsuario.Persona.Avatar == "")
                        Session["AvatarPersona"] = Globales.ImageDefault(objUsuario.Persona.Sexo); //"Data/Avatar/noImage.png";



                    else
                    {
                        Session["AvatarPersona"] = Globales.ImageDefault(objUsuario.Persona.Sexo);//"Data/Avatar/noImage.png";

                        string current = Server.MapPath(@"~/Data/Avatar/" + objUsuario.Persona.Avatar);
                        if (File.Exists(current))
                        {
                            Session["AvatarPersona"] = "Data/Avatar/" + objUsuario.Persona.Avatar;
                        }

                    }
                        
                }
                else
                {
                    Session["nombre"] = "";
                    Session["apellidos"] = "";
                }

                int porcentaje = UsuarioCapacitacionBLL.Instancia.ObtenerPorcentajeModulos(objUsuario.IdUsuario);

                Session["prog_value"] = $"width: {porcentaje}%";
                Session["prog_text"] = $"{porcentaje}% Avance";

                

                if (Convert.ToInt32(Session["IdPerfil"].ToString()) == 1)
                {
                    Response.Redirect("GestionUsuario.aspx");
                }
                else
                {
                    
                    Response.Redirect("Principal.aspx");
                }

               
            }
            else
            {

                lblError.Visible = true;

            }



        }               

        [WebMethod]
        public static string EnviarEmail(string email)
        {



            string mensaje = "Correo Invalido";
            string token = "";
            bool correoValido = false;



            if (Globales.ValidarEmail(email))
            {

                mensaje = "Email enviado. Revise su correo";
                Usuario objUsuario = UsuarioBLL.Instancia.ValidarPorUsuario(email);
                correoValido = objUsuario != null;


                if (correoValido)
                {
                    token = Globales.GenerarToken();

                    if (!UsuarioBLL.Instancia.ActualizarToken(token, objUsuario.IdUsuario))
                    {
                        mensaje = "Error al enviar correo intente de nuevo";
                        correoValido = false;
                    }
                    else
                    {
                        string url = HttpContext.Current.Request.Url.AbsoluteUri;
                        string pagina = HttpContext.Current.Request.Url.AbsolutePath;
                        string page = url.Replace(pagina, "")+"/RecuperarContraseña/"+token;
                        enviaremail(email,page);
                    }

                }
                else
                {
                    mensaje = "El correo no se encuentra registrado";
                }


                //admin@hotmail.com


            }


            return JsonConvert.SerializeObject(
                new
                {
                    correoValido,
                    mensaje,
                    token

                }
                );

        }

        private static void enviaremail(string correo,string page)
        {
            SmtpClient sc = new SmtpClient("smtp.gmail.com");
            sc.UseDefaultCredentials = false;
            sc.Credentials = new System.Net.NetworkCredential("aulavirtualeducacccion@gmail.com", "Danper20203%");
            sc.EnableSsl = true;
            sc.Port = 587;
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("inscripciones@aulavirtual-juntoscrecemos.pe", "Victoria");
            mail.To.Add(new MailAddress(correo));
            mail.Subject = "Recuperación de Contraseña.";
            mail.To.Add(correo);
            string mailbody = "<br/><html><body><div style='text-align:center'><img src=\"cid:Email\"><div style='position: absolute; text-align:center; font-size:15px; font-weight:bold; color:#5B127D;'><p> Haz click en el siguiente botón para cambiar tu contraseña. </p></div><div><a style ='position: absolute; font-size:large; background-color:#5B127D; color:white; padding:10px; font-size:20px; border-radius:20px; text-decoration:none;' href='"+page+"'>Recuperar Contraseña</a></div><br /><br /><div><img src=\"cid:EmailFooter\" ></div></div></body></html>";
            AlternateView AlternateView_Html = AlternateView.CreateAlternateViewFromString(mailbody, null, MediaTypeNames.Text.Html);
            LinkedResource Picture1 = new LinkedResource(HttpContext.Current.Server.MapPath(@"~/images/correoLogo.jpg"), MediaTypeNames.Image.Jpeg);
            
            LinkedResource Picture3 = new LinkedResource(HttpContext.Current.Server.MapPath(@"~/images/correoFooter.jpg"), MediaTypeNames.Image.Jpeg);
            Picture1.ContentId = "Email";
            //Picture2.ContentId = "EmailMid";
            Picture3.ContentId = "EmailFooter";
            AlternateView_Html.LinkedResources.Add(Picture1);
            //AlternateView_Html.LinkedResources.Add(Picture2);
            AlternateView_Html.LinkedResources.Add(Picture3);
            mail.AlternateViews.Add(AlternateView_Html);
            mail.Body = mailbody;
            sc.Send(mail);
        }
    }
}