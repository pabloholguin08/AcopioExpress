using AcopioExpress.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AcopioExpress.DAL.Repositorios.Contrato
{
    public interface IIngresosAcopioRepository
    {
        Task<IngresosAcopio> CrearIngresosAcopio(IngresosAcopio ingresosAcopio);
        Task<IngresosAcopio> ObtenerIngresosAcopio(int id);
        Task<bool> EliminarIngresosAcopio(int id);
        Task<IQueryable<IngresosAcopio>> Consultar(Expression<Func<IngresosAcopio, bool>> filtro = null);
    }
}
