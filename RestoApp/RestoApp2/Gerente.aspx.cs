using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace RestoApp2
{
    public partial class Gerente : System.Web.UI.Page
    {
        public int cantidadMesas;
        public Consultas gerente = new Consultas();
        public int coloropc;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserLog"] != null)
                {

                    if (((Dominio.Persona)Session["UserLog"]).Cargo.Descripcion == "Empleado")
                    {
                        ((Label)Master.FindControl("OPCMESERO")).Visible = true;
                        ((Label)Master.FindControl("OPCGERENTE")).Visible = false;
                        Response.Redirect("Inicio.aspx");
                    }
                    else if (((Dominio.Persona)Session["UserLog"]).Cargo.Descripcion == "Gerente")
                    {
                        ((Label)Master.FindControl("OPCMESERO")).Visible = false;
                        ((Label)Master.FindControl("OPCGERENTE")).Visible = true;
                    }
                }
                else
                {
                    ((Label)Master.FindControl("OPCMESERO")).Visible = false;
                    ((Label)Master.FindControl("OPCGERENTE")).Visible = false;
                    Response.Redirect("Inicio.aspx");

                }
            }
            catch (Exception)
            {
                //Acción cerrar Sesion
                Session["UserLog"] = null;
                Response.Redirect("Inicio.aspx");
            }
            cantidadMesas = gerente.CantidadMesas();
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

        protected void HistorialMensual(object sender, EventArgs e)
        {
            btnHistorialOPC.Text = "CONTINUAR";
            List<HistorialPedido> list = new List<HistorialPedido>();
            list = gerente.ListarHistorialPedido("where MONTH(FechaHora) = MONTH(GETDATE()) and YEAR(FechaHora) = YEAR(GETDATE())");
            repeaterHistorial.DataSource = list;
            repeaterHistorial.DataBind();

            int cont_1 = 0;
            decimal cont_2 = 0;
            foreach (HistorialPedido item in list)
            {
                cont_1++;
                cont_2 += item.Total;
            }
            informacion.Text = "En el Mes hubo " + cont_1 + " ventas, recuadando un total de $" + cont_2;

            string javaScript = "abrirlistaEmerg()";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
        }

        protected void HistorialSemanal(object sender, EventArgs e)
        {
            btnHistorialOPC.Text = "CONTINUAR";
            List<HistorialPedido> list = new List<HistorialPedido>();
            list = gerente.ListarHistorialPedido("where DATEPART(WEEK,FechaHora) = datepart(week,GETDATE())");
            repeaterHistorial.DataSource = list;
            repeaterHistorial.DataBind();

            int cont_1 = 0;
            decimal cont_2 = 0;
            foreach (HistorialPedido item in list)
            {
                cont_1++;
                cont_2 += item.Total;
            }
            informacion.Text = "En la Semana hubo " + cont_1 + " ventas, recuadando un total de $" + cont_2;

            string javaScript = "abrirlistaEmerg()";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
        }

        protected void HistorialDiario(object sender, EventArgs e)
        {
            btnHistorialOPC.Text = "CONTINUAR";
            List<HistorialPedido> list = new List<HistorialPedido>();
            list = gerente.ListarHistorialPedido("where CAST(FechaHora as date) = CAST(GETDATE() as date)");
            repeaterHistorial.DataSource = list;
            repeaterHistorial.DataBind();

            int cont_1 = 0;
            decimal cont_2 = 0;
            foreach (HistorialPedido item in list)
            {
                cont_1++;
                cont_2 += item.Total;
            }
            informacion.Text = "En el dia hubo " + cont_1 + " ventas, recuadando un total de $" + cont_2;

            string javaScript = "abrirlistaEmerg()";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
        }

        protected void HistorialItems(object sender, EventArgs e)
        {
            var argument = ((Button)sender).CommandArgument;

            List <HistorialItem> list = new List<HistorialItem>();

            list = gerente.ListarHistorialItem(int.Parse(argument));
            repeaterItemH.DataSource = list;
            repeaterItemH.DataBind();

            int cont_1 = 0;
            decimal cont_2 = 0;
            foreach (HistorialItem item in list)
            {
                cont_1++;
                cont_2 += item.Subtotal;
            }
            informacion.Text = "En este pedido se encuentran " + cont_1 + " insumos, recuadando un total de $" + cont_2;

            btnHistorialOPC.Text = "VOLVER";

            string javaScript = "abrirlistaEmerg_2()";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
        }

        protected void HistorialVolver(object sender, EventArgs e)
        {
            if(btnHistorialOPC.Text != "CONTINUAR")
            {
                btnHistorialOPC.Text = "CONTINUAR";
                string javaScript = "abrirlistaEmerg()";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
            }
        }

        protected void Mesas(object sender, EventArgs e)
        {
            string javaScript = "abrirventanaEmerg()";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
        }

    }
}