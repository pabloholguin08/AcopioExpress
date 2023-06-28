using AcopioExpress.BLL.Servicios.Contratos;
using AcopioExpress.DAL.Repositorios.Contrato;
using AcopioExpress.DTO;
using AcopioExpress.Model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcopioExpress.BLL.Servicios
{
    public class LoginService: ILoginService
    {
        private readonly ILogginRepository _loginRepository;
        private readonly IMapper _mapper;

        public LoginService(ILogginRepository loginRepository, IMapper mapper)
        {
            _loginRepository = loginRepository;
            _mapper = mapper;
        }

        public async Task<LoginDTO> ValidaCredenciales(string usuario, string pass)
        {
            try
            {
                var queryUsuario = await _loginRepository.Consultar(u =>
                u.Usuario == usuario &&
                u.Password == pass);

                if (queryUsuario.FirstOrDefault()==null)
                {
                    return null;
                }

                Login devolverUsuario = queryUsuario.Include(r => r.IdRolNavigation)
                    .Include(a =>a.IdAcopioNavigation).First();
                return _mapper.Map<LoginDTO>(devolverUsuario);
            }
            catch 
            {

                throw;
            }

        }

        public async Task<LoginDTO> RecuperarCredenciales(string usuario)
        {
            try
            {
                var queryUsuario = await _loginRepository.Consultar(u =>
                u.Usuario == usuario);

                if (queryUsuario.FirstOrDefault() == null)
                {
                    throw new TaskCanceledException("El usuario no existe");
                }

                Login devolverUsuario = queryUsuario.First();
                return _mapper.Map<LoginDTO>(devolverUsuario);
            }
            catch
            {

                throw;
            }
        }

     
    }
}
