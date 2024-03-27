using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.Entidades
{
    public class Pago
    {
        public int IdPago { get; set; }
        public DateTime FechaPago { get; set; }
        public int IdProductos { get; set; }
        public int IdUsuario { get; set; }
        public int IdOrden { get; set; }
        public int IdMetodoPago { get; set; }
    }
}
