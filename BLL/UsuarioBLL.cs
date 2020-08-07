using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using EL;

namespace BLL
{
    public class UsuarioBLL
    {
        #region Patron Singleton
        private static UsuarioBLL _instancia = null;

        public UsuarioBLL()
        {
        }

        public static UsuarioBLL Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new UsuarioBLL();
                }
                return _instancia;
            }
        }
        #endregion

        private static UsuarioDAL oUsuarioDAL = new UsuarioDAL();

        public Usuario ObtenerUsuario(string usuario, string password)
        {
            if ( usuario.Trim().Length > 0 && password.Trim().Length > 0)
            {
                return oUsuarioDAL.ObtenerUsuario(usuario, password);
            }
            else
            {

                return null;

            }
        }

        public Usuario ValidarPorUsuario(string usuario)
        {

            return oUsuarioDAL.ValidarPorUsuario(usuario);

        }

        public Boolean ActualizarToken(String token, Int32 idUsuario)
        {
            return oUsuarioDAL.ActualizarToken(token, idUsuario);
        }

        public Boolean ActualizarPassword(String password, Int32 idUsuario)
        {
            return oUsuarioDAL.ActualizarPassword(password, idUsuario);
        }

        public Usuario ValidarPorToken(string token)
        {
            return oUsuarioDAL.ValidarPorToken(token);
        }

        public int ValidarExisteUsuario(string correo)
        {
            return oUsuarioDAL.ValidarExisteUsuario(correo);
        }
    }
}
