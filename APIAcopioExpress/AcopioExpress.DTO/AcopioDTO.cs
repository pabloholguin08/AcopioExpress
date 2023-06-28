using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcopioExpress.DTO
{
    public class AcopioDTO
    {
        public int IdAcopio { get; set; }

        public string NombreAcopi { get; set; } = null!;

        public string Ubicacion { get; set; } = null!;

        public int CantidadEmpleados { get; set; }


    }
}
