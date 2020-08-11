using BLL;
using EL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VictoriaApp
{
    public partial class GestionUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargasUsuarios();
                CargarPerfil();
            }
        }

        public void CargarPerfil()
        {
            cbPerfil.DataSource = PerfilBLL.Instancia.ObtenerPerfil();
            cbPerfil.DataTextField = "Nombre";
            cbPerfil.DataValueField = "IdPerfil";
            cbPerfil.DataBind();
        }

        private void CargasUsuarios()
        {

            List<Usuario> lista = UsuarioBLL.Instancia.ObtenerUsuarios();

            StringBuilder innerHtml = new StringBuilder();

            int i = 1;
            foreach (var item in lista)
            {
                string fila = "<tr>";
                fila += $"<td>{i++}</td>";
                fila += $"<td>{item.Persona.Nombre} {item.Persona.Apellidos}</td>";
                fila += $"<td>{item.Perfil.Nombre}</td>";
                fila += $"<td>{item.User}</td>";
                fila += $"<td><button class=\"btn btn-outline-primary\" onClick=\"cargarData({item.IdUsuario});\">Editar</button>";
                fila += $"<button class=\"btn btn-outline-danger\" onClick=\"eliminar({item.IdUsuario});\">Eliminar</button></td>";
                fila += "</tr>";

                innerHtml.AppendLine(fila);

            }

            tbody_modulo.InnerHtml = innerHtml.ToString();


        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            string tipo = txtTipo.Value;

            if (tipo == "1")
                RegistrarUsuario();
            else
                ActualizarUsuario();
        }

        private void RegistrarUsuario()
        {
            string nombre = txtNombre.Value;
            string apellido = txtApellido.Value;
            string dni = txtDNI.Value;
            string email = txtEmail.Value;
            string contrasenia = txtContrasenia.Value;
            string contrasenia2 = txtContrasenia2.Value;
            string fechaNac = txtFechaNacimiento.Value;
            string sexo = cbSexo.Value;
            string perfil = cbPerfil.Value;

            Persona objPersona = new Persona();
            objPersona.Nombre = nombre;
            objPersona.Apellidos = apellido;
            objPersona.Dni = dni;
            objPersona.FechaNacimiento = Convert.ToDateTime(fechaNac);
            objPersona.Sexo = sexo;
            objPersona.Enterar = "";

            int idPersona = PersonaBLL.Instancia.RegistrarPersona(objPersona);

            if (idPersona > 0)
            {
                Usuario oUsuario = new Usuario();
                oUsuario.IdPerfil = Convert.ToInt32(perfil);
                oUsuario.IdPersona = idPersona;
                oUsuario.IdUsuarioRegistro = Convert.ToInt32(Session["IdUsuario"]);
                oUsuario.User = email;
                oUsuario.Password = contrasenia;

                if (UsuarioBLL.Instancia.InsertarUsuario(oUsuario))
                {
                    string currentPage = this.Page.Request.AppRelativeCurrentExecutionFilePath;
                    Response.Redirect(currentPage);
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "registrarModulo", "showSwal('auto-close', 'Registro exitoso!', 'Usuario registrado correctamente', 'GestionUsuario.aspx', '')", true);
                }

            }




        }

        private void ActualizarUsuario()
        {
            string nombre = txtNombre.Value;
            string apellido = txtApellido.Value;
            string dni = txtDNI.Value;
            string fechaNac = txtFechaNacimiento.Value;
            string sexo = cbSexo.Value;
            string perfil = cbPerfil.Value;
            string idPersona = txtPersona.Value;
            string id = txtId.Value;

            Persona objPersona = new Persona();
            objPersona.Nombre = nombre;
            objPersona.Apellidos = apellido;
            objPersona.Dni = dni;
            objPersona.FechaNacimiento = Convert.ToDateTime(fechaNac);
            objPersona.Sexo = sexo;
            objPersona.Id = Convert.ToInt32(idPersona);


            if (PersonaBLL.Instancia.ActualizarPersona(objPersona))
            {
                Usuario oUsuario = new Usuario();
                oUsuario.IdPerfil = Convert.ToInt32(perfil);
                oUsuario.IdUsuarioEdicion = Convert.ToInt32(Session["IdUsuario"]);
                oUsuario.IdUsuario = Convert.ToInt32(id);

                if (UsuarioBLL.Instancia.ActualizarUsuario(oUsuario))
                {
                    string currentPage = this.Page.Request.AppRelativeCurrentExecutionFilePath;
                    Response.Redirect(currentPage);
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "registrarModulo", "showSwal('auto-close', 'Registro exitoso!', 'Usuario registrado correctamente', 'GestionUsuario.aspx', '')", true);
                }

            }



        }

        [WebMethod]
        public static string CargarDataUsuario(int id)
        {

            Usuario objUsuario = UsuarioBLL.Instancia.ObtenerUsuarioPorId(id);

            return JsonConvert.SerializeObject(
                new
                {
                    objUsuario

                }
                );

        }

        [WebMethod]
        public static bool EliminarData(int id)
        {
            return UsuarioBLL.Instancia.EliminarUsuario(id);
        }


    }
}