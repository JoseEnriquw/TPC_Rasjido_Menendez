using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Pedido
    {
        public int Id { get; set; }
        public List<ItemsPedidos> ListaItems { get; set; }
        public decimal PrecioTotal { get; set; }
        public DateTime FechaHora { get; set; }
        public bool Estado { get; set; }
    }
}
