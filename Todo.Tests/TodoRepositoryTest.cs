using System;
using System.Linq;
using System.Threading.Tasks;
using Todo.Api.DataAccess;
using Xunit;
using Xunit.Abstractions;

namespace Todo.Tests;

public class TodoRepositoryTest
{
    private readonly ITestOutputHelper _testOutputHelper;

    public TodoRepositoryTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public async Task AddShouldFail_WhenNameIsImLazy()
    {
        //Arrange
        IToDoRepository todoRepository = new ToDoRepository();

        // Act
        //Assert
        await Assert.ThrowsAsync<Exception>(() => todoRepository.Add(new Api.Data.Todo() {Name = "I'm lazy"}));
    }

    [Fact]
    public void DefaultShouldReturn_SingleTodo()
    {
        //Arrange
        IToDoRepository todoRepository = new ToDoRepository();

        //Act
        var todos = todoRepository.List().Result.FirstOrDefault();

        //Assert
        Assert.Equal("Do some work", todos?.Name);
        Assert.False(todos?.Completed);
    }

    [Fact]
    public void UpdateDoesNotChangeId_ButOtherProps()
    {
        //Arrange
        IToDoRepository todoRepository = new ToDoRepository();
        var todo = todoRepository.List().Result.FirstOrDefault();


        //Act
        todoRepository.Update("abc123", new Api.Data.Todo()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Test",
            Completed = true
        });

        var updatedTodo = todoRepository.List().Result.FirstOrDefault();

        //Assert
        Assert.True(updatedTodo?.Completed);
        Assert.Equal("Test", todo?.Name);
        Assert.Equal("abc123", todo?.Id);
    }
}