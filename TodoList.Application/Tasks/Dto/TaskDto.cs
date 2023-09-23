using TodoList.Application.Common;

namespace TodoList.Application.Tasks.Dto
{
    public class TaskDto : EntityDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsImportant { get; set; }
        public bool IsDeleted { get; set; }

    }
}
