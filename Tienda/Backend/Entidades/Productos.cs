using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.Entidades
{
    public class Productos
   {    
           public int? IdProducto { get; set; }
            public string Tipo { get; set; }
            public decimal? Precio { get; set; }
            public string Nombre { get; set; }
            public int? Cantidad { get; set; }
            public  DateTime? FechaVencimiento { get; set; }
            public string Descripcion { get; set; }
            public int? IdMarca { get; set; }
           
        
    }
}
