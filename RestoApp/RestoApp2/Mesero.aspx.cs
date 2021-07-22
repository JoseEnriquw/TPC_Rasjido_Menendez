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
        public Consultas logueo = new Consultas();
        public string prueba = " ";
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
           
            try
            {
                int id = ((Dominio.Persona)Session["UserLog"]).Id;
                List<Dominio.Mesa> listaprueba = new List<Dominio.Mesa>();
                listaprueba = ((List<Dominio.Mesa>)Session["MesasGerente"]);
                    ListaMesas = new List<Dominio.Mesa>();




                if (((Dominio.Persona)Session["UserLog"]).Cargo.Descripcion != "Gerente")
                {
                    ListaMesas = VistaMesero(listaprueba,id);
                if (Session["MesasMesero"] == null)
                {
                    Session["MesasMesero"] = ListaMesas;
                }
                else
                {
                    Session["MesasMesero"] = VistaMesero(((List<Dominio.Mesa>)Session["MesasMesero"]), id);
                }
                }
                else
                {
                        ListaMesas = ((List<Dominio.Mesa>)Session["MesasGerente"]);
                }




                RepeaterMesero.DataSource = ListaMesas;
                    RepeaterMesero.DataBind();


               

                int cont = 0;
                foreach (Dominio.Mesa item in ListaMesas)
                {
                    if (item.Estado.ToUpper() == "LIBRE")
                    {
                        ((Button)RepeaterMesero.Items[cont].FindControl("ButtonOpc")).Enabled = true;
                        ((Button)RepeaterMesero.Items[cont].FindControl("ButtonOpc")).Text = "ABRIR MESA";
                    }else if (item.Estado.ToUpper() == "ABIERTO")
                    {
                        ((Button)RepeaterMesero.Items[cont].FindControl("ButtonOpc")).Enabled = true;
                        ((Button)RepeaterMesero.Items[cont].FindControl("ButtonOpc")).Text = "VER PEDIDOS";
                    }
                    else
                    {
                        ((Button)RepeaterMesero.Items[cont].FindControl("ButtonOpc")).Enabled = false;
                        ((Button)RepeaterMesero.Items[cont].FindControl("ButtonOpc")).Text = "MESA EN ATENCION";
                    }
                    if(item.Estado.ToUpper()== "ABIERTO" && ((Dominio.Persona)Session["UserLog"]).Cargo.Descripcion == "Gerente")
                    {
                        ((Button)RepeaterMesero.Items[cont].FindControl("ButtonOpc")).Enabled = true;
                        ((Button)RepeaterMesero.Items[cont].FindControl("ButtonOpc")).Text = "VER PEDIDOS DE "+ item.Mesero.Nombre.ToUpper() + " " + item.Mesero.Apellido.ToUpper();
                    }
                    cont++;
                }
            }
            catch (Exception ex)
            {
               Response.Redirect("Error.aspx");
                throw ex;
            }

        }

        protected void AbrirMesa(object sender, EventArgs e)
        {
            int argument = int.Parse(((Button)sender).CommandArgument);
            int pos = ((List<Dominio.Mesa>)Session["MesasGerente"]).FindIndex(x => x.NumeroMesa == argument);
            ((List<Dominio.Mesa>)Session["MesasGerente"])[pos].Estado ="abierto";
            if (((Dominio.Persona)Session["UserLog"]).Cargo.Descripcion != "Gerente") { 
            ((List<Dominio.Mesa>)Session["MesasGerente"])[pos].Mesero = ((Dominio.Persona)Session["UserLog"]);
            }
            Session["MesaActual"] = ((List<Dominio.Mesa>)Session["MesasGerente"])[pos];
            
            Response.Redirect("Mesa.aspx");
        }

        public List<Dominio.Mesa> VistaMesero(List<Dominio.Mesa> lista,int id)
        {
            for (int i = 0; i < lista.Count(); i++)
            {

                if (lista[i].Mesero.Id != id && lista[i].Estado == "abierto")
                {
                    lista[i].Estado = "cerrado";
                }
                else if (lista[i].Mesero.Id == id && lista[i].Estado == "cerrado") {
                    lista[i].Estado = "abierto"; 
                }

            }
            return lista;
        }


    }
}