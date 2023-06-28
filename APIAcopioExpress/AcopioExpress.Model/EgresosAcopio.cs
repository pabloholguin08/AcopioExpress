using System;
using System.Collections.Generic;

namespace AcopioExpress.Model;

public partial class EgresosAcopio
{
    public int IdEgresosAcopio { get; set; }

    public int IdAcopio { get; set; }

    public long Arriendo { get; set; }

    public int SumatoriaNominas { get; set; }

    public int Servicios { get; set; }

    public int SumatoriaLiquidacion { get; set; }

    public int GastosExtras { get; set; }

    public long TotalEgresos { get; set; }

    public DateTime FechaInicailEgresos { get; set; }

    public DateTime FechaFinalIngresosEgresos { get; set; }

    public virtual Acopio IdAcopioNavigation { get; set; } = null!;
}
