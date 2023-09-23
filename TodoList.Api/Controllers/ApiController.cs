using Microsoft.AspNetCore.Mvc;
using TodoList.Domain;

namespace TodoList.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public abstract class ApiController : ControllerBase
    {
    }
}