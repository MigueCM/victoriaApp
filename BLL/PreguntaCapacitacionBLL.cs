using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PreguntaCapacitacionBLL
    {
        #region Patron Singleton
        private static PreguntaCapacitacionBLL _instancia = null;

        public PreguntaCapacitacionBLL()
        {
        }

        public static PreguntaCapacitacionBLL Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new PreguntaCapacitacionBLL();
                }
                return _instancia;
            }
        }
        #endregion

        private static PreguntaCapacitacionDAL oModuloDAL = new PreguntaCapacitacionDAL();

        public List<PreguntaCapacitacion> ObtenerPreguntas(int idModulo)
        {
            return oModuloDAL.ObtenerPreguntas(idModulo);
        }

        public PreguntaCapacitacion ObtenerPreguntasPorId(int idPregunta)
        {
            return oModuloDAL.ObtenerPreguntasPorId(idPregunta);
        }

        public int ObtenerUltimoNumero(int idModulo)
        {
            return oModuloDAL.ObtenerUltimoNumero(idModulo);
        }

        public bool RegistrarPregunta(PreguntaCapacitacion preguntaCapacitacion)
        {
            return oModuloDAL.RegistrarPregunta(preguntaCapacitacion);
        }
        public bool EditarPregunta(PreguntaCapacitacion preguntaCapacitacion)
        {
            return oModuloDAL.EditarPregunta(preguntaCapacitacion);
        }

    }
}
