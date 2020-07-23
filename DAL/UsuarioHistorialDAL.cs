using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UsuarioHistorialDAL
    {
        public bool InsertarHistorial(int idUsuario)
        {

            SqlConnection _conexion = new SqlConnection(Conexion.CadenaConexion);
            SqlCommand _comando = new SqlCommand("PA_UsuarioHistorial", _conexion) { CommandType = CommandType.StoredProcedure };
            _comando.Parameters.AddWithValue("@idUsuario", SqlDbType.VarChar).Value = idUsuario;
            _comando.Parameters.AddWithValue("@fechaSesion", SqlDbType.VarChar).Value = DateTime.Now;
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
