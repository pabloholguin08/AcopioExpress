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
    public class IngresosAcopioService : IIngresosAcopioService
    {

        private readonly IIngresosAcopioRepository _ingresosAcopioRepository;
        private readonly IVentaInsumoRepository _ventainsumoRepository;
        private readonly IProduccionRepository _produccionRepository;
        private readonly IVentaProduccionRepository _ventaProduccionRepository;
        private readonly IMapper _mapper;

        public IngresosAcopioService(IIngresosAcopioRepository ingresosAcopioRepository, 
            IVentaInsumoRepository ventainsumoRepository,
            IProduccionRepository produccionRepository, 
            IVentaProduccionRepository ventaProduccionRepository,
            IMapper mapper)
        {
            _ingresosAcopioRepository = ingresosAcopioRepository;
            _ventainsumoRepository = ventainsumoRepository;
            _produccionRepository = produccionRepository;
            _ventaProduccionRepository = ventaProduccionRepository;
            _mapper = mapper;
        }


        public async Task<List<IngresosAcopioDTO>> ListarIngresosAcopio()
        {
            try
            {
                var query = await _ingresosAcopioRepository.Consultar();
                var lista = query.Include(acopio => acopio.IdAcopioNavigation);
                return _mapper.Map<List<IngresosAcopioDTO>>(lista);
            }
            catch 
            {

                throw;
            }
        }

        public async Task<IngresosAcopioDTO> ObtenerIngresosAcopio(int id)
        {
            try
            {
                var query = await _ingresosAcopioRepository.Consultar( i => i.IdIngresosAcopio == id);
                var ingreso = query.Include(acopio => acopio.IdAcopioNavigation);
                return _mapper.Map<IngresosAcopioDTO>(ingreso);
            }
            catch
            {

                throw;
            }
        }
        public async Task<IngresosAcopioDTO> GenerarIngresosAcopio( string? fechaInicio, string? fechaFin)
        {
            IQueryable<DetalleVentaInsumo> queryInsumo = await _ventainsumoRepository.ConsultarDetalle();
            IQueryable<VentaProduccion> queryProduccion = await _ventaProduccionRepository.Consultar();
            DateTime fech_inicio = DateTime.Parse(fechaInicio);
            DateTime fech_fin = DateTime.Parse(fechaFin);

            var listaVentaProduccion = new List<VentaProduccion>();
            var listaVentaInsumo = new List<DetalleVentaInsumo>();
            var totalVentaProduccion = 0;
            var totalVentaInsumos = 0;

            IngresosAcopio nuevoIngreso = new IngresosAcopio();
            try
            {
                listaVentaInsumo = await queryInsumo
                    .Include(dv => dv.IdVentaInsumoNavigation)
                    .Where(v => v.IdVentaInsumoNavigation.FechaRegistro.Value >= fech_inicio.Date &&
                              v.IdVentaInsumoNavigation.FechaRegistro.Value <= fech_fin.Date)
                    .ToListAsync();
                foreach (var item in listaVentaInsumo)
                {
                    totalVentaInsumos = (int)(item.TotalVentaInsumo + totalVentaInsumos);
                }

                listaVentaProduccion = await queryProduccion
                    .Where(v => v.FechaVenta.Date >= fech_inicio.Date &&
                              v.FechaVenta.Date <= fech_fin.Date).ToListAsync();

                foreach (var item in listaVentaProduccion)
                {
                    totalVentaProduccion = (int)(item.TotalVentaProduccion + totalVentaProduccion);
                }

                nuevoIngreso.TotalGananciaInsumos = totalVentaInsumos;
                nuevoIngreso.TotalGananciaProduccion = totalVentaProduccion;
                nuevoIngreso.IdAcopio = 1;
                nuevoIngreso.FechaInicailIngresos = fech_inicio;
                nuevoIngreso.FechaFinalIngresosLiquidacion= fech_fin;
                nuevoIngreso.TotalIngresos = totalVentaInsumos + totalVentaProduccion;

                var respuestaIngreso = await _ingresosAcopioRepository.CrearIngresosAcopio(nuevoIngreso);
                return _mapper.Map<IngresosAcopioDTO>(respuestaIngreso);

            }
            catch
            { 

                throw;
            }
        }
        public async Task<bool> EliminarIngresosAcopio(int id)
        {
            try
            {
                await _ingresosAcopioRepository.EliminarIngresosAcopio(id);
                return true;
            }
            catch
            {

                throw;
            }
        }

        public async Task<List<IngresosAcopioDTO>> ListarIngresosAcopioFechas(string? fechaInicio, string? fechaFin)
        {
            DateTime fech_inicio = DateTime.Parse(fechaInicio);
            DateTime fecha_fin = DateTime.Parse(fechaFin);

            try
            {
                var query = await _ingresosAcopioRepository.Consultar(i => i.FechaInicailIngresos.Date >= fech_inicio.Date 
                                                                        && i.FechaFinalIngresosLiquidacion.Date<=fecha_fin);
                var lista = query.Include(acopio => acopio.IdAcopioNavigation);
                return _mapper.Map<List<IngresosAcopioDTO>>(lista);
            }
            catch 
            {

                throw;
            }
        }
    }
}
