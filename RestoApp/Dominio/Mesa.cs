using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Mesa
    {
        public int Id { get; set; }
        public Persona Mesero { get; set; }
        public List<Pedido> Pedidos { get; set; }
        public bool Estado { get; set; }
    }
}
