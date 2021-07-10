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
        
       
        public Persona userLog = new Persona();
        protected void Page_Load(object sender, EventArgs e)
        {
            Consultas Consulta = new Consultas();
     

            if (Session["MesasGerente"]==null)
            {
                //Fijarse (no es publica la lista se debe intentar con session)
                Session["MesasGerente"] = Consulta.CrearMesas();

            }
        }

        protected void ingreso(object sender, EventArgs e)
        {
            try
            {
                Consultas logueo = new Consultas();
                if (TextBox1.Text != "" && TextBox2.Text != "")
                {
                    if (logueo.ValidarLogueo(TextBox1.Text, TextBox2.Text,ref userLog))
                    {
                        Session["UserLog"] = userLog;
                        if (userLog.Cargo.Descripcion == "Empleado")
                        {
                            Response.Redirect("Mesero.aspx");
                        }
                        else if (userLog.Cargo.Descripcion == "Gerente")
                        {
                            Response.Redirect("Gerente.aspx");
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
            Response.Redirect("Menu.aspx");
        }


    

    }
}

