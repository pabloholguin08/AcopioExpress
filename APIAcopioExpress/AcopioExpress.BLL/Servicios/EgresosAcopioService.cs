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
    public class EgresosAcopioService :IEgresosAcopioService
    {
        private readonly IEgresosAcopioRepository _egresosAcopioRepository;
        private readonly INominaRepository _nominaRepository;
        private readonly ILiquidacionRepository _liquidacioRepository;        
        private IMapper _mapper;

        public EgresosAcopioService(IEgresosAcopioRepository egresosAcopioRepository,
            INominaRepository nominaRepository,
            ILiquidacionRepository liquidacioRepository,
            IMapper mapper)
        {
            _egresosAcopioRepository = egresosAcopioRepository;
            _nominaRepository = nominaRepository;
            _liquidacioRepository = liquidacioRepository;
            _mapper = mapper;
        }

        public async Task<List<EgresosAcopioDTO>> ListarEgresosAcopio()
        {
            try
            {
                var query = await _egresosAcopioRepository.Consultar();
                var lista = query.Include(acopio => acopio.IdAcopioNavigation);
                return _mapper.Map<List<EgresosAcopioDTO>>(lista);
            }
            catch 
            {

                throw;
            }
        }

        public async Task<List<EgresosAcopioDTO>> ListarEgresosAcopioFechas(string? fechaInicio, string? fechaFin)
        {
            DateTime fech_inicio = DateTime.Parse(fechaInicio);
            DateTime fech_fin = DateTime.Parse(fechaFin);
            try
            {
                var query = await _egresosAcopioRepository.Consultar(i => i.FechaInicailEgresos.Date >= fech_inicio.Date
                 && i.FechaFinalIngresosEgresos.Date <= fech_fin);
                var lista = query.Include(acopio => acopio.IdAcopioNavigation);
                return _mapper.Map<List<EgresosAcopioDTO>>(lista);
            }
            catch
            {

                throw;
            }
        }
        public async Task<EgresosAcopioDTO> GenerarEgresosAcopio(EgresosAcopioDTO egresosAcopioDTO, string? fechaInicio, string? fechaFin)
        {
            IQueryable<Nomina> queryNomina = await _nominaRepository.Consultar( );
            IQueryable<LiquidacionProductor> queryLiquidacion = await _liquidacioRepository.Consultar();
            DateTime fech_inicio = DateTime.Parse(fechaInicio);
            DateTime fech_fin = DateTime.Parse(fechaFin);

            var listaNominas = new List<Nomina>();
            var listaLiquidacion = new List<LiquidacionProductor>();

            var totalNominas = 0;
            var totalLiquidaciones = 0;

            try
            {
                listaNominas = await queryNomina.
                    Where(n => n.FechaPago.Date >= fech_inicio.Date &&
                    n.FechaPago.Date     <= fech_fin.Date ).ToListAsync();

                foreach (var item in listaNominas)
                {
                    totalNominas = (int)(item.Salario + totalNominas);
                }

                listaLiquidacion = await queryLiquidacion.
                    Where(n => n.FechaLiquidacion.Date >= fech_inicio.Date &&
                    n.FechaLiquidacion.Date <= fech_fin.Date).ToListAsync();

                foreach (var item in listaLiquidacion)
                {
                    totalLiquidaciones = (int)(item.TotalPagar + totalLiquidaciones);
                }

                egresosAcopioDTO.SumatoriaLiquidacion= totalLiquidaciones;
                egresosAcopioDTO.SumatoriaNominas= totalNominas;
                egresosAcopioDTO.FechaInicailEgresos = fech_inicio;
                egresosAcopioDTO.FechaFinalIngresosEgresos= fech_fin;
                egresosAcopioDTO.TotalEgresos = (egresosAcopioDTO.Arriendo + egresosAcopioDTO.SumatoriaNominas + egresosAcopioDTO.Servicios + egresosAcopioDTO.SumatoriaLiquidacion + egresosAcopioDTO.GastosExtras);
                

                await _egresosAcopioRepository.CrearEgresosAcopio(_mapper.Map<EgresosAcopio>(egresosAcopioDTO));
                return(egresosAcopioDTO);



            }
            catch
            {

                throw;
            }
        }
        public async Task<bool> EliminarEgresosAcopio(int id)
        {
            try
            {
                await _egresosAcopioRepository.EliminarEgresosAcopio(id);
                return true;    
            }
            catch
            {

                throw;
            }
        }
    }
}
