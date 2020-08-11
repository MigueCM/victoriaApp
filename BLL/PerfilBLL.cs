using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PerfilBLL
    {
        #region Patron Singleton
        private static PerfilBLL _instancia = null;

        public PerfilBLL()
        {
        }

        public static PerfilBLL Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new PerfilBLL();
                }
                return _instancia;
            }
        }
        #endregion

        private static PerfilDAL oPerfilDAL = new PerfilDAL();

        public List<Perfil> ObtenerPerfil()
        {
            return oPerfilDAL.ObtenerPerfil();
        }
    }
}
