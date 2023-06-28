using AcopioExpress.BLL.Servicios;
using AcopioExpress.BLL.Servicios.Contratos;
using AcopioExpress.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcopioExpress.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaService _personaService;

        public PersonaController(IPersonaService personaService)
        {
            _personaService = personaService;
        }



        [HttpGet]
        [Route("listar")]
        public async Task<IActionResult> ListarPersonas()
        {
            try
            {
                var personas = await _personaService.ListarPersona();
                return Ok(personas);
            }
            catch 
            {

                throw;
            }


        }

        [HttpGet]
        [Route("listarEmpleados")]
        public async Task<IActionResult> ListarEmpleado()
        {
            try
            {
                var personas = await _personaService.ListarEmpleados();
                return Ok(personas);
            }
            catch
            {

                throw;
            }


        }
        [HttpGet]
        [Route("listarProductores")]
        public async Task<IActionResult> ListarProductores()
        {
            try
            {
                var personas = await _personaService.ListarProductores();
                return Ok(personas);
            }
            catch
            {
                throw;
            }
        }



        [HttpPost]
        [Route("crear")]
        public async Task<IActionResult> CrearPersona([FromBody] PersonaDTO personaDTO)
        {
            try
            {
                var persona = await _personaService.CrearPersona(personaDTO);
                return Ok(persona);
            }
            catch
            {

                throw;
            }


        }


        [HttpGet]
        [Route("obtener/{id:int}")]
        public async Task<IActionResult> ObtenerPersona(int id)
        {
            try
            {
                var persona = await _personaService.ObtenerPersona(id);
                return Ok(persona);
            }
            catch
            {

                throw;
            }
  

        }


        [HttpPut]
        [Route("editar")]
        public async Task<IActionResult> ActualizarPersona([FromBody] PersonaDTO modelo)
        {
            try
            {
                await _personaService.ActualizarPersona(modelo);
                return Ok();
            }
            catch
            {

                throw;
            }
        }

        [HttpPut]
        [Route("eliminar/{id:int}")]
        public async Task<IActionResult> EliminarPersona(int id)
        {
            try
            {
                await _personaService.EliminarPersona(id);
                return Ok();
            }
            catch
            {

                throw;
            }
        }

        [HttpGet]
        [Route("listarEliminados")]
        public async Task<IActionResult> ListarPersonasEliminadas()
        {
            try
            {
                var personas = await _personaService.ListarPersonaEliminados();
                return Ok(personas);
            }
            catch
            {

                throw;
            }
        }

        [HttpPut]
        [Route("recuperar/{id:int}")]
        public async Task<IActionResult> RecuperarPersona(int id)
        {
            try
            {
                await _personaService.RecuperarPersona(id);
                return Ok();
            }
            catch
            {

                throw;
            }
        }
    }
}
