using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Filtros
{
	public class FiltrosInsumos
	{
		public string  nombre { get; set; }
		public string precio { get; set; }
		public string cantidad { get; set; }
		public string categoria { get; set; }
		public string tipoInsumo { get; set; }
		public string buscarPorTodo { get; set; }
		public bool baja { get; set; }

		public FiltrosInsumos()
		{
		 nombre=" "; 
	     precio=" "; 
	     cantidad=""; 
	     categoria=" "; 
	     tipoInsumo =" ";
	     buscarPorTodo = " ";
		 baja = false;
		}

	}
}
