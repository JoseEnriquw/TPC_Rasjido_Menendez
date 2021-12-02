using Dominio;
using Dominio.Filtros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
	public class NegocioPersona
	{

		private AccessData accessdata = new AccessData("(local)\\SQLEXPRESS", "TPC_Rasjido_Menendez_DB");

		public void InsertPersona(Persona persona )
		{
		
			try
			{
				accessdata.setearConsulta(" insert into Personas (IDCargo,DNI,Nombre,Apellido,Baja) VALUES (@IDCargo,@DNI,@Nombre,@Apellido,@Baja)");
				accessdata.agregarParametro("@IDCargo", persona.Cargo.Id);
				accessdata.agregarParametro("@DNI", persona.Dni);
				accessdata.agregarParametro("@Nombre", persona.Nombre);
				accessdata.agregarParametro("@Apellido", persona.Apellido);
			    accessdata.agregarParametro("@Baja", persona.Baja);
				accessdata.ejecutarAccion();
			}
			catch (Exception ex) { throw ex; }
			finally
			{
				accessdata.cerrarConexion();
			}


		}

		public List<Persona> GetAllPersonas(FiltrosPersonas filtros)
		{
			List<Persona> lista = new List<Persona>();
			string query = "select ID,IDCargo,Cargo,DNI,Nombre,Apellido,Baja from VW_Personas " + CrearWhere(filtros);

			try
			{
				accessdata.setearConsulta(query);
				accessdata.ejecutarLectura();
				while (accessdata.Lector.Read())
				{
					Persona aux = new Persona();
					aux.Id = accessdata.Lector.GetInt32(0);
					aux.Cargo = new Cargo(accessdata.Lector.GetInt32(1), accessdata.Lector.GetString(2));
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

		public Persona GetPersonaByDNI(string dni)
		{
			Persona persona = new Persona();

			try
			{
				accessdata.setearConsulta("select ID,IDCargo,Cargo,DNI,Nombre,Apellido,Baja from VW_Personas where DNI = @DNI");
				accessdata.agregarParametro("@DNI", dni);
				accessdata.ejecutarLectura();
				while (accessdata.Lector.Read())
				{

					persona.Id = accessdata.Lector.GetInt32(0);
					persona.Cargo = new Cargo(accessdata.Lector.GetInt32(1), accessdata.Lector.GetString(2));
					persona.Dni = accessdata.Lector.GetString(3);
					persona.Nombre = accessdata.Lector.GetString(4);
					persona.Apellido = accessdata.Lector.GetString(5);
					persona.Baja = accessdata.Lector.GetBoolean(6);


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

			return persona;


		}

		public void UpdatePersona(Persona persona)
		{
			try
			{
				accessdata.setearConsulta(" update Personas set IDCargo=@IDCargo,DNI=@DNI,Nombre=@Nombre,Apellido=@Apellido,Baja=@Baja Where ID=@ID");
				accessdata.agregarParametro("@IDCargo", persona.Cargo.Id);
				accessdata.agregarParametro("@DNI", persona.Dni);
				accessdata.agregarParametro("@Nombre", persona.Nombre);
				accessdata.agregarParametro("@Apellido", persona.Apellido);
				accessdata.agregarParametro("@Baja", persona.Baja);
				accessdata.agregarParametro("@ID", persona.Id);
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

		public void DeletePersona(int id)
		{
			try
			{
				accessdata.setearConsulta(" delete from Personas Where ID=@ID");
				accessdata.agregarParametro("@ID", id);
				accessdata.ejecutarAccion();
			}
			catch (Exception ex) { throw ex; }
			finally
			{
				accessdata.cerrarConexion();
			}


		}

		public string CrearWhere(FiltrosPersonas filtros)
		{
			string where = "where";

			if (filtros != null)
			{
				bool dni = false;
				bool nombre = false;

				//Si la variable DNI no es nula hace Like de DNI
				if (filtros.dni != "")
				{
			
					
					where += " DNI like '%" + filtros.dni + "%' ";
					

				    dni = true;
				}

				//Si la variable nombre no es nula hace Like de nombre
				if (filtros.nombre != " ")
				{
					if (dni)
					{
						where += " and Nombre like '%" + filtros.nombre + "%' ";
						
					}
					else
					{
						where += " Nombre like '%" + filtros.nombre + "%' ";
					}
					nombre = true;
				}

	

				//Si la variable Apellido no es nula hace Like de Apellido
				if (filtros.apellido != " ")
				{
					if (dni || nombre)
					{
						where += " and Apellido like '%" + filtros.apellido + "%' ";
					}
					else
					{
						where += " Apellido like '%" + filtros.apellido + "%' ";
					}
				
				}

				

			}
			return where != "where" ? where : "";

		}

	}
}
