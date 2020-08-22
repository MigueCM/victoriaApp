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
    public class ModuloCapacitacionDAL
    {
        public List<ModuloCapacitacion> ObtenerModulos(int idUsuario)
        {

            SqlConnection _conexion = new SqlConnection(Conexion.CadenaConexion);
            SqlCommand _comando = new SqlCommand("PA_ModuloCapacitacion", _conexion) { CommandType = CommandType.StoredProcedure };
            _comando.Parameters.AddWithValue("@idUsuario", SqlDbType.Int).Value = idUsuario;
            _comando.Parameters.AddWithValue("@tipo", SqlDbType.Int).Value = 10;
            List<ModuloCapacitacion> lista = new List<ModuloCapacitacion>();
            try
            {
                if (_conexion.State == ConnectionState.Closed)
                    _conexion.Open();

                SqlDataReader dr = _comando.ExecuteReader();
                while (dr.Read())
                {
                    ModuloCapacitacion modulo = new ModuloCapacitacion();

                    modulo.IdModuloCapacitacion = Convert.ToInt32(dr["idModuloCapacitacion"]);
                    modulo.Nombre = dr["Nombre"].ToString();
                    lista.Add(modulo);
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
        public List<ModuloCapacitacion> ObtenerModulosPorUsuario(int idUsuario)
        {

            SqlConnection _conexion = new SqlConnection(Conexion.CadenaConexion);
            SqlCommand _comando = new SqlCommand("PA_ModuloCapacitacion", _conexion) { CommandType = CommandType.StoredProcedure };
            _comando.Parameters.AddWithValue("@idUsuario", SqlDbType.Int).Value = idUsuario;
            _comando.Parameters.AddWithValue("@tipo", SqlDbType.Int).Value = 4;
            List<ModuloCapacitacion> lista = new List<ModuloCapacitacion>();
            try
            {
                if (_conexion.State == ConnectionState.Closed)
                    _conexion.Open();

                SqlDataReader dr = _comando.ExecuteReader();
                while (dr.Read())
                {
                    ModuloCapacitacion modulo = new ModuloCapacitacion();
                    
                    modulo.IdModuloCapacitacion = Convert.ToInt32(dr["idModuloCapacitacion"]);
                    modulo.Nombre = dr["Nombre"].ToString();
                    modulo.Descripcion = dr["Descripcion"].ToString();
                    modulo.Nro = Convert.ToInt32(dr["Nro"]);
                    modulo.Autor = dr["Autor"].ToString();
                    modulo.Enlace = dr["Enlace"].ToString();
                    modulo.Imagen = dr["Imagen"].ToString();

                    if(dr["Completado"] != DBNull.Value )
                        modulo.Completado = Convert.ToInt32(dr["Completado"]);

                    if (dr["Aprobado"] != DBNull.Value)
                        modulo.Aprobado = Convert.ToInt32(dr["Aprobado"]);

                    if (dr["fechaActualizacion"] != DBNull.Value)
                        modulo.FechaActualizacion = Convert.ToDateTime(dr["fechaActualizacion"]);

                    modulo.Intentos = Convert.ToInt32(dr["intentos"]);

                    lista.Add(modulo);

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

        public List<ModuloCapacitacion> ObtenerModulosPorUsuarioPanel(int idUsuario)
        {

            SqlConnection _conexion = new SqlConnection(Conexion.CadenaConexion);
            SqlCommand _comando = new SqlCommand("PA_ModuloCapacitacion", _conexion) { CommandType = CommandType.StoredProcedure };
            _comando.Parameters.AddWithValue("@idUsuario", SqlDbType.Int).Value = idUsuario;
            _comando.Parameters.AddWithValue("@tipo", SqlDbType.Int).Value = 8;
            List<ModuloCapacitacion> lista = new List<ModuloCapacitacion>();
            try
            {
                if (_conexion.State == ConnectionState.Closed)
                    _conexion.Open();

                SqlDataReader dr = _comando.ExecuteReader();
                while (dr.Read())
                {
                    ModuloCapacitacion modulo = new ModuloCapacitacion();

                    modulo.IdModuloCapacitacion = Convert.ToInt32(dr["idModuloCapacitacion"]);
                    modulo.Nombre = dr["Nombre"].ToString();
                    modulo.Descripcion = dr["Descripcion"].ToString();
                    modulo.Nro = Convert.ToInt32(dr["Nro"]);
                    modulo.Autor = dr["Autor"].ToString();
                    modulo.Enlace = dr["Enlace"].ToString();
                    modulo.Imagen = dr["Imagen"].ToString();

                    if (dr["Completado"] != DBNull.Value)
                        modulo.Completado = Convert.ToInt32(dr["Completado"]);

                    modulo.Calificacion = Convert.ToInt32(dr["Calificacion"]);

                    lista.Add(modulo);

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


        public List<ModuloCapacitacion> ObtenerModulosCalificacionPorUsuario(int idUsuario)
        {

            SqlConnection _conexion = new SqlConnection(Conexion.CadenaConexion);
            SqlCommand _comando = new SqlCommand("PA_ModuloCapacitacion", _conexion) { CommandType = CommandType.StoredProcedure };
            _comando.Parameters.AddWithValue("@idUsuario", SqlDbType.Int).Value = idUsuario;
            _comando.Parameters.AddWithValue("@tipo", SqlDbType.Int).Value = 9;
            List<ModuloCapacitacion> lista = new List<ModuloCapacitacion>();
            try
            {
                if (_conexion.State == ConnectionState.Closed)
                    _conexion.Open();

                SqlDataReader dr = _comando.ExecuteReader();
                while (dr.Read())
                {
                    ModuloCapacitacion modulo = new ModuloCapacitacion();

                    modulo.IdModuloCapacitacion = Convert.ToInt32(dr["idModuloCapacitacion"]);
                    modulo.Completado = Convert.ToInt32(dr["Completado"]);
                    modulo.Aprobado = Convert.ToInt32(dr["Aprobado"]);

                    lista.Add(modulo);

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

        public List<ModuloCapacitacion> ObtenerModulos()
        {

            SqlConnection _conexion = new SqlConnection(Conexion.CadenaConexion);
            SqlCommand _comando = new SqlCommand("PA_ModuloCapacitacion", _conexion) { CommandType = CommandType.StoredProcedure };
            _comando.Parameters.AddWithValue("@tipo", SqlDbType.Int).Value = 5;
            List<ModuloCapacitacion> lista = new List<ModuloCapacitacion>();
            try
            {
                if (_conexion.State == ConnectionState.Closed)
                    _conexion.Open();

                SqlDataReader dr = _comando.ExecuteReader();
                while (dr.Read())
                {
                    ModuloCapacitacion modulo = new ModuloCapacitacion();

                    modulo.IdModuloCapacitacion = Convert.ToInt32(dr["idModuloCapacitacion"]);
                    modulo.Nombre = dr["Nombre"].ToString();
                    modulo.Descripcion = dr["Descripcion"].ToString();
                    modulo.Nro = Convert.ToInt32(dr["Nro"]);
                    modulo.Autor = dr["Autor"].ToString();
                    modulo.Enlace = dr["Enlace"].ToString();
                    modulo.Imagen = dr["Imagen"].ToString();
                    modulo.Calificacion = Convert.ToInt32(dr["calificacion"]);

                    lista.Add(modulo);

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

        public ModuloCapacitacion ObtenerModulosPorId(int idModulo)
        {

            SqlConnection _conexion = new SqlConnection(Conexion.CadenaConexion);
            SqlCommand _comando = new SqlCommand("PA_ModuloCapacitacion", _conexion) { CommandType = CommandType.StoredProcedure };
            _comando.Parameters.AddWithValue("@idModuloCapacitacion", SqlDbType.Int).Value = idModulo;
            _comando.Parameters.AddWithValue("@tipo", SqlDbType.Int).Value = 6;
            ModuloCapacitacion modulo = null;
            try
            {
                if (_conexion.State == ConnectionState.Closed)
                    _conexion.Open();

                SqlDataReader dr = _comando.ExecuteReader();
                if (dr.Read())
                {
                    modulo = new ModuloCapacitacion();

                    modulo.IdModuloCapacitacion = Convert.ToInt32(dr["idModuloCapacitacion"]);
                    modulo.Nombre = dr["Nombre"].ToString();
                    modulo.Descripcion = dr["Descripcion"].ToString();
                    modulo.Nro = Convert.ToInt32(dr["Nro"]);
                    modulo.Autor = dr["Autor"].ToString();
                    modulo.Enlace = dr["Enlace"].ToString();
                    modulo.Imagen = dr["Imagen"].ToString();

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

        public bool RegistrarModulo(ModuloCapacitacion moduloCapacitacion)
        {
            SqlConnection _conexion = new SqlConnection(Conexion.CadenaConexion);
            SqlCommand _comando = new SqlCommand("PA_ModuloCapacitacion", _conexion) { CommandType = CommandType.StoredProcedure };
            _comando.Parameters.AddWithValue("@Nombre", SqlDbType.VarChar).Value = moduloCapacitacion.Nombre;
            _comando.Parameters.AddWithValue("@Descripcion", SqlDbType.VarChar).Value = moduloCapacitacion.Descripcion;
            _comando.Parameters.AddWithValue("@Autor", SqlDbType.VarChar).Value = moduloCapacitacion.Autor;
            _comando.Parameters.AddWithValue("@Enlace", SqlDbType.VarChar).Value = moduloCapacitacion.Enlace;
            _comando.Parameters.AddWithValue("@Imagen", SqlDbType.VarChar).Value = moduloCapacitacion.Imagen;
            _comando.Parameters.AddWithValue("@FechaRegistro", SqlDbType.DateTime).Value = DateTime.Now;
            _comando.Parameters.AddWithValue("@IdUsuarioRegistro", SqlDbType.Int).Value = moduloCapacitacion.IdUsuarioRegistro;
            _comando.Parameters.AddWithValue("@estado", SqlDbType.Bit).Value = moduloCapacitacion.Estado;
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

        public bool EditarModulo(ModuloCapacitacion moduloCapacitacion)
        {
            SqlConnection _conexion = new SqlConnection(Conexion.CadenaConexion);
            SqlCommand _comando = new SqlCommand("PA_ModuloCapacitacion", _conexion) { CommandType = CommandType.StoredProcedure };
            _comando.Parameters.AddWithValue("@Nombre", SqlDbType.VarChar).Value = moduloCapacitacion.Nombre;
            _comando.Parameters.AddWithValue("@Descripcion", SqlDbType.VarChar).Value = moduloCapacitacion.Descripcion;
            _comando.Parameters.AddWithValue("@Autor", SqlDbType.VarChar).Value = moduloCapacitacion.Autor;
            _comando.Parameters.AddWithValue("@Enlace", SqlDbType.VarChar).Value = moduloCapacitacion.Enlace;
            _comando.Parameters.AddWithValue("@Imagen", SqlDbType.VarChar).Value = moduloCapacitacion.Imagen;
            _comando.Parameters.AddWithValue("@FechaRegistro", SqlDbType.DateTime).Value = DateTime.Now;
            _comando.Parameters.AddWithValue("@IdUsuarioRegistro", SqlDbType.Int).Value = moduloCapacitacion.IdUsuarioRegistro;
            _comando.Parameters.AddWithValue("@estado", SqlDbType.Bit).Value = moduloCapacitacion.Estado;
            _comando.Parameters.AddWithValue("@idModuloCapacitacion", SqlDbType.Int).Value = moduloCapacitacion.IdModuloCapacitacion;
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

        public bool EliminarModulo(int idModuloCapacitacion)
        {
            SqlConnection _conexion = new SqlConnection(Conexion.CadenaConexion);
            SqlCommand _comando = new SqlCommand("PA_ModuloCapacitacion", _conexion) { CommandType = CommandType.StoredProcedure };
            _comando.Parameters.AddWithValue("@idModuloCapacitacion", SqlDbType.Int).Value = idModuloCapacitacion;
            _comando.Parameters.AddWithValue("@tipo", SqlDbType.Int).Value = 7;
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
