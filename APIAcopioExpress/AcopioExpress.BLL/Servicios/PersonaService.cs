using AcopioExpress.BLL.Servicios.Contratos;
using AcopioExpress.DAL.Repositorios;
using AcopioExpress.DAL.Repositorios.Contrato;
using AcopioExpress.DTO;
using AcopioExpress.Model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcopioExpress.BLL.Servicios
{
    public class PersonaService:IPersonaService
    {
        private readonly IPersonaRepository _personaRepository;
        private readonly IMapper _mapper;

        public PersonaService(IPersonaRepository personaRepository, IMapper mapper)
        {
            _personaRepository = personaRepository;
            _mapper = mapper;
        }


        public async Task<List<PersonaDTO>> ListarPersona()
        {
            try
            {
                var queryPersonas = await _personaRepository.Consultar(p => p.Estado ==1);
                var listaPersonas = queryPersonas.Include(acopio => acopio.IdAcopioNavigation ).Include(rol => rol.IdRolNavigation)
                    .Include(tp => tp.IdTipoProductoNavigation);
                return _mapper.Map<List<PersonaDTO>>(listaPersonas).ToList();
            }
            catch
            {

                throw;
            }
        }
     

        public async Task<PersonaDTO> CrearPersona(PersonaDTO personaDTO)
        {
            try
            {
                var nuevaPersona = await _personaRepository.CrearPersona(_mapper.Map<Persona>(personaDTO));
                if (nuevaPersona.IdPersona == 0)
                {
                    throw new TaskCanceledException("No se pudo crear");
                }
                var query = await _personaRepository.Consultar(p => p.IdPersona == nuevaPersona.IdPersona);

                nuevaPersona=query.Include(ap=> ap.IdAcopioNavigation).Include(tp => tp.IdTipoProductoNavigation)
                    .Include(rol=> rol.IdRolNavigation).First(p => p.Estado == 1);
                return _mapper.Map<PersonaDTO>(nuevaPersona);
            }
            catch 
            {

                throw;
            }
        }
        public async Task<PersonaDTO> ObtenerPersona(int id)
        {
            try
            {
                var persona = await _personaRepository.Consultar(p => p.IdPersona ==id);
                var personaEncontrada = persona.Include(ap => ap.IdAcopioNavigation).Include(tp => tp.IdTipoProductoNavigation)
                    .Include(rol => rol.IdRolNavigation).First(p=>p.Estado == 1);


                if (personaEncontrada == null)
                {
                    throw new TaskCanceledException("No Existe la persona");
                }
                return _mapper.Map<PersonaDTO>(personaEncontrada);
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
                var personaEliminada = await _personaRepository.EliminarPersona(id);
                return true;
            }
            catch
            {

                throw;
            }
        }
        public async Task<bool> ActualizarPersona(PersonaDTO personaDTO)
        {
            try
            {
                var personaModelo = _mapper.Map<Persona>(personaDTO);
                var personaEncontrada = await _personaRepository.ObtenerPersona(personaModelo.IdPersona);
                if (personaEncontrada == null)
                {
                    throw new TaskCanceledException("La persona no existe");
                }

                personaEncontrada.Cedula = personaModelo.Cedula;
                personaEncontrada.Nombres = personaModelo.Nombres;
                personaEncontrada.Apellidos = personaModelo.Apellidos;
                personaEncontrada.Telefono = personaModelo.Telefono;
                personaEncontrada.Direccion = personaModelo.Direccion;
                personaEncontrada.IdAcopio = personaModelo.IdAcopio;
                personaEncontrada.IdTipoProducto = personaModelo.IdTipoProducto;
                personaEncontrada.IdRol = personaModelo.IdRol;

                bool respuesta = await _personaRepository.ActualizarPersona(personaEncontrada);
                if (!respuesta)
                {
                    throw new TaskCanceledException("La persona no existe");
                }

                return respuesta;

            }
            catch
            {

                throw;
            }
        }

        public async Task<List<PersonaDTO>> ListarPersonaEliminados()
        {
            try
            {
                var queryPersonas = await _personaRepository.Consultar(p => p.Estado == 0);
                var listaPersonas = queryPersonas.Include(acopio => acopio.IdAcopioNavigation).Include(rol => rol.IdRolNavigation)
                    .Include(tp => tp.IdTipoProductoNavigation);
                return _mapper.Map<List<PersonaDTO>>(listaPersonas).ToList();
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
                var personaEliminado = await _personaRepository.RecuperarPersona(id);
                return true;
            }
            catch
            {

                throw;
            }
        }

        public async Task<List<PersonaDTO>> ListarEmpleados()
        {
            try
            {
                var queryPersonas = await _personaRepository.Consultar(p => p.Estado == 1 && p.IdRol ==2);
                var listaPersonas = queryPersonas.Include(acopio => acopio.IdAcopioNavigation).Include(rol => rol.IdRolNavigation)
                    .Include(tp => tp.IdTipoProductoNavigation);
                return _mapper.Map<List<PersonaDTO>>(listaPersonas).ToList();
            }
            catch
            {

                throw;
            }
        }

        public async Task<List<PersonaDTO>> ListarProductores()
        {
            try
            {
                var queryPersonas = await _personaRepository.Consultar(p => p.Estado == 1 && p.IdRol == 3);
                var listaPersonas = queryPersonas.Include(acopio => acopio.IdAcopioNavigation).Include(rol => rol.IdRolNavigation)
                    .Include(tp => tp.IdTipoProductoNavigation);
                return _mapper.Map<List<PersonaDTO>>(listaPersonas).ToList();
            }
            catch
            {

                throw;
            }
        }
    }
}
