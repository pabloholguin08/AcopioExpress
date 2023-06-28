
using AcopioExpress.BLL.Servicios.Contratos;
using AcopioExpress.DAL.Repositorios.Contrato;
using AcopioExpress.DTO;
using AcopioExpress.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AcopioExpress.BLL.Servicios
{
    public class InsumoService:IInsumoService
    {
        private readonly IInsumoRepository _insumoRepository;
        private readonly IMapper _mapper;

        public InsumoService(IInsumoRepository insumoRepository, IMapper mapper)
        {
            _insumoRepository = insumoRepository;
            _mapper = mapper;
        }

        public async Task<List<InsumoDTO>> ListarInsumo()
        {
            try
            {
                var insumos = await _insumoRepository.ListarInsumo();
                return _mapper.Map<List<InsumoDTO>>(insumos);
            }
            catch 
            {

                throw;
            }
        }
        public async Task<InsumoDTO> CrearInsumo(InsumoDTO insumoDto)
        {
            try
            {
                insumoDto.GananciaUnitaria = insumoDto.ValorUnitarioCompra - insumoDto.ValorUnitarioVenta;             
                var nuevoInsumo= await _insumoRepository.CrearInsumo(_mapper.Map<Insumo>(insumoDto));
                return _mapper.Map<InsumoDTO>( nuevoInsumo);

            }
            catch
            {

                throw;
            }
        }

        public async Task<bool> ActualizarInsumo(InsumoDTO insumoDto)
        {
            try
            {
                var insumoModelo = _mapper.Map<Insumo>(insumoDto);
                var insumoEncontrado = await _insumoRepository.ObtenerInsumo(insumoModelo.IdInsumo);

                if (insumoEncontrado == null)
                {
                    throw new TaskCanceledException("El Insumo no existe");
                }

                insumoEncontrado.NombreInsumo = insumoModelo.NombreInsumo;
                insumoEncontrado.Descripcion = insumoModelo.Descripcion;
                insumoEncontrado.ValorUnitarioVenta = insumoModelo.ValorUnitarioVenta;
                insumoEncontrado.Stock = insumoModelo.Stock;
                insumoEncontrado.ValorUnitarioCompra = insumoModelo.ValorUnitarioCompra;
                insumoEncontrado.GananciaUnitaria = insumoModelo.ValorUnitarioVenta- insumoModelo.ValorUnitarioCompra;

                bool respuesta = await _insumoRepository.ActualizarInsumo(insumoEncontrado);
                if (!respuesta)
                {
                    throw new TaskCanceledException("El Insumo no se pudo actualizar");
                }
                return respuesta;
            }
            catch
            {

                throw;
            }

        }
        public async Task<InsumoDTO> ObtenerInsumo(int id)
        {
            try
            {
                var insumo = await _insumoRepository.ObtenerInsumo(id);
                if (insumo == null)
                {
                    throw new TaskCanceledException("El Insumo no existe");
                }

                return _mapper.Map<InsumoDTO>(insumo);
            }
            catch
            {

                throw;
            }
        }



        public async Task<bool> EliminarInsumo(int id)
        {
            try
            {
                var insumoEliminado = await _insumoRepository.EliminarInsumo(id);
                return true;
            }
            catch
            {

                throw;
            }
        }

        public async Task<List<InsumoDTO>> ListarInsumoEliminados()
        {
            try
            {
                var insumos = await _insumoRepository.ListarInsumoEliminados();
                return _mapper.Map<List<InsumoDTO>>(insumos);
            }
            catch
            {

                throw;
            }
        }

       

        public  async Task<bool> RecuperarInsumo(int id)
        {
            try
            {
                var insumoEliminado = await _insumoRepository.RecuperarInsumo(id);
                return true;
            }
            catch
            {

                throw;
            }
        }
    }
}
