using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ToDoList.Data.Context;
using ToDoList.Domain.DTO;
using ToDoList.Domain.Models;

namespace ToDoList.Domain.Services
{
    public class LoginService
    {
        private AppDbContext _appDbContext;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        
        public LoginService(AppDbContext appDbContext, IConfiguration configuration, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _configuration = configuration;
            _mapper = mapper;

        }

        public Usuario Login(UsuarioLoginDTO dto)
        {
            var usuario = _appDbContext.Usuarios.FirstOrDefault(u => u.Email == dto.Email && u.Senha == dto.Senha);

            return usuario;
        }
    }
}
