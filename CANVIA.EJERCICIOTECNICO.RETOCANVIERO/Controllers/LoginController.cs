using CANVIA.EJERCICIOTECNICO.RETOCANVIERO.Models.Login;
using CANVIA.EJERCICIOTECNICO.RETOCANVIERO.ViewModels.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CANVIA.EJERCICIOTECNICO.RETOCANVIERO.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("login")]
    public class LoginController : ApiController
    {
        [HttpPost]
        [Route("login")]
        public IHttpActionResult LogIn(LoginModel model)
        {
            try
            {
                var vm = new LoginViewModel();
                var data = vm.Login(model);
                if (data == null) {
                    return Content(HttpStatusCode.BadRequest, "Credenciales Incorrectas");
                }
                return Ok(data);
                //return Content(HttpStatusCode.BadRequest, response);
            }
            catch (Exception ex)
            {
                return Unauthorized();
            }
        }
    }
}
