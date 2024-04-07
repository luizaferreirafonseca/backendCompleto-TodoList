using AutoMapper;
using ToDoList.Domain.DTO;
using ToDoList.Domain.Models;

namespace ToDoList.Domain.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile() { 
            
            CreateMap<Usuario, CriarUsuarioDTO>().ReverseMap();
            CreateMap<Usuario, UsuarioLoginDTO>().ReverseMap();


        
        }
    }
}
