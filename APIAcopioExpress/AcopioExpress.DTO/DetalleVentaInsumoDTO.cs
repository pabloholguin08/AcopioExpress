using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcopioExpress.DTO
{
    public class DetalleVentaInsumoDTO
    {
        public int IdDetalleVentaInsumo { get; set; }

        public int IdInsumo { get; set; }

        public string NombreInsumo { get; set; } = null!;

        public int Precio { get; set; } 
        public int Cantidad { get; set; }


        public int? TotalVentaInsumo { get; set; }

    }
}
