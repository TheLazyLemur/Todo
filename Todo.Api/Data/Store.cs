namespace Todo.Api.Data;

public class Store
{
    public static Dictionary<string, Todo> Todos = new()
    {
        {
            "abc123", new Todo()
            {
                Id = "abc123",
                Name = "Default todo",
                Completed = false
            }
        }
    };
}