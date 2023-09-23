namespace TodoList.Application.Tasks.Dto
{
    public class GetAllTaskInput
    {
        public bool? IsImportant { get; set; }
        public bool? IsCompleted { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
