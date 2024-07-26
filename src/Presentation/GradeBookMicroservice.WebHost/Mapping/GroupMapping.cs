using AutoMapper;
using GradeBookMicroservice.Application.Models;
using GradeBookMicroservice.Application.Models.Create;
using GradeBookMicroservice.WebHost.Requests.Group;
using GradeBookMicroservice.WebHost.Responses.Group;

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
