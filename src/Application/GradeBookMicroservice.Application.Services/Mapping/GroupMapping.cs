using AutoMapper;
using GradeBookMicroservice.Application.Models;
using GradeBookMicroservice.Application.Models.Create;
using GradeBookMicroservice.Domain.Entities;
using GradeBookMicroservice.Domain.ValueObjects;

namespace GradeBookMicroservice.Application.Services.Mapping;
public class GroupMapping : Profile
{
    public GroupMapping()
    {
        CreateMap<CreateGroupModel, Group>();
        CreateMap<Group, GroupModel>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.Name));
    
    }

}