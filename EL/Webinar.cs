using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class Webinar
    {
        int idWebinar;
        string titulo;
        string autor;
        string imagen;
        string descripcion;
        int idUsuarioRegistro;
        DateTime fechaRegistro;
        int idUsuarioEdicion;
        DateTime fechaEdicion;

        public int IdWebinar { get => idWebinar; set => idWebinar = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public string Autor { get => autor; set => autor = value; }
        public string Imagen { get => imagen; set => imagen = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int IdUsuarioRegistro { get => idUsuarioRegistro; set => idUsuarioRegistro = value; }
        public DateTime FechaRegistro { get => fechaRegistro; set => fechaRegistro = value; }
        public int IdUsuarioEdicion { get => idUsuarioEdicion; set => idUsuarioEdicion = value; }
        public DateTime FechaEdicion { get => fechaEdicion; set => fechaEdicion = value; }
    }
}
