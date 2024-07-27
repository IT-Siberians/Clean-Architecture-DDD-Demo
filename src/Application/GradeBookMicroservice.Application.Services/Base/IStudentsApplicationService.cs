using GradeBookMicroservice.Application.Models.Create;
using GradeBookMicroservice.Application.Models.Student;


namespace GradeBookMicroservice.Application.Services;

public interface IStudentsApplicationService
{
    Task<IEnumerable<StudentModel>> GetAllStudentsAsync();
    Task<StudentModel?> GetStudentByIdAsync(Guid id);
    Task<StudentModel?> AddStudentAsync(CreateStudentModel studentInfo);
    Task UpdateStudent(StudentModel student);
    Task DeleteStudent(Guid id);
}
