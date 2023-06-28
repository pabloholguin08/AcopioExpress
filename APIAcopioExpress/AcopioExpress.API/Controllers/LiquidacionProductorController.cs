using AcopioExpress.BLL.Servicios;
using AcopioExpress.BLL.Servicios.Contratos;
using AcopioExpress.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcopioExpress.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LiquidacionProductorController : ControllerBase
    {
        private readonly ILiquidacionService _liquidacionService;

        public LiquidacionProductorController(ILiquidacionService liquidacionService)
        {
            _liquidacionService = liquidacionService;
        }

        [HttpPost]
        [Route("registrar")]
        public async Task<IActionResult> Registrar( int id, string fechaInicio, string fechaFin)
        {
            fechaInicio = fechaInicio is null ? "" : fechaInicio;
            fechaFin = fechaFin is null ? "" : fechaFin;
            try
            {
                await _liquidacionService.GenerarLiquidacion(id, fechaInicio, fechaFin);
                return Ok();
            }
            catch
            {

                throw;
            }

        }


        [HttpGet]
        [Route("listar")]
        public async Task<IActionResult> ListarLiquidaciones()
        {
            try
            {
                var liquidaciones = await _liquidacionService.ListarLiquidaciones();
                return Ok(liquidaciones);
            }
            catch 
            {

                throw;
            }



        }

        [HttpDelete]
        [Route("eliminar/{id:int}")]
        public async Task<IActionResult> EliminarLiquidacion(int id)
        {
            try
            {
                await _liquidacionService.EliminarLiquidacion(id);
                return Ok();
            }
            catch
            {

                throw;
            }


        }


        [HttpGet]
        [Route("obtener/{id:int}")]
        public async Task<IActionResult> ObtenerLiquidacion(int id)
        {
            try
            {
                var liquidacion = await _liquidacionService.ObtenerLiquidacion(id);
                return Ok(liquidacion);
            }
            catch
            {

                throw;
            }


        }


    }
}
