using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AcopioExpress.Model;

namespace AcopioExpress.DAL.Repositorios.Contrato
{
    public interface IVentaInsumoRepository
    {
        Task<VentaInsumo> Registrar(VentaInsumo modelo);
        Task<VentaInsumo> ObtenerVenta(int id);
        Task<bool> EliminarVenta(int id);
        Task<IQueryable<VentaInsumo>> Consultar(Expression<Func<VentaInsumo, bool>> filtro = null);
        Task<IQueryable<DetalleVentaInsumo>> ConsultarDetalle(Expression<Func<DetalleVentaInsumo, bool>> filtro = null);

    }
}
