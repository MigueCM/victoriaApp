using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class Foro:Persona
    {
        public int IdForo { get; set; }
        public int IdUsuario { get; set; }
        public string Titulo { get; set; }
        public string Contenido { get; set; }
        public int IdUsuarioRespuesta { get; set; }
        public string Respuesta { get; set; }
        public DateTime FechaPregunta { get; set; }
        public DateTime FechaRespuesta { get; set; }
        public int IdModulo { get; set; }
        public int Votado { get; set; }
        public int RptCantidad { get; set; }

        //public Persona Persona { get; set; }
    }
}
