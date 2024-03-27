using Backend.accesoDatos;
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
            DateTime? date = null;
            DateTime? fechaPago = req.pago.FechaPago; 
            try
            {
                res.listaDeErrores = new List<string>();
                if (!fechaPago.HasValue)
                {
                    
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

                    int cantidadNueva = 0; //Recibir cantidad a comprar y restar a lo que hay en la cantidad del producto para obtener la cantidad despues de la compra
                    
                    int? resultado = null;
                    conexionLinqDataContext laConexion = new conexionLinqDataContext();
                    laConexion.SP_INSERTARPAGO(req.pago.FechaPago, req.pago.IdProductos, req.pago.IdUsuario, 
                        req.pago.IdOrden, req.pago.IdMetodoPago,cantidadNueva, ref resultado);
                    if(resultado == 0)
                    {
                        res.listaDeErrores.Add("No se pudo completar el metodo de pago");
                        res.result = false;
                    }
                    else
                    {
                        res.result = true;
                    }
                    
                    
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
