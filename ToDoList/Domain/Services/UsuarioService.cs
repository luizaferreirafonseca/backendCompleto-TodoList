using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ToDoList.Data.Context;
using ToDoList.Domain.DTO;
using ToDoList.Domain.Models;

namespace ToDoList.Domain.Services
{
    public class UsuarioService
    {
        private AppDbContext _appDbContext;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public UsuarioService(AppDbContext appDbContext, IConfiguration configuration, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _configuration = configuration;
            _mapper = mapper;
        }

        public  Usuario Cadastrar(CriarUsuarioDTO usuarioDTO)
        {
            var emailExistente =  _appDbContext.Usuarios.Any(
               u => u.Email == usuarioDTO.Email
                );

            if (emailExistente)
            {
                throw new ArgumentException("Usuário já está cadastrado");
            }

            if (usuarioDTO is null)
            {
                throw new BadHttpRequestException("Informações do usuário inválidas");
            }

            Usuario usuario = _mapper.Map<Usuario>(usuarioDTO);

            var usuarioCriado = _appDbContext.Usuarios.Add(usuario);
            _appDbContext.SaveChanges();

            return usuario;

        }

        public bool DeletarUsuario(int id)
        {
            var usuario = _appDbContext.Usuarios.Find(id);
            if (usuario == null)
            {
                throw new KeyNotFoundException("Usuário não encontrado");
            }

            usuario.Ativo = false; 
            _appDbContext.Usuarios.Update(usuario);
            _appDbContext.SaveChanges(); 

            return true;

        }

        public Usuario PegarPorEmail(string email)
        {
            var usuario = _appDbContext.Usuarios.FirstOrDefault(u => u.Email == email);

            if (usuario == null)
            {
                throw new KeyNotFoundException("Usuário não encontrado");
            }

            return usuario;
        }

        public Usuario PegarPeloId(int id)
        {
            var usuario = _appDbContext.Usuarios.FirstOrDefault(u => u.Id == id);

            if (usuario == null)
            {
                throw new KeyNotFoundException("Usuário não encontrado");
            }

            return usuario;
        }

        public List<Usuario> PegarUsuarios()
        {
            var usuarios = _appDbContext.Usuarios.ToList();

            return usuarios;
        }



    }
}
