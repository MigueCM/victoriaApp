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
    public class ForoDAL
    {
        public bool RegistrarPregunta(Foro foro)
        {
            SqlConnection _conexion = new SqlConnection(Conexion.CadenaConexion);
            SqlCommand _comando = new SqlCommand("PA_Foro", _conexion) { CommandType = CommandType.StoredProcedure };
            _comando.Parameters.AddWithValue("@IdUsuario", SqlDbType.Int).Value = foro.IdUsuario;
            _comando.Parameters.AddWithValue("@Titulo", SqlDbType.VarChar).Value = foro.Titulo;
            _comando.Parameters.AddWithValue("@Contenido", SqlDbType.VarChar).Value = foro.Contenido;
            _comando.Parameters.AddWithValue("@IdModulo", SqlDbType.Int).Value = foro.IdModulo;
            _comando.Parameters.AddWithValue("@Votado", SqlDbType.Int).Value = 0;
            _comando.Parameters.AddWithValue("@Tipo", SqlDbType.Int).Value = 1;
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

        public List<Foro> ObtenerComentarios()
        {
            List<Foro> foros = new List<Foro>();
            SqlConnection _conexion = new SqlConnection(Conexion.CadenaConexion);
            SqlCommand _comando = new SqlCommand("PA_Foro", _conexion) { CommandType = CommandType.StoredProcedure };
            _comando.Parameters.AddWithValue("@Tipo", SqlDbType.Int).Value = 2;
            try
            {
                if (_conexion.State == ConnectionState.Closed)
                    _conexion.Open();

                SqlDataReader dr = _comando.ExecuteReader();
                while (dr.Read())
                {
                    Foro foro = new Foro();
                    foro.IdForo = Convert.ToInt32(dr["Id"].ToString());
                    foro.Titulo = dr["Titulo"].ToString();
                    foro.Contenido = dr["Contenido"].ToString();
                    foro.FechaPregunta = Convert.ToDateTime(dr["FechaPregunta"].ToString());
                    foro.Votado = Convert.ToInt32(dr["Votado"].ToString());
                    foro.Sexo = dr["Sexo"].ToString();
                    if (dr["Respuesta"] != DBNull.Value && dr["Respuesta"].ToString() != "")
                    {
                        foro.Respuesta = dr["Respuesta"].ToString();
                        foro.RptCantidad = 1;
                    }
                    else
                    {
                        foro.RptCantidad = 0;
                    }
                    foro.Nombre = dr["Nombre"].ToString();
                    foro.Apellidos = dr["Apellidos"].ToString();
                    foro.Avatar = dr["Avatar"].ToString();
                    foros.Add(foro);
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
            return foros;
        }

        public bool ActualizarVotado(Foro foro)
        {
            SqlConnection _conexion = new SqlConnection(Conexion.CadenaConexion);
            SqlCommand _comando = new SqlCommand("PA_Foro", _conexion) { CommandType = CommandType.StoredProcedure };
            _comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = foro.IdForo;
            _comando.Parameters.AddWithValue("@Votado", SqlDbType.Int).Value = foro.Votado;
            _comando.Parameters.AddWithValue("@Tipo", SqlDbType.Int).Value = 3;
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

        public int ObtenerCambioVotado(int id)
        {
            SqlConnection _conexion = new SqlConnection(Conexion.CadenaConexion);
            SqlCommand _comando = new SqlCommand("PA_Foro", _conexion) { CommandType = CommandType.StoredProcedure };
            _comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
            _comando.Parameters.AddWithValue("@Tipo", SqlDbType.Int).Value = 4;
            int valor = 0;
            try
            {
                if (_conexion.State == ConnectionState.Closed)
                    _conexion.Open();

                SqlDataReader dr = _comando.ExecuteReader();
                if (dr.Read())
                {
                    valor = Convert.ToInt32(dr["Votado"].ToString());
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

        public Foro ObtenerComentarioResponder(int id)
        {
            Foro foro = null;
            SqlConnection _conexion = new SqlConnection(Conexion.CadenaConexion);
            SqlCommand _comando = new SqlCommand("PA_Foro", _conexion) { CommandType = CommandType.StoredProcedure };
            _comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
            _comando.Parameters.AddWithValue("@Tipo", SqlDbType.Int).Value = 5;
            try
            {
                if (_conexion.State == ConnectionState.Closed)
                    _conexion.Open();

                SqlDataReader dr = _comando.ExecuteReader();
                if (dr.Read())
                {
                    foro = new Foro();
                    foro.IdForo = Convert.ToInt32(dr["Id"].ToString());
                    foro.Titulo = dr["Titulo"].ToString();
                    foro.Contenido = dr["Contenido"].ToString();
                    foro.Nombre = dr["Nombre"].ToString();
                    foro.Apellidos = dr["Apellidos"].ToString();
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
            return foro;
        }

        public bool ActualizarRespuesta(int id, int idUsuarioRespuesta, string respuesta)
        {
            SqlConnection _conexion = new SqlConnection(Conexion.CadenaConexion);
            SqlCommand _comando = new SqlCommand("PA_Foro", _conexion) { CommandType = CommandType.StoredProcedure };
            _comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
            _comando.Parameters.AddWithValue("@IdUsuarioRespuesta", SqlDbType.Int).Value = idUsuarioRespuesta;
            _comando.Parameters.AddWithValue("@Respuesta", SqlDbType.VarChar).Value = respuesta;
            _comando.Parameters.AddWithValue("@Tipo", SqlDbType.Int).Value = 6;
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

        public Foro ObtenerRespuesta(int id)
        {
            Foro foro = null;
            SqlConnection _conexion = new SqlConnection(Conexion.CadenaConexion);
            SqlCommand _comando = new SqlCommand("PA_Foro", _conexion) { CommandType = CommandType.StoredProcedure };
            _comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
            _comando.Parameters.AddWithValue("@Tipo", SqlDbType.Int).Value = 7;
            try
            {
                if (_conexion.State == ConnectionState.Closed)
                    _conexion.Open();

                SqlDataReader dr = _comando.ExecuteReader();
                if (dr.Read())
                {
                    foro = new Foro();
                    foro.IdForo = Convert.ToInt32(dr["Id"].ToString());
                    foro.Titulo = dr["Titulo"].ToString();
                    foro.Respuesta = dr["Respuesta"].ToString();
                    foro.FechaRespuesta = Convert.ToDateTime(dr["FechaRespuesta"].ToString());
                    foro.Nombre = dr["Nombre"].ToString();
                    foro.Apellidos = dr["Apellidos"].ToString();
                    foro.Avatar = dr["Avatar"].ToString();
                    foro.Sexo = dr["Sexo"].ToString();
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
            return foro;
        }
    }
}
