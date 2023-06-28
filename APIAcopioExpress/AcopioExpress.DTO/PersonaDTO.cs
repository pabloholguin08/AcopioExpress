using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcopioExpress.DTO
{
    public class PersonaDTO
    {
        public int IdPersona { get; set; }

        public string Cedula { get; set; } = null!;

        public string Nombres { get; set; } = null!;

        public string Apellidos { get; set; } = null!;

        public string Telefono { get; set; } = null!;

        public string Direccion { get; set; } = null!;

        public int IdAcopio { get; set; }
        public string? NombreAcopi { get; set; }

        public int IdTipoProducto { get; set; }
        public string? TipoProducto1 { get; set; }

        public int IdRol { get; set; }
        public string? NombreRol { get; set; }
    }
}
