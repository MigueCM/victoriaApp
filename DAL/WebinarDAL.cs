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
    public class WebinarDAL
    {
        public List<Webinar> ObtenerWebinar()
        {

            SqlConnection _conexion = new SqlConnection(Conexion.CadenaConexion);
            SqlCommand _comando = new SqlCommand("PA_Webinar", _conexion) { CommandType = CommandType.StoredProcedure };
            _comando.Parameters.AddWithValue("@tipo", SqlDbType.Int).Value = 4;
            List<Webinar> lista = new List<Webinar>();
            try
            {
                if (_conexion.State == ConnectionState.Closed)
                    _conexion.Open();

                SqlDataReader dr = _comando.ExecuteReader();
                while (dr.Read())
                {
                    Webinar webinar = new Webinar();

                    webinar.IdWebinar = Convert.ToInt32(dr["id"]);
                    webinar.Titulo = dr["Titulo"].ToString();
                    webinar.Autor = dr["Autor"].ToString();
                    webinar.Imagen = dr["Imagen"].ToString();
                    webinar.Descripcion = dr["Descripcion"].ToString();

                    if(dr["FechaWebinar"] != DBNull.Value)
                        webinar.FechaWebinar = Convert.ToDateTime(dr["FechaWebinar"]);

                    webinar.HoraWebinar = dr["HoraWebinar"].ToString();
                    webinar.IdUsuarioRegistro = Convert.ToInt32(dr["IdUsuarioRegistro"]);
                    webinar.FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]);                  
                    
                    lista.Add(webinar);

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

        public Webinar ObtenerWebinarPorId(int id)
        {

            SqlConnection _conexion = new SqlConnection(Conexion.CadenaConexion);
            SqlCommand _comando = new SqlCommand("PA_Webinar", _conexion) { CommandType = CommandType.StoredProcedure };
            _comando.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;
            _comando.Parameters.AddWithValue("@tipo", SqlDbType.Int).Value = 5;
            Webinar webinar = null;
            try
            {
                if (_conexion.State == ConnectionState.Closed)
                    _conexion.Open();

                SqlDataReader dr = _comando.ExecuteReader();
                if (dr.Read())
                {
                    webinar = new Webinar();

                    webinar.IdWebinar = Convert.ToInt32(dr["id"]);
                    webinar.Titulo = dr["Titulo"].ToString();
                    webinar.Autor = dr["Autor"].ToString();
                    webinar.Imagen = dr["Imagen"].ToString();
                    webinar.Descripcion = dr["Descripcion"].ToString();
                    if (dr["FechaWebinar"] != DBNull.Value)
                        webinar.FechaWebinar = Convert.ToDateTime(dr["FechaWebinar"]);
                    webinar.HoraWebinar = dr["HoraWebinar"].ToString().Trim();
                    webinar.IdUsuarioRegistro = Convert.ToInt32(dr["IdUsuarioRegistro"]);
                    webinar.FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]);

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
            return webinar;

        }

        public bool RegistrarWebinar(Webinar objWebinar)
        {
            SqlConnection _conexion = new SqlConnection(Conexion.CadenaConexion);
            SqlCommand _comando = new SqlCommand("PA_Webinar", _conexion) { CommandType = CommandType.StoredProcedure };
            _comando.Parameters.AddWithValue("@titulo", SqlDbType.VarChar).Value = objWebinar.Titulo;
            _comando.Parameters.AddWithValue("@autor", SqlDbType.VarChar).Value = objWebinar.Autor;
            _comando.Parameters.AddWithValue("@imagen", SqlDbType.VarChar).Value = objWebinar.Imagen;
            _comando.Parameters.AddWithValue("@descripcion", SqlDbType.VarChar).Value = objWebinar.Descripcion;
            _comando.Parameters.AddWithValue("@FechaWebinar", SqlDbType.Date).Value = objWebinar.FechaWebinar;
            _comando.Parameters.AddWithValue("@HoraWebinar", SqlDbType.VarChar).Value = objWebinar.HoraWebinar;
            _comando.Parameters.AddWithValue("@FechaRegistro", SqlDbType.DateTime).Value = DateTime.Now;
            _comando.Parameters.AddWithValue("@IdUsuarioRegistro", SqlDbType.Int).Value = objWebinar.IdUsuarioRegistro;
            _comando.Parameters.AddWithValue("@tipo", SqlDbType.Int).Value = 1;
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

        public bool EditarWebinar(Webinar objWebinar)
        {
            SqlConnection _conexion = new SqlConnection(Conexion.CadenaConexion);
            SqlCommand _comando = new SqlCommand("PA_Webinar", _conexion) { CommandType = CommandType.StoredProcedure };
            _comando.Parameters.AddWithValue("@titulo", SqlDbType.VarChar).Value = objWebinar.Titulo;
            _comando.Parameters.AddWithValue("@autor", SqlDbType.VarChar).Value = objWebinar.Autor;
            _comando.Parameters.AddWithValue("@imagen", SqlDbType.VarChar).Value = objWebinar.Imagen;
            _comando.Parameters.AddWithValue("@descripcion", SqlDbType.VarChar).Value = objWebinar.Descripcion;
            _comando.Parameters.AddWithValue("@FechaWebinar", SqlDbType.Date).Value = objWebinar.FechaWebinar;
            _comando.Parameters.AddWithValue("@HoraWebinar", SqlDbType.VarChar).Value = objWebinar.HoraWebinar;
            _comando.Parameters.AddWithValue("@fechaEdicion", SqlDbType.DateTime).Value = DateTime.Now;
            _comando.Parameters.AddWithValue("@idUsuarioEdicion", SqlDbType.Int).Value = objWebinar.IdUsuarioEdicion;
            _comando.Parameters.AddWithValue("@id", SqlDbType.Int).Value = objWebinar.IdWebinar;
            _comando.Parameters.AddWithValue("@tipo", SqlDbType.Int).Value = 2;
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

        public bool EliminarWebinar(int idWebinar)
        {
            SqlConnection _conexion = new SqlConnection(Conexion.CadenaConexion);
            SqlCommand _comando = new SqlCommand("PA_Webinar", _conexion) { CommandType = CommandType.StoredProcedure };
            _comando.Parameters.AddWithValue("@id", SqlDbType.Int).Value = idWebinar;
            _comando.Parameters.AddWithValue("@tipo", SqlDbType.Int).Value = 3;
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

    }
}
