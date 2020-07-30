using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class ModuloCapacitacion
    {
        int idModuloCapacitacion;
        string nombre;
        string descripcion;
        int nro;
        string autor;
        string enlace;
        string imagen;
        int idUsuarioRegistro;
        DateTime fechaRegistro;
        int estado;

        int completado;
        DateTime fechaActualizacion;

        public int IdModuloCapacitacion { get => idModuloCapacitacion; set => idModuloCapacitacion = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int Nro { get => nro; set => nro = value; }
        public string Autor { get => autor; set => autor = value; }
        public string Enlace { get => enlace; set => enlace = value; }
        public string Imagen { get => imagen; set => imagen = value; }
        public int IdUsuarioRegistro { get => idUsuarioRegistro; set => idUsuarioRegistro = value; }
        public DateTime FechaRegistro { get => fechaRegistro; set => fechaRegistro = value; }
        public int Estado { get => estado; set => estado = value; }
        public int Completado { get => completado; set => completado = value; }
        public DateTime FechaActualizacion { get => fechaActualizacion; set => fechaActualizacion = value; }
    }
}
