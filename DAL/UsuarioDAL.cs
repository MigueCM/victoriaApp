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
    public class UsuarioDAL
    {
        public bool InsertarUsuario(int id, string usuario, string password)
        {

            SqlConnection _conexion = new SqlConnection(Conexion.CadenaConexion);
            SqlCommand _comando = new SqlCommand("PA_Usuario", _conexion) { CommandType = CommandType.StoredProcedure };
            _comando.Parameters.AddWithValue("@user", SqlDbType.VarChar).Value = usuario;
            _comando.Parameters.AddWithValue("@password", SqlDbType.VarChar).Value = password;
            _comando.Parameters.AddWithValue("@idUsuarioRegistro", SqlDbType.VarChar).Value = id;
            _comando.Parameters.AddWithValue("@idPersona", SqlDbType.Int).Value = id;
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

        public Usuario ObtenerUsuario(string usuario, string password) 
        {

            SqlConnection _conexion = new SqlConnection(Conexion.CadenaConexion);
            SqlCommand _comando = new SqlCommand("PA_Usuario", _conexion) { CommandType = CommandType.StoredProcedure };
            _comando.Parameters.AddWithValue("@user", SqlDbType.VarChar).Value = usuario;
            _comando.Parameters.AddWithValue("@password", SqlDbType.VarChar).Value = password;
            _comando.Parameters.AddWithValue("@tipo", SqlDbType.Int).Value = 4;
            Usuario oUsuario = null;
            try
            {
                if (_conexion.State == ConnectionState.Closed)
                    _conexion.Open();

                SqlDataReader dr = _comando.ExecuteReader();
                if (dr.Read())
                {
                    oUsuario = new Usuario();
                    oUsuario.IdUsuario = Convert.ToInt32(dr["idUsuario"]);
                    oUsuario.User = dr["user"].ToString();
                    if(dr["idPerfil"] != DBNull.Value)
                        oUsuario.IdPerfil = Convert.ToInt32(dr["idPerfil"]);
                    if (dr["idPersona"] != DBNull.Value)
                    {
                        oUsuario.IdPersona = Convert.ToInt32(dr["idPersona"]);
                        oUsuario.Persona = new Persona();
                        oUsuario.Persona.Id = Convert.ToInt32(dr["idPersona"]);
                        oUsuario.Persona.Nombre = dr["Nombre"].ToString();
                        oUsuario.Persona.Apellidos = dr["Apellidos"].ToString();
                    }

                        


                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                _conexion.Close();
            }
            return oUsuario;

        }

        public Usuario ValidarPorUsuario(string usuario)
        {

            SqlConnection _conexion = new SqlConnection(Conexion.CadenaConexion);
            SqlCommand _comando = new SqlCommand("PA_Usuario", _conexion) { CommandType = CommandType.StoredProcedure };
            _comando.Parameters.AddWithValue("@user", SqlDbType.VarChar).Value = usuario;
            _comando.Parameters.AddWithValue("@tipo", SqlDbType.Int).Value = 5;

            Usuario oUsuario = null;

            try
            {
                if (_conexion.State == ConnectionState.Closed)
                    _conexion.Open();

                SqlDataReader dr = _comando.ExecuteReader();
                if (dr.Read())
                {
                    oUsuario = new Usuario();
                    oUsuario.IdUsuario = Convert.ToInt32(dr["idUsuario"]);
                    oUsuario.User = dr["user"].ToString();
                    oUsuario.IdPerfil = Convert.ToInt32(dr["idPerfil"]);
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
            return oUsuario;

        }

        public Boolean ActualizarToken(String token, Int32 idUsuario)
        {
            SqlConnection _conexion = new SqlConnection(Conexion.CadenaConexion);
            SqlCommand _comando = new SqlCommand("PA_Usuario", _conexion) { CommandType = CommandType.StoredProcedure };
            _comando.Parameters.AddWithValue("@token", SqlDbType.VarChar).Value = token;
            _comando.Parameters.AddWithValue("@fechaToken", SqlDbType.DateTime).Value = DateTime.Now;
            _comando.Parameters.AddWithValue("@idUsuario", SqlDbType.VarChar).Value = idUsuario;
            _comando.Parameters.AddWithValue("@tipo", SqlDbType.Int).Value = 7;
            Boolean exito = false;
            try
            {
                if (_conexion.State == ConnectionState.Closed)
                {
                    _conexion.Open();
                    if (_comando.ExecuteNonQuery() > 0)
                    {
                        exito = true;
                    }
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                _conexion.Dispose();
                _conexion.Close();
            }
            return exito;
        }

        public Boolean ActualizarPassword(String password, Int32 idUsuario)
        {
            SqlConnection _conexion = new SqlConnection(Conexion.CadenaConexion);
            SqlCommand _comando = new SqlCommand("PA_Usuario", _conexion) { CommandType = CommandType.StoredProcedure };
            _comando.Parameters.AddWithValue("@password", SqlDbType.VarChar).Value = password;
            _comando.Parameters.AddWithValue("@idUsuario", SqlDbType.VarChar).Value = idUsuario;
            _comando.Parameters.AddWithValue("@tipo", SqlDbType.Int).Value = 9;
            Boolean exito = false;
            try
            {
                if (_conexion.State == ConnectionState.Closed)
                {
                    _conexion.Open();
                    if (_comando.ExecuteNonQuery() > 0)
                    {
                        exito = true;
                    }
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                _conexion.Dispose();
                _conexion.Close();
            }
            return exito;
        }

        public Usuario ValidarPorToken(string token)
        {

            SqlConnection _conexion = new SqlConnection(Conexion.CadenaConexion);
            SqlCommand _comando = new SqlCommand("PA_Usuario", _conexion) { CommandType = CommandType.StoredProcedure };
            _comando.Parameters.AddWithValue("@token", SqlDbType.VarChar).Value = token;
            _comando.Parameters.AddWithValue("@tipo", SqlDbType.Int).Value = 8;

            Usuario oUsuario = null;

            try
            {
                if (_conexion.State == ConnectionState.Closed)
                    _conexion.Open();

                SqlDataReader dr = _comando.ExecuteReader();
                if (dr.Read())
                {
                    oUsuario = new Usuario();
                    oUsuario.IdUsuario = Convert.ToInt32(dr["idUsuario"]);
                    oUsuario.User = dr["user"].ToString();
                    oUsuario.IdPerfil = Convert.ToInt32(dr["idPerfil"]);
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
            return oUsuario;

        }

    }
}
