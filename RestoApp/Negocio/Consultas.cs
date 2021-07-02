using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;


namespace Negocio
{

    public class Consultas
    {
        AccessData accessdata = new AccessData("(local)\\SQLEXPRESS", "Rasjido_Menendez_DB");

      

        public List<Insumo> ListarInsumos(string where)
        {
            List<Insumo> lista = new List<Insumo>();
            accessdata.setearConsulta("select * from VW_Insumos " + where);
            accessdata.ejecutarLectura();
            while (accessdata.Lector.Read())
            {
                Insumo aux = new Insumo();
                aux.Id = (int)accessdata.Lector["Id"];
                aux.Nombre = (string)accessdata.Lector["Nombre"];
                aux.Categoria= (string)accessdata.Lector["Categoria"];
                aux.Tipo = (string)accessdata.Lector["Tipo"];
                aux.Precio = (decimal)accessdata.Lector["Precio"];
                aux.Stock = (short)accessdata.Lector["Stock"];
                aux.UrlImagen = (string)accessdata.Lector["UrlImg"];
                lista.Add(aux);
            }
            return lista;
        }

        //public List<Pedido> ListarPedido(string consulta)
        //{
        //    List<Pedido> lista = new List<Pedido>();
        //    accessdata.setearConsulta(consulta);
        //    accessdata.ejecutarLectura();
        //    while (accessdata.Lector.Read())
        //    {
        //        Pedido aux = new Pedido();
        //        aux.Id = (int)accessdata.Lector["Id"];
        //        aux.Precio = (decimal)accessdata.Lector["Precio"];
        //        aux.ListaItems.Add( (ItemsPedidos)accessdata.Lector["Items"]);
               

        //        lista.Add(aux);
        //    }
        //    return lista;
        //}

        public List<Persona> ListarPersona(string where)
        {
            List<Persona> lista = new List<Persona>();
            accessdata.setearConsulta("select *from VW_Personas" + where);
            accessdata.ejecutarLectura();
            while (accessdata.Lector.Read())
            {
                Persona aux = new Persona();
                aux.Id = (int)accessdata.Lector["Id"];
                aux.Cargo = (string)accessdata.Lector["Cargo"];
                aux.Dni = (string)accessdata.Lector["DNI"];
                aux.Nombre = (string)accessdata.Lector["Nombre"];
                aux.Apellido = (string)accessdata.Lector["Apellido"];

                lista.Add(aux);
            }
            return lista;
        }

        public List<Usuario> ListarUsuario(string consulta)
        {
            List<Usuario> lista = new List<Usuario>();
            accessdata.setearConsulta(consulta);
            accessdata.ejecutarLectura();
            while (accessdata.Lector.Read())
            {
                Usuario aux = new Usuario();
                aux.Id = (int)accessdata.Lector["ID"];
                aux.Dni = (string)accessdata.Lector["DNI"];
                aux.Contraseña = (string)accessdata.Lector["Contraseña"];

                lista.Add(aux);
            }


            return lista;
        }

        

        //public List<Mesa> ListarMesa(string consulta)
        //{
        //    List<Mesa> lista = new List<Mesa>();
        //    accessdata.setearConsulta(consulta);
        //    accessdata.ejecutarLectura();
        //    while (accessdata.Lector.Read())
        //    {
        //        Mesa aux = new Mesa();
        //        aux.Id = (int)accessdata.Lector["ID"];
        //        aux.IDMeser = (int)accessdata.Lector["IDMesero"];

        //        lista.Add(aux);
        //    }


        //    return lista;
        //}

  

    }
}
