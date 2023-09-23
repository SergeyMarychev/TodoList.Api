using AutoMapper;
using TodoList.Domain.Tasks;

namespace TodoList.Application.Tasks.Dto
{
    public class TaskMapProfile : Profile
    {
        public TaskMapProfile()
        {
            CreateMap<TodoTask, TaskDto>();
        }
    }
}
