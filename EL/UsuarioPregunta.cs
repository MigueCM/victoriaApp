using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class UsuarioPregunta
    {
        int idUsuarioPregunta;
        int idUsuarioCapacitacion;
        int idPreguntaCapacitacion;
        string respuesta;

        public int IdUsuarioPregunta { get => idUsuarioPregunta; set => idUsuarioPregunta = value; }
        public int IdUsuarioCapacitacion { get => idUsuarioCapacitacion; set => idUsuarioCapacitacion = value; }
        public int IdPreguntaCapacitacion { get => idPreguntaCapacitacion; set => idPreguntaCapacitacion = value; }
        public string Respuesta { get => respuesta; set => respuesta = value; }
    }
}
