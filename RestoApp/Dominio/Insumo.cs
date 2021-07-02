using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Insumo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public string Tipo { get; set; } 
        public decimal Precio { get; set; }
        public short Stock { get; set; }
        public string UrlImagen { get; set; }

    }
}
