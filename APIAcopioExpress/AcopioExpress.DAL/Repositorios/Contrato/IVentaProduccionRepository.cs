using AcopioExpress.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AcopioExpress.DAL.Repositorios.Contrato
{
    public interface IVentaProduccionRepository
    {
        Task<VentaProduccion> Registrar(VentaProduccion modelo);
        Task<bool> ActualizarVenta(VentaProduccion modelo);
        Task<VentaProduccion> ObtenerVenta(int id);
        Task<bool> EliminarVenta(int id);
        Task<bool> RecuperarVenta(int id);
        Task<IQueryable<VentaProduccion>> Consultar(Expression<Func<VentaProduccion, bool>> filtro = null);
    }
}
