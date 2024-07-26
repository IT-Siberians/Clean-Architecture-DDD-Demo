using GradeBookMicroservice.Application.Models;
using GradeBookMicroservice.Application.Models.Create;

namespace GradeBookMicroservice.Application.Services;

public interface IGoupsApplicationService
{
    Task<IEnumerable<GroupModel>> GetAllGroupsAsync();
    Task<GroupModel> GetGroupByIdAsync(Guid id);
    Task<GroupModel?> CreateGroupAsync(CreateGroupModel groupInfo);
    Task UpdateGroupAsync(GroupModel group);
    Task DeleteGroupAsync(Guid id);

}
