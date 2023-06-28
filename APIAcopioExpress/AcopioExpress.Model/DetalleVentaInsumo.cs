using System;
using System.Collections.Generic;

namespace AcopioExpress.Model;

public partial class DetalleVentaInsumo
{
    public int IdDetalleVentaInsumo { get; set; }

    public int IdInsumo { get; set; }

    public int IdVentaInsumo { get; set; }

    public int Cantidad { get; set; }

    public int Precio { get; set; }

    public long? TotalVentaInsumo { get; set; }

    public int Estado { get; set; }

    public virtual Insumo IdInsumoNavigation { get; set; } = null!;

    public virtual VentaInsumo IdVentaInsumoNavigation { get; set; } = null!;
}
