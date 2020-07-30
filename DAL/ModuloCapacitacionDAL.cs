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

                    if (dr["fechaActualizacion"] != DBNull.Value)
                        modulo.FechaActualizacion = Convert.ToDateTime(dr["fechaActualizacion"]);

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

    }
}
