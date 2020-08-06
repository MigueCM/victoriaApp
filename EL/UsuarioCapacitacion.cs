using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class UsuarioCapacitacion
    {
        int idUsuarioCapacitacion;
        int idUsuario;
        int idModuloCapacitacion;
        DateTime fechaRegistro;
        DateTime fechaActualizacion;
        int completado;
        int iniciado;
        int nota;
        int aprobado;
        int calificacion;
        ModuloCapacitacion moduloCapacitacion;
        List<UsuarioPregunta> listaUsuarioPregunta;

        public int IdUsuarioCapacitacion { get => idUsuarioCapacitacion; set => idUsuarioCapacitacion = value; }
        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public int IdModuloCapacitacion { get => idModuloCapacitacion; set => idModuloCapacitacion = value; }
        public DateTime FechaRegistro { get => fechaRegistro; set => fechaRegistro = value; }
        public DateTime FechaActualizacion { get => fechaActualizacion; set => fechaActualizacion = value; }
        public int Completado { get => completado; set => completado = value; }
        public int Iniciado { get => iniciado; set => iniciado = value; }
        public int Nota { get => nota; set => nota = value; }
        public int Aprobado { get => aprobado; set => aprobado = value; }
        public ModuloCapacitacion ModuloCapacitacion { get => moduloCapacitacion; set => moduloCapacitacion = value; }
        public int Calificacion { get => calificacion; set => calificacion = value; }
        public List<UsuarioPregunta> ListaUsuarioPregunta { get => listaUsuarioPregunta; set => listaUsuarioPregunta = value; }
    }
}
