using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ModuloCapacitacionBLL
    {
        #region Patron Singleton
        private static ModuloCapacitacionBLL _instancia = null;

        public ModuloCapacitacionBLL()
        {
        }

        public static ModuloCapacitacionBLL Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new ModuloCapacitacionBLL();
                }
                return _instancia;
            }
        }
        #endregion

        private static ModuloCapacitacionDAL oModuloDAL = new ModuloCapacitacionDAL();

        public List<ModuloCapacitacion> ObtenerModulos(int idUsuario)
        {
            return oModuloDAL.ObtenerModulos(idUsuario);
        }

    }
}
