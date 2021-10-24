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
        public List<Insumo> InsumoListaACT;
        public List<Insumo> InsumoListaINA;
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
                /*VEREFICAR EL USO DEL SESSION*/
                InsumoLista = GerenteMenu.ListarInsumos("");
                Session.Add("ListadoInsumo", InsumoLista);

            
                    InsumoListaACT = new List<Insumo>();
                    InsumoListaINA = new List<Insumo>();
                
                foreach (Insumo item in InsumoLista)
                {
                    if (item.Baja) 
                    {
                            InsumoListaACT.Add(item);
                    }
                    else 
                    {
                            InsumoListaINA.Add(item);

                    }
                    
                }
                    repeaterMenu.DataSource = InsumoListaACT;
                    repeaterMenu.DataBind();
                    repeaterMenu2.DataSource = InsumoListaINA;
                    repeaterMenu2.DataBind();


                    int cont = 0;
                    foreach (Insumo item in InsumoListaACT)
                    {

                            ((Image)repeaterMenu.Items[cont].FindControl("Img")).ImageUrl = item.UrlImagen;
                            ((TextBox)repeaterMenu.Items[cont].FindControl("Insumo")).Text = item.Nombre.ToUpper();
                            ((TextBox)repeaterMenu.Items[cont].FindControl("Tipo")).Text = item.Tipo.Descripcion.ToUpper();
                            ((TextBox)repeaterMenu.Items[cont].FindControl("Precio")).Text = item.Precio.ToString();
                            ((TextBox)repeaterMenu.Items[cont].FindControl("Url")).Text = item.UrlImagen;
                            cont++;
                    }
                    cont = 0;
                    foreach (Insumo item in InsumoListaINA)
                    {

                        ((Image)repeaterMenu2.Items[cont].FindControl("Img2")).ImageUrl = item.UrlImagen;
                        ((TextBox)repeaterMenu2.Items[cont].FindControl("Insumo2")).Text = item.Nombre.ToUpper();
                        ((TextBox)repeaterMenu2.Items[cont].FindControl("Tipo2")).Text = item.Tipo.Descripcion.ToUpper();
                        ((TextBox)repeaterMenu2.Items[cont].FindControl("Precio2")).Text = item.Precio.ToString();
                        ((TextBox)repeaterMenu2.Items[cont].FindControl("Url2")).Text = item.UrlImagen;
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
            /*
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
            }*/
        }

        protected void ConfirmBorrar(object sender, EventArgs e)
        {
            var argument = ((Button)sender).CommandArgument;

            jsBorrar.CommandArgument = argument;
            jsBorrar.Visible = true;
            jsActualizar.Visible = false;
            jsReactivar.Visible = false;
            jsAgregar.Visible = false;

            string javaScript = "abrirventanaEmerg_Borrar()";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
        }
        protected void ConfirmReactivar(object sender, EventArgs e)
        {
            var argument = ((Button)sender).CommandArgument;

            jsReactivar.CommandArgument = argument;
            jsBorrar.Visible = false;
            jsActualizar.Visible = false;
            jsReactivar.Visible = true;
            jsAgregar.Visible = false;

            string javaScript = "abrirventanaEmerg_Borrar()";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
        }
        protected void ConfirmActualizar(object sender, EventArgs e)
        {
            var argument = ((Button)sender).CommandArgument;

            jsActualizar.CommandArgument = argument;
            jsBorrar.Visible = false;
            jsActualizar.Visible = true;
            jsReactivar.Visible = false;
            jsAgregar.Visible = false;

            string javaScript = "abrirventanaEmerg_Borrar()";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
        }
        protected void ConfirmAgregar(object sender, EventArgs e)
        {
            jsBorrar.Visible = false;
            jsActualizar.Visible = false;
            jsReactivar.Visible = false;
            jsAgregar.Visible = true;


            string javaScript = "abrirventanaEmerg_Borrar()";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
        }







        protected void Actualizar(object sender, EventArgs e)
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
                    aux = item;

                    aux.Nombre = ((TextBox)repeaterMenu.Items[cont].FindControl("Insumo")).Text;

                    aux.Categoria.Descripcion = ((TextBox)repeaterMenu.Items[cont].FindControl("Tipo")).Text;

                    aux.Precio = decimal.Parse(((TextBox)repeaterMenu.Items[cont].FindControl("Precio")).Text);
                    aux.UrlImagen = ((TextBox)repeaterMenu.Items[cont].FindControl("Url")).Text;
                    aux.Stock = item.Stock;
                    aux.Baja = true;

                    insumos.ActualizarInsumo(true, aux);
                }
                if (item.Baja) cont++;
            }
            Response.Redirect("Gerente-Menu.aspx");
        }

        protected void Borrar(object sender, EventArgs e)
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
                    aux = item;
                    aux.Baja = false;

                    insumos.ActualizarInsumo(false, aux);
                }
                if (item.Baja) cont++;
            }
            Response.Redirect("Gerente-Menu.aspx");
        }

        protected void Agregar(object sender, EventArgs e)
        {
            Insumo aux = new Insumo();
            Consultas query = new Consultas();
            if (InsumoNew.Text != "" && TipoNew.Text != "" && PrecioNew.Text != "" && UrlNew.Text != "")
            {
                aux.Nombre = InsumoNew.Text;
                aux.Categoria = new Categorias();
                aux.Categoria.Id = int.Parse(TipoNew.Text);
                aux.Precio = decimal.Parse(PrecioNew.Text);
                aux.UrlImagen = UrlNew.Text;
                aux.Tipo.Id = 1;
                aux.Baja = true;
                query.AgregarInsumo(aux);
            }
            else
            {
                string script = @"<script type='text/javascript'>abrirventanaEmerg();</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", script, false);
            }
            Response.Redirect("Gerente-Menu.aspx");
        }

        protected void Reactivar_Insumo(object sender, EventArgs e)
        {
            Consultas consulta = new Consultas();
            var argument = int.Parse(((Button)sender).CommandArgument);
          
            ((List<Insumo>)Session["ListadoInsumo"]).Find(x => x.Id == argument).Baja = true;

            consulta.ActualizarInsumo(true, ((List<Insumo>)Session["ListadoInsumo"]).Find(x => x.Id == argument));

            Response.Redirect("Gerente-Menu.aspx");
        }

    }
}