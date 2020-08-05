using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class PreguntaCapacitacion
    {
        private int idPreguntaCapacitacion;
        private int idModuloCapacitacion;
        private string descripcion;
        private int orden;
        private string alternativa1;
        private string alternativa2;
        private string alternativa3;
        private string alternativa4;
        private string alternativa5;
        private string respuesta;

        public int IdPreguntaCapacitacion { get => idPreguntaCapacitacion; set => idPreguntaCapacitacion = value; }
        public int IdModuloCapacitacion { get => idModuloCapacitacion; set => idModuloCapacitacion = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int Orden { get => orden; set => orden = value; }
        public string Alternativa1 { get => alternativa1; set => alternativa1 = value; }
        public string Alternativa2 { get => alternativa2; set => alternativa2 = value; }
        public string Alternativa3 { get => alternativa3; set => alternativa3 = value; }
        public string Alternativa4 { get => alternativa4; set => alternativa4 = value; }
        public string Alternativa5 { get => alternativa5; set => alternativa5 = value; }
        public string Respuesta { get => respuesta; set => respuesta = value; }
    }
}
