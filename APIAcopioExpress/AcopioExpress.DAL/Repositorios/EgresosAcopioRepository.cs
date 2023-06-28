using AcopioExpress.DAL.DBContext;
using AcopioExpress.DAL.Repositorios.Contrato;
using AcopioExpress.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AcopioExpress.DAL.Repositorios
{
    public class EgresosAcopioRepository : IEgresosAcopioRepository
    {
        private readonly AcopioExpressDbContext _dbcontext;

        public EgresosAcopioRepository(AcopioExpressDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }


        public async Task<EgresosAcopio> CrearEgresosAcopio(EgresosAcopio egresosAcopio)
        {
            try
            {
                _dbcontext.EgresosAcopios.Add(egresosAcopio);
                await _dbcontext.SaveChangesAsync();
                return egresosAcopio;
            }
            catch 
            {

                throw;
            }
        }

        public async Task<EgresosAcopio> ObtenerEgresosAcopio(int id)
        {
            try
            {
                var datoEncontrado = await _dbcontext.EgresosAcopios.Where(d => d.IdEgresosAcopio == id).FirstOrDefaultAsync();
                return datoEncontrado;
            }
            catch
            {

                throw;
            }
        }
        public  async Task<bool> EliminarEgresosAcopio(int id)
        {
            try
            {
                var egresos = _dbcontext.EgresosAcopios.Where(n => n.IdEgresosAcopio == id).First();
                _dbcontext.EgresosAcopios.Remove(egresos);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch
            {

                throw;
            }
        }

        public async Task<IQueryable<EgresosAcopio>> Consultar(Expression<Func<EgresosAcopio, bool>> filtro = null)
        {
            try
            {
                IQueryable<EgresosAcopio> queryModelo = filtro == null ? _dbcontext.Set<EgresosAcopio>() : _dbcontext.EgresosAcopios.Where(filtro);
                return queryModelo;
            }
            catch
            {

                throw;
            }
        }

    }
}
