using AcopioExpress.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AcopioExpress.DAL.Repositorios.Contrato
{
    public interface IPersonaRepository
    {
        Task<Persona> CrearPersona(Persona persona);
        Task<bool> ActualizarPersona(Persona persona);
        Task<Persona> ObtenerPersona(int id);
        Task<bool> EliminarPersona(int id);
        Task<bool> RecuperarPersona(int id);
        Task<IQueryable<Persona>> Consultar(Expression<Func<Persona, bool>> filtro = null);


    }
}
