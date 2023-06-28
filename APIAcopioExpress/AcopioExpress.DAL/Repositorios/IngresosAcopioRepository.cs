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
    public class IngresosAcopioRepository: IIngresosAcopioRepository
    {
        private readonly AcopioExpressDbContext _dbcontext;

        public IngresosAcopioRepository(AcopioExpressDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }


        public async Task<IngresosAcopio> CrearIngresosAcopio(IngresosAcopio ingresosAcopio)
        {
            try
            {
                _dbcontext.IngresosAcopios.Add(ingresosAcopio);
                await _dbcontext.SaveChangesAsync();
                return ingresosAcopio;
            }
            catch 
            {

                throw;
            }

        }
        public async Task<IngresosAcopio> ObtenerIngresosAcopio(int id)
        {
            try
            {
                var datoEncontrado = await _dbcontext.IngresosAcopios.Where(d => d.IdIngresosAcopio == id).FirstOrDefaultAsync();
                return datoEncontrado;
            }
            catch 
            {

                throw;
            }

        }
        public async Task<bool> EliminarIngresosAcopio(int id)
        {
            try
            {
                var ingresos = _dbcontext.IngresosAcopios.Where(n => n.IdIngresosAcopio == id).First();
                _dbcontext.IngresosAcopios.Remove(ingresos);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch
            {

                throw;
            }

        }


        public async Task<IQueryable<IngresosAcopio>> Consultar(Expression<Func<IngresosAcopio, bool>> filtro = null)
        {
            try
            {
                IQueryable<IngresosAcopio> queryModelo = filtro == null ? _dbcontext.Set<IngresosAcopio>() : _dbcontext.IngresosAcopios.Where(filtro);
                return queryModelo;
            }
            catch
            {

                throw;
            }
        }


    }
}
