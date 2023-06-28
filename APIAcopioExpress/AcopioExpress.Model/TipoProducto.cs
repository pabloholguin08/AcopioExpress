using System;
using System.Collections.Generic;

namespace AcopioExpress.Model;

public partial class TipoProducto
{
    public int IdTipoProducto { get; set; }

    public string TipoProducto1 { get; set; } = null!;

    public int Estado { get; set; }

    public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();
}
