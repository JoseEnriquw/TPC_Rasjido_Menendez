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
        public List<Insumo> InsumoLista;
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

            
            Consultas query = new Consultas();
            if (!IsPostBack)
            {
                InsumoLista = new List<Insumo>();
                InsumoLista = query.ListarInsumos("");
                //Categoria DropDownList
                //Extracción de información de la base de Datos
                List<Categorias> listaCate = new List<Categorias>();
                Categorias AuxCate = new Categorias(0, "None");
                listaCate.Add(AuxCate);
                listaCate.AddRange(query.FiltrosCategorias());

                //Se agregan los datos de la lista DropDonwList
                DDL_Categorias.DataSource = listaCate;
                DDL_Categorias.DataTextField = "Descripcion";
                DDL_Categorias.DataValueField = "Id";
                DDL_Categorias.DataBind();


                //Tipo de Insumo DropDownList 
                //Extracción de información de la base de Datos
                List<TipoInsumo> listaTipoInsumo = new List<TipoInsumo>();
                TipoInsumo AuxTI = new TipoInsumo(0, "None");
                listaTipoInsumo.Add(AuxTI);
                listaTipoInsumo.AddRange(query.FiltrosTipoInsumo());

                //Se agregan los datos de la lista DropDonwList
                DDL_Tipo_Insumo.DataSource = listaTipoInsumo;
                DDL_Tipo_Insumo.DataTextField = "Descripcion";
                DDL_Tipo_Insumo.DataValueField = "Id";
                DDL_Tipo_Insumo.DataBind();

            }
            

            Consultas GerenteMenu = new Consultas();

            if (!IsPostBack) { 
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
        }

        protected void OnTextChanged_Filtros(object sender, EventArgs e)
        {
            string Insumo = TB_Insumo.Text;
            int IDCategoria = int.Parse(DDL_Categorias.SelectedItem.Value);
            int IDTipo = int.Parse(DDL_Tipo_Insumo.SelectedItem.Value);

            //Los 3 tienen datos
            if (IDCategoria != 0 && IDTipo != 0 && Insumo != " ")
            {
                Session["ListadoInsumo"] = ((List<Insumo>)Session["ListadoInsumo"]).FindAll(x => x.Tipo.Id == IDTipo && x.Categoria.Id == IDCategoria && (x.Nombre.ToUpper().Contains(Insumo.ToUpper()) || x.Tipo.Descripcion.ToUpper().Contains(Insumo.ToUpper()) || x.Categoria.Descripcion.ToUpper().Contains(Insumo.ToUpper()) || x.Precio.ToString().ToUpper().Contains(Insumo.ToUpper())));

            }
            //Cate no tiene Datos y los demas si
            else if (IDCategoria == 0 && IDTipo != 0 && Insumo != " ")
            {
                Session["ListadoInsumo"] = ((List<Insumo>)Session["ListadoInsumo"]).FindAll(x => x.Tipo.Id == IDTipo && (x.Nombre.ToUpper().Contains(Insumo.ToUpper()) || x.Tipo.Descripcion.ToUpper().Contains(Insumo.ToUpper()) || x.Categoria.Descripcion.ToUpper().Contains(Insumo.ToUpper()) || x.Precio.ToString().ToUpper().Contains(Insumo.ToUpper())));
            }
            //Tipo no tine datos y los demas si
            else if (IDCategoria != 0 && IDTipo == 0 && Insumo != " ")
            {
                Session["ListadoInsumo"] = ((List<Insumo>)Session["ListadoInsumo"]).FindAll(x => x.Categoria.Id == IDCategoria && (x.Nombre.ToUpper().Contains(Insumo.ToUpper()) || x.Tipo.Descripcion.ToUpper().Contains(Insumo.ToUpper()) || x.Categoria.Descripcion.ToUpper().Contains(Insumo.ToUpper()) || x.Precio.ToString().ToUpper().Contains(Insumo.ToUpper())));
            }
            //Buscar no tiene datos y los demas si 
            else if (IDCategoria != 0 && IDTipo != 0 && Insumo == " ")
            {
                Session["ListadoInsumo"] = ((List<Insumo>)Session["ListadoInsumo"]).FindAll(x => x.Tipo.Id == IDTipo && x.Categoria.Id == IDCategoria);
            }
            //Solo buscar tiene datos
            else if (IDCategoria == 0 && IDTipo == 0 && Insumo != " ")
            {
                Session["ListadoInsumo"] = ((List<Insumo>)Session["ListadoInsumo"]).FindAll(x => x.Nombre.ToUpper().Contains(Insumo.ToUpper()) || x.Tipo.Descripcion.ToUpper().Contains(Insumo.ToUpper()) || x.Categoria.Descripcion.ToUpper().Contains(Insumo.ToUpper()) || x.Precio.ToString().ToUpper().Contains(Insumo.ToUpper()));
            }
            //Solo Cate tiene datos
            else if (IDCategoria != 0 && IDTipo == 0 && Insumo == " ")
            {
                Session["ListadoInsumo"] = ((List<Insumo>)Session["ListadoInsumo"]).FindAll(x => x.Categoria.Id == IDCategoria);
            }
            //Solo Tipo tiene datos
            else if (IDCategoria == 0 && IDTipo != 0 && Insumo == " ")
            {
                Session["ListadoInsumo"] = ((List<Insumo>)Session["ListadoInsumo"]).FindAll(x => x.Tipo.Id == IDTipo);
            }
            else
            {
                //ListaMenu = ((List<Insumo>)Session["ListadoMenu"]).FindAll(x => x.Nombre.Contains(Buscar) || x.Tipo.Descripcion.Contains(Buscar) || x.Categoria.Descripcion.Contains(Buscar) || x.Precio.ToString().Contains(Buscar));
                Session["ListadoInsumo"] = ((List<Insumo>)Session["ListadoInsumo"]);
            }
        }


        protected void actualizar(object sender, EventArgs e)
        {
            var argument = ((Button)sender).CommandArgument;
            Consultas insumos = new Consultas();
            Insumo aux = new Insumo();

            int cont = 0;
            foreach (Insumo item in ((List<Insumo>)Session["ListadoInsumo"]))
            {
                if (argument == item.Id.ToString()
                    && ((TextBox)repeaterMenu.Items[cont].FindControl("Insumo")).Text != ""
                    && ((TextBox)repeaterMenu.Items[cont].FindControl("Tipo")).Text != ""
                    && ((TextBox)repeaterMenu.Items[cont].FindControl("Precio")).Text != ""
                    && ((TextBox)repeaterMenu.Items[cont].FindControl("Url")).Text != "")
                {
                    aux.Id = item.Id;
                    aux.Nombre = ((TextBox)repeaterMenu.Items[cont].FindControl("Insumo")).Text;
                    aux.Categoria = new Categorias();
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
            Response.Redirect("Gerente-Menu.aspx");
        }

        protected void borrar(object sender, EventArgs e)
        {
            var argument = ((Button)sender).CommandArgument;
            Consultas insumos = new Consultas();
            Insumo aux = new Insumo();

            int cont = 0;
            foreach (Insumo item in ((List<Insumo>)Session["ListadoInsumo"]))
            {
                if (argument == item.Id.ToString()
                    && ((TextBox)repeaterMenu.Items[cont].FindControl("Insumo")).Text != ""
                    && ((TextBox)repeaterMenu.Items[cont].FindControl("Tipo")).Text != ""
                    && ((TextBox)repeaterMenu.Items[cont].FindControl("Precio")).Text != ""
                    && ((TextBox)repeaterMenu.Items[cont].FindControl("Url")).Text != "")
                {
                    aux.Id = item.Id;
                    aux.Nombre = ((TextBox)repeaterMenu.Items[cont].FindControl("Insumo")).Text;
                    aux.Categoria = new Categorias();
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
            Response.Redirect("Gerente-Menu.aspx");
        }

        protected void agregar(object sender, EventArgs e)
        {
            Consultas personal = new Consultas();
            Insumo aux = new Insumo();
            if (InsumoNew.Text != "" && TipoNew.Text != "" && PrecioNew.Text != "" && UrlNew.Text != "")
            {
                aux.Nombre = InsumoNew.Text;
                aux.Categoria = new Categorias();
                aux.Categoria.Id = int.Parse(TipoNew.Text);
                aux.Precio = decimal.Parse(PrecioNew.Text);
                aux.UrlImagen = UrlNew.Text;
                aux.Tipo.Id = 1;
            }
            else
            {
                string script = @"<script type='text/javascript'>abrirventanaEmerg();</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", script, false);
            }
            Response.Redirect("Gerente-Menu.aspx");
        }
    }
}