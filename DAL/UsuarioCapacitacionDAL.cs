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
    
    }
}
