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
        public void actualizarPersona(bool opcion, Persona aux)
        {
            try
            {
                string id = " ID=" + aux.Id.ToString();
                string cargo = " IDCargo=" + aux.Cargo.Id.ToString();
                string dni = " DNI='" + aux.Dni + "'";
                string nombre = " Nombre='" + aux.Nombre + "'";
                string apellido = " Apellido='" + aux.Apellido + "'";

                if (opcion == true)
                {
                    accessdata.setearConsulta("update Personas set" + cargo + " ," + dni + " ," + nombre + " ," + apellido + " where"+ id);
                }
                else
                {
                    accessdata.setearConsulta("delete from Personas where" + id);
                }

                accessdata.ejectutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                accessdata.cerrarConexion();
            }
        }

        public void agregarPersonal(Persona aux)
        {
            try
            {
                string id = aux.Id.ToString();
                string cargo = aux.Cargo.Id.ToString();
                string dni = aux.Dni;
                string nombre = aux.Nombre;
                string apellido = aux.Apellido;

                accessdata.setearConsulta("insert into Personas values(" + cargo + ",'" + dni + "','" + nombre + "','" + apellido + "')");  
                accessdata.ejectutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                accessdata.cerrarConexion();
            }
        }

        public void actualizarInsumo(bool opcion, Insumo aux)
        {
            try
            {
                string id = " ID=" + aux.Id.ToString();
                string nombre = " Nombre='" + aux.Nombre + "'";
                string idcategoria = " IDCategoria=" + aux.Categoria.Id.ToString();
                string idtipo = " IDTipo=" + aux.Tipo.Id.ToString();
                string precio = " Precio=" + aux.Precio.ToString();
                string stock = " Stock=" + aux.Stock.ToString();
                string url = " UrlImg='" + aux.UrlImagen + "'";


                if (opcion == true)
                {
                    accessdata.setearConsulta("update Insumos set"+ stock + " where" + id);
                }
                else
                {
                    accessdata.setearConsulta("delete from Insumos where" + id);
                }

                accessdata.ejectutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                accessdata.cerrarConexion();
            }
        }

        public void agregarInsumo(Insumo aux)
        {
            try
            {
                string id = aux.Id.ToString();
                string nombre = aux.Nombre;
                string idcategoria = aux.Categoria.Id.ToString();
                string idtipo = aux.Tipo.Id.ToString();
                string precio = aux.Precio.ToString();
                string stock = aux.Stock.ToString();
                string url = aux.UrlImagen;

                accessdata.setearConsulta("insert into Insumos values('" + nombre + "'," + idcategoria + "," + idtipo + "," + precio + "," + stock + ",'" + url + "')");
                accessdata.ejectutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                accessdata.cerrarConexion();
            }
        }

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

        public bool ValidarLogueo(string _dni, string _pass, ref Persona userLog)
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
            int cont = 1;
              List<Mesa> lista = new List<Mesa>();
              accessdata.setearConsulta("select * from Mesas");
              accessdata.ejecutarLectura();
              while (accessdata.Lector.Read())
                {
                Mesa aux = new Mesa();

                aux.NumeroMesa = (int)accessdata.Lector["ID"];
                if ((String)accessdata.Lector["Descripcion"] == "none") { aux.Nombre = "N°" + cont.ToString(); }
                else { aux.Nombre = (String)accessdata.Lector["Descripcion"]; }

                aux.Mesero = new Persona();
                aux.Mesero.Nombre = "S/";
                aux.Mesero.Apellido = "mesero";
                aux.Pedidos = new Pedido();
                aux.Estado = "libre";
                lista.Add(aux);
                cont++;
            }
           return lista;
        }

        public int cantidadMesas()
        {
            int cant = 0;
            accessdata.setearConsulta("select * from Mesas");
            accessdata.ejecutarLectura();
            while (accessdata.Lector.Read())
            {
                cant++;
            }
            accessdata.cerrarConexion();
            return cant;
        }

        public void MesasInsert(int cantidadNueva, int cantidadAnterior)
        {
            int dif = cantidadNueva - cantidadAnterior;
            if (cantidadAnterior == cantidadNueva) { }
            else if (cantidadAnterior < cantidadNueva)
            {
                for (int i = 0; i < (cantidadNueva - cantidadAnterior); i++)
                {
                    accessdata.setearConsulta("insert into Mesas values ('none')");
                    accessdata.ejectutarAccion();
                    accessdata.cerrarConexion();
                }
            }
            else
            {
                accessdata.setearConsulta("delete Mesas where ID = (select top(" + dif + ") ID from Mesas order by ID desc)");
                accessdata.ejectutarAccion();
                accessdata.cerrarConexion();
            }
        }
    }
}
