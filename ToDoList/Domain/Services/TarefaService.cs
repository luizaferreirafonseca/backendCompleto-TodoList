using AutoMapper;
using ToDoList.Data.Context;
using ToDoList.Domain.DTO;
using ToDoList.Domain.Models;

namespace ToDoList.Domain.Services
{
    public class TarefaService
    {
        private AppDbContext _appDbContext;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public TarefaService(AppDbContext appDbContext, IConfiguration configuration, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _configuration = configuration;
            _mapper = mapper;
        }




        public List<Tarefa> Cadastrar(TarefaDTO tarefaDto)
        {
            if(tarefaDto == null)
            {
                throw new BadHttpRequestException("Dados inválidos");
            }

            Tarefa novaTarefa = _mapper.Map<Tarefa>(tarefaDto);

            _appDbContext.Tarefas.Add(novaTarefa);
            _appDbContext.SaveChanges();

            var tarefasAtualizadas = _appDbContext.Tarefas.ToList();

            return tarefasAtualizadas;

        }

        public bool Deletar(int id)
        {
            var tarefa = _appDbContext.Tarefas.Find(id);

            if (tarefa == null)
            {
                return false;
            }

            _appDbContext.Remove(tarefa);
            _appDbContext.SaveChanges();

            return true;
        }


        public Tarefa PegarPeloId(int id)
        {
            var tarefa = _appDbContext.Tarefas.FirstOrDefault(t => t.Id == id);

            if (tarefa == null)
            {
                throw new KeyNotFoundException($"A tarefa com o ID {id} não foi encontrada");
            }
            return tarefa;

        }

        public Tarefa Editar(int id, TarefaDTO tarefaPraEditar)
        {
            var tarefa = _appDbContext.Tarefas.FirstOrDefault(t => t.Id == id);

            if (tarefa == null)
            {
                throw new Exception($"A tarefa com ID {id} não foi encontrada.");
            }

           
            _mapper.Map(tarefaPraEditar, tarefa);

            
            _appDbContext.Tarefas.Update(tarefa);

            
            _appDbContext.SaveChanges();

            
            return tarefa;


        }

    }
}
