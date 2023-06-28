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
    public class AcopioService:IAcopioService
    {

        private readonly IAcopioRepository _acopioRepository;
        private readonly IEgresosAcopioRepository _egresosAcopioRepository;
        private readonly IIngresosAcopioRepository _ingresosAcopioRepository;
        private readonly IMapper _mapper;

        public AcopioService(IAcopioRepository acopioRepository, 
            IEgresosAcopioRepository egresosAcopioRepository,
            IIngresosAcopioRepository ingresosAcopioRepository, 
            IMapper mapper)
        {
            _acopioRepository = acopioRepository;
            _egresosAcopioRepository = egresosAcopioRepository;
            _ingresosAcopioRepository = ingresosAcopioRepository;
            _mapper = mapper;
        }

        public async Task<List<AcopioDTO>> ListarAcopios()
        {
            try
            {
                var query = await _acopioRepository.Consultar(q => q.Estado ==1);
 
                return _mapper.Map<List<AcopioDTO>>(query);
            }
            catch
            {

                throw;
            }
        
        }

        public async Task<AcopioDTO> CrearAcopio(AcopioDTO modelo)
        {
            try
            {
                var nuevoAcopio = await _acopioRepository.CrearAcopio(_mapper.Map<Acopio>(modelo));
                if (nuevoAcopio.IdAcopio == 0)
                {
                    throw new TaskCanceledException("No se pudo crear");
                }
                return _mapper.Map<AcopioDTO>(nuevoAcopio);
            }
            catch
            {

                throw;
            }
          
        }

        public async Task<AcopioDTO> ObtenerAcopio(int id)
        {

            try
            {
                var acopio = await _acopioRepository.ObtenerAcopio(id);
                if (acopio == null)
                {
                    throw new TaskCanceledException("No Existe el Acopio");
                }
                return _mapper.Map<AcopioDTO>(acopio);
            }
            catch
            {

                throw;
            }
           

        }



        public async Task<bool> EliminarAcopio(int id)
        {

            try
            {
                var acopioEliminado = await _acopioRepository.EliminarAcopio(id);
                return true;
            }
            catch
            {

                throw;
            }
   
        }


        public async Task<bool> ActualizarAcopio(AcopioDTO acopiodto)
        {
            try
            {
                var acopioModelo = _mapper.Map<Acopio>(acopiodto);
                var acopioEncontrado = await _acopioRepository.ObtenerAcopio(acopioModelo.IdAcopio);

                if (acopioEncontrado == null)
                {
                    throw new TaskCanceledException("El Acopio no existe");
                }

                acopioEncontrado.NombreAcopi = acopioModelo.NombreAcopi;
                acopioEncontrado.Ubicacion = acopioModelo.Ubicacion;
                acopioEncontrado.CantidadEmpleados = acopioModelo.CantidadEmpleados;

                bool respuesta = await _acopioRepository.ActualizarAcopio(acopioEncontrado);

                if (!respuesta)
                {
                    throw new TaskCanceledException("El acopio no se pudo editar");
                }

                return respuesta;
            }
            catch
            {

                throw;
            }
        }


        public async Task<List<AcopioDTO>> ListarAcopioEliminados()
        {
            try
            {
                var query = await _acopioRepository.Consultar(q => q.Estado == 0);
              
                return _mapper.Map<List<AcopioDTO>>(query);
            }
            catch
            {

                throw;
            }
        }

        public async Task<bool> RecuperarAcopio(int id)
        {
            try
            {
                var acopioEliminado = await _acopioRepository.RecuperarAcopio(id);
                return true;
            }
            catch
            {

                throw;
            }
        }

        public async Task<ReporteAcopioDTO> GenerarReporte(string? fechaInicio, string? fechaFin)
        {
            IQueryable<EgresosAcopio> queryEgresos = await _egresosAcopioRepository.Consultar();
            IQueryable<IngresosAcopio> queryIngresos = await _ingresosAcopioRepository.Consultar();
            DateTime fech_inicio = DateTime.Parse(fechaInicio);
            DateTime fech_fin = DateTime.Parse(fechaFin);

            var listaEgresos = new List<EgresosAcopio>();
            var listaIngresos = new List<IngresosAcopio>();
            var totalEgresos = 0;
            var totalIngresos = 0;

            ReporteAcopioDTO nuevoIngreso = new ReporteAcopioDTO();
            try
            {
                listaEgresos = await queryEgresos
                    .Where(v => v.FechaInicailEgresos.Date >= fech_inicio.Date &&
                              v.FechaInicailEgresos.Date <= fech_fin.Date)
                    .ToListAsync();
                foreach (var item in listaEgresos)
                {
                    totalEgresos = (int)(item.TotalEgresos + totalEgresos);
                }

                
                listaIngresos = await queryIngresos
                    .Where(v => v.FechaInicailIngresos.Date >= fech_inicio.Date &&
                              v.FechaInicailIngresos.Date <= fech_fin.Date)
                    .ToListAsync();
                foreach (var item in listaIngresos)
                {
                    totalIngresos = (int)( item.TotalIngresos+ totalIngresos);
                }

                nuevoIngreso.TotalEgresos = totalEgresos;   
                nuevoIngreso.TotalIngresos= totalIngresos;
                nuevoIngreso.GananTotal = totalIngresos - totalEgresos;

                return nuevoIngreso;

            }
            catch 
            {

                throw;
            }
        }
    }
}
