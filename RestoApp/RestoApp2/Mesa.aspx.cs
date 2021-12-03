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
        public decimal CostoEstimadoTotal;


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

                    }
                    else if (((Dominio.Persona)Session["UserLog"]).Cargo.Descripcion == "Gerente")
                    {
                        ((Label)Master.FindControl("OPCMESERO")).Visible = false;
                        ((Label)Master.FindControl("OPCGERENTE")).Visible = true;
                    }
                    Persona auxSession = new Persona();
                    auxSession = ((Dominio.Persona)Session["UserLog"]);
                    Session["UserLog"] = auxSession;
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

            mesa = ((Dominio.Mesa)Session["MesaActual"]);

            if (!IsPostBack)
            {

                //Se obtiene el ID_Insumo
                if (Request.QueryString["id"] != null || idInsumo != 0)
                {
                    idInsumo = int.Parse(Request.QueryString["id"]);
                }
                else
                {
                    idInsumo = 0;
                }
                int cant = 0;

                //Se obtiene la cantidad de Items en la mesa actual
                if (((Dominio.Mesa)Session["MesaActual"]).Pedidos.ListaItems != null)
                {
                    cant = ((Dominio.Mesa)Session["MesaActual"]).Pedidos.ListaItems.Count();
                }
                else
                {
                    cant = 0;
                }

                //Comprueba si se selecciono algo
                if (idInsumo != 0)
                {
                    ItemsPedidos AuxItem = new ItemsPedidos();
                    AuxItem.Item = new Insumo();
                    Insumo ItemAux = new Insumo();

                    //Si esta vacia - el primer obj
                    if (((Dominio.Mesa)Session["MesaActual"]).Pedidos.ListaItems == null)
                    {

                        CantTotalInsumos = 0;

                        ((Dominio.Mesa)Session["MesaActual"]).Pedidos = new Pedido();
                        ((Dominio.Mesa)Session["MesaActual"]).Pedidos.ListaItems = new List<ItemsPedidos>();

                        AuxItem.Item = ((List<Insumo>)Session["ListadoMenu"]).Find(x => x.Id == idInsumo);
                        AuxItem.Cantidad++;
                        AuxItem.PrecioSubTotal = AuxItem.Item.Precio;

                        ((Dominio.Mesa)Session["MesaActual"]).Pedidos.PrecioTotal = 0;
                        ((Dominio.Mesa)Session["MesaActual"]).Pedidos.FechaHora = DateTime.Now.ToLocalTime();
                        ((Dominio.Mesa)Session["MesaActual"]).Pedidos.Estado = true;

                        int auxpos = 0;
                        int pos = 0;
                        foreach (ItemsPedidos items in ((Dominio.Mesa)Session["MesaActual"]).Pedidos.ListaItems)
                        {
                            if (items.Id == idInsumo) { auxpos = pos; }
                            pos++;
                        }
                        cant = 1;

                        ((Dominio.Mesa)Session["MesaActual"]).Pedidos.ListaItems.Add(AuxItem);

                        ((Dominio.Mesa)Session["MesaActual"]).Pedidos.ListaItems[auxpos].estado = false;

                    }
                    //En caso de haber seleccionado un obj
                    else
                    {
                        AuxItem.Item = ((List<Insumo>)Session["ListadoMenu"]).Find(x => x.Id == idInsumo);

                        bool igual = false;



                        foreach (ItemsPedidos items in ((Dominio.Mesa)Session["MesaActual"]).Pedidos.ListaItems)
                        {
                            if (items.Item.Id == idInsumo && !items.estado)
                            {
                                igual = true;
                            }
                        }
                        //Es repetido
                        if (igual)
                        {
                            int auxpos = 0;
                            int pos = 0;


                            foreach (ItemsPedidos items in ((Dominio.Mesa)Session["MesaActual"]).Pedidos.ListaItems)
                            {
                                if (items.Item.Id == idInsumo && !items.estado)
                                {
                                    auxpos = pos;
                                }
                                pos++;
                            }
                            cant = pos;
                            if (verificarStock(1, ((Dominio.Mesa)Session["MesaActual"]).Pedidos.ListaItems[auxpos].Item.Id))
                            {
                                ((Dominio.Mesa)Session["MesaActual"]).Pedidos.ListaItems[auxpos].Cantidad++;
                                ((Dominio.Mesa)Session["MesaActual"]).Pedidos.ListaItems[auxpos].estado = false;
                                ((Dominio.Mesa)Session["MesaActual"]).Pedidos.ListaItems[auxpos].PrecioSubTotal = ((Dominio.Mesa)Session["MesaActual"]).Pedidos.ListaItems[auxpos].Cantidad * AuxItem.Item.Precio;
                            }
                        }
                        else//Es un nuevo obj
                        {
                            if (verificarStock(1, idInsumo))
                            {
                                AuxItem.Item = ((List<Insumo>)Session["ListadoMenu"]).Find(x => x.Id == idInsumo);
                                AuxItem.Cantidad++;

                                int auxpos = 0;
                                int pos = 0;

                                ((Dominio.Mesa)Session["MesaActual"]).Pedidos.ListaItems.Add(AuxItem);

                                foreach (ItemsPedidos items in ((Dominio.Mesa)Session["MesaActual"]).Pedidos.ListaItems)
                                {
                                    if (items.Item.Id == idInsumo)
                                    {
                                        auxpos = pos;
                                    }
                                    pos++;
                                }
                                cant = pos;

                                ((Dominio.Mesa)Session["MesaActual"]).Pedidos.ListaItems[auxpos].estado = false;

                                ((Dominio.Mesa)Session["MesaActual"]).Pedidos.ListaItems[auxpos].PrecioSubTotal = ((Dominio.Mesa)Session["MesaActual"]).Pedidos.ListaItems[auxpos].Cantidad * ((Dominio.Mesa)Session["MesaActual"]).Pedidos.ListaItems[auxpos].Item.Precio;
                            }
                        }
                    }
                }


                Dominio.Mesa auxRepeater = ((Dominio.Mesa)Session["MesaActual"]);

                List<ItemsPedidos> auxP = new List<ItemsPedidos>();

                //Calcula el precio sub total y total
                mesa.Pedidos.PrecioTotal = 0;
                for (int i = 0; i < cant; i++)
                {
					if (auxRepeater.Pedidos.ListaItems[i].estado) 
                    {
                    mesa.Pedidos.PrecioTotal += auxRepeater.Pedidos.ListaItems[i].PrecioSubTotal;
                    }
								
                    CostoEstimadoTotal += auxRepeater.Pedidos.ListaItems[i].PrecioSubTotal;
                                    
                    auxP.Add(auxRepeater.Pedidos.ListaItems[i]);
                }

                //Asigna datasource
                RepeaterMesa.DataSource = auxP;
                RepeaterMesa.DataBind();


                //Asignacion al repeater
                int cont = 0;
                foreach (ItemsPedidos item in auxP)
                {

                    ((TextBox)RepeaterMesa.Items[cont].FindControl("txtCantidad")).Text = item.Cantidad.ToString();
                    ((Label)RepeaterMesa.Items[cont].FindControl("LabelPrecio")).Text = item.Item.Precio.ToString();

                    if (!item.estado)
                    {
                        ((Label)RepeaterMesa.Items[cont].FindControl("LabelEstado")).Text = "SIN ENTREGAR";
                        ((Label)RepeaterMesa.Items[cont].FindControl("LabelEstado")).ForeColor = System.Drawing.Color.IndianRed;
                    }
                    else
                    {
                        ((Label)RepeaterMesa.Items[cont].FindControl("LabelEstado")).Text = "ENTREGADO";
                        ((Button)RepeaterMesa.Items[cont].FindControl("ButtonDelete")).Text = "CAMBIAR";
                        ((Button)RepeaterMesa.Items[cont].FindControl("ButtonEntrega")).Enabled = false;
                        ((Button)RepeaterMesa.Items[cont].FindControl("ButtonEntrega")).Visible = false;
                        ((Button)RepeaterMesa.Items[cont].FindControl("ButtonUpdate")).Enabled = false;
                        ((Button)RepeaterMesa.Items[cont].FindControl("ButtonUpdate")).Visible = false;
                        ((TextBox)RepeaterMesa.Items[cont].FindControl("txtCantidad")).Enabled = false;
                        ((Label)RepeaterMesa.Items[cont].FindControl("LabelEstado")).ForeColor = System.Drawing.Color.ForestGreen;
                    }

                    CantTotalInsumos += item.Cantidad;
                    cont++;
                }

                //Actualizacion al Session
                int posicion = ((List<Dominio.Mesa>)Session["MesasMesero"]).FindIndex(x => x.NumeroMesa == ((Dominio.Mesa)Session["MesaActual"]).NumeroMesa);
                ((List<Dominio.Mesa>)Session["MesasMesero"])[posicion] = ((Dominio.Mesa)Session["MesaActual"]);


                if (idInsumo != 0) { Response.Redirect("Mesa.aspx?id=0"); }
            }
        }

        //Actualiza la cantidad del Pedido con la cantidad que hay en TextBox
        protected void Actualizar(object sender, EventArgs e)
        {
            var argument = ((Button)sender).CommandArgument;

            int pos = mesa.Pedidos.ListaItems.FindIndex(x => x.Item.Id == int.Parse(argument) && x.estado == false);

            int cantAux = int.Parse(((TextBox)RepeaterMesa.Items[pos].FindControl("txtCantidad")).Text);
            //A verificarStock se le manda como parametros la cantidad a agregar y el id del insumo, para ver si hay en stock la cantidad solicitada 
            if (verificarStock(cantAux - mesa.Pedidos.ListaItems[pos].Cantidad, mesa.Pedidos.ListaItems[pos].Item.Id))
            {
                mesa.Pedidos.ListaItems[pos].Cantidad = cantAux;

                mesa.Pedidos.ListaItems[pos].PrecioSubTotal = cantAux * mesa.Pedidos.ListaItems[pos].Item.Precio;

                int posicion = ((List<Dominio.Mesa>)Session["MesasMesero"]).FindIndex(x => x.NumeroMesa == ((Dominio.Mesa)Session["MesaActual"]).NumeroMesa);
                ((List<Dominio.Mesa>)Session["MesasMesero"])[posicion] = mesa;
            }
            Response.Redirect("Mesa.aspx?id=0");
        }

        protected void Entregado(object sender, EventArgs e)
        {
            var argument = ((Button)sender).CommandArgument;
            int pos = mesa.Pedidos.ListaItems.FindIndex(x => x.Item.Id == int.Parse(argument) && x.estado==false);
            int posaux;

            if((posaux = mesa.Pedidos.ListaItems.FindIndex(x => x.Item.Id == int.Parse(argument) && x.estado == true)) >= 0)
			{

                mesa.Pedidos.ListaItems[posaux].Cantidad += mesa.Pedidos.ListaItems[pos].Cantidad;
                mesa.Pedidos.ListaItems[posaux].PrecioSubTotal += mesa.Pedidos.ListaItems[pos].PrecioSubTotal;
                mesa.Pedidos.ListaItems.RemoveAt(pos);

            }
			else 
            { 
            mesa.Pedidos.ListaItems[pos].estado = true;                         
            }

            int posicion = ((List<Dominio.Mesa>)Session["MesasMesero"]).FindIndex(x => x.NumeroMesa == ((Dominio.Mesa)Session["MesaActual"]).NumeroMesa);
            ((List<Dominio.Mesa>)Session["MesasMesero"])[posicion] = mesa;
            Response.Redirect("Mesa.aspx?id=0");
        }

        protected void Eliminar(object sender, EventArgs e)
        {

            var argument = ((Button)sender).CommandArgument;
            int pos = mesa.Pedidos.ListaItems.FindIndex(x => x.Item.Id == int.Parse(argument));
            ItemsPedidos elim = mesa.Pedidos.ListaItems.Find(x => x.Item.Id == int.Parse(argument));

            mesa.Pedidos.ListaItems.Remove(elim);

            int posicion = ((List<Dominio.Mesa>)Session["MesasMesero"]).FindIndex(x => x.NumeroMesa == ((Dominio.Mesa)Session["MesaActual"]).NumeroMesa);
            ((List<Dominio.Mesa>)Session["MesasMesero"])[posicion] = mesa;

            if (((Button)sender).Text == "ELIMINAR") { Response.Redirect("Mesa.aspx?id=0"); }
            else
            {
                ((Button)sender).Text = "ELIMINAR";
                Response.Redirect("Menu.aspx");
            }
        }

        protected void Cambio(object sender, EventArgs e)
        {
            /*
            Response.Redirect("Error.aspx");*/
        }

        protected void volverMenu(object sender, EventArgs e)
        {
            Response.Redirect("Menu.aspx");
        }

        protected void volverMesero(object sender, EventArgs e)
        {
            Response.Redirect("Mesero.aspx");
        }

        protected void CerrarMesa(object sender, EventArgs e)
        {
            
            Consultas aux = new Consultas();
            bool pedidovalido = false;

            int pos = ((List<Dominio.Mesa>)Session["MesasMesero"]).FindIndex(x => x.NumeroMesa == ((Dominio.Mesa)Session["MesaActual"]).NumeroMesa);


            if (((List<Dominio.Mesa>)Session["MesasMesero"])[pos].Pedidos.ListaItems != null) {
				foreach (var item in ((List<Dominio.Mesa>)Session["MesasMesero"])[pos].Pedidos.ListaItems)
				{
                    if (item.estado) pedidovalido = true;
				}
				if (pedidovalido) { 
            aux.IngresarPedido(((List<Dominio.Mesa>)Session["MesasMesero"])[pos]);

            int id = ((List<Dominio.Mesa>)Session["MesasMesero"])[pos].NumeroMesa;
            string nombre = ((List<Dominio.Mesa>)Session["MesasMesero"])[pos].Nombre;

            ((List<Dominio.Mesa>)Session["MesasMesero"])[pos] = new Dominio.Mesa(id, nombre);

            

            Response.Redirect("Mesero.aspx");
                }
            }

        }

        public bool verificarStock(int cantpedida, int id)
        {
            bool result = false;
            int stock = ((List<Insumo>)Session["ListadoMenu"]).Find(x => x.Id == id).Stock;
            int pos = 0;

            foreach (var item in ((List<Dominio.Mesa>)Session["MesasMesero"]))
            {

                if (item.Pedidos.ListaItems != null)
                {
                    if ((pos = item.Pedidos.ListaItems.FindIndex(x => x.Item.Id == id && x.estado == true)) >= 0)
                    {
                        stock -= item.Pedidos.ListaItems[pos].Cantidad;
                    }
                    if ((pos = item.Pedidos.ListaItems.FindIndex(x => x.Item.Id == id && x.estado == false)) >= 0)
                    {
                        stock -= item.Pedidos.ListaItems[pos].Cantidad;
                    }
                }



            }

            result = ((stock - cantpedida) >= 0);


            return result;
        }
    }
}