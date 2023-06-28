using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcopioExpress.DTO
{
    public class LoginDTO
    {
        public int IdLogin { get; set; }

        public string Usuario { get; set; } = null!;

        public string Password { get; set; } = null!;
        public int IdAcopio { get; set; }
        public string? NombreAcopi { get; set; }
        public int IdRol { get; set; }
        public string NombreRol { get; set; } 




    }
}
