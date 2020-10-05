using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class Usuario
    {
        Persona persona;
        Perfil perfil;
        int idPersona;
        private int idUsuario;
        private int idPerfil;
        private string user;
        private string password;
        private int idUsuarioRegistro;
        private DateTime fechaRegistro;
        private int idUsuarioEdicion;
        private DateTime fechaEdicion;
        private int porcentaje;

        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public int IdPerfil { get => idPerfil; set => idPerfil = value; }
        public string User { get => user; set => user = value; }
        public string Password { get => password; set => password = value; }
        public int IdUsuarioRegistro { get => idUsuarioRegistro; set => idUsuarioRegistro = value; }
        public DateTime FechaRegistro { get => fechaRegistro; set => fechaRegistro = value; }
        public Persona Persona { get => persona; set => persona = value; }
        public int IdPersona { get => idPersona; set => idPersona = value; }
        public int Porcentaje { get => porcentaje; set => porcentaje = value; }
        public Perfil Perfil { get => perfil; set => perfil = value; }
        public int IdUsuarioEdicion { get => idUsuarioEdicion; set => idUsuarioEdicion = value; }
        public DateTime FechaEdicion { get => fechaEdicion; set => fechaEdicion = value; }
        public string FechaSesion { get; set; }
    }
}
