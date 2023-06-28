using AcopioExpress.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AcopioExpress.DAL.Repositorios.Contrato
{
    public interface ILiquidacionRepository
    {
        Task<LiquidacionProductor> CrearLiquidacion(LiquidacionProductor liquidacionProductor);
        Task<LiquidacionProductor> ObtenerLiquidacion(int id);
        Task<bool> EliminarLiquidacion(int id);
        Task<IQueryable<LiquidacionProductor>> Consultar(Expression<Func<LiquidacionProductor, bool>> filtro = null);
    }
}
