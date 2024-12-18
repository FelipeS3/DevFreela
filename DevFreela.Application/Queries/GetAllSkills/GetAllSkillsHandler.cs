using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Queries.GetAllSkills;

public class GetAllSkillsHandler : IRequestHandler<GetAllSkillsQuery,ResultViewModel<List<SkillViewModel>>>
{
    private readonly DevFreelaDbContext _context;

    public GetAllSkillsHandler(DevFreelaDbContext context)
    {
        _context = context;
    }

    public async Task<ResultViewModel<List<SkillViewModel>>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
    {
        var skills = await _context.Skills.ToListAsync();

        var model = skills.Select(SkillViewModel.FromEntity).ToList();

        return ResultViewModel<List<SkillViewModel>>.Success(model);
    }
}
