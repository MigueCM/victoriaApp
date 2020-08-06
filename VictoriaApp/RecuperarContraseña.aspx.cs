using BLL;
using EL;
using System;

namespace VictoriaApp
{
    public partial class RecuperarContraseña : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Uri url = Request.Url;

                string localPath = url.LocalPath;


                if (localPath.ToLower().Equals("/recuperarcontraseña"))
                {
                    Response.Redirect("Login.aspx");
                }
                else if (localPath.ToLower().Equals("/recuperarcontraseña/"))
                {
                    Response.Redirect("/Login.aspx");
                }

            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {

            Uri url = Request.Url;

            string token = url.LocalPath.Substring(url.LocalPath.Length - Globales.longitudToken, Globales.longitudToken);

            Usuario objUsuario = UsuarioBLL.Instancia.ValidarPorToken(token);
            lblError.Visible = true;

            if (objUsuario != null)
            {

                if (password1.Text.Trim().Length > 0 && password2.Text.Trim().Length > 0)
                {

                    if (password1.Text == password2.Text)
                    {

                        string password = Globales.CifrarClave(password1.Text);

                        if (UsuarioBLL.Instancia.ActualizarPassword(password, objUsuario.IdUsuario))
                        {
                            Response.Redirect("/Login.aspx");
                            lblError.InnerText = "Modificado correctamente";

                        }
                        else
                        {
                            lblError.InnerText = "Error al modificar usuario";
                        }

                    }
                    else
                    {
                        lblError.InnerText = "Error ingrese contraseñas iguales";
                    }

                }
                else
                {
                    lblError.InnerText = "Error debe ingresarla contraseñas";
                }

            }
            else
            {

                lblError.InnerText = "Error token invalido y/o ya expiró";

            }

        }
    }
}