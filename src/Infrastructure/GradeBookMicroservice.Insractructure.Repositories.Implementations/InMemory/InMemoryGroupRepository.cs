using GradeBookMicroservice.Domain.Entities;
using GradeBookMicroservice.Domain.Repositories.Abstractions;

namespace GradeBookMicroservice.Infractructure.Repositories.Implementations.InMemory;

public class InMemoryGroupRepository(IEnumerable<Group> groups) : InMemoryRepository<Group, Guid>(groups), IGroupsRepository
{
    public InMemoryGroupRepository() : this([])
    {
        
    }
    public Task<Group?> GetGroupByNameAsync(string name) => Task.FromResult(Entities.FirstOrDefault(x => x.Name.Name == name));

}
