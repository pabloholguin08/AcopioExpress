using AcopioExpress.DTO;
using AcopioExpress.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcopioExpress.BLL.Servicios.Contratos
{
    public interface IAcopioService
    {
        Task<List<AcopioDTO>> ListarAcopios();
        Task<AcopioDTO> CrearAcopio(AcopioDTO acopio);
        Task<bool> ActualizarAcopio(AcopioDTO acopio);
        Task<AcopioDTO> ObtenerAcopio(int id);
        Task<bool> EliminarAcopio(int id);
        Task<List<AcopioDTO>> ListarAcopioEliminados();
        Task<bool> RecuperarAcopio(int id);
        Task<ReporteAcopioDTO> GenerarReporte(string? fechaInicio , string? fechaFin);
    }
}
