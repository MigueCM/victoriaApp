using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using EL;

namespace BLL
{
    public class UsuarioBLL
    {
        #region Patron Singleton
        private static UsuarioBLL _instancia = null;

        public UsuarioBLL()
        {
        }

        public static UsuarioBLL Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new UsuarioBLL();
                }
                return _instancia;
            }
        }
        #endregion

        private static UsuarioDAL oUsuarioDAL = new UsuarioDAL();

        public Usuario ObtenerUsuario(string usuario, string password)
        {
            return null;
        }


    }
}
