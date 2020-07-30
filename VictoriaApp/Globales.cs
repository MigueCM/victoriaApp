using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace VictoriaApp
{
    public class Globales
    {

        public static int longitudToken = 10;
        public static string CifrarClave(string clave)
        {
            SHA512Managed password = new SHA512Managed();
            byte[] texto = Encoding.ASCII.GetBytes(clave);
            byte[] textocifrado = password.ComputeHash(texto);
            string contrasena = Convert.ToBase64String(textocifrado);
            return contrasena;
        }

        public static Boolean ValidarEmail(String email)
        {
            String expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            /*if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

                return Regex.Replace(email, expresion, String.Empty).Length == 0;

            }
            else
            {
                return false;
            }*/

            return Regex.IsMatch(email, expresion) ?
                        Regex.Replace(email, expresion, String.Empty).Length == 0 :
                        false;

        }

        public static string GenerarToken()
        {
            Guid miGuid = Guid.NewGuid();
            string token = Convert.ToBase64String(miGuid.ToByteArray());
            token = token.Replace("=", "").Replace("+", "");

            //Console.WriteLine(token.Substring(0, longitud));

            return token.Substring(0, longitudToken);

        }

    }
}