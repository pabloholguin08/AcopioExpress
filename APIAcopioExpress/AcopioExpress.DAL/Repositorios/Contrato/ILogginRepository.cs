using AcopioExpress.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AcopioExpress.DAL.Repositorios.Contrato
{
    public interface ILogginRepository
    {
        Task<IQueryable<Login>> Consultar(Expression<Func<Login, bool>> filtro = null);
    }
}
