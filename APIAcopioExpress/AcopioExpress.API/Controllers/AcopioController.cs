using AcopioExpress.BLL.Servicios.Contratos;
using AcopioExpress.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcopioExpress.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcopioController : ControllerBase
    {

        private readonly IAcopioService _copioService;

        public AcopioController(IAcopioService copioService)
        {
            _copioService = copioService;
        }

        [HttpGet]
        [Route("listar")]
        public async Task<IActionResult> ListarAcopio()
        {
            try
            {
                var acopios = await _copioService.ListarAcopios();
                return Ok(acopios);
            }
            catch 
            {

                throw;
            }


        }

        [HttpPost]
        [Route("crear")]
        public async Task<IActionResult> CrearAcopio([FromBody] AcopioDTO acopio)
        {

            try
            {
                var acopios = await _copioService.CrearAcopio(acopio);
                return Ok(acopios);
            }
            catch
            {

                throw;
            }


        }

        [HttpGet]
        [Route("obtener/{id:int}")]
        public async Task<IActionResult> ObtenerAcopio(int id)
        {

            try
            {
                var acopio = await _copioService.ObtenerAcopio(id);
                return Ok(acopio);
            }
            catch
            {

                throw;
            }


        }

        [HttpPut]
        [Route("eliminar/{id:int}")]
        public async Task<IActionResult> EliminarAcopio(int id)
        {
            try
            {
                await _copioService.EliminarAcopio(id);
                return Ok();
            }
            catch
            {

                throw;
            }


        }

        [HttpPut]
        [Route("editar")]
        public async Task<IActionResult> ActualizarAcopio([FromBody] AcopioDTO modelo)
        {
            try
            {
                await _copioService.ActualizarAcopio(modelo);
                return Ok();
            }
            catch
            {

                throw;
            }


        }

        [HttpGet]
        [Route("listarEliminados")]
        public async Task<IActionResult> ListarAcopioEliminados()
        {
            try
            {
                var acopios = await _copioService.ListarAcopioEliminados();
                return Ok(acopios);
            }
            catch
            {

                throw;
            }


        }


        [HttpPut]
        [Route("recuperar/{id:int}")]
        public async Task<IActionResult> RecuperarAcopio(int id)
        {
            try
            {
                await _copioService.RecuperarAcopio(id);
                return Ok();
            }
            catch
            {

                throw;
            }


        }


        [HttpGet]
        [Route("reporte")]
        public async Task<IActionResult> GenerarReporte(string fechaInicio, string fechaFin)
        {
            fechaInicio = fechaInicio is null ? "" : fechaInicio;
            fechaFin = fechaFin is null ? "" : fechaFin;
            try
            {
                var reporte = await _copioService.GenerarReporte(fechaInicio, fechaFin);
                return Ok(reporte);
            }
            catch 
            {

                throw;
            }


        }

    }
}
