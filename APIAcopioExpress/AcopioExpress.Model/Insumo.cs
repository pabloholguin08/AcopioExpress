using System;
using System.Collections.Generic;

namespace AcopioExpress.Model;

public partial class Insumo
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

    public int Estado { get; set; }

    public virtual ICollection<DetalleVentaInsumo> DetalleVentaInsumos { get; set; } = new List<DetalleVentaInsumo>();
}
