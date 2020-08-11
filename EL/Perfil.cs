using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class Perfil
    {
        int idPerfil;
        string nombre;
        string descripcion;
        string estado;
        DateTime fechaCreacion;
        DateTime fechaMovimiento;

        public int IdPerfil { get => idPerfil; set => idPerfil = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Estado { get => estado; set => estado = value; }
        public DateTime FechaCreacion { get => fechaCreacion; set => fechaCreacion = value; }
        public DateTime FechaMovimiento { get => fechaMovimiento; set => fechaMovimiento = value; }
    }
}
