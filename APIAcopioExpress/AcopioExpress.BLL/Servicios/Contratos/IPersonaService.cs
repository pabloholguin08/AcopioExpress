using AcopioExpress.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcopioExpress.BLL.Servicios.Contratos
{
    public interface IPersonaService
    {
        Task<List<PersonaDTO>> ListarPersona();
        Task<List<PersonaDTO>> ListarEmpleados();
        Task<List<PersonaDTO>> ListarProductores();
        Task<PersonaDTO> CrearPersona(PersonaDTO personaDTO);
        Task<bool> ActualizarPersona(PersonaDTO personaDTO);
        Task<PersonaDTO> ObtenerPersona(int id);
        Task<bool> EliminarPersona(int id);
        Task<List<PersonaDTO>> ListarPersonaEliminados();
        Task<bool> RecuperarPersona(int id);
    }
}
