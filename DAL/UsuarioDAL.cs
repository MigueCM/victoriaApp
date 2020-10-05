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
        public bool InsertarUsuario(Usuario usuario)
        {

            SqlConnection _conexion = new SqlConnection(Conexion.CadenaConexion);
            SqlCommand _comando = new SqlCommand("PA_Usuario", _conexion) { CommandType = CommandType.StoredProcedure };
            _comando.Parameters.AddWithValue("@user", SqlDbType.VarChar).Value = usuario.User;
            _comando.Parameters.AddWithValue("@password", SqlDbType.VarChar).Value = usuario.Password;
            _comando.Parameters.AddWithValue("@idUsuarioRegistro", SqlDbType.VarChar).Value = usuario.IdUsuarioRegistro;
            _comando.Parameters.AddWithValue("@idPersona", SqlDbType.Int).Value = usuario.IdPersona;
            _comando.Parameters.AddWithValue("@idPerfil", SqlDbType.Int).Value = usuario.IdPerfil;
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

        public bool ActualizarUsuario(Usuario usuario)
        {

            SqlConnection _conexion = new SqlConnection(Conexion.CadenaConexion);
            SqlCommand _comando = new SqlCommand("PA_Usuario", _conexion) { CommandType = CommandType.StoredProcedure };
            _comando.Parameters.AddWithValue("@idPerfil", SqlDbType.Int).Value = usuario.IdPerfil;
            _comando.Parameters.AddWithValue("@IdUsuarioEdicion", SqlDbType.VarChar).Value = usuario.IdUsuarioEdicion;
            _comando.Parameters.AddWithValue("@idUsuario", SqlDbType.VarChar).Value = usuario.IdUsuario;
            _comando.Parameters.AddWithValue("@fechaEdicion", SqlDbType.VarChar).Value = DateTime.Now;
            _comando.Parameters.AddWithValue("@tipo", SqlDbType.Int).Value = 2;
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

        public bool EliminarUsuario(int idUsuario)
        {
            SqlConnection _conexion = new SqlConnection(Conexion.CadenaConexion);
            SqlCommand _comando = new SqlCommand("PA_Usuario", _conexion) { CommandType = CommandType.StoredProcedure };
            _comando.Parameters.AddWithValue("@idUsuario", SqlDbType.Int).Value = idUsuario;
            _comando.Parameters.AddWithValue("@tipo", SqlDbType.Int).Value = 13;
            bool valor = false;
            try
            {
                if (_conexion.State == ConnectionState.Closed)
                    _conexion.Open();
                _comando.ExecuteNonQuery();
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
                        oUsuario.Persona.Avatar = dr["Avatar"].ToString();
                        oUsuario.Persona.Dni = dr["Dni"].ToString();
                        oUsuario.Persona.Departamento = dr["Departamento"].ToString();
                        oUsuario.Persona.Ciudad = dr["Distrito"].ToString();
                        oUsuario.Persona.Sexo = dr["Sexo"].ToString();
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

        public int ValidarExisteUsuario(string correo)
        {
            SqlConnection _conexion = new SqlConnection(Conexion.CadenaConexion);
            SqlCommand _comando = new SqlCommand("PA_Usuario", _conexion) { CommandType = CommandType.StoredProcedure };
            _comando.Parameters.AddWithValue("@user", SqlDbType.VarChar).Value = correo;
            _comando.Parameters.AddWithValue("@tipo", SqlDbType.Int).Value = 10;

            int existe = 0;

            try
            {
                if (_conexion.State == ConnectionState.Closed)
                    _conexion.Open();

                SqlDataReader dr = _comando.ExecuteReader();
                if (dr.Read())
                {
                    existe = Convert.ToInt32(dr["Existe"].ToString());
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
            return existe;

        }

        public List<Usuario> ObtenerUsuarios()
        {

            SqlConnection _conexion = new SqlConnection(Conexion.CadenaConexion);
            SqlCommand _comando = new SqlCommand("PA_Usuario", _conexion) { CommandType = CommandType.StoredProcedure };
            _comando.Parameters.AddWithValue("@tipo", SqlDbType.Int).Value = 11;
            List<Usuario> lista = new List<Usuario>();
            try
            {
                if (_conexion.State == ConnectionState.Closed)
                    _conexion.Open();

                SqlDataReader dr = _comando.ExecuteReader();
                while (dr.Read())
                {
                    Usuario objUsuario = new Usuario();

                    objUsuario.IdUsuario = Convert.ToInt32(dr["idUsuario"]);
                    objUsuario.User = dr["User"].ToString();
                    
                    objUsuario.Perfil = new Perfil();
                    objUsuario.Perfil.IdPerfil = Convert.ToInt32(dr["idPerfil"]);
                    objUsuario.Perfil.Nombre = dr["perfil"].ToString();

                    objUsuario.Persona = new Persona();
                    objUsuario.Persona.Id = Convert.ToInt32(dr["idPersona"]);
                    objUsuario.Persona.Nombre = dr["Nombre"].ToString();
                    objUsuario.Persona.Apellidos = dr["Apellidos"].ToString();

                    lista.Add(objUsuario);

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
            return lista;

        }

        public List<Usuario> ObtenerUsuariosExcel()
        {

            SqlConnection _conexion = new SqlConnection(Conexion.CadenaConexion);
            SqlCommand _comando = new SqlCommand("PA_Usuario", _conexion) { CommandType = CommandType.StoredProcedure };
            _comando.Parameters.AddWithValue("@tipo", SqlDbType.Int).Value = 19;
            List<Usuario> lista = new List<Usuario>();
            try
            {
                if (_conexion.State == ConnectionState.Closed)
                    _conexion.Open();

                SqlDataReader dr = _comando.ExecuteReader();
                while (dr.Read())
                {
                    Usuario objUsuario = new Usuario();

                    
                    objUsuario.User = dr["User"].ToString();
                    objUsuario.Porcentaje = Convert.ToInt32(dr["porcentaje"]);
                    objUsuario.FechaRegistro = Convert.ToDateTime(dr["fechaRegistro"]);
                    objUsuario.FechaSesion = dr["FechaSesion"].ToString();

                    objUsuario.Persona = new Persona();
                    objUsuario.Persona.Nombre = dr["Nombre"].ToString();
                    objUsuario.Persona.Apellidos = dr["Apellidos"].ToString();
                    objUsuario.Persona.Dni = dr["Dni"].ToString();
                    objUsuario.Persona.Celular = dr["Celular"].ToString();
                    objUsuario.Persona.Ciudad = dr["Distrito"].ToString();
                    objUsuario.Persona.Departamento = dr["Departamento"].ToString();
                    objUsuario.Persona.Sexo = dr["Sexo"].ToString();
                    objUsuario.Persona.Enterar = dr["Enteraste"].ToString();
                    

                    lista.Add(objUsuario);

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
            return lista;

        }

        public Usuario ObtenerUsuarioPorId(int idUsuario)
        {
            SqlConnection _conexion = new SqlConnection(Conexion.CadenaConexion);
            SqlCommand _comando = new SqlCommand("PA_Usuario", _conexion) { CommandType = CommandType.StoredProcedure };
            _comando.Parameters.AddWithValue("@idUsuario", SqlDbType.Int).Value = idUsuario;
            _comando.Parameters.AddWithValue("@tipo", SqlDbType.Int).Value = 12;
            Usuario objUsuario = null;
            try
            {
                if (_conexion.State == ConnectionState.Closed)
                    _conexion.Open();

                SqlDataReader dr = _comando.ExecuteReader();
                while (dr.Read())
                {
                    objUsuario = new Usuario();

                    objUsuario.IdUsuario = Convert.ToInt32(dr["idUsuario"]);
                    objUsuario.User = dr["User"].ToString();
                    objUsuario.IdPerfil = Convert.ToInt32(dr["idPerfil"]);
                    objUsuario.IdPersona = Convert.ToInt32(dr["idPersona"]);

                    objUsuario.Persona = new Persona();
                    objUsuario.Persona.Id = Convert.ToInt32(dr["idPersona"]);
                    objUsuario.Persona.Nombre = dr["Nombre"].ToString();
                    objUsuario.Persona.Apellidos = dr["Apellidos"].ToString();
                    objUsuario.Persona.Dni = dr["Dni"].ToString();
                    objUsuario.Persona.FechaNacimiento = Convert.ToDateTime(dr["FechaNacimiento"]);
                    objUsuario.Persona.Sexo = dr["Sexo"].ToString();


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
            return objUsuario;
        }

        public List<Usuario> ObtenerUsuarioAvance()
        {
            SqlConnection _conexion = new SqlConnection(Conexion.CadenaConexion);
            SqlCommand _comando = new SqlCommand("PA_Usuario", _conexion) { CommandType = CommandType.StoredProcedure };
            _comando.Parameters.AddWithValue("@tipo", SqlDbType.Int).Value = 15;
            List<Usuario> lista = new List<Usuario>();
            try
            {
                if (_conexion.State == ConnectionState.Closed)
                    _conexion.Open();

                SqlDataReader dr = _comando.ExecuteReader();
                while (dr.Read())
                {
                    Usuario objUsuario = new Usuario();

                    objUsuario.IdUsuario = Convert.ToInt32(dr["idUsuario"]);
                    objUsuario.User = dr["nombreUsuario"].ToString();
                    objUsuario.Porcentaje = Convert.ToInt32(dr["porcentaje"]);

                    objUsuario.Persona = new Persona();
                    objUsuario.Persona.Id = Convert.ToInt32(dr["IdPersona"]);
                    objUsuario.Persona.Nombre = dr["Nombre"].ToString();
                    objUsuario.Persona.Apellidos = dr["Apellidos"].ToString();
                    objUsuario.FechaRegistro = Convert.ToDateTime(dr["FechaRegUsu"].ToString());
                    if (dr["FechaSesion"] != DBNull.Value)
                        objUsuario.FechaSesion = Convert.ToDateTime(dr["FechaSesion"].ToString()).ToString("dd/MM/yyyy HH:mm");
                    else
                        objUsuario.FechaSesion = "No ha iniciado sesión";
                    lista.Add(objUsuario);

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
            return lista;
        }

        public List<UsuarioCapacitacion> ObtenerUsuarioYModulo()
        {
            SqlConnection _conexion = new SqlConnection(Conexion.CadenaConexion);
            SqlCommand _comando = new SqlCommand("PA_Usuario", _conexion) { CommandType = CommandType.StoredProcedure };
            _comando.Parameters.AddWithValue("@tipo", SqlDbType.Int).Value = 18;
            List<UsuarioCapacitacion> lista = new List<UsuarioCapacitacion>();
            try
            {
                if (_conexion.State == ConnectionState.Closed)
                    _conexion.Open();

                SqlDataReader dr = _comando.ExecuteReader();
                while (dr.Read())
                {
                    UsuarioCapacitacion objUsuario = new UsuarioCapacitacion();
                    objUsuario.IdUsuario = Convert.ToInt32(dr["idUsuario"]);
                    objUsuario.Nombre = dr["Nombre"].ToString()+" "+ dr["Apellidos"].ToString();
                    objUsuario.ModuloCapacitacion = new ModuloCapacitacion();
                    objUsuario.ModuloCapacitacion.Nombre = dr["NombreMod"].ToString();
                    objUsuario.Nota = Convert.ToInt32(dr["Nota"]);
                    objUsuario.Calificacion = Convert.ToInt32(dr["Calificacion"]);
                    lista.Add(objUsuario);
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
            return lista;
        }

        public int ObtenerEstadoMsjBienvenida(int idUsuario)
        {
            SqlConnection _conexion = new SqlConnection(Conexion.CadenaConexion);
            SqlCommand _comando = new SqlCommand("PA_Usuario", _conexion) { CommandType = CommandType.StoredProcedure };
            _comando.Parameters.AddWithValue("@idUsuario", SqlDbType.Int).Value = idUsuario;
            _comando.Parameters.AddWithValue("@tipo", SqlDbType.Int).Value = 16;
            int estado = 0;
            try
            {
                if (_conexion.State == ConnectionState.Closed)
                    _conexion.Open();

                SqlDataReader dr = _comando.ExecuteReader();
                if (dr.Read())
                {
                    if(dr["Bienvenida"] != DBNull.Value)
                        estado = Convert.ToInt32(dr["Bienvenida"].ToString());
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
            return estado;
        }

        public void ActualizarEstadoMsjBienvenida(int idUsuario)
        {
            SqlConnection _conexion = new SqlConnection(Conexion.CadenaConexion);
            SqlCommand _comando = new SqlCommand("PA_Usuario", _conexion) { CommandType = CommandType.StoredProcedure };
            _comando.Parameters.AddWithValue("@idUsuario", SqlDbType.Int).Value = idUsuario;
            _comando.Parameters.AddWithValue("@tipo", SqlDbType.Int).Value = 17;
            try
            {
                if (_conexion.State == ConnectionState.Closed)
                    _conexion.Open();

                _comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _conexion.Close();
            }
        }
    }
}
