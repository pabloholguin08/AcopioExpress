using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using AcopioExpress.BLL.Servicios.Contratos;
using AcopioExpress.DAL.Repositorios.Contrato;
using AcopioExpress.DTO;
using AcopioExpress.Model;
using System.Globalization;
using Microsoft.EntityFrameworkCore;
using AcopioExpress.DAL.Repositorios;

namespace AcopioExpress.BLL.Servicios
{
    public class VentaInsumoService :IventaInsumoService
    {
        private readonly IVentaInsumoRepository _vetaInsumoRepository;
        private readonly IInsumoRepository _insumoRepository;
        private readonly IMapper _mapper;

        public VentaInsumoService(IVentaInsumoRepository vetaInsumoRepository, IInsumoRepository insumoRepository, IMapper mapper)
        {
            _vetaInsumoRepository = vetaInsumoRepository;
            _insumoRepository = insumoRepository;
            _mapper = mapper;
        }

        public async Task<VentaInsumoDTO> Registrar(VentaInsumoDTO modelo)
        {
            IQueryable<Insumo> query = await _insumoRepository.Consultar();
            var ListaResultado = new List<VentaProduccion>();
            try
            {
             
                var detalleVenta = modelo.DetalleVentaInsumos;

                if (detalleVenta == null)
                {
                    throw new ArgumentNullException("detalleVenta", "El objeto detalleVenta es nulo");
                }
                // Calcular el totalVenta para cada objeto en detalleVenta
                foreach (var detalle in detalleVenta)
                {
                    var insumo = await query.FirstOrDefaultAsync(v => v.IdInsumo == detalle.IdInsumo);
                    
         
                    if (insumo == null)
                    {   
                        throw new NullReferenceException("El objeto insumo es nulo ");
                    } 
                    detalle.Precio = insumo.ValorUnitarioVenta;
                    detalle.TotalVentaInsumo = detalle.Cantidad * detalle.Precio;
                }
                var ventaGenerada = await _vetaInsumoRepository.Registrar(_mapper.Map<VentaInsumo>(modelo));

                if (ventaGenerada.IdVentaInsumo == 0)
                {
                    throw new TaskCanceledException("No se pudo crear");
                }

     

                return _mapper.Map<VentaInsumoDTO>(ventaGenerada);

            }
            catch 
            {

                throw;
            }
        }
        public async Task<List<VentaInsumoDTO>> Historial( string? fechaInicio, string? fechaFin)
        {
            IQueryable<VentaInsumo> query = await _vetaInsumoRepository.Consultar();
            DateTime fech_inicio = DateTime.Parse(fechaInicio);
            DateTime fech_fin = DateTime.Parse(fechaFin);
           
            var ListaResultado = new List<VentaInsumo>();    
            try
            {
                    ListaResultado = await query.Where(v =>
                              v.FechaRegistro.Value >= fech_inicio.Date &&
                              v.FechaRegistro.Value <= fech_fin.Date
                              ).Include(persona => persona.IdPersonaNavigation)
                               .Include(tp => tp.IdTipoPagoNavigation)
                               .Include(dv => dv.DetalleVentaInsumos)
                              .ThenInclude(i => i.IdInsumoNavigation)
                              .Where(i => i.Estado ==1)
                              .ToListAsync();

            }
            catch
            {

                throw;
            }

            return _mapper.Map<List<VentaInsumoDTO>>(ListaResultado);
        }



        public async Task<List<ReporteDTO>> Reporte(string fechaInicio, string fechaFin)
        {
            IQueryable<DetalleVentaInsumo> query = await _vetaInsumoRepository.ConsultarDetalle();
            var ListaResultado = new List<DetalleVentaInsumo>();
            try
            {
                DateTime fech_inicio = DateTime.Parse(fechaInicio);
                DateTime fech_fin = DateTime.Parse(fechaFin);

                ListaResultado = await  query
                    .Include(i=> i.IdVentaInsumoNavigation)
                    .ThenInclude(vi => vi.IdTipoPagoNavigation)
                    .Include(i => i.IdInsumoNavigation)
                    .Include(i => i.IdVentaInsumoNavigation)
                    .Where(dv =>
                        dv.IdVentaInsumoNavigation.FechaRegistro.Value.Date >= fech_inicio.Date &&
                        dv.IdVentaInsumoNavigation.FechaRegistro.Value.Date <= fech_fin.Date
                    ).Where(i =>i.Estado ==1).ToListAsync();

            }
            catch
            {

                throw;
            }

            return _mapper.Map<List<ReporteDTO>>(ListaResultado);
        }

        public async Task<bool> EliminarVenta(int id)
        {
            try
            {
                await _vetaInsumoRepository.EliminarVenta(id);
                return true;
            }
            catch
            {

                throw;
            }
        }
    }
}
