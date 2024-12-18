using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Commands.InsertSkill;

public class InsertSkillHandler : IRequestHandler<InsertSkillCommand, ResultViewModel<int>>
{
    private readonly DevFreelaDbContext _context;

    public InsertSkillHandler(DevFreelaDbContext context)
    {
        _context = context;
    }

    public async Task<ResultViewModel<int>> Handle(InsertSkillCommand request, CancellationToken cancellationToken)
    {
        var skill = request.ToEntity();

        await _context.Skills.AddAsync(skill);
        await _context.SaveChangesAsync();

        return ResultViewModel<int>.Success(skill.Id);
    }
}