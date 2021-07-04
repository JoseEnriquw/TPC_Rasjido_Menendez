using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Cargo
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public Cargo() { }

        public Cargo(int id, string descripcion)
        {
            Id = id;
            Descripcion = descripcion;
        }
        public override string ToString()
        {
            return Descripcion;
        }
    }
}
