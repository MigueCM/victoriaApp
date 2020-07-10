using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class Usuario
    {
        private int idUsuario;
        private int idPerfil;
        private string user;
        private string password;
        private int idUsuarioRegistro;
        private DateTime fechaRegistro;

        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public int IdPerfil { get => idPerfil; set => idPerfil = value; }
        public string User { get => user; set => user = value; }
        public string Password { get => password; set => password = value; }
        public int IdUsuarioRegistro { get => idUsuarioRegistro; set => idUsuarioRegistro = value; }
        public DateTime FechaRegistro { get => fechaRegistro; set => fechaRegistro = value; }
    }
}
