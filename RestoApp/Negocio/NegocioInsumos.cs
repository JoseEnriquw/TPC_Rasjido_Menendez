using Dominio;
using Dominio.Filtros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
	public class NegocioInsumos
	{
		private AccessData accessdata = new AccessData("(local)\\SQLEXPRESS", "TPC_Rasjido_Menendez_DB");

		public void InsertInsumo(Insumo insumo)
		{
			try
			{
				accessdata.setearConsulta(" insert into Insumos (Nombre,IDCategoria,IDTipo,Precio,Stock,UrlImg,Baja) VALUES (@Nombre,@IDCategoria,@IDTipo,@Precio,@Stock,@UrlImg,@Baja)");
				accessdata.agregarParametro("@Nombre", insumo.Nombre);
				accessdata.agregarParametro("@IDCategoria", insumo.Categoria.Id);
				accessdata.agregarParametro("@IDTipo", insumo.Tipo.Id);
				accessdata.agregarParametro("@Precio", insumo.Precio);
				accessdata.agregarParametro("@Stock", insumo.Stock);
				accessdata.agregarParametro("@UrlImg", insumo.UrlImagen);
				accessdata.agregarParametro("@Baja", insumo.Baja);
				accessdata.ejecutarAccion();
			}
			catch (Exception ex) { throw ex; }
			finally
			{
				accessdata.cerrarConexion();
			}


		}

		public List<Insumo> GetAllInsumos(FiltrosInsumos filtros)
		{
			List<Insumo> lista = new List<Insumo>();
			string query = "select ID,Nombre,IDCategoria,Categoria,IDTipo,Tipo,Precio,Stock,UrlImg,Baja from VW_Insumos "+CrearWhere(filtros);
			
			try
			{
				accessdata.setearConsulta(query);
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

		public Insumo GetInsumoByID(int id)
		{
			Insumo insumo = new Insumo();

			try
			{
				accessdata.setearConsulta("select ID, Nombre, IDCategoria, Categoria, IDTipo, Tipo, Precio, Stock, UrlImg, Baja from VW_Insumos where ID = @ID");
				accessdata.agregarParametro("@ID", id);
				accessdata.ejecutarLectura();
				while (accessdata.Lector.Read())
				{
					
					insumo.Id = (int)accessdata.Lector.GetInt32(0);
					insumo.Nombre = (string)accessdata.Lector.GetString(1);

					insumo.Categoria = new Categorias(accessdata.Lector.GetInt32(2), accessdata.Lector.GetString(3));
					insumo.Tipo = new TipoInsumo((int)accessdata.Lector.GetInt32(4), accessdata.Lector.GetString(5));
					insumo.Precio = (decimal)accessdata.Lector["Precio"];
					insumo.Stock = (short)accessdata.Lector["Stock"];
					insumo.UrlImagen = (string)accessdata.Lector.GetString(8);
					insumo.Baja = accessdata.Lector.GetBoolean(9);

					
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

			return insumo;


		}

		public void UpdateInsumo(Insumo insumo)
		{
			try
			{
				accessdata.setearConsulta(" update Insumos set Nombre=@Nombre,IDCategoria=@IDCategoria,IDTipo=@IDTipo,Precio=@Precio,Stock=@Stock,UrlImg=@UrlImg,Baja=@Baja Where ID=@ID");
				accessdata.agregarParametro("@Nombre", insumo.Nombre);
				accessdata.agregarParametro("@IDCategoria", insumo.Categoria.Id);
				accessdata.agregarParametro("@IDTipo", insumo.Tipo.Id);
				accessdata.agregarParametro("@Precio", insumo.Precio);
				accessdata.agregarParametro("@Stock", insumo.Stock);
				accessdata.agregarParametro("@UrlImg", insumo.UrlImagen);
				accessdata.agregarParametro("@Baja", insumo.Baja);
				accessdata.agregarParametro("@ID", insumo.Id);
				accessdata.ejecutarAccion();
			}
			catch (Exception ex) {
				throw ex;
			}
			finally
			{
				accessdata.cerrarConexion();
			}


		}

		public void DeleteInsumo(int id)
		{
			try
			{
				accessdata.setearConsulta(" delete from Insumos Where ID=@ID");
				accessdata.agregarParametro("@ID", id);
				accessdata.ejecutarAccion();
			}
			catch (Exception ex) { throw ex; }
			finally
			{
				accessdata.cerrarConexion();
			}


		}

		public string CrearWhere(FiltrosInsumos filtros)
		{
			string where = "where";

			if (filtros != null)
			{
				bool nombre = false;
				bool precio = false;
				bool cantidad = false;
				bool categoria = false;
				bool tipoInsumo = false;


				if (!filtros.baja)
				{
					where += " Baja=0 ";
				}

				//Si la variable nombre no es nula hace Like de nombre
				if (filtros.nombre != " ")
				{
					if (filtros.baja) { 
					where += " Nombre like '%" + filtros.nombre + "%' ";
					}
					else
					{
						where += " and Nombre like '%" + filtros.nombre + "%' ";
					}
					nombre = true;
				}

				//Si la variable precio no es nula hace Like de precio
				if (filtros.precio != " ")
				{
					if (!filtros.baja || nombre)
					{
						where += " and Precio like '%" + filtros.precio + "%' ";
					}
					else
					{
						where += " Precio like '%" + filtros.precio + "%' ";
					}

					precio = true;
				}

				//Si la variable cantidad no es nula hace Like de cantidad
				if (filtros.cantidad != "")
				{
					if (!filtros.baja || nombre || precio)
					{
						where += " and Stock like '%" + filtros.cantidad + "%' ";
					}
					else
					{
						where += " Stock like '%" + filtros.cantidad + "%' ";
					}
					cantidad = true;
				}

				//Si la variable Categoria no es nula hace Like de Categoria
				if (filtros.categoria != " ")
				{
					if (!filtros.baja || nombre || precio || cantidad)
					{
						where += " and Categoria like '%" + filtros.categoria + "%' ";
					}
					else
					{
						where += " Categoria like '%" + filtros.categoria + "%' ";
					}
					categoria = true;
				}
				
				//Si la variable tipoInsumo no es nula hace Like de tipoInsumo
				if (filtros.tipoInsumo != " ")
				{
					if (!filtros.baja || nombre || precio || cantidad || categoria)
					{
						where += " and Tipo like '%" + filtros.tipoInsumo + "%' ";
					}
					else
					{
						where += " Tipo like '%" + filtros.tipoInsumo + "%' ";
					}
					tipoInsumo = true;
				}

				//Si la variable buscarPorTodo no es nula hace Like de buscarPorTodo
				if (filtros.buscarPorTodo != " ")
				{
					if (!filtros.baja || nombre || precio || cantidad || categoria || tipoInsumo)
					{
						where += " and (Nombre like '%" + filtros.buscarPorTodo + "%' or Categoria like '%" + filtros.buscarPorTodo + "%'" +
						" or Tipo like '%" + filtros.buscarPorTodo + "%' or Precio like '%" + filtros.buscarPorTodo + "%' or Stock like '%" + filtros.buscarPorTodo + "%' ) ";
					}
					else
					{
						where += " Nombre like '%" + filtros.buscarPorTodo + "%' or Categoria like '%" + filtros.buscarPorTodo + "%'" +
						" or Tipo like '%" + filtros.buscarPorTodo + "%' or Precio like '%" + filtros.buscarPorTodo + "%' or Stock like '%" + filtros.buscarPorTodo + "%' ";
					}
				}

			}
			return where!="where"? where: "";

		}

	}
}
