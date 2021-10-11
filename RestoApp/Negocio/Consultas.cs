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
                    aux.Baja = accessdata.Lector.GetBoolean(9);

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
        public void ActualizarPersona(bool opcion, Persona aux)
        {
            try
            {
                string id = " ID=" + aux.Id.ToString();
                string cargo = " IDCargo=" + aux.Cargo.Id.ToString();
                string dni = " DNI='" + aux.Dni + "'";
                string nombre = " Nombre='" + aux.Nombre + "'";
                string apellido = " Apellido='" + aux.Apellido + "'";
                string baja = " Baja=" + Convert.ToByte(aux.Baja).ToString();

                if (opcion == true)
                {
                    accessdata.setearConsulta("update Personas set" + cargo + " ," + dni + " ," + nombre + " ," + apellido + " ,"+ baja+" where"+ id);
                }
                else
                {
                    accessdata.setearConsulta("update Personas set Baja = 0 where" + id);
                }

                accessdata.ejecutarAccion();
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

        public void AgregarPersonal(Persona aux)
        {
            try
            {
                string id = aux.Id.ToString();
                string cargo = aux.Cargo.Id.ToString();
                string dni = aux.Dni;
                string nombre = aux.Nombre;
                string apellido = aux.Apellido;
                string baja = Convert.ToByte(aux.Baja).ToString();

                accessdata.setearConsulta("insert into Personas values(" + cargo + ",'" + dni + "','" + nombre + "','" + apellido + "'"+baja+")");  
                accessdata.ejecutarAccion();
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

        public void ActualizarInsumo(bool opcion, Insumo aux)
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
                string baja = " Baja=" + Convert.ToByte(aux.Baja).ToString();

                if (opcion == true)
                {
                    accessdata.setearConsulta("update Insumos set" 
                    + nombre + "," 
                    + idcategoria + "," 
                    + idtipo + "," 
                    + precio + ","
                    + stock + "," 
                    + url + "," 
                    + baja 
                    + " where" + id);
                }
                else
                {
                    accessdata.setearConsulta("update Insumos set Baja = 0 where" + id);
                }

                accessdata.ejecutarAccion();
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

        public void AgregarInsumo(Insumo aux)
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
                string baja = Convert.ToByte(aux.Baja).ToString();

                accessdata.setearConsulta("insert into Insumos values('" + nombre + "'," + idcategoria + "," + idtipo + "," + precio + "," + stock + ",'" + url + " ,"+baja+")");
                accessdata.ejecutarAccion();
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

        public List<HistorialPedido> ListarHistorialPedido(string where)
        {
            List<HistorialPedido> lista = new List<HistorialPedido>();

            try
            {
                accessdata.setearConsulta("select * from VW_HistorialPedidos " + where);
                accessdata.ejecutarLectura();
                while (accessdata.Lector.Read())
                {
                    HistorialPedido aux = new HistorialPedido();
                    aux.Id = accessdata.Lector.GetInt32(0);
                    aux.Mesa = new Mesa(accessdata.Lector.GetInt32(1), accessdata.Lector.GetString(2));
                    aux.Mesero = new Persona();
                    aux.Mesero.Id = accessdata.Lector.GetInt32(3);
                    aux.Mesero.Cargo = new Cargo(accessdata.Lector.GetInt32(4), accessdata.Lector.GetString(5));
                    aux.Mesero.Dni = accessdata.Lector.GetString(6);
                    aux.Mesero.Nombre = accessdata.Lector.GetString(7);
                    aux.Mesero.Apellido = accessdata.Lector.GetString(8);
                    aux.Mesero.Baja = accessdata.Lector.GetBoolean(9);
                    aux.Total = accessdata.Lector.GetDecimal(10);
                    aux.FechaHora = accessdata.Lector.GetDateTime(11);

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
                    aux.Baja = accessdata.Lector.GetBoolean(6);

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
                    aux.Baja = accessdata.Lector.GetBoolean(3);

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
                if (lista.Count == 1 && lista[0].Baja==true)
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

                int NumeroMesa = (int)accessdata.Lector["ID"];
                string Nombre;
                if ((String)accessdata.Lector["Descripcion"] == "none") { Nombre = "N°" + cont.ToString(); }
                else { Nombre = (String)accessdata.Lector["Descripcion"]; }

                Mesa aux = new Mesa(NumeroMesa,Nombre);
               

                lista.Add(aux);
                cont++;
            }
           return lista;
        }

        public int CantidadMesas()
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
                    accessdata.ejecutarAccion();
                    accessdata.cerrarConexion();
                }
            }
            else
            {
                accessdata.setearConsulta("delete Mesas where ID = (select top(" + dif + ") ID from Mesas order by ID desc)");
                accessdata.ejecutarAccion();
                accessdata.cerrarConexion();
            }
        }

        public void IngresarPedido(Mesa aux)
        {
            accessdata.setearConsulta(" insert into Pedidos VALUES (@IDMesa, @IDMesero, @PrecioTotal, @FechaHora)");
            accessdata.agregarParametro("@IDMesa", aux.NumeroMesa);
            accessdata.agregarParametro("@IDMesero", aux.Mesero.Id);
            accessdata.agregarParametro("@PrecioTotal", aux.Pedidos.PrecioTotal);
            accessdata.agregarParametro("@FechaHora", DateTime.UtcNow);


            accessdata.ejecutarAccion();

            accessdata.cerrarConexion();
            int id = 0;


            accessdata.setearConsulta(" select top(1) ID from Pedidos order by ID DESC");
            accessdata.ejecutarLectura();
            if (accessdata.Lector.Read()) { id = (int)accessdata.Lector["ID"]; }
            accessdata.cerrarConexion();

            foreach (ItemsPedidos item in aux.Pedidos.ListaItems)
            {
               
                accessdata.setearConsulta("insert into ItemsPedido " +
                    " VALUES (@IDPedido,@IDInsumo,@PrecioSubTotal,@Cantidad)");
                accessdata.agregarParametro("@IDPedido",  id);
                accessdata.agregarParametro("@IDInsumo", item.Item.Id);
                accessdata.agregarParametro("@PrecioSubTotal", item.PrecioSubTotal  );
                accessdata.agregarParametro("@Cantidad", item.Cantidad);


                accessdata.ejecutarAccion();
                accessdata.cerrarConexion();

                short auxcant = 0;
                accessdata.setearConsulta("select Stock from Insumos  where ID=" + item.Item.Id);
                accessdata.ejecutarLectura();
                if (accessdata.Lector.Read()) { auxcant = (short)accessdata.Lector["Stock"]; }
                accessdata.cerrarConexion();

                accessdata.setearConsulta(" update Insumos set Stock="+(auxcant-item.Cantidad)+ " where ID="+ item.Item.Id);
                accessdata.ejecutarAccion();
                accessdata.cerrarConexion();

            }

           

            

        }

     
    }
}
