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
    public partial class Menu : System.Web.UI.Page
    {
        public List<Insumo> ListaMenu;
        protected void Page_Load(object sender, EventArgs e)
        {
            Consultas query = new Consultas();
            try
            {
                ListaMenu = new List<Insumo>();
                ListaMenu = query.ListarInsumos("");
                Session.Add("ListadoMenu", ListaMenu);
                if (!IsPostBack) { 
                

                    //Categoria DropDownList
                    //Extracción de información de la base de Datos
                    List<Categorias> listaCate = new List<Categorias>();
                    Categorias AuxCate = new Categorias(0, "None");
                    listaCate.Add(AuxCate);
                    listaCate.AddRange( query.FiltrosCategorias());
                    
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
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
            }
        }

        protected void OnTextChanged_Filtros(object sender, EventArgs e)
        {
            //string Buscar=TB_Buscar.Text;
            int IDCategoria = int.Parse(DDL_Categorias.SelectedItem.Value);
            int IDTipo = int.Parse(DDL_Tipo_Insumo.SelectedItem.Value);
            
            
            if (IDCategoria!=0 && IDTipo!=0)
            {
                ListaMenu=((List<Insumo>)Session["ListadoMenu"]).FindAll(x => x.Tipo.Id ==IDTipo && x.Categoria.Id==IDCategoria);
                
            }
            else if(IDCategoria == 0 && IDTipo != 0)
            {
                ListaMenu = ((List<Insumo>)Session["ListadoMenu"]).FindAll(x => x.Tipo.Id == IDTipo );
            }
            else if(IDCategoria != 0 && IDTipo == 0)
            {
                ListaMenu = ((List<Insumo>)Session["ListadoMenu"]).FindAll(x => x.Categoria.Id == IDCategoria);
            }
            else
            {
                ListaMenu = ((List<Insumo>)Session["ListadoMenu"]);
            }
        }

    }
}