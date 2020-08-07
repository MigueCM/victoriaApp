using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TerminosCondicionesBLL
    {
        #region Patron Singleton
        private static TerminosCondicionesBLL _instancia = null;

        public TerminosCondicionesBLL()
        {
        }

        public static TerminosCondicionesBLL Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new TerminosCondicionesBLL();
                }
                return _instancia;
            }
        }
        #endregion

        TerminosCondicionesDAL terminosCondicionesDAL = new TerminosCondicionesDAL();
        public List<string> RegistrarTerminos(string titulo, string descripcion, string usuario)
        {
            List<string> errores = new List<string>();
            TerminosCondicionesEL terminos = new TerminosCondicionesEL();
            if (!string.IsNullOrEmpty(titulo) && !string.IsNullOrWhiteSpace(titulo))
                terminos.Titulo = titulo;
            else
                errores.Add("El título es un campo requerido");
            if (!string.IsNullOrEmpty(descripcion) && !string.IsNullOrWhiteSpace(descripcion))
                terminos.Descripcion = descripcion;
            else
                errores.Add("La descripción es un campo requerido");

            terminos.Usuario = usuario;

            if (errores.Count > 0)
            {
                return errores;
            }
            else
            {
                terminosCondicionesDAL.RegistrarTerminos(terminos);
                return errores;
            }
        }

        public TerminosCondicionesEL ObtenerTerminos()
        {
            return terminosCondicionesDAL.ObtenerTerminos();
        }
    }
}
