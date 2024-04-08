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

            var tarefaCriada = _appDbContext.Tarefas.Add(novaTarefa);
            _appDbContext.SaveChanges();

            var tarefasAtualizadas = _appDbContext.Tarefas.ToList();

            return tarefasAtualizadas;

        }
        
        public List<Tarefa> Deletar(int id)
        {
            var tarefa = _appDbContext.Tarefas.Find(id);

            if (tarefa == null)
            {
                throw new Exception($"A tarefa com ID {id} não foi encontrada.");
            }

            _appDbContext.Remove(tarefa);
            _appDbContext.SaveChanges();

            var tarefasAtualizadas = _appDbContext.Tarefas.ToList();
            return tarefasAtualizadas;
        }

        public Tarefa PegarPeloId(int id)
        {
            var tarefa = _appDbContext.Tarefas.FirstOrDefault(t => t.Id == id);

            if (tarefa == null)
            {
                throw new Exception($"O {id} não existe");
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
