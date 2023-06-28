using AcopioExpress.BLL.Servicios;
using AcopioExpress.BLL.Servicios.Contratos;
using AcopioExpress.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcopioExpress.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaProduccionController : ControllerBase
    {
        private readonly IVentaProduccionService _ventaProduccionService;

        public VentaProduccionController(IVentaProduccionService ventaProduccionService)
        {
            _ventaProduccionService = ventaProduccionService;
        }




        [HttpGet]
        [Route("listar")]
        public async Task<IActionResult> ListarProduccion()
        {
            try
            {
                var produccion = await _ventaProduccionService.ListarProduccion();
                return Ok(produccion);
            }
            catch 
            {

                throw;
            }
  

        }


        [HttpPost]
        [Route("crear")]
        public async Task<IActionResult> CrearVentaProduccion([FromBody] VentaProduccionDTO modelo)
        {
            try
            {
                var produccion = await _ventaProduccionService.CrearProduccion(modelo);
                return Ok(produccion);
            }
            catch 
            {

                throw;
            }
 

        }


        [HttpGet]
        [Route("obtener/{id:int}")]
        public async Task<IActionResult> ObtenerVentaProduccion(int id)
        {
            try
            {
                var produccion = await _ventaProduccionService.ObtenerProduccion(id);
                return Ok(produccion);
            }
            catch 
            {

                throw;
            }
      

        }


        [HttpPut]
        [Route("editar")]
        public async Task<IActionResult> ActualizarVentaProduccion([FromBody] VentaProduccionDTO modelo)
        {

            try
            {
                await _ventaProduccionService.ActualizarProduccion(modelo);
                return Ok();
            }
            catch 
            {

                throw;
            }
      

        }

        [HttpPut]
        [Route("eliminar/{id:int}")]
        public async Task<IActionResult> EliminarVentaProduccion(int id)
        {
            try
            {
                await _ventaProduccionService.EliminarProduccion(id);
                return Ok();

            }
            catch 
            {

                throw;
            }
  
        }

        [HttpGet]
        [Route("listarEliminados")]
        public async Task<IActionResult> ListarVentaProduccionEliminadas()
        {
            try
            {
                var personas = await _ventaProduccionService.ListarProduccionEliminados();
                return Ok(personas);
            }
            catch 
            {

                throw;
            }


        }

        [HttpPut]
        [Route("recuperar/{id:int}")]
        public async Task<IActionResult> RecuperarVentaProduccion(int id)
        {
            try
            {
                await _ventaProduccionService.RecuperarProduccion(id);
                return Ok();

            }
            catch 
            {

                throw;
            }

        }

        [HttpGet]
        [Route("listarFecha")]
        public async Task<IActionResult> ListarPorFechaVentaProduccion(string? fechaInicio, string? fechaFin)
        {
            fechaInicio = fechaInicio is null ? "" : fechaInicio;
            fechaFin = fechaFin is null ? "" : fechaFin;

            try
            {
                var reporte = await _ventaProduccionService.ListarPorFecha(fechaInicio, fechaFin);
                return Ok(reporte);
            }
            catch
            {

                throw;
            }

        }

    }
}
