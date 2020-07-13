using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace VictoriaApp
{
    public class Globales
    {
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