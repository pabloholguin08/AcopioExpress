using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcopioExpress.DTO
{
    public class VentaProduccionDTO
    {

        public int IdVentaProduccion { get; set; }

        public int IdAcopio { get; set; }
        public string NombreAcopi { get; set; } = null!;//Acopio

        public DateTime FechaVenta { get; set; }

        public int Cantidad { get; set; }

        public decimal? Precio { get; set; }

        public decimal? TotalVentaProduccion { get; set; }

        public string? Observaciones { get; set; }




    }
}
