﻿using EL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class WebinarNotificacionDAL
    {
        public bool RegistrarNotificacion(WebinarNotificacion webinar)
        {
            SqlConnection _conexion = new SqlConnection(Conexion.CadenaConexion);
            SqlCommand _comando = new SqlCommand("PA_WebinarNotificacion", _conexion) { CommandType = CommandType.StoredProcedure };
            _comando.Parameters.AddWithValue("@idUsuario", SqlDbType.VarChar).Value = webinar.IdUsuario;
            _comando.Parameters.AddWithValue("@idWebinar", SqlDbType.VarChar).Value = webinar.IdWebinar;
            _comando.Parameters.AddWithValue("@FechaRegistro", SqlDbType.DateTime).Value = DateTime.Now;
            _comando.Parameters.AddWithValue("@tipo", SqlDbType.Int).Value = 1;
            bool valor = false;
            try
            {
                if (_conexion.State == ConnectionState.Closed)
                    _conexion.Open();

                if (_comando.ExecuteNonQuery() > 0)
                    valor = true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _conexion.Close();
            }
            return valor;
        }

        public int ObtenerNotificacion(int idWebinar, int idUsuario)
        {

            SqlConnection _conexion = new SqlConnection(Conexion.CadenaConexion);
            SqlCommand _comando = new SqlCommand("PA_WebinarNotificacion", _conexion) { CommandType = CommandType.StoredProcedure };
            _comando.Parameters.AddWithValue("@idUsuario", SqlDbType.VarChar).Value = idUsuario;
            _comando.Parameters.AddWithValue("@idWebinar", SqlDbType.VarChar).Value = idWebinar;
            _comando.Parameters.AddWithValue("@tipo", SqlDbType.Int).Value = 2;
            int cantidad = 0;
            try
            {
                if (_conexion.State == ConnectionState.Closed)
                    _conexion.Open();

                SqlDataReader dr = _comando.ExecuteReader();
                if (dr.Read())
                {
                    cantidad = Convert.ToInt32(dr["notificacion"]);              

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _conexion.Close();
            }
            return cantidad;

        }


        public int ObtenerCntWebinarsNtf()
        {

            SqlConnection _conexion = new SqlConnection(Conexion.CadenaConexion);
            SqlCommand _comando = new SqlCommand("PA_Webinar", _conexion) { CommandType = CommandType.StoredProcedure };
            _comando.Parameters.AddWithValue("@tipo", SqlDbType.Int).Value = 6;
            int cantidad = 0;
            try
            {
                if (_conexion.State == ConnectionState.Closed)
                    _conexion.Open();

                SqlDataReader dr = _comando.ExecuteReader();
                if (dr.Read())
                {
                    cantidad = Convert.ToInt32(dr["Cantidad"]);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _conexion.Close();
            }
            return cantidad;

        }

        public List<Webinar> ObtenerNtfWebinarText()
        {
            SqlConnection _conexion = new SqlConnection(Conexion.CadenaConexion);
            SqlCommand _comando = new SqlCommand("PA_Webinar", _conexion) { CommandType = CommandType.StoredProcedure };
            _comando.Parameters.AddWithValue("@Tipo", SqlDbType.Int).Value = 7;
            List<Webinar> listaNoti = new List<Webinar>();
            try
            {
                if (_conexion.State == ConnectionState.Closed)
                    _conexion.Open();

                SqlDataReader dr = _comando.ExecuteReader();
                while (dr.Read())
                {
                    Webinar foro = new Webinar();
                    foro.IdWebinar = Convert.ToInt32(dr["Id"].ToString());
                    foro.Titulo = dr["Titulo"].ToString();
                    listaNoti.Add(foro);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _conexion.Close();
            }
            return listaNoti;
        }

        public bool MarcarLeidos(int idUsuario)
        {
            SqlConnection _conexion = new SqlConnection(Conexion.CadenaConexion);
            SqlCommand _comando = new SqlCommand("PA_Webinar", _conexion) { CommandType = CommandType.StoredProcedure };
            _comando.Parameters.AddWithValue("@IdUsuario", SqlDbType.Int).Value = idUsuario;
            _comando.Parameters.AddWithValue("@Tipo", SqlDbType.Int).Value = 10;
            bool exito = false;
            try
            {
                if (_conexion.State == ConnectionState.Closed)
                    _conexion.Open();

                if (_comando.ExecuteNonQuery() > 0)
                {
                    exito = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _conexion.Close();
            }
            return exito;
        }
    }
}
