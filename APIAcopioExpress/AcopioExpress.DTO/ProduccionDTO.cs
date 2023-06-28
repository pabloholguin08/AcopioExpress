using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcopioExpress.DTO
{
    public class ProduccionDTO
    {
        public int IdProduccion { get; set; }

        public DateTime DiaIngresoProducto { get; set; }

        public int Cantidad { get; set; }

        public int PrecioProducto { get; set; }

        public string Observaciones { get; set; } = null!;

        public int? ValorProducto { get; set; }

        public int IdPersona { get; set; }
        public string Nombres { get; set; } = null!;

        public string Apellidos { get; set; } = null!;

    }
}
