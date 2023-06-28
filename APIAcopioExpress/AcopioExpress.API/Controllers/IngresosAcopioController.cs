using AcopioExpress.BLL.Servicios;
using AcopioExpress.BLL.Servicios.Contratos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcopioExpress.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngresosAcopioController : ControllerBase
    {
        private readonly IIngresosAcopioService _ingresosAcopioService;

        public IngresosAcopioController(IIngresosAcopioService ingresosAcopioService)
        {
            _ingresosAcopioService = ingresosAcopioService;
        }


        [HttpPost]
        [Route("registrar")]
        public async Task<IActionResult> Registrar( string fechaInicio, string fechaFin)
        {
            fechaInicio = fechaInicio is null ? "" : fechaInicio;
            fechaFin = fechaFin is null ? "" : fechaFin;
            try
            {
                await _ingresosAcopioService.GenerarIngresosAcopio( fechaInicio, fechaFin);
                return Ok();
            }
            catch
            {

                throw;
            }

        }


        [HttpGet]
        [Route("listar")]
        public async Task<IActionResult> ListarIngresos()
        {
            try
            {
                var liquidaciones = await _ingresosAcopioService.ListarIngresosAcopio();
                return Ok(liquidaciones);
            }
            catch 
            {

                throw;
            }


        }

        [HttpDelete]
        [Route("eliminar/{id:int}")]
        public async Task<IActionResult> EliminarIngresos(int id)
        {
            try
            {
                await _ingresosAcopioService.EliminarIngresosAcopio(id);
                return Ok();
            }
            catch 
            {

                throw;
            }
         

        }


        [HttpGet]
        [Route("listarFecha")]
        public async Task<IActionResult> ListarIngresosFecha(string? fechaInicio, string? fechaFin)
        {
            fechaInicio = fechaInicio is null ? "" : fechaInicio;
            fechaFin = fechaFin is null ? "" : fechaFin;
            try
            {
                var ingresos = await _ingresosAcopioService.ListarIngresosAcopioFechas(fechaInicio, fechaFin);
                return Ok(ingresos);
            }
            catch 
            {

                throw;
            }


        }
    }
}
