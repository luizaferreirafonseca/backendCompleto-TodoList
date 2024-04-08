using AutoMapper;
using ToDoList.Domain.DTO;
using ToDoList.Domain.Models;

namespace ToDoList.Domain.Profiles
{
    public class TarefaProfile : Profile
    {
        public TarefaProfile() {

            CreateMap<Tarefa, TarefaDTO>().ReverseMap();
        
        }
    }
}
