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

        public List<Cargo_TipoInsumo> ListarCargos_TipoInsumo(string consulta)
        {
            List<Cargo_TipoInsumo> lista = new List<Cargo_TipoInsumo>();
            accessdata.setearConsulta(consulta);
            accessdata.ejecutarLectura();
            while (accessdata.Lector.Read())
            {
                Cargo_TipoInsumo aux = new Cargo_TipoInsumo();
                aux.ID = (int)accessdata.Lector["Id"];
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
                aux.ID = (int)accessdata.Lector["Id"];
                aux.IDTipo = (int)accessdata.Lector["IDTipo"];
                aux.Nombre = (string)accessdata.Lector["Nombre"];
                aux.Precio = (float)accessdata.Lector["Precio"];

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
                aux.ID = (int)accessdata.Lector["Id"];
                aux.IDMesa = (int)accessdata.Lector["IDMesa"];
                aux.IDInsumo = (int)accessdata.Lector["IDInsumo"];
                aux.Cantidad = (int)accessdata.Lector["Cantidad"];
                aux.Precio = (float)accessdata.Lector["Precio"];
                aux.Estado = (bool)accessdata.Lector["Estado"];
                aux.FechaHora = (DateTime)accessdata.Lector["FechaHora"];

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
                aux.DNI = (int)accessdata.Lector["DNI"];
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
                aux.ID = (int)accessdata.Lector["Id"];
                aux.DNI = (int)accessdata.Lector["DNI"];
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
                aux.ID = (int)accessdata.Lector["Id"];
                aux.IDMesero = (int)accessdata.Lector["IDMesero"];

                lista.Add(aux);
            }


            return lista;
        }

    }
}
