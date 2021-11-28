using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
	public class NegocioCategoria
	{
		private AccessData accessdata = new AccessData("(local)\\SQLEXPRESS", "TPC_Rasjido_Menendez_DB");

		public void InsertCategoria(Categorias categorias)
		{
			try
			{
				accessdata.setearConsulta(" insert into Categorias (Descripcion) VALUES (@Descripcion)");
				accessdata.agregarParametro("@Nombre", categorias.Descripcion);
				accessdata.ejecutarAccion();
			}
			catch (Exception ex) { }
			finally
			{
				accessdata.cerrarConexion();
			}


		}

		public List<Categorias> GetAllCategorias()
		{
			List<Categorias> lista = new List<Categorias>();

			try
			{
				accessdata.setearConsulta("select ID,Descripcion from Categorias");
				accessdata.ejecutarLectura();
				while (accessdata.Lector.Read())
				{
					Categorias aux = new Categorias();
					aux.Id = (int)accessdata.Lector.GetInt32(0);
					aux.Descripcion = (string)accessdata.Lector.GetString(1);

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

		public Categorias GetCategoriaByID(int id)
		{
			Categorias categoria = new Categorias();

			try
			{
				accessdata.setearConsulta("select ID, Descripcion from Categorias where ID = @ID");
				accessdata.agregarParametro("@ID", id);
				accessdata.ejecutarLectura();
				while (accessdata.Lector.Read())
				{

					categoria.Id = (int)accessdata.Lector.GetInt32(0);
					categoria.Descripcion = (string)accessdata.Lector.GetString(1);


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

			return categoria;


		}

		public void UpdateCategoria(Categorias categoria)
		{
			try
			{
				accessdata.setearConsulta(" update Insumos set Descripcion=@Descripcion Where ID=@ID ");
				accessdata.agregarParametro("@Descripcion", categoria.Descripcion);
				accessdata.agregarParametro("@ID", categoria.Id);
				accessdata.ejecutarAccion();
			}
			catch (Exception ex) { }
			finally
			{
				accessdata.cerrarConexion();
			}


		}

		public void DeleteCategoria(int id)
		{
			try
			{
				accessdata.setearConsulta(" delete from Insumos Where ID=@ID");
				accessdata.agregarParametro("@ID", id);
				accessdata.ejecutarAccion();
			}
			catch (Exception ex) { }
			finally
			{
				accessdata.cerrarConexion();
			}


		}


	}
}
