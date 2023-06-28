using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcopioExpress.DTO
{
    public class DetalleVentaProduccionDTO
    {
        public int IdDetalleVentaProduccion { get; set; }

        public int IdProduccion { get; set; }

        public int Cantidad { get; set; }

        public decimal? Precio { get; set; }

        public decimal? TotalVentaProduccion { get; set; }

    }
}
