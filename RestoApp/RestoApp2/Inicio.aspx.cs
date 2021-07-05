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
        public bool abrir;
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            Consultas logueo = new Consultas();
            if (abrir == false) { abrir = true; logueo.MesasVacias(); }*/
        }

        protected void ingreso(object sender, EventArgs e)
        {
            Consultas logueo = new Consultas();
            if (TextBox1.Text != "" && TextBox2.Text != "")
            {
                if (logueo.ValidarLogueo(TextBox1.Text, TextBox2.Text))
                {
                    if (logueo.userLog.Cargo.Descripcion == "Empleado")
                    {
                        Response.Redirect("Mesero.aspx?id=" + logueo.userLog.Id);
                    }
                    else if (logueo.userLog.Cargo.Descripcion == "Gerente")
                    {
                        Response.Redirect("Gerente.aspx?id=" + logueo.userLog.Id);
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

        protected void MenuVer(object sender, EventArgs e)
        {
            Consultas logueo = new Consultas();
            Response.Redirect("Menu.aspx?id=" + logueo.userLog.Id);
        }
    }
}