using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace RestoApp2
{
    public partial class Gerente : System.Web.UI.Page
    {
        public int cantidadMesas;
        public Consultas gerente = new Consultas();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (((Dominio.Persona)Session["UserLog"]).Cargo.Descripcion == "Empleado")
            {
                ((Label)Master.FindControl("OPCMESERO")).Visible = true;
                ((Label)Master.FindControl("OPCGERENTE")).Visible = false;
            }
            else if (((Dominio.Persona)Session["UserLog"]).Cargo.Descripcion == "Gerente")
            {
                ((Label)Master.FindControl("OPCMESERO")).Visible = false;
                ((Label)Master.FindControl("OPCGERENTE")).Visible = true;
            }
            else
            {
                ((Label)Master.FindControl("OPCMESERO")).Visible = false;
                ((Label)Master.FindControl("OPCGERENTE")).Visible = false;
            }
            cantidadMesas = gerente.cantidadMesas();
        }

        protected void NewMesas(object sender, EventArgs e)
        {

            int nuevaCantidad = int.Parse(NewCant.Text);
            if (nuevaCantidad >= 0)
            {
                gerente.MesasInsert(nuevaCantidad, cantidadMesas);
                Session["MesasGerente"] = gerente.CrearMesas();
            }
            Page_Load(sender, e);
        }

        protected void Historial(object sender, EventArgs e)
        {
            string javaScript = "abrirlistaEmerg()";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);

        }

        protected void Mesas(object sender, EventArgs e)
        {
            string javaScript = "abrirventanaEmerg()";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
        }

    }
}