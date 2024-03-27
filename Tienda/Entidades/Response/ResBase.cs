using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.Entidades.Response
{
    public class Resbase
    {
        public bool result { set; get; }
        public List<String> listaDeErrores { set; get; }
    }
}
