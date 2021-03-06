using Todo.Api.Data;

namespace Todo.Api.DataAccess;

public class ToDoRepository : IToDoRepository
{
    private readonly Store _store = new();

    public Task<Data.Todo> Add(Data.Todo todo)
    {
        if (todo.Name == "I'm lazy")
            throw new Exception("Name is I'm lazy");

        var newId = Guid.NewGuid().ToString();
        var createdTodo = new Data.Todo()
        {
            Id = newId,
            Name = todo.Name,
            Completed = todo.Completed,
        };

        _store.Todos.Add(newId, createdTodo);

        return Task.FromResult(createdTodo);
    }

    public Task<List<Data.Todo>> List()
    {
        return Task.FromResult(_store.Todos.Values.ToList());
    }

    public Task<Data.Todo> Update(string id, Data.Todo newTodoValues)
    {
        var exists = _store.Todos.TryGetValue(id, out var todo);
        if (!exists || todo is null)
            throw new Exception("Todo not found");

        todo.Completed = newTodoValues.Completed;
        todo.Name = newTodoValues.Name;

        _store.Todos[id] = todo;

        return Task.FromResult(todo);
    }

    public Task Delete(string id)
    {
        _store.Todos.Remove(id);
        return Task.CompletedTask;
    }
}