using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Insumo
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public int IDcategoria { get; set; }
        public string tipo { get; set; }
        public string tiempo { get; set; }
        public decimal Precio{ get; set; }

    }
}
