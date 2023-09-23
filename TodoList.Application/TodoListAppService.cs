using AutoMapper;
using TodoList.Domain;

namespace TodoList.Application
{
    public abstract class TodoListAppService
    {
        protected TodoDbContext Context { get; set; }
        protected IMapper Mapper { get; set; }

        protected TodoListAppService(TodoDbContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }
    }
}
