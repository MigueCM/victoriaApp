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
    public class PerfilDAL
    {
        public List<Perfil> ObtenerPerfil()
        {
            List<Perfil> lista = new List<Perfil>();
            SqlConnection _conexion = new SqlConnection(Conexion.CadenaConexion);
            SqlCommand _comando = new SqlCommand("PA_Perfil", _conexion) { CommandType = CommandType.StoredProcedure };
            _comando.Parameters.AddWithValue("@tipo", SqlDbType.Int).Value = 4;

            Perfil oDefPerfil = new Perfil();
            oDefPerfil.IdPerfil = 0;
            oDefPerfil.Nombre = "-SELECCIONE PERFIL-";
            lista.Add(oDefPerfil);
            try
            {
                if (_conexion.State == ConnectionState.Closed)
                    _conexion.Open();

                SqlDataReader dr = _comando.ExecuteReader();
                while (dr.Read())
                {
                    Perfil oPefil = new Perfil();
                    oPefil.IdPerfil = Convert.ToInt32(dr["idPerfil"]);
                    oPefil.Nombre = dr["Perfil"].ToString();
                    lista.Add(oPefil);
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
    }
}
