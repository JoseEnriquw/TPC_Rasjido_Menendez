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
            try
            {

                int id = ((Dominio.Persona)Session["UserLog"]).Id;
                List<Dominio.Mesa> listaprueba = new List<Dominio.Mesa>();
                listaprueba = ((List<Dominio.Mesa>)Session["MesasGerente"]);
                    ListaMesas = new List<Dominio.Mesa>();
                    
               
                    //Esta funcion esta de prueba (usar el session del inicio.aspx.cs
                   ListaMesas = VistaMesero(listaprueba,id);
             
                    RepeaterMesero.DataSource = ListaMesas;
                    RepeaterMesero.DataBind();
               
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
            ((List<Dominio.Mesa>)Session["MesasGerente"])[pos].Mesero = ((Dominio.Persona)Session["UserLog"]);

            Response.Redirect("Mesa.aspx");
            //((Button)sender).Text=
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