using BLL;
using EL;
using System;
using System.Collections.Generic;
using System.Web.UI;

namespace VictoriaApp
{
    public partial class Registro : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

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
                oPersona.Departamento = cbDepartamento.Value.Trim();
            else
                errores.Add("Escoge tu pais");

            if (cbCiudad.SelectedIndex != 0)
                oPersona.Ciudad = cbCiudad.Value.Trim();
            else
                errores.Add("Escoge tu ciudad");

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
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "showSwal('success-message', 'Registro exitoso!', 'Bienvenido a Victoria', 'Login.aspx')", true);
                }
                divErrores.Visible = false;
                lbErrores.Visible = false;
                lbErrores.Items.Clear();
            }
        }
    }
}