using System;
using System.Collections.Generic;

namespace AcopioExpress.Model;

public partial class VentaInsumo
{
    public int IdVentaInsumo { get; set; }

    public int IdPersona { get; set; }

    public int? IdTipoPago { get; set; }

    public string Observacion { get; set; } = null!;

    public DateTime? FechaRegistro { get; set; }

    public int Estado { get; set; }

    public virtual ICollection<DetalleVentaInsumo> DetalleVentaInsumos { get; set; } = new List<DetalleVentaInsumo>();

    public virtual Persona IdPersonaNavigation { get; set; } = null!;

    public virtual TipoPago? IdTipoPagoNavigation { get; set; }
}
