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
        public int CantTotalInsumos;
        public int idInsumo;
      

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


            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null) {
                    if (validarIdInsumo(int.Parse(Request.QueryString["id"]))) { idInsumo = 0; }
                    else 
                    {
                        idInsumo = int.Parse(Request.QueryString["id"]);
                        Session["IdActual"] = idInsumo;
                    }
                }
                else { idInsumo =0; }
            }



            if (mesa.Pedidos.ListaItems == null && idInsumo > 0)
            {

                CantTotalInsumos = 0;
                mesa.Pedidos = new Pedido();
                mesa.Pedidos.ListaItems = new List<ItemsPedidos>();
                ItemsPedidos AuxItem = new ItemsPedidos();
                AuxItem.Item = new Insumo();
                AuxItem.Item = ((List<Insumo>)Session["ListadoMenu"]).Find(x => x.Id == idInsumo);
                AuxItem.Cantidad++;
                mesa.Pedidos.PrecioTotal = AuxItem.PrecioSubTotal = AuxItem.Item.Precio;
                mesa.Pedidos.FechaHora = DateTime.Now;
                mesa.Pedidos.Estado = true;
                mesa.Pedidos.ListaItems.Add(AuxItem);
               
            }else if(idInsumo > 0 )
            {

                    ItemsPedidos aux = new ItemsPedidos();
                    aux.Item = ((List<Dominio.Insumo>)Session["ListadoMenu"]).Find(x => x.Id == idInsumo);
                    if ((aux.Cantidad) <= aux.Item.Stock)
                    {
                        aux.Cantidad++;
                        aux.PrecioSubTotal = aux.Item.Precio;
                        mesa.Pedidos.ListaItems.Add(aux);
                        mesa.Pedidos.PrecioTotal += aux.PrecioSubTotal;
                    }
            
                
            }
            else if (mesa.Pedidos.ListaItems != null)
            {
                int cont = 0;
                mesa.Pedidos.PrecioTotal = 0;
                foreach (ItemsPedidos item in mesa.Pedidos.ListaItems)
                {

                    if (int.Parse(((TextBox)RepeaterMesa.Items[cont].FindControl("txtCantidad")).Text) <= mesa.Pedidos.ListaItems[cont].Item.Stock)
                    {
                        mesa.Pedidos.ListaItems[cont].Cantidad = int.Parse(((TextBox)RepeaterMesa.Items[cont].FindControl("txtCantidad")).Text);
                        mesa.Pedidos.ListaItems[cont].PrecioSubTotal = mesa.Pedidos.ListaItems[cont].Cantidad * mesa.Pedidos.ListaItems[cont].Item.Precio;

                    }
                    mesa.Pedidos.PrecioTotal += item.PrecioSubTotal;
                    cont++;
                }
              
            }
           
            

            if (mesa.Pedidos.ListaItems != null)
            {
                List<ItemsPedidos> aux = new List<ItemsPedidos>();
                aux = mesa.Pedidos.ListaItems;
                RepeaterMesa.DataSource = aux;
                RepeaterMesa.DataBind();

                int cont = CantTotalInsumos= 0;
                foreach (ItemsPedidos item in mesa.Pedidos.ListaItems)
                {
                    ((TextBox)RepeaterMesa.Items[cont].FindControl("txtCantidad")).Text = item.Cantidad.ToString();
                    CantTotalInsumos += item.Cantidad;
                    cont++;
                }
                int posicion = ((List<Dominio.Mesa>)Session["MesasMesero"]).FindIndex(x => x.NumeroMesa == mesa.NumeroMesa);
                ((List<Dominio.Mesa>)Session["MesasMesero"])[posicion] = mesa;
            
            }

            
        }

        public bool validarIdInsumo(int id)
        {
            bool resultado = false;

            if (mesa.Pedidos.ListaItems != null)
            {
                foreach (Dominio.ItemsPedidos item in mesa.Pedidos.ListaItems)
                {
                    if (item.Item.Id == id) resultado = true;
                }
            }

            return resultado;
        }

        ////TexChange
        //protected void cantidad_ontexchange(object sender, EventArgs e)
        //{
        //    int argument = int.Parse(((Button)sender).CommandArgument);
        //    int pos = mesa.Pedidos.ListaItems.FindIndex(x => x.Item.Id == argument);
        //    int cant = mesa.Pedidos.ListaItems[pos].Cantidad;

        //    if (int.Parse(((TextBox)RepeaterMesa.Items[pos].FindControl("txtCantidad")).Text) <= mesa.Pedidos.ListaItems[pos].Item.Stock)
        //        {                  
        //            mesa.Pedidos.ListaItems[pos].Cantidad = int.Parse(((TextBox)RepeaterMesa.Items[pos].FindControl("txtCantidad")).Text);
        //            mesa.Pedidos.ListaItems[pos].PrecioSubTotal = mesa.Pedidos.ListaItems[pos].Cantidad * mesa.Pedidos.ListaItems[pos].Item.Precio;
        //            mesa.Pedidos.PrecioTotal += ((mesa.Pedidos.ListaItems[pos].Cantidad - cant)* mesa.Pedidos.ListaItems[pos].Item.Precio);
        //        CantTotalInsumos += mesa.Pedidos.ListaItems[pos].Cantidad - cant;
        //        }
           
           
        //    List<ItemsPedidos> aux = new List<ItemsPedidos>();
        //    aux = mesa.Pedidos.ListaItems;
        //    RepeaterMesa.DataSource = aux;
        //    RepeaterMesa.DataBind();
        //    ((TextBox)RepeaterMesa.Items[pos].FindControl("txtCantidad")).Text = mesa.Pedidos.ListaItems[pos].Cantidad.ToString();
        //    int posicion = ((List<Dominio.Mesa>)Session["MesasMesero"]).FindIndex(x => x.NumeroMesa == mesa.NumeroMesa);
        //    ((List<Dominio.Mesa>)Session["MesasMesero"])[posicion] = mesa;
         
        //}

     
    }
}