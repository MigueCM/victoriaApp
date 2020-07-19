﻿using EL;
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
            lbErrores.Items.Clear();
            List<string> errores = new List<string>();
            errores.Add("SOLUCIONE LOS SIGUIENTES ERRORES:");
            string usuario, password;
            Persona oPersona = new Persona();
            if (!string.IsNullOrEmpty(txtNombre.Value.Trim()))
                oPersona.Nombre = txtNombre.Value.Trim();
            else
                errores.Add("Ingrese nombre");
            if (!string.IsNullOrEmpty(txtApellidos.Value.Trim()))
                oPersona.Apellidos = txtApellidos.Value.Trim();
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
            if (cbPais.SelectedIndex != 0)
                oPersona.Pais = cbPais.Value.Trim();
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
                errores.Add("Ingrese usuario");
            if (!string.IsNullOrEmpty(txtPassword.Value.Trim()))
                password = CifrarClave(txtPassword.Value.Trim());
            else
                errores.Add("Ingrese password");
            if (errores.Count > 0)
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
                divErrores.Visible = false;
                lbErrores.Visible = false;
                lbErrores.Items.Clear();
            }
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