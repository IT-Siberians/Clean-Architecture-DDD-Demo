using AutoMapper;
using GradeBookMicroservice.Application.Models.Grade;
using GradeBookMicroservice.Domain.Entities;

namespace GradeBookMicroservice.Application.Services.Mapping;

public class GradeMapping : Profile
{
    public GradeMapping()
    {
        CreateMap<Grade, GradeModel>();
    }
    
}