using AcopioExpress.BLL.Servicios.Contratos;
using AcopioExpress.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcopioExpress.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

 

        [HttpGet]
        [Route("validarGet")]
        public async Task<IActionResult> ValidarCredenciales(string usuario, string pass)
        {
            try
            {
                var usuarioValidado = await _loginService.ValidaCredenciales(usuario, pass);
                return Ok(usuarioValidado);
            }
            catch
            {

                throw;
            }

        }



    }
}
