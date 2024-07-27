using AutoMapper;
using GradeBookMicroservice.Application.Models.Teacher;
using GradeBookMicroservice.Application.Services.Base;
using GradeBookMicroservice.Domain.Entities;
using GradeBookMicroservice.Domain.Repositories.Abstractions;
using GradeBookMicroservice.Domain.ValueObjects;

namespace GradeBookMicroservice.Application.Services;

public class TeachersApplicationService(IRepository<Teacher, Guid> repository, IMapper mapper) : ITeachersApplicationService
{
    public async Task<TeacherModel?> CreateTeacherAsync(CreateTeacherModel teacherInformation)
    {
        var teacher = new Teacher(new PersonName(teacherInformation.Name));
        teacher = await repository.AddAsync(teacher);
        if(teacher is null)
            return null;
        return mapper.Map<TeacherModel>(teacher);

    }

    public async Task DeleteTeacherAsync(Guid id)
    {
        var teacher = await repository.GetByIdAsync(id);
        if(teacher is null)
            return;
        await repository.DeleteAsync(teacher);
    }

    public async Task<TeacherModel?> GetTeacherByIdAsync(Guid id)
    {
        var teacher = await repository.GetByIdAsync(id);
        if(teacher is null)
            return null;
        return mapper.Map<TeacherModel>(teacher);
    }

    public async Task<IEnumerable<TeacherModel>> GetTeachersAsync() 
            => (await repository.GetAllAsync()).Select(mapper.Map<TeacherModel>);


    public async Task UpdateTeacherAsync(TeacherModel teacher)
    {
        var entity = await repository.GetByIdAsync(teacher.Id);
        if(entity is null)
            return;
        entity = mapper.Map<Teacher>(teacher);
        await repository.UpdateAsync(entity);
    }
}
