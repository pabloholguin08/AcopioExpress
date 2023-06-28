using AcopioExpress.DTO;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AcopioExpress.BLL.Servicios.Contratos
{
    public interface INominaSevice
    {
        Task<List<NominaDTO>> ListarNominas();
        Task<NominaDTO> CrearNomina(NominaDTO nominaDTO);
        Task<bool> ActualizarNomina(NominaDTO nomina);
        Task<NominaDTO> ObtenerNomina(int id);
        Task<bool> EliminarNomina(int id);
     
    }
}
