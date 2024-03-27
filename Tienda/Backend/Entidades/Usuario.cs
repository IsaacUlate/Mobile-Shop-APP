using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.Entidades
{
    public class Usuario
    {
        public int? idUsuario { get; set; }
        public string nombreUsuario { get; set; }
        public string correo { get; set; }
        public string tipo { get; set; }
        public string contrasena { get; set; }
    }
}
