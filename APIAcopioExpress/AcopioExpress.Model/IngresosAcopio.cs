using System;
using System.Collections.Generic;

namespace AcopioExpress.Model;

public partial class IngresosAcopio
{
    public int IdIngresosAcopio { get; set; }

    public int IdAcopio { get; set; }

    public int TotalGananciaInsumos { get; set; }

    public int TotalGananciaProduccion { get; set; }

    public DateTime FechaInicailIngresos { get; set; }

    public DateTime FechaFinalIngresosLiquidacion { get; set; }

    public long TotalIngresos { get; set; }

    public virtual Acopio IdAcopioNavigation { get; set; } = null!;
}
