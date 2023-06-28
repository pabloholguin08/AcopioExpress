using AcopioExpress.BLL.Servicios.Contratos;
using AcopioExpress.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcopioExpress.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsumoController : ControllerBase
    {

        private readonly IInsumoService _insumoService;

        public InsumoController(IInsumoService insumoService)
        {
            _insumoService = insumoService;
        }

        [HttpGet]
        [Route("listar")]
        public async Task<IActionResult> ListarInsumo()
        {
            try
            {

                var insumos = await _insumoService.ListarInsumo();
                return Ok(insumos);
            }
            catch 
            {

                throw;
            }


        }

        [HttpPost]
        [Route("crear")]
        public async Task<IActionResult> CrearAcopio([FromBody] InsumoDTO insumoDTO)
        {
            try
            {
                var insumo = await _insumoService.CrearInsumo(insumoDTO);
                return Ok(insumo);
            }
            catch
            {

                throw;
            }


        }

        [HttpGet]
        [Route("obtener/{id:int}")]
        public async Task<IActionResult> ObtenerInsumo(int id)
        {
            try
            {
                var Insumo = await _insumoService.ObtenerInsumo(id);
                return Ok(Insumo);
            }
            catch
            {

                throw;
            }


        }

        [HttpPut]
        [Route("eliminar/{id:int}")]
        public async Task<IActionResult> EliminarInsumo(int id)
        {
            try
            {
                await _insumoService.EliminarInsumo(id);
                return Ok();
            }
            catch
            {

                throw;
            }


        }

        [HttpPut]
        [Route("editar")]
        public async Task<IActionResult> ActualizarInsumo([FromBody] InsumoDTO insumoDTO)
        {
            try
            {
                await _insumoService.ActualizarInsumo(insumoDTO);
                return Ok();
            }
            catch
            {

                throw;
            }


        }

        [HttpGet]
        [Route("listarEliminados")]
        public async Task<IActionResult> ListarInsumoEliminados()
        {
            try
            {
                var insumos = await _insumoService.ListarInsumoEliminados();
                return Ok(insumos);

            }
            catch
            {

                throw;
            }
  
        }


        [HttpPut]
        [Route("recuperar/{id:int}")]
        public async Task<IActionResult> RecuperarInsumo(int id)
        {
            try
            {
                await _insumoService.RecuperarInsumo(id);
                return Ok();
            }
            catch
            {

                throw;
            }


        }

    }
}
