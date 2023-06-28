using AcopioExpress.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcopioExpress.BLL.Servicios.Contratos
{
     public interface IventaInsumoService
    {
        Task<VentaInsumoDTO> Registrar(VentaInsumoDTO modelo);
        Task<List<VentaInsumoDTO>> Historial(  string? fechaInicio, string? fechaFin);
        Task<bool> EliminarVenta(int id);
        Task<List<ReporteDTO>> Reporte( string fechaInicio, string fechaFin);

    }
}
