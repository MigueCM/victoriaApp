using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class WebinarNotificacionBLL
    {

        #region Patron Singleton
        private static WebinarNotificacionBLL _instancia = null;

        public WebinarNotificacionBLL()
        {
        }

        public static WebinarNotificacionBLL Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new WebinarNotificacionBLL();
                }
                return _instancia;
            }
        }
        #endregion

        private static WebinarNotificacionDAL oWebinarDAL = new WebinarNotificacionDAL();

        public bool RegistrarNotificacion(WebinarNotificacion webinar)
        {
            return oWebinarDAL.RegistrarNotificacion(webinar);
        }

        public int ObtenerNotificacion(int idWebinar, int idUsuario)
        {
            return oWebinarDAL.ObtenerNotificacion(idWebinar, idUsuario);
        }

    }
}
