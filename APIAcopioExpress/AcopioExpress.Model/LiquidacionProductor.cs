using System;
using System.Collections.Generic;

namespace AcopioExpress.Model;

public partial class LiquidacionProductor
{
    public int IdLiquidacion { get; set; }

    public DateTime FechaLiquidacion { get; set; }

    public long TotalProduccion { get; set; }

    public int TotalInsumos { get; set; }

    public long? TotalPagar { get; set; }

    public int IdPersona { get; set; }

    public virtual Persona IdPersonaNavigation { get; set; } = null!;
}
