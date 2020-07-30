using BLL;
using EL;
using Newtonsoft.Json;
using System;
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

                int porcentaje = UsuarioCapacitacionBLL.Instancia.ObtenerPorcentajeModulos(objUsuario.IdUsuario);

                Session["prog_value"] = $"width: {porcentaje}%";
                Session["prog_text"] = $"{porcentaje}% Avance";

                if (objUsuario.Persona != null)
                {
                    Session["nombre"] = objUsuario.Persona.Nombre;
                    Session["apellidos"] = objUsuario.Persona.Apellidos;
                }
                else
                {
                    Session["nombre"] = "";
                    Session["apellidos"] = "";
                }
                Response.Redirect("Principal.aspx");
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

    }
}