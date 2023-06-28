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
    public class InsumoRepository:IInsumoRepository
    {
        private readonly AcopioExpressDbContext _dbcontext;
         
        public InsumoRepository(AcopioExpressDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }


        public async Task<List<Insumo>> ListarInsumo()
        {
            try
            {
                var lista = new List<Insumo>();
                lista = await _dbcontext.Insumos.Where(i => i.Estado == 1).ToListAsync();
                return lista;
            }
            catch 
            {

                throw;
            }
        }


        public async Task<Insumo> CrearInsumo(Insumo insumo)
        {
            try
            {
                insumo.GananciaUnitaria = insumo.ValorUnitarioVenta - insumo.ValorUnitarioCompra;
                _dbcontext.Add(insumo);
                await _dbcontext.SaveChangesAsync();
                return insumo;
            }
            catch
            {

                throw;
            }
        }

        public async Task<bool> ActualizarInsumo(Insumo insumo)
        {
            try
            {
                _dbcontext.Update(insumo);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch
            {

                throw;
            }
        }
        public async Task<Insumo> ObtenerInsumo(int id)
        {
            try
            {
                var InsumoEncontrado = await _dbcontext.Insumos.Where(i => i.Estado == 1).FirstOrDefaultAsync(i => i.IdInsumo == id);
                return InsumoEncontrado;
            }
            catch
            {

                throw;
            }
        }

        public async Task<bool> EliminarInsumo(int id)
        {
            try
            {
                var insumo = _dbcontext.Insumos.FirstOrDefault(i => i.IdInsumo == id);
                insumo.Estado = 0;
                _dbcontext.Update(insumo);
                await _dbcontext.SaveChangesAsync(); 
                return true;

            }
            catch
            {

                throw;
            }
        }


        public async Task<List<Insumo>> ListarInsumoEliminados()
        {
            try
            {
                var lista = new List<Insumo>();
                lista = await _dbcontext.Insumos.Where(i => i.Estado == 0).ToListAsync();
                return lista;
            }
            catch
            {

                throw;
            }
        }

      

        public async Task<bool> RecuperarInsumo(int id)
        {
            try
            {
                var insumo = _dbcontext.Insumos.FirstOrDefault(i => i.IdInsumo == id);
                insumo.Estado = 1;
                _dbcontext.Update(insumo);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch
            {

                throw;
            }
        }

        public async Task<IQueryable<Insumo>> Consultar(Expression<Func<Insumo, bool>> filtro = null)
        {
            try
            {
                IQueryable<Insumo> queryModelo = filtro == null ? _dbcontext.Set<Insumo>() : _dbcontext.Insumos.Where(filtro);
                return queryModelo;
            }   
            catch
            {

                throw;
            }
        }
    }
}
