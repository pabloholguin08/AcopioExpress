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
    public class LiquidacionRepository:ILiquidacionRepository
    {

        private readonly AcopioExpressDbContext _dbcontext;

        public LiquidacionRepository(AcopioExpressDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }



        public async Task<LiquidacionProductor> CrearLiquidacion(LiquidacionProductor liquidacionProductor)
        {
            try
            {
                
                _dbcontext.Add(liquidacionProductor);
                await _dbcontext.SaveChangesAsync();
                return liquidacionProductor;

            }
            catch
            {

                throw;
            }
        }

        public async Task<LiquidacionProductor> ObtenerLiquidacion(int id)
        {
            try
            {

                var datoEncontrado = await _dbcontext.LiquidacionProductors.Where(d => d.IdLiquidacion == id).FirstOrDefaultAsync();
                return datoEncontrado;
            }
            catch
            {

                throw;
            }
        }

        public async Task<bool> EliminarLiquidacion(int id)
        {
            try
            {

                var liquidacion = _dbcontext.LiquidacionProductors.Where(n => n.IdLiquidacion == id).First();
                _dbcontext.LiquidacionProductors.Remove(liquidacion);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch
            {

                throw;
            }
        }

        
        public async Task<IQueryable<LiquidacionProductor>> Consultar(Expression<Func<LiquidacionProductor, bool>> filtro = null)
        {
            try
            {
                IQueryable<LiquidacionProductor> queryModelo = filtro == null ? _dbcontext.Set<LiquidacionProductor>() : _dbcontext.LiquidacionProductors.Where(filtro);
                return queryModelo;
            }
            catch
            {

                throw;
            }
        }
    }
}
