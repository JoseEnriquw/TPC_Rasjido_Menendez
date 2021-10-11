using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace RestoApp2
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void CerrarSesion(object sender, EventArgs e)
        {
            Persona userLog = new Persona();
            userLog = null;
            Session["UserLog"] = userLog;

            Response.Redirect("inicio.aspx");
        }
    }
}