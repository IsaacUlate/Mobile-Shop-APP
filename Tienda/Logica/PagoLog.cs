using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.Entidades.Request;
using Tienda.Entidades.Response;

namespace Tienda.Logica
{
    public class PagoLog
    {

        public ResAgregarPago ingresarPago(ReqAgregarPago req)
        {
            ResAgregarPago res = new ResAgregarPago();
            try
            {

                if (string.IsNullOrEmpty(req.pago.FechaPago).ToString())
                {
                    res.listaDeErrores = new List<string>();
                    res.listaDeErrores.Add("Falta la fecha de pago");
                    res.result = false;
                }
                else if (string.IsNullOrEmpty(req.pago.IdProductos.ToString()))
                {
                    res.listaDeErrores.Add("Falta el id del producto");
                    res.result = false;
                }
                else if (string.IsNullOrEmpty(req.pago.IdUsuario.ToString()))
                {
                    res.listaDeErrores.Add("Falta el Id del usuario");
                    res.result = false;
                }
                else if (string.IsNullOrEmpty(req.pago.IdOrden.ToString()))
                {
                    res.listaDeErrores.Add("Falta el id de la orden");
                    res.result = false;
                }
                else if (string.IsNullOrEmpty(req.pago.IdMetodoPago.ToString()))
                {
                    res.listaDeErrores.Add("Falta el id del metodo de pago");
                    res.result = false;
                }
                else
                {
                    conexionLinqDataContext laConexion = new conexionLinqDataContext();
                    laConexion.SP_INSERTARPAGO(req.pago.FechaPago, req.pago.IdProductos, req.pago.IdUsuario, 
                        req.pago.IdOrden, req.pago.IdMetodoPago);
                    res.result = true;
                }
            }
            catch (Exception ex)
            {
                res.listaDeErrores = new List<string>();
                res.listaDeErrores.Add(ex.Message);
                res.result = false;
            }
            return res;
        }
    }
}
