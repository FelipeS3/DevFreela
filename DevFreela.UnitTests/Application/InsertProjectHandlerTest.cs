using DevFreela.Application.Commands.InsertProject;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.UnitTests.Fakes;
using FluentAssertions;
using MediatR;
using Moq;
using NSubstitute;

namespace DevFreela.UnitTests.Application;


public class InsertProjectHandlerTest
{
    [Fact]
    public async Task InputDataAreOk_InsertProject_NSubstite()
    {
        //Arrange 
        const int ID = 1;

        var repository = Substitute.For<IProjectRepository>();
        var mediator = Substitute.For<IMediator>();

        repository.AddProject(Arg.Any<Project>()).Returns(Task.FromResult(ID));

        //var command = new InsertProjectCommand()
        //{
        //    Title = "Project A",
        //    Description = "Descrição do projeto",
        //    TotalCost = 20000,
        //    IdClient = 1,
        //    IdFreelancer = 2
        //};

        var command = FakeDataHelper.CreateFakeInsertProjectCommand();

        var handler = new InsertProjectHandler(mediator, repository);

        //Act
        var result = await handler.Handle(command, new CancellationToken());

        //Assert
        Assert.True(result.IsSuccess);
        result.IsSuccess.Should().BeTrue();

        Assert.Equal(ID, result.Data);
        result.Data.Should().Be(ID);

        await repository.Received(1).AddProject(Arg.Any<Project>());
    }

    [Fact]
    public async Task InputDataAreOk_InsertProject_Moq()
    {
        // Arrange 
        const int ID = 1;

        var mock = new Mock<IProjectRepository>();
        mock.Setup(r => r.AddProject(It.IsAny<Project>())).ReturnsAsync(ID);

        // var respository = Mock.Of<IProjectRepository>(r => r.AddProject(It.IsAny<Project>()) == Task.FromResult(ID));

        var mediator = new Mock<IMediator>();

        //var command = new InsertProjectCommand()
        //{
        //    Title = "Project A",
        //    Description = "Descrição do projeto",
        //    TotalCost = 20000,
        //    IdClient = 1,
        //    IdFreelancer = 2
        //};

        var command = FakeDataHelper.CreateFakeInsertProjectCommand();

        var handler = new InsertProjectHandler(mediator.Object, mock.Object);

        // Act
        var result = await handler.Handle(command, new CancellationToken());

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(ID, result.Data);

        // Verifique o mock que foi injetado no handler
        mock.Verify(m => m.AddProject(It.IsAny<Project>()), Times.Once());
    }
}