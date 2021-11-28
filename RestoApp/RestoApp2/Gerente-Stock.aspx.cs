﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Dominio.Filtros;
using Negocio;

namespace RestoApp2
{
    public partial class Gerente_Stock : System.Web.UI.Page
    {
        public List<Insumo> StockLista;
        public List<Insumo> StockListaACT;
        public List<Insumo> StockListaINA;
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
            Consultas GerenteMenu = new Consultas();
            NegocioInsumos negocioInsumos = new NegocioInsumos();
            if (!IsPostBack)
            {
                try
                {
                    FiltrosInsumos filtros = new FiltrosInsumos();
                    filtros.baja = true;
                    StockLista = new List<Insumo>();
                    StockListaACT = new List<Insumo>();
                    StockListaINA = new List<Insumo>();
                    StockLista = negocioInsumos.GetAllInsumos(filtros);
                    Session.Add("ListadoStock", StockLista);

                    foreach (Insumo item in StockLista)
                    {
                        if (item.Baja)
                        {
                            StockListaACT.Add(item);
                        }
                        else
                        {
                            StockListaINA.Add(item);
                        }
                    }

                    repeaterStock.DataSource = StockListaACT;
                    repeaterStock.DataBind();
                    repeaterStock2.DataSource = StockListaINA;
                    repeaterStock2.DataBind();


                }
                catch (Exception ex)
                {
                    Session.Add("Error", ex.ToString());

                }
            }
        }

        protected void OnTextChanged_Filtros(object sender, EventArgs e)
        {
            /*
            string Insumo = TB_Insumo.Text;
            string Precio = TB_Precio.Text;
            string Cantidad = TB_Cantidad.Text;


            //Los 3 tienen datos
            if (Insumo != " " && Precio != " " && Cantidad != " ")
            {
                StockLista = ((List<Insumo>)Session["ListadoStock"]).FindAll(x => x.Nombre.ToUpper().Contains(Insumo.ToUpper()) && x.Precio.ToString().ToUpper().Contains(Precio.ToUpper()) && x.Stock.ToString().ToUpper().Contains(Cantidad.ToUpper()));

            }
            //INSUMO no tiene Datos y los demas si
            else if (Insumo == " " && Precio != " " && Cantidad != " ")
            {
                StockLista = ((List<Insumo>)Session["ListadoStock"]).FindAll(x => x.Precio.ToString().ToUpper().Contains(Precio.ToUpper()) && x.Stock.ToString().ToUpper().Contains(Cantidad.ToUpper()));

            }
            //PRECIO no tine datos y los demas si
            else if (Insumo != " " && Precio == " " && Cantidad != " ")
            {
                StockLista = ((List<Insumo>)Session["ListadoStock"]).FindAll(x => x.Nombre.ToUpper().Contains(Insumo.ToUpper()) && x.Stock.ToString().ToUpper().Contains(Cantidad.ToUpper()));

            }
            //CANTIDAD no tiene datos y los demas si 
            else if (Insumo != " " && Precio != " " && Cantidad == " ")
            {
                StockLista = ((List<Insumo>)Session["ListadoStock"]).FindAll(x => x.Nombre.ToUpper().Contains(Insumo.ToUpper()) && x.Precio.ToString().ToUpper().Contains(Precio.ToUpper()));

            }
            //Solo INSUMO tiene datos
            else if (Insumo != " " && Precio == " " && Cantidad == " ")
            {
                StockLista = ((List<Insumo>)Session["ListadoStock"]).FindAll(x => x.Nombre.ToUpper().Contains(Insumo.ToUpper()));

            }
            //Solo PRECIO tiene datos
            else if (Insumo == " " && Precio != " " && Cantidad == " ")
            {
                StockLista = ((List<Insumo>)Session["ListadoStock"]).FindAll(x => x.Precio.ToString().ToUpper().Contains(Precio.ToUpper()));

            }
            //Solo CANTIDAD tiene datos
            else if (Insumo == " " && Precio == " " && Cantidad != " ")
            {
                StockLista = ((List<Insumo>)Session["ListadoStock"]).FindAll(x => x.Stock.ToString().ToUpper().Contains(Cantidad.ToUpper()));

            }
            else
            {
                StockLista = ((List<Insumo>)Session["ListadoStock"]);
            }*/

        }
        protected void Confirmacion(object sender, EventArgs e)
        {
            var argument = ((Button)sender).CommandArgument;

            si.CommandArgument = argument;
            string javaScript = "abrirventanaEmerg()";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
        }

        protected void Actualizar(object sender, EventArgs e)
        {


            var argument = ((Button)sender).CommandArgument;
            Consultas insumos = new Consultas();
            Insumo aux = new Insumo();

            int pos = 0;
            int cont = 0;
            foreach (Insumo item in ((List<Insumo>)Session["ListadoStock"]))
            {
                string auxtext = ((TextBox)repeaterStock.Items[cont].FindControl("CantidadNueva")).Text;
                if (int.Parse(argument) == item.Id
                    && auxtext != "")
                {
                    aux.Id = item.Id;
                    aux.Nombre = item.Nombre;
                    aux.Categoria = item.Categoria;
                    aux.Tipo = item.Tipo;
                    aux.UrlImagen = item.UrlImagen;
                    aux.Precio = item.Precio;
                    aux.Stock = item.Stock;
                    aux.Stock+= short.Parse(((TextBox)repeaterStock.Items[cont].FindControl("CantidadNueva")).Text);
                    aux.Baja = item.Baja;

                    pos = cont;
                    insumos.ActualizarInsumo(true, aux);
                    ((List<Insumo>)Session["ListadoStock"])[pos] = aux;

                    repeaterStock.DataSource = ((List<Insumo>)Session["ListadoStock"]);
                    repeaterStock.DataBind();
                    Response.Redirect("Gerente-Stock.aspx");

                }
                if(item.Baja) cont++;
            }

          
        }

       
        
    }
}