using AcopioExpress.BLL.Servicios;
using AcopioExpress.BLL.Servicios.Contratos;
using AcopioExpress.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcopioExpress.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduccionController : ControllerBase
    {

        private readonly IProduccionService _produccionService;

        public ProduccionController(IProduccionService produccionService)
        {
            _produccionService = produccionService;
        }




        [HttpGet]
        [Route("listar")]
        public async Task<IActionResult> ListarProduccion()
        {
            try
            {
                var produccion = await _produccionService.ListarProduccion();
                return Ok(produccion);
            }
            catch 
            {

                throw;
            }


        }
        [HttpGet]
        [Route("listarFecha")]
        public async Task<IActionResult> ListarPorFechaProduccion(string? fechaInicio, string? fechaFin)
        {
            fechaInicio = fechaInicio is null ? "" : fechaInicio;
            fechaFin = fechaFin is null ? "" : fechaFin;

            try
            {
                var reporte = await _produccionService.ListarProduccionFecha(fechaInicio, fechaFin);
                return Ok(reporte);
            }
            catch
            {

                throw;
            }

        }


        [HttpPost]
        [Route("crear")]
        public async Task<IActionResult> CrearProduccion([FromBody] ProduccionDTO modelo)
        {
            try
            {
                var produccion = await _produccionService.CrearProduccion(modelo);
                return Ok(produccion);
            }
            catch
            {

                throw;
            }


        }


        [HttpGet]
        [Route("obtener/{id:int}")]
        public async Task<IActionResult> ObtenerProduccion(int id)
        {
            try
            {
                var produccion = await _produccionService.ObtenerProduccion(id);
                return Ok(produccion);

            }
            catch
            {

                throw;
            }

        }


        [HttpPut]
        [Route("editar")]
        public async Task<IActionResult> ActualizarProduccion([FromBody] ProduccionDTO modelo)
        {

            try
            {
                await _produccionService.ActualizarProduccion(modelo);
                return Ok();
            }
            catch
            {

                throw;
            }
  

        }

        [HttpPut]
        [Route("eliminar/{id:int}")]
        public async Task<IActionResult> EliminarProduccion(int id)
        {
            try
            {
                await _produccionService.EliminarProduccion(id);
                return Ok();
            }
            catch
            {

                throw;
            }
 

        }

        [HttpGet]
        [Route("listarEliminados")]
        public async Task<IActionResult> ListarProduccionEliminadas()
        {
            try
            {
                var personas = await _produccionService.ListarProduccionEliminados();
                return Ok(personas);
            }
            catch
            {

                throw;
            }


        }

        [HttpPut]
        [Route("recuperar/{id:int}")]
        public async Task<IActionResult> RecuperarProduccion(int id)
        {
            try
            {
                await _produccionService.RecuperarProduccion(id);
                return Ok();
            }
            catch
            {

                throw;
            }


        }
    }
}
