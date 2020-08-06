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

        public List<ModuloCapacitacion> ObtenerModulosPorUsuario(int idUsuario)
        {
            return oModuloDAL.ObtenerModulosPorUsuario(idUsuario);
        }

        public List<ModuloCapacitacion> ObtenerModulosPorUsuarioPanel(int idUsuario)
        {
            return oModuloDAL.ObtenerModulosPorUsuarioPanel(idUsuario);
        }

        public List<ModuloCapacitacion> ObtenerModulos()
        {
            return oModuloDAL.ObtenerModulos();
        }

        public ModuloCapacitacion ObtenerModulosPorId(int idModulo)
        {
            return oModuloDAL.ObtenerModulosPorId(idModulo);
        }

        public bool RegistrarModulo(ModuloCapacitacion moduloCapacitacion)
        {
            return oModuloDAL.RegistrarModulo(moduloCapacitacion);
        }

        public bool EditarModulo(ModuloCapacitacion moduloCapacitacion)
        {
            return oModuloDAL.EditarModulo(moduloCapacitacion);
        }

        public bool EliminarModulo(int idModuloCapacitacion)
        {
            return oModuloDAL.EliminarModulo(idModuloCapacitacion);
        }

    }
}
