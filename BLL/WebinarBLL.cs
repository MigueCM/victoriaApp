using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class WebinarBLL
    {
        #region Patron Singleton
        private static WebinarBLL _instancia = null;

        public WebinarBLL()
        {
        }

        public static WebinarBLL Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new WebinarBLL();
                }
                return _instancia;
            }
        }
        #endregion

        private static WebinarDAL oWebinarDAL = new WebinarDAL();

        public List<Webinar> ObtenerWebinar()
        {
            return oWebinarDAL.ObtenerWebinar();
        }

        public Webinar ObtenerWebinarPorId(int id)
        {
            return oWebinarDAL.ObtenerWebinarPorId(id);
        }

        public bool RegistrarWebinar(Webinar objWebinar)
        {
            return oWebinarDAL.RegistrarWebinar(objWebinar);
        }

        public bool EditarWebinar(Webinar objWebinar)
        {
            return oWebinarDAL.EditarWebinar(objWebinar);
        }

        public bool EliminarWebinar(int idWebinar)
        {
            return oWebinarDAL.EliminarWebinar(idWebinar);
        }

        public List<string> ObtenerCorreos()
        {
            return oWebinarDAL.ObtenerCorreos();
        }
    }
}
