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
    public partial class Menu : System.Web.UI.Page
    {
        public List<Insumo> listaMenu;
        protected void Page_Load(object sender, EventArgs e)
        {
            Consultas menu = new Consultas();
            try
            {
                listaMenu = menu.ListarInsumos("");
                Session.Add("listadoMenu", listaMenu);
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
            }
        }
    }
}