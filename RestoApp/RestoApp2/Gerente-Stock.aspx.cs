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
    public partial class Gerente_Stock : System.Web.UI.Page
    {
        public List<Insumo> StockLista;
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
            Consultas GerenteMenu = new Consultas();

            if (!IsPostBack) { 
            try
            {
                StockLista = new List<Insumo>();
                StockLista = GerenteMenu.ListarInsumos("");
                Session.Add("ListadoStock", StockLista);

                repeaterStock.DataSource = StockLista;
                repeaterStock.DataBind();

                int cont = 0;
                foreach (Insumo item in StockLista)
                {
                    ((TextBox)repeaterStock.Items[cont].FindControl("Cantidad")).Text = item.Stock.ToString();
                    cont++;
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());

            }
            }
        }

        protected void OnTextChanged_Filtros(object sender, EventArgs e)
        {
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
            }

        }

        protected void actualizar(object sender, EventArgs e)
        {
            var argument = ((Button)sender).CommandArgument;
            Consultas insumos = new Consultas();
            Insumo aux = new Insumo();

            int cont = 0;
            foreach (Insumo item in ((List<Insumo>)Session["ListadoStock"]))
            {
                if (argument == item.Id.ToString()
                    && ((TextBox)repeaterStock.Items[cont].FindControl("Cantidad")).Text != "")
                {
                    aux.Id = item.Id;
                    aux.Nombre = item.Nombre;
                    aux.Categoria = item.Categoria;
                    aux.Tipo = item.Tipo;
                    aux.UrlImagen = item.UrlImagen;
                    aux.Precio = item.Precio;
                    aux.Stock = short.Parse(((TextBox)repeaterStock.Items[cont].FindControl("Cantidad")).Text);

                    insumos.actualizarInsumo(true, aux);
                }
                cont++;
            }
        }

        protected void borrar(object sender, EventArgs e)
        {
            var argument = ((Button)sender).CommandArgument;
            Consultas insumos = new Consultas();
            Insumo aux = new Insumo();

            int cont = 0;
            foreach (Insumo item in ((List<Insumo>)Session["ListadoStock"]))
            {
                if (argument == item.Id.ToString()
                    && ((TextBox)repeaterStock.Items[cont].FindControl("Cantidad")).Text != "")
                {
                    aux.Id = item.Id;
                    aux.Nombre = item.Nombre;
                    aux.Categoria = item.Categoria;
                    aux.Tipo = item.Tipo;
                    aux.UrlImagen = item.UrlImagen;
                    aux.Precio = item.Precio;
                    aux.Stock = short.Parse(((TextBox)repeaterStock.Items[cont].FindControl("Cantidad")).Text);

                    insumos.actualizarInsumo(false, aux);
                }
                cont++;
            }
        }
    }
}