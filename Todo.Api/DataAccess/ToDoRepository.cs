using Todo.Api.Data;

namespace Todo.Api.DataAccess;

public class ToDoRepository : IToDoRepository
{
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

        Store.Todos.Add(newId, createdTodo);

        return Task.FromResult(createdTodo);
    }

    public Task<List<Data.Todo>> List()
    {
        return Task.FromResult(Store.Todos.Values.ToList());
    }

    public Task<Data.Todo> Update(string id, Data.Todo newTodoValues)
    {
        var todoToUpdate = Store.Todos[id];

        if (todoToUpdate is null)
            throw new Exception("Todo not found");

        todoToUpdate.Completed = newTodoValues.Completed;
        todoToUpdate.Name = newTodoValues.Name;

        return Task.FromResult(todoToUpdate);
    }

    public Task Delete(string id)
    {
        Store.Todos.Remove(id);
        return Task.CompletedTask;
    }
}