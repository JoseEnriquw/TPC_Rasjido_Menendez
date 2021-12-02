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
    public partial class Gerente_Personal : System.Web.UI.Page
    {
        public List<Persona> PersonaLista;
        public List<Persona> PersonaListaACT;
        public List<Persona> PersonaListaINA;
        private NegocioPersona negocioPersona;
        private FiltrosPersonas filtrosPersonas;
        private NegocioCargo negocioCargo;
        public int coloropc;
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (Session["UserLog"]!=null)
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

            negocioPersona = new NegocioPersona();
            negocioCargo = new NegocioCargo();
            if (!IsPostBack)
            {
                filtrosPersonas = new FiltrosPersonas();
                
                try
                {
                    PersonaLista = new List<Persona>();
                    PersonaLista = negocioPersona.GetAllPersonas(filtrosPersonas);
                    Session.Add("ListadoPersonal", PersonaLista);

                    List<Cargo> listaCargo = new List<Cargo>();
                    listaCargo.AddRange(negocioCargo.GetAllCargos());
                    DDL_CargoNew.DataSource = listaCargo;
                    DDL_CargoNew.DataTextField = "Descripcion";
                    DDL_CargoNew.DataValueField = "Id";
                    DDL_CargoNew.DataBind();

                    PersonaListaACT = new List<Persona>();
                    PersonaListaINA = new List<Persona>();

                    foreach(Persona item in PersonaLista)
                    {
                        if (!item.Baja)
                        {
                            PersonaListaACT.Add(item);
                        }
                        else
                        {
                            PersonaListaINA.Add(item);
                        }
                    }

                    repeaterPersonal.DataSource = PersonaListaACT;
                    repeaterPersonal.DataBind();
                    repeaterPersonal2.DataSource = PersonaListaINA;
                    repeaterPersonal2.DataBind();

                    int cont = 0;
                    foreach (Persona item in PersonaListaACT)
                    {
                        ((TextBox)repeaterPersonal.Items[cont].FindControl("Nombre")).Text = item.Nombre.ToUpper();
                        ((TextBox)repeaterPersonal.Items[cont].FindControl("Apellido")).Text = item.Apellido.ToUpper();
                        ((TextBox)repeaterPersonal.Items[cont].FindControl("Dni")).Text = item.Dni;                   

                        //Se agregan los datos de la lista DropDonwList
                        ((DropDownList)repeaterPersonal.Items[cont].FindControl("DDL_Cargo")).DataSource = listaCargo;
                        ((DropDownList)repeaterPersonal.Items[cont].FindControl("DDL_Cargo")).DataTextField = "Descripcion";
                        ((DropDownList)repeaterPersonal.Items[cont].FindControl("DDL_Cargo")).DataValueField = "Id";
                        ((DropDownList)repeaterPersonal.Items[cont].FindControl("DDL_Cargo")).DataBind();
                        ((DropDownList)repeaterPersonal.Items[cont].FindControl("DDL_Cargo")).SelectedValue = item.Cargo.Id.ToString();

                        if (item.Cargo.Descripcion.ToUpper() == "GERENTE" && item.Id != ((Persona)Session["UserLog"]).Id)
                        {
                            ((Button)repeaterPersonal.Items[cont].FindControl("ButtonA")).Visible = false;
                            ((Button)repeaterPersonal.Items[cont].FindControl("ButtonA")).Enabled = false;
                            ((Button)repeaterPersonal.Items[cont].FindControl("ButtonD")).Visible = false;
                            ((Button)repeaterPersonal.Items[cont].FindControl("ButtonD")).Enabled = false;
                        }
                        cont++;
                    }
                    cont = 0;
                    foreach (Persona item in PersonaListaINA)
                    {
                        ((TextBox)repeaterPersonal2.Items[cont].FindControl("Nombre2")).Text = item.Nombre.ToUpper();
                        ((TextBox)repeaterPersonal2.Items[cont].FindControl("Apellido2")).Text = item.Apellido.ToUpper();
                        ((TextBox)repeaterPersonal2.Items[cont].FindControl("Dni2")).Text = item.Dni;

                        //Se agregan los datos de la lista DropDonwList
                        ((DropDownList)repeaterPersonal2.Items[cont].FindControl("DDL_Cargo2")).DataSource = listaCargo;
                        ((DropDownList)repeaterPersonal2.Items[cont].FindControl("DDL_Cargo2")).DataTextField = "Descripcion";
                        ((DropDownList)repeaterPersonal2.Items[cont].FindControl("DDL_Cargo2")).DataValueField = "Id";
                        ((DropDownList)repeaterPersonal2.Items[cont].FindControl("DDL_Cargo2")).DataBind();
                        ((DropDownList)repeaterPersonal2.Items[cont].FindControl("DDL_Cargo2")).SelectedValue = item.Cargo.Id.ToString();
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
            filtrosPersonas = new FiltrosPersonas();
            filtrosPersonas.dni = TB_DNI.Text;
            filtrosPersonas.nombre = TB_Nombre.Text;
            filtrosPersonas.apellido = TB_Apellido.Text;
            try
            {
                PersonaLista = new List<Persona>();
                PersonaLista = negocioPersona.GetAllPersonas(filtrosPersonas);
                Session.Add("ListadoPersonal", PersonaLista);
                List<Cargo> listaCargo = new List<Cargo>();
                listaCargo.AddRange(negocioCargo.GetAllCargos());

                PersonaListaACT = new List<Persona>();
                PersonaListaINA = new List<Persona>();

                foreach (Persona item in PersonaLista)
                {
                    if (!item.Baja)
                    {
                        PersonaListaACT.Add(item);
                    }
                    else
                    {
                        PersonaListaINA.Add(item);
                    }
                }

                repeaterPersonal.DataSource = PersonaListaACT;
                repeaterPersonal.DataBind();
                repeaterPersonal2.DataSource = PersonaListaINA;
                repeaterPersonal2.DataBind();

                int cont = 0;
                foreach (Persona item in PersonaListaACT)
                {
                    ((TextBox)repeaterPersonal.Items[cont].FindControl("Nombre")).Text = item.Nombre.ToUpper();
                    ((TextBox)repeaterPersonal.Items[cont].FindControl("Apellido")).Text = item.Apellido.ToUpper();
                    ((TextBox)repeaterPersonal.Items[cont].FindControl("Dni")).Text = item.Dni;

                    //Se agregan los datos de la lista DropDonwList
                    ((DropDownList)repeaterPersonal.Items[cont].FindControl("DDL_Cargo")).DataSource = listaCargo;
                    ((DropDownList)repeaterPersonal.Items[cont].FindControl("DDL_Cargo")).DataTextField = "Descripcion";
                    ((DropDownList)repeaterPersonal.Items[cont].FindControl("DDL_Cargo")).DataValueField = "Id";
                    ((DropDownList)repeaterPersonal.Items[cont].FindControl("DDL_Cargo")).DataBind();
                    ((DropDownList)repeaterPersonal.Items[cont].FindControl("DDL_Cargo")).SelectedValue = item.Cargo.Id.ToString();

                    if (item.Cargo.Descripcion.ToUpper() == "GERENTE" && item.Id != ((Persona)Session["UserLog"]).Id)
                    {
                        ((Button)repeaterPersonal.Items[cont].FindControl("ButtonA")).Visible = false;
                        ((Button)repeaterPersonal.Items[cont].FindControl("ButtonA")).Enabled = false;
                        ((Button)repeaterPersonal.Items[cont].FindControl("ButtonD")).Visible = false;
                        ((Button)repeaterPersonal.Items[cont].FindControl("ButtonD")).Enabled = false;
                    }
                    cont++;
                }
                cont = 0;
                foreach (Persona item in PersonaListaINA)
                {
                    ((TextBox)repeaterPersonal2.Items[cont].FindControl("Nombre2")).Text = item.Nombre.ToUpper();
                    ((TextBox)repeaterPersonal2.Items[cont].FindControl("Apellido2")).Text = item.Apellido.ToUpper();
                    ((TextBox)repeaterPersonal2.Items[cont].FindControl("Dni2")).Text = item.Dni;

                    //Se agregan los datos de la lista DropDonwList
                    ((DropDownList)repeaterPersonal2.Items[cont].FindControl("DDL_Cargo2")).DataSource = listaCargo;
                    ((DropDownList)repeaterPersonal2.Items[cont].FindControl("DDL_Cargo2")).DataTextField = "Descripcion";
                    ((DropDownList)repeaterPersonal2.Items[cont].FindControl("DDL_Cargo2")).DataValueField = "Id";
                    ((DropDownList)repeaterPersonal2.Items[cont].FindControl("DDL_Cargo2")).DataBind();
                    ((DropDownList)repeaterPersonal2.Items[cont].FindControl("DDL_Cargo2")).SelectedValue = item.Cargo.Id.ToString();
                    cont++;
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
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
            Persona aux = new Persona();

            int cont = 0;
            foreach (Persona item in ((List<Persona>)Session["ListadoPersonal"]))
            {
                if (argument == item.Id.ToString()
                    && ((TextBox)repeaterPersonal.Items[cont].FindControl("Nombre")).Text != ""
                    && ((TextBox)repeaterPersonal.Items[cont].FindControl("Apellido")).Text != ""
                    && ((TextBox)repeaterPersonal.Items[cont].FindControl("Dni")).Text != "")
                {
                    aux.Id = item.Id;
                    aux.Nombre = ((TextBox)repeaterPersonal.Items[cont].FindControl("Nombre")).Text;
                    aux.Apellido = ((TextBox)repeaterPersonal.Items[cont].FindControl("Apellido")).Text;
                    aux.Dni = ((TextBox)repeaterPersonal.Items[cont].FindControl("Dni")).Text;
                    aux.Cargo = new Cargo(int.Parse(DDL_CargoNew.SelectedItem.Value), DDL_CargoNew.SelectedItem.Text);
                    aux.Baja = false;

                    negocioPersona.UpdatePersona(aux);
                }
                if (item.Baja) cont++;
            }
            Response.Redirect("Gerente-Personal.aspx");
        }

        protected void Borrar(object sender, EventArgs e)
        {
            var argument = int.Parse(((Button)sender).CommandArgument);

            ((List<Persona>)Session["ListadoPersonal"]).Find(x => x.Id == argument).Baja = true;

            negocioPersona.UpdatePersona(((List<Persona>)Session["ListadoPersonal"]).Find(x => x.Id == argument));

            Response.Redirect("Gerente-Personal.aspx");
        }

        protected void Agregar(object sender, EventArgs e)
        {
            Persona aux = new Persona();
            if (NombreNew.Text != "" && ApellidoNew.Text != "" && DniNew.Text != "" && DDL_CargoNew.SelectedItem.Text != "")
            {
                aux.Nombre = NombreNew.Text;
                aux.Apellido = ApellidoNew.Text;
                aux.Dni = DniNew.Text;
                aux.Cargo = new Cargo(int.Parse(DDL_CargoNew.SelectedItem.Value), DDL_CargoNew.SelectedItem.Text);           
                aux.Baja = false;
                negocioPersona.InsertPersona(aux);
            }
            else
            {
                string script = @"<script type='text/javascript'>abrirventanaEmerg();</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", script, false);
            }
            Response.Redirect("Gerente-Personal.aspx");
        }

        protected void Reactivar_Persona(object sender, EventArgs e)
        {


            var argument = int.Parse(((Button)sender).CommandArgument);

            ((List<Persona>)Session["ListadoPersonal"]).Find(x => x.Id == argument).Baja = false;

           negocioPersona.UpdatePersona( ((List<Persona>)Session["ListadoPersonal"]).Find(x => x.Id == argument));

            Response.Redirect("Gerente-Personal.aspx");
        }

    }
}
