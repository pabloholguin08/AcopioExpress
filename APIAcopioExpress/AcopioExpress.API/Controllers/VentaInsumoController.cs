using AcopioExpress.BLL.Servicios;
using AcopioExpress.BLL.Servicios.Contratos;
using AcopioExpress.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcopioExpress.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaInsumoController : ControllerBase
    {
        private readonly IventaInsumoService _ventaService;

        public VentaInsumoController(IventaInsumoService ventaService)
        {
            _ventaService = ventaService;
        }


        [HttpPost]
        [Route("registrar")]
        public async Task<IActionResult> Registrar([FromBody] VentaInsumoDTO venta)    
        {
            try
            {
                await _ventaService.Registrar(venta);
                return Ok();    
            }
            catch 
            {

                throw;
            }
        
        }


        [HttpGet]
        [Route("historial")]
        public async Task<IActionResult> Historial( string fechaInicio,string fechaFin)
        {

            fechaInicio = fechaInicio is null ? "" : fechaInicio;
            fechaFin = fechaFin is null ? "" : fechaFin;
            try
            {
                var historial= await _ventaService.Historial( fechaInicio, fechaFin);
                return Ok(historial);
            }
            catch
            {

                throw;
            }

        }

        [HttpGet]
        [Route("reporte")]
        public async Task<IActionResult> reporte( string? fechaInicio, string? fechaFin)
        {

            fechaInicio = fechaInicio is null ? "" : fechaInicio;
            fechaFin = fechaFin is null ? "" : fechaFin;

            try
            {
                var reporte = await _ventaService.Reporte( fechaInicio, fechaFin);
                return Ok(reporte);
            }
            catch
            {

                throw;
            }



        }

        [HttpDelete]
        [Route("eliminar/{id:int}")]
        public async Task<IActionResult> EliminarVentaInsumo(int id)
        {
            try
            {
                await _ventaService.EliminarVenta(id);
                return Ok();

            }
            catch
            {

                throw;
            }

        }
    }
}
