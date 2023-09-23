using Microsoft.AspNetCore.Mvc;
using TodoList.Application.Tasks;
using TodoList.Application.Tasks.Dto;

namespace TodoList.Api.Controllers
{
    public class TasksController : ApiController
    {
        private readonly ITaskAppService _taskAppService;

        public TasksController(ITaskAppService taskAppService)
        {
            _taskAppService = taskAppService;
        }

        [HttpGet("[action]")]
        public IActionResult GetAll([FromQuery] GetAllTaskInput input)
        {
            var result = _taskAppService.GetAll(input);
            return Ok(result);
            return BadRequest("");
        }

        [HttpPost("[action]")]
        public IActionResult Create(string name)
        {
            _taskAppService.Create(name);
            return Ok();
        }

        [HttpDelete("[action]")]
        public IActionResult Delete(int id, bool isSoftDelete)
        {
            _taskAppService.Delete(id, isSoftDelete);
            return Ok();
        }

        [HttpPut("[action]")]
        public IActionResult Update(UpdateTaskDto input)
        {
            _taskAppService.Update(input);
            return Ok();
        }

        [HttpGet("[action]")]
        public IActionResult Get(int id)
        {
            var task = _taskAppService.Get(id);
            return Ok(task);
        }
    }
}
