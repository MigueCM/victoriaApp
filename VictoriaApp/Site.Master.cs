using BLL;
using System;
using System.IO;
using System.Web.UI;

namespace VictoriaApp
{
    public partial class SiteMaster : MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnImagen_Click(object sender, EventArgs e)
        {

            if ((txtFile.PostedFile != null) && (txtFile.PostedFile.ContentLength > 0))
            {
                //string fn = System.IO.Path.GetFileName(txtFile.PostedFile.FileName);
                string ext = System.IO.Path.GetExtension(txtFile.PostedFile.FileName);
                string fileImagen = Session["IdPersona"].ToString().Trim() + Session["nombre"].ToString().Trim() + ext;
                string rutaImagen = Server.MapPath("Data\\Avatar") + "\\" + fileImagen;

                if (PersonaBLL.Instancia.ActualizarAvatar(fileImagen, Convert.ToInt32(Session["IdPersona"].ToString())))
                {

                    try
                    {
                        if (File.Exists(rutaImagen))
                            File.Delete(rutaImagen);
                        txtFile.PostedFile.SaveAs(rutaImagen);
                        //Response.Write("The file has been uploaded.");
                        Session["AvatarPersona"] = "Data/Avatar/" + PersonaBLL.Instancia.ObtenerAvatar(Convert.ToInt32(Session["IdPersona"].ToString()));
                        string currentPage = this.Page.Request.AppRelativeCurrentExecutionFilePath;
                        Response.Redirect(currentPage);
                    }
                    catch (Exception ex)
                    {
                        //Response.Write("Error: " + ex.Message);//Note: Exception.Message returns a detailed message that describes the current exception. //For security reasons, we do not recommend that you return Exception.Message to end users in //production environments. It would be better to put a generic error message. 
                    }
                }


            }
            else
            {
                Response.Write("Please select a file to upload.");
            }
        }
    }
}