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
    public class UsuarioLog
    {
        public ResInsertarUsuario insertarUsuario(ReqInsertarUsuario req)
        {
            ResInsertarUsuario res = new ResInsertarUsuario();
            try
            {

                
                if (String.IsNullOrEmpty(req.elUsuario.nombreUsuario))
                {
                    res.listaDeErrores = new List<string>();
                    res.listaDeErrores.Add("Falta el nombre de usuario");
                    res.result = false;
                }
                else if (String.IsNullOrEmpty(req.elUsuario.correo))
                {
                    res.listaDeErrores.Add("Falta el correo");
                    res.result = false;
                }
                else if (String.IsNullOrEmpty(req.elUsuario.tipo))
                {
                    res.listaDeErrores.Add("Falta su tipo de usuario");
                    res.result = false;
                }
                else if (String.IsNullOrEmpty(req.elUsuario.contrasena))
                {
                    res.listaDeErrores.Add("Falta su contraseña");
                    res.result = false;
                }
                else
                {
                    conexionLinqDataContext laConexion = new conexionLinqDataContext();
                    laConexion.SP_INSERTARUSUARIO(req.elUsuario.nombreUsuario, req.elUsuario.correo,
                        req.elUsuario.tipo, req.elUsuario.contrasena);
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

        public ResActualizarUsuario actualizarUsuario(ReqActualizarUsuario req)
        {
            ResActualizarUsuario res = new ResActualizarUsuario();
            try
            {
                //Validar datos

                if (String.IsNullOrEmpty(req.elUsuario.nombreUsuario))
                {
                    res.listaDeErrores = new List<string>();
                    res.listaDeErrores.Add("Falta el nombre");
                    res.result = false;
                }
                else if (req.elUsuario.idUsuario == 0)
                {
                    res.listaDeErrores = new List<string>();
                    res.listaDeErrores.Add("Falta el Id");
                    res.result = false;
                }
                else if (String.IsNullOrEmpty(req.elUsuario.correo))
                {
                    res.listaDeErrores.Add("Falta el correo");
                    res.result = false;
                }
                else if (String.IsNullOrEmpty(req.elUsuario.tipo))
                {
                    res.listaDeErrores.Add("Falta el tipo de usuario");
                    res.result = false;
                }
                else if (String.IsNullOrEmpty(req.elUsuario.contrasena))
                {
                    res.listaDeErrores.Add("Falta la contraseña");
                    res.result = false;
                }
                else
                {
                    conexionLinqDataContext laConexion = new conexionLinqDataContext();
                    laConexion.SP_ACTUALIZARUSUARIO(req.elUsuario.idUsuario, req.elUsuario.nombreUsuario,
                        req.elUsuario.correo, req.elUsuario.tipo, req.elUsuario.contrasena);
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

        public ResEliminarUsuario eliminarUsuario(ReqEliminarUsuario req)
        {
            ResEliminarUsuario res = new ResEliminarUsuario();
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
                    laConexion.SP_DELETEUSUARIO(req.id);
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

        public ResLogin validarLogin(ReqLogin req)
        {
            ResLogin res = new ResLogin();
            try
            {
                res.listaDeErrores = new List<string>();
                if (String.IsNullOrEmpty(req.elUsuarioLogin.nombreUsuario))
                {
                    
                    res.listaDeErrores.Add("Usuario faltante");
                    res.result = false;
                }
                else if (String.IsNullOrEmpty(req.elUsuarioLogin.contrasena))
                {
                    res.listaDeErrores.Add("Contrasena faltante");
                    res.result = false;
                }
                else
                {
                    conexionLinqDataContext laConexion = new conexionLinqDataContext();
                    laConexion.SP_Login(req.elUsuarioLogin.nombreUsuario, req.elUsuarioLogin.contrasena);
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
