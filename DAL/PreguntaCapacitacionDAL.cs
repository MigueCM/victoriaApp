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
    public class PreguntaCapacitacionDAL
    {
        public List<PreguntaCapacitacion> ObtenerPreguntas(int idModulo)
        {

            SqlConnection _conexion = new SqlConnection(Conexion.CadenaConexion);
            SqlCommand _comando = new SqlCommand("PA_PreguntaCapacitacion", _conexion) { CommandType = CommandType.StoredProcedure };
            _comando.Parameters.AddWithValue("@idModuloCapacitacion", SqlDbType.Int).Value = idModulo;
            _comando.Parameters.AddWithValue("@tipo", SqlDbType.Int).Value = 4;
            List<PreguntaCapacitacion> lista = new List<PreguntaCapacitacion>();
            try
            {
                if (_conexion.State == ConnectionState.Closed)
                    _conexion.Open();

                SqlDataReader dr = _comando.ExecuteReader();
                while (dr.Read())
                {
                    PreguntaCapacitacion modulo = new PreguntaCapacitacion();

                    modulo.IdPreguntaCapacitacion = Convert.ToInt32(dr["idModuloCapacitacion"]);
                    modulo.IdModuloCapacitacion = Convert.ToInt32(dr["idModuloCapacitacion"]);
                    modulo.Descripcion = dr["Descripcion"].ToString();
                    modulo.Orden = Convert.ToInt32(dr["Nro"]);
                    modulo.Alternativa1 = dr["Alternativa1"].ToString();
                    modulo.Alternativa2 = dr["Alternativa2"].ToString();
                    modulo.Alternativa3 = dr["Alternativa3"].ToString();
                    modulo.Alternativa4 = dr["Alternativa4"].ToString();
                    modulo.Alternativa5 = dr["Alternativa5"].ToString();
                    modulo.Respuesta = dr["Respuesta"].ToString();

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

        public int ObtenerUltimoNumero(int idModulo)
        {

            SqlConnection _conexion = new SqlConnection(Conexion.CadenaConexion);
            SqlCommand _comando = new SqlCommand("PA_PreguntaCapacitacion", _conexion) { CommandType = CommandType.StoredProcedure };
            _comando.Parameters.AddWithValue("@idModuloCapacitacion", SqlDbType.Int).Value = idModulo;
            _comando.Parameters.AddWithValue("@tipo", SqlDbType.Int).Value = 6;
            int numero = 0;
            try
            {
                if (_conexion.State == ConnectionState.Closed)
                    _conexion.Open();

                SqlDataReader dr = _comando.ExecuteReader();
                if (dr.Read())
                {
                    numero = Convert.ToInt32(dr["Orden"]);
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
            return numero;

        }

        public PreguntaCapacitacion ObtenerPreguntasPorId(int idPregunta)
        {
            SqlConnection _conexion = new SqlConnection(Conexion.CadenaConexion);
            SqlCommand _comando = new SqlCommand("PA_PreguntaCapacitacion", _conexion) { CommandType = CommandType.StoredProcedure };
            _comando.Parameters.AddWithValue("@idPreguntaCapacitacion", SqlDbType.Int).Value = idPregunta;
            _comando.Parameters.AddWithValue("@tipo", SqlDbType.Int).Value = 5;
            PreguntaCapacitacion modulo = null;
            try
            {
                if (_conexion.State == ConnectionState.Closed)
                    _conexion.Open();

                SqlDataReader dr = _comando.ExecuteReader();
                while (dr.Read())
                {
                    modulo = new PreguntaCapacitacion();

                    modulo.IdPreguntaCapacitacion = Convert.ToInt32(dr["idModuloCapacitacion"]);
                    modulo.IdModuloCapacitacion = Convert.ToInt32(dr["idModuloCapacitacion"]);
                    modulo.Descripcion = dr["Descripcion"].ToString();
                    modulo.Orden = Convert.ToInt32(dr["Nro"]);
                    modulo.Alternativa1 = dr["Alternativa1"].ToString();
                    modulo.Alternativa2 = dr["Alternativa2"].ToString();
                    modulo.Alternativa3 = dr["Alternativa3"].ToString();
                    modulo.Alternativa4 = dr["Alternativa4"].ToString();
                    modulo.Alternativa5 = dr["Alternativa5"].ToString();
                    modulo.Respuesta = dr["Respuesta"].ToString();

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

        public bool RegistrarPregunta(PreguntaCapacitacion preguntaCapacitacion)
        {
            SqlConnection _conexion = new SqlConnection(Conexion.CadenaConexion);
            SqlCommand _comando = new SqlCommand("PA_ModuloCapacitacion", _conexion) { CommandType = CommandType.StoredProcedure };
            _comando.Parameters.AddWithValue("@idModuloCapacitacion", SqlDbType.Int).Value = preguntaCapacitacion.IdModuloCapacitacion;
            _comando.Parameters.AddWithValue("@Descripcion", SqlDbType.VarChar).Value = preguntaCapacitacion.Descripcion;
            _comando.Parameters.AddWithValue("@nro", SqlDbType.Int).Value = preguntaCapacitacion.Orden;
            _comando.Parameters.AddWithValue("@alternativa1", SqlDbType.VarChar).Value = preguntaCapacitacion.Alternativa1;
            _comando.Parameters.AddWithValue("@alternativa2", SqlDbType.VarChar).Value = preguntaCapacitacion.Alternativa2;
            _comando.Parameters.AddWithValue("@alternativa3", SqlDbType.VarChar).Value = preguntaCapacitacion.Alternativa3;
            _comando.Parameters.AddWithValue("@alternativa4", SqlDbType.VarChar).Value = preguntaCapacitacion.Alternativa4;
            _comando.Parameters.AddWithValue("@alternativa5", SqlDbType.VarChar).Value = preguntaCapacitacion.Alternativa5;
            _comando.Parameters.AddWithValue("@respuesta", SqlDbType.VarChar).Value = preguntaCapacitacion.Respuesta;
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

        public bool EditarPregunta(PreguntaCapacitacion preguntaCapacitacion)
        {
            SqlConnection _conexion = new SqlConnection(Conexion.CadenaConexion);
            SqlCommand _comando = new SqlCommand("PA_ModuloCapacitacion", _conexion) { CommandType = CommandType.StoredProcedure };
            _comando.Parameters.AddWithValue("@idPreguntaCapacitacion", SqlDbType.Int).Value = preguntaCapacitacion.IdPreguntaCapacitacion;
            _comando.Parameters.AddWithValue("@idModuloCapacitacion", SqlDbType.Int).Value = preguntaCapacitacion.IdModuloCapacitacion;
            _comando.Parameters.AddWithValue("@Descripcion", SqlDbType.VarChar).Value = preguntaCapacitacion.Descripcion;
            _comando.Parameters.AddWithValue("@nro", SqlDbType.Int).Value = preguntaCapacitacion.Orden;
            _comando.Parameters.AddWithValue("@alternativa1", SqlDbType.VarChar).Value = preguntaCapacitacion.Alternativa1;
            _comando.Parameters.AddWithValue("@alternativa2", SqlDbType.VarChar).Value = preguntaCapacitacion.Alternativa2;
            _comando.Parameters.AddWithValue("@alternativa3", SqlDbType.VarChar).Value = preguntaCapacitacion.Alternativa3;
            _comando.Parameters.AddWithValue("@alternativa4", SqlDbType.VarChar).Value = preguntaCapacitacion.Alternativa4;
            _comando.Parameters.AddWithValue("@alternativa5", SqlDbType.VarChar).Value = preguntaCapacitacion.Alternativa5;
            _comando.Parameters.AddWithValue("@respuesta", SqlDbType.VarChar).Value = preguntaCapacitacion.Respuesta;
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
    }
}
