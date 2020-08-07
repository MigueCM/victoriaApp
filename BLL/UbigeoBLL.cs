using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UbigeoBLL
    {
        #region Patron Singleton
        private static UbigeoBLL _instancia = null;

        public UbigeoBLL()
        {
        }

        public static UbigeoBLL Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new UbigeoBLL();
                }
                return _instancia;
            }
        }
        #endregion

        UbigeoDAL ubigeoDAL = new UbigeoDAL();
        public List<Ubigeo> ObtenerUbigeo()
        {
            return ubigeoDAL.ObtenerUbigeo();
        }
    }
}
