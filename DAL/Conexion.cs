using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Conexion
    {
        private static string _CadenaConexion = "Data Source=tcp:s23.winhost.com;Initial Catalog=DB_137602_victoria;User ID=DB_137602_victoria_user;Password=tumarido;Integrated Security=False;";
        //private static string _CadenaConexion = "Data Source=localhost;Initial Catalog=db_victoria;User ID=sa;Password=123456;Integrated Security=False;";

        public static string CadenaConexion
        {
            get
            {
                return _CadenaConexion;
            }
        }
    }
}
