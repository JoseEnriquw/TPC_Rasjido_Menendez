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
    public partial class Mesa : System.Web.UI.Page
    {

        public Dominio.Mesa mesa;

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
            mesa = new Dominio.Mesa();
            mesa = ((Dominio.Mesa)Session["MesaActual"]);

            if (Request.QueryString["Id"] != null)
            {
                int idInsumo = int.Parse(Request.QueryString["id"]);
                               

            if (mesa.Pedidos.ListaItems == null)
            {
                    mesa.Pedidos = new Pedido();
                    mesa.Pedidos.ListaItems = new List<ItemsPedidos>();
                    ItemsPedidos AuxItem = new ItemsPedidos();
                AuxItem.Item = new Insumo();
                AuxItem.Item = ((List<Insumo>)Session["ListadoMenu"]).Find(x => x.Id == idInsumo);
                AuxItem.Cantidad++;
                mesa.Pedidos.PrecioTotal = AuxItem.PrecioSubTotal =AuxItem.Item.Precio;
                    mesa.Pedidos.FechaHora = DateTime.Now;
                    mesa.Pedidos.Estado = true;
                mesa.Pedidos.ListaItems.Add(AuxItem);

            }
            else
            {
                    int pos = -1;
                    int cont = 0;

                    foreach (ItemsPedidos item in mesa.Pedidos.ListaItems)
                    {
                        if (item.Item.Id == idInsumo) pos = cont;

                        cont++;
                    }

                    if (pos == -1)
                    {
                        ItemsPedidos aux = new ItemsPedidos();
                        aux.Item = ((List<Dominio.Insumo>)Session["ListadoMenu"]).Find(x => x.Id == idInsumo);
                        aux.Cantidad++;
                        aux.PrecioSubTotal = aux.Item.Precio;
                        mesa.Pedidos.ListaItems.Add(aux);

                    }
                    else
                    {
                        mesa.Pedidos.ListaItems[pos].Cantidad++;
                        mesa.Pedidos.ListaItems[pos].PrecioSubTotal = mesa.Pedidos.ListaItems[pos].Cantidad * mesa.Pedidos.ListaItems[pos].Item.Precio;
                    }

            }
                int posicion = ((List<Dominio.Mesa>)Session["MesasMesero"]).FindIndex(x => x.NumeroMesa == mesa.NumeroMesa);
                 ((List<Dominio.Mesa>)Session["MesasMesero"])[posicion] = mesa;


              
            }

            if (mesa.Pedidos.ListaItems != null)
            {
                List<ItemsPedidos> aux = new List<ItemsPedidos>();
                aux = mesa.Pedidos.ListaItems;
                RepeaterMesa.DataSource = aux;
                RepeaterMesa.DataBind();
                int cont = 0;
                foreach (ItemsPedidos item in mesa.Pedidos.ListaItems)
                {
                    ((TextBox)RepeaterMesa.Items[cont].FindControl("txtCantidad")).Text = item.Cantidad.ToString();
                    cont++;
                }

            }

        }
    }
}