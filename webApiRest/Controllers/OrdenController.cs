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
    public class OrdenController : ApiController
    {
        public ResIngresarOrden Post([FromBody] ReqInsertarOrden req)
        {
            OrdenLog laLogicaDeOrden = new OrdenLog();
            return laLogicaDeOrden.insertarOrden(req);
        }
    }
}
