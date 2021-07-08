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
        public AccessData accessdata = new AccessData("(local)\\SQLEXPRESS", "TPC_Rasjido_Menendez_DB");
        public Persona userLog = new Persona();
        public List<Mesa> mesasPriv = new List<Mesa>();
        public List<Mesa> mesasPubl = new List<Mesa>(); 

        //Categorias
        public List<Categorias> FiltrosCategorias()
        {
            List<Categorias> Lista = new List<Categorias>();

            try
            {
                accessdata.setearConsulta("Select ID,Descripcion from Categorias ");
                accessdata.ejecutarLectura();

                while (accessdata.Lector.Read())
                {
                    Categorias aux = new Categorias();
                    aux.Id = accessdata.Lector.GetInt32(0);
                    aux.Descripcion = accessdata.Lector.GetString(1);
                    Lista.Add(aux);

                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                accessdata.cerrarConexion();
            }

            return Lista;
        }

        //Tipo de Insumo
        public List<TipoInsumo> FiltrosTipoInsumo()
        {
            List<TipoInsumo> Lista = new List<TipoInsumo>();

            try
            {
                accessdata.setearConsulta("Select ID,Descripcion from TipoInsumos ");
                accessdata.ejecutarLectura();

                while (accessdata.Lector.Read())
                {
                    TipoInsumo aux = new TipoInsumo();
                    aux.Id = accessdata.Lector.GetInt32(0);
                    aux.Descripcion = accessdata.Lector.GetString(1);
                    Lista.Add(aux);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                accessdata.cerrarConexion();
            }

            return Lista;
        }

        //Insumos
        public List<Insumo> ListarInsumos(string where)
        {
            List<Insumo> lista = new List<Insumo>();

            try
            {
                accessdata.setearConsulta("select * from VW_Insumos " + where + " order by Precio asc");
                accessdata.ejecutarLectura();
                while (accessdata.Lector.Read())
                {
                    Insumo aux = new Insumo();
                    aux.Id = (int)accessdata.Lector.GetInt32(0);
                    aux.Nombre = (string)accessdata.Lector.GetString(1);

                    aux.Categoria = new Categorias(accessdata.Lector.GetInt32(2), accessdata.Lector.GetString(3));
                    aux.Tipo = new TipoInsumo((int)accessdata.Lector.GetInt32(4), accessdata.Lector.GetString(5));
                    aux.Precio = (decimal)accessdata.Lector["Precio"];
                    aux.Stock = (short)accessdata.Lector["Stock"];
                    aux.UrlImagen = (string)accessdata.Lector.GetString(8);

                    lista.Add(aux);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                accessdata.cerrarConexion();
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

        //Personas
        public List<Persona> ListarPersona(string where)
        {
            List<Persona> lista = new List<Persona>();

            try
            {
                accessdata.setearConsulta("select * from VW_Personas" + where);
                accessdata.ejecutarLectura();
                while (accessdata.Lector.Read())
                {
                    Persona aux = new Persona();
                    aux.Id = accessdata.Lector.GetInt32(0);
                    aux.Cargo=new Cargo( accessdata.Lector.GetInt32(1),accessdata.Lector.GetString(2));
                    aux.Dni = accessdata.Lector.GetString(3);
                    aux.Nombre = accessdata.Lector.GetString(4);
                    aux.Apellido = accessdata.Lector.GetString(5);

                    lista.Add(aux);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                accessdata.cerrarConexion();
            }  
            
            return lista;
        }

        //Usuario
        public List<Usuario> ListarUsuario(string consulta)
        {
            List<Usuario> lista = new List<Usuario>();

            try
            {
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
            }
            catch (Exception ex)
            {
                 throw ex;
            }
            finally
            {
                accessdata.cerrarConexion();
            }

            return lista;
        }

        public bool ValidarLogueo(string _dni, string _pass)
        {
            accessdata.setearConsulta("select * from Usuarios where DNI = '" + _dni + "' AND Contraseña = '" + _pass + "'");
            accessdata.ejecutarLectura();
            if (accessdata.Lector.Read())
            {
                accessdata.cerrarConexion();
                List<Persona> lista = ListarPersona(" where DNI='" + _dni + "'");
                if (lista.Count == 1)
                {
                    userLog.Id = lista[0].Id;
                    userLog.Nombre = lista[0].Nombre;
                    userLog.Apellido = lista[0].Apellido;
                    userLog.Cargo = new Cargo(lista[0].Cargo.Id, lista[0].Cargo.Descripcion);
                    userLog.Dni = lista[0].Dni;
                    return true;
                }
            }


            accessdata.cerrarConexion();
            return false;
        }

        //Lista publica
        public List<Mesa> CrearMesas()
        {
              List<Mesa> lista = new List<Mesa>();
              accessdata.setearConsulta("select ID from Mesas");
              accessdata.ejecutarLectura();
              while (accessdata.Lector.Read())
                {
                Mesa aux = new Mesa();
                aux.NumeroMesa = (int)accessdata.Lector["ID"];
                aux.Mesero = new Persona();
                aux.Mesero.Nombre = "S/";
                aux.Mesero.Apellido = "mesero";
                aux.Pedidos = new Pedido();
                aux.Estado = "abierto";
                lista.Add(aux);
            }
           return lista;
        }

        //Lista privada para mesero
        public List<Mesa> VistaMesero(List<Mesa> lista)
        {
            for (int i = 0; i < lista.Count(); i++)
            {
                if (lista[i].Mesero.Id != userLog.Id && lista[i].Estado=="abierto")
                {
                    lista[i].Estado = "cerrado";
                }
            }
            return lista;
        }

        //Actualizacion lista publica
        public List<Mesa> MeseroAct(List<Mesa> lista, Mesa itemAct)
        {
            for (int i = 0; i < lista.Count; i++)
            {
                if(lista[i].NumeroMesa == itemAct.NumeroMesa)
                {
                    lista[i].Mesero = itemAct.Mesero;
                    lista[i].Pedidos = itemAct.Pedidos;
                    lista[i].Estado = itemAct.Estado;
                }
            }
            return lista;
        }

    }
}
