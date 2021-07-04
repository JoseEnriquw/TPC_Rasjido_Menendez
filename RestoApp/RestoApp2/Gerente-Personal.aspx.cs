using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace RestoApp2
{
    public partial class Gerente_Personal : System.Web.UI.Page
    {
        public List<Persona> Personalista=new List<Persona>();
        protected void Page_Load(object sender, EventArgs e)
        {
            Consultas personal = new Consultas();
            try
            {
                Personalista = personal.ListarPersona("");
                Session.Add("listadoPersonal", Personalista);
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
            }
        }
    }
}