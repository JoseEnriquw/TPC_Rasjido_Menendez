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
                aux.ID = (int)accessdata.Lector["ID"];
                aux.Nombre = (string)accessdata.Lector["Nombre"];

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
                aux.ID = (int)accessdata.Lector["ID"];
                aux.Nombre = (string)accessdata.Lector["Nombre"];
                aux.IDcategoria = (int)accessdata.Lector["IDcategoria"];
                aux.tipo = (string)accessdata.Lector["Tipo"];
                aux.Precio = (decimal)accessdata.Lector["Precio"];

                lista.Add(aux);
            }
            return lista;
        }

        public List<Pedido> ListarPedido(string consulta)
        {
            List<Pedido> lista = new List<Pedido>();
            accessdata.setearConsulta(consulta);
            accessdata.ejecutarLectura();
            while (accessdata.Lector.Read())
            {
                Pedido aux = new Pedido();
                aux.ID = (int)accessdata.Lector["ID"];
                aux.IDMesa = (int)accessdata.Lector["IDMesa"];
                aux.Precio = (decimal)accessdata.Lector["Precio"];
                aux.Cantidad = (int)accessdata.Lector["Cantidad"];
                aux.Estado = (bool)accessdata.Lector["Estado"];

                lista.Add(aux);
            }
            return lista;
        }

        public List<Persona> ListarPersona(string consulta)
        {
            List<Persona> lista = new List<Persona>();
            accessdata.setearConsulta(consulta);
            accessdata.ejecutarLectura();
            while (accessdata.Lector.Read())
            {
                Persona aux = new Persona();
                aux.ID = (int)accessdata.Lector["Id"];
                aux.IDCargo = (int)accessdata.Lector["IDCargo"];
                aux.DNI = (string)accessdata.Lector["DNI"];
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
                aux.ID = (int)accessdata.Lector["ID"];
                aux.DNI = (string)accessdata.Lector["DNI"];
                aux.Contraseña = (string)accessdata.Lector["Contraseña"];

                lista.Add(aux);
            }


            return lista;
        }

        public List<Stock> ListarStock(string consulta)
        {
            List<Stock> lista = new List<Stock>();
            accessdata.setearConsulta(consulta);
            accessdata.ejecutarLectura();
            while (accessdata.Lector.Read())
            {
                Stock aux = new Stock();
                aux.ID = (int)accessdata.Lector["Id"];
                aux.IDInsumo = (int)accessdata.Lector["IDInsumo"];
                aux.cantidad = (int)accessdata.Lector["cantidad"];

                lista.Add(aux);
            }


            return lista;
        }

        public List<Mesa> ListarMesa(string consulta)
        {
            List<Mesa> lista = new List<Mesa>();
            accessdata.setearConsulta(consulta);
            accessdata.ejecutarLectura();
            while (accessdata.Lector.Read())
            {
                Mesa aux = new Mesa();
                aux.ID = (int)accessdata.Lector["ID"];
                aux.IDMesero = (int)accessdata.Lector["IDMesero"];

                lista.Add(aux);
            }


            return lista;
        }

        public List<Categorias> ListarCategorias(string consulta)
        {
            List<Categorias> lista = new List<Categorias>();
            accessdata.setearConsulta(consulta);
            accessdata.ejecutarLectura();
            while (accessdata.Lector.Read())
            {
                Categorias aux = new Categorias();
                aux.ID = (int)accessdata.Lector["ID"];
                aux.Nombre = (string)accessdata.Lector["Nombre"];

                lista.Add(aux);
            }


            return lista;
        }

    }
}
