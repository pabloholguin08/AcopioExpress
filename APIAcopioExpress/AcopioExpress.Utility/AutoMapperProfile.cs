using AcopioExpress.DTO;
using AcopioExpress.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcopioExpress.Utility
{
    public class AutoMapperProfile:Profile
    {

        //Relaciones entre las clases y los DTOS                                                                                                           
        public AutoMapperProfile()
        {

                  
        #region Acopio
            CreateMap<Acopio, AcopioDTO>().ReverseMap();
            #endregion Acopio

         #region Insumo
            CreateMap<Insumo, InsumoDTO>().ReverseMap();
         #endregion Insumo

         #region Persona
            CreateMap<Persona, PersonaDTO>()
                    .ForMember(destino =>
                    destino.NombreAcopi,
                    opciones => opciones.MapFrom(origen => origen.IdAcopioNavigation.NombreAcopi)
                    )
                    .ForMember(destino =>
                    destino.TipoProducto1,
                    opciones => opciones.MapFrom(origen => origen.IdTipoProductoNavigation.TipoProducto1)
                    )
                    .ForMember(destino =>
                    destino.NombreRol,
                    opciones => opciones.MapFrom(origen => origen.IdRolNavigation.NombreRol)
                    );

            CreateMap<PersonaDTO, Persona>()
                .ForMember(destino =>
                destino.IdAcopioNavigation,
                opciones => opciones.Ignore()
                )
                .ForMember(destino =>
                destino.IdTipoProductoNavigation,
                opciones => opciones.Ignore()
                )
                .ForMember(destino =>
                destino.IdRolNavigation,
                opciones => opciones.Ignore()
                );
            #endregion Persona

         #region Nomina
            CreateMap<Nomina, NominaDTO>()
                .ForMember(destino =>
                destino.Nombres,
                opciones => opciones.MapFrom(origen => origen.IdPersonaNavigation.Nombres)
                )
                .ForMember(destino =>
                destino.Apellidos,
                opciones => opciones.MapFrom(origen => origen.IdPersonaNavigation.Apellidos)
                );

            CreateMap<NominaDTO, Nomina>()
                .ForMember(destino =>
                destino.IdPersonaNavigation,
                opciones => opciones.Ignore()
                );
            #endregion Nomina

         #region Login
            CreateMap<Login, LoginDTO>()
                .ForMember(destino =>
                    destino.NombreAcopi,
                    opciones => opciones.MapFrom(origen => origen.IdAcopioNavigation.NombreAcopi)
                    )
                .ForMember(destino =>
                destino.NombreRol,
                opciones => opciones.MapFrom(origen => origen.IdRolNavigation.NombreRol));

            CreateMap<LoginDTO, Login>()
           .ForMember(destino =>
               destino.IdRolNavigation,
               opciones => opciones.Ignore()
               )
           .ForMember(destino =>
           destino.IdAcopioNavigation,
           opciones => opciones.Ignore());
            #endregion Login

            #region Produccion
            CreateMap<Produccion, ProduccionDTO>()
                .ForMember(destino =>
                destino.Nombres,
                opciones => opciones.MapFrom(origen => origen.IdPersonaNavigation.Nombres)
                )
                .ForMember(destino =>
                destino.Apellidos,
                opciones => opciones.MapFrom(origen => origen.IdPersonaNavigation.Apellidos)
                );

            CreateMap<ProduccionDTO, Produccion>()
                .ForMember(destino =>
                destino.IdPersonaNavigation,
                opciones => opciones.Ignore()
                );
            #endregion Produccion

         #region LiquidacionProducto
            CreateMap<LiquidacionProductor, LiquidacionProductorDTO>()
                .ForMember(destino =>
                destino.Nombres,
                opciones => opciones.MapFrom(origen => origen.IdPersonaNavigation.Nombres)
                )
                .ForMember(destino =>
                destino.Apellidos,
                opciones => opciones.MapFrom(origen => origen.IdPersonaNavigation.Apellidos)
                );

            CreateMap<LiquidacionProductorDTO, LiquidacionProductor>()
                .ForMember(destino =>
                destino.IdPersonaNavigation,
                opciones => opciones.Ignore()
                );
            #endregion Produccion


         #region DetalleVentaInsumo
            CreateMap<DetalleVentaInsumo, DetalleVentaInsumoDTO>()
                    .ForMember(destino =>
                    destino.NombreInsumo,
                    opciones => opciones.MapFrom(origen => origen.IdInsumoNavigation.NombreInsumo));
    

            CreateMap<DetalleVentaInsumoDTO, DetalleVentaInsumo>()
            .ForMember(destino =>
            destino.IdVentaInsumoNavigation,
            opciones => opciones.Ignore());
            #endregion DetalleVentaInsumo

         #region VentaInsumo
            CreateMap<VentaInsumo, VentaInsumoDTO>()
                    .ForMember(destino =>
                    destino.Nombres,
                    opciones => opciones.MapFrom(origen => origen.IdPersonaNavigation.Nombres)
                    )
                    .ForMember(destino =>
                    destino.Apellidos,
                    opciones => opciones.MapFrom(origen => origen.IdPersonaNavigation.Apellidos)
                    )
                    .ForMember(destino =>
                    destino.NombreTipoProducto,
                    opciones => opciones.MapFrom(origen => origen.IdTipoPagoNavigation.NombreTipoProducto)
                    ) ;

            CreateMap<VentaInsumoDTO, VentaInsumo>()
            .ForMember(destino =>
            destino.IdPersonaNavigation,
            opciones => opciones.Ignore())
            .ForMember(destino =>
            destino.IdTipoPagoNavigation,
            opciones => opciones.Ignore());
            #endregion VentaInsumo


         #region ReporteDTO
            CreateMap<DetalleVentaInsumo, ReporteDTO>()
                .ForMember(destino =>
                    destino.NumeroDocumento,
                    opciones => opciones.MapFrom(origen => Convert.ToString(origen.IdVentaInsumo))
                    )
                    .ForMember(destino =>
                    destino.FechaRegistro,
                    opciones => opciones.MapFrom(origen => origen.IdVentaInsumoNavigation.FechaRegistro.Value.ToString("dd/MM/yyyy"))
                    )
                    .ForMember(destino =>
                    destino.TipoPago,
                    opciones => opciones.MapFrom(origen => origen.IdVentaInsumoNavigation.IdTipoPagoNavigation.NombreTipoProducto)
                    )
                    .ForMember(destino =>
                    destino.TotalVenta,
                    opciones => opciones.MapFrom(origen => Convert.ToString(origen.TotalVentaInsumo))
                    )
                       .ForMember(destino =>
                    destino.Insumo,
                    opciones => opciones.MapFrom(origen => origen.IdInsumoNavigation.NombreInsumo)
                    )
                       .ForMember(destino =>
                    destino.Precio,
                    opciones => opciones.MapFrom(origen => Convert.ToString(origen.IdInsumoNavigation.ValorUnitarioVenta))
                    )
                         .ForMember(destino =>
                    destino.Cantidad,
                    opciones => opciones.MapFrom(origen => Convert.ToString(origen.Cantidad))
                    )
                    ;

            #endregion ReporteDTO

         #region VentaProduccion
            CreateMap<VentaProduccion, VentaProduccionDTO>()
                    .ForMember(destino =>
                    destino.NombreAcopi,
                    opciones => opciones.MapFrom(origen => origen.IdAcopioNavigation.NombreAcopi)
                    );

            CreateMap<VentaProduccionDTO, VentaProduccion>()
            .ForMember(destino =>
            destino.IdAcopioNavigation,
            opciones => opciones.Ignore());

            #endregion VentaProduccion

         #region EgresosAcopio
            CreateMap<EgresosAcopio, EgresosAcopioDTO>()
                    .ForMember(destino =>
                    destino.NombreAcopi,
                    opciones => opciones.MapFrom(origen => origen.IdAcopioNavigation.NombreAcopi)
                    );

            CreateMap<EgresosAcopioDTO, EgresosAcopio>()
            .ForMember(destino =>
            destino.IdAcopioNavigation,
            opciones => opciones.Ignore());

            #endregion EgresosAcopio

         #region IngresosAcopio
            CreateMap<IngresosAcopio, IngresosAcopioDTO>()
                    .ForMember(destino =>
                    destino.NombreAcopi,
                    opciones => opciones.MapFrom(origen => origen.IdAcopioNavigation.NombreAcopi)
                    );

            CreateMap<IngresosAcopioDTO, IngresosAcopio>()
            .ForMember(destino =>
            destino.IdAcopioNavigation,
            opciones => opciones.Ignore());

            #endregion IngresosAcopio

         #region ReporteAcopio
            CreateMap<EgresosAcopio, ReporteAcopioDTO>()
            .ForMember(destino =>
          destino.TotalEgresos,
          opciones => opciones.MapFrom(origen => origen.TotalEgresos)
          );
            CreateMap<IngresosAcopio, ReporteAcopioDTO>()
            .ForMember(destino =>
          destino.TotalIngresos,
          opciones => opciones.MapFrom(origen => origen.TotalIngresos)
          );
            #endregion ReporteAcopio

        }
    }
}
