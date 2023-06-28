using AcopioExpress.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcopioExpress.BLL.Servicios.Contratos
{
    public interface ILiquidacionService
    {
        Task<List<LiquidacionProductorDTO>> ListarLiquidaciones();
        Task<LiquidacionProductorDTO> GenerarLiquidacion(int id , string? fechaInicio, string? fechaFin);
        Task<LiquidacionProductorDTO> ObtenerLiquidacion(int id);
        Task<bool> EliminarLiquidacion(int id);
    }
}
