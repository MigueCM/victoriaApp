using BLL;
using EL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Net.Mime;
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
            System.Threading.Thread.Sleep(2000);
            lbErrores.Items.Clear();
            List<string> errores = new List<string>();
            errores.Add("SOLUCIONE LOS SIGUIENTES ERRORES:");
            string usuario = null, password = null;
            Persona oPersona = new Persona();
            if (!string.IsNullOrEmpty(txtNombre.Value.Trim()))
                oPersona.Nombre = txtNombre.Value.Trim();
            else
                errores.Add("Ingrese nombre");

            if (!string.IsNullOrEmpty(txtApellidos.Value.Trim()))
                oPersona.Apellidos = txtApellidos.Value.Trim();
            else
                errores.Add("Ingrese apellidos");

            if (!string.IsNullOrEmpty(txtDni.Value.Trim()))
                oPersona.Dni = txtDni.Value.Trim();
            else
                errores.Add("Ingrese apellidos");

            if (!string.IsNullOrEmpty(deFechaNacimiento.Value.Trim()))
                oPersona.FechaNacimiento = Convert.ToDateTime(deFechaNacimiento.Value.Trim());
            else
                errores.Add("Ingrese fecha de nacimiento");

            if (!string.IsNullOrEmpty(txtCelular.Value.Trim()))
                oPersona.Celular = txtCelular.Value.Trim();
            else
                errores.Add("Ingrese celular");

            if (cbSexo.SelectedIndex != 0)
                oPersona.Sexo = cbSexo.Value.Trim();
            else
                errores.Add("Escoge tu sexo");

            if (cbDepartamento.SelectedIndex != 0)
            {

                //for (int i = 0; i <= cbDepartamento.Items.Count - 1; i++)
                //{
                //    if (cbDepartamento.Items[i].Selected)
                        oPersona.Departamento = cbDepartamento.Items[cbDepartamento.SelectedIndex].Value.ToString();
                //}
            }
                //oPersona.Departamento = cbDepartamento.Items[i]..ToString();
            else
                errores.Add("Escoge tu departamento");

            if (cbEnterar.SelectedIndex != 0)
                oPersona.Enterar = cbEnterar.Value.Trim();
            else
                errores.Add("Escoge como te enteraste");

            if (!string.IsNullOrEmpty(txtUsuario.Value.Trim()))
                usuario = txtUsuario.Value.Trim();
            else
                errores.Add("Ingrese Email");

            if(!Globales.ValidarEmail(txtUsuario.Value.Trim()))
                errores.Add("Ingrese un Email valido");

            if(UsuarioBLL.Instancia.ValidarExisteUsuario(txtUsuario.Value.Trim()) == 1)
                errores.Add("Este Email esta siendo usado");

            if (!txtVerificarPassword.Value.Trim().Equals(txtPassword.Value.Trim()))
                errores.Add("Las contraseñas no son iguales");

            if (string.IsNullOrEmpty(txtVerificarPassword.Value.Trim()))
            {
                errores.Add("Verifique contraseña");
                if (txtVerificarPassword.Value.Trim().Length < 6)
                    errores.Add("Verificar contraseña debe tener minimo 6 caracteres");
            }

            if (!string.IsNullOrEmpty(txtPassword.Value.Trim()))
            {
                password = Globales.CifrarClave(txtPassword.Value.Trim());
                if (txtPassword.Value.Trim().Length < 6)
                    errores.Add("La contraseña debe tener minimo 6 caracteres");
            }
            else
                errores.Add("Ingrese contraseña");

            if (!chkTerminos.Checked)
            {
                errores.Add("Acepte los terminos, condiciones y politicas de privacidad");
            }

            if (errores.Count > 1)
            {
                lbErrores.Rows = errores.Count;

                divErrores.Visible = true;
                lbErrores.Visible = true;
                foreach (var item in errores)
                {
                    lbErrores.Items.Add(item);
                }
            }
            else
            {
                if (PersonaBLL.Instancia.RegistrarPersona(oPersona, usuario, password))
                {
                    enviaremail(usuario, oPersona.Nombre, oPersona.Apellidos); 
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "showSwal('success-message', 'Registro exitoso!', 'Bienvenido a Victoria', 'Login.aspx', '')", true);
                }
                divErrores.Visible = false;
                lbErrores.Visible = false;
                lbErrores.Items.Clear();
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
            string mailbody = "<br/><html><body><div style='text-align:center'><img src=\"cid:Email\"><div style='position: absolute; text-align:center; font-size:30px; font-weight:bold; color:#5B127D;'><p>" + nombre +" "+ apellidos +"</p><p> "+correo+ " </p></div><div><img src=\"cid:EmailMid\"></div><div><a style ='position: absolute; font-size:large; background-color:#5B127D; color:white; padding:10px; font-size:20px; border-radius:20px; text-decoration:none;' href='#'>Comienza el camino de la igualdad</a></div><br /><br /><div><img src=\"cid:EmailFooter\" ></div></div></body></html>";
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