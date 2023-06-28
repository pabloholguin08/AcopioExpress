using AcopioExpress.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcopioExpress.BLL.Servicios.Contratos
{
    public interface IProduccionService
    {
        Task<List<ProduccionDTO>> ListarProduccion();
        Task<List<ProduccionDTO>> ListarProduccionFecha(string? fechaInicio, string? fechaFin);

        Task<ProduccionDTO> CrearProduccion(ProduccionDTO produccionDTO);
        Task<bool> ActualizarProduccion(ProduccionDTO produccionDTO);
        Task<ProduccionDTO> ObtenerProduccion(int id);
        Task<bool> EliminarProduccion(int id);
        Task<List<ProduccionDTO>> ListarProduccionEliminados();
        Task<bool> RecuperarProduccion(int id);
    }
}
