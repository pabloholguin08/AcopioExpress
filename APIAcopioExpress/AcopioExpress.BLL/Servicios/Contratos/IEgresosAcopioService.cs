using AcopioExpress.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcopioExpress.BLL.Servicios.Contratos
{
    public interface IEgresosAcopioService
    {
        Task<EgresosAcopioDTO> GenerarEgresosAcopio(EgresosAcopioDTO egresosAcopioDTO,string? fechaInicio, string? fechaFin);
        Task<List<EgresosAcopioDTO>> ListarEgresosAcopio();
        Task<List<EgresosAcopioDTO>> ListarEgresosAcopioFechas(string? fechaInicio, string? fechaFin);
        Task<bool> EliminarEgresosAcopio(int id);
    }
}
