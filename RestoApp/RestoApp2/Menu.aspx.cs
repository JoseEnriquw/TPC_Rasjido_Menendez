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
            try
            {
                ListaMenu = new List<Insumo>();
                ListaMenu = query.ListarInsumos("");
                Session["ListadoMenu"]= ListaMenu;
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
            string Buscar = TB_Buscar.Text;
            int IDCategoria = int.Parse(DDL_Categorias.SelectedItem.Value);
            int IDTipo = int.Parse(DDL_Tipo_Insumo.SelectedItem.Value);

           
            //Los 3 tienen datos
            if (IDCategoria != 0 && IDTipo != 0 && Buscar != " ")
            {
                ListaMenu = ((List<Insumo>)Session["ListadoMenu"]).FindAll(x => x.Tipo.Id == IDTipo && x.Categoria.Id == IDCategoria && (x.Nombre.ToUpper().Contains(Buscar.ToUpper()) || x.Tipo.Descripcion.ToUpper().Contains(Buscar.ToUpper()) || x.Categoria.Descripcion.ToUpper().Contains(Buscar.ToUpper()) || x.Precio.ToString().ToUpper().Contains(Buscar.ToUpper())));

            }
            //Cate no tiene Datos y los demas si
            else if (IDCategoria == 0 && IDTipo != 0 && Buscar != " ")
            {
                ListaMenu = ((List<Insumo>)Session["ListadoMenu"]).FindAll(x => x.Tipo.Id == IDTipo && (x.Nombre.ToUpper().Contains(Buscar.ToUpper()) || x.Tipo.Descripcion.ToUpper().Contains(Buscar.ToUpper()) || x.Categoria.Descripcion.ToUpper().Contains(Buscar.ToUpper()) || x.Precio.ToString().ToUpper().Contains(Buscar.ToUpper())));
            }
            //Tipo no tine datos y los demas si
            else if (IDCategoria != 0 && IDTipo == 0 && Buscar != " ")
            {
                ListaMenu = ((List<Insumo>)Session["ListadoMenu"]).FindAll(x => x.Categoria.Id == IDCategoria && (x.Nombre.ToUpper().Contains(Buscar.ToUpper()) || x.Tipo.Descripcion.ToUpper().Contains(Buscar.ToUpper()) || x.Categoria.Descripcion.ToUpper().Contains(Buscar.ToUpper()) || x.Precio.ToString().ToUpper().Contains(Buscar.ToUpper())));
            }
            //Buscar no tiene datos y los demas si 
            else if(IDCategoria != 0 && IDTipo != 0 && Buscar == " ")
            {
                ListaMenu = ((List<Insumo>)Session["ListadoMenu"]).FindAll(x => x.Tipo.Id == IDTipo && x.Categoria.Id == IDCategoria);
            }
            //Solo buscar tiene datos
            else if (IDCategoria == 0 && IDTipo == 0 && Buscar != " ")
            {
                ListaMenu = ((List<Insumo>)Session["ListadoMenu"]).FindAll(x => x.Nombre.ToUpper().Contains(Buscar.ToUpper()) || x.Tipo.Descripcion.ToUpper().Contains(Buscar.ToUpper()) || x.Categoria.Descripcion.ToUpper().Contains(Buscar.ToUpper()) || x.Precio.ToString().ToUpper().Contains(Buscar.ToUpper()));
            }
            //Solo Cate tiene datos
            else if(IDCategoria != 0 && IDTipo == 0 && Buscar == " ")
            {
                ListaMenu = ((List<Insumo>)Session["ListadoMenu"]).FindAll(x => x.Categoria.Id == IDCategoria);
            }
            //Solo Tipo tiene datos
            else if (IDCategoria == 0 && IDTipo != 0 && Buscar == " ")
            {
                ListaMenu = ((List<Insumo>)Session["ListadoMenu"]).FindAll(x => x.Tipo.Id == IDTipo );
            }
            else
            {
                //ListaMenu = ((List<Insumo>)Session["ListadoMenu"]).FindAll(x => x.Nombre.Contains(Buscar) || x.Tipo.Descripcion.Contains(Buscar) || x.Categoria.Descripcion.Contains(Buscar) || x.Precio.ToString().Contains(Buscar));
                ListaMenu = ((List<Insumo>)Session["ListadoMenu"]);
            }
        }

    }
}