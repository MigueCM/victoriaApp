using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PersonaBLL
    {
        #region Patron Singleton
        private static PersonaBLL _instancia = null;

        public PersonaBLL()
        {
        }

        public static PersonaBLL Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new PersonaBLL();
                }
                return _instancia;
            }
        }
        #endregion

        private static PersonaDAL oPersonaDAL = new PersonaDAL();

        public int RegistrarPersona(Persona persona)
        {
            return oPersonaDAL.RegistrarPersona(persona);
        }

        public bool ActualizarPersona(Persona persona)
        {
            return oPersonaDAL.ActualizarPersona(persona);
        }

        public bool ActualizarAvatar(string archivo, int id)
        {
            return oPersonaDAL.ActualizarAvatar(archivo, id);
        }

        public string ObtenerAvatar(int id)
        {
            return oPersonaDAL.ObtenerAvatar(id);
        }
    }
}
