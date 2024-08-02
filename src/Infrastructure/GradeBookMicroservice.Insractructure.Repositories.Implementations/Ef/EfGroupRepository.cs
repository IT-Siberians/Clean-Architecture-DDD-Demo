using GradeBookMicroservice.Domain.Entities;
using GradeBookMicroservice.Domain.Repositories.Abstractions;
using GradeBookMicroservice.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace GradeBookMicroservice.Infrastructure.Repositories.Implementations.Ef;

public class EfGroupRepository(ApplicationDbContext context) : EfRepository<Group, Guid>(context), IGroupsRepository
{
    public Task<Group?> GetGroupByNameAsync(string name) => context.Groups.FirstOrDefaultAsync(group => group.Name.Equals(name));
    public override Task<Group?> GetByIdAsync(Guid id) => context.Set<Group>().Include(c => c.Students).FirstOrDefaultAsync(group => group.Id.Equals(id));

}
