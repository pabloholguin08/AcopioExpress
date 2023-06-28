using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcopioExpress.DTO
{
    public class EgresosAcopioDTO
    {
        public int IdEgresosAcopio { get; set; }

        public int IdAcopio { get; set; }
        public string NombreAcopi { get; set; } = null!;

        public long Arriendo { get; set; }

        public int SumatoriaNominas { get; set; }

        public int Servicios { get; set; }

        public int SumatoriaLiquidacion { get; set; }

        public int GastosExtras { get; set; }

        public long TotalEgresos { get; set; }

        public DateTime FechaInicailEgresos { get; set; }

        public DateTime FechaFinalIngresosEgresos { get; set; }

    }
}
