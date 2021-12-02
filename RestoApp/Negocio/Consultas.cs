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

        public List<HistorialItem> ListarHistorialItem(int _ID)
        {
            List<HistorialItem> lista = new List<HistorialItem>();
            try
            {
                accessdata.setearConsulta("select * from VW_HistorialItems where PEDIDO_ID = " + _ID );
                accessdata.ejecutarLectura();
                while (accessdata.Lector.Read())
                {
                    HistorialItem aux = new HistorialItem();
                    aux.Id = accessdata.Lector.GetInt32(0);
                    aux.Insumo = new Insumo();
                    aux.Insumo.Nombre = accessdata.Lector.GetString(2);
                    aux.Subtotal = accessdata.Lector.GetDecimal(3);
                    aux.Cantidad = accessdata.Lector.GetInt16(4);

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

        private NegocioPersona negocioPersona;

        public bool ValidarLogueo(string _dni, string _pass, ref Persona userLog)
        {
            accessdata.setearConsulta("select * from Usuarios where DNI = '" + _dni + "' AND Contraseña = '" + _pass + "'");
            accessdata.ejecutarLectura();
            if (accessdata.Lector.Read())
            {
                accessdata.cerrarConexion();
                negocioPersona = new NegocioPersona();
                Persona persona = negocioPersona.GetPersonaByDNI(_dni);
                if (persona.Baja==false)
                {
                    userLog.Id = persona.Id;
                    userLog.Nombre = persona.Nombre;
                    userLog.Apellido = persona.Apellido;
                    userLog.Cargo = new Cargo(persona.Cargo.Id, persona.Cargo.Descripcion);
                    userLog.Dni = persona.Dni;
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
				if (item.estado)
				{

				
                IngresarItemPedido(id,item.Item.Id,item.PrecioSubTotal,item.Cantidad);

                short auxcant = 0;
                accessdata.setearConsulta("select Stock from Insumos  where ID=" + item.Item.Id);
                accessdata.ejecutarLectura();
                if (accessdata.Lector.Read()) { auxcant = (short)accessdata.Lector["Stock"]; }
                accessdata.cerrarConexion();

                accessdata.setearConsulta(" update Insumos set Stock="+(auxcant-item.Cantidad)+ " where ID="+ item.Item.Id);
                accessdata.ejecutarAccion();
                accessdata.cerrarConexion();

                accessdata.LimpiarParametros();
                }
            }

           

            

        }

        private void IngresarItemPedido(int idPedido,int idInsumo,decimal PrecioSubTotal,int Cantidad)
        {

            accessdata.setearConsulta("insert into ItemsPedido " +
           
                " VALUES (@IDPedido,@IDInsumo,@PrecioSubTotal,@Cantidad)");
            accessdata.agregarParametro("@IDPedido", idPedido);
            accessdata.agregarParametro("@IDInsumo", idInsumo);
            accessdata.agregarParametro("@PrecioSubTotal", PrecioSubTotal);
            accessdata.agregarParametro("@Cantidad", Cantidad);


            accessdata.ejecutarAccion();
            accessdata.cerrarConexion();
        }


    }
}
