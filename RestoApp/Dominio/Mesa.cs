using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Mesa
    {
        public int NumeroMesa { get; set; }
        
        public Persona Mesero { get; set; }
        
        public Pedido Pedidos { get; set; }
        public string Estado { get; set; }
    }
}
