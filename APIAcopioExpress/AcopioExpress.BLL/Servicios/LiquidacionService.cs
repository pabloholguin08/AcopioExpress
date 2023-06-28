using AcopioExpress.BLL.Servicios.Contratos;
using AcopioExpress.DAL.Repositorios;
using AcopioExpress.DAL.Repositorios.Contrato;
using AcopioExpress.DTO;
using AcopioExpress.Model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcopioExpress.BLL.Servicios
{
    public class LiquidacionService :ILiquidacionService
    {
        private readonly ILiquidacionRepository _liquidacionRepository;
        private readonly IProduccionRepository _produccionRepository;
        private readonly IVentaInsumoRepository _ventainsumoRepository;
        private readonly IMapper _mapper;

        public LiquidacionService(ILiquidacionRepository liquidacionRepository, 
            IProduccionRepository produccionRepository,
            IVentaInsumoRepository ventainsumoRepository, 
            IMapper mapper)
        {
            _liquidacionRepository = liquidacionRepository;
            _produccionRepository = produccionRepository;
            _ventainsumoRepository = ventainsumoRepository;
            _mapper = mapper;
        }

        public  async Task<List<LiquidacionProductorDTO>> ListarLiquidaciones()
        {
            try
            {
                var query = await _liquidacionRepository.Consultar();
                var lista = query.Include(nomina => nomina.IdPersonaNavigation);
                return _mapper.Map<List<LiquidacionProductorDTO>>(lista);
            }
            catch 
            {

                throw;
            }
          
        }

        public  async Task<LiquidacionProductorDTO> ObtenerLiquidacion(int id)
        {
            try
            {
                var query = await _liquidacionRepository.Consultar(p => p.IdLiquidacion == id);
                var liquidacionEncontrada = query.Include(nomina => nomina.IdPersonaNavigation).First();
                return _mapper.Map<LiquidacionProductorDTO>(liquidacionEncontrada);
            }
            catch 
            {

                throw;
            }

   
        }

        public async Task<LiquidacionProductorDTO> GenerarLiquidacion(int id , string? fechaInicio, string? fechaFin)
        {
            IQueryable<Produccion> queryProdu = await _produccionRepository.Consultar(p => p.IdPersona ==id);
            IQueryable<DetalleVentaInsumo> queryVenta = await _ventainsumoRepository.ConsultarDetalle();
            DateTime fech_inicio = DateTime.Parse(fechaInicio);
            DateTime fech_fin = DateTime.Parse(fechaFin);

            var ListaProduccion = new List<Produccion>();
            var ListaVentaInsumo = new List<DetalleVentaInsumo>();
            var totalProduccion= 0;
            var totalInsumos = 0;
            LiquidacionProductor nuevaLiquidacion = new LiquidacionProductor();
            
            try
            {
               ListaProduccion = await queryProdu.Where(v =>
                              v.DiaIngresoProducto.Date >= fech_inicio.Date &&
                              v.DiaIngresoProducto.Date <= fech_fin.Date
                              ).ToListAsync();
                foreach (var produccion in ListaProduccion)
                {
                    totalProduccion = (int)(produccion.ValorProducto + totalProduccion);
                }

                ListaVentaInsumo = await queryVenta
                    .Include(dv => dv.IdVentaInsumoNavigation)
                    .Where( v => v.IdVentaInsumoNavigation.FechaRegistro.Value >= fech_inicio.Date &&
                              v.IdVentaInsumoNavigation.FechaRegistro.Value <= fech_fin.Date)
                    .Where(p => p.IdVentaInsumoNavigation.IdPersona == id)
                    .ToListAsync();
                foreach (var venta in ListaVentaInsumo)
                {
                    totalInsumos = (int)(venta.TotalVentaInsumo + totalInsumos);
                }

                nuevaLiquidacion.TotalInsumos = totalInsumos;
                nuevaLiquidacion.TotalProduccion= totalProduccion;
                nuevaLiquidacion.IdPersona= id;
                nuevaLiquidacion.FechaLiquidacion = fech_fin;

                var respuestaLiquidacion = await _liquidacionRepository.CrearLiquidacion(nuevaLiquidacion);
                return _mapper.Map<LiquidacionProductorDTO>(respuestaLiquidacion);



            }
            catch 
            {

                throw;
            }

        }
        public async Task<bool> EliminarLiquidacion(int id)
        {
            try
            {
                await _liquidacionRepository.EliminarLiquidacion(id);
                return true;
            }
            catch 
            {

                throw;
            }
        }


    }
}
