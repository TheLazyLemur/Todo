[![.NET](https://github.com/TheLazyLemur/Todo/actions/workflows/dotnet.yml/badge.svg)](https://github.com/TheLazyLemur/Todo/actions/workflows/dotnet.yml)

# Todo Service

## Description Of Application

A Todo microservice that implements an in Memory store. The service should implement the open api spec provided.

## Building the project

### Requirements

- .Net6
- xunit (Testing)

### Run Tests

- git clone https://github.com/TheLazyLemur/Todo
- cd Todo
- dotnet restore
- dotnet test


### Run Api

- git clone https://github.com/TheLazyLemur/Todo
- cd Todo/Todo.Api
- dotnet restore
- dotnet run or dotnet watch

### Service Design

This service follows a repository pattern with the main repository hidden behind an interface to hide its implmentation,
making it easier to Mock. 

I am using github actions to ensure code compliance when commit are made.
