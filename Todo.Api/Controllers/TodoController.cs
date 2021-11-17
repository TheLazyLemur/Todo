using Microsoft.AspNetCore.Mvc;
using Todo.Api.Data;

namespace Todo.Api.Controllers;

[ApiController]
[Route("/todos")]
public class TodoController : ControllerBase
{
    [HttpGet]
    public ActionResult<Todos> ListTodos()
    {
        return new Todos()
        {
            Items = new List<Data.Todo>()
        };
    }

    [HttpPost]
    public ActionResult<Data.Todo> Add()
    {
        return Ok(new Data.Todo());
    }

    [HttpPut("{id}")]
    public ActionResult<Data.Todo> Update(string id)
    {
        return Ok(new Data.Todo());
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(string id)
    {
        return Ok();
    }
}