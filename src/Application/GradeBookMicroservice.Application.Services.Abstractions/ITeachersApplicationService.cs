using GradeBookMicroservice.Application.Models.Teacher;

namespace GradeBookMicroservice.Application.Services.Abstractions;

public interface ITeachersApplicationService
{
    Task<TeacherModel?> GetTeacherByIdAsync(Guid id);
    Task<IEnumerable<TeacherModel>> GetTeachersAsync();
    Task<TeacherModel?> CreateTeacherAsync(CreateTeacherModel teacherInformation);
    Task UpdateTeacherAsync(TeacherModel teacher);
    Task DeleteTeacherAsync(Guid id);

}
