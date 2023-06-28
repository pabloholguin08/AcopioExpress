using AcopioExpress.BLL.Servicios;
using AcopioExpress.BLL.Servicios.Contratos;
using AcopioExpress.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcopioExpress.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NominaController : ControllerBase
    {

        private readonly INominaSevice _nominaService;

        public NominaController(INominaSevice nominaService)
        {
            _nominaService = nominaService;
        }


        [HttpGet]
        [Route("listar")]
        public async Task<IActionResult> ListarNominas()
        {
            try
            {
                var nominas = await _nominaService.ListarNominas();
                return Ok(nominas);
            }
            catch 
            {

                throw;
            }


        }


        [HttpPost]
        [Route("crear")]
        public async Task<IActionResult> CrearNomina([FromBody] NominaDTO nominaDTO)
        {
            try
            {
                var nomina = await _nominaService.CrearNomina(nominaDTO);
                return Ok(nomina);
            }
            catch
            {

                throw;
            }


        }

        [HttpGet]
        [Route("obtener/{id:int}")]
        public async Task<IActionResult> ObtenerNomina(int id)
        {
            try
            {
                var nomina = await _nominaService.ObtenerNomina(id);
                return Ok(nomina);
            }
            catch
            {

                throw;
            }


        }

        [HttpPut]
        [Route("editar")]
        public async Task<IActionResult> ActualizarNomina([FromBody] NominaDTO modelo)
        {
            try
            {
                await _nominaService.ActualizarNomina(modelo);
                return Ok();
            }
            catch
            {

                throw;
            }


        }


        [HttpDelete]
        [Route("eliminar/{id:int}")]
        public async Task<IActionResult> EliminarNomina(int id)
        {
            try
            {
                await _nominaService.EliminarNomina(id);
                return Ok();
            }
            catch
            {

                throw;
            }


        }



    }
}
