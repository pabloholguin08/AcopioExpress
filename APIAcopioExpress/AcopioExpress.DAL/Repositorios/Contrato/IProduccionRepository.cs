using AcopioExpress.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AcopioExpress.DAL.Repositorios.Contrato
{
    public interface IProduccionRepository
    {
        Task<Produccion> CrearProduccion(Produccion produccion);
        Task<bool> ActualizarProduccion(Produccion produccion);
        Task<Produccion> ObtenerProduccion(int id);
        Task<bool> EliminarProduccion(int id);
        Task<bool> RecuperarProduccion(int id);
        Task<IQueryable<Produccion>> Consultar(Expression<Func<Produccion, bool>> filtro = null);

    }
}
