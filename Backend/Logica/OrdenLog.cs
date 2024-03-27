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
    public class OrdenLog
    {
        public ResIngresarOrden insertarOrden(ReqInsertarOrden req)
        {
            ResIngresarOrden res = new ResIngresarOrden();
            try
            {
                res.listaDeErrores = new List<string>();
                if (String.IsNullOrEmpty(req.orden.DireccionEnvio))
                {
                    
                    res.listaDeErrores.Add("Falta direccion de envio");
                    res.result = false;
                }
                else if (string.IsNullOrEmpty(req.orden.PrecioTotal.ToString()))
                {
                    res.listaDeErrores.Add("No se pudo agregar el precio total");
                    res.result = false;
                }
                else if (string.IsNullOrEmpty(req.orden.IdUsuario.ToString()))
                {
                    res.listaDeErrores.Add("No se envio el id del usuario");
                    res.result = false;
                }
                else
                {
                    conexionLinqDataContext laConexion = new conexionLinqDataContext();
                    int? idDeOrden = 0;
                    laConexion.SP_INSERTARORDEN(req.orden.DireccionEnvio, req.orden.PrecioTotal, req.orden.IdUsuario,ref idDeOrden);
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

        public static implicit operator OrdenLog(PagoLog v)
        {
            throw new NotImplementedException();
        }
    }
}
