using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcopioExpress.DTO
{
    public class IngresosAcopioDTO
    {
        public int IdIngresosAcopio { get; set; }

        public int IdAcopio { get; set; }
        public string NombreAcopi { get; set; } = null!;

        public int TotalGananciaInsumos { get; set; }

        public int TotalGananciaProduccion { get; set; }

        public DateTime FechaInicailIngresos { get; set; }

        public DateTime FechaFinalIngresosLiquidacion { get; set; }
        public long TotalIngresos { get; set; }

    }
}
