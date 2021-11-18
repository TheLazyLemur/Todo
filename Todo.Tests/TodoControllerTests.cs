using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Todo.Api.Controllers;
using Todo.Api.DataAccess;
using Xunit;
using Xunit.Abstractions;

namespace Todo.Tests;

public class TodoControllerTests
{
    private readonly TodoController _sut;
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly Mock<IToDoRepository> _mock = new();

    public TodoControllerTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
        _sut = new TodoController(_mock.Object);
    }

    [Fact]
    public async Task AddShouldFail_WhenNameIsImLazy_Return500()
    {
        var todo = new Todo.Api.Data.Todo()
        {
            Id = "abc123",
            Name = "I'm lazy",
            Completed = false
        };

        _mock.Setup(x => x.Add(todo)).ThrowsAsync(new Exception());

        var response = await _sut.Add(todo);

        var n = response.Result as ObjectResult;

        Assert.NotNull(n);
        Assert.Equal(500, n?.StatusCode);
    }

    [Fact]
    public async Task UpdateShouldFail_WhenTodoDoesNotExist_Return500()
    {
        var todoId = "testid";
        var todo = new Todo.Api.Data.Todo()
        {
            Id = "abc123",
            Name = "I'm lazy",
            Completed = false
        };

        _mock.Setup(x => x.Update(todoId, todo)).ThrowsAsync(new Exception());

        var response = await _sut.Update(todoId, todo);

        var n = response.Result as ObjectResult;

        Assert.NotNull(n);
        Assert.Equal(500, n?.StatusCode);
    }
}