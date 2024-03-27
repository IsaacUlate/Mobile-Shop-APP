using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tienda.Entidades;
using Tienda.Entidades.Request;
using Tienda.Entidades.Response;
using Tienda.Logica;


namespace webApiRest.Controllers
{
    public class UsuarioController : ApiController
    {
        // GET api/<controller>



        // GET https://localhost:44317/api/Usuario/5


        // POST api/<controller>
        public ResInsertarUsuario Post([FromBody] ReqInsertarUsuario req)
        {
            UsuarioLog laLogicaDeUsuario = new UsuarioLog();
            return laLogicaDeUsuario.insertarUsuario(req);
        }

        // PUT api/<controller>/5
        public ResActualizarUsuario Put([FromBody] ReqActualizarUsuario req)
        {
            UsuarioLog laLogicaDeUsuario = new UsuarioLog();
            return laLogicaDeUsuario.actualizarUsuario(req);
        }

        // login

       

        // DELETE api/<controller>/5
        public ResEliminarUsuario Delete(int id)
        {
            ReqEliminarUsuario req = new ReqEliminarUsuario();
            req.id = id;
            UsuarioLog laLogicaDeUsuario = new UsuarioLog();
            return laLogicaDeUsuario.eliminarUsuario(req);
        }
    }
}