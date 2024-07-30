using GradeBookMicroservice.Application.Models.Group;

namespace GradeBookMicroservice.Application.Services.Abstractions;

public interface IGroupsApplicationService
{
    Task<IEnumerable<GroupModel>> GetAllGroupsAsync();
    Task<GroupModel?> GetGroupByIdAsync(Guid id);
    Task<GroupModel?> GetGroupByNameAsync(string name);
    Task<GroupModel?> CreateGroupAsync(CreateGroupModel groupInfo);
    Task UpdateGroupAsync(GroupModel group);
    Task DeleteGroupAsync(Guid id);
}
