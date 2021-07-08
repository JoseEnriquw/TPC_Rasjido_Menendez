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
    public partial class _Default : Page
    {
        
        public List<Dominio.Persona> ListaPersonas = new List<Persona>();
        protected void Page_Load(object sender, EventArgs e)
        {
            Consultas Consulta = new Consultas();
            ListaPersonas= Consulta.ListarPersona(" ");
            Session["ListaPersonas"]= ListaPersonas;

            if (!IsPostBack)
            {
                //Fijarse (no es publica la lista se debe intentar con session)
                Consulta.mesasPubl = Consulta.CrearMesas();
            }
        }

        protected void ingreso(object sender, EventArgs e)
        {
            try
            {
                Consultas logueo = new Consultas();
                if (TextBox1.Text != "" && TextBox2.Text != "")
                {
                    if (logueo.ValidarLogueo(TextBox1.Text, TextBox2.Text))
                    {
                        if (logueo.userLog.Cargo.Descripcion == "Empleado")
                        {
                            Response.Redirect("Mesero.aspx?id="+logueo.userLog.Id.ToString());
                        }
                        else if (logueo.userLog.Cargo.Descripcion == "Gerente")
                        {
                            Response.Redirect("Gerente.aspx?id="+logueo.userLog.Id.ToString());
                        }
                        else
                        {
                            Response.Write("<script>alert('USUARIO NO ENCONTRADO!');</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('VERIFIQUE LOS CAMPOS!');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('DEBES INGRESAR LOS CAMPOS!');</script>");
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
            }


        }

        protected void MenuVer(object sender, EventArgs e)
        {
            Consultas logueo = new Consultas();
            Response.Redirect("Menu.aspx?id="+ logueo.userLog.Id.ToString());
        }
    }
}