using System;
using System.Collections.Generic;

namespace AcopioExpress.Model;

public partial class Login
{
    public int IdLogin { get; set; }

    public string Usuario { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int IdAcopio { get; set; }

    public int IdRol { get; set; }

    public virtual Acopio IdAcopioNavigation { get; set; } = null!;

    public virtual RolUser IdRolNavigation { get; set; } = null!;
}
