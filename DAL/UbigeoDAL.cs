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
    public class UbigeoDAL
    {
        public List<Ubigeo> ObtenerUbigeo()
        {
            List<Ubigeo> ubigeos = new List<Ubigeo>();
            SqlConnection _conexion = new SqlConnection(Conexion.CadenaConexion);
            string cadena = @"select d.id as IdDistrito, d.[name] as Distrito, p.[name] as Provincia, dp.[name] as Departamento from [ubigeo_peru_districts] d
                                inner join[ubigeo_peru_provinces] p on p.id = d.province_id
                                inner join[ubigeo_peru_departments] dp on dp.id = d.department_id";
            SqlCommand _comando = new SqlCommand(cadena, _conexion);
            Ubigeo defaultU = new Ubigeo();
            defaultU.IdDistrito = "0";
            defaultU.Completo = "-SELECCIONE SU UBICACIÓN-";
            ubigeos.Add(defaultU);
            try
            {
                if (_conexion.State == ConnectionState.Closed)
                    _conexion.Open();

                SqlDataReader dr = _comando.ExecuteReader();
                while (dr.Read())
                {
                    Ubigeo ubigeo = new Ubigeo();
                    ubigeo.IdDistrito = dr["IdDistrito"].ToString();
                    ubigeo.Completo = dr["Departamento"].ToString() + " - " + dr["Provincia"].ToString() + " - " + dr["Distrito"].ToString();
                    ubigeos.Add(ubigeo);
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
            return ubigeos;
        }
    }
}
