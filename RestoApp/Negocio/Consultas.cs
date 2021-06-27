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

        public List<Cargo> ListarCargos(string consulta)
        {
            List<Cargo> lista = new List<Cargo>();
            accessdata.setearConsulta(consulta);
            accessdata.ejecutarLectura();
            while (accessdata.Lector.Read())
            {
                Cargo aux = new Cargo();
                aux.Id = (int)accessdata.Lector["Id"];
                aux.Descripcion = (string)accessdata.Lector[".Descripcion"];

                lista.Add(aux);
            }
            return lista;
        }

        public List<Insumo> ListarInsumo(string consulta)
        {
            List<Insumo> lista = new List<Insumo>();
            accessdata.setearConsulta(consulta);
            accessdata.ejecutarLectura();
            while (accessdata.Lector.Read())
            {
                Insumo aux = new Insumo();
                aux.Id = (int)accessdata.Lector["Id"];
                aux.Nombre = (string)accessdata.Lector["Nombre"];
                aux.Categoria.Id = (int)accessdata.Lector["C.Id"];
                aux.Categoria.Descripcion = (string)accessdata.Lector["C.Descripcion"];
                aux.Tipo.Id = (int)accessdata.Lector["T.Id"];
                aux.Tipo.Descripcion = (string)accessdata.Lector["T.Descripcion"];
                aux.Precio = (decimal)accessdata.Lector["Precio"];

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

        public List<Persona> ListarPersona(string consulta)
        {
            List<Persona> lista = new List<Persona>();
            accessdata.setearConsulta(consulta);
            accessdata.ejecutarLectura();
            while (accessdata.Lector.Read())
            {
                Persona aux = new Persona();
                aux.Id = (int)accessdata.Lector["Id"];
                aux.Cargo.Id = (int)accessdata.Lector["C.Id"];
                aux.Cargo.Descripcion = (string)accessdata.Lector["C.Descripcion"];
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

        //public List<Stock> ListarStock(string consulta)
        //{
        //    List<Stock> lista = new List<Stock>();
        //    accessdata.setearConsulta(consulta);
        //    accessdata.ejecutarLectura();
        //    while (accessdata.Lector.Read())
        //    {
        //        Stock aux = new Stock();
        //        aux.Id = (int)accessdata.Lector["Id"];
        //        aux.Id = (int)accessdata.Lector["Id"];
        //        aux.Insumo.Nombre = (string)accessdata.Lector["Nombre"];
        //        aux.Insumo.Categoria.Id = (int)accessdata.Lector["C.Id"];
        //        aux.Insumo.Categoria.Descripcion = (string)accessdata.Lector["C.Descripcion"];
        //        aux.Insumo.Tipo.Id = (int)accessdata.Lector["T.Id"];
        //        aux.Insumo.Tipo.Descripcion = (string)accessdata.Lector["T.Descripcion"];
        //        aux.Insumo.Precio = (decimal)accessdata.Lector["Precio"];
        //        aux.Insumo.Cantidad = (int)accessdata.Lector["Cantidad"];

        //        lista.Add(aux);
        //    }


        //    return lista;
        //}

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

        public List<Categorias> ListarCategorias(string consulta)
        {
            List<Categorias> lista = new List<Categorias>();
            accessdata.setearConsulta(consulta);
            accessdata.ejecutarLectura();
            while (accessdata.Lector.Read())
            {
                Categorias aux = new Categorias();
                aux.Id = (int)accessdata.Lector["ID"];
                aux.Descripcion = (string)accessdata.Lector["Nombre"];

                lista.Add(aux);
            }


            return lista;
        }

    }
}
