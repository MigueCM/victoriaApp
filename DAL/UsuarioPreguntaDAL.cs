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
    public class UsuarioPreguntaDAL
    {
        public bool InsertarUsuarioPregunta(UsuarioPregunta objUsuarioPregunta)
        {

            SqlConnection _conexion = new SqlConnection(Conexion.CadenaConexion);
            SqlCommand _comando = new SqlCommand("PA_UsuarioPregunta", _conexion) { CommandType = CommandType.StoredProcedure };
            _comando.Parameters.AddWithValue("@idUsuarioCapacitacion", SqlDbType.Int).Value = objUsuarioPregunta.IdUsuarioCapacitacion;
            _comando.Parameters.AddWithValue("@idPreguntaCapacitacion", SqlDbType.VarChar).Value = objUsuarioPregunta.IdPreguntaCapacitacion;
            _comando.Parameters.AddWithValue("@respuesta", SqlDbType.Char).Value = objUsuarioPregunta.Respuesta;
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
    }
}
