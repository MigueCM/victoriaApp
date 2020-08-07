using BLL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VictoriaApp
{
    public partial class TerminosCondiciones : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            lbErrores.Items.Clear();
            List<string> errores = new List<string>();
            errores = TerminosCondicionesBLL.Instancia.RegistrarTerminos(txtTitulo.Value.Trim(), txtDescripcion.Value.Trim(), Session["UsuarioDni"].ToString().Trim());
            if (errores.Count > 0)
            {
                lbErrores.Rows = errores.Count;

                divErrores.Visible = true;
                lbErrores.Visible = true;
                foreach (var item in errores)
                {
                    lbErrores.Items.Add(item);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "showSwal('success-message-terminos', 'Registro exitoso!', 'Se ha registrado correctamente', 'TerminosCondiciones.aspx', '')", true);
            }
        }
    }
}