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
    public class ProduccionService : IProduccionService
    {
        private readonly IProduccionRepository _produccionRepository;
        private readonly IMapper _mapper;

        public ProduccionService(IProduccionRepository produccionRepository, IMapper mapper)
        {
            _produccionRepository = produccionRepository;
            _mapper = mapper;
        }


        public async Task<List<ProduccionDTO>> ListarProduccion()
        {
            try
            {
                var query = await _produccionRepository.Consultar(p => p.Estado == 1);
                var lista = query.Include(acopio => acopio.IdPersonaNavigation);
                return _mapper.Map<List<ProduccionDTO>>(lista).ToList();
            }
            catch
            {

                throw;
            }
        }

        public async Task<ProduccionDTO> CrearProduccion(ProduccionDTO produccionDTO)
        {
            try
            {
                var nuevaProduccion = await _produccionRepository.CrearProduccion(_mapper.Map<Produccion>(produccionDTO));
                if (nuevaProduccion.IdProduccion == 0)
                {
                    throw new TaskCanceledException("No se pudo crear");
                }
                var query = await _produccionRepository.Consultar(p => p.IdProduccion == nuevaProduccion.IdProduccion);

                nuevaProduccion = query.Include(p => p.IdPersonaNavigation).First();
                return _mapper.Map<ProduccionDTO>(nuevaProduccion);
            }
            catch
            {

                throw;
            }
        }

        public async Task<ProduccionDTO> ObtenerProduccion(int id)
        {
            try
            {
                var produccion = await _produccionRepository.Consultar(p => p.IdProduccion == id);
                var produccionEncontrada = produccion.Include(ap => ap.IdPersonaNavigation).First( p => p.Estado ==1);


                if (produccionEncontrada == null)
                {
                    throw new TaskCanceledException("No Existe la persona");
                }
                return _mapper.Map<ProduccionDTO>(produccionEncontrada);
            }
            catch
            {

                throw;
            }
        }


        public async Task<bool> EliminarProduccion(int id)
        {
            try
            {
                var personaEliminada = await _produccionRepository.EliminarProduccion(id);
                return true;
            }
            catch
            {

                throw;
            }
        }

        public async Task<bool> ActualizarProduccion(ProduccionDTO produccionDTO)
        {
            try
            {
                var Modelo = _mapper.Map<Produccion>(produccionDTO);
                var produccionEncontrada = await _produccionRepository.ObtenerProduccion(Modelo.IdProduccion);
                if (produccionEncontrada == null)
                {
                    throw new TaskCanceledException("La persona no existe");
                }

                produccionEncontrada.DiaIngresoProducto = Modelo.DiaIngresoProducto;
                produccionEncontrada.Cantidad = Modelo.Cantidad;
                produccionEncontrada.PrecioProducto = Modelo.PrecioProducto;
                produccionEncontrada.Observaciones = Modelo.Observaciones;
                produccionEncontrada.ValorProducto = Modelo.ValorProducto;
                produccionEncontrada.IdPersona = Modelo.IdPersona;


                bool respuesta = await _produccionRepository.ActualizarProduccion(produccionEncontrada);
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




        public  async Task<List<ProduccionDTO>> ListarProduccionEliminados()
        {
            try
            {
                var query = await _produccionRepository.Consultar(p => p.Estado == 0);
                var lista = query.Include(acopio => acopio.IdPersonaNavigation);
                return _mapper.Map<List<ProduccionDTO>>(lista).ToList();
            }
            catch
            {

                throw;
            }
        }

    

        public async Task<bool> RecuperarProduccion(int id)
        {

            try
            {
                var personaEliminado = await _produccionRepository.RecuperarProduccion(id);
                return true;
            }
            catch
            {

                throw;
            }
        }

        public async Task<List<ProduccionDTO>> ListarProduccionFecha(string? fechaInicio, string? fechaFin)
        {
            DateTime fech_inicio = DateTime.Parse(fechaInicio);
            DateTime fech_fin = DateTime.Parse(fechaFin);

            try
            {
                var query = await _produccionRepository.Consultar(p => p.Estado == 1);
                var lista = query.Include(persona => persona.IdPersonaNavigation).Where( v =>
                             v.DiaIngresoProducto >= fech_inicio.Date &&
                             v.DiaIngresoProducto <= fech_fin.Date
                             ).ToList();
                return _mapper.Map<List<ProduccionDTO>>(lista).ToList();
            }
            catch
            {

                throw;
            }
        }
    }
}
