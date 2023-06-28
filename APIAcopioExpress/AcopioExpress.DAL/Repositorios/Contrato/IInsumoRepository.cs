using AcopioExpress.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AcopioExpress.DAL.Repositorios.Contrato
{
    public interface IInsumoRepository
    {
        Task<List<Insumo>> ListarInsumo();
        Task<Insumo> CrearInsumo(Insumo insumo);
        Task<bool> ActualizarInsumo(Insumo insumo);
        Task<Insumo> ObtenerInsumo(int id);
        Task<bool> EliminarInsumo(int id);
        Task<List<Insumo>> ListarInsumoEliminados();
        Task<bool> RecuperarInsumo(int id);
        Task<IQueryable<Insumo>> Consultar(Expression<Func<Insumo, bool>> filtro = null);

    }
}
