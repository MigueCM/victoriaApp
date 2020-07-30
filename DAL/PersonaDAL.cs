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
    public class PersonaDAL
    {
        UsuarioDAL usuarioDAL = new UsuarioDAL();
        public bool RegistrarPersona(Persona persona, string usuario, string password)
        {
            SqlConnection _conexion = new SqlConnection(Conexion.CadenaConexion);
            SqlCommand _comando = new SqlCommand("PA_Persona", _conexion) { CommandType = CommandType.StoredProcedure };
            _comando.Parameters.AddWithValue("@Nombre", SqlDbType.VarChar).Value = persona.Nombre;
            _comando.Parameters.AddWithValue("@Apellidos", SqlDbType.VarChar).Value = persona.Apellidos;
            _comando.Parameters.AddWithValue("@Dni", SqlDbType.VarChar).Value = persona.Dni;
            _comando.Parameters.AddWithValue("@FechaNacimiento", SqlDbType.DateTime).Value = persona.FechaNacimiento;
            _comando.Parameters.AddWithValue("@Sexo", SqlDbType.VarChar).Value = persona.Sexo;
            _comando.Parameters.AddWithValue("@Celular", SqlDbType.VarChar).Value = persona.Celular;
            _comando.Parameters.AddWithValue("@Departamento", SqlDbType.VarChar).Value = persona.Departamento;
            _comando.Parameters.AddWithValue("@Ciudad", SqlDbType.VarChar).Value = persona.Ciudad;
            _comando.Parameters.AddWithValue("@Avatar", SqlDbType.VarChar).Value = persona.Avatar;
            _comando.Parameters.AddWithValue("@Enteraste", SqlDbType.VarChar).Value = persona.Enterar;
            _comando.Parameters.AddWithValue("@tipo", SqlDbType.Int).Value = 1;
            bool valor = false;
            int id = 0;
            try
            {
                if (_conexion.State == ConnectionState.Closed)
                    _conexion.Open();
                SqlDataReader dr = _comando.ExecuteReader();
                if (dr.Read())
                {
                    valor = true;
                    id = Convert.ToInt32(dr["ID"]);
                }
                    
                if (!usuarioDAL.InsertarUsuario(id, usuario, password))
                    valor = false;
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
