using AcopioExpress.BLL.Servicios;
using AcopioExpress.BLL.Servicios.Contratos;
using AcopioExpress.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcopioExpress.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EgresosAcopioController : ControllerBase
    {
        private readonly IEgresosAcopioService _egresosAcopioService;

        public EgresosAcopioController(IEgresosAcopioService egresosAcopioService)
        {
            _egresosAcopioService = egresosAcopioService;
        }



        [HttpPost]
        [Route("registrar")]
        public async Task<IActionResult> Registrar([FromBody] EgresosAcopioDTO egresosAcopioDTO, string fechaInicio, string fechaFin)
        {
            fechaInicio = fechaInicio is null ? "" : fechaInicio;
            fechaFin = fechaFin is null ? "" : fechaFin;
            try
            {
                await _egresosAcopioService.GenerarEgresosAcopio(egresosAcopioDTO, fechaInicio, fechaFin);
                return Ok();
            }
            catch
            {

                throw;
            }

        }


        [HttpGet]
        [Route("listar")]
        public async Task<IActionResult> ListarEgresos()
        {
            try
            {
                var egresos = await _egresosAcopioService.ListarEgresosAcopio();
                return Ok(egresos);
            }
            catch 
            {

                throw ;
            }


        }

        [HttpDelete]
        [Route("eliminar/{id:int}")]
        public async Task<IActionResult> EliminarEgresos(int id)
        {

            try
            {
                await _egresosAcopioService.EliminarEgresosAcopio(id);
                return Ok();
            }
            catch
            {

                throw;
            }


        }


        [HttpGet]
        [Route("listarFecha")]
        public async Task<IActionResult> ListarEgresosFecha(string? fechaInicio, string? fechaFin)
        {
            fechaInicio = fechaInicio is null ? "" : fechaInicio;
            fechaFin = fechaFin is null ? "" : fechaFin;
            try
            {
                var egresos = await _egresosAcopioService.ListarEgresosAcopioFechas(fechaInicio, fechaFin);
                return Ok(egresos);

            }
            catch
            {

                throw;
            }
   
        }
    } 
}
