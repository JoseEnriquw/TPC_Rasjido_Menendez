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
        public string Nombre { get; set; }
        
        public Persona Mesero { get; set; }
        
        public Pedido Pedidos { get; set; }
        public string Estado { get; set; }

       public Mesa(int idMesa,string nombreMesa)
        {
            NumeroMesa = idMesa;
            Nombre = nombreMesa;
                Mesero = new Persona();
                Mesero.Nombre = "S/";
                Mesero.Apellido = "mesero";
                Pedidos = new Pedido();
                Estado = "libre";
        }
    }


}
