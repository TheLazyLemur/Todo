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
        var result = await _toDoRepository.Add(todo);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Data.Todo>> Update(string id, Data.Todo newTodoValues)
    {
        var result = await _toDoRepository.Update(id, newTodoValues);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(string id)
    {
        _toDoRepository.Delete(id);
        return Ok();
    }
}