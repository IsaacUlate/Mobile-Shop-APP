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
    public class PagoController : ApiController
    {
        public ResAgregarPago Post([FromBody] ReqAgregarPago req)
        {
            PagoLog laLogicaDePago = new PagoLog();
            return laLogicaDePago.ingresarPago(req);
        }
    }
}
