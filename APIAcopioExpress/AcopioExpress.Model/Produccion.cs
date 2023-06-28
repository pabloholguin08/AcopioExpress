using System;
using System.Collections.Generic;

namespace AcopioExpress.Model;

public partial class Produccion
{
    public int IdProduccion { get; set; }

    public DateTime DiaIngresoProducto { get; set; }

    public int Cantidad { get; set; }

    public int PrecioProducto { get; set; }

    public string Observaciones { get; set; } = null!;

    public int? ValorProducto { get; set; }

    public int IdPersona { get; set; }

    public int Estado { get; set; }

    public virtual Persona IdPersonaNavigation { get; set; } = null!;
}
