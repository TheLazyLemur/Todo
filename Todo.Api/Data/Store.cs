namespace Todo.Api.Data;

public class Store
{
    public Dictionary<string, Todo> Todos = new()
    {
        {
            "abc123", new Todo()
            {
                Id = "abc123",
                Name = "Do some work",
                Completed = false
            }
        }
    };
}