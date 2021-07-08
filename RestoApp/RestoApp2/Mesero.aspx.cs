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
    public partial class Mesero : System.Web.UI.Page
    {
        public List<Dominio.Mesa> ListaMesas;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(Request.QueryString["id"]);

                Consultas logueo = new Consultas();
                ListaMesas = new List<Dominio.Mesa>();


                //Esta funcion esta de prueba (usar el session del inicio.aspx.cs
                logueo.mesasPubl = logueo.CrearMesas();


                ListaMesas = logueo.VistaMesero(logueo.mesasPubl);
                Session.Add("ListadoMesa", ListaMesas);
            }
            catch (Exception ex)
            {
                Response.Redirect("Error.aspx");
                throw ex;
            }
        }
    }
}