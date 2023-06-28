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
    public class NominaRepository : INominaRepository
    {
        private readonly AcopioExpressDbContext _dbcontext;

        public NominaRepository(AcopioExpressDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }


        public async Task<Nomina> CrearNomina(Nomina nomina)
        {
            try
            {
                _dbcontext.Add(nomina);
                await _dbcontext.SaveChangesAsync();    
                return nomina;
            }
            catch
            {

                throw;
            }
        }

        public async Task<bool> ActualizarNomina(Nomina nomina)
        {
            try
            {
                _dbcontext.Update(nomina);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch
            {

                throw;
            }
        }

        public async Task<bool> EliminarNomina(int id)
        {
            try
            {
                var nomina = _dbcontext.Nominas.Where(n => n.IdNomina == id).First();
                _dbcontext.Nominas.Remove(nomina);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch
            {

                throw;
            }
        }

        public async Task<Nomina> ObtenerNomina(int id)
        {
            try
            {

                var nominaEncontrado =  _dbcontext.Nominas.Where(n => n.IdNomina == id).First();
                return nominaEncontrado;
            }
            catch
            {

                throw;
            }
        }

        public async Task<IQueryable<Nomina>> Consultar(Expression<Func<Nomina, bool>> filtro = null)
        {
            try
            {
                IQueryable<Nomina> queryModelo = filtro == null ? _dbcontext.Set<Nomina>() : _dbcontext.Nominas.Where(filtro);
                return queryModelo;
            }
            catch
            {

                throw;
            }
        }
    }
}
