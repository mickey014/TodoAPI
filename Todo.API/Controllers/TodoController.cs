using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Todo.API.Extensions;
using Todo.Application.Contracts;
using Todo.Application.DTOs.Request;

namespace Todo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;
        private readonly ILogger<TodoController> logger;

        public TodoController(
            ITodoService todoService,
            ILogger<TodoController> logger
        )
        {
            this._todoService = todoService;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get() {
            logger.LogInformation($"Executing GET method inside a TodoController Date:{DateTime.Now}");

            var result = await _todoService.GetItems();

            if (result.IsFailure)
                return result.ToProblemDetails();

            return Ok(result.Value);
        }

        [HttpPost]
        public async Task<IActionResult> Post(
            [FromBody] CreateTodoDto todo
        )
        {
            var result = await _todoService.CreateTodoAsync(todo);
            return result.IsSuccess ? Created() : result.ToProblemDetails();
        }
    }
}
