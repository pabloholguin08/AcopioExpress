using System;
using System.Collections.Generic;

namespace AcopioExpress.Model;

public partial class RolUser
{
    public int IdRol { get; set; }

    public string NombreRol { get; set; } = null!;

    public virtual ICollection<Login> Logins { get; set; } = new List<Login>();

    public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();
}
