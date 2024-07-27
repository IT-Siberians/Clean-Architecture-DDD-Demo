using AutoMapper;
using GradeBookMicroservice.Application.Models.Group;
using GradeBookMicroservice.Domain.Entities;


namespace GradeBookMicroservice.Application.Services.Mapping;
public class GroupMapping : Profile
{
    public GroupMapping()
    {
        CreateMap<CreateGroupModel, Group>();
        CreateMap<Group, GroupModel>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.Name));
    
    }

}