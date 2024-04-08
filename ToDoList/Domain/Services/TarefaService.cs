using AutoMapper;
using ToDoList.Data.Context;

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

    }
}
