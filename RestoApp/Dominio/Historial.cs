using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class HistorialPedido
    {
        public int Id { get; set; }
        public Mesa Mesa { get; set; }
        public Persona Mesero { get; set; }
        public decimal Total { get; set; }
        public DateTime FechaHora { get; set; }
    }
    public class HistorialItem
    {
        public int Id { get; set; }
        public HistorialPedido Pedido { get; set; }
        public Insumo Insumo { get; set; }
        public decimal Subtotal { get; set; }
        public int Cantidad { get; set; }
    }
}
