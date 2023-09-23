using TodoList.Application.Tasks.Dto;

namespace TodoList.Application.Tasks
{
    public interface ITaskAppService
    {
        TaskDto Get(int id);
        void Update(UpdateTaskDto input);
        void Delete(int id, bool isSoftDelete);
        void Create(string name);
        IEnumerable<TaskDto> GetAll(GetAllTaskInput input);
    }
}
