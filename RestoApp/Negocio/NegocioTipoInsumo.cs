using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
	public class NegocioTipoInsumo
	{

		private AccessData accessdata = new AccessData("(local)\\SQLEXPRESS", "TPC_Rasjido_Menendez_DB");

		public void InsertTipoInsumo(TipoInsumo tipoInsumo)
		{
			try
			{
				accessdata.setearConsulta(" insert into TipoInsumo (Descripcion) VALUES (@Descripcion)");
				accessdata.agregarParametro("@Nombre", tipoInsumo.Descripcion);
				accessdata.ejecutarAccion();
			}
			catch (Exception ex) { }
			finally
			{
				accessdata.cerrarConexion();
			}


		}

		public List<TipoInsumo> GetAllTipoInsumo()
		{
			List<TipoInsumo> lista = new List<TipoInsumo>();

			try
			{
				accessdata.setearConsulta("select ID,Descripcion from TipoInsumos");
				accessdata.ejecutarLectura();
				while (accessdata.Lector.Read())
				{
					TipoInsumo aux = new TipoInsumo();
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

		public TipoInsumo GetTipoInsumoByID(int id)
		{
			TipoInsumo tipoInsumo = new TipoInsumo();

			try
			{
				accessdata.setearConsulta("select ID,Descripcion from TipoInsumos where ID = @ID");
				accessdata.agregarParametro("@ID", id);
				accessdata.ejecutarLectura();
				while (accessdata.Lector.Read())
				{

					tipoInsumo.Id = (int)accessdata.Lector.GetInt32(0);
					tipoInsumo.Descripcion = (string)accessdata.Lector.GetString(1);


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

			return tipoInsumo;


		}

		public void UpdateTipoInsumo(TipoInsumo tipoInsumo)
		{
			try
			{
				accessdata.setearConsulta(" update TipoInsumos set Descripcion=@Descripcion Where ID=@ID ");
				accessdata.agregarParametro("@Descripcion", tipoInsumo.Descripcion);
				accessdata.agregarParametro("@ID", tipoInsumo.Id);
				accessdata.ejecutarAccion();
			}
			catch (Exception ex) { }
			finally
			{
				accessdata.cerrarConexion();
			}


		}

		public void DeleteTipoInsumo(int id)
		{
			try
			{
				accessdata.setearConsulta(" delete from TipoInsumos Where ID=@ID");
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
