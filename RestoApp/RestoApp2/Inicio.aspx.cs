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
        public bool redit;
        protected void Page_Load(object sender, EventArgs e)
        {
            Consultas Consulta = new Consultas();
            if (Session["MesasGerente"]==null)
            {
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
                            ((UpdatePanel)Master.FindControl("NavUpdate")).Update();
                            
                            Response.Redirect("Gerente.aspx");
                        }
                        else
                        {
                            msjError.Text = "USUARIO NO ENCONTRADO!";
                            string script = @"<script type='text/javascript'>abrirventanaEmerg();</script>";
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", script, false);

                        }
                    }
                    else
                    {
                        msjError.Text = "VERIFIQUE LOS CAMPOS!";
                        string script = @"<script type='text/javascript'>abrirventanaEmerg();</script>";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", script, false);
                    }
                }
                else
                {
                    msjError.Text = "DEBES INGRESAR LOS CAMPOS!";
                    string script = @"<script type='text/javascript'>abrirventanaEmerg();</script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", script, false);
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
            }


        }


        protected void MenuVer(object sender, EventArgs e)
        {
            Response.Redirect("Menu.aspx");
        }


    

    }
}

