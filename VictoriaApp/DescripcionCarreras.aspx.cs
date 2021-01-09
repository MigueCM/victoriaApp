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
    public partial class DescripcionCarreras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["IdCarreraSeleccionada"] != null && Session["Genero"] != null)
                {
                    string genero = Session["Genero"].ToString();
                    string image = "";
                    string cadena1 = "";
                    string cadena2 = "";
                    string cadena3 = "";
                    switch (Convert.ToInt32(Session["IdCarreraSeleccionada"].ToString()))
                    {
                        case 1:
                            Session["DesCarrera"] = "ingenieria-minas";

                            cadena1 = @"Es la ingeniería que gestiona eficientemente las operaciones para la extracción y aprovechamiento
                                        de recursos mineros, evaluando el impacto en el medio ambiente y las comunidades.
                                        <br />
                                        <br />
                                        Desarrolla las competencias y habilidades para la investigación, prospección, explotación y producción
                                        de yacimientos minero.";

                            cadena2 = @"Se trata de una carrera con bastantes oportunidades para los jóvenes
                                        con espiritu competitivo y que estén dispuestos a prepararse constantemente. ";

                            cadena3 = @"Operaciones <br />
                                        Planeamiento <br />
                                        Desarrollo y evaluación de proyectos <br />
                                        Servicios auxiliares <br />
                                        Seguridad minera <br />
                                        Medio ambiente <br />
                                        Investigación <br />
                                        Servicios de consultoría o de gestión a nivel general en empresas
                                        y organizaciones relacionadas con este sector<br />";

                            image = "ingenieria-minas/fondo-pregunta.png";
                            break;
                        case 2:
                            Session["DesCarrera"] = "ingenieria-aeronautica";

                            cadena1 = @"Domina la dinámica de vuelo de los motores, diseña, construye, mantiene y repara aeronaves.
                                        Lidera proyectos de construcción del sector aeronáutico.
                                        <br/>
                                        <br/>
                                        Gestiona, planifica e implementa el desarrollo aeroportuario.";

                            cadena2 = @"Se trata de una carrera con bastantes oportunidades para los jóvenes con enfoque
                                        analítico y lógico para la resolución de problemas, combinado con creatividad e imaginación.";

                            cadena3 = @"Diseño <br/>
                                        Investigación <br/>
                                        Construcción <br/>
                                        Mantenimiento <br/>
                                        Mejoras e Innovación <br/>";

                            image = "ingenieria-aeronautica/fondo-pregunta.jpg";
                            break;
                        case 3:
                            Session["DesCarrera"] = "ingenieria-sistemas";

                            cadena1 = @"Es un profesional capaz de conducir proyectos complejos de diversa índole, define adecuadamente los problemas
                                        que estos generan, usando métodos, técnicas, teorías y metodologías que le brindan las disciplinas de la computación,
                                        para luego proponer soluciones adecuadas mediante el diseño e implementación de sistemas informáticos.";

                            cadena2 = @"Se trata de una carrera con bastantes oportunidades para los jóvenes que disfrutan resolviendo problemas, adquiriendo
                                        una visión del conjunto y centrándose en todos los diferentes factores involucrados.
                                        <br/>
                                        <br/>
                                        Sus habilidades analiticas son fundamentales.";

                            cadena3 = @"Analista de sistemas de información <br/>
                                        Jefe de proyectos informáticos <br/>
                                        Desarrollador de software <br/>
                                        Auditor de sistemas de información <br/>
                                        Investigador <br/>";

                            image = "ingenieria-sistemas/fondo-pregunta.png";
                            break;
                        case 4:
                            Session["DesCarrera"] = "arquitectura-datos";

                            cadena1 = @"Desarrollarás soluciones de software para la gestión de datos masivos utilizando herramientas tecnológicas adecuadas, 
                                        transformándols en información significativa que contribuya a la toma de decisiones.";

                            cadena2 = @"Se trata de una carrera con bastantes oportunidades para los jóvenes que posean habilidades que aúnan las habilidades
                                        numéricas con las sociales y buenas habildades comunicativas, debe gustarle el trabajo colaborativo.";

                            cadena3 = @"Analista de datos <br/>
                                        Construcción de modelos estadísticos de predicción <br/>
                                        Diseño de exprimentos <br/>
                                        Control de calidad <br/>
                                        Investigación de mercados <br/>
                                        Consultoría <br/>
                                        Análista de bases de datos <br/>
                                        Bioestadística <br/>
                                        Geoestadística <br/>
                                        Investigador <br/>";

                            image = "arquitectura-datos/fondo-pregunta.png";
                            break;
                        case 5:
                            Session["DesCarrera"] = "biologia-marina";

                            cadena1 = @"Perfil competente, visión interdisciplinaria, habilidades y conocimientos de las tendencias globales en investigación y
                                        y protección del ambiente marino; preparados para la investigación, el manejo sostenible de los recursos acuáticos; integrando
                                        el conocimiento de los ecosistemas marinos y acuáticos en general, con un enfoque cientifico, técnico y humanista que les permita
                                        afrontar los problemas globales en búsqueda de soluciones.";

                            cadena2 = @"Se trata de una carrera con bastantes oportunidades para los jóvenes que posean interés por la conservación del medioambiente y de
                                        los ecosistemas marinos puede el trabajo colaborativo y el gusto por la investigación.";

                            cadena3 = @"Gestión de proyectos medioambientales <br/>
                                        Investigación <br/>
                                        Buceo cientifico <br/>
                                        Manejo y conservación del mar <br/>
                                        Biotecnología <br/>
                                        Pesquería y acuicultura <br/>";

                            image = "biologia-marina/fondo-pregunta.png";
                            break;
                        case 6:
                            Session["DesCarrera"] = "mecatronica";

                            cadena1 = @"Analiza y diseña productos y procesos de manufacturas automatizadas. Domina los procedimientos y tecnologias provenientes de la 
                                        ingenieria mecánica, electrónica, informática y eléctrica. Destaca en el campo laboral por tu conocimiento en el área de 
                                        automatización, sistemas electrónicos y mecánicos.";

                            cadena2 = @"Se trata de una carrera con bastantes oportunidades para los jóvenes que posean interés por los números y la tecnología, apasionados
                                        en solucionar problemas y crear proyectos para mejorar procesos o innovar.";

                            cadena3 = @"Metal-mecánico <br/>
                                        Manufactura <br/>
                                        Minería <br/>
                                        Pesquería <br/>
                                        Agroindustria <br/>
                                        Textil <br/>
                                        Energía <br/>
                                        Petroquímica <br/>
                                        Transporte <br/>
                                        Servicios <br/>";

                            image = "mecatronica/fondo-pregunta.png";
                            break;
                        case 7:
                            Session["DesCarrera"] = "deportes";

                            cadena1 = @"Gestión de todos tipos de empresas enfocadas en el deporte aprendiendo la gestión, planificación y ejecución en la industria deportiva
                                        combinando habilidades blandas y duras. Desempeñarte como gestor deportivo te permitirá desarrollarte en el sector tanto a nivel nacional 
                                        como internacional.";

                            cadena2 = @"Se trata de una carrera con bastantes oportunidades para los jovenes que posean interés por la gestión integral que les apasione el deporte
                                        con un enfoque más estratégico, con habilidades en gestión, comunicación y planificación.";

                            cadena3 = @"Creador de empresas del sector cultural, recreativo y deportivo. <br/>
                                        Gerente y gestor en empresas <br/>
                                        Directivo en entidades y organizaciones <br/>
                                        Consultor <br/>";

                            image = "deportes/fondo-pregunta.png";
                            break;
                        case 8:
                            Session["DesCarrera"] = "economia";

                            cadena1 = @"Es competente para entender las interrelaciones económicas y financieras en una economía globalizada; están capacitados para gerenciar empresas
                                        públicas y privadas que logren una mayor valoración en el tiempo; con el objetivo de mejorar la calidad de vida de la sociedad peruana y 
                                        latinoamericana.
                                        <br/>
                                        <br/>
                                        Tienen las habilidades y destrezas para ser empresarios de éxito.";

                            cadena2 = @"Se trata de una carrera con bastantes oportunidades para los jóvenes que les guste los números, las estadísticas, y deben tener una alta capacidad
                                        analítica para comprender e interpretar los datos.";

                            cadena3 = @"Analista <br/>
                                        Docente <br/>
                                        Directivo en entidades y organizaciones <br/>
                                        Consultor <br/>";

                            image = "economia/fondo-pregunta.png";
                            break;
                        case 9:
                            Session["DesCarrera"] = "biotecnologia";

                            cadena1 = @"Cuenta con las facultades para desarrollar productos originados por manipulación genética de células, controla la calidad de productos y materia prima
                                        en industrias además de desarrollar distintos sistemas de diagnóstico de laboratorio tanto en humanos, animales y vegetales, debido a que tiene 
                                        conocimientos para realizar estudios e investigaciones que se relacionen con la Biología la Bioquímica, la Biología Celular y la Biología Molecular.";

                            cadena2 = @"Se trata de una carrera con bastantes oportunidades para los jóvenes que posean interés en áreas como la atención sanitaria en la industria yla agricultura,
                                        deben tener aptitudes numéricas, tecnológicas y ser amantes de la biologías.";

                            cadena3 = @"Creador de productos <br/>
                                        Investigación <br/>
                                        Laboratorista <br/>
                                        Gestión de equipos técnicos <br/>
                                        Diseñan, ejecutan y evalúan los experimentos <br/>";

                            image = "biotecnologia/fondo-pregunta.png";
                            break;
                        case 10:
                            Session["DesCarrera"] = "fisica";

                            cadena1 = @"La Física es una ciencia que se dedica a buscar las leyes que gobiernan tanto el comportamiento de las particulas más elementales como las que rigen la 
                                        dinámica del universo en su conjunto. Es decir, es una ciencia que se ocupa del mocrocosmos y del macrocosmos. Esta ciencia posee distintas ramas:
                                        mientras el fisico teórico propone modelos para explicar diversos fenómenos, el físico experimental somete esos modelos a la prueba del experimento para,
                                        asi, validarlos o descartarlos. Tambien existe la física aplicada, donde se hace uso del conocimiento fundamental para lograr que la naturaleza se comporte
                                        de una forma que nos sea útil. Comprenderás que se trata de una ciencia en constante evolución: con cada pregunta que se logra responder, aparecen muchas 
                                        otras que representan nuevos desafios.";

                            cadena2 = @"Se trata de una carrera con bastantes oportunidades para los jóvenes que posean curiosidad con respecto al mundo, interés respecto a la resolución de 
                                        problemas y a cómo suceden las cosas habilidades fuertes en matemáticas.";

                            cadena3 = @"Investigación <br/>
                                        Docencia en universidades, instituto, centros de investigación, etc <br/>
                                        Desarrollo de modelos y de códigos informáticos <br/>
                                        Evaluación estadística <br/>";

                            image = "fisica/fondo-pregunta.png";
                            break;
                        default:
                            break;

                            
                    }

                    Session["UrlBackground"] = image;
                    Session["Text1"] = HttpUtility.HtmlEncode(cadena1);
                    Session["Text2"] = HttpUtility.HtmlEncode(cadena2);
                    Session["Text3"] = HttpUtility.HtmlEncode(cadena3);

                    Cargardescripcion();
                }
            }
        }

        private void Cargardescripcion()
        {
            StringBuilder innerHtml = new StringBuilder();
            for (int i = 1; i <= 3; i++)
            {
                string fila = "<div class=\"card\">";

                fila += $"<div class=\"card-header\" role=\"tab\" id=\"heading-{i}\">";
                fila += "<h6 class=\"mb-0\">";
                fila += $"<a data-toggle=\"collapse\" href=\"#collapse-{i}\" aria-expanded=\"true\" aria-controls=\"collapse-{i}\"> How can I pay for an order I placed?</a>";
                fila += "   </h6>";
                fila += " </div>";
                fila += $"<div id =\"collapse-{i}\" class=\"collapse\" role=\"tabpanel\" aria-labelledby=\"heading-{i}\" data-parent=\"#accordion-4\" >";
                fila += "   <div class=\"card-body\">";
                fila += "  <div class=\"row\">";
                fila += " <div class=\"col-9\">";
                              fila += "  <p class=\"mb -0 text-white\">You can pay for the product you have purchased using credit cards, debit cards, or via online banking. We also on-delivery services.</p>";
                fila += "</div>";
                fila += "  </div>";
                fila += "    </div>";
                fila += "   </div>";
                fila += "    </div>";
                innerHtml.AppendLine(fila);
            }
               
               

            Session["ACarreras"] = HttpUtility.HtmlEncode(innerHtml.ToString());
        }
    }
}