using System;
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
    public partial class Gerente_Menu : System.Web.UI.Page
    {
        public List<Insumo> InsumoLista;
        public List<Insumo> InsumoListaACT;
        public List<Insumo> InsumoListaINA;
        public int coloropc;
        public FiltrosInsumos filtros;
        private NegocioInsumos negocioInsumos;
        private NegocioCategoria negocioCategoria;
        private NegocioTipoInsumo negocioTipoInsumo;

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


          
            negocioInsumos = new NegocioInsumos();
            negocioCategoria = new NegocioCategoria();
            negocioTipoInsumo = new NegocioTipoInsumo();

            if (!IsPostBack)
            {
                filtros = new FiltrosInsumos();
                filtros.baja = true;
                InsumoLista = new List<Insumo>();
                InsumoLista = negocioInsumos.GetAllInsumos(filtros);
                //Categoria DropDownList
                //Extracción de información de la base de Datos
                List<Categorias> listaCate = new List<Categorias>();
                Categorias AuxCate = new Categorias(0, "None");
                listaCate.Add(AuxCate);
                listaCate.AddRange(negocioCategoria.GetAllCategorias());

                //Se agregan los datos de la lista DropDonwList de Categorias
                DDL_Categorias.DataSource = listaCate;
                DDL_Categorias.DataTextField = "Descripcion";
                DDL_Categorias.DataValueField = "Id";
                DDL_Categorias.DataBind();

                //Se agregan los datos de la lista DropDonwList de Categorias Agregar
                listaCate[0].Descripcion = "";
                DDL_Categorias_Agregar.DataSource = listaCate;
                DDL_Categorias_Agregar.DataTextField = "Descripcion";
                DDL_Categorias_Agregar.DataValueField = "Id";
                DDL_Categorias_Agregar.DataBind();

                //Tipo de Insumo DropDownList 
                //Extracción de información de la base de Datos
                List<TipoInsumo> listaTipoInsumo = new List<TipoInsumo>();
                TipoInsumo AuxTI = new TipoInsumo(0, "None");
                listaTipoInsumo.Add(AuxTI);
                listaTipoInsumo.AddRange(negocioTipoInsumo.GetAllTipoInsumo());

                //Se agregan los datos de la lista DropDonwList TipoInsumo
                DDL_Tipo_Insumo.DataSource = listaTipoInsumo;
                DDL_Tipo_Insumo.DataTextField = "Descripcion";
                DDL_Tipo_Insumo.DataValueField = "Id";
                DDL_Tipo_Insumo.DataBind();

                //Se agregan los datos de la lista DropDonwList TipoInsumo_Agregar
                listaTipoInsumo[0].Descripcion = "";
                DDL_TipoInsumo_Agregar.DataSource = listaTipoInsumo;
                DDL_TipoInsumo_Agregar.DataTextField = "Descripcion";
                DDL_TipoInsumo_Agregar.DataValueField = "Id";
                DDL_TipoInsumo_Agregar.DataBind();

            }
            

           

            if (!IsPostBack) { 
            try
            {
                    /*VEREFICAR EL USO DEL SESSION*/
                    FiltrosInsumos filtros = new FiltrosInsumos();
                    filtros.baja = true;
                    InsumoLista = negocioInsumos.GetAllInsumos(filtros);
                    Session.Add("ListadoInsumo", InsumoLista);
                    List<Categorias> listaCate = new List<Categorias>();
                    listaCate.AddRange(negocioCategoria.GetAllCategorias());
                    List<TipoInsumo> listaTipoInsumo = new List<TipoInsumo>();
                    listaTipoInsumo.AddRange(negocioTipoInsumo.GetAllTipoInsumo());

                    InsumoListaACT = new List<Insumo>();
                    InsumoListaINA = new List<Insumo>();
                
                foreach (Insumo item in InsumoLista)
                {
                    if (!item.Baja) 
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

                        //Se agregan los datos de la lista DropDonwList de Categorias Item
                       
                        ((DropDownList)repeaterMenu.Items[cont].FindControl("DDL_Categorias_Item")).DataSource = listaCate;
                        ((DropDownList)repeaterMenu.Items[cont].FindControl("DDL_Categorias_Item")).DataTextField = "Descripcion";
                        ((DropDownList)repeaterMenu.Items[cont].FindControl("DDL_Categorias_Item")).DataValueField = "Id";
                        ((DropDownList)repeaterMenu.Items[cont].FindControl("DDL_Categorias_Item")).DataBind();
                        ((DropDownList)repeaterMenu.Items[cont].FindControl("DDL_Categorias_Item")).SelectedValue = item.Categoria.Id.ToString();

                        //Se agregan los datos de la lista DropDonwList TipoInsumo

                        ((DropDownList)repeaterMenu.Items[cont].FindControl("DDL_TipoInsumo_Item")).DataSource = listaTipoInsumo;
                        ((DropDownList)repeaterMenu.Items[cont].FindControl("DDL_TipoInsumo_Item")).DataTextField = "Descripcion";
                        ((DropDownList)repeaterMenu.Items[cont].FindControl("DDL_TipoInsumo_Item")).DataValueField = "Id";
                        ((DropDownList)repeaterMenu.Items[cont].FindControl("DDL_TipoInsumo_Item")).DataBind();
                        ((DropDownList)repeaterMenu.Items[cont].FindControl("DDL_TipoInsumo_Item")).SelectedValue = item.Tipo.Id.ToString();

                        ((TextBox)repeaterMenu.Items[cont].FindControl("Precio")).Text = item.Precio.ToString();
                            ((TextBox)repeaterMenu.Items[cont].FindControl("Url")).Text = item.UrlImagen;
                            cont++;
                    }
                    cont = 0;
                    foreach (Insumo item in InsumoListaINA)
                    {

                        ((Image)repeaterMenu2.Items[cont].FindControl("Img2")).ImageUrl = item.UrlImagen;
                        ((TextBox)repeaterMenu2.Items[cont].FindControl("Insumo2")).Text = item.Nombre.ToUpper();
                        ((TextBox)repeaterMenu2.Items[cont].FindControl("txt_Categorias_Item2")).Text = item.Categoria.Descripcion;
                        ((TextBox)repeaterMenu2.Items[cont].FindControl("txt_TipoInsumo_Item2")).Text = item.Tipo.Descripcion;
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
            filtros = new FiltrosInsumos();
            filtros.baja = true;
            InsumoListaACT = new List<Insumo>();
            InsumoListaINA = new List<Insumo>();
            filtros.buscarPorTodo = TB_Insumo.Text;
            filtros.categoria = DDL_Categorias.SelectedItem.Text == "None" ? " " : DDL_Categorias.SelectedItem.Text;
            filtros.tipoInsumo = DDL_Tipo_Insumo.SelectedItem.Text == "None" ? " " : DDL_Tipo_Insumo.SelectedItem.Text;
            List<Categorias> listaCate = new List<Categorias>();
            listaCate.AddRange(negocioCategoria.GetAllCategorias());
            List<TipoInsumo> listaTipoInsumo = new List<TipoInsumo>();
            listaTipoInsumo.AddRange(negocioTipoInsumo.GetAllTipoInsumo());

            InsumoLista = negocioInsumos.GetAllInsumos(filtros);
            foreach (Insumo item in InsumoLista)
            {
                if (!item.Baja)
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

                //Se agregan los datos de la lista DropDonwList de Categorias Item

                ((DropDownList)repeaterMenu.Items[cont].FindControl("DDL_Categorias_Item")).DataSource = listaCate;
                ((DropDownList)repeaterMenu.Items[cont].FindControl("DDL_Categorias_Item")).DataTextField = "Descripcion";
                ((DropDownList)repeaterMenu.Items[cont].FindControl("DDL_Categorias_Item")).DataValueField = "Id";
                ((DropDownList)repeaterMenu.Items[cont].FindControl("DDL_Categorias_Item")).DataBind();
                ((DropDownList)repeaterMenu.Items[cont].FindControl("DDL_Categorias_Item")).SelectedValue = item.Categoria.Id.ToString();

                //Se agregan los datos de la lista DropDonwList TipoInsumo

                ((DropDownList)repeaterMenu.Items[cont].FindControl("DDL_TipoInsumo_Item")).DataSource = listaTipoInsumo;
                ((DropDownList)repeaterMenu.Items[cont].FindControl("DDL_TipoInsumo_Item")).DataTextField = "Descripcion";
                ((DropDownList)repeaterMenu.Items[cont].FindControl("DDL_TipoInsumo_Item")).DataValueField = "Id";
                ((DropDownList)repeaterMenu.Items[cont].FindControl("DDL_TipoInsumo_Item")).DataBind();
                ((DropDownList)repeaterMenu.Items[cont].FindControl("DDL_TipoInsumo_Item")).SelectedValue = item.Tipo.Id.ToString();

                ((TextBox)repeaterMenu.Items[cont].FindControl("Precio")).Text = item.Precio.ToString();
                ((TextBox)repeaterMenu.Items[cont].FindControl("Url")).Text = item.UrlImagen;
                cont++;
            }
            cont = 0;
            foreach (Insumo item in InsumoListaINA)
            {

                ((Image)repeaterMenu2.Items[cont].FindControl("Img2")).ImageUrl = item.UrlImagen;
                ((TextBox)repeaterMenu2.Items[cont].FindControl("Insumo2")).Text = item.Nombre.ToUpper();             
                ((TextBox)repeaterMenu.Items[cont].FindControl("txt_Categorias_Item2")).Text = item.Categoria.Descripcion;
                ((TextBox)repeaterMenu.Items[cont].FindControl("txt_TipoInsumo_Item2")).Text = item.Tipo.Descripcion;
                ((TextBox)repeaterMenu2.Items[cont].FindControl("Precio2")).Text = item.Precio.ToString();
                ((TextBox)repeaterMenu2.Items[cont].FindControl("Url2")).Text = item.UrlImagen;
                cont++;
            }

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
            Insumo aux = new Insumo();

            int cont = 0;
            foreach (Insumo item in ((List<Insumo>)Session["ListadoInsumo"]))
            {
                if (argument == item.Id.ToString()
                    && ((TextBox)repeaterMenu.Items[cont].FindControl("Insumo")).Text != ""
                    && ((TextBox)repeaterMenu.Items[cont].FindControl("Precio")).Text != ""
                    && ((TextBox)repeaterMenu.Items[cont].FindControl("Url")).Text != "")
                {
                    aux = item;

                    aux.Nombre = ((TextBox)repeaterMenu.Items[cont].FindControl("Insumo")).Text;

                    aux.Categoria.Id = int.Parse(((DropDownList)repeaterMenu.Items[cont].FindControl("DDL_Categorias_Item")).SelectedValue);
                    aux.Tipo.Id = int.Parse(((DropDownList)repeaterMenu.Items[cont].FindControl("DDL_TipoInsumo_Item")).SelectedValue);
                    aux.Precio = decimal.Parse(((TextBox)repeaterMenu.Items[cont].FindControl("Precio")).Text);
                    aux.UrlImagen = ((TextBox)repeaterMenu.Items[cont].FindControl("Url")).Text;
                    aux.Stock = item.Stock;
                    aux.Baja = false;

                    negocioInsumos.UpdateInsumo(aux);
                }
                if (!item.Baja) cont++;
            }
            Response.Redirect("Gerente-Menu.aspx");
        }

        protected void Borrar(object sender, EventArgs e)
        {
            var argument = int.Parse(((Button)sender).CommandArgument);

            ((List<Insumo>)Session["ListadoInsumo"]).Find(x => x.Id == argument).Baja = true;

            negocioInsumos.UpdateInsumo(((List<Insumo>)Session["ListadoInsumo"]).Find(x => x.Id == argument));

            Response.Redirect("Gerente-Menu.aspx");
        }

        protected void Agregar(object sender, EventArgs e)
        {
            Insumo aux = new Insumo();
           

            if (InsumoNew.Text != "" && DDL_Categorias_Agregar.SelectedItem.Text != "" && PrecioNew.Text != "" && UrlNew.Text != "" && DDL_TipoInsumo_Agregar.SelectedItem.Text != "")
            {
                aux.Nombre = InsumoNew.Text;
                aux.Categoria.Id = int.Parse(DDL_Categorias_Agregar.SelectedItem.Value);
                aux.Precio = decimal.Parse(PrecioNew.Text);
                aux.UrlImagen = UrlNew.Text;
                aux.Tipo.Id = int.Parse(DDL_TipoInsumo_Agregar.SelectedItem.Value);
                aux.Baja = false;
                negocioInsumos.InsertInsumo(aux);
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
            
            var argument = int.Parse(((Button)sender).CommandArgument);
          
            ((List<Insumo>)Session["ListadoInsumo"]).Find(x => x.Id == argument).Baja = false;

            negocioInsumos.UpdateInsumo( ((List<Insumo>)Session["ListadoInsumo"]).Find(x => x.Id == argument));

            Response.Redirect("Gerente-Menu.aspx");
        }

    }
}