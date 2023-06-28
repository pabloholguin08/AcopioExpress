using AcopioExpress.BLL.Servicios;
using AcopioExpress.BLL.Servicios.Contratos;
using AcopioExpress.DAL.DBContext;
using AcopioExpress.DAL.Repositorios;
using AcopioExpress.DAL.Repositorios.Contrato;
using AcopioExpress.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcopioExpress.IOC
{
    public static class Dependencia
    {
        public static void InyectarDependencias(this IServiceCollection services, IConfiguration configuration)
        {
            // Inyeccion de Dependecia de conexion con la base de datos
            services.AddDbContext<AcopioExpressDbContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("cadenaSQL"));
            });

            // Inyeccion de Dependecia de automapper con todos los mapeos
            services.AddAutoMapper(typeof(AutoMapperProfile));

            // Inyeccion de Dependecia de Los repositorios
            services.AddScoped<IAcopioRepository, AcopioRepository>();
            services.AddScoped<IInsumoRepository, InsumoRepository>();
            services.AddScoped<IPersonaRepository, PersonaRepository>();
            services.AddScoped<INominaRepository,NominaRepository>();
            services.AddScoped<ILogginRepository, LogginRepository>();
            services.AddScoped<IProduccionRepository, ProduccionRepository>();
            services.AddScoped<ILiquidacionRepository, LiquidacionRepository>();
            services.AddScoped<IVentaInsumoRepository, VentaInsumoRepository>();
            services.AddScoped<IVentaProduccionRepository, VentaProduccionRepository>();
            services.AddScoped<IIngresosAcopioRepository, IngresosAcopioRepository>();
            services.AddScoped<IEgresosAcopioRepository, EgresosAcopioRepository>();


            // Inyeccion de Dependecia de Los Servicios
            services.AddScoped<IAcopioService, AcopioService>();
            services.AddScoped<IInsumoService, InsumoService>();
            services.AddScoped<IPersonaService, PersonaService>();
            services.AddScoped<INominaSevice,NominaService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IProduccionService, ProduccionService>();
            services.AddScoped<IventaInsumoService, VentaInsumoService>();
            services.AddScoped<IVentaProduccionService, VentaProduccionService>();
            services.AddScoped<ILiquidacionService, LiquidacionService>(); 
            services.AddScoped<IIngresosAcopioService, IngresosAcopioService>();   
            services.AddScoped<IEgresosAcopioService,EgresosAcopioService>();   

        }
    }
}
