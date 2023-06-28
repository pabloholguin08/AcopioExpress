using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcopioExpress.DTO
{
    public class InsumoDTO
    {
        public int IdInsumo { get; set; }

        public string NombreInsumo { get; set; } = null!;

        public string Descripcion { get; set; } = null!;

        public int ValorUnitarioVenta { get; set; }

        public int Stock { get; set; }

        public int? ValorTotalInsumosV { get; set; }

        public int ValorUnitarioCompra { get; set; }

        public int? ValorTotalUcompra { get; set; }

        public int? GananciaUnitaria { get; set; }

    }
}
