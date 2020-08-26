﻿using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ForoBLL
    {
        #region Patron Singleton
        private static ForoBLL _instancia = null;

        public ForoBLL()
        {
        }

        public static ForoBLL Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new ForoBLL();
                }
                return _instancia;
            }
        }
        #endregion

        ForoDAL foroDAL = new ForoDAL();

        public bool RegistrarPregunta(Foro foro)
        {
            return foroDAL.RegistrarPregunta(foro);
        }

        public List<Foro> ObtenerComentariosUsuario(int idUsuario)
        {
            return foroDAL.ObtenerComentariosUsuario(idUsuario);
        }

        public bool ActualizarVotado(Foro foro)
        {
            return foroDAL.ActualizarVotado(foro);
        }

        public int ObtenerCambioVotado(int id)
        {
            return foroDAL.ObtenerCambioVotado(id);
        }

        public Foro ObtenerComentarioResponder(int id)
        {
            return foroDAL.ObtenerComentarioResponder(id);
        }

        public bool ActualizarRespuesta(int id, int idUsuarioRespuesta,  string respuesta)
        {
            return foroDAL.ActualizarRespuesta(id, idUsuarioRespuesta, respuesta);
        }

        public Foro ObtenerRespuesta(int id)
        {
            return foroDAL.ObtenerRespuesta(id);
        }

        public int ObtenerCntNotificaciones(int id)
        {
            return foroDAL.ObtenerCntNotificaciones(id);
        }

        public List<Foro> ObtenerNotificaciones(int id)
        {
            return foroDAL.ObtenerNotificaciones(id);
        }

        public bool MarcarLeidos(int idUsuario)
        {
            return foroDAL.MarcarLeidos(idUsuario);
        }

        public List<Foro> ObtenerComentarios()
        {
            return foroDAL.ObtenerComentarios();
        }
        public int ObtenerCntNotificacionesAdmin()
        {
            return foroDAL.ObtenerCntNotificacionesAdmin();
        }

        public List<Foro> ObtenerNotificacionesAdmin()
        {
            return foroDAL.ObtenerNotificacionesAdmin();
        }

        public bool MarcarLeidosAdmin()
        {
            return foroDAL.MarcarLeidosAdmin();
        }

        public bool EliminarPregunta(int id)
        {
            return foroDAL.EliminarPregunta(id);
        }
    }
}
