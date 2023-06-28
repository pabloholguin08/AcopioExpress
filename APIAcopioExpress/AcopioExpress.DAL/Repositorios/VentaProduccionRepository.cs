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
    public class VentaProduccionRepository :IVentaProduccionRepository
    {

        private readonly AcopioExpressDbContext _dbcontext;

        public VentaProduccionRepository(AcopioExpressDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<VentaProduccion> Registrar(VentaProduccion modelo)
        {
            try
            {
                _dbcontext.Add(modelo);
                await _dbcontext.SaveChangesAsync();
                return modelo;
            }
            catch 
            {

                throw;
            }
        }
        public async Task<VentaProduccion> ObtenerVenta(int id)
        {
            try
            {
                var ventaEncontrada = await _dbcontext.VentaProduccions.Where(vp => vp.Estado ==1).FirstOrDefaultAsync(vp => vp.IdVentaProduccion == id);
                return ventaEncontrada;
            }
            catch
            {

                throw;
            }
        }
        public async Task<bool> ActualizarVenta(VentaProduccion modelo)
        {
            try
            {
                _dbcontext.Update(modelo);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch
            {

                throw;
            }
        }


        public async Task<bool> EliminarVenta(int id)
        {
            try
            {
                var venta = _dbcontext.VentaProduccions.FirstOrDefault(a => a.IdVentaProduccion == id);
                venta.Estado = 0;
                _dbcontext.VentaProduccions.Update(venta);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch
            {

                throw;
            }
        }

        public async Task<bool> RecuperarVenta(int id)
        {
            try
            {
                var venta = _dbcontext.VentaProduccions.FirstOrDefault(a => a.IdVentaProduccion == id);
                venta.Estado = 1;
                _dbcontext.VentaProduccions.Update(venta);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch
            {

                throw;
            }
        }




        public async Task<IQueryable<VentaProduccion>> Consultar(Expression<Func<VentaProduccion, bool>> filtro = null)
        {
            IQueryable<VentaProduccion> queryModelo = filtro == null ? _dbcontext.Set<VentaProduccion>() : _dbcontext.VentaProduccions.Where(filtro);
            return queryModelo;
        }
    }
}
