using AutoMapper;
using GradeBookMicroservice.Application.Models;
using GradeBookMicroservice.Application.Models.Create;

namespace GradeBookMicroservice.WebHost.Mapping;

public class GroupMapping : Profile
{
    public GroupMapping()
    {
        CreateMap<CreateGroupRequest, CreateGroupModel>();
        CreateMap<GroupModel, GroupShortResponse>();
        CreateMap<GroupModel, GroupDetailedResponse>();
    }

}
