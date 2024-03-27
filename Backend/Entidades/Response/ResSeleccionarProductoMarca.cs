using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tienda.Entidades;
using Tienda.Entidades.Response;

namespace Backend.Entidades.Response
{
    public class ResSeleccionarProductoMarca : Resbase
    {
        public List<Productos> listaDeProductosMarca;
    }
}