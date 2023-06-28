using AcopioExpress.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AcopioExpress.DAL.Repositorios.Contrato
{
    public interface IAcopioRepository
    {
        Task<Acopio> CrearAcopio(Acopio acopio);
        Task<bool> ActualizarAcopio(Acopio acopio );
        Task<Acopio> ObtenerAcopio(int id);
        Task<bool> EliminarAcopio(int id);
        Task<bool> RecuperarAcopio(int id);
        Task<IQueryable<Acopio>> Consultar(Expression<Func<Acopio, bool>> filtro = null);

    }
}
