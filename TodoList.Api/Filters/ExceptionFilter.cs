using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TodoList.Application.Exceptions;

namespace TodoList.Api.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            if (exception is UserFriendlyException)
            {
                context.Result = new BadRequestObjectResult(exception.Message);
            }
        }
    }
}
