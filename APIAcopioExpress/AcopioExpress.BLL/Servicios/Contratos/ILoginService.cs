using AcopioExpress.DTO;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcopioExpress.BLL.Servicios.Contratos
{
    public interface ILoginService
    {
        Task<LoginDTO> ValidaCredenciales(string usuario, string pass);
        Task<LoginDTO> RecuperarCredenciales(string usuario);
    }
}
