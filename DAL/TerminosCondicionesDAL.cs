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
    public class TerminosCondicionesDAL
    {
        public bool RegistrarTerminos(TerminosCondicionesEL terminos)
        {
            bool exito = false;
            SqlConnection connection = new SqlConnection(Conexion.CadenaConexion);
            SqlCommand command = new SqlCommand("PA_TerminosCondiciones", connection) { CommandType = CommandType.StoredProcedure };
            command.Parameters.AddWithValue("@Titulo", SqlDbType.VarChar).Value = terminos.Titulo;
            command.Parameters.AddWithValue("@Descripcion", SqlDbType.VarChar).Value = terminos.Descripcion;
            command.Parameters.AddWithValue("@Usuario", SqlDbType.VarChar).Value = terminos.Usuario;
            command.Parameters.AddWithValue("@Tipo", SqlDbType.Int).Value = 1;
            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                if (command.ExecuteNonQuery() > 0)
                    exito = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return exito;
        }

        public TerminosCondicionesEL ObtenerTerminos()
        {
            TerminosCondicionesEL terminos = null;
            SqlConnection connection = new SqlConnection(Conexion.CadenaConexion);
            SqlCommand command = new SqlCommand("PA_TerminosCondiciones", connection) { CommandType = CommandType.StoredProcedure };
            command.Parameters.AddWithValue("@Tipo", SqlDbType.Int).Value = 2;
            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                SqlDataReader dr = command.ExecuteReader();
                if (dr.Read())
                {
                    terminos = new TerminosCondicionesEL();
                    terminos.Titulo = dr["Titulo"].ToString();
                    terminos.Descripcion = dr["Descripcion"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return terminos;
        }
    }
}
