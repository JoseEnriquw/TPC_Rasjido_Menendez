using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Pedido
    {
        public int ID { get; set; }
        public int IDMesa { get; set; }
        public int IDInsumo { get; set; }
        public int Cantidad { get; set; }
        public float Precio { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaHora { get; set; }


    }
}
