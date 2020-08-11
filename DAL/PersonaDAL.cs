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
        public int RegistrarPersona(Persona persona)
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
                    
                //if (!usuarioDAL.InsertarUsuario(id, usuario, password))
                //    valor = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _conexion.Close();
            }
            return id;
        }

        public bool ActualizarPersona(Persona persona)
        {
            SqlConnection _conexion = new SqlConnection(Conexion.CadenaConexion);
            SqlCommand _comando = new SqlCommand("PA_Persona", _conexion) { CommandType = CommandType.StoredProcedure };
            _comando.Parameters.AddWithValue("@Nombre", SqlDbType.VarChar).Value = persona.Nombre;
            _comando.Parameters.AddWithValue("@Apellidos", SqlDbType.VarChar).Value = persona.Apellidos;
            _comando.Parameters.AddWithValue("@Dni", SqlDbType.VarChar).Value = persona.Dni;
            _comando.Parameters.AddWithValue("@FechaNacimiento", SqlDbType.DateTime).Value = persona.FechaNacimiento;
            _comando.Parameters.AddWithValue("@Sexo", SqlDbType.VarChar).Value = persona.Sexo;
            _comando.Parameters.AddWithValue("@FechaUltimaModificacion", SqlDbType.DateTime).Value = DateTime.Now;
            _comando.Parameters.AddWithValue("@id", SqlDbType.Int).Value = persona.Id;
            //_comando.Parameters.AddWithValue("@Celular", SqlDbType.VarChar).Value = persona.Celular;
            //_comando.Parameters.AddWithValue("@Departamento", SqlDbType.VarChar).Value = persona.Departamento;
            //_comando.Parameters.AddWithValue("@Ciudad", SqlDbType.VarChar).Value = persona.Ciudad;
            //_comando.Parameters.AddWithValue("@Avatar", SqlDbType.VarChar).Value = persona.Avatar;
            //_comando.Parameters.AddWithValue("@Enteraste", SqlDbType.VarChar).Value = persona.Enterar;
            _comando.Parameters.AddWithValue("@tipo", SqlDbType.Int).Value = 4;
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

        public bool ActualizarAvatar(string archivo, int id)
        {
            SqlConnection _conexion = new SqlConnection(Conexion.CadenaConexion);
            SqlCommand _comando = new SqlCommand("PA_Persona", _conexion) { CommandType = CommandType.StoredProcedure };
            _comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
            _comando.Parameters.AddWithValue("@Avatar", SqlDbType.VarChar).Value = archivo;
            _comando.Parameters.AddWithValue("@Tipo", SqlDbType.Int).Value = 2;
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

        public string ObtenerAvatar(int id)
        {
            SqlConnection _conexion = new SqlConnection(Conexion.CadenaConexion);
            SqlCommand _comando = new SqlCommand("PA_Persona", _conexion) { CommandType = CommandType.StoredProcedure };
            _comando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
            _comando.Parameters.AddWithValue("@Tipo", SqlDbType.Int).Value = 3;
            string nombreImagen = "";
            try
            {
                if (_conexion.State == ConnectionState.Closed)
                    _conexion.Open();

                SqlDataReader dr = _comando.ExecuteReader();

                if (dr.Read())
                    nombreImagen = dr["Imagen"].ToString();
                    
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _conexion.Close();
            }
            return nombreImagen;
        }
    }
}