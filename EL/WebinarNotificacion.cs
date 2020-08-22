using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class WebinarNotificacion
    {
        int idNotificacion;
        int idUsuario;
        int idWebinar;
        DateTime fechaRegistro;

        public int IdNotificacion { get => idNotificacion; set => idNotificacion = value; }
        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public int IdWebinar { get => idWebinar; set => idWebinar = value; }
        public DateTime FechaRegistro { get => fechaRegistro; set => fechaRegistro = value; }
    }
}
