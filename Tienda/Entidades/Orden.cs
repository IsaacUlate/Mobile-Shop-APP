using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.Entidades
{
    public class Orden
    {
        public int IdOrden { get; set; }
        public string DireccionEnvio { get; set; }
        public decimal PrecioTotal { get; set; }
        public int IdUsuario { get; set; }
    }
}
