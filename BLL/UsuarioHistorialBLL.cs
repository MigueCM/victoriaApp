using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UsuarioHistorialBLL
    {
        #region Patron Singleton
        private static UsuarioHistorialBLL _instancia = null;

        public UsuarioHistorialBLL()
        {
        }

        public static UsuarioHistorialBLL Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new UsuarioHistorialBLL();
                }
                return _instancia;
            }
        }
        #endregion

        private static UsuarioHistorialDAL oUsuarioDAL = new UsuarioHistorialDAL();

        public bool InsertarHistorial(int idUsuario)
        {
            if (idUsuario > 0)
            {
                return oUsuarioDAL.InsertarHistorial(idUsuario);
            }
            else return false;
        }
    }
}
