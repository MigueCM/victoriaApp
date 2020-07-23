using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class UsuarioHistorial
    {
        private int idHistorial;
        private int idUsuario;
        private DateTime fechaSesion;

        public int IdHistorial { get => idHistorial; set => idHistorial = value; }
        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public DateTime FechaSesion { get => fechaSesion; set => fechaSesion = value; }
    }
}
