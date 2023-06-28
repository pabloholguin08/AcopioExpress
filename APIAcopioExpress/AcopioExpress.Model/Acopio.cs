using System;
using System.Collections.Generic;

namespace AcopioExpress.Model;

public partial class Acopio
{
    public int IdAcopio { get; set; }

    public string NombreAcopi { get; set; } = null!;

    public string Ubicacion { get; set; } = null!;

    public int CantidadEmpleados { get; set; }

    public int Estado { get; set; }

    public virtual ICollection<EgresosAcopio> EgresosAcopios { get; set; } = new List<EgresosAcopio>();

    public virtual ICollection<IngresosAcopio> IngresosAcopios { get; set; } = new List<IngresosAcopio>();

    public virtual ICollection<Login> Logins { get; set; } = new List<Login>();

    public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();

    public virtual ICollection<VentaProduccion> VentaProduccions { get; set; } = new List<VentaProduccion>();
}
