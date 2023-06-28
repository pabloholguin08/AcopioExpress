using AcopioExpress.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcopioExpress.BLL.Servicios.Contratos
{
    public interface IIngresosAcopioService
    {
        Task<IngresosAcopioDTO> GenerarIngresosAcopio( string? fechaInicio, string? fechaFin);
        Task<List<IngresosAcopioDTO>> ListarIngresosAcopio();
        Task<List<IngresosAcopioDTO>> ListarIngresosAcopioFechas(string? fechaInicio, string? fechaFin);
        Task<bool> EliminarIngresosAcopio(int id);

    }
}
