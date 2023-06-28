using System;
using System.Collections.Generic;

namespace AcopioExpress.Model;

public partial class Nomina
{
    public int IdNomina { get; set; }

    public int IdPersona { get; set; }

    public decimal Salario { get; set; }

    public DateTime FechaPago { get; set; }

    public virtual Persona IdPersonaNavigation { get; set; } = null!;
}
