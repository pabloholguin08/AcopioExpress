using System;
using System.Collections.Generic;

namespace AcopioExpress.Model;

public partial class VentaProduccion
{
    public int IdVentaProduccion { get; set; }

    public int IdAcopio { get; set; }

    public DateTime FechaVenta { get; set; }

    public int Cantidad { get; set; }

    public decimal? Precio { get; set; }

    public decimal? TotalVentaProduccion { get; set; }

    public string? Observaciones { get; set; }

    public int Estado { get; set; }

    public virtual Acopio IdAcopioNavigation { get; set; } = null!;
}
