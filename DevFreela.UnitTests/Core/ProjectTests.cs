using DevFreela.Core.Entities;
using DevFreela.Core.Enum;

namespace DevFreela.UnitTests.Core;

public class ProjectTests
{
    [Fact]
    public void ProjectIsCreated_Start_Success()
    {
        //Arrange

        var project = new Project("Titulo", "Descricao", 3, 3, 2000);

        //Act

        project.Start();

        //Assert

        Assert.Equal(ProjectStatusEnum.InProgress, project.Status);
        Assert.NotNull(project.StartedAt);

        Assert.True(project.Status == ProjectStatusEnum.InProgress);
        Assert.False(project.StartedAt is null);
    }

    [Fact] 
    public void ProjectIsInInvalidState_Start_ThrowsNewException()
    {
        //Arrange 
        var project = new Project("Titulo", "Descricao", 3, 3, 2000);

        project.Start();    

        //Act
        Action? start = project.Start;

        //Assert
        var exception = Assert.Throws<InvalidOperationException>(start);
        Assert.Equal(Project.INVALID_STATE_MESSAGE, exception.Message);
    }

    [Fact]
    public void ProjectIsCanceled_Canceled_Sucess()
    {
        //Arrange 
        var project = new Project("abc", "abc", 2, 2, 2200);

        //Act
        Action? cancel = project.Cancel;

        //Assert
        var exception = Assert.Throws<InvalidOperationException>(cancel);
        Assert.Equal(Project.INVALID_CANCELSTATE_MESSAGE, exception.Message);
        
    }

    [Fact]
    public void ProjectIsUpdated_Update_Sucess()
    {
        //Arrange
        var project = new Project("Title", "Descricao", 3, 3, 2000);
        //Action
        project.Update("Title update", "description update", 1000);
        //Assert
        Assert.Equal("Title update", project.Title);
        Assert.Equal("description update", project.Description);
        Assert.Equal(1000, project.TotalCost);
    }
}