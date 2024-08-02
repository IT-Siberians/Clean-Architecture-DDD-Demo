using GradeBookMicroservice.Domain.Entities;
using GradeBookMicroservice.Domain.Repositories.Abstractions;
using GradeBookMicroservice.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace GradeBookMicroservice.Infrastructure.Repositories.Implementations.Ef;

public class EfGroupRepository(ApplicationDbContext context) : EfRepository<Group, Guid>(context), IGroupsRepository
{
    public Task<Group?> GetGroupByNameAsync(string name) => context.Groups.FirstOrDefaultAsync(group => group.Name.Equals(name));
    public override async Task<Group?> GetByIdAsync(Guid id)
    {
        var group = await context.Groups.FindAsync(id);
        if (group is null)
            return null;
        await context.Entry(group).Collection(group => group.Students).LoadAsync();
        return group;
    }
}
