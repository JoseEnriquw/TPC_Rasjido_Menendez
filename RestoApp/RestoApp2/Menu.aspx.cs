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
    public partial class Menu : System.Web.UI.Page
    {
        public List<Insumo> ListaMenu;
        public FiltrosInsumos filtros;
        private NegocioInsumos negocioInsumos;
        private NegocioCategoria negocioCategoria;
        private NegocioTipoInsumo negocioTipoInsumo;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (((Dominio.Persona)Session["UserLog"]) != null) {
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
                Persona auxSession = new Persona();
                auxSession = ((Dominio.Persona)Session["UserLog"]);
                Session["UserLog"] = auxSession;
            }
            negocioInsumos = new NegocioInsumos();
            negocioCategoria = new NegocioCategoria();
            negocioTipoInsumo = new NegocioTipoInsumo();

            try
            {
              
                ListaMenu = new List<Insumo>();
                ListaMenu = negocioInsumos.GetAllInsumos(filtros);
                Session["ListadoMenu"]= ListaMenu;

                if (!IsPostBack) {

                    filtros = new FiltrosInsumos();
                    //Categoria DropDownList
                    //Extracción de información de la base de Datos
                    List<Categorias> listaCate = new List<Categorias>();
                    Categorias AuxCate = new Categorias(0, "None");
                    listaCate.Add(AuxCate);
                    listaCate.AddRange( negocioCategoria.GetAllCategorias());
                    
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
                    listaTipoInsumo.AddRange(negocioTipoInsumo.GetAllTipoInsumo());

                    //Se agregan los datos de la lista DropDonwList
                    DDL_Tipo_Insumo.DataSource = listaTipoInsumo;
                    DDL_Tipo_Insumo.DataTextField = "Descripcion";
                    DDL_Tipo_Insumo.DataValueField = "Id";
                    DDL_Tipo_Insumo.DataBind();

                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
            }
        }

        protected void OnTextChanged_Filtros(object sender, EventArgs e)
        {
            filtros = new FiltrosInsumos();
           
            filtros.buscarPorTodo = TB_Buscar.Text;
             filtros.categoria = DDL_Categorias.SelectedItem.Text == "None" ? " " : DDL_Categorias.SelectedItem.Text;
            filtros.tipoInsumo=DDL_Tipo_Insumo.SelectedItem.Text=="None"? " ": DDL_Tipo_Insumo.SelectedItem.Text;

            ListaMenu = negocioInsumos.GetAllInsumos(filtros);


        }

        public bool verificarStock(int cantpedida, int id)
        {
            
            bool result = false;
            try
            {
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
            }
            catch(Exception ex)
            {
                return false;
            }

            return result;
        }

    }
}