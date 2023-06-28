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
    public class ProduccionRepository :IProduccionRepository
    {
        private readonly AcopioExpressDbContext _dbcontext;

        public ProduccionRepository(AcopioExpressDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }



        public async Task<Produccion> CrearProduccion(Produccion produccion)
        {
            try
            {
                _dbcontext.Add(produccion);
                await _dbcontext.SaveChangesAsync();
                return produccion;

            }
            catch
            {

                throw;
            }
        }

        public async Task<Produccion> ObtenerProduccion(int id)
        {
            try
            {

                var datoEncontrado = await _dbcontext.Produccions.Where(d => d.Estado == 1).FirstOrDefaultAsync(d => d.IdProduccion == id);
                return datoEncontrado;
            }
            catch
            {

                throw;
            }
        }

        public async Task<bool> EliminarProduccion(int id)
        {
            try
            {

                var produccion = _dbcontext.Produccions.FirstOrDefault(a => a.IdProduccion == id);
                produccion.Estado = 0;
                _dbcontext.Produccions.Update(produccion);
                await _dbcontext.SaveChangesAsync();
                return true;

            }
            catch
            {

                throw;
            }
        }


        public async Task<bool> ActualizarProduccion(Produccion produccion)
        {
            try
            {

                _dbcontext.Produccions.Update(produccion);
                await _dbcontext.SaveChangesAsync();
                return true;

            }
            catch
            {

                throw;
            }
        }


        public async Task<bool> RecuperarProduccion(int id)
        {
            try
            {
                var produccion = _dbcontext.Produccions.FirstOrDefault(p => p.IdProduccion == id);
                produccion.Estado = 1;
                _dbcontext.Produccions.Update(produccion);
                await _dbcontext.SaveChangesAsync();
                return true;

            }
            catch
            {

                throw;
            }
        }

        public async Task<IQueryable<Produccion>> Consultar(Expression<Func<Produccion, bool>> filtro = null)
        {
            try
            {
                IQueryable<Produccion> queryModelo = filtro == null ? _dbcontext.Set<Produccion>() : _dbcontext.Produccions.Where(filtro);
                return queryModelo;
            }
            catch
            {

                throw;
            }
        }
    }
}
