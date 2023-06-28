using AcopioExpress.BLL.Servicios.Contratos;
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
    public class NominaService : INominaSevice
    {
        private readonly INominaRepository _nominaRepository;
        private readonly IMapper _mapper;

        public NominaService(INominaRepository nominaRepository, IMapper mapper)
        {
            _nominaRepository = nominaRepository;
            _mapper = mapper;
        }

        public async Task<List<NominaDTO>> ListarNominas()
        {
            try
            {
                var queryNomina = await _nominaRepository.Consultar( n => n.IdPersonaNavigation.IdRol == 2);
                var listaNomina = queryNomina.Include(nomina => nomina.IdPersonaNavigation);
                return _mapper.Map<List<NominaDTO>>(listaNomina);

            }
            catch 
            {

                throw;
            }
        }

        public async Task<NominaDTO> ObtenerNomina(int id)
        {
            try
            {
                var nomina = await _nominaRepository.Consultar(p => p.IdNomina == id);
                var nominaEncontrada = nomina.Include(nomina => nomina.IdPersonaNavigation).First(n => n.IdPersonaNavigation.IdRol == 2);
                return _mapper.Map<NominaDTO>( nominaEncontrada);
            }
            catch
            {

                throw;
            }
        }

        public async Task<NominaDTO> CrearNomina(NominaDTO nominaDTO)
        {
            try
            {
                var nuevaNomina = await _nominaRepository.CrearNomina(_mapper.Map<Nomina>(nominaDTO));
                if (nuevaNomina.IdNomina == 0)
                {
                    throw new TaskCanceledException("No se pudo crear");
                }
                var query = await _nominaRepository.Consultar(n => n.IdNomina == nuevaNomina.IdNomina);

                nuevaNomina = query.Include(nomina => nomina.IdPersonaNavigation).First();
                return _mapper.Map<NominaDTO>(nuevaNomina);
            }
            catch
            {

                throw;
            }
        }

        public async Task<bool> ActualizarNomina(NominaDTO nomina)
        {
            try
            {

                var nominaModelo = _mapper.Map<Nomina>(nomina);
                var nominaEncontrada = await _nominaRepository.ObtenerNomina(nominaModelo.IdNomina);
                if (nominaEncontrada == null)
                {
                    throw new TaskCanceledException("La Nomina no existe");
                }

                nominaEncontrada.IdPersona = nominaModelo.IdPersona;
                nominaEncontrada.Salario= nominaModelo.Salario;
                nominaEncontrada.FechaPago = nominaModelo.FechaPago;

                bool respuesta = await _nominaRepository.ActualizarNomina(nominaEncontrada);
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

        public async Task<bool> EliminarNomina(int id)
        {
            try
            {
                await _nominaRepository.EliminarNomina(id);
                return true;
            }
            catch
            {

                throw;
            }
        }

  
    }
}
