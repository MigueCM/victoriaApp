using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VictoriaApp
{
    public partial class Registro : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            Persona oPersona = new Persona();
            oPersona.Nombre = txtNombre.Value;
            oPersona.Apellidos = txtApellidos.Value;
            oPersona.FechaNacimiento = Convert.ToDateTime(deFechaNacimiento.Value);
            oPersona.Correo = txtCorreo.Value;
            oPersona.Password = txtPassword.Value;
            oPersona.Celular = txtCelular.Value;

        }
    }
}