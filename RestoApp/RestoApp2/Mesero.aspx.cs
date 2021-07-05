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
        protected void Page_Load(object sender, EventArgs e)
        {
            Consultas menu = new Consultas();
            int idMesero = int.Parse(Request.QueryString["id"]);
            try
            {
                for (int x = 0; x < menu.listaMesa.Count(); x++)
                {
                    //La mesa esta abierta y sin mesero
                    if (menu.listaMesa[x].Mesero == null)
                    {
                        menu.listaMesa[x].Estado = "libre";
                    }
                    //La mesa esta abierta y con el mesero logueado
                    else if (menu.listaMesa[x].Mesero.Id == idMesero && menu.listaMesa[x].Estado == "abierto")
                    {
                        menu.listaMesa[x].Estado = "abierto";
                    }
                    else
                    {
                        menu.listaMesa[x].Estado = "cerrado";
                    }

                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
            }
        }
    }
}