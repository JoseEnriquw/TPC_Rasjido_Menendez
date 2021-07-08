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

            Consultas logueo = new Consultas();

                ListaMesas = new List<Dominio.Mesa>();
                logueo.mesasPriv = logueo.VistaMesero(logueo.mesasPubl);
                ListaMesas = logueo.mesasPriv;
                Session.Add("ListadoMesa", ListaMesas);

        }
    }
}