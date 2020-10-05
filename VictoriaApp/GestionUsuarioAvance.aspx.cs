using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using EL;
using SpreadsheetLight;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;


namespace VictoriaApp
{
    public partial class GestionUsuarioAvance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargasUsuarios();
                CargasUsuarios2();
            }
        }

        private void CargasUsuarios()
        {

            List<Usuario> lista = UsuarioBLL.Instancia.ObtenerUsuarioAvance();

            StringBuilder innerHtml = new StringBuilder();

            int i = 1;
            foreach (var item in lista)
            {
                //int porcentaje = UsuarioCapacitacionBLL.Instancia.ObtenerPorcentajeModulos(item.IdUsuario);
                string fila = "<tr>";
                fila += $"<td>{i++}</td>";
                fila += $"<td>{item.Persona.Nombre} {item.Persona.Apellidos}</td>";
                //fila += $"<td>{item.Perfil.Nombre}</td>";
                fila += $"<td>{item.FechaRegistro}</td>";
                fila += $"<td>";
                fila += $"<div class=\"progress progress-xl mt-2 \" style='height:23px;'>";
                fila += $"<div class=\"progress-bar bg-primary\" role=\"progressbar\" style=\"width:{item.Porcentaje}%\" aria-valuenow=\"50\" aria-valuemin=\"0\" aria-valuemax=\"100\">";
                fila += $"<span class=\"text-progressbar2\">{item.Porcentaje}%</span>";
                fila += $"</div>";
                fila += $"</div>";
                fila += $"</td>";
                fila += $"<td>{item.FechaSesion}</td>";
                fila += "</tr>";

                innerHtml.AppendLine(fila);

            }

            tbody_modulo.InnerHtml = innerHtml.ToString();


        }


        private void CargasUsuarios2()
        {

            List<UsuarioCapacitacion> lista = UsuarioBLL.Instancia.ObtenerUsuarioYModulo();

            StringBuilder innerHtml = new StringBuilder();

            int i = 1;
            foreach (var item in lista)
            {
                string fila = "<tr>";
                fila += $"<td>{i++}</td>";
                fila += $"<td>{item.Nombre}</td>";
                fila += $"<td>{item.ModuloCapacitacion.Nombre}</td>";
                fila += $"<td>{item.Nota}</td>";
                fila += $"<td>{item.Calificacion}</td>";
                fila += "</tr>";

                innerHtml.AppendLine(fila);

            }

            tbody2.InnerHtml = innerHtml.ToString();


        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            

            string fileName = "plantilla.xlsx";
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "archivos", fileName);
            string pathNew = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "archivos", "datosVictoria.xlsx");
            string ruta = "~/archivos/datosVictoria.xlsx";
            if (File.Exists(path))
            {
                SLDocument sl = new SLDocument(path);

                List<Usuario> lista = UsuarioBLL.Instancia.ObtenerUsuariosExcel();
                int i = 1;
                foreach (Usuario item in lista)
                {

                    string estado = "";

                    if( item.Porcentaje == 0)
                    {
                        estado = "No Iniciado";
                    }else if (item.Porcentaje == 100)
                    {
                        estado = "Graduado";
                    }
                    else
                    {
                        estado = "En Proceso";
                    }

                    int celdaContenido = i + 1;

                    sl.SetCellValue("A"+ celdaContenido, i);
                    sl.SetCellValue("B" + celdaContenido, String.Format("{0} {1}",item.Persona.Nombre,item.Persona.Apellidos) );
                    sl.SetCellValue("C" + celdaContenido, item.Persona.Dni);
                    sl.SetCellValue("D" + celdaContenido, item.Persona.Celular);
                    sl.SetCellValue("E" + celdaContenido, item.User);
                    sl.SetCellValue("F" + celdaContenido, String.Format("{0}%", item.Porcentaje));
                    sl.SetCellValue("G" + celdaContenido, item.Persona.Ciudad);
                    sl.SetCellValue("H" + celdaContenido, item.Persona.Departamento);
                    sl.SetCellValue("I" + celdaContenido, item.Persona.Sexo);
                    sl.SetCellValue("J" + celdaContenido, estado);
                    sl.SetCellValue("K" + celdaContenido, item.Persona.Enterar);
                    sl.SetCellValue("L" + celdaContenido, item.FechaRegistro.ToString("dd/mm/yyyy"));
                    sl.SetCellValue("M" + celdaContenido, item.FechaSesion);


                    SLStyle sLStyle = sl.CreateStyle();
                    sLStyle.SetPatternFill(PatternValues.Solid, System.Drawing.Color.White, System.Drawing.Color.FromArgb(65, 0, 96));
                    sl.SetCellStyle("F" + celdaContenido, sLStyle);

                    i += 1;

                }


                    
                
                sl.SaveAs(pathNew);

                String prueba;
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "xlsx";
                prueba = Path.GetFileName(ruta).ToString();
                HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=" + prueba);
                HttpContext.Current.Response.TransmitFile(ruta);
                HttpContext.Current.Response.End();
                File.Delete(pathNew);

            }
            else
            {
                Console.WriteLine("Archivo no existe");
            }
        }
    }
}