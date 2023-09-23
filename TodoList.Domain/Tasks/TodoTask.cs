using System.ComponentModel.DataAnnotations.Schema;
using TodoList.Domain.Entities;

namespace TodoList.Domain.Tasks
{
    [Table("Tasks")]
    public class TodoTask : Entity, ISoftDelete
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsImportant { get; set; }
        public bool IsDeleted { get; set; }

        public TodoTask(string name)
        {
            Name = name;
        }
    }
}
