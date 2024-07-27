using AutoMapper;
using GradeBookMicroservice.Application.Models.Group;
using GradeBookMicroservice.Application.Services.Base;
using GradeBookMicroservice.Domain.Entities;
using GradeBookMicroservice.Domain.Repositories.Abstractions;
using GradeBookMicroservice.Domain.ValueObjects;

namespace GradeBookMicroservice.Application.Services;

public class GroupsApplicationService(IGroupsRepository repository, IMapper mapper) : IGroupsApplicationService
{

    public async Task<GroupModel?> CreateGroupAsync(CreateGroupModel groupInfo)
    {
        if(await repository.GetGroupByNameAsync(groupInfo.Name)!=null)
            return null;
        var group = new Group(new GroupName(groupInfo.Name), groupInfo.Description);
        await repository.AddAsync(group);
        return mapper.Map<GroupModel>(group);
    }

    public async Task DeleteGroupAsync(Guid id)
    {
        var group = await repository.GetByIdAsync(id);
        if(group==null)
            return;
        await repository.DeleteAsync(group);
    }

    public async Task<IEnumerable<GroupModel>> GetAllGroupsAsync() 
                => (await repository.GetAllAsync()).Select(mapper.Map<GroupModel>);


    public async Task<GroupModel?> GetGroupByIdAsync(Guid id)
    {
        var group = await repository.GetByIdAsync(id);
        return group == null ? null : mapper.Map<GroupModel>(group);
    }

    public async Task<GroupModel?> GetGroupByNameAsync(string name)
    {
        var group = await repository.GetGroupByNameAsync(name);
        return group == null ? null : mapper.Map<GroupModel>(group);
    }

    public async Task UpdateGroupAsync(GroupModel group)
    {
        var entity = await repository.GetByIdAsync(group.Id);
        if(entity==null)
            return;
        var model = mapper.Map<Group>(group);
        await repository.UpdateAsync(model);
    
    }
}
