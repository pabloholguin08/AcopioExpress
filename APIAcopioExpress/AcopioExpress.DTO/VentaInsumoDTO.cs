using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcopioExpress.DTO
{
    public class VentaInsumoDTO
    {
        public int IdVentaInsumo { get; set; }

        public int IdPersona { get; set; }
        public string Nombres { get; set; } = null!;

        public string Apellidos { get; set; } = null!;

        public int? IdTipoPago { get; set; }
        public string NombreTipoProducto { get; set; } = null!;
        public virtual ICollection<DetalleVentaInsumoDTO> DetalleVentaInsumos { get; set; }
        public string Observacion { get; set; } = null!;

        public DateTime? FechaRegistro { get; set; }
    }
}
