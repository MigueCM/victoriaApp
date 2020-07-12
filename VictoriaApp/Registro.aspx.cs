using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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
            oPersona.Password = CifrarClave(txtPassword.Value.Trim());
            oPersona.Celular = txtCelular.Value;

        }

        public static string CifrarClave(string clave)
        {
            SHA512Managed password = new SHA512Managed();
            byte[] texto = Encoding.ASCII.GetBytes(clave);
            byte[] textocifrado = password.ComputeHash(texto);
            string contrasena = Convert.ToBase64String(textocifrado);
            return contrasena;
        }
    }
}