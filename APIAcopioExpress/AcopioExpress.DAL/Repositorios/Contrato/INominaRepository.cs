using AcopioExpress.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AcopioExpress.DAL.Repositorios.Contrato
{
    public interface INominaRepository
    {
        Task<Nomina> CrearNomina(Nomina nomina);
        Task<bool> ActualizarNomina(Nomina nomina);
        Task<Nomina> ObtenerNomina(int id);
        Task<bool> EliminarNomina(int id);
        Task<IQueryable<Nomina>> Consultar(Expression<Func<Nomina, bool>> filtro = null);

    }
}
