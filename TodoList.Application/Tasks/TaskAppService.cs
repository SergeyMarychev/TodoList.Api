using AutoMapper;
using TodoList.Application.Exceptions;
using TodoList.Application.Tasks.Dto;
using TodoList.Domain;
using TodoList.Domain.Tasks;

namespace TodoList.Application.Tasks
{
    public class TaskAppService : TodoListAppService, ITaskAppService
    {
        public TaskAppService(TodoDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public void Create(string name)
        {
            if (Context.Tasks.Any(t => t.Name.ToLower() == name.ToLower()))
            {
                throw new UserFriendlyException("Такая задача уже есть!"); 
            }

            Context.Tasks.Add(new TodoTask(name));
            Context.SaveChanges();
        }

        public void Delete(int id, bool isSoftDelete)
        {
            var task = Context.Tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                throw new UserFriendlyException("Такой задачи не существует!");
            }

            if (isSoftDelete)
            {
                task.IsDeleted = true;
                Context.Tasks.Update(task);
            }
            else
            {
                Context.Tasks.Remove(task);
            }

            Context.SaveChanges();
        }

        public TaskDto Get(int id)
        {
            var task = Context.Tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                throw new UserFriendlyException("Такой задачи не существует!");
            }

            return Mapper.Map<TaskDto>(task);
        }

        public IEnumerable<TaskDto> GetAll(GetAllTaskInput input)
        {
            IQueryable<TodoTask> query = Context.Tasks;

            if (input.IsCompleted.HasValue)
            {
                query = query.Where(t => t.IsCompleted == input.IsCompleted);
            }

            if (input.IsImportant.HasValue)
            {
                query = query.Where(t => t.IsImportant == input.IsImportant);
            }

            if (input.IsDeleted.HasValue)
            {
                query = query.Where(t => t.IsDeleted == input.IsDeleted);
            }

            var result = query.ToList();

            return Mapper.Map<IEnumerable<TaskDto>>(result);
        }

        public void Update(UpdateTaskDto input)
        {
            var task = Context.Tasks.FirstOrDefault(t => t.Id == input.Id);
            if (task == null)
            {
                throw new UserFriendlyException("Такой задачи не существует!");
            }

            if (input.IsImportant.HasValue)
            {
                task.IsImportant = input.IsImportant.Value;
            }

            if (input.IsCompleted.HasValue)
            {
                task.IsCompleted = input.IsCompleted.Value;

                if (!task.IsCompleted && task.IsDeleted)
                {
                    task.IsDeleted = false;
                }
            }

            if (!string.IsNullOrWhiteSpace(input.Name))
            {
                task.Name = input.Name;
            }

            if (input.Description != null)
            {
                task.Description = input.Description.Trim();
            }

            Context.Tasks.Update(task);
            Context.SaveChanges();
        }
    }
}
