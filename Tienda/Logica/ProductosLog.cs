using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.Entidades;
using Tienda.Entidades.Request;
using Tienda.Entidades.Response;

namespace Tienda.Logica
{
    public class ProductosLog
    {
        public ResInsertarProducto insertarProducto(ReqInsertarProducto req)
        {
            ResInsertarProducto res = new ResInsertarProducto();
            try
            {

                if (String.IsNullOrEmpty(req.elProducto.Tipo))
                {
                    res.listaDeErrores = new List<string>();
                    res.listaDeErrores.Add("Ingrese el nombre de usuario");
                    res.result = false;
                }
                else if (string.IsNullOrEmpty(req.elProducto.Precio.ToString()))
                {
                    res.listaDeErrores.Add("Ingrese el precio del producto");
                    res.result = false;
                }
                else if (string.IsNullOrEmpty(req.elProducto.Nombre))
                {
                    res.listaDeErrores.Add("Ingrese el nombre del producto");
                    res.result = false;
                }
                else if (string.IsNullOrEmpty(req.elProducto.Cantidad.ToString()))
                {
                    res.listaDeErrores.Add("Ingrese la cantidad de productos");
                    res.result = false;
                }
                else if (string.IsNullOrEmpty(req.elProducto.FechaVencimiento.ToString()))
                {
                    res.listaDeErrores.Add("Ingrese la fecha de vencimiento");
                    res.result = false;
                }
                else if (string.IsNullOrEmpty(req.elProducto.Descripcion))
                {
                      res.listaDeErrores.Add("Ingrese la descripcion");
                      res.result = false;
                }
                else if (string.IsNullOrEmpty(req.elProducto.IdMarca.ToString()))
                {
                    res.listaDeErrores.Add("Ingrese la la marca");
                    res.result = false;
                }
                
                else
                {            
                conexionLinqDataContext laConexion = new conexionLinqDataContext();
                    laConexion.SP_INSERTARPRODUCTO(req.elProducto.Tipo, req.elProducto.Precio, req.elProducto.Nombre, req.elProducto.cantidad, req.elProducto.FechaVencimiento,
                        req.elProducto.Descripcion, req.elProducto.IdMarca);
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


        public ResActualizarProducto actualizarProducto(ReqActualizarProducto req)
        {
            ResActualizarProducto res = new ResActualizarProducto();
            try
            {
                //Validar datos

                if (String.IsNullOrEmpty(req.elProducto.Nombre))
                {
                    res.listaDeErrores = new List<string>();
                    res.listaDeErrores.Add("Ingrese el nombre de producto");
                    res.result = false;
                }
                else if (req.elProducto.IdProducto == 0)
                {
                    res.listaDeErrores = new List<string>();
                    res.listaDeErrores.Add("Ingrese el Id");
                    res.result = false;
                }
                else if (String.IsNullOrEmpty(req.elProducto.Tipo))
                {
                    res.listaDeErrores.Add("Ingrese el tipo de producto");
                    res.result = false;
                }
                else if (String.IsNullOrEmpty(req.elProducto.Precio.ToString()))
                {
                    res.listaDeErrores.Add("Ingrese el precio del producto");
                    res.result = false;
                }
                else if (String.IsNullOrEmpty(req.elProducto.Cantidad.ToString()))
                {
                    res.listaDeErrores.Add("Ingrese la cantidad de productos");
                    res.result = false;
                }
                else if (String.IsNullOrEmpty(req.elProducto.FechaVencimiento.ToString()))
                {
                    res.listaDeErrores.Add("Ingrese la fecha de vencimiento");
                    res.result = false;
                }
                else if (String.IsNullOrEmpty(req.elProducto.Descripcion))
                {
                    res.listaDeErrores.Add("Ingrese la descripcion del producto");
                    res.result = false;
                }
                else if (String.IsNullOrEmpty(req.elProducto.IdMarca.ToString()))
                {
                    res.listaDeErrores.Add("Ingrese el id de la marca");
                    res.result = false;
                }
                
                else
                {
                    conexionLinqDataContext laConexion = new conexionLinqDataContext();
                    laConexion.SP_ACTUALIZARPRODUCTO(req.elProducto.Tipo, req.elProducto.Precio, req.elProducto.Nombre, req.elProducto.
                        Cantidad, req.elProducto.FechaVencimiento,
                         req.elProducto.Descripcion, req.elProducto.IdMarca);
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

        public ResEliminarProducto eliminarProducto(ReqEliminarProducto req)
        {
            ResEliminarProducto res = new ResEliminarProducto();
            try
            {
                if (req.id == 0)
                {
                    res.listaDeErrores = new List<string>();
                    res.listaDeErrores.Add("No se envio el id");
                    res.result = false;
                }
                else
                {
                    conexionLinqDataContext laConexion = new conexionLinqDataContext();
                    laConexion.SP_DELETEPRODUCTOS(req.id);
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

        public ResObtenerProductos obtenerTodosLosProductos(ReqObtenerProductos req)
        {
            ResObtenerProductos res = new ResObtenerProductos();
            try
            {

                conexionLinqDataContext laConexion = new conexionLinqDataContext();
                List<SP_SELECCIONARPRODUCTOSResult> result = laConexion.SP_SELECCIONARPRODUCTOS().ToList();
                if (result.Count != 0)
                {
                    res.listaDeProductos = new List<Productos>();
                    res.listaDeProductos = this.armarListaDeProductos(result);

                    res.result = true;
                }
                else
                {
                    res.listaDeErrores = new List<string>();
                    res.listaDeErrores.Add("No se encontraron productos");
                    res.result = false;
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

        public ResSeleccionarProductoTipo buscarProductoTipo(ReqSeleccionarProductoTipo req)
        {
            ResSeleccionarProductoTipo res = new ResSeleccionarProductoTipo();
            try
            {

                conexionLinqDataContext laConexion = new conexionLinqDataContext();
                List<SP_SELECCIONARPRODUCTOTIPOResult> result = laConexion.SP_SELECCIONARPRODUCTOTIPO().ToList();
                if (result.Count != 0)
                {
                    res.listaDeProductosTipo = new List<Productos>();
                    res.listaDeProductosTipo = this.armarListaDeProductosTipo(result);

                    res.result = true;
                }
                else
                {
                    res.listaDeErrores = new List<string>();
                    res.listaDeErrores.Add("No se encontraron productos");
                    res.result = false;
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

        public ResSeleccionarProductoTipo buscarProductoMarca(ReqSeleccionarProductoTipo req)
        {
            ResSeleccionarProductoTipo res = new ResSeleccionarProductoTipo();
            try
            {

                conexionLinqDataContext laConexion = new conexionLinqDataContext();
                List<SP_SELECCIONARPRODUCTOTIPOResult> result = laConexion.SP_SELECCIONARPRODUCTOTIPO().ToList();
                if (result.Count != 0)
                {
                    res.listaDeProductosTipo = new List<Productos>();
                    res.listaDeProductosTipo = this.armarListaDeProductosTipo(result);

                    res.result = true;
                }
                else
                {
                    res.listaDeErrores = new List<string>();
                    res.listaDeErrores.Add("No se encontraron productos");
                    res.result = false;
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


        private List<Productos> armarListaDeProductos(List<SP_SELECCIONARPRODUCTOSResult> listaDeProductosLinq)
        {
            List<Usuario> listaDeProductosArmada = new List<Productos>();
            foreach (SP_SELECCIONARPRODUCTOSResult elementoLinq in listaDeProductosLinq)
            {
                Productos elProducto = new Productos();
                elProducto.IdProducto = elementoLinq.IdProducto; //revisar lo de linq el nombre con el que aparece en linq
                elProducto.Tipo = elementoLinq.Tipo;
                elProducto.Precio = elementoLinq.Precio;
                elProducto.Nombre = elementoLinq.Nombre;
                elProducto.Cantidad = elementoLinq.Cantidad;
                elProducto.FechaVencimiento = elementoLinq.FechaVencimiento;
                elProducto.Descripcion = elementoLinq.Descripcion;
                elProducto.IdMarca= elementoLinq.IdMarca;
                

                listaDeProductosArmada.Add(elProducto);
            }
            return listaDeProductosArmada;
        }


        private List<Productos> armarListaDeProductosTipo(List<SP_SELECCIONARPRODUCTOTIPOResult> listaDeProductosTipoLinq)
        {
            List<Usuario> listaDeProductosTipoArmada = new List<Productos>();
            foreach (SP_SELECCIONARPRODUCTOTIPOResult elementoLinq in listaDeProductosTipoLinq)
            {
                Productos elProducto = new Productos();
                elProducto.IdProducto = elementoLinq.IdProducto; //revisar lo de linq 
                elProducto.Tipo = elementoLinq.Tipo;
                elProducto.Precio = elementoLinq.Precio;
                elProducto.Nombre = elementoLinq.Nombre;
                elProducto.Cantidad = elementoLinq.Cantidad;
                elProducto.FechaVencimiento = elementoLinq.FechaVencimiento;
                elProducto.Descripcion = elementoLinq.Descripcion;
                elProducto.IdMarca = elementoLinq.IdMarca;
                

                listaDeProductosTipoArmada.Add(elProducto);
            }
            return listaDeProductosTipoArmada;
        }

    }
}
