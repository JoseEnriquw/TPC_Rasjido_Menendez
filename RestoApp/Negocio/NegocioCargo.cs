using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
	public class NegocioCargo
	{
		private AccessData accessdata = new AccessData("(local)\\SQLEXPRESS", "TPC_Rasjido_Menendez_DB");

		public void InsertCargo(Cargo cargo)
		{
			try
			{
				accessdata.setearConsulta(" insert into Cargos (Descripcion) VALUES (@Descripcion)");
				accessdata.agregarParametro("@Descripcion", cargo.Descripcion);
				accessdata.ejecutarAccion();
			}
			catch (Exception ex) { }
			finally
			{
				accessdata.cerrarConexion();
			}


		}

		public List<Cargo> GetAllCargos()
		{
			List<Cargo> lista = new List<Cargo>();

			try
			{
				accessdata.setearConsulta("select ID,Descripcion from Cargos");
				accessdata.ejecutarLectura();
				while (accessdata.Lector.Read())
				{
					Cargo aux = new Cargo();
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

		public Cargo GetCargoByID(int id)
		{
			Cargo cargo = new Cargo();

			try
			{
				accessdata.setearConsulta("select ID, Descripcion from Cargos where ID = @ID");
				accessdata.agregarParametro("@ID", id);
				accessdata.ejecutarLectura();
				while (accessdata.Lector.Read())
				{

					cargo.Id = (int)accessdata.Lector.GetInt32(0);
					cargo.Descripcion = (string)accessdata.Lector.GetString(1);


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

			return cargo;


		}

		public void UpdateCargo(Cargo cargo)
		{
			try
			{
				accessdata.setearConsulta(" update Cargos set Descripcion=@Descripcion Where ID=@ID ");
				accessdata.agregarParametro("@Descripcion", cargo.Descripcion);
				accessdata.agregarParametro("@ID", cargo.Id);
				accessdata.ejecutarAccion();
			}
			catch (Exception ex) { }
			finally
			{
				accessdata.cerrarConexion();
			}


		}

		public void DeleteCargo(int id)
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
