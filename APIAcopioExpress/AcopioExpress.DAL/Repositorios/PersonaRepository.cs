
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
    public class PersonaRepository:IPersonaRepository
    {
        private readonly AcopioExpressDbContext _dbcontext;

        public PersonaRepository(AcopioExpressDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<Persona> CrearPersona(Persona persona)
        {
            try
            {
                _dbcontext.Add(persona);
                await _dbcontext.SaveChangesAsync();
                return persona;

            }
            catch
            {

                throw;
            }
        }

        public async Task<Persona> ObtenerPersona(int id)
        {
            try
            {

                var personaEncontrado = await _dbcontext.Personas.Where(a => a.Estado == 1).FirstOrDefaultAsync(a => a.IdPersona == id);
                return personaEncontrado;
            }
            catch
            {

                throw;
            }
        }

        public async Task<bool> EliminarPersona(int id)
        {
            try
            {

                var persona = _dbcontext.Personas.FirstOrDefault(a => a.IdPersona == id);
                persona.Estado = 0;
                _dbcontext.Personas.Update(persona);
                await _dbcontext.SaveChangesAsync();
                return true;

            }
            catch
            {

                throw;
            }
        }


        public async Task<bool> ActualizarPersona(Persona persona)
        {
            try
            {

                _dbcontext.Personas.Update(persona);
                await _dbcontext.SaveChangesAsync();
                return true;

            }
            catch 
            {

                throw;
            }
        }
       

        public async Task<bool> RecuperarPersona(int id)
        {
            try
            {
                var persona = _dbcontext.Personas.FirstOrDefault(a => a.IdPersona == id);
                persona.Estado = 1;
                _dbcontext.Personas.Update(persona);
                await _dbcontext.SaveChangesAsync();
                return true;

            }
            catch
            {

                throw;
            }
        }

        public  async Task<IQueryable<Persona>> Consultar(Expression<Func<Persona, bool>> filtro = null)
        {
            try
            {
                IQueryable<Persona> queryModelo = filtro==null?_dbcontext.Set<Persona>():_dbcontext.Personas.Where(filtro);
                return queryModelo;
            }
            catch 
            {

                throw;
            }
        }
    }
}
