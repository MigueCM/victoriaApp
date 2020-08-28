using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UsuarioCapacitacionBLL
    {
        #region Patron Singleton
        private static UsuarioCapacitacionBLL _instancia = null;

        public UsuarioCapacitacionBLL()
        {
        }

        public static UsuarioCapacitacionBLL Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new UsuarioCapacitacionBLL();
                }
                return _instancia;
            }
        }
        #endregion

        private static UsuarioCapacitacionDAL oUsuarioDAL = new UsuarioCapacitacionDAL();

        public int ObtenerPorcentajeModulos(int idUsuario)
        {
            return oUsuarioDAL.ObtenerPorcentajeModulos(idUsuario);
        }

        public int ObtenerModuloDesbloqueado(int idUsuario)
        {
            return oUsuarioDAL.ObtenerModuloDesbloqueado(idUsuario);
        }

        public bool RegistrarCapacitacion(UsuarioCapacitacion usuarioCapacitacion)
        {
            return oUsuarioDAL.RegistrarCapacitacion(usuarioCapacitacion);
        }

        public int ObtenerCalificacion(int idModulo)
        {
            return oUsuarioDAL.ObtenerCalificacion(idModulo);
        }

        public int ObtenerIntento(int idModulo, int idUsuario)
        {
            return oUsuarioDAL.ObtenerIntento(idModulo, idUsuario);
        }

        public int ObtenerVisualizacion(int idModulo)
        {
            return oUsuarioDAL.ObtenerVisualizacion(idModulo);
        }

        public int ObtenerEstadoModulo(int idModulo, int idUsuario)
        {
            return oUsuarioDAL.ObtenerEstadoModulo(idModulo, idUsuario);
        }

        public List<UsuarioCapacitacion> ObtenerUsuariosCapacitados()
        {
            return oUsuarioDAL.ObtenerUsuariosCapacitados();
        }

        public int ObtenerUltimoModulo()
        {
            return oUsuarioDAL.ObtenerUltimoModulo();
        }

        public List<Persona> ObtenerDatosCertificado(int idUsuario)
        {
            return oUsuarioDAL.ObtenerDatosCertificado(idUsuario);
        }
    }
}
