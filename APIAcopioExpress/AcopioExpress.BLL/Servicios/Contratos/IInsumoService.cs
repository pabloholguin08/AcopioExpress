using AcopioExpress.DTO;
using AcopioExpress.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcopioExpress.BLL.Servicios.Contratos
{
    public interface IInsumoService
    {
        Task<List<InsumoDTO>> ListarInsumo();
        Task<InsumoDTO> CrearInsumo(InsumoDTO insumoDto);
        Task<bool> ActualizarInsumo(InsumoDTO insumoDto);
        Task<InsumoDTO> ObtenerInsumo(int id);
        Task<bool> EliminarInsumo(int id);
        Task<List<InsumoDTO>> ListarInsumoEliminados();
        Task<bool> RecuperarInsumo(int id);
    }
}
