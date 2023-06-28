using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcopioExpress.DTO
{
    public class LiquidacionProductorDTO
    {

        public int IdLiquidacion { get; set; }

        public DateTime FechaLiquidacion { get; set; }

        public long TotalProduccion { get; set; }

        public int TotalInsumos { get; set; }

        public long? TotalPagar { get; set; }

        public int IdPersona { get; set; }

        public string Nombres { get; set; } = null!;

        public string Apellidos { get; set; } = null!;


    }
}
