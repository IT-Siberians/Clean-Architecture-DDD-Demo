using GradeBookMicroservice.Application.Models;
using GradeBookMicroservice.Application.Models.Create;

namespace GradeBookMicroservice.Application.Services.Base;

public interface IGroupsApplicationService
{
    Task<IEnumerable<GroupModel>> GetAllGroupsAsync();
    Task<GroupModel?> GetGroupByIdAsync(Guid id);
    Task<GroupModel?> GetGroupByNameAsync(string name);
    Task<GroupModel?> CreateGroupAsync(CreateGroupModel groupInfo);
    Task UpdateGroupAsync(GroupModel group);
    Task DeleteGroupAsync(Guid id);

}
