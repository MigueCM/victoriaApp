using BLL;
using EL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Web;
using System.Web.UI;

namespace VictoriaApp
{
    public partial class Registro : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TerminosCondicionesEL terminos = new TerminosCondicionesEL();
            terminos = TerminosCondicionesBLL.Instancia.ObtenerTerminos();
            Session["TituloTerminos"] = terminos.Titulo;
            Session["DescripcionTerminos"] = terminos.Descripcion;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Titulo", "var sessionTitulo = '" + Session["TituloTerminos"] + "';", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Descripcion", "var sessionDescripcion = '" + Session["DescripcionTerminos"] + "';", true);
            if (!IsPostBack)
            {
                List<Ubigeo> data = new List<Ubigeo>();
                data = UbigeoBLL.Instancia.ObtenerUbigeo();
                cbDepartamento.DataSource = data;
                cbDepartamento.DataTextField = "Completo";
                cbDepartamento.DataValueField = "IdDistrito"; 
                cbDepartamento.DataBind();

            }

            //ClientScript.RegisterStartupScript(this.GetType(), "Loader", "<script> $(document).ready(function() {$('#<%=UpdateProgress1.ClientID %>').show('slow', 'linear', function() {$('#<%=UpdateProgress1.ClientID %>').hide();});});</script>");
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            StringBuilder innerHtml = new StringBuilder();
            System.Threading.Thread.Sleep(2000);
            //lbErrores.Items.Clear();
            List<string> errores = new List<string>();
            errores.Add("SOLUCIONE LOS SIGUIENTES ERRORES: <br/>");
            string usuario = null, password = null;
            Persona oPersona = new Persona();
            if (!string.IsNullOrEmpty(txtNombre.Value.Trim()))
                oPersona.Nombre = txtNombre.Value.Trim();
            else
            {
                errores.Add("Ingresa tu nombre <br/>");
            }
            if (!string.IsNullOrEmpty(txtApellidos.Value.Trim()))
                oPersona.Apellidos = txtApellidos.Value.Trim();
            else
            {
                //fila += $"Ingrese apellidos";
                errores.Add("Ingresa tus apellidos <br/>");
            }
            if (!string.IsNullOrEmpty(txtDni.Value.Trim()))
                oPersona.Dni = txtDni.Value.Trim();
            else
            {
                //fila += $"Ingrese número de DNI";
                errores.Add("Ingresa tu número de DNI <br/>");
            }
            if (!string.IsNullOrEmpty(deFechaNacimiento.Value.Trim()))
                oPersona.FechaNacimiento = Convert.ToDateTime(deFechaNacimiento.Value.Trim());
            else
            {
                //fila += $"Ingrese fecha de nacimiento";
                errores.Add("Ingresa tu fecha de nacimiento <br/>");
            }
            if (!string.IsNullOrEmpty(txtCelular.Value.Trim()))
                oPersona.Celular = txtCelular.Value.Trim();
            else
            {
                //fila += $"Ingrese celular";
                errores.Add("Ingresa tu número celular <br/>");
            }
            if (cbSexo.SelectedIndex != 0)
                oPersona.Sexo = cbSexo.Value.Trim();
            else
            {
                //fila += $"Escoge tu sexo";
                errores.Add("Escoge tu sexo <br/>");
            }
            if (cbDepartamento.SelectedIndex != 0)
            {
                oPersona.Departamento = cbDepartamento.Items[cbDepartamento.SelectedIndex].Value.ToString();
            }
            else
            {
                //fila += $"Escoge tu departamento";
                errores.Add("Escoge tu departamento <br/>");
            }
            if (cbEnterar.SelectedIndex != 0)
                oPersona.Enterar = cbEnterar.Value.Trim();
            else
            {
                errores.Add("Escoge como te enteraste <br/>");
            }
            if (!string.IsNullOrEmpty(txtUsuario.Value.Trim()))
                usuario = txtUsuario.Value.Trim();
            else
            {
                errores.Add("Ingrese Email <br/>");
            }
            if (!Globales.ValidarEmail(txtUsuario.Value.Trim()))
                errores.Add("Ingrese un Email valido <br/>");

            if(UsuarioBLL.Instancia.ValidarExisteUsuario(txtUsuario.Value.Trim()) == 1)
                errores.Add("Este Email esta siendo usado <br/>");

            if (!txtVerificarPassword.Value.Trim().Equals(txtPassword.Value.Trim()))
                errores.Add("Las contraseñas no son iguales <br/>");

            if (!string.IsNullOrEmpty(txtVerificarPassword.Value.Trim()))
            {
                if (txtVerificarPassword.Value.Trim().Length < 6)
                    errores.Add("Verificar contraseña debe tener minimo 6 caracteres <br/>");
            }
            else
            {
                errores.Add("Ingrese contraseña <br/>");
            }

            if (!string.IsNullOrEmpty(txtPassword.Value.Trim()))
            {
                password = Globales.CifrarClave(txtPassword.Value.Trim());
                if (txtPassword.Value.Trim().Length < 6)
                    errores.Add("La contraseña debe tener minimo 6 caracteres <br/>");
            }
            else
            {
                errores.Add("Ingrese contraseña <br/>");
            }

            if (!chkTerminos.Checked)
            {
                errores.Add("Acepte los terminos, condiciones y politicas de privacidad <br/>");
            }
           
            
            if (errores.Count > 1)
            {
                //lbErrores.Rows = errores.Count;

                //divErrores.Visible = true;
                //lbErrores.Visible = true;
                //foreach (var item in errores)
                //{
                //    lbErrores.Items.Add(item);
                //}
                lblError.Visible = true;
                string fila = null;
                foreach (var item in errores)
                {
                    fila += $"{item}";
                }
                innerHtml.AppendLine(fila);
                Session["ErroresRegistro"] = HttpUtility.HtmlEncode(innerHtml.ToString());
            }
            else
            {
                int idPersona = PersonaBLL.Instancia.RegistrarPersona(oPersona);
                if (idPersona > 0)
                {

                    Usuario oUsuario = new Usuario();
                    oUsuario.IdPerfil = 2;
                    oUsuario.IdPersona = idPersona;
                    oUsuario.IdUsuarioRegistro = 0;
                    oUsuario.User = usuario;
                    oUsuario.Password = password;

                    if (UsuarioBLL.Instancia.InsertarUsuario(oUsuario))
                    {
                        enviaremail(usuario, oPersona.Nombre, oPersona.Apellidos);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "showSwal('success-message', 'Registro exitoso!', 'Bienvenido a Victoria', 'Login.aspx', '')", true);
                    }

                    
                }
                //divErrores.Visible = false;
                //lbErrores.Visible = false;
                //lbErrores.Items.Clear();
            }
        }

        protected void enviaremail(string correo, string nombre, string apellidos)
        {
            SmtpClient sc = new SmtpClient("smtp.gmail.com");
            sc.UseDefaultCredentials = false;
            sc.Credentials = new System.Net.NetworkCredential("aulavirtualeducacccion@gmail.com", "Danper20203%");
            sc.EnableSsl = true;
            sc.Port = 587;
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("inscripciones@aulavirtual-juntoscrecemos.pe", "Victoria");
            mail.To.Add(new MailAddress(correo));
            mail.Subject = "Solicitud registrada.";
            mail.To.Add(correo);
            string mailbody = "<br/><html><body><div style='text-align:center'><img src=\"cid:Email\"><div style='position: absolute; text-align:center; font-size:30px; font-weight:bold; color:#5B127D;'><p>" + nombre +" "+ apellidos +"</p><p> "+correo+ " </p></div><div><img src=\"cid:EmailMid\"></div><div><a style ='position: absolute; font-size:large; background-color:#5B127D; color:white; padding:10px; font-size:20px; border-radius:20px; text-decoration:none;' href='http://www.aulavirtual-juntoscrecemos.pe/victoria/login.aspx'>Comienza</a></div><br /><br /><div><img src=\"cid:EmailFooter\" ></div></div></body></html>";
            AlternateView AlternateView_Html = AlternateView.CreateAlternateViewFromString(mailbody, null, MediaTypeNames.Text.Html);
            LinkedResource Picture1 = new LinkedResource(Server.MapPath(@"~/images/correoCabecera.jpg"), MediaTypeNames.Image.Jpeg);
            LinkedResource Picture2 = new LinkedResource(Server.MapPath(@"~/images/correoMedio.jpg"), MediaTypeNames.Image.Jpeg);
            LinkedResource Picture3 = new LinkedResource(Server.MapPath(@"~/images/correoFooter.jpg"), MediaTypeNames.Image.Jpeg);
            Picture1.ContentId = "Email";
            Picture2.ContentId = "EmailMid";
            Picture3.ContentId = "EmailFooter";
            AlternateView_Html.LinkedResources.Add(Picture1);
            AlternateView_Html.LinkedResources.Add(Picture2);
            AlternateView_Html.LinkedResources.Add(Picture3);
            mail.AlternateViews.Add(AlternateView_Html);
            mail.Body = mailbody;
            sc.Send(mail);
        }
    }
}