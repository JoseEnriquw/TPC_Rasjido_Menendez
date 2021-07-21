using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ItemsPedidos
    {
        public int Id { get; set; }
        public Insumo Item { get; set; }
        public decimal PrecioSubTotal { get; set; }
        public int Cantidad { get; set; }

        public bool estado { get; set; }
    }
}
