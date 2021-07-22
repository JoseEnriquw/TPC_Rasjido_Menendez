﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace RestoApp2
{
    public partial class Gerente_Personal : System.Web.UI.Page
    {
        public List<Persona> PersonaLista;
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
            if (!IsPostBack)
            {
                Consultas personal = new Consultas();
                try
                {

                    PersonaLista = personal.ListarPersona("");
                    Session.Add("ListadoPersonal", PersonaLista);

                    repeaterPersonal.DataSource = PersonaLista;
                    repeaterPersonal.DataBind();

                    int cont = 0;
                    foreach (Persona item in PersonaLista)
                    {
                        ((TextBox)repeaterPersonal.Items[cont].FindControl("Nombre")).Text = item.Nombre.ToUpper();
                        ((TextBox)repeaterPersonal.Items[cont].FindControl("Apellido")).Text = item.Apellido.ToUpper();
                        ((TextBox)repeaterPersonal.Items[cont].FindControl("Dni")).Text = item.Dni;
                        ((TextBox)repeaterPersonal.Items[cont].FindControl("Cargo")).Text = item.Cargo.Descripcion.ToUpper();
                        if (item.Cargo.Descripcion.ToUpper() == "GERENTE" && item.Id != ((Dominio.Persona)Session["UserLog"]).Id)
                        {
                            ((Button)repeaterPersonal.Items[cont].FindControl("ButtonA")).Visible = false;
                            ((Button)repeaterPersonal.Items[cont].FindControl("ButtonA")).Enabled = false;
                            ((Button)repeaterPersonal.Items[cont].FindControl("ButtonD")).Visible = false;
                            ((Button)repeaterPersonal.Items[cont].FindControl("ButtonD")).Enabled = false;
                        }
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
            string DNI = TB_DNI.Text;
            string Nombre = TB_Nombre.Text;
            string Apellido = TB_Apellido.Text;


            //Los 3 tienen datos
            if (DNI != " " && Nombre != " " && Apellido != " ")
            {
                PersonaLista = ((List<Persona>)Session["ListadoPersonal"]).FindAll(x => x.Dni.ToUpper().Contains(DNI.ToUpper()) && x.Nombre.ToUpper().Contains(Nombre.ToUpper()) && x.Apellido.ToUpper().Contains(Apellido.ToUpper()));

            }
            //DNI no tiene Datos y los demas si
            else if (DNI == " " && Nombre != " " && Apellido != " ")
            {
                PersonaLista = ((List<Persona>)Session["ListadoPersonal"]).FindAll(x => x.Nombre.ToUpper().Contains(Nombre.ToUpper()) && x.Apellido.ToUpper().Contains(Apellido.ToUpper()));

            }
            //Nombre no tine datos y los demas si
            else if (DNI != " " && Nombre == " " && Apellido != " ")
            {
                PersonaLista = ((List<Persona>)Session["ListadoPersonal"]).FindAll(x => x.Dni.ToUpper().Contains(DNI.ToUpper()) && x.Apellido.ToUpper().Contains(Apellido.ToUpper()));

            }
            //Apellido no tiene datos y los demas si 
            else if (DNI != " " && Nombre != " " && Apellido == " ")
            {
                PersonaLista = ((List<Persona>)Session["ListadoPersonal"]).FindAll(x => x.Dni.ToUpper().Contains(DNI.ToUpper()) && x.Nombre.ToUpper().Contains(Nombre.ToUpper()));

            }
            //Solo DNI tiene datos
            else if (DNI != " " && Nombre == " " && Apellido == " ")
            {
                PersonaLista = ((List<Persona>)Session["ListadoPersonal"]).FindAll(x => x.Dni.ToUpper().Contains(DNI.ToUpper()));

            }
            //Solo Nombre tiene datos
            else if (DNI == " " && Nombre != " " && Apellido == " ")
            {
                PersonaLista = ((List<Persona>)Session["ListadoPersonal"]).FindAll(x => x.Nombre.ToUpper().Contains(Nombre.ToUpper()));

            }
            //Solo Apellido tiene datos
            else if (DNI == " " && Nombre == " " && Apellido != " ")
            {
                PersonaLista = ((List<Persona>)Session["ListadoPersonal"]).FindAll(x => x.Apellido.ToUpper().Contains(Apellido.ToUpper()));

            }
            else
            {
                PersonaLista = ((List<Persona>)Session["ListadoPersonal"]);
            }
        }


        protected void actualizar(object sender, EventArgs e)
        {
            var argument = ((Button)sender).CommandArgument;
            Consultas personal = new Consultas();
            Persona aux = new Persona();

            int cont = 0;
            foreach (Persona item in ((List<Persona>)Session["ListadoPersonal"]))
            {
                if (argument == item.Id.ToString()
                    && ((TextBox)repeaterPersonal.Items[cont].FindControl("Nombre")).Text != ""
                    && ((TextBox)repeaterPersonal.Items[cont].FindControl("Apellido")).Text != ""
                    && ((TextBox)repeaterPersonal.Items[cont].FindControl("Dni")).Text != ""
                    && ((TextBox)repeaterPersonal.Items[cont].FindControl("Cargo")).Text != "")
                {
                    aux.Id = item.Id;
                    aux.Nombre = ((TextBox)repeaterPersonal.Items[cont].FindControl("Nombre")).Text;
                    aux.Apellido = ((TextBox)repeaterPersonal.Items[cont].FindControl("Apellido")).Text;
                    aux.Dni = ((TextBox)repeaterPersonal.Items[cont].FindControl("Dni")).Text;
                    aux.Cargo = new Cargo();
                    aux.Cargo.Descripcion = ((TextBox)repeaterPersonal.Items[cont].FindControl("Cargo")).Text.ToUpper();
                    if (aux.Cargo.Descripcion == "GERENTE") { aux.Cargo.Id = 1; } else { aux.Cargo.Id = 2; }

                    personal.actualizarPersona(true, aux);
                }
                cont++;
            }
            Response.Redirect("Gerente-Personal.aspx");
        }

        protected void borrar(object sender, EventArgs e)
        {
            var argument = ((Button)sender).CommandArgument;
            Consultas personal = new Consultas();
            Persona aux = new Persona();

            int cont = 0;
            foreach (Persona item in ((List<Persona>)Session["ListadoPersonal"]))
            {
                if (argument == item.Id.ToString()
                    && ((TextBox)repeaterPersonal.Items[cont].FindControl("Nombre")).Text != ""
                    && ((TextBox)repeaterPersonal.Items[cont].FindControl("Apellido")).Text != ""
                    && ((TextBox)repeaterPersonal.Items[cont].FindControl("Dni")).Text != ""
                    && ((TextBox)repeaterPersonal.Items[cont].FindControl("Cargo")).Text != "")
                {
                    aux.Id = item.Id;
                    aux.Nombre = ((TextBox)repeaterPersonal.Items[cont].FindControl("Nombre")).Text;
                    aux.Apellido = ((TextBox)repeaterPersonal.Items[cont].FindControl("Apellido")).Text;
                    aux.Dni = ((TextBox)repeaterPersonal.Items[cont].FindControl("Dni")).Text;
                    aux.Cargo = new Cargo();
                    aux.Cargo.Descripcion = ((TextBox)repeaterPersonal.Items[cont].FindControl("Cargo")).Text;
                    if (aux.Cargo.Descripcion == "Gerente") { aux.Cargo.Id = 1; } else { aux.Cargo.Id = 2; }

                    personal.actualizarPersona(false, aux);
                }
                cont++;
            }
            Response.Redirect("Gerente-Personal.aspx");
        }

        protected void agregar(object sender, EventArgs e)
        {
            Consultas personal = new Consultas();
            Persona aux = new Persona();
            if (NombreNew.Text != "" && ApellidoNew.Text != "" && DniNew.Text != "" && CargoNew.Text != "")
            {
                aux.Nombre = NombreNew.Text;
                aux.Apellido = ApellidoNew.Text;
                aux.Dni = DniNew.Text;
                aux.Cargo = new Cargo();
                aux.Cargo.Descripcion = CargoNew.Text;
                if (aux.Cargo.Descripcion == "Gerente") { aux.Cargo.Id = 1; } else { aux.Cargo.Id = 2; }
                personal.agregarPersonal(aux);
            }
            else
            {
                string script = @"<script type='text/javascript'>abrirventanaEmerg();</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", script, false);
            }
            Response.Redirect("Gerente-Personal.aspx");
        }
    }
}
