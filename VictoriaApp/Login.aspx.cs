using BLL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VictoriaApp
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Ingresar_Click(object sender, EventArgs e)
        {


            string usuario = txtUsuario.Text;
            string password = Globales.CifrarClave(txtPassword.Text);

            Usuario objUsuario = UsuarioBLL.Instancia.ObtenerUsuario(usuario, password);

            if (objUsuario != null)
            {
                Session["IdUsuario"] = objUsuario.IdUsuario;


            }
            else
            {



            }



        }
    }
}