using System;
using System.Collections.Generic;

namespace AcopioExpress.Model;

public partial class TipoPago
{
    public int IdTipoPago { get; set; }

    public string NombreTipoProducto { get; set; } = null!;

    public virtual ICollection<VentaInsumo> VentaInsumos { get; set; } = new List<VentaInsumo>();
}
