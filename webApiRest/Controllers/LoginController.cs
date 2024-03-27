using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tienda.Entidades.Request;
using Tienda.Entidades.Response;
using Tienda.Logica;

namespace webApiRest.Controllers
{
    public class LoginController : ApiController
    {
        // GET api/<controller>
        public ResLogin POST(ReqLogin req)
        {
        
        UsuarioLog laLogicaDeUsuario = new UsuarioLog();
        return laLogicaDeUsuario.validarLogin(req);
        }

        // GET api/<controller>/5


        // POST api/<controller>
       /* public ResLogin POST(string nombreUsuario, string contrasena)
        {
            ReqLogin req = new ReqLogin();
            req.nombreUsuario = nombreUsuario;
            req.contrasena = contrasena;
            UsuarioLog laLogicaDeUsuario = new UsuarioLog();
        }*/

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