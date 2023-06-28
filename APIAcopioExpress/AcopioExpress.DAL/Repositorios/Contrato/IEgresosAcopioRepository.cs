using AcopioExpress.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AcopioExpress.DAL.Repositorios.Contrato
{
    public interface IEgresosAcopioRepository
    {
        Task<EgresosAcopio> CrearEgresosAcopio(EgresosAcopio egresosAcopio);
        Task<EgresosAcopio> ObtenerEgresosAcopio(int id);
        Task<bool> EliminarEgresosAcopio(int id);
        Task<IQueryable<EgresosAcopio>> Consultar(Expression<Func<EgresosAcopio, bool>> filtro = null);
    }
}
