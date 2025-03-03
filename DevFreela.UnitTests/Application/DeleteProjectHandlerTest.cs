using DevFreela.Application.Commands.DeleteProject;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using FluentAssertions;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Moq;
using NSubstitute;

namespace DevFreela.UnitTests.Application;

public class DeleteProjectHandlerTest
{
    [Fact]
    public async Task ProjectExists_Delete_Sucess_NSubstitute()
    {
        //arrange
        var project = new Project("Project A", "Descrição do projeto", 1, 2, 10000);

        var repository = Substitute.For<IProjectRepository>();
        repository.GetById(1).Returns(Task.FromResult((Project?)project));
        repository.Update(Arg.Any<Project>()).Returns(Task.CompletedTask);

        var handler = new DeleteProjectHandler(repository);

        var command = new DeleteProjectCommand(1);
        //act
        var result = await handler.Handle(command, new CancellationToken());

        //assert
        Assert.True(result.IsSuccess);
        result.IsSuccess.Should().BeTrue();

        await repository.Received(1).GetById(1);
        await repository.Received(1).Update(Arg.Any<Project>());

    }

    [Fact]
    public async Task ProjectDoesNotExist_Delete_Error_NSubstitute()
    {
        //arrange
        var repository = Substitute.For<IProjectRepository>();

        repository.GetById(Arg.Any<int>()).Returns(Task.FromResult((Project?)null));

        var handler = new DeleteProjectHandler(repository);

        var command = new DeleteProjectCommand(1);
        //act
        var result = await handler.Handle(command, new CancellationToken());

        //assert
        Assert.False(result.IsSuccess);
        result.IsSuccess.Should().BeFalse();
        Assert.Equal(DeleteProjectHandler.PROJECT_NOT_FOUND_MESSAGE, result.Message);

        await repository.Received(1).GetById(Arg.Any<int>());
        await repository.DidNotReceive().Update(Arg.Any<Project>());
    }

}