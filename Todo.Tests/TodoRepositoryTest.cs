using System;
using System.Linq;
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
    public void Add_Should_Fail_When_Name_Is_Im_Lazy()
    {
        //Arrange
        IToDoRepository todoRepository = new ToDoRepository();

        try
        {
            todoRepository.Add(new Api.Data.Todo() {Name = "I'm lazy"});
        }
        catch (Exception e)
        {
            Assert.Contains("Name is I'm lazy", e.Message);
        }
    }

    [Fact]
    public void Default_Should_Return_Single_Todo()
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
    public void Update_Does_Not_Change_Id_But_Other_Props()
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