using Bogus;
using DevFreela.Application.Commands.DeleteProject;
using DevFreela.Application.Commands.InsertProject;
using DevFreela.Core.Entities;

namespace DevFreela.UnitTests.Fakes;

public class FakeDataHelper
{
    private static readonly Faker _faker = new Faker();

    public static Project CreateFakeProjectV1()
    {
        return new Project(
            _faker.Commerce.ProductName(),
            _faker.Lorem.Sentence(),
            _faker.Random.Int(1, 100),
            _faker.Random.Int(1, 100),
            _faker.Random.Decimal(1000, 10000)
        );
    }

    private static readonly Faker<Project> _projectFaker = new Faker<Project>()
        .CustomInstantiator(f => new Project(
            f.Commerce.ProductName(),
            f.Lorem.Sentence(),
            f.Random.Int(1, 100),
            f.Random.Int(1, 100),
            f.Random.Decimal(1000, 10000)
             ));

    private static readonly Faker<InsertProjectCommand> _insertProjectCommandFaker = new Faker<InsertProjectCommand>()
        .RuleFor(c => c.Title, f => f.Commerce.ProductName())
        .RuleFor(c => c.Description, f => f.Lorem.Sentence())
        .RuleFor(c => c.IdFreelancer, f => f.Random.Int(1, 100))
        .RuleFor(c => c.IdClient, f => f.Random.Int(1, 100))
        .RuleFor(c => c.TotalCost, f => f.Random.Decimal(1000, 10000));

    public static Project CreateFakeProjects() => _projectFaker.Generate();
    public static List<Project> CreateFakeProjectList() => _projectFaker.Generate(5);

    public static InsertProjectCommand CreateFakeInsertProjectCommand() => _insertProjectCommandFaker.Generate();

    public static DeleteProjectCommand CreateFakeDeleteProjectCommand(int id) => new(id);
}