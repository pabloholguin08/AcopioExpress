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
    public class VentaInsumoRepository : IVentaInsumoRepository
    {
        private readonly AcopioExpressDbContext _dbcontext;

        public VentaInsumoRepository(AcopioExpressDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<VentaInsumo> Registrar(VentaInsumo modelo)
        {
            VentaInsumo ventaGenerada = modelo;

            using (var transaction = _dbcontext.Database.BeginTransaction())
            {
                try
                {
                    foreach (DetalleVentaInsumo dv in ventaGenerada.DetalleVentaInsumos)
                    {
                        Insumo insumo_encontrado = _dbcontext.Insumos.Where(i => i.IdInsumo == dv.IdInsumo).First();
                        insumo_encontrado.Stock = insumo_encontrado.Stock - dv.Cantidad;
                        _dbcontext.Insumos.Update(insumo_encontrado);

                    }
                    await _dbcontext.SaveChangesAsync();

                    _dbcontext.VentaInsumos.Add(ventaGenerada);
                    await _dbcontext.SaveChangesAsync();

                    transaction.Commit();

                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }

                return ventaGenerada;
            }
        }

        public async Task<VentaInsumo> ObtenerVenta(int id)
        {

            var datoEncontrado = await _dbcontext.VentaInsumos.Where(d => d.IdVentaInsumo == id).FirstOrDefaultAsync();
            return datoEncontrado;
        }

        public async Task<bool> EliminarVenta(int id)
        {
            try
            {
                VentaInsumo ventaGenerada = await _dbcontext.VentaInsumos.Include(v => v.DetalleVentaInsumos).FirstOrDefaultAsync(v => v.IdVentaInsumo == id);

                if (ventaGenerada == null)
                {
                    // Manejar el caso en el que no se encuentre la venta
                    return false;
                }

                foreach (DetalleVentaInsumo dv in ventaGenerada.DetalleVentaInsumos)
                {
                    Insumo insumo_encontrado = _dbcontext.Insumos.FirstOrDefault(i => i.IdInsumo == dv.IdInsumo);
                    if (insumo_encontrado != null)
                    {
                        insumo_encontrado.Stock += dv.Cantidad;
                        _dbcontext.Insumos.Update(insumo_encontrado);
                    }
                    _dbcontext.DetalleVentaInsumos.Remove(dv);
                }

                _dbcontext.VentaInsumos.Remove(ventaGenerada);
                await _dbcontext.SaveChangesAsync();

                return true;
            }
            catch
            {
                throw;
            }
        }


        public async Task<IQueryable<VentaInsumo>> Consultar(Expression<Func<VentaInsumo, bool>> filtro = null)
        {
            try
            {
                IQueryable<VentaInsumo> queryModelo = filtro == null ? _dbcontext.Set<VentaInsumo>() : _dbcontext.VentaInsumos.Where(filtro);
                return queryModelo;
            }
            catch
            {

                throw;
            }
        }

        public async Task<IQueryable<DetalleVentaInsumo>> ConsultarDetalle(Expression<Func<DetalleVentaInsumo, bool>> filtro = null)
        {
            try
            {
                IQueryable<DetalleVentaInsumo> queryModelo = filtro == null ? _dbcontext.Set<DetalleVentaInsumo>() : _dbcontext.DetalleVentaInsumos.Where(filtro);
                return queryModelo;
            }
            catch
            {

                throw;
            }
        }
    }
}
