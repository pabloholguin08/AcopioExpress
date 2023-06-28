using AcopioExpress.DTO;
using AcopioExpress.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcopioExpress.BLL.Servicios.Contratos
{
    public interface IVentaProduccionService
    {
        
        Task<List<VentaProduccionDTO>> ListarProduccion();
        Task<VentaProduccionDTO> CrearProduccion(VentaProduccionDTO produccionDTO);
        Task<bool> ActualizarProduccion(VentaProduccionDTO produccionDTO);
        Task<VentaProduccionDTO> ObtenerProduccion(int id);
        Task<bool> EliminarProduccion(int id);
        Task<List<VentaProduccionDTO>> ListarProduccionEliminados();
        Task<bool> RecuperarProduccion(int id);
        Task<List<VentaProduccionDTO>> ListarPorFecha(string? fechaInicio, string? fechaFin);

    }
}
