using Newtonsoft.Json;
using System;
using System.Web.Services;
using System.Web.UI;

namespace VictoriaApp
{
    public partial class SiteMaster : MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string SubirAvatar(string filePath)
        {
            return JsonConvert.SerializeObject(
               new
               {


               }
               );
        }
    }
}