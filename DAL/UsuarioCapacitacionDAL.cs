using EL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UsuarioCapacitacionDAL
    {
        UsuarioPreguntaDAL usuarioDAL = new UsuarioPreguntaDAL();
        public int ObtenerPorcentajeModulos(int idUsuario)
        {

            SqlConnection _conexion = new SqlConnection(Conexion.CadenaConexion);
            SqlCommand _comando = new SqlCommand("PA_UsuarioCapacitacion", _conexion) { CommandType = CommandType.StoredProcedure };
            _comando.Parameters.AddWithValue("@idUsuario", SqlDbType.Int).Value = idUsuario;
            _comando.Parameters.AddWithValue("@tipo", SqlDbType.Int).Value = 4;
            int porcentaje = 0;
            try
            {
                if (_conexion.State == ConnectionState.Closed)
                    _conexion.Open();

                SqlDataReader dr = _comando.ExecuteReader();
                if (dr.Read())
                {

                    porcentaje = Convert.ToInt32(dr["por_avance"]);

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
            return porcentaje;

        }
    
        public int ObtenerModuloDesbloqueado(int idUsuario)
        {
            SqlConnection _conexion = new SqlConnection(Conexion.CadenaConexion);
            SqlCommand _comando = new SqlCommand("PA_UsuarioCapacitacion", _conexion) { CommandType = CommandType.StoredProcedure };
            _comando.Parameters.AddWithValue("@idUsuario", SqlDbType.Int).Value = idUsuario;
            _comando.Parameters.AddWithValue("@tipo", SqlDbType.Int).Value = 5;
            int modulo = 0;
            try
            {
                if (_conexion.State == ConnectionState.Closed)
                    _conexion.Open();

                SqlDataReader dr = _comando.ExecuteReader();
                if (dr.Read())
                {

                    modulo = Convert.ToInt32(dr["modulo"]) + 1;

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
            return modulo;
        }

        public bool RegistrarCapacitacion(UsuarioCapacitacion usuarioCapacitacion)
        {
            SqlConnection _conexion = new SqlConnection(Conexion.CadenaConexion);
            SqlCommand _comando = new SqlCommand("PA_UsuarioCapacitacion", _conexion) { CommandType = CommandType.StoredProcedure };
            _comando.Parameters.AddWithValue("@idUsuario", SqlDbType.VarChar).Value = usuarioCapacitacion.IdUsuario;
            _comando.Parameters.AddWithValue("@idModuloCapacitacion", SqlDbType.VarChar).Value = usuarioCapacitacion.IdModuloCapacitacion;
            _comando.Parameters.AddWithValue("@FechaRegistro", SqlDbType.DateTime).Value = DateTime.Now;
            _comando.Parameters.AddWithValue("@fechaActualizacion", SqlDbType.DateTime).Value = DateTime.Now;
            _comando.Parameters.AddWithValue("@completado", SqlDbType.Bit).Value = 1;
            _comando.Parameters.AddWithValue("@iniciado", SqlDbType.Bit).Value = 1;
            _comando.Parameters.AddWithValue("@aprobado", SqlDbType.Bit).Value = usuarioCapacitacion.Aprobado;
            _comando.Parameters.AddWithValue("@calificacion", SqlDbType.Int).Value = usuarioCapacitacion.Calificacion;
            _comando.Parameters.AddWithValue("@nota", SqlDbType.Int).Value = usuarioCapacitacion.Nota;
            _comando.Parameters.AddWithValue("@tipo", SqlDbType.Int).Value = 1;
            bool valor = false;
            int id = 0;
            try
            {
                if (_conexion.State == ConnectionState.Closed)
                    _conexion.Open();
                SqlDataReader dr = _comando.ExecuteReader();
                if (dr.Read())
                {
                    valor = true;
                    id = Convert.ToInt32(dr["ID"]);
                }

                foreach (UsuarioPregunta item in usuarioCapacitacion.ListaUsuarioPregunta)
                {
                    item.IdUsuarioCapacitacion = id;
                    if (!usuarioDAL.InsertarUsuarioPregunta(item))
                        valor = false;
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
            return valor;
        }

        public int ObtenerCalificacion(int idModulo)
        {
            SqlConnection _conexion = new SqlConnection(Conexion.CadenaConexion);
            SqlCommand _comando = new SqlCommand("PA_UsuarioCapacitacion", _conexion) { CommandType = CommandType.StoredProcedure };
            _comando.Parameters.AddWithValue("@idModuloCapacitacion", SqlDbType.Int).Value = idModulo;
            _comando.Parameters.AddWithValue("@tipo", SqlDbType.Int).Value = 6;
            int calificacion = 0;
            try
            {
                if (_conexion.State == ConnectionState.Closed)
                    _conexion.Open();

                SqlDataReader dr = _comando.ExecuteReader();
                if (dr.Read())
                {

                    calificacion = Convert.ToInt32(dr["calificacion"]);

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
            return calificacion;
        }

        public int ObtenerIntento(int idModulo , int idUsuario)
        {
            SqlConnection _conexion = new SqlConnection(Conexion.CadenaConexion);
            SqlCommand _comando = new SqlCommand("PA_UsuarioCapacitacion", _conexion) { CommandType = CommandType.StoredProcedure };
            _comando.Parameters.AddWithValue("@idUsuario", SqlDbType.Int).Value = idUsuario;
            _comando.Parameters.AddWithValue("@idModuloCapacitacion", SqlDbType.Int).Value = idModulo;
            _comando.Parameters.AddWithValue("@tipo", SqlDbType.Int).Value = 7;
            int intento = 0;
            try
            {
                if (_conexion.State == ConnectionState.Closed)
                    _conexion.Open();

                SqlDataReader dr = _comando.ExecuteReader();
                if (dr.Read())
                {

                    intento = Convert.ToInt32(dr["intentos"]);

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
            return intento;
        }

        public int ObtenerEstadoModulo(int idModulo, int idUsuario)
        {
            SqlConnection _conexion = new SqlConnection(Conexion.CadenaConexion);
            SqlCommand _comando = new SqlCommand("PA_UsuarioCapacitacion", _conexion) { CommandType = CommandType.StoredProcedure };
            _comando.Parameters.AddWithValue("@idUsuario", SqlDbType.Int).Value = idUsuario;
            _comando.Parameters.AddWithValue("@idModuloCapacitacion", SqlDbType.Int).Value = idModulo;
            _comando.Parameters.AddWithValue("@tipo", SqlDbType.Int).Value = 9;
            int aprobado = 0;
            try
            {
                if (_conexion.State == ConnectionState.Closed)
                    _conexion.Open();

                SqlDataReader dr = _comando.ExecuteReader();
                if (dr.Read())
                {

                    aprobado = Convert.ToInt32(dr["aprobado"]);

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
            return aprobado;
        }

        public int ObtenerVisualizacion(int idModulo)
        {
            SqlConnection _conexion = new SqlConnection(Conexion.CadenaConexion);
            SqlCommand _comando = new SqlCommand("PA_UsuarioCapacitacion", _conexion) { CommandType = CommandType.StoredProcedure };
            _comando.Parameters.AddWithValue("@idModuloCapacitacion", SqlDbType.Int).Value = idModulo;
            _comando.Parameters.AddWithValue("@tipo", SqlDbType.Int).Value = 8;
            int visualizaciones = 0;
            try
            {
                if (_conexion.State == ConnectionState.Closed)
                    _conexion.Open();

                SqlDataReader dr = _comando.ExecuteReader();
                if (dr.Read())
                {

                    visualizaciones = Convert.ToInt32(dr["visualizacion"]);

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
            return visualizaciones;
        }

    }
}
