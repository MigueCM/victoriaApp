using DAL;
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
    }
}
