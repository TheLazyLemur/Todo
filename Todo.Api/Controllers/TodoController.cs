using Microsoft.AspNetCore.Mvc;
using Todo.Api.Data;
using Todo.Api.DataAccess;

namespace Todo.Api.Controllers;

[ApiController]
[Route("/todos")]
public class TodoController : ControllerBase
{
    private readonly IToDoRepository _toDoRepository;

    public TodoController(IToDoRepository toDoRepository)
    {
        _toDoRepository = toDoRepository;
    }

    [HttpGet]
    public async Task<ActionResult<Todos>> ListTodos()
    {
        return new Todos()
        {
            Items = await _toDoRepository.List()
        };
    }

    [HttpPost]
    public async Task<ActionResult<Data.Todo>> Add(Data.Todo todo)
    {
        try
        {
            var result = await _toDoRepository.Add(todo);
            return Ok(result);
        }
        catch
        {
            return StatusCode(500, "Oops something went wrong");
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Data.Todo>> Update(string id, Data.Todo newTodoValues)
    {
        try
        {
            var result = await _toDoRepository.Update(id, newTodoValues);
            return Ok(result);
        }
        catch
        {
            return StatusCode(500, "Oops something went wrong");
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(string id)
    {
        try
        {
            await _toDoRepository.Delete(id);
            return Ok();
        }
        catch
        {
            return StatusCode(500, "Oops something went wrong");
        }
    }
}