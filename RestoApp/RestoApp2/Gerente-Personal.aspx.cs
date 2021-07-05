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
    public partial class Gerente_Personal : System.Web.UI.Page
    {
        public List<Persona> PersonaLista=new List<Persona>();
        protected void Page_Load(object sender, EventArgs e)
        {
            Consultas personal = new Consultas();
            try
            {
                PersonaLista = personal.ListarPersona("");
                Session.Add("ListadoPersonal", PersonaLista);
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
            }
        }

        protected void OnTextChanged_Filtros(object sender, EventArgs e)
        {
            string DNI = TB_DNI.Text;
            string Nombre = TB_Nombre.Text;
            string Apellido =TB_Apellido.Text ;


            //Los 3 tienen datos
            if (DNI !=" " && Nombre != " " && Apellido != " ")
            {
                PersonaLista = ((List<Persona>)Session["ListadoPersonal"]).FindAll(x => x.Dni.Contains(DNI) && x.Nombre.Contains(Nombre) && x.Apellido.Contains(Apellido) );

            }
            //DNI no tiene Datos y los demas si
           else if (DNI == " " && Nombre != " " && Apellido != " ")
            {
                PersonaLista = ((List<Persona>)Session["ListadoPersonal"]).FindAll(x => x.Nombre.Contains(Nombre) && x.Apellido.Contains(Apellido));

            }
            //Nombre no tine datos y los demas si
           else if (DNI != " " && Nombre == " " && Apellido != " ")
            {
                PersonaLista = ((List<Persona>)Session["ListadoPersonal"]).FindAll(x => x.Dni.Contains(DNI) &&  x.Apellido.Contains(Apellido));

            }
            //Apellido no tiene datos y los demas si 
           else if (DNI != " " && Nombre != " " && Apellido == " ")
            {
                PersonaLista = ((List<Persona>)Session["ListadoPersonal"]).FindAll(x => x.Dni.Contains(DNI) && x.Nombre.Contains(Nombre) );

            }
            //Solo DNI tiene datos
           else if (DNI != " " && Nombre == " " && Apellido == " ")
            {
                PersonaLista = ((List<Persona>)Session["ListadoPersonal"]).FindAll(x => x.Dni.Contains(DNI) );

            }
            //Solo Nombre tiene datos
           else if (DNI == " " && Nombre != " " && Apellido == " ")
            {
                PersonaLista = ((List<Persona>)Session["ListadoPersonal"]).FindAll(x => x.Nombre.Contains(Nombre) );

            }
            //Solo Apellido tiene datos
           else if (DNI == " " && Nombre == " " && Apellido != " ")
            {
                PersonaLista = ((List<Persona>)Session["ListadoPersonal"]).FindAll(x =>  x.Apellido.Contains(Apellido));

            }
           else {
               
                PersonaLista = ((List<Persona>)Session["ListadoPersonal"]);
            }
        }
    }
}

