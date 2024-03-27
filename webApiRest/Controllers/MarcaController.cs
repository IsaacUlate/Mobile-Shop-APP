using Backend.Entidades.Request;
using Backend.Entidades.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tienda.Logica;

namespace webApiRest.Controllers
{
    public class MarcaController : ApiController
    {
        // GET api/<controller>
        

        // GET api/<controller>/5
       // public string Get(int id)
        //{
          //  return "value";
        //}
        public ResSeleccionarProductoMarca Get(string NombreMarca)
        {
            ReqSeleccionarProductoMarca req = new ReqSeleccionarProductoMarca();
            req.marca = NombreMarca;

            ProductosLog laLogicaDelBackEnd = new ProductosLog();
            return laLogicaDelBackEnd.buscarProductoMarca(req);
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}