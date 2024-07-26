using GradeBookMicroservice.Application.Models;
using GradeBookMicroservice.Application.Models.Create;

namespace GradeBookMicroservice.Application.Services.Base;

public interface ITeachersApplicationService
{
    Task<TeacherModel?> GetTeacherByIdAsync(Guid id);
    Task<IEnumerable<TeacherModel>> GetTeachersAsync();
    Task<TeacherModel?> CreateTeacherAsync(CreateTeacherModel teacherInformation);
    Task UpdateTeacherAsync(TeacherModel teacher);
    Task DeleteTeacherAsync(Guid id);

}
