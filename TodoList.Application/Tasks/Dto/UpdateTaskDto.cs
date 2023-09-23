namespace TodoList.Application.Tasks.Dto
{
    public class UpdateTaskDto
    {
        public int Id { get; set; }
        public bool? IsImportant { get; set; }
        public bool? IsCompleted { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
