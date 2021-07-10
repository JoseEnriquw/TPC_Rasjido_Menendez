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
    public partial class Gerente_Menu : System.Web.UI.Page
    {
        public List<Insumo> InsumoLista = new List<Insumo>();
        protected void Page_Load(object sender, EventArgs e)
        {
            Consultas GerenteMenu = new Consultas();
            try
            {
                InsumoLista = GerenteMenu.ListarInsumos("");
                Session.Add("ListadoInsumo", InsumoLista);

                repeaterMenu.DataSource = InsumoLista;
                repeaterMenu.DataBind();

                int cont = 0;
                foreach (Insumo item in InsumoLista)
                {
                    ((Image)repeaterMenu.Items[cont].FindControl("Img")).ImageUrl = item.UrlImagen;
                    ((TextBox)repeaterMenu.Items[cont].FindControl("Insumo")).Text = item.Nombre.ToUpper();
                    ((TextBox)repeaterMenu.Items[cont].FindControl("Tipo")).Text = item.Tipo.Descripcion.ToUpper();
                    ((TextBox)repeaterMenu.Items[cont].FindControl("Precio")).Text = item.Precio.ToString();
                    ((TextBox)repeaterMenu.Items[cont].FindControl("Url")).Text = item.UrlImagen;
                    cont++;
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());

            }
        }

        protected void OnTextChanged_Filtros(object sender, EventArgs e)
        {
            string Insumo = TB_Insumo.Text;
            string Precio = TB_Precio.Text;
            string Tipo = TB_Tipo.Text;

            //Los 3 tienen datos
            if (Insumo != " " && Precio != " " && Tipo != " ")
            {
                InsumoLista = ((List<Insumo>)Session["ListadoInsumo"]).FindAll(x => x.Nombre.ToUpper().Contains(Insumo.ToUpper()) && x.Precio.ToString().ToUpper().Contains(Precio.ToUpper()) && x.Categoria.Descripcion.ToUpper().Contains(Tipo.ToUpper()));

            }
            //INSUMO no tiene Datos y los demas si
            else if (Insumo == " " && Precio != " " && Tipo != " ")
            {
                InsumoLista = ((List<Insumo>)Session["ListadoInsumo"]).FindAll(x => x.Precio.ToString().ToUpper().Contains(Precio.ToUpper()) && x.Categoria.Descripcion.ToUpper().Contains(Tipo.ToUpper()));

            }
            //PRECIO no tine datos y los demas si
            else if (Insumo != " " && Precio == " " && Tipo != " ")
            {
                InsumoLista = ((List<Insumo>)Session["ListadoInsumo"]).FindAll(x => x.Nombre.ToUpper().Contains(Insumo.ToUpper()) && x.Categoria.Descripcion.ToUpper().Contains(Tipo.ToUpper()));

            }
            //TIPO no tiene datos y los demas si 
            else if (Insumo != " " && Precio != " " && Tipo == " ")
            {
                InsumoLista = ((List<Insumo>)Session["ListadoInsumo"]).FindAll(x => x.Nombre.ToUpper().Contains(Insumo.ToUpper()) && x.Precio.ToString().ToUpper().Contains(Precio.ToUpper()));

            }
            //Solo INSUMO tiene datos
            else if (Insumo != " " && Precio == " " && Tipo == " ")
            {
                InsumoLista = ((List<Insumo>)Session["ListadoInsumo"]).FindAll(x => x.Nombre.ToUpper().Contains(Insumo.ToUpper()));

            }
            //Solo PRECIO tiene datos
            else if (Insumo == " " && Precio != " " && Tipo == " ")
            {
                InsumoLista = ((List<Insumo>)Session["ListadoInsumo"]).FindAll(x => x.Precio.ToString().ToUpper().Contains(Precio.ToUpper()));

            }
            //Solo TIPO tiene datos
            else if (Insumo == " " && Precio == " " && Tipo != " ")
            {
                InsumoLista = ((List<Insumo>)Session["ListadoInsumo"]).FindAll(x => x.Categoria.Descripcion.ToUpper().Contains(Tipo.ToUpper()));

            }
            else
            {
                InsumoLista = ((List<Insumo>)Session["ListadoInsumo"]);
            }

        }


        protected void actualizar(object sender, EventArgs e)
        {
            var argument = ((Button)sender).CommandArgument;
            Consultas insumos = new Consultas();
            Insumo aux = new Insumo();

            int cont = 0;
            foreach (Insumo item in InsumoLista)
            {
                if (argument == item.Id.ToString()
                    && ((TextBox)repeaterMenu.Items[cont].FindControl("Insumo")).Text != ""
                    && ((TextBox)repeaterMenu.Items[cont].FindControl("Tipo")).Text != ""
                    && ((TextBox)repeaterMenu.Items[cont].FindControl("Precio")).Text != ""
                    && ((TextBox)repeaterMenu.Items[cont].FindControl("Url")).Text != "")
                {
                    aux.Id = item.Id;
                    aux.Nombre = ((TextBox)repeaterMenu.Items[cont].FindControl("Insumo")).Text;
                    aux.Categoria.Descripcion = ((TextBox)repeaterMenu.Items[cont].FindControl("Tipo")).Text;
                    aux.Categoria.Id = item.Categoria.Id;
                    aux.Tipo = item.Tipo;
                    aux.Precio = decimal.Parse(((TextBox)repeaterMenu.Items[cont].FindControl("Precio")).Text);
                    aux.UrlImagen = ((TextBox)repeaterMenu.Items[cont].FindControl("Url")).Text;
                    aux.Stock = item.Stock;

                    insumos.actualizarInsumo(false, aux);
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
            foreach (Insumo item in InsumoLista)
            {
                if (argument == item.Id.ToString()
                    && ((TextBox)repeaterMenu.Items[cont].FindControl("Insumo")).Text != ""
                    && ((TextBox)repeaterMenu.Items[cont].FindControl("Tipo")).Text != ""
                    && ((TextBox)repeaterMenu.Items[cont].FindControl("Precio")).Text != ""
                    && ((TextBox)repeaterMenu.Items[cont].FindControl("Url")).Text != "")
                {
                    aux.Id = item.Id;
                    aux.Nombre = ((TextBox)repeaterMenu.Items[cont].FindControl("Insumo")).Text;
                    aux.Categoria.Descripcion = ((TextBox)repeaterMenu.Items[cont].FindControl("Tipo")).Text;
                    aux.Categoria.Id = item.Categoria.Id;
                    aux.Tipo = item.Tipo;
                    aux.Precio = decimal.Parse(((TextBox)repeaterMenu.Items[cont].FindControl("Precio")).Text);
                    aux.UrlImagen = ((TextBox)repeaterMenu.Items[cont].FindControl("Url")).Text;
                    aux.Stock = item.Stock;

                    insumos.actualizarInsumo(true, aux);
                }
                cont++;
            }
        }
    }
}