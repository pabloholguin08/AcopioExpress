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
    public class VentaProduccionService : IVentaProduccionService
    {
        private readonly IVentaProduccionRepository _ventaProduccionRepo;
        private readonly IMapper _mapper;
         
        public VentaProduccionService(IVentaProduccionRepository ventaProduccionRepo, IMapper mapper)
        {
            _ventaProduccionRepo = ventaProduccionRepo;
            _mapper = mapper;
        }
        public async Task<List<VentaProduccionDTO>> ListarProduccion()
        {
            try
            {
                var query = await _ventaProduccionRepo.Consultar(p => p.Estado == 1);
                var lista = query.Include(acopio => acopio.IdAcopioNavigation);
                return _mapper.Map<List<VentaProduccionDTO>>(lista).ToList();
            }
            catch 
            {

                throw;
            }
        }

        public async Task<VentaProduccionDTO> CrearProduccion(VentaProduccionDTO produccionDTO)
        {
            try
            {
                var nuevaProduccion = await _ventaProduccionRepo.Registrar(_mapper.Map<VentaProduccion>(produccionDTO));
                if (nuevaProduccion.IdVentaProduccion == 0)
                {
                    throw new TaskCanceledException("No se pudo crear");
                }
                var query = await _ventaProduccionRepo.Consultar(p => p.IdVentaProduccion == nuevaProduccion.IdVentaProduccion);

                nuevaProduccion = query.Include(a => a.IdAcopioNavigation).First();
                return _mapper.Map<VentaProduccionDTO>(nuevaProduccion);
            }
            catch
            {

                throw;
            }
        }

        public async Task<VentaProduccionDTO> ObtenerProduccion(int id)
        {
            try
            {
                var Vproduccion = await _ventaProduccionRepo.Consultar(p => p.IdVentaProduccion == id);
                var VproduccionEncontrada = Vproduccion.Include(ap => ap.IdAcopioNavigation).First(p => p.Estado == 1);


                if (VproduccionEncontrada == null)
                {
                    throw new TaskCanceledException("No Existe la Venta");
                }
                return _mapper.Map<VentaProduccionDTO>(VproduccionEncontrada);
            }
            catch
            {

                throw;
            }
        }
        public async Task<bool> ActualizarProduccion(VentaProduccionDTO produccionDTO)
        {
            try
            {
                var Modelo = _mapper.Map<VentaProduccion>(produccionDTO);
                var VproduccionEncontrada = await _ventaProduccionRepo.ObtenerVenta(Modelo.IdVentaProduccion);
                if (VproduccionEncontrada == null)
                {
                    throw new TaskCanceledException("La persona no existe");
                }

                VproduccionEncontrada.IdAcopio = Modelo.IdAcopio;
                VproduccionEncontrada.FechaVenta = Modelo.FechaVenta;
                VproduccionEncontrada.Cantidad = Modelo.Cantidad;
                VproduccionEncontrada.Precio = Modelo.Precio;
                VproduccionEncontrada.TotalVentaProduccion = Modelo.TotalVentaProduccion;
                VproduccionEncontrada.Observaciones = Modelo.Observaciones;


                bool respuesta = await _ventaProduccionRepo.ActualizarVenta(VproduccionEncontrada);
                if (!respuesta)
                {
                    throw new TaskCanceledException("La Venta no existe");
                }

                return respuesta;
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
                var ventaProduccionEliminada = await _ventaProduccionRepo.EliminarVenta(id);
                return true;
            }
            catch
            {

                throw;
            }
        }

   

     
        public async Task<List<VentaProduccionDTO>> ListarProduccionEliminados()
        {
            try
            {
                var query = await _ventaProduccionRepo.Consultar(p => p.Estado == 0);
                var lista = query.Include(acopio => acopio.IdAcopioNavigation);
                return _mapper.Map<List<VentaProduccionDTO>>(lista).ToList();
            }
            catch
            {

                throw;
            }
        }

        public async Task<List<VentaProduccionDTO>> ListarPorFecha(string? fechaInicio, string? fechaFin)
        {

            IQueryable<VentaProduccion> query = await _ventaProduccionRepo.Consultar();
            DateTime fech_inicio = DateTime.Parse(fechaInicio);
            DateTime fech_fin = DateTime.Parse(fechaFin);
            var ListaResultado = new List<VentaProduccion>();
            try
            {
                ListaResultado = await query.Where(v =>
                             v.FechaVenta >= fech_inicio.Date &&
                             v.FechaVenta <= fech_fin.Date
                             ).Include(A => A.IdAcopioNavigation)
                             .ToListAsync();
            }
            catch
            {

                throw;
            }
            return _mapper.Map<List<VentaProduccionDTO>>(ListaResultado);
        }
        public async Task<bool> RecuperarProduccion(int id)
        {
            try
            {
                var personaEliminado = await _ventaProduccionRepo.RecuperarVenta(id);
                return true;
            }
            catch
            {

                throw;
            }
        }
    }
}
