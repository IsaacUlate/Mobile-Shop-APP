using Backend.Entidades.Request;
using Backend.Entidades.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Tienda.Entidades.Request;
using Tienda.Entidades.Response;
using Tienda.Logica;

namespace webApiRest.Controllers
{
    public class ProductoController : ApiController
    {
        // GET https://localhost:44317/api/Producto/5
        public ResInsertarProducto Post([FromBody] ReqInsertarProducto req)
        {
            ProductosLog laLogicaDeProducto = new ProductosLog();
            return laLogicaDeProducto.insertarProducto(req);
        }

        // PUT api/<controller>/5
        public ResActualizarProducto put([FromBody] ReqActualizarProducto req)
        {
            ProductosLog laLogicaDeProducto = new ProductosLog();
            return laLogicaDeProducto.actualizarProducto(req);
        }
        // DELETE api/<controller>/5
        public ResEliminarProducto Delete(int id)
        {
            ReqEliminarProducto req = new ReqEliminarProducto();
            req.id = id;
            ProductosLog laLogicaDeProducto = new ProductosLog();
            return laLogicaDeProducto.eliminarProducto(req);
        }

        public ResSeleccionarProductoTipo Get(string Tipo)
        {
            ReqSeleccionarProductoTipo req = new ReqSeleccionarProductoTipo();
            req.tipo = Tipo;

            ProductosLog laLogicaDelBackEnd = new ProductosLog();
            return laLogicaDelBackEnd.buscarProductoTipo(req);
        }

        
        public ResObtenerProductos Get()
        {
            ReqObtenerProductos req = new ReqObtenerProductos();

            ProductosLog laLogicaDelBackEnd = new ProductosLog();
            return laLogicaDelBackEnd.obtenerTodosLosProductos(req);
        }
    }
}
