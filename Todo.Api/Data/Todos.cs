using System.Text.Json.Serialization;

namespace Todo.Api.Data;

public class Todos
{
    [JsonPropertyName("todos")] public List<Todo>? Items { get; set; }
}