namespace Todo.Api.DataAccess;

public interface IToDoRepository
{
    public Task<Data.Todo> Add(Data.Todo todo);

    public Task<List<Data.Todo>> List();

    public Task<Data.Todo> Update(string id, Data.Todo updateTodoValues);

    public Task Delete(string id);
}