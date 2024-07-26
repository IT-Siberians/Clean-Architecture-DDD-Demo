using GradeBookMicroservice.Domain.Entities;

namespace GradeBookMicroservice.Domain.Repositories.Abstractions;

public interface IGroupsRepository : IRepository<Group, Guid>
{
    Task<Group?> GetGroupByNameAsync(string name);

}
