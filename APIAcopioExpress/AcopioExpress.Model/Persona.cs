using System;
using System.Collections.Generic;

namespace AcopioExpress.Model;

public partial class Persona
{
    public int IdPersona { get; set; }

    public string Cedula { get; set; } = null!;

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public int IdAcopio { get; set; }

    public int IdTipoProducto { get; set; }

    public int IdRol { get; set; }

    public int Estado { get; set; }

    public virtual Acopio IdAcopioNavigation { get; set; } = null!;

    public virtual RolUser IdRolNavigation { get; set; } = null!;

    public virtual TipoProducto IdTipoProductoNavigation { get; set; } = null!;

    public virtual ICollection<LiquidacionProductor> LiquidacionProductors { get; set; } = new List<LiquidacionProductor>();

    public virtual ICollection<Nomina> Nominas { get; set; } = new List<Nomina>();

    public virtual ICollection<Produccion> Produccions { get; set; } = new List<Produccion>();

    public virtual ICollection<VentaInsumo> VentaInsumos { get; set; } = new List<VentaInsumo>();
}
