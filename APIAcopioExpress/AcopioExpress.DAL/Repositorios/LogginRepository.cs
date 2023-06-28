using AcopioExpress.DAL.DBContext;
using AcopioExpress.DAL.Repositorios.Contrato;
using AcopioExpress.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AcopioExpress.DAL.Repositorios
{
    public class LogginRepository:ILogginRepository
    {
        private readonly AcopioExpressDbContext _dbcontext;

        public LogginRepository(AcopioExpressDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }


        public async Task<IQueryable<Login>> Consultar(Expression<Func<Login, bool>> filtro = null)
        {
            try
            {
                IQueryable<Login> queryModelo = filtro == null ? _dbcontext.Set<Login>() : _dbcontext.Logins.Where(filtro);
                return queryModelo;
            }
            catch
            {

                throw;
            }
        }

    }
}
