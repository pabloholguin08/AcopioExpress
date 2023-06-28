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
    public class AcopioRepository:IAcopioRepository
    {
        //Instacia de dbcontext
        private readonly AcopioExpressDbContext _dbcontext;

        public AcopioRepository(AcopioExpressDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

 
        public async Task<Acopio> CrearAcopio(Acopio acopio)
        {

            try
            {
                _dbcontext.Add(acopio);
                await _dbcontext.SaveChangesAsync();
                return acopio;
            }
            catch
            {

                throw;
            }
           
        }

        public async Task<Acopio> ObtenerAcopio(int id)
        {

            try
            {
                var acopioEncontrado = await _dbcontext.Acopios.Where(a => a.Estado == 1).FirstOrDefaultAsync(a => a.IdAcopio == id);
                return acopioEncontrado;
            }
            catch
            {

                throw;
            }
      
        }

 
        public async Task<bool> EliminarAcopio(int id)
        {

            try
            {
                var acopio = _dbcontext.Acopios.FirstOrDefault(a => a.IdAcopio == id);
                acopio.Estado = 0;
                _dbcontext.Acopios.Update(acopio);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch
            {

                throw;
            }

        }

        public async Task<bool> ActualizarAcopio(Acopio acopio)
        {
            try
            {

                _dbcontext.Acopios.Update(acopio);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch 
            {

                throw;
            }
        }

        public async Task<bool> RecuperarAcopio(int id)
        {

            try
            {
                var acopio = _dbcontext.Acopios.FirstOrDefault(a => a.IdAcopio == id);
                acopio.Estado = 1;
                _dbcontext.Acopios.Update(acopio);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch 
            {

                throw;
            }
            
        }

        public async Task<IQueryable<Acopio>> Consultar(Expression<Func<Acopio, bool>> filtro = null)
        {
            try
            {
                IQueryable<Acopio> queryModelo = filtro==null?_dbcontext.Set<Acopio>():_dbcontext.Acopios.Where(filtro);
                return queryModelo;
            }
            catch
            {

                throw;
            }
        }
    }
}
