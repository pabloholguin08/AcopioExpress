using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcopioExpress.DTO
{
    public class NominaDTO
    {
        public int IdNomina { get; set; }

        public int IdPersona { get; set; }
        public string? Nombres { get; set; } = null!;

        public string? Apellidos { get; set; } = null!;

        public decimal Salario { get; set; }

        public DateTime FechaPago { get; set; }
    }
}
